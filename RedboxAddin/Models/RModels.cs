using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedboxAddin.Models
{
    class RMasterBooking
    {
        public long ID { get; set; }
        public long SchoolID { get; set; }
        public string School { get; set; }
        public long ContactID { get; set; }
        public string TeacherName { get; set; }
        public string Details { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isAbsence { get; set; }
        public string AbsenceReason { get; set; }
        public bool HalfDay { get; set; }
        public bool LongTerm { get; set; }
        public bool Nur { get; set; }
        public bool Rec { get; set; }
        public bool Yr1 { get; set; }
        public bool Yr2 { get; set; }
        public bool Yr3 { get; set; }
        public bool Yr4 { get; set; }
        public bool Yr5 { get; set; }
        public bool Yr6 { get; set; }
        public bool QTS { get; set; }
        public bool NQT { get; set; }
        public bool OTT { get; set; }
        public bool TA { get; set; }
        public bool NN { get; set; }
        public bool QNN { get; set; }
        public bool SEN { get; set; }
        public Decimal Charge { get; set; }
        public long LinkedTeacherID { get; set; }
        public string LinkedTeacherName { get; set; }
        public bool NameGiven { get; set; }
        public bool AskedFor { get; set; }
        public bool TrialDay { get; set; }





    }

    class RAvailability
    {
        public string Teacher { get; set; }
        public string Live { get; set; }
        public string Wants { get; set; }
        public string YrGroup { get; set; }
        public string QTS { get; set; }
        public string Pay { get; set; }
        public string PofA { get; set; }
        public string CRB { get; set; }
        public string NoGo { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
    }

    class RLoad
    {
        public string School { get; set; }
        public string Name { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Charge { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public Decimal Margin { get; set; }
    }

    class RBookings
    {
        public string School { get; set; }
        public string KeyRef { get; set; }
        public string Teacher { get; set; }
        public string Days { get; set; }
        public string Pay { get; set; }
        public string Charge { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Margin { get; set; }
        public string Cost { get; set; }
        public string Net { get; set; }
    }

    public class RNames
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
    }

    public class RReminder
    {
        public DateTime DueDate { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public long contactID { get; set; }
        public long reminderID { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CompletedBy { get; set; }
    }

    public class RAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
    }
}
