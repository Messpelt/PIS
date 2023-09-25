using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_PIC_5.Data
{
    internal class OrgRepository
    {
        public static Organization[] OrganizationsMas =
        {
            new Organization(1,"МКУ «ЛесПаркХоз»", "3664069397", "770201001", "г. Сургут", "Коммерческий", "действующее"),
            new Organization(2,"ГосОтлов", "9574637594","770495001", "г. Тюмень", "Государственная организация", "действующее"),
            new Organization(3,"ПРОО «Общество защиты животных»", "5769384756", "720294631", "г. Тюмень", "Коммерческий", "действующее")
        };

        public static List<Organization> Organizations = new List<Organization>(OrganizationsMas);

        public static void Save(Organization Org)
        {
            var IdOrg = Organizations.FindIndex(x => x.idOrg == Org.idOrg);
            
            Organizations[IdOrg] = Org;
        }
        public static void SaveAdd(Organization Org)
        {
            Organizations.Add(Org);
        }

        public static void Del(Organization organization)
        {
            Organizations.Remove(organization);
        }
    }
}
