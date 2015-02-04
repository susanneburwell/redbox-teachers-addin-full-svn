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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace RedboxAddin.Presentation
{
    public partial class frmViewBookings : Form
    {
        public frmViewBookings()
        {
            InitializeComponent();

            //RepositoryItemCheckEdit checkEdit = gridControl1.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;

            //checkEdit.ValueChecked = "Yes";
            //checkEdit.ValueUnchecked = "No";

            //checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            //gridView1.Columns["LT"].ColumnEdit = checkEdit;
        }

        private void frmViewBookings_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    Utils.PopulateSchools(cmbSchool);
                    Utils.PopulateTeacher(cmbTeacher, true);
                    Utils.PopulateBookingStatuses(cmbStatus);
                }

                //set dates
                dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
                dtTo.Value = dtFrom.Value.AddDays(5);
                LoadGrid(false);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }


        }

        private void RestoreLayout()
        {
            try
            {
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ViewBookingsFormDump.xml");
            }
            catch (Exception) { }
        }

        private void SaveLayout()
        {
            try
            {
                gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ViewBookingsFormDump.xml");
            }
            catch (Exception) { }
        }

        private string lastFilter = "";
        private void LoadGrid(bool radChanged)
        {

            try
            {
                if (!radChanged) lastFilter = "";
                string schoolID = "";
                string teacherID = "";
                string status = "";
                string startdate = "";
                string enddate = "";
                DBManager dbm = new DBManager();
                if (chkDate.Checked)
                {
                    startdate = dtFrom.Value.ToString("yyyyMMdd");
                    enddate = dtTo.Value.ToString("yyyyMMdd");
                }


                if (chkUnassigned.Checked)
                {
                    //Find unassigned bookings
                    List<RBookings> bookings = dbm.GetUnassignedBookings(startdate, enddate);
                    gridControl1.DataSource = bookings;
                }
                else
                {
                    if (chkSch.Checked) schoolID = cmbSchool.SelectedValue.ToString();
                    if (chkTeach.Checked) teacherID = cmbTeacher.SelectedValue.ToString();
                    if (chkStatus.Checked) status = cmbStatus.Text.Trim();

                    string filter = "ALL";
                    if (radLT.Checked) filter = "LT";
                    if (radnoLT.Checked) filter = "NOLT";

                    if (lastFilter != filter)
                    {
                        //we need tostop the form getting loaded twice if two rads change
                        lastFilter = filter;
                        List<RBookings> bookings = dbm.GetBookings(schoolID, teacherID, startdate, enddate, status, filter);
                        gridControl1.DataSource = bookings;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadGrid(frmViewBookings): " + ex.Message);
            }
            RestoreLayout();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(false);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SaveLayout();
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
                Debug.DebugMessage(2, "Error in dgcAvail_DoubleClick: " + ex.Message);
            }
        }

        private void chkUnassigned_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnassigned.Checked)
            {
                lblSchool.Enabled = false;
                lblStatus.Enabled = false;
                lblTeacher.Enabled = false;
                cmbSchool.Enabled = false;
                cmbStatus.Enabled = false;
                cmbTeacher.Enabled = false;
                chkSch.Enabled = false;
                chkStatus.Enabled = false;
                chkTeach.Enabled = false;
            }
            else
            {
                lblSchool.Enabled = true;
                lblStatus.Enabled = true;
                lblTeacher.Enabled = true;
                cmbSchool.Enabled = true;
                cmbStatus.Enabled = true;
                cmbTeacher.Enabled = true;
                chkSch.Enabled = true;
                chkStatus.Enabled = true;
                chkTeach.Enabled = true;
            }
        }

        private void bnFwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (radWeek.Checked) dtFrom.Value = dtFrom.Value.AddDays(7);
                else dtFrom.Value = dtFrom.Value.AddMonths(1);
                SetToDate();
                LoadGrid(false);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in bnFwd_Click: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (radWeek.Checked) dtFrom.Value = dtFrom.Value.AddDays(-7);
                else dtFrom.Value = dtFrom.Value.AddMonths(-1);
                SetToDate();
                LoadGrid(false);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in bnFwd_Click: " + ex.Message);
            }
        }

        private void SetToDate()
        {
            try
            {
                if (radWeek.Checked) dtTo.Value = dtFrom.Value.AddDays(5);
                else dtTo.Value = dtFrom.Value.AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SetToDate: " + ex.Message);
            }
        }

        private void radWeek_CheckedChanged(object sender, EventArgs e)
        {
            SetToDate();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column == LT)
            //{
            //    if ((bool)e.Value)
            //        e.DisplayText = "Yes";
            //    else
            //        e.DisplayText = "No";
            //}
        }


        private void radLT_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid(true);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            try
            {
                string columnname = e.Column.FieldName;
                string expname = "";//"MonColor";
                int myRow = e.RowHandle;

                //  redd/yell  redd forecolr   yel back colour
                string myStatus = gridView1.GetRowCellValue(myRow, "BookingStatus").ToString();
                string myLT = gridView1.GetRowCellValue(myRow, "LT").ToString();
                bool isLT = false;
                if (myLT.ToLower() == "true") isLT = true;

                string myVal = Utils.SetColours(myStatus, false, isLT, null);

                //switch (columnname)
                //{
                //    case "Monday":
                //        expname = "MonColor";
                //        break;
                //    case "Tuesday":
                //        expname = "TueColor";
                //        break;
                //    case "Wednesday":
                //        expname = "WedColor";
                //        break;
                //    case "Thursday":
                //        expname = "ThuColor";
                //        break;
                //    case "Friday":
                //        expname = "FriColor";
                //        break;

                //    case "Teacher":
                //        //string myG = gridView1.GetRowCellValue(myRow, "Guar").ToString();
                //        //string myP = gridView1.GetRowCellValue(myRow, "Prio").ToString();
                //        //if (myG == "1")
                //        //{
                //        //    e.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen;
                //        //}
                //        //else if (myP == "1")
                //        //{
                //        //    e.Appearance.BackColor = System.Drawing.Color.PeachPuff;
                //        //}
                //        //else
                //        //{
                //        //    string myL = gridView1.GetRowCellValue(myRow, "LongTerm").ToString();//ASK
                //        //    if (myL == "1") e.Appearance.BackColor = System.Drawing.Color.Violet;
                //        //}
                //        //return;
                //        break;

                //    default:
                //        //return;
                //        break;
                //}


                //If colours are set
                if (myVal.Length > 8)
                {
                    string backcolor = myVal.Substring(5, 4);
                    string forecolor = myVal.Substring(0, 4);
                    string italics = "e";
                    if (myVal.Length > 9) italics = myVal.Substring(9, 1);

                    switch (backcolor)
                    {
                        case "yell":
                            e.Appearance.BackColor = System.Drawing.Color.Yellow;
                            break;
                        case "gray":
                            e.Appearance.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "lblu":
                            e.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
                            break;
                        case "dblu":
                            e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
                            break;
                        case "brwn":
                            e.Appearance.BackColor = System.Drawing.Color.BurlyWood;
                            break;
                        case "gree": //guaranteed
                            e.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen;
                            break;
                        case "pink": //texted
                            e.Appearance.BackColor = System.Drawing.Color.LightPink;
                            break;
                        case "orng": //unavailable
                            e.Appearance.BackColor = System.Drawing.Color.Orange;
                            break;
                        case "lgre": //unavailable
                            e.Appearance.BackColor = System.Drawing.Color.PaleGreen;
                            break;
                        case "pech": //unavailable
                            e.Appearance.BackColor = System.Drawing.Color.PeachPuff;
                            break;
                        case "purp":
                            e.Appearance.BackColor = System.Drawing.Color.Violet;
                            e.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

                            break;
                        default:
                            break;
                    }

                    switch (forecolor)
                    {
                        case "redd":
                            e.Appearance.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "purp":
                            e.Appearance.ForeColor = System.Drawing.Color.Purple;
                            break;
                        case "blck":
                            e.Appearance.ForeColor = System.Drawing.Color.Black;
                            break;

                        default:
                            break;
                    }

                    if (italics == "i")
                    {
                        e.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_CustomDrawCell: " + ex.Message);
            }
        }



    }
}
