using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download_Manager
{
    public class Listing
    {
        public List<Category> categories = new List<Category>();
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
            "Security" };

        public void Initialize()
        {
            Category webBrowsers = new Category("Web Browsers", 0);
            categories.Add(webBrowsers);

            for (int i = 0; i < 12; i++)
            {
                Category category = new Category(categoryName[i], i);
                categories.Add(category);
            }
        }
    }
}
