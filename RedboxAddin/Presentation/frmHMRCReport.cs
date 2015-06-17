﻿using RedboxAddin.BL;
using RedboxAddin.DL;
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
    public partial class frmHMRCReport : Form
    {
        public frmHMRCReport()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime enddate = dtpEndDate.Value.Date;

            DataSet dsWorkersDetails = GetWorkerDetails(startDate, enddate);

            ExcelExporter objReport = new ExcelExporter();
            objReport.CreateHRMCReport(dsWorkersDetails, startDate, enddate);

            Cursor.Current = Cursors.Default;
        }

        private DataSet GetWorkerDetails(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataSet dsWorkersDetails = new DBManager().GetWorkerDetails(startDate, endDate);
                return dsWorkersDetails;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetWorkerDetails: " + ex.Message);
                return null;
            }

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ResetEndDate();
        }

        private void frmHMRCReport_Load(object sender, EventArgs e)
        {
            ResetEndDate();
        }

        private void ResetEndDate()
        {
            dtpEndDate.Value = dtpStartDate.Value.Date.AddMonths(3).AddDays(-1);
        }
    }
}