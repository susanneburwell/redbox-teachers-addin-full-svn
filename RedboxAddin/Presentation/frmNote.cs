using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
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
    public partial class frmNote : Form
    {
        DataSet DSSchools = null;
        private Note OriginalNotes = null;
        private Note EditedNote = null;
        public frmNote()
        {
            InitializeComponent();
        }

        private void LoadSchoolCombo()
        {
            try
            {
                DSSchools = new DBManager().GetSchoolsAndID();
                cmbSchool.DataSource = DSSchools.Tables[0];
                cmbSchool.ValueMember = "ID";
                cmbSchool.DisplayMember = "SchoolName";
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadSchoolCombo : " + ex.Message);
            }

        }

        private void frmNote_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSchoolCombo();               
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNote_Load : " + ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EditedNote.NoteText = txtNotes.Text;
                EditedNote.SchoolID = Int64.Parse(cmbSchool.SelectedValue.ToString());
                EditedNote.SchoolName = cmbSchool.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in btnSave_Click : " + ex.Message);
            }

        }

        public Note ShowDialogExt(Note name)
        {
            this.OriginalNotes = name;
            this.EditedNote = name;
            DialogResult myResult = base.ShowDialog();

            if (myResult == System.Windows.Forms.DialogResult.OK)
            {
                return EditedNote;
            }
            else
            {
                return null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
