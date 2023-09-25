using Lab_PIC_5.Controllers;
using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_PIC_5.Views
{
    public partial class AppAdd : Form
    {
        public AppAdd()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void OkAppAdd_Click(object sender, EventArgs e)
        {
            var app = new App(DateTime.Parse(date.Text), AppRepository.Applicatiions.Max(x => x.number) + 1, loc.Text, territory.Text, animalHabbiat.Text, urgency.Text, descrip.Text, categoryApp.Text);
            AppService.AddApplication(app);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
