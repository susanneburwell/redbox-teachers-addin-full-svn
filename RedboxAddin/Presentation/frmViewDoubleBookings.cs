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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace RedboxAddin.Presentation
{
    public partial class frmViewDoubleBookings : Form
    {
        public frmViewDoubleBookings()
        {
            InitializeComponent();
        }

        private void frmViewDoubleBookings_Load(object sender, EventArgs e)
        {
            timer1.Interval = 250;
            timer1.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                CheckDoubleBookings();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in timer1_Tick: " + ex.Message);
            }
        }

        private void CheckDoubleBookings()
        {
            try
            {
                gridControl2.DataSource = null;
                gridControl1.DataSource = new DBManager().CheckDoubleBookings();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDoubleBookings: " + ex.Message );
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                Point pt = gridControl1.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));

                    string ContactID = gridView1.GetRowCellValue(info.RowHandle, "ContactID").ToString();
                    DateTime oDate = Utils.CheckDate(gridView1.GetRowCellValue(info.RowHandle, "Date"));
                    string dDate = oDate.ToString("yyyyMMdd");

                    gridControl2.DataSource = new DBManager().GetBookings(ContactID, dDate);

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridControl1_Click: " + ex.Message);
            }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = gridControl2.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView2.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));

                    string MbkgID = gridView2.GetRowCellValue(info.RowHandle, "MasterBookingID").ToString();
                    long MasterbkgID = Convert.ToInt64(MbkgID);
                    if (MasterbkgID >0)
                    {
                        frmMasterBooking fq = new frmMasterBooking(MasterbkgID);
                        fq.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridControl2_DoubleClick: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CheckDoubleBookings();
        }


    }
}
