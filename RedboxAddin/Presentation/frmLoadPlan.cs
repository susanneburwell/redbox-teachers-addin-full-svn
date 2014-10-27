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
using RedboxAddin.Presentation;
using DevExpress.Data;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace RedboxAddin.Presentation
{
    public partial class frmLoadPlan : Form
    {
        public frmLoadPlan()
        {
            InitializeComponent();
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = true;
        }

        private void frmLoadPlan_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrom.Value = Utils.GetFirstDayoftheWeek(DateTime.Today);
                UpdateDates();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmLoadPlan_Load: " + ex.Message);
            }
        }

        private void SetDates(object sender, EventArgs e)
        {
            UpdateDates();
        }

        private void RefreshGrid(object sender, EventArgs e)
        {
            UpdateDates();
        }

        private void UpdateDates()
        {
            try
            {
                DateTime dStart = dtFrom.Value.Date;
                DateTime dEnd = dStart;
                if (radWeek.Checked) dEnd = dStart.AddDays(7);
                if (radMonth.Checked) dEnd = dStart.AddMonths(1);
                if (radCustom.Checked)
                {
                    dEnd = dtTo.Value.Date;
                    dtTo.Value = dStart;
                    dtTo.Visible = true;
                    lblTo.Visible = false;
                }
                else
                {
                    dtTo.Visible = false;
                    lblTo.Visible = true;
                }
                lblTo.Text = dEnd.ToLongDateString();

                gridControl1.DataSource = new DBManager().GetLoadPlan(dStart);


            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in UpdateDates: " + ex.Message);
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtTo.Visible)
            {
                DateTime dStart = dtFrom.Value.Date;
                DateTime dEnd = dtTo.Value.Date;
                gridControl1.DataSource = new DBManager().GetLoadPlan(dStart);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (radWeek.Checked)
            {
                dtFrom.Value = dtFrom.Value.AddDays(-7);
            }
            else
            {
                dtFrom.Value = dtFrom.Value.AddMonths(-1);
            }
        }

        private void bnFwd_Click(object sender, EventArgs e)
        {
            if (radWeek.Checked)
            {
                dtFrom.Value = dtFrom.Value.AddDays(7);
            }
            else
            {
                dtFrom.Value = dtFrom.Value.AddMonths(1);
            }
        }

        private void btnCreatePaySheets_Click(object sender, EventArgs e)
        {
            string sEnd = dtFrom.Value.AddDays(4).ToString("yyyy-MM-dd");
            List<string> names = LINQmanager.GetPaymentTypes();
            ExcelExporter exEx = new ExcelExporter();
            DBManager dbm = new DBManager();

            int num = 0;
            foreach (string name in names)
            {
                List<Payment> lp = dbm.GetPayrun(dtFrom.Value);
                //count successful attempts
                if (exEx.CreatePaySheet(name, sEnd, lp)) num += 1;
            }

            if (num == 0)
            {
                MessageBox.Show("No Paysheets were created.");
            }

            else if (num == 1)
            {
                MessageBox.Show("1 Paysheet was created.");
            }

            else
            {
                MessageBox.Show(num.ToString() + " Paysheets were created.");
            }
        }

        private void btnCreateInvoices_Click(object sender, EventArgs e)
        {
            ExcelExporter exEx = new ExcelExporter();

            int num = exEx.CreateInvoices(dtFrom.Value.AddDays(4).ToString("yyyy-MM-dd"));

            if (num == 0)
            {
                MessageBox.Show("No Invoices were created.");
            }
            else if (num == 1)
            {
                MessageBox.Show("1 Invoice was created.");
            }
            else
            {
                MessageBox.Show(num.ToString() + " Invoices were created.");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
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
                        //try { rowInfo.Teacher = gridView1.GetRowCellValue(info.RowHandle, "Teacher").ToString(); }
                        //catch { rowInfo.Teacher = ""; }
                        try { rowInfo.Description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString(); }
                        catch { rowInfo.Description = "zxcvbnmkl"; }
                    }
                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "Error in AvailabilityGrid_DoubleClick: " + ex.Message);
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
                        rowInfo.Description = gridView1.GetRowCellValue(info.RowHandle, info.Column).ToString();

                        switch (rowInfo.ColumnCaption.Substring(0, 3))
                        {
                            case "Mon":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "MonID").ToString();
                                break;
                            case "Tue":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "TueID").ToString();
                                break;
                            case "Wed":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "WedID").ToString();
                                break;
                            case "Thu":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "ThuID").ToString();
                                break;
                            case "Fri":
                                rowInfo.Status = gridView1.GetRowCellValue(info.RowHandle, "FriID").ToString();
                                break;
                        }
                    }

                    rowInfo.School = gridView1.GetRowCellValue(info.RowHandle, "SchoolName").ToString();
                    rowInfo.Teacher = gridView1.GetRowCellValue(info.RowHandle, "FirstName").ToString() + " " + gridView1.GetRowCellValue(info.RowHandle, "LastName").ToString();

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
                    LoadPlanCustomMenu menu = new LoadPlanCustomMenu(gridView1);
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

        private void btnTotals_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPwd.Text.ToLower() == "totals!")
                {
                    gridView1.OptionsView.ShowFooter = true;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(1, "Error in TotalsButton: " + ex.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(GetSelectedValues(gridView1));
                e.Handled = true;
            }
        }

        private string GetSelectedValues(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            //validate selected row count
            if (view.SelectedRowsCount == 0) return "";

            const string CellDelimiter = "\t"; 
            const string LineDelimiter = "\r\n";
            string result = "";

            //Iterate cells and compose a tab delimited string of cell values
            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {
                int row = view.GetSelectedRows()[i];
                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {
                    result += view.GetRowCellDisplayText(row, view.VisibleColumns[j]);
                    if (j != view.VisibleColumns.Count - 1)
                        result += CellDelimiter;
                }

                if (i != 0)
                    result += LineDelimiter;
            }
            return result;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Save_File = "";
                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "xls files (*.xls)|*.xls |csv files (*.csv)|*.csv";
                saveFD.DefaultExt = ".xls";
                saveFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveFD.ShowDialog() == DialogResult.OK)
                {
                    Save_File = saveFD.FileName;
                    switch (saveFD.FilterIndex)
                    {
                        case 1:
                            gridView1.ExportToXls(Save_File);
                            break;
                        case 2:
                            gridView1.ExportToCsv(Save_File);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in btnExport_Click(): " + ex.Message);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int myRow = e.RowHandle;//Test2

            bool isOT = bool.Parse(gridView1.GetRowCellValue(myRow, "OT").ToString());
            if (isOT)
                e.Appearance.BackColor = System.Drawing.Color.LightGray;
        }
    }
}

public class LoadPlanCustomMenu : GridViewMenu
{
    public LoadPlanCustomMenu(DevExpress.XtraGrid.Views.Grid.GridView view) : base(view) { }

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


        Items.Clear();
        int vv = GridMenuImages.Column.Images.Count;
        int vw = GridMenuImages.Footer.Images.Count;
        int vx = GridMenuImages.GroupPanel.Images.Count;
        Items.Add(CreateMenuItem("Edit Description", imageList.Images[0], "Edit", true));
        Items.Add(CreateMenuItem("Open Master Booking", imageList.Images[0], "Open", true));

    }

    protected override void OnMenuItemClick(object sender, EventArgs e)
    {
        try
        {


            if (RaiseClickEvent(sender, null)) return;
            DXMenuItem item = sender as DXMenuItem;
            string action = item.Tag.ToString();

            string teacher = _rowInfo.Teacher;
            string description = _rowInfo.Description;
            string status = _rowInfo.Status;
            string date = _rowInfo.ColumnCaption;
            string school = _rowInfo.School;

            if (action == "Open")
            {
                try
                {
                    string[] ids = status.Split(':');
                    if (!string.IsNullOrEmpty(ids[1]))
                    {
                        long id = Convert.ToInt64(ids[1]);
                        frmMasterBooking fmb = new frmMasterBooking(id);
                        fmb.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error trying to open the Master Booking: " + ex.Message);
                }
            }
            else
            {
                //Edit
                try
                {
                     string[] ids = status.Split(':');
                     if (!string.IsNullOrEmpty(ids[0]))
                     {
                         long id = Convert.ToInt64(ids[0]);
                         frmEditBooking eb = new frmEditBooking(id,teacher, school, date);
                         eb.Show();
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error trying to open the  Booking: " + ex.Message);
                }
            }


        }
        catch (Exception ex)
        {
            MessageBox.Show("Right Click Error: " + ex.Message);
        }
    }




}
