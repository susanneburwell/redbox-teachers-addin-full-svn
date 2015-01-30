using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using RedboxAddin.BL;
using RedboxAddin.Models;
using RedboxAddin.DL;
using System.Runtime.InteropServices;

namespace RedboxAddin.Presentation
{
    public partial class frmExtractData : Form
    {
        public frmExtractData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MAPIFolder oFolder = Globals.objNS.GetFolderFromID(txtFolderID.Text);
            Items oItems = oFolder.Items;
            Debug.DebugMessage(2, "Contact Count = " + oItems.Count.ToString());

            foreach (var item in oItems)
            {
                ContactItem mapiContactObj = item as ContactItem;
                if (mapiContactObj == null)
                {
                    //Debug.DebugMessage(3,""+ item.GetType().InvokeMember("Subject",System.Reflection.BindingFlags.));
                    Debug.DebugMessage(3, "Ignoring Item");
                    continue;

                }
                UserProperties oProps = mapiContactObj.UserProperties;
                RContact contactObj = new RContact();
                Debug.DebugMessage(3, "Adding " + mapiContactObj.FirstName + " " + mapiContactObj.LastName);
                contactObj.FirstName = mapiContactObj.FirstName;
                contactObj.LastName = mapiContactObj.LastName;
                contactObj.Title = mapiContactObj.Title;
                contactObj.MiddleName = mapiContactObj.MiddleName;
                contactObj.Suffix = mapiContactObj.Suffix;
                contactObj.Email1 = mapiContactObj.Email1Address;
                contactObj.Email2 = mapiContactObj.Email2Address;
                contactObj.Email3 = mapiContactObj.Email3Address;
                contactObj.AddressStreet = mapiContactObj.BusinessAddressStreet;
                contactObj.AddressCity = mapiContactObj.BusinessAddressCity;
                contactObj.AddressState = mapiContactObj.BusinessAddressState;
                contactObj.AddressPostcode = mapiContactObj.BusinessAddressPostalCode;
                contactObj.AddressCountry = mapiContactObj.BusinessAddressCountry;
                contactObj.PhoneHome = mapiContactObj.HomeTelephoneNumber;
                contactObj.PhoneMobile = mapiContactObj.MobileTelephoneNumber;
                contactObj.PhoneBusiness = mapiContactObj.BusinessTelephoneNumber;
                contactObj.PhoneFax = mapiContactObj.BusinessFaxNumber;
                contactObj.CategoryStr = mapiContactObj.Categories;
                contactObj._1stRefChecked = CheckBool(GetOProp("1st Ref Checked", ref oProps));
                contactObj._2ndRefChecked = CheckBool(GetOProp("2nd Ref Checked", ref oProps));
                contactObj._3rdRefChecked = CheckBool(GetOProp("3rd Ref Checked", ref oProps));
                contactObj.AccountName = GetOProp("Account Name", ref oProps);
                contactObj.Cautions_AdditionalInfo_OnDBS = CheckBool(GetOProp("Additional Info on CRB", ref oProps));
                contactObj.BankAccountNumber = GetOProp("Bank Account No.", ref oProps);
                contactObj.BankName = GetOProp("Bank Name", ref oProps);
                contactObj.BankSortCode = GetOProp("Bank Sort Code", ref oProps);
                contactObj.BankStatementLocation = GetOProp("BankStatementLocation", ref oProps);
                contactObj.BirthDate = FormatBirthDay(GetOProp("Birth date", ref oProps));
                contactObj.DBSandAddressProofMatch = CheckBool(GetOProp("CRB & Proof of Address match", ref oProps));
                contactObj.DBSDateSent = CheckDate(GetOProp("CRB Date Sent", ref oProps));
                contactObj.DBSExpiryDate = CheckDate(GetOProp("CRB Expiry Date", ref oProps));
                contactObj.DBSFormRef = GetOProp("CRB Form Ref", ref oProps);
                contactObj.DBSNumber = GetOProp("CRB Number", ref oProps);
                contactObj.DBSValidFrom = CheckDate(GetOProp("CRB Valid From", ref oProps));
                contactObj.Consultant = GetOProp("Consultant", ref oProps);
                contactObj.CurrentPayScale = GetOProp("Current Pay Scale", ref oProps);
                contactObj.CVReceived = CheckBool(GetOProp("CV Received", ref oProps));
                contactObj.DateOfSupply = CheckDate(GetOProp("Date of Supply", ref oProps));
                contactObj.FirstDayTeachingUK = CheckDate(GetOProp("First Day Teaching UK", ref oProps));
                contactObj.PhotoLocation = mapiContactObj.User1;
                contactObj.GTCCheckDate = CheckDate(GetOProp("GTC Check Date", ref oProps));
                contactObj.GTCNumber = GetOProp("GTC Number", ref oProps);
                contactObj.IDChecked = CheckBool(GetOProp("ID Checked", ref oProps));
                contactObj.Instructor = CheckBool(GetOProp("Instructor", ref oProps));
                contactObj.InterviewNotes = GetOProp("Interview Notes", ref oProps);
                contactObj.JobTitle = mapiContactObj.JobTitle;
                contactObj.List99 = CheckBool(GetOProp("List 99", ref oProps));
                contactObj.LTStartDate = CheckDate(GetOProp("LT Start Date", ref oProps));
                contactObj.MedicalChecklist = CheckBool(GetOProp("Medical Checklist", ref oProps));
                contactObj.NINumber = GetOProp("N.I. Number", ref oProps);
                contactObj.Notes = mapiContactObj.Body;
                contactObj.NQT = CheckBool(GetOProp("NQT", ref oProps));
                contactObj.OtherCRBNumber = CheckBool(GetOProp("Other CRB Number", ref oProps));
                contactObj.OTTEndDate = CheckDate(GetOProp("OTT End Date", ref oProps));
                contactObj.OverseasPoliceCheck = CheckBool(GetOProp("Overseas Police Check", ref oProps));
                contactObj.OverseasTrainedTeacher = CheckBool(GetOProp("OverseasTrainedTeacher", ref oProps));
                contactObj.PassportNo = GetOProp("Passport No.", ref oProps);
                contactObj.PassportLocation = GetOProp("PassportLocation", ref oProps);
                contactObj.PayDetails = GetOProp("Pay Details", ref oProps);
                contactObj.PAYETeacherContractSigned = CheckBool(GetOProp("PAYE Teacher Contract signed", ref oProps));
                contactObj.ProtabilityCheckSent = CheckDate(GetOProp("Portability Check Sent", ref oProps));
                contactObj.ProtabilityReceivedDate = CheckDate(GetOProp("Portability Received Date", ref oProps));
                contactObj.ProofOfAddress = CheckBool(GetOProp("Proof of Address", ref oProps));
                contactObj.ProofOfID = GetOProp("Proof of ID", ref oProps);
                contactObj.ProofOfID2 = GetOProp("Proof of ID2", ref oProps);
                contactObj.QTS = CheckBool(GetOProp("QTS", ref oProps));
                contactObj.Qualification = GetOProp("Qualification", ref oProps);
                contactObj.RedboxLeaveDate = CheckDate(GetOProp("RedBox Leave Date", ref oProps));
                contactObj.RedboxStartDate = CheckDate(GetOProp("RedBox Start Date", ref oProps));
                contactObj.RedboxDBS = CheckBool(GetOProp("RedBoxCRB", ref oProps));
                contactObj.Referee1Address = GetOProp("Referee1 Address", ref oProps);
                contactObj.Referee1Email = GetOProp("Referee1 Email", ref oProps);
                contactObj.Referee1Fax = GetOProp("Referee1 Fax", ref oProps);
                contactObj.Referee1Mobile = GetOProp("Referee1 Mobile", ref oProps);
                contactObj.Referee1Name = GetOProp("Referee1 Name", ref oProps);
                contactObj.Referee1Notes = GetOProp("Referee1 Notes", ref oProps);
                contactObj.Referee1Phone = GetOProp("Referee1 Phone", ref oProps);
                contactObj.Referee2Address = GetOProp("Referee2 Address", ref oProps);
                contactObj.Referee2Email = GetOProp("Referee2 Email", ref oProps);
                contactObj.Referee2Fax = GetOProp("Referee2 Fax", ref oProps);
                contactObj.Referee2Mobile = GetOProp("Referee2 Mobile", ref oProps);
                contactObj.Referee2Name = GetOProp("Referee2 Name", ref oProps);
                contactObj.Referee2Notes = GetOProp("Referee2 Notes", ref oProps);
                contactObj.Referee2Phone = GetOProp("Referee2 Phone", ref oProps);
                contactObj.Referee3Address = GetOProp("Referee3 Address", ref oProps);
                contactObj.Referee3Email = GetOProp("Referee3 Email", ref oProps);
                contactObj.Referee3Fax = GetOProp("Referee3 Fax", ref oProps);
                contactObj.Referee3Mobile = GetOProp("Referee3 Mobile", ref oProps);
                contactObj.Referee3Name = GetOProp("Referee3 Name", ref oProps);
                contactObj.Referee3Notes = GetOProp("Referee3 Notes", ref oProps);
                contactObj.Referee3Phone = GetOProp("Referee3 Phone", ref oProps);
                contactObj.ReferencesChecked = CheckBool(GetOProp("References Checked", ref oProps));
                contactObj.RegistrationComplete = CheckBool(GetOProp("Registration Complete", ref oProps));
                contactObj.RegistrationDate = CheckDate(GetOProp("Registration Date", ref oProps));
                contactObj.SendBankStatement = CheckBool(GetOProp("Send Bank Statement", ref oProps));
                contactObj.SendPassport = CheckBool(GetOProp("Send Passport", ref oProps));
                contactObj.SendVisa = CheckBool(GetOProp("Send Visa", ref oProps));
                contactObj.SicknessRecord = GetOProp("Sickness Record", ref oProps);
                contactObj.TeacherStatus = GetOProp("Teacher Status", ref oProps);
                contactObj.UKArrivalDate = CheckDate(GetOProp("UK Arrival Date", ref oProps));
                contactObj.VisaExpiryDate = CheckDate(GetOProp("Visa Expiry Date", ref oProps));
                contactObj.VisaType = GetOProp("Visa Type", ref oProps);
                contactObj.VisaLocation = GetOProp("VisaLocation", ref oProps);
                contactObj.YearGroup = GetOProp("Year Group", ref oProps);
                new DBManager().AddContact(contactObj);

                if (oProps != null) Marshal.ReleaseComObject(oProps);
                if (mapiContactObj != null) Marshal.ReleaseComObject(mapiContactObj);
                if (item != null) Marshal.ReleaseComObject(item);
                GC.Collect();
            }
            MessageBox.Show("All done :) ");
        }

        private bool CheckBool(string valToConvert)
        {
            try
            {
                return Convert.ToBoolean(valToConvert);
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        private DateTime CheckDate(string dtVal)
        {
            try
            {
                var dtValToMactch = DateTime.Parse("01/01/4501 00:00:00");
                var dtObj = Convert.ToDateTime(dtVal);
                if (dtObj == dtValToMactch) throw new System.Exception("");
                return dtObj;
            }
            catch (System.Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        private string FormatBirthDay(string dtVal)
        {
            return dtVal.Substring(0, 10);
        }

        public static String GetOProp(String propertyName, ref UserProperties oProps)
        {
            try
            {
                var x = oProps.Find(propertyName, true).Value.ToString();
                return x;
            }

            catch (System.Exception ex2)
            {
                Debug.DebugMessage(3, "Error getting the Value for userProperty : " + propertyName + ": - " + ex2.Message);
                return "";
            }
        }

        private void frmExtractData_Load(object sender, EventArgs e)
        {

        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            Redemption.RDOFolder rFolder = RedemptionCode.rSession.PickFolder();
            if (rFolder != null)
            {
                txtFolderID.Text = rFolder.EntryID;
            }
            if (rFolder != null) Marshal.ReleaseComObject(rFolder);
            GC.Collect();
        }

        private void btnUpdatePictures_Click(object sender, EventArgs e)
        {
            MAPIFolder oFolder = Globals.objNS.GetFolderFromID(txtFolderID.Text);
            Items oItems = oFolder.Items;
            Debug.DebugMessage(2, "Contact Count = " + oItems.Count.ToString());

            foreach (var item in oItems)
            {
                ContactItem mapiContactObj = item as ContactItem;
                if (mapiContactObj == null)
                {
                    //Debug.DebugMessage(3,""+ item.GetType().InvokeMember("Subject",System.Reflection.BindingFlags.));
                    Debug.DebugMessage(3, "Ignoring Item");
                    continue;

                }
                RContact contactObj = new RContact();
                Debug.DebugMessage(3, "Updating " + mapiContactObj.FirstName + " " + mapiContactObj.LastName);
                contactObj.Email1 = mapiContactObj.Email1Address;
                contactObj.PhotoLocation = mapiContactObj.User1;
                if (string.IsNullOrEmpty(contactObj.PhotoLocation)) continue;
                new DBManager().ExecuteQuery("UPDATE Contacts SET PhotoLocation = '" + contactObj.PhotoLocation + "' WHERE Email1 = '" + contactObj.Email1 + "'  ");

                if (mapiContactObj != null) Marshal.ReleaseComObject(mapiContactObj);
                if (item != null) Marshal.ReleaseComObject(item);
                GC.Collect();
            }
        }

        private void btnUpdateRefBy_Click(object sender, EventArgs e)
        {
            MAPIFolder oFolder = Globals.objNS.GetFolderFromID(txtFolderID.Text);
            Items oItems = oFolder.Items;
            Debug.DebugMessage(2, "Contact Count = " + oItems.Count.ToString());

            foreach (var item in oItems)
            {
                ContactItem mapiContactObj = item as ContactItem;
                if (mapiContactObj == null)
                {
                    //Debug.DebugMessage(3,""+ item.GetType().InvokeMember("Subject",System.Reflection.BindingFlags.));
                    Debug.DebugMessage(3, "Ignoring Item");
                    continue;

                }
                RContact contactObj = new RContact();
                Debug.DebugMessage(3, "Updating Ref By for " + mapiContactObj.FirstName + " " + mapiContactObj.LastName);
                contactObj.Email1 = mapiContactObj.Email1Address;
                contactObj.ReferredBy = mapiContactObj.ReferredBy;
                if (string.IsNullOrEmpty(contactObj.ReferredBy)) continue;
                new DBManager().ExecuteQuery("UPDATE Contacts SET ReferredBy = '" + contactObj.ReferredBy + "' WHERE Email1 = '" + contactObj.Email1 + "'  ");

                if (mapiContactObj != null) Marshal.ReleaseComObject(mapiContactObj);
                if (item != null) Marshal.ReleaseComObject(item);
                GC.Collect();
            }
        }
    }
}
