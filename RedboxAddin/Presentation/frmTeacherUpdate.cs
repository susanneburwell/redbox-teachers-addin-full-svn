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
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

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

                        if (chkAccepted.Checked) gd.Accepted = true;
                        else gd.Accepted = false;
                        gd.Date = bookingdate;
                        gd.Note = txtDetails.Text;
                        gd.TeacherID = Utils.CheckLong(cmbTeacher.SelectedValue);

                        //don't add twice
                        var numFound = db.GuaranteedDays.Count(g => g.Date == bookingdate && g.TeacherID == gd.TeacherID);
                        if (numFound == 0) db.GuaranteedDays.InsertOnSubmit(gd);

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
            if (radAbs.Checked)
            {
                grpAbsence.Visible = true;
                chkAccepted.Visible = false;
            }
            else
            {
                grpAbsence.Visible = false;
                chkAccepted.Visible = true;
            }
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

        private void chkShowGuarantees_CheckedChanged(object sender, EventArgs e)
        {
            LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            dtTo.Value = dtFrom.Value;
        }


        private void gcGuaranteed_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Check if the end-user has right clicked the grid control. 
                if (e.Button == MouseButtons.Right)
                {
                    REventArgs rowInfo = new REventArgs();
                    GridHitInfo info = gvGuaranteed.CalcHitInfo(new Point(e.X, e.Y));

                    //******************88
                    if (info.InRow || info.InRowCell)
                    {
                        rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                        rowInfo.Teacher = gvGuaranteed.GetRowCellValue(info.RowHandle, "dte").ToString();
                        rowInfo.Description = gvGuaranteed.GetRowCellValue(info.RowHandle, info.Column).ToString();

                        //switch (rowInfo.ColumnCaption.Substring(0, 3))
                        //{
                        //    case "Mon":
                        //        rowInfo.Status = gvGuaranteed.GetRowCellValue(info.RowHandle, "MonStatus").ToString();
                        //        break;
                        //    case "Tue":
                        //        rowInfo.Status = gvGuaranteed.GetRowCellValue(info.RowHandle, "TueStatus").ToString();
                        //        break;
                        //    case "Wed":
                        //        rowInfo.Status = gvGuaranteed.GetRowCellValue(info.RowHandle, "WedStatus").ToString();
                        //        break;
                        //    case "Thu":
                        //        rowInfo.Status = gvGuaranteed.GetRowCellValue(info.RowHandle, "ThuStatus").ToString();
                        //        break;
                        //    case "Fri":
                        //        rowInfo.Status = gvGuaranteed.GetRowCellValue(info.RowHandle, "FriStatus").ToString();
                        //        break;
                        //}
                    }

                    if (rowInfo.Description.Trim() == "")
                    {
                        //System.Media.SystemSounds.Exclamation.Play();
                        System.Media.SystemSounds.Beep.Play();
                        return;
                    }


                    //rowInfo.Status = LINQmanager.GetMasterBookingStatus(rowInfo.Teacher, rowInfo.ColumnCaption, rowInfo.Description);

                    //*******************
                    //if (hi.HitTest == GridHitTest.ColumnButton)
                    //{
                    GridViewCustomMenu menu = new GridViewCustomMenu(gvGuaranteed);
                    //menu.RepaintRequired += OnRepaintRequired;
                    menu.SetRowInfo(rowInfo);
                    menu.imageList = imageList1;
                    menu.Init(info);
                    // Display the menu. 
                    menu.Show(info.HitPoint);
                    //}
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in Mouse Down: " + ex.Message);
            }
        }

       

       


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
            int unass = 0;
            int cont = 0;
            int conf = 0;
            int dets = 0;
            int none = 0;

            switch (_rowInfo.Status)
            {
                case "Unassigned":
                    unass = 1;
                    break;

                case "Contacted":
                    cont = 1;
                    break;

                case "Confirmed":
                    conf = 1;
                    break;

                case "Details Sent":
                    dets = 1;
                    break;

                case "None":
                    none = 1;
                    break;
            }

            Items.Clear();
            int vv = GridMenuImages.Column.Images.Count;
            int vw = GridMenuImages.Footer.Images.Count;
            int vx = GridMenuImages.GroupPanel.Images.Count;
            Items.Add(CreateMenuItem("Unassigned", imageList.Images[unass], "Unassigned", true));
            Items.Add(CreateMenuItem("Contacted", imageList.Images[cont], "Contacted", true));
            Items.Add(CreateMenuItem("Confirmed", imageList.Images[conf], "Confirmed", true));
            Items.Add(CreateMenuItem("Details Sent", imageList.Images[dets], "Details Sent", true));
            Items.Add(CreateMenuItem("None", imageList.Images[none], "None", true));

        }

        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (RaiseClickEvent(sender, null)) return;
            DXMenuItem item = sender as DXMenuItem;
            string status = item.Tag.ToString();

            string teacher = _rowInfo.Teacher;
            string description = _rowInfo.Description;
            string colCaption = _rowInfo.ColumnCaption;

            List<long> MasterBookingIDs = LINQmanager.GetMasterBookingIDs(teacher, colCaption, description);

            if (MasterBookingIDs.Count > 0)
            {
                if (LINQmanager.SetBookingStatus(MasterBookingIDs[0], status))
                {
                    EventHandler handler = RepaintRequired;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }

        }

    }

}



