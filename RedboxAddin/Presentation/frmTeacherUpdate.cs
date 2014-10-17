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
using System.Data.SqlClient;

namespace RedboxAddin.Presentation
{
    public partial class frmTeacherUpdate : Form
    {
        long _teacherID = 0;
        DataSet dsClashingDates = new DataSet();
        RedBoxDB db;

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
                Utils.PopulateTeacher(cmbTeacher, rdoLastName.Checked);

                if (_teacherID != 0) LoadTeacherDates(_teacherID);              

                TickAllDateCheckBoxes();
                CheckForClashingDates();
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
                List<RTeacherday> teacherdays = dbm.GetTeacherDays(teacherID, chkPast.Checked, chkFuture.Checked, radAvailability.Checked);

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
                Cursor.Current = Cursors.WaitCursor;
                //Check dates are valid
                if (dtTo.Value.Date < dtFrom.Value.Date)
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
                List<DayOfWeek> listOfDays = new List<DayOfWeek>();
                bool isTicked = false;
                int iCatch = 0;
                string action;

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


                //If Guaranteed Days
                if (radAvailability.Checked)
                {
                    do
                    {
                        isTicked = false;

                        //Create a new Guaranteed Day
                        action = "Creating Guaranteed Day";
                        GuaranteedDay gd = new GuaranteedDay();

                        //1- guaranteed offered, 2-guar accepted, 3-texted, 4-available, 5-unavailable, 6-priority
                        //if (chkAccepted.Checked) gd.Accepted = true; else gd.Accepted = false;
                        if (radOffered.Checked) gd.Type = 1;
                        if (radGuaranteed.Checked) gd.Type = 2;
                        if (radTexted.Checked) gd.Type = 3;
                        if (radAvail.Checked) gd.Type = 4;
                        if (radUnavail.Checked) gd.Type = 5;
                        if (radPriority.Checked) gd.Type = 6;

                        gd.Date = bookingdate;
                        gd.Note = txtDetails.Text;
                        gd.TeacherID = Utils.CheckLong(cmbTeacher.SelectedValue);
                        gd.Note = txtNotes.Text.Trim();

                        foreach (DayOfWeek day in listOfDays)
                        {
                            if (bookingdate.DayOfWeek == day)
                                isTicked = true;
                        }

                        if (isTicked)
                        {
                            //don't add twice
                            var numFound = db.GuaranteedDays.Count(g => g.Date == bookingdate && g.TeacherID == gd.TeacherID);
                            if (numFound == 0) db.GuaranteedDays.InsertOnSubmit(gd);
                        }

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
                // We update existing
                //we do not create new absence record.
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Teacher Update: Error SaveRequest: " + ex.Message);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public int UpdateBooking(long id, string description)
        {
            int numUpdated = 0;
            try
            {
                string sqlStr = "UPDATE GuaranteedDays  "
                    + "SET Note = @descr "
                    + "WHERE ID = @ID";

                DBManager.OpenDBConnection();
                var CmdAddContact = new SqlCommand(sqlStr, DBManager._DBConn);

                CmdAddContact.Parameters.Add("@ID", SqlDbType.BigInt);
                CmdAddContact.Parameters.Add("@descr", SqlDbType.VarChar, 50);

                CmdAddContact.Prepare();

                CmdAddContact.Parameters["@ID"].Value = id;
                CmdAddContact.Parameters["@descr"].Value = description;

                numUpdated = CmdAddContact.ExecuteNonQuery();
                return numUpdated;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateGuarantee :- " + ex.Message);
                return numUpdated;
            }
            finally
            {
                DBManager.CloseDBConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRequest();
            LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
            CheckForClashingDates();
        }

        private void radAbs_CheckedChanged(object sender, EventArgs e)
        {
            LoadTeacherDates(Utils.CheckLong(cmbTeacher.SelectedValue));
            UpdateAbsenceVisibility();
        }

        private void UpdateAbsenceVisibility()
        {
            if (radAbs.Checked)
            {
                chkAccepted.Visible = false;
                grpAbsence.Visible = true;
                grpAvailability.Visible = false;
                lblType.Text = "Register Absence";

            }
            else
            {
                chkAccepted.Visible = true;
                grpAbsence.Visible = false;
                grpAvailability.Visible = true;
                lblType.Text = "Availability";

            }
        }

        private void cmbTeacher_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _teacherID = Utils.CheckLong(cmbTeacher.SelectedValue);
            LoadTeacherDates(_teacherID);
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
            txtNotes.Clear();
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
                        if (radAvailability.Checked) rowInfo.isGuarantee = true;
                        else rowInfo.isGuarantee = false;
                        rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                        rowInfo.Teacher = gvGuaranteed.GetRowCellValue(info.RowHandle, "dte").ToString();
                        //rowInfo.Description = gvGuaranteed.GetRowCellValue(info.RowHandle, info.Column).ToString();
                        rowInfo.Description = txtDetails.Text;
                        int[] selectedRows = gvGuaranteed.GetSelectedRows();

                        //Get IDs from selected rows
                        long[] selectedIDs;
                        if (selectedRows.Length > 1)
                        {
                            //Multiple rows selected
                            selectedIDs = new long[selectedRows.Length];

                            for (int i = 0; i < selectedRows.Length; i++)
                            {
                                int rowNum = selectedRows[i];
                                long? rowID = gvGuaranteed.GetRowCellValue(rowNum, "ID") as long?;
                                if (rowID != null) selectedIDs[i] = (long)gvGuaranteed.GetRowCellValue(rowNum, "ID");
                            }
                        }
                        else
                        {
                            //single row selected
                            selectedIDs = new long[1];
                            selectedIDs[0] = (long)gvGuaranteed.GetRowCellValue(info.RowHandle, "ID");
                        }
                        rowInfo.SelectedRows = selectedIDs;
                    }

                    GridViewCustomMenu menu = new GridViewCustomMenu(gvGuaranteed);
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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            LoadTeacherDates(_teacherID);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeacherDates(_teacherID);
            btnDblBkgs.Visible = false;
            TickAllDateCheckBoxes();
            CheckForClashingDates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager dbm = new DBManager();

                int[] myRowIDs = gvGuaranteed.GetSelectedRows();
                long[] itemIDs = new long[myRowIDs.Length];
                int i = 0;
                foreach (int iD in myRowIDs)
                {
                    long itemID = (long)gvGuaranteed.GetRowCellValue(iD, "ID");
                    itemIDs[i] = itemID;
                    i += 1;
                }
                dbm.DeleteGuarantee(itemIDs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting items: " + ex.Message);
            }
            finally
            {
                LoadTeacherDates(_teacherID);

            }


        }

        private void rdoLastName_CheckedChanged(object sender, EventArgs e)
        {
            Utils.PopulateTeacher(cmbTeacher, rdoLastName.Checked);
        }

        private void rdoFirstName_CheckedChanged(object sender, EventArgs e)
        {
            Utils.PopulateTeacher(cmbTeacher, rdoLastName.Checked);
        }

        private void gvGuaranteed_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.Caption != "Details") return;

                string cellValue = e.Value.ToString();
                int updatedRowCount = 0;
                long id = 0;

                string cellValueDate = gvGuaranteed.GetRowCellValue(e.RowHandle, "dte").ToString();
                DateTime date = DateTime.Parse(cellValueDate);
                long teacherID = Utils.CheckLong(cmbTeacher.SelectedValue);

                GuaranteedDay gDay = db.GuaranteedDays.Where(p => p.Date == date && p.TeacherID == teacherID).FirstOrDefault();
                id = gDay.ID;

                updatedRowCount = UpdateBooking(id, cellValue);

                if (updatedRowCount > 0)
                    MessageBox.Show("Note Updated");
                else
                    MessageBox.Show("Error! Note update failed");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Note update failed : " + ex.Message);
            }
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNotes.Clear();
        }


        private void CheckForClashingDates()
        {

            dsClashingDates = new DBManager().GetClashingBookingDetails();
            if (dsClashingDates.Tables[0].Rows.Count > 0)
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

            #region Old method using Linq
            //DateTime sDate = dtFrom.Value.Date;
            //DateTime eDate = dtTo.Value.Date;
            //long teacherID = -1;
            //teacherID = Utils.CheckLong(cmbTeacher.SelectedValue);

            //if (teacherID != -1)
            //{
            //    table.Rows.Clear();
            //    isClashing = false;

            //    List<MasterBooking> oMasterBookings = db.MasterBookings.ToList().OrderBy(a => a.ContactID).Where(a => ((a.ContactID == teacherID) && (
            //                    (sDate.Date >= (a.StartDate.Date) && sDate.Date <= (a.EndDate.Date) && eDate.Date > (a.StartDate.Date) && eDate.Date >= (a.EndDate.Date)) ||
            //                    (sDate.Date >= (a.StartDate.Date) && sDate.Date < (a.EndDate.Date) && eDate.Date > (a.StartDate.Date) && eDate.Date <= (a.EndDate.Date)) ||
            //                    (sDate.Date <= (a.StartDate.Date) && sDate.Date < (a.EndDate.Date) && eDate.Date >= (a.StartDate.Date) && eDate.Date <= (a.EndDate.Date)) ||
            //                    (sDate.Date <= (a.StartDate.Date) && eDate.Date >= (a.EndDate.Date))))).ToList();


            //    List<School> oSchools = db.Schools.ToList();

            //    foreach (MasterBooking oMasterBooking in oMasterBookings)
            //    {
            //        List<Booking> oBookings = db.Bookings.ToList().Where(p => p.MasterBookingID == oMasterBooking.ID).ToList();
            //        if (oBookings.Count > 0)
            //        {
            //            foreach (Booking oBooking in oBookings)
            //            {
            //                if (oBooking.Date >= sDate && oBooking.Date <= eDate)
            //                {
            //                    isClashing = true;
            //                }
            //            }

            //            if (isClashing)
            //            {
            //                string schoolName = "N/A";
            //                if (oMasterBooking.SchoolID > 0)
            //                    schoolName = oSchools.Where(p => p.ID == oMasterBooking.SchoolID).SingleOrDefault().SchoolName;
            //                table.Rows.Add(oMasterBooking.ID, schoolName, oMasterBooking.StartDate, oMasterBooking.EndDate);

            //                btnDblBkgs.Visible = true;
            //                flashtimer1.Interval = 500;
            //                flashtimer1.Enabled = true;
            //            }
            //            else
            //            {
            //                btnDblBkgs.Visible = false;
            //                flashtimer1.Enabled = false;
            //            }

            //        }
            //    }
            //} 
            #endregion
        }

        private void btnDblBkgs_Click(object sender, EventArgs e)
        {
            frmViewClashingBookings frm = new frmViewClashingBookings();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.TopMost = true;
            frm.Show();
        }

        private void flashtimer1_Tick(object sender, EventArgs e)
        {
            if (btnDblBkgs.BackColor == Color.Crimson)
            {
                btnDblBkgs.BackColor = Color.Orange;
            }
            else btnDblBkgs.BackColor = Color.Crimson;
        }

        private void TickAllDateCheckBoxes()
        {
            //Tick date check boxes
            chkMon.Checked = true;
            chkTue.Checked = true;
            chkWed.Checked = true;
            chkThu.Checked = true;
            chkFri.Checked = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DataSet ds = new DBManager().GetClashingBookingDetails();

            frmViewClashingBookings frm = new frmViewClashingBookings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true;
            frm.Show();
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
            int off = 0;
            int acct = 0;
            int conf = 0;
            int dets = 0;
            int none = 0;

            switch (_rowInfo.Status)
            {
                case "Offered":
                    off = 1;
                    break;

                case "Accepted":
                    acct = 1;
                    break;
            }
            if (_rowInfo.isGuarantee)
            {
                Items.Clear();
                int vv = GridMenuImages.Column.Images.Count;
                int vw = GridMenuImages.Footer.Images.Count;
                int vx = GridMenuImages.GroupPanel.Images.Count;
                Items.Add(CreateMenuItem("Guarantee Offered", imageList.Images[off], "Offered", true));
                Items.Add(CreateMenuItem("Guarantee Accepted", imageList.Images[acct], "Accepted", true));
                Items.Add(CreateMenuItem("Texted", imageList.Images[acct], "Texted", true));
                Items.Add(CreateMenuItem("Available", imageList.Images[acct], "Available", true));
                Items.Add(CreateMenuItem("Unavailable", imageList.Images[acct], "Unavailable", true));
                Items.Add(CreateMenuItem("Priority", imageList.Images[acct], "Priority", true));//Ask
                Items.Add(CreateMenuItem("Delete", imageList.Images[conf], "Delete", true));
            }
            else
            {
                Items.Clear();
                int vv = GridMenuImages.Column.Images.Count;
                int vw = GridMenuImages.Footer.Images.Count;
                int vx = GridMenuImages.GroupPanel.Images.Count;
                Items.Add(CreateMenuItem("AA", imageList.Images[off], "AA", true));
                Items.Add(CreateMenuItem("AAL", imageList.Images[acct], "AAL", true));
                Items.Add(CreateMenuItem("Sick", imageList.Images[conf], "Sick", true));
                Items.Add(CreateMenuItem("Other", imageList.Images[conf], "Other", true));
            }
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
            if (_rowInfo.isGuarantee)
            {
                //Update Guarantees
                //1- guaranteed offered, 2-guar accepted, 3-texted, 4-available, 5-unavailable
                switch (status)
                {
                    case "Offered":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 1);
                        break;
                    case "Accepted":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 2);
                        break;
                    case "Texted":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 3);
                        break;
                    case "Available":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 4);
                        break;
                    case "Unavailable":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 5);
                        break;
                    case "Priority":
                        response = dbm.UpdateGuarantee(_rowInfo.SelectedRows, 6);
                        break;
                    case "Delete":
                        response = dbm.DeleteGuarantee(_rowInfo.SelectedRows);
                        break;

                }
            }
            else
            {
                //Update Bookings
                if (string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show("Please enter the Details/Notes for this absence.");
                    return;
                }
                else
                {
                    response = dbm.UpdateBookings(_rowInfo.SelectedRows, status, description);
                }

            }


        }

    }

}



