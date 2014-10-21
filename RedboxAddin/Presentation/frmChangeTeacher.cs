using RedboxAddin.BL;
using RedboxAddin.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedboxAddin.Presentation
{
    public partial class frmChangeTeacher : Form
    {
        #region Variables
        DateTime selectedDate = new DateTime(2000, 01, 01);
        long masterBookingID = -1;
        #endregion


        #region Form Load
        public frmChangeTeacher()
        {
            InitializeComponent();
        }

        public frmChangeTeacher(DateTime selectedDate, long masterBookingID)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
            this.masterBookingID = masterBookingID;
        }

        private void frmChangeTeacher_Load(object sender, EventArgs e)
        {
            //populate teachers
            Utils.PopulateTeacher(cmbTeacher, true);
        } 
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check for clashes

            //if there are clashes, show the msg in red (same msg like in master booking)
                //this needs to be clear after another teacher is selected

            //save

            //refresh availability grid after saving

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsCalshing()
        {
            bool isClashing = false;

            DataTable dtClashingBookings = new DBManager().GetClashingBookingDetails(selectedDate, selectedDate, Utils.CheckLong(cmbTeacher.SelectedValue));
            if (dtClashingBookings != null)
            {
                foreach (DataRow row in dtClashingBookings.Rows)
                {
                    DateTime bookingDate = DateTime.Parse(row["Date"].ToString());
                    if (bookingDate.Date == this.selectedDate.Date)
                    {
                        isClashing = true;
                        break;
                    }
                   
                }
            }

            return isClashing;
        }
    }
}
