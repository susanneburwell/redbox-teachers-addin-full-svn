using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RedboxAddin.BL;
using RedboxAddin.DL;
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
    public partial class frmViewClashingBookings : Form
    {
        string teacherName = string.Empty;
        long teacherID = 0;
        DataTable dtClashingMasterBookings = null;
        DataSet dsClashingMasterBookings = null;

        DateTime sDate;
        DateTime eDate;
        RedBoxDB db;

        public frmViewClashingBookings()
        {
            InitializeComponent();
        }

        public frmViewClashingBookings(long teacherID, string teacherName, DateTime startDate, DateTime endDate, DataTable clashingMasterBookings)
        {
            InitializeComponent();
            this.teacherID = teacherID;
            this.teacherName = teacherName;
            this.dtClashingMasterBookings = clashingMasterBookings;
            this.sDate = startDate;
            this.eDate = endDate;
            gridControl1.DataSource = clashingMasterBookings;
        }

        public frmViewClashingBookings(DataSet clashingMasterBookings)
        {
            InitializeComponent();

            DataTable table = clashingMasterBookings.Tables[0];
            gridControl1.DataSource = table;

        }


        private void frmViewClashingBookings_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                db = new RedBoxDB(CONNSTR);

                //this.Text = "Clash Bookings for " + this.teacherName;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmViewClashingBookings_Load: " + ex.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = gridControl1.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                    string masterbooking = gridView1.GetRowCellValue(info.RowHandle, "MasterBookingID").ToString();
                    long id = Convert.ToInt64(masterbooking);
                    frmMasterBooking fq = new frmMasterBooking(id);
                    fq.Show();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_DoubleClick: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable table = new DBManager().GetClashes().Tables[0];
            if (table.Rows.Count > 0)
                gridControl1.DataSource = table;
            else
                gridControl1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        //private void Test()
        //{

        //    bool isClashing = false;
        //    List<School> oSchools = db.Schools.ToList();

        //    DataTable table = new DataTable();
        //    table.Columns.Add("MasterBookingID", typeof(long));
        //    table.Columns.Add("TeacherName", typeof(string));
        //    table.Columns.Add("School", typeof(string));
        //    table.Columns.Add("StartDate", typeof(DateTime));
        //    table.Columns.Add("EndDate", typeof(DateTime));

        //    try
        //    {
        //        List<MasterBooking> oMasterBookings = db.MasterBookings.ToList().ToList();

        //        foreach (MasterBooking oMasterBooking in oMasterBookings)
        //        {
        //            List<Booking> oBookings = db.Bookings.ToList().Where(p => p.MasterBookingID == oMasterBooking.ID).ToList();
        //            if (oBookings.Count > 0)
        //            {
        //                foreach (Booking oBooking in oBookings)
        //                {
        //                    int count =  db.GuaranteedDays.ToList().Where(p => p.TeacherID == oMasterBooking.ContactID && p.Date == oBooking.Date).Count();
        //                    if (count > 0)
        //                        isClashing = true;
        //                }

        //                if (isClashing)
        //                {
        //                    string schoolName = "N/A";
        //                    if (oMasterBooking.SchoolID > 0)
        //                        schoolName = oSchools.Where(p => p.ID == oMasterBooking.SchoolID).SingleOrDefault().SchoolName;
        //                    table.Rows.Add(oMasterBooking.ID, schoolName, oMasterBooking.StartDate, oMasterBooking.EndDate);
        //                }
        //            }
        //        }
        //        gridControl1.DataSource = table;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in btnRefresh_Click: " + ex.Message);
        //    }
        //}

        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    Test();
        //}


    }
}
