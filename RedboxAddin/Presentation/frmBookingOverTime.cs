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
            if (halfday) chkHalfDay.Checked = true;
        }

        private void frmBookingOverTime_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                CheckOvertime();
                ClearFields();
                FillDetails();
                RefreshView();
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
            if (radOT.Checked)
            {
                SaveAdditionalHours();
            }
            else
            {
                ReviseBookingRates();
            }

        }

        private void SaveAdditionalHours()
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
                    //oBOT.IsCredit = chkIsCredit.Checked;

                    Booking bk = db.Bookings.Where(p => p.ID == bookingID).SingleOrDefault();
                    bk.IsOverTimeAvailable = true;
                    bk.Notes = txtNotes.Text.Trim();

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
                Debug.DebugMessage(2, "Error in SaveAdditionalHours: " + ex.Message);
            }
        }

        private void ReviseBookingRates()
        {
            try
            {
                if (CheckNumberValidity())
                {

                    Booking bk = db.Bookings.Where(p => p.ID == bookingID).SingleOrDefault();
                    bk.Notes = txtNotes.Text.Trim();
                    bk.Description = bk.Description + " ( " + txtNotes.Text.Trim() + " )";
                    if (bk.Description.Length > 200) bk.Description = bk.Description.Substring(0, 199);
                    bk.Rate = decimal.Parse(txtRate.Text.Trim());
                    bk.Charge = decimal.Parse(txtCharge.Text.Trim());
                    bk.Hours = int.Parse(txtHours.Text);
                    bk.Minutes = int.Parse(txtMinutes.Text);

                    db.SubmitChanges();
                    this.Close();
                }
                else
                    MessageBox.Show(validateErrorMessage, "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SaveAdditionalHours: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will delete the Overtime details from the system. There is no UNDO option.\r" +
               "Press OK to Delete, or Cancel to cancel deleting.", "Redbox Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (DeleteOvertime()) this.Close();
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
            lblRateValue.Text = "0.00";
            lblChargeValue.Text = "0.00";
            txtHours.Text = "00";
            txtMinutes.Text = "00";
            txtNotes.Clear();
            //chkIsCredit.Checked = false;
        }
        #endregion

        #region Fill Details

        private void CheckOvertime()
        {
            BookingOverTime oBookingOverTime = db.BookingOverTimes.Where(p => p.MasterBookingID == masterbookingID && p.BookingID == bookingID).SingleOrDefault();
            if (oBookingOverTime != null)
            {
                radOT.Checked = true;
            }
            else
            {
                radSick.Checked = true;
            }

        }
        private void FillDetails()
        {
            ClearFields();
            if (radOT.Checked)
            {
                FillOvertimeDetails();
            }
            else
            {
                FillReducedHoursDetails();
            }
        }
        private void FillOvertimeDetails()
        {
            lblChargeValue.Text = originalCharge.ToString();
            lblRateValue.Text = originalRate.ToString();

            BookingOverTime oBookingOverTime = db.BookingOverTimes.Where(p => p.MasterBookingID == masterbookingID && p.BookingID == bookingID).SingleOrDefault();
            if (oBookingOverTime != null) //ToDDo: Check For IDs as wel if necessary
            {
                txtRate.Text = oBookingOverTime.RateAdditional.ToString();
                txtCharge.Text = oBookingOverTime.ChargeAdditional.ToString();
                txtHours.Text = oBookingOverTime.Hours.ToString();
                txtMinutes.Text = oBookingOverTime.Minutes.ToString();
                txtNotes.Text = oBookingOverTime.Notes;
                //chkIsCredit.Checked = oBookingOverTime.IsCredit;
            }

        }

        private void FillReducedHoursDetails()
        {
            lblChargeValue.Text = originalCharge.ToString();
            lblRateValue.Text = originalRate.ToString();

            Booking bkg = db.Bookings.Where(p => p.ID == bookingID).SingleOrDefault();
            if (bkg != null)
            {
                if (bkg.Hours != null) txtHours.Text = bkg.Hours.ToString();
                if (bkg.Minutes != null) txtMinutes.Text = bkg.Minutes.ToString();
                radSick.Checked = true;
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
        private bool DeleteOvertime()
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

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void txtMinutes_TextChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void radOTSick_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails();
            RefreshView();
            CalcHours();
        }

        private void chkHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            CalcHours();
        }

        private void CalcHours()
        {
            if (radOT.Checked)
            {
                CalcAdditionalHours();
            }
            else
            {
                CalcRevisedHours();
            }
        }

        private void CalcAdditionalHours()
        {
            try
            {
                double hours = 6.5;
                if (chkHalfDay.Checked) hours = 3.25;

                Double hourlyCharge = ((double)originalCharge) / hours;
                Double hourlyrate = (double)originalRate / hours;

                Double actualHours;
                bool ok1 = double.TryParse(txtHours.Text, out actualHours);
                if (!ok1) actualHours = 0;
                Double actualMins;
                bool ok2 = double.TryParse(txtMinutes.Text, out actualMins);
                if (!ok2) actualMins = 0;

                Double addRate = (hourlyrate * actualHours) + (hourlyrate * actualMins / 60);
                Double addCharge = (hourlyCharge * actualHours) + (hourlyCharge * actualMins / 60);

                txtRate.Text = addRate.ToString("N2");
                txtCharge.Text = addCharge.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation Error: " + ex.Message);
            }
        }

        private void CalcRevisedHours()
        {
            try
            {
                double hours = 6.5;
                double margin = 35;
                if (chkHalfDay.Checked) hours = 3.25;

                Double hourlyCharge = ((double)originalCharge - margin) / hours;
                Double hourlyrate = (double)originalRate / hours;

                Double actualHours;
                bool ok1 = double.TryParse(txtHours.Text, out actualHours);
                if (!ok1) actualHours = 0;
                Double actualMins;
                bool ok2 = double.TryParse(txtMinutes.Text, out actualMins);
                if (!ok2) actualMins = 0;

                Double revisedRate = (hourlyrate * actualHours) + (hourlyrate * actualMins / 60);
                Double revisedCharge = (hourlyCharge * actualHours) + (hourlyCharge * actualMins / 60) + margin;
                if (actualHours == 0) revisedCharge = 0;

                txtRate.Text = revisedRate.ToString("N2");
                txtCharge.Text = revisedCharge.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation Error: " + ex.Message);
            }
        }

        private void RefreshView()
        {
            if (radOT.Checked)
            {
                lblRate.Text = "Additional Rate";
                lblCharge.Text = "Additional Charge";
                lblInfo.Text = "Add New Line with Overtime worked";
                lblInfo.BackColor = Color.LightGreen;
            }
            else
            {
                lblRate.Text = "Revised Rate";
                lblCharge.Text = "Revised Charge";
                lblInfo.Text = "Update Booking Rate based on Hours worked";
                lblInfo.BackColor = Color.Orange;
            }
        }



    }
}
