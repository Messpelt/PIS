using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_PIC_5.Data
{
    internal class AppRepository
    {
        public static App[] ApplicatiionsMas =
        {
            new App(DateTime.Parse("20-02-2023"), 1, "г. Тюмень", "р-н Ленинский", "около дома 10", "10", "Белая собака с черным ухом, порода неизвестна,", "Физ. лицо"),
            new App(DateTime.Parse("15-02-2023"), 2, "г. Тюмень","р-н Калининский", "около магазина Магнит", "15", "Рыжая собака", "Физ. лицо"),
            new App(DateTime.Parse("20-03-2023"), 3,"г. Сургут", "мкр. 10", "двор дома №6", "7", "Черная собака", "Физ. лицо")
        };

        public static List<App> Applicatiions = new List<App>(ApplicatiionsMas);

        public static void Save(App app)
        {
            var id = Applicatiions.FindIndex(x => x.number == app.number);
            Applicatiions[id] = app;
        }
        public static void SaveAdd(App app)
        {
            Applicatiions.Add(app);
        }

        public static void Del(App app)
        {
            Applicatiions.Remove(app);
        }

        public static List<string[]> FilterByDate(string filter, string filter2)
        {
            List<App> AppsFilter = Applicatiions.Where(x => x.date >= DateTime.Parse(filter) && x.date <= DateTime.Parse(filter2)).ToList();
            List<string[]> apps = new List<string[]>();
            foreach (App app in AppsFilter)
            {
                var tempApp = new List<string>
                {
                    app.date.ToString(),
                    app.number.ToString(),
                    app.locality,
                    app.territory,
                    app.animalHabiat,
                    app.urgencyOfExecution,
                    app.animaldescription,
                    app.applicantCategory
                };
                apps.Add(tempApp.ToArray());
            }
            return apps;
        }
    }
}
