using RedboxAddin.BL;
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
    public partial class frmBookingOverTime : Form
    {
        #region Variables
        RedBoxDB db;
        long masterbookingID = 0;
        long bookingID = 0;
        string validateErrorMessage = "Can not save. Please check following field(s)\n";
        decimal originalRate = 0;
        decimal originalCharge = 0;
        bool halfday = false;
        #endregion


        #region Form Load
        public frmBookingOverTime()
        {
            InitializeComponent();
        }

        public frmBookingOverTime(long masterbookingID, long bookingID, decimal charge, decimal rate, bool halfDay)
        {
            InitializeComponent();
            this.masterbookingID = masterbookingID;
            this.bookingID = bookingID;
            this.originalCharge = charge;
            this.originalRate = rate;
            this.halfday = halfDay;
        }

        private void frmBookingOverTime_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                ClearFields();
                FillDetails();
            }
            catch (Exception ex) //ASK : My debug message format seperated by ':' 
            {
                Debug.DebugMessage(2, "Error in frmBookingOverTime_Load: " + ex.Message);
            }
        }
        #endregion

        #region Button Clicks
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckNumberValidity())
                {
                    BookingOverTime oBOT;
                    bool isUpdate = false;

                    BookingOverTime oBookingOverTime = db.BookingOverTimes.Where(p => p.MasterBookingID == masterbookingID && p.BookingID == bookingID).SingleOrDefault();
                    if (oBookingOverTime != null) //ToDDo: Check For IDs as wel if necessary
                    {
                        oBOT = oBookingOverTime;
                        isUpdate = true;
                    }
                    else
                    {
                        oBOT = new BookingOverTime();
                    }

                    oBOT.MasterBookingID = masterbookingID;
                    oBOT.BookingID = bookingID;
                    oBOT.RateAdditional = decimal.Parse(txtRate.Text.Trim());
                    oBOT.ChargeAdditional = decimal.Parse(txtCharge.Text.Trim());
                    oBOT.Hours = int.Parse(txtHours.Text.Trim());
                    oBOT.Minutes = int.Parse(txtMinutes.Text.Trim());
                    oBOT.Notes = txtNotes.Text.Trim();
                    oBOT.IsCredit = chkIsCredit.Checked;

                    if (isUpdate)
                    {
                        db.SubmitChanges();
                        this.Close();
                    }
                    else
                    {
                        db.BookingOverTimes.InsertOnSubmit(oBOT);
                        db.SubmitChanges();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show(validateErrorMessage, "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmBookingOverTime_Load: " + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will delete the entire booking from the system. There is no UNDO option.\r" +
               "Press OK to Delete, or Cancel to cancel deleting.", "Redbox Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (DeleteBooking()) this.Close();
                else MessageBox.Show("Deletion Failed!");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fileds
        private void ClearFields()
        {
            txtRate.Text = "0.00";
            txtCharge.Text = "0.00";
            lblRate.Text = "0.00";
            lblCharge.Text = "0.00";
            txtHours.Text = "00";
            txtMinutes.Text = "00";
            txtNotes.Clear();
            chkIsCredit.Checked = false;
        }
        #endregion

        #region Fill Details
        private void FillDetails()
        {
                lblCharge.Text = originalCharge.ToString();
                lblRate.Text = originalRate.ToString();
            BookingOverTime oBookingOverTime = db.BookingOverTimes.Where(p => p.MasterBookingID == masterbookingID && p.BookingID == bookingID).SingleOrDefault();
            if (oBookingOverTime != null) //ToDDo: Check For IDs as wel if necessary
            {
                txtRate.Text = oBookingOverTime.RateAdditional.ToString();
                txtCharge.Text = oBookingOverTime.ChargeAdditional.ToString();
                txtHours.Text = oBookingOverTime.Hours.ToString();
                txtMinutes.Text = oBookingOverTime.Minutes.ToString();
                txtNotes.Text = oBookingOverTime.Notes;
                chkIsCredit.Checked = oBookingOverTime.IsCredit;
            }
        }
        #endregion       

        #region Check Validity
        private bool CheckNumberValidity()
        {
            bool bStatus = true;
            validateErrorMessage = "Can not save. Please check following field(s)\n";
            try
            {
                decimal d;
                int i;
                if (!(decimal.TryParse(txtRate.Text, out d)))
                {
                    bStatus = false;
                    validateErrorMessage += "Rate\n";
                }

                if (!(decimal.TryParse(txtCharge.Text, out d)))
                {
                    bStatus = false;
                    validateErrorMessage += "Charge\n";
                }                

                if (!(int.TryParse(txtHours.Text, out i)))
                {
                    bStatus = false;
                    validateErrorMessage += "Hours\n";
                }
                else 
                {
                    i = int.Parse(txtHours.Text);
                    if (i > 24)
                    {
                        bStatus = false;
                        validateErrorMessage += "Hours\n";
                    }                    
                }

                if (!(int.TryParse(txtMinutes.Text, out i)))
                {
                    bStatus = false;
                    validateErrorMessage += "Minutes\n";
                }
                else
                {
                    i = int.Parse(txtMinutes.Text);
                    if (i > 60)
                    {
                        bStatus = false;
                        validateErrorMessage += "Minutes\n";
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckNumberValidity : " + ex.Message);
            }
            return bStatus;
        }
        #endregion       

        #region Delete Booking
        private bool DeleteBooking()
        {
            BookingOverTime oBookingOverTime = db.BookingOverTimes.Where(p => p.MasterBookingID == masterbookingID && p.BookingID == bookingID).SingleOrDefault();
            if (oBookingOverTime != null) //ToDDo: Check For IDs as wel if necessary
            {
                db.BookingOverTimes.DeleteOnSubmit(oBookingOverTime);
                db.SubmitChanges();
                return true;
            }
            else
                return false;
        } 
        #endregion


    }
}
