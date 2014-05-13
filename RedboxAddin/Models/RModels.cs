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
        public bool PPL { get; set; }
        public Decimal Charge { get; set; }
        public long LinkedTeacherID { get; set; }
        public string LinkedTeacherName { get; set; }
        public bool NameGiven { get; set; }
        public bool AskedFor { get; set; }
        public bool TrialDay { get; set; }
        public string Color { get; set; }
        public string BookingStatus { get; set; }
    }

    class RAvailability
    {
        public string Teacher { get; set; }
        public string Live { get; set; }
        public string Location { get; set; }
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
        public string Guar { get; set; }
        public string LongTerm { get; set; }
        public string MonColor { get; set; }
        public string TueColor { get; set; }
        public string WedColor { get; set; }
        public string ThuColor { get; set; }
        public string FriColor { get; set; }
        public string MonStatus { get; set; }
        public string TueStatus { get; set; }
        public string WedStatus { get; set; }
        public string ThuStatus { get; set; }
        public string FriStatus { get; set; }
        public bool FirstAid { get; set; }
        public bool RWInc { get; set; }
        public bool BSL { get; set; }

    }

    class RTimeSheet
    {
        public long ID { get; set; }
        public string SchoolName { get; set; }
        public string FullName { get; set; }
        public string days { get; set; }
        public int numDays { get; set; }
        public string Description { get; set; }
        public Decimal DayRate { get; set; }
        public Decimal Total { get; set; }
    }

    class RLoad
    {
        public string SchoolName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int numDays { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public Decimal srate { get; set; }
        public Decimal TotalCost { get; set; }
        public Decimal Margin { get; set; }
        public Decimal Charge { get; set; }
        public Decimal Revenue { get; set; }
        public Decimal TMargin { get; set; }
    }

    class RPivotLoad
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
        public string SchoolName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ContactID { get; set; }
        public string SchoolID { get; set; }
        public string Teacher { get; set; }
        public long MasterBookingID { get; set; }
        public string BookingStatus { get; set; }
        public bool Selected { get; set; }
    }

    class RDoubleBookings
    {
        public string ContactID { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
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

    public class RTeacherday
    {
        public Int64 ID { get; set; }
        public DateTime dte { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }

    public class REventArgs: EventArgs
    {
        public string Teacher { get; set; }
        public string ColumnCaption { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public long[] SelectedRows { get; set; }
        public bool isGuarantee { get; set; }
    }

    public class Payment
    {
        public long ID { get; set; }
        public string PayDetails { get; set; }
        public string AgencyRef { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string WeekEnding { get; set; }
        public int TotalDays { get; set; }
        public decimal Rate { get; set; }
        public decimal AdditionalPayment { get; set; }

    }

    public class InvoiceLine
    {
        public string WeekEnding { get; set; }
        public string SageAcctRef { get; set; }
        public string Address { get; set; }
        public string PayDetails { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int TotalDays { get; set; }
        public decimal Charge { get; set; }

    }

}
