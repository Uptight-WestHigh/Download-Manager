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
            WebClient webClient = new WebClient();

            // Check for missing files.
            if (!File.Exists("Categories.config"))
            {
                DialogResult dialogResult = MessageBox.Show("The Categories.config file is missing. The Program will not work without this file. Press OK to download the missing file.", "Error: Missing file", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Categories.Config", "Categories.Config");
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                }
            }
            if (!File.Exists("Programs.config"))
            {
                DialogResult dialogResult = MessageBox.Show("The Programs.config file is missing. The Program will not work without this file. Please download the program again.", "Error: Missing file", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    webClient.DownloadFile("http://snaxdax.tk/downloadFiles/Programs.Config", "Programs.Config");
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
