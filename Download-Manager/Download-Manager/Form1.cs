using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace Download_Manager
{
    public partial class Form1 : Form
    {
        public static Listing listing = new Listing();
        public List<Programs> selectedPrograms = new List<Programs>();
        int j;

        public List<CheckBox> checkBoxes = new List<CheckBox>();
        public List<Label> labels = new List<Label>();

        string downloadSite = "http://snaxdax.tk/downloadFiles/";
        WebClient webClient = new WebClient();
        int i = 0;
        string saveTo = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
            listing.InitializeCategories();
            listing.InitializePrograms();

            CreateCategories();
            CreatePrograms();
        }

        /// <summary>
        /// Creates all the categories
        /// </summary>
        private void CreateCategories()
        {
            RadioButton[] radioButtons = new RadioButton[listing.categories.Count];

            for (int i = 0; i < listing.categories.Count; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].AutoSize = true;
                // Position relative to the panel
                radioButtons[i].Location = new Point(3, (2 + i * 20));
                radioButtons[i].Margin = new Padding(2, 2, 2, 2);
                radioButtons[i].Name = listing.categories[i].name;
                radioButtons[i].TabIndex = 12;
                radioButtons[i].TabStop = true;
                radioButtons[i].Text = listing.categories[i].name;
                radioButtons[i].UseVisualStyleBackColor = true;
                radioButtons[i].Cursor = Cursors.Hand;
                radioButtons[i].Click += new EventHandler(radioButtons_Click);

                categoriesPanel.Controls.Add(radioButtons[i]);
            }
        }

        /// <summary>
        /// Creates all the browsers checkboxes
        /// </summary>
        private void CreatePrograms()
        {
            for (int i = 0; i < listing.programs.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                checkBoxes[i].AutoSize = true;
                // Name = Category
                checkBoxes[i].Name = listing.programs[i].category;
                checkBoxes[i].TabIndex = 0;
                // Text = Program name
                checkBoxes[i].Text = listing.programs[i].name;
                checkBoxes[i].UseVisualStyleBackColor = true;
                checkBoxes[i].Cursor = Cursors.Hand;
                checkBoxes[i].Click += new EventHandler(checkBoxes_Click);
                checkBoxes[i].Visible = false;
                // Resets Y-position if new category
                if (i != 0 && checkBoxes[i - 1].Name != checkBoxes[i].Name)
                {
                    j = 0;
                }
                // Position relative to the panel
                checkBoxes[i].Location = new Point(3, (3 + j * 20));
                // Increase position variable
                j++;
                programsPanel.Controls.Add(checkBoxes[i]);
            }
        }

        /// <summary>
        /// Triggered when a radiobutton in the categories is changed
        /// </summary>
        private void radioButtons_Click(object sender, EventArgs e)
        {
            // Go through all of the checkboxes
            for (int i = 0; i < listing.programs.Count; i++)
            {
                // If the checkbox name (category) matches the radiobutton name
                if (checkBoxes[i].Name == ((RadioButton)sender).Name)
                {
                    // Display them
                    checkBoxes[i].Visible = true;
                }
                else
                {
                    // Hide them
                    checkBoxes[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// Triggered when a checkbox in the programs is changed
        /// </summary>
        private void checkBoxes_Click(object sender, EventArgs e)
        {
            // Get description
            for (int i = 0; i < listing.programs.Count; i++)
            {
                // If the checkbox matches the sending object
                if (checkBoxes[i].Text == ((CheckBox)sender).Text)
                {
                    // Set the description
                    descriptionTextBox.Text = ((CheckBox)sender).Text + "\n\n" + listing.programs[i].desc;
                    // If the program has not been added to the list yet
                    if (!listing.programs[i].added)
                    {
                        // Remove all programs in the list
                        // To clear and replace with the programs still left.
                        for (int i2 = 0; i2 < selectedPrograms.Count; i2++)
                        {
                            selectedPanel.Controls.RemoveAt(0);
                        }

                        // Add current program to the list of selected programs
                        selectedPrograms.Add(listing.programs[i]);
                            int k = 0;

                        // For each of the selected programs
                        for (int j = 0; j < selectedPrograms.Count; j++)
                        {

                            labels.Add(new Label());
                            labels[j].AutoSize = true;
                            // Text = Program name
                            labels[j].Text = selectedPrograms[j].name;
                            labels[j].Visible = true;
                            // Resets Y-position if new category

                            // Position relative to the panel
                            labels[j].Location = new Point(3, (3));
                            // Increase position variable
                            k++;
                            selectedPanel.Controls.Add(labels[j]);
                            listing.programs[i].added = true;
                        }
                    }
                    // If the program alreadt exists in the list, remove it.
                    else if (listing.programs[i].added)
                    {
                        // For each of the selected programs
                        for (int j = 0; j < selectedPrograms.Count; j++)
                        {
                            // Get the program list id that matches the program name
                            int programListId = GetProgramListID(listing.programs[i].name);
                            // If nothing is returned, stop
                            if (programListId < 0)
                                return;
                             
                            // Remove the program from the list
                            selectedPrograms.RemoveAt(programListId);
                            // Set the "added" variable to false
                            listing.programs[i].added = false;
                            // Remove the selected program list item
                            selectedPanel.Controls.RemoveAt(programListId);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Get the list item ID that matches the checkbox
        /// </summary>
        private int GetProgramListID(string name)
        {
            for (int i = 0; i < selectedPrograms.Count; i++)
            {
                if (selectedPrograms[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Download every selected object
        /// </summary>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            DownloadItems();
        }

        private void DownloadItems()
        {
            if (i < selectedPrograms.Count)
            {
                MessageBox.Show("Currently downloading " + selectedPrograms[i].name + "\nURL: " + downloadSite + selectedPrograms[i].url);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(downloadSite + selectedPrograms[i].url), saveTo + selectedPrograms[i].url);
                i++;
            }
        }

        /// <summary>
        /// Changes the value of the progressbar to show download progress.
        /// </summary>
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            float bytesIn = float.Parse(e.BytesReceived.ToString());
            float totalBytes = float.Parse(e.TotalBytesToReceive.ToString());
            float percentage = bytesIn / totalBytes * 100f;
            float bytesRecieved = e.BytesReceived / 1048576f;
            float bytesToRecieve = e.TotalBytesToReceive / 1048576f;
            // Displays the current status.
            // Downloading (ProgramName), (BytesRecieved) / (BytesToRecieve), (Speed), (Done) / (Total)
            label2.Text = "Downloading " + selectedPrograms[i-1].name + ", " + bytesRecieved.ToString("0.##") + "MB / " + bytesToRecieve.ToString("0.##") + "MB, ";
            downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            label1.Text = Convert.ToString(int.Parse(Math.Truncate(percentage).ToString())) + "%";
        }

        /// <summary>
        /// Called when the download is finished.
        /// Opens the Windows Explorer to the download location.
        /// </summary>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(saveTo);
            DownloadItems();
        }

        private void descriptionTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //RichTextBox linkBox = (RichTextBox)sender;
            //for (int i = 0; i < listing.programs.Count; i++)
            //{
            //    if (listing.programs[i].text = linkBox.Name)
            //}
            //ProcessStartInfo sInfo = new ProcessStartInfo(listing.programs[i].url);
            //Process.Start(sInfo);
        }
    }
}
