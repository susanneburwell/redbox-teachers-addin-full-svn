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
            GetWorkerDetails();
        }

        private void GetWorkerDetails()
        {
            DataSet DSSchools = new DBManager().GetWorkerDetails();
        }
    }
}
