using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AddinExpress.OL;
using RedboxAddin.DL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data;
using System.Collections.Generic;
using RedboxAddin.Models;
using RedboxAddin.BL;

namespace RedboxAddin.Presentation
{
    public partial class frmContactExp : AddinExpress.OL.ADXOlForm
    {
        public frmContactExp()
        {
            InitializeComponent();
        }

        private void frmContactExp_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = new DBManager().GetContacts();
            try
            {
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
            }
            catch (Exception) { }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int contactID = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gcID).ToString());
                frmViewContact frmObj = new frmViewContact(contactID);
                frmObj.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {          
            try
            {
                var rowsArray = gridView1.GetSelectedRows();
                var recpList = "";
                List<string> recpL = new List<string>();

                foreach (var item in rowsArray)
                {
                    if (gridView1.IsGroupRow(item)) continue;
                    RContact rr = (RContact)gridView1.GetRow(item);
                    recpL.Add(rr.Email1);
                }

                var chunks = recpL.Chunkify(50);

                foreach (var chunk in chunks)
                {
                    recpList = "";
                    foreach (var item in chunk)
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        recpList = recpList + item + ";";
                    }
                    OpenEmailForRecps(recpList);                    
                }             
                    
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in toolStripMenuItem1_Click : " + ex.Message);
            }
           

        }

        private void OpenEmailForRecps(string recpList)
        {
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = null;
            Microsoft.Office.Interop.Outlook.Items oItems = null;
            Microsoft.Office.Interop.Outlook.MailItem mailItem = null;
            try
            {
                oFolder = Globals.objNS.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderDrafts);
                oItems = oFolder.Items;
                mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oItems.Add("IPM.Note");
                mailItem.BCC = recpList;
                mailItem.Display();
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in toolStripMenuItem1_Click : " + ex.Message);
            }
            finally
            {
                if (mailItem != null) Marshal.ReleaseComObject(mailItem);
                if (oItems != null) Marshal.ReleaseComObject(oItems);
                if (oFolder != null) Marshal.ReleaseComObject(oFolder);
                GC.Collect();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

            if (hitInfo.InRow)
            {

                view.FocusedRowHandle = hitInfo.RowHandle;
                //DataRow row = (gridView1.GetRow(hitInfo.RowHandle) as DataRowView).Row;
                ContextMenu1.Show(view.GridControl, e.Point);

            }
        }

        private void frmContactExp_VisibleChanged(object sender, EventArgs e)
        {
            gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
            gridControl1.DataSource = new DBManager().GetContacts();
            gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ApplyFindFilter(textEdit1.Text);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            gridView1.ApplyFindFilter(textEdit1.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "";
        }

        bool previousIndexGrouped = false;

        private void gridView1_EndGrouping(object sender, EventArgs e)
        {
            if (gcCategories.GroupIndex == -1)
            {
                if (previousIndexGrouped) return;
                previousIndexGrouped = true;
                gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
                gridControl1.DataSource = new DBManager().GetContactsEx();
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");

            }
            else
            {
                if (!previousIndexGrouped) return;
                previousIndexGrouped = false;
                gridView1.SaveLayoutToXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");
                gridControl1.DataSource = new DBManager().GetContacts();
                gridView1.RestoreLayoutFromXml(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Davton\\" + "RedboxAddin" + "\\ContactFormDump.xml");

            }
        }





    }
}
