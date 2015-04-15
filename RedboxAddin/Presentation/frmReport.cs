using RedboxAddin.DL;
using RedboxAddin.BL;
using RedboxAddin.Models;
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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            switch (cmbReport.Text)
            {
                case "DBS Expiry within 9 months":
                    CreateDailyReport();
                    break;
                case "Long Term 10-14 weeks":
                    string to = DateTime.Now.AddDays(-70).ToString("yyyy-MM-dd");
                    string from = DateTime.Now.AddDays(-98).ToString("yyyy-MM-dd");
                    CreateLongTermReport(from, to);
                    break;
                case "UpdateService Last Checked 10 months+":
                    string from1 = DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd");
                    CreateDBSupdateCheckReport(from1);
                    break;

                default:
                    MessageBox.Show("Nothing Selected.");
                    break;

            }

        }

        private void CreateDailyReport()
        {
            try
            {
                string nineMonths = DateTime.Now.AddMonths(9).ToString("yyyy-MM-dd");
                string WhereSQL = "WHERE datediff(d,'" + nineMonths + "', CRBExpiryDate) < 0   ";
                if (chkCurrent.Checked) WhereSQL += " AND [Current] = 1 ";
                WhereSQL += "ORDER BY  CRBExpiryDate ASC ";

                DBManager dbm = new DBManager();
                List<RContact> listContacts = dbm.GetContacts(WhereSQL);

                string myText = "";

                myText = listContacts.Count().ToString() + " Contacts in Report" + Environment.NewLine;

                foreach (RContact rc in listContacts)
                {
                    myText += rc.FullName + "       " + rc.DBSExpiryDate.ToString("dd-MMM-yyyy") + Environment.NewLine;  // "\n\r";
                }

                txtReport.Text = myText;
                lblText.Text = "Finished";

            }
            catch (Exception ex)
            {
                lblText.Text = "Error";
                Debug.DebugMessage(2, "Error Creating daily Report: " + ex.Message);
            }
        }

        private void CreateLongTermReport(string from, string to)
        {
            try
            {

                string WhereSQL = "WHERE datediff(d,'" + from + "', [LTStartDate]) > 0   "
                                + " AND datediff(d,'" + to + "', [LTStartDate]) < 0   ";
                if (chkCurrent.Checked) WhereSQL += " AND [Current] = 1 ";
                WhereSQL += "ORDER BY  [LTStartDate] ASC ";

                DBManager dbm = new DBManager();
                List<RContact> listContacts = dbm.GetContacts(WhereSQL);

                string myText = "";

                myText = listContacts.Count().ToString() + " Contacts in Report" + Environment.NewLine;

                foreach (RContact rc in listContacts)
                {
                    myText += rc.FullName + "       started: " + rc.LTStartDate.ToString("dd-MMM-yyyy") +
                        "    due: " + rc.LTStartDate.AddDays(84).ToString("dd-MMM-yyyy") + Environment.NewLine;  // "\n\r";
                }

                txtReport.Text = myText;
                lblText.Text = "Finished";

            }
            catch (Exception ex)
            {
                lblText.Text = "Error";
                Debug.DebugMessage(2, "Error Creating LongTermReport: " + ex.Message);
            }
        }

        private void CreateDBSupdateCheckReport(string from)
        {
            try
            {

                string WhereSQL = "WHERE datediff(d,'" + from + "', [DBSUpdateSvcChkdDate]) < 0   ";
                if (chkCurrent.Checked) WhereSQL += " AND [Current] = 1 ";
                WhereSQL += "ORDER BY  [DBSUpdateSvcChkdDate] ASC ";

                DBManager dbm = new DBManager();
                List<RContact> listContacts = dbm.GetContacts(WhereSQL);

                string myText = "";

                myText = listContacts.Count().ToString() + " Contacts in Report" + Environment.NewLine;

                foreach (RContact rc in listContacts)
                {
                    myText += rc.FullName + "       last checked: " + rc.DBSUpdateServiceCheckedDate.ToString("dd-MMM-yyyy") 
                        + Environment.NewLine;  // "\n\r";
                }

                txtReport.Text = myText;
                lblText.Text = "Finished";

            }
            catch (Exception ex)
            {
                lblText.Text = "Error";
                Debug.DebugMessage(2, "Error Creating CreateDBSupdateCheckReport: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblText.Text = "Loading Report...";
            txtReport.Text = "";
            timer1.Enabled = true;
        }


    }
}
