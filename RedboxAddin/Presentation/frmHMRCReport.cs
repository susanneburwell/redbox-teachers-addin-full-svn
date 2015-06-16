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
            DateTime startDate=dtpStartDate.Value.Date;
            DateTime enddate = dtpEndDate.Value.Date;

            DataSet dsWorkersDetails = GetWorkerDetails(startDate,enddate);

            ExcelExporter objReport = new ExcelExporter();
            objReport.CreateHRMCReport(dsWorkersDetails);
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
                return null;
            }

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = dtpStartDate.Value.Date.AddMonths(3);
        }
    }
}
