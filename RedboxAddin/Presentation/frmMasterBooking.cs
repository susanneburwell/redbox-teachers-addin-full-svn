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
using RedboxAddin;
using RedboxAddin.Models;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;




namespace RedboxAddin.Presentation
{
    public partial class frmMasterBooking : Form
    {
        RedBoxDB db;
        long _masterBookingID = -1;
        long contactIDLong = -1;
        DateTime bookingDate = new DateTime(2000, 01, 01);
        bool loading = false;
        string errorMessage = "Not Saved";

        public frmMasterBooking()
        {
            InitializeComponent();
            availabilityGrid1.DblClick += new EventHandler(availabilityGrid_DblClick);
        }

        public frmMasterBooking(string contactID, DateTime bookingDate)
        {
            InitializeComponent();
            this.contactIDLong = long.Parse(contactID);
            this.bookingDate = bookingDate;
            availabilityGrid1.DblClick += new EventHandler(availabilityGrid_DblClick);
        }

        public frmMasterBooking(long masterBookingID)
        {
            InitializeComponent();
            _masterBookingID = masterBookingID;
            availabilityGrid1.DblClick += new EventHandler(availabilityGrid_DblClick);
        }

        private void frmNewRequest_Load(object sender, EventArgs e)
        {
            DateTime tempDate = new DateTime(2000, 01, 01);

            InitialLoad();
            if (contactIDLong != -1)
                cmbTeacher.SelectedValue = contactIDLong;

            if (bookingDate != tempDate)
            {
                dtFrom.Value = bookingDate;
                dtTo.Value = bookingDate;
            }
        }

        private void InitialLoad()
        {
            loading = true;
            dgcBookings.DataSource = bindingSource1;
            dgcBookings.Hide();
            availabilityGrid1.Hide();

            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                PopulateSchools();
                PopulateBookingStatus();
                Utils.PopulateTeacher(cmbTeacher, true);
                Utils.PopulateTeacher(cmbRequestedTeacher, true);

                if (_masterBookingID != -1)
                {
                    LoadMasterBooking(_masterBookingID);
                    SetGridVisibility();
                    ShowSavedDetails();
                    SetTopRow();
                }
                else
                {
                    txtNotes.Text = DateTime.Now.ToString("ddMMM HH:mm") + " : ";
                    txtRequestedBy.Text = "  on " + DateTime.Now.ToString("dd-MMM") + " at " + DateTime.Now.ToString("HH:mm");
                }
                loading = false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

            loading = false;
        }

        private void SetTopRow()
        {
            try
            {
                for (int i = 0; i < ViewBookings.RowCount; i++)
                {
                    if (Convert.ToDateTime(ViewBookings.GetRowCellValue(i, ViewBookings.Columns["Date"])) >= DateTime.Now.Date)
                    {
                        ViewBookings.TopRowIndex = i;
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #region LoadControls

        private void PopulateSchools()
        {
            try
            {
                var q = from s in db.Schools
                        orderby s.SchoolName
                        select s;
                var schools = q.ToList();

                cmbSchool.DataSource = schools;
                cmbSchool.DisplayMember = "SchoolName";
                cmbSchool.ValueMember = "ID";
                cmbSchool.Text = "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools(frmMasterbooking): " + ex.Message);
            }
        }

        private void PopulateBookingStatus()
        {
            try
            {
                var q = from s in db.BookingStatuses
                        select s;
                var bs = q.ToList();

                if (!string.IsNullOrEmpty(cmbSchool.Text))
                {
                    //If selected school has 'Vetting Details Morning Only' then remove the status of "Confirmed" else remove the status of "Confirmed - Morning Only"
                    if (IsVettingDetailsMorningOnly())
                    {
                        BookingStatuse obj = bs.ElementAt(6);
                        bs.RemoveAt(2);
                        bs.Insert(2, obj);
                        bs.RemoveAt(6);
                    }
                    else
                    {
                        bs.RemoveAt(6);
                    }
                }
                else
                {
                    BookingStatuse obj = bs.ElementAt(6);
                    bs.Insert(3, obj);
                    bs.RemoveAt(7);
                }

                //

                cmbBookingStatus.DataSource = bs;
                cmbBookingStatus.DisplayMember = "Status";
                cmbBookingStatus.ValueMember = "ID";
                cmbBookingStatus.Text = "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateBookingStatus: " + ex.Message);
            }
        }

        private void LoadMasterBooking(long ID)
        {
            try
            {
                RMasterBooking rMB = new DBManager().GetMasterBookingInfo(ID);

                //cmbSchool.ValueMember=rMB.SchoolID ;
                cmbSchool.Text = rMB.School;
                //=rMB.ContactID ;
                cmbTeacher.Text = rMB.TeacherName;
                //cmbTeacher.SelectedValue = rMB.ContactID;
                txtDescription.Text = rMB.Details;
                lblDescription.Text = rMB.Details;
                txtNotes.Text = rMB.Notes;
                dtFrom.Value = rMB.Startdate;
                dtTo.Value = rMB.EndDate;
                //=rMB.isAbsence ;
                //=rMB.AbsenceReason ;
                chkHalfDay.Checked = rMB.HalfDay;
                chkLongTerm.Checked = rMB.LongTerm;
                chkNur.Checked = rMB.Nur;
                chkRec.Checked = rMB.Rec;
                chkYr1.Checked = rMB.Yr1;
                chkYr2.Checked = rMB.Yr2;
                chkYr3.Checked = rMB.Yr3;
                chkYr4.Checked = rMB.Yr4;
                chkYr5.Checked = rMB.Yr5;
                chkYr6.Checked = rMB.Yr6;
                chkQTS.Checked = rMB.QTS;
                chkNQT.Checked = rMB.NQT;
                chkOTT.Checked = rMB.OTT;
                chkTeacher.Checked = rMB.Teacher;
                chkTA.Checked = rMB.TA;
                chkNN.Checked = rMB.NN;
                chkQNN.Checked = rMB.QNN;
                chkSEN.Checked = rMB.SEN;
                chkPPL.Checked = rMB.PPL;
                txtCharge.Text = rMB.Charge.ToString();
                //cmbRequestedTeacher.Text = rMB.LinkedTeacherName;

                // =rMB.LinkedTeacherID ;
                radNG.Checked = rMB.NameGiven;
                radAF.Checked = rMB.AskedFor;
                radTD.Checked = rMB.TrialDay;

                lblColor.Text = rMB.Color;
                cmbBookingStatus.Text = rMB.BookingStatus;
                chkProvisional.Checked = rMB.Provisional;

                txtCharge.Text = rMB.Charge.ToString();
                txtRequestedBy.Text = rMB.RequestedBy;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadMasterBooking: " + ex.Message);
            }
        }

        //private void PopulateTeacher(ComboBox cmb1)
        //{
        //    try
        //    {
        //        var q = from s in db.Contacts
        //                join c in db.ContactDatas on s.ContactID equals c.ContactID
        //                where s.LastName != null && c.Current == true
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

        #endregion

        #region actions

        private void clearControls()
        {
            loading = true;
            _masterBookingID = -1;
            cmbSchool.Text = "";
            cmbRequestedTeacher.Text = "";
            txtNotes.Text = "";
            txtDescription.Text = "";
            txtRequestedBy.Text = "";
            lblDescription.Text = "";
            cmbTeacher.Text = "";
            cmbBookingStatus.Text = "";
            radNS.Checked = true;
            chkMon.Checked = true;
            chkTue.Checked = true;
            chkWed.Checked = true;
            chkThu.Checked = true;
            chkFri.Checked = true;

            //**************************
            cmbSchool.Visible = true;
            dtFrom.Visible = true;
            dtTo.Visible = true;
            lblSchool.Text = "";
            lblFrom.Text = "";
            lblTo.Text = "";
            lblTo.Visible = false;
            lblFrom.Visible = false;
            lblSchool.Visible = false;


            //replace days
            chkMon.Visible = true;
            chkTue.Visible = true;
            chkWed.Visible = true;
            chkThu.Visible = true;
            chkFri.Visible = true;

            chkMon.Checked = true;
            chkTue.Checked = true;
            chkWed.Checked = true;
            chkThu.Checked = true;
            chkFri.Checked = true;
            lblDays.Text = "";
            lblDays.Visible = false;

            //**********************
        }

        private bool SaveRequest()
        {
            try
            {
                errorMessage = "Not Saved";
                if (!IsCalshing())
                {
                    MasterBooking mb;
                    //If this is a new request - create a new item

                    if (_masterBookingID < 1) mb = new MasterBooking();

                    else mb = db.MasterBookings.Where<MasterBooking>(b => b.ID == _masterBookingID).FirstOrDefault();

                    //Table<MasterBooking> mbs = db.GetTable<MasterBooking>();


                    mb.SchoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                    //mb.YearGroup = cmbYearGroup.Text;
                    //mb.TeacherLevel = cmbTeacherLevel.Text;
                    mb.StartDate = dtFrom.Value;
                    mb.EndDate = dtTo.Value;
                    mb.Details = txtDescription.Text;
                    mb.Notes = txtNotes.Text;
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
                    mb.Teacher = chkTeacher.Checked;
                    mb.TA = chkTA.Checked;
                    mb.SEN = chkSEN.Checked;
                    mb.QTS = chkQTS.Checked;
                    mb.NQT = chkNQT.Checked;
                    mb.OTT = chkOTT.Checked;
                    mb.QNN = chkQNN.Checked;
                    mb.NN = chkNN.Checked;
                    mb.PPL = chkPPL.Checked;
                    mb.Charge = Utils.CheckDecimal(txtCharge.Text);

                    mb.ContactID = Utils.CheckLong(cmbTeacher.SelectedValue);
                    mb.Color = lblColor.Text;
                    mb.BookingStatus = cmbBookingStatus.Text;
                    mb.Provisional = chkProvisional.Checked;
                    mb.RequestedBy = txtRequestedBy.Text;

                    //Check teacher is real
                    string teachername = cmbTeacher.Text.Replace(',', ' ');
                    if (teachername.Trim() == "") mb.ContactID = -1;

                    //If Teacher named
                    mb.NameGiven = radNG.Checked;
                    mb.AskedFor = radAF.Checked;
                    mb.TrialDay = radTD.Checked;
                    if (radNS.Checked == false) mb.LinkedTeacherID = Convert.ToInt64(cmbRequestedTeacher.SelectedValue);
                    else mb.LinkedTeacherID = -1;

                    //set selected weekdays
                    string selectedWeekdays = "";
                    if (chkMon.Checked) selectedWeekdays += "Mon, ";
                    if (chkTue.Checked) selectedWeekdays += "Tue, ";
                    if (chkWed.Checked) selectedWeekdays += "Wed, ";
                    if (chkThu.Checked) selectedWeekdays += "Thu, ";
                    if (chkFri.Checked) selectedWeekdays += "Fri, ";
                    if (selectedWeekdays.Length > 1)
                        selectedWeekdays = selectedWeekdays.Substring(0, selectedWeekdays.Length - 2);
                    mb.Weekdays = selectedWeekdays;


                    //If this is not a new booking, submit changes and exit
                    if (_masterBookingID > 0)
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
                    _masterBookingID = mb.ID;

                    //Create IndividualBookings
                    long contID = -1;
                    decimal? rate = null;


                    try
                    {
                        rate = Convert.ToDecimal(txtRate.Text);
                    }
                    catch (Exception) { }


                    DateTime bookingdate = (System.DateTime)mb.StartDate.Date;
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

                            if (rate == null) nb.Rate = 0;
                            else nb.Rate = (decimal)rate;

                            nb.HalfDay = chkHalfDay.Checked;

                            if (lblDescription.Visible) nb.Description = lblDescription.Text;
                            else nb.Description = txtDescription.Text;

                            nb.Notes = string.Empty;
                            nb.IsOverTimeAvailable = false;
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

                    } while (bookingdate.Date <= mb.EndDate.Date.AddMinutes(1));//1 minute added to ensure comparison works

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    errorMessage = "Availability Error: Selected teacher is not available on one or more dates of the booking";
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error saving new Request: " + ex.Message);
                return false;
            }
        }

        private void LoadAvailabilityTable()
        {


            try
            {
                //Get first day of week
                DateTime input = dtFrom.Value;
                int delta = DayOfWeek.Monday - input.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = input.AddDays(delta).Date;

                string wheresql = WHERESQL();
                availabilityGrid1.LoadTable(wheresql, monday, "");

                //dgcAvail.DataSource = new DBManager().GetAvailability(monday, wheresql);
                //dgcAvailView.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                //dgcAvailView.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                //dgcAvailView.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                //dgcAvailView.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                //dgcAvailView.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");
                //RestoreLayout();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadAvailabilityTable: " + ex.Message);
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
                string teacherStatus = Utils.TeacherQuals(chkTA.Checked, chkQTS.Checked, chkNQT.Checked, chkOTT.Checked, chkQNN.Checked,
                    chkNN.Checked, chkSEN.Checked, chkPPA.Checked, chkFloat.Checked);

                //Get AgeGroup
                string agegroup = Utils.YearGroup(chkNur.Checked, chkRec.Checked, chkYr1.Checked, chkYr2.Checked, chkYr3.Checked, chkYr4.Checked, chkYr5.Checked, chkYr6.Checked);

                lblDescription.Text = shortname + " " + teacherStatus + " " + agegroup;

                //Check Halfday
                if (chkHalfDay.Checked) lblDescription.Text += " 0.5";

                //check Long Term
                if (chkLongTerm.Checked) lblDescription.Text += " LT";

                if (radAF.Checked) lblDescription.Text = "AF " + lblDescription.Text;

                if (radTD.Checked) lblDescription.Text = "TD " + lblDescription.Text;
                txtDescription.Text = lblDescription.Text;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CreateDescription: " + ex.Message);
            }
        }

        private void SetColours()
        {

            this.ActiveControl = lblBooking;
            //cmbBookingStatus.Select(3, 0);

            lblColor.Text = Utils.SetColours(cmbBookingStatus.Text.ToString(), radAF.Checked, chkLongTerm.Checked, cmbBookingStatus);
        }

        private void SetColours_old()
        {
            //colours are abbreviated to 4 letters
            //colour is split fore/back
            string fore = "";
            string back = "";
            string status = cmbBookingStatus.Text.ToString();
            if (status == "") status = "Unassigned";

            switch (status)
            {

                case "Unassigned":
                    cmbBookingStatus.ForeColor = Color.Red;
                    cmbBookingStatus.BackColor = Color.Yellow;
                    fore = "redd";
                    back = "yell";
                    break;
                case "Contacted":
                    cmbBookingStatus.ForeColor = Color.Purple;
                    cmbBookingStatus.BackColor = Color.Yellow;
                    fore = "purp";
                    back = "yell";
                    break;
                case "Confirmed":
                    cmbBookingStatus.ForeColor = Color.Black;
                    cmbBookingStatus.BackColor = Color.Yellow;
                    fore = "blck";
                    back = "yell";
                    break;
                case "Details Sent":
                    cmbBookingStatus.ForeColor = Color.Black;
                    cmbBookingStatus.BackColor = Color.LightGray;
                    fore = "purp";
                    back = "gray";
                    break;
                    //case "Confirmed - Morning Only":
                    //    cmbBookingStatus.ForeColor = Color.Black;
                    //    cmbBookingStatus.BackColor = Color.BurlyWood;
                    //    fore = "purp";
                    //    back = "gray";
                    break;
                default:
                    cmbBookingStatus.ForeColor = System.Drawing.SystemColors.WindowText;
                    cmbBookingStatus.BackColor = System.Drawing.SystemColors.Window;
                    break;

            }

            if (radAF.Checked) //asked for
            {
                if (status == "Details Sent") back = "dblu"; //darkblue;
                else back = "lblu";  //light blue
            }

            if (chkLongTerm.Checked) //LongTerm / Regular Booking
            {
                back = "purp";
            }


            this.ActiveControl = lblBooking;
            //cmbBookingStatus.Select(3, 0);

            lblColor.Text = fore + "/" + back;
        }

        private void SetChargeRate()
        {
            try
            {
                long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                School school = db.Schools.Where<School>(s => s.ID == schoolID).FirstOrDefault();
                if (chkTA.Checked)
                {
                    if (chkHalfDay.Checked)
                    {
                        if (chkLongTerm.Checked) txtCharge.Text = school.TAHalfDayChargeLT.ToString();
                        else txtCharge.Text = school.TAHalfDayCharge.ToString();
                    }
                    else
                    {
                        if (chkLongTerm.Checked) txtCharge.Text = school.TADayChargeLT.ToString();
                        else txtCharge.Text = school.TADayCharge.ToString();
                    }
                }
                else
                {
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
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SetChargeRate: " + ex.Message);
            }
        }

        private string GetRateType()
        {
            try
            {
                long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                School school = db.Schools.Where<School>(s => s.ID == schoolID).FirstOrDefault();

                if (school == null) throw new Exception("Error in GetRateType(): Could not find School");

                if (school.RateType == null) return "TeacherRate";
                else return school.RateType;
            }
            catch (Exception ex)
            {
                return "TeacherRate";
                throw new Exception("Error in GetRateType(): " + ex.Message);
            }

        }

        private void SetTeacherRate()
        {
            //if school is set for always use school rate, set rate to Charge - £35  
            //otherwise use rate set for teacher
            string rateType = GetRateType();
            if (rateType == "CalcRate")
            {
                txtRate.Text = (Convert.ToDouble(txtCharge.Text) - 35).ToString();
            }
            else if (rateType == "SchoolRate")
            {
                txtRate.Text = GetRate(teacherRate: false);
            }
            else
            {
                txtRate.Text = GetRate(teacherRate: true);
            }
        }

        private string GetRate(bool teacherRate)
        {
            decimal? rate = 0;
            string rateName = "";
            try
            {
                //Get rate for teacher
                if (chkTA.Checked)
                {
                    //TA
                    if (chkHalfDay.Checked)
                    {
                        //HalfDay
                        if (chkLongTerm.Checked)
                        {
                            //LongTerm
                            rateName = "HalfDayRateLTTA";
                        }
                        else
                        {
                            rateName = "HalfDayRateTA";
                        }
                    }
                    else
                    {
                        //FullDay
                        if (chkLongTerm.Checked)
                        {
                            //LongTerm
                            rateName = "DayRateLTTA";
                        }
                        else
                        {
                            rateName = "DayRateTA";
                        }
                    }
                }
                else
                {
                    //Teacher
                    if (chkHalfDay.Checked)
                    {
                        //Half Day
                        if (chkLongTerm.Checked)
                        {
                            //LongTerm
                            rateName = "HalfDayRateLT";
                        }
                        else
                        {
                            rateName = "HalfDayRate";
                        }
                    }
                    else
                    {
                        //Full Day
                        if (chkLongTerm.Checked)
                        {
                            //LongTerm
                            rateName = "DayRateLT";
                        }
                        else
                        {
                            rateName = "DayRate";
                        }
                    }
                }
                if (teacherRate)
                {
                    long contID = Convert.ToInt64(cmbTeacher.SelectedValue);
                    rate = LINQmanager.GetRateForContact(contID, rateName);
                }
                else
                {
                    //must be school rate
                    long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                    rate = LINQmanager.GetRateForSchool(schoolID, rateName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetRate(): " + ex.Message);

            }
            return rate.ToString();
        }

        private void RestoreLayout()
        {
            try
            {
                ViewBookings.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\MasterBookingsFormDump.xml");
            }
            catch (Exception) { }
        }

        private void SaveLayout()
        {
            try
            {
                ViewBookings.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\MasterBookingsFormDump.xml");
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
                if (chkPPA.Checked) wheresql += "AND ([PPA] = 'true') ";
                //if (chkFloat.Checked) wheresql += "AND ([Float] = 'true') ";

                wheresql = " WHERE [current] = 'true' AND [Lastname] IS NOT NULL " + wheresql;

                //Get qualifications
                string SQL = "";
                if (chkQTS.Checked) SQL += " OR [QTS] = 'true' ";
                if (chkNQT.Checked) SQL += " OR [NQT] = 'true' ";
                if (chkOTT.Checked) SQL += " OR [OverseasTrainedTeacher]  = 'true' ";
                if (chkTA.Checked) SQL += " OR [TA]  = 'true' ";
                if (chkQNN.Checked) SQL += " OR [QNN]  = 'true' ";
                if (chkNN.Checked) SQL += " OR [NN]  = 'true' ";
                if (chkSEN.Checked) SQL += " OR [SEN]  = 'true' ";
                if (chkTeacher.Checked) SQL += " OR [Teacher]  = 'true' ";

                if (SQL != "")
                {
                    wheresql = wheresql + " AND (" + SQL.Substring(3) + ") ";
                }

                wheresql = wheresql + " ORDER BY [LastName]";


                return wheresql;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Eror in WHERESQL: " + ex.Message);
                return null;
            }
        }

        private void setTeacherControls(bool ShowDropDown)
        {
            cmbRequestedTeacher.Visible = ShowDropDown;
            //lblTS.Visible = ShowDropDown;
            lblTS2.Visible = ShowDropDown;
        }

        private void CheckDoubleBookings()
        {
            try
            {
                DBManager dbm = new DBManager();
                List<RDoubleBookings> listDblB = dbm.CheckDoubleBookings();
                if (listDblB.Count > 0)
                {
                    btnDblBkgs.Visible = true;
                    flashtimer1.Interval = 500;
                    flashtimer1.Enabled = true;
                }
                else
                {
                    btnDblBkgs.Visible = false;
                    flashtimer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDoubleBookings: " + ex.Message);
            }
        }

        private void SendNotificationDetails()
        {
            try
            {
                if (Utils.SendNotification(_masterBookingID, txtDescription.Text) == false)
                {
                    MessageBox.Show("Error. The email could not be created at this time.");
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in send notification details: " + ex.Message);
            }
        }

        private void SendVettingDetails()
        {
            try
            {
                MasterBooking mb = db.MasterBookings.Where<MasterBooking>(b => b.ID == _masterBookingID).FirstOrDefault();
                long schoolID = mb.SchoolID;
                string agegroup = Utils.YearGroup(chkNur.Checked, chkRec.Checked, chkYr1.Checked, chkYr2.Checked, chkYr3.Checked, chkYr4.Checked, chkYr5.Checked, chkYr6.Checked);

                //agegroup = (chkPPA.Checked) ? agegroup += "/PPA" : agegroup;
                agegroup = (chkFloat.Checked) ? agegroup += "/Float" : agegroup;
                agegroup = (chkTA.Checked) ? agegroup += "/TA" : agegroup;

                long contactID = (long)mb.ContactID;
                bool result = RedemptionCode.SendVettingDetails(false, contactID.ToString(), schoolID.ToString(),
                    dtFrom.Value.ToShortDateString(), dtTo.Value.ToShortDateString(), agegroup, txtRequestedBy.Text);
                if (result == false)
                {
                    MessageBox.Show("Error. The email could not be created at this time.");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error creating the email. Please make sure you have selected a contact.");
                Debug.DebugMessage(2, "Error in SendVettingDetails(2): " + ex.Message);
            }
        }

        private void ShowSavedDetails()
        {
            //this sets school and dates as fixed labels
            {
                cmbSchool.Visible = false;
                dtFrom.Visible = false;
                dtTo.Visible = false;
                lblSchool.Text = cmbSchool.Text;
                lblFrom.Text = dtFrom.Value.ToString("ddd dd MMM yy");
                lblTo.Text = dtTo.Value.ToString("ddd dd MMM yy");
                lblTo.Visible = true;
                lblFrom.Visible = true;
                lblSchool.Visible = true;


                //replace days
                chkMon.Visible = false;
                chkTue.Visible = false;
                chkWed.Visible = false;
                chkThu.Visible = false;
                chkFri.Visible = false;

                string days = "";
                if (chkMon.Checked) days += "Mon, ";
                if (chkTue.Checked) days += "Tue, ";
                if (chkWed.Checked) days += "Wed, ";
                if (chkThu.Checked) days += "Thu, ";
                if (chkFri.Checked) days += "Fri, ";
                if (days.Length > 1) days = days.Substring(0, days.Length - 2);
                lblDays.Text = days;
                lblDays.Visible = true;
            }
        }

        private bool CheckForPastBookings()
        {
            try
            {
                var bookingList = from b in db.Bookings
                                  where b.MasterBookingID == _masterBookingID
                                  && b.Date < DateTime.Today
                                  select b;

                if (bookingList == null)
                {
                    MessageBox.Show("Error Reviewing Past Bookings. Can not delete.");
                    return true;
                }
                else if (bookingList.Count() > 0)
                {
                    MessageBox.Show("This Master Booking has Past Bookings already logged. It can not be deleted.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckForPastBookings(): " + ex.Message);
                return false;
            }
        }
        
        private bool DeleteBooking()
        {
            try
            {
                //Delete bookings overtime information
                var bookingOTList = from b in db.BookingOverTimes
                                    where b.MasterBookingID == _masterBookingID
                                    select b;
                foreach (var bOT in bookingOTList)
                {
                    db.BookingOverTimes.DeleteOnSubmit(bOT);
                }

                //Delete bookings
                var bookingList = from b in db.Bookings
                                  where b.MasterBookingID == _masterBookingID
                                  select b;
                foreach (var bkg in bookingList)
                {
                    db.Bookings.DeleteOnSubmit(bkg);
                }


                //Delete Booking
                var mBooking = from b in db.MasterBookings
                               where b.ID == _masterBookingID
                               select b;
                foreach (var mbkg in mBooking)
                {
                    db.MasterBookings.DeleteOnSubmit(mbkg);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in DeleteBooking(): " + ex.Message);
                return false;
            }
        }

        #endregion

        #region DGC

        private void RefreshDGC()
        {
            LoadBookingsGrid();
        }

        private void LoadBookingsGrid()
        {
            try
            {

                //Table<Booking> bookingList = db.GetTable<Booking>();
                var bookingList = from b in db.Bookings
                                  where b.MasterBookingID == _masterBookingID
                                  select b;
                bindingSource1.DataSource = bookingList;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in BindGrid: " + ex.Message);
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

        private void Refresh()
        {
            //refresh database connection
            string CONNSTR = DavSettings.getDavValue("CONNSTR");
            db = new RedBoxDB(CONNSTR);

            if (dgcBookings.Visible) RefreshDGC();
            if (availabilityGrid1.Visible) LoadAvailabilityTable();
            if (btnDblBkgs.Visible) CheckDoubleBookings();

        }

        #region buttons

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
                ShowSavedDetails();

                btnView.Text = "Edit Daily Bookings";
                SetGridVisibility();
                btnSave.Text = "Save Updates";
                CheckDoubleBookings();
            }
            else
            {
                MessageBox.Show(errorMessage, "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsaveAndClose_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage, "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
                clearControls();
                txtNotes.Text = DateTime.Now.ToShortDateString() + " : ";
                btnView.Text = "Edit Daily Bookings";
                availabilityGrid1.Clear();
                availabilityGrid1.Visible = false;
                dgcBookings.DataSource = null;
                dgcBookings.Visible = false;

                InitialLoad();

                btnSave.Text = "Save";
                btnDblBkgs.Visible = false;
                flashtimer1.Enabled = false;
            }
            else
            {
                MessageBox.Show(errorMessage, "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAvailabilityTable();
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

        private void chkPPL_Click(object sender, EventArgs e)
        {
            if (chkPPL.Checked)
            {
                chkNur.Checked = true;
                chkRec.Checked = true;
                chkYr1.Checked = true;
                chkYr2.Checked = true;
                chkYr3.Checked = true;
                chkYr4.Checked = true;
                chkYr5.Checked = true;
                chkYr6.Checked = true;
            }

        }

        private void chkTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return;
            CheckChanged();
        }

        private void chkTA_CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return;
            SetChargeRate();
            SetTeacherRate();
            CheckChanged();

        }
        private void radAF_CheckedChanged(object sender, EventArgs e)
        {
            SetColours();
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
            SetColours();
            SetTeacherRate();
        }

        private void chkHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            SetChargeRate();
            UpdateDescription();
            SetTeacherRate();
        }

        private void btnEditDesc_Click(object sender, EventArgs e)
        {
            txtDescription.Visible = lblDescription.Visible;
            lblDescription.Visible = !txtDescription.Visible;
            if (txtDescription.Visible) txtDescription.Text = lblDescription.Text;
            if (lblDescription.Visible) lblDescription.Text = txtDescription.Text;

        }

        private void cmbBookingStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            SetColours();
            if (loading) return;

            if (cmbBookingStatus.Text == "Cancelled" || cmbBookingStatus.Text == "Cancelled - ttbt")
            {
                manageCancelledBooking(cmbBookingStatus.Text);
            }
        }

        private void manageCancelledBooking(string status)
        {
            try
            {
                if (status == "Cancelled")
                {
                    DialogResult response = MessageBox.Show("You have set the Status to Cancelled. \rThis should be set when the school has cancelled AND the teacher has been told.\r" +
                        "If this is correct select Yes to remove the individual bookings from the availability sheet, or No to leave them.\r" +
                        "You should normally remove them.\r" +
                        "Do not use this method if the teacher has already worked one or more days on this booking.", "Cancelled Booking - Teacher TOLD", MessageBoxButtons.YesNoCancel);
                    if (response == DialogResult.Yes)
                    {
                        DBManager dbm = new DBManager();

                        int result = dbm.DeleteBookingsFromDate(_masterBookingID.ToString(), "1901-01-01");
                        MessageBox.Show(result.ToString() + " individual bookings removed.");
                        SaveRequest();
                    }
                }
                else if (status == "Cancelled - ttbt")
                {
                    DialogResult response = MessageBox.Show("You have set the Status to Cancelled - ttbt. \rThis should be set when the school has cancelled BUT the teacher has NOT been told.\r" +
                        "If this is correct select Yes to update the individual booking text to Cancelled.\r" +
                        "Once the Teacher has been told, the individual bookings can be deleted.\r" +
                        "Do not use this method if the teacher has already worked one or more days on this booking.", "Cancelled - ttbt - Teacher To Be Told", MessageBoxButtons.YesNoCancel);
                    if (response == DialogResult.Yes)
                    {
                        DBManager dbm = new DBManager();

                        int result = dbm.UpdateBookings(_masterBookingID, null, null, "Cancelled");
                        MessageBox.Show(result.ToString() + " individual bookings updated.");
                        SaveRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in manageCancelledBooking: " + ex.Message);
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

        private void View_Click(object sender, EventArgs e)
        {
            SetGridVisibility();
        }

        private void SetGridVisibility()
        {
            if (btnView.Text == "View Availability")
            {
                btnView.Text = "Edit Daily Bookings";
                LoadAvailabilityTable();
                availabilityGrid1.Show();
                availabilityGrid1.Dock = DockStyle.Fill;
                dgcBookings.Hide();
            }
            else
            {
                btnView.Text = "View Availability";
                availabilityGrid1.Hide();
                LoadBookingsGrid();
                dgcBookings.Dock = DockStyle.Fill;
                dgcBookings.Show();
            }
        }

        //private void DateChanged(object sender, EventArgs e)
        //{
        //    dtTo.Value = dtFrom.Value;

        //    UpdateDescription();
        //    if (availabilityGrid1.Visible) LoadAvailabilityTable();
        //    SetColours();
        //}

        private void ValueChanged(object sender, EventArgs e)
        {
            if (sender == dtFrom)
            {
                if (DateTime.Compare(dtFrom.Value, dtTo.Value) > 0) dtTo.Value = dtFrom.Value;
            }
            if (sender == dtTo)
            {
                if (DateTime.Compare(dtFrom.Value, dtTo.Value) > 0) dtFrom.Value = dtTo.Value;
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return;

            CheckChanged();
        }

        private void CheckChanged()
        {
            if (loading) return;
            UpdateDescription();
            if (availabilityGrid1.Visible) LoadAvailabilityTable();
            SetColours();
        }

        protected void availabilityGrid_DblClick(object sender, EventArgs e)
        {
            try
            {
                REventArgs e1 = e as REventArgs;
                cmbTeacher.Text = e1.Teacher;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in dgcAvail_DoubleClick: " + ex.Message);
            }
        }

        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            SendNotificationDetails();
        }

        private void btnSendVettingDetails_Click(object sender, EventArgs e)
        {
            SendVettingDetails();
        }

        private void btnDblBkgs_Click(object sender, EventArgs e)
        {
            frmViewDoubleBookings fdb = Application.OpenForms["frmViewDoubleBookings"] as frmViewDoubleBookings;
            if (fdb == null)
            {
                fdb = new frmViewDoubleBookings();
                fdb.Show();
            }
            else { fdb.BringToFront(); }
        }

        private void cmbTeacher_SelectedValueChanged(object sender, EventArgs e)
        {
            //this sets the rate when we load
            //if (loading) return;

            //check nogo status
            try
            {
                long teacherID = Convert.ToInt64(cmbTeacher.SelectedValue);
                long schoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                if (teacherID < 0) return;

                SetTeacherRate();
                if (!loading) cmbBookingStatus.Text = "Unassigned";

                //School school = cmbTeacher.SelectedItem as School;
                string nogo = LINQmanager.GetNoGoforContactID(teacherID).ToLower();
                if (nogo == "") return;
                string shortname = LINQmanager.GetShortNameforSchoolID(schoolID).ToLower();
                if (shortname == "") return;

                if (nogo.Contains(shortname))
                {
                    MessageBox.Show(cmbTeacher.Text + " has a NoGo flagged for " + shortname, "NoGo Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            }
            catch (InvalidCastException ex)
            {
                Debug.DebugMessage(4, "Error: InvalidCastException in cmbTeacher_SelectedValueChanged: " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in cmbTeacher_SelectedValueChanged: " + ex.Message);
            }
        }

        #endregion

        private void flashtimer1_Tick(object sender, EventArgs e)
        {
            if (btnDblBkgs.BackColor == Color.Crimson)
            {
                btnDblBkgs.BackColor = Color.Orange;
            }
            else btnDblBkgs.BackColor = Color.Crimson;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            RefreshDGC();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool foundPastBookings = CheckForPastBookings();
            if (foundPastBookings == true)
            {
                return;  //Message box shows in CheckForPastBookings()
            }
            else
            {
                DialogResult dr = MessageBox.Show("This will delete the entire booking from the system. There is no UNDO option.\r" +
                    "Press OK to Delete, or Cancel to cancel deleting.", "Redbox Warning", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    if (DeleteBooking()) this.Close();
                    else MessageBox.Show("Deletion Failed!");

                }
            }
        }

        private void btnUpdateDaily_Click(object sender, EventArgs e)
        {
            frmUpdateBookings ub = new frmUpdateBookings();
            ub.rate = txtRate.Text;
            ub.charge = txtCharge.Text;
            ub.description = txtDescription.Text;
            ub.masterID = _masterBookingID.ToString();
            ub.ShowDialog();

            dgcBookings.Visible = true;
            availabilityGrid1.Visible = false;

            //refresh database connection
            string CONNSTR = DavSettings.getDavValue("CONNSTR");
            db = new RedBoxDB(CONNSTR);

            RefreshDGC();

        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager();
            int result = dbm.UpdateBookings(_masterBookingID, null, txtRate.Text, null);
            if (result == -1) MessageBox.Show("Error updating bookings");
            else if (result == 1) MessageBox.Show("1 booking updated");
            else MessageBox.Show(result.ToString() + " bookings updated");
            Refresh();
        }

        private void btnUpdateCharge_Click(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager();
            int result = dbm.UpdateBookings(_masterBookingID, txtCharge.Text, null, null);
            if (result == -1) MessageBox.Show("Error updating bookings");
            else if (result == 1) MessageBox.Show("1 booking updated");
            else MessageBox.Show(result.ToString() + " bookings updated");
            Refresh();
        }

        private void btnUpdateDescription_Click(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager();
            int result = dbm.UpdateBookings(_masterBookingID, null, null, txtDescription.Text);
            if (result == -1) MessageBox.Show("Error updating bookings");
            else if (result == 1) MessageBox.Show("1 booking updated");
            else MessageBox.Show(result.ToString() + " bookings updated");
            Refresh();
        }

        private void dgcBookings_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the end-user has right clicked the grid control. 
                if (e.Button == MouseButtons.Right)
                {
                    REventArgs rowInfo = new REventArgs();
                    GridHitInfo info = ViewBookings.CalcHitInfo(new Point(e.X, e.Y));

                    //******************88
                    if (info.InRow || info.InRowCell)
                    {
                        rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                        //rowInfo.Teacher = ViewBookings.GetRowCellValue(info.RowHandle, "dte").ToString();
                        int[] selectedRows = ViewBookings.GetSelectedRows();

                        //Get IDs from selected rows
                        long[] selectedIDs;
                        if (selectedRows.Length > 1)
                        {
                            //Multiple rows selected
                            selectedIDs = new long[selectedRows.Length];

                            for (int i = 0; i < selectedRows.Length; i++)
                            {
                                int rowNum = selectedRows[i];
                                long? rowID = ViewBookings.GetRowCellValue(rowNum, "ID") as long?;
                                if (rowID != null) selectedIDs[i] = (long)ViewBookings.GetRowCellValue(rowNum, "ID");
                            }
                        }
                        else
                        {
                            //single row selected
                            selectedIDs = new long[1];
                            selectedIDs[0] = (long)ViewBookings.GetRowCellValue(info.RowHandle, "ID");
                        }
                        rowInfo.SelectedRows = selectedIDs;
                    }

                    GridViewCustomMenu menu = new GridViewCustomMenu(ViewBookings);
                    menu.SetRowInfo(rowInfo);
                    menu.imageList = imageList1;
                    menu.Init(info);
                    // Display the menu. 
                    menu.Show(info.HitPoint);

                    refreshTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in Mouse Down: " + ex.Message);
            }
        }

        private bool IsCalshing()
        {
            bool isClashing = false;

            if (_masterBookingID < 1) //For insert a new record
            {
                List<DayOfWeek> listOfDays = new List<DayOfWeek>();

                //Add ticked days to listOfDays
                if (chkMon.Checked)
                    listOfDays.Add(DayOfWeek.Monday);
                if (chkTue.Checked)
                    listOfDays.Add(DayOfWeek.Tuesday);
                if (chkWed.Checked)
                    listOfDays.Add(DayOfWeek.Wednesday);
                if (chkThu.Checked)
                    listOfDays.Add(DayOfWeek.Thursday);
                if (chkFri.Checked)
                    listOfDays.Add(DayOfWeek.Friday);


                DataTable dtClashingBookings = new DBManager().GetClashingBookingDetails(dtFrom.Value.Date, dtTo.Value.Date, Utils.CheckLong(cmbTeacher.SelectedValue));
                if (dtClashingBookings != null)
                {
                    foreach (DataRow row in dtClashingBookings.Rows)
                    {
                        DateTime bookingDate = DateTime.Parse(row["Date"].ToString());
                        foreach (DayOfWeek day in listOfDays)
                        {
                            if (bookingDate.DayOfWeek == day)
                            {
                                isClashing = true;
                                break;
                            }
                        }
                        if (isClashing)
                            break;
                    }
                }
            }
            else //For update a record
            {
                DataTable dtClashingBookings = new DBManager().GetClashingBookingDetailsForUpdate(_masterBookingID, Utils.CheckLong(cmbTeacher.SelectedValue));
                if (dtClashingBookings != null && dtClashingBookings.Rows.Count > 0)
                    isClashing = true;
            }

            return isClashing;
        }


        public class GridViewCustomMenu : GridViewMenu
        {
            public GridViewCustomMenu(DevExpress.XtraGrid.Views.Grid.GridView view) : base(view) { }

            private REventArgs _rowInfo;
            public ImageList imageList;
            public event EventHandler RepaintRequired;


            public void SetRowInfo(REventArgs rowInfo)
            {
                _rowInfo = rowInfo;
            }
            // Create menu items. 
            // This method is automatically called by the menu's public Init method. 
            protected override void CreateItems()
            {
                //image 0 = dot ; image 1 = tick
                int off = 0;
                int acct = 0;
                int conf = 0;
                int dets = 0;
                int none = 0;

                Items.Clear();
                int vv = GridMenuImages.Column.Images.Count;
                int vw = GridMenuImages.Footer.Images.Count;
                int vx = GridMenuImages.GroupPanel.Images.Count;
                Items.Add(CreateMenuItem("Delete", imageList.Images[conf], "Delete", true));


            }

            protected override void OnMenuItemClick(object sender, EventArgs e)
            {
                if (RaiseClickEvent(sender, null)) return;
                DXMenuItem item = sender as DXMenuItem;
                string status = item.Tag.ToString();

                string teacher = _rowInfo.Teacher;
                string description = _rowInfo.Description;
                string colCaption = _rowInfo.ColumnCaption;

                DBManager dbm = new DBManager();
                int response = -1;
                switch (status)
                {
                    case "Delete":
                        response = dbm.DeleteBookings(_rowInfo.SelectedRows);
                        break;

                }

                if (response < 1) MessageBox.Show("No Items Deleted.");
                else MessageBox.Show(response.ToString() + " Items Deleted.");
            }

        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateBookingStatus();
        }

        private bool IsVettingDetailsMorningOnly()
        {
            try
            {
                bool isVettingAM = false;
                //not sure why but sometimes selected value is a school
                if (cmbSchool.SelectedValue.ToString() == "RedboxAddin.School") return false;
                if (cmbSchool.SelectedValue != null)
                {
                    long selectedSchoolID = long.Parse(cmbSchool.SelectedValue.ToString());
                    School oSchool = db.Schools.Where(p => p.ID == selectedSchoolID).FirstOrDefault();
                    if (oSchool != null)
                    {
                        if (oSchool.VettingAM)
                            isVettingAM = true;
                    }

                }
                return isVettingAM;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in IsVettingDetailsMorningOnly: " + ex.Message);
                return false;
            }
        }

        private void dgcBookings_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = dgcBookings.PointToClient(Control.MousePosition);
                GridHitInfo info = ViewBookings.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    long masterbookingID = Convert.ToInt64(ViewBookings.GetRowCellValue(info.RowHandle, "MasterBookingID").ToString());
                    long bookingID = Convert.ToInt64(ViewBookings.GetRowCellValue(info.RowHandle, "ID").ToString());
                    //We use the rate from the Master booking, not the individual booking
                    Decimal charge = Convert.ToDecimal(txtCharge.Text);
                    Decimal rate = Convert.ToDecimal(txtRate.Text);
                    //Decimal charge = Convert.ToDecimal(ViewBookings.GetRowCellValue(info.RowHandle, "Charge").ToString());
                    //Decimal rate = Convert.ToDecimal(ViewBookings.GetRowCellValue(info.RowHandle, "Rate").ToString());
                    bool halfday = Convert.ToBoolean(ViewBookings.GetRowCellValue(info.RowHandle, "HalfDay").ToString());

                    if (masterbookingID > -1 && bookingID > -1)
                    {
                        frmBookingOverTime fq = new frmBookingOverTime(masterbookingID, bookingID, charge, rate, halfday);
                        fq.Show();
                    }
                    else
                    {
                        throw new Exception("Missing BookingID");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_DoubleClick: " + ex.Message);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrWhiteSpace(txtCharge.Text)) || (string.IsNullOrWhiteSpace(txtRate.Text)))
                {
                    MessageBox.Show("Please make sure Rate and Charge are set correctly.", "Missing Rate or Charge");
                    return;
                }

                Decimal charge = Convert.ToDecimal(txtCharge.Text);
                Decimal rate = Convert.ToDecimal(txtRate.Text);
                bool halfday = chkHalfDay.Checked;

                using (FrmCalc frmC = new FrmCalc(charge, rate, halfday))
                {
                    DialogResult dr = frmC.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        txtCharge.Text = frmC.newCharge.ToString();
                        txtRate.Text = frmC.newRate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading calculation form: " + ex.Message);
            }
        }



























    }


}
