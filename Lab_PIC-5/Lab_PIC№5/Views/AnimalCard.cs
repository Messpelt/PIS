using Lab_PIC_5.Controllers;
using Lab_PIC_5.Data;
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
    public partial class AnimalCardForm : Form
    {
        private int actId;
        public string[] returnAnime;
        private bool AnimalToEdit;
        public AnimalCardForm(string act)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GITLER.Text = act;
            actId = (ActRepository.acts.Max(x => x.ActNumber)) + 1;
            AnimalToEdit = true;
            InicilisateAll();
        }
        public AnimalCardForm(int actIdi, string act)
        {
            InitializeComponent();
            GITLER.Text = act;
            actId = actIdi;
            AnimalToEdit = false;
            InicilisateAll();
        }

        private void InicilisateAll()
        {
            if (AnimalToEdit)
            {
                textBoxKategori.Text = GITLER.Text;
                God.Text = "Акт:" + actId;
                comboBoxLocation.DataSource = new BindingSource(
                                        LocationCostReposiroty.locationCosts, null);
                comboBoxLocation.DisplayMember = "City";
                comboBoxLocation.ValueMember = "IdLocation";
            }
            else
            {
                var index = AnimalRepository.animalCards.FindIndex(x => x.ActCapture.ActNumber == actId & x.Category == GITLER.Text);
                var animalCard = AnimalRepository.animalCards[index];
                textBoxKategori.Text = animalCard.Category;
                textBoxGender.Text = animalCard.Gender;
                textBoxPoroda.Text = animalCard.Breed;
                numericUpDownSize.Value = animalCard.Size;
                textBoxFurType.Text = animalCard.FurType;
                textBoxColor.Text = animalCard.Color;
                textBoxEars.Text = animalCard.Ears;
                textBoxTail.Text = animalCard.Tail;
                textBoxSpicialSigns.Text = animalCard.SpicialSigns;
                textBoxIdentificationLabel.Text = animalCard.IdentificationLabel;
                God.Text = "Акт:" + actId;
                comboBoxLocation.DataSource = new BindingSource(
                                        LocationCostReposiroty.locationCosts, null);
                comboBoxLocation.DisplayMember = "City";
                comboBoxLocation.ValueMember = "IdLocation";
                KillEdit();
            }
        }

        private void KillEdit()
        {
            textBoxKategori.Enabled = false;
            textBoxGender.Enabled = false;
            numericUpDownSize.Enabled = false;
            textBoxKategori.Enabled = false;
            textBoxPoroda.Enabled = false;
            textBoxFurType.Enabled = false;
            textBoxColor.Enabled = false;
            textBoxEars.Enabled = false;
            textBoxTail.Enabled = false;
            textBoxSpicialSigns.Enabled = false;
            textBoxIdentificationLabel.Enabled = false;
            comboBoxLocation.Enabled = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (AnimalToEdit)
            {
                if (ChekOtvet())
                {
                    var otp = new string[] { textBoxKategori.Text, textBoxGender.Text,
                                            textBoxPoroda.Text, numericUpDownSize.Value.ToString(),
                                            textBoxFurType.Text, textBoxColor.Text, textBoxEars.Text,
                                            textBoxTail.Text, textBoxSpicialSigns.Text, textBoxIdentificationLabel.Text,
                                            comboBoxLocation.SelectedValue.ToString(), actId.ToString(),null};
                    returnAnime = otp;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ChekOtvet()
        {
            if (textBoxPoroda.Text == "")
            {
                MessageBox.Show("Вы не ввели породу ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
