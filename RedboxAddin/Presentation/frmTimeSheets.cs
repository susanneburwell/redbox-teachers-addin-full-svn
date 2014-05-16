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
            string timesheetfilepath = "";
            try
            {
                string weekEnding = dtFrom.Value.AddDays(4).ToString("dd-MMM-yyyy");

                //save file to temp folder
                string timeSheetfolder = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\TimeSheets";
                if (!Directory.Exists(timeSheetfolder)) Directory.CreateDirectory(timeSheetfolder);

                timesheetfilepath = timeSheetfolder + "\\" + "TimeSheet_" + cmbSchool.Text + "_" + weekEnding + ".pdf";

                using (System.IO.FileStream myPDF = new FileStream(timesheetfilepath, FileMode.Create))
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
                atts.Add(timesheetfilepath);
                oMail.Subject = "Redbox Timesheet " + cmbSchool.Text + " Week Ending: " + weekEnding;
                oMail.To = emailAddress;
                oMail.CC = "admin@redboxteachers.co.uk";
                oMail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                oMail.HTMLBody = timesheetText();


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

        private string timesheetText()
        {
            string myText = "<BODY><p><SPAN style=\"FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666; FONT-FAMILY: arial\">" + 
                             "Please find attached the Timesheet for week beginning " + dtFrom.Value.ToString("dd-MMM-yyyy")
                          + ".  Please check and confirm the details by replying to this message.</SPAN></p>"
                          + "<TABLE  border:1px solid black; cellSpacing=0 cellPadding=10 width=\"100%\"\">"
                          +"<TBODY>";

            //Header Text
            string myRowText = "<TR style=\"FONT-WEIGHT: bold; FONT-SIZE: 14px; FONT-FAMILY: arial\">";
            myRowText += "<TD>Teacher</TD>";
            myRowText += "<TD>Days Worked</TD>";
            myRowText += "<TD>Total days</TD>";
            myRowText += "<TD>Description</TD>";

            myRowText += "</TR>";
            myText += myRowText;
            try
            {
                int numrows = gridView1.RowCount;

                for (int myRow = 0; myRow < numrows; myRow++)
                {
                    string myName = gridView1.GetRowCellValue(myRow, "FullName").ToString();
                    string mydays = gridView1.GetRowCellValue(myRow, "days").ToString();
                    string mynumDays = gridView1.GetRowCellValue(myRow, "numDays").ToString();
                    string myDescription = gridView1.GetRowCellValue(myRow, "Description").ToString();

                    myRowText = "<TR style=\"FONT-SIZE: 12px; FONT-FAMILY: arial\">";
                    myRowText += "<TD>" + myName + "</TD>";
                    myRowText += "<TD>" + mydays + "</TD>";
                    myRowText += "<TD>" + mynumDays + "</TD>";
                    myRowText += "<TD>" + myDescription + "</TD>";

                    myRowText += "</TR>";
                    myText += myRowText;
                }

                myText += "</TBODY></BODY>";

            return myText;
                
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in timesheetTable: " + ex.Message);
                return "There was an erropr creating the timesheet";
            }
        }


    }
}
