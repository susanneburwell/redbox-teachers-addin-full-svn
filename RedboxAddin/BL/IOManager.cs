using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace RedboxAddin.BL
{
    class IOManager
    {
        public bool WriteText(string textString)
        {
            //Writing on Current User's  Application Data folder
            try
            {
                StreamWriter ioFile = null;
                string myFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\Davton\\" + "RedboxAddin" + "\\FormatDump.xml";
                if (File.Exists(myFilePath))
                {
                    File.Delete(myFilePath);
                }
                DirectoryInfo d1 = Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\Davton\\" + "RedboxAddin" + "");
                ioFile = new StreamWriter(myFilePath);
                ioFile.WriteLine(textString);
                ioFile.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in WriteText () ; " + ex.Message);
                return false;
            }
        }

        public string ReadText()
        {
            try
            {
                StreamReader ioFile = null;
                string xmlString = null;
                string myFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\Davton\\" + "RedboxAddin" + "\\FormatDump.xml";
                if (File.Exists(myFilePath))
                {
                    ioFile = new StreamReader(myFilePath);
                    xmlString = ioFile.ReadToEnd();
                    ioFile.Close();
                }
                return xmlString;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in ReadText() : " + ex.Message);
                return "";
            }


        }

        //public void GetExcelData()
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.FileName = "*.xls";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {

        //        Excel.Application xlApp = new Excel.Application();
        //        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(openFileDialog1.FileName, 0, true, 5,
        //                 "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
        //        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        //        Excel.Range xlRange = xlWorksheet.UsedRange;


        //        for (int i = 1; i <= 10; i++)
        //        {
        //            Excel.Range range = xlWorksheet.get_Range("A" + i.ToString(), "J" + i.ToString());
        //            System.Array myvalues = (System.Array)range.Cells.Value;
        //            string[] strArray = ConvertToStringArray(myvalues);
        //        }
        //    }

        //}
    }
}
