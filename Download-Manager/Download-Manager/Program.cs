using System;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Download_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Prevent crashing by checking if the 
            // configuration files are missing
            // If it returns true, close
            if (CheckFilesMissing())
                Application.Exit();

            // If the files are not missing, start the form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DownloadManagerForm());
        }

        /// <summary>
        /// Checks if the required configuration files are missing
        /// If they are, download them
        /// If unable to download them, close
        /// </summary>
        static bool CheckFilesMissing()
        {
            // Create a WebClient object
            WebClient webClient = new WebClient();

            // Check if Categories.config doesn't exist
            if (!File.Exists("Categories.config"))
            {
                // Display error stating that the file is missing
                // Ask to download the missing file from the server
                DialogResult dialogResult = MessageBox.Show("The Categories.config file is missing. The Program will not work without this file. Press OK to download the missing file.",
                    "Error: Missing file",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                // If the OK button is pressed on the dialog
                if (dialogResult == DialogResult.OK)
                {
                    // Download the file from the server
                    webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Categories.Config", "Categories.Config");
                }
                // Else if the Cancel button is pressed on the dialog
                else if (dialogResult == DialogResult.Cancel)
                {
                    // Exit the application to prevent crashes
                    Application.Exit();
                }
            }

            // Check if Programs.config is missing
            if (!File.Exists("Programs.config"))
            {
                // Display error stating that the file is missing
                // Ask to download the missing file from the server
                DialogResult dialogResult = MessageBox.Show("The Programs.config file is missing. The Program will not work without this file. Please download the program again.",
                    "Error: Missing file",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                // If the OK button is pressed on the dialog
                if (dialogResult == DialogResult.OK)
                {
                    // Download the file from the server
                    webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Programs.Config", "Programs.Config");
                }
                // Else if the Cancel button is pressed on the dialog
                else if (dialogResult == DialogResult.Cancel)
                {
                    // Exit the application to prevent crashes
                    Application.Exit();
                }
            }

            // If both files now exist, return false (no files missing)
            if (File.Exists("Categories.config") && File.Exists("Programs.config"))
                return false;
            // If any of them is missing, return true (files missing)
            else
                return true;
        }
    }
}
