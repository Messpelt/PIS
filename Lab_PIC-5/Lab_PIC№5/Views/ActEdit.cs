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
    public partial class ActEdit : Form
    {
        private bool actToEdit;
        private int actId;
        
        public ActEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            actToEdit = false;
            Isus.Text = "Добавление акта";
            FillEditor();
        }
        public ActEdit(int id)
        {
            InitializeComponent();
            actToEdit = true;
            actId = id;
            Isus.Text = "Редактирование акта";
            FillEditor();
        }

        private void FillEditor()
        {
            if (actToEdit)
            {
                var index = ActRepository.acts.FindIndex(x => x.ActNumber == actId);
                Act act = ActRepository.acts[index];
                numericUpDownDog.Value = act.CountDogs;
                numericUpDownCat.Value = act.CountCats;
                dateAct.Value = act.Date;
                textBoxTarget.Text = act.TargetCapture;
                FullComboBox();
                comboBoxOrganization.Text = act.Organization.name;
                comboBoxContract.Text = act.Contracts.IdContract.ToString();
                comboBoxApp.Text = act.Application.number.ToString();
            }
            else
            {
                FullComboBox();
            }
        }

        private void FullComboBox()
        {
            comboBoxOrganization.DataSource = new BindingSource(
                                    OrgRepository.Organizations, null);
            comboBoxOrganization.DisplayMember = "name";
            comboBoxOrganization.ValueMember = "idOrg";

            comboBoxContract.DataSource = new BindingSource(
                    ContractRepository.contract, null);
            comboBoxContract.DisplayMember = "IdContract";
            comboBoxContract.ValueMember = "IdContract";

            comboBoxApp.DataSource = new BindingSource(
                    AppRepository.Applicatiions, null);
            comboBoxApp.DisplayMember = "number";
            comboBoxApp.ValueMember = "number";
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ChekOtvet())
                if (actToEdit)
                {
                    var act = new string[] {actId.ToString(), numericUpDownDog.Value.ToString(),numericUpDownCat.Value.ToString(), comboBoxOrganization.SelectedValue.ToString(),
                        dateAct.Value.ToString(), textBoxTarget.Text, comboBoxApp.SelectedValue.ToString(), comboBoxContract.SelectedValue.ToString()};
                    ActService.EditAct(act);
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    var act = new string[] {numericUpDownDog.Value.ToString(),numericUpDownCat.Value.ToString(), comboBoxOrganization.SelectedValue.ToString(),
                        dateAct.Value.ToString(), textBoxTarget.Text, comboBoxApp.SelectedValue.ToString(), comboBoxContract.SelectedValue.ToString()};

                    bool IsDog = int.Parse(act[0]) > 0 ? true : false;
                    bool IsCat = int.Parse(act[1]) > 0 ? true : false;

                    bool flag = true;
                    Dictionary<int, string> animalDictionary = new Dictionary<int, string>() { { 0, "Собака" }, { 1, "Кот" } };
                    List<string[]> listAnimals = new List<string[]>();

                    if (IsDog)
                    {
                        var animForm = new AnimalCardForm("Собака");
                        DialogResult otvet = animForm.ShowDialog();
                        if (otvet == DialogResult.OK)
                            listAnimals.Add(animForm.returnAnime);

                        if (otvet == DialogResult.Cancel)
                            flag = false;
                    }
                    
                    if (IsCat & flag)
                    {
                        var animForm = new AnimalCardForm("Кот");
                        DialogResult otvet = animForm.ShowDialog();
                        if (otvet == DialogResult.OK)
                            listAnimals.Add(animForm.returnAnime);

                        if (otvet == DialogResult.Cancel)
                            flag = false;
                        
                    }

                    if (flag)
                    {
                        ActService.Save(act);
                        foreach (var animal in listAnimals)
                            AnimalCardService.AddAnimalCard(animal);
                        this.DialogResult = DialogResult.OK;

                    }
                    this.DialogResult = DialogResult.OK;
                }
        }

        private bool ChekOtvet()
        {
            if (numericUpDownDog.Value == 0 & numericUpDownCat.Value == 0)
            {
                MessageBox.Show("Вы не выбрали ни одного животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(textBoxTarget.Text == "")
            {
                MessageBox.Show("Введите цель отлова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
