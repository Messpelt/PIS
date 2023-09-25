using Lab_PIC_5.Controllers;
using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using Lab_PIC_5.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_PIC_5
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CreateData();
            SetDataGridAct();
            ShowContract();
            
            SetDataGridApp();
            SetDataGridOrg();

        }
        DataSet dsApplication = new DataSet();
        DataSet dsOrganization = new DataSet();

        private void CreateData()
        {
            ContractTable.Rows.Clear();
            var cont = ContractRepository.ShowCont(dateTimePicker3.Value.ToString(), dateTimePicker1.Value.ToString());
            foreach (var i in cont)
                ContractTable.Rows.Add(i);
        }
        private bool CheckPrivilege(NameMdels model)
        {
            if (!PreveligeService.SetPrivilege(model))
            {
                MessageBox.Show("Нюхай БЭБРУ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }


        /* -----------------------------------ACT----------------------------------------------------- */

        private void SetDataGridAct()
        {
            DataGridViewActs.Rows.Clear();
            var actss = ActService.ShowAct(dateTimePickerAct.Value.ToString());
            foreach (var organization in actss)
                DataGridViewActs.Rows.Add(organization);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Act)) 
            {
                ActEdit editWindow = new ActEdit();
                editWindow.ShowDialog();
                SetDataGridAct();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    ActEdit editWindow = new ActEdit(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    editWindow.ShowDialog();
                    SetDataGridAct();
                }
        }

        private void DeleteActButton_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    ActService.DeleteAct(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    SetDataGridAct();
                }
        }
        private void buttonAnimalCard_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    bool IsDog = int.Parse(DataGridViewActs.CurrentRow.Cells[1].Value.ToString()) > 0 ? true : false;
                    bool IsCat = int.Parse(DataGridViewActs.CurrentRow.Cells[2].Value.ToString()) > 0 ? true : false;

                    if (IsDog)
                    {
                        AnimalCardForm otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Собака");
                        otvet.ShowDialog();
                    }
                    if (IsCat)
                    {
                        AnimalCardForm otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Кот");
                        otvet.ShowDialog();
                    }
                }
        }

        private void dateTimePickerAct_ValueChanged(object sender, EventArgs e)
        {
            SetDataGridAct();
        }


        private void SetDataGridOrg()
        {
            /*-Organization-------------------------*/
            dsOrganization.Tables.Clear();
            dsOrganization.Tables.Add("Score");
            dsOrganization.Tables[0].Columns.Add("Номер");
            dsOrganization.Tables[0].Columns.Add("Наименование");
            dsOrganization.Tables[0].Columns.Add("ИНН");
            dsOrganization.Tables[0].Columns.Add("КПП");
            dsOrganization.Tables[0].Columns.Add("Адрес регистрации");
            dsOrganization.Tables[0].Columns.Add("Тип");
            dsOrganization.Tables[0].Columns.Add("Статус");
            var orgs = OrgService.ShowOrganizations();
            foreach (var org in orgs)
            {
                dsOrganization.Tables[0].Rows.Add(org);
            }
            dataGridViewOrg.DataSource = dsOrganization.Tables[0];
        }
        private void SetDataGridApp()
        {
            /*-Applications-------------------------*/
            dsApplication.Tables.Clear();
            dsApplication.Tables.Add("Score");
            dsApplication.Tables[0].Columns.Add("Дата подачи");
            dsApplication.Tables[0].Columns.Add("Номер");
            dsApplication.Tables[0].Columns.Add("Населенный пункт");
            dsApplication.Tables[0].Columns.Add("Территория");
            dsApplication.Tables[0].Columns.Add("Место обитания");
            dsApplication.Tables[0].Columns.Add("Срочность исполнения");
            dsApplication.Tables[0].Columns.Add("Описание животного");
            dsApplication.Tables[0].Columns.Add("Категория заявителя");
            var apps = AppService.ShowApplication();
            foreach (var app in apps)
            {
                dsApplication.Tables[0].Rows.Add(app);
            }
            dataGridViewApp.DataSource = dsApplication.Tables[0];
        }

        /*------------------------------------------------------------------*/
        private void AppDelete_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    int app = Convert.ToInt32(dataGridViewApp.CurrentRow.Cells[1].Value.ToString());
                    AppService.DeleteApplication(app);
                    SetDataGridApp();
                }
        }

        private void AppEdit_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    string app = dataGridViewApp.CurrentRow.Cells[1].Value.ToString();
                    AppEdit appEdit = new AppEdit(app);
                    appEdit.ShowDialog();
                    SetDataGridApp();
                }
        }

        private void OrgDelete_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    string org = dataGridViewOrg.CurrentRow.Cells[2].Value.ToString();
                    OrgService.DeleteOrganization(org);
                    SetDataGridOrg();
                }
        }

        private void OrgEdit_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    string org = dataGridViewOrg.CurrentRow.Cells[0].Value.ToString();
                    OrgEdit orgEdit = new OrgEdit(org);
                    orgEdit.ShowDialog();
                    SetDataGridOrg();
                }
        }

        private void OrgAdd_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Org))
            {
                OrgAdd orgAdd = new OrgAdd();
                orgAdd.ShowDialog();
                SetDataGridOrg();
            }
        }

        private void AppAdd_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.App))
            {
                AppAdd appAdd = new AppAdd();
                appAdd.ShowDialog();
                SetDataGridApp();
            }
        }

        private void ShowContract()
        {
            ContractTable.Rows.Clear();
            var contract = ContractService.ShowContract(dateTimePicker3.Value.ToString(), dateTimePicker1.Value.ToString());
            foreach (var i in contract)
            {
                ContractTable.Rows.Add(i);
            }
        }
        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Contract))
            {
                AddContractForm contAdd = new AddContractForm();
                contAdd.ShowDialog();
                ShowContract();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    AddContractForm contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
                    contAdd.ShowDialog();
                    ShowContract();
                }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    ContractService.DeleteContract(ContractTable.CurrentRow.Cells[0].Value.ToString());
                    ShowContract();
                }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            ShowContract();
        }

        private void ContractTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddContractForm contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
            contAdd.ShowDialog();
            ShowContract();
        }

        private void filterAppDate_ValueChanged(object sender, EventArgs e)
        {
            dsApplication.Tables[0].Rows.Clear();
            var apps = AppService.FilterByDate(filterAppDate.Value.ToString(), filterAppDate2.Value.ToString());
            foreach (var app in apps)
                dsApplication.Tables[0].Rows.Add(app);
            dataGridViewApp.DataSource = dsApplication.Tables[0];
        }

        private void filterAppDate2_ValueChanged(object sender, EventArgs e)
        {
            dsApplication.Tables[0].Rows.Clear();
            var apps = AppService.FilterByDate(filterAppDate.Value.ToString(), filterAppDate2.Value.ToString());
            foreach (var app in apps)
                dsApplication.Tables[0].Rows.Add(app);
            dataGridViewApp.DataSource = dsApplication.Tables[0];
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowContract();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenReport();
        }

        private void OpenReport()
        {
            if (CheckPrivilege(NameMdels.Report))
            {
                ReportForm rep = new ReportForm();
                rep.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.SelectedTab = tabPage1;
                OpenReport();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
