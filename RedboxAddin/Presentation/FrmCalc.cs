using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedboxAddin.Presentation
{
    public partial class FrmCalc : Form
    {

        decimal originalRate = 0;
        decimal originalCharge = 0;
        bool halfday = false;
        public decimal newRate = 0;
        public decimal newCharge = 0;

        public FrmCalc(decimal charge, decimal rate, bool halfDay)
        {
            InitializeComponent();
            this.originalCharge = charge;
            this.originalRate = rate;
            this.halfday = halfDay;
            if (halfday) radHalfday.Checked = true;
        }

        private void FrmCalc_Load(object sender, EventArgs e)
        {
            ClearFields();
            FillDetails();
        }

        private void FillDetails()
        {
            lblCharge.Text = originalCharge.ToString();
            lblRate.Text = originalRate.ToString();
        }

        private void ClearFields()
        {
            txtRate.Text = "0.00";
            txtCharge.Text = "0.00";
            lblRate.Text = "0.00";
            lblCharge.Text = "0.00";
            txtHours.Text = "00";
            txtMinutes.Text = "00";
            //chkIsCredit.Checked = false;
        }

        private void CalcHours()
        {
            try
            {
                double hours = 6.5;
                if (radHalfday.Checked) hours = 3.25;

                Double hourlyCharge = ((double)originalCharge - 35) / hours;
                Double hourlyrate = (double)originalRate / hours;

                Double actualHours;
                bool ok1 = double.TryParse(txtHours.Text, out actualHours);
                if (!ok1) actualHours = 0;
                Double actualMins;
                bool ok2 = double.TryParse(txtMinutes.Text, out actualMins);
                if (!ok2) actualMins = 0;

                Double addRate = (hourlyrate * actualHours) + (hourlyrate * actualMins / 60);
                Double addCharge = (hourlyCharge * actualHours) + (hourlyCharge * actualMins / 60) + 35;
                if (actualHours == 0) addCharge = 0;

                txtRate.Text = addRate.ToString("N2");
                txtCharge.Text = addCharge.ToString("N2");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation Error: " + ex.Message);
            }
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void txtMinutes_TextChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void radFullday_CheckedChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool ok1 = decimal.TryParse(txtRate.Text, out newRate);
            if (!ok1) newRate = 0;
            bool ok2 = decimal.TryParse(txtCharge.Text, out newCharge);
            if (!ok2) newCharge = 0;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

       
    }
}
