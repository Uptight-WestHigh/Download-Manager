using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Download_Manager
{
    public class Download
    {
        string saveTo = Directory.GetCurrentDirectory();
        string downloadSite = "http://www.snaxdax.tk/downloadFiles/";
        WebClient webClient = new WebClient();
        ProgressBar downloadProgressBar;

        /// <summary>
        /// Constructor. Passes the progressbar
        /// </summary>
        public Download(ProgressBar progressBar)
        {
            downloadProgressBar = progressBar;
        }

        /// <summary>
        /// Starts the download. Programs
        /// </summary>
        public void DownloadItems(List<Programs> selectedPrograms)
        {
            for (int i = 0; i < selectedPrograms.Count; i++)
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(downloadSite + selectedPrograms[i].url), saveTo);
                MessageBox.Show("Currently downloading " + selectedPrograms[i].name + "\nURL: " + downloadSite + selectedPrograms[i].url);
            }
        }

        /// <summary>
        /// Called when the download is finished.
        /// Opens the Windows Explorer to the download location.
        /// </summary>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(saveTo);
        }

        /// <summary>
        /// Changes the value of the progressbar to show download progress.
        /// </summary>
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgressBar.Value = e.ProgressPercentage;
        }

    }
}
