using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.DL;

namespace RedboxAddin.Presentation
{
    public partial class frmEditBooking : Form
    {
        long _bookingID;
        string _teacher = null;
        string _school = null;
        string _date = null;


        public frmEditBooking(long id, string teacher, string school, string date)
        {
            InitializeComponent();
            _bookingID = id;
            _teacher = teacher;
            _school = school;
            _date = date;
        }

        private void frmEditBooking_Load(object sender, EventArgs e)
        {
            try
            {
                Booking bb = LINQmanager.GetBookingbyID(_bookingID);
                if (bb == null)
                {
                    MessageBox.Show("The booking could not be retrieved");
                    this.Close();
                }
                else
                {

                    lblDate.Text = _date;
                    lblSchool.Text = _school;
                    lblTeacher.Text = _teacher;

                    txtDescription.Text = bb.Description;
                    txtCharge.Text = bb.Charge.ToString();
                    txtRate.Text = bb.Rate.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int response = new DBManager().UpdateBooking(_bookingID, txtDescription.Text, txtRate.Text, txtCharge.Text);
            }
            catch (Exception ex)
            {
                
            }
        }


    }
}
