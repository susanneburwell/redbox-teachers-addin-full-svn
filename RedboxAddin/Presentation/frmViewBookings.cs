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

namespace RedboxAddin.Presentation
{
    public partial class frmViewBookings : Form
    {
        public frmViewBookings()
        {
            InitializeComponent();
        }

        private void frmViewBookings_Load(object sender, EventArgs e)
        {
            try
            {
                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    PopulateSchools(db);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in frmNewRequest_Load: " + ex.Message);
            }

            
        }

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
                Debug.DebugMessage(2, "Error in PopulateSchools: " + ex.Message);
            }
        }

        private void LoadGrid()
        {
            try
            {
                School selected = cmbSchool.SelectedItem as School;


                string CONNSTR = DavSettings.getDavValue("CONNSTR");
                using (RedBoxDB db = new RedBoxDB(CONNSTR))
                {
                    var bookings = db.MasterBookings.Where(item => item.SchoolID == selected.ID);
                    gridControl1.DataSource = bookings;
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in LoadGrid(frmViewBookings): " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        
    }
}
