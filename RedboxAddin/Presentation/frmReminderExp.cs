using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AddinExpress.OL;
using RedboxAddin.DL;
using RedboxAddin.BL;
using RedboxAddin.Models;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraGrid.Helpers;
using System.Xml;
using System.IO;

namespace RedboxAddin.Presentation
{
    public partial class frmReminderExp : AddinExpress.OL.ADXOlForm
    {
        public frmReminderExp()
        {
            InitializeComponent();
        }

        private void frmReminderExp_Load(object sender, EventArgs e)
        {
            cmbReminderType.SelectedIndex = 0;
            RefreshData();
            LoadAppearanceFromXML();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2)
                {
                    var ID = gridView1.GetRowCellValue(e.RowHandle, gridColumnID).ToString();
                    frmViewReminder frmObj = new frmViewReminder(Convert.ToInt64(ID));
                    frmObj.ShowDialog();
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in gridView1_RowClick() :- " + ex.Message);
            }
        }

        private void radioGroupSent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (radioGroupSent.SelectedIndex == 1)
            //{
            //    HandleDateControls(false);
            //    RefreshData();
            //}
            //else
            {
                HandleDateControls(true);
                RefreshData();
            }
        }

        void HandleDateControls(bool value)
        {
            try
            {
                dateEditEnd.Enabled = value;
                dateEditStart.Enabled = value;
                // lblStart.Enabled = value;
                //lblEnd.Enabled = value;
                if (value)
                {
                    dateEditEnd.Text = "";
                    dateEditStart.Text = "";
                    //  lblEnd.ForeColor = Color.MidnightBlue;
                    //  lblStart.ForeColor = Color.MidnightBlue;

                    string selectedSentOn = "All";
                    DatesForSearch objDatesForSearch = GetDates();
                    switch (radioGroupSent.SelectedIndex)
                    {
                        case 2:
                            dateEditStart.DateTime = DateTime.Now;
                            dateEditEnd.DateTime = DateTime.Now;
                            break;
                        case 3:
                            dateEditStart.DateTime = DateTime.Now.AddDays(1);
                            dateEditEnd.DateTime = DateTime.Now.AddDays(1);
                            break;
                        case 4:
                            dateEditEnd.DateTime = objDatesForSearch.ThisWeekEndDate;
                            dateEditStart.DateTime = objDatesForSearch.ThisWeekStartDate;
                            break;
                        case 5:
                            dateEditStart.DateTime = objDatesForSearch.NextWeekStartDate;
                            dateEditEnd.DateTime = objDatesForSearch.NextWeekEndDate;
                            break;
                        case 6:
                            dateEditStart.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            dateEditEnd.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
                            break;
                        case 7:
                            dateEditStart.DateTime = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 1);
                            dateEditEnd.DateTime = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(2).Month, 1).AddDays(-1);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    dateEditEnd.Text = "";
                    dateEditStart.Text = "";
                    // lblEnd.ForeColor = Color.Gray;
                    // lblStart.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "***HandleDateControls : Error : " + ex.Message);
            }

        }

        private DatesForSearch GetDates()
        {
            ArrayList startEndDates = new ArrayList();
            double offset = 0;
            switch (System.DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    offset = 0;
                    break;
                case DayOfWeek.Tuesday:
                    offset = -1;
                    break;
                case DayOfWeek.Wednesday:
                    offset = -2;
                    break;
                case DayOfWeek.Thursday:
                    offset = -3;
                    break;
                case DayOfWeek.Friday:
                    offset = -4;
                    break;
                case DayOfWeek.Saturday:
                    offset = -5;
                    break;
                case DayOfWeek.Sunday:
                    offset = -6;
                    break;
            }
            DatesForSearch objDatesForSearch = new DatesForSearch()
            {
                PreviousWeekEndDate = DateTime.Today.AddDays(offset - 1),
                PreviousWeekStartDate = DateTime.Today.AddDays(-7 + offset),
            };
            objDatesForSearch.ThisWeekStartDate = objDatesForSearch.PreviousWeekEndDate.AddDays(1);
            objDatesForSearch.ThisWeekEndDate = objDatesForSearch.ThisWeekStartDate.AddDays(6);
            objDatesForSearch.NextWeekStartDate = objDatesForSearch.ThisWeekEndDate.AddDays(1);
            objDatesForSearch.NextWeekEndDate = objDatesForSearch.NextWeekStartDate.AddDays(6);
            return objDatesForSearch;
        }

        private void cmbReminderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void chkShowComplete_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var originalCollection = new DBManager().GetReminders();
            List<RReminder> filteredCollection = new DBManager().GetReminders();
            if (cmbReminderType.Text != "ALL")
            {
                filteredCollection = originalCollection.FindAll(delegate(RReminder o) { return o.Type == cmbReminderType.Text.Trim(); });
            }
            if (radioGroupSent.SelectedIndex != 0)
            {
                if (radioGroupSent.SelectedIndex == 1)
                {
                    filteredCollection = filteredCollection.FindAll(delegate(RReminder o) { return (GetFlatDatetime(o.DueDate) <= GetFlatDatetime(DateTime.Now)); });
                }
                else
                {
                    filteredCollection = filteredCollection.FindAll(delegate(RReminder o) { return (GetFlatDatetime(o.DueDate) <= GetFlatDatetime(dateEditEnd.DateTime)) && (GetFlatDatetime(o.DueDate) >= GetFlatDatetime(dateEditStart.DateTime)); });
                }
            }
            if (!chkShowComplete.Checked)
            {
                filteredCollection = filteredCollection.FindAll(delegate(RReminder o) { return o.Status != "Completed"; });
            }
            gridControl1.DataSource = filteredCollection;
            gridView1.ExpandAllGroups();
        }


        private DateTime GetFlatDatetime(DateTime datetimeVal)
        {
            return new DateTime(datetimeVal.Year, datetimeVal.Month, datetimeVal.Day);
        }

        private void WriteXML()
        {
            try
            {
                XmlDocument myXMLdoc = new XmlDocument();
                XmlElement myRoot = default(XmlElement);
                XmlElement my2ndRoot = default(XmlElement);
                XmlDeclaration myDeclare = myXMLdoc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                myXMLdoc.InsertBefore(myDeclare, myXMLdoc.DocumentElement);

                myRoot = myXMLdoc.CreateElement("FormState");
                myXMLdoc.InsertAfter(myRoot, myDeclare);
                my2ndRoot = myXMLdoc.CreateElement("GridView");
                myRoot.AppendChild(my2ndRoot);

                //Saving grouped columns
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.GroupedColumns)
                {
                    XmlElement my3rdRoot = default(XmlElement);
                    my3rdRoot = myXMLdoc.CreateElement("Column");
                    my2ndRoot.AppendChild(my3rdRoot);
                    AddField(ref myXMLdoc, ref  my3rdRoot, "Name", column.FieldName);
                    AddField(ref myXMLdoc, ref my3rdRoot, "Header", column.Caption);
                    AddField(ref myXMLdoc, ref  my3rdRoot, "GroupIndex", column.GroupIndex.ToString());
                    AddField(ref myXMLdoc, ref my3rdRoot, "Width", column.Width.ToString());
                    AddField(ref myXMLdoc, ref  my3rdRoot, "Visible", column.Visible.ToString());
                    AddField(ref myXMLdoc, ref  my3rdRoot, "VisibleIndex", column.VisibleIndex.ToString());
                }

                //Saving un-grouped columns
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
                {
                    if (column.GroupIndex == -1)
                    {
                        XmlElement my3rdRoot = default(XmlElement);
                        my3rdRoot = myXMLdoc.CreateElement("Column");
                        my2ndRoot.AppendChild(my3rdRoot);
                        AddField(ref myXMLdoc, ref  my3rdRoot, "Name", column.FieldName);
                        AddField(ref myXMLdoc, ref  my3rdRoot, "Header", column.Caption);
                        AddField(ref myXMLdoc, ref  my3rdRoot, "GroupIndex", column.GroupIndex.ToString());
                        AddField(ref myXMLdoc, ref  my3rdRoot, "Width", column.Width.ToString());
                        AddField(ref myXMLdoc, ref  my3rdRoot, "Visible", column.Visible.ToString());
                        AddField(ref myXMLdoc, ref my3rdRoot, "VisibleIndex", column.VisibleIndex.ToString());
                    }
                }

                XmlElement my2ndRoot2 = default(XmlElement);
                my2ndRoot2 = myXMLdoc.CreateElement("Filters");
                myRoot.AppendChild(my2ndRoot2);

                XmlElement my2ndRoot21 = default(XmlElement);
                my2ndRoot21 = myXMLdoc.CreateElement("Period");
                my2ndRoot2.AppendChild(my2ndRoot21);
                AddField(ref myXMLdoc, ref my2ndRoot21, "Index", radioGroupSent.SelectedIndex.ToString());

                XmlElement my2ndRoot22 = null;
                my2ndRoot22 = myXMLdoc.CreateElement("ReminderType");
                my2ndRoot2.AppendChild(my2ndRoot22);
                AddField(ref myXMLdoc, ref  my2ndRoot22, "Selected", cmbReminderType.Text);

                XmlElement my2ndRoot23 = null;
                my2ndRoot23 = myXMLdoc.CreateElement("ShowComplete");
                my2ndRoot2.AppendChild(my2ndRoot23);
                AddField(ref myXMLdoc, ref  my2ndRoot23, "Selected", chkShowComplete.Checked.ToString());

                string myXMLString = myXMLdoc.OuterXml;
                new IOManager().WriteText(myXMLString);

            }
            catch (Exception ex)
            {

            }
        }

        public void AddField(ref XmlDocument XMLdoc, ref XmlElement xmlParent, string Name, string myData, string myType = "text")
        {
            //* This adds a child Field to a parent Appointment
            try
            {
                XmlElement myField = default(XmlElement);
                myField = XMLdoc.CreateElement(Name);
                if (!(myType == "text"))
                    myField.SetAttribute("type", myType);
                myField.InnerText = myData;
                xmlParent.AppendChild(myField);

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in function AddField() :- " + ex.Message);
            }
        }

        private void frmReminderExp_VisibleChanged(object sender, EventArgs e)
        {
            WriteXML();
        }

        private void LoadAppearanceFromXML()
        {
            try
            {
                string XMLString = new IOManager().ReadText();
                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList grid_nodelist = default(XmlNodeList);

                m_xmld = new XmlDocument();
                StringReader strReader = new StringReader(XMLString);
                m_xmld.Load(strReader);
                grid_nodelist = m_xmld.SelectNodes("/FormState/GridView/Column");
                gridView1.BeginSort();
                gridView1.ClearGrouping();

                foreach (XmlNode m_node in grid_nodelist)
                {
                    try
                    {
                        string ColumnName = (m_node.ChildNodes.Item(0).InnerText);
                        string ColumnHeader = (m_node.ChildNodes.Item(1).InnerText);
                        string GroupIndex = (m_node.ChildNodes.Item(2).InnerText);
                        string ColumnWidth = (m_node.ChildNodes.Item(3).InnerText);
                        string ColumnVisibility = (m_node.ChildNodes.Item(4).InnerText);
                        string ColumnVisibleIndex = (m_node.ChildNodes.Item(5).InnerText);

                        gridView1.Columns[ColumnName].Caption = ColumnHeader;
                        try
                        {
                            gridView1.Columns[ColumnName].GroupIndex = Convert.ToInt32(GroupIndex);
                        }
                        catch (Exception ex)
                        {
                            gridView1.Columns[ColumnName].GroupIndex = -1;
                        }
                        try
                        {
                            gridView1.Columns[ColumnName].Width = Convert.ToInt32(ColumnWidth);
                        }
                        catch (Exception ex)
                        {
                            gridView1.Columns[ColumnName].Width = 80;
                        }
                        try
                        {
                            gridView1.Columns[ColumnName].Visible = Convert.ToBoolean(ColumnVisibility);
                        }
                        catch (Exception ex)
                        {
                            gridView1.Columns[ColumnName].Visible = true;
                        }
                        try
                        {
                            gridView1.Columns[ColumnName].VisibleIndex = Convert.ToInt32(ColumnVisibleIndex);
                        }
                        catch (Exception ex) { }
                    }
                    catch (Exception ex) { }
                }
                try
                {
                    int periodValue = Convert.ToInt32(m_xmld.SelectSingleNode("/FormState/Filters/Period/Index").InnerText);
                    radioGroupSent.SelectedIndex = periodValue;
                }
                catch (Exception ex) { }
                try
                {
                    string ReminderType = m_xmld.SelectSingleNode("/FormState/Filters/ReminderType/Selected").InnerText;
                    if (!string.IsNullOrEmpty(ReminderType))
                        cmbReminderType.Text = ReminderType;
                }
                catch (Exception ex) { }
                try
                {
                    bool showComplete = Convert.ToBoolean(m_xmld.SelectSingleNode("/FormState/Filters/ShowComplete/Selected").InnerText);
                    if (showComplete)
                        chkShowComplete.Checked = true;
                }
                catch (Exception ex) { }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in " + ex.Message);
            }
            finally
            {
                gridView1.EndSort();
            }

        }




    }
}
