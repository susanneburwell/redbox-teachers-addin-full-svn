using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedboxAddin.BL;
using RedboxAddin.DL;

namespace RedboxAddin.Presentation
{
    public partial class frmImportSchools : Form
    {
        public frmImportSchools()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {

        }

        private void SelectFile()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.FileName = "*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    grpBox.Visible = true;
                    List<string> list = ExcelImporter.GetColumnNames(openFileDialog1.FileName);
                    lblCol1.Text = list[0];
                    lblCol2.Text = list[1];
                    lblCol3.Text = list[2];
                    lblCol4.Text = list[3];
                    lblCol5.Text = list[4];
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in select File: " + ex.Message);
            }


        }
    }
}
