using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace RedboxAddin.BL
{
    class Debug
    {
        static System.IO.FileStream myTraceLog;
        static TextWriterTraceListener myListener;
        static BooleanSwitch myBoolSwitch = new BooleanSwitch("myBoolSwitch", "RedboxEngine1 General");
        static System.Diagnostics.TraceSwitch myTraceSwitch = new System.Diagnostics.TraceSwitch("myTraceSwitch", "RedboxEngine2 General");
        internal static string TracePath = "";
        private static int DebugLevel = 2;

        public static void InitialiseTrace()
        {
            try
            {
                TracePath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Davton\\RedboxAddin\\Logs";
                if (Directory.Exists(TracePath)) { }
                else
                {
                    //* Directory Doesnt Exist - Create it 
                    Directory.CreateDirectory(TracePath);
                }

                myTraceLog = new FileStream(TracePath + "\\RedboxAddinLog (" + DateTime.Now.ToString("dd-MM-yy") + ").txt", FileMode.Append);
                myListener = new TextWriterTraceListener(myTraceLog);
                Trace.AutoFlush = true;
                Trace.Listeners.Add(myListener);
                Trace.WriteLineIf(myTraceSwitch.TraceVerbose, "Initialise Trace");
                System.Diagnostics.Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                System.Diagnostics.Debug.AutoFlush = true;
                System.Diagnostics.Debug.Indent();
                DebugMessage(1, "Application Started");
                ClearOldDebugFiles();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(@"Error Initialising Trace for Debugging. " + Environment.NewLine + @"The FSI folder or Trace file may be opened :- " + ex.Message, @"FSI Debug");
            }
        }

        internal static void DebugMessage(Int16 Level, string dbMessage)
        {
            try
            {
                switch (Level)
                {
                    case 1:
                        myListener.WriteLine(DateTime.Now + " -1- " + dbMessage);
                        //MessageBox.Show(dbMessage, "Level 1 Debug Message");
                        break;

                    case 2:
                        if (DebugLevel >= 2) myListener.WriteLine(DateTime.Now + " -2- " + dbMessage);
                        //MessageBox.Show(dbMessage, "Level 2 Debug Message");
                        break;
                    case 3:
                        if (DebugLevel >= 3)
                            myListener.WriteLine(DateTime.Now + " -3- " + dbMessage);
                        break;

                    case 4:
                        if (DebugLevel >= 4)
                            myListener.WriteLine(DateTime.Now + " -4- " + dbMessage);
                        break;
                }
                myListener.Flush();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(@"Error writing Trace : " + ex.Message);
            }
        }

        private static bool ClearOldDebugFiles()
        {
            try
            {
                var filesArray = Directory.GetFiles(TracePath);
                Array.Sort(filesArray);
                Debug.DebugMessage(3, filesArray.Length.ToString() + " Log files found");
                foreach (var item in filesArray)
                {
                    string shortFilePath = item.Replace(TracePath, "");
                    int indexOfOpenBrace = shortFilePath.IndexOf("(") + 1;
                    int indexOfCloseBrace = shortFilePath.IndexOf(")");
                    string dateStr = shortFilePath.Substring(indexOfOpenBrace, indexOfCloseBrace - indexOfOpenBrace);
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime datetimeVal = DateTime.ParseExact(dateStr, "dd-MM-yy", provider);
                    if ((DateTime.Now - datetimeVal).Days > 30)
                    {
                        File.Delete(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugMessage(2, "Error in ClearOldDebugFiles : " + ex.Message);
                return false;
            }
        }

        internal static void SetDebugLevel()
        {
            try
            {
                DebugLevel = Int32.Parse(DavSettings.getDavValue("DEBUGLEVEL"));
            }
            catch (Exception ex)
            {
                DebugMessage(2, "Error in SetDebugLevel : " + ex.Message);
            }
        }
    }
}
