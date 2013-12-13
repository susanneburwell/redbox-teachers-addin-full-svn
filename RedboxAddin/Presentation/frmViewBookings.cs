﻿using System;
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

namespace RedboxAddin.Presentation
{
    public partial class frmViewBookings : Form
    {
        public frmViewBookings()
        {
            InitializeComponent();
        }

        private void frmViewBookings_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    Utils.PopulateSchools(cmbSchool);
                    Utils.PopulateTeacher(cmbTeacher);
                }

                //set dates
                dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
                dtTo.Value = dtFrom.Value.AddDays(5);
                LoadGrid();
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

        private void LoadGrid()
        {

            try
            {
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

                    List<RBookings> bookings = dbm.GetBookings(schoolID, teacherID, startdate, enddate, status);
                    gridControl1.DataSource = bookings;
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
            LoadGrid();
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
                LoadGrid();
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
                LoadGrid();
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

    }
}
