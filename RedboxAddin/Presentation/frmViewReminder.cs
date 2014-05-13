using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.Models;
using RedboxAddin.DL;
using RedboxAddin.BL;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;

namespace RedboxAddin.Presentation
{
    public partial class frmViewReminder : Form
    {
        RReminder GReminder = null;
        long ReminderID = 0;
        private long p;
        public frmViewReminder(long reminderID)
        {
            ReminderID = reminderID;
            GReminder = new DBManager().GetReminder(reminderID);
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Save Reminder details
            if (GReminder == null) GReminder = new RReminder();
            GReminder.Subject = txtSubject.Text;
            GReminder.Status = cmbStatus.Text;
            GReminder.DueDate = dtDueDate.Value;
            GReminder.Notes = txtNotes.Text;
            GReminder.CompletedBy = txtCompletedBy.Text;
            new DBManager().UpdateReminder(GReminder, ReminderID);

            AddOutlookReminder(GReminder);

            this.Close();
        }

        private void frmViewReminder_Load(object sender, EventArgs e)
        {
            if (GReminder == null) return;
            txtSubject.Text = GReminder.Subject;
            txtNotes.Text = GReminder.Notes;
            dtDueDate.Value = GReminder.DueDate;
            cmbStatus.Text = GReminder.Status;
            txtCompletedBy.Text = GReminder.CompletedBy;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "Completed")
            {
                lblCompletedBy.Visible = true;
                txtCompletedBy.Visible = true;
            }
            else
            {
                lblCompletedBy.Visible = false;
                txtCompletedBy.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewContact contactFrmObj = new frmViewContact(GReminder.contactID);
            contactFrmObj.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete Reminder
            if (new DBManager().ExecuteQuery("DELETE FROM Reminders WHERE ReminderID = '" + ReminderID.ToString() + "'"))
            {
                this.Close();
            }
        }


        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            try
            {
                txtNotes.Text = DateTime.Now.ToString() + "  " + RedemptionCode.OutlookUserName + Environment.NewLine + "*********************************************************" + Environment.NewLine + txtNotes.Text;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error adding notes " + ex.Message);
            }
        }

        private void AddOutlookReminder(RReminder rr)
        {
            try
            {
                MAPIFolder oCalendar = Globals.objNS.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                Items oItems = oCalendar.Items;
                AppointmentItem oApp = null;
                //Find Appointment with BillingInfo =  rr.reminderID

                string searchCriteria = "[BillingInformation] = \"" + rr.reminderID.ToString() + "\"";
                object resultItem = oItems.Find(searchCriteria);
                if ((resultItem != null) && (resultItem is _AppointmentItem))
                {
                    oApp = resultItem as AppointmentItem;
                }
                else
                {
                    oApp = oItems.Add("IPM.Appointment");
                }

                oApp.Start = rr.DueDate;
                oApp.Subject = rr.Subject;
                oApp.Body = rr.Notes;
                oApp.ReminderSet = true;
                oApp.ReminderMinutesBeforeStart = 0;
                oApp.BillingInformation = rr.reminderID.ToString();
                oApp.Save();

                if (oApp != null) Marshal.ReleaseComObject(oApp);
                if (oItems != null) Marshal.ReleaseComObject(oItems);
                if (oCalendar != null) Marshal.ReleaseComObject(oCalendar);


            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in AddOutlookReminder " + ex.Message);
                MessageBox.Show("There was an error adding this notification to your Outlook calendar.\r" + ex.Message);
            }
        }

    }
}
