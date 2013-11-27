using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedboxAddin.DL;
using System.Data;


namespace RedboxAddin.Presentation
{
    public partial class frmAttributePicker : Form
    {
        List<string> outboundAtt = new List<string>();
        List<string> attList = new List<string>();
        bool OkClicked = false;

        public frmAttributePicker(List<string> AttListAlreadyAdded)
        {
            InitializeComponent();
            //Get Addable attributes
            List<string> addableCategories = new List<string>();
            var ds = new DBManager().GetDataSet("SELECT * FROM Categories");
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    addableCategories.Add(dr["CategoryName"].ToString().Trim());
                }
            }

            foreach (string s in addableCategories)
            {                
                lboxAttAddables.Items.Add(s.Trim());
            }


            if (AttListAlreadyAdded != null && AttListAlreadyAdded.Count > 0)
            {
                attList = AttListAlreadyAdded;

                foreach (string s in attList)
                {
                    lboxAttAdded.Items.Add(s);
                    lboxAttAddables.Items.Remove(s);
                }
            }
        }

        private void btnAddAtt_Click(object sender, EventArgs e)
        {
            if (lboxAttAddables.SelectedItem != null)
            {
                foreach (var item in lboxAttAddables.SelectedItems)
                {
                    lboxAttAdded.Items.Add(item);
                }
                foreach (var item in lboxAttAdded.Items)
                {
                    lboxAttAddables.Items.Remove(item);
                }

                lboxAttAddables.SelectedItem = null;
            }
        }

        private void btnRemoveAtt_Click(object sender, EventArgs e)
        {
            if (lboxAttAdded.SelectedItem != null)
            {
                // lboxAttAddables.Items.Add(lboxAttAdded.SelectedItem);
                // lboxAttAdded.Items.Remove(lboxAttAdded.SelectedItem);

                List<string> picked = lboxAttAdded.SelectedItems.Cast<string>().ToList<string>();

                foreach (var item in picked)
                {
                    lboxAttAddables.Items.Add(item);
                }
                foreach (var item in picked)
                {
                    lboxAttAdded.Items.Remove(item.ToString());
                }

                //Resort the Addables list
                List<string> ls = new List<string>();
                foreach (string s in lboxAttAddables.Items)
                {
                    ls.Add(s);
                }

                // ls = ls.OrderBy(x => Utilities.PadStringNums(x)).ToList<string>();
                lboxAttAddables.Items.Clear();
                lboxAttAddables.Items.AddRange(ls.ToArray());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OkClicked = false;
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            foreach (string item in lboxAttAdded.Items)
            {
                //attributesOut += item + ", ";
                outboundAtt.Add(item);
            }
            //attributesOut = attributesOut.Trim();
            //attributesOut.TrimEnd(new char[] { ',' });
            OkClicked = true;
            this.Close();
        }

        new public List<string> ShowDialog()
        {
            base.ShowDialog();
            if (OkClicked) return outboundAtt;
            return null;
        }

        private void lboxAttAddables_DoubleClick(object sender, EventArgs e)
        {
            btnAddAtt_Click(sender, e);
        }

        private void lboxAttAdded_DoubleClick(object sender, EventArgs e)
        {
            btnRemoveAtt_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lboxAttAddables.Items.Add(txtNewAttribute.Text.Trim());
            new DBManager().ExecuteQuery("INSERT INTO Categories (CategoryName) VALUES('"+txtNewAttribute.Text.Trim()+"')");
        }
    }
}
