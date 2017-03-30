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

        // List of browsers
        public List<Programs> browsers = new List<Programs>();

        // Array of browser names
        public string[] browsersName = new string[]
        {   "Google Chrome",
            "Mozilla Firefox",
            "Opera",
            "Microsoft Edge",
            "Vivaldi",
            "Safari",
        };

        // Array of browser URL's
        public string[] browsersUrl = new string[]
        {   "Web Browsers",
            "File Sharing",
            "Compression",
            "Messaging",
            "Online Storage",
            "Media",
        };

        // Array of browser descriptions
        public string[] browsersDesc = new string[]
        {   "The world's most popular web browser.",
            "Open source.",
            "Based on chrome.",
            "Microsofts modern browser.",
            "A new customizable browser.",
            "Apple's web browser.",
        };

        /// <summary>
        /// Add the browsers to the list
        /// </summary>
        public void InitializeBrowsers()
        {
            for (int i = 0; i < 6; i++)
            {
                // Name, ID, CategoryID, URL, Description
                // The CategoryID is used to display the correct programs
                // ID may become obsolete
                Programs browser = new Programs(browsersName[i], i, 0, browsersUrl[i], browsersDesc[i]);
                browsers.Add(browser);
            }
        }
    }
}
