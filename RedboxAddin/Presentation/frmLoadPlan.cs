﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedboxAddin.DL;
using RedboxAddin.BL;
using RedboxAddin.Models;

namespace RedboxAddin.Presentation
{
    public partial class frmLoadPlan : Form
    {
        public frmLoadPlan()
        {
            InitializeComponent();
        }

        private void frmLoadPlan_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
                UpdateDates();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmLoadPlan_Load: " + ex.Message);
            }
        }

        private void SetDates(object sender, EventArgs e)
        {
            UpdateDates();
        }

        private void RefreshGrid(object sender, EventArgs e)
        {
            UpdateDates();
        }

       
        private void UpdateDates()
        {
            try
            {
                DateTime dStart = dtFrom.Value.Date;
                DateTime dEnd = dStart;
                if (radWeek.Checked)dEnd = dStart.AddDays(7);
                if (radMonth.Checked)dEnd = dStart.AddMonths(1);
                if (radCustom.Checked)
                {
                    dEnd = dtTo.Value.Date;
                    dtTo.Value = dStart;
                    dtTo.Visible = true;
                    lblTo.Visible = false;
                }
                else
                {
                    dtTo.Visible = false;
                    lblTo.Visible = true;
                }
                lblTo.Text = dEnd.ToLongDateString();

                gridControl1.DataSource = new DBManager().GetLoadPlan(dStart);
                    
                
            }
            catch (Exception ex)
            {
               Debug.DebugMessage(2, "Error in UpdateDates: " + ex.Message);
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtTo.Visible)
            {
                DateTime dStart = dtFrom.Value.Date;
                DateTime dEnd = dtTo.Value.Date;
                gridControl1.DataSource = new DBManager().GetLoadPlan(dStart);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (radWeek.Checked)
            {
                dtFrom.Value = dtFrom.Value.AddDays(-7);
            }
            else
            {
                dtFrom.Value = dtFrom.Value.AddMonths(-1);
            }
}

        private void bnFwd_Click(object sender, EventArgs e)
        {
            if (radWeek.Checked)
            {
                dtFrom.Value = dtFrom.Value.AddDays(7);
            }
            else
            {
                dtFrom.Value = dtFrom.Value.AddMonths(1);
            }
        }

        private void btnCreatePaySheets_Click(object sender, EventArgs e)
        {
            string sEnd = dtFrom.Value.AddDays(4).ToString("yyyy-MM-dd");
            List<string> names = LINQmanager.GetPaymentTypes();
            ExcelExporter exEx = new ExcelExporter();
            DBManager dbm = new DBManager();

            int num = 0;
            foreach (string name in names)
            {
                List<Payment> lp = dbm.GetPayrun(dtFrom.Value);
                //count successful attempts
                if (exEx.CreatePaySheet(name, sEnd, lp)) num +=1;
            }

            if (num == 0)
            {
                MessageBox.Show("No Paysheets were created.");
            }

            else if (num == 1)
            {
                MessageBox.Show("1 Paysheet was created.");
            }

            else
            {
                MessageBox.Show(num.ToString() + " Paysheets were created.");
            }
        }

        private void btnCreateInvoices_Click(object sender, EventArgs e)
        {
            ExcelExporter exEx = new ExcelExporter();

            int num = exEx.CreateInvoices(dtFrom.Value.AddDays(4).ToString("yyyy-MM-dd"));

            if (num == 0)
            {
                MessageBox.Show("No Invoices were created.");
            }
            else if (num == 1)
            {
                MessageBox.Show("1 Invoice was created.");
            }
            else
            {
                MessageBox.Show(num.ToString() + " Invoices were created.");
            }
        }



      
    }
}
