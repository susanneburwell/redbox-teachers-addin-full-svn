using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace RedboxAddin.BL
{
    public class SendMailshot
    {

        public void SendMail(string firstname, string email, ref Outlook.MailItem myMail)
        {
            Outlook.MailItem oMailCopy = null;
            try
            {
                oMailCopy = myMail.Copy();
                oMailCopy.To = email;
                //oMailCopy.To = "croosb@gmail.com";
                oMailCopy.HTMLBody = myMail.HTMLBody.Replace("[Name]", firstname);
                oMailCopy.Send();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendMail : " + ex.Message);
            }

            finally
            {
                if (oMailCopy != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oMailCopy);
                GC.Collect();
            }

        }

        public bool TestSendMail(string email, ref Outlook.MailItem myMail)
        {
            Outlook.MailItem oMailCopy = null;
            try
            {
                oMailCopy = myMail.Copy();
                oMailCopy.To = email;
                //oMailCopy.Subject = "Test Mail";
                oMailCopy.HTMLBody = myMail.HTMLBody.Replace("[Name]", "Test Name");
                oMailCopy.Send();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in TestSendMail : " + ex.Message);
                return false;
            }

            finally
            {
                if (oMailCopy != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oMailCopy);
                GC.Collect();
            }

        }

        private bool IsValidEmail(string email)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(email, pattern)) { return true; }
            else { return false; }
        }

        public string GetEmails(string emails)
        {
            string allEmails = string.Empty;
            try
            {
                string[] emailsArray = emails.Split(';');
                foreach (string mail in emailsArray)
                {
                    if (IsValidEmail(mail.Trim()))
                    {
                        allEmails += mail + "; ";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetEmails : " + ex.Message);
            }

            return allEmails;
        }


    }
}
