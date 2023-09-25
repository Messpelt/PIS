using Lab_PIC_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Controllers
{
    class UserService
    {
        public static bool CheckUser(string login, string password)
        {
            return UserRepository.CheckUser(login, password);
        }
    }
}
