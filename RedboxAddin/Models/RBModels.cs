using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

//THis clsss was made by copying entity framework created classes


namespace RedboxAddin.Models
{
    public partial class AbsenceReason
    {
        public long ID { get; set; }
        public string Reason { get; set; }
    }

    public partial class Booking
    {
        public long ID { get; set; }
        public Nullable<long> MasterBookingID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> am { get; set; }
        public Nullable<bool> pm { get; set; }

        public virtual MasterBooking MasterBooking { get; set; }
    }

    public partial class Category
    {
        [Key]
        public string CategoryName { get; set; }
    }

    public partial class MasterBooking
    {
        public MasterBooking()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public long ID { get; set; }
        public Nullable<long> SchoolID { get; set; }
        public Nullable<long> contactID { get; set; }
        public string YearGroup { get; set; }
        public string TeacherLevel { get; set; }
        public string Details { get; set; }
        public Nullable<bool> isAbsence { get; set; }
        public string AbsenceReason { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }

    public partial class NoGo
    {
        public long ID { get; set; }
        public Nullable<long> SchoolID { get; set; }
        public Nullable<long> TeacherID { get; set; }
        public string RequestedBy { get; set; }
    }

    public partial class School
    {
        public long ID { get; set; }
        public string SchoolName { get; set; }
    }

    public partial class TeacherLevel
    {
        public long ID { get; set; }
        public string level { get; set; }
    }

    public partial class YearGroup
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
