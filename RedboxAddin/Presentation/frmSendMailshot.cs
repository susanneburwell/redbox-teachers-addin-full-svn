using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace RedboxAddin.Presentation
{
    public partial class frmSendMailshot : Form
    {
        string testemailaddress = "";
        DataSet DSSchools = null;
        DataSet DSUsers = null;
        bool chkTeacherState = true;
        bool chkSchoolState = false;
        string AppDataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RedboxAddin\";

        public frmSendMailshot()
        {
            InitializeComponent();
        }

        private void frmSendMailshot_Load(object sender, EventArgs e)
        {
            // load data 
            DSSchools = new DBManager().GetSchooltContacts();
            DSUsers = new DBManager().GetCurrentContacts();
            DrawDatagrid(chkTeacherState, chkSchoolState);

            DisplayTestEmail();

        }

        private void chkTeachers_CheckedChanged(object sender, EventArgs e)
        {
            chkTeacherState = chkTeachers.Checked;
            DrawDatagrid(chkTeacherState, chkSchoolState);
        }

        private void chkSchool_CheckedChanged(object sender, EventArgs e)
        {
            chkSchoolState = chkSchool.Checked;
            DrawDatagrid(chkTeacherState, chkSchoolState);
        }

        private void DrawDatagrid(bool teachersState, bool schoolsState)
        {
            try
            {
                lblSending.Text = "";
                grdCurrntUsers.DataSource = null;

                DataTable table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Email", typeof(string));
                table.Columns.Add("User", typeof(string));

                if (teachersState)
                {
                    foreach (DataRow dataRow in DSUsers.Tables[0].Rows)
                    {
                        table.Rows.Add(dataRow[0].ToString(), dataRow[2].ToString(), "Teacher");
                    }
                }

                if (schoolsState)
                {
                    foreach (DataRow dataRow in DSSchools.Tables[0].Rows)
                    {
                        table.Rows.Add(dataRow[0].ToString(), dataRow[1].ToString(), "School");
                    }
                }
                grdCurrntUsers.DataSource = table;

                grdCurrntUsers.Columns[1].Width = 200;
                grdCurrntUsers.Columns[2].Width = 250;
                grdCurrntUsers.Columns[3].Visible = false;


                for (int i = 0; i < grdCurrntUsers.Rows.Count; i++)
                {
                    grdCurrntUsers.Rows[i].Cells[0].Value = true;
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DrawDatagrid : " + ex.Message);
            }
        }

        private List<SelectedContacts> SelectCheckedContacts()
        {
            List<SelectedContacts> selectedContacts = new List<SelectedContacts>();

            try
            {
                for (int i = 0; i < grdCurrntUsers.Rows.Count; i++)
                {
                    if (grdCurrntUsers.Rows[i].Cells[0].Value != null && grdCurrntUsers.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        SelectedContacts selectedContact = new SelectedContacts();
                        selectedContact.Name = grdCurrntUsers.Rows[i].Cells[1].Value.ToString();
                        selectedContact.Email = grdCurrntUsers.Rows[i].Cells[2].Value.ToString();
                        selectedContact.User = grdCurrntUsers.Rows[i].Cells[3].Value.ToString();
                        selectedContacts.Add(selectedContact);
                    }
                }
            }
            catch (Exception ex)
            {
                selectedContacts = null;
                Debug.DebugMessage(2, "Error in SelectCheckedContacts : " + ex.Message);
            }

            return selectedContacts;
        }

        private void btnSendNow_Click(object sender, EventArgs e)
        {
            Outlook.Inspector currentInspector = null;
            Outlook.MailItem myMail = null;
            SendMailshot objSendMailshot = new SendMailshot();
            List<SelectedContacts> selectCheckedContacts = SelectCheckedContacts();
            try
            {
                if (MessageBox.Show("Are you sure? This will send an email to " + selectCheckedContacts.Count + " contacts! ", "Send mail", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    currentInspector = Globals.objOutlook.ActiveInspector();
                    myMail = currentInspector.CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;

                    foreach (var selectedcontact in selectCheckedContacts)
                    {
                        lblSending.Text = "Sending email to " + selectedcontact.Name;
                        objSendMailshot.SendMail(selectedcontact.Name, objSendMailshot.GetEmails(selectedcontact.Email), ref myMail);
                    }

                    if (selectCheckedContacts.Count == 1) { lblSending.Text = "The e-mail has been successfully sent for " + selectCheckedContacts.Count + " contact"; }
                    else if (selectCheckedContacts.Count > 1) { lblSending.Text = "E-Mails have been successfully sent for " + selectCheckedContacts.Count + " contacts"; }
                    else if (selectCheckedContacts.Count == 0) { lblSending.Text = "The e-mails has been successfully sent for " + selectCheckedContacts.Count + " contact"; }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in btnSendNow_Click : " + ex.Message);
                lblSending.Text = "E-Mail has not been sent";
            }

            finally
            {
                if (myMail != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(myMail);
                GC.Collect();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string TESTEMAIL = GetTestEmail();
            if (string.IsNullOrEmpty(TESTEMAIL))
            {
                btnAdd_Click(null, null);
            }
            else
            {
                SendTestMail(TESTEMAIL);
            }

        }

        private void SendTestMail(string testemail)
        {
            Outlook.Inspector currentInspector = null;
            Outlook.MailItem myMail = null;
            SendMailshot objSendMailshot = new SendMailshot();
            try
            {
                currentInspector = Globals.objOutlook.ActiveInspector();
                myMail = currentInspector.CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;
                objSendMailshot.TestSendMail(testemail, ref myMail);
                lblSending.Text = "Test mail has been sent successfully.";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendTestMail : " + ex.Message);
            }
            finally
            {
                if (myMail != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(myMail);
                GC.Collect();
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTestEmailAddress frmObj = new frmTestEmailAddress();
            RTestEmail namesObj = frmObj.ShowDialogExt(new RTestEmail() { TestEmail = testemailaddress });
            testemailaddress = namesObj.TestEmail;
            lblTestEmail.Text = "Test Email : " + testemailaddress;
            btnAdd.Text = "Change";

        }

        private string GetTestEmail()
        {
            string testEmail = string.Empty;

            if (File.Exists(AppDataFilePath + "TestEmail.txt"))
            {
                try
                {
                    testEmail = File.ReadAllText(AppDataFilePath + "TestEmail.txt");
                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "Error in GetTestEmail: " + ex.Message);
                    return null;

                }
            }
            return testEmail;
        }

        private void DisplayTestEmail()
        {
            string TESTEMAIL = GetTestEmail();
            if (!string.IsNullOrEmpty(TESTEMAIL))
            {
                lblTestEmail.Text = "Test Email : " + TESTEMAIL;
                btnAdd.Text = "Change";
                testemailaddress = TESTEMAIL;
            }
            else
            {
                lblTestEmail.Text = "Please add test email before test mail : ";
                btnAdd.Text = "Add";
            }

        }


    }
}
