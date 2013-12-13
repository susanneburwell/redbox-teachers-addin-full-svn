using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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

namespace RedboxAddin.UC
{
    public partial class AvailabilityGrid : UserControl
    {

        public event EventHandler DblClick;

        public AvailabilityGrid()
        {
            InitializeComponent();
        }

        public void LoadTable(string wheresql, DateTime input)
        {
            try
            {
                this.UseWaitCursor = true;
                Application.DoEvents();
                //Get first day of week
                //DateTime input = dtFrom.Value;
                int delta = DayOfWeek.Monday - input.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = input.AddDays(delta).Date;


                DataSet msgDs = new DBManager().GetAvailabilityDS(monday, wheresql);
                //bindingSource1.DataSource = msgDs;
                gridControl1.DataSource = new DBManager().GetAvailability(monday, wheresql);
                gridView1.Columns["Monday"].Caption = monday.ToString("ddd d MMM yy");
                gridView1.Columns["Tuesday"].Caption = monday.AddDays(1).ToString("ddd d MMM yy");
                gridView1.Columns["Wednesday"].Caption = monday.AddDays(2).ToString("ddd d MMM yy");
                gridView1.Columns["Thursday"].Caption = monday.AddDays(3).ToString("ddd d MMM yy");
                gridView1.Columns["Friday"].Caption = monday.AddDays(4).ToString("ddd d MMM yy");

                this.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadTable: " + ex.Message);
                this.UseWaitCursor = false;
            }
        }

        public void RestoreLayout()
        {
            try
            {
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        public void SaveLayout()
        {
            try
            {
                gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\AvailabilityFormDump.xml");
            }
            catch (Exception) { }
        }

        private void AvailabilityGrid_Load(object sender, EventArgs e)
        {
            try
            {
                //Colour name if guaranteed
                //StyleFormatCondition st1 = new StyleFormatCondition();
                //st1.Appearance.BackColor = System.Drawing.Color.LightGreen;
                //st1.Appearance.Options.UseBackColor = true;
                //st1.Column = this.Teacher; // this.Mon;
                //st1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
                //st1.Expression = "!IsNullOrEmpty([MonG])";
                //this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { st1 });

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in AvailabilityGrid_Load: " + ex.Message);
            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //this paints the grid
            try
            {
                string columnname = e.Column.FieldName;
                string expname = "";//"MonColor";
                int myRow = e.RowHandle;

                switch (columnname)
                {
                    case "Monday":
                        expname = "MonColor";
                        break;
                    case "Tuesday":
                        expname = "TueColor";
                        break;
                    case "Wednesday":
                        expname = "WedColor";
                        break;
                    case "Thursday":
                        expname = "ThuColor";
                        break;
                    case "Friday":
                        expname = "FriColor";
                        break;

                    case "Teacher":
                        string myG = gridView1.GetRowCellValue(myRow, "MonG").ToString();
                        if (myG == "1")
                        {
                            e.Appearance.BackColor = System.Drawing.Color.LightGreen;
                        }
                        return;
                        break;

                    default:
                        return;
                        break;
                }


                string myVal = gridView1.GetRowCellValue(myRow, expname).ToString();
                string backcolor = myVal.Substring(5, 4);
                string forecolor = myVal.Substring(0, 4);

                switch (backcolor)
                {
                    case "yell":
                        e.Appearance.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case "gray":
                        e.Appearance.BackColor = System.Drawing.Color.LightGray;
                        break;
                    case "lblu":
                        e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                        break;
                    case "dblu":
                        e.Appearance.BackColor = System.Drawing.Color.DarkBlue;
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
                        e.Appearance.BackColor = System.Drawing.Color.Red;
                        break;
                    case "purp":
                        e.Appearance.BackColor = System.Drawing.Color.Purple;
                        break;
                    case "blck":
                        e.Appearance.BackColor = System.Drawing.Color.Black;
                        break;

                    default:
                        break;
                }



            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_CustomDrawCell: " + ex.Message);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            EventHandler handler = this.DblClick;
            if (handler != null)
            {
            REventArgs rowInfo = new REventArgs();
            try
            {
                Point pt = gridControl1.PointToClient(Control.MousePosition);
                GridHitInfo info = gridView1.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    rowInfo.Teacher = gridView1.GetRowCellValue(info.RowHandle, "Teacher").ToString();
                    rowInfo.Description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in AvailabilityGrid_DoubleClick: " + ex.Message);
            }

            this.DblClick(this, rowInfo);
            }

        }




    }
}
