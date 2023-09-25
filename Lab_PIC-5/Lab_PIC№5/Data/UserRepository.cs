using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class UserRepository
    {
        public static List<User> users = new List<User>
                                    {
                                        new User(1, "UserOtlov", "ot", PrivilegeRepository.rols[0]),
                                        new User(2, "UserBET", "b", PrivilegeRepository.rols[1]),
                                        new User(3, "UserOMCY", "o", PrivilegeRepository.rols[2]),
                                        new User(4, "User4", "4", PrivilegeRepository.rols[3]),
                                        new User(5, "Admin", "Admin", PrivilegeRepository.rols[7])
                                    };
        public static bool CheckUser(string login, string password)
        {
            var col = users.Where(x => x.Login == login & x.Password == password);
            
            if (col.Count() != 0)
            {
                UserSessia.UserLog = col.ToList()[0];
                return true;
            }
            return false;
        }
    }
}
   
