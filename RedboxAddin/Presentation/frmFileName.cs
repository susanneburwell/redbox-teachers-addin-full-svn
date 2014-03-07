using RedboxAddin.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;


namespace RedboxAddin
{
    public partial class frmFileName : Form
    {
        private string _fileName;
        private string _foldername;

        public frmFileName(string FileName)
        {
            InitializeComponent();
            ProcessFolderName(FileName);
            string fileName = FileName.Replace("Redbox Timesheet", "").Replace("Week Ending", "").Replace("Week Beginning", "");
            fileName = fileName.Replace("FWD", "").Replace("Fwd", "").Replace("fwd", "").Trim();
            _fileName = Regex.Replace(fileName, @"[^\w\.-]", "");
        }

        private void frmFileName_Load(object sender, EventArgs e)
        {
            txtFileName.Text = _fileName;
            lblFolder.Text = _foldername;
        }

        private void ProcessFolderName(string FileName)
        {
            //get date from fielname
            string dateString = null;
            try
            {
                dateString = FileName.Substring(FileName.Length - 11);
            }
            catch { }

            _foldername = "Y:\\A. Timesheets";
            if (dateString != null)
            {
                try
                {
                    DateTime nowDate = DateTime.Now;
                    //get the next Friday
                    var dayVal = nowDate.DayOfWeek;
                    DateTime wkEnd = DateTime.Now;
                    switch (dayVal)
                    {
                        case DayOfWeek.Monday:
                            wkEnd = nowDate.AddDays(-3);
                            break;
                        case DayOfWeek.Tuesday:
                            wkEnd = nowDate.AddDays(-4);
                            break;
                        case DayOfWeek.Wednesday:
                            wkEnd = nowDate.AddDays(-5);
                            break;
                        case DayOfWeek.Thursday:
                            wkEnd = nowDate.AddDays(-6);
                            break;
                        case DayOfWeek.Saturday:
                            wkEnd = nowDate.AddDays(-1);
                            break;
                        case DayOfWeek.Sunday:
                            wkEnd = nowDate.AddDays(-2);
                            break;
                        default:
                            wkEnd = nowDate;
                            break;
                    }
                    string year = wkEnd.ToString("yyyy");
                    string month = wkEnd.ToString("MMM yyyy");
                    string day = wkEnd.ToString("d.M.yy");
                    _foldername = "Y:\\A. Timesheets\\Timesheets " + year + "\\" + month + "\\|W.E." + day;
                }
                catch { }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            {
                MessageBox.Show("You have a forbidden character in your filename, please change it.");
                return;
            }
            else
            {
                _fileName = txtFileName.Text;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _fileName = null;
            _foldername = null;
            this.Close();
        }



        public string FileName
        {
            get { return _fileName; }
        }

        public string FolderName
        {
            get { return _foldername; }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    lblFolder.Text = fbd.SelectedPath;
                    _foldername = lblFolder.Text;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
