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
    public partial class frmLongTermEnding : Form
    {
        public frmLongTermEnding()
        {
            InitializeComponent();
        }

        private void frmLongTermEnding_Load(object sender, EventArgs e)
        {
            DefaultDateTime();
            LoadGrid();
        }

        private void LoadGrid()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string startdate = dtpFrom.DateTime.ToString("yyyyMMdd");
                string enddate = dtpTo.DateTime.ToString("yyyyMMdd");
                DBManager dbm = new DBManager();
                gcLongTermEditing.DataSource = dbm.GetLongTermBooking(startdate, enddate).Tables[0];
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Load LTBR Grid :- " + ex.Message);
            }

            Cursor.Current = Cursors.Default;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void DefaultDateTime()
        {
            //dtpFrom.DateTime = DateTime.Now.AddDays(-28);
            //dtpTo.DateTime = DateTime.Now;
            dtpFrom.DateTime = Utils.GetFirstDayoftheWeek(DateTime.Today);
            dtpTo.DateTime = dtpFrom.DateTime.AddDays(27);
        }

        private void gvLongTermEditing_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string masterbooking = gvLongTermEditing.GetRowCellValue(e.RowHandle, "MasterBookingID").ToString();
                long id = Convert.ToInt64(masterbooking);
                frmMasterBooking fq = new frmMasterBooking(id);
                fq.Show();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gvLongTermEditing_RowClick :- " + ex.Message);
                Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
        }

        private void dtpFrom_DateTimeChanged(object sender, EventArgs e)
        {
            FromTimechange();
        }

        private void FromTimechange()
        {
            try
            {
                DateTime fromDate = dtpFrom.DateTime;
                dtpFrom.DateTime = Utils.GetFirstDayoftheWeek(fromDate);
                dtpTo.DateTime = dtpFrom.DateTime.AddDays(27);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in FromTimechange :- " + ex.Message);
            }

        }

    }
}
