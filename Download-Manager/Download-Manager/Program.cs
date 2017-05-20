using System;
using System.Windows.Forms;
using System.IO;

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
            if (!File.Exists("Categories.config"))
            {
                MessageBox.Show("The Categories.config file is missing. The Program will not work without this file. Please download the program again.", "Error: Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            if (!File.Exists("Programs.config"))
            {
                MessageBox.Show("The Categories.config file is missing. The Program will not work without this file. Please download the program again.", "Error: Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
