using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_Manager
{
    public partial class Form1 : Form
    {
        public static Listing listing = new Listing();
        public List<Programs> selectedPrograms = new List<Programs>();
        int j;

        public CheckBox[] checkBoxes = new CheckBox[100];
        public Label[] labels = new Label[100];
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
                checkBoxes[i] = new CheckBox();
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
                if (checkBoxes[i].Text == ((CheckBox)sender).Text)
                {
                    // Set the description text box
                    descriptionTextBox.Text = ((CheckBox)sender).Text + "\n\n" + listing.programs[i].desc + "\n\n" + listing.programs[i].url;

                    // Add to list of selected programs
                    selectedPrograms.Add(listing.programs[i]);
                    int k = 0;
                    for (int j = 0; j < selectedPrograms.Count; j++)
                    {
                        labels[j] = new Label();
                        labels[j].AutoSize = true;
                        // Name = Category
                        // Text = Program name
                        labels[j].Text = listing.programs[i].name;
                        labels[j].Visible = true;
                        // Resets Y-position if new category

                        // Position relative to the panel
                        labels[j].Location = new Point(3, (3 + k * 20));
                        // Increase position variable
                        k++;
                        selectedPanel.Controls.Add(labels[j]);
                    }
                }
            }

        }
    }
}
