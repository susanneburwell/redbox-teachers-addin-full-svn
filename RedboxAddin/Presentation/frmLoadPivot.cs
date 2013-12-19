using System;
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

namespace RedboxAddin.Presentation
{
    public partial class frmLoadPivot : Form
    {
        public frmLoadPivot()
        {
            InitializeComponent();
        }

        private void frmLoadPlan_Load(object sender, EventArgs e)
        {
            try
            {
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

                pivotGridControl1.DataSource = new DBManager().GetPivotLoadPlan(dStart, dEnd);
                    
                
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
                pivotGridControl1.DataSource = new DBManager().GetPivotLoadPlan(dStart, dEnd);
            }
        }



      
    }
}
