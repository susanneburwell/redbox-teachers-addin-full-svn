using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

using RedboxAddin.BL;
using RedboxAddin.Models;

namespace RedboxAddin.DL
{
    static class ExcelImporter
    {

        public static List<RAvailability> Import(string filepath)
        {

            //The connection string to the excel file
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";

            //Get the sheet names
            IEnumerable<string> sheets = GetExcelSheetNames(filepath);


            //The connection to that file
            OleDbConnection conn = new OleDbConnection(connStr);

            //The query (Selects all from SHEET1)
            string strSQL = "SELECT * FROM ["+sheets.First()+"]"  ; //;  //[{0}$]  + sheets.First()

            //The command (executes select all)
            OleDbCommand cmd = new OleDbCommand(/*The query*/strSQL, /*The connection*/conn);
            DataTable dt = new DataTable();
            conn.Open();

            try
            {
                //Read in the data from the specified Excel
                OleDbDataReader dr1 = cmd.ExecuteReader();

                if (dr1.Read())
                {
                    dt.Load(dr1);
                }

                //Gets the number of columns  
                int iColCount = dt.Columns.Count;

                //Get the number of rows
                int iRowCount = dt.Rows.Count;

                List<RAvailability> listA = new List<RAvailability>();

                for (int iRow = 1; iRow < iRowCount; iRow++)
                {
                    try
                    {
                        RAvailability rA = new RAvailability();
                        rA.Teacher = dt.Rows[iRow][0].ToString();
                        rA.Live = dt.Rows[iRow][3].ToString();
                        rA.Wants = dt.Rows[iRow][4].ToString();
                        rA.YrGroup = dt.Rows[iRow][5].ToString();
                        rA.QTS = dt.Rows[iRow][6].ToString();
                        rA.Pay = dt.Rows[iRow][7].ToString();
                        rA.PofA = dt.Rows[iRow][8].ToString();
                        rA.CRB = dt.Rows[iRow][9].ToString();
                        rA.Monday = dt.Rows[iRow][10].ToString();
                        rA.Tuesday = dt.Rows[iRow][11].ToString();
                        rA.Wednesday = dt.Rows[iRow][12].ToString();
                        rA.Thursday = dt.Rows[iRow][13].ToString();
                        rA.Friday = dt.Rows[iRow][14].ToString();

                        listA.Add(rA);
                    }
                    catch { }

                }

                return listA;

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error importing from Exel: " + ex.Message);
                return null;
            }
        }

        public static IEnumerable<string> GetExcelSheetNames(string excelFile)
        {
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties=Excel 12.0;";
            //var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //      "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            using (var connection = new OleDbConnection(connStr))
            {
                connection.Open();
                using (var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
                {
                    return (dt ?? new DataTable())
                        .Rows
                        .Cast<DataRow>()
                        .Select(row => row["TABLE_NAME"].ToString());
                }
            }
        }
    }
}
