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
using Exception = System.Exception;
using Redemption;
using System.Runtime.InteropServices;

namespace RedboxAddin.Presentation
{
    public partial class frmViewContact : Form
    {
        RContact currentContact = null;
        long CurrentContactID = 0;
        string firstName = "";
        string lastName = "";
        string title = "";
        string middleName = "";
        string suffix = "";
        string addressStreet = "";
        string addressCity = "";
        string addressState = "";
        string addressPostcode = "";
        string addressCountry = "";
        string categoryStr = "";

        public frmViewContact(long contactID)
        {
            InitializeComponent();
            this.CurrentContactID = contactID;
        }

        public frmViewContact()
        {
            InitializeComponent();
        }

        private void CheckReminderButtonColors()
        {
            try
            {
                var ds = new DBManager().GetDataSet("SELECT ReminderID,Type FROM Reminders WHERE ContactRefID = " + CurrentContactID.ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string reminderType = dr["Type"].ToString();
                    if (reminderType == "12QP") btn12QPReminder.ForeColor = System.Drawing.Color.Green;
                    if (reminderType == "1Year") btn1YearReminder.ForeColor = System.Drawing.Color.Green;
                    if (reminderType == "CRB Expiry") btnCRBExpiryReminder.ForeColor = System.Drawing.Color.Green;
                    if (reminderType == "Visa Expiry") btnVisaExpiryReminder.ForeColor = System.Drawing.Color.Green;
                    if (reminderType == "Redbox Start") btnRedboxStartReminder.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckReminderButtonColors : -" + ex.Message);
            }
        }

        private void frmViewContact_Load(object sender, EventArgs e)
        {
            if (CurrentContactID == 0) return;
            RContact contactObj = new DBManager().GetContact(this.CurrentContactID);
            if (contactObj == null)
            {
                MessageBox.Show("Contact no longer exists", "Contact not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                lblID.Text = contactObj.contactID.ToString();
                lblFullName.Text = Utils.GetFullName(contactObj.Title, contactObj.FirstName, contactObj.MiddleName, contactObj.LastName, contactObj.Suffix);
                lblTeacherName.Text = lblFullName.Text;


                txtEmail.Text = contactObj.Email1;
                txtJobTitle.Text = contactObj.JobTitle;
                addressStreet = contactObj.AddressStreet;
                addressCity = contactObj.AddressCity;
                addressState = contactObj.AddressState;
                addressPostcode = contactObj.AddressPostcode;
                addressCountry = contactObj.AddressCountry;
                firstName = contactObj.FirstName;
                middleName = contactObj.MiddleName;
                lastName = contactObj.LastName;
                title = contactObj.Title;
                suffix = contactObj.Suffix;
                categoryStr = contactObj.CategoryStr;
                txtCategories.Text = categoryStr;
                lblAddress.Text = Utils.GetAddress(addressStreet, addressCity, addressState, addressPostcode, addressCountry);
                txtPhoneHome.Text = contactObj.PhoneHome;
                txtPhoneMobile.Text = contactObj.PhoneMobile;
                //txtPhoneBusiness.Text = contactObj.PhoneBusiness;
                //txtPhoneBusinessFax.Text = contactObj.PhoneFax;
                chkReferee1Checked.Checked = contactObj._1stRefChecked;
                chkReferee2Checked.Checked = contactObj._2ndRefChecked;
                chkReferee3Checked.Checked = contactObj._3rdRefChecked;
                //txtAccountName.Text = contactObj.AccountName;
                chkCautionsCRB.Checked = contactObj.Cautions_AdditionalInfo_OnDBS;
                //txtBankAccountNumber.Text = contactObj.BankAccountNumber;
                //txtBankName.Text = contactObj.BankName;
                //txtBankSortCode.Text = contactObj.BankSortCode;
                //txtBankStatementLocation.Text = contactObj.BankStatementLocation;
                txtBirthday.Text = contactObj.BirthDate;
                txtConsultant.Text = contactObj.Consultant;
                chkProofOfAddress.Checked = contactObj.DBSandAddressProofMatch;
                dtCRBDateSent.Value = contactObj.DBSDateSent;
                dtCRBExpiry.Value = contactObj.DBSExpiryDate;
                txtCRBFormRef.Text = contactObj.DBSFormRef;
                txtCRBNumber.Text = contactObj.DBSNumber;
                dtCRBValidFrom.Value = contactObj.DBSValidFrom;
                chkDBSDirectPayment.Checked = contactObj.DBSDirectPayment;
                dtDBSudChk.Value = contactObj.DBSUpdateServiceCheckedDate ;
                dtDBAChkd.Value = contactObj.DBAChkd ;
                chkDBAsigned.Checked = contactObj.DBASgnd;

                txtCurrentPayScale.Text = contactObj.CurrentPayScale;
                chkCVReceived.Checked = contactObj.CVReceived;
                dtDateOfSupply.Value = contactObj.DateOfSupply;
                dtFirstDayTeachingUK.Value = contactObj.FirstDayTeachingUK;
                dtGTCCheckDate.Value = contactObj.GTCCheckDate;
                chkIDChecked.Checked = contactObj.IDChecked;
                dtIDChkd.Value = contactObj.IDCheckedDate;
                chkInstructor.Checked = contactObj.Instructor;
                txtGTCNumber.Text = contactObj.GTCNumber;
                txtInterviewNotes.Text = contactObj.InterviewNotes;
                txtKeyRef.Text = contactObj.KeyRef;
                txtLateRecord.Text = contactObj.LateRecord;
                chkList99Undertaken.Checked = contactObj.List99;
                dtList99Chkd.Value = contactObj.List99CheckedDate;
                dtLongTermStart.Value = contactObj.LTStartDate;
                chkMedicalChecklist.Checked = contactObj.MedicalChecklist;
                dtMedCLChkd.Value = contactObj.MedicalChecklistCheckedDate ;

                txtNINumber.Text = contactObj.NINumber;
                txtNotes.Text = contactObj.Notes;
                chkNQT.Checked = contactObj.NQT;
                // false;  //*************************=            contactObj.OtherCRBNumber ;
                dtOTTEndDate.Value = contactObj.OTTEndDate;
                chkOverseasPoliceCheck.Checked = contactObj.OverseasPoliceCheck;
                dtOvPolChkd.Value = contactObj.OverseasPoliceCheckedDate ;
                chkOverseasTrainedTeacher.Checked = contactObj.OverseasTrainedTeacher;
                //txtPassportNumber.Text = contactObj.PassportNo;
                //txtPassportLocation.Text = contactObj.PassportLocation;
                cmbPayDetails.Text = contactObj.PayDetails;
                chkPAYETeacherContractSigned.Checked = contactObj.PAYETeacherContractSigned;
                picturebox1.ImageLocation = contactObj.PhotoLocation;
                pictureBox2.ImageLocation = contactObj.PhotoLocation;
                txtFilePath.Text = contactObj.PhotoLocation;
                dtGradDate.Value = contactObj.GraduationDate;
                chkPrFrmTch.Checked =contactObj.ProhibitionFromTeaching ;
                dtPrFrmTchchkd.Value = contactObj.ProhibitionFromTeachingCheckedDate;
                dtProtabilityCheckSent.Value = contactObj.ProtabilityCheckSent;
                dtProtabilityReceivedDate.Value = contactObj.ProtabilityReceivedDate;
                chkProofOfAddress.Checked = contactObj.ProofOfAddress;
                dtPOAChkd.Value = contactObj.ProofOfAddressCheckedDate;
                //cmbProofID.Text = contactObj.ProofOfID;
                //cmbProofID2.Text = contactObj.ProofOfID2;
                chkQTS.Checked = contactObj.QTS;
                txtQualification.Text = contactObj.Qualification;
                dtQualChecked.Value = contactObj.QualificationCheckedDate ;

                dtRedboxLeaveDate.Value = contactObj.RedboxLeaveDate;
                dtRedboxStart.Value = contactObj.RedboxStartDate;
                chkRedboxCRB.Checked = contactObj.RedboxDBS;
                //txtReferredBy.Text = contactObj.ReferredBy;
                txtReferee1Address.Text = contactObj.Referee1Address;
                txtReferee1Email.Text = contactObj.Referee1Email;
                txtReferee1Fax.Text = contactObj.Referee1Fax;
                txtReferee1Mobile.Text = contactObj.Referee1Mobile;
                txtReferee1Name.Text = contactObj.Referee1Name;
                txtReferee1Notes.Text = contactObj.Referee1Notes;
                txtReferee1Phone.Text = contactObj.Referee1Phone;
                txtReferee2Address.Text = contactObj.Referee2Address;
                txtReferee2Email.Text = contactObj.Referee2Email;
                txtReferee2Fax.Text = contactObj.Referee2Fax;
                txtReferee2Mobile.Text = contactObj.Referee2Mobile;
                txtReferee2Name.Text = contactObj.Referee2Name;
                txtReferee2Notes.Text = contactObj.Referee2Notes;
                txtReferee2Phone.Text = contactObj.Referee2Phone;
                txtReferee3Address.Text = contactObj.Referee3Address;
                txtReferee3Email.Text = contactObj.Referee3Email;
                txtReferee3Fax.Text = contactObj.Referee3Fax;
                txtReferee3Mobile.Text = contactObj.Referee3Mobile;
                txtReferee3Name.Text = contactObj.Referee3Name;
                txtReferee3Notes.Text = contactObj.Referee3Notes;
                txtReferee3Phone.Text = contactObj.Referee3Phone;
                chkReferencesChecked.Checked = contactObj.ReferencesChecked;
                dtRefChkd.Value = contactObj.ReferencesCheckedDate;
                //chkRegistrationComplete.Checked = contactObj.RegistrationComplete;
                dtRegistrationDate.Value = contactObj.RegistrationDate;
                //chkSendBankStatement.Checked = contactObj.SendBankStatement;
                //chkSendPassport.Checked = contactObj.SendPassport;
                //chkSendVisa.Checked = contactObj.SendVisa;
                txtSicknessRecord.Text = contactObj.SicknessRecord;
                cmbTeacherStatus.Text = contactObj.TeacherStatus;
                dtUKArrivalDate.Value = contactObj.UKArrivalDate;
                chkUpdateService.Checked = contactObj.UpdateService;
                dtUpdateServiceRegDate.Value = contactObj.UpdateServiceRegisteredDate;
                dtVisaExpiryDate.Value = contactObj.VisaExpiryDate;
                txtVisaType.Text = contactObj.VisaType;
                dtVisaChkd.Value =contactObj.VisaCheckedDate ;
                //txtVisaLocation.Text = contactObj.VisaLocation;
                txtYearGroup.Text = contactObj.YearGroup;
                //chkMMRV.Checked = contactObj.AttendMMRV;
                CheckReminderButtonColors();

                LoadSummaryInfo();
                PopulatePaymentTypes();

            }
        }

        private bool SaveContact()
        {
            try
            {
                RContact contactObj = new RContact();
                contactObj.FirstName = firstName;
                contactObj.LastName = lastName;
                contactObj.Title = title;
                contactObj.MiddleName = middleName;
                contactObj.Suffix = suffix;
                contactObj.Email1 = txtEmail.Text;
                contactObj.Email2 = txtEmail.Text;
                contactObj.Email3 = txtEmail.Text;
                contactObj.JobTitle = txtJobTitle.Text;
                contactObj.AddressStreet = addressStreet;
                contactObj.AddressCity = addressCity;
                contactObj.AddressState = addressState;
                contactObj.AddressPostcode = addressPostcode;
                contactObj.AddressCountry = addressCountry;
                contactObj.PhoneHome = txtPhoneHome.Text;
                contactObj.PhoneMobile = txtPhoneMobile.Text;
                //contactObj.PhoneBusiness = txtPhoneBusiness.Text;
                //contactObj.PhoneFax = txtPhoneBusinessFax.Text;
                contactObj.CategoryStr = categoryStr;
                contactObj._1stRefChecked = chkReferee1Checked.Checked;
                contactObj._2ndRefChecked = chkReferee2Checked.Checked;
                contactObj._3rdRefChecked = chkReferee3Checked.Checked;
                //contactObj.AccountName = txtAccountName.Text;
                contactObj.Cautions_AdditionalInfo_OnDBS = chkCautionsCRB.Checked;
                //contactObj.BankAccountNumber = txtBankAccountNumber.Text;
                //contactObj.BankName = txtBankName.Text;
                //contactObj.BankSortCode = txtBankSortCode.Text;
                //contactObj.BankStatementLocation = txtBankStatementLocation.Text;
                contactObj.BirthDate = txtBirthday.Text;
                contactObj.Consultant = txtConsultant.Text;
                contactObj.DBAChkd = dtDBAChkd.Value;
                contactObj.DBASgnd = chkDBAsigned.Checked;
                contactObj.DBSandAddressProofMatch = chkProofOfAddress.Checked;
                contactObj.DBSDateSent = dtCRBDateSent.Value;
                contactObj.DBSExpiryDate = dtCRBExpiry.Value;
                contactObj.DBSFormRef = txtCRBFormRef.Text;
                contactObj.DBSNumber = txtCRBNumber.Text;
                contactObj.DBSValidFrom = dtCRBValidFrom.Value;
                contactObj.DBSDirectPayment = chkDBSDirectPayment.Checked;
                contactObj.DBSUpdateServiceCheckedDate = dtDBSudChk.Value;
                contactObj.CurrentPayScale = txtCurrentPayScale.Text;
                contactObj.CVReceived = chkCVReceived.Checked;
                contactObj.DateOfSupply = dtDateOfSupply.Value;
                contactObj.FirstDayTeachingUK = dtFirstDayTeachingUK.Value;
                contactObj.GTCCheckDate = dtGTCCheckDate.Value;
                contactObj.IDChecked = chkIDChecked.Checked;
                contactObj.IDCheckedDate = dtIDChkd.Value;
                contactObj.Instructor = chkInstructor.Checked;
                contactObj.InterviewNotes = txtInterviewNotes.Text;
                contactObj.LateRecord = txtLateRecord.Text;
                contactObj.GTCNumber = txtGTCNumber.Text;
                contactObj.KeyRef = txtKeyRef.Text;
                contactObj.List99 = chkList99Undertaken.Checked;
                contactObj.List99CheckedDate = dtList99Chkd.Value;
                contactObj.LTStartDate = dtLongTermStart.Value;
                contactObj.MedicalChecklist = chkMedicalChecklist.Checked;
                contactObj.MedicalChecklistCheckedDate = dtMedCLChkd.Value;
                contactObj.NINumber = txtNINumber.Text;
                contactObj.Notes = txtNotes.Text;
                contactObj.NQT = chkNQT.Checked;
                contactObj.OtherCRBNumber = false;  //**************************
                contactObj.OTTEndDate = dtOTTEndDate.Value;
                contactObj.OverseasPoliceCheck = chkOverseasPoliceCheck.Checked;
                contactObj.OverseasPoliceCheckedDate = dtOvPolChkd.Value;
                contactObj.OverseasTrainedTeacher = chkOverseasTrainedTeacher.Checked;
                //contactObj.PassportNo = txtPassportNumber.Text;
                //contactObj.PassportLocation = txtPassportLocation.Text;
                contactObj.PayDetails = cmbPayDetails.Text;
                contactObj.PAYETeacherContractSigned = chkPAYETeacherContractSigned.Checked;
                contactObj.PhotoLocation = txtFilePath.Text;
                contactObj.GraduationDate = dtGradDate.Value;
                contactObj.ProhibitionFromTeaching = chkPrFrmTch.Checked;
                contactObj.ProhibitionFromTeachingCheckedDate = dtPrFrmTchchkd.Value;
                contactObj.ProtabilityCheckSent = dtProtabilityCheckSent.Value;
                contactObj.ProtabilityReceivedDate = dtProtabilityReceivedDate.Value;
                contactObj.ProofOfAddress = chkProofOfAddress.Checked;
                contactObj.ProofOfAddressCheckedDate = dtPOAChkd.Value;
                //contactObj.ProofOfID = cmbProofID.Text;
                //contactObj.ProofOfID2 = cmbProofID2.Text;
                contactObj.QTS = chkQTS.Checked;
                contactObj.Qualification = txtQualification.Text;
                contactObj.QualificationCheckedDate = dtQualChecked.Value;
                contactObj.RedboxLeaveDate = dtRedboxLeaveDate.Value;
                contactObj.RedboxStartDate = dtRedboxStart.Value;
                contactObj.RedboxDBS = chkRedboxCRB.Checked;
                //contactObj.ReferredBy = txtReferredBy.Text;
                contactObj.Referee1Address = txtReferee1Address.Text;
                contactObj.Referee1Email = txtReferee1Email.Text;
                contactObj.Referee1Fax = txtReferee1Fax.Text;
                contactObj.Referee1Mobile = txtReferee1Mobile.Text;
                contactObj.Referee1Name = txtReferee1Name.Text;
                contactObj.Referee1Notes = txtReferee1Notes.Text;
                contactObj.Referee1Phone = txtReferee1Phone.Text;
                contactObj.Referee2Address = txtReferee2Address.Text;
                contactObj.Referee2Email = txtReferee2Email.Text;
                contactObj.Referee2Fax = txtReferee2Fax.Text;
                contactObj.Referee2Mobile = txtReferee2Mobile.Text;
                contactObj.Referee2Name = txtReferee2Name.Text;
                contactObj.Referee2Notes = txtReferee2Notes.Text;
                contactObj.Referee2Phone = txtReferee2Phone.Text;
                contactObj.Referee3Address = txtReferee3Address.Text;
                contactObj.Referee3Email = txtReferee3Email.Text;
                contactObj.Referee3Fax = txtReferee3Fax.Text;
                contactObj.Referee3Mobile = txtReferee3Mobile.Text;
                contactObj.Referee3Name = txtReferee3Name.Text;
                contactObj.Referee3Notes = txtReferee3Notes.Text;
                contactObj.Referee3Phone = txtReferee3Phone.Text;
                contactObj.ReferencesChecked = chkReferencesChecked.Checked;
                contactObj.ReferencesCheckedDate = dtRefChkd.Value;
                //contactObj.RegistrationComplete = chkRegistrationComplete.Checked;
                contactObj.RegistrationDate = dtRegistrationDate.Value;
                //contactObj.SendBankStatement = chkSendBankStatement.Checked;
                //contactObj.SendPassport = chkSendPassport.Checked;
                //contactObj.SendVisa = chkSendVisa.Checked;
                contactObj.SicknessRecord = txtSicknessRecord.Text;
                contactObj.TeacherStatus = cmbTeacherStatus.Text;
                contactObj.UKArrivalDate = dtUKArrivalDate.Value;
                contactObj.UpdateService = chkUpdateService.Checked;
                contactObj.UpdateServiceRegisteredDate = dtUpdateServiceRegDate.Value;
                contactObj.VisaExpiryDate = dtVisaExpiryDate.Value;
                contactObj.VisaCheckedDate = dtVisaChkd.Value;
                contactObj.VisaType = txtVisaType.Text;
                //contactObj.VisaLocation = txtVisaLocation.Text;
                contactObj.YearGroup = txtYearGroup.Text;
                //contactObj.AttendMMRV = chkMMRV.Checked;

                bool result = false;
                if (CurrentContactID != 0)
                {
                    result = new DBManager().UpdateContact(contactObj, CurrentContactID);
                    SaveSummaryInfo();
                    if (result)
                    {
                        MessageBox.Show("Contact saved successfully", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error saving the contact", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    //check for duplicates
                    List<long> dupesFound = new DBManager().CheckDupes(firstName, lastName);
                    if (dupesFound != null)
                    {
                        DialogResult dr = MessageBox.Show("There is already a contact with name \"" + firstName + " " + lastName + "\""
                            + Environment.NewLine + "Do you want to open the duplicates ?"
                            + Environment.NewLine + "Yes - Open duplicates , No - Save anyway , Cancel - Do nothing",
                            "Duplicates found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Open the contacts
                            int count = 0;
                            foreach (var contactID in dupesFound)
                            {
                                if (count >= 2) return false;
                                new frmViewContact(contactID).Show();
                                count++;

                            }
                            return false;
                        }
                        else if (dr == System.Windows.Forms.DialogResult.No) { /* Let the function flow**/ }
                        else
                        {
                            return false;
                        }
                    }

                    //create contact
                    CurrentContactID = new DBManager().AddContact(contactObj);
                    
                    //create contactdata
                    string CONNSTR = DavSettings.getDavValue("CONNSTR");
                    using (RedBoxDB db = new RedBoxDB(CONNSTR))
                    {
                        ContactData cd = new ContactData();
                        cd.ContactID = CurrentContactID;
                        db.ContactDatas.InsertOnSubmit(cd);
                        db.SubmitChanges();
                    }

                    

                    if (CurrentContactID != 0)
                    {
                        SaveSummaryInfo();
                        MessageBox.Show("Contact saved successfully", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error saving the contact", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SaveContact :- " + ex.Message);
                return false;
            }
        }

        private string GetLocation()
        {
            string location = "";
            if (chkNorth.Checked) location += ", North";
            if (chkSouth.Checked) location += ", South";
            if (chkEast.Checked) location += ", East";
            if (chkWest.Checked) location += ", West";
            if (location == "") return "";
            else return location.Substring(2);
        }

        private void SetLocation(string location)
        {
            if (location == null) return;

            if (location.IndexOf("North") > -1) chkNorth.Checked = true;
            else chkNorth.Checked = false;
            if (location.IndexOf("South") > -1) chkSouth.Checked = true;
            else chkSouth.Checked = false;
            if (location.IndexOf("East") > -1) chkEast.Checked = true;
            else chkEast.Checked = false;
            if (location.IndexOf("West") > -1) chkWest.Checked = true;
            else chkWest.Checked = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveContact()) this.Close();
        }
        
        private void btnPickAddress_Click(object sender, EventArgs e)
        {
            frmAddress frmObj = new frmAddress();
            RAddress addressObj = frmObj.ShowDialogExt(new RAddress() { City = addressCity, Street = addressStreet, Country = addressCountry, State = addressState, ZIP = addressPostcode });
            addressStreet = addressObj.Street;
            addressCity = addressObj.City;
            addressState = addressObj.State;
            addressPostcode = addressObj.ZIP;
            addressCountry = addressObj.Country;
            lblAddress.Text = Utils.GetAddress(addressStreet, addressCity, addressState, addressPostcode, addressCountry);
        }

        private void PopulatePaymentTypes()
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    var q = from s in db.PaymentTypes
                            orderby s.Name
                            select s;
                    var paymentTypes = q.ToList();
                    cmbPayDetails.Items.Clear();
                    foreach (var pt in paymentTypes)
                    {
                        cmbPayDetails.Items.Add(pt.Name.Trim());
                    }
                    if (cmbPayDetails.Text.Substring(0, 3).ToLower() == "key")
                    {
                        cmbPayDetails.Items.Add(cmbPayDetails.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulatePaymentTypes: " + ex.Message);
            }
        }


        #region Reminders

        private void btn12QPReminder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtLongTermStart.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please Specify Long Terms Start Date before adding a 12QP Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (new DBManager().ReminderExist(CurrentContactID, "12QP"))
                {
                    //MessageBox.Show("You have already set a 12QP Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "12QP");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    return;
                };
                RReminder reminderObj = new RReminder();
                reminderObj.contactID = CurrentContactID;
                reminderObj.Subject = "12QP Reminder " + lblFullName.Text;
                reminderObj.Status = "Due";
                reminderObj.Type = "12QP";
                reminderObj.DueDate = dtLongTermStart.Value.AddDays(70);
                if (new DBManager().AddReminder(reminderObj))
                {
                    //MessageBox.Show("12QP Reminder Added", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "12QP");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    CheckReminderButtonColors();
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding 12QP Reminder :- " + ex.Message);
            }
        }

        private void btn1YearReminder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtLongTermStart.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please Specify Long Terms Start Date before adding a 1 Year Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (new DBManager().ReminderExist(CurrentContactID, "1Year"))
                {
                    //MessageBox.Show("You have already set a 1 Year Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "1Year");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    return;
                };
                RReminder reminderObj = new RReminder();
                reminderObj.contactID = CurrentContactID;
                reminderObj.Subject = "1 Year Reminder " + lblFullName.Text;
                reminderObj.Status = "Due";
                reminderObj.Type = "1Year";
                reminderObj.DueDate = dtLongTermStart.Value.AddYears(1);
                if (new DBManager().AddReminder(reminderObj))
                {
                    // MessageBox.Show("1 Year Reminder Added", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "1Year");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    CheckReminderButtonColors();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding 12QP Reminder :- " + ex.Message);
            }
        }

        private void btnCRBExpiryReminder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtCRBExpiry.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please Specify CRB Expiry Date before adding a CRB Expiry Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (new DBManager().ReminderExist(CurrentContactID, "CRB Expiry"))
                {
                    // MessageBox.Show("You have already set a CRB Expiry Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "CRB Expiry");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    return;
                };
                RReminder reminderObj = new RReminder();
                reminderObj.contactID = CurrentContactID;
                reminderObj.Subject = "CRB Expiry Reminder " + dtCRBExpiry.Value.ToLongDateString() + " " + lblFullName.Text;
                reminderObj.Status = "Due";
                reminderObj.Type = "CRB Expiry";
                reminderObj.DueDate = dtCRBExpiry.Value.AddDays(-90);
                if (new DBManager().AddReminder(reminderObj))
                {
                    // MessageBox.Show("CRB Expiry Reminder Added", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "CRB Expiry");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    CheckReminderButtonColors();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding CRB Expiry Reminder :- " + ex.Message);
            }
        }

        private void btnRedboxStartReminder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtRedboxStart.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please Specify Redbox Start Date before adding a Redbox Start Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (new DBManager().ReminderExist(CurrentContactID, "Redbox Start"))
                {
                    //MessageBox.Show("You have already set a Redbox Start Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "Redbox Start");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    return;
                };
                RReminder reminderObj = new RReminder();
                reminderObj.contactID = CurrentContactID;
                reminderObj.Subject = "Redbox Start Reminder " + dtRedboxStart.Value.ToLongDateString() + " " + lblFullName.Text;
                reminderObj.Status = "Due";
                reminderObj.Type = "Redbox Start";
                reminderObj.DueDate = dtRedboxStart.Value;
                if (new DBManager().AddReminder(reminderObj))
                {
                    //MessageBox.Show("Redbox Start Reminder Added", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "Redbox Start");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    CheckReminderButtonColors();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding Redbox Start Reminder :- " + ex.Message);
            }
        }

        private void btnVisaExpiryReminder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtVisaExpiryDate.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please Specify Visa Expiry Date before adding a Visa Expiry Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (new DBManager().ReminderExist(CurrentContactID, "Visa Expiry"))
                {
                    // MessageBox.Show("You have already set a Visa Expiry Reminder", "Reminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "Visa Expiry");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    return;
                };
                RReminder reminderObj = new RReminder();
                reminderObj.contactID = CurrentContactID;
                reminderObj.Subject = "" + lblFullName.Text;
                reminderObj.Status = "Due";
                reminderObj.Type = "Visa Expiry";
                reminderObj.DueDate = dtVisaExpiryDate.Value.AddMonths(-3);
                if (new DBManager().AddReminder(reminderObj))
                {
                    //MessageBox.Show("Visa Expiry Reminder Added", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reminderID = new DBManager().GetReminderID(CurrentContactID, "Visa Expiry");
                    frmViewReminder frmObj = new frmViewReminder(reminderID);
                    frmObj.ShowDialog();
                    CheckReminderButtonColors();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding Visa Expiry Reminder :- " + ex.Message);
            }
        }

        #endregion


        #region LoadPhoto/Attachements

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogObj = new OpenFileDialog();
            openFileDialogObj.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            openFileDialogObj.Title = "Pick Image";
            var dResult = openFileDialogObj.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFileDialogObj.FileName;
                txtFilePath.Text = filePath;
                picturebox1.ImageLocation = filePath;
            }
        }

        //private void btnLoadPassport_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialogObj = new OpenFileDialog();
        //    openFileDialogObj.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
        //    openFileDialogObj.Title = "Pick Image";
        //    var dResult = openFileDialogObj.ShowDialog();
        //    if (dResult == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string filePath = openFileDialogObj.FileName;
        //        txtPassportLocation.Text = filePath;
        //    }
        //}

        //private void btnLoadBankStatement_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialogObj = new OpenFileDialog();
        //    openFileDialogObj.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
        //    openFileDialogObj.Title = "Pick Image";
        //    var dResult = openFileDialogObj.ShowDialog();
        //    if (dResult == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string filePath = openFileDialogObj.FileName;
        //        txtBankStatementLocation.Text = filePath;
        //    }
        //}

        //private void btnLoadVisa_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialogObj = new OpenFileDialog();
        //    openFileDialogObj.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
        //    openFileDialogObj.Title = "Pick Image";
        //    var dResult = openFileDialogObj.ShowDialog();
        //    if (dResult == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string filePath = openFileDialogObj.FileName;
        //        txtVisaLocation.Text = filePath;
        //    }
        //}

        #endregion

        //private bool AddAttachments(ref RDOAttachments attachmentCol)
        //{
        //    try
        //    {
        //        if (chkSendBankStatement.Checked)
        //        {
        //            if (!string.IsNullOrWhiteSpace(txtBankStatementLocation.Text))
        //            {
        //                RDOAttachment rAttachment = attachmentCol.Add(txtBankStatementLocation.Text);
        //                if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
        //            }
        //        }
        //        if (chkSendPassport.Checked)
        //        {
        //            if (!string.IsNullOrWhiteSpace(txtPassportLocation.Text))
        //            {
        //                RDOAttachment rAttachment = attachmentCol.Add(txtPassportLocation.Text);
        //                if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
        //            }
        //        }
        //        if (chkSendVisa.Checked)
        //        {
        //            if (!string.IsNullOrWhiteSpace(txtVisaLocation.Text))
        //            {
        //                RDOAttachment rAttachment = attachmentCol.Add(txtVisaLocation.Text);
        //                if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in AddAttachments :- " + ex.Message);
        //        return false;
        //    }
        //}

        private void btnSendDetails_Click(object sender, EventArgs e)
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
                string yearGroup = "";

                string contentID = "myident";
                string TableTop = "<table border=" + (char)(34) + "1" + (char)(34) + "width=" + (char)(34) + "100%" +
                                  "id=" + (char)(34) + "table1" + (char)(34) + "height=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine +
                                  "<tr>" + Environment.NewLine + "<td width=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine;
                rFolderDrafts = RedemptionCode.rSession.GetDefaultFolder(rdoDefaultFolders.olFolderDrafts);
                rItems = rFolderDrafts.Items;
                rMail = (RDOMail)rItems.Add("IPM.Note");

                //attachments removed
                //colAttach = rMail.Attachments;
                //AddAttachments(ref colAttach);

                rMail.Body = " ";
                try
                {
                    myAttach = colAttach.Add(txtFilePath.Text, OlAttachmentType.olByValue, rMail.Body.Length, Type.Missing);
                    myAttach.Hidden = true;
                    myAttach.set_Fields(0x370E001E, "image/jpeg");
                    myAttach.set_Fields(0x3712001E, "myident");

                    myAttach.ContentID = contentID;
                }
                catch (Exception ex) { Debug.DebugMessage(2, "Error attaching pictures in the " + ex.Message); }

                rMail.Save();
                myEntryID = rMail.EntryID;

                oMail = (MailItem)Globals.objNS.GetItemFromID(myEntryID);

                yearGroup = (false) ? yearGroup += "Float, " : yearGroup; //ToDo
                yearGroup = (chkNur.Checked) ? yearGroup += "Nur, " : yearGroup;
                yearGroup = (chkRec.Checked) ? yearGroup += "Rec, " : yearGroup;
                yearGroup = (chkYr1.Checked) ? yearGroup += "Yr1, " : yearGroup;
                yearGroup = (chkYr2.Checked) ? yearGroup += "Yr2, " : yearGroup;
                yearGroup = (chkYr3.Checked) ? yearGroup += "Yr3, " : yearGroup;
                yearGroup = (chkYr4.Checked) ? yearGroup += "Yr4, " : yearGroup;
                yearGroup = (chkYr5.Checked) ? yearGroup += "Yr5, " : yearGroup;
                yearGroup = (chkYr6.Checked) ? yearGroup += "Yr6, " : yearGroup;
                yearGroup = (chkTA.Checked) ? yearGroup += "TA, " : yearGroup;
                if (yearGroup.Length > 0)
                    yearGroup = yearGroup.Remove(yearGroup.Length - 2, 1);

                myPic = "<DIV>" + Environment.NewLine + "<IMG style=" + " border=0 hspace=0 alt=myPic align=baseline src=cid:myident width=200 height=200>" + Environment.NewLine + "</DIV>" + Environment.NewLine;
                TableMiddle = "</td>" + Environment.NewLine + "<td><FONT SIZE=2 FACE=" + (char)34 + "Arial" + (char)34 + ">";
                txtBody = txtBody + "Date of Supply: " + dtDateOfSupply.Value.ToShortDateString() + Environment.NewLine;
                txtBody = txtBody + Environment.NewLine + "Supply Requirement: Basic Cover" + Environment.NewLine + Environment.NewLine;
                txtBody = txtBody + "Teacher Name: " + lblFullName.Text + Environment.NewLine + Environment.NewLine;
                txtBody = txtBody + "Year Group: " + txtYearGroup.Text + " " + yearGroup + Environment.NewLine;
                txtBody = txtBody + Environment.NewLine + "Qualification: " + txtQualification.Text;
                if (chkQTS.Checked)
                {
                    txtBody = txtBody + Environment.NewLine + "QTS? Yes";
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "QTS? No";
                }

                if (chkNQT.Checked)
                {
                    txtBody = txtBody + Environment.NewLine + "NQT? Yes";
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "NQT? No";
                }

                if (chkInstructor.Checked) { txtBody = txtBody + Environment.NewLine + "Instructor? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Instructor? No"; }

                if (chkOverseasTrainedTeacher.Checked) { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? No"; }

                if (chkCVReceived.Checked) { txtBody = txtBody + Environment.NewLine + "CV Received? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "CV Received? No"; }

                if (chkRedboxCRB.Checked) { txtBody = txtBody + Environment.NewLine + "Red Box CRB? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Red Box CRB? No"; }

                txtBody = txtBody + Environment.NewLine + "Red Box CRB Form Ref: " + txtCRBFormRef.Text;
                txtBody = txtBody + Environment.NewLine + "CRB Number: " + txtCRBNumber.Text;

                if (dtCRBValidFrom.Value != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "CRB Valid from: " + dtCRBValidFrom.Value.ToShortDateString();
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "CRB Valid from: None";
                }

                if (chkCautionsCRB.Checked) { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? No"; }

                if (chkUpdateService.Checked) { txtBody = txtBody + Environment.NewLine + "DBS Update Service? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "DBS Update Service? No"; }

                if (dtVisaExpiryDate.Value != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: " + dtVisaExpiryDate.Value.ToShortDateString();
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: None";
                }

                if (!string.IsNullOrEmpty(txtVisaType.Text))
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Type: " + txtVisaType.Text;
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Type: None";
                }

                if (chkIDChecked.Checked) { txtBody = txtBody + Environment.NewLine + "ID checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "ID checked? No"; }

                if (chkOverseasPoliceCheck.Checked) { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? No"; }

                if (chkReferencesChecked.Checked) { txtBody = txtBody + Environment.NewLine + "All References checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "All References checked? No"; }

                if (chkList99Undertaken.Checked) { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? No"; }

                if (chkMedicalChecklist.Checked) { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? No"; }

                if (chkProofOfAddress.Checked) { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? No"; }

                if (dtRegistrationDate.Value != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "Date of Registration: " + dtRegistrationDate.Value.ToShortDateString();
                }
                else { txtBody = txtBody + Environment.NewLine + "Date of Registration: None"; }

                txtBody = txtBody + Environment.NewLine + "GTC Number: " + txtGTCNumber.Text;

                if (dtGTCCheckDate.Value != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "GTC Check Date: " + dtGTCCheckDate.Value.ToShortDateString();
                }
                else { txtBody = txtBody + Environment.NewLine + "GTC Check Date: None"; }

                if (!string.IsNullOrWhiteSpace(txtBirthday.Text))
                {
                    txtBody = txtBody + Environment.NewLine + "Date of Birth: " + txtBirthday.Text;
                }
                else { txtBody = txtBody + Environment.NewLine + "Date of Birth: None"; }

                //if (dtUKArrivalDate.Value != DateTime.MinValue)
                //{
                //    txtBody = txtBody + Environment.NewLine + "UK Arrival Date: " + dtUKArrivalDate.Value.ToShortDateString();
                //}
                //else { txtBody = txtBody + Environment.NewLine + "UK Arrival Date: None"; }

                //if (dtFirstDayTeachingUK.Value != DateTime.MinValue)
                //{
                //    txtBody = txtBody + Environment.NewLine + "First Day Teaching UK: " + dtFirstDayTeachingUK.Value.ToShortDateString();
                //}
                //else { txtBody = txtBody + Environment.NewLine + "First Day Teaching UK: None"; }

                //txtBody = txtBody + Environment.NewLine + "Charge Rate: ";
                txtBody = txtBody + Environment.NewLine;
                TableBottom = "</td>" + Environment.NewLine + "</tr>" + Environment.NewLine + "</table>";
                Replacement1 = "<BODY>" + Environment.NewLine + TableTop + myPic + TableMiddle;
                Replacement2 = TableBottom + "</BODY>";

                oMail.Subject = lblFullName.Text;
                oMail.Body = txtBody;

                //send attachments

                string myText = oMail.HTMLBody;
                myText = myText.Replace("<BODY>", Replacement1);
                myText = myText.Replace("</BODY>", Replacement2);
                oMail.HTMLBody = myText;

                oMail.Display();
                oMail.Save();

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Send Details : " + ex.Message);
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

        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            try
            {
                txtNotes.Text = DateTime.Now.ToString() + "  " + RedemptionCode.OutlookUserName + Environment.NewLine + "*********************************************************" + Environment.NewLine + txtNotes.Text;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error adding notes " + ex.Message);
            }
        }

        private void btnPickFullName_Click(object sender, EventArgs e)
        {
            frmNames frmObj = new frmNames();
            RNames namesObj = frmObj.ShowDialogExt(new RNames() { Title = title, FirstName = firstName, MiddleName = middleName, LastName = lastName, Suffix = suffix });
            title = namesObj.Title;
            firstName = namesObj.FirstName;
            middleName = namesObj.MiddleName;
            lastName = namesObj.LastName;
            suffix = namesObj.Suffix;
            lblFullName.Text = Utils.GetFullName(title, firstName, middleName, lastName, suffix);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var arr = categoryStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            List<string> lst = arr.OfType<string>().ToList();
            frmAttributePicker frmObj = new frmAttributePicker(lst);
            var listReturnred = frmObj.ShowDialog();
            if (listReturnred == null) return;
            categoryStr = "";
            foreach (var item in listReturnred)
            {
                categoryStr = categoryStr + item + ",";
            }
            txtCategories.Text = categoryStr;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete the contact ?", "Redbox Addin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (CurrentContactID != 0)
                {
                    var deleteResult = new DBManager().ExecuteQuery("DELETE FROM Contacts WHERE contactID = " + CurrentContactID.ToString());
                    if (deleteResult)
                    {
                        MessageBox.Show("Contact deleted successfully", "Redbox Addin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting the contact", "Redbox Addin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void chkCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrent.Checked)
            {
                string payDetails = cmbPayDetails.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(payDetails))
                {
                    showPayCodeError();
                    return;
                }
                if (payDetails == "key")
                {
                    showPayCodeError();
                    return;
                }
            }

        }

        private void showPayCodeError()
        {
            MessageBox.Show("This contact does not have a valid paycode. Please update the PayCode as soon as possible.");
        }

        #region NewCode

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (chkNur.Checked)
            {
                chkNur.Checked = false;
                chkRec.Checked = false;
                chkYr1.Checked = false;
                chkYr2.Checked = false;
                chkYr3.Checked = false;
                chkYr4.Checked = false;
                chkYr5.Checked = false;
                chkYr6.Checked = false;
            }
            else
            {
                chkNur.Checked = true;
                chkRec.Checked = true;
                chkYr1.Checked = true;
                chkYr2.Checked = true;
                chkYr3.Checked = true;
                chkYr4.Checked = true;
                chkYr5.Checked = true;
                chkYr6.Checked = true;
            }
        }

        private void btnEY_Click(object sender, EventArgs e)
        {
            if (chkNur.Checked)
            {
                chkNur.Checked = false;
                chkRec.Checked = false;
            }
            else
            {
                chkNur.Checked = true;
                chkRec.Checked = true;
            }
        }

        private void btnKS1_Click(object sender, EventArgs e)
        {
            if (chkYr1.Checked)
            {
                chkYr1.Checked = false;
                chkYr2.Checked = false;
            }
            else
            {
                chkYr1.Checked = true;
                chkYr2.Checked = true;
            }
        }

        private void btnKS2_Click(object sender, EventArgs e)
        {
            if (chkYr4.Checked)
            {
                chkYr3.Checked = false;
                chkYr4.Checked = false;
                chkYr5.Checked = false;
                chkYr6.Checked = false;
            }
            else
            {
                chkYr3.Checked = true;
                chkYr4.Checked = true;
                chkYr5.Checked = true;
                chkYr6.Checked = true;
            }
        }

        private void chkPPA_Click(object sender, EventArgs e)
        {
            if (chkPPA.Checked)
            {
                chkNur.Checked = true;
                chkRec.Checked = true;
                chkYr1.Checked = true;
                chkYr2.Checked = true;
                chkYr3.Checked = true;
                chkYr4.Checked = true;
                chkYr5.Checked = true;
                chkYr6.Checked = true;
            }
            UpdateWants();
        }

        private void chkLT_Click(object sender, EventArgs e)
        {
            UpdateWants();
        }

        private void chkD2D_Click(object sender, EventArgs e)
        {
            UpdateWants();
        }

        private void chkRGD_Click(object sender, EventArgs e)
        {
            UpdateWants();
        }

        private void SaveSummaryInfo()
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.ContactDatas.FirstOrDefault(s => s.ContactID == CurrentContactID);

                    cd.Live = txtLives.Text;
                    cd.NoGo = txtNoGo.Text;
                    cd.Wants = txtWants.Text;
                    cd.CRBStatus = txtCRBstatus.Text;
                    cd.TeacherStatus = txtTeacherStatus.Text;
                    cd.Teacher = chkTeacher.Checked;
                    cd.NN = chkNN.Checked;
                    cd.QNN = chkQNN.Checked;
                    cd.SEN = chkSEN.Checked;
                    cd.Nur = chkNur.Checked;
                    cd.Rec = chkRec.Checked;
                    cd.Yr1 = chkYr1.Checked;
                    cd.Yr2 = chkYr2.Checked;
                    cd.Yr3 = chkYr3.Checked;
                    cd.Yr4 = chkYr4.Checked;
                    cd.Yr5 = chkYr5.Checked;
                    cd.Yr6 = chkYr6.Checked;
                    cd.DayRate = Utils.CheckDecimal(txtDayRate.Text);
                    cd.HalfDayRate = Utils.CheckDecimal(txtHfDayRate.Text);
                    cd.DayRateLT = Utils.CheckDecimal(txtLTDay.Text);
                    cd.HalfDayRateLT = Utils.CheckDecimal(txtLTHfDay.Text);

                    cd.DayRateTA = Utils.CheckDecimal(txtDayRateTA.Text);
                    cd.HalfDayRateTA = Utils.CheckDecimal(txtHfDayRateTA.Text);
                    cd.DayRateLTTA = Utils.CheckDecimal(txtLTDayTA.Text);
                    cd.HalfDayRateLTTA = Utils.CheckDecimal(txtLTHfDayTA.Text);

                    cd.Current = chkCurrent.Checked;
                    cd.Teacher = chkTeacher.Checked;
                    cd.TA = chkTA.Checked;
                    cd.Actor = chkActor.Checked;
                    cd.PPA = chkPPA.Checked;
                    cd.LT = chkLT.Checked;
                    cd.D2D = chkD2D.Checked;
                    cd.RGD = chkRGD.Checked;
                    cd.Location = GetLocation();

                    //cd.FirstAid = chkFirstAid.Checked;
                    //cd.RWInc = chkRWInc.Checked;
                    //cd.BSL = chkBSL.Checked;

                    db.SubmitChanges();
                    return;

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SaveSummaryInfo: " + ex.Message);
            }
        }

        private void LoadSummaryInfo()
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.ContactDatas.FirstOrDefault(s => s.ContactID == CurrentContactID);

                    if (cd == null)
                    {
                        cd = new ContactData();
                        cd.ContactID = CurrentContactID;
                        db.ContactDatas.InsertOnSubmit(cd);
                        db.SubmitChanges();

                    }
                    else
                    {

                        txtLives.Text = cd.Live;
                        txtNoGo.Text = cd.NoGo;
                        txtWants.Text = cd.Wants;
                        txtCRBstatus.Text = cd.CRBStatus;
                        txtTeacherStatus.Text = cd.TeacherStatus;
                        chkTeacher.Checked = cd.Teacher;
                        chkTA.Checked = cd.TA;
                        chkActor.Checked = cd.Actor;
                        chkNN.Checked = cd.NN;
                        chkQNN.Checked = cd.QNN;
                        chkSEN.Checked = cd.SEN;
                        chkQTS1.Checked = chkQTS.Checked; //load only - updated via different control
                        chkNQT1.Checked = chkNQT.Checked;//load only - updated via different control
                        chkOTT.Checked = chkOverseasTrainedTeacher.Checked;//load only - updated via different control
                        chkNur.Checked = cd.Nur;
                        chkRec.Checked = cd.Rec;
                        chkYr1.Checked = cd.Yr1;
                        chkYr2.Checked = cd.Yr2;
                        chkYr3.Checked = cd.Yr3;
                        chkYr4.Checked = cd.Yr4;
                        chkYr5.Checked = cd.Yr5;
                        chkYr6.Checked = cd.Yr6;
                        txtDayRate.Text = cd.DayRate.ToString();
                        txtHfDayRate.Text = cd.HalfDayRate.ToString();
                        txtLTDay.Text = cd.DayRateLT.ToString();
                        txtLTHfDay.Text = cd.HalfDayRateLT.ToString();

                        txtDayRateTA.Text = cd.DayRateTA.ToString();
                        txtHfDayRateTA.Text = cd.HalfDayRateTA.ToString();
                        txtLTDayTA.Text = cd.DayRateLTTA.ToString();
                        txtLTHfDayTA.Text = cd.HalfDayRateLTTA.ToString();

                        chkCurrent.Checked = cd.Current;
                        chkTeacher.Checked = cd.Teacher;
                        chkTA.Checked = cd.TA;
                        chkPPA.Checked = cd.PPA;
                        chkLT.Checked = cd.LT;
                        chkD2D.Checked = cd.D2D;
                        chkRGD.Checked = cd.RGD;
                        SetLocation(cd.Location);
                        //chkFirstAid.Checked = cd.FirstAid;
                        //chkRWInc.Checked = cd.RWInc;
                        //chkBSL.Checked = cd.BSL;

                    }


                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadSummaryInfo(): " + ex.Message);
            }
        }

        private void UpdateWants()
        {
            string wants = "";
            if (chkPPA.Checked) wants += "/PPA";
            if (chkLT.Checked) wants += "/LT";
            if (chkD2D.Checked) wants += "/D2D";
            if (chkRGD.Checked) wants += "/RGD";

            if (wants.Length > 0) wants = wants.Substring(1);
            txtWants.Text = wants;


        }

        #endregion




















    }
}
