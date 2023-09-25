using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_PIC_5.Controllers
{
    internal class AppService
    {
        public static void AddApplication(App App)
        {
            AppRepository.SaveAdd(App);
        }

        public static void EditApplication(App app)
        {
            AppRepository.Save(app);
        }

        public static List<string[]> FilterByDate(string filter, string filter2)
        {
            return AppRepository.FilterByDate(filter, filter2);
        }

        public static void DeleteApplication(int app)
        {
            foreach (App applic in AppRepository.Applicatiions)
            {
                if (Convert.ToInt32(applic.number) == app)
                {
                    AppRepository.Del(applic);
                    break; 
                }
            }
        }

        public static List<string[]> ShowApplication()
        {
            List<string[]> apps = new List<string[]>();
            foreach (App app in AppRepository.Applicatiions)
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
