namespace Download_Manager
{
    public class Category
    {
        // Contains the information about the varius programs  

        public string name; // Name of the category
        public int id;      // Category ID

        /// <summary>
        /// Constructor for Category, inherited by Programs.cs
        /// Enters the variables read from the configuration files
        /// </summary>
        /// <param name="name">Category name, read from file</param>
        /// <param name="id">Category ID, given by the program</param>
        public Category(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
