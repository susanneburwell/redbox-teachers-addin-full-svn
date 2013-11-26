using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedboxAddin.Models;
using System.Data;
using RedboxAddin.BL;
using System.Data.SqlClient;


namespace RedboxAddin.DL
{
    class DBManager
    {
        internal static SqlConnection _DBConn;
        //private static string _SQLCEConnStr = "Data Source=DAVTON05\\EXPRESS2;Initial Catalog=RedboxDB;Integrated Security=True";


        internal static bool OpenDBConnection()
        {
            try
            {
                string connStrFromSettings = DavSettings.getDavValue("CONNSTR");
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

        public bool ExecuteQuery(string sql)
        {
            try
            {
                OpenDBConnection();
                SqlCommand cmd = new SqlCommand(sql, _DBConn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(4, "***Error Creating the Database Connection. /n" + ex.Message);
                return false;
            }
            finally { CloseDBConnection(); }
        }

        public List<RContact> GetContacts()
        {

            List<RContact> contactList = new List<RContact>();
            try
            {
                DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix,CategoryStr,Email1,Birthdate,JobTitle,contactID,PhoneHome,PhoneMobile,PhoneBusiness,LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate from tblContacts");


                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        string categoryString = dr["CategoryStr"].ToString();
                        var arr = categoryString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 0)
                        {
                            objContact = new RContact()
                            {
                                FirstName = dr["FirstName"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Title = dr["Title"].ToString(),
                                MiddleName = dr["MiddleName"].ToString(),
                                Suffix = dr["Suffix"].ToString(),
                                Email1 = dr["Email1"].ToString(),
                                BirthDate = dr["BirthDate"].ToString(),
                                JobTitle = dr["JobTitle"].ToString(),
                                PhoneHome = dr["PhoneHome"].ToString(),
                                PhoneBusiness = dr["PhoneBusiness"].ToString(),
                                CategoryStr = "",
                                PhoneMobile = dr["PhoneMobile"].ToString(),
                                contactID = Convert.ToInt64(dr["contactID"].ToString()),
                                CRBExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                                LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                                VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                                RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                                FullName = dr["Title"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString()
                            };
                            contactList.Add(objContact);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                objContact = new RContact()
                                {
                                    FirstName = dr["FirstName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    MiddleName = dr["MiddleName"].ToString(),
                                    Suffix = dr["Suffix"].ToString(),
                                    Email1 = dr["Email1"].ToString(),
                                    BirthDate = dr["BirthDate"].ToString(),
                                    JobTitle = dr["JobTitle"].ToString(),
                                    PhoneHome = dr["PhoneHome"].ToString(),
                                    PhoneBusiness = dr["PhoneBusiness"].ToString(),
                                    CategoryStr = arr[i],
                                    PhoneMobile = dr["PhoneMobile"].ToString(),
                                    contactID = Convert.ToInt64(dr["contactID"].ToString()),
                                    CRBExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                                    LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                                    VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                                    RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                                    FullName = dr["Title"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString()
                                };
                                contactList.Add(objContact);
                            }
                        }


                    }
                    return contactList;
                }
                else return null;
            }
            catch (Exception ex) { return null; }
        }

        public List<RContact> GetContactsEx()
        {

            List<RContact> contactList = new List<RContact>();
            try
            {
                DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix,CategoryStr,Email1,Birthdate,JobTitle,contactID,PhoneHome,PhoneMobile,PhoneBusiness,LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate from tblContacts");
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        objContact = new RContact()
                        {
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Title = dr["Title"].ToString(),
                            MiddleName = dr["MiddleName"].ToString(),
                            Suffix = dr["Suffix"].ToString(),
                            Email1 = dr["Email1"].ToString(),
                            BirthDate = dr["BirthDate"].ToString(),
                            JobTitle = dr["JobTitle"].ToString(),
                            PhoneHome = dr["PhoneHome"].ToString(),
                            PhoneBusiness = dr["PhoneBusiness"].ToString(),
                            CategoryStr = dr["CategoryStr"].ToString(),
                            PhoneMobile = dr["PhoneMobile"].ToString(),
                            contactID = Convert.ToInt64(dr["contactID"].ToString()),
                            CRBExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                            LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                            VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                            RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                            FullName = dr["Title"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString()
                        };
                        contactList.Add(objContact);
                    }
                    return contactList;
                }
                else return null;
            }
            catch (Exception ex) { return null; }
        }

        public List<RReminder> GetReminders()
        {
            List<RReminder> reminderList = new List<RReminder>();
            try
            {
                DataSet ds = GetDataSet("Select * from tblReminders");
                if (ds != null)
                {
                    RReminder reminderObj = null;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        reminderObj = new RReminder()
                          {
                              contactID = Convert.ToInt64(dr["ContactRefID"].ToString()),
                              Type = dr["Type"].ToString(),
                              DueDate = CheckDate(dr["DueDate"].ToString()),
                              Subject = dr["Subject"].ToString(),
                              Status = dr["Status"].ToString(),
                              Notes = dr["Notes"].ToString(),
                              CompletedBy = dr["CompletedBy"].ToString(),
                              reminderID = Convert.ToInt64(dr["ReminderID"].ToString())
                          };
                        reminderList.Add(reminderObj);
                    }
                }
                return reminderList;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "" + ex.Message);
                return reminderList;
            }
        }

        public List<RAvailability> GetAvailability(DateTime weekbegining, string wheresql)
        {

            List<RAvailability> availabilityList = new List<RAvailability>();
            try
            {
                string SQLstr = GetAvailabilitySQL(weekbegining);
                DataSet msgDs = GetDataSet(SQLstr + wheresql);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RAvailability objAvail = new RAvailability()
                        {
                            Teacher = dr["Teacher"].ToString(),
                            //CRB = dr["CRB"].ToString(),
                            Live = dr["Live"].ToString(),
                            NoGo = dr["NoGo"].ToString(),
                            PofA = dr["ProofofAddress"].ToString(),
                            QTS = dr["QTS"].ToString(),
                            Wants = dr["Wants"].ToString(),
                            YrGroup = dr["YearGroup"].ToString(),
                            Monday = dr["Monday"].ToString(),
                            Tuesday = dr["Tuesday"].ToString(),
                            Wednesday = dr["Wednesday"].ToString(),
                            Thursday = dr["Thursday"].ToString(),
                            Friday = dr["Friday"].ToString(),

                        };
                        availabilityList.Add(objAvail);

                    }

                    return availabilityList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetAvailability: " + ex.Message);
                return null;
            }
        }

        public List<RLoad> GetLoadPlan(DateTime dStart, DateTime dEnd)
        {

            List<RLoad> LoadPlan = new List<RLoad>();
            try
            {
                string SQLstr = GetLoadPlanSQL(dStart, dEnd);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            RLoad objLoad = new RLoad()
                           {
                               School = dr["SchoolName"].ToString(),
                               Name = dr["Name"].ToString(),
                               Rate = Utils.CheckDecimal(dr["Rate"].ToString()),
                               Charge = Utils.CheckDecimal(dr["Charge"].ToString()),
                               Date = Convert.ToDateTime(dr["Date"]),
                               Description = dr["Description"].ToString(),
                               Margin = Utils.CheckDecimal(dr["Margin"].ToString())

                           };
                            LoadPlan.Add(objLoad);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List: " + ex.Message); }

                    }

                    return LoadPlan;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetLoadPlan: " + ex.Message);
                return null;
            }
        }

        public List<RBookings> GetBookings(DateTime weekbegining, string wheresql)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetBookingSQL(weekbegining);
                DataSet msgDs = GetDataSet(SQLstr + wheresql);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RBookings objBkg = new RBookings()
                        {
                            Teacher = dr["Teacher"].ToString(),
                            //CRB = dr["CRB"].ToString(),
                            //Live = dr["Live"].ToString(),
                            //NoGo = dr["NoGo"].ToString(),
                            //PofA = dr["ProofofAddress"].ToString(),
                            //QTS = dr["QTS"].ToString(),
                            //Wants = dr["Wants"].ToString(),
                            //YrGroup = dr["YearGroup"].ToString(),
                            Monday = dr["Monday"].ToString(),
                            //Tuesday = dr["Tuesday"].ToString(),
                            //Wednesday = dr["Wednesday"].ToString(),
                            //Thursday = dr["Thursday"].ToString(),
                            //Friday = dr["Friday"].ToString(),

                        };
                        bookingList.Add(objBkg);

                    }

                    return bookingList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetAvailability: " + ex.Message);
                return null;
            }
        }

        public RReminder GetReminder(long reminderID)
        {
            try
            {
                DataSet ds = GetDataSet("Select * from tblReminders WHERE ReminderID =" + reminderID);
                if (ds != null)
                {
                    RReminder reminderObj = null;
                    DataRow dr = ds.Tables[0].Rows[0];

                    reminderObj = new RReminder()
                    {
                        contactID = Convert.ToInt64(dr["ContactRefID"].ToString()),
                        Type = dr["Type"].ToString(),
                        DueDate = CheckDate(dr["DueDate"].ToString()),
                        Subject = dr["Subject"].ToString(),
                        Status = dr["Status"].ToString(),
                        Notes = dr["Notes"].ToString(),
                        CompletedBy = dr["CompletedBy"].ToString(),
                        reminderID = Convert.ToInt64(dr["ReminderID"].ToString())
                    };
                    return reminderObj;
                }
                return null;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetReminder() : " + ex.Message);
                return null;
            }
        }

        public long GetReminderID(long contactRef, string reminderType)
        {
            try
            {
                DataSet ds = GetDataSet("Select ReminderID from tblReminders WHERE ContactRefID =" + contactRef + " AND Type = '" + reminderType + "'");
                if (ds != null)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    var reminderID = Convert.ToInt64(dr["ReminderID"].ToString());
                    return reminderID;
                }
                return 0;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetReminder() : " + ex.Message);
                return 0;
            }
        }

        public long GetContactIDfromFullName(string fullName)
        {
            //Return contactID or -1 of not found
            try
            {
                string[] names = fullName.Split(' ');
                string firstname = names[1];
                string lastname = names[0];
                DataSet msgDs = GetDataSet("Select ContactID from tblContacts "
                + "WHERE FirstName = '" + firstname + "' AND LastName = '" + lastname + "'");
                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        string id = dr["ContactID"].ToString();
                        return Convert.ToInt64(id);
                    }
                }
                Debug.DebugMessage(2, "No ContactID found for " + fullName);
                return -1;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetContactIDfromFullName: " + ex.Message);
                return -1;
            }

        }

        public long GetSchoolIDfromName(string schoolName)
        {
            //Return contactID or -1 of not found
            try
            {
                DataSet msgDs = GetDataSet("Select ID from schools "
                + "WHERE SchoolName = '" + schoolName + "' OR ShortName = '" + schoolName + "'");
                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        string id = dr["ID"].ToString();
                        return Convert.ToInt64(id);
                    }
                }

                ////Create New School if not found

                //string sqlStr = "INSERT INTO schools (SchoolName) VALUES (@SchoolName)";

                //DBManager.OpenDBConnection();
                //var CmdAddSchool = new SqlCommand(sqlStr, DBManager._DBConn);
                //CmdAddSchool.Parameters.Add("@SchoolName", SqlDbType.VarChar, 200);
                //CmdAddSchool.Parameters["@SchoolName"].Value = schoolName;
                //CmdAddSchool.ExecuteNonQuery();

                //DataSet ds = GetDataSet("SELECT ID FROM Schools WHERE SchoolName = '" + schoolName + "'");
                //DataRow drow = ds.Tables[0].Rows[0];
                //long autoGeneratedID = Convert.ToInt64(drow["ID"].ToString());
                //return autoGeneratedID;

                //Debug.DebugMessage(2, "No ContactID found for " + schoolName);
                return -1;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetContactIDfromFullName: " + ex.Message);
                return -1;
            }

        }

        public RContact GetContact(long contactID)
        {
            try
            {
                DataSet msgDs = GetDataSet("Select * from tblContacts WHERE contactID = " + contactID.ToString());
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
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
                            AdditionalInfoOnCRB = CheckBool(dr["AdditionalInfoOnCRB"].ToString()),
                            BankAccountNumber = dr["BankAccountNumber"].ToString(),
                            BankName = dr["BankName"].ToString(),
                            BankSortCode = dr["BankSortCode"].ToString(),
                            BankStatementLocation = dr["BankStatementLocation"].ToString(),
                            BirthDate = dr["BirthDate"].ToString(),
                            Consultant = dr["Consultant"].ToString(),
                            CRBandAddressProofMatch = CheckBool(dr["CRBandAddressProofMatch"].ToString()),
                            CRBDateSent = CheckDate(dr["CRBDateSent"].ToString()),
                            CRBExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                            CRBFormRef = dr["CRBFormRef"].ToString(),
                            CRBNumber = dr["CRBNumber"].ToString(),
                            CRBValidFrom = CheckDate(dr["CRBValidFrom"].ToString()),
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
                            RedboxCRB = CheckBool(dr["RedboxCRB"].ToString()),
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
                        return objContact;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "***GetMessageTemplates : Error  : " + ex.Message);
                return null;
            }

        }

        public bool AddReminder(RReminder reminderObj)
        {
            try
            {
                string sqlStr = "INSERT INTO tblReminders ("
                    + "ContactRefID,"
                    + "Type,"
                    + "Subject,"
                    + "DueDate,"
                    + "Status,"
                    + "Notes) VALUES(@contactRef,@type,@subject,@duedate,@status,@notes) ";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@contactRef", SqlDbType.BigInt);
                CmdAddContact.Parameters.Add("@type", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@subject", SqlDbType.VarChar, 1000);
                CmdAddContact.Parameters.Add("@duedate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@status", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@notes", SqlDbType.VarChar, 5000);
                CmdAddContact.Prepare();
                CmdAddContact.Parameters["@contactRef"].Value = CheckVals(reminderObj.contactID);
                CmdAddContact.Parameters["@type"].Value = CheckVals(reminderObj.Type);
                CmdAddContact.Parameters["@subject"].Value = CheckVals(reminderObj.Subject);
                CmdAddContact.Parameters["@duedate"].Value = CheckVals(reminderObj.DueDate);
                CmdAddContact.Parameters["@status"].Value = CheckVals(reminderObj.Status);
                CmdAddContact.Parameters["@notes"].Value = CheckVals(reminderObj.Notes);
                CmdAddContact.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding the reminder :- " + ex.Message);
                return false;
            }
        }

        public bool UpdateReminder(RReminder reminderObj, long reminderID)
        {
            try
            {
                string sqlStr = "UPDATE tblReminders SET "
                                       + "Type = @type,"
                    + "Subject = @subject,"
                    + "DueDate = @duedate,"
                    + "Status = @status,CompletedBy = @completedBy,"
                    + "Notes= @notes WHERE ReminderID = @reminderID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@reminderID", SqlDbType.BigInt);
                CmdAddContact.Parameters.Add("@type", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@subject", SqlDbType.VarChar, 1000);
                CmdAddContact.Parameters.Add("@duedate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@status", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@notes", SqlDbType.VarChar, 5000);
                CmdAddContact.Parameters.Add("@completedBy", SqlDbType.VarChar, 500);
                CmdAddContact.Prepare();
                CmdAddContact.Parameters["@reminderID"].Value = CheckVals(reminderID);
                CmdAddContact.Parameters["@type"].Value = CheckVals(reminderObj.Type);
                CmdAddContact.Parameters["@subject"].Value = CheckVals(reminderObj.Subject);
                CmdAddContact.Parameters["@duedate"].Value = CheckVals(reminderObj.DueDate);
                CmdAddContact.Parameters["@status"].Value = CheckVals(reminderObj.Status);
                CmdAddContact.Parameters["@notes"].Value = CheckVals(reminderObj.Notes);
                CmdAddContact.Parameters["@completedBy"].Value = CheckVals(reminderObj.CompletedBy);
                CmdAddContact.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in adding the reminder :- " + ex.Message);
                return false;
            }
        }

        public List<long> CheckDupes(string firstName, string lastName)
        {
            try
            {
                var listToReturn = new List<long>();
                DataSet ds = GetDataSet("SELECT contactID FROM tblContacts WHERE FirstName = '" + firstName + "' AND LastName = '" + lastName + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listToReturn.Add(Convert.ToInt64(dr["contactID"]));
                }
                if (listToReturn.Count == 0)
                    return null;
                else return listToReturn;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDupes :- " + ex.Message);
                return null;
            }
        }


        public long AddContact(RContact contactObj)
        {
            try
            {
                string sqlStr = "INSERT INTO tblContacts ("
                    + "FirstName,"
                    + "LastName,"
                    + "Title,"
                    + "MiddleName,"
                    + "Suffix,"
                    + "Email1,"
                    + "Email2,"
                    + "Email3,"
                    + "JobTitle,"
                    + "AddressStreet,"
                    + "AddressCity,"
                    + "AddressState,"
                    + "AddressPostcode,"
                    + "AddressCountry,"
                    + "PhoneHome,"
                    + "PhoneMobile,"
                    + "PhoneBusiness,"
                    + "PhoneFax,"
                    + "CategoryStr,"
                    + "[1stRefChecked],"
                    + "[2ndRefChecked],"
                    + "[3rdRefChecked],"
                    + "AccountName,"
                    + "AdditionalInfoOnCRB,"
                    + "BankAccountNumber,"
                    + "BankName,"
                    + "BankSortCode,"
                    + "BankStatementLocation,"
                    + "BirthDate,"
                    + "Consultant,"
                    + "CRBandAddressProofMatch,"
                    + "CRBDateSent,"
                    + "CRBExpiryDate,"
                    + "CRBFormRef,"
                    + "CRBNumber,"
                    + "CRBValidFrom,"
                    + "CurrentPayScale,"
                    + "CVReceived,"
                    + "DateOfSupply,"
                    + "FirstDayTeachingUK,"
                    + "GTCCheckDate,"
                    + "GTCNumber,"
                    + "IDChecked,"
                    + "Instructor,"
                    + "InterviewNotes,"
                    + "LateRecord,"
                    + "List99,"
                    + "LTStartDate,"
                    + "MedicalChecklist,"
                    + "NINumber,"
                    + "Notes,"
                    + "NQT,"
                    + "OtherCRBNumber,"
                    + "OTTEndDate,"
                    + "OverseasPoliceCheck,"
                    + "OverseasTrainedTeacher,"
                    + "PassportNo,"
                    + "PassportLocation,"
                    + "PayDetails,"
                    + "PAYETeacherContractSigned,"
                    + "PhotoLocation,"
                    + "GraduationDate,"
                    + "ProtabilityCheckSent,"
                    + "ProtabilityReceivedDate,"
                    + "ProofOfAddress,"
                    + "ProofOfID,"
                    + "ProofOfID2,"
                    + "QTS,"
                    + "Qualification,"
                    + "RedboxLeaveDate,"
                    + "RedboxStartDate,"
                    + "RedboxCRB,"
                    + "ReferredBy, "
                    + "Referee1Address,"
                    + "Referee1Email,"
                    + "Referee1Fax,"
                    + "Referee1Mobile,"
                    + "Referee1Name,"
                    + "Referee1Notes,"
                    + "Referee1Phone,"
                    + "Referee2Address,"
                    + "Referee2Email,"
                    + "Referee2Fax,"
                    + "Referee2Mobile,"
                    + "Referee2Name,"
                    + "Referee2Notes,"
                    + "Referee2Phone,"
                    + "Referee3Address,"
                    + "Referee3Email,"
                    + "Referee3Fax,"
                    + "Referee3Mobile,"
                    + "Referee3Name,"
                    + "Referee3Notes,"
                    + "Referee3Phone,"
                    + "ReferencesChecked,"
                    + "RegistrationComplete,"
                    + "RegistrationDate,"
                    + "SendBankStatement,"
                    + "SendPassport,"
                    + "SendVisa,"
                    + "SicknessRecord,"
                    + "TeacherStatus,"
                    + "UKArrivalDate,"
                    + "UpdateService,"
                    + "UpdateServiceRegisteredDate,"
                    + "VisaExpiryDate,"
                    + "VisaType,"
                    + "VisaLocation,"
                    + "YearGroup,"
                    + "LastMod,"
                    + "GUID) VALUES ("
                    + "@FirstName,"
                    + "@LastName,"
                    + "@Title,"
                    + "@MiddleName,"
                    + "@Suffix,"
                    + "@Email1,"
                    + "@Email2,"
                    + "@Email3,"
                    + "@JobTitle,"
                    + "@AddressStreet,"
                    + "@AddressCity,"
                    + "@AddressState,"
                    + "@AddressPostcode,"
                    + "@AddressCountry,"
                    + "@PhoneHome,"
                    + "@PhoneMobile,"
                    + "@PhoneBusiness,"
                    + "@PhoneFax,"
                    + "@CategoryStr,"
                    + "@1stRefChecked,"
                    + "@2ndRefChecked,"
                    + "@3rdRefChecked,"
                    + "@AccountName,"
                    + "@AdditionalInfoOnCRB,"
                    + "@BankAccountNumber,"
                    + "@BankName,"
                    + "@BankSortCode,"
                    + "@BankStatementLocation,"
                    + "@BirthDate,"
                    + "@Consultant,"
                    + "@CRBandAddressProofMatch,"
                    + "@CRBDateSent,"
                    + "@CRBExpiryDate,"
                    + "@CRBFormRef,"
                    + "@CRBNumber,"
                    + "@CRBValidFrom,"
                    + "@CurrentPayScale,"
                    + "@CVReceived,"
                    + "@DateOfSupply,"
                    + "@FirstDayTeachingUK,"
                    + "@GTCCheckDate,"
                    + "@GTCNumber,"
                    + "@IDChecked,"
                    + "@Instructor,"
                    + "@InterviewNotes,"
                    + "@LateRecord,"
                    + "@List99,"
                    + "@LTStartDate,"
                    + "@MedicalChecklist,"
                    + "@NINumber,"
                    + "@Notes,"
                    + "@NQT,"
                    + "@OtherCRBNumber,"
                    + "@OTTEndDate,"
                    + "@OverseasPoliceCheck,"
                    + "@OverseasTrainedTeacher,"
                    + "@PassportNo,"
                    + "@PassportLocation,"
                    + "@PayDetails,"
                    + "@PAYETeacherContractSigned,"
                    + "@PhotoLocation,"
                    + "@GraduationDate,"
                    + "@ProtabilityCheckSent,"
                    + "@ProtabilityReceivedDate,"
                    + "@ProofOfAddress,"
                    + "@ProofOfID,"
                    + "@ProofOfID2,"
                    + "@QTS,"
                    + "@Qualification,"
                    + "@RedboxLeaveDate,"
                    + "@RedboxStartDate,"
                    + "@RedboxCRB,"
                    + "@ReferredBy, "
                    + "@Referee1Address,"
                    + "@Referee1Email,"
                    + "@Referee1Fax,"
                    + "@Referee1Mobile,"
                    + "@Referee1Name,"
                    + "@Referee1Notes,"
                    + "@Referee1Phone,"
                    + "@Referee2Address,"
                    + "@Referee2Email,"
                    + "@Referee2Fax,"
                    + "@Referee2Mobile,"
                    + "@Referee2Name,"
                    + "@Referee2Notes,"
                    + "@Referee2Phone,"
                    + "@Referee3Address,"
                    + "@Referee3Email,"
                    + "@Referee3Fax,"
                    + "@Referee3Mobile,"
                    + "@Referee3Name,"
                    + "@Referee3Notes,"
                    + "@Referee3Phone,"
                    + "@ReferencesChecked,"
                    + "@RegistrationComplete,"
                    + "@RegistrationDate,"
                    + "@SendBankStatement,"
                    + "@SendPassport,"
                    + "@SendVisa,"
                    + "@SicknessRecord,"
                    + "@TeacherStatus,"
                    + "@UKArrivalDate,"
                    + "@UpdateService,"
                    + "@UpdateServiceRegisteredDate,"
                    + "@VisaExpiryDate,"
                    + "@VisaType,"
                    + "@VisaLocation,"
                    + "@YearGroup,"
                    + "@LastMod,"
                    + "@GUID)";

                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@FirstName", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@LastName", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Title", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@MiddleName", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Suffix", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Email1", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Email2", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Email3", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@JobTitle", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@AddressStreet", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@AddressCity", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@AddressState", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@AddressPostcode", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@AddressCountry", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@PhoneHome", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@PhoneMobile", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@PhoneBusiness", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@PhoneFax", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@CategoryStr", SqlDbType.VarChar, 1000);
                CmdAddContact.Parameters.Add("@1stRefChecked", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@2ndRefChecked", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@3rdRefChecked", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@AccountName", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@AdditionalInfoOnCRB", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@BankAccountNumber", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@BankName", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@BankSortCode", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@BankStatementLocation", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@BirthDate", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@Consultant", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@CRBandAddressProofMatch", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@CRBDateSent", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@CRBExpiryDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@CRBFormRef", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@CRBNumber", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@CRBValidFrom", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@CurrentPayScale", SqlDbType.VarChar, 50);
                CmdAddContact.Parameters.Add("@CVReceived", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@DateOfSupply", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@FirstDayTeachingUK", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@GTCCheckDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@GTCNumber", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@IDChecked", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@Instructor", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@InterviewNotes", SqlDbType.VarChar, 8000);
                CmdAddContact.Parameters.Add("@LateRecord", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@List99", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@LTStartDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@MedicalChecklist", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@NINumber", SqlDbType.VarChar, 50);
                CmdAddContact.Parameters.Add("@Notes", SqlDbType.VarChar, -1);
                CmdAddContact.Parameters.Add("@NQT", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@OtherCRBNumber", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@OTTEndDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@OverseasPoliceCheck", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@OverseasTrainedTeacher", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@PassportNo", SqlDbType.VarChar, 50);
                CmdAddContact.Parameters.Add("@PassportLocation", SqlDbType.VarChar, 1000);
                CmdAddContact.Parameters.Add("@PayDetails", SqlDbType.VarChar, 50);
                CmdAddContact.Parameters.Add("@PAYETeacherContractSigned", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@PhotoLocation", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@GraduationDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@ProtabilityCheckSent", SqlDbType.DateTime);   //@GraduationDate
                CmdAddContact.Parameters.Add("@ProtabilityReceivedDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@ProofOfAddress", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@ProofOfID", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@ProofOfID2", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@QTS", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@Qualification", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@RedboxLeaveDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@RedboxStartDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@RedboxCRB", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@ReferredBy", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@Referee1Address", SqlDbType.VarChar, 2000);
                CmdAddContact.Parameters.Add("@Referee1Email", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Referee1Fax", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee1Mobile", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee1Name", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee1Notes", SqlDbType.VarChar, 8000);
                CmdAddContact.Parameters.Add("@Referee1Phone", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee2Address", SqlDbType.VarChar, 2000);
                CmdAddContact.Parameters.Add("@Referee2Email", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Referee2Fax", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee2Mobile", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee2Name", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee2Notes", SqlDbType.VarChar, 8000);
                CmdAddContact.Parameters.Add("@Referee2Phone", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee3Address", SqlDbType.VarChar, 2000);
                CmdAddContact.Parameters.Add("@Referee3Email", SqlDbType.VarChar, 200);
                CmdAddContact.Parameters.Add("@Referee3Fax", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee3Mobile", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee3Name", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@Referee3Notes", SqlDbType.VarChar, 8000);
                CmdAddContact.Parameters.Add("@Referee3Phone", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@ReferencesChecked", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@RegistrationComplete", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@SendBankStatement", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@SendPassport", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@SendVisa", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@SicknessRecord", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@TeacherStatus", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@UKArrivalDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@UpdateService", SqlDbType.Bit);
                CmdAddContact.Parameters.Add("@UpdateServiceRegisteredDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@VisaExpiryDate", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@VisaType", SqlDbType.VarChar, 100);
                CmdAddContact.Parameters.Add("@VisaLocation", SqlDbType.VarChar, 1000);
                CmdAddContact.Parameters.Add("@YearGroup", SqlDbType.VarChar, 500);
                CmdAddContact.Parameters.Add("@LastMod", SqlDbType.DateTime);
                CmdAddContact.Parameters.Add("@GUID", SqlDbType.VarChar, 100);
                CmdAddContact.Prepare();
                CmdAddContact.Parameters["@FirstName"].Value = CheckVals(contactObj.FirstName);
                CmdAddContact.Parameters["@LastName"].Value = CheckVals(contactObj.LastName);
                CmdAddContact.Parameters["@Title"].Value = CheckVals(contactObj.Title);
                CmdAddContact.Parameters["@MiddleName"].Value = CheckVals(contactObj.MiddleName);
                CmdAddContact.Parameters["@Suffix"].Value = CheckVals(contactObj.Suffix);
                CmdAddContact.Parameters["@Email1"].Value = CheckVals(contactObj.Email1);
                CmdAddContact.Parameters["@Email2"].Value = CheckVals(contactObj.Email2);
                CmdAddContact.Parameters["@Email3"].Value = CheckVals(contactObj.Email3);
                CmdAddContact.Parameters["@JobTitle"].Value = CheckVals(contactObj.JobTitle);
                CmdAddContact.Parameters["@AddressStreet"].Value = CheckVals(contactObj.AddressStreet);
                CmdAddContact.Parameters["@AddressCity"].Value = CheckVals(contactObj.AddressCity);
                CmdAddContact.Parameters["@AddressState"].Value = CheckVals(contactObj.AddressState);
                CmdAddContact.Parameters["@AddressPostcode"].Value = CheckVals(contactObj.AddressPostcode);
                CmdAddContact.Parameters["@AddressCountry"].Value = CheckVals(contactObj.AddressCountry);
                CmdAddContact.Parameters["@PhoneHome"].Value = CheckVals(contactObj.PhoneHome);
                CmdAddContact.Parameters["@PhoneMobile"].Value = CheckVals(contactObj.PhoneMobile);
                CmdAddContact.Parameters["@PhoneBusiness"].Value = CheckVals(contactObj.PhoneBusiness);
                CmdAddContact.Parameters["@PhoneFax"].Value = CheckVals(contactObj.PhoneFax);
                CmdAddContact.Parameters["@CategoryStr"].Value = CheckVals(contactObj.CategoryStr);
                CmdAddContact.Parameters["@1stRefChecked"].Value = CheckVals(contactObj._1stRefChecked);
                CmdAddContact.Parameters["@2ndRefChecked"].Value = CheckVals(contactObj._2ndRefChecked);
                CmdAddContact.Parameters["@3rdRefChecked"].Value = CheckVals(contactObj._3rdRefChecked);
                CmdAddContact.Parameters["@AccountName"].Value = CheckVals(contactObj.AccountName);
                CmdAddContact.Parameters["@AdditionalInfoOnCRB"].Value = CheckVals(contactObj.AdditionalInfoOnCRB);
                CmdAddContact.Parameters["@BankAccountNumber"].Value = CheckVals(contactObj.BankAccountNumber);
                CmdAddContact.Parameters["@BankName"].Value = CheckVals(contactObj.BankName);
                CmdAddContact.Parameters["@BankSortCode"].Value = CheckVals(contactObj.BankSortCode);
                CmdAddContact.Parameters["@BankStatementLocation"].Value = CheckVals(contactObj.BankStatementLocation);
                CmdAddContact.Parameters["@BirthDate"].Value = CheckVals(contactObj.BirthDate);
                CmdAddContact.Parameters["@Consultant"].Value = CheckVals(contactObj.Consultant);
                CmdAddContact.Parameters["@CRBandAddressProofMatch"].Value = CheckVals(contactObj.CRBandAddressProofMatch);
                CmdAddContact.Parameters["@CRBDateSent"].Value = FilterSQLDate(contactObj.CRBDateSent);
                CmdAddContact.Parameters["@CRBExpiryDate"].Value = FilterSQLDate(contactObj.CRBExpiryDate);
                CmdAddContact.Parameters["@CRBFormRef"].Value = CheckVals(contactObj.CRBFormRef);
                CmdAddContact.Parameters["@CRBNumber"].Value = CheckVals(contactObj.CRBNumber);
                CmdAddContact.Parameters["@CRBValidFrom"].Value = FilterSQLDate(contactObj.CRBValidFrom);
                CmdAddContact.Parameters["@CurrentPayScale"].Value = CheckVals(contactObj.CurrentPayScale);
                CmdAddContact.Parameters["@CVReceived"].Value = CheckVals(contactObj.CVReceived);
                CmdAddContact.Parameters["@DateOfSupply"].Value = FilterSQLDate(contactObj.DateOfSupply);
                CmdAddContact.Parameters["@FirstDayTeachingUK"].Value = FilterSQLDate(contactObj.FirstDayTeachingUK);
                CmdAddContact.Parameters["@GTCCheckDate"].Value = FilterSQLDate(contactObj.GTCCheckDate);
                CmdAddContact.Parameters["@GTCNumber"].Value = CheckVals(contactObj.GTCNumber);
                CmdAddContact.Parameters["@IDChecked"].Value = CheckVals(contactObj.IDChecked);
                CmdAddContact.Parameters["@Instructor"].Value = CheckVals(contactObj.Instructor);
                CmdAddContact.Parameters["@InterviewNotes"].Value = CheckVals(contactObj.InterviewNotes);
                CmdAddContact.Parameters["@LateRecord"].Value = CheckVals(contactObj.LateRecord);
                CmdAddContact.Parameters["@List99"].Value = CheckVals(contactObj.List99);
                CmdAddContact.Parameters["@LTStartDate"].Value = FilterSQLDate(contactObj.LTStartDate);
                CmdAddContact.Parameters["@MedicalChecklist"].Value = CheckVals(contactObj.MedicalChecklist);
                CmdAddContact.Parameters["@NINumber"].Value = CheckVals(contactObj.NINumber);
                CmdAddContact.Parameters["@Notes"].Value = CheckVals(contactObj.Notes);
                CmdAddContact.Parameters["@NQT"].Value = CheckVals(contactObj.NQT);
                CmdAddContact.Parameters["@OtherCRBNumber"].Value = CheckVals(contactObj.OtherCRBNumber);
                CmdAddContact.Parameters["@OTTEndDate"].Value = FilterSQLDate(contactObj.OTTEndDate);
                CmdAddContact.Parameters["@OverseasPoliceCheck"].Value = CheckVals(contactObj.OverseasPoliceCheck);
                CmdAddContact.Parameters["@OverseasTrainedTeacher"].Value = CheckVals(contactObj.OverseasTrainedTeacher);
                CmdAddContact.Parameters["@PassportNo"].Value = CheckVals(contactObj.PassportNo);
                CmdAddContact.Parameters["@PassportLocation"].Value = CheckVals(contactObj.PassportLocation);
                CmdAddContact.Parameters["@PayDetails"].Value = CheckVals(contactObj.PayDetails);
                CmdAddContact.Parameters["@PAYETeacherContractSigned"].Value = CheckVals(contactObj.PAYETeacherContractSigned);
                CmdAddContact.Parameters["@PhotoLocation"].Value = CheckVals(contactObj.PhotoLocation);
                CmdAddContact.Parameters["@GraduationDate"].Value = FilterSQLDate(contactObj.GraduationDate);
                CmdAddContact.Parameters["@ProtabilityCheckSent"].Value = FilterSQLDate(contactObj.ProtabilityCheckSent);
                CmdAddContact.Parameters["@ProtabilityReceivedDate"].Value = FilterSQLDate(contactObj.ProtabilityReceivedDate);
                CmdAddContact.Parameters["@ProofOfAddress"].Value = CheckVals(contactObj.ProofOfAddress);
                CmdAddContact.Parameters["@ProofOfID"].Value = CheckVals(contactObj.ProofOfID);
                CmdAddContact.Parameters["@ProofOfID2"].Value = CheckVals(contactObj.ProofOfID2);
                CmdAddContact.Parameters["@QTS"].Value = CheckVals(contactObj.QTS);
                CmdAddContact.Parameters["@Qualification"].Value = CheckVals(contactObj.Qualification);
                CmdAddContact.Parameters["@RedboxLeaveDate"].Value = FilterSQLDate(contactObj.RedboxLeaveDate);
                CmdAddContact.Parameters["@RedboxStartDate"].Value = FilterSQLDate(contactObj.RedboxStartDate);
                CmdAddContact.Parameters["@RedboxCRB"].Value = CheckVals(contactObj.RedboxCRB);
                CmdAddContact.Parameters["@ReferredBy"].Value = CheckVals(contactObj.ReferredBy);
                CmdAddContact.Parameters["@Referee1Address"].Value = CheckVals(contactObj.Referee1Address);
                CmdAddContact.Parameters["@Referee1Email"].Value = CheckVals(contactObj.Referee1Email);
                CmdAddContact.Parameters["@Referee1Fax"].Value = CheckVals(contactObj.Referee1Fax);
                CmdAddContact.Parameters["@Referee1Mobile"].Value = CheckVals(contactObj.Referee1Mobile);
                CmdAddContact.Parameters["@Referee1Name"].Value = CheckVals(contactObj.Referee1Name);
                CmdAddContact.Parameters["@Referee1Notes"].Value = CheckVals(contactObj.Referee1Notes);
                CmdAddContact.Parameters["@Referee1Phone"].Value = CheckVals(contactObj.Referee1Phone);
                CmdAddContact.Parameters["@Referee2Address"].Value = CheckVals(contactObj.Referee2Address);
                CmdAddContact.Parameters["@Referee2Email"].Value = CheckVals(contactObj.Referee2Email);
                CmdAddContact.Parameters["@Referee2Fax"].Value = CheckVals(contactObj.Referee2Fax);
                CmdAddContact.Parameters["@Referee2Mobile"].Value = CheckVals(contactObj.Referee2Mobile);
                CmdAddContact.Parameters["@Referee2Name"].Value = CheckVals(contactObj.Referee2Name);
                CmdAddContact.Parameters["@Referee2Notes"].Value = CheckVals(contactObj.Referee2Notes);
                CmdAddContact.Parameters["@Referee2Phone"].Value = CheckVals(contactObj.Referee2Phone);
                CmdAddContact.Parameters["@Referee3Address"].Value = CheckVals(contactObj.Referee3Address);
                CmdAddContact.Parameters["@Referee3Email"].Value = CheckVals(contactObj.Referee3Email);
                CmdAddContact.Parameters["@Referee3Fax"].Value = CheckVals(contactObj.Referee3Fax);
                CmdAddContact.Parameters["@Referee3Mobile"].Value = CheckVals(contactObj.Referee3Mobile);
                CmdAddContact.Parameters["@Referee3Name"].Value = CheckVals(contactObj.Referee3Name);
                CmdAddContact.Parameters["@Referee3Notes"].Value = CheckVals(contactObj.Referee3Notes);
                CmdAddContact.Parameters["@Referee3Phone"].Value = CheckVals(contactObj.Referee3Phone);
                CmdAddContact.Parameters["@ReferencesChecked"].Value = CheckVals(contactObj.ReferencesChecked);
                CmdAddContact.Parameters["@RegistrationComplete"].Value = CheckVals(contactObj.RegistrationComplete);
                CmdAddContact.Parameters["@RegistrationDate"].Value = FilterSQLDate(contactObj.RegistrationDate);
                CmdAddContact.Parameters["@SendBankStatement"].Value = CheckVals(contactObj.SendBankStatement);
                CmdAddContact.Parameters["@SendPassport"].Value = CheckVals(contactObj.SendPassport);
                CmdAddContact.Parameters["@SendVisa"].Value = CheckVals(contactObj.SendVisa);
                CmdAddContact.Parameters["@SicknessRecord"].Value = CheckVals(contactObj.SicknessRecord);
                CmdAddContact.Parameters["@TeacherStatus"].Value = CheckVals(contactObj.TeacherStatus);
                CmdAddContact.Parameters["@UKArrivalDate"].Value = FilterSQLDate(contactObj.UKArrivalDate);
                CmdAddContact.Parameters["@UpdateService"].Value = CheckVals(contactObj.UpdateService);
                CmdAddContact.Parameters["@UpdateServiceRegisteredDate"].Value = FilterSQLDate(contactObj.UpdateServiceRegisteredDate);
                CmdAddContact.Parameters["@VisaExpiryDate"].Value = FilterSQLDate(contactObj.VisaExpiryDate);
                CmdAddContact.Parameters["@VisaType"].Value = CheckVals(contactObj.VisaType);
                CmdAddContact.Parameters["@VisaLocation"].Value = CheckVals(contactObj.VisaLocation);
                CmdAddContact.Parameters["@YearGroup"].Value = CheckVals(contactObj.YearGroup);
                CmdAddContact.Parameters["@LastMod"].Value = FilterSQLDate(DateTime.UtcNow);
                string guidVal = System.Guid.NewGuid().ToString();
                CmdAddContact.Parameters["@GUID"].Value = CheckVals(guidVal);
                CmdAddContact.ExecuteNonQuery();

                DataSet ds = GetDataSet("SELECT contactID FROM tblContacts WHERE GUID = '" + guidVal + "'");
                DataRow dr = ds.Tables[0].Rows[0];
                long autoGeneratedContactID = Convert.ToInt64(dr["contactID"].ToString());

                return autoGeneratedContactID;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in AddContact :- " + ex.Message);
                return 0;
            }
        }

        public bool UpdateContact(RContact contactObj, long contactID)
        {
            try
            {
                string sqlStr = "UPDATE tblContacts SET "
                       + "FirstName = @FirstName, "
                       + "LastName = @LastName, "
                       + "Title = @Title, "
                       + "MiddleName = @MiddleName, "
                       + "Suffix = @Suffix, "
                       + "Email1 = @Email1, "
                       + "Email2 = @Email2, "
                       + "Email3 = @Email3, "
                       + "JobTitle = @JobTitle, "
                       + "AddressStreet = @AddressStreet, "
                       + "AddressCity = @AddressCity, "
                       + "AddressState = @AddressState, "
                       + "AddressPostcode = @AddressPostcode, "
                       + "AddressCountry = @AddressCountry, "
                       + "PhoneHome = @PhoneHome, "
                       + "PhoneMobile = @PhoneMobile, "
                       + "PhoneBusiness = @PhoneBusiness, "
                       + "PhoneFax = @PhoneFax, "
                       + "CategoryStr = @CategoryStr, "
                       + "[1stRefChecked] = @1stRefChecked, "
                       + "[2ndRefChecked] = @2ndRefChecked, "
                       + "[3rdRefChecked] = @3rdRefChecked, "
                       + "AccountName = @AccountName, "
                       + "AdditionalInfoOnCRB = @AdditionalInfoOnCRB, "
                       + "BankAccountNumber = @BankAccountNumber, "
                       + "BankName = @BankName, "
                       + "BankSortCode = @BankSortCode, "
                       + "BankStatementLocation = @BankStatementLocation, "
                       + "BirthDate = @BirthDate, "
                       + "Consultant = @Consultant , "
                       + "CRBandAddressProofMatch = @CRBandAddressProofMatch, "
                       + "CRBDateSent = @CRBDateSent, "
                       + "CRBExpiryDate = @CRBExpiryDate, "
                       + "CRBFormRef = @CRBFormRef, "
                       + "CRBNumber = @CRBNumber, "
                       + "CRBValidFrom = @CRBValidFrom, "
                       + "CurrentPayScale = @CurrentPayScale, "
                       + "CVReceived = @CVReceived, "
                       + "DateOfSupply = @DateOfSupply, "
                       + "FirstDayTeachingUK = @FirstDayTeachingUK, "
                       + "GTCCheckDate = @GTCCheckDate, "
                       + "GTCNumber = @GTCNumber, "
                       + "IDChecked = @IDChecked, "
                       + "Instructor = @Instructor, "
                       + "InterviewNotes = @InterviewNotes, "
                       + "LateRecord = @LateRecord, "
                       + "List99 = @List99, "
                       + "LTStartDate = @LTStartDate, "
                       + "MedicalChecklist = @MedicalChecklist, "
                       + "NINumber = @NINumber, "
                       + "Notes = @Notes,"
                       + "NQT = @NQT, "
                       + "OtherCRBNumber = @OtherCRBNumber, "
                       + "OTTEndDate = @OTTEndDate, "
                       + "OverseasPoliceCheck = @OverseasPoliceCheck, "
                       + "OverseasTrainedTeacher = @OverseasTrainedTeacher, "
                       + "PassportNo = @PassportNo, "
                       + "PassportLocation = @PassportLocation, "
                       + "PayDetails = @PayDetails, "
                       + "PAYETeacherContractSigned = @PAYETeacherContractSigned, "
                       + "PhotoLocation = @PhotoLocation,"
                       + "GraduationDate = @GraduationDate, "
                       + "ProtabilityCheckSent = @ProtabilityCheckSent, "
                       + "ProtabilityReceivedDate = @ProtabilityReceivedDate, "
                       + "ProofOfAddress = @ProofOfAddress, "
                       + "ProofOfID = @ProofOfID, "
                       + "ProofOfID2 = @ProofOfID2, "
                       + "QTS = @QTS, "
                       + "Qualification = @Qualification, "
                       + "RedboxLeaveDate = @RedboxLeaveDate, "
                       + "RedboxStartDate = @RedboxStartDate, "
                       + "RedboxCRB = @RedboxCRB, "
                       + "ReferredBy = @ReferredBy, "
                       + "Referee1Address = @Referee1Address, "
                       + "Referee1Email = @Referee1Email, "
                       + "Referee1Fax = @Referee1Fax, "
                       + "Referee1Mobile = @Referee1Mobile, "
                       + "Referee1Name = @Referee1Name, "
                       + "Referee1Notes = @Referee1Notes, "
                       + "Referee1Phone = @Referee1Phone, "
                       + "Referee2Address = @Referee2Address, "
                       + "Referee2Email = @Referee2Email, "
                       + "Referee2Fax = @Referee2Fax, "
                       + "Referee2Mobile = @Referee2Mobile, "
                       + "Referee2Name = @Referee2Name, "
                       + "Referee2Notes = @Referee2Notes, "
                       + "Referee2Phone = @Referee2Phone, "
                       + "Referee3Address = @Referee3Address, "
                       + "Referee3Email = @Referee3Email, "
                       + "Referee3Fax = @Referee3Fax, "
                       + "Referee3Mobile = @Referee3Mobile, "
                       + "Referee3Name = @Referee3Name, "
                       + "Referee3Notes = @Referee3Notes, "
                       + "Referee3Phone = @Referee3Phone, "
                       + "ReferencesChecked = @ReferencesChecked, "
                       + "RegistrationComplete = @RegistrationComplete, "
                       + "RegistrationDate = @RegistrationDate, "
                       + "SendBankStatement = @SendBankStatement, "
                       + "SendPassport = @SendPassport, "
                       + "SendVisa = @SendVisa, "
                       + "SicknessRecord = @SicknessRecord, "
                       + "TeacherStatus = @TeacherStatus, "
                       + "UKArrivalDate = @UKArrivalDate, "
                       + "UpdateService = @UpdateService,"
                       + "UpdateServiceRegisteredDate = @UpdateServiceRegisteredDate,"
                       + "VisaExpiryDate = @VisaExpiryDate, "
                       + "VisaType = @VisaType, "
                       + "VisaLocation = @VisaLocation, "
                       + "YearGroup = @YearGroup, "
                       + "LastMod = @LastMod WHERE contactID = @contactID";
                DBManager.OpenDBConnection();
                var CmdUpdateContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdUpdateContact.Parameters.Add("@contactID", SqlDbType.BigInt);
                CmdUpdateContact.Parameters.Add("@FirstName", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@LastName", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Title", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@MiddleName", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Suffix", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Email1", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Email2", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Email3", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@JobTitle", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@AddressStreet", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@AddressCity", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@AddressState", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@AddressPostcode", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@AddressCountry", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@PhoneHome", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@PhoneMobile", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@PhoneBusiness", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@PhoneFax", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@CategoryStr", SqlDbType.VarChar, 1000);
                CmdUpdateContact.Parameters.Add("@1stRefChecked", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@2ndRefChecked", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@3rdRefChecked", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@AccountName", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@AdditionalInfoOnCRB", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@BankAccountNumber", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@BankName", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@BankSortCode", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@BankStatementLocation", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@BirthDate", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@Consultant", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@CRBandAddressProofMatch", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@CRBDateSent", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@CRBExpiryDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@CRBFormRef", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@CRBNumber", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@CRBValidFrom", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@CurrentPayScale", SqlDbType.VarChar, 50);
                CmdUpdateContact.Parameters.Add("@CVReceived", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@DateOfSupply", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@FirstDayTeachingUK", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@GTCCheckDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@GTCNumber", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@IDChecked", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@Instructor", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@InterviewNotes", SqlDbType.VarChar, -1);
                CmdUpdateContact.Parameters.Add("@LateRecord", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@List99", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@LTStartDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@MedicalChecklist", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@NINumber", SqlDbType.VarChar, 50);
                CmdUpdateContact.Parameters.Add("@Notes", SqlDbType.VarChar, -1);
                CmdUpdateContact.Parameters.Add("@NQT", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@OtherCRBNumber", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@OTTEndDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@OverseasPoliceCheck", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@OverseasTrainedTeacher", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@PassportNo", SqlDbType.VarChar, 50);
                CmdUpdateContact.Parameters.Add("@PassportLocation", SqlDbType.VarChar, 1000);
                CmdUpdateContact.Parameters.Add("@PayDetails", SqlDbType.VarChar, 50);
                CmdUpdateContact.Parameters.Add("@PAYETeacherContractSigned", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@PhotoLocation", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@GraduationDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@ProtabilityCheckSent", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@ProtabilityReceivedDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@ProofOfAddress", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@ProofOfID", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@ProofOfID2", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@QTS", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@Qualification", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@RedboxLeaveDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@RedboxStartDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@RedboxCRB", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@ReferredBy", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@Referee1Address", SqlDbType.VarChar, 2000);
                CmdUpdateContact.Parameters.Add("@Referee1Email", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Referee1Fax", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee1Mobile", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee1Name", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee1Notes", SqlDbType.VarChar, 8000);
                CmdUpdateContact.Parameters.Add("@Referee1Phone", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee2Address", SqlDbType.VarChar, 2000);
                CmdUpdateContact.Parameters.Add("@Referee2Email", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Referee2Fax", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee2Mobile", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee2Name", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee2Notes", SqlDbType.VarChar, 8000);
                CmdUpdateContact.Parameters.Add("@Referee2Phone", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee3Address", SqlDbType.VarChar, 2000);
                CmdUpdateContact.Parameters.Add("@Referee3Email", SqlDbType.VarChar, 200);
                CmdUpdateContact.Parameters.Add("@Referee3Fax", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee3Mobile", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee3Name", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@Referee3Notes", SqlDbType.VarChar, 8000);
                CmdUpdateContact.Parameters.Add("@Referee3Phone", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@ReferencesChecked", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@RegistrationComplete", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@SendBankStatement", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@SendPassport", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@SendVisa", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@SicknessRecord", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@TeacherStatus", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@UKArrivalDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@UpdateService", SqlDbType.Bit);
                CmdUpdateContact.Parameters.Add("@UpdateServiceRegisteredDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@VisaExpiryDate", SqlDbType.DateTime);
                CmdUpdateContact.Parameters.Add("@VisaType", SqlDbType.VarChar, 100);
                CmdUpdateContact.Parameters.Add("@VisaLocation", SqlDbType.VarChar, 1000);
                CmdUpdateContact.Parameters.Add("@YearGroup", SqlDbType.VarChar, 500);
                CmdUpdateContact.Parameters.Add("@LastMod", SqlDbType.DateTime);
                CmdUpdateContact.Prepare();
                CmdUpdateContact.Parameters["@contactID"].Value = contactID;
                CmdUpdateContact.Parameters["@FirstName"].Value = CheckVals(contactObj.FirstName);
                CmdUpdateContact.Parameters["@LastName"].Value = CheckVals(contactObj.LastName);
                CmdUpdateContact.Parameters["@Title"].Value = CheckVals(contactObj.Title);
                CmdUpdateContact.Parameters["@MiddleName"].Value = CheckVals(contactObj.MiddleName);
                CmdUpdateContact.Parameters["@Suffix"].Value = CheckVals(contactObj.Suffix);
                CmdUpdateContact.Parameters["@Email1"].Value = CheckVals(contactObj.Email1);
                CmdUpdateContact.Parameters["@Email2"].Value = CheckVals(contactObj.Email2);
                CmdUpdateContact.Parameters["@Email3"].Value = CheckVals(contactObj.Email3);
                CmdUpdateContact.Parameters["@JobTitle"].Value = CheckVals(contactObj.JobTitle);
                CmdUpdateContact.Parameters["@AddressStreet"].Value = CheckVals(contactObj.AddressStreet);
                CmdUpdateContact.Parameters["@AddressCity"].Value = CheckVals(contactObj.AddressCity);
                CmdUpdateContact.Parameters["@AddressState"].Value = CheckVals(contactObj.AddressState);
                CmdUpdateContact.Parameters["@AddressPostcode"].Value = CheckVals(contactObj.AddressPostcode);
                CmdUpdateContact.Parameters["@AddressCountry"].Value = CheckVals(contactObj.AddressCountry);
                CmdUpdateContact.Parameters["@PhoneHome"].Value = CheckVals(contactObj.PhoneHome);
                CmdUpdateContact.Parameters["@PhoneMobile"].Value = CheckVals(contactObj.PhoneMobile);
                CmdUpdateContact.Parameters["@PhoneBusiness"].Value = CheckVals(contactObj.PhoneBusiness);
                CmdUpdateContact.Parameters["@PhoneFax"].Value = CheckVals(contactObj.PhoneFax);
                CmdUpdateContact.Parameters["@CategoryStr"].Value = CheckVals(contactObj.CategoryStr);
                CmdUpdateContact.Parameters["@1stRefChecked"].Value = CheckVals(contactObj._1stRefChecked);
                CmdUpdateContact.Parameters["@2ndRefChecked"].Value = CheckVals(contactObj._2ndRefChecked);
                CmdUpdateContact.Parameters["@3rdRefChecked"].Value = CheckVals(contactObj._3rdRefChecked);
                CmdUpdateContact.Parameters["@AccountName"].Value = CheckVals(contactObj.AccountName);
                CmdUpdateContact.Parameters["@AdditionalInfoOnCRB"].Value = CheckVals(contactObj.AdditionalInfoOnCRB);
                CmdUpdateContact.Parameters["@BankAccountNumber"].Value = CheckVals(contactObj.BankAccountNumber);
                CmdUpdateContact.Parameters["@BankName"].Value = CheckVals(contactObj.BankName);
                CmdUpdateContact.Parameters["@BankSortCode"].Value = CheckVals(contactObj.BankSortCode);
                CmdUpdateContact.Parameters["@BankStatementLocation"].Value = CheckVals(contactObj.BankStatementLocation);
                CmdUpdateContact.Parameters["@BirthDate"].Value = CheckVals(contactObj.BirthDate);
                CmdUpdateContact.Parameters["@Consultant"].Value = CheckVals(contactObj.Consultant);
                CmdUpdateContact.Parameters["@CRBandAddressProofMatch"].Value = CheckVals(contactObj.CRBandAddressProofMatch);
                CmdUpdateContact.Parameters["@CRBDateSent"].Value = FilterSQLDate(contactObj.CRBDateSent);
                CmdUpdateContact.Parameters["@CRBExpiryDate"].Value = FilterSQLDate(contactObj.CRBExpiryDate);
                CmdUpdateContact.Parameters["@CRBFormRef"].Value = CheckVals(contactObj.CRBFormRef);
                CmdUpdateContact.Parameters["@CRBNumber"].Value = CheckVals(contactObj.CRBNumber);
                CmdUpdateContact.Parameters["@CRBValidFrom"].Value = FilterSQLDate(contactObj.CRBValidFrom);
                CmdUpdateContact.Parameters["@CurrentPayScale"].Value = CheckVals(contactObj.CurrentPayScale);
                CmdUpdateContact.Parameters["@CVReceived"].Value = CheckVals(contactObj.CVReceived);
                CmdUpdateContact.Parameters["@DateOfSupply"].Value = FilterSQLDate(contactObj.DateOfSupply);
                CmdUpdateContact.Parameters["@FirstDayTeachingUK"].Value = FilterSQLDate(contactObj.FirstDayTeachingUK);
                CmdUpdateContact.Parameters["@GTCCheckDate"].Value = FilterSQLDate(contactObj.GTCCheckDate);
                CmdUpdateContact.Parameters["@GTCNumber"].Value = CheckVals(contactObj.GTCNumber);
                CmdUpdateContact.Parameters["@IDChecked"].Value = CheckVals(contactObj.IDChecked);
                CmdUpdateContact.Parameters["@Instructor"].Value = CheckVals(contactObj.Instructor);
                CmdUpdateContact.Parameters["@InterviewNotes"].Value = CheckVals(contactObj.InterviewNotes);
                CmdUpdateContact.Parameters["@LateRecord"].Value = CheckVals(contactObj.LateRecord);
                CmdUpdateContact.Parameters["@List99"].Value = CheckVals(contactObj.List99);
                CmdUpdateContact.Parameters["@LTStartDate"].Value = FilterSQLDate(contactObj.LTStartDate);
                CmdUpdateContact.Parameters["@MedicalChecklist"].Value = CheckVals(contactObj.MedicalChecklist);
                CmdUpdateContact.Parameters["@NINumber"].Value = CheckVals(contactObj.NINumber);
                CmdUpdateContact.Parameters["@Notes"].Value = CheckVals(contactObj.Notes);
                CmdUpdateContact.Parameters["@NQT"].Value = CheckVals(contactObj.NQT);
                CmdUpdateContact.Parameters["@OtherCRBNumber"].Value = CheckVals(contactObj.OtherCRBNumber);
                CmdUpdateContact.Parameters["@OTTEndDate"].Value = FilterSQLDate(contactObj.OTTEndDate);
                CmdUpdateContact.Parameters["@OverseasPoliceCheck"].Value = CheckVals(contactObj.OverseasPoliceCheck);
                CmdUpdateContact.Parameters["@OverseasTrainedTeacher"].Value = CheckVals(contactObj.OverseasTrainedTeacher);
                CmdUpdateContact.Parameters["@PassportNo"].Value = CheckVals(contactObj.PassportNo);
                CmdUpdateContact.Parameters["@PassportLocation"].Value = CheckVals(contactObj.PassportLocation);
                CmdUpdateContact.Parameters["@PayDetails"].Value = CheckVals(contactObj.PayDetails);
                CmdUpdateContact.Parameters["@PAYETeacherContractSigned"].Value = CheckVals(contactObj.PAYETeacherContractSigned);
                CmdUpdateContact.Parameters["@PhotoLocation"].Value = CheckVals(contactObj.PhotoLocation);
                CmdUpdateContact.Parameters["@GraduationDate"].Value = FilterSQLDate(contactObj.GraduationDate);
                CmdUpdateContact.Parameters["@ProtabilityCheckSent"].Value = FilterSQLDate(contactObj.ProtabilityCheckSent);
                CmdUpdateContact.Parameters["@ProtabilityReceivedDate"].Value = FilterSQLDate(contactObj.ProtabilityReceivedDate);
                CmdUpdateContact.Parameters["@ProofOfAddress"].Value = CheckVals(contactObj.ProofOfAddress);
                CmdUpdateContact.Parameters["@ProofOfID"].Value = CheckVals(contactObj.ProofOfID);
                CmdUpdateContact.Parameters["@ProofOfID2"].Value = CheckVals(contactObj.ProofOfID2);
                CmdUpdateContact.Parameters["@QTS"].Value = CheckVals(contactObj.QTS);
                CmdUpdateContact.Parameters["@Qualification"].Value = CheckVals(contactObj.Qualification);
                CmdUpdateContact.Parameters["@RedboxLeaveDate"].Value = FilterSQLDate(contactObj.RedboxLeaveDate);
                CmdUpdateContact.Parameters["@RedboxStartDate"].Value = FilterSQLDate(contactObj.RedboxStartDate);
                CmdUpdateContact.Parameters["@RedboxCRB"].Value = CheckVals(contactObj.RedboxCRB);
                CmdUpdateContact.Parameters["@ReferredBy"].Value = CheckVals(contactObj.ReferredBy);
                CmdUpdateContact.Parameters["@Referee1Address"].Value = CheckVals(contactObj.Referee1Address);
                CmdUpdateContact.Parameters["@Referee1Email"].Value = CheckVals(contactObj.Referee1Email);
                CmdUpdateContact.Parameters["@Referee1Fax"].Value = CheckVals(contactObj.Referee1Fax);
                CmdUpdateContact.Parameters["@Referee1Mobile"].Value = CheckVals(contactObj.Referee1Mobile);
                CmdUpdateContact.Parameters["@Referee1Name"].Value = CheckVals(contactObj.Referee1Name);
                CmdUpdateContact.Parameters["@Referee1Notes"].Value = CheckVals(contactObj.Referee1Notes);
                CmdUpdateContact.Parameters["@Referee1Phone"].Value = CheckVals(contactObj.Referee1Phone);
                CmdUpdateContact.Parameters["@Referee2Address"].Value = CheckVals(contactObj.Referee2Address);
                CmdUpdateContact.Parameters["@Referee2Email"].Value = CheckVals(contactObj.Referee2Email);
                CmdUpdateContact.Parameters["@Referee2Fax"].Value = CheckVals(contactObj.Referee2Fax);
                CmdUpdateContact.Parameters["@Referee2Mobile"].Value = CheckVals(contactObj.Referee2Mobile);
                CmdUpdateContact.Parameters["@Referee2Name"].Value = CheckVals(contactObj.Referee2Name);
                CmdUpdateContact.Parameters["@Referee2Notes"].Value = CheckVals(contactObj.Referee2Notes);
                CmdUpdateContact.Parameters["@Referee2Phone"].Value = CheckVals(contactObj.Referee2Phone);
                CmdUpdateContact.Parameters["@Referee3Address"].Value = CheckVals(contactObj.Referee3Address);
                CmdUpdateContact.Parameters["@Referee3Email"].Value = CheckVals(contactObj.Referee3Email);
                CmdUpdateContact.Parameters["@Referee3Fax"].Value = CheckVals(contactObj.Referee3Fax);
                CmdUpdateContact.Parameters["@Referee3Mobile"].Value = CheckVals(contactObj.Referee3Mobile);
                CmdUpdateContact.Parameters["@Referee3Name"].Value = CheckVals(contactObj.Referee3Name);
                CmdUpdateContact.Parameters["@Referee3Notes"].Value = CheckVals(contactObj.Referee3Notes);
                CmdUpdateContact.Parameters["@Referee3Phone"].Value = CheckVals(contactObj.Referee3Phone);
                CmdUpdateContact.Parameters["@ReferencesChecked"].Value = CheckVals(contactObj.ReferencesChecked);
                CmdUpdateContact.Parameters["@RegistrationComplete"].Value = CheckVals(contactObj.RegistrationComplete);
                CmdUpdateContact.Parameters["@RegistrationDate"].Value = FilterSQLDate(contactObj.RegistrationDate);
                CmdUpdateContact.Parameters["@SendBankStatement"].Value = CheckVals(contactObj.SendBankStatement);
                CmdUpdateContact.Parameters["@SendPassport"].Value = CheckVals(contactObj.SendPassport);
                CmdUpdateContact.Parameters["@SendVisa"].Value = CheckVals(contactObj.SendVisa);
                CmdUpdateContact.Parameters["@SicknessRecord"].Value = CheckVals(contactObj.SicknessRecord);
                CmdUpdateContact.Parameters["@TeacherStatus"].Value = CheckVals(contactObj.TeacherStatus);
                CmdUpdateContact.Parameters["@UKArrivalDate"].Value = FilterSQLDate(contactObj.UKArrivalDate);
                CmdUpdateContact.Parameters["@UpdateService"].Value = CheckVals(contactObj.UpdateService);
                CmdUpdateContact.Parameters["@UpdateServiceRegisteredDate"].Value = FilterSQLDate(contactObj.UpdateServiceRegisteredDate);
                CmdUpdateContact.Parameters["@VisaExpiryDate"].Value = FilterSQLDate(contactObj.VisaExpiryDate);
                CmdUpdateContact.Parameters["@VisaType"].Value = CheckVals(contactObj.VisaType);
                CmdUpdateContact.Parameters["@VisaLocation"].Value = CheckVals(contactObj.VisaLocation);
                CmdUpdateContact.Parameters["@YearGroup"].Value = CheckVals(contactObj.YearGroup);
                CmdUpdateContact.Parameters["@LastMod"].Value = FilterSQLDate(DateTime.UtcNow);
                CmdUpdateContact.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private DateTime CheckDate(object value)
        {
            if (value == DBNull.Value) return DateTime.MinValue;
            else if (value == null) return DateTime.MinValue;
            else if (string.IsNullOrEmpty(value.ToString())) return DateTime.MinValue;
            else return DateTime.Parse(value.ToString());
        }

        private object FilterSQLDate(DateTime dtVal)
        {
            if (dtVal == DateTime.MinValue)
            {
                return DBNull.Value;
            }
            else
            {
                return dtVal;
            }
        }

        private object CheckVals(object value)
        {
            if (value == null) return DBNull.Value;
            else return value;
        }

        private bool CheckBool(object value)
        {
            if (value == DBNull.Value) return false;
            else if (value == null) return false;
            else if (value.ToString() == "") return false;
            else return bool.Parse(value.ToString());
        }

        public bool ReminderExist(long contactID, string reminderType)
        {
            var ds = GetDataSet("SELECT * FROM tblReminders WHERE contactRefID = " + contactID.ToString() + " AND Type = '" + reminderType + "'");
            if (ds == null) return false;
            else if (ds.Tables[0].Rows.Count > 0) return true;
            else { return false; }
        }

        public void CheckAndUpdateTeachers()
        {
            //Process the teacher database and update the ContactData table
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var contacts = db.TblContacts;

                    foreach (TblContact cc in contacts)
                    {
                        //find or create ContactData
                        var cd = db.ContactDatas.FirstOrDefault(s => s.ContactID == cc.ContactID);

                        if (cd == null)
                        {
                            //Create a new one
                            cd = new ContactData();
                            cd.ContactID = cc.ContactID;
                            db.ContactDatas.InsertOnSubmit(cd);
                            db.SubmitChanges();
                        }
                        //Create Teacher Status
                        string tStatus = "";
                        if (cc.QTS == true) tStatus += "QTS ";
                        if (cc.NQT == true) tStatus += "NQT ";
                        if (cc.OverseasTrainedTeacher == true) tStatus += "OTT ";
                        cd.TeacherStatus = tStatus.Trim().Replace(' ', ',');
                        cd.CRBStatus = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckAndUpdateTeachers: " + ex.Message);
            }
        }

        #region Create tables

        public bool CheckDatabase()
        {
            OpenDBConnection();

            try
            {

                CreateSchoolsTable();
                CreateSchoolContactsTable();
                CreateMasterBookingsTable();
                CreateBookingsTable();
                CreateAbsenceReasonsTable();
                CreateTeacherLevelTable();
                CreateYearGroupsTable();
                CreateNoGoTable();
                CreateContactDataTable();

                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CreateDatabase" + ex.Message);
                return false;
            }
            finally
            {
                CloseDBConnection();
            }
        }

        private bool CreateTable(string name, string sql)
        {
            try
            {
                string sqlcmd = "Drop Table " + name;

                SqlCommand cmd = new SqlCommand(sqlcmd, _DBConn);

                //Only create table if it does not already exist
                //drop existing table
                //try
                //{
                //    cmd.ExecuteNonQuery();
                //    Debug.DebugMessage(3, name + " Table Dropped");
                //}
                //catch (Exception ex1) { Debug.DebugMessage(3, "Error dropping " + name + " Table: " + ex1); }


                //Create new Table
                try
                {
                    cmd.CommandText = "create table " + name + " ( " + sql + ") ";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex2) { Debug.DebugMessage(1, "Error Creating " + name + " Table: " + ex2); }

                Debug.DebugMessage(3, name + " Table Created");
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in CreateTable(" + name + ")" + ex.Message);
                return false;
            }
        }

        private void CreateSchoolsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                + "SchoolName nvarchar (200) ";
            CreateTable("Schools", sql);
        }

        private void CreateSchoolContactsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                + "SchoolID bigint REFERENCES Schools(SchoolID),"
                + "FirstName nvarchar (50), "
                + "LastName nvarchar (50), "
                + "Phone nvarchar (20), "
                + "Fax nvarchar (20), "
                + "Email nvarchar (50), "
                + "Notes nvarchar (500)";
            CreateTable("SchoolContacts", sql);
        }

        private void CreateMasterBookingsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                + "SchoolID bigint NOT NULL, "
                + "contactID bigint, "
                + "YearGroup nvarchar (20), "
                + "TeacherLevel nvarchar (20), "
                + "Details nvarchar (250), "
                + "StartDate date NOT NULL, "
                + "EndDate date NOT NULL, "
                + "isAbsence bit NOT NULL, "
                + "AbsenceReason nvarchar (50) ";
            CreateTable("MasterBookings", sql);
        }

        private void CreateBookingsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                + "MasterBookingID bigint REFERENCES MasterBookings(ID), "
                + "Date date NOT NULL, "
                + "am bit, "
                + "pm bit ";
            CreateTable("Bookings", sql);
        }

        private void CreateAbsenceReasonsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                 + "Reason nvarchar (50) ";
            CreateTable("AbsenceReasons", sql);
        }

        private void CreateTeacherLevelTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                 + "level nvarchar (50) ";
            CreateTable("TeacherLevels", sql);
        }

        private void CreateYearGroupsTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                 + "YearGroup nvarchar (50) ";
            CreateTable("YearGroups", sql);
        }

        private void CreateNoGoTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                 + "SchoolID bigint, "
                 + "TeacherID bigint, "
                 + "RequestedBy nvarchar (10) ";
            CreateTable("NoGo", sql);
        }

        private void CreateContactDataTable()
        {
            //Create Folders Table
            string sql = "ID bigint IDENTITY NOT NULL PRIMARY KEY, "
                 + "ContactID bigint NOT NULL, "
                 + "Live nvarchar(50), "
                 + "Wants nvarchar(10), "
                 + "YrGroup nvarchar(10), "
                 + "Pay nvarchar(5), "
                 + "PofA bit, "
                 + "NoGo nvarchar(10), "
                 + "RequestedBy nvarchar (10) ";
            CreateTable("ContactData", sql);
        }

        #endregion

        #region SQLQueries

        private string GetAvailabilitySQL(DateTime weekbegining)
        {
            string monday = weekbegining.ToString("yyyyMMdd");
            string tuesday = weekbegining.AddDays(1).ToString("yyyyMMdd");
            string wednesday = weekbegining.AddDays(2).ToString("yyyyMMdd");
            string thursday = weekbegining.AddDays(3).ToString("yyyyMMdd");
            string friday = weekbegining.AddDays(4).ToString("yyyyMMdd");

            string SQLstr = "Select Lastname+' '+FirstName as Teacher,Live, Wants,[ContactData].YearGroup,QTS,ProofofAddress,NoGo, " +
                            "OverseasTrainedTeacher, NQT, TA, QNN, SEN, NN, " +
                            "Nur,Rec,Yr1,Yr2,Yr3,Yr4,Yr5,Yr6, " +
                            "s1.School as Monday, s2.School as Tuesday, s3.School as Wednesday, " +
                            "s4.School as Thursday, s5.School as Friday " +
                            "FROM [tblContacts] " +

                            "LEFT JOIN [ContactData] " +
                            "ON [tblContacts].contactID = [ContactData].ContactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + monday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + monday + "' " +
                            ") as s1 " +
                            "ON s1.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + tuesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + tuesday + "' " +
                            ") as s2 " +
                            "ON s2.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + wednesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + wednesday + "' " +
                            ") as s3 " +
                            "ON s3.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + thursday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + thursday + "' " +
                            ") as s4 " +
                            "ON s4.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + friday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + friday + "' " +
                            ") as s5 " +
                            "ON s5.contactID = [tblContacts].contactID ";

            return SQLstr;
        }

        private string GetBookingSQL(DateTime weekbegining)
        {
            string monday = weekbegining.ToString("yyyyMMdd");
            string tuesday = weekbegining.AddDays(1).ToString("yyyyMMdd");
            string wednesday = weekbegining.AddDays(2).ToString("yyyyMMdd");
            string thursday = weekbegining.AddDays(3).ToString("yyyyMMdd");
            string friday = weekbegining.AddDays(4).ToString("yyyyMMdd");

            string SQLstr = "Select FirstName+' '+Lastname as Teacher,Live, Wants,[ContactData].YearGroup,QTS,ProofofAddress,NoGo, " +
                            "s1.School as Monday, s2.School as Tuesday, s3.School as Wednesday, " +
                            "s4.School as Thursday, s5.School as Friday " +
                            "FROM [tblContacts] " +

                            "LEFT JOIN [ContactData] " +
                            "ON [tblContacts].contactID = [ContactData].ContactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + monday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + monday + "' " +
                            ") as s1 " +
                            "ON s1.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + tuesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + tuesday + "' " +
                            ") as s2 " +
                            "ON s2.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + wednesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + wednesday + "' " +
                            ") as s3 " +
                            "ON s3.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + thursday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + thursday + "' " +
                            ") as s4 " +
                            "ON s4.contactID = [tblContacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Schools].SchoolName+' '+[MasterBookings].YearGroup+' '+[MasterBookings].TeacherLevel as School, [MasterBookings].contactID " +
                            "FROM [MasterBookings] " +
                            "JOIN [Schools] " +
                            "ON [Schools].ID = [MasterBookings].SchoolID " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + friday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + friday + "' " +
                            ") as s5 " +
                            "ON s5.contactID = [tblContacts].contactID ";

            return SQLstr;
        }

        private string GetLoadPlanSQL(DateTime dStart, DateTime dEnd)
        {
            string SQL = "";
            SQL += "SELECT SchoolName, LastName+', '+FirstName as Name, Rate, Bookings.Charge, Bookings.Date, Description, Bookings.Charge-Bookings.Rate as Margin ";
            SQL += "FROM [Bookings] ";
            SQL += "LEFT JOIN [MasterBookings] ";
            SQL += "ON [Bookings].MasterBookingID = MasterBookings.ID ";
            SQL += "LEFT JOIN [Schools] ";
            SQL += "ON [MasterBookings].SchoolID = Schools.ID ";
            SQL += "LEFT JOIN [tblContacts] ";
            SQL += "ON MasterBookings.contactID = tblContacts.contactID ";
            SQL += "WHERE ";
            SQL += "((Bookings.Date >= '" + dStart.ToString("yyyyMMdd") + "') AND (Bookings.Date <= '" + dEnd.ToString("yyyyMMdd") + "'))";

            return SQL;
        }
        #endregion


    }
}
