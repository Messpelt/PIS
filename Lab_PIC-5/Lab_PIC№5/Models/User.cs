using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Models
{
    class User
    {
        public int IdUser { get; set; }
        public string Login {get; set;}
        public string Password { get; set; }
        public Role Role { get; }

        public User (int idUser, string login, string password, Role role)
        {
            IdUser = idUser;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
