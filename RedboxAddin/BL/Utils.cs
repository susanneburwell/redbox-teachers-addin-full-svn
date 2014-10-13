using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.DL;
using Redemption;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Drawing;



namespace RedboxAddin.BL
{
    static class Utils
    {
        internal static string GetFullName(string prefix, string firstName, string middleName, string lastName, string suffix)
        {
            string fullname = "";
            if (!string.IsNullOrEmpty(prefix)) fullname = fullname + prefix + " ";
            if (!string.IsNullOrEmpty(firstName)) fullname = fullname + firstName + " ";
            if (!string.IsNullOrEmpty(middleName)) fullname = fullname + middleName + " ";
            if (!string.IsNullOrEmpty(lastName)) fullname = fullname + lastName + " ";
            if (!string.IsNullOrEmpty(suffix)) fullname = fullname + suffix + " ";
            return fullname;
        }

        internal static string GetAddress(string street, string city, string state, string postcode, string country)
        {
            string fullAddress = "";
            if (!string.IsNullOrEmpty(street)) fullAddress = fullAddress + street + "\n";
            if (!string.IsNullOrEmpty(city)) fullAddress = fullAddress + city + "\n";
            if (!string.IsNullOrEmpty(state)) fullAddress = fullAddress + state + "\n";
            if (!string.IsNullOrEmpty(postcode)) fullAddress = fullAddress + postcode + "\n";
            if (!string.IsNullOrEmpty(country)) fullAddress = fullAddress + country + "\n";
            return fullAddress;
        }

        internal static decimal GetDayRate(object myObject)
        {
            try
            {
                string value = myObject.ToString().Trim();
                if ((value == "TA") || (string.IsNullOrWhiteSpace(value))) return -1;

                Decimal dec = Convert.ToDecimal(myObject);
                return dec;
            }
            catch
            {
                return Convert.ToDecimal("-1");
            }
        }

        public static string CheckString(object myObject)
        {
            try
            {
                if (System.DBNull.Value == myObject)
                {
                    return "";
                }
                else if (myObject == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(myObject);
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "CheckString Failed :- " + ex.Message);
                return "";
            }
        }

        public static bool CheckBool(object myObject)
        {
            try
            {
                if (System.DBNull.Value == myObject)
                {
                    return false;
                }
                else if (myObject == null)
                {
                    return false;
                }
                else if (myObject.ToString().ToLower() == "yes")
                {
                    return true;
                }
                else if (myObject.ToString().Trim() == "1")
                {
                    return true;
                }

                else
                {
                    return Convert.ToBoolean(myObject);
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(4, "CheckBool Failed :- " + ex.Message);
                return false;
            }
        }

        public static decimal CheckDecimal(object myObject)
        {

            try
            {
                Decimal dec = Convert.ToDecimal(myObject);
                return dec;
            }
            catch
            {
                return Convert.ToDecimal("00.0");
            }
        }

        public static Int32 CheckInt(object myObject)
        {

            try
            {
                if (myObject == null) return -1;
                int myInt = Convert.ToInt32(myObject);
                return myInt;
            }
            catch
            {
                return -1;
            }
        }

        public static Int64 CheckLong(object myObject)
        {

            try
            {
                if (myObject == null) return -1;

                long myInt = Convert.ToInt64(myObject);
                return myInt;
            }
            catch
            {
                return -1;
            }
        }

        public static DateTime CheckDate(object myObject)
        {

            try
            {
                DateTime md = Convert.ToDateTime(myObject);
                return md;
            }
            catch
            {
                return Convert.ToDateTime("2000-01-01");
            }
        }

        public static bool validateDecimal(string text)
        {
            try
            {
                Decimal dec = Convert.ToDecimal(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Dictionary<int, string> ExtractAppointmentData(string data)
        {
            Dictionary<int, string> datastring = new Dictionary<int, string>();
            try
            {
                string school = data.Substring(0, data.IndexOf(' ')).Trim();
                string other = data.Substring(data.IndexOf(' ')).Trim();
                datastring.Add(1, school);
                datastring.Add(2, other);
                return datastring;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in ExtractAppointmentData: " + ex.Message);
                return datastring;
            }
        }

        //internal static bool CheckForRedboxFolder()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in CheckForRedboxFolder() :- " + ex.Message);
        //    }
        //}

        public static string TeacherQuals(bool TA, bool QTS, bool NQT, bool OTT, bool QNN, bool NN, bool SEN, bool PPA, bool Float)
        {
            string Quals = "";
            if (TA) Quals += "/TA";
            if (QTS) Quals += "/QTS";
            if (NQT) Quals += "/NQT";
            if (OTT) Quals += "/OTT";
            if (QNN) Quals += "/QNN";
            if (NN) Quals += "/NN";
            if (SEN) Quals += "/SEN";
            if (PPA) Quals += "/PPA";
            if (Float) Quals += "/Float";

            if (Quals != "") Quals = Quals.Substring(1);
            return Quals;
        }

        public static string YearGroup(bool Nur, bool Rec, bool Yr1, bool Yr2, bool Yr3, bool Yr4, bool Yr5, bool Yr6)
        {
            string agegroup = "";
            if (Nur) agegroup += "Nur/";
            if (Rec) agegroup += "Rec/";
            if (Yr1) agegroup += "Yr1/";
            if (Yr2) agegroup += "Yr2/";
            if (Yr3) agegroup += "Yr3/";
            if (Yr4) agegroup += "Yr4/";
            if (Yr5) agegroup += "Yr5/";
            if (Yr6) agegroup += "Yr6";

            agegroup = agegroup.Replace("Nur/Rec", "Nur-Rec");
            agegroup = agegroup.Replace("Rec/Yr1", "Rec-Yr1");
            agegroup = agegroup.Replace("Yr1/Yr2", "Yr1-Yr2");
            agegroup = agegroup.Replace("Yr2/Yr3", "Yr2-Yr3");
            agegroup = agegroup.Replace("Yr3/Yr4", "Yr3-Yr4");
            agegroup = agegroup.Replace("Yr4/Yr5", "Yr4-Yr5");
            agegroup = agegroup.Replace("Yr5/Yr6", "Yr5-Yr6");

            agegroup = agegroup.Replace("-Rec-", "-");
            agegroup = agegroup.Replace("-Yr1-", "-");
            agegroup = agegroup.Replace("-Yr2-", "-");
            agegroup = agegroup.Replace("-Yr3-", "-");
            agegroup = agegroup.Replace("-Yr4-", "-");
            agegroup = agegroup.Replace("-Yr5-", "-");

            if (agegroup.Length > 0)
            {
                if (agegroup.Substring(agegroup.Length - 1) == "/") agegroup = agegroup.Substring(0, agegroup.Length - 1);
            }

            return agegroup;
        }

        public static void PopulateSchools(ComboBox cmbSchool)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var q = from s in db.Schools
                            orderby s.SchoolName
                            select s;
                    var schools = q.ToList();
                    cmbSchool.DataSource = schools;
                    cmbSchool.DisplayMember = "SchoolName";
                    cmbSchool.ValueMember = "ID";
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        public static void PopulateTeacher(ComboBox cmb1, bool sortByLastName)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    if (sortByLastName)
                    {
                        var q = from s in db.Contacts
                                join c in db.ContactDatas on s.ContactID equals c.ContactID
                                where s.LastName != null && c.Current == true
                                orderby s.LastName
                                select new { FullName = (s.LastName + ',' + ' ' + s.FirstName), s.ContactID };
                        //select new CHTest { FullName = (s.LastName + ','+' ' + s.FirstName),ContactID= s.ContactID };
                        var teachers = q.ToList();

                        cmb1.DataSource = teachers;
                        cmb1.DisplayMember = "FullName";
                        cmb1.ValueMember = "ContactID";
                        cmb1.Text = "";
                    }
                    else
                    {
                        var q = from s in db.Contacts
                                join c in db.ContactDatas on s.ContactID equals c.ContactID
                                where s.LastName != null && c.Current == true
                                orderby s.FirstName
                                select new { FullName = (s.FirstName + ',' + ' ' + s.LastName), s.ContactID };
                        var teachers = q.ToList();

                        cmb1.DataSource = teachers;
                        cmb1.DisplayMember = "FullName";
                        cmb1.ValueMember = "ContactID";
                        cmb1.Text = "";
                    }                    
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        public static void PopulateBookingStatuses(ComboBox cmb1)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR)) 
                {

                    var q = from s in db.BookingStatuses
                            //orderby s.Status
                            select s;
                    var bookingStatuses = q.ToList();
                    cmb1.Items.Clear();
                    foreach (var pt in bookingStatuses)
                    {
                        cmb1.Items.Add(pt.Status);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateBookingStatuses: " + ex.Message);
            }
        }

        public static DateTime GetFirstDayoftheWeek(DateTime mydate)
        {
            //Get first day of week
            DateTime input = mydate.Date;
            int delta = DayOfWeek.Monday - input.DayOfWeek;
            if (delta > 0) delta -= 7;
            DateTime monday = input.AddDays(delta).Date;
            return monday;
        }

        public static bool SendNotification(long bookingID, string description)
        {
            try
            {
                MasterBooking mb = LINQmanager.GetMasterBookingbyID(bookingID);

                if (mb.ContactID == null) return false;
                Contact contact = LINQmanager.GetContactbyID((long)mb.ContactID);
                School school = LINQmanager.GetSchoolbyID((long)mb.SchoolID);

                MailItem oMail = Globals.objOutlook.CreateItem(OlItemType.olMailItem) as MailItem;
                string subject = "Redbox Booking: " + mb.StartDate.ToLongDateString();
                string details = "Dear " + contact.FirstName;
                details += "\rPlease confirm acceptance of the following booking:";
                details += "\r\rSchool: " + school.SchoolName;
                details += "\rFirst Day: " + mb.StartDate.ToLongDateString();
                details += "\rFinal Day: " + mb.EndDate.ToLongDateString();
                details += "\r\rDescription: " + description;
                details += "\r\rOther Details:" + mb.Details;
                details += "\r\rSchool Address:\r " + school.Address;

                oMail.To = contact.Email1;
                oMail.Subject = subject;
                oMail.Body = details;
                oMail.Display();


                return true;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendNotification(2): " + ex.Message);
                return false;
            }
        }

        public static bool SendVettingDetails(long schoolID, long contactID)
        {
            try
            {
                //get school 
                School school = LINQmanager.GetSchoolbyID(schoolID);
                string schoolEmail = school.VettingEmails;

                //get contact
                Contact contact = LINQmanager.GetContactbyID(contactID);

                //create text 

                {
                    RDOFolder rFolderDrafts = null;
                    RDOItems rItems = null;
                    Redemption.RDOMail rMail = null;
                    RDOAttachments colAttach = null;
                    RDOAttachment myAttach = null;
                    MailItem oMail = null;
                    try
                    {
                        string myEntryID = "";
                        string TableMiddle = "";
                        string TableBottom = "";
                        string Replacement1 = "";
                        string Replacement2 = "";
                        string myPic = "";
                        string myBody = "";
                        string txtBody = "";

                        string contentID = "myident";
                        string TableTop = "<table border=" + (char)(34) + "1" + (char)(34) + "width=" + (char)(34) + "100%" +
                                          "id=" + (char)(34) + "table1" + (char)(34) + "height=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine +
                                          "<tr>" + Environment.NewLine + "<td width=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine;
                        rFolderDrafts = RedemptionCode.rSession.GetDefaultFolder(rdoDefaultFolders.olFolderDrafts);
                        rItems = rFolderDrafts.Items;
                        rMail = (RDOMail)rItems.Add("IPM.Note");
                        colAttach = rMail.Attachments;
                        AddAttachments(ref colAttach, contact);
                        rMail.Body = " ";
                        try
                        {
                            myAttach = colAttach.Add(contact.PhotoLocation, OlAttachmentType.olByValue, rMail.Body.Length, Type.Missing);
                            myAttach.Hidden = true;
                            myAttach.set_Fields(0x370E001E, "image/jpeg");
                            myAttach.set_Fields(0x3712001E, "myident");

                            myAttach.ContentID = contentID;
                        }
                        catch (System.Exception ex) { Debug.DebugMessage(2, "Error attaching pictures in the " + ex.Message); }

                        rMail.Save();
                        myEntryID = rMail.EntryID;

                        oMail = (MailItem)Globals.objNS.GetItemFromID(myEntryID);

                        myPic = "<DIV>" + Environment.NewLine + "<IMG style=" + " border=0 hspace=0 alt=myPic align=baseline src=cid:myident width=200 height=200>" + Environment.NewLine + "</DIV>" + Environment.NewLine;
                        TableMiddle = "</td>" + Environment.NewLine + "<td><FONT SIZE=2 FACE=" + (char)34 + "Arial" + (char)34 + ">";
                        //TODO contact.DateOfSupply
                        txtBody = txtBody + "Date of Supply: " + contact.DateOfSupply.ToString() + Environment.NewLine;
                        txtBody = txtBody + Environment.NewLine + "Supply Requirement: Basic Cover" + Environment.NewLine + Environment.NewLine;
                        txtBody = txtBody + "Teacher Name: " + contact.FirstName + " " + contact.LastName + Environment.NewLine + Environment.NewLine;
                        txtBody = txtBody + "Year Group: " + contact.YearGroup + Environment.NewLine;
                        txtBody = txtBody + Environment.NewLine + "Qualification: " + contact.Qualification;
                        if (contact.QTS == true)
                        {
                            txtBody = txtBody + Environment.NewLine + "QTS? Yes";
                        }
                        else
                        {
                            txtBody = txtBody + Environment.NewLine + "QTS? No";
                        }

                        if (contact.NQT == true)
                        {
                            txtBody = txtBody + Environment.NewLine + "NQT? Yes";
                        }
                        else
                        {
                            txtBody = txtBody + Environment.NewLine + "NQT? No";
                        }

                        if (contact.Instructor == true) { txtBody = txtBody + Environment.NewLine + "Instructor? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Instructor? No"; }

                        if (contact.OverseasTrainedTeacher == true) { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? No"; }

                        if (contact.CVReceived == true) { txtBody = txtBody + Environment.NewLine + "CV Received? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "CV Received? No"; }

                        if (contact.RedboxCRB == true) { txtBody = txtBody + Environment.NewLine + "Red Box CRB? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Red Box CRB? No"; }

                        txtBody = txtBody + Environment.NewLine + "Red Box CRB Form Ref: " + contact.CRBFormRef;
                        txtBody = txtBody + Environment.NewLine + "CRB Number: " + contact.CRBNumber;

                        if (contact.CRBValidFrom != DateTime.MinValue && contact.CRBValidFrom != null)
                        {
                            txtBody = txtBody + Environment.NewLine + "CRB Valid from: " + contact.CRBValidFrom.ToString();
                        }
                        else
                        {
                            txtBody = txtBody + Environment.NewLine + "CRB Valid from: None";
                        }

                        if (contact.AdditionalInfoOnCRB == true) { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? No"; }

                        if (contact.UpdateService == true) { txtBody = txtBody + Environment.NewLine + "DBS Update Service? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "DBS Update Service? No"; }

                        if (contact.VisaExpiryDate != DateTime.MinValue && contact.VisaExpiryDate != null)
                        {
                            txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: " + contact.VisaExpiryDate.ToString();
                        }
                        else
                        {
                            txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: None";
                        }

                        if (!string.IsNullOrEmpty(contact.VisaType))
                        {
                            txtBody = txtBody + Environment.NewLine + "Visa Type: " + contact.VisaType;
                        }
                        else
                        {
                            txtBody = txtBody + Environment.NewLine + "Visa Type: None";
                        }

                        if (contact.IDChecked == true) { txtBody = txtBody + Environment.NewLine + "ID checked? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "ID checked? No"; }

                        if (contact.OverseasPoliceCheck == true) { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? No"; }

                        if (contact.ReferencesChecked == true) { txtBody = txtBody + Environment.NewLine + "All References checked? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "All References checked? No"; }

                        if (contact.List99 == true) { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? No"; }

                        if (contact.MedicalChecklist == true) { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? No"; }

                        if (contact.ProofOfAddress == true) { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? Yes"; }
                        else { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? No"; }

                        if (contact.RegistrationDate != DateTime.MinValue && contact.RegistrationDate != null)
                        {
                            txtBody = txtBody + Environment.NewLine + "Date of Registration: " + contact.RegistrationDate.ToString();
                        }
                        else { txtBody = txtBody + Environment.NewLine + "Date of Registration: None"; }

                        txtBody = txtBody + Environment.NewLine + "GTC Number: " + contact.GTCNumber;

                        if (contact.GTCCheckDate != DateTime.MinValue && contact.GTCCheckDate != null)
                        {
                            txtBody = txtBody + Environment.NewLine + "GTC Check Date: " + contact.GTCCheckDate.ToString();
                        }
                        else { txtBody = txtBody + Environment.NewLine + "GTC Check Date: None"; }

                        if (!string.IsNullOrWhiteSpace(contact.BirthDate))
                        {
                            txtBody = txtBody + Environment.NewLine + "Date of Birth: " + contact.BirthDate;
                        }
                        else { txtBody = txtBody + Environment.NewLine + "Date of Birth: None"; }

                        txtBody = txtBody + Environment.NewLine;
                        TableBottom = "</td>" + Environment.NewLine + "</tr>" + Environment.NewLine + "</table>";
                        Replacement1 = "<BODY>" + Environment.NewLine + TableTop + myPic + TableMiddle;
                        Replacement2 = TableBottom + "</BODY>";

                        oMail.Subject = contact.FirstName + " " + contact.LastName;
                        oMail.Body = txtBody;

                        //send attachments

                        string myText = oMail.HTMLBody;
                        myText = myText.Replace("<BODY>", Replacement1);
                        myText = myText.Replace("</BODY>", Replacement2);
                        oMail.HTMLBody = myText;
                        oMail.To = schoolEmail;

                        oMail.Display();
                        oMail.Save();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in Send Details(1) : " + ex.Message);
                        return false;
                    }
                    finally
                    {
                        if (oMail != null) Marshal.ReleaseComObject(oMail);
                        if (myAttach != null) Marshal.ReleaseComObject(myAttach);
                        if (colAttach != null) Marshal.ReleaseComObject(colAttach);
                        if (rMail != null) Marshal.ReleaseComObject(rMail);
                        if (rItems != null) Marshal.ReleaseComObject(rItems);
                        if (rFolderDrafts != null) Marshal.ReleaseComObject(rFolderDrafts);
                        GC.Collect();
                    }
                }
                // pop up email
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendVettingDetails: " + ex.Message);
            }
            return false;
        }

        private static bool AddAttachments(ref RDOAttachments attachmentCol, Contact contact)
        {
            try
            {
                if (contact.SendBankStatement == true)
                {
                    if (!string.IsNullOrWhiteSpace(contact.BankStatementLocation))
                    {
                        RDOAttachment rAttachment = attachmentCol.Add(contact.BankStatementLocation);
                        if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                    }
                }
                if (contact.SendPassport == true)
                {
                    if (!string.IsNullOrWhiteSpace(contact.PassportLocation))
                    {
                        RDOAttachment rAttachment = attachmentCol.Add(contact.PassportLocation);
                        if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                    }
                }
                if (contact.SendVisa == true)
                {
                    if (!string.IsNullOrWhiteSpace(contact.VisaLocation))
                    {
                        RDOAttachment rAttachment = attachmentCol.Add(contact.VisaLocation);
                        if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in AddAttachments :- " + ex.Message);
                return false;
            }
        }

        public static string SetColours(string status, bool af, bool lt, System.Windows.Forms.ComboBox cmbBookingStatus)
        {
            //colours are abbreviated to 4 letters
            //colour is split fore/back
            string fore = "";
            string back = "";
            if (status == "") status = "Unassigned";

            switch (status)
            {

                case "Unassigned":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Red;
                        cmbBookingStatus.BackColor = Color.Yellow;
                    }
                    fore = "redd";
                    back = "yell";
                    break;
                case "Contacted":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Purple;
                        cmbBookingStatus.BackColor = Color.Yellow;
                    }
                    fore = "purp";
                    back = "yell";
                    break;
                case "Confirmed":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Black;
                        cmbBookingStatus.BackColor = Color.Yellow;
                    }
                    fore = "blck";
                    back = "yell";
                    break;
                case "Details Sent":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Black;
                        cmbBookingStatus.BackColor = Color.LightGray;
                    }
                    fore = "blck";
                    back = "gray";
                    break;

                case "Cancelled":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Black;
                        cmbBookingStatus.BackColor = Color.LightGreen;
                    }
                    fore = "blck";
                    back = "lgre";
                    break;

                case "Cancelled - ttbt":
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = Color.Black;
                        cmbBookingStatus.BackColor = Color.LightGreen;
                    }
                    fore = "blck";
                    back = "lgre";
                    break;

                default:
                    if (cmbBookingStatus != null)
                    {
                        cmbBookingStatus.ForeColor = System.Drawing.SystemColors.WindowText;
                        cmbBookingStatus.BackColor = System.Drawing.SystemColors.Window;
                    }
                    break;

            }

            if (af) //asked for
            {
                if (status == "Details Sent") back = "dblu"; //darkblue;
                else back = "lblu";  //light blue
            }

            if (lt) //LongTerm / Regular Booking
            {
                back = "purp";
            }


            return fore + "/" + back;
        }
    }
}
