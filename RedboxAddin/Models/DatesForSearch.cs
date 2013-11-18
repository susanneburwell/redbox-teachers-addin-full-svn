using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedboxAddin.Models
{
    public class DatesForSearch
    {
        private DateTime _PreviousWeekStartDate;

        public DateTime PreviousWeekStartDate
        {
            get { return _PreviousWeekStartDate; }
            set { _PreviousWeekStartDate = value; }
        }
        private DateTime _PreviousWeekEndDate;

        public DateTime PreviousWeekEndDate
        {
            get { return _PreviousWeekEndDate; }
            set { _PreviousWeekEndDate = value; }
        }
        private DateTime _ThisWeekStartDate;

        public DateTime ThisWeekStartDate
        {
            get { return _ThisWeekStartDate; }
            set { _ThisWeekStartDate = value; }
        }
        private DateTime _ThisWeekEndDate;

        public DateTime ThisWeekEndDate
        {
            get { return _ThisWeekEndDate; }
            set { _ThisWeekEndDate = value; }
        }

        private DateTime _NextWeekEndDate;

        public DateTime NextWeekEndDate
        {
            get { return _NextWeekEndDate; }
            set { _NextWeekEndDate = value; }
        }

        private DateTime _NextWeekStartDate;

        public DateTime NextWeekStartDate
        {
            get { return _NextWeekStartDate; }
            set { _NextWeekStartDate = value; }
        }

    }
}
