using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedboxAddin.Models
{
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
}
