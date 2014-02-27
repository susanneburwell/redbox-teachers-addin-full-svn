using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.DL;
using RedboxAddin.BL;
using DevExpress.XtraGrid.Columns;

namespace RedboxAddin.Presentation
{
    public partial class frmSendVetting : Form
    {

        bool formloading = false;

        public frmSendVetting()
        {
            formloading = true;
            InitializeComponent();
            formloading = false;
        }

        private void LoadGrid()
        {
            try
            {
                string date = dtFrom.Value.ToString("yyyy-MM-dd");
                gridControl1.DataSource = new DBManager().GetBookingsForDate(date, radShowConfirmed.Checked);
                SetSelected(); //set the checkboxes to the required values
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadGrid(): " + ex.Message);
            }
        }

        private void SetSelected()
        {
            try
            {

                GridColumn colSelect = gridView1.Columns.ColumnByName("Selected");
                GridColumn colStatus = gridView1.Columns.ColumnByName("Status");

                // Obtain the number of data rows. 
                int dataRowCount = gridView1.DataRowCount;
                // Traverse data rows and change the Price field values. 
                for (int i = 0; i < dataRowCount; i++)
                {
                    try
                    {
                        string status = gridView1.GetRowCellValue(i, colStatus).ToString();
                        bool selected = false;
                        if (status == "Confirmed") selected = true;
                        gridView1.SetRowCellValue(i, colSelect, selected);

                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error Sending Vetting Details: " + ex.Message);
                    }
                }


            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendDetails(): " + ex.Message);
            }
        }
        
        private void SendDetails(bool sendAuto)
        {
            try
            {

                GridColumn colSelect = gridView1.Columns.ColumnByName("Selected");
                GridColumn colContactID = gridView1.Columns.ColumnByFieldName("ContactID");
                GridColumn colSchoolID = gridView1.Columns.ColumnByFieldName("SchoolID");
                GridColumn colMasterBookingID = gridView1.Columns.ColumnByFieldName("MasterBookingID");
                GridColumn colTeacher = gridView1.Columns.ColumnByFieldName("Teacher");
                GridColumn colSchool = gridView1.Columns.ColumnByFieldName("SchoolName");

                string errors = "";

                // Obtain the number of data rows. 
                int dataRowCount = gridView1.DataRowCount;
                // Traverse data rows and change the Price field values. 
                for (int i = 0; i < dataRowCount; i++)
                {
                    try
                    {
                        bool selected = Convert.ToBoolean(gridView1.GetRowCellValue(i, colSelect));
                        if (selected)
                        {
                            string teacherID = gridView1.GetRowCellValue(i, colContactID).ToString();
                            string schoolID = gridView1.GetRowCellValue(i, colSchoolID).ToString();
                            Int64 masterBookingID = Convert.ToInt64(gridView1.GetRowCellValue(i, colMasterBookingID));
                            bool success = RedemptionCode.SendVettingDetails(teacherID, schoolID, sendAuto);

                            if (success)
                            {
                                LINQmanager.SetBookingStatus(masterBookingID, "Details Sent");
                            }
                            else
                            {
                                string teacher = gridView1.GetRowCellValue(i, colTeacher).ToString();
                                string school= gridView1.GetRowCellValue(i, colSchool).ToString();
                                errors += teacher + " at " + school + "\r";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error Sending Vetting Details: " + ex.Message);
                    }
                }

                if (errors != "")
                {
                    MessageBox.Show("There were errors sending the following messages:\r\r" + errors);
                }

                LoadGrid();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendDetails(): " + ex.Message);
            }
        }

        

        

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (formloading) return;
                LoadGrid();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in dtFrom_ValueChanged: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendDetails(chkSendAuto.Checked);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
