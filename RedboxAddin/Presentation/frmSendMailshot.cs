using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace RedboxAddin.Presentation
{
    public partial class frmSendMailshot : Form
    {
        DataSet DSSchools = null;
        DataSet DSUsers = null;
        bool chkTeacherState = true;
        bool chkSchoolState = false;

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
                    if (grdCurrntUsers.Rows[i].Cells[0].Value.ToString() == "True")
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
            try
            {
                List<SelectedContacts> selectCheckedContacts = SelectCheckedContacts();
                if (MessageBox.Show("Are you sure? This will send an email to " + selectCheckedContacts.Count + " contacts! ", "Send mail", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    currentInspector = Globals.objOutlook.ActiveInspector();
                    myMail = currentInspector.CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;

                    foreach (var selectedcontact in selectCheckedContacts)
                    {
                        lblSending.Text = "Sending email to " + selectedcontact.Name;
                        objSendMailshot.SendMail(selectedcontact.Name, objSendMailshot.GetEmails(selectedcontact.Email),ref myMail);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in btnSendNow_Click : " + ex.Message);
            }

            finally
            {
                if (myMail != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(myMail);
                GC.Collect();
            }

            lblSending.Text = "";
        }
        
    }
}
