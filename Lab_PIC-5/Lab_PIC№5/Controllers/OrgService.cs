using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_PIC_5.Controllers
{
    internal class OrgService
    {
        public static List<string[]> ShowOrganizations()
        {
            List<string[]> orgs = new List<string[]>();
            foreach (Organization org in OrgRepository.Organizations)
            {
                var tempOrg = new List<string>
                {
                    org.idOrg.ToString(),
                    org.name,
                    org.INN,
                    org.KPP,
                    org.registrationAdress,
                    org.type,
                    org.status
                };
                orgs.Add(tempOrg.ToArray());
            }
            return orgs;
        }

        public static void AddOrganization(Organization Org)
        {
            OrgRepository.SaveAdd(Org);
        }

        public static void EditOrganization(Organization Org)
        {
            OrgRepository.Save(Org);
        }

        public static void DeleteOrganization(string org)
        {
            foreach (Organization organization in OrgRepository.Organizations)
            {
                if (organization.INN == Convert.ToString(org))
                {
                    OrgRepository.Del(organization);
                    break;
                }

            }
        }

    }
}
