using Lab_PIC_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Controllers
{
    class ReportService
    {
        public static List<string[]> GenereteReport(DateTime start, DateTime finish)
        {
            var rep =  ReportRepository.GenereteReport(start, finish);
            List<string[]> otvRep = new List<string[]>();
            foreach (var item in rep)
            {
                var old = new string[]
                {
                    //item.DateStart.ToString(),
                    //item.DateFinish.ToString(),
                    item.Loc.City,
                    item.Close.ToString(),
                    item.CountAnumals.ToString(),
                    item.Sum.ToString()
                };
                otvRep.Add(old);
            }
            return otvRep;
        }
    }
}
