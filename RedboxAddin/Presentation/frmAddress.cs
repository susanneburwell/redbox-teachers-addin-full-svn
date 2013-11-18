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
    public partial class frmAddress : Form
    {
        public frmAddress()
        {
            InitializeComponent();
        }

        private RAddress OriginalAddress = null;
        private RAddress EditedAddress = null;

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditedAddress.Street = txtStreet.Text;
            EditedAddress.City = txtCity.Text;
            EditedAddress.State = txtState.Text;
            EditedAddress.ZIP = txtPostCode.Text;
            EditedAddress.Country = txtCountry.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public RAddress ShowDialogExt(RAddress address)
        {
            this.OriginalAddress = address;
            this.EditedAddress = address;
            DialogResult myResult = base.ShowDialog();

            if (myResult == System.Windows.Forms.DialogResult.OK)
            {
                return EditedAddress;
            }
            else
            {
                return OriginalAddress;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmAddress_Load(object sender, EventArgs e)
        {
            txtStreet.Text = OriginalAddress.Street;
            txtCity.Text = OriginalAddress.City;
            txtState.Text = OriginalAddress.State;
            txtPostCode.Text = OriginalAddress.ZIP;
            txtCountry.Text = OriginalAddress.Country;
        }



    }
}
