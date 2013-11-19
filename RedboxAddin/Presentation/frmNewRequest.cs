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



namespace RedboxAddin.Presentation
{
    public partial class frmNewRequest : Form
    {
        public frmNewRequest()
        {
            InitializeComponent();
        }

        private void frmNewRequest_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    PopulateSchools(db);
                    PopulateYearGroup(db);
                    PopulateTeacherLevel(db);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

            LoadTable();
        }

        #region LoadControls

        private void PopulateSchools(RedBoxDB db)
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

        private void PopulateYearGroup(RedBoxDB db)
        {
            try
            {
                List<YearGroup> ygs = db.YearGroups.ToList();
                cmbYearGroup.DataSource = ygs;
                cmbYearGroup.DisplayMember = "Name";
                cmbYearGroup.ValueMember = "Name";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateYearGroup: " + ex.Message);
            }

        }

        private void PopulateTeacherLevel(RedBoxDB db)
        {
            try
            {
                List<TeacherLevel> tl = db.TeacherLevels.ToList();
                cmbTeacherLevel.DataSource = tl;
                cmbTeacherLevel.DisplayMember = "level";
                cmbTeacherLevel.ValueMember = "level";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateTeacherLevel: " + ex.Message);
            }

        }

        #endregion

        #region buttons
        
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveRequest())
            {
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

        private void frmNewRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
        }

        #endregion

        #region actions  

        private bool SaveRequest()
        {
            try
            {

                if (dtTo.Value < dtFrom.Value )
                {
                    MessageBox.Show("Your end date can not be earlier than your start date.");
                    return false;
                }

                if ((dtTo.Value == null )|| ( dtFrom.Value == null))
                {
                    MessageBox.Show("Please pick a start and end date.");
                    return false;
                }

                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var mb = new MasterBooking();

                    //Table<MasterBooking> mbs = db.GetTable<MasterBooking>();
                    
                    
                    mb.SchoolID = Convert.ToInt64(cmbSchool.SelectedValue);
                    mb.YearGroup = cmbYearGroup.Text;
                    mb.TeacherLevel = cmbTeacherLevel.Text;
                    mb.StartDate = dtFrom.Value;
                    mb.EndDate = dtTo.Value;
                    mb.Details = txtDetails.Text;
                    db.MasterBookings.InsertOnSubmit(mb);
                   
                    db.SubmitChanges();

                    if (mb.ID <1)
                    {
                            MessageBox.Show("There was an error creating the Master Booking.");
                            Debug.DebugMessage(2, "There was an error creating the Master Booking. MasterBookingID 0 or Null");
                            return false;

                    }
                    DateTime bookingdate =(System.DateTime) mb.StartDate;
                    int iCatch = 0;
                    do 
                    {
                    var nb = new Booking();
                    nb.Am = true;
                    nb.Pm = true;
                    nb.MasterBookingID = mb.ID;
                    nb.Date = bookingdate;

                    db.Bookings.InsertOnSubmit(nb);
                    bookingdate = bookingdate.AddDays(1);
                        iCatch +=1;
                        if (iCatch > 365) 
                        {
                            MessageBox.Show("There was an error creating the daily bookings.");
                            Debug.DebugMessage(2, "Overflow error creating the daily bookings. MasterBookingID: " + mb.ID);
                            return false;
                        }

                    } while (bookingdate <= mb.EndDate);

                    db.SubmitChanges();
                }

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
                if(delta > 0)     delta -= 7;
                DateTime monday = input.AddDays(delta).Date;


                gridControl1.DataSource = new DBManager().GetAvailability(monday);
                gridView1.Columns[9].Caption = monday.ToString("ddd d MMM yy");
                gridView1.Columns[10].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                gridView1.Columns[11].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                gridView1.Columns[12].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                gridView1.Columns[13].Caption = monday.AddDays(4).ToString("ddd d MMM yy");
                RestoreLayout();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTable: " + ex.Message);
            }
        }

        private void RestoreLayout()
        {
            try
            {
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        private void SaveLayout()
        {
            try
            {
                gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        #endregion

        

    }
}
