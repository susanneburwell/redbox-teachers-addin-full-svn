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
                DataSet msgDs = GetDataSet("Select FirstName,LastName,Title,MiddleName,Suffix,CategoryStr,Email1,Birthdate,JobTitle,contactID,PhoneHome,PhoneMobile,PhoneBusiness,LTStartDate,RedboxStartDate,VisaExpiryDate,CRBExpiryDate from Contacts");


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

        public DataSet GetAvailabilityDS(DateTime weekbegining, string wheresql)
        {
            try
            {
                string SQLstr = GetAvailabilitySQL(weekbegining);
                DataSet msgDs = GetDataSet(SQLstr + wheresql);
                return msgDs;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetAvailability: " + ex.Message);
                return null;
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
                        RAvailability objAvail = new RAvailability();

                        objAvail.Teacher = dr["Teacher"].ToString();
                        //CRB = dr["CRB"].ToString();
                        objAvail.Live = dr["Live"].ToString();
                        objAvail.NoGo = dr["NoGo"].ToString();
                        objAvail.PofA = dr["ProofofAddress"].ToString();
                        objAvail.QTS = dr["QTS"].ToString();
                        objAvail.Wants = dr["Wants"].ToString();
                        objAvail.YrGroup = dr["YearGroup"].ToString();
                        objAvail.Monday = dr["Monday"].ToString();
                        objAvail.Tuesday = dr["Tuesday"].ToString();
                        objAvail.Wednesday = dr["Wednesday"].ToString();
                        objAvail.Thursday = dr["Thursday"].ToString();
                        objAvail.Friday = dr["Friday"].ToString();
                        objAvail.MonG = dr["MonG"].ToString();
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

                        //objAvail.MonG = Utils.CheckLong(dr["MonG"]);
                        //objAvail.TueG = Utils.CheckLong(dr["TueG"]);
                        //objAvail.WedG = Utils.CheckLong(dr["WedG"]);
                        //objAvail.ThuG = Utils.CheckLong(dr["ThuG"]);
                        //objAvail.FriG = Utils.CheckLong(dr["FriG"]);
                        //if (Utils.CheckLong(dr["MonG"]) > 0) objAvail.MonG = true;
                        //if (Utils.CheckLong(dr["TueG"]) > 0) objAvail.TueG = true;
                        //if (Utils.CheckLong(dr["WedG"]) > 0) objAvail.WedG = true;
                        //if (Utils.CheckLong(dr["ThuG"]) > 0) objAvail.ThuG = true;
                        //if (Utils.CheckLong(dr["FriG"]) > 0) objAvail.FriG = true;

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

        public List<RTeacherday> GetTeacherDays(Int64 teacherID, bool past, bool future)
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
            try
            {
                string SQLstr = "SELECT [Date],[Note] " +
                                "FROM [GuaranteedDays] " +
                                "Where [TeacherID] = '" + teacherID.ToString() + "' ";
                DataSet msgDs = GetDataSet(SQLstr + DateSQL);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RTeacherday tDay = new RTeacherday();
                        tDay.dte = Utils.CheckDate(dr["Date"]);
                        tDay.Type = "Guaranteed Day";
                        tDay.Details = Utils.CheckString(dr["Note"]);
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

            //Get Booked days
            try
            {
                string SQLstr = "SELECT Description, [MasterBookings].contactID, Bookings.Date, isAbsence, Status " +
                                "FROM [Bookings] " +
                                "LEFT JOIN [MasterBookings] ON [Bookings].MasterBookingID = [MasterBookings].ID  " +
                                "LEFT JOIN [BookingStatuses] ON [MasterBookings].BookingStatus = BookingStatuses.ID " +
                                "WHERE  [MasterBookings].contactID = '" + teacherID.ToString() + "' ";
                DataSet msgDs = GetDataSet(SQLstr + DateSQL);


                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        RTeacherday tDay = new RTeacherday();
                        tDay.dte = Utils.CheckDate(dr["Date"]);
                        if (Utils.CheckBool(dr["isAbsence"])) tDay.Type = "Absence";
                        else tDay.Type = Utils.CheckString(dr["Status"]);
                        tDay.Details = Utils.CheckString(dr["Description"]);
                        teacherDays.Add(tDay);

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetTeacherDays(Guarantees): " + ex.Message);
                return null;
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

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            RTimeSheet objTS = new RTimeSheet()
                           {
                               ID = Utils.CheckLong(dr["MasterBookingID"]),
                               SchoolName = dr["SchoolName"].ToString(),
                               FullName = dr["FullName"].ToString(),
                               days = GetDay(dr["Date"].ToString()),
                               numDays = 1,
                               DayRate = Utils.CheckDecimal(dr["DayRate"].ToString()),
                               Total = Utils.CheckDecimal(dr["DayRate"].ToString()),

                           };
                            TimeSheets.Add(objTS);
                        }
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating GetTimeSheets List: " + ex.Message); }

                    }

                    //
                    //iterate through the list
                    int listPointer = 0;
                    while (listPointer < TimeSheets.Count - 1)
                    {
                        if (TimeSheetsMatch(TimeSheets[listPointer], TimeSheets[listPointer + 1]))
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

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            Payment objTS = new Payment()
                            {
                                //ID = Utils.CheckLong(dr["ID"]),
                                PayDetails = dr["PayDetails"].ToString(),
                                AgencyRef = dr["Description"].ToString(),
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
                                Address = dr["Address"].ToString(),
                                PayDetails = dr["PayDetails"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                FirstName = dr["FirstName"].ToString(),
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
                DataSet msgDs = GetDataSet(SQLstr);

                if (msgDs != null)
                {
                    foreach (DataRow dr in msgDs.Tables[0].Rows)
                    {
                        try
                        {
                            RLoad objLoad = new RLoad()
                           {
                               SchoolName = dr["SchoolName"].ToString(),
                               FirstName = dr["FirstName"].ToString(),
                               LastName = dr["LastName"].ToString(),
                               numDays = Convert.ToInt32(dr["numDays"]),
                               Monday = dr["Monday"].ToString(),
                               Tuesday = dr["Tuesday"].ToString(),
                               Wednesday = dr["Wednesday"].ToString(),
                               Thursday = dr["Thursday"].ToString(),
                               Friday = dr["Friday"].ToString(),
                               srate = Utils.CheckDecimal(dr["srate"].ToString()),
                               TotalCost = Utils.CheckDecimal(dr["TotalCost"].ToString()),
                               Margin = Utils.CheckDecimal(dr["Margin"].ToString()),
                               Charge = Utils.CheckDecimal(dr["Charge"].ToString()),
                               Revenue = Utils.CheckDecimal(dr["Revenue"].ToString()),
                               TMargin = Utils.CheckDecimal(dr["TMargin"].ToString()),

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
                        catch (Exception ex) { Debug.DebugMessage(2, "Error Creating LoadPlan List: " + ex.Message); }

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

        public List<RBookings> GetBookings(string SchoolID, string teacherID, string dtStart, string dtEnd, string status)
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

        public List<RBookings> GetBookingsForDate(string ddate, bool confirmed)
        {
            List<RBookings> bookingList = new List<RBookings>();
            try
            {
                string SQLstr = GetMasterBookingsforDateSQL(ddate, confirmed);
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
                            DBSDirectPayment = CheckBool(dr["DBSDirectPayment"]),
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

                        objContact.FullName = objContact.LastName + ", " + objContact.FirstName;
                        if (objContact.Suffix != "") objContact.FullName += " " + objContact.Suffix;

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
                    + "DBSDirectPayment,"
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
                    + "@DBSDirectPayment,"
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
                CmdAddContact.Parameters.Add("@DBSDirectPayment", SqlDbType.Bit);

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
                CmdAddContact.Parameters["@DBSDirectPayment"].Value = CheckVals(contactObj.DBSDirectPayment);
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
                       + "DBSDirectPayment = @DBSDirectPayment, "
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
                CmdUpdateContact.Parameters.Add("@DBSDirectPayment", SqlDbType.Bit);

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
                CmdUpdateContact.Parameters["@DBSDirectPayment"].Value = CheckVals(contactObj.DBSDirectPayment);
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

        #endregion

        #region SQLQueries

        private string GetAvailabilitySQL(DateTime weekbegining)
        {
            string monday = weekbegining.ToString("yyyyMMdd");
            string tuesday = weekbegining.AddDays(1).ToString("yyyyMMdd");
            string wednesday = weekbegining.AddDays(2).ToString("yyyyMMdd");
            string thursday = weekbegining.AddDays(3).ToString("yyyyMMdd");
            string friday = weekbegining.AddDays(4).ToString("yyyyMMdd");

            string SQLstr = "Select Lastname+', '+FirstName as Teacher,Live, Wants,[ContactData].YearGroup,QTS,ProofofAddress,NoGo, " +
                            "OverseasTrainedTeacher, NQT, TA, QNN, SEN, NN, " +
                            "Nur,Rec,Yr1,Yr2,Yr3,Yr4,Yr5,Yr6, " +
                            "s1.School as Monday, g1.gar as MonG, s2.School as Tuesday, g2.gar as TueG, s3.School as Wednesday, " +
                            "g3.gar as WedG, s4.School as Thursday, g4.gar as ThuG, s5.School as Friday, g5.gar as FriG,  " +
                            "s1.Color as MonColor, s2.Color as TueColor, s3.Color as WedColor, s4.Color as ThuColor, s5.Color  as FriColor, " +
                            "s1.BookingStatus as MonStatus, s2.BookingStatus as TueStatus, s3.BookingStatus as WedStatus, s4.BookingStatus as ThuStatus, s5.BookingStatus  as FriStatus " +
                            "FROM [Contacts] " +

                            "LEFT JOIN [ContactData] " +
                            "ON [Contacts].contactID = [ContactData].ContactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus " +
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
                            "SELECT COUNT(ID) as gar , TeacherID " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + monday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g1 ON g1.TeacherID = [Contacts].contactID " +

                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus " +
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
                            "SELECT COUNT(ID) as gar , TeacherID " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + tuesday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g2 ON g2.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus " +
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
                            "SELECT COUNT(ID) as gar , TeacherID " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + wednesday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g3 ON g3.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus " +
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
                            "SELECT COUNT(ID) as gar , TeacherID " +
                            "FROM GuaranteedDays " +
                            "WHERE CONVERT(VARCHAR(10), GuaranteedDays.Date, 112) = '" + thursday + "' " +
                            "GROUP BY TeacherID " +
                            ") AS g4 ON g4.TeacherID = [Contacts].contactID " +


                            "LEFT JOIN " +
                            "( " +
                            "SELECT [Bookings].Description as School , [MasterBookings].contactID, Color, BookingStatus " +
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
                            "SELECT COUNT(ID) as gar , TeacherID " +
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
            SQL += "SELECT SchoolName, FirstName, LastName, s.numDays, s1.Description as Monday, s2.Description as Tuesday, ";
            SQL += "s3.Description as Wednesday, s4.Description as Thursday, s5.Description as Friday, Cast(ROUND(total/numDays, 2) as decimal(18,2)) as srate,  ";
            SQL += "Cast(Round(total,2) as decimal(18,2)) as TotalCost, ";
            SQL += "Charge-Cast(ROUND(total/numDays, 2) as decimal(18,2)) as Margin,Charge,  numDays*Charge as Revenue, (numDays*Charge)-total as TMargin ";
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
            SQL += "SELECT Description, MasterBookingID, Rate ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + monday + "' ";
            SQL += ") As s1 ";
            SQL += "ON s1.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + tuesday + "' ";
            SQL += ") As s2 ";
            SQL += "ON s2.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + wednesday + "' ";
            SQL += ") As s3 ";
            SQL += "ON s3.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + thursday + "' ";
            SQL += ") As s4 ";
            SQL += "ON s4.MasterBookingID = [MasterBookings].ID ";

            SQL += "Left JOIN  ";
            SQL += "( ";
            SQL += "SELECT Description, MasterBookingID, Rate ";
            SQL += "FROM Bookings ";
            SQL += "WHERE Date = '" + friday + "' ";
            SQL += ") As s5 ";
            SQL += "ON s5.MasterBookingID = [MasterBookings].ID ";

            SQL += "LEFT JOIN [Contacts] ";
            SQL += "ON MasterBookings.contactID = [Contacts].contactID ";

            SQL += "LEFT JOIN [Schools]  ";
            SQL += "ON MasterBookings.SchoolID = [Schools].ID ";
            SQL += "WHERE isAbsence != 1 ";

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
            SQL += "ORDER BY contactID, Rate ";

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
            SQL += "ORDER BY contactID, Rate  ";

            return SQL;
        }

        private string GetTimeSheetSQL(DateTime dStart, string schoolID)
        {
            string start = dStart.ToString("yyyy-MM-dd");
            string dEnd = dStart.AddDays(4).ToString("yyyy-MM-dd");

            string SQL = "";
            SQL += "SELECT  Date, ";
            SQL += "[Bookings].Charge as DayRate, [Bookings].MasterBookingID, SchoolName, LastName+', ' +FirstName as FullName ";
            SQL += "FROM Bookings  ";
            SQL += "LEFT JOIN MasterBookings ON MasterBookings.ID = MasterBookingID ";
            SQL += "LEFT JOIN [Contacts] ON MasterBookings.contactID = [Contacts].contactID  ";
            SQL += "LEFT JOIN [Schools]  ON MasterBookings.SchoolID = [Schools].ID  ";
            SQL += "WHERE (Date >= '" + start + "' ) AND (Date <= '" + dEnd + "') ";
            SQL += "AND ( isAbsence != 1) AND (MasterBookings.SchoolID = '" + schoolID + "') ";
            SQL += "ORDER BY [Bookings].MasterBookingID, [Bookings].Charge, [Bookings].Date ";
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
            string SQLstr = " SELECT MasterBookings.ID, SchoolID, SchoolName as School, MasterBookings.contactID, MasterBookings.BookingStatus," +
                            "LastName+', '+FirstName as TeacherName, Details, [MasterBookings].StartDate, [MasterBookings].EndDate, isAbsence, AbsenceReason, " +
                            "HalfDay, LongTerm, Nur, Rec, Yr1, Yr2, Yr3, Yr4, Yr5, Yr6, [MasterBookings].QTS,[MasterBookings].NQT, OTT, TA,SEN, QNN, NN, PPL, " +
                            "Charge, LinkedTeacherID,NameGiven,AskedFor,TrialDay, LinkedTeacherName, Color " +

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
                         "LastName+', ' + FirstName as FullName, BookingStatus " +
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

        private string GetMasterBookingsforDateSQL(string ddate, bool confirmed)
        {
            string SQL = "SELECT [Schools].SchoolName, Bookings.Date, Contacts.LastName+', '+Contacts.FirstName as FullName,  " +
                        "[Bookings].Description, MasterBookings.ID as MasterBookingID, Contacts.contactID, Schools.ID as SchoolID , BookingStatus " +
                        "FROM MasterBookings " +
                        "Left JOIN [Bookings] ON MasterBookingID = MasterBookings.ID " +
                        "Left Join [Schools] ON Schools.ID = MasterBookings.SchoolID " +
                        "Left Join [Contacts] on MasterBookings.contactID = Contacts.contactID " +
                        "WHERE [Bookings].Date = '" + ddate + "'";
            if (confirmed)
            {
                SQL += " AND MasterBookings.BookingStatus = 'Confirmed'  ";
            }



            return SQL;
        }

        private string GetCheckDoubleBookingsSQL()
        {
            string SQL = "SELECT Contacts.contactID as contID, FirstName, LastName, s1.num, s1.Date " +
                        "FROM Contacts " +
                        "JOIN " +
                        "( " +
                        "SELECT  [Date], COUNT(Date) as num, [MasterBookings].contactID  " +
                        "FROM [RedboxDB2].[dbo].[Bookings] " +
                        "LEFT JOIN [MasterBookings] ON MasterBookingID = MasterBookings.ID " +
                        "GROUP BY Date, [MasterBookings].contactID " +
                        ") as s1 ON s1.ContactID = Contacts.contactID  " +
                        "WHERE s1.num > 1 ";
            return SQL;
        }

        private string GetUnassignedBookingsSQL(string dtStart, string dtEnd)
        {
            string SQL = "SELECT [Bookings].ID, MasterBookingID, Description, Date, [MasterBookings].contactID, SchoolID, SchoolName, " +
                         "LastName+', ' + FirstName as FullName , BookingStatus " +
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


    }
}
