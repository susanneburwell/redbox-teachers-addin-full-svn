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
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using RedboxAddin;
using RedboxAddin.Presentation;

namespace RedboxAddin.UC
{
    public partial class AvailabilityGrid : UserControl
    {
        public event EventHandler DblClick;
        public event EventHandler RepaintRequired;

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


                //DataSet msgDs = new DBManager().GetAvailabilityDS(monday, wheresql);
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
                        e.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
                        break;
                    case "dblu":
                        e.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
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



            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_CustomDrawCell: " + ex.Message);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
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
                            try { rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption(); }
                            catch { }
                            try {rowInfo.Teacher = gridView1.GetRowCellValue(info.RowHandle, "Teacher").ToString();}
                            catch { rowInfo.Teacher = ""; }
                            try { rowInfo.Description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString(); }
                            catch { rowInfo.Description = "zxcvbnmkl"; }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in AvailabilityGrid_DoubleClick: " + ex.Message);
                    }

                    this.DblClick(this, rowInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in DoubleClick: " + ex.Message);
            }

        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {


                // Check if the end-user has right clicked the grid control. 
                if (e.Button == MouseButtons.Right)
                {
                    REventArgs rowInfo = new REventArgs();
                    GridHitInfo info = gridView1.CalcHitInfo(new Point(e.X, e.Y));

                    //******************88
                    if (info.InRow || info.InRowCell)
                    {
                        rowInfo.ColumnCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                        rowInfo.Teacher = gridView1.GetRowCellValue(info.RowHandle, "Teacher").ToString();
                        rowInfo.Description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString();

                        switch (rowInfo.ColumnCaption.Substring(0, 3))
                        {
                            case "Mon":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "MonStatus").ToString();
                                break;
                            case "Tue":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "TueStatus").ToString();
                                break;
                            case "Wed":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "WedStatus").ToString();
                                break;
                            case "Thu":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "ThuStatus").ToString();
                                break;
                            case "Fri":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "FriStatus").ToString();
                                break;
                        }
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
                    GridViewCustomMenu menu = new GridViewCustomMenu(gridView1);
                    menu.RepaintRequired += OnRepaintRequired;
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

        protected virtual void OnRepaintRequired(object sender, EventArgs e)
        {
            EventHandler handler = RepaintRequired;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public int getTopRow()
        {
            return gridView1.TopRowIndex;
        }

        public void setTopRow(int topRow)
        {
            gridView1.TopRowIndex = topRow;
        }

        public void Clear()
        {
            gridControl1.DataSource = null;
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
