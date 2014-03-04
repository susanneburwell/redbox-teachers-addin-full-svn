﻿using System;
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

        public static List<long> GetMasterBookingIDs(string teachername, string bookingdate, string description)
        {
            List<long> IDs = new List<long>();
            try
            {
                DateTime bdate = Convert.ToDateTime(bookingdate).Date;

                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    //Determine if teacher name exists
                    bool TeacherNameFound = !string.IsNullOrWhiteSpace(teachername.Replace(',', ' '));
                    long teacherID = -1;
                    if (TeacherNameFound)
                    {
                        string[] name = teachername.Split(',');
                        string lastname = name[0].Trim();
                        string firstname = name[1].Trim();

                        //get teacherID from teachername
                        var teachers = db.Contacts.Where(s => s.FirstName == firstname && s.LastName == lastname).First();
                        teacherID = teachers.ContactID;
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
                            if (TeacherNameFound)
                            {
                                if (bb.ContactID == teacherID) IDs.Add(id);
                            }
                            else IDs.Add(id);
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

                    return pt2 ;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetSchoolbyID: " + ex.Message);
                return null;
            }
        }

        public static decimal? GetRateForContact(long contactID, string requiredRate)
        {
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
                Debug.DebugMessage(2, "Error in GetContactbyID: " + ex.Message);
                return null;
            }
        }
    
    }
}
