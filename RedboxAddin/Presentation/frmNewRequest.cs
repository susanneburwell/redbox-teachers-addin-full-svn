﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Linq;
using RedboxAddin.BL;
using RedboxAddin.DL;
using DevExpress.XtraGrid.Views.Base;



namespace RedboxAddin.Presentation
{
    public partial class frmNewRequest : Form
    {
        RedBoxDB db;
        long masterBookingID;


        public frmNewRequest()
        {
            InitializeComponent();
        }

        private void frmNewRequest_Load(object sender, EventArgs e)
        {
            dgcBookings.DataSource = bindingSource1;

            dgcBookings.Hide();
            dgcAvail.Hide();
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                PopulateSchools();
                //PopulateYearGroup();
                //PopulateTeacherLevel();
                PopulateTeacher();

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

            LoadTable();
        }

        #region LoadControls

        private void PopulateSchools()
        {
            try
            {
                var q = from s in db.Schools
                        select s;
                var schools = q.ToList();
                cmbSchool.DataSource = schools;
                cmbSchool.DisplayMember = "SchoolName";
                cmbSchool.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        //private void PopulateYearGroup()
        //{
        //    try
        //    {
        //        List<YearGroup> ygs = db.YearGroups.ToList();
        //        cmbYearGroup.DataSource = ygs;
        //        cmbYearGroup.DisplayMember = "Name";
        //        cmbYearGroup.ValueMember = "Name";
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in PopulateYearGroup: " + ex.Message);
        //    }

        //}

        //private void PopulateTeacherLevel()
        //{
        //    try
        //    {
        //        List<TeacherLevel> tl = db.TeacherLevels.ToList();
        //        cmbTeacherLevel.DataSource = tl;
        //        cmbTeacherLevel.DisplayMember = "level";
        //        cmbTeacherLevel.ValueMember = "level";
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in PopulateTeacherLevel: " + ex.Message);
        //    }

        //}

        private void PopulateTeacher()
        {
            try
            {
                var q = from s in db.TblContacts
                        where s.LastName != null
                        orderby s.LastName
                        select new { FullName = (s.LastName + ' ' + s.FirstName), s.ContactID };
                var schools = q.ToList();
                cmbTeacherName.DataSource = schools;
                cmbTeacherName.DisplayMember = "FullName";
                cmbTeacherName.ValueMember = "ContactID";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        #endregion

        #region buttons

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGC();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
                dgcAvail.Show();
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }

        private void btnEY_Click(object sender, EventArgs e)
        {
            bool set = !chkNur.Checked;
            chkNur.Checked = set;
            chkRec.Checked = set;
            UpdateDescription();
        }

        private void btnKS1_Click(object sender, EventArgs e)
        {
            bool set = !chkYr1.Checked;
            chkYr1.Checked = set;
            chkYr2.Checked = set;
            UpdateDescription();
        }

        private void btnKS2_Click(object sender, EventArgs e)
        {
            bool set = !chkYr3.Checked;
            chkYr3.Checked = set;
            chkYr4.Checked = set;
            chkYr5.Checked = set;
            chkYr6.Checked = set;
            UpdateDescription();
        }

        private void cmbSchool_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChargeRate();
            UpdateDescription();
        }

        private void cmbTeacherLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void chkLongTerm_CheckedChanged(object sender, EventArgs e)
        {
            SetChargeRate();
            UpdateDescription();

        }

        private void chkHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            SetChargeRate();
            UpdateDescription();
        }

        private void btnEditDesc_Click(object sender, EventArgs e)
        {
            txtDescription.Visible = lblDescription.Visible;
            lblDescription.Visible = !txtDescription.Visible;
            if (txtDescription.Visible) txtDescription.Text = lblDescription.Text;
            
        }

        private void chkUpdate_Click(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void SetChargeRate()
        {
            try
            {
                long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                School school = db.Schools.Where<School>(s => s.ID == schoolID).FirstOrDefault();
                if (chkHalfDay.Checked)
                {
                    if (chkLongTerm.Checked) txtCharge.Text = school.HalfDayChargeLT.ToString();
                    else txtCharge.Text = school.HalfDayCharge.ToString();
                }
                else
                {
                    if (chkLongTerm.Checked) txtCharge.Text = school.DayChargeLT.ToString();
                    else txtCharge.Text = school.DayCharge.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SetChargeRate: " + ex.Message);
            }
        }

        private void frmNewRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
        }

        private void radNS_CheckedChanged(object sender, EventArgs e)
        {
            if (radNS.Checked) setTeacherControls(false);
            else setTeacherControls(true);
            UpdateDescription();
        }

        #endregion

        #region actions

        private bool SaveRequest()
        {
            try
            {

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


                MasterBooking mb;
                //If this is a new request - create a new item

                if (masterBookingID == 0) mb = new MasterBooking();

                else mb = db.MasterBookings.Where<MasterBooking>(b => b.ID == masterBookingID).FirstOrDefault();

                //Table<MasterBooking> mbs = db.GetTable<MasterBooking>();


                mb.SchoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                //mb.YearGroup = cmbYearGroup.Text;
                //mb.TeacherLevel = cmbTeacherLevel.Text;
                mb.StartDate = dtFrom.Value;
                mb.EndDate = dtTo.Value;
                mb.Details = txtDetails.Text;
                mb.HalfDay = chkHalfDay.Checked;
                mb.LongTerm = chkLongTerm.Checked;
                mb.Nur = chkNur.Checked;
                mb.Rec = chkRec.Checked;
                mb.Yr1 = chkYr1.Checked;
                mb.Yr2 = chkYr2.Checked;
                mb.Yr3 = chkYr3.Checked;
                mb.Yr4 = chkYr4.Checked;
                mb.Yr5 = chkYr5.Checked;
                mb.Yr6 = chkYr6.Checked;
                mb.Charge = Utils.CheckDecimal(txtCharge.Text);

                //If Teacher named
                mb.NameGiven = radNG.Checked;
                mb.AskedFor = radAF.Checked;
                mb.TrialDay = radTD.Checked;
                if (radNS.Checked == false) mb.LinkedTeacherID = Convert.ToInt64(cmbTeacherName.SelectedValue);
                else mb.LinkedTeacherID = -1;

                //If this is not a new booking, submit changes and exit
                if (masterBookingID != 0)
                {
                    db.SubmitChanges();
                    return true;
                }


                //This is a new Master booking so create new bookings
                db.MasterBookings.InsertOnSubmit(mb);
                db.SubmitChanges();

                if (mb.ID < 1)
                {
                    MessageBox.Show("There was an error creating the Master Booking.");
                    Debug.DebugMessage(2, "There was an error creating the Master Booking. MasterBookingID 0 or Null");
                    return false;

                }
                masterBookingID = mb.ID;

                //Create IndividualBookings
                DateTime bookingdate = (System.DateTime)mb.StartDate;
                int iCatch = 0;
                do
                {
                    //only create new booking if relevant day tickbox is ticked
                    if (CheckIfRequiredDay(bookingdate))
                    {
                        var nb = new Booking();
                        nb.MasterBookingID = mb.ID;
                        nb.Date = bookingdate;
                        nb.Charge = Utils.CheckDecimal(txtCharge.Text);
                        nb.Rate = Globals.TeacherDailyRate;
                        nb.HalfDay = chkHalfDay.Checked;
                        if (lblDescription.Visible) nb.Description = lblDescription.Text;
                        else nb.Description = txtDescription.Text;

                        db.Bookings.InsertOnSubmit(nb);
                    }

                    bookingdate = bookingdate.AddDays(1);
                    iCatch += 1;
                    if (iCatch > 365)
                    {
                        MessageBox.Show("There was an error creating the daily bookings. Too many booking created.");
                        Debug.DebugMessage(2, "Overflow error creating the daily bookings. MasterBookingID: " + mb.ID);
                        return false;
                    }

                } while (bookingdate <= mb.EndDate);

                db.SubmitChanges();


                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error saving new Request: " + ex.Message);
                return false;
            }
        }

        private void LoadTable()
        {
            try
            {
                //Get first day of week
                DateTime input = dtFrom.Value;
                int delta = DayOfWeek.Monday - input.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = input.AddDays(delta).Date;

                string wheresql = WHERESQL();
                //gridControl1.DataSource = new DBManager().GetAvailability(monday, wheresql);
                //gridView1.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                //gridView1.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                //gridView1.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                //gridView1.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                //gridView1.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");
                //RestoreLayout();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTable: " + ex.Message);
            }
        }

        private bool CheckIfRequiredDay(DateTime bookingdate)
        {
            try
            {
                //Get the day of week
                DayOfWeek dow = bookingdate.DayOfWeek;

                switch (dow)
                {
                    case DayOfWeek.Monday:
                        return chkMon.Checked;
                    case DayOfWeek.Tuesday:
                        return chkTue.Checked;
                    case DayOfWeek.Wednesday:
                        return chkWed.Checked;
                    case DayOfWeek.Thursday:
                        return chkThu.Checked;
                    case DayOfWeek.Friday:
                        return chkFri.Checked;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckIfRequiredDay: " + ex.Message);
                return false;
            }
        }

        private void UpdateDescription()
        {
            try
            {
                //get School short Name
                School sc = cmbSchool.SelectedItem as School;
                string shortname = sc.ShortName;


                //get Teacher Status
                //TeacherLevel tl = cmbTeacherLevel.SelectedItem as TeacherLevel;
                string teacherStatus = Utils.TeacherQuals(chkTA.Checked,chkQTS.Checked, chkNQT.Checked, chkOTT.Checked, chkQNN.Checked, chkNN.Checked, chkSEN.Checked);

                //Get AgeGroup
                string agegroup = Utils.YearGroup(chkNur.Checked, chkRec.Checked, chkYr1.Checked, chkYr2.Checked, chkYr3.Checked, chkYr4.Checked, chkYr5.Checked, chkYr6.Checked);
                //if (chkNur.Checked) agegroup += "Nur/";
                //if (chkRec.Checked) agegroup += "Rec/";
                //if (chkYr1.Checked) agegroup += "Yr1/";
                //if (chkYr2.Checked) agegroup += "Yr2/";
                //if (chkYr3.Checked) agegroup += "Yr3/";
                //if (chkYr4.Checked) agegroup += "Yr4/";
                //if (chkYr5.Checked) agegroup += "Yr5/";
                //if (chkYr6.Checked) agegroup += "Yr6";

                //agegroup = agegroup.Replace("Nur/Rec", "Nur-Rec");
                //agegroup = agegroup.Replace("Rec/Yr1", "Rec-Yr1");
                //agegroup = agegroup.Replace("Yr1/Yr2", "Yr1-Yr2");
                //agegroup = agegroup.Replace("Yr2/Yr3", "Yr2-Yr3");
                //agegroup = agegroup.Replace("Yr3/Yr4", "Yr3-Yr4");
                //agegroup = agegroup.Replace("Yr4/Yr5", "Yr4-Yr5");
                //agegroup = agegroup.Replace("Yr5/Yr6", "Yr5-Yr6");

                //agegroup = agegroup.Replace("-Rec-", "-");
                //agegroup = agegroup.Replace("-Yr1-", "-");
                //agegroup = agegroup.Replace("-Yr2-", "-");
                //agegroup = agegroup.Replace("-Yr3-", "-");
                //agegroup = agegroup.Replace("-Yr4-", "-");
                //agegroup = agegroup.Replace("-Yr5-", "-");

                //if (agegroup.Length > 0)
                //{
                //    if (agegroup.Substring(agegroup.Length - 1) == "/") agegroup = agegroup.Substring(0, agegroup.Length - 1);
                //}

                lblDescription.Text =   shortname + " " + teacherStatus + " " + agegroup;

                //Check Halfday
                if (chkHalfDay.Checked) lblDescription.Text += " 0.5";

                //check Long Term
                if (chkLongTerm.Checked) lblDescription.Text += " LT";

                if (radAF.Checked) lblDescription.Text = "AF " + lblDescription.Text;

                if (radTD.Checked) lblDescription.Text = "TD " + lblDescription.Text;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CreateDescription: " + ex.Message);
            }
        }
        
        #region DGC

        private void RefreshDGC()
        {
            BindGrid();
        }

        private void BindGrid()
        {
            try
            {

                //Table<Booking> bookingList = db.GetTable<Booking>();
                var bookingList = from b in db.Bookings
                                  where b.MasterBookingID == masterBookingID
                                  select b;
                bindingSource1.DataSource = bookingList;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in BindGrid: " + ex.Message);
            }
        }

        #endregion

        private void RestoreLayout()
        {
            try
            {
                ViewBookings.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\BookingsFormDump.xml");
            }
            catch (Exception) { }
        }

        private void SaveLayout()
        {
            try
            {
                ViewBookings.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\BookingsFormDump.xml");
            }
            catch (Exception) { }
        }

        private string WHERESQL()
        {
            try
            {
                string wheresql = "";

                if (chkNur.Checked) wheresql += "AND ([Nur] = 'true') ";
                if (chkRec.Checked) wheresql += "AND ([Rec] = 'true') ";
                if (chkYr1.Checked) wheresql += "AND ([Yr1] = 'true') ";
                if (chkYr2.Checked) wheresql += "AND ([Yr2] = 'true') ";
                if (chkYr3.Checked) wheresql += "AND ([Yr3] = 'true') ";
                if (chkYr4.Checked) wheresql += "AND ([Yr4] = 'true') ";
                if (chkYr5.Checked) wheresql += "AND ([Yr5] = 'true') ";
                if (chkYr6.Checked) wheresql += "AND ([Yr6] = 'true') ";

                wheresql = " WHERE Lastname IS NOT NULL " + wheresql;
                wheresql = wheresql + " ORDER BY [LastName]";



                return wheresql;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Eror in WHERESQL: " + ex.Message);
                return null;
            }
        }

        #endregion

        private void txtDayRate_Validating(object sender, CancelEventArgs e)
        {
            if (!validateDecimal(txtCharge.Text))
            {
                txtCharge.Text = "0.00";
            }
        }

        private bool validateDecimal(string text)
        {
            try
            {
                Decimal dec = Convert.ToDecimal(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Teacher Specified


        private void setTeacherControls(bool ShowDropDown)
        {
            cmbTeacherName.Visible = ShowDropDown;
            lblTS.Visible = ShowDropDown;
            lblTS2.Visible = ShowDropDown;
        }

        
        #endregion

       

        private void View_Click(object sender, EventArgs e)
        {
            if (btnView.Text == "View Daily Bookings")
            {
                btnView.Text = "View Availability";
                dgcAvail.Show();
                dgcAvail.Dock = DockStyle.Fill;
                dgcBookings.Hide();
            }
            else
            {
                btnView.Text = "View Daily Bookings";
                dgcAvail.Hide();
                dgcBookings.Dock = DockStyle.Left;
                dgcBookings.Show();
            }
        }

        

        















    }
}
