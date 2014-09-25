namespace RedboxAddin.Presentation
{
    partial class frmContactExp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
  
  
        /// <summary>
        /// Clean uppreparation[n++] = " any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
  
        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JobTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhoneHome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhoneMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Current = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.PayDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wants = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoGo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.D2D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGD = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.ContextMenu1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1052, 542);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FullName,
            this.LastName,
            this.JobTitle,
            this.PhoneHome,
            this.PhoneMobile,
            this.Email1,
            this.CategoryStr,
            this.BirthDate,
            this.Current,
            this.gcID,
            this.PayDetails,
            this.Wants,
            this.Teacher,
            this.TA,
            this.NoGo,
            this.LT,
            this.D2D,
            this.PPA,
            this.RGD});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(-557, 383, 216, 178);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.EndGrouping += new System.EventHandler(this.gridView1_EndGrouping);
            // 
            // FullName
            // 
            this.FullName.Caption = "Full Name";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.OptionsColumn.AllowEdit = false;
            this.FullName.OptionsColumn.ReadOnly = true;
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 0;
            this.FullName.Width = 115;
            // 
            // LastName
            // 
            this.LastName.Caption = "Last Name";
            this.LastName.FieldName = "LastName";
            this.LastName.MinWidth = 10;
            this.LastName.Name = "LastName";
            this.LastName.OptionsColumn.AllowEdit = false;
            this.LastName.OptionsColumn.ReadOnly = true;
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 1;
            this.LastName.Width = 115;
            // 
            // JobTitle
            // 
            this.JobTitle.Caption = "Job Title";
            this.JobTitle.FieldName = "JobTitle";
            this.JobTitle.Name = "JobTitle";
            this.JobTitle.OptionsColumn.AllowEdit = false;
            // 
            // PhoneHome
            // 
            this.PhoneHome.Caption = "Home Phone";
            this.PhoneHome.FieldName = "PhoneHome";
            this.PhoneHome.Name = "PhoneHome";
            this.PhoneHome.OptionsColumn.AllowEdit = false;
            this.PhoneHome.Visible = true;
            this.PhoneHome.VisibleIndex = 3;
            this.PhoneHome.Width = 115;
            // 
            // PhoneMobile
            // 
            this.PhoneMobile.Caption = "Mobile Phone";
            this.PhoneMobile.FieldName = "PhoneMobile";
            this.PhoneMobile.Name = "PhoneMobile";
            this.PhoneMobile.OptionsColumn.AllowEdit = false;
            this.PhoneMobile.Visible = true;
            this.PhoneMobile.VisibleIndex = 4;
            this.PhoneMobile.Width = 115;
            // 
            // Email1
            // 
            this.Email1.Caption = "Email Address";
            this.Email1.FieldName = "Email1";
            this.Email1.Name = "Email1";
            this.Email1.OptionsColumn.AllowEdit = false;
            this.Email1.Visible = true;
            this.Email1.VisibleIndex = 5;
            this.Email1.Width = 115;
            // 
            // CategoryStr
            // 
            this.CategoryStr.Caption = "Category";
            this.CategoryStr.FieldName = "CategoryStr";
            this.CategoryStr.Name = "CategoryStr";
            this.CategoryStr.OptionsColumn.AllowEdit = false;
            this.CategoryStr.Visible = true;
            this.CategoryStr.VisibleIndex = 2;
            this.CategoryStr.Width = 115;
            // 
            // BirthDate
            // 
            this.BirthDate.Caption = "Birth Date";
            this.BirthDate.FieldName = "BirthDate";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.OptionsColumn.AllowEdit = false;
            this.BirthDate.Visible = true;
            this.BirthDate.VisibleIndex = 6;
            this.BirthDate.Width = 115;
            // 
            // Current
            // 
            this.Current.Caption = "Current";
            this.Current.FieldName = "Current";
            this.Current.Name = "Current";
            this.Current.OptionsColumn.AllowEdit = false;
            this.Current.OptionsColumn.ReadOnly = true;
            this.Current.Visible = true;
            this.Current.VisibleIndex = 7;
            this.Current.Width = 50;
            // 
            // gcID
            // 
            this.gcID.Caption = "contactID";
            this.gcID.FieldName = "contactID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.OptionsColumn.AllowShowHide = false;
            this.gcID.OptionsColumn.ReadOnly = true;
            // 
            // ContextMenu1
            // 
            this.ContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.ContextMenu1.Name = "ContextMenu1";
            this.ContextMenu1.Size = new System.Drawing.Size(154, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem1.Text = "Email Contacts";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 572);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.textEdit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(487, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(425, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(363, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(12, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(345, 20);
            this.textEdit1.TabIndex = 1;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // PayDetails
            // 
            this.PayDetails.Caption = "Pay Details";
            this.PayDetails.FieldName = "PayDetails";
            this.PayDetails.Name = "PayDetails";
            this.PayDetails.OptionsColumn.AllowEdit = false;
            this.PayDetails.OptionsColumn.ReadOnly = true;
            this.PayDetails.Visible = true;
            this.PayDetails.VisibleIndex = 8;
            this.PayDetails.Width = 181;
            // 
            // Wants
            // 
            this.Wants.Caption = "Wants";
            this.Wants.FieldName = "Wants";
            this.Wants.Name = "Wants";
            this.Wants.OptionsColumn.AllowEdit = false;
            this.Wants.OptionsColumn.ReadOnly = true;
            // 
            // Teacher
            // 
            this.Teacher.Caption = "Teacher";
            this.Teacher.FieldName = "Teacher";
            this.Teacher.Name = "Teacher";
            this.Teacher.OptionsColumn.AllowEdit = false;
            this.Teacher.OptionsColumn.ReadOnly = true;
            // 
            // TA
            // 
            this.TA.Caption = "TA";
            this.TA.FieldName = "TA";
            this.TA.Name = "TA";
            this.TA.OptionsColumn.AllowEdit = false;
            this.TA.OptionsColumn.ReadOnly = true;
            this.TA.Width = 50;
            // 
            // NoGo
            // 
            this.NoGo.Caption = "NoGo";
            this.NoGo.FieldName = "NoGo";
            this.NoGo.Name = "NoGo";
            this.NoGo.OptionsColumn.AllowEdit = false;
            this.NoGo.OptionsColumn.ReadOnly = true;
            // 
            // LT
            // 
            this.LT.Caption = "LT";
            this.LT.FieldName = "LT";
            this.LT.Name = "LT";
            this.LT.OptionsColumn.AllowEdit = false;
            this.LT.OptionsColumn.ReadOnly = true;
            this.LT.Width = 50;
            // 
            // D2D
            // 
            this.D2D.Caption = "D2D";
            this.D2D.FieldName = "D2D";
            this.D2D.Name = "D2D";
            this.D2D.OptionsColumn.AllowEdit = false;
            this.D2D.OptionsColumn.ReadOnly = true;
            this.D2D.Width = 50;
            // 
            // PPA
            // 
            this.PPA.Caption = "PPA";
            this.PPA.FieldName = "PPA";
            this.PPA.Name = "PPA";
            this.PPA.OptionsColumn.AllowEdit = false;
            this.PPA.OptionsColumn.ReadOnly = true;
            this.PPA.Width = 50;
            // 
            // RGD
            // 
            this.RGD.Caption = "RGD";
            this.RGD.FieldName = "RGD";
            this.RGD.Name = "RGD";
            this.RGD.OptionsColumn.AllowEdit = false;
            this.RGD.OptionsColumn.ReadOnly = true;
            this.RGD.Width = 50;
            // 
            // frmContactExp
            // 
            this.ClientSize = new System.Drawing.Size(1052, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmContactExp";
            this.Text = "View";
            this.Load += new System.EventHandler(this.frmContactExp_Load);
            this.VisibleChanged += new System.EventHandler(this.frmContactExp_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ContextMenu1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn JobTitle;
        private DevExpress.XtraGrid.Columns.GridColumn PhoneHome;
        private DevExpress.XtraGrid.Columns.GridColumn PhoneMobile;
        private DevExpress.XtraGrid.Columns.GridColumn Email1;
        private DevExpress.XtraGrid.Columns.GridColumn CategoryStr;
        private DevExpress.XtraGrid.Columns.GridColumn BirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private System.Windows.Forms.ContextMenuStrip ContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Current;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn PayDetails;
        private DevExpress.XtraGrid.Columns.GridColumn Wants;
        private DevExpress.XtraGrid.Columns.GridColumn Teacher;
        private DevExpress.XtraGrid.Columns.GridColumn TA;
        private DevExpress.XtraGrid.Columns.GridColumn NoGo;
        private DevExpress.XtraGrid.Columns.GridColumn LT;
        private DevExpress.XtraGrid.Columns.GridColumn D2D;
        private DevExpress.XtraGrid.Columns.GridColumn PPA;
        private DevExpress.XtraGrid.Columns.GridColumn RGD;
    }
}
