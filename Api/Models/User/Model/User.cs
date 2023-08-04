using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.User.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime creationDate { get; set; }



        public User(string name, string email, string password)
        {

            this.id = Guid.NewGuid();
            this.name = name;
            this.email = email;
            this.password = password;
            this.creationDate = DateTime.Now;
        }


        public User()
        {

            this.id = Guid.NewGuid();
            this.name = string.Empty;
            this.email = string.Empty;
            this.password = string.Empty;
            this.creationDate = DateTime.Now;
        }






    }
}