using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LepFoundation;

namespace LepPoleInGround
{
    public partial class MainFrm : Form
    {
        public DataModel dataModel;

        public MainFrm()
        {
            InitializeComponent();
            comboBoxPoleType.SelectedIndex = 0;
            dataModel = new DataModel();
            //Binding binding = new Binding("Text", dataModel, "PoleDiameter");            
            this.textBoxPoleDiameter.DataBindings.Add("Text", dataModel, "PoleDiameter", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvLoads_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex!=0)
            {
                CheckLoad(e);
            }
            //DataGridViewColumn column = dgvLoads.Columns[e.ColumnIndex];
            //if(column.Name=="")
            //{

            //}
        }

        private static void CheckLoad(DataGridViewCellValidatingEventArgs newValue)
        {
            Double ignored = new Double();
            if (String.IsNullOrEmpty(newValue.FormattedValue.ToString()))
            {
                //do nothing
            }
            else if (!Double.TryParse(newValue.FormattedValue.ToString(), out ignored))
            {
                NotifyUserAndForceRedo("Введите число", newValue);
            }
            else if (Double.Parse(newValue.FormattedValue.ToString()) < 0)
            {
                NotifyUserAndForceRedo("Значение должно быть положительным", newValue);
            }
        }

        private static void NotifyUserAndForceRedo(string errorMessage, DataGridViewCellValidatingEventArgs newValue)
        {
            MessageBox.Show(errorMessage);
            newValue.Cancel = true;
        }

        private void сГСToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            SetPicturePoleByRadioBtns();
        }
        private void SetPicturePoleByRadioBtns()
        {
            if (radioButton1.Checked)
            {
                pictureBox1.Image = Properties.Resources.type1;
                groupBoxUpRigel.Enabled = false;
                groupBoxDownRigel.Enabled = false;
                groupBoxBanketka.Enabled = false;
            }
            if (radioButton2.Checked)
            {
                pictureBox1.Image = Properties.Resources.type2;
                groupBoxUpRigel.Enabled = true;
                groupBoxDownRigel.Enabled = false;
                groupBoxBanketka.Enabled = false;
            }
            if (radioButton3.Checked)
            {
                pictureBox1.Image = Properties.Resources.type3;
                groupBoxUpRigel.Enabled = true;
                groupBoxDownRigel.Enabled = false;
                groupBoxBanketka.Enabled = false;
            }
            if (radioButton4.Checked)
            {
                pictureBox1.Image = Properties.Resources.type4;
                pictureBox1.Image = Properties.Resources.type3;
                groupBoxUpRigel.Enabled = true;
                groupBoxDownRigel.Enabled = true;
                groupBoxBanketka.Enabled = false;
            }
            if (radioButton5.Checked)
            {
                pictureBox1.Image = Properties.Resources.type5;
                groupBoxUpRigel.Enabled = true;
                groupBoxDownRigel.Enabled = false;
                groupBoxBanketka.Enabled = true;
            }
            if (radioButton6.Checked)
            {
                pictureBox1.Image = Properties.Resources.type6;
                groupBoxUpRigel.Enabled = true;
                groupBoxDownRigel.Enabled = true;
                groupBoxBanketka.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKoefLoads.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvLoads.RowCount = Decimal.ToInt32 (numericUpDown1.Value);
        }

        private void checkBoxWater_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHWater.Enabled = checkBoxWater.Checked;
        }

        private void checkBoxPRS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPRS.Enabled = checkBoxPRS.Checked;
        }

        private void textBoxPoleDiameter_Validating(object sender, CancelEventArgs e)
        {
            //string errorMsg;
            //if(!ValidDoubleValue(textBoxPoleDiameter.Text, out errorMsg))
            //{
            //    e.Cancel = true;
            //    textBoxPoleDiameter.Select(0, textBoxPoleDiameter.Text.Length);
            //}
        }

        private bool ValidDoubleValue(string text, out string errorMsg)
        {
            Double ignored = new Double();
            if (!Double.TryParse(text, out ignored))
            {
                errorMsg = "error";
                return false;
            }
            errorMsg = "";
            return true;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {

        }

        private bool CheckInput()
        {
            StringBuilder builder = new StringBuilder();

            //string errorMsg;
            //if (textBoxPoleDiameter.Text, out errorMsg)
            //{

            //}
            return false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataModel.PoleDiameter = "diam";
            dataModel.Save("d:\\testPole.xml");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
