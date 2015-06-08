using RedboxAddin.BL;
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
    public partial class frmTestEmailAddress : Form
    {
        string AppDataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RedboxAddin\";
        private RTestEmail OriginalName = null;
        private RTestEmail EditedName = null;

        public frmTestEmailAddress()
        {
            InitializeComponent();
        }

        public RTestEmail ShowDialogExt(RTestEmail name)
        {
            this.OriginalName = name;
            this.EditedName = name;
            DialogResult myResult = base.ShowDialog();

            if (myResult == System.Windows.Forms.DialogResult.OK)
            {
                return EditedName;
            }
            else
            {
                return OriginalName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  
            lblInvalidMsg.Text = "";

            if (IsValidEmail(txtTestEmail.Text.Trim().ToString()))
            {
                SaveTestEmail(txtTestEmail.Text.Trim().ToString());

                string text1 = File.ReadAllText(AppDataFilePath + "TestEmail.txt");

                EditedName.TestEmail = txtTestEmail.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                //SendTestMail(txtTestEmail.Text.Trim().ToString());                
            }
            else
            {
                lblInvalidMsg.Text = "Invalid email address.";
            }

        }

        private bool IsValidEmail(string email)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(email, pattern)) { return true; }
            else { return false; }
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

        private void SaveTestEmail(string email)
        {
            try
            {
                System.IO.File.WriteAllText(AppDataFilePath + "TestEmail.txt", email);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SaveTestEmail : " + ex.Message);
            }
        }

        private void frmTestEmailAddress_Load(object sender, EventArgs e)
        {
            txtTestEmail.Text = OriginalName.TestEmail;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
