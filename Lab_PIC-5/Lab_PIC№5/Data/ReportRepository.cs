using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class ReportRepository
    {
        public static List<Report> reports = new List<Report>();
        public static List<Report> GenereteReport(DateTime start, DateTime finish)
        {
            reports = new List<Report>();
            foreach (var loc in LocationCostReposiroty.locationCosts)
            { 
                var allSity = ActRepository.acts.Where(x => x.Application.locality == loc.City & x.Date >= start & x.Date <= finish);
                int summ = 0;
                foreach (var act in allSity)
                {
                    summ += act.Contracts.Cost;
                }
                if (summ != 0)
                    reports.Add( new Report(start, finish, loc, allSity.Count(), allSity.Sum(x => x.Sum), summ));
            }
            return reports;
        }
    }
}
