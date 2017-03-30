using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download_Manager
{
    public class Category
    {
        public string name;
        public int id;

        public Category(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
