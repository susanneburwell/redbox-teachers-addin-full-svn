using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;



namespace RedboxAddin
{
    class ExcelExporter
    {


        public bool CreatePaySheet(string type, string WeekEnding, List<Payment> payments)
        {
            Excel.Application objApp = null;
            Excel._Workbook objBook = null;
            Excel.Workbooks objBooks = null;
            Excel.Sheets objSheets = null;
            Excel._Worksheet objSheet = null;
            Excel.Range range = null;
            string fileName = "not set";

            try
            {
                //Create an array.
                string[,] data = GetDataArray(type, payments, WeekEnding);
                if (data == null) return false;


                // Instantiate Excel and start a new workbook.
                string templatefolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Davton Files\\Templates";
                if (!Directory.Exists(templatefolder)) Directory.CreateDirectory(templatefolder);

                string template = templatefolder + "\\PayRunTemplate.xltx";
                objApp = new Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(template);
                objSheets = objBook.Worksheets;
                objSheet = objSheets.get_Item(1) as Excel._Worksheet;

                range = objSheet.get_Range("B3");
                range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, WeekEnding);

                range = objSheet.get_Range("A6");
                range = range.get_Resize(data.GetLength(0), 8);

                //Set the range value to the array.
                range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, data);

                //Save the file
                fileName = "Payrun_" + type + "_" + WeekEnding + ".xlsx";
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Davton Files\\Paysheets\\";
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                objBook.SaveAs(filePath + fileName);
                //Return control of Excel to the user.
                objApp.Visible = true;
                objApp.UserControl = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Paysheet '" + fileName + "': " + ex.Message);
                Debug.DebugMessage(2, "Error in CreatePaySheet: " + ex.Message);
                return false;
            }
            finally
            {
                if (objApp != null) Marshal.ReleaseComObject(objApp);
                if (objBook != null) Marshal.ReleaseComObject(objBook);
                if (objBooks != null) Marshal.ReleaseComObject(objBooks);
                if (objSheets != null) Marshal.ReleaseComObject(objSheets);
                if (objSheet != null) Marshal.ReleaseComObject(objSheet);
                if (range != null) Marshal.ReleaseComObject(range);
            }
        }

        public string[,] GetDataArray(string type, List<Payment> payments, string WeekEnding)
        {
            //process the list and convert to the data array to be added

            int listPointer = 0;
            try
            {

                //get rid of unwanted items
                while (listPointer < payments.Count)
                {
                    if (type == "Key")
                    {
                        if (payments[listPointer].PayDetails.Length < 3) payments.RemoveAt(listPointer);
                        else if (payments[listPointer].PayDetails.Substring(0, 3).ToLower() != "key") payments.RemoveAt(listPointer);
                        else listPointer += 1;
                    }
                    else if (type != payments[listPointer].PayDetails)
                    {
                        payments.RemoveAt(listPointer);
                    }
                    else
                    {
                        //move on to next payment
                        listPointer += 1;
                    }

                }

                //list now contains only items of correct type
                if (payments.Count == 0) return null;

                //iterate through teh list
                listPointer = 0;
                while (listPointer < payments.Count - 1)
                {
                    if (PaymentsMatch(payments[listPointer], payments[listPointer + 1]))
                    {
                        //add a day to existing payment
                        payments[listPointer].TotalDays += 1;
                        payments.RemoveAt(listPointer + 1);
                    }
                    else
                    {
                        //move on to next payment
                        listPointer += 1;
                    }



                }

                //create the array
                int numMax = payments.Count;
                string[,] myArr = new string[numMax, 8];

                int arrPointer = 0;
                foreach (Payment pay in payments)  //arrPointer is zero based
                {
                    myArr[arrPointer, 0] = pay.PayDetails;
                    myArr[arrPointer, 1] = pay.AgencyRef;
                    myArr[arrPointer, 2] = pay.LastName;
                    myArr[arrPointer, 3] = pay.FirstName;
                    myArr[arrPointer, 4] = WeekEnding;
                    myArr[arrPointer, 5] = pay.TotalDays.ToString();
                    myArr[arrPointer, 7] = pay.Rate.ToString();
                    arrPointer += 1;
                }

                return myArr;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Excel Exporter.GetDataArray: listPointer=" + listPointer.ToString() + " Error: " + ex.Message);
                return null;
            }
        }

        private bool PaymentsMatch(Payment pay1, Payment pay2)
        {
            try
            {
                if (pay1.PayDetails != pay2.PayDetails) return false;
                if (pay1.AgencyRef != pay2.AgencyRef) return false;
                if (pay1.LastName != pay2.LastName) return false;
                if (pay1.FirstName != pay2.FirstName) return false;
                if (pay1.Rate != pay2.Rate) return false;


                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Excel Exporter.PaymentsMatchy: " + ex.Message);
                return false;
            }
        }

        public int CreateInvoices(string WeekEnding)
        {
            int invCount = 0;
            try
            {
                //Get list of schools
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                RedBoxDB db = new RedBoxDB(CONNSTR);
                var q = from s in db.Schools select s;
                List<School> schools = q.ToList();
                DBManager dbm = new DBManager();

                foreach (School sch in schools)
                {
                    //For each school get list of invoice lines

                    List<InvoiceLine> listItems = dbm.GetInvoice(WeekEnding, sch.SageName);
                    if (listItems == null) continue;
                    if (listItems.Count == 0) continue;

                    UpdateList(listItems);  //this processes to show multiple days on one line
                    if (CreateInvoice(listItems, sch.ShortName)) invCount += 1;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CreateInvoices: " + ex.Message);
            }

            return invCount;
        }

        private void UpdateList(List<InvoiceLine> listItems)
        {
            //iterate through the list - remove dupes and update total days
            int listPointer = 0;
            while (listPointer < listItems.Count - 1)
            {
                if (InvoiceLinesMatch(listItems[listPointer], listItems[listPointer + 1]))
                {
                    //add a day to existing payment
                    listItems[listPointer].TotalDays += 1;
                    listItems.RemoveAt(listPointer + 1);
                }
                else
                {
                    //move on to next payment
                    listPointer += 1;
                }

            }
        }

        private bool InvoiceLinesMatch(InvoiceLine line1, InvoiceLine line2)
        {
            try
            {
                if (line1.Description != line2.Description) return false;
                if (line1.Charge != line2.Charge) return false;
                if (line1.LastName != line2.LastName) return false;
                if (line1.FirstName != line2.FirstName) return false;


                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Excel Exporter.InvoiceLinesMatch: " + ex.Message);
                return false;
            }
        }

        private bool CreateInvoice(List<InvoiceLine> listItems, string shortName)
        {
            try
            {

                StringBuilder sb = new StringBuilder();

                //Add header row
                sb.AppendLine("CUST_ORDER_NUMBER,ACCOUNT_REF,ADDRESS_1,ADDRESS_2,ADDRESS_3,ADDRESS_4,ADDRESS_5," +
                    "DESCRIPTION,NOMINAL_CODE,QTY_ORDER,STOCK_CODE,UNIT_PRICE");

                //for each InvoiceLine

                foreach (InvoiceLine invLine in listItems)
                {
                    string addressFull = invLine.Address.Replace(',', ';');
                    string[] myAddress = invLine.Address.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    string myAddress1 = (myAddress.Length > 0) ? myAddress[0] : "";
                    string myAddress2 = (myAddress.Length > 1) ? myAddress[1] : "";
                    string myAddress3 = (myAddress.Length > 2) ? myAddress[2] : "";
                    string myAddress4 = (myAddress.Length > 3) ? myAddress[3] : "";
                    string myAddress5 = (myAddress.Length > 4) ? myAddress[4] : "";

                    //remove school name from description
                    string updatedDescription = invLine.Description.Replace(shortName, "").Trim();
                    string initial = (invLine.FirstName.Length > 0)?" " + invLine.FirstName.Substring(0,1):"";
                    string nameWithInitial = invLine.LastName + initial;

                    string myDesc = nameWithInitial + ": " + updatedDescription;
                    myDesc.Replace(',', ';');

                    string myLine = invLine.WeekEnding + ",";
                    myLine += invLine.SageAcctRef + ",";
                    myLine += myAddress1 + ",";
                    myLine += myAddress2 + ",";
                    myLine += myAddress3 + ",";
                    myLine += myAddress4 + ",";
                    myLine += myAddress5 + ",";
                    myLine += myDesc + ",";
                    myLine += "4000,";
                    myLine += invLine.TotalDays + ",";
                    myLine += "XX,";
                    myLine += invLine.Charge + ",";
                    sb.AppendLine(myLine);

                }
                string fileName = listItems[0].SageAcctRef + "_" + listItems[0].WeekEnding + ".csv";

                string filePath = DavSettings.getDavValue("INVOICEFOLDERPATH");
                if( filePath== null) filePath = "Y:\\A. Sage Invoices Imports";

                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                File.WriteAllText(filePath + "\\" + fileName, sb.ToString());

                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CreateInvoice: " + ex.Message);
                return false;
            }
        }
    }


}
