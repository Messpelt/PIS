using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5
{
    internal class ActService
    {
        public static List<string[]> ShowAct(string filter)
        {
            List<string[]> acts = stringMassChencher(ActRepository.ShowAct(filter));
            return acts;
        }

        public static void EditAct(string[] takedActData)
        {
            var actData = new Act(
                int.Parse(takedActData[0]),
                int.Parse(takedActData[1]), int.Parse(takedActData[2]),
                OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(takedActData[3]))],
                DateTime.Parse(takedActData[4]), takedActData[5],
                AppRepository.Applicatiions[AppRepository.Applicatiions.FindIndex(x => x.number == int.Parse(takedActData[6]))],
                ContractRepository.contract[ContractRepository.contract.FindIndex(x => x.IdContract == int.Parse(takedActData[7]))]);
            ActRepository.SaveActData(actData);
        }

        public static void DeleteAct(int choosedAct)
        {
            ActRepository.Delete(choosedAct);
        }

        public static void Save(string[] A)
        {
            var actData = new Act(
               ActRepository.acts.Max(x => x.ActNumber) + 1,
               int.Parse(A[0]), int.Parse(A[1]),
               OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(A[2]))],
               DateTime.Parse(A[3]), A[4],
               AppRepository.Applicatiions[AppRepository.Applicatiions.FindIndex(x => x.number == int.Parse(A[5]))],
               ContractRepository.contract[ContractRepository.contract.FindIndex(x => x.IdContract == int.Parse(A[6]))]);
            ActRepository.Save(actData);
        }

        private static List<string[]> stringMassChencher(List<Act> acts)
        {
            List<string[]> result = new List<string[]>();
            foreach (Act act in acts)
            {
                var oldAct = new List<string>
                {
                    act.ActNumber.ToString(),
                    act.CountDogs.ToString(),
                    act.CountCats.ToString(),
                    act.Organization.name,
                    act.Date.ToShortDateString(),
                    act.TargetCapture,
                    act.Application.number.ToString(),
                    act.Contracts.IdContract.ToString()
                };
                result.Add(oldAct.ToArray());
            }
            return result;
        }
    }
}
