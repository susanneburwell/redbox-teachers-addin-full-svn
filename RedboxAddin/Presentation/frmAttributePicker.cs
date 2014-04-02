using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedboxAddin.DL;
using RedboxAddin.BL;
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
            new DBManager().ExecuteQuery("INSERT INTO Categories (CategoryName) VALUES('" + txtNewAttribute.Text.Trim() + "')");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lboxAttAddables.SelectedItem != null)
            {
                string catName = "iowdnwduq280du0";
                var item = lboxAttAddables.SelectedItems[0];
                if (item != null)
                {
                    catName = item.ToString();
                    DialogResult dr = MessageBox.Show("Delete '" + catName + "'?", "Delete Category", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    if (Removecategory(catName))
                    {
                        lboxAttAddables.Items.Remove(item);

                        foreach (var item2 in lboxAttAdded.Items)
                        {
                            if (item2.ToString() == catName)
                                lboxAttAdded.Items.Remove(item2);
                        }
                    }
                }
            }
        }

        private bool Removecategory(string catName)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var deleteCategoryDetails = from cat in db.Categories
                                                where cat.CategoryName == catName
                                                select cat;

                    foreach (var detail in deleteCategoryDetails)
                    {
                        db.Categories.DeleteOnSubmit(detail);
                    }

                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Debug.DebugMessage(2, "Error in Removecategory: " + e.Message);
                        return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in Removecategory(1): " + ex.Message);
                return false;
            }
        }
    }
}
