using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedboxAddin.BL;

namespace RedboxAddin.DL
{
    static class LINQmanager
    {

        //public static string GetMasterBookingStatus(string teachername, string bookingdate, string description)
        //{
        //    try
        //    {
        //        List<long> MasterBookingIDs = GetMasterBookingIDs(teachername, bookingdate, description);

        //        if (MasterBookingIDs.Count > 0)
        //        {
        //        }

        //        return "returned value";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "error";
        //    }
        //}

        public static List<long> GetMasterBookingIDs(string teacher, string bookingdate, string description)
        {
            List<long> IDs = new List<long>();
            try
            {
                DateTime bdate = Convert.ToDateTime(bookingdate).Date;

                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    ////Determine if teacher name exists
                    //bool TeacherNameFound = !string.IsNullOrWhiteSpace(teacher.Replace(',', ' '));
                    long teacherID = -1;
                    //if (TeacherNameFound)
                    //{
                    //    string[] name = teacher.Split(',');
                    //    string lastname = name[0].Trim();
                    //    string firstname = name[1].Trim();

                    //    //get teacherID from teachername
                    //    var teachers = db.Contacts.Where(s => s.FirstName == firstname && s.LastName == lastname).First();
                    //    teacherID = teachers.ContactID;
                    //}

                    if (string.IsNullOrWhiteSpace(teacher)) return null;
                    else
                    {
                        try
                        {
                            teacherID = Convert.ToInt64(teacher);
                        }
                        catch
                        {
                            teacherID = -1;
                        }
                    }

                    if (teacherID == -1)
                    {
                        return null;
                    }

                    //get bookings ID from description and date
                    var bkgs = (from bk in db.Bookings
                                where bk.Date == bdate && bk.Description == description
                                join mb in db.MasterBookings on bk.MasterBookingID equals mb.ID
                                select new { bk.MasterBookingID, mb.ContactID }).ToList();

                    foreach (var bb in bkgs)
                    {
                        try
                        {
                            long id = Convert.ToInt64(bb.MasterBookingID);
                            //if (TeacherNameFound)
                            //{
                                if (bb.ContactID == teacherID) IDs.Add(id);
                            //}
                            //else IDs.Add(id);
                        }
                        catch { }
                    }
                    return IDs;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetMasterBookingID: " + ex.Message);
                return IDs;
            }
        }



        public static bool SetBookingStatus(long masterBookingID, string status)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var mb = db.MasterBookings.FirstOrDefault(s => s.ID == masterBookingID);

                    if (mb != null)
                    {
                        mb.BookingStatus = status;
                        mb.Color = Utils.SetColours(status, mb.AskedFor, mb.LongTerm, null);
                        db.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SetBookingStatus: " + ex.Message);
                return false;
            }
        }

        public static void CheckAndUpdateTeachers()
        {
            //Process the Contact database and update the ContactData table
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var contacts = db.Contacts;

                    foreach (Contact cc in contacts)
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

        public static void ImportContacts()
        {
            //Process the teacher database and update the ContactData table
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var contacts = db.Contacts;

                    foreach (Contact cc in contacts)
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
                Debug.DebugMessage(2, "Error in ImportContacts: " + ex.Message);
            }
        }

        public static string GetNoGoforContactID(long teacherID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.ContactDatas.FirstOrDefault(s => s.ContactID == teacherID);

                    if (cd == null) return "";
                    else return cd.NoGo;
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetNoGoforContactID: " + ex.Message);
                return "";
            }
        }


        public static string GetShortNameforSchoolID(long schoolID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.Schools.FirstOrDefault(s => s.ID == schoolID);

                    if (cd == null) return "";
                    else return cd.ShortName;
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetShortNameforSchoolID: " + ex.Message);
                return "";
            }
        }

        public static School GetSchoolbyID(long schoolID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.Schools.FirstOrDefault(s => s.ID == schoolID);

                    if (cd == null) return null;
                    else return cd;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetSchoolbyID: " + ex.Message);
                return null;
            }
        }

        public static Contact GetContactbyID(long contactID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.Contacts.FirstOrDefault(s => s.ContactID == contactID);

                    if (cd == null) return null;
                    else return cd;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetContactbyID: " + ex.Message);
                return null;
            }
        }

        public static MasterBooking GetMasterBookingbyID(long masterBookingID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var mb = db.MasterBookings.FirstOrDefault(s => s.ID == masterBookingID);

                    if (mb == null) return null;
                    else return mb;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetMasterBookingbyID: " + ex.Message);
                return null;
            }
        }

        public static Booking GetBookingbyID(long BookingID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var bb = db.Bookings.FirstOrDefault(s => s.ID == BookingID);

                    if (bb == null) return null;
                    else return bb;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetBookingbyID: " + ex.Message);
                return null;
            }
        }

        public static string GetEmailAddressforSchoolID(long schoolID)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.Schools.FirstOrDefault(s => s.ID == schoolID);

                    if (cd == null) return "";
                    else return cd.EmailAddress;
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetShortNameforSchoolID: " + ex.Message);
                return "";
            }
        }

        public static List<string> GetPaymentTypes()
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var pt = (from n in db.PaymentTypes select n);
                    List<string> pt2 = new List<string>();
                    foreach (RedboxAddin.PaymentType type in pt) pt2.Add(type.Name.ToString().Trim());

                    return pt2;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetSchoolbyID: " + ex.Message);
                return null;
            }
        }

        public static string GetRate(long masterBookingID, long? contactID)
        {
            if (contactID == null) return "0.00";

            MasterBooking mb = GetMasterBookingbyID(masterBookingID);
            long schoolID = mb.SchoolID;
            School sch = GetSchoolbyID(schoolID);
            string rateType = sch.RateType;
            if (rateType == null) rateType = "TeacherRate";

            decimal? rate = null;

            string rateName = "";
            try
            {
                if (mb.TA)
                {
                    //TA
                    if (mb.HalfDay)
                    {
                        //HalfDay
                        if (mb.LongTerm)
                        {
                            //LongTerm
                            rateName = "HalfDayRateLTTA";
                        }
                        else
                        {
                            rateName = "HalfDayRateTA";
                        }
                    }
                    else
                    {
                        //FullDay
                        if (mb.LongTerm)
                        {
                            //LongTerm
                            rateName = "DayRateLTTA";
                        }
                        else
                        {
                            rateName = "DayRateTA";
                        }
                    }
                }
                else
                {
                    //Teacher
                    if (mb.HalfDay)
                    {
                        //Half Day
                        if (mb.LongTerm)
                        {
                            //LongTerm
                            rateName = "HalfDayRateLT";
                        }
                        else
                        {
                            rateName = "HalfDayRate";
                        }
                    }
                    else
                    {
                        //Full Day
                        if (mb.LongTerm)
                        {
                            //LongTerm
                            rateName = "DayRateLT";
                        }
                        else
                        {
                            rateName = "DayRate";
                        }
                    }
                }

                if (rateType == "TeacherRate")
                {
                    rate = LINQmanager.GetRateForContact(contactID, rateName);
                }
                else if (rateType == "SchoolRate")
                {
                    rate = LINQmanager.GetRateForSchool(schoolID, rateName);
                }
                else if (rateType == "CalcRate")
                {
                    rate = LINQmanager.GetChargeForSchool(schoolID, rateName) - 35;
                }
                else
                {
                    throw new Exception("Error in GetRate(): Invalid rateType: " + rateType);
                }
                return rate.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetRate(): " + ex.Message);

            }
            return null;
        }

        public static decimal? GetRateForContact(long? contactID, string requiredRate)
        {
            if (contactID == null) return (Decimal)0.00;
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var cd = db.ContactDatas.FirstOrDefault(s => s.ContactID == contactID);

                    if (cd == null) return null;

                    switch (requiredRate)
                    {
                        case "DayRate":
                            return cd.DayRate;
                            break;
                        case "HalfDayRate":
                            return cd.HalfDayRate;
                            break;
                        case "DayRateLT":
                            return cd.DayRateLT;
                            break;
                        case "HalfDayRateLT":
                            return cd.HalfDayRateLT;
                            break;
                        case "DayRateTA":
                            return cd.DayRateTA;
                            break;
                        case "HalfDayRateTA":
                            return cd.HalfDayRateTA;
                            break;
                        case "DayRateLTTA":
                            return cd.DayRateLTTA;
                            break;
                        case "HalfDayRateLTTA":
                            return cd.HalfDayRateLTTA;
                            break;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetRateForContact: " + ex.Message);
                return null;
            }
        }

        public static decimal? GetRateForSchool(long schoolID, string requiredRate)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var sd = db.Schools.FirstOrDefault(s => s.ID == schoolID);

                    if (sd == null) return null;

                    switch (requiredRate)
                    {
                        case "DayRate":
                            return sd.DayRate;
                            break;
                        case "HalfDayRate":
                            return sd.HalfDayRate;
                            break;
                        case "DayRateLT":
                            return sd.DayRateLT;
                            break;
                        case "HalfDayRateLT":
                            return sd.HalfDayRateLT;
                            break;
                        case "DayRateTA":
                            return sd.TADayRate;
                            break;
                        case "HalfDayRateTA":
                            return sd.TAHalfDayRate;
                            break;
                        case "DayRateLTTA":
                            return sd.TADayRateLT;
                            break;
                        case "HalfDayRateLTTA":
                            return sd.TAHalfDayRateLT;
                            break;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetRateForSchool: " + ex.Message);
                return null;
            }
        }

        public static decimal? GetChargeForSchool(long schoolID, string requiredRate)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var sd = db.Schools.FirstOrDefault(s => s.ID == schoolID);

                    if (sd == null) return null;

                    switch (requiredRate)
                    {
                        //Although this says day Rate we want the CHARGE in each case as we will calculate rate as Charge -35
                        case "DayRate":
                            return sd.DayCharge;
                            break;
                        case "HalfDayRate":
                            return sd.HalfDayCharge;
                            break;
                        case "DayRateLT":
                            return sd.DayChargeLT;
                            break;
                        case "HalfDayRateLT":
                            return sd.HalfDayChargeLT;
                            break;
                        case "DayRateTA":
                            return sd.TADayCharge;
                            break;
                        case "HalfDayRateTA":
                            return sd.TAHalfDayCharge;
                            break;
                        case "DayRateLTTA":
                            return sd.TADayRateLT;
                            break;
                        case "HalfDayRateLTTA":
                            return sd.TAHalfDayRateLT;
                            break;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetRateForSchool: " + ex.Message);
                return null;
            }
        }


    }
}
