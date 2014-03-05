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


namespace RedboxAddin
{
    public partial class frmFileName : Form
    {
        private string _fileName;
        private string _foldername;

        public frmFileName(string FileName, string Foldername)
        {
            InitializeComponent();
            _fileName = Regex.Replace(FileName, @"[^\w\.-]", "_");
            _foldername = Foldername;
        }

        private void frmFileName_Load(object sender, EventArgs e)
        {
            txtFileName.Text = _fileName;
            lblFolder.Text = _foldername;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            {
                MessageBox.Show("You have an forbidden character in your filename, please change it.");
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
