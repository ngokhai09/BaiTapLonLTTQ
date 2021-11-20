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
        private List<string> Class = new List<string>();
        private string subject;
        private string chucvu;
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
        public List<string> Class1 { get => Class; set => Class = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
    }
}
