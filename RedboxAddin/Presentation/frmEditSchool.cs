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
    public partial class frmEditSchool : Form
    {
        bool _AddingNew = false;
        School _selectedItem = null;

        public frmEditSchool()
        {
            InitializeComponent();
        }

        private void frmEditSchool_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    PopulateSchools(db);
                    LoadSchoolDetails(cmbSchool.Text);
                     if (cmbSchool.SelectedItem != null) _selectedItem = cmbSchool.SelectedItem as School;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error Loading Edit School: " + ex.Message);
            }
        }

        private void cmbSchool_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSchool.SelectedItem != null)
            {
                _selectedItem = cmbSchool.SelectedItem as School;

                LoadSchoolDetails(_selectedItem.SchoolName);

            }
        }

        #region LoadControls

        private void PopulateSchools(RedBoxDB db)
        {
            try
            {
                var q = from s in db.Schools
                        orderby s.SchoolName
                        select s;
                var schools = q.ToList();
                cmbSchool.DataSource = schools;
                cmbSchool.DisplayMember = "SchoolName";
                cmbSchool.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in PopulateSchools(frmEditSchool): " + ex.Message);
            }
        }


        private void LoadSchoolDetails(string schoolName)
        {
            //Get school details
            try
            {
                lblSchoolName.Visible = true;
                txtSchoolName.Visible = false;

                if (schoolName.Trim() == "")
                {
                    lblSchoolName.Text = "";
                    txtShortName.Text = "";
                    txtMainContact.Text = "";
                    txtEmailAddress.Text = "";
                    txtTel.Text = "";
                    txtFax.Text = "";
                    txtDayCharge.Text = "";
                    txtHfDayCharge.Text = "";
                    txtLTDay.Text = "";
                    txtLTHfDay.Text = "";
                    txtTADayCharge.Text = "";
                    txtTAHfDayCharge.Text = "";
                    txtTALTDay.Text = "";
                    txtTALTHfDay.Text = "";
                    lblID.Text = "";
                    txtVettingEmails.Text = "";
                    chkUseFaxForTimeSheets.Checked = false;
                    txtAddress.Text = "";
                    txtSageAccountRef.Text = "";
                    txtNotes.Text = "";
                    chkVettingAM.Checked = false;
                    chkUseSchoolRate.Checked = false;

                    return;
                }
                else
                {

                    //School selectedItem = cmbSchool.SelectedItem as School;


                    string CONNSTR = DavSettings.getDavValue("CONNSTR");
                    using (RedBoxDB db = new RedBoxDB(CONNSTR))
                    {
                        var schools = (from s in db.Schools
                                       where s.SchoolName == schoolName
                                       select s).Distinct();

                        foreach (School school in schools)
                        {

                            lblSchoolName.Text = school.SchoolName;
                            txtShortName.Text = school.ShortName;
                            txtMainContact.Text = school.MainContact;
                            txtEmailAddress.Text = school.EmailAddress;
                            txtTel.Text = school.Telephone;
                            txtFax.Text = school.Fax;
                            txtDayCharge.Text = school.DayCharge.ToString();
                            txtHfDayCharge.Text = school.HalfDayCharge.ToString();
                            txtLTDay.Text = school.DayChargeLT.ToString();
                            txtLTHfDay.Text = school.HalfDayChargeLT.ToString();
                            txtTADayCharge.Text = school.TADayCharge.ToString();
                            txtTAHfDayCharge.Text = school.TAHalfDayCharge.ToString();
                            txtTALTDay.Text = school.TADayChargeLT.ToString();
                            txtTALTHfDay.Text = school.TAHalfDayChargeLT.ToString();
                            lblID.Text = school.ID.ToString();
                            txtVettingEmails.Text = school.VettingEmails;
                            chkUseFaxForTimeSheets.Checked = school.FaxTimeSheet;
                            txtAddress.Text = school.Address;
                            txtSageAccountRef.Text = school.SageName;
                            txtNotes.Text = school.Notes;
                            chkVettingAM.Checked = school.VettingAM;
                            chkUseSchoolRate.Checked = school.AlwaysUseSchoolRate;

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadSchoolDetails: " + ex.Message);
            }

        }

        private bool SaveChanges()
        {
            //Get school details
            try
            {
                //School selectedItem = cmbSchool.SelectedItem as School;
                if (!_AddingNew && _selectedItem == null) return false;

                //Update Existing
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {

                    if (_AddingNew)
                    {
                        School school = new School();
                        school.SchoolName = txtSchoolName.Text;
                        school.ShortName = txtShortName.Text;
                        school.MainContact = txtMainContact.Text;
                        school.EmailAddress = txtEmailAddress.Text;
                        school.Telephone = txtTel.Text;
                        school.Fax = txtFax.Text;
                        school.DayCharge = Convert.ToDecimal(txtDayCharge.Text);
                        school.HalfDayCharge = Convert.ToDecimal(txtHfDayCharge.Text);
                        school.DayChargeLT = Convert.ToDecimal(txtLTDay.Text);
                        school.HalfDayChargeLT = Convert.ToDecimal(txtLTHfDay.Text);
                        school.TADayCharge = Convert.ToDecimal(txtTADayCharge.Text);
                        school.TAHalfDayCharge = Convert.ToDecimal(txtTAHfDayCharge.Text);
                        school.TADayChargeLT = Convert.ToDecimal(txtTALTDay.Text);
                        school.TAHalfDayChargeLT = Convert.ToDecimal(txtTALTHfDay.Text);
                        school.VettingEmails = txtVettingEmails.Text;
                        school.FaxTimeSheet = chkUseFaxForTimeSheets.Checked;
                        school.Address = txtAddress.Text;
                        school.SageName = txtSageAccountRef.Text;
                        school.Notes = txtNotes.Text;
                        school.VettingAM = chkVettingAM.Checked;
                        school.AlwaysUseSchoolRate = chkUseSchoolRate.Checked;

                        db.Schools.InsertOnSubmit(school);
                        db.SubmitChanges();

                        PopulateSchools(db);
                        cmbSchool.Text = txtSchoolName.Text;
                        LoadSchoolDetails(txtSchoolName.Text);
                        return true;
                    }
                    else
                    {

                        var schools = (from s in db.Schools
                                       where s.ID == _selectedItem.ID
                                       select s).Distinct();

                        foreach (School school in schools)
                        {
                            school.SchoolName = cmbSchool.Text;
                            school.ShortName = txtShortName.Text;
                            school.MainContact = txtMainContact.Text;
                            school.EmailAddress = txtEmailAddress.Text;
                            school.Telephone = txtTel.Text;
                            school.Fax = txtFax.Text;
                            school.DayCharge = Convert.ToDecimal(txtDayCharge.Text);
                            school.HalfDayCharge = Convert.ToDecimal(txtHfDayCharge.Text);
                            school.DayChargeLT = Convert.ToDecimal(txtLTDay.Text);
                            school.HalfDayChargeLT = Convert.ToDecimal(txtLTHfDay.Text);
                            school.TADayCharge = Convert.ToDecimal(txtTADayCharge.Text);
                            school.TAHalfDayCharge = Convert.ToDecimal(txtTAHfDayCharge.Text);
                            school.TADayChargeLT = Convert.ToDecimal(txtTALTDay.Text);
                            school.TAHalfDayChargeLT = Convert.ToDecimal(txtTALTHfDay.Text);
                            school.VettingEmails = txtVettingEmails.Text;
                            school.FaxTimeSheet = chkUseFaxForTimeSheets.Checked;
                            school.Address = txtAddress.Text;
                            school.SageName = txtSageAccountRef.Text;
                            school.Notes = txtNotes.Text;
                            school.VettingAM = chkVettingAM.Checked;
                            school.AlwaysUseSchoolRate = chkUseSchoolRate.Checked;
                            db.SubmitChanges();
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in Save School: " + ex.Message);
                return false;
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                //do nothing
                if (_AddingNew)
                {
                    lblSchoolName.Visible = true;
                    txtSchoolName.Visible = false;
                    cmbSchool.Visible = true;
                    _AddingNew = false;
                }
                else
                {
                    LoadSchoolDetails(cmbSchool.Text);

                }
            }
            else
            {
                MessageBox.Show("Save School failed!", "Save School");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _AddingNew = true;
            lblSchoolName.Visible = false;
            txtSchoolName.Visible = true;
            cmbSchool.Visible = false;
            cmbSchool.Text = "";
            _selectedItem = null;

            //lblSchoolName.Text = cmbSchool.Text;
            txtShortName.Text = "";
            txtMainContact.Text = "";
            txtEmailAddress.Text = "";
            txtAddress.Text = "";
            txtNotes.Text = "";
            txtVettingEmails.Text = "";
            txtTel.Text = "";
            txtFax.Text = "";
            txtDayCharge.Text = "00.00";
            txtHfDayCharge.Text = "00.00";
            txtLTDay.Text = "00.00";
            txtLTHfDay.Text = "00.00";
            lblID.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Delete "  +_selectedItem.SchoolName + "? This can not be undone.", "Delete?", MessageBoxButtons.YesNo);
            if (ans == DialogResult.Yes)
            {
                DBManager dbm = new DBManager();
                if (dbm.DeleteSchool(_selectedItem.ID))
                {
                    MessageBox.Show("Deleted " + _selectedItem.SchoolName);
                    this.Close();
                }
                else MessageBox.Show(_selectedItem.SchoolName + " could not be Deleted");
            }
         }

        private void txtDayCharge_Validating(object sender, CancelEventArgs e)
        {
            if (!Utils.validateDecimal(txtDayCharge.Text))
            {
                txtDayCharge.Text = "0.00";
            }
        }

        private void txtHfDayCharge_Validating(object sender, CancelEventArgs e)
        {
            if (!Utils.validateDecimal(txtHfDayCharge.Text))
            {
                txtDayCharge.Text = "0.00";
            }
        }

        private void txtLTDay_Validating(object sender, CancelEventArgs e)
        {
            if (!Utils.validateDecimal(txtLTDay.Text))
            {
                txtDayCharge.Text = "0.00";
            }
        }

        private void txtLTHfDay_Validating(object sender, CancelEventArgs e)
        {
            if (!Utils.validateDecimal(txtLTHfDay.Text))
            {
                txtDayCharge.Text = "0.00";
            }
        }

        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            try
            {
                txtNotes.Text = DateTime.Now.ToString() + "  " + RedemptionCode.OutlookUserName + Environment.NewLine + "*********************************************************" + Environment.NewLine + txtNotes.Text;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error adding notes " + ex.Message);
            }
        }

       



    }
}
