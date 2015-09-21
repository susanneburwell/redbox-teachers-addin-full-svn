using RedboxAddin.DL;
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
    public partial class frmViewNotes : Form
    {
        public frmViewNotes()
        {
            InitializeComponent();
        }

        private void LoadNoteGrid(DateTime fromDate, DateTime Todate)
        {
            DataSet noteDS = new DBManager().GetNotes(fromDate, Todate);
            if (noteDS != null)
            {
                gcViewNotes.DataSource = noteDS.Tables[0];
            }
        }

        private void frmViewNotes_Load(object sender, EventArgs e)
        {
            SetDefaultDate();
            LoadNoteGrid(dtpFrom.Value, dtpTo.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNoteGrid(dtpFrom.Value, dtpTo.Value);
        }

        private void SetDefaultDate()
        {
            try
            {
                dtpFrom.Value = DateTime.Now.AddDays(-7);
                dtpTo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
