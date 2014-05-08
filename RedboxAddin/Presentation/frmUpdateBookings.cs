using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.DL;

namespace RedboxAddin
{
    public partial class frmUpdateBookings : Form
    {
        public string rate;
        public string charge;
        public string description;
        public string masterID;


        public frmUpdateBookings()
        {
            InitializeComponent();
        }

        private void frmUpdateBookings_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            txtRate.Text = rate;
            txtCharge.Text = charge;
            txtDescription.Text = description;
        }

        private void radUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (radUpdate.Checked)
            {
                lblAction.Text = "Update Bookings";
                btnUpdate.Text = "Update";
                grpSet.Visible = true;
            }
            else
            {
                lblAction.Text = "Delete Bookings";
                btnUpdate.Text = "Delete";
                grpSet.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (radUpdate.Checked)
                {
                    string _rate = (chkRate.Checked) ? txtRate.Text : null;
                    string _charge = (chkCharge.Checked) ? txtCharge.Text : null;
                    string _description = (chkDescription.Checked) ? txtDescription.Text : null;
                    DBManager dbm = new DBManager();
                    int updateCount = dbm.UpdateBookingsFromDate(masterID, dateTimePicker1.Value.ToString("yyyy-MM-dd"), _rate, _charge, _description);
                    if (updateCount >= 0)
                    {
                        MessageBox.Show(updateCount.ToString() + " bookings were updated.");
                        this.Close();
                    }
                    else MessageBox.Show("The update failed. ");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You are about to DELETE bookings. There is NO undo option",
                        "Delete Bookings?", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        DBManager dbm = new DBManager();
                        int updateCount = dbm.DeleteBookingsFromDate(masterID, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        if (updateCount >= 0)
                        {
                            MessageBox.Show(updateCount.ToString() + " bookings were Deleted.");
                            this.Close();
                        }
                        else MessageBox.Show("The update failed. ");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Bookings. (" + ex.Message + ")");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblFrom.Text = "From " + dateTimePicker1.Value.ToLongDateString();
        }
    }
}
