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
            if (!File.Exists("Categories.config") || !File.Exists("Programs.config"))
            {
                // Display error stating that the file is missing
                // Ask to download the missing file from the server
                DialogResult dialogResult = MessageBox.Show("A config file is missing. This is normal if it is the first time starting the program. The program will not work without this file.\nPress OK to download the missing file(s).",
                    "Error: Missing file",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                // If the OK button is pressed on the dialog
                if (dialogResult == DialogResult.OK)
                {
                    // Download the file from the server
                    DownloadManagerForm.UpdateConfig();
                }
                // Else if the Cancel button is pressed on the dialog
                else if (dialogResult == DialogResult.Cancel)
                {
                    // Exit the application to prevent crashes
                    Application.Exit();
                }
            }

            // If both files now exist, return false (no files missing)
            return (File.Exists("Categories.config") && File.Exists("Programs.config")) ? false : true;
        }
    }
}
