using System;
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
using RedboxAddin.Models;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace RedboxAddin.Presentation
{
    public partial class frmAvailabilitySheet : Form
    {
        // RedBoxDB db;


        public frmAvailabilitySheet()
        {
            InitializeComponent();
            availabilityGrid1.DblClick += new EventHandler(availabilityGrid_DblClick);
            availabilityGrid1.RepaintRequired += new EventHandler(availabilityGrid_Repaint);
        }

        private void frmAvailabilitySheet_Load(object sender, EventArgs e)
        {
            //string CONNSTR = DavSettings.getDavValue("CONNSTR");
            //db = new RedBoxDB(CONNSTR);
            //gridControl1.DataSource = bindingSource1;


            //Not used any more
            //We now use gridView1_CustomDrawCell as it is quicker and more flexible.
            //createGridViewConditions to set colours based on grid view;
            //createGridViewConditions(this.Mon, "MonColor");
            //createGridViewConditions(this.Tue, "TueColor");
            //createGridViewConditions(this.Wed, "WedColor");
            //createGridViewConditions(this.Thur, "ThuColor");
            //createGridViewConditions(this.Fri, "FriColor");
            //**********************************

            //Colour name if guaranteed
            //StyleFormatCondition st1 = new StyleFormatCondition();
            //st1.Appearance.BackColor = System.Drawing.Color.LightGreen;
            //st1.Appearance.Options.UseBackColor = true;
            //st1.Column = this.Teacher; // this.Mon;
            //st1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            //st1.Expression = "!IsNullOrEmpty([MonG])";
            //this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { st1 });

            //RestoreLayout();
            dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
            LoadTable();
            CheckDoubleBookingsTimer1.Interval = 250;
            CheckDoubleBookingsTimer1.Enabled = true;

        }

        private void LoadTable()
        {
            try
            {
                //this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                string wheresql = "";
                if (chkJustBookings.Checked) wheresql = JustBookingSQL();
                else wheresql = WHERESQL();

                //Application.DoEvents();
                //Get first day of week
                DateTime input = dtFrom.Value;
                int delta = DayOfWeek.Monday - input.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = input.AddDays(delta).Date;

                availabilityGrid1.LoadTable(wheresql, monday);


                //DataSet msgDs = new DBManager().GetAvailabilityDS(monday, wheresql);
                ////bindingSource1.DataSource = msgDs;
                //gridControl1.DataSource = new DBManager().GetAvailability(monday, wheresql);
                //gridView1.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                //gridView1.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                //gridView1.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                //gridView1.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                //gridView1.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTable: " + ex.Message);
                this.UseWaitCursor = false;
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
                if (chkTeacher.Checked) SQL += " OR [Teacher]  = 'true' ";

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
                if (chkLongTerm.Checked) SQL2 += " AND [LT] = 'true' ";
                if (chkGuaranteed.Checked) SQL2 += " AND G1.gar > 0 ";


                if (SQL == "")
                {
                    if (SQL2 != "") SQL = " WHERE [current] = 'true' AND (" + SQL2.Substring(4) + ") ";
                    else SQL = " WHERE [current] = 'true' ";
                }
                else
                {
                    if (SQL2 == "") SQL = "WHERE [current] = 'true' AND (" + SQL.Substring(3) + ") ";
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

        private string JustBookingSQL()
        {
            try
            {

                //Get qualifications
                string SQL = "";
                SQL += "WHERE s1.School <> '' OR s2.School <> '' OR s3.School <> '' OR s4.School <> '' or s5.School <> '' ";


                return SQL;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in WHERESQL: " + ex.Message);
                return "";
            }
        }



        private void CheckDoubleBookings()
        {
            try
            {
                DBManager dbm = new DBManager();
                List<RDoubleBookings> listDblB = dbm.CheckDoubleBookings();
                if (listDblB.Count > 0)
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
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDoubleBookings: " + ex.Message);
            }
        }

        private void RestoreLayout()
        {
            try
            {
                availabilityGrid1.RestoreLayout();
                //gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        private void SaveLayout()
        {
            try
            {
                availabilityGrid1.SaveLayout();
                //gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        private void frmAvailabilitySheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveLayout();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTable();
            CheckDoubleBookings();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        protected void availabilityGrid_DblClick(object sender, EventArgs e)
        {
            try
            {
                REventArgs e1 = e as REventArgs;

                string teacher = e1.Teacher;
                string description = e1.Description;
                string colCaption = e1.ColumnCaption;

                List<long> MasterBookingIDs = LINQmanager.GetMasterBookingIDs(teacher, colCaption, description);

                if (MasterBookingIDs.Count > 0)
                {
                    frmMasterBooking fq = new frmMasterBooking(MasterBookingIDs[0]);
                    fq.Show();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in dgcAvail_DoubleClick: " + ex.Message);
            }
        }

        protected void availabilityGrid_Repaint(object sender, EventArgs e)
        {
            try
            {
                int topRow = availabilityGrid1.getTopRow();
                LoadTable();
                availabilityGrid1.setTopRow(topRow);
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in availabilityGrid_Repaint: " + ex.Message);
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

        private void createGridViewConditions(GridColumn gridColumn, string expName)
        {
            //Foreground: Red , Purple, Black
            //Background: yello, gray, light blue, darkblue , purple

            //Foreground: Red 
            StyleFormatCondition st1 = new StyleFormatCondition();
            st1.Appearance.ForeColor = System.Drawing.Color.Red;
            st1.Appearance.Options.UseForeColor = true;
            st1.Column = gridColumn; // this.Mon;
            st1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st1.Expression = "Substring([" + expName + "],0,4)= \'redd\'";

            //Foreground: Purple
            StyleFormatCondition st2 = new StyleFormatCondition();
            st2.Appearance.ForeColor = System.Drawing.Color.Purple;
            st2.Appearance.Options.UseForeColor = true;
            st2.Column = gridColumn; // this.Mon;
            st2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st2.Expression = "Substring([" + expName + "],0,4)= \'purp\'";

            //Foreground: Black
            StyleFormatCondition st3 = new StyleFormatCondition();
            st3.Appearance.ForeColor = System.Drawing.Color.Black;
            st3.Appearance.Options.UseForeColor = true;
            st3.Column = gridColumn; // this.Mon;
            st3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st3.Expression = "Substring([" + expName + "],0,4)= \'blck\'";


            //Background: yellow
            StyleFormatCondition st4 = new StyleFormatCondition();
            st4.Appearance.BackColor = System.Drawing.Color.Yellow;
            st4.Appearance.Options.UseBackColor = true;
            st4.Column = gridColumn;
            st4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st4.Expression = "Substring([" + expName + "],5,4)= \'yell\'";

            //Background: gray
            StyleFormatCondition st5 = new StyleFormatCondition();
            st5.Appearance.BackColor = System.Drawing.Color.LightGray;
            st5.Appearance.Options.UseBackColor = true;
            st5.Column = gridColumn; ;
            st5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st5.Expression = "Substring([" + expName + "],5,4)= \'gray\'";

            //Background: light blue
            StyleFormatCondition st6 = new StyleFormatCondition();
            st6.Appearance.BackColor = System.Drawing.Color.LightBlue;
            st6.Appearance.Options.UseBackColor = true;
            st6.Column = gridColumn; ;
            st6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st6.Expression = "Substring([" + expName + "],5,4)= \'lblu\'";

            //Background: darkblue
            StyleFormatCondition st7 = new StyleFormatCondition();
            st7.Appearance.BackColor = System.Drawing.Color.DarkBlue;
            st7.Appearance.Options.UseBackColor = true;
            st7.Column = gridColumn; ;
            st7.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st7.Expression = "Substring([" + expName + "],5,4)= \'dblu\'";

            //Background: purple
            StyleFormatCondition st8 = new StyleFormatCondition();
            st8.Appearance.BackColor = System.Drawing.Color.Violet;
            st8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            st8.Appearance.Options.UseFont = true;
            st8.Appearance.Options.UseBackColor = true;
            st8.Column = gridColumn; ;
            st8.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            st8.Expression = "Substring([" + expName + "],5,4)= \'purp\'";

            // this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { st1, st2, st3, st4, st5, st6, st7, st8 });


            //st2.Appearance.BackColor = System.Drawing.Color.Purple;
            //st2.Appearance.Options.UseBackColor = true;
            //st2.Column = this.Mon;
            //st2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            //st2.Expression = "Substring([MonColor],5,4)= \'purp\'";



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

        private void CheckDoubleBookingsTimer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CheckDoubleBookingsTimer1.Enabled = false;
                CheckDoubleBookings();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CheckDoubleBookingsTimer: " + ex.Message);
            }
        }

        private void btnDblBkgs_Click(object sender, EventArgs e)
        {
            frmViewDoubleBookings fdb = Application.OpenForms["frmViewDoubleBookings"] as frmViewDoubleBookings;
            if (fdb == null)
            {
                fdb = new frmViewDoubleBookings();
                fdb.Show();
            }
            else { fdb.BringToFront(); }
        }

        private void flashtimer1_Tick(object sender, EventArgs e)
        {
            if (btnDblBkgs.BackColor == Color.Crimson)
            {
                btnDblBkgs.BackColor = Color.Orange;
            }
            else btnDblBkgs.BackColor = Color.Crimson;
        }


        private void btnCreatePaySheets_Click(object sender, EventArgs e)
        {
            string sEnd = dtFrom.Value.AddDays(4).ToString("yyyy-MM-dd");
            List<string> names = LINQmanager.GetPaymentTypes();
            ExcelExporter exEx = new ExcelExporter();
            DBManager dbm = new DBManager();

            foreach (string name in names)
            {
                List<Payment> lp = dbm.GetPayrun(dtFrom.Value);
                exEx.CreatePaySheet(name, sEnd, lp);
            }
        }

        private void chkJustBookings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJustBookings.Checked)
            {
                grpQual.Visible = false;
                grpYearGroups.Visible = false;
                btnCreatePaySheets.Visible = true;
            }
            else
            {
                grpQual.Visible = true;
                grpYearGroups.Visible = true;
                btnCreatePaySheets.Visible = false;
            }
            LoadTable();
        }





        //private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    //this paints the grid
        //    try
        //    {
        //        string columnname = e.Column.FieldName;
        //        string expname = "";//"MonColor";

        //        switch (columnname)
        //        {
        //            case "Monday":
        //                expname = "MonColor";
        //                break;
        //            case "Tuesday":
        //                expname = "TueColor";
        //                break;
        //            case "Wednesday":
        //                expname = "WedColor";
        //                break;
        //            case "Thursday":
        //                expname = "ThuColor";
        //                break;
        //            case "Friday":
        //                expname = "FriColor";
        //                break;

        //            default:
        //                return;
        //                break;
        //        }

        //        int myRow = e.RowHandle;
        //        string myVal = gridView1.GetRowCellValue(myRow, expname).ToString();
        //        string backcolor = myVal.Substring(5, 4);
        //        string forecolor = myVal.Substring(0, 4);

        //        switch (backcolor)
        //        {
        //            case "yell":
        //                e.Appearance.BackColor = System.Drawing.Color.Yellow;
        //                break;
        //            case "gray":
        //                e.Appearance.BackColor = System.Drawing.Color.LightGray;
        //                break;
        //            case "lblu":
        //                e.Appearance.BackColor = System.Drawing.Color.LightBlue;
        //                break;
        //            case "dblu":
        //                e.Appearance.BackColor = System.Drawing.Color.DarkBlue;
        //                break;
        //            case "purp":
        //                e.Appearance.BackColor = System.Drawing.Color.Violet;
        //                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

        //                break;
        //            default:
        //                break;
        //        }

        //        switch (forecolor)
        //        {
        //            case "redd":
        //                e.Appearance.BackColor = System.Drawing.Color.Red;
        //                break;
        //            case "purp":
        //                e.Appearance.BackColor = System.Drawing.Color.Purple;
        //                break;
        //            case "blck":
        //                e.Appearance.BackColor = System.Drawing.Color.Black;
        //                break;

        //            default:
        //                break;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.DebugMessage(2, "Error in gridView1_CustomDrawCell: " + ex.Message);
        //    }
        //}


    }
}
