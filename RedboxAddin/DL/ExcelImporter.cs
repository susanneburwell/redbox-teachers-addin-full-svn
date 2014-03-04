using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

using RedboxAddin.BL;
using RedboxAddin.Models;
using System.Windows.Forms;

namespace RedboxAddin.DL
{
    static class ExcelImporter
    {

        public static List<string> GetColumnNames(string filepath)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [" + sheets.First() + "]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            List<string> list = new List<string>();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                //startdate is the date for the first (Monday) column
                string first = "";
                string second = "";
                string third = "";
                string fourth = "";
                string fifth = "";
                try
                {
                    first = dt.Columns[0].ColumnName;
                    list.Add(first);
                }
                catch { }
                try
                {
                    second = dt.Columns[1].ColumnName;
                    list.Add(second);
                }
                catch { }
                try
                {
                    third = dt.Columns[2].ColumnName;
                    list.Add(third);
                }
                catch { }
                try
                {
                    fourth = dt.Columns[3].ColumnName;
                    list.Add(fourth);
                }
                catch { }
                try
                {
                    fifth = dt.Columns[4].ColumnName;
                    list.Add(fifth);
                }
                catch { }

                return list;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error getting headers from Exel: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static string GetNameForRow(string filepath, int firstrownumber, int lastrownumber)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [" + sheets.First() + "]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                string fullname1 = "";
                string fullname2 = "";
                try { fullname1 = dt.Rows[firstrownumber][0].ToString(); }
                catch { }
                try { fullname2 = dt.Rows[lastrownumber][0].ToString(); }
                catch { }

                return fullname1 + "/" + fullname2;

            }
            catch (Exception ex1)
            {
                Debug.DebugMessage(2, "Error in GetNameForRow: " + ex1.Message);
                return "";
            }
        }

        public static void Import(string filepath, bool setTA, bool setTeacher, bool setCurrent, int startrow, int endrow)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [" + sheets.First() + "]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                //startdate is the date for the first (Monday) column
                DateTime monday;
                DateTime tuesday;
                DateTime wednesday;
                DateTime thursday;
                DateTime friday;
                try
                {
                    monday = Convert.ToDateTime(dt.Columns[11].ColumnName).Date;
                    tuesday = Convert.ToDateTime(dt.Columns[12].ColumnName).Date;
                    wednesday = Convert.ToDateTime(dt.Columns[13].ColumnName).Date;
                    thursday = Convert.ToDateTime(dt.Columns[14].ColumnName).Date;
                    friday = Convert.ToDateTime(dt.Columns[15].ColumnName).Date;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error - Could not retrieve the dates to import to. Import aborted.");
                    return;
                }

                List<RAvailability> listA = new List<RAvailability>();
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                DBManager.OpenDBConnection();
                DBManager dbm = new DBManager();

                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    for (int iRow = startrow; iRow < endrow; iRow++)
                    {
                        try
                        {
                            //get contact id from full name
                            string fullname = dt.Rows[iRow][0].ToString();
                            long contactID = dbm.GetContactIDfromFullName(fullname);

                            if (contactID == -1)   //-1 == not found
                            {
                                Debug.DebugMessage(2, "Importing: Contact Name not found: " + fullname);
                                continue;
                            }
                            else
                            {
                                //create contact data
                                ContactData cd = new ContactData();
                                cd.ContactID = contactID;
                                cd.Live = Utils.CheckString(dt.Rows[iRow][3]);
                                cd.NoGo = Utils.CheckString(dt.Rows[iRow][10]);
                                Decimal dayrate = Utils.GetDayRate(dt.Rows[iRow][7]);
                                if (dayrate > 0) cd.DayRate = dayrate;
                                //cd.Pay = Utils.CheckString(dt.Rows[iRow][7]);
                                //cd.PofA = Utils.CheckBool(dt.Rows[iRow][8]);
                                cd.Wants = Utils.CheckString(dt.Rows[iRow][4]);
                                cd.YearGroup = Utils.CheckString(dt.Rows[iRow][5]);
                                cd.Nur = Utils.CheckBool(dt.Rows[iRow][18]);
                                cd.Rec = Utils.CheckBool(dt.Rows[iRow][19]);
                                cd.Yr1 = Utils.CheckBool(dt.Rows[iRow][20]);
                                cd.Yr2 = Utils.CheckBool(dt.Rows[iRow][21]);
                                cd.Yr3 = Utils.CheckBool(dt.Rows[iRow][22]);
                                cd.Yr4 = Utils.CheckBool(dt.Rows[iRow][23]);
                                cd.Yr5 = Utils.CheckBool(dt.Rows[iRow][24]);
                                cd.Yr6 = Utils.CheckBool(dt.Rows[iRow][25]);
                                cd.Teacher = Utils.CheckBool(dt.Rows[iRow][26]);
                                cd.TA = Utils.CheckBool(dt.Rows[iRow][27]);
                                cd.Current = Utils.CheckBool(dt.Rows[iRow][28]);

                                //if (setTA) cd.TA = true;
                                //if (setTeacher) cd.Teacher = true;
                                //if (setCurrent) cd.Current = true;

                                //Find SEN, QNN, TA, in year Group
                                if (cd.YearGroup.IndexOf("QNN") > -1) cd.QNN = true;
                                if (cd.YearGroup.IndexOf("SEN") > -1) cd.SEN = true;
                                //if (Utils.CheckString(dt.Rows[iRow][7].ToString()).IndexOf("TA") > -1) cd.TA = true;


                                db.ContactDatas.InsertOnSubmit(cd);
                                db.SubmitChanges();

                            }

                            //create master bookings - Mon
                            MasterBooking mb;
                            Dictionary<int, string> apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][11].ToString());
                            if (apptData.Count > 0)
                            {
                                mb = new MasterBooking();
                                mb.ContactID = contactID;
                                mb.YearGroup = Utils.CheckString(dt.Rows[iRow][5].ToString());
                                mb.TeacherLevel = dt.Rows[iRow][6].ToString();
                                mb.StartDate = monday;
                                mb.EndDate = monday;
                                if (apptData.Count > 0) mb.SchoolID = dbm.GetSchoolIDfromName(apptData[1]);
                                mb.Charge = Utils.CheckDecimal("170.00");
                                mb.Details = dt.Rows[iRow][11].ToString();
                                mb.LongTerm = Utils.CheckBool(dt.Rows[iRow][29]);

                                db.MasterBookings.InsertOnSubmit(mb);
                                db.SubmitChanges();

                                Booking bb = new Booking();
                                bb.MasterBookingID = mb.ID;
                                bb.Date = monday;
                                bb.Charge = mb.Charge;
                                bb.Rate = Utils.CheckDecimal(dt.Rows[iRow][7].ToString());
                                bb.Description = mb.Details;
                                db.Bookings.InsertOnSubmit(bb);
                                db.SubmitChanges();
                            }

                            //create master bookings - Tue
                            //check if it already exists
                            apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][12].ToString());
                            if (apptData.Count > 0)
                            {
                                mb = null;
                                try
                                {
                                    mb = db.MasterBookings.Where(b => b.ContactID == contactID && b.EndDate == monday).First();
                                }
                                catch { }
                                if (mb == null)
                                {
                                    mb = new MasterBooking();
                                    mb.ContactID = contactID;
                                    mb.YearGroup = Utils.CheckString(dt.Rows[iRow][5].ToString());
                                    mb.TeacherLevel = dt.Rows[iRow][6].ToString();
                                    mb.StartDate = tuesday;
                                    mb.EndDate = tuesday;
                                    if (apptData.Count > 0) mb.SchoolID = dbm.GetSchoolIDfromName(apptData[1]);
                                    mb.Charge = Utils.CheckDecimal("170.00");
                                    mb.Details = dt.Rows[iRow][12].ToString();

                                    db.MasterBookings.InsertOnSubmit(mb);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    mb.EndDate = tuesday;
                                }

                                Booking bb = new Booking();
                                bb.MasterBookingID = mb.ID;
                                bb.Date = tuesday;
                                bb.Charge = mb.Charge;
                                bb.Rate = Utils.CheckDecimal(dt.Rows[iRow][7].ToString());
                                bb.Description = mb.Details;
                                db.Bookings.InsertOnSubmit(bb);
                                db.SubmitChanges();
                            }

                            //create master bookings - Wed
                            //check if it already exists
                            apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][13].ToString());
                            if (apptData.Count > 0)
                            {
                                mb = null;
                                try
                                {
                                    mb = db.MasterBookings.Where(b => b.ContactID == contactID && b.EndDate == tuesday).First();
                                }
                                catch { }
                                if (mb == null)
                                {
                                    mb = new MasterBooking();
                                    apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][13].ToString());
                                    mb.ContactID = contactID;
                                    mb.YearGroup = Utils.CheckString(dt.Rows[iRow][5].ToString());
                                    mb.TeacherLevel = dt.Rows[iRow][6].ToString();
                                    mb.StartDate = wednesday;
                                    mb.EndDate = wednesday;
                                    if (apptData.Count > 0) mb.SchoolID = dbm.GetSchoolIDfromName(apptData[1]);
                                    mb.Charge = Utils.CheckDecimal("170.00");
                                    mb.Details = dt.Rows[iRow][13].ToString();

                                    db.MasterBookings.InsertOnSubmit(mb);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    mb.EndDate = wednesday;
                                }

                                Booking bb = new Booking();
                                bb.MasterBookingID = mb.ID;
                                bb.Date = wednesday;
                                bb.Charge = mb.Charge;
                                bb.Rate = Utils.CheckDecimal(dt.Rows[iRow][7].ToString());
                                bb.Description = mb.Details;
                                db.Bookings.InsertOnSubmit(bb);
                                db.SubmitChanges();
                            }

                            //create master bookings - thur
                            //check if it already exists
                            apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][12].ToString());
                            if (apptData.Count > 0)
                            {
                                mb = null;
                                try
                                {
                                    mb = db.MasterBookings.Where(b => b.ContactID == contactID && b.EndDate == wednesday).First();
                                }
                                catch { }
                                if (mb == null)
                                {
                                    mb = new MasterBooking();
                                    apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][14].ToString());
                                    mb.ContactID = contactID;
                                    mb.YearGroup = Utils.CheckString(dt.Rows[iRow][5].ToString());
                                    mb.TeacherLevel = dt.Rows[iRow][6].ToString();
                                    mb.StartDate = thursday;
                                    mb.EndDate = thursday;
                                    if (apptData.Count > 0) mb.SchoolID = dbm.GetSchoolIDfromName(apptData[1]);
                                    mb.Charge = Utils.CheckDecimal("170.00");
                                    mb.Details = dt.Rows[iRow][14].ToString();

                                    db.MasterBookings.InsertOnSubmit(mb);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    mb.EndDate = thursday;
                                }
                                Booking bb = new Booking();
                                bb.MasterBookingID = mb.ID;
                                bb.Date = thursday;
                                bb.Charge = mb.Charge;
                                bb.Rate = Utils.CheckDecimal(dt.Rows[iRow][7].ToString());
                                bb.Description = mb.Details;
                                db.Bookings.InsertOnSubmit(bb);
                                db.SubmitChanges();
                            }

                            //create master bookings - frid
                            //check if it already exists
                            apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][12].ToString());
                            if (apptData.Count > 0)
                            {
                                mb = null;
                                try
                                {
                                    mb = db.MasterBookings.Where(b => b.ContactID == contactID && b.EndDate == thursday).First();
                                }
                                catch { }
                                if (mb == null)
                                {
                                    mb = new MasterBooking();
                                    apptData = Utils.ExtractAppointmentData(dt.Rows[iRow][15].ToString());
                                    mb.ContactID = contactID;
                                    mb.YearGroup = Utils.CheckString(dt.Rows[iRow][5].ToString());
                                    mb.TeacherLevel = dt.Rows[iRow][6].ToString();
                                    mb.StartDate = friday;
                                    mb.EndDate = friday;
                                    if (apptData.Count > 0) mb.SchoolID = dbm.GetSchoolIDfromName(apptData[1]);
                                    mb.Charge = Utils.CheckDecimal("170.00");
                                    mb.Details = dt.Rows[iRow][15].ToString();

                                    db.MasterBookings.InsertOnSubmit(mb);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    mb.EndDate = friday;
                                }

                                Booking bb = new Booking();
                                bb.MasterBookingID = mb.ID;
                                bb.Date = friday;
                                bb.Charge = mb.Charge;
                                bb.Rate = Utils.CheckDecimal(dt.Rows[iRow][7].ToString());
                                bb.Description = mb.Details;
                                db.Bookings.InsertOnSubmit(bb);
                                db.SubmitChanges();
                            }
                        }
                        catch (Exception ex1)
                        {
                            Debug.DebugMessage(2, "Error updating database: " + ex1.Message);
                        }

                    }
                }
                return;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error importing from Exel: " + ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool ImportSchools(string filepath)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [" + sheets.First() + "]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                string CONNSTR = DavSettings.getDavValue("CONNSTR");

                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        try
                        {
                            //create School
                            School school = new School();
                            school.SchoolName = Utils.CheckString(dt.Rows[iRow][0].ToString());
                            school.ShortName = Utils.CheckString(dt.Rows[iRow][1].ToString());
                            school.DayCharge = Utils.CheckDecimal(dt.Rows[iRow][2].ToString());
                            school.HalfDayCharge = Utils.CheckDecimal(dt.Rows[iRow][3].ToString());
                            school.DayChargeLT = Utils.CheckDecimal(dt.Rows[iRow][4].ToString());
                            school.HalfDayChargeLT = Utils.CheckDecimal(dt.Rows[iRow][5].ToString());

                            db.Schools.InsertOnSubmit(school);
                            db.SubmitChanges();

                        }
                        catch (Exception ex1)
                        {
                            Debug.DebugMessage(2, "Error updating database: " + ex1.Message);
                        }

                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error importing schools: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool ImportKeyRefs(string filepath)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [Key Refs$]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                string CONNSTR = DavSettings.getDavValue("CONNSTR");

                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    for (int iRow = 0; iRow < iRowCount; iRow++)
                    {
                        try
                        {
                            //create School
                            string fn = Utils.CheckString(dt.Rows[iRow][2].ToString());
                            string ln = Utils.CheckString(dt.Rows[iRow][1].ToString());

                            Contact contact = db.Contacts.Where(c => c.FirstName == fn && c.LastName == ln).FirstOrDefault();
                            if (contact == null)
                            {
                                Debug.DebugMessage(2, "Import KeyRefs: Contact Not Found: " + fn + " " + ln);
                            }
                            else
                            {
                                contact.KeyRef = Utils.CheckString(dt.Rows[iRow][0].ToString());
                            }

                            db.SubmitChanges();

                        }
                        catch (Exception ex1)
                        {
                            Debug.DebugMessage(2, "Error updating database(ImportKeyRef): " + ex1.Message);
                        }

                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error ImportKeyRef: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static IEnumerable<string> GetExcelSheetNames(string excelFile)
        {
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties=Excel 12.0;";
            //var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //      "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            using (var connection = new OleDbConnection(connStr))
            {
                connection.Open();
                using (var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
                {
                    return (dt ?? new DataTable())
                        .Rows
                        .Cast<DataRow>()
                        .Select(row => row["TABLE_NAME"].ToString());
                }
            }
        }

        public static void CheckNamesInExcel(string filepath)
        {
            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM [" + sheets.First() + "]"; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;


                List<RAvailability> listA = new List<RAvailability>();
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                DBManager.OpenDBConnection();
                DBManager dbm = new DBManager();

                string MissingNames = "";

                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    for (int iRow = 0; iRow < iRowCount ; iRow++)
                    {
                        try
                        {
                            //get contact id from full name
                            string fullname = dt.Rows[iRow][0].ToString();
                            long contactID = dbm.GetContactIDfromFullName(fullname);

                            if (contactID == -1)   //-1 == not found
                            {
                                MissingNames += fullname + "\r\n";
                                continue;
                            }
                        }
                        catch { }
                    }
                }

                //save file to temp folder
                string tempfolder = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\Davton";
                if (!Directory.Exists(tempfolder)) Directory.CreateDirectory(tempfolder);

                string tempfilepath = tempfolder + "\\" + "UnMatched_Names.txt";

                System.IO.StreamWriter myFile = new StreamWriter(tempfilepath, false);

                myFile.Write(MissingNames);
                myFile.Flush();
                myFile.Close();
                System.Diagnostics.Process.Start(tempfilepath);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error CheckNamesInExcel: " + ex.Message);
            }
        }
    }
}
