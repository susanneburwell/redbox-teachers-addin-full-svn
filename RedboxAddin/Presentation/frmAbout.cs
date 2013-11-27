using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using RedboxAddin.BL;
using RedboxAddin.DL;
using Debug = RedboxAddin.BL.Debug;
using RedboxAddin.Models;

namespace RedboxAddin.Presentation
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblRedemptionVersion.Text = RedemptionCode.rSession.Version;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVersion.Text = fvi.ProductVersion;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmExtractData frmObj = new frmExtractData();
            frmObj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reminderList = new DBManager().GetContacts();
            Debug.DebugMessage(2, "Number of contacts to create reminders " + reminderList.Count.ToString());
            foreach (var item in reminderList)
            {
                Debug.DebugMessage(3, "for " + item.FirstName + " " + item.LastName);
                Create12QPReminder(item.FirstName + " " + item.LastName, item.LTStartDate, item.contactID);
                Create1YearReminder(item.FirstName + " " + item.LastName, item.LTStartDate, item.contactID);
                CreateCRBReminder(item.FirstName + " " + item.LastName, item.CRBExpiryDate, item.contactID);
                CreateRedboxStartReminder(item.FirstName + " " + item.LastName, item.RedboxStartDate, item.contactID);
                CreateVisaExpiryReminder(item.FirstName + " " + item.LastName, item.VisaExpiryDate, item.contactID);
            }
        }

        private bool CreateCRBReminder(string fullName,DateTime dtVal,long contactID)
        {
            string reminderType = "CRB Expiry";
            if (dtVal == DateTime.MinValue)
            {
                Debug.DebugMessage(3, "DT value null");               
                return false;
            }
            else if (new DBManager().ReminderExist(contactID, reminderType))
            {
                Debug.DebugMessage(3, "Reminder Exists"); 
                return true;
            };
            RReminder reminderObj = new RReminder();
            reminderObj.contactID = contactID;
            reminderObj.Subject = "CRB Expiry Reminder " + dtVal.ToLongDateString() + " " + fullName;
            reminderObj.Status = "Due";
            reminderObj.Type = reminderType;
            reminderObj.DueDate = dtVal.AddDays(-90);
            if (new DBManager().AddReminder(reminderObj))
            {
                Debug.DebugMessage(3, "CRB Expiry Reminder Created"); 
                return true;
            }
            return false;
        }

        private bool Create12QPReminder(string fullName, DateTime dtVal, long contactID)
        {
            string reminderType = "12QP";
            if (dtVal == DateTime.MinValue)
            {
                Debug.DebugMessage(3, "DT value null");
                return false;
            }
            else if (new DBManager().ReminderExist(contactID, reminderType))
            {
                Debug.DebugMessage(3, "Reminder Exists"); 
                return true;
            };
            RReminder reminderObj = new RReminder();
            reminderObj.contactID = contactID;
            reminderObj.Subject = "12QP Reminder " + dtVal.ToLongDateString() + " " + fullName;
            reminderObj.Status = "Due";
            reminderObj.Type = reminderType;
            reminderObj.DueDate = dtVal.AddDays(70);
            if (new DBManager().AddReminder(reminderObj))
            {
                Debug.DebugMessage(3, " 12qp Reminder Created"); 
                return true;
            }
            return false;
        }

        private bool Create1YearReminder(string fullName, DateTime dtVal, long contactID)
        {
            string reminderType = "1Year";
            if (dtVal == DateTime.MinValue)
            {
                Debug.DebugMessage(3, "DT value null");
                return false;
            }
            else if (new DBManager().ReminderExist(contactID, reminderType))
            {
                Debug.DebugMessage(3, "Reminder Exists"); 
                return true;
            };
            RReminder reminderObj = new RReminder();
            reminderObj.contactID = contactID;
            reminderObj.Subject = "1 Year Reminder " + dtVal.ToLongDateString() + " " + fullName;
            reminderObj.Status = "Due";
            reminderObj.Type = reminderType;
            reminderObj.DueDate = dtVal.AddYears(1);
            if (new DBManager().AddReminder(reminderObj))
            {
                Debug.DebugMessage(3, "1 year Reminder Created"); 
                return true;
            }
            return false;
        }

        private bool CreateRedboxStartReminder(string fullName, DateTime dtVal, long contactID)
        {
            string reminderType = "Redbox Start";
            if (dtVal == DateTime.MinValue)
            {
                Debug.DebugMessage(3, "DT value null");
                return false;
            }
            else if (new DBManager().ReminderExist(contactID, reminderType))
            {
                Debug.DebugMessage(3, "Reminder Exists"); 
                return true;
            };
            RReminder reminderObj = new RReminder();
            reminderObj.contactID = contactID;
            reminderObj.Subject = "Redbox Start Reminder " + dtVal.ToLongDateString() + " " + fullName;
            reminderObj.Status = "Due";
            reminderObj.Type = reminderType;
            reminderObj.DueDate = dtVal;
            if (new DBManager().AddReminder(reminderObj))
            {
                Debug.DebugMessage(3, " redbox start Reminder Created"); 
                return true;
            }
            return false;
        }

        private bool CreateVisaExpiryReminder(string fullName, DateTime dtVal, long contactID)
        {
            string reminderType = "Visa Expiry";
            if (dtVal == DateTime.MinValue)
            {
                Debug.DebugMessage(3, "DT value null");
                return false;
            }
            else if (new DBManager().ReminderExist(contactID, reminderType))
            {
                Debug.DebugMessage(3, "Reminder Exists");
                return true;
            };
            RReminder reminderObj = new RReminder();
            reminderObj.contactID = contactID;
            reminderObj.Subject = "Visa Expiry Reminder " + dtVal.ToLongDateString() + " " + fullName;
            reminderObj.Status = "Due";
            reminderObj.Type = reminderType;
            reminderObj.DueDate = dtVal.AddMonths(-3);
            if (new DBManager().AddReminder(reminderObj))
            {
                Debug.DebugMessage(3, "visa expiry Reminder Created");
                return true;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {      

            try
            {
                DataSet msgDs = new DBManager(). GetDataSet("Select CategoryStr,contactID from Contacts");
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        string categoryString = dr["CategoryStr"].ToString();
                        var arr = categoryString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < arr.Length; i++)
                        {
                            new DBManager().ExecuteQuery("INSERT INTO Categories (CategoryName) VALUES('" + arr[i].Trim() + "')");
                        }
                    }                    
                }                
            }
            catch (Exception ex) {  }
        }
        

       
    }
}
