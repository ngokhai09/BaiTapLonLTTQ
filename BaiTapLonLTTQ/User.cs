using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonLTTQ
{
    public class User
    {
        private string username;
        private string password;
        private string name;
        public User()
        {
            username = "";
            password = "";
            name = "";
        }
        public User(string username = "", string password = "", string name = "")
        {
            this.username = username;
            this.password = password;
            this.name = name;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
    }
}
