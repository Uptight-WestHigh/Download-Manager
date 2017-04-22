using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download_Manager
{
    public class Programs
    {
        // Contains the information about the varius programs

        public string name;
        public int id;
        public string category;
        public string url;
        public string desc;

        public Programs(string name, int id, string programCategory, string desc, string url)
        {
            this.name = name;
            this.id = id;
            this.category = programCategory;
            this.url = url;
            this.desc = desc;
        }
    }
}
