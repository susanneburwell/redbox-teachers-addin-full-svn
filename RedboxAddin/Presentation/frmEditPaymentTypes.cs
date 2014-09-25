using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedboxAddin.BL;
using RedboxAddin.DL;


namespace RedboxAddin.Presentation
{
    public partial class frmEditPaymentTypes : Form
    {
        DBManager dbm;

        public frmEditPaymentTypes()
        {
            InitializeComponent();
        }

        private void frmEditPaymentTypes_Load(object sender, EventArgs e)
        {
            LoadPaymentTypes();
            dbm = new DBManager();
        }


        private void LoadPaymentTypes()
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    var q = from s in db.PaymentTypes
                            orderby s.Name
                            select s;
                    var paymentTypes = q.ToList();


                    cmbRemove.Items.Clear();
                    cmbRemove.Text = "";
                    txtTypes.Text = "";
                    foreach (var pt in paymentTypes)
                    {
                        cmbRemove.Items.Add(pt.Name.Trim());
                        txtTypes.Text += pt.Name.Trim() + Environment.NewLine;
                    }
                    txtAdd.Text = "";
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadPaymentTypes: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text.Length > 25)
            {
                MessageBox.Show("Max length for Payment Type is 25 characters");
            }
            else
            {
                dbm.AddPaymentType(txtAdd.Text);
                LoadPaymentTypes();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dbm.DeletePaymentType(cmbRemove.Text);
            LoadPaymentTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
