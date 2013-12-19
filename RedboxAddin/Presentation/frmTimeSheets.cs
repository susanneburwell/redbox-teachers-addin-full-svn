using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin;
using RedboxAddin.Models;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace RedboxAddin.Presentation
{
    public partial class frmTimeSheets : Form
    {
        bool loadingForm = false;

        public frmTimeSheets()
        {
            InitializeComponent();
        }

        private void frmTimeSheets_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
                loadingForm = true;
                Utils.PopulateSchools(cmbSchool);
                loadingForm = false;
     
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmTimeSheets_Load: " + ex.Message);
            }
        }

        private void LoadGrid()
        {
             try
            {
                string schoolID = cmbSchool.SelectedValue.ToString();
                gridControl1.DataSource = new DBManager().GetTimeSheets(dtFrom.Value, schoolID);
            
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadGrid: " + ex.Message);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dtFrom.Value = dtFrom.Value.AddDays(-7);
        }

        private void bnFwd_Click(object sender, EventArgs e)
        {
            dtFrom.Value = dtFrom.Value.AddDays(7);
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtFrom.Value.DayOfWeek == DayOfWeek.Monday)
            {
                if (!loadingForm) LoadGrid();
            }
            else
            {
                dtFrom.Value = Utils.GetFirstDayoftheWeek(dtFrom.Value);
            }
        }

        private void cmbSchool_TextChanged(object sender, EventArgs e)
        {
            if (!loadingForm) LoadGrid();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                cmbSchool.SelectedIndex += 1;
            }
            catch { }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                cmbSchool.SelectedIndex -= 1;
            }
            catch { }
        }

       


    }
}
