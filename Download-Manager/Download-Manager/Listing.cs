using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_Manager
{
    public class Listing
    {
        // List of categories
        public List<Category> categories = new List<Category>();

        // Array of category names
        public string[] categoryName = new string[] 
        {   "Web Browsers",
            "File Sharing",
            "Compression",
            "Messaging",
            "Online Storage",
            "Media",
            "Runtimes",
            "Other",
            "Imaging",
            "Developer Tools",
            "Documents",
            "Utilities",
            "Security"
        };

        /// <summary>
        /// Add the categories to the list
        /// </summary>
        public void InitializeCategories()
        {
            for (int i = 0; i < categoryName.Length; i++)
            {
                // Name, ID
                // ID may become obsolete
                Category category = new Category(categoryName[i], i);
                categories.Add(category);
            }
        }

        // List of programss
        public List<Programs> programs = new List<Programs>();

        /// <summary>
        /// Add the programs to the list
        /// </summary>
        public void InitializePrograms()
        {
            int i = 0;

            // Name, ID, Category, Description, URL

            // Web browsers
            programs.Add(new Programs("Google Chrome", i, "Web Browsers", "The world's most popular web browser.", "http://dl.google.com/tag/s/appguid=%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D&iid=%7BB7F9A059-3A71-F0A8-67CB-8C83969F881C%7D&lang=en-IN&browser=3&usagestats=0&appname=Google%20Chrome&needsadmin=false/update2/installers/ChromeStandaloneSetup.exe")); i++;
            programs.Add(new Programs("Mozilla Firefox", i, "Web Browsers", "", "")); i++;
            programs.Add(new Programs("Opera", i, "Web Browsers", "", "")); i++;
            programs.Add(new Programs("Microsoft Edge", i, "Web Browsers", "", "")); i++;
            programs.Add(new Programs("Vivaldi", i, "Web Browsers", "", "")); i++;
            programs.Add(new Programs("Safari", i, "Web Browsers", "", "")); i++;

            // File Sharing
            programs.Add(new Programs("qBittorrent", i, "File Sharing", "", "")); i++;
            programs.Add(new Programs("eMule", i, "File Sharing", "", "")); i++;

            // Compression
            programs.Add(new Programs("7-zip", i, "Compression", "", "")); i++;
            programs.Add(new Programs("PeaZip", i, "Compression", "", "")); i++;
            programs.Add(new Programs("WinRar", i, "Compression", "", "")); i++;

            // Messaging
            programs.Add(new Programs("Skype", i, "Messaging", "", "")); i++;
            programs.Add(new Programs("Pidgin", i, "Messaging", "", "")); i++;
            programs.Add(new Programs("Thunderbird", i, "Messaging", "", "")); i++;
            programs.Add(new Programs("Trillian", i, "Messaging", "", "")); i++;
            programs.Add(new Programs("AIM", i, "Messaging", "", "")); i++;

            // Online Storage
            programs.Add(new Programs("Dropbox", i, "Online Storage", "", "")); i++;
            programs.Add(new Programs("Google Drive", i, "Online Storage", "", "")); i++;
            programs.Add(new Programs("Mozy", i, "Online Storage", "", "")); i++;
            programs.Add(new Programs("OneDrive", i, "Online Storage", "", "")); i++;
            programs.Add(new Programs("SugarSync", i, "Online Storage", "", "")); i++;

            // Media
            programs.Add(new Programs("iTunes", i, "Media", "", "")); i++;
            programs.Add(new Programs("VLC", i, "Media", "", "")); i++;
            programs.Add(new Programs("AIMP", i, "Media", "", "")); i++;
            programs.Add(new Programs("foobar2000", i, "Media", "", "")); i++;
            programs.Add(new Programs("Winamp", i, "Media", "", "")); i++;
            programs.Add(new Programs("Audacity", i, "Media", "", "")); i++;
            programs.Add(new Programs("K-Lite Codecs", i, "Media", "", "")); i++;
            programs.Add(new Programs("GOM", i, "Media", "", "")); i++;
            programs.Add(new Programs("CCCP", i, "Media", "", "")); i++;
            programs.Add(new Programs("MediaMonkey", i, "Media", "", "")); i++;
            programs.Add(new Programs("HandBrake", i, "Media", "", "")); i++;

            // Runtimes
            programs.Add(new Programs("Java 8", i, "Runtimes", "", "")); i++;
            programs.Add(new Programs(".NET 4.6.2", i, "Runtimes", "", "")); i++;
            programs.Add(new Programs("Silverlight", i, "Runtimes", "", "")); i++;
            programs.Add(new Programs("Air", i, "Runtimes", "", "")); i++;
            programs.Add(new Programs("Shockwave", i, "Runtimes", "", "")); i++;

            // Other
            programs.Add(new Programs("Evernote", i, "Other", "", "")); i++;
            programs.Add(new Programs("Google Earth", i, "Other", "", "")); i++;
            programs.Add(new Programs("Steam", i, "Other", "", "")); i++;
            programs.Add(new Programs("KeePass 2", i, "Other", "", "")); i++;
            programs.Add(new Programs("Everything", i, "Other", "", "")); i++;
            programs.Add(new Programs("NV Access", i, "Other", "", "")); i++;

            // Imaging
            programs.Add(new Programs("Paint.NET", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("GIMP", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("IrfanView", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("XnView", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("InkScape", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("FastStone", i, "Imaging", "", "")); i++;
            programs.Add(new Programs("ShareX", i, "Imaging", "", "")); i++;

            // Developer Tools
            programs.Add(new Programs("Python", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("FileZilla", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("Notepad++", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("JDK 8", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("JDK x64 8", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("WinSCP", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("PuTTY", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("WinMerge", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("Eclipse", i, "Developer Tools", "", "")); i++;
            programs.Add(new Programs("Visual Studio", i, "Developer Tools", "", "")); i++;

            // Documents
            programs.Add(new Programs("Foxit Reader", i, "Documents", "", "")); i++;
            programs.Add(new Programs("Libreoffice", i, "Documents", "", "")); i++;
            programs.Add(new Programs("SumatraPDF", i, "Documents", "", "")); i++;
            programs.Add(new Programs("CutePDF", i, "Documents", "", "")); i++;
            programs.Add(new Programs("PDFCreator", i, "Documents", "", "")); i++;
            programs.Add(new Programs("OpenOffice", i, "Documents", "", "")); i++;

            // Utilities
            programs.Add(new Programs("Teamwiever 12", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("ImgBurn", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("RealVNC", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("TeraCopy", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("CDBurnerXP", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("Revo", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("Launchy", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("WinDirStat", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("Glary", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("InfraRecorder", i, "Utilities", "", "")); i++;
            programs.Add(new Programs("Classic Start", i, "Utilities", "", "")); i++;

            // Security
            programs.Add(new Programs("Microsoft Essentials", i, "Security", "", "")); i++;
            programs.Add(new Programs("Avast", i, "Security", "", "")); i++;
            programs.Add(new Programs("AVG", i, "Security", "", "")); i++;
            programs.Add(new Programs("Malwarebytes", i, "Security", "", "")); i++;
            programs.Add(new Programs("Ad-Aware", i, "Security", "", "")); i++;
            programs.Add(new Programs("Spybot 2", i, "Security", "", "")); i++;
            programs.Add(new Programs("Avira", i, "Security", "", "")); i++;
            programs.Add(new Programs("SUPERAntiSpyware", i, "Security", "", "")); i++;
        }
    }
}
