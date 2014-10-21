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
        #endregion


        #region Form Load
        public frmChangeTeacher()
        {
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
        }

        public frmChangeTeacher(DateTime selectedDate, long masterBookingID)
        {
            InitializeComponent();
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);
                this.selectedDate = selectedDate;
                this.masterBookingID = masterBookingID;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmChangeTeacher Load(DateTime selectedDate, long masterBookingID): " + ex.Message);
            }
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
            if (IsCalshing())
            {
                //if there are clashes, show the msg in red (same msg like in master booking)
                //this needs to be clear after another teacher is selected
                lblError.Visible = true;
            }
            else
            {
                MasterBooking oMasterBooking = db.MasterBookings.Where(p => p.ID == this.masterBookingID).SingleOrDefault();
                if (oMasterBooking != null)
                {
                    oMasterBooking.ContactID = Utils.CheckLong(cmbTeacher.SelectedValue);
                    db.SubmitChanges();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsCalshing()
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

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
