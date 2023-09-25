using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class LocationCostReposiroty
    {
        public static List<Location> locationCosts = new List<Location>
        { new Location(1, "г. Тюмень"), 
            new Location(2, "г. Тобольск"),
            new Location(3, "г. Сургут")};
    }
}
