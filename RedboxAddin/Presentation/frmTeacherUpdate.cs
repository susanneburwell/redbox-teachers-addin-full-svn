using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;

namespace RedboxAddin.Presentation
{
    public partial class frmTeacherUpdate : Form
    {

        RedBoxDB db;
        long _teacherID;

        public frmTeacherUpdate()
        {
            InitializeComponent();
        }

        private void frmTeacherUpdate_Load(object sender, EventArgs e)
        {
            gcGuaranteed.DataSource = bindingSource1;


            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                //PopulateTeacher(cmbTeacher);
                Utils.PopulateTeacher(cmbTeacher);

                if (_teacherID != 0) LoadTeacherDates(_teacherID);

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

        }

        //private void PopulateTeacher(ComboBox cmb1)
        //{
        //    try
        //    {
        //        var q = from s in db.Contacts
        //                where s.LastName != null && s.c
        //                orderby s.LastName
        //                select new { FullName = (s.LastName + ',' + ' ' + s.FirstName), s.ContactID };
        //        //select new CHTest { FullName = (s.LastName + ','+' ' + s.FirstName),ContactID= s.ContactID };
        //        var schools = q.ToList();

        //        cmb1.DataSource = schools;
        //        cmb1.DisplayMember = "FullName";
        //        cmb1.ValueMember = "ContactID";
        //        cmb1.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
        //    }
        //}

        private void LoadTeacherDates(Int64 teacherID)
        {
            try
            {
                DBManager dbm = new DBManager();
                List<RTeacherday> teacherdays = dbm.GetTeacherDays(teacherID, chkPast.Checked, chkFuture.Checked, chkShowGuarantees.Checked);

                gcGuaranteed.DataSource = teacherdays;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTeacherDates: " + ex.Message);
            }
        }

        private bool SaveRequest()
        {
            try
            {
                //Check dates are valid
                if (dtTo.Value < dtFrom.Value)
                {
                    MessageBox.Show("Your end date can not be earlier than your start date.");
                    return false;
                }

                if ((dtTo.Value == null) || (dtFrom.Value == null))
                {
                    MessageBox.Show("Please pick a start and end date.");
                    return false;
                }


                DateTime bookingdate = dtFrom.Value.Date;
                int iCatch = 0;
                string action;

                //If Guaranteed Days
                if (radGuar.Checked)
                {
                    do
                    {
                        //Create a new Guaranteed Day
                        action = "Creating Guaranteed Day";
                        GuaranteedDay gd = new GuaranteedDay();

                        
                        gd.Date = bookingdate;
                        gd.Note = txtDetails.Text;
                        gd.TeacherID = Utils.CheckLong(cmbTeacher.SelectedValue);

                        //don't add twice
                        var numFound = db.GuaranteedDays.Count(g => g.Date == bookingdate && g.TeacherID == gd.TeacherID );
                        if (numFound == 0)   db.GuaranteedDays.InsertOnSubmit(gd);

                        bookingdate = bookingdate.AddDays(1);
                        iCatch += 1;
                        if (iCatch > 365)
                        {
                            MessageBox.Show("There was an error while " + action + "Too many created.");
                            Debug.DebugMessage(2, "Overflow error while " + action);
                            return false;
                        }


                    } while (bookingdate <= dtTo.Value.Date);
                    db.SubmitChanges();

                }

                //If Registering Absence
                else
                {
                    //Create a new MasterBooking
                    action = "Registering Teacher Absence";

                    MasterBooking mb = new MasterBooking();
                    mb.StartDate = dtFrom.Value.Date;
                    mb.EndDate = dtTo.Value.Date;
                    mb.ContactID = Utils.CheckLong(cmbTeacher.SelectedValue);
                    mb.IsAbsence = true;
                    if (radAA.Checked) mb.Details = "AA: " + txtDetails.Text;
                    if (radAAL.Checked) mb.Details = "AAL: " + txtDetails.Text;
                    if (radSick.Checked) mb.Details = "Sick: " + txtDetails.Text;
                    if (radOther.Checked) mb.Details = "Absence: " + txtDetails.Text;

                    db.MasterBookings.InsertOnSubmit(mb);
                    db.SubmitChanges();

                    //Create individual day bookings
                    do
                    {
                        Booking bb = new Booking();
                        bb.MasterBookingID = mb.ID;
                        bb.Date = bookingdate;
                        bb.Description = mb.Details;

                        db.Bookings.InsertOnSubmit(bb);

                        bookingdate = bookingdate.AddDays(1);
                        iCatch += 1;
                        if (iCatch > 365)
                        {
                            MessageBox.Show("There was an error while " + action + "Too many created.");
                            Debug.DebugMessage(2, "Overflow error while " + action);
                            return false;
                        }

                    } while (bookingdate <= dtTo.Value.Date);

                    db.SubmitChanges();

                }




                return true;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Teacher Update: Error SaveRequest: " + ex.Message);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRequest();
            LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
        }

        private void radAbs_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAbsenceVisibility();
        }

        private void UpdateAbsenceVisibility()
        {
            if (radAbs.Checked) grpAbsence.Visible = true;
            else grpAbsence.Visible = false;
        }

         private void cmbTeacher_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
        }

         private void chkFuture_CheckedChanged(object sender, EventArgs e)
         {
             LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
         }

         private void chkPast_CheckedChanged(object sender, EventArgs e)
         {
             LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
         }

         private void dtFrom_ValueChanged(object sender, EventArgs e)
         {
             dtTo.Value = dtFrom.Value;
         }


    }
}
