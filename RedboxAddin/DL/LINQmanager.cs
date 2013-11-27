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

        public static List<long> GetMasterBookingIDs(string teachername, string bookingdate, string description)
        {
            List<long> IDs = new List<long>();
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    string[] name = teachername.Split(',');
                    string lastname = name[0].Trim();
                    string firstname = name[1].Trim();
                    DateTime bdate = Convert.ToDateTime(bookingdate).Date;

                    //get teacherID from teachername
                    var teachers = db.Contacts.Where(s => s.FirstName == firstname && s.LastName == lastname);

                    foreach (Contact cc in teachers)
                    {
                        //get Masterbooking ID from name and date
                        var bkgs = db.MasterBookings.Where(m => m.ContactID == cc.ContactID && m.StartDate >= bdate && m.EndDate <= bdate);

                        foreach (MasterBooking mb in bkgs)
                        {
                            //get masterbooking ID from bookingID
                            IDs.Add(mb.ID);
                        }

                    }
                }
                return IDs;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetMasterBookingID: " + ex.Message);
                return IDs;
            }
        }

        public static void CheckAndUpdateTeachers()
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
    }
}
