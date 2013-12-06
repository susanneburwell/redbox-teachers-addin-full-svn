﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedboxAddin.DL;
using RedboxAddin.BL;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace RedboxAddin.Presentation
{
    public partial class frmAvailabilitySheet : Form
    {
        // RedBoxDB db;

        public frmAvailabilitySheet()
        {
            InitializeComponent();
        }

        private void frmAvailabilitySheet_Load(object sender, EventArgs e)
        {
            //string CONNSTR = DavSettings.getDavValue("CONNSTR");
            //db = new RedBoxDB(CONNSTR);
            //gridControl1.DataSource = bindingSource1;

            //createGridViewCondition();
            RestoreLayout();
            LoadTable();
            
        }

        private void LoadTable()
        {
            try
            {
                //Get first day of week
                DateTime input = dtFrom.Value;
                int delta = DayOfWeek.Monday - input.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = input.AddDays(delta).Date;

                string wheresql = WHERESQL();
                DataSet msgDs = new DBManager().GetAvailabilityDS(monday, wheresql);
                //bindingSource1.DataSource = msgDs;
                gridControl1.DataSource = new DBManager().GetAvailability(monday, wheresql);
                gridView1.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                gridView1.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                gridView1.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                gridView1.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                gridView1.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");
                
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTable: " + ex.Message);
            }
        }

        private string WHERESQL()
        {
            try
            {

                //Get qualifications
                string SQL = "";
                if (chkQTS.Checked) SQL += " OR [QTS] = 'true' ";
                if (chkNQT.Checked) SQL += " OR [NQT] = 'true' ";
                if (chkOTT.Checked) SQL += " OR [OverseasTrainedTeacher]  = 'true' ";
                if (chkTA.Checked) SQL += " OR [TA]  = 'true' ";
                if (chkQNN.Checked) SQL += " OR [QNN]  = 'true' ";
                if (chkNN.Checked) SQL += " OR [NN]  = 'true' ";
                if (chkSEN.Checked) SQL += " OR [SEN]  = 'true' ";

                //Get Year Groups
                string SQL2 = "";
                if (chkNur.Checked) SQL2 += " AND [Nur] = 'true' ";
                if (chkRec.Checked) SQL2 += " AND [Rec] = 'true' ";
                if (chkYr1.Checked) SQL2 += " AND [Yr1] = 'true' ";
                if (chkYr2.Checked) SQL2 += " AND [Yr2] = 'true' ";
                if (chkYr3.Checked) SQL2 += " AND [Yr3] = 'true' ";
                if (chkYr4.Checked) SQL2 += " AND [Yr4] = 'true' ";
                if (chkYr5.Checked) SQL2 += " AND [Yr5] = 'true' ";
                if (chkYr6.Checked) SQL2 += " AND [Yr6] = 'true' ";


                if (SQL == "")
                {
                    if (SQL2 != "") SQL = " WHERE " + SQL2.Substring(4);
                }
                else
                {
                    if (SQL2 == "") SQL = " WHERE " + SQL.Substring(3);
                    else SQL = " WHERE [current] = 'true' AND (" + SQL.Substring(3) + ") AND (" + SQL2.Substring(4) + ")";

                }


                return SQL;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in WHERESQL: " + ex.Message);
                return "";
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

        private void frmAvailabilitySheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Point pt = gridControl1.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));

                    string teacher = gridView1.GetRowCellValue(info.RowHandle, "Teacher").ToString();
                    string description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString();

                    List<long> MasterBookingIDs = LINQmanager.GetMasterBookingIDs(teacher, colCaption, description);

                    if (MasterBookingIDs.Count > 0)
                    {
                        frmMasterBooking fq = new frmMasterBooking(MasterBookingIDs[0]);
                        fq.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in dgcAvail_DoubleClick: " + ex.Message);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {

            dtFrom.Value = dtFrom.Value.AddDays(-7);

        }

        private void bnFwd_Click(object sender, EventArgs e)
        {

            dtFrom.Value = dtFrom.Value.AddDays(7);

        }

        private void createGridViewCondition()
        {
            StyleFormatCondition condition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            condition1.Appearance.BackColor = Color.SeaShell;
            condition1.Appearance.Options.UseBackColor = true;
            condition1.Appearance.Options.UseFont = false;
            condition1.Condition = FormatConditionEnum.Expression;
            condition1.Expression = "[MonG] >0";
            condition1.ApplyToRow = false;
            gridView1.FormatConditions.Add(condition1);
        }

        private void btnEY_Click(object sender, EventArgs e)
        {
            bool set = !chkNur.Checked;
            chkNur.Checked = set;
            chkRec.Checked = set;
            LoadTable();
        }

        private void btnKS1_Click(object sender, EventArgs e)
        {
            bool set = !chkYr1.Checked;
            chkYr1.Checked = set;
            chkYr2.Checked = set;
            LoadTable();
        }

        private void btnKS2_Click(object sender, EventArgs e)
        {
            bool set = !chkYr3.Checked;
            chkYr3.Checked = set;
            chkYr4.Checked = set;
            chkYr5.Checked = set;
            chkYr6.Checked = set;
            LoadTable();
        }


    }
}
