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
    public partial class DownloadManagerForm : Form
    {
        public static Listing listing = new Listing();
        public List<Programs> selectedPrograms = new List<Programs>();

        public List<CheckBox> checkBoxes = new List<CheckBox>();
        public List<Label> labels = new List<Label>();

        WebClient webClient;

        string downloadSite = "https://filipdev.000webhostapp.com/downloadmanager/";
        int dc = 0;
        string saveTo = Directory.GetCurrentDirectory();
        Stopwatch sw = new Stopwatch();

        public DownloadManagerForm()
        {
            InitializeComponent();
            listing.InitializeCategories();
            listing.InitializePrograms();

            CreateCategories();
            CreatePrograms();
        }

        #region Creating
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
            int j = 0;
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
        #endregion

        #region Radiobutton / Checkbox clicking
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
                        selectedPanel.Controls.Clear();

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
            if (selectedPrograms.Count > 0)
                downloadButton.Enabled = true;
            else
                downloadButton.Enabled = false;

        }
        #endregion

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

        #region Downloading
        /// <summary>
        /// Download every selected object
        /// </summary>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                saveTo = folderBrowserDialog1.SelectedPath;
            }
            else
                return;

            if (!Directory.Exists(saveTo + "/Setups/"))
                Directory.CreateDirectory(saveTo + "/Setups/");
            statusLabel.Text = "Initializing download.";
            // Disable the button to prevent errors
            downloadButton.Enabled = false;
            programsPanel.Enabled = false;
            descriptionTextBox.Enabled = false;
            // Start the Downloading method
            DownloadItems();
        }

        /// <summary>
        /// Downloads the selected items
        /// </summary>
        private void DownloadItems()
        {
            // Create new webclient
            // This was the solution to downloading several installers
            webClient = new WebClient();

            if (dc < selectedPrograms.Count)
            {
                if (!webClient.IsBusy)
                {
                    Debug.WriteLine("Downloading " + selectedPrograms[dc].url);
                    sw.Start();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(downloadSite + selectedPrograms[dc].category + "/" + selectedPrograms[dc].url), saveTo + "/Setups/" + selectedPrograms[dc].url);
                    dc++;
                }
                else
                {
                    webClient.CancelAsync();
                    DownloadItems();
                }
            }
            else
            {
                Debug.WriteLine("All files downloaded. Open explorer.");
                statusLabel.Text = "All files downloaded.";
                Process.Start(saveTo + "/Setups/");

                Close();
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
            double byteSpeed = e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds;   // Calculate download speed

            // Displays the current status.
            // Downloading (ProgramName), (BytesRecieved) / (BytesToRecieve), (Speed), (Done) / (Total)
            statusLabel.Text = "Downloading " + selectedPrograms[dc-1].name + ", "                            // Display name
                + bytesRecieved.ToString("0.00") + "MB / " + bytesToRecieve.ToString("0.00") + "MB, "   // Display bytes downloaded / total
                + string.Format("{0} kb/s", (byteSpeed).ToString("0.00")) + ", "                        // Display download speed
                + dc + " / " + selectedPrograms.Count + " downloaded.";                                  // Display amount of programs downloaded / total
            downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());                // Set the value of the progressbar
            percentLabel.Text = Convert.ToString(int.Parse(Math.Truncate(percentage).ToString())) + "%";      // Display percentage done
            Debug.Write(Convert.ToString(int.Parse(Math.Truncate(percentage).ToString())) + "% ");
        }

        /// <summary>
        /// Called when the download is finished.
        /// Opens the Windows Explorer to the download location.
        /// </summary>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Debug.WriteLine(selectedPrograms[dc - 1].name + " downloaded.");
            // Reset the stopwatch
            sw.Reset();
            // Display what program was just completed
            statusLabel.Text = selectedPrograms[dc - 1].name + " downloaded.";
            // Remove the downlaoded item label from the selected panel
            selectedPanel.Controls.RemoveAt(0);
            // Start the download again
            DownloadItems();
        }

        /// <summary>
        /// If you press the X in the top right of the window
        /// Stops the program from closing, asks for confirmation
        /// </summary>
        private void DownloadManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display a message
            // Ask for confirmation
            if (dc < selectedPrograms.Count)
            {
                var result = MessageBox.Show("Are you sure that you want to close the program? \nAll unfinished downloads will be lost.", "Confirmation",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button2);

                // If the answer is "no", stop the program from exiting.
                e.Cancel = (result == DialogResult.No);
            }
        }
        #endregion

        #region Toolstrip Buttons

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to download new configuration files? This may give you an updated list of programs.", 
                "Information", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                UpdateConfig();
                MessageBox.Show("New configuration files downloaded. The program will now restart.", "Download complete", MessageBoxButtons.OK, MessageBoxIcon.None);
                Application.Restart();
            }
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Choose any of the categories in the panel to the left. This will display the corresponding programs in the programs panel.\n\n When choosing a program from the programs panel, notice how information about the program is displayed and that the program is added to the selected programs list to the right. Click on a program again to remove it from the list.\n\nTo start the download, press the download button at the bottom right. This will first display a dialogue, asking for a download location. After it will sequentially download all of the selected programs. Information about the download will be displayed at the bottom.",
            "Help",
            MessageBoxButtons.OK,
            MessageBoxIcon.Question);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "All software installers were downloaded from their respective official websites. The setups are stored and downloaded by this client from http://snaxdax.tk. \n\nAll featured software is free to download and the installers are exactly the same as those from the official sources. All rights go to the respective publishers and owners.\n\nIf you do not approve of your software being included here, please contact us.\n\nThe program is made with .NET and Windows Forms. It uses the built-in WebClient class to download the selected files.\n© 2003 Microsoft Corporation\n\nDesigned and written by Filip Bergkvist, 2017", 
                "About Download-Manager", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        public static void UpdateConfig()
        {
            WebClient webClient = new WebClient();

            if (File.Exists("Categories.Config"))
                File.Delete("Categories.Config");
            if (File.Exists("Programs.Config"))
                File.Delete("Programs.Config");

            webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Categories.Config", "Categories.Config");
            webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Programs.Config", "Programs.Config");
        }

        #endregion
    }
}
