namespace Download_Manager
{
    public class Programs : Category
    {
        // Contains the information about the varius programs
        public string category;
        public string url;
        public string desc;
        public bool added = false;

        public Programs(string name, int id, string category, string desc, string url) : base(name, id)
        {
            this.category = category;
            this.url = url;
            this.desc = desc;
        }
    }
}
