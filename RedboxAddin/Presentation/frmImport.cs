using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedboxAddin.DL;
using RedboxAddin.BL;

namespace RedboxAddin.Presentation
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }


        private void SelectFile()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.FileName = "*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lblFile.Text = openFileDialog1.FileName;
                    //List<string> list = ExcelImporter.GetColumnNames(openFileDialog1.FileName);
                    
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in select File: " + ex.Message);
            }


        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSQL();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSQL();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSQL();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSQL();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSQL();
        }

        private void CalculateSQL()
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string names = ExcelImporter.GetNameForRow(lblFile.Text, Convert.ToInt32(numFirst.Value), Convert.ToInt32(numLast.Value));
            string[] name = names.Split('/');
            lblFirst.Text = name[0];
            lblL.Text = name[1];
        }


    }
}
