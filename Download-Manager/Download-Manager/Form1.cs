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
        Listing listing = new Listing();
        public Form1()
        {
            InitializeComponent();
            listing.InitializeCategories();
            listing.InitializeBrowsers();

            CreateCategories();
            CreateBrowsers();
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
        private void CreateBrowsers()
        {
            CheckBox[] checkBoxes = new CheckBox[listing.browsers.Count];

            for (int i = 0; i < listing.browsers.Count; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].AutoSize = true;
                // Position relative to the panel
                checkBoxes[i].Location = new Point(3, (3 + i * 20));
                checkBoxes[i].Name = listing.browsers[i].name;
                checkBoxes[i].TabIndex = 0;
                checkBoxes[i].Text = listing.browsers[i].name;
                checkBoxes[i].UseVisualStyleBackColor = true;
                checkBoxes[i].Cursor = Cursors.Hand;
                checkBoxes[i].Click += new EventHandler(checkBoxes_Click);

                programsPanel.Controls.Add(checkBoxes[i]);
            }
        }

        /// <summary>
        /// Triggered when a radiobutton in the categories is changed
        /// </summary>
        private void radioButtons_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((RadioButton)sender).Name + " is selected");
        }

        /// <summary>
        /// Triggered when a checkbox in the programs is changed
        /// </summary>
        private void checkBoxes_Click(object sender, EventArgs e)
        {
            // Need to make this more universal, currently only works with browsers.
            // Alternative: One void for each type of program.
            string programDesc = "";
            // Get description
            for (int i = 0; i < listing.browsers.Count; i++)
            {
                if (listing.browsers[i].name == ((CheckBox)sender).Name)
                {
                    programDesc = listing.browsers[i].desc;
                }
            }
            // Set the description text box
            descriptionTextBox.Text = ((CheckBox)sender).Name + "\n\n" + programDesc;
        }
    }
}
