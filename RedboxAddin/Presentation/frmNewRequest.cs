using System;
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
using RedboxAddin.Models;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;



namespace RedboxAddin.Presentation
{
    public partial class frmNewRequest : Form
    {
        RedBoxDB db;
        long _masterBookingID;


        public frmNewRequest()
        {
            InitializeComponent();
        }

        public frmNewRequest(long masterBookingID)
        {
            InitializeComponent();
            _masterBookingID = masterBookingID;
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
                PopulateTeacher(cmbTeacher);
                PopulateTeacher(cmbRequestedTeacher);

                if (_masterBookingID != null) LoadMasterBooking(_masterBookingID);

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

            LoadAvailabilityTable();
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
                cmbSchool.Text = "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        private void LoadMasterBooking(long ID)
        {
            try
            {
                RMasterBooking rMB = new DBManager().GetMasterBookingInfo(ID);
                
                //cmbSchool.ValueMember=rMB.SchoolID ;
                cmbSchool.Text=rMB.School;
                //=rMB.ContactID ;
                cmbTeacher.Text=rMB.TeacherName ;
                //cmbTeacher.SelectedValue = rMB.ContactID;
                txtDetails.Text=rMB.Details ;
                dtFrom.Value=rMB.Startdate ;
                dtTo.Value=rMB.EndDate ;
                //=rMB.isAbsence ;
                //=rMB.AbsenceReason ;
                chkHalfDay.Checked=rMB.HalfDay ;
                chkLongTerm.Checked=rMB.LongTerm ;
                chkNur.Checked=rMB.Nur ;
                chkRec.Checked=rMB.Rec ;
                chkYr1.Checked=rMB.Yr1 ;
                chkYr2.Checked=rMB.Yr2 ;
                chkYr3.Checked=rMB.Yr3 ;
                chkYr4.Checked=rMB.Yr4 ;
                chkYr5.Checked=rMB.Yr5 ;
                chkYr6.Checked=rMB.Yr6 ;
                chkQTS.Checked=rMB.QTS ;
                chkNQT.Checked=rMB.NQT ;
                chkOTT.Checked=rMB.OTT ;
                chkTA.Checked=rMB.TA ;
                chkNN.Checked=rMB.NN ;
                chkQNN.Checked=rMB.QNN ;
                chkSEN.Checked=rMB.SEN ;
                txtCharge.Text=rMB.Charge.ToString() ;
                //cmbRequestedTeacher.Text = rMB.LinkedTeacherName;
                
               // =rMB.LinkedTeacherID ;
                radNG.Checked=rMB.NameGiven ;
                radAF.Checked=rMB.AskedFor ;
                radTD.Checked=rMB.TrialDay ;


            }
            catch (Exception ex)
            {
               Debug.DebugMessage(2, "Error in LoadMasterBooking: " + ex.Message);
            }
        }

        private void PopulateTeacher(ComboBox cmb1)
        {
            try
            {
                var q = from s in db.Contacts
                        where s.LastName != null
                        orderby s.LastName
                        select new  { FullName = (s.LastName + ',' + ' ' + s.FirstName),  s.ContactID };
                        //select new CHTest { FullName = (s.LastName + ','+' ' + s.FirstName),ContactID= s.ContactID };
                var schools = q.ToList();

                cmb1.DataSource = schools;
                cmb1.DisplayMember = "FullName";
                cmb1.ValueMember = "ContactID";
                cmb1.Text = "";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
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

                if (_masterBookingID == 0) mb = new MasterBooking();

                else mb = db.MasterBookings.Where<MasterBooking>(b => b.ID == _masterBookingID).FirstOrDefault();

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
                mb.ContactID = Utils.CheckLong(cmbTeacher.SelectedValue);

                //If Teacher named
                mb.NameGiven = radNG.Checked;
                mb.AskedFor = radAF.Checked;
                mb.TrialDay = radTD.Checked;
                if (radNS.Checked == false) mb.LinkedTeacherID = Convert.ToInt64(cmbRequestedTeacher.SelectedValue);
                else mb.LinkedTeacherID = -1;

                //If this is not a new booking, submit changes and exit
                if (_masterBookingID != 0)
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
                dgcAvail.DataSource = new DBManager().GetAvailability(monday, wheresql);
                dgcAvailView.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                dgcAvailView.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                dgcAvailView.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                dgcAvailView.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                dgcAvailView.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");
                RestoreLayout();
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
                string teacherStatus = Utils.TeacherQuals(chkTA.Checked, chkQTS.Checked, chkNQT.Checked, chkOTT.Checked, chkQNN.Checked, chkNN.Checked, chkSEN.Checked);

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

                lblDescription.Text = shortname + " " + teacherStatus + " " + agegroup;

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
            cmbRequestedTeacher.Visible = ShowDropDown;
            lblTS.Visible = ShowDropDown;
            lblTS2.Visible = ShowDropDown;
        }


        #endregion

        #region buttons

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dgcBookings.Visible)  RefreshDGC();
            if (dgcAvail.Visible) LoadAvailabilityTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
                btnView.Text = "Edit Daily Bookings";
                SetGridVisibility();
                btnSave.Text = "Save Updates";
            }
            else
            {
                MessageBox.Show("Not Saved", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgcAvail.Show();
                dgcAvail.Dock = DockStyle.Fill;
                dgcBookings.Hide();
            }
            else
            {
                btnView.Text = "View Availability";
                dgcAvail.Hide();
                BindGrid();
                dgcBookings.Dock = DockStyle.Fill;
                dgcBookings.Show();
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            UpdateDescription();
            if (dgcAvail.Visible) LoadAvailabilityTable();
        }


        private void dgcAvail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = dgcAvail.PointToClient(Control.MousePosition);
                GridHitInfo info = dgcAvailView.CalcHitInfo(pt);
                if(info.InRow || info.InRowCell) 
                {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                string teacher = dgcAvailView.GetRowCellValue(info.RowHandle, "Teacher").ToString();
                cmbTeacher.Text = teacher;

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in dgcAvail_DoubleClick: " + ex.Message);
            }
        }

        #endregion

        private void cmbTeacher_SelectedValueChanged(object sender, EventArgs e)
        {
            string test = cmbTeacher.Text;
        }


    }

   
}
