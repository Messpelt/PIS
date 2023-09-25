using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class ContractRepository
    {
        public static List<Contract> contract = new List<Contract> 
        { 
            new Contract(1, DateTime.Parse("02.05.2023"), DateTime.Parse("05.05.2023"), 
                LocationCostReposiroty.locationCosts[0], 1000, 
                OrgRepository.Organizations[0], OrgRepository.Organizations[1]),

            new Contract(2, DateTime.Parse("12.05.2023"), DateTime.Parse("15.05.2023"), 
                LocationCostReposiroty.locationCosts[1], 2000, 
                OrgRepository.Organizations[1], OrgRepository.Organizations[1]),

            new Contract(3, DateTime.Parse("10.05.2023"), DateTime.Parse("19.05.2023"),
                LocationCostReposiroty.locationCosts[2], 1550,
                OrgRepository.Organizations[2], OrgRepository.Organizations[1]),

            new Contract(4, DateTime.Parse("20.05.2023"), DateTime.Parse("25.05.2023"),
                LocationCostReposiroty.locationCosts[0], 2100,
                OrgRepository.Organizations[0], OrgRepository.Organizations[2])
        };

        public static void EditContractData(Contract cont)
        {
            var index = contract.FindIndex(x => x.IdContract == cont.IdContract);
            contract[index] = cont;
        }
        public static void SaveAdd(Contract cont)
        {
            contract.Add(cont);
        }
        public static List<Contract> ShowCont(string filter1, string filter2)
        {
            List<Contract> returnCont = contract.Where(x => x.DateConclusion >= DateTime.Parse(filter1) 
            && x.DateConclusion <= DateTime.Parse(filter2)).ToList();
            return returnCont;
        }
        public static void DeleteContract(Contract cont)
        {
            contract.Remove(cont);
        }
    }
}
