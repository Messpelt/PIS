using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Lab_PIC_5.Controllers;

namespace Lab_PIC_5.Views
{
    public partial class AppEdit : Form
    {
        public AppEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private string AppNum;
        public AppEdit(string num)
        {
            InitializeComponent();
            AppNum = num;
            FillAppEdit();
        }
        private void FillAppEdit()
        {
            var NumAppId = AppRepository.Applicatiions.FindIndex(x => x.number == Convert.ToInt32(AppNum));
            App app = AppRepository.Applicatiions[NumAppId];
            date.Text = app.date.ToString();
            loc.Text = app.locality;
            territory.Text = app.territory;
            animalHabbiat.Text = app.animalHabiat;
            urgency.Text = app.urgencyOfExecution;
            descrip.Text = app.animaldescription;
            categoryApp.Text = app.applicantCategory;
        }

        private void OkAppEdit_Click(object sender, EventArgs e)
        {
            var app = new App(DateTime.Parse(date.Text), Convert.ToInt32(AppNum), loc.Text, territory.Text, animalHabbiat.Text, urgency.Text, descrip.Text, categoryApp.Text);
            AppService.EditApplication(app);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
