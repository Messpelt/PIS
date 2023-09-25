using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class PrivilegeRepository
    {
        public static List<Role> rols = new List<Role>
                                    { new Role("Операто по отлову", new Dictionary<NameMdels, bool>()
                                                                    {
                                                                        {NameMdels.Act, true},
                                                                        {NameMdels.App, false},
                                                                        {NameMdels.Contract, false},
                                                                        {NameMdels.Org, false},
                                                                        {NameMdels.Report, false}
                                                                    }),
                                    new Role("Операто вет. службы", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, false}
                                                                }),
                                    new Role("Операто ОМСУ", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, true},
                                                                    {NameMdels.Contract, true},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, true},
                                                                }),
                                    new Role("Сотрудник вет. службы", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false}
                                                                }),
                                    new Role("Сотрудник отлова", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false}
                                                                }),
                                    new Role("Сотрудник ОМСУ", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false}
                                                                }),
                                    new Role("Сотрудник приюта", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false}
                                                                }),
                                    new Role("Admin", new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, true},
                                                                    {NameMdels.App, true},
                                                                    {NameMdels.Contract, true},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, true}
                                                                })
                                    };

        public static bool SetPrivilege(NameMdels model)
        {
            var user = UserSessia.UserLog;
            return user.Role.CheckPosibilitis[model];
        }
    }
}
