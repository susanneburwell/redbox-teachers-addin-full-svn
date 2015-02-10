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
        RedBoxDB db;
        DateTime selectedDate = new DateTime(2000, 01, 01);
        long masterBookingID = -1;
        long schoolID = -1;
        bool formLoading = true;
        #endregion


        #region Form Load
        public frmChangeTeacher()
        {
            formLoading = true;
            InitializeComponent();

            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmChangeTeacher Load: " + ex.Message);
            }
            formLoading = false;
        }

        public frmChangeTeacher(DateTime selectedDate, long masterBookingID)
        {
            formLoading = true;
            InitializeComponent();
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);
                this.selectedDate = selectedDate;
                this.masterBookingID = masterBookingID;
                MasterBooking mb = LINQmanager.GetMasterBookingbyID(masterBookingID);
                schoolID = mb.SchoolID;
                lblOrigRate.Text = LINQmanager.GetRate(masterBookingID, mb.ContactID);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmChangeTeacher Load(DateTime selectedDate, long masterBookingID): " + ex.Message);
            }
            formLoading = false;
        }

        private void frmChangeTeacher_Load(object sender, EventArgs e)
        {
            //populate teachers
            formLoading = true;
            Utils.PopulateTeacher(cmbTeacher, true);
            formLoading = false;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check for clashes
            if (IsClashing())
            {
                //if there are clashes, show the msg in red (same msg like in master booking)
                //this needs to be clear after another teacher is selected
                lblError.Visible = true;
            }
            else if (IsNogo())
            {
                MessageBox.Show("There is a NoGo for that Teacher and School.", "Can not save changes");
            }

            else
            {
                MasterBooking oMasterBooking = db.MasterBookings.Where(p => p.ID == this.masterBookingID).SingleOrDefault();
                if (oMasterBooking != null)
                {
                    //update Masterbooking
                    oMasterBooking.ContactID = Utils.CheckLong(cmbTeacher.SelectedValue);
                    oMasterBooking.BookingStatus = "Unassigned";
                    //LINQmanager.SetBookingStatus(oMasterBooking.ID, "Unassigned");
                    db.SubmitChanges();

                    //if rate has changed - update bookings
                    if (lblOrigRate.Text != lblNewRate.Text)
                    {
                        DBManager dbm = new DBManager();
                        int result = dbm.UpdateBookings(this.masterBookingID, null, lblNewRate.Text, null);
                        if (result == -1) MessageBox.Show("Error updating bookings");
                        else if (result == 1) MessageBox.Show("1 booking updated");
                        else MessageBox.Show(result.ToString() + " bookings updated");
                    }

                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsClashing()
        {
            bool isClashing = false;

            try
            {
                DataTable dtClashingBookings = new DBManager().GetClashingBookingDetailsForUpdate(this.masterBookingID, Utils.CheckLong(cmbTeacher.SelectedValue));
                if (dtClashingBookings != null && dtClashingBookings.Rows.Count > 0)
                    isClashing = true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmChangeTeacher IsCalshing(frmChangeTeacher) : " + ex.Message);
            }
            return isClashing;
        }

        private bool IsNogo()
        {
            //School school = cmbTeacher.SelectedItem as School;
            //string strTeacherID = cmbTeacher.Value;
            long teacherID = Utils.CheckLong(cmbTeacher.SelectedValue);
            string nogo = LINQmanager.GetNoGoforContactID(teacherID).ToLower();
            if (nogo == "")
            {
                lblNogo.Text = " - ";
                return false;
            }
            else lblNogo.Text = nogo;
            string shortname = LINQmanager.GetShortNameforSchoolID(schoolID).ToLower();
            if (shortname == "") return false;

            if (nogo.Contains(shortname))
            {
                MessageBox.Show(cmbTeacher.Text + " has a NoGo flagged for " + shortname, "NoGo Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!formLoading)
            {
                IsNogo();
                long teacherID = Utils.CheckLong(cmbTeacher.SelectedValue);
                lblNewRate.Text = LINQmanager.GetRate(masterBookingID, teacherID);

            }
        }
    }
}
