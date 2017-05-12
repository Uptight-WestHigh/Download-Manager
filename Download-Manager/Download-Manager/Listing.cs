using System.Collections.Generic;

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
            programs.Add(new Programs("Google Chrome", i, "Web Browsers", "Fast Browser by Google", "ChromeSetup.exe")); i++;
            programs.Add(new Programs("Opera", i, "Web Browsers", "Alternative Browser.", "OperaSetup.exe")); i++;
            programs.Add(new Programs("Mozilla Firefox", i, "Web Browsers", "Extensible Browser.", "FirefoxSetup.exe")); i++;

            // File Sharing
            programs.Add(new Programs("qBittorrent 32-bit", i, "File Sharing", "Free Bittorrent Client (32-bit)", "qBittorrentSetup.exe")); i++;
            programs.Add(new Programs("qBittorrent 64-bit", i, "File Sharing", "Free Bittorrent Client (64-bit)", "qBittorrentSetup64.exe")); i++;
            programs.Add(new Programs("eMule", i, "File Sharing", "File Sharing Client", "eMuleSetup.exe")); i++;

            // Compression
            programs.Add(new Programs("7-zip 32-bit", i, "Compression", "Great Compression App (32-bit)", "7-zipSetup.exe")); i++;
            programs.Add(new Programs("7-zip 64-bit", i, "Compression", "Great Compression App (64-bit)", "7-zipSetup64.exe")); i++;
            programs.Add(new Programs("PeaZip", i, "Compression", "File Compression Tool", "PeaZipSetup.exe")); i++;
            programs.Add(new Programs("WinRar 32-bit", i, "Compression", "Another Compression Tool (32-bit)", "WinRarSetup.exe")); i++;
            programs.Add(new Programs("WinRar 64-bit", i, "Compression", "Another Compression Tool (64-bit)", "WinRarSetup64.exe")); i++;

            // Messaging
            programs.Add(new Programs("Skype", i, "Messaging", "Internet Telephone", "SkypeSetup.exe")); i++;
            programs.Add(new Programs("Pidgin", i, "Messaging", "Multi-IM Client", "PidginSetup.exe")); i++;
            programs.Add(new Programs("Thunderbird", i, "Messaging", "Email Reader by Mozilla", "ThunderbirdSetup.exe")); i++;
            programs.Add(new Programs("Trillian", i, "Messaging", "Trillian IM", "TrillianSetup.exe")); i++;

            // Online Storage
            programs.Add(new Programs("Dropbox", i, "Online Storage", "", "DropboxSetup.exe")); i++;
            programs.Add(new Programs("Google Drive", i, "Online Storage", "", "GoogleDriveSetup.exe")); i++;
            programs.Add(new Programs("OneDrive", i, "Online Storage", "", "OneDriveSetup.exe")); i++;
            programs.Add(new Programs("SugarSync", i, "Online Storage", "", "SugarSyncSetup.exe")); i++;

            // Media
            programs.Add(new Programs("iTunes", i, "Media", "", "iTunesSetup64.exe")); i++;
            programs.Add(new Programs("VLC", i, "Media", "", "VLCSetup.exe")); i++;
            programs.Add(new Programs("Winamp", i, "Media", "", "WinampSetup.exe")); i++;
            programs.Add(new Programs("Audacity", i, "Media", "", "AudacitySetup.exe")); i++;
            programs.Add(new Programs("Spotify", i, "Media", "", "SpotifySetup.exe")); i++;
            programs.Add(new Programs("HandBrake", i, "Media", "", "HandBrakeSetup.exe")); i++;

            // Runtimes
            programs.Add(new Programs("Java 8", i, "Runtimes", "", "Java8Setup.exe")); i++;
            programs.Add(new Programs(".NET 4.6.2", i, "Runtimes", "", ".NET4.6.2Setup.exe")); i++;
            programs.Add(new Programs("Silverlight", i, "Runtimes", "", "SilverlightSetup.exe")); i++;
            programs.Add(new Programs("Air", i, "Runtimes", "", "AirSetup.exe")); i++;
            programs.Add(new Programs("Shockwave", i, "Runtimes", "", "ShockwaveSetup.exe")); i++;

            // Other
            programs.Add(new Programs("Evernote", i, "Other", "", "EvernoteSetup.exe")); i++;
            programs.Add(new Programs("Google Earth", i, "Other", "", "GoogleEarthSetup.exe")); i++;
            programs.Add(new Programs("Steam", i, "Other", "", "SteamSetup.exe")); i++;

            // Imaging
            programs.Add(new Programs("Paint.NET", i, "Imaging", "", "PaintNetSetup.exe")); i++;
            programs.Add(new Programs("GIMP", i, "Imaging", "", "GimpSetup.exe")); i++;
            programs.Add(new Programs("InkScape 32-bit", i, "Imaging", "", "InkScapeSetup.exe")); i++;
            programs.Add(new Programs("InkScape 64-bit", i, "Imaging", "", "InkScapeSetup64.exe")); i++;
            programs.Add(new Programs("ShareX", i, "Imaging", "", "ShareXSetup.exe")); i++;

            // Developer Tools
            programs.Add(new Programs("Python", i, "Developer Tools", "", "PythonSetup.exe")); i++;
            programs.Add(new Programs("FileZilla 32-bit", i, "Developer Tools", "", "FileZillaSetup.exe")); i++;
            programs.Add(new Programs("FileZilla 64-bit", i, "Developer Tools", "", "FileZillaSetup64.exe")); i++;
            programs.Add(new Programs("Notepad++", i, "Developer Tools", "", "Notepad++Setup.exe")); i++;
            programs.Add(new Programs("JDK 8 32-bit", i, "Developer Tools", "", "JDK8Setup.exe")); i++;
            programs.Add(new Programs("JDK 8 64-bit", i, "Developer Tools", "", "JDK8Setup64.exe")); i++;
            programs.Add(new Programs("Eclipse 32-bit", i, "Developer Tools", "", "EclipseSetup.exe")); i++;
            programs.Add(new Programs("Eclipse 64-bit", i, "Developer Tools", "", "EclipseSetup64.exe")); i++;
            programs.Add(new Programs("Visual Studio Code", i, "Developer Tools", "", "VisualStudioCodeSetup.exe")); i++;

            // Documents
            programs.Add(new Programs("Libreoffice", i, "Documents", "", "LibreOfficeSetup.msi")); i++;
            programs.Add(new Programs("OpenOffice", i, "Documents", "", "OpenOfficeSetup.exe")); i++;

            // Utilities
            programs.Add(new Programs("TeamViewer 12", i, "Utilities", "", "TeamViewer12Setup.exe")); i++;
            programs.Add(new Programs("ImgBurn", i, "Utilities", "", "ImgBurnSetup.exe")); i++;
            programs.Add(new Programs("WinDirStat", i, "Utilities", "", "WinDirStatSetup.exe")); i++;
            programs.Add(new Programs("Classic Start 8", i, "Utilities", "", "ClassicStart8Setup.exe")); i++;

            // Security
            programs.Add(new Programs("Microsoft Security Essentials 32-bit", i, "Security", "", "MicrosoftSecurityEssentialsSetup.exe")); i++;
            programs.Add(new Programs("Microsoft Security Essentials 64-bit", i, "Security", "", "MicrosoftSecurityEssentialsSetup64.exe")); i++;
            programs.Add(new Programs("Avast", i, "Security", "", "AvastSetup.exe")); i++;
            programs.Add(new Programs("AVG", i, "Security", "", "AVGSetup.exe")); i++;
            programs.Add(new Programs("Malwarebytes", i, "Security", "", "MalwarebytesSetup.exe")); i++;
            programs.Add(new Programs("Avira", i, "Security", "", "AviraSetup.exe")); i++;
        }
    }
}
