using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Models
{
    internal class Organization
    {
        public int idOrg { get; set; }
        public string name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string registrationAdress { get; set; }
        public string type { get; set; }
        public string status { get; set; }

        public Organization(int IdOrg, string name, string iNN, string kPP, string registrationAdress, string type, string status)
        {
            this.idOrg = IdOrg;
            this.name = name;
            INN = iNN;
            KPP = kPP;
            this.registrationAdress = registrationAdress;
            this.type = type;
            this.status = status;
        }
    }
}
