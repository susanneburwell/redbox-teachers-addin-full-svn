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
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;
using DevExpress.XtraPrintingLinks;
using System.Runtime.InteropServices;


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
                //prepare grid for printing
                gridView1.ViewCaption = "Redbox Teachers TimeSheet - " + cmbSchool.Text + " Week beginning " + dtFrom.Value.ToString("dd-MMM-yyyy");

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

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendTimeSheet();
        }

        private void SendTimeSheet()
        {
            string tempfilepath = "";
            try
            {

                //save file to temp folder
                string tempfolder = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\TimeSheets";
                if (!Directory.Exists(tempfolder)) Directory.CreateDirectory(tempfolder);

                tempfilepath = tempfolder + "\\" + "TimeSheet_" + cmbSchool.Text + "_" + dtFrom.Value.ToString("dd-MMM-yyyy") + ".pdf";

                using (System.IO.FileStream myPDF = new FileStream(tempfilepath, FileMode.Create))
                {
                    gridControl1.ExportToPdf(myPDF);
                    myPDF.Flush();
                    myPDF.Close();
                }

                //get contact details for school
                long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                string emailAddress = LINQmanager.GetEmailAddressforSchoolID(schoolID);



                //create email
                Outlook.MailItem oMail = Globals.objOutlook.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
                Outlook.Attachments atts = oMail.Attachments;
                atts.Add(tempfilepath);
                oMail.Subject = "Redbox Timesheet Week Beginning: " + dtFrom.Value.ToString("dd-MMM-yyyy");
                oMail.To = emailAddress;
                oMail.CC = "admin@redboxteachers.co.uk";
                oMail.Body = "Please find attached the Timesheet for week beginning " + dtFrom.Value.ToString("dd-MMM-yyyy") +
                    "/R" + "Please check and confirm the details by replying to this message";

                if (chkSendAuto.Checked)
                {
                    oMail.Send();
                }
                else
                {
                    oMail.Display();
                }
                if (atts != null) Marshal.ReleaseComObject(atts);
                if (oMail != null) Marshal.ReleaseComObject(oMail);


            }
            catch (System.IO.IOException exio)
            {
                MessageBox.Show("There was a problem saving file to: " + @tempfilepath + "\r Please check that it is not already open in another window");
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendTimeSheet: " + ex.Message);
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = gridControl1.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    long MasterBookingID = Utils.CheckLong(gridView1.GetRowCellValue(info.RowHandle, "ID"));
                    string description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString();

                    frmMasterBooking fMB = new frmMasterBooking(MasterBookingID);
                    fMB.Show();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in AvailabilityGrid_DoubleClick: " + ex.Message);
            }
        }




    }
}
