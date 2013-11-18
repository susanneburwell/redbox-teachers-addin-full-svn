using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.Models;

namespace RedboxAddin.Presentation
{
    public partial class frmNames : Form
    {

        private RNames OriginalName = null;
        private RNames EditedName = null;
        public frmNames()
        {
            InitializeComponent();
        }

        public RNames ShowDialogExt(RNames name)
        {
            this.OriginalName = name;
            this.EditedName = name;
            DialogResult myResult = base.ShowDialog();

            if (myResult == System.Windows.Forms.DialogResult.OK)
            {
                return EditedName;
            }
            else
            {
                return OriginalName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditedName.Title = txtTitle.Text;
            EditedName.FirstName = txtFirst.Text;
            EditedName.MiddleName = txtMiddle.Text;
            EditedName.LastName = txtLast.Text;
            EditedName.Suffix = txtSuffix.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmNames_Load(object sender, EventArgs e)
        {
            txtTitle.Text = OriginalName.Title;
            txtFirst.Text = OriginalName.FirstName;
            txtMiddle.Text = OriginalName.MiddleName;
            txtLast.Text = OriginalName.LastName;
            txtSuffix.Text = OriginalName.Suffix;
        }
    }
}
