using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class ActRepository
    {
        public static List<Act> acts = new List<Act>
        {
            new Act(1, 4, 0, OrgRepository.Organizations[0], DateTime.Parse("01-06-23"), "Отловить 4 собаки",
                    AppRepository.Applicatiions[0], ContractRepository.contract[1]),

            new Act(2, 0, 4, OrgRepository.Organizations[1], DateTime.Parse("02-06-23"), "Отловить 4 кошки",
                    AppRepository.Applicatiions[1], ContractRepository.contract[0]),

            new Act(3, 3, 2, OrgRepository.Organizations[2], DateTime.Parse("03-06-23"), "Отловить 3 собаки и 2 кошки",
                    AppRepository.Applicatiions[2], ContractRepository.contract[1]),

        };

        public static void SaveActData(Act actData)
        {
            var index = acts.FindIndex(x => x.ActNumber == actData.ActNumber);
            acts[index] = actData;
        }

        public static void Save(Act A)
        {
            acts.Add(A);
        }

        public static void Delete(int choosedAct)
        {
            var index = acts.FindIndex(x => x.ActNumber == choosedAct);
            acts.RemoveAt(index);
        }

        public static List<Act> ShowAct(string filter)
        {
            List<Act> returnAct = acts.Where(x => x.Date >= DateTime.Parse(filter)).ToList();
            return returnAct;
        }
    }
}
