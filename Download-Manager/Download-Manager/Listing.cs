using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Download_Manager
{
    public class Listing
    {
        // List of categories
        public List<Category> categories = new List<Category>();

        /// <summary>
        /// Add the categories to the list
        /// </summary>
        public void InitializeCategories()
        {
            string categoryContents = string.Empty;
            using (FileStream fs = File.Open("Categories.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                categoryContents = reader.ReadToEnd();
            }
            if (categoryContents.Length > 0)
            {
                string[] lines = categoryContents.Split(new char[] { '\n' });
                for (int i = 0; i < lines.Length; i++)
                {
                    Category category = new Category(lines[i].TrimEnd(), i);
                    categories.Add(category);
                }
            }
        }

        // List of programss
        public List<Programs> programs = new List<Programs>();

        /// <summary>
        /// Add the programs to the list
        /// </summary>
        public void InitializePrograms()
        {
            // Name, ID, Category, Description, URL

            int i = 0;

            string programsContents = string.Empty;
            using (FileStream fs = File.Open("Programs.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                programsContents = reader.ReadToEnd();
            }

            if (programsContents.Length > 0)
            {
                string[] lines = programsContents.Split(new char[] { '\n' });
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line.Trim()) && !line.StartsWith("//"))
                    {
                        string[] keyAndValue = line.Split(new char[] { ',' });
                        Programs program = new Programs(keyAndValue[0].Trim(), i, keyAndValue[1].Trim(), keyAndValue[2].Trim(), keyAndValue[3].Trim());
                        programs.Add(program);
                        i++;
                    }
                }
            }
        }
    }
}
