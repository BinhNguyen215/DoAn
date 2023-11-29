using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User()
        {
        }

        public User(int id, string name, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }
        
    }
}
