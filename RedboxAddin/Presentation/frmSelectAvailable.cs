using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedboxAddin.Presentation
{
    public partial class frmSelectAvailable : Form
    {
        string Available = "";
        public frmSelectAvailable()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Available = GetAvailable();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmSelectAvailable_Load(object sender, EventArgs e)
        {

        }

        public string ShowDialogExt()
        {
            DialogResult myResult = base.ShowDialog();

            if (myResult == System.Windows.Forms.DialogResult.OK)
            {
                return Available;
            }
            else
            {
                return "";
            }
        }

        private string GetAvailable()
        {
            string available = "";
            try
            {
                if (chkAM.Checked) available = "AM";
                if (chkPM.Checked) available = "PM";
                if (chkAM.Checked && chkPM.Checked) available = "";
            }
            catch (Exception ex)
            {
            }

            return available;
        }
        
    }
}
