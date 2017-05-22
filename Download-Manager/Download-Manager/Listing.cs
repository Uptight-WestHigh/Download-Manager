using System.Collections.Generic;
using System.IO;

namespace Download_Manager
{
    public class Listing
    {
        // List of categories
        public List<Category> categories = new List<Category>();

        /// <summary>
        /// Reads the Categories.config file, reads the programs and adds them to the list.
        /// </summary>
        public void InitializeCategories()
        {
            // String to store the entire file in
            string categoryContents = string.Empty;
            // Open the Categories.config
            using (FileStream fs = File.Open("Categories.config", FileMode.Open))
            // Read the file using StreamReader
            using (StreamReader reader = new StreamReader(fs))
            {
                // Store the file in the string
                categoryContents = reader.ReadToEnd();
            }
            // If the string isn't empty
            if (categoryContents.Length > 0)
            {
                // Split the string into an array of each row
                string[] lines = categoryContents.Split(new char[] { '\n' });
                // For each line
                for (int i = 0; i < lines.Length; i++)
                {
                    // Create an object with the name read from the file.
                    // Trim the end to remove any extra characters, like a new row.
                    Category category = new Category(lines[i].TrimEnd(), i);
                    // Add it to the list of categories.
                    categories.Add(category);
                }
            }
        }

        // List of programs
        public List<Programs> programs = new List<Programs>();

        /// <summary>
        /// Reads the Programs.config file, reads the programs and adds them to the list.
        /// </summary>
        public void InitializePrograms()
        {
            // Name, ID, Category, Description, URL

            // i is used for the ID of the programs.
            int i = 0;

            // String to store the entire file in
            string programsContents = string.Empty;
            // Open the Programs.config
            using (FileStream fs = File.Open("Programs.config", FileMode.Open))
            // Read the file using StreamReader
            using (StreamReader reader = new StreamReader(fs))
            {
                // Store the file in the string
                programsContents = reader.ReadToEnd();
            }
            // If the string isn't empty
            if (programsContents.Length > 0)
            {
                // Split the string into an array of each row
                string[] lines = programsContents.Split(new char[] { '\n' });
                // Dictionary to store the different "sections"
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                // For each row (as string line)
                foreach (string line in lines)
                {
                    // If the string isn't empty or a comment
                    if (!string.IsNullOrEmpty(line.Trim()) && !line.StartsWith("//"))
                    {
                        // Split the row into an array. Split every ","
                        string[] keyAndValue = line.Split(new char[] { ',' });
                        
                        // Create an object with the name read from the file.
                        // Trim the end to remove any extra characters, like a new row.
                        // Name, ID, Category, Description, URL
                        Programs program = new Programs(keyAndValue[0].TrimEnd(), i, keyAndValue[1].TrimEnd(), keyAndValue[2].TrimEnd(), keyAndValue[3].TrimEnd());
                        // Add it to the list
                        programs.Add(program);
                        // Increment the ID variable
                        i++;
                    }
                }
            }
        }
    }
}
