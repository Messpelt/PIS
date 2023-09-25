using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Controllers
{
    class PreveligeService
    {
        public static bool SetPrivilege(NameMdels model)
        {
            return PrivilegeRepository.SetPrivilege(model);
        }
    }
}
