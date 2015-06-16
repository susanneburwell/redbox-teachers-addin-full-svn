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
                Debug.DebugMessage(1, "Error Opening the DB Connection - the database could not be found :- " + ex.Message);
                return false;
            }
        }

        internal static bool OpenOriginalDBConnection()
        {
            try
            {
                string connStrFromSettings = DavSettings.getDavValue("CONNSTR");
                connStrFromSettings.Replace("RedboxDB2", "RedboxDB");
                Debug.DebugMessage(2, "OriginalConnStr " + connStrFromSettings);
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

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                OpenDBConnection();
                SqlCommand cmd = new SqlCommand(sql, _DBConn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(4, "***Error Creating the Database Connection. /n" + ex.Message);
                return -1;
            }
            finally { CloseDBConnection(); }
        }

        public DataSet GetCurrentContacts()
        {
            DataSet msgDs = null;
            try
            {
                msgDs = GetDataSet("Select FirstName,LastName,Email1 from Contacts join ContactData on ContactData.ContactID = Contacts.contactID WHERE [Deleted] = 0 AND [Current]=1");
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(4, "***Error in GetCurrentContacts. /n" + ex.Message);
                return null;

            }

            return msgDs;
        }

        public DataSet GetSchooltContacts()
        {
            DataSet msgDs = null;
            try
            {
                msgDs = GetDataSet("Select SchoolName, VettingEmails from Schools WHERE EmailAddress != ''");
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(4, "***Error in GetCurrentContacts. /n" + ex.Message);
                return null;

            }

            return msgDs;
        }

        public DataSet GetWorkerDetails(DateTime startDate, DateTime endDate)
        {
            DataSet msgDs = null;
            try
            {

                msgDs = GetDataSet("SELECT"
                                 + "[MasterBookings].[ContactID],"
                                 + "max([FirstName]) as FN,"
                                 + "max( [LastName])as LFN,"
                                 + "max( [Title])as title,"
                                 + "max([MiddleName])as middle,"
                                 + "max([BirthDate]) as DOB,"
                                 + "max( [NINumber])as NI,"
                                 + "SUM([Rate]) as total,"
                                 + "min([Bookings].Date) as start,"
                                 + "max([Bookings].Date) as finish,"
                                 + "max([AddressStreet]) as Address1,"
                                 + "max([AddressCity]) as Address2,"
                                 + "max([AddressState]) as Address3,"
                                 + "max([AddressPostcode]) as PostCode"
                                 + " FROM [RedboxDB2].[dbo].[Bookings]"
                                 + " join [RedboxDB2].[dbo].[MasterBookings] On [MasterBookings].ID = MasterBookingID"
                                 + " join [RedboxDB2].[dbo].Contacts ON [MasterBookings].contactID = [Contacts].contactID"
                                 + " Where [Bookings].Date > '" + startDate + "'"
                                 + " AND [Bookings].Date < '" + endDate + "'"
                                 + " Group By [MasterBookings].[ContactID]"
                                 + " Order by [MasterBookings].[ContactID], start");

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(4, "***Error in GetWorkerDetails. /n" + ex.Message);
                return null;

            }

            return msgDs;
        }

        public List<RContact> GetContacts()
        {

            List<RContact> contactList = new List<RContact>();
            try
            {
                //DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix,CategoryStr,Email1,Birthdate,JobTitle,contactID,PhoneHome,PhoneMobile,PhoneBusiness,LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate from Contacts");
                DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix," +
                "CategoryStr,Email1,Birthdate,JobTitle,Contacts.contactID,PhoneHome,PhoneMobile,PhoneBusiness," +
                "LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate, PayDetails, " +
                "ContactData.[Current],ContactData.[Wants],ContactData.[Teacher],ContactData.[TA],ContactData.[NoGo],ContactData.[LT], " +
                "ContactData.[D2D],ContactData.[PPA],ContactData.[RGD] from Contacts " +
                "join ContactData on ContactData.ContactID = Contacts.contactID " +
                "WHERE [Deleted] = 0 ");


                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        string categoryString = dr["CategoryStr"].ToString();
                        if (categoryString == null) categoryString = "";
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
                                PayDetails = dr["PayDetails"].ToString(),
                                CategoryStr = "",
                                PhoneMobile = dr["PhoneMobile"].ToString(),
                                contactID = Convert.ToInt64(dr["contactID"].ToString()),
                                DBSExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                                LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                                VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                                RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                                FullName = dr["Title"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString(),
                                Current = CheckBool(dr["Current"]),
                                Teacher = CheckBool(dr["Teacher"]),
                                TA = CheckBool(dr["TA"]),
                                LT = CheckBool(dr["LT"]),
                                D2D = CheckBool(dr["D2D"]),
                                PPA = CheckBool(dr["PPA"]),
                                RGD = CheckBool(dr["RGD"]),
                                NoGo = dr["NoGo"].ToString(),
                                Wants = dr["Wants"].ToString()
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
                                    PayDetails = dr["PayDetails"].ToString(),
                                    CategoryStr = arr[i],
                                    PhoneMobile = dr["PhoneMobile"].ToString(),
                                    contactID = Convert.ToInt64(dr["contactID"].ToString()),
                                    DBSExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
                                    LTStartDate = CheckDate(dr["LTStartDate"].ToString()),
                                    VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString()),
                                    RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString()),
                                    FullName = dr["Title"].ToString() + " " + dr["FirstName"].ToString() + " " + dr["LastName"].ToString(),
                                    Current = CheckBool(dr["Current"]),
                                    Teacher = CheckBool(dr["Teacher"]),
                                    TA = CheckBool(dr["TA"]),
                                    LT = CheckBool(dr["LT"]),
                                    D2D = CheckBool(dr["D2D"]),
                                    PPA = CheckBool(dr["PPA"]),
                                    RGD = CheckBool(dr["RGD"]),
                                    NoGo = dr["NoGo"].ToString(),
                                    Wants = dr["Wants"].ToString()
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
                DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix,CategoryStr,Email1,Birthdate,JobTitle,contactID,PhoneHome,PhoneMobile,PhoneBusiness,LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate from Contacts");
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
                            DBSExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString()),
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

        public List<string> CheckTeacherPaymentTypes()
        {
            List<string> missingContacts = new List<string>();
            List<string> pTypes = new List<string>();
            try
            {

                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    var q = from s in db.PaymentTypes
                            orderby s.Name
                            select s;
                    var paymentTypes = q.ToList();

                    foreach (var pt in paymentTypes)
                    {
                        if (pt.Name.Trim() != "key")
                            pTypes.Add(pt.Name.Trim());
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulatePaymentTypes: " + ex.Message);
            }

            List<RContact> contactList = new List<RContact>();
            try
            {
                DataSet msgDs = GetDataSet("Select FirstName,LastName, PayDetails, [Current] from Contacts join ContactData on ContactData.ContactID = Contacts.contactID");
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        objContact = new RContact()
                        {
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            PayDetails = dr["PayDetails"].ToString(),
                            Current = Utils.CheckBool(dr["Current"])
                        };
                        contactList.Add(objContact);
                    }
                }

                foreach (RContact rc in contactList)
                {
                    //just check current contacts
                    if (!rc.Current) continue;

                    //find empty pay details
                    if (string.IsNullOrWhiteSpace(rc.PayDetails))
                    {
                        missingContacts.Add(rc.FirstName + " " + rc.LastName);
                    }
                    //Check for mising key details
                    else if (rc.PayDetails.Substring(0, 3).ToLower() == "key")
                    {
                        if (rc.PayDetails.Length < 6) missingContacts.Add(rc.FirstName + " " + rc.LastName);

                    }
                    else
                    {
                        //check to see if it is set to a known pay type
                        bool found = false;
                        foreach (string paytype in pTypes)
                        {
                            if (paytype == rc.PayDetails)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found) missingContacts.Add(rc.FirstName + " " + rc.LastName);
                    }
                }
            }

            catch (Exception ex) { return null; }
            return missingContacts;
        }


        public List<RReminder> GetReminders()
        {
            List<RReminder> reminderList = new List<RReminder>();
            try
            {
                DataSet ds = GetDataSet("Select * from Reminders");
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

        public List<RAvailability> GetAvailability(DateTime weekbegining, string wheresql, string sortDay)
        {

            List<RAvailability> availabilityList = new List<RAvailability>();

            //********* Get Assigned Bookings *************
            try
            {
                //Mon Availability
                //string orderSQL = " ORDER BY MonGA DESC ";

                string SQLstr = GetAvailabilitySQL(weekbegining);
                DataSet msgDs = GetDataSet(SQLstr + wheresql);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RAvailability objAvail = new RAvailability();
                        string monType = dr["MonType"].ToString();
                        string tueType = dr["TueType"].ToString();
                        string wedType = dr["WedType"].ToString();
                        string thuType = dr["ThuType"].ToString();
                        string friType = dr["FriType"].ToString();
                        bool monProv = Utils.CheckBool(dr["MonPr"]);
                        bool tueProv = Utils.CheckBool(dr["TuePr"]);
                        bool wedProv = Utils.CheckBool(dr["WedPr"]);
                        bool thuProv = Utils.CheckBool(dr["ThuPr"]);
                        bool friProv = Utils.CheckBool(dr["FriPr"]);


                        string yearGroup = "";
                        if (dr["Nur"].ToString() == "True") yearGroup += "N";
                        if (dr["Rec"].ToString() == "True") yearGroup += "R";
                        if (dr["Yr1"].ToString() == "True") yearGroup += "1";
                        if (dr["Yr2"].ToString() == "True") yearGroup += "2";
                        if (dr["Yr3"].ToString() == "True") yearGroup += "3";
                        if (dr["Yr4"].ToString() == "True") yearGroup += "4";
                        if (dr["Yr5"].ToString() == "True") yearGroup += "5";
                        if (dr["Yr6"].ToString() == "True") yearGroup += "6";
                        if (dr["SEN"].ToString() == "True") yearGroup += "S";


                        objAvail.Teacher = dr["TeacherName"].ToString();
                        objAvail.TeacherID = dr["TeacherID"].ToString();
                        objAvail.Mobile = dr["Mobile"].ToString();

                        //CRB = dr["CRB"].ToString();
                        objAvail.CRB = dr["CRBStatus"].ToString();
                        objAvail.Live = dr["Live"].ToString();
                        objAvail.Location = dr["Location"].ToString();
                        objAvail.NoGo = dr["NoGo"].ToString();
                        objAvail.PofA = dr["ProofofAddress"].ToString();
                        objAvail.QTS = dr["QTS"].ToString();
                        objAvail.Wants = dr["Wants"].ToString();
                        objAvail.YrGroup = yearGroup;
                        objAvail.Monday = dr["Monday"].ToString();
                        objAvail.Tuesday = dr["Tuesday"].ToString();
                        objAvail.Wednesday = dr["Wednesday"].ToString();
                        objAvail.Thursday = dr["Thursday"].ToString();
                        objAvail.Friday = dr["Friday"].ToString();
                        objAvail.MonStatus = dr["MonStatus"].ToString();
                        objAvail.TueStatus = dr["TueStatus"].ToString();
                        objAvail.WedStatus = dr["WedStatus"].ToString();
                        objAvail.ThuStatus = dr["ThuStatus"].ToString();
                        objAvail.FriStatus = dr["FriStatus"].ToString();
                        string MonG = dr["MonG"].ToString();
                        string TueG = dr["TueG"].ToString();
                        string WedG = dr["WedG"].ToString();
                        string ThuG = dr["ThuG"].ToString();
                        string FriG = dr["FriG"].ToString();

                        //Set whetehr any guarantees are offered (1) or Guaranteed (2)
                        //if (MonG == "1" || TueG == "1" || WedG == "1" || ThuG == "1" || FriG == "1")
                        if (monType == "1" || tueType == "1" || wedType == "1" || thuType == "1" || friType == "1" ||
                            monType == "2" || tueType == "2" || wedType == "2" || thuType == "2" || friType == "2")
                        {
                            objAvail.Guar = "1";
                        }
                        else objAvail.Guar = "";

                        if (monType == "6" || tueType == "6" || wedType == "6" || thuType == "6" || friType == "6")
                        {
                            objAvail.Prio = "1";
                        }
                        else objAvail.Prio = "";

                        if (dr["MonLT"].ToString() == "True" || dr["TueLT"].ToString() == "True" || dr["WedLT"].ToString() == "True" || dr["ThuLT"].ToString() == "True" || dr["FriLT"].ToString() == "True")
                        {
                            objAvail.LongTerm = "1";
                        }
                        else objAvail.LongTerm = "";


                        //****** Set Guaranteed colours and status for each day if required
                        if (objAvail.Monday != "")
                        {
                            objAvail.MonColor = dr["MonColor"].ToString();
                        }
                        else if (MonG == "1")
                        {
                            objAvail.MonColor = GetColor(monType);
                            if (monType == "1") objAvail.Monday = "GP Offered";
                        }
                        //If provisional show text in italics
                        if (monProv) objAvail.MonColor += "i";
                        else objAvail.MonColor += "o";

                        //****** Set Guaranteed colours and status for each day if required
                        if (objAvail.Tuesday != "")
                        {
                            objAvail.TueColor = dr["TueColor"].ToString();
                        }
                        else if (TueG == "1")
                        {
                            objAvail.TueColor = GetColor(tueType);
                            if (tueType == "1") objAvail.Tuesday = "GP Offered";
                        }
                        if (tueProv) objAvail.TueColor += "i";
                        else objAvail.TueColor += "o";

                        //****** Set Guaranteed colours and status for each day if required
                        if (objAvail.Wednesday != "")
                        {
                            objAvail.WedColor = dr["WedColor"].ToString();
                        }
                        else if (WedG == "1")
                        {
                            objAvail.WedColor = GetColor(wedType);
                            if (wedType == "1") objAvail.Wednesday = "GP Offered";
                        }
                        if (wedProv) objAvail.WedColor += "i";
                        else objAvail.WedColor += "o";

                        //****** Set Guaranteed colours and status for each day if required
                        if (objAvail.Thursday != "")
                        {
                            objAvail.ThuColor = dr["ThuColor"].ToString();
                        }
                        else if (ThuG == "1")
                        {
                            objAvail.ThuColor = GetColor(thuType);
                            if (thuType == "1") objAvail.Thursday = "GP Offered";
                        }
                        if (thuProv) objAvail.ThuColor += "i";
                        else objAvail.ThuColor += "o";

                        //****** Set Guaranteed colours and status for each day if required
                        if (objAvail.Friday != "")
                        {
                            objAvail.FriColor = dr["FriColor"].ToString();
                        }
                        else if (FriG == "1")
                        {
                            objAvail.FriColor = GetColor(friType);
                            if (friType == "1") objAvail.Friday = "GP Offered";
                        }
                        if (friProv) objAvail.FriColor += "i";
                        else objAvail.FriColor += "o";


                        objAvail.FirstAid = Utils.CheckBool(dr["FirstAid"]);
                        objAvail.RWInc = Utils.CheckBool(dr["RWInc"]);
                        objAvail.BSL = Utils.CheckBool(dr["BSL"]);
                        objAvail.Actor = Utils.CheckBool(dr["Actor"]);
                        objAvail.SEN = Utils.CheckBool(dr["SEN"]);
                        objAvail.QNN = Utils.CheckBool(dr["QNN"]);

                        //Set Sort Information
                        //This allows the data to be sorted based on the users availability on a particular day
                        //Sort order is Guaranteed, Priority, Available, Unspecified, Unavailable
                        string dayType = "0";
                        switch (sortDay)
                        {
                            case "Mon":
                                if (objAvail.Monday == "") dayType = monType;
                                else if (dr["MonLT"].ToString() == "True") dayType = "L";
                                else dayType = "B";
                                break;
                            case "Tue":
                                if (objAvail.Tuesday == "") dayType = tueType;
                                else if (dr["TueLT"].ToString() == "True") dayType = "L";
                                else dayType = "B";
                                break;
                            case "Wed":
                                if (objAvail.Wednesday == "") dayType = wedType;
                                else if (dr["WedLT"].ToString() == "True") dayType = "L";
                                else dayType = "B";
                                break;
                            case "Thu":
                                if (objAvail.Thursday == "") dayType = thuType;
                                else if (dr["ThuLT"].ToString() == "True") dayType = "L";
                                else dayType = "B";
                                break;
                            case "Fri":
                                if (objAvail.Friday == "") dayType = friType;
                                else if (dr["FriLT"].ToString() == "True") dayType = "L";
                                else dayType = "B";
                                break;
                            default:
                                break;
                        }

                        switch (dayType)
                        {
                            case "B": //Booked
                                objAvail.Sort = 0;
                                break;
                            case "L": //LongTerm
                                objAvail.Sort = 90;
                                break;
                            case "2": //guarantee Accepted
                                objAvail.Sort = 10;
                                break;
                            case "1": //guarantee offered
                                objAvail.Sort = 20;
                                break;
                            case "6": //priority
                                objAvail.Sort = 30;
                                break;
                            case "4": //Avail
                                objAvail.Sort = 40;
                                break;
                            case "3": //Texted
                                objAvail.Sort = 60;
                                break;
                            case "5": //unAvail
                                objAvail.Sort = 80;
                                break;
                            default: //Not set
                                objAvail.Sort = 60;
                                break;
                        }

                        if (string.IsNullOrWhiteSpace(objAvail.Teacher))
                        {
                            //do nothing - don't add
                        }
                        else
                        {
                            availabilityList.Add(objAvail);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetAvailability: " + ex.Message);
            }

            //*******  Get Unassigned Bookings ***********
            try
            {
                string SQLstr = GetUnassignedAvailabilitySQL(weekbegining);
                string wheresql2 = " WHERE [MasterBookings].contactID = -1 ";
                DataSet msgDs = GetDataSet(SQLstr + wheresql2);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RAvailability objAvail = new RAvailability();

                        objAvail.Monday = dr["Monday"].ToString();
                        objAvail.Tuesday = dr["Tuesday"].ToString();
                        objAvail.Wednesday = dr["Wednesday"].ToString();
                        objAvail.Thursday = dr["Thursday"].ToString();
                        objAvail.Friday = dr["Friday"].ToString();
                        objAvail.MonColor = dr["MonColor"].ToString();
                        objAvail.TueColor = dr["TueColor"].ToString();
                        objAvail.WedColor = dr["WedColor"].ToString();
                        objAvail.ThuColor = dr["ThuColor"].ToString();
                        objAvail.FriColor = dr["FriColor"].ToString();
                        objAvail.MonStatus = dr["MonStatus"].ToString();
                        objAvail.TueStatus = dr["TueStatus"].ToString();
                        objAvail.WedStatus = dr["WedStatus"].ToString();
                        objAvail.ThuStatus = dr["ThuStatus"].ToString();
                        objAvail.FriStatus = dr["FriStatus"].ToString();

                        if (string.IsNullOrWhiteSpace(objAvail.Teacher))
                        {
                            //do nothing - don't add
                        }
                        else
                        {
                            availabilityList.Add(objAvail);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetAvailability: " + ex.Message);
            }

            return availabilityList;


        }

        private string GetColor(string type)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(type)) return null;

                switch (type)
                {
                    case "1": //guarantee offered
                        return "purp/gree";
                        break;
                    case "2": //gurantee acceopted
                        return "purp/gree";
                        break;
                    case "3": //texted
                        return "purp/pink";
                        break;
                    case "4": //available
                        return "purp/lgre";
                        break;
                    case "5": //unavailable
                        return "purp/orng";
                        break;
                    case "6":  //priority
                        return "blck/pech";
                        break;
                    default:
                        return "";
                        break;

                }
            }
            catch (Exception)
            {
                return "";
            }
        }


        public List<RTeacherday> GetTeacherDays(Int64 teacherID, bool past, bool future, bool guarantee)
        {

            List<RTeacherday> teacherDays = new List<RTeacherday>();

            //Create DateSQL
            string today = DateTime.Today.Date.ToString("yyyyMMdd");
            string DateSQL = "";
            if (!past)
            {
                DateSQL = " AND [Date] >= '" + today + "' ";
            }

            if (!future)
            {
                DateSQL = " AND [Date] <= '" + today + "' ";
            }



            //Get Guaranteed days
            if (guarantee)
            {
                try
                {
                    string SQLstr = "SELECT [ID],[Date],[Note],[Accepted],[Type] " +
                                    "FROM [GuaranteedDays] " +
                                    "Where [TeacherID] = '" + teacherID.ToString() + "' ";
                    DataSet msgDs = GetDataSet(SQLstr + DateSQL);


                    if (msgDs != null)
                    {
                        foreach (DataRow dr in msgDs.Tables[0].Rows)
                        {
                            RTeacherday tDay = new RTeacherday();
                            tDay.ID = Utils.CheckLong(dr["ID"]);
                            tDay.dte = Utils.CheckDate(dr["Date"]);
                            tDay.Details = Utils.CheckString(dr["Note"]);
                            //tDay.Status = (Utils.CheckBool(dr["Accepted"])) ? "Accepted" : "Offered";
                            tDay.Type = Utils.CheckInt(dr["Type"]);

                            switch (tDay.Type)
                            {
                                case 1:
                                    tDay.Text = "Guarantee";
                                    tDay.Status = "Guarantee Offered";
                                    break;
                                case 2:
                                    tDay.Text = "Guarantee";
                                    tDay.Status = "Guarantee Accepted";
                                    break;
                                case 3:
                                    tDay.Text = "Availability";
                                    tDay.Status = "Texted";
                                    break;
                                case 4:
                                    tDay.Text = "Availability";
                                    tDay.Status = "Available";
                                    break;
                                case 5:
                                    tDay.Text = "Availability";
                                    tDay.Status = "Unavailable";
                                    break;
                                case 6:
                                    tDay.Text = "Availability";
                                    tDay.Status = "Priority";
                                    break;
                                default:
                                    tDay.Status = "-";
                                    break;
                            }

                            teacherDays.Add(tDay);

                        }
                    }


                    else return null;
                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "Error in GetTeacherDays(Guarantees): " + ex.Message);
                    return null;
                }
            }

            else
            {
                //Get Booked days
                try
                {
                    string SQLstr = "SELECT [Bookings].ID, Description, [MasterBookings].contactID, Bookings.Date, isAbsence, BookingStatus, Code " +
                                    "FROM [Bookings] " +
                                    "LEFT JOIN [MasterBookings] ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                                    "WHERE  [MasterBookings].contactID = '" + teacherID.ToString() + "' ";
                    DataSet msgDs = GetDataSet(SQLstr + DateSQL);


                    if (msgDs != null)
                    {
                        foreach (DataRow dr in msgDs.Tables[0].Rows)
                        {
                            RTeacherday tDay = new RTeacherday();
                            tDay.ID = Utils.CheckLong(dr["ID"]);
                            tDay.dte = Utils.CheckDate(dr["Date"]);
                            if (Utils.CheckBool(dr["isAbsence"])) tDay.Status = "Absence";
                            else tDay.Status = Utils.CheckString(dr["BookingStatus"]);
                            tDay.Text = Utils.CheckString(dr["Description"]);
                            switch (Utils.CheckInt(dr["Code"]))
                            {
                                case 1:
                                    tDay.Details = "AA";
                                    tDay.Status = "Absence";
                                    break;
                                case 2:
                                    tDay.Details = "AAL";
                                    tDay.Status = "Absence";
                                    break;
                                case 3:
                                    tDay.Details = "Sick";
                                    tDay.Status = "Absence";
                                    break;
                                case 4:
                                    tDay.Details = "Other";
                                    tDay.Status = "Absence";
                                    break;
                                default:
                                    tDay.Details = "-";
                                    break;
                            }
                            teacherDays.Add(tDay);

                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "Error in GetTeacherDays(Guarantees): " + ex.Message);
                    return null;
                }
            }

            return teacherDays;
        }

        public List<RTimeSheet> GetTimeSheets(DateTime dStart, string schoolID)
        {

            List<RTimeSheet> TimeSheets = new List<RTimeSheet>();
            try
            {
                string SQLstr = GetTimeSheetSQL(dStart, schoolID);
                DataSet msgDs = GetDataSet(SQLstr);

                string SQLstr2 = GetTimeSheetOTDetailsSQL(dStart, schoolID);
                DataSet msgDs2 = GetDataSet(SQLstr2);

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            string shortname = dr["ShortName"].ToString();
                            RTimeSheet objTS = new RTimeSheet()
                           {
                               ID = Utils.CheckLong(dr["MasterBookingID"]),
                               SchoolName = dr["SchoolName"].ToString(),
                               FullName = dr["FullName"].ToString(),
                               days = GetDay(dr["Date"].ToString()),
                               Description = dr["Description"].ToString().Replace(shortname, "").Trim(),
                               numDays = 1,
                               DayRate = Utils.CheckDecimal(dr["DayRate"].ToString()),
                               Total = Utils.CheckDecimal(dr["DayRate"].ToString()),

                           };
                            //only add if charge required
                            //if (objTS.DayRate > 0) TimeSheets.Add(objTS);
                            //10/10/2014 Add all items to timesheet
                            TimeSheets.Add(objTS);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating GetTimeSheets List: " + ex.Message); }
                    }

                    //
                    //iterate through the list
                    int listPointer = 0;
                    while (listPointer < TimeSheets.Count - 1)
                    {
                        if (TimeSheetsMatch(TimeSheets[listPointer], TimeSheets[listPointer + 1]))//ASK
                        {
                            //add a day to existing payment
                            TimeSheets[listPointer].numDays += 1;
                            TimeSheets[listPointer].days += "," + TimeSheets[listPointer + 1].days;
                            TimeSheets[listPointer].Total += TimeSheets[listPointer + 1].Total;

                            TimeSheets.RemoveAt(listPointer + 1);
                        }
                        else
                        {
                            //move on to next payment
                            listPointer += 1;
                        }
                    }

                    foreach (DataRow dr in msgDs2.Tables[0].Rows)
                    {
                        try
                        {
                            string shortname = dr["ShortName"].ToString();
                            RTimeSheet objTS = new RTimeSheet()
                            {
                                ID = Utils.CheckLong(dr["MasterBookingID"]),
                                SchoolName = dr["SchoolName"].ToString(),
                                FullName = dr["FullName"].ToString(),
                                days = GetDay(dr["Date"].ToString()),
                                Description = dr["Description"].ToString().Replace(shortname, "").Trim() + " [OT]",
                                numDays = 1,
                                DayRate = Utils.CheckDecimal(dr["DayRate"].ToString()),
                                Total = Utils.CheckDecimal(dr["DayRate"].ToString()),

                            };
                            //only add if charge required
                            //if (objTS.DayRate > 0) TimeSheets.Add(objTS);
                            //10/10/2014 Add all items to timesheet
                            TimeSheets.Add(objTS);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating GetTimeSheets List: " + ex.Message); }
                    }

                    return TimeSheets;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetTimeSheets: " + ex.Message);
                return null;
            }
        }

        private string GetDay(string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                string day = dt.DayOfWeek.ToString();
                return day.Substring(0, 3);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in  GetDay: " + ex.Message);
                return "Err";
            }
        }

        private bool TimeSheetsMatch(RTimeSheet ts1, RTimeSheet ts2)
        {
            try
            {
                if (ts1.FullName != ts2.FullName) return false;
                if (ts1.SchoolName != ts2.SchoolName) return false;
                if (ts1.DayRate != ts2.DayRate) return false;
                if (ts1.Description != ts2.Description) return false;
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in TimeSheetsMatch: " + ex.Message);
                return false;
            }
        }

        public List<Payment> GetPayrun(DateTime dStart)
        {
            List<Payment> PayList = new List<Payment>();
            try
            {
                string SQLstr = GetPayRunSQL(dStart);
                DataSet msgDs = GetDataSet(SQLstr);
                string SQLstr2 = GetPayRunOverTimeSQL(dStart);
                DataSet msgOTDs = GetDataSet(SQLstr2);

                //Build list of overtime results
                List<Payment> Overtime = new List<Payment>();
                if (msgOTDs != null)
                {
                    foreach (DataRow dr in msgOTDs.Tables[0].Rows)
                    {
                        try
                        {
                            Payment objTS = new Payment()
                            {
                                ID = Utils.CheckLong(dr["contactID"]),  //contactID
                                PayDetails = dr["PayDetails"].ToString(),
                                AgencyRef = dr["Notes"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                FirstName = dr["FirstName"].ToString(),
                                TotalDays = 1,
                                Rate = Utils.CheckDecimal(dr["ARate"]),
                            };
                            Overtime.Add(objTS);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating GetTimeSheets List: " + ex.Message); }
                    }

                }

                if (msgDs != null)
                {
                    long previousID = 0;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            //We add overtime to the end of the list of payments for a particular person
                            //So we check to see if the person (ID) has changed , and then find overtime belonging to the PREVIOUS person
                            long currentID = Utils.CheckLong(dr["contactID"]); //ID of the current teacher
                            if (previousID == 0) previousID = currentID;

                            if (currentID != previousID) //ID has changed so add overtime for previous contact
                            {
                                foreach (Payment pp in Overtime)
                                {
                                    if (pp.ID == previousID) //only add if ID of payment matches ID of previous contact
                                    {
                                        pp.ID = 0;  //set ID back to zero - we will use this to identify which have been processed
                                        PayList.Add(pp);
                                    }
                                }

                                previousID = currentID;
                            }


                            Payment objTS = new Payment()
                            {
                                //ID = Utils.CheckLong(dr["ID"]),
                                PayDetails = dr["PayDetails"].ToString(),
                                AgencyRef = "", //dr["Description"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                FirstName = dr["FirstName"].ToString(),
                                TotalDays = 1,
                                Rate = Utils.CheckDecimal(dr["Rate"]),
                                //AdditionalPayment = Utils.CheckDecimal(dr["ID"]),

                            };
                            PayList.Add(objTS);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating GetTimeSheets List: " + ex.Message); }

                    }

                    //Now add any overtime not already added
                    foreach (Payment pp in Overtime)
                    {
                        if (pp.ID != 0) //not already processed
                        {
                            PayList.Add(pp);
                        }
                    }

                    return PayList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetTimeSheets: " + ex.Message);
                return null;
            }
        }

        public List<InvoiceLine> GetInvoice(string WeekEnding, string SageAccountRef)
        {
            if (string.IsNullOrWhiteSpace(SageAccountRef)) return null;
            SageAccountRef = SageAccountRef.Trim();

            List<InvoiceLine> invoiceList = new List<InvoiceLine>();
            try
            {
                string SQLstr = GetInvoiceSQL(WeekEnding, SageAccountRef);
                DataSet msgDs = GetDataSet(SQLstr);

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            InvoiceLine invLine = new InvoiceLine()
                            {
                                WeekEnding = WeekEnding,
                                SageAcctRef = SageAccountRef,
                                Address = dr["Address"].ToString().Replace(",", ""),
                                Description = dr["Description"].ToString().Replace(",", ";"),
                                LastName = dr["LastName"].ToString().Replace(",", ""),
                                FirstName = dr["FirstName"].ToString().Replace(",", ""),
                                TotalDays = 1,
                                Charge = Utils.CheckDecimal(dr["Charge"])
                            };
                            invoiceList.Add(invLine);
                        }
                        catch (Exception ex)
                        {
                            Debug.DebugMessage(2, "Error in GetInvoice(1): " + ex.Message);
                        }
                    }

                    //Add Overtime
                    string SQLstr2 = GetInvoiceOTSQL(WeekEnding, SageAccountRef);
                    DataSet msgOTDs = GetDataSet(SQLstr2);
                    if (msgOTDs != null)
                    {
                        foreach (DataRow dr in msgOTDs.Tables[0].Rows)
                        {
                            try
                            {
                                InvoiceLine invLine = new InvoiceLine()
                                {
                                    WeekEnding = WeekEnding,
                                    SageAcctRef = SageAccountRef,
                                    Address = dr["Address"].ToString().Replace(",", ""),
                                    Description = dr["Description"].ToString().Replace(",", ";") + " ( " + dr["BNotes"].ToString().Replace(",", ";") + " )",
                                    LastName = dr["LastName"].ToString().Replace(",", ""),
                                    FirstName = dr["FirstName"].ToString().Replace(",", ""),
                                    TotalDays = 1,
                                    Charge = Utils.CheckDecimal(dr["ChargeAdditional"])
                                };
                                invoiceList.Add(invLine);
                            }
                            catch (Exception ex)
                            {
                                Debug.DebugMessage(2, "Error in GetInvoice(1): " + ex.Message);
                            }
                        }
                    }

                    return invoiceList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetInvoice: " + ex.Message);
                return null;
            }
        }

        public List<RLoad> GetLoadPlan(DateTime dStart)
        {

            List<RLoad> LoadPlan = new List<RLoad>();
            try
            {
                string SQLstr = GetLoadPlanSQL(dStart);
                string SQLstr2 = GetLoadPlanOverTimeSQL(dStart);
                DataSet msgDs = GetDataSet(SQLstr);
                DataSet msgDs2 = GetDataSet(SQLstr2);

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            string shortname = dr["ShortName"].ToString();
                            RLoad objLoad = new RLoad()
                           {
                               SchoolName = dr["SchoolName"].ToString(),
                               FirstName = dr["FirstName"].ToString(),
                               LastName = dr["LastName"].ToString(),
                               numDays = Convert.ToInt32(dr["numDays"]),
                               Monday = dr["Monday"].ToString().Replace(shortname, "").Trim(),
                               Tuesday = dr["Tuesday"].ToString().Replace(shortname, "").Trim(),
                               Wednesday = dr["Wednesday"].ToString().Replace(shortname, "").Trim(),
                               Thursday = dr["Thursday"].ToString().Replace(shortname, "").Trim(),
                               Friday = dr["Friday"].ToString().Replace(shortname, "").Trim(),
                               srate = Utils.CheckDecimal(dr["srate"].ToString()),
                               TotalCost = Utils.CheckDecimal(dr["TotalCost"].ToString()),
                               //Margin = Utils.CheckDecimal(dr["Margin"].ToString()),
                               Charge = Utils.CheckDecimal(dr["sCharge"].ToString()),
                               Revenue = Utils.CheckDecimal(dr["Revenue"].ToString()),
                               TMargin = Utils.CheckDecimal(dr["TMargin"].ToString()),
                               MonID = dr["MonID"].ToString(),
                               TueID = dr["TueID"].ToString(),
                               WedID = dr["WedID"].ToString(),
                               ThuID = dr["ThuID"].ToString(),
                               FriID = dr["FriID"].ToString(),
                               OT = false

                           };
                            LoadPlan.Add(objLoad);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List(GetLoadPlan): " + ex.Message); }
                    }

                    //-------------Get OT details----------------------------
                    if (msgDs2 != null)
                    {
                        foreach (DataRow dr in msgDs2.Tables[0].Rows)
                        {
                            try
                            {
                                DateTime date = DateTime.Parse(dr["Date"].ToString());
                                string mondayText = string.Empty;
                                string tuesdayText = string.Empty;
                                string wednesdayText = string.Empty;
                                string thursdayText = string.Empty;
                                string fridayText = string.Empty;

                                if (date.DayOfWeek == DayOfWeek.Monday)
                                    mondayText = dr["Notes"].ToString();
                                if (date.DayOfWeek == DayOfWeek.Tuesday)
                                    tuesdayText = dr["Notes"].ToString();
                                if (date.DayOfWeek == DayOfWeek.Wednesday)
                                    wednesdayText = dr["Notes"].ToString();
                                if (date.DayOfWeek == DayOfWeek.Thursday)
                                    thursdayText = dr["Notes"].ToString();
                                if (date.DayOfWeek == DayOfWeek.Friday)
                                    fridayText = dr["Notes"].ToString();


                                RLoad objLoad = new RLoad()
                                {
                                    SchoolName = dr["SchoolName"].ToString(),
                                    FirstName = dr["FirstName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
                                    numDays = 1,
                                    Monday = mondayText,
                                    Tuesday = tuesdayText,
                                    Wednesday = wednesdayText,
                                    Thursday = thursdayText,
                                    Friday = fridayText,
                                    srate = Utils.CheckDecimal(dr["ARate"].ToString()),
                                    Charge = Utils.CheckDecimal(dr["ACharge"].ToString()),
                                    TotalCost = Utils.CheckDecimal(dr["ARate"].ToString()),
                                    Revenue = Utils.CheckDecimal(dr["ACharge"].ToString()),
                                    TMargin = Utils.CheckDecimal(dr["ACharge"].ToString()) - Utils.CheckDecimal(dr["ARate"].ToString()),
                                    OT = true
                                };


                                mondayText = string.Empty;
                                tuesdayText = string.Empty;
                                wednesdayText = string.Empty;
                                thursdayText = string.Empty;
                                fridayText = string.Empty;

                                LoadPlan.Add(objLoad);
                            }
                            catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List(GetLoadPlan): " + ex.Message); }
                        }
                    }

                    //LoadPlan = 

                    //var itemList = from t in LoadPlan
                    //    where !t.Items && t.DeliverySelection
                    //    orderby t.Delivery.SubmissionDate descending
                    //    select t;

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

        //public List<RLoad> GetOverTimeDetails(DateTime dStart)
        //{

        //    List<RLoad> LoadPlan = new List<RLoad>();
        //    try
        //    {
        //        string SQLstr = GetLoadPlanSQL(dStart);
        //        DataSet msgDs = GetDataSet(SQLstr);

        //        if (msgDs != null)
        //        {
        //            foreach (DataRow dr in msgDs.Tables[0].Rows)
        //            {
        //                try
        //                {
        //                    string shortname = dr["ShortName"].ToString();
        //                    RLoad objLoad = new RLoad()
        //                    {

        //                        SchoolName = dr["SchoolName"].ToString(),
        //                        FirstName = dr["FirstName"].ToString(),
        //                        LastName = dr["LastName"].ToString(),
        //                        numDays = Convert.ToInt32(dr["numDays"]),
        //                        Monday = dr["Monday"].ToString().Replace(shortname, "").Trim(),
        //                        Tuesday = dr["Tuesday"].ToString().Replace(shortname, "").Trim(),
        //                        Wednesday = dr["Wednesday"].ToString().Replace(shortname, "").Trim(),
        //                        Thursday = dr["Thursday"].ToString().Replace(shortname, "").Trim(),
        //                        Friday = dr["Friday"].ToString().Replace(shortname, "").Trim(),
        //                        srate = Utils.CheckDecimal(dr["srate"].ToString()),
        //                        TotalCost = Utils.CheckDecimal(dr["TotalCost"].ToString()),
        //                        //Margin = Utils.CheckDecimal(dr["Margin"].ToString()),
        //                        Charge = Utils.CheckDecimal(dr["sCharge"].ToString()),
        //                        Revenue = Utils.CheckDecimal(dr["Revenue"].ToString()),
        //                        TMargin = Utils.CheckDecimal(dr["TMargin"].ToString()),
        //                        MonID = dr["MonID"].ToString(),
        //                        TueID = dr["TueID"].ToString(),
        //                        WedID = dr["WedID"].ToString(),
        //                        ThuID = dr["ThuID"].ToString(),
        //                        FriID = dr["FriID"].ToString(),

        //                    };
        //                    LoadPlan.Add(objLoad);
        //                }
        //                catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List(GetLoadPlan): " + ex.Message); }

        //            }

        //            return LoadPlan;
        //        }
        //        else return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in GetLoadPlan: " + ex.Message);
        //        return null;
        //    }
        //}

        public List<RPivotLoad> GetPivotLoadPlan(DateTime dStart, DateTime dEnd)
        {

            List<RPivotLoad> LoadPlan = new List<RPivotLoad>();
            try
            {
                string SQLstr = GetPivotLoadPlanSQL(dStart, dEnd);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            RPivotLoad objLoad = new RPivotLoad()
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
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List(GetPivotLoadPlan): " + ex.Message); }

                    }

                    return LoadPlan;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetPivotLoadPlan: " + ex.Message);
                return null;
            }
        }

        public List<RBookings> GetBookings(string SchoolID, string teacherID, string dtStart, string dtEnd, string status, string filter)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetViewBookingsSQL(SchoolID, teacherID, dtStart, dtEnd, status);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RBookings objBkg = new RBookings()
                        {
                            Teacher = dr["FullName"].ToString(),
                            SchoolName = dr["SchoolName"].ToString(),
                            Description = dr["Description"].ToString(),
                            Date = Utils.CheckDate(dr["Date"].ToString()),
                            ContactID = dr["ContactID"].ToString(),
                            SchoolID = dr["SchoolID"].ToString(),
                            MasterBookingID = Utils.CheckLong(dr["MasterBookingID"]),
                            BookingStatus = dr["BookingStatus"].ToString(),
                            LT = Utils.CheckBool(dr["LT"])

                        };
                        switch (Utils.CheckInt(dr["Code"]))
                        {
                            case 1:
                                objBkg.BookingStatus = "Absence:AA";
                                break;
                            case 2:
                                objBkg.BookingStatus = "Absence:AAL";
                                break;
                            case 3:
                                objBkg.BookingStatus = "Absence:Sick";
                                break;
                            case 4:
                                objBkg.BookingStatus = "Absence:Other";
                                break;
                            default:
                                break;
                        }
                        switch (filter)
                        {
                            case "LT":
                                if (objBkg.LT) bookingList.Add(objBkg);
                                break;
                            case "NOLT":
                                if (!objBkg.LT) bookingList.Add(objBkg);
                                break;
                            default:
                                bookingList.Add(objBkg);
                                break;
                        }


                    }

                    return bookingList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }

        public List<RBookings> GetBookings(string teacherID, string ddate)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetMasterBookingsSQL(teacherID, ddate);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RBookings objBkg = new RBookings()
                        {
                            Teacher = dr["FullName"].ToString(),
                            SchoolName = dr["SchoolName"].ToString(),
                            Description = dr["Description"].ToString(),
                            Date = Utils.CheckDate(dr["Date"]),
                            ContactID = dr["ContactID"].ToString(),
                            SchoolID = dr["SchoolID"].ToString(),
                            MasterBookingID = Utils.CheckLong(dr["MasterBookingID"]),
                            BookingStatus = dr["BookingStatus"].ToString()

                        };
                        bookingList.Add(objBkg);

                    }

                    return bookingList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }

        public DataTable GetClashingBookingDetailsForUpdate(long masterBookingID, long newTeacherID)
        {
            try
            {
                string SQLstr = "SELECT Date FROM GuaranteedDays WHERE (TeacherID = " + newTeacherID + ") AND (Date IN " +
                                "(SELECT Bookings.Date FROM Bookings INNER JOIN MasterBookings ON " +
                                "Bookings.MasterBookingID = MasterBookings.ID WHERE (MasterBookings.ID = " + masterBookingID + "))) AND Type = 5  ";

                DataSet msgDs = GetDataSet(SQLstr);
                if (msgDs != null)
                {
                    DataTable table = msgDs.Tables[0];
                    if (table.Rows.Count > 0)
                        return table;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }


        public DataSet GetClashingBookingDetails()
        {
            try
            {
                string SQLstr = "SELECT dbo.MasterBookings.ID AS MasterBookingID, dbo.MasterBookings.contactID, dbo.Contacts.FirstName, dbo.Contacts.LastName, " +
"dbo.Schools.SchoolName, dbo.Bookings.Date, COUNT(dbo.Bookings.Date) AS num, SUM(CASE WHEN [MasterBookings].HalfDay = 1 THEN 0.5 ELSE 1 END) AS days " +
"FROM dbo.Bookings LEFT OUTER JOIN dbo.MasterBookings ON dbo.Bookings.MasterBookingID = dbo.MasterBookings.ID INNER JOIN" +
"(SELECT TeacherID, Date FROM dbo.GuaranteedDays WHERE (Type = 5) GROUP BY TeacherID, Date) AS a1 ON a1.TeacherID = dbo.MasterBookings.contactID AND " +
"a1.Date = dbo.Bookings.Date INNER JOIN dbo.Contacts ON dbo.MasterBookings.contactID = dbo.Contacts.contactID INNER JOIN " +
"dbo.Schools ON dbo.MasterBookings.SchoolID = dbo.Schools.ID  GROUP BY dbo.Bookings.Date, dbo.MasterBookings.contactID, dbo.MasterBookings.ID, " +
"dbo.Contacts.FirstName, dbo.Contacts.LastName, dbo.Schools.SchoolName";

                DataSet msgDs = GetDataSet(SQLstr);
                return msgDs;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }

        public DataTable GetClashingBookingDetails(DateTime dateFrom, DateTime dateTo, long teacherID)
        {
            try
            {
                //                string SQLstr = "SELECT dbo.MasterBookings.ID AS MasterBookingID, dbo.MasterBookings.contactID, dbo.Contacts.FirstName, dbo.Contacts.LastName, " +
                //"dbo.Schools.SchoolName, dbo.Bookings.Date, COUNT(dbo.Bookings.Date) AS num, SUM(CASE WHEN [MasterBookings].HalfDay = 1 THEN 0.5 ELSE 1 END) AS days " +
                //"FROM dbo.Bookings LEFT OUTER JOIN dbo.MasterBookings ON dbo.Bookings.MasterBookingID = dbo.MasterBookings.ID INNER JOIN" +
                //"(SELECT TeacherID, Date FROM dbo.GuaranteedDays WHERE (Type = 5) GROUP BY TeacherID, Date) AS a1 ON a1.TeacherID = dbo.MasterBookings.contactID AND " +
                //"a1.Date = dbo.Bookings.Date INNER JOIN dbo.Contacts ON dbo.MasterBookings.contactID = dbo.Contacts.contactID INNER JOIN " +
                //"dbo.Schools ON dbo.MasterBookings.SchoolID = dbo.Schools.ID"+
                //" WHERE [Date] >= '" + dateFrom.ToString("yyyy-MM-dd") + "' AND [Date] <= '" + dateTo.ToString("yyyy-MM-dd") + "' AND [TeacherID] = " + teacherID +
                //" GROUP BY dbo.Bookings.Date, dbo.MasterBookings.contactID, dbo.MasterBookings.ID, dbo.Contacts.FirstName, dbo.Contacts.LastName, dbo.Schools.SchoolName";

                string SQLstr = "SELECT [TeacherID],[Date] FROM [dbo].[GuaranteedDays] WHERE [Date] >= '" + dateFrom.ToString("yyyy-MM-dd")
                    + "' AND [Date] <= '" + dateTo.ToString("yyyy-MM-dd") + "' AND [TeacherID] = " + teacherID + " AND Type = 5 ";
                DataSet msgDs = GetDataSet(SQLstr);
                if (msgDs != null)
                {
                    DataTable table = msgDs.Tables[0];
                    if (table.Rows.Count > 0)
                        return table;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }

        public List<RBookings> GetBookingsForDate(string ddate, string status)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetMasterBookingsforDateSQL(ddate, status);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RBookings objBkg = new RBookings()
                        {
                            Teacher = dr["FullName"].ToString(),
                            SchoolName = dr["SchoolName"].ToString(),
                            Description = dr["Description"].ToString(),
                            Date = Utils.CheckDate(dr["Date"]),
                            ContactID = dr["ContactID"].ToString(),
                            SchoolID = dr["SchoolID"].ToString(),
                            MasterBookingID = Utils.CheckLong(dr["MasterBookingID"]),
                            BookingStatus = dr["BookingStatus"].ToString(),
                            Selected = true
                        };
                        bookingList.Add(objBkg);

                    }

                    return bookingList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return null;
            }
        }

        public int UpdateBookings(long MasterBookingID, string charge, string rate, string description)
        {
            try
            {

                string updateSQL = "";
                if (rate != null) updateSQL = " Rate = '" + rate + "' ";
                if (charge != null) updateSQL += ", Charge = '" + charge + "' ";
                if (description != null) updateSQL += ", Description = '" + description + "' ";

                //remove leading comma if necessary
                if (updateSQL.Substring(0, 1) == ",") updateSQL = updateSQL.Substring(1);
                if (updateSQL.Length < 1) return 0;

                string SQL = "UPDATE Bookings SET " + updateSQL;

                SQL += " WHERE MasterBookingID = '" + MasterBookingID + "' ";

                return ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateBookingsFromDate: " + ex.Message);
                return -1;
            }

        }

        /// <summary>
        /// Pass null values for rate, charge, description if they should not be updated
        /// ddate should be in format (yyyy-MM-dd)
        /// </summary>
        /// <param name="masterID"></param>
        /// <param name="ddate"></param>
        /// <param name="rate"></param>
        /// <param name="charge"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int UpdateBookingsFromDate(string masterID, string ddate, string rate, string charge, string description)
        {
            try
            {

                string updateSQL = "";
                if (rate != null) updateSQL = " Rate = '" + rate + "' ";
                if (charge != null) updateSQL += ", Charge = '" + charge + "' ";
                if (description != null) updateSQL += ", Description = '" + description + "' ";

                //remove leading comma if necessary
                if (updateSQL.Substring(0, 1) == ",") updateSQL = updateSQL.Substring(1);
                if (updateSQL.Length < 1) return 0;

                string SQL = "UPDATE Bookings SET " + updateSQL;

                SQL += " WHERE MasterBookingID = '" + masterID + "' ";
                SQL += " AND DATE >= '" + ddate + "' ";

                return ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateBookingsFromDate: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// ddate should be in format (yyyy-MM-dd)
        /// </summary>
        /// <param name="masterID"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public int DeleteBookingsFromDate(string masterID, string ddate)
        {
            try
            {
                string SQL = "DELETE FROM Bookings ";

                SQL += " WHERE MasterBookingID = '" + masterID + "' ";
                SQL += " AND DATE >= '" + ddate + "' ";

                return ExecuteNonQuery(SQL);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteBookingsFromDate: " + ex.Message);
                return -1;
            }
        }

        public List<RBookings> GetUnassignedBookings(string dtStart, string dtEnd)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetUnassignedBookingsSQL(dtStart, dtEnd);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RBookings objBkg = new RBookings()
                        {
                            Teacher = dr["FullName"].ToString(),
                            SchoolName = dr["SchoolName"].ToString(),
                            Description = dr["Description"].ToString(),
                            Date = Utils.CheckDate(dr["Date"]),
                            ContactID = dr["ContactID"].ToString(),
                            SchoolID = dr["SchoolID"].ToString(),
                            MasterBookingID = Utils.CheckLong(dr["MasterBookingID"]),
                            BookingStatus = dr["BookingStatus"].ToString(),
                            LT = Utils.CheckBool(dr["LT"])

                        };
                        bookingList.Add(objBkg);

                    }

                    return bookingList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetUnassignedBookings: " + ex.Message);
                return null;
            }
        }

        public List<RDoubleBookings> CheckDoubleBookings()
        {
            List<RDoubleBookings> ListDblB = new List<RDoubleBookings>();
            try
            {
                string SQLstr = GetCheckDoubleBookingsSQL();
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RDoubleBookings objBkg = new RDoubleBookings()
                        {
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Number = dr["num"].ToString(),
                            Date = Utils.CheckDate(dr["Date"].ToString()),
                            ContactID = dr["ContID"].ToString(),
                        };
                        if (!String.IsNullOrWhiteSpace(objBkg.FirstName) && !String.IsNullOrWhiteSpace(objBkg.LastName)) ListDblB.Add(objBkg);
                    }
                }
                return ListDblB;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookings: " + ex.Message);
                return ListDblB;
            }
        }

        public RMasterBooking GetMasterBookingInfo(long masterBookingID)
        {
            RMasterBooking rMB = new RMasterBooking();
            try
            {
                string SQLstr = GetMasterBookingInfoSQL(masterBookingID);
                DataSet msgDs = GetDataSet(SQLstr);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RMasterBooking objBkg = new RMasterBooking();

                        objBkg.ID = Utils.CheckLong(dr["ID"]);
                        objBkg.SchoolID = Utils.CheckLong(dr["SchoolID"]);
                        objBkg.School = Utils.CheckString(dr["School"]);
                        objBkg.ContactID = Utils.CheckLong(dr["ContactID"]);
                        objBkg.TeacherName = Utils.CheckString(dr["TeacherName"]);
                        objBkg.Details = Utils.CheckString(dr["Details"]);
                        objBkg.Notes = Utils.CheckString(dr["Notes"]);
                        objBkg.Startdate = Convert.ToDateTime(dr["StartDate"]).Date;
                        objBkg.EndDate = Convert.ToDateTime(dr["EndDate"]).Date;
                        objBkg.isAbsence = Utils.CheckBool(dr["isAbsence"]);
                        objBkg.AbsenceReason = Utils.CheckString(dr["AbsenceReason"]);
                        objBkg.HalfDay = Utils.CheckBool(dr["HalfDay"]);
                        objBkg.LongTerm = Utils.CheckBool(dr["LongTerm"]);
                        objBkg.Nur = Utils.CheckBool(dr["Nur"]);
                        objBkg.Rec = Utils.CheckBool(dr["Rec"]);
                        objBkg.Yr1 = Utils.CheckBool(dr["Yr1"]);
                        objBkg.Yr2 = Utils.CheckBool(dr["Yr2"]);
                        objBkg.Yr3 = Utils.CheckBool(dr["Yr3"]);
                        objBkg.Yr4 = Utils.CheckBool(dr["Yr4"]);
                        objBkg.Yr5 = Utils.CheckBool(dr["Yr5"]);
                        objBkg.Yr6 = Utils.CheckBool(dr["Yr6"]);
                        objBkg.QTS = Utils.CheckBool(dr["QTS"]);
                        objBkg.NQT = Utils.CheckBool(dr["NQT"]);
                        objBkg.OTT = Utils.CheckBool(dr["OTT"]);
                        objBkg.Teacher = Utils.CheckBool(dr["Teacher"]);
                        objBkg.TA = Utils.CheckBool(dr["TA"]);
                        objBkg.NN = Utils.CheckBool(dr["NN"]);
                        objBkg.QNN = Utils.CheckBool(dr["QNN"]);
                        objBkg.SEN = Utils.CheckBool(dr["SEN"]);
                        objBkg.PPL = Utils.CheckBool(dr["PPL"]);
                        objBkg.Charge = Utils.CheckDecimal(dr["Charge"]);
                        objBkg.LinkedTeacherID = Utils.CheckLong(dr["LinkedTeacherID"]);
                        objBkg.LinkedTeacherName = Utils.CheckString(dr["LinkedTeacherName"]);
                        objBkg.NameGiven = Utils.CheckBool(dr["NameGiven"]);
                        objBkg.AskedFor = Utils.CheckBool(dr["AskedFor"]);
                        objBkg.TrialDay = Utils.CheckBool(dr["TrialDay"]);
                        objBkg.Color = Utils.CheckString(dr["Color"]);
                        objBkg.BookingStatus = Utils.CheckString(dr["BookingStatus"]);
                        objBkg.Provisional = Utils.CheckBool(dr["Provisional"]);
                        objBkg.RequestedBy = Utils.CheckString(dr["RequestedBy"]);
                        return objBkg;
                    }

                    return null;
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
                DataSet ds = GetDataSet("Select * from Reminders WHERE ReminderID =" + reminderID);
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
                DataSet ds = GetDataSet("Select ReminderID from Reminders WHERE ContactRefID =" + contactRef + " AND Type = '" + reminderType + "'");
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
                firstname = firstname.Replace("'", @"''");
                lastname = lastname.Replace("'", @"\'");

                DataSet msgDs = GetDataSet("Select ContactID from Contacts "
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

        public bool DeleteSchool(long schoolID)
        {
            try
            {
                string sqlStr = "DELETE FROM Schools  "
                    + "WHERE ID = @ID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Prepare();

                CmdAddContact.Parameters["@ID"].Value = schoolID;
                int numUpdated = CmdAddContact.ExecuteNonQuery();

                DBManager.CloseDBConnection();
                if (numUpdated > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteGuarantee :- " + ex.Message);
                return false;
            }

        }

        public bool DeletePaymentType(string name)
        {
            try
            {
                name = name.PadRight(25);
                string sqlStr = "DELETE FROM PaymentTypes  "
                    + "WHERE Name = @Name";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.AddWithValue("@Name", name);

                int numUpdated = CmdAddContact.ExecuteNonQuery();

                DBManager.CloseDBConnection();
                if (numUpdated > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeletePaymentType :- " + ex.Message);
                return false;
            }

        }

        public bool AddPaymentType(string name)
        {
            try
            {
                name = name.PadRight(25);
                string sqlStr = "Insert Into PaymentTypes (Name)  VALUES(@Name) ";

                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.AddWithValue("@Name", name);
                int numUpdated = CmdAddContact.ExecuteNonQuery();

                DBManager.CloseDBConnection();
                if (numUpdated > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in AddPaymentType :- " + ex.Message);
                return false;
            }

        }

        public string GetVettingEmailAddresses(string SchoolID)
        {
            try
            {
                DataSet msgDs = GetDataSet("Select VettingEmails from Schools WHERE ID = '" + SchoolID + "'");
                foreach (DataRow dr in msgDs.Tables[0].Rows)
                {
                    string vettingEmailAddresses = dr["VettingEmails"].ToString();
                    return vettingEmailAddresses;
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetVettingEmailAddresses: " + ex.Message);
                return null;
            }
        }

        public RContact GetContact(long contactID)
        {
            try
            {
                DataSet msgDs = GetDataSet("Select * from Contacts WHERE contactID = " + contactID.ToString());
                if (msgDs != null)
                {
                    RContact objContact;
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                        return objContact = GetContactFromDataRow(dr);
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "***GetMessageTemplates : Error  : " + ex.Message);
                return null;
            }

        }

        public List<RContact> GetContacts(string WhereSQL)
        {
            try
            {
                List<RContact> contactList = new List<RContact>();
                string sql = "Select * from Contacts ";
                sql += "join ContactData on ContactData.ContactID = Contacts.contactID ";
                DataSet msgDs = GetDataSet(sql + WhereSQL);
                if (msgDs != null)
                {

                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RContact objContact = GetContactFromDataRow(dr);
                        contactList.Add(objContact);
                    }
                }
                return contactList;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "***GetMessageTemplates : Error  : " + ex.Message);
                return null;
            }

        }

        private RContact GetContactFromDataRow(DataRow dr)
        {
            RContact objContact = new RContact();

            objContact.FirstName = dr["FirstName"].ToString();
            objContact.LastName = dr["LastName"].ToString();
            objContact.Title = dr["Title"].ToString();
            objContact.MiddleName = dr["MiddleName"].ToString();
            objContact.Suffix = dr["Suffix"].ToString();
            objContact.Email1 = dr["Email1"].ToString();
            objContact.Email2 = dr["Email2"].ToString();
            objContact.Email3 = dr["Email3"].ToString();
            objContact.JobTitle = dr["JobTitle"].ToString();
            objContact.contactID = Convert.ToInt64(dr["contactID"].ToString());
            objContact.AddressStreet = dr["AddressStreet"].ToString();
            objContact.AddressCity = dr["AddressCity"].ToString();
            objContact.AddressState = dr["AddressState"].ToString();
            objContact.AddressPostcode = dr["AddressPostcode"].ToString();
            objContact.AddressCountry = dr["AddressCountry"].ToString();
            objContact.PhoneHome = dr["PhoneHome"].ToString();
            objContact.PhoneMobile = dr["PhoneMobile"].ToString();
            objContact.PhoneBusiness = dr["PhoneBusiness"].ToString();
            objContact.PhoneFax = dr["PhoneFax"].ToString();
            objContact.CategoryStr = dr["CategoryStr"].ToString();
            objContact._1stRefChecked = CheckBool(dr["1stRefChecked"].ToString());
            objContact._2ndRefChecked = CheckBool(dr["2ndRefChecked"].ToString());
            objContact._3rdRefChecked = CheckBool(dr["3rdRefChecked"].ToString());
            objContact.AccountName = dr["AccountName"].ToString();
            objContact.Cautions_AdditionalInfo_OnDBS = CheckBool(dr["AdditionalInfoOnCRB"].ToString());
            //AttendMMRV = CheckBool(dr["AttendMMRV"].ToString());
            //BankAccountNumber = dr["BankAccountNumber"].ToString();
            //BankName = dr["BankName"].ToString();
            //BankSortCode = dr["BankSortCode"].ToString();
            //BankStatementLocation = dr["BankStatementLocation"].ToString();
            objContact.BirthDate = dr["BirthDate"].ToString();
            //Consultant = dr["Consultant"].ToString();
            objContact.DBSandAddressProofMatch = CheckBool(dr["CRBandAddressProofMatch"].ToString());
            objContact.DBSDateSent = CheckDate(dr["CRBDateSent"].ToString());
            objContact.DBSExpiryDate = CheckDate(dr["CRBExpiryDate"].ToString());
            objContact.DBSFormRef = dr["CRBFormRef"].ToString();
            objContact.DBSNumber = dr["CRBNumber"].ToString();
            objContact.DBSValidFrom = CheckDate(dr["CRBValidFrom"].ToString());
            //DBSDirectPayment = CheckBool(dr["DBSDirectPayment"]);
            objContact.DBSUpdateServiceCheckedDate = CheckDate(dr["DBSUpdateSvcChkdDate"].ToString());
            objContact.DisqByAssocChkdDate = CheckDate(dr["DisqByAssocChkdDate"].ToString());
            objContact.DisqByAssoc = CheckBool(dr["DisqByAssoc"]);
            objContact.DSWC = CheckBool(dr["DSWC"]);
            objContact.DSWCChkdDate = CheckDate(dr["DSWCChkdDate"].ToString());

            objContact.CurrentPayScaleProof = CheckBool(dr["CurrentPayScaleProof"]);
            objContact.CurrentPayScale = dr["CurrentPayScale"].ToString();
            objContact.CNGHO = dr["CNGHO"].ToString();
            objContact.CVReceived = CheckBool(dr["CVReceived"].ToString());
            objContact.DateOfSupply = CheckDate(dr["DateOfSupply"].ToString());
            objContact.FirstDayTeachingUK = CheckDate(dr["FirstDayTeachingUK"].ToString());
            objContact.GTCCheckDate = CheckDate(dr["GTCCheckDate"].ToString());
            objContact.IDChecked = CheckBool(dr["IDChecked"].ToString());
            objContact.IDCheckedDate = CheckDate(dr["IDChkdDate"].ToString());
            //Instructor = CheckBool(dr["Instructor"].ToString());
            objContact.GTCNumber = dr["GTCNumber"].ToString();
            objContact.InterviewNotes = dr["InterviewNotes"].ToString();
            //KeyRef = dr["KeyRef"].ToString();
            objContact.LateRecord = dr["LateRecord"].ToString();
            objContact.List99 = CheckBool(dr["List99"].ToString());
            objContact.List99CheckedDate = CheckDate(dr["List99ChkdDate"].ToString());
            objContact.LTStartDate = CheckDate(dr["LTStartDate"].ToString());
            objContact.MedicalChecklist = CheckBool(dr["MedicalChecklist"].ToString());
            objContact.MedicalChecklistCheckedDate = CheckDate(dr["MedicalChecklistChkdDate"].ToString());
            objContact.NextOfKin = dr["NextOfKin"].ToString();
            objContact.NINumber = dr["NINumber"].ToString();
            objContact.Notes = dr["Notes"].ToString();
            objContact.NQT = CheckBool(dr["NQT"].ToString());
            objContact.OtherCRBNumber = CheckBool(dr["OtherCRBNumber"].ToString());
            objContact.OTTEndDate = CheckDate(dr["OTTEndDate"].ToString());
            objContact.OverseasPoliceCheck = CheckBool(dr["OverseasPoliceCheck"].ToString());
            objContact.OverseasPoliceCheckedDate = CheckDate(dr["OverseasPoliceChkdDate"].ToString());
            objContact.OverseasTrainedTeacher = CheckBool(dr["OverseasTrainedTeacher"].ToString());
            //PassportNo = dr["PassportNo"].ToString();
            //PassportLocation = dr["PassportLocation"].ToString();
            objContact.PayDetails = dr["PayDetails"].ToString();
            //PAYETeacherContractSigned = CheckBool(dr["PAYETeacherContractSigned"].ToString());
            objContact.PhotoLocation = dr["PhotoLocation"].ToString();
            objContact.GraduationDate = CheckDate(dr["GraduationDate"].ToString());
            //ProtabilityCheckSent = CheckDate(dr["ProtabilityCheckSent"].ToString());
            objContact.ProtabilityReceivedDate = CheckDate(dr["ProtabilityReceivedDate"].ToString());
            objContact.ProofOfAddress = CheckBool(dr["ProofOfAddress"].ToString());
            objContact.ProofOfAddressCheckedDate = CheckDate(dr["POAChkdDate"].ToString());
            objContact.ProhibitionFromTeaching = CheckBool(dr["ProFrmTch"].ToString());
            objContact.ProhibitionFromTeachingCheckedDate = CheckDate(dr["ProFrmTchChkdDate"].ToString());
            //ProofOfID = dr["ProofOfID"].ToString();
            //ProofOfID2 = dr["ProofOfID2"].ToString();
            objContact.QTS = CheckBool(dr["QTS"].ToString());
            objContact.Qualification = dr["Qualification"].ToString();
            objContact.QualificationCheckedDate = CheckDate(dr["QualificationCheckedDate"].ToString());
            objContact.RedboxLeaveDate = CheckDate(dr["RedboxLeaveDate"].ToString());
            objContact.RedboxStartDate = CheckDate(dr["RedboxStartDate"].ToString());
            objContact.RedboxDBS = CheckBool(dr["RedboxCRB"].ToString());
            //ReferredBy = dr["ReferredBy"].ToString();
            objContact.Referee1Address = dr["Referee1Address"].ToString();
            objContact.Referee1Email = dr["Referee1Email"].ToString();
            objContact.Referee1Fax = dr["Referee1Fax"].ToString();
            objContact.Referee1Mobile = dr["Referee1Mobile"].ToString();
            objContact.Referee1Name = dr["Referee1Name"].ToString();
            objContact.Referee1Notes = dr["Referee1Notes"].ToString();
            objContact.Referee1Phone = dr["Referee1Phone"].ToString();
            objContact.Referee2Address = dr["Referee2Address"].ToString();
            objContact.Referee2Email = dr["Referee2Email"].ToString();
            objContact.Referee2Fax = dr["Referee2Fax"].ToString();
            objContact.Referee2Mobile = dr["Referee2Mobile"].ToString();
            objContact.Referee2Name = dr["Referee2Name"].ToString();
            objContact.Referee2Notes = dr["Referee2Notes"].ToString();
            objContact.Referee2Phone = dr["Referee2Phone"].ToString();
            objContact.Referee3Address = dr["Referee3Address"].ToString();
            objContact.Referee3Email = dr["Referee3Email"].ToString();
            objContact.Referee3Fax = dr["Referee3Fax"].ToString();
            objContact.Referee3Mobile = dr["Referee3Mobile"].ToString();
            objContact.Referee3Name = dr["Referee3Name"].ToString();
            objContact.Referee3Notes = dr["Referee3Notes"].ToString();
            objContact.Referee3Phone = dr["Referee3Phone"].ToString();
            objContact.ReferencesChecked = CheckBool(dr["ReferencesChecked"].ToString());
            objContact.ReferencesCheckedDate = CheckDate(dr["ReferencesChkdDate"].ToString());
            //RegistrationComplete = CheckBool(dr["RegistrationComplete"].ToString());
            objContact.RegistrationDate = CheckDate(dr["RegistrationDate"].ToString());
            //SendBankStatement = CheckBool(dr["SendBankStatement"].ToString());
            //SendPassport = CheckBool(dr["SendPassport"].ToString());
            //SendVisa = CheckBool(dr["SendVisa"].ToString());
            objContact.SicknessRecord = dr["SicknessRecord"].ToString();
            objContact.Summary = dr["Summary"].ToString();
            //TeacherStatus = dr["TeacherStatus"].ToString();
            objContact.UKArrivalDate = CheckDate(dr["UKArrivalDate"].ToString());
            objContact.UpdateService = CheckBool(dr["UpdateService"].ToString());
            //UpdateServiceRegisteredDate = CheckDate(dr["UpdateServiceRegisteredDate"].ToString());
            objContact.VisaExpiryDate = CheckDate(dr["VisaExpiryDate"].ToString());
            objContact.VisaType = dr["VisaType"].ToString();
            objContact.VisaCheckedDate = CheckDate(dr["VisaChkdDate"].ToString());
            //VisaLocation = dr["VisaLocation"].ToString();
            objContact.YearGroup = dr["YearGroup"].ToString();


            objContact.FullName = objContact.LastName + ", " + objContact.FirstName;
            if (objContact.Suffix != "") objContact.FullName += " " + objContact.Suffix;

            return objContact;
        }

        public bool AddReminder(RReminder reminderObj)
        {
            try
            {
                string sqlStr = "INSERT INTO Reminders ("
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
                string sqlStr = "UPDATE Reminders SET "
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

        public int UpdateGuarantee(long[] guaranteeIDs, int status)
        {
            int numUpdated = 0;
            try
            {

                string sqlStr = "UPDATE GuaranteedDays  ";

                switch (status)
                {
                    case 1:
                        sqlStr += "SET Type = 1 ";
                        break;
                    case 2:
                        sqlStr += "SET Type = 2 ";
                        break;
                    case 3:
                        sqlStr += "SET Type = 3 ";
                        break;
                    case 4:
                        sqlStr += "SET Type = 4 ";
                        break;
                    case 5:
                        sqlStr += "SET Type = 5 ";
                        break;
                    case 6:
                        sqlStr += "SET Type = 6 ";
                        break;

                    default:
                        break;
                }
                sqlStr += "WHERE ID = @ID";


                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Prepare();

                foreach (long id in guaranteeIDs)
                {

                    CmdAddContact.Parameters["@ID"].Value = id;
                    numUpdated += CmdAddContact.ExecuteNonQuery();
                }
                return numUpdated;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateGuarantee :- " + ex.Message);
                return numUpdated;
            }

        }

        public int DeleteGuarantee(long[] guaranteeIDs)
        {
            int numUpdated = 0;
            try
            {
                string sqlStr = "DELETE FROM GuaranteedDays  "
                    + "WHERE ID = @ID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Prepare();

                foreach (long id in guaranteeIDs)
                {

                    CmdAddContact.Parameters["@ID"].Value = id;
                    numUpdated += CmdAddContact.ExecuteNonQuery();
                }
                return numUpdated;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteGuarantee :- " + ex.Message);
                return numUpdated;
            }

        }

        public int DeleteBookings(long[] bookingIDs)
        {
            int numUpdated = 0;
            try
            {
                DeleteBookingsOTInformation(bookingIDs);

                string sqlStr = "DELETE FROM Bookings  "
                    + "WHERE ID = @ID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Prepare();

                foreach (long id in bookingIDs)
                {
                    CmdAddContact.Parameters["@ID"].Value = id;
                    numUpdated += CmdAddContact.ExecuteNonQuery();
                }
                return numUpdated;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteBookings :- " + ex.Message);
                return numUpdated;
            }
        }

        public void DeleteBookingsOTInformation(long[] bookingIDs)
        {
            try
            {
                string sqlStr = "DELETE FROM BookingOverTime  "
                    + "WHERE BookingID = @BookingID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@BookingID", SqlDbType.BigInt);
                CmdAddContact.Prepare();

                foreach (long id in bookingIDs)
                {
                    CmdAddContact.Parameters["@BookingID"].Value = id;
                    CmdAddContact.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteBookingsOTInformation :- " + ex.Message);
            }
        }

        public int UpdateBooking(long id, string description, string rate, string charge)
        {
            int numUpdated = 0;
            try
            {
                Decimal _rate = Convert.ToDecimal(rate);
                Decimal _charge = Convert.ToDecimal(charge);

                string sqlStr = "UPDATE Bookings  "
                    + "SET Description = @descr, "
                    + "Rate = @rate, "
                    + "Charge = @charge "
                    + "WHERE ID = @ID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                SqlParameter pa = new SqlParameter("@rate", SqlDbType.Decimal);
                pa.Precision = 7;
                pa.Scale = 2;
                CmdAddContact.Parameters.Add(pa);
                SqlParameter pb = new SqlParameter("@charge", SqlDbType.Decimal);
                pb.Precision = 7;
                pb.Scale = 2;
                CmdAddContact.Parameters.Add(pb);
                CmdAddContact.Parameters.Add("@descr", SqlDbType.VarChar, 50);
                CmdAddContact.Prepare();

                CmdAddContact.Parameters["@ID"].Value = id;
                CmdAddContact.Parameters["@descr"].Value = description;
                CmdAddContact.Parameters["@rate"].Value = _rate;
                CmdAddContact.Parameters["@charge"].Value = _charge;
                numUpdated = CmdAddContact.ExecuteNonQuery();
                return numUpdated;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateGuarantee :- " + ex.Message);
                return numUpdated;
            }
            finally
            {
                DBManager.CloseDBConnection();
            }
        }

        public int UpdateBookings(long[] bookingIDs, string status, string description)
        {
            int numUpdated = 0;
            int code = 0;

            switch (status)
            {
                case "AA":
                    code = 1;
                    break;
                case "AAL":
                    code = 2;
                    break;
                case "Sick":
                    code = 3;
                    break;
                case "Other":
                    code = 4;
                    break;
                default:
                    return -1;
                    break;
            }

            if (description.Length > 50) description = description.Substring(0, 50);

            try
            {
                string sqlStr = "UPDATE Bookings  "
                    + "SET Code = @code, "
                    + "Description = @descr, "
                    + "Rate = 0, "
                    + "Charge = 0 "
                    + "WHERE ID = @ID";
                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);
                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Parameters.Add("@code", SqlDbType.Int);
                CmdAddContact.Parameters.Add("@descr", SqlDbType.VarChar, 50);
                CmdAddContact.Prepare();

                foreach (long id in bookingIDs)
                {
                    CmdAddContact.Parameters["@ID"].Value = id;
                    CmdAddContact.Parameters["@code"].Value = code;
                    CmdAddContact.Parameters["@descr"].Value = description;
                    numUpdated += CmdAddContact.ExecuteNonQuery();
                }
                return numUpdated;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateGuarantee :- " + ex.Message);
                return numUpdated;
            }

        }

        public List<long> CheckDupes(string firstName, string lastName)
        {
            try
            {
                var listToReturn = new List<long>();
                DataSet ds = GetDataSet("SELECT contactID FROM Contacts WHERE FirstName = '" + firstName + "' AND LastName = '" + lastName + "'");
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
                string sqlStr = "INSERT INTO Contacts ("
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
                    //+ "AttendMMRV,"
                    //+ "BankAccountNumber,"
                    //+ "BankName,"
                    //+ "BankSortCode,"
                    //+ "BankStatementLocation,"
                    + "BirthDate,"
                    //                    + "Consultant,"
                    + "CRBandAddressProofMatch,"
                    + "CRBDateSent,"
                    + "CRBExpiryDate,"
                    + "CRBFormRef,"
                    + "CRBNumber,"
                    + "CRBValidFrom,"
                    + "CurrentPayScale,"
                    + "CurrentPayScaleProof,"
                    + "CNGHO,"
                    //+ "DBSDirectPayment,"
                    + "DBSUpdateSvcChkdDate, "
                    + "DisqByAssoc, "
                    + "DisqByAssocChkdDate, "
                    + "DSWC, "
                    + "DSWCChkdDate, "
                    + "CVReceived,"
                    + "DateOfSupply,"
                    + "FirstDayTeachingUK,"
                    + "GTCCheckDate,"
                    + "GTCNumber,"
                    + "IDChecked,"
                    + "IDChkdDate, "
                    //                    + "Instructor,"
                    + "InterviewNotes,"
                    //                    + "KeyRef,"
                    + "LateRecord,"
                    + "List99,"
                    + "List99ChkdDate, "
                    + "LTStartDate,"
                    + "MedicalChecklist,"
                    + "MedicalChecklistChkdDate, "
                    + "NextOfKin, "
                    + "NINumber,"
                    + "Notes,"
                    + "NQT,"
                    + "OtherCRBNumber,"
                    + "OTTEndDate,"
                    + "OverseasPoliceCheck,"
                    + "OverseasPoliceChkdDate, "
                    + "OverseasTrainedTeacher,"
                    //+ "PassportNo,"
                    //+ "PassportLocation,"
                    + "PayDetails,"
                    //+ "PAYETeacherContractSigned,"
                    + "PhotoLocation,"
                    + "GraduationDate,"
                    //+ "ProtabilityCheckSent,"
                    + "ProtabilityReceivedDate,"
                    + "ProFrmTch, "
                    + "ProFrmTchChkdDate, "
                    + "ProofOfAddress,"
                    + "POAChkdDate, "
                    //+ "ProofOfID,"
                    //+ "ProofOfID2,"
                    + "QTS,"
                    + "Qualification,"
                    + "QualificationCheckedDate, "
                    + "RedboxLeaveDate,"
                    + "RedboxStartDate,"
                    + "RedboxCRB,"
                    //+ "ReferredBy, "
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
                    + "ReferencesChkdDate, "
                    //+ "RegistrationComplete,"
                    + "RegistrationDate,"
                    //+ "SendBankStatement,"
                    //+ "SendPassport,"
                    //+ "SendVisa,"
                    + "SicknessRecord,"
                    + "Summary,"
                    //+ "TeacherStatus,"
                    + "UKArrivalDate,"
                    + "UpdateService,"
                    //+ "UpdateServiceRegisteredDate,"
                    + "VisaExpiryDate,"
                    + "VisaType,"
                    + "VisaChkdDate, "
                    //+ "VisaLocation,"
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
                    //+ "@AttendMMRV,"
                    //+ "@BankAccountNumber,"
                    //+ "@BankName,"
                    //+ "@BankSortCode,"
                    //+ "@BankStatementLocation,"
                    + "@BirthDate,"
                    //                    + "@Consultant,"
                    + "@CRBandAddressProofMatch,"
                    + "@CRBDateSent,"
                    + "@CRBExpiryDate,"
                    + "@CRBFormRef,"
                    + "@CRBNumber,"
                    + "@CRBValidFrom,"
                    + "@CurrentPayScale,"
                    + "@CurrentPayScaleProof,"
                    + "@CNGHO,"
                    //+ "@DBSDirectPayment,"
                    + "@DBSUpdateSvcChkdDate, "
                    + "@DisqByAssoc, "
                    + "@DisqByAssocChkdDate, "
                    + "@DSWC, "
                    + "@DSWCChkdDate, "

                    + "@CVReceived,"
                    + "@DateOfSupply,"
                    + "@FirstDayTeachingUK,"
                    + "@GTCCheckDate,"
                    + "@GTCNumber,"
                    + "@IDChecked,"
                    + "@IDChkdDate, "
                    //                    + "@Instructor,"
                    + "@InterviewNotes,"
                    //                    + "@KeyRef,"
                    + "@LateRecord,"
                    + "@List99,"
                    + "@List99ChkdDate, "
                    + "@LTStartDate,"
                    + "@MedicalChecklist,"
                    + "@MedicalChecklistChkdDate, "
                    + "@NextOfKin, "

                    + "@NINumber,"
                    + "@Notes,"
                    + "@NQT,"
                    + "@OtherCRBNumber,"
                    + "@OTTEndDate,"
                    + "@OverseasPoliceCheck,"
                    + "@OverseasPoliceChkdDate, "
                    + "@OverseasTrainedTeacher,"
                    //+ "@PassportNo,"
                    //+ "@PassportLocation,"
                    + "@PayDetails,"
                    //+ "@PAYETeacherContractSigned,"
                    + "@PhotoLocation,"
                    + "@GraduationDate,"
                    //+ "@ProtabilityCheckSent,"
                    + "@ProtabilityReceivedDate,"
                    + "@ProFrmTch, "
                    + "@ProFrmTchChkdDate, "
                    + "@ProofOfAddress,"
                    + "@POAChkdDate, "
                    //+ "@ProofOfID,"
                    //+ "@ProofOfID2,"
                    + "@QTS,"
                    + "@Qualification,"
                    + "@QualificationCheckedDate, "
                    + "@RedboxLeaveDate,"
                    + "@RedboxStartDate,"
                    + "@RedboxCRB,"
                    //+ "@ReferredBy, "
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
                    + "@ReferencesChkdDate, "
                    //+ "@RegistrationComplete,"
                    + "@RegistrationDate,"
                    //+ "@SendBankStatement,"
                    //+ "@SendPassport,"
                    //+ "@SendVisa,"
                    + "@SicknessRecord,"
                    + "@Summary,"
                    //+ "@TeacherStatus,"
                    + "@UKArrivalDate,"
                    + "@UpdateService,"
                    //+ "@UpdateServiceRegisteredDate,"
                    + "@VisaExpiryDate,"
                    + "@VisaType,"
                    + "@VisaChkdDate, "
                    //+ "@VisaLocation,"
                    + "@YearGroup,"
                    + "@LastMod,"
                    + "@GUID)";

                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);

                CmdAddContact.Parameters.AddWithValue("@FirstName", CheckVals(contactObj.FirstName));
                CmdAddContact.Parameters.AddWithValue("@LastName", CheckVals(contactObj.LastName));
                CmdAddContact.Parameters.AddWithValue("@Title", CheckVals(contactObj.Title));
                CmdAddContact.Parameters.AddWithValue("@MiddleName", CheckVals(contactObj.MiddleName));
                CmdAddContact.Parameters.AddWithValue("@Suffix", CheckVals(contactObj.Suffix));
                CmdAddContact.Parameters.AddWithValue("@Email1", CheckVals(contactObj.Email1));
                CmdAddContact.Parameters.AddWithValue("@Email2", CheckVals(contactObj.Email2));
                CmdAddContact.Parameters.AddWithValue("@Email3", CheckVals(contactObj.Email3));
                CmdAddContact.Parameters.AddWithValue("@JobTitle", CheckVals(contactObj.JobTitle));
                CmdAddContact.Parameters.AddWithValue("@AddressStreet", CheckVals(contactObj.AddressStreet));
                CmdAddContact.Parameters.AddWithValue("@AddressCity", CheckVals(contactObj.AddressCity));
                CmdAddContact.Parameters.AddWithValue("@AddressState", CheckVals(contactObj.AddressState));
                CmdAddContact.Parameters.AddWithValue("@AddressPostcode", CheckVals(contactObj.AddressPostcode));
                CmdAddContact.Parameters.AddWithValue("@AddressCountry", CheckVals(contactObj.AddressCountry));
                CmdAddContact.Parameters.AddWithValue("@PhoneHome", CheckVals(contactObj.PhoneHome));
                CmdAddContact.Parameters.AddWithValue("@PhoneMobile", CheckVals(contactObj.PhoneMobile));
                CmdAddContact.Parameters.AddWithValue("@PhoneBusiness", CheckVals(contactObj.PhoneBusiness));
                CmdAddContact.Parameters.AddWithValue("@PhoneFax", CheckVals(contactObj.PhoneFax));
                CmdAddContact.Parameters.AddWithValue("@CategoryStr", CheckVals(contactObj.CategoryStr));
                CmdAddContact.Parameters.AddWithValue("@1stRefChecked", CheckVals(contactObj._1stRefChecked));
                CmdAddContact.Parameters.AddWithValue("@2ndRefChecked", CheckVals(contactObj._2ndRefChecked));
                CmdAddContact.Parameters.AddWithValue("@3rdRefChecked", CheckVals(contactObj._3rdRefChecked));
                CmdAddContact.Parameters.AddWithValue("@AccountName", CheckVals(contactObj.AccountName));
                CmdAddContact.Parameters.AddWithValue("@AdditionalInfoOnCRB", CheckVals(contactObj.Cautions_AdditionalInfo_OnDBS));
                //CmdAddContact.Parameters.AddWithValue("@AttendMMRV",  CheckVals(contactObj.AttendMMRV));
                //CmdAddContact.Parameters.AddWithValue("@BankAccountNumber",  CheckVals(contactObj.BankAccountNumber));
                //CmdAddContact.Parameters.AddWithValue("@BankName",  CheckVals(contactObj.BankName));
                //CmdAddContact.Parameters.AddWithValue("@BankSortCode",  CheckVals(contactObj.BankSortCode));
                //CmdAddContact.Parameters.AddWithValue("@BankStatementLocation",  CheckVals(contactObj.BankStatementLocation));
                CmdAddContact.Parameters.AddWithValue("@BirthDate", CheckVals(contactObj.BirthDate));
                //CmdAddContact.Parameters.AddWithValue("@Consultant",  CheckVals(contactObj.Consultant));
                CmdAddContact.Parameters.AddWithValue("@CRBandAddressProofMatch", CheckVals(contactObj.DBSandAddressProofMatch));
                CmdAddContact.Parameters.AddWithValue("@CRBDateSent", FilterSQLDate(contactObj.DBSDateSent));
                CmdAddContact.Parameters.AddWithValue("@CRBExpiryDate", FilterSQLDate(contactObj.DBSExpiryDate));
                CmdAddContact.Parameters.AddWithValue("@CRBFormRef", CheckVals(contactObj.DBSFormRef));
                CmdAddContact.Parameters.AddWithValue("@CRBNumber", CheckVals(contactObj.DBSNumber));
                CmdAddContact.Parameters.AddWithValue("@CRBValidFrom", FilterSQLDate(contactObj.DBSValidFrom));
                //CmdAddContact.Parameters.AddWithValue("@DBSDirectPayment",  CheckVals(contactObj.DBSDirectPayment));
                CmdAddContact.Parameters.AddWithValue("@DBSUpdateSvcChkdDate", FilterSQLDate(contactObj.DBSUpdateServiceCheckedDate));
                CmdAddContact.Parameters.AddWithValue("@DisqByAssoc", CheckVals(contactObj.DisqByAssoc));
                CmdAddContact.Parameters.AddWithValue("@DisqByAssocChkdDate", FilterSQLDate(contactObj.DisqByAssocChkdDate));
                CmdAddContact.Parameters.AddWithValue("@DSWC", CheckVals(contactObj.DSWC));
                CmdAddContact.Parameters.AddWithValue("@DSWCChkdDate", FilterSQLDate(contactObj.DSWCChkdDate));
                CmdAddContact.Parameters.AddWithValue("@CurrentPayScale", CheckVals(contactObj.CurrentPayScale));
                CmdAddContact.Parameters.AddWithValue("@CurrentPayScaleProof", CheckVals(contactObj.CurrentPayScaleProof));
                CmdAddContact.Parameters.AddWithValue("@CNGHO", CheckVals(contactObj.CNGHO));
                CmdAddContact.Parameters.AddWithValue("@CVReceived", CheckVals(contactObj.CVReceived));
                CmdAddContact.Parameters.AddWithValue("@DateOfSupply", FilterSQLDate(contactObj.DateOfSupply));
                CmdAddContact.Parameters.AddWithValue("@FirstDayTeachingUK", FilterSQLDate(contactObj.FirstDayTeachingUK));
                CmdAddContact.Parameters.AddWithValue("@GTCCheckDate", FilterSQLDate(contactObj.GTCCheckDate));
                CmdAddContact.Parameters.AddWithValue("@GTCNumber", CheckVals(contactObj.GTCNumber));
                CmdAddContact.Parameters.AddWithValue("@IDChecked", CheckVals(contactObj.IDChecked));
                CmdAddContact.Parameters.AddWithValue("@IDChkdDate", FilterSQLDate(contactObj.IDCheckedDate));
                //CmdAddContact.Parameters.AddWithValue("@Instructor",  CheckVals(contactObj.Instructor));
                CmdAddContact.Parameters.AddWithValue("@InterviewNotes", CheckVals(contactObj.InterviewNotes));
                //CmdAddContact.Parameters.AddWithValue("@KeyRef",  CheckVals(contactObj.KeyRef));
                CmdAddContact.Parameters.AddWithValue("@LateRecord", CheckVals(contactObj.LateRecord));
                CmdAddContact.Parameters.AddWithValue("@List99", CheckVals(contactObj.List99));
                CmdAddContact.Parameters.AddWithValue("@List99ChkdDate", FilterSQLDate(contactObj.List99CheckedDate));
                CmdAddContact.Parameters.AddWithValue("@LTStartDate", FilterSQLDate(contactObj.LTStartDate));
                CmdAddContact.Parameters.AddWithValue("@MedicalChecklist", CheckVals(contactObj.MedicalChecklist));
                CmdAddContact.Parameters.AddWithValue("@MedicalChecklistChkdDate", FilterSQLDate(contactObj.MedicalChecklistCheckedDate));
                CmdAddContact.Parameters.AddWithValue("@NextOfKin", CheckVals(contactObj.NextOfKin));

                CmdAddContact.Parameters.AddWithValue("@NINumber", CheckVals(contactObj.NINumber));
                CmdAddContact.Parameters.AddWithValue("@Notes", CheckVals(contactObj.Notes));
                CmdAddContact.Parameters.AddWithValue("@NQT", CheckVals(contactObj.NQT));
                CmdAddContact.Parameters.AddWithValue("@OtherCRBNumber", CheckVals(contactObj.OtherCRBNumber));
                CmdAddContact.Parameters.AddWithValue("@OTTEndDate", FilterSQLDate(contactObj.OTTEndDate));
                CmdAddContact.Parameters.AddWithValue("@OverseasPoliceCheck", CheckVals(contactObj.OverseasPoliceCheck));
                CmdAddContact.Parameters.AddWithValue("@OverseasPoliceChkdDate", FilterSQLDate(contactObj.OverseasPoliceCheckedDate));
                CmdAddContact.Parameters.AddWithValue("@OverseasTrainedTeacher", CheckVals(contactObj.OverseasTrainedTeacher));
                //CmdAddContact.Parameters.AddWithValue("@PassportNo",  CheckVals(contactObj.PassportNo));
                //CmdAddContact.Parameters.AddWithValue("@PassportLocation",  CheckVals(contactObj.PassportLocation));
                CmdAddContact.Parameters.AddWithValue("@PayDetails", CheckVals(contactObj.PayDetails));
                //CmdAddContact.Parameters.AddWithValue("@PAYETeacherContractSigned",  CheckVals(contactObj.PAYETeacherContractSigned));
                CmdAddContact.Parameters.AddWithValue("@PhotoLocation", CheckVals(contactObj.PhotoLocation));
                CmdAddContact.Parameters.AddWithValue("@GraduationDate", FilterSQLDate(contactObj.GraduationDate));
                CmdAddContact.Parameters.AddWithValue("@ProFrmTchChkdDate", FilterSQLDate(contactObj.ProhibitionFromTeachingCheckedDate));
                CmdAddContact.Parameters.AddWithValue("@ProFrmTch", CheckVals(contactObj.ProhibitionFromTeaching));
                //CmdAddContact.Parameters.AddWithValue("@ProtabilityCheckSent",  FilterSQLDate(contactObj.ProtabilityCheckSent));
                CmdAddContact.Parameters.AddWithValue("@ProtabilityReceivedDate", FilterSQLDate(contactObj.ProtabilityReceivedDate));
                CmdAddContact.Parameters.AddWithValue("@ProofOfAddress", CheckVals(contactObj.ProofOfAddress));
                CmdAddContact.Parameters.AddWithValue("@POAChkdDate", FilterSQLDate(contactObj.ProofOfAddressCheckedDate));
                //CmdAddContact.Parameters.AddWithValue("@ProofOfID",  CheckVals(contactObj.ProofOfID));
                //CmdAddContact.Parameters.AddWithValue("@ProofOfID2",  CheckVals(contactObj.ProofOfID2));
                CmdAddContact.Parameters.AddWithValue("@QTS", CheckVals(contactObj.QTS));
                CmdAddContact.Parameters.AddWithValue("@Qualification", CheckVals(contactObj.Qualification));
                CmdAddContact.Parameters.AddWithValue("@QualificationCheckedDate", FilterSQLDate(contactObj.QualificationCheckedDate));
                CmdAddContact.Parameters.AddWithValue("@RedboxLeaveDate", FilterSQLDate(contactObj.RedboxLeaveDate));
                CmdAddContact.Parameters.AddWithValue("@RedboxStartDate", FilterSQLDate(contactObj.RedboxStartDate));
                CmdAddContact.Parameters.AddWithValue("@RedboxCRB", CheckVals(contactObj.RedboxDBS));
                //CmdAddContact.Parameters.AddWithValue("@ReferredBy",  CheckVals(contactObj.ReferredBy));
                CmdAddContact.Parameters.AddWithValue("@Referee1Address", CheckVals(contactObj.Referee1Address));
                CmdAddContact.Parameters.AddWithValue("@Referee1Email", CheckVals(contactObj.Referee1Email));
                CmdAddContact.Parameters.AddWithValue("@Referee1Fax", CheckVals(contactObj.Referee1Fax));
                CmdAddContact.Parameters.AddWithValue("@Referee1Mobile", CheckVals(contactObj.Referee1Mobile));
                CmdAddContact.Parameters.AddWithValue("@Referee1Name", CheckVals(contactObj.Referee1Name));
                CmdAddContact.Parameters.AddWithValue("@Referee1Notes", CheckVals(contactObj.Referee1Notes));
                CmdAddContact.Parameters.AddWithValue("@Referee1Phone", CheckVals(contactObj.Referee1Phone));
                CmdAddContact.Parameters.AddWithValue("@Referee2Address", CheckVals(contactObj.Referee2Address));
                CmdAddContact.Parameters.AddWithValue("@Referee2Email", CheckVals(contactObj.Referee2Email));
                CmdAddContact.Parameters.AddWithValue("@Referee2Fax", CheckVals(contactObj.Referee2Fax));
                CmdAddContact.Parameters.AddWithValue("@Referee2Mobile", CheckVals(contactObj.Referee2Mobile));
                CmdAddContact.Parameters.AddWithValue("@Referee2Name", CheckVals(contactObj.Referee2Name));
                CmdAddContact.Parameters.AddWithValue("@Referee2Notes", CheckVals(contactObj.Referee2Notes));
                CmdAddContact.Parameters.AddWithValue("@Referee2Phone", CheckVals(contactObj.Referee2Phone));
                CmdAddContact.Parameters.AddWithValue("@Referee3Address", CheckVals(contactObj.Referee3Address));
                CmdAddContact.Parameters.AddWithValue("@Referee3Email", CheckVals(contactObj.Referee3Email));
                CmdAddContact.Parameters.AddWithValue("@Referee3Fax", CheckVals(contactObj.Referee3Fax));
                CmdAddContact.Parameters.AddWithValue("@Referee3Mobile", CheckVals(contactObj.Referee3Mobile));
                CmdAddContact.Parameters.AddWithValue("@Referee3Name", CheckVals(contactObj.Referee3Name));
                CmdAddContact.Parameters.AddWithValue("@Referee3Notes", CheckVals(contactObj.Referee3Notes));
                CmdAddContact.Parameters.AddWithValue("@Referee3Phone", CheckVals(contactObj.Referee3Phone));
                CmdAddContact.Parameters.AddWithValue("@ReferencesChecked", CheckVals(contactObj.ReferencesChecked));
                CmdAddContact.Parameters.AddWithValue("@ReferencesChkdDate", FilterSQLDate(contactObj.ReferencesCheckedDate));
                //CmdAddContact.Parameters.AddWithValue("@RegistrationComplete",  CheckVals(contactObj.RegistrationComplete));
                CmdAddContact.Parameters.AddWithValue("@RegistrationDate", FilterSQLDate(contactObj.RegistrationDate));
                //CmdAddContact.Parameters.AddWithValue("@SendBankStatement",  CheckVals(contactObj.SendBankStatement));
                //CmdAddContact.Parameters.AddWithValue("@SendPassport",  CheckVals(contactObj.SendPassport));
                //CmdAddContact.Parameters.AddWithValue("@SendVisa",  CheckVals(contactObj.SendVisa));
                CmdAddContact.Parameters.AddWithValue("@SicknessRecord", CheckVals(contactObj.SicknessRecord));
                CmdAddContact.Parameters.AddWithValue("@Summary", CheckVals(contactObj.Summary));
                //CmdAddContact.Parameters.AddWithValue("@TeacherStatus", CheckVals(contactObj.TeacherStatus));
                CmdAddContact.Parameters.AddWithValue("@UKArrivalDate", FilterSQLDate(contactObj.UKArrivalDate));
                CmdAddContact.Parameters.AddWithValue("@UpdateService", CheckVals(contactObj.UpdateService));
                //CmdAddContact.Parameters.AddWithValue("@UpdateServiceRegisteredDate",  FilterSQLDate(contactObj.UpdateServiceRegisteredDate));
                CmdAddContact.Parameters.AddWithValue("@VisaExpiryDate", FilterSQLDate(contactObj.VisaExpiryDate));
                CmdAddContact.Parameters.AddWithValue("@VisaType", CheckVals(contactObj.VisaType));
                CmdAddContact.Parameters.AddWithValue("@VisaChkdDate", FilterSQLDate(contactObj.VisaCheckedDate));
                //CmdAddContact.Parameters.AddWithValue("@VisaLocation",  CheckVals(contactObj.VisaLocation));
                CmdAddContact.Parameters.AddWithValue("@YearGroup", CheckVals(contactObj.YearGroup));
                CmdAddContact.Parameters.AddWithValue("@LastMod", FilterSQLDate(DateTime.UtcNow));
                string guidVal = System.Guid.NewGuid().ToString();
                CmdAddContact.Parameters.AddWithValue("@GUID", CheckVals(guidVal));
                CmdAddContact.ExecuteNonQuery();

                DataSet ds = GetDataSet("SELECT contactID FROM Contacts WHERE GUID = '" + guidVal + "'");
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
                string sqlStr = "UPDATE Contacts SET "
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
                    //+ "AttendMMRV = @AttendMMRV, "
                    //+ "BankAccountNumber = @BankAccountNumber, "
                    //+ "BankName = @BankName, "
                    //+ "BankSortCode = @BankSortCode, "
                    //+ "BankStatementLocation = @BankStatementLocation, "
                       + "BirthDate = @BirthDate, "
                    // + "Consultant = @Consultant , "
                       + "CRBandAddressProofMatch = @CRBandAddressProofMatch, "
                       + "CRBDateSent = @CRBDateSent, "
                       + "CRBExpiryDate = @CRBExpiryDate, "
                       + "CRBFormRef = @CRBFormRef, "
                       + "CRBNumber = @CRBNumber, "
                       + "CRBValidFrom = @CRBValidFrom, "
                    //+ "DBSDirectPayment = @DBSDirectPayment, "
                       + "DBSUpdateSvcChkdDate = @DBSUpdateSvcChkdDate, "
                       + "DisqByAssoc = @DisqByAssoc, "
                       + "DisqByAssocChkdDate = @DisqByAssocChkdDate, "
                       + "DSWC = @DSWC, "
                       + "DSWCChkdDate = @DSWCChkdDate, "
                       + "CurrentPayScale = @CurrentPayScale, "
                       + "CurrentPayScaleProof = @CurrentPayScaleProof, "
                       + "CNGHO = @CNGHO, "
                       + "CVReceived = @CVReceived, "
                       + "DateOfSupply = @DateOfSupply, "
                       + "FirstDayTeachingUK = @FirstDayTeachingUK, "
                       + "GTCCheckDate = @GTCCheckDate, "
                       + "GTCNumber = @GTCNumber, "
                       + "IDChecked = @IDChecked, "
                       + "IDChkdDate = @IDChkdDate, "
                    // + "Instructor = @Instructor, "
                       + "InterviewNotes = @InterviewNotes, "
                    // + "KeyRef = @KeyRef, "
                       + "LateRecord = @LateRecord, "
                       + "List99 = @List99, "
                       + "List99ChkdDate = @List99ChkdDate, "
                       + "LTStartDate = @LTStartDate, "
                       + "MedicalChecklist = @MedicalChecklist, "
                       + "MedicalChecklistChkdDate = @MedicalChecklistChkdDate, "
                       + "NextOfKin = @NextOfKin, "
                       + "NINumber = @NINumber, "
                       + "Notes = @Notes,"
                       + "NQT = @NQT, "
                       + "OtherCRBNumber = @OtherCRBNumber, "
                       + "OTTEndDate = @OTTEndDate, "
                       + "OverseasPoliceCheck = @OverseasPoliceCheck, "
                       + "OverseasPoliceChkdDate = @OverseasPoliceChkdDate, "
                       + "OverseasTrainedTeacher = @OverseasTrainedTeacher, "
                    //+ "PassportNo = @PassportNo, "
                    //+ "PassportLocation = @PassportLocation, "
                       + "PayDetails = @PayDetails, "
                    // + "PAYETeacherContractSigned = @PAYETeacherContractSigned, "
                       + "PhotoLocation = @PhotoLocation,"
                       + "GraduationDate = @GraduationDate, "
                       + "ProFrmTch = @ProFrmTch, "
                       + "ProFrmTchChkdDate = @ProFrmTchChkdDate, "
                    //+ "ProtabilityCheckSent = @ProtabilityCheckSent, "
                       + "ProtabilityReceivedDate = @ProtabilityReceivedDate, "
                       + "ProofOfAddress = @ProofOfAddress, "
                       + "POAChkdDate = @POAChkdDate, "
                    //+ "ProofOfID = @ProofOfID, "
                    //+ "ProofOfID2 = @ProofOfID2, "
                       + "QTS = @QTS, "
                       + "Qualification = @Qualification, "
                       + "QualificationCheckedDate = @QualificationCheckedDate, "
                       + "RedboxLeaveDate = @RedboxLeaveDate, "
                       + "RedboxStartDate = @RedboxStartDate, "
                       + "RedboxCRB = @RedboxCRB, "
                    //+ "ReferredBy = @ReferredBy, "
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
                       + "ReferencesChkdDate = @ReferencesChkdDate, "
                    //+ "RegistrationComplete = @RegistrationComplete, "
                       + "RegistrationDate = @RegistrationDate, "
                    //+ "SendBankStatement = @SendBankStatement, "
                    //+ "SendPassport = @SendPassport, "
                    //+ "SendVisa = @SendVisa, "
                       + "SicknessRecord = @SicknessRecord, "
                       + "Summary = @Summary, "
                    //+ "TeacherStatus = @TeacherStatus, "
                       + "UKArrivalDate = @UKArrivalDate, "
                       + "UpdateService = @UpdateService,"
                    //+ "UpdateServiceRegisteredDate = @UpdateServiceRegisteredDate,"
                       + "VisaExpiryDate = @VisaExpiryDate, "
                       + "VisaType = @VisaType, "
                    //+ "VisaLocation = @VisaLocation, "
                       + "VisaChkdDate = @VisaChkdDate, "
                       + "YearGroup = @YearGroup, "
                       + "LastMod = @LastMod WHERE contactID = @contactID";
                DBManager.OpenDBConnection();
                var CmdUpdateContact = new SqlCommand(sqlStr, DBManager._DBConn);

                CmdUpdateContact.Parameters.AddWithValue("@contactID", contactID);
                CmdUpdateContact.Parameters.AddWithValue("@FirstName", CheckVals(contactObj.FirstName));
                CmdUpdateContact.Parameters.AddWithValue("@LastName", CheckVals(contactObj.LastName));
                CmdUpdateContact.Parameters.AddWithValue("@Title", CheckVals(contactObj.Title));
                CmdUpdateContact.Parameters.AddWithValue("@MiddleName", CheckVals(contactObj.MiddleName));
                CmdUpdateContact.Parameters.AddWithValue("@Suffix", CheckVals(contactObj.Suffix));
                CmdUpdateContact.Parameters.AddWithValue("@Email1", CheckVals(contactObj.Email1));
                CmdUpdateContact.Parameters.AddWithValue("@Email2", CheckVals(contactObj.Email2));
                CmdUpdateContact.Parameters.AddWithValue("@Email3", CheckVals(contactObj.Email3));
                CmdUpdateContact.Parameters.AddWithValue("@JobTitle", CheckVals(contactObj.JobTitle));
                CmdUpdateContact.Parameters.AddWithValue("@AddressStreet", CheckVals(contactObj.AddressStreet));
                CmdUpdateContact.Parameters.AddWithValue("@AddressCity", CheckVals(contactObj.AddressCity));
                CmdUpdateContact.Parameters.AddWithValue("@AddressState", CheckVals(contactObj.AddressState));
                CmdUpdateContact.Parameters.AddWithValue("@AddressPostcode", CheckVals(contactObj.AddressPostcode));
                CmdUpdateContact.Parameters.AddWithValue("@AddressCountry", CheckVals(contactObj.AddressCountry));
                CmdUpdateContact.Parameters.AddWithValue("@PhoneHome", CheckVals(contactObj.PhoneHome));
                CmdUpdateContact.Parameters.AddWithValue("@PhoneMobile", CheckVals(contactObj.PhoneMobile));
                CmdUpdateContact.Parameters.AddWithValue("@PhoneBusiness", CheckVals(contactObj.PhoneBusiness));
                CmdUpdateContact.Parameters.AddWithValue("@PhoneFax", CheckVals(contactObj.PhoneFax));
                CmdUpdateContact.Parameters.AddWithValue("@CategoryStr", CheckVals(contactObj.CategoryStr));
                CmdUpdateContact.Parameters.AddWithValue("@1stRefChecked", CheckVals(contactObj._1stRefChecked));
                CmdUpdateContact.Parameters.AddWithValue("@2ndRefChecked", CheckVals(contactObj._2ndRefChecked));
                CmdUpdateContact.Parameters.AddWithValue("@3rdRefChecked", CheckVals(contactObj._3rdRefChecked));
                CmdUpdateContact.Parameters.AddWithValue("@AccountName", CheckVals(contactObj.AccountName));
                CmdUpdateContact.Parameters.AddWithValue("@AdditionalInfoOnCRB", CheckVals(contactObj.Cautions_AdditionalInfo_OnDBS));
                // CmdUpdateContact.Parameters.AddWithValue("@AttendMMRV", CheckVals(contactObj.AttendMMRV));
                // CmdUpdateContact.Parameters.AddWithValue("@BankAccountNumber", CheckVals(contactObj.BankAccountNumber));
                //CmdUpdateContact.Parameters.AddWithValue("@BankName", CheckVals(contactObj.BankName));
                //CmdUpdateContact.Parameters.AddWithValue("@BankSortCode", CheckVals(contactObj.BankSortCode));
                // CmdUpdateContact.Parameters.AddWithValue("@BankStatementLocation", CheckVals(contactObj.BankStatementLocation));
                CmdUpdateContact.Parameters.AddWithValue("@BirthDate", CheckVals(contactObj.BirthDate));
                //CmdUpdateContact.Parameters.AddWithValue("@Consultant", CheckVals(contactObj.Consultant));
                CmdUpdateContact.Parameters.AddWithValue("@CRBandAddressProofMatch", CheckVals(contactObj.DBSandAddressProofMatch));
                CmdUpdateContact.Parameters.AddWithValue("@CRBDateSent", FilterSQLDate(contactObj.DBSDateSent));
                CmdUpdateContact.Parameters.AddWithValue("@CRBExpiryDate", FilterSQLDate(contactObj.DBSExpiryDate));
                CmdUpdateContact.Parameters.AddWithValue("@CRBFormRef", CheckVals(contactObj.DBSFormRef));
                CmdUpdateContact.Parameters.AddWithValue("@CRBNumber", CheckVals(contactObj.DBSNumber));
                CmdUpdateContact.Parameters.AddWithValue("@CRBValidFrom", FilterSQLDate(contactObj.DBSValidFrom));
                //CmdUpdateContact.Parameters.AddWithValue("@DBSDirectPayment", CheckVals(contactObj.DBSDirectPayment));
                CmdUpdateContact.Parameters.AddWithValue("@DBSUpdateSvcChkdDate", FilterSQLDate(contactObj.DBSUpdateServiceCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@DisqByAssoc", CheckVals(contactObj.DisqByAssoc));
                CmdUpdateContact.Parameters.AddWithValue("@DisqByAssocChkdDate", FilterSQLDate(contactObj.DisqByAssocChkdDate));
                CmdUpdateContact.Parameters.AddWithValue("@DSWC", CheckVals(contactObj.DSWC));
                CmdUpdateContact.Parameters.AddWithValue("@DSWCChkdDate", FilterSQLDate(contactObj.DSWCChkdDate));
                CmdUpdateContact.Parameters.AddWithValue("@CurrentPayScale", CheckVals(contactObj.CurrentPayScale));
                CmdUpdateContact.Parameters.AddWithValue("@CurrentPayScaleProof", CheckVals(contactObj.CurrentPayScaleProof));
                CmdUpdateContact.Parameters.AddWithValue("@CNGHO", CheckVals(contactObj.CNGHO));
                CmdUpdateContact.Parameters.AddWithValue("@CVReceived", CheckVals(contactObj.CVReceived));
                CmdUpdateContact.Parameters.AddWithValue("@DateOfSupply", FilterSQLDate(contactObj.DateOfSupply));
                CmdUpdateContact.Parameters.AddWithValue("@FirstDayTeachingUK", FilterSQLDate(contactObj.FirstDayTeachingUK));
                CmdUpdateContact.Parameters.AddWithValue("@GTCCheckDate", FilterSQLDate(contactObj.GTCCheckDate));
                CmdUpdateContact.Parameters.AddWithValue("@GTCNumber", CheckVals(contactObj.GTCNumber));
                CmdUpdateContact.Parameters.AddWithValue("@IDChecked", CheckVals(contactObj.IDChecked));
                CmdUpdateContact.Parameters.AddWithValue("@IDChkdDate", FilterSQLDate(contactObj.IDCheckedDate));
                //CmdUpdateContact.Parameters.AddWithValue("@Instructor", CheckVals(contactObj.Instructor));
                CmdUpdateContact.Parameters.AddWithValue("@InterviewNotes", CheckVals(contactObj.InterviewNotes));
                //CmdUpdateContact.Parameters.AddWithValue("@KeyRef", CheckVals(contactObj.KeyRef));
                CmdUpdateContact.Parameters.AddWithValue("@LateRecord", CheckVals(contactObj.LateRecord));
                CmdUpdateContact.Parameters.AddWithValue("@List99", CheckVals(contactObj.List99));
                CmdUpdateContact.Parameters.AddWithValue("@List99ChkdDate", FilterSQLDate(contactObj.List99CheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@LTStartDate", FilterSQLDate(contactObj.LTStartDate));
                CmdUpdateContact.Parameters.AddWithValue("@MedicalChecklistChkdDate", FilterSQLDate(contactObj.MedicalChecklistCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@MedicalChecklist", CheckVals(contactObj.MedicalChecklist));
                CmdUpdateContact.Parameters.AddWithValue("@NextOfKin", CheckVals(contactObj.NextOfKin));
                CmdUpdateContact.Parameters.AddWithValue("@NINumber", CheckVals(contactObj.NINumber));
                CmdUpdateContact.Parameters.AddWithValue("@Notes", CheckVals(contactObj.Notes));
                CmdUpdateContact.Parameters.AddWithValue("@NQT", CheckVals(contactObj.NQT));
                CmdUpdateContact.Parameters.AddWithValue("@OtherCRBNumber", CheckVals(contactObj.OtherCRBNumber));
                CmdUpdateContact.Parameters.AddWithValue("@OTTEndDate", FilterSQLDate(contactObj.OTTEndDate));
                CmdUpdateContact.Parameters.AddWithValue("@OverseasPoliceChkdDate", FilterSQLDate(contactObj.OverseasPoliceCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@OverseasPoliceCheck", CheckVals(contactObj.OverseasPoliceCheck));
                CmdUpdateContact.Parameters.AddWithValue("@OverseasTrainedTeacher", CheckVals(contactObj.OverseasTrainedTeacher));
                //CmdUpdateContact.Parameters.AddWithValue("@PassportNo", CheckVals(contactObj.PassportNo));
                //CmdUpdateContact.Parameters.AddWithValue("@PassportLocation", CheckVals(contactObj.PassportLocation));
                CmdUpdateContact.Parameters.AddWithValue("@PayDetails", CheckVals(contactObj.PayDetails));
                //CmdUpdateContact.Parameters.AddWithValue("@PAYETeacherContractSigned", CheckVals(contactObj.PAYETeacherContractSigned));
                CmdUpdateContact.Parameters.AddWithValue("@PhotoLocation", CheckVals(contactObj.PhotoLocation));
                CmdUpdateContact.Parameters.AddWithValue("@GraduationDate", FilterSQLDate(contactObj.GraduationDate));
                CmdUpdateContact.Parameters.AddWithValue("@ProFrmTchChkdDate", FilterSQLDate(contactObj.ProhibitionFromTeachingCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@ProFrmTch", CheckVals(contactObj.ProhibitionFromTeaching));
                //CmdUpdateContact.Parameters.AddWithValue("@ProtabilityCheckSent", FilterSQLDate(contactObj.ProtabilityCheckSent));
                CmdUpdateContact.Parameters.AddWithValue("@ProtabilityReceivedDate", FilterSQLDate(contactObj.ProtabilityReceivedDate));
                CmdUpdateContact.Parameters.AddWithValue("@ProofOfAddress", CheckVals(contactObj.ProofOfAddress));
                CmdUpdateContact.Parameters.AddWithValue("@POAChkdDate", FilterSQLDate(contactObj.ProofOfAddressCheckedDate));
                //CmdUpdateContact.Parameters.AddWithValue("@ProofOfID", CheckVals(contactObj.ProofOfID));
                //CmdUpdateContact.Parameters.AddWithValue("@ProofOfID2", CheckVals(contactObj.ProofOfID2));
                CmdUpdateContact.Parameters.AddWithValue("@QTS", CheckVals(contactObj.QTS));
                CmdUpdateContact.Parameters.AddWithValue("@Qualification", CheckVals(contactObj.Qualification));
                CmdUpdateContact.Parameters.AddWithValue("@QualificationCheckedDate", FilterSQLDate(contactObj.QualificationCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@RedboxLeaveDate", FilterSQLDate(contactObj.RedboxLeaveDate));
                CmdUpdateContact.Parameters.AddWithValue("@RedboxStartDate", FilterSQLDate(contactObj.RedboxStartDate));
                CmdUpdateContact.Parameters.AddWithValue("@RedboxCRB", CheckVals(contactObj.RedboxDBS));
                //CmdUpdateContact.Parameters.AddWithValue("@ReferredBy", CheckVals(contactObj.ReferredBy));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Address", CheckVals(contactObj.Referee1Address));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Email", CheckVals(contactObj.Referee1Email));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Fax", CheckVals(contactObj.Referee1Fax));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Mobile", CheckVals(contactObj.Referee1Mobile));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Name", CheckVals(contactObj.Referee1Name));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Notes", CheckVals(contactObj.Referee1Notes));
                CmdUpdateContact.Parameters.AddWithValue("@Referee1Phone", CheckVals(contactObj.Referee1Phone));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Address", CheckVals(contactObj.Referee2Address));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Email", CheckVals(contactObj.Referee2Email));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Fax", CheckVals(contactObj.Referee2Fax));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Mobile", CheckVals(contactObj.Referee2Mobile));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Name", CheckVals(contactObj.Referee2Name));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Notes", CheckVals(contactObj.Referee2Notes));
                CmdUpdateContact.Parameters.AddWithValue("@Referee2Phone", CheckVals(contactObj.Referee2Phone));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Address", CheckVals(contactObj.Referee3Address));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Email", CheckVals(contactObj.Referee3Email));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Fax", CheckVals(contactObj.Referee3Fax));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Mobile", CheckVals(contactObj.Referee3Mobile));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Name", CheckVals(contactObj.Referee3Name));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Notes", CheckVals(contactObj.Referee3Notes));
                CmdUpdateContact.Parameters.AddWithValue("@Referee3Phone", CheckVals(contactObj.Referee3Phone));
                CmdUpdateContact.Parameters.AddWithValue("@ReferencesChecked", CheckVals(contactObj.ReferencesChecked));
                CmdUpdateContact.Parameters.AddWithValue("@ReferencesChkdDate", FilterSQLDate(contactObj.ReferencesCheckedDate));
                //CmdUpdateContact.Parameters.AddWithValue("@RegistrationComplete", CheckVals(contactObj.RegistrationComplete));
                CmdUpdateContact.Parameters.AddWithValue("@RegistrationDate", FilterSQLDate(contactObj.RegistrationDate));
                //CmdUpdateContact.Parameters.AddWithValue("@SendBankStatement", CheckVals(contactObj.SendBankStatement));
                //CmdUpdateContact.Parameters.AddWithValue("@SendPassport", CheckVals(contactObj.SendPassport));
                //CmdUpdateContact.Parameters.AddWithValue("@SendVisa", CheckVals(contactObj.SendVisa));
                CmdUpdateContact.Parameters.AddWithValue("@SicknessRecord", CheckVals(contactObj.SicknessRecord));
                CmdUpdateContact.Parameters.AddWithValue("@Summary", CheckVals(contactObj.Summary));
                //CmdUpdateContact.Parameters.AddWithValue("@TeacherStatus", CheckVals(contactObj.TeacherStatus));
                CmdUpdateContact.Parameters.AddWithValue("@UKArrivalDate", FilterSQLDate(contactObj.UKArrivalDate));
                CmdUpdateContact.Parameters.AddWithValue("@UpdateService", CheckVals(contactObj.UpdateService));
                //CmdUpdateContact.Parameters.AddWithValue("@UpdateServiceRegisteredDate", FilterSQLDate(contactObj.UpdateServiceRegisteredDate));
                CmdUpdateContact.Parameters.AddWithValue("@VisaExpiryDate", FilterSQLDate(contactObj.VisaExpiryDate));
                CmdUpdateContact.Parameters.AddWithValue("@VisaChkdDate", FilterSQLDate(contactObj.VisaCheckedDate));
                CmdUpdateContact.Parameters.AddWithValue("@VisaType", CheckVals(contactObj.VisaType));
                //CmdUpdateContact.Parameters.AddWithValue("@VisaLocation", CheckVals(contactObj.VisaLocation));
                CmdUpdateContact.Parameters.AddWithValue("@YearGroup", CheckVals(contactObj.YearGroup));
                CmdUpdateContact.Parameters.AddWithValue("@LastMod", FilterSQLDate(DateTime.UtcNow));
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
            var ds = GetDataSet("SELECT * FROM Reminders WHERE contactRefID = " + contactID.ToString() + " AND Type = '" + reminderType + "'");
            if (ds == null) return false;
            else if (ds.Tables[0].Rows.Count > 0) return true;
            else { return false; }
        }

        public void CleanContactNames()
        {
            //This finds contacts with no lastname. and updates the firstname and last name accordingly
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                RedBoxDB db = new RedBoxDB(CONNSTR);
                List<Contact> contacts = db.Contacts.ToList();
                foreach (Contact c in contacts)
                {
                    if (string.IsNullOrWhiteSpace(c.LastName))
                    {
                        string fullname = c.FirstName.Trim();
                        int i = fullname.IndexOf(") ") + 1;
                        if (i < 2) i = fullname.IndexOf(' ');
                        if (i > 0)
                        {
                            string firstname = fullname.Substring(0, i).Trim();
                            string lastname = fullname.Substring(i).Trim();
                            c.FirstName = firstname;
                            c.LastName = lastname;
                            db.SubmitChanges();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CleanContactNames: " + ex.Message);
            }
        }

        public void MarkAllCurrent()
        {
            //This finds contacts with no lastname. and updates the firstname and last name accordingly
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                RedBoxDB db = new RedBoxDB(CONNSTR);
                List<ContactData> contacts = db.ContactDatas.ToList();
                foreach (ContactData c in contacts)
                {
                    c.Current = true;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CleanContactNames: " + ex.Message);
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

        internal string UpdateDatabase()
        {
            try
            {
                OpenDBConnection();
                string response = "";
                string sql = "ALTER TABLE Schools ADD [TADayCharge] [decimal](7, 2) NOT NULL DEFAULT (0) ";
                response += UpdateColumn("[TADayCharge]", sql);

                sql = "ALTER TABLE Schools ADD [TAHalfDayCharge] [decimal](7, 2) NOT NULL DEFAULT (0) ";
                response += UpdateColumn("[TAHalfDayCharge]", sql);

                sql = "ALTER TABLE Schools ADD [TADayChargeLT]  [decimal](7, 2) NOT NULL DEFAULT (0) ";
                response += UpdateColumn("[TADayChargeLT]", sql);

                sql = "ALTER TABLE Schools ADD [TAHalfDayChargeLT] [decimal](7, 2) NOT NULL DEFAULT (0) ";
                response += UpdateColumn("[TAHalfDayChargeLT]", sql);

                return response;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                CloseDBConnection();
            }
        }

        private string UpdateColumn(string columnName, string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _DBConn);
                var value = cmd.ExecuteScalar();

                return columnName + ";";
            }
            catch (Exception ex)
            {
                return "Error " + columnName + ": " + ex.Message + ";";
            }
        }

        #endregion

        #region SQLQueries

        private string GetUnassignedAvailabilitySQL(DateTime weekbegining)
        {
            string monday = weekbegining.ToString("yyyyMMdd");
            string tuesday = weekbegining.AddDays(1).ToString("yyyyMMdd");
            string wednesday = weekbegining.AddDays(2).ToString("yyyyMMdd");
            string thursday = weekbegining.AddDays(3).ToString("yyyyMMdd");
            string friday = weekbegining.AddDays(4).ToString("yyyyMMdd");

            string SQLstr = "Select  " +
                            "s1.School as Monday, s2.School as Tuesday,  s3.School as Wednesday, " +
                            "s4.School as Thursday, s5.School as Friday,  " +
                            "s1.Color as MonColor, s2.Color as TueColor, s3.Color as WedColor, s4.Color as ThuColor, s5.Color  as FriColor, " +
                            "s1.BookingStatus as MonStatus, s2.BookingStatus as TueStatus, s3.BookingStatus as WedStatus, s4.BookingStatus as ThuStatus, s5.BookingStatus  as FriStatus " +
                            "FROM [MasterBookings] " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, MasterBookingID " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + monday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + monday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + monday + "' " +
                            ") as s1 " +
                            "ON s1.MasterBookingID = [MasterBookings].ID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, MasterBookingID " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + tuesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + tuesday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + tuesday + "' " +
                            ") as s2 " +
                            "ON s2.MasterBookingID = [MasterBookings].ID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, MasterBookingID " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + wednesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + wednesday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + wednesday + "' " +
                            ") as s3 " +
                            "ON s3.MasterBookingID = [MasterBookings].ID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, MasterBookingID " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + thursday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + thursday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + thursday + "' " +
                            ") as s4 " +
                            "ON s4.MasterBookingID = [MasterBookings].ID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, MasterBookingID " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + friday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + friday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + friday + "' " +
                            ") as s5 " +
                            "ON s5.MasterBookingID = [MasterBookings].ID ";

            return SQLstr;
        }

        private string GetAvailabilitySQL(DateTime weekbegining)
        {
            string monday = weekbegining.ToString("yyyyMMdd");
            string tuesday = weekbegining.AddDays(1).ToString("yyyyMMdd");
            string wednesday = weekbegining.AddDays(2).ToString("yyyyMMdd");
            string thursday = weekbegining.AddDays(3).ToString("yyyyMMdd");
            string friday = weekbegining.AddDays(4).ToString("yyyyMMdd");

            string SQLstr = "Select Lastname+', '+FirstName as TeacherName, Contacts.contactID AS TeacherID, Live, Location, Wants,[ContactData].YearGroup,QTS,ProofofAddress,NoGo, " +
                            "OverseasTrainedTeacher, NQT, TA, Teacher, QNN, SEN, NN, CRBStatus, PhoneMobile as Mobile, " +
                            "Nur,Rec,Yr1,Yr2,Yr3,Yr4,Yr5,Yr6, Float, LT, D2D, RWInc, BSL, FirstAid, " +
                            "s1.School as Monday, g1.gar as MonG, s2.School as Tuesday, g2.gar as TueG, s3.School as Wednesday, " +
                            "g3.gar as WedG, s4.School as Thursday, g4.gar as ThuG, s5.School as Friday, g5.gar as FriG,  " +
                            "s1.Color as MonColor, s2.Color as TueColor, s3.Color as WedColor, s4.Color as ThuColor, s5.Color  as FriColor, " +
                            "s1.BookingStatus as MonStatus, s2.BookingStatus as TueStatus, s3.BookingStatus as WedStatus, s4.BookingStatus as ThuStatus, s5.BookingStatus  as FriStatus, " +
                            "s1.LongTerm as MonLT, s2.LongTerm as TueLT, s3.LongTerm as WedLT, s4.LongTerm as ThuLT, s5.LongTerm  as FriLT, " +
                            "s1.Provisional as MonPr, s2.Provisional as TuePr, s3.Provisional as WedPr, s4.Provisional as ThuPr, s5.Provisional  as FriPr, " +
                            "g1.Acc as MonGA, g2.Acc as TueGA, g3.Acc as WedGA, g4.Acc as ThuGA, g5.Acc  as FriGA, " +
                            "g1.Type1 as MonType, g2.Type1 as TueType, g3.Type1 as WedType, g4.Type1 as ThuType, g5.Type1 as FriType, ContactData.Actor " +
                            "FROM [Contacts] " +

                            "LEFT JOIN [ContactData] " +
                            "ON [Contacts].contactID = [ContactData].ContactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, LongTerm, Provisional " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + monday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + monday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + monday + "' " +
                            ") as s1 " +
                            "ON s1.contactID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT COUNT(ID) as gar , TeacherID, SUM(CASE WHEN Type = 2 THEN 1 ELSE 0 END) AS Acc, MAX(Type) AS Type1 " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + monday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g1 ON g1.TeacherID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, LongTerm, Provisional " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + tuesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + tuesday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + tuesday + "' " +
                            ") as s2 " +
                            "ON s2.contactID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT COUNT(ID) as gar , TeacherID, SUM(CASE WHEN Type = 2 THEN 1 ELSE 0 END) AS Acc, MAX(Type) AS Type1 " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + tuesday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g2 ON g2.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, LongTerm, Provisional " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + wednesday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + wednesday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + wednesday + "' " +
                            ") as s3 " +
                            "ON s3.contactID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT COUNT(ID) as gar , TeacherID, SUM(CASE WHEN Type = 2 THEN 1 ELSE 0 END) AS Acc, MAX(Type) AS Type1 " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + wednesday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g3 ON g3.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, LongTerm, Provisional " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + thursday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + thursday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + thursday + "' " +
                            ") as s4 " +
                            "ON s4.contactID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT COUNT(ID) as gar , TeacherID, SUM(CASE WHEN Type = 2 THEN 1 ELSE 0 END) AS Acc, MAX(Type) AS Type1 " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + thursday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g4 ON g4.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus, LongTerm, Provisional " +
                            "FROM [MasterBookings] " +
                            "LEFT JOIN [Bookings] " +
                            "ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                            "WHERE  " +
                            "CONVERT(VARCHAR(10), [MasterBookings].StartDate, 112) <= '" + friday + "' " +
                            "AND " +
                            "CONVERT(VARCHAR(10), [MasterBookings].EndDate, 112) >= '" + friday + "' " +
                            "AND CONVERT(VARCHAR(10), [Bookings].Date, 112) ='" + friday + "' " +
                            ") as s5 " +
                            "ON s5.contactID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT COUNT(ID) as gar , TeacherID, SUM(CASE WHEN Type = 2 THEN 1 ELSE 0 END) AS Acc, MAX(Type) AS Type1 " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + friday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g5 ON g5.TeacherID = [Contacts].contactID ";



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
                            "FROM [Contacts] " +

                            "LEFT JOIN [ContactData] " +
                            "ON [Contacts].contactID = [ContactData].ContactID " +

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
                            "ON s1.contactID = [Contacts].contactID " +

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
                            "ON s2.contactID = [Contacts].contactID " +

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
                            "ON s3.contactID = [Contacts].contactID " +

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
                            "ON s4.contactID = [Contacts].contactID " +

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
                            "ON s5.contactID = [Contacts].contactID ";

            return SQLstr;
        }

        private string GetPivotLoadPlanSQL(DateTime dStart, DateTime dEnd)
        {
            string SQL = "";
            SQL += "SELECT SchoolName, LastName+', '+FirstName as Name, Rate, Bookings.Charge, Bookings.Date, Description, Bookings.Charge-Bookings.Rate as Margin ";
            SQL += "FROM [Bookings] ";
            SQL += "LEFT JOIN [MasterBookings] ";
            SQL += "ON [Bookings].MasterBookingID = MasterBookings.ID ";
            SQL += "LEFT JOIN [Schools] ";
            SQL += "ON [MasterBookings].SchoolID = Schools.ID ";
            SQL += "LEFT JOIN [Contacts] ";
            SQL += "ON MasterBookings.contactID = Contacts.contactID ";
            SQL += "WHERE ";
            SQL += "((Bookings.Date >= '" + dStart.ToString("yyyyMMdd") + "') AND (Bookings.Date <= '" + dEnd.ToString("yyyyMMdd") + "'))";

            return SQL;

        }

        private string GetLoadPlanSQL(DateTime dStart)
        {
            string monday = dStart.ToString("yyyy-MM-dd");
            string tuesday = dStart.AddDays(1).ToString("yyyy-MM-dd");
            string wednesday = dStart.AddDays(2).ToString("yyyy-MM-dd");
            string thursday = dStart.AddDays(3).ToString("yyyy-MM-dd");
            string friday = dStart.AddDays(4).ToString("yyyy-MM-dd");


            string SQL = "";
            SQL += "SELECT SchoolName, ShortName, FirstName, LastName, s.numDays, s1.Description as Monday, s2.Description as Tuesday, ";
            SQL += "s3.Description as Wednesday, s4.Description as Thursday, s5.Description as Friday, Cast(ROUND(total/numDays, 2) as decimal(18,2)) as srate,  ";
            SQL += "Cast((ISNULL(s1.Charge,0) + ISNULL(s2.Charge,0) + ISNULL(s3.Charge,0) + ISNULL(s4.Charge,0) + ISNULL(s5.Charge,0))/numDays as decimal(7,2)) as sCharge, ";
            SQL += "Cast (s1.ID AS varchar(9)) + ':' + Cast (s1.MasterBookingID AS varchar(9)) as MonID, ";
            SQL += "Cast (s2.ID AS varchar(9)) + ':' + Cast (s2.MasterBookingID AS varchar(9)) as TueID, ";
            SQL += "Cast (s3.ID AS varchar(9)) + ':' + Cast (s3.MasterBookingID AS varchar(9)) as WedID, ";
            SQL += "Cast (s4.ID AS varchar(9)) + ':' + Cast (s4.MasterBookingID AS varchar(9)) as ThuID, ";
            SQL += "Cast (s5.ID AS varchar(9)) + ':' + Cast (s5.MasterBookingID AS varchar(9)) as FriID,  ";
            SQL += "Cast(ISNULL(s1.Rate,0) + ISNULL(s2.Rate,0) + ISNULL(s3.Rate,0) + ISNULL(s4.Rate,0) + ISNULL(s5.Rate,0) as decimal(7,2)) as TotalCost, ";
            SQL += "Cast(ISNULL(s1.Charge,0) + ISNULL(s2.Charge,0) + ISNULL(s3.Charge,0) + ISNULL(s4.Charge,0) + ISNULL(s5.Charge,0) as decimal(7,2)) as Revenue, ";
            SQL += "Cast(ISNULL(s1.Charge,0) + ISNULL(s2.Charge,0) + ISNULL(s3.Charge,0) + ISNULL(s4.Charge,0) + ISNULL(s5.Charge,0) ";
            SQL += "-ISNULL(s1.Rate,0) - ISNULL(s2.Rate,0) - ISNULL(s3.Rate,0) - ISNULL(s4.Rate,0) - ISNULL(s5.Rate,0) as decimal(7,2)) as TMargin ";
            SQL += "FROM MasterBookings ";

            SQL += "JOIN  ";
            SQL += "( ";
            SQL += "SELECT COUNT(Bookings.ID) as numDays, MasterBookingID, SUM(Rate) as total ";
            SQL += "FROM Bookings ";
            SQL += "WHERE (Date >= '" + monday + "' ) AND (Date <= '" + friday + "') ";
            SQL += "GROUP BY MasterBookingID ";
            SQL += ") As s ";
            SQL += "ON s.MasterBookingID = [MasterBookings].ID ";

            SQL += "LEFT JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate, Charge, ID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + monday + "' ";
            SQL += ") As s1 ";
            SQL += "ON s1.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate, Charge, ID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + tuesday + "' ";
            SQL += ") As s2 ";
            SQL += "ON s2.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate, Charge, ID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + wednesday + "' ";
            SQL += ") As s3 ";
            SQL += "ON s3.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate, Charge, ID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + thursday + "' ";
            SQL += ") As s4 ";
            SQL += "ON s4.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate, Charge, ID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + friday + "' ";
            SQL += ") As s5 ";
            SQL += "ON s5.MasterBookingID = [MasterBookings].ID ";

            SQL += "LEFT JOIN [Contacts] ";
            SQL += "ON MasterBookings.contactID = [Contacts].contactID ";

            SQL += "LEFT JOIN [Schools]  ";
            SQL += "ON MasterBookings.SchoolID = [Schools].ID ";
            SQL += "WHERE isAbsence != 1 ";

            SQL += "ORDER BY SchoolName, sCharge DESC, LastName, FirstName ";
            GetLoadPlanOverTimeSQL(dStart);
            return SQL;
        }

        private string GetLoadPlanOverTimeSQL(DateTime dStart)
        {

            string monday = dStart.ToString("yyyyMMdd");
            string tuesday = dStart.AddDays(1).ToString("yyyyMMdd");
            string wednesday = dStart.AddDays(2).ToString("yyyyMMdd");
            string thursday = dStart.AddDays(3).ToString("yyyyMMdd");
            string friday = dStart.AddDays(4).ToString("yyyyMMdd");

            string SQL = "";

            //            SQL = "Select Schools.SchoolName, Contacts.FirstName, Contacts.LastName, SUM(BookingOverTime.RateAdditional) AS ARate, SUM(BookingOverTime.ChargeAdditional) AS ACharge " +
            //"FROM BookingOverTime INNER JOIN Bookings ON BookingOverTime.BookingID = Bookings.ID INNER JOIN " +
            //"MasterBookings ON Bookings.MasterBookingID = MasterBookings.ID INNER JOIN Schools ON MasterBookings.SchoolID = Schools.ID INNER JOIN Contacts ON MasterBookings.contactID = Contacts.contactID " +
            //"WHERE (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + monday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + tuesday + "') OR " +
            //"(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + wednesday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + thursday + "') OR " +
            //"(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + friday + "') GROUP BY MasterBookings.SchoolID, Schools.SchoolName, Contacts.FirstName, Contacts.LastName, MasterBookings.contactID";

            SQL = "Select Schools.SchoolName, Contacts.FirstName, Contacts.LastName, BookingOverTime.RateAdditional AS ARate, BookingOverTime.ChargeAdditional AS ACharge, BookingOverTime.Notes, Bookings.Date " +
"FROM BookingOverTime INNER JOIN Bookings ON BookingOverTime.BookingID = Bookings.ID INNER JOIN " +
"MasterBookings ON Bookings.MasterBookingID = MasterBookings.ID INNER JOIN Schools ON MasterBookings.SchoolID = Schools.ID INNER JOIN Contacts ON MasterBookings.contactID = Contacts.contactID " +
"WHERE (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + monday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + tuesday + "') OR " +
"(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + wednesday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + thursday + "') OR " +
"(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + friday + "')";

            return SQL;
        }

        private string GetPayRunSQL(DateTime dStart)
        {
            string sStart = dStart.ToString("yyyy-MM-dd");
            string sEnd = dStart.AddDays(4).ToString("yyyy-MM-dd");
            string SQL = "";
            SQL += "SELECT   ";
            SQL += "[MasterBookingID]  ";
            SQL += ",[Date]  ";
            SQL += ",[Rate]  ";
            SQL += ",[Bookings].[Charge]  ";
            SQL += ",[Description]  ";
            SQL += ",[MasterBookings].contactID  ";
            SQL += ",[Contacts].FirstName  ";
            SQL += ",[Contacts].LastName  ";
            SQL += ",[Contacts].KeyRef  ";
            SQL += ",[Contacts].PayDetails  ";
            SQL += "FROM [RedboxDB2].[dbo].[Bookings]  ";
            SQL += " LEFT JOIN [MasterBookings]   ";
            SQL += "ON [MasterBookings].ID = Bookings.MasterBookingID  ";
            SQL += "LEFT JOIN [Contacts]  ";
            SQL += "ON [MasterBookings].contactID = [Contacts].contactID  ";
            SQL += "WHERE [Date] >= '" + sStart + "' AND [Date] <= '" + sEnd + "'  ";
            SQL += "ORDER BY [Contacts].LastName, [Contacts].FirstName ";

            return SQL;
        }

        private string GetPayRunOverTimeSQL(DateTime dStart)
        {

            string monday = dStart.ToString("yyyyMMdd");
            string tuesday = dStart.AddDays(1).ToString("yyyyMMdd");
            string wednesday = dStart.AddDays(2).ToString("yyyyMMdd");
            string thursday = dStart.AddDays(3).ToString("yyyyMMdd");
            string friday = dStart.AddDays(4).ToString("yyyyMMdd");

            string SQL = "";

            SQL = "Select Schools.SchoolName, Contacts.contactID, Contacts.FirstName, Contacts.LastName, Contacts.PayDetails,  " +
                    "BookingOverTime.RateAdditional AS ARate, BookingOverTime.ChargeAdditional AS ACharge, BookingOverTime.Notes, Bookings.Date " +
                    "FROM BookingOverTime " +
                    "INNER JOIN Bookings ON BookingOverTime.BookingID = Bookings.ID " +
                    "INNER JOIN MasterBookings ON Bookings.MasterBookingID = MasterBookings.ID " +
                    "INNER JOIN Schools ON MasterBookings.SchoolID = Schools.ID " +
                    "INNER JOIN Contacts ON MasterBookings.contactID = Contacts.contactID " +
                    "WHERE (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + monday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + tuesday + "') OR " +
                    "(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + wednesday + "') OR (CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + thursday + "') OR " +
                    "(CONVERT(VARCHAR(10), Bookings.Date, 112) = '" + friday + "') " +
                    "ORDER By Contacts.LastName,Contacts.FirstName, Arate DESC ";

            return SQL;
        }

        private string GetInvoiceSQL(string WeekEnding, string SageAccountRef)
        {
            DateTime dtEnd = Convert.ToDateTime(WeekEnding);
            string sStart = dtEnd.AddDays(-4).ToString("yyyy-MM-dd");
            string SQL = "";
            SQL += "SELECT   ";
            SQL += "[MasterBookingID] ,";
            SQL += "[Date],";
            SQL += "[Rate],";
            SQL += "[Bookings].[Charge],";
            SQL += "[Description],";
            SQL += "[MasterBookings].contactID,";
            SQL += "[Contacts].FirstName,";
            SQL += "[Contacts].LastName,";
            SQL += "[Contacts].KeyRef,";
            SQL += "[Contacts].PayDetails ,";
            SQL += "[Schools].SchoolName,";
            SQL += "[Schools].SageName,";
            SQL += "[Schools].Address ";
            SQL += "FROM [RedboxDB2].[dbo].[Bookings]   ";
            SQL += "LEFT JOIN [MasterBookings] ";
            SQL += "ON [MasterBookings].ID = Bookings.MasterBookingID ";
            SQL += "LEFT JOIN [Contacts] ";
            SQL += "ON [MasterBookings].contactID = [Contacts].contactID ";
            SQL += "LEFT JOIN [Schools] ";
            SQL += "ON [MasterBookings].SchoolID = [Schools].ID ";
            SQL += "WHERE [Date] >= '" + sStart + "' AND [Date] <= '" + WeekEnding + "'  ";
            SQL += "AND [Schools].SageName = '" + SageAccountRef + "' ";
            SQL += "ORDER BY [Schools].SchoolName,[Bookings].[Charge] DESC, [Contacts].LastName,[Contacts].FirstName  ";

            return SQL;
        }

        private string GetInvoiceOTSQL(string WeekEnding, string SageAccountRef)
        {
            DateTime dtEnd = Convert.ToDateTime(WeekEnding);
            string sStart = dtEnd.AddDays(-4).ToString("yyyy-MM-dd");
            string SQL = "";
            SQL += "SELECT   ";
            SQL += "[BookingOverTime].[MasterBookingID] ,[Date],[RateAdditional],[ChargeAdditional],[Description],[BookingOverTime].[Notes] As BNotes, ";
            SQL += "[MasterBookings].contactID,[Contacts].FirstName,[Contacts].LastName,[Contacts].KeyRef,[Contacts].PayDetails , ";
            SQL += "[Schools].SchoolName,[Schools].SageName,[Schools].Address ";
            SQL += "FROM [RedboxDB2].[dbo].[BookingOverTime] ";
            SQL += "LEFT JOIN [Bookings] ON [BookingOverTime].BookingID = [Bookings].ID ";
            SQL += "LEFT JOIN [MasterBookings] ON [MasterBookings].ID = Bookings.MasterBookingID ";
            SQL += "LEFT JOIN [Contacts] ON [MasterBookings].contactID = [Contacts].contactID ";
            SQL += "LEFT JOIN [Schools] ON [MasterBookings].SchoolID = [Schools].ID ";

            SQL += "WHERE [Date] >= '" + sStart + "' AND [Date] <= '" + WeekEnding + "'  ";
            SQL += "AND [Schools].SageName = '" + SageAccountRef + "' ";
            SQL += "ORDER BY [Bookings].[Charge] DESC, [Contacts].LastName,[Contacts].FirstName  ";

            return SQL;
        }

        private string GetTimeSheetSQL(DateTime dStart, string schoolID)
        {
            string start = dStart.ToString("yyyy-MM-dd");
            string dEnd = dStart.AddDays(4).ToString("yyyy-MM-dd");

            string SQL = "";
            SQL += "SELECT  Date, ";
            SQL += "[Bookings].Charge as DayRate, [Bookings].MasterBookingID, SchoolName, LastName+', ' +FirstName as FullName, ";
            SQL += "[Bookings].Description, ShortName ";
            SQL += "FROM Bookings  ";
            SQL += "LEFT JOIN MasterBookings ON MasterBookings.ID = MasterBookingID ";
            SQL += "LEFT JOIN [Contacts] ON MasterBookings.contactID = [Contacts].contactID  ";
            SQL += "LEFT JOIN [Schools]  ON MasterBookings.SchoolID = [Schools].ID  ";
            SQL += "WHERE (Date >= '" + start + "' ) AND (Date <= '" + dEnd + "') ";
            SQL += "AND ( isAbsence != 1) AND (MasterBookings.SchoolID = '" + schoolID + "') ";
            //SQL += "ORDER BY [Bookings].MasterBookingID, [Bookings].Charge, [Bookings].Date, LastName, Firstname ";
            SQL += "ORDER BY [Bookings].Charge, LastName, Firstname ";//Added as adviced by David
            return SQL;
        }

        private string GetTimeSheetOTDetailsSQL(DateTime dStart, string schoolID)
        {
            string start = dStart.ToString("yyyy-MM-dd");
            string dEnd = dStart.AddDays(4).ToString("yyyy-MM-dd");

            string SQL = "";
            SQL = "SELECT Bookings.Date, BookingOverTime.ChargeAdditional AS DayRate, Bookings.MasterBookingID, Schools.SchoolName, " +
"Contacts.LastName + ', ' + Contacts.FirstName AS FullName, BookingOverTime.Notes AS Description, Schools.ShortName " +
"FROM Bookings LEFT OUTER JOIN BookingOverTime ON Bookings.MasterBookingID = BookingOverTime.MasterBookingID AND " +
"Bookings.ID = BookingOverTime.BookingID LEFT OUTER JOIN MasterBookings ON MasterBookings.ID = Bookings.MasterBookingID " +
"LEFT OUTER JOIN Contacts ON MasterBookings.contactID = Contacts.contactID LEFT OUTER JOIN Schools ON MasterBookings.SchoolID = Schools.ID " +
"WHERE (Bookings.Date >= '" + start + "' ) AND (Bookings.Date <= '" + dEnd + "') AND (MasterBookings.isAbsence <> 1) AND " +
"(MasterBookings.SchoolID = '" + schoolID + "') AND (BookingOverTime.ChargeAdditional > 0) ORDER BY DayRate, Contacts.LastName, Contacts.FirstName ";
            return SQL;
        }

        private string GetTimeSheetSQL_orig(DateTime dStart, string schoolID)
        {
            string monday = dStart.ToString("yyyy-MM-dd");
            string tuesday = dStart.AddDays(1).ToString("yyyy-MM-dd");
            string wednesday = dStart.AddDays(2).ToString("yyyy-MM-dd");
            string thursday = dStart.AddDays(3).ToString("yyyy-MM-dd");
            string friday = dStart.AddDays(4).ToString("yyyy-MM-dd");


            string SQL = "";
            SQL += "SELECT MasterBookings.ID, SchoolName, LastName+', ' +FirstName as FullName,  ";
            SQL += "CASE  WHEN ISNULL(s1.Description,'')='' THEN '' ELSE 'Mon,' END+ ";
            SQL += "CASE  WHEN ISNULL(s2.Description,'')='' THEN '' ELSE 'Tue,' END+ ";
            SQL += "CASE  WHEN ISNULL(s3.Description,'')='' THEN '' ELSE 'Wed,' END+ ";
            SQL += "CASE  WHEN ISNULL(s4.Description,'')='' THEN '' ELSE 'Thu,' END+ ";
            SQL += "CASE  WHEN ISNULL(s5.Description,'')='' THEN '' ELSE 'Fri' END AS days, ";

            SQL += "s.numDays,  Charge as DayRate,  numDays*Charge as Total ";
            SQL += "FROM MasterBookings ";

            SQL += "JOIN  ";
            SQL += "( ";
            SQL += "SELECT COUNT(Bookings.ID) as numDays, MasterBookingID, SUM(Rate) as total ";
            SQL += "FROM Bookings ";
            SQL += "WHERE (Date >= '" + monday + "' ) AND (Date <= '" + friday + "') ";
            SQL += "GROUP BY MasterBookingID ";
            SQL += ") As s ";
            SQL += "ON s.MasterBookingID = [MasterBookings].ID ";

            SQL += "LEFT JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + monday + "' ";
            SQL += ") As s1 ";
            SQL += "ON s1.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + tuesday + "' ";
            SQL += ") As s2 ";
            SQL += "ON s2.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + wednesday + "' ";
            SQL += ") As s3 ";
            SQL += "ON s3.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + thursday + "' ";
            SQL += ") As s4 ";
            SQL += "ON s4.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + friday + "' ";
            SQL += ") As s5 ";
            SQL += "ON s5.MasterBookingID = [MasterBookings].ID ";

            SQL += "LEFT JOIN [Contacts] ";
            SQL += "ON MasterBookings.contactID = [Contacts].contactID ";

            SQL += "LEFT JOIN [Schools]  ";
            SQL += "ON MasterBookings.SchoolID = [Schools].ID ";

            SQL += "WHERE isAbsence != 1 AND MasterBookings.SchoolID = '" + schoolID + "' ";


            return SQL;

        }

        private string GetMasterBookingInfoSQL(long masterBookingID)
        {
            string SQLstr = " SELECT MasterBookings.ID, SchoolID, SchoolName as School, MasterBookings.contactID, MasterBookings.BookingStatus, MasterBookings.Provisional, " +
                            "LastName+', '+FirstName as TeacherName, Details, MasterBookings.Notes, [MasterBookings].StartDate, [MasterBookings].EndDate, isAbsence, AbsenceReason, " +
                            "HalfDay, LongTerm, Nur, Rec, Yr1, Yr2, Yr3, Yr4, Yr5, Yr6, [MasterBookings].QTS,[MasterBookings].NQT, OTT, Teacher, TA,SEN, QNN, NN, PPL, " +
                            "Charge, LinkedTeacherID,NameGiven,AskedFor,TrialDay, LinkedTeacherName, Color, RequestedBy " +

                            "FROM MasterBookings " +
                            "LEFT JOIN [Schools] " +
                            "ON [MasterBookings].SchoolID = Schools.ID " +
                            "LEFT JOIN [Contacts]  " +
                            "ON [MasterBookings].ContactID = [Contacts].ContactID " +
                            "LEFT JOIN " +
                            "( " +
                            "SELECT contactID, LastName+', '+FirstName as LinkedTeacherName " +
                            "FROM [Contacts] " +
                            ") as LinkedTeacher " +
                            "ON LinkedTeacher.contactID = MasterBookings.LinkedTeacherID " +
                            "WHERE MasterBookings.ID = '" + masterBookingID.ToString() + "' ";

            return SQLstr;
        }

        private string GetViewBookingsSQL(string SchoolID, string teacherID, string dtStart, string dtEnd, string status)
        {
            string SQL = "SELECT [Bookings].ID, MasterBookingID, Description, Date, [MasterBookings].contactID, SchoolID, SchoolName, " +
                         "LastName+', ' + FirstName as FullName, BookingStatus, Code, MasterBookings.LongTerm AS LT " +
                         "FROM [Bookings] " +
                         "LEFT JOIN [MasterBookings] ON [MasterBookings].ID = [Bookings].MasterBookingID " +
                         "LEFT JOIN [Schools] ON [MasterBookings].SchoolID = [Schools].ID " +
                         "LEFT JOIN [Contacts] ON [MasterBookings].contactID = [Contacts].contactID";
            string WhereSQL = "";
            if (!string.IsNullOrWhiteSpace(SchoolID)) WhereSQL += " AND SchoolID = '" + SchoolID + "' ";
            if (!string.IsNullOrWhiteSpace(teacherID)) WhereSQL += " AND [MasterBookings].contactID = '" + teacherID + "' ";
            if (!string.IsNullOrWhiteSpace(dtStart)) WhereSQL += " AND CONVERT(VARCHAR(10), [Bookings].Date, 112) >= '" + dtStart + "' ";
            if (!string.IsNullOrWhiteSpace(dtEnd)) WhereSQL += " AND CONVERT(VARCHAR(10), [Bookings].Date, 112) <= '" + dtEnd + "' ";
            if (!string.IsNullOrWhiteSpace(status)) WhereSQL += " AND [BookingStatus] = '" + status + "' ";

            if (WhereSQL.Length > 2)
            {
                WhereSQL = " WHERE " + WhereSQL.Substring(4).Trim();
            }
            return SQL + WhereSQL;
        }

        private string GetMasterBookingsSQL(string teacherID, string ddate)
        {
            string SQL = "SELECT [Schools].SchoolName, Bookings.Date, Contacts.LastName+', '+Contacts.FirstName as FullName,  " +
                        "[Bookings].Description, MasterBookings.ID as MasterBookingID, Contacts.contactID, Schools.ID as SchoolID , BookingStatus " +
                        "FROM MasterBookings " +
                        "Left JOIN [Bookings] ON MasterBookingID = MasterBookings.ID " +
                        "Left Join [Schools] ON Schools.ID = MasterBookings.SchoolID " +
                        "Left Join [Contacts] on MasterBookings.contactID = Contacts.contactID " +
                        "WHERE MasterBookings.contactID = '" + teacherID + "' AND [Bookings].Date = '" + ddate + "'";



            return SQL;
        }

        private string GetMasterBookingsforDateSQL(string ddate, string status)
        {
            string SQL = "SELECT [Schools].SchoolName, Bookings.Date, Contacts.LastName+', '+Contacts.FirstName as FullName,  " +
                        "[Bookings].Description, MasterBookings.ID as MasterBookingID, Contacts.contactID, Schools.ID as SchoolID , BookingStatus " +
                        "FROM MasterBookings " +
                        "Left JOIN [Bookings] ON MasterBookingID = MasterBookings.ID " +
                        "Left Join [Schools] ON Schools.ID = MasterBookings.SchoolID " +
                        "Left Join [Contacts] on MasterBookings.contactID = Contacts.contactID " +
                        "WHERE [Bookings].Date = '" + ddate + "'";
            if (!string.IsNullOrEmpty(status))
            {
                SQL += " AND MasterBookings.BookingStatus = '" + status + "'  ";
            }



            return SQL;
        }

        private string GetCheckDoubleBookingsSQL()
        {
            string SQL = "SELECT Contacts.contactID as contID, FirstName, LastName, s1.num, s1.Date " +
                        "FROM Contacts " +
                        "JOIN " +
                        "( " +
                        "SELECT  [Date], COUNT(Date) as num, [MasterBookings].contactID, SUM(CASE WHEN [MasterBookings].HalfDay = 1 THEN 0.5 ELSE 1 END) AS days  " +
                        "FROM [RedboxDB2].[dbo].[Bookings] " +
                        "LEFT JOIN [MasterBookings] ON MasterBookingID = MasterBookings.ID " +
                        "GROUP BY Date, [MasterBookings].contactID " +
                        ") as s1 ON s1.ContactID = Contacts.contactID  " +
                        "WHERE s1.days > 1 ";
            //"WHERE s1.num > 1 ";
            return SQL;
        }

        private string GetUnassignedBookingsSQL(string dtStart, string dtEnd)
        {
            string SQL = "SELECT [Bookings].ID, MasterBookingID, Description, Date, [MasterBookings].contactID, SchoolID, SchoolName, " +
                         "LastName+', ' + FirstName as FullName , BookingStatus, MasterBookings.LongTerm AS LT" +
                         "FROM [Bookings] " +
                         "LEFT JOIN [MasterBookings] ON [MasterBookings].ID = [Bookings].MasterBookingID " +
                         "LEFT JOIN [Schools] ON [MasterBookings].SchoolID = [Schools].ID " +
                         "LEFT JOIN [Contacts] ON [MasterBookings].contactID = [Contacts].contactID " +
                         "WHERE ([MasterBookings].contactID = -1 OR [MasterBookings].contactID IS NULL OR FirstName = '' or LastName = '' )";
            if (!string.IsNullOrWhiteSpace(dtStart)) SQL += " AND (CONVERT(VARCHAR(10), [Bookings].Date, 112) >= '" + dtStart + "') ";
            if (!string.IsNullOrWhiteSpace(dtEnd)) SQL += " AND (CONVERT(VARCHAR(10), [Bookings].Date, 112) <= '" + dtEnd + "') ";


            return SQL;
        }
        #endregion

        #region Import Data from original Database

        public void ImportOriginalData()
        {
            try
            {
                //Get dataset from original 
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in ImportOriginalData: " + ex.Message);
            }
        }
        #endregion
    }
}
