namespace Download_Manager
{
    public class Programs : Category
    {
        // Contains the information about the varius programs
        
        public string category;     // Category is used to display the correct programs when viewing a category
        public string url;          // The URL is the name of the installer file on the server
        public string desc;         // Description is optional, gives an idea of what the program does
        public bool added = false;  // Added is checked to see if the program is already in the selected programs list

        /// <summary>
        /// Constructor for Programs, inherited from Category.cs
        /// Enters the variables read from the configuration files
        /// </summary>
        /// <param name="name">Program name, read from file</param>
        /// <param name="id">Program ID, given by the program</param>
        /// <param name="category">Category name, read from file</param>
        /// <param name="desc">Description, read from file</param>
        /// <param name="url">Setup URL, read from file</param>
        public Programs(string name, int id, string category, string desc, string url) : base(name, id)
        {
            this.category = category;
            this.url = url;
            this.desc = desc;
        }
    }
}
