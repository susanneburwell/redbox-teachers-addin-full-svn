using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using RedboxAddin.Models;
using System.Data;
using RedboxAddin.BL;
using System.Data.SqlClient;

namespace RedboxAddin.DL
{
    class OLDDBManager
    {
        internal static SqlConnection _DBConn;
        //private static string _SQLCEConnStr = "Data Source=DAVTON05\\EXPRESS2;Initial Catalog=RedboxDB;Integrated Security=True";


        internal static bool OpenDBConnection()
        {
            try
            {
                string connStrFromSettings = DavSettings.getDavValue("CONNSTROLD");
                Debug.DebugMessage(4, "ConnStr " + connStrFromSettings);
                if (_DBConn == null) _DBConn = _DBConn = new SqlConnection(connStrFromSettings);
                if (_DBConn.State == ConnectionState.Closed)
                {
                    _DBConn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error Opening the DB Connection :- " + ex.Message);
                return false;
            }
        }

        internal static bool CloseDBConnection()
        {
            try
            {
                if (_DBConn.State == ConnectionState.Open)
                {
                    _DBConn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error closing the DB connection :- " + ex.Message);
                return false;
            }
        }

        public DataSet GetDataSet(string sql)
        {
            try
            {
                OpenDBConnection();
                SqlCommand cmd;
                DataSet ds = new DataSet();
                cmd = new SqlCommand(sql, _DBConn);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(ds, "dataset");
                return ds;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "***GetDateSet : Error creating the dataset : " + ex.Message);
                return null;
            }
            finally
            {
                CloseDBConnection();
            }
        }

        public List<RContact> GetOldContacts()
        {
            List<RContact> contactList = new List<RContact>();
            try
            {
                DataSet msgDs = GetDataSet("Select * from tblContacts");
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            objContact = new RContact()
                            {
                                FirstName = dr["FirstName"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Title = dr["Title"].ToString(),
                                MiddleName = dr["MiddleName"].ToString(),
                                Suffix = dr["Suffix"].ToString(),
                                Email1 = dr["Email1"].ToString(),
                                Email2 = dr["Email2"].ToString(),
                                Email3 = dr["Email3"].ToString(),
                                JobTitle = dr["JobTitle"].ToString(),
                                contactID = Convert.ToInt64(dr["contactID"].ToString()),
                                AddressStreet = dr["AddressStreet"].ToString(),
                                AddressCity = dr["AddressCity"].ToString(),
                                AddressState = dr["AddressState"].ToString(),
                                AddressPostcode = dr["AddressPostcode"].ToString(),
                                AddressCountry = dr["AddressCountry"].ToString(),
                                PhoneHome = dr["PhoneHome"].ToString(),
                                PhoneMobile = dr["PhoneMobile"].ToString(),
                                PhoneBusiness = dr["PhoneBusiness"].ToString(),
                                PhoneFax = dr["PhoneFax"].ToString(),
                                CategoryStr = dr["CategoryStr"].ToString(),
                                _1stRefChecked = CheckBool(dr["1stRefChecked"].ToString()),
                                _2ndRefChecked = CheckBool(dr["2ndRefChecked"].ToString()),
                                _3rdRefChecked = CheckBool(dr["3rdRefChecked"].ToString()),
                                AccountName = dr["AccountName"].ToString(),
                                Cautions_AdditionalInfo_OnDBS = CheckBool(dr["AdditionalInfoOnCRB"].ToString()),
                                BankAccountNumber = dr["BankAccountNumber"].ToString(),
                                BankName = dr["BankName"].ToString(),
                                BankSortCode = dr["BankSortCode"].ToString(),
                                BankStatementLocation = dr["BankStatementLocation"].ToString(),
                                BirthDate = dr["BirthDate"].ToString(),
                                Consultant = dr["Consultant"].ToString(),
                                DBSandAddressProofMatch = CheckBool(dr["CRBandAddressProofMatch"].ToString()),
                                DBSDateSent = CheckDate(dr["CRBDateSent"].ToString()),
                                DBSExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                                DBSFormRef = dr["CRBFormRef"].ToString(),
                                DBSNumber = dr["CRBNumber"].ToString(),
                                DBSValidFrom = CheckDate(dr["CRBValidFrom"].ToString()),
                                CurrentPayScale = dr["CurrentPayScale"].ToString(),
                                CVReceived = CheckBool(dr["CVReceived"].ToString()),
                                DateOfSupply = CheckDate(dr["DateOfSupply"].ToString()),
                                FirstDayTeachingUK = CheckDate(dr["FirstDayTeachingUK"].ToString()),
                                GTCCheckDate = CheckDate(dr["GTCCheckDate"].ToString()),
                                IDChecked = CheckBool(dr["IDChecked"].ToString()),
                                Instructor = CheckBool(dr["Instructor"].ToString()),
                                GTCNumber = dr["GTCNumber"].ToString(),
                                InterviewNotes = dr["InterviewNotes"].ToString(),
                                LateRecord = dr["LateRecord"].ToString(),
                                List99 = CheckBool(dr["List99"].ToString()),
                                LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                                MedicalChecklist = CheckBool(dr["MedicalChecklist"].ToString()),
                                NINumber = dr["NINumber"].ToString(),
                                Notes = dr["Notes"].ToString(),
                                NQT = CheckBool(dr["NQT"].ToString()),
                                OtherCRBNumber = CheckBool(dr["OtherCRBNumber"].ToString()),
                                OTTEndDate = CheckDate(dr["OTTEndDate"].ToString()),
                                OverseasPoliceCheck = CheckBool(dr["OverseasPoliceCheck"].ToString()),
                                OverseasTrainedTeacher = CheckBool(dr["OverseasTrainedTeacher"].ToString()),
                                PassportNo = dr["PassportNo"].ToString(),
                                PassportLocation = dr["PassportLocation"].ToString(),
                                PayDetails = dr["PayDetails"].ToString(),
                                PAYETeacherContractSigned = CheckBool(dr["PAYETeacherContractSigned"].ToString()),
                                PhotoLocation = dr["PhotoLocation"].ToString(),
                                GraduationDate = CheckDate(dr["GraduationDate"].ToString()),
                                ProtabilityCheckSent = CheckDate(dr["ProtabilityCheckSent"].ToString()),
                                ProtabilityReceivedDate = CheckDate(dr["ProtabilityReceivedDate"].ToString()),
                                ProofOfAddress = CheckBool(dr["ProofOfAddress"].ToString()),
                                ProofOfID = dr["ProofOfID"].ToString(),
                                ProofOfID2 = dr["ProofOfID2"].ToString(),
                                QTS = CheckBool(dr["QTS"].ToString()),
                                Qualification = dr["Qualification"].ToString(),
                                RedboxLeaveDate = CheckDate(dr["RedboxLeaveDate"].ToString()),
                                RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                                RedboxDBS = CheckBool(dr["RedboxCRB"].ToString()),
                                ReferredBy = dr["ReferredBy"].ToString(),
                                Referee1Address = dr["Referee1Address"].ToString(),
                                Referee1Email = dr["Referee1Email"].ToString(),
                                Referee1Fax = dr["Referee1Fax"].ToString(),
                                Referee1Mobile = dr["Referee1Mobile"].ToString(),
                                Referee1Name = dr["Referee1Name"].ToString(),
                                Referee1Notes = dr["Referee1Notes"].ToString(),
                                Referee1Phone = dr["Referee1Phone"].ToString(),
                                Referee2Address = dr["Referee2Address"].ToString(),
                                Referee2Email = dr["Referee2Email"].ToString(),
                                Referee2Fax = dr["Referee2Fax"].ToString(),
                                Referee2Mobile = dr["Referee2Mobile"].ToString(),
                                Referee2Name = dr["Referee2Name"].ToString(),
                                Referee2Notes = dr["Referee2Notes"].ToString(),
                                Referee2Phone = dr["Referee2Phone"].ToString(),
                                Referee3Address = dr["Referee3Address"].ToString(),
                                Referee3Email = dr["Referee3Email"].ToString(),
                                Referee3Fax = dr["Referee3Fax"].ToString(),
                                Referee3Mobile = dr["Referee3Mobile"].ToString(),
                                Referee3Name = dr["Referee3Name"].ToString(),
                                Referee3Notes = dr["Referee3Notes"].ToString(),
                                Referee3Phone = dr["Referee3Phone"].ToString(),
                                ReferencesChecked = CheckBool(dr["ReferencesChecked"].ToString()),
                                RegistrationComplete = CheckBool(dr["RegistrationComplete"].ToString()),
                                RegistrationDate = CheckDate(dr["RegistrationDate"].ToString()),
                                SendBankStatement = CheckBool(dr["SendBankStatement"].ToString()),
                                SendPassport = CheckBool(dr["SendPassport"].ToString()),
                                SendVisa = CheckBool(dr["SendVisa"].ToString()),
                                SicknessRecord = dr["SicknessRecord"].ToString(),
                                TeacherStatus = dr["TeacherStatus"].ToString(),
                                UKArrivalDate = CheckDate(dr["UKArrivalDate"].ToString()),
                                UpdateService = CheckBool(dr["UpdateService"].ToString()),
                                UpdateServiceRegisteredDate = CheckDate(dr["UpdateServiceRegisteredDate"].ToString()),
                                VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                                VisaType = dr["VisaType"].ToString(),
                                VisaLocation = dr["VisaLocation"].ToString(),
                                YearGroup = dr["YearGroup"].ToString(),
                            };
                            contactList.Add(objContact);
                        }
                        catch (Exception ex1)
                        { Debug.DebugMessage(2, "Error in GetOldContacts(1): " + ex1.Message); }
                    }
                }
                return contactList;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetOldContacts: " + ex.Message);
                return null;
            }

        }

        private bool CheckBool(object value)
        {
            if (value == DBNull.Value) return false;
            else if (value == null) return false;
            else if (value.ToString() == "") return false;
            else return bool.Parse(value.ToString());
        }

        private DateTime CheckDate(object value)
        {
            if (value == DBNull.Value) return DateTime.MinValue;
            else if (value == null) return DateTime.MinValue;
            else if (string.IsNullOrEmpty(value.ToString())) return DateTime.MinValue;
            else return DateTime.Parse(value.ToString());
        }
    }
}
