namespace RedboxAddin.Presentation
{
    partial class frmLoadPlan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadPlan));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnTotals = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnCreateInvoices = new System.Windows.Forms.Button();
            this.btnCreatePaySheets = new System.Windows.Forms.Button();
            this.bnFwd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.School = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Monday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Friday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Charge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Revenue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TueID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WedID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FriID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 673);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnTotals);
            this.panelTop.Controls.Add(this.txtPwd);
            this.panelTop.Controls.Add(this.btnCreateInvoices);
            this.panelTop.Controls.Add(this.btnCreatePaySheets);
            this.panelTop.Controls.Add(this.bnFwd);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.radCustom);
            this.panelTop.Controls.Add(this.radMonth);
            this.panelTop.Controls.Add(this.radWeek);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.dtTo);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(4, 4);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(998, 89);
            this.panelTop.TabIndex = 0;
            // 
            // btnTotals
            // 
            this.btnTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotals.Location = new System.Drawing.Point(758, 50);
            this.btnTotals.Name = "btnTotals";
            this.btnTotals.Size = new System.Drawing.Size(68, 22);
            this.btnTotals.TabIndex = 92;
            this.btnTotals.Text = "Extra";
            this.btnTotals.UseVisualStyleBackColor = true;
            this.btnTotals.Click += new System.EventHandler(this.btnTotals_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(832, 50);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(66, 26);
            this.txtPwd.TabIndex = 91;
            // 
            // btnCreateInvoices
            // 
            this.btnCreateInvoices.Location = new System.Drawing.Point(567, 32);
            this.btnCreateInvoices.Name = "btnCreateInvoices";
            this.btnCreateInvoices.Size = new System.Drawing.Size(156, 28);
            this.btnCreateInvoices.TabIndex = 90;
            this.btnCreateInvoices.Text = "Create Invoices";
            this.btnCreateInvoices.UseVisualStyleBackColor = true;
            this.btnCreateInvoices.Click += new System.EventHandler(this.btnCreateInvoices_Click);
            // 
            // btnCreatePaySheets
            // 
            this.btnCreatePaySheets.Location = new System.Drawing.Point(567, 4);
            this.btnCreatePaySheets.Name = "btnCreatePaySheets";
            this.btnCreatePaySheets.Size = new System.Drawing.Size(156, 28);
            this.btnCreatePaySheets.TabIndex = 89;
            this.btnCreatePaySheets.Text = "Create PaySheets";
            this.btnCreatePaySheets.UseVisualStyleBackColor = true;
            this.btnCreatePaySheets.Click += new System.EventHandler(this.btnCreatePaySheets_Click);
            // 
            // bnFwd
            // 
            this.bnFwd.Location = new System.Drawing.Point(362, 37);
            this.bnFwd.Name = "bnFwd";
            this.bnFwd.Size = new System.Drawing.Size(51, 23);
            this.bnFwd.TabIndex = 27;
            this.bnFwd.Text = ">>";
            this.bnFwd.UseVisualStyleBackColor = true;
            this.bnFwd.Click += new System.EventHandler(this.bnFwd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(296, 37);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(60, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // radCustom
            // 
            this.radCustom.AutoSize = true;
            this.radCustom.Location = new System.Drawing.Point(473, 10);
            this.radCustom.Name = "radCustom";
            this.radCustom.Size = new System.Drawing.Size(88, 24);
            this.radCustom.TabIndex = 24;
            this.radCustom.Text = "Custom";
            this.radCustom.UseVisualStyleBackColor = true;
            this.radCustom.Visible = false;
            this.radCustom.Click += new System.EventHandler(this.SetDates);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Location = new System.Drawing.Point(384, 10);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(76, 24);
            this.radMonth.TabIndex = 23;
            this.radMonth.Text = "Month";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.Visible = false;
            this.radMonth.Click += new System.EventHandler(this.SetDates);
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.Checked = true;
            this.radWeek.Location = new System.Drawing.Point(296, 11);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(72, 24);
            this.radWeek.TabIndex = 22;
            this.radWeek.TabStop = true;
            this.radWeek.Text = "Week";
            this.radWeek.UseVisualStyleBackColor = true;
            this.radWeek.Visible = false;
            this.radWeek.Click += new System.EventHandler(this.SetDates);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(68, 8);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 26);
            this.dtFrom.TabIndex = 18;
            this.dtFrom.ValueChanged += new System.EventHandler(this.RefreshGrid);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "From:";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(68, 37);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 26);
            this.dtTo.TabIndex = 20;
            this.dtTo.Visible = false;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 17;
            this.label1.Text = "Load Plan";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(65, 41);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(45, 20);
            this.lblTo.TabIndex = 25;
            this.lblTo.Text = "lblTo";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(4, 101);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(998, 568);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.School,
            this.FirstName,
            this.LastName,
            this.numDays,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Rate,
            this.Charge,
            this.Revenue,
            this.TotalCost,
            this.TMargin,
            this.sMargin,
            this.MonID,
            this.TueID,
            this.WedID,
            this.ThuID,
            this.FriID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TMargin", null, "£{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Revenue", null, "£{0}")});
            this.gridView1.Name = "gridView1";
            // 
            // School
            // 
            this.School.Caption = "School";
            this.School.FieldName = "SchoolName";
            this.School.MaxWidth = 200;
            this.School.MinWidth = 100;
            this.School.Name = "School";
            this.School.OptionsColumn.AllowEdit = false;
            this.School.OptionsColumn.ReadOnly = true;
            this.School.Visible = true;
            this.School.VisibleIndex = 0;
            this.School.Width = 110;
            // 
            // FirstName
            // 
            this.FirstName.Caption = "First Name";
            this.FirstName.FieldName = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.OptionsColumn.AllowEdit = false;
            this.FirstName.OptionsColumn.ReadOnly = true;
            this.FirstName.Visible = true;
            this.FirstName.VisibleIndex = 1;
            this.FirstName.Width = 68;
            // 
            // LastName
            // 
            this.LastName.Caption = "Last Name";
            this.LastName.FieldName = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.OptionsColumn.AllowEdit = false;
            this.LastName.OptionsColumn.ReadOnly = true;
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 2;
            this.LastName.Width = 68;
            // 
            // numDays
            // 
            this.numDays.Caption = "No. of days";
            this.numDays.FieldName = "numDays";
            this.numDays.Name = "numDays";
            this.numDays.OptionsColumn.AllowEdit = false;
            this.numDays.OptionsColumn.ReadOnly = true;
            this.numDays.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "numDays", "{0} days")});
            this.numDays.Visible = true;
            this.numDays.VisibleIndex = 3;
            this.numDays.Width = 68;
            // 
            // Monday
            // 
            this.Monday.Caption = "Monday";
            this.Monday.FieldName = "Monday";
            this.Monday.Name = "Monday";
            this.Monday.OptionsColumn.AllowEdit = false;
            this.Monday.OptionsColumn.ReadOnly = true;
            this.Monday.Visible = true;
            this.Monday.VisibleIndex = 4;
            this.Monday.Width = 68;
            // 
            // Tuesday
            // 
            this.Tuesday.Caption = "Tuesday";
            this.Tuesday.FieldName = "Tuesday";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.OptionsColumn.AllowEdit = false;
            this.Tuesday.OptionsColumn.ReadOnly = true;
            this.Tuesday.Visible = true;
            this.Tuesday.VisibleIndex = 5;
            this.Tuesday.Width = 68;
            // 
            // Wednesday
            // 
            this.Wednesday.Caption = "Wednesday";
            this.Wednesday.FieldName = "Wednesday";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.OptionsColumn.AllowEdit = false;
            this.Wednesday.OptionsColumn.ReadOnly = true;
            this.Wednesday.Visible = true;
            this.Wednesday.VisibleIndex = 6;
            this.Wednesday.Width = 68;
            // 
            // Thursday
            // 
            this.Thursday.Caption = "Thursday";
            this.Thursday.FieldName = "Thursday";
            this.Thursday.Name = "Thursday";
            this.Thursday.OptionsColumn.AllowEdit = false;
            this.Thursday.OptionsColumn.ReadOnly = true;
            this.Thursday.Visible = true;
            this.Thursday.VisibleIndex = 7;
            this.Thursday.Width = 68;
            // 
            // Friday
            // 
            this.Friday.Caption = "Friday";
            this.Friday.FieldName = "Friday";
            this.Friday.Name = "Friday";
            this.Friday.OptionsColumn.AllowEdit = false;
            this.Friday.OptionsColumn.ReadOnly = true;
            this.Friday.Visible = true;
            this.Friday.VisibleIndex = 8;
            this.Friday.Width = 68;
            // 
            // Rate
            // 
            this.Rate.Caption = "Rate";
            this.Rate.DisplayFormat.FormatString = "{0:c}";
            this.Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Rate.FieldName = "srate";
            this.Rate.MaxWidth = 80;
            this.Rate.MinWidth = 10;
            this.Rate.Name = "Rate";
            this.Rate.OptionsColumn.AllowEdit = false;
            this.Rate.OptionsColumn.ReadOnly = true;
            this.Rate.Visible = true;
            this.Rate.VisibleIndex = 9;
            this.Rate.Width = 50;
            // 
            // Charge
            // 
            this.Charge.Caption = "Charge";
            this.Charge.DisplayFormat.FormatString = "{0:c}";
            this.Charge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Charge.FieldName = "Charge";
            this.Charge.MaxWidth = 80;
            this.Charge.MinWidth = 10;
            this.Charge.Name = "Charge";
            this.Charge.OptionsColumn.AllowEdit = false;
            this.Charge.OptionsColumn.ReadOnly = true;
            this.Charge.Visible = true;
            this.Charge.VisibleIndex = 10;
            this.Charge.Width = 50;
            // 
            // Revenue
            // 
            this.Revenue.Caption = "Revenue";
            this.Revenue.FieldName = "Revenue";
            this.Revenue.MaxWidth = 100;
            this.Revenue.MinWidth = 75;
            this.Revenue.Name = "Revenue";
            this.Revenue.OptionsColumn.AllowEdit = false;
            this.Revenue.OptionsColumn.ReadOnly = true;
            this.Revenue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Revenue", "{0:c}")});
            this.Revenue.Visible = true;
            this.Revenue.VisibleIndex = 11;
            // 
            // TotalCost
            // 
            this.TotalCost.Caption = "Total Cost";
            this.TotalCost.FieldName = "TotalCost";
            this.TotalCost.MaxWidth = 80;
            this.TotalCost.MinWidth = 10;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.OptionsColumn.AllowEdit = false;
            this.TotalCost.OptionsColumn.ReadOnly = true;
            this.TotalCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "{0:c}")});
            this.TotalCost.Visible = true;
            this.TotalCost.VisibleIndex = 12;
            this.TotalCost.Width = 68;
            // 
            // TMargin
            // 
            this.TMargin.Caption = "Total Margin";
            this.TMargin.DisplayFormat.FormatString = "{0:c}";
            this.TMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TMargin.FieldName = "TMargin";
            this.TMargin.MaxWidth = 100;
            this.TMargin.MinWidth = 80;
            this.TMargin.Name = "TMargin";
            this.TMargin.OptionsColumn.AllowEdit = false;
            this.TMargin.OptionsColumn.ReadOnly = true;
            this.TMargin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TMargin", "{0:c}")});
            this.TMargin.Visible = true;
            this.TMargin.VisibleIndex = 13;
            this.TMargin.Width = 80;
            // 
            // sMargin
            // 
            this.sMargin.Caption = "Margin";
            this.sMargin.FieldName = "Margin";
            this.sMargin.MaxWidth = 80;
            this.sMargin.MinWidth = 10;
            this.sMargin.Name = "sMargin";
            this.sMargin.OptionsColumn.AllowEdit = false;
            this.sMargin.OptionsColumn.ReadOnly = true;
            // 
            // MonID
            // 
            this.MonID.Caption = "MonID";
            this.MonID.FieldName = "MonID";
            this.MonID.Name = "MonID";
            // 
            // TueID
            // 
            this.TueID.Caption = "TueID";
            this.TueID.FieldName = "TueID";
            this.TueID.Name = "TueID";
            // 
            // WedID
            // 
            this.WedID.Caption = "WedID";
            this.WedID.FieldName = "WedID";
            this.WedID.Name = "WedID";
            // 
            // ThuID
            // 
            this.ThuID.Caption = "ThuID";
            this.ThuID.FieldName = "ThuID";
            this.ThuID.Name = "ThuID";
            // 
            // FriID
            // 
            this.FriID.Caption = "FriID";
            this.FriID.FieldName = "FriID";
            this.FriID.Name = "FriID";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "status.png");
            this.imageList1.Images.SetKeyName(1, "found.png");
            // 
            // frmLoadPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadPlan";
            this.Text = "Load Plan";
            this.Load += new System.EventHandler(this.frmLoadPlan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn School;
        private DevExpress.XtraGrid.Columns.GridColumn Rate;
        private DevExpress.XtraGrid.Columns.GridColumn Charge;
        private DevExpress.XtraGrid.Columns.GridColumn TMargin;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radWeek;
        private DevExpress.XtraGrid.Columns.GridColumn FirstName;
        private System.Windows.Forms.Button bnFwd;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn numDays;
        private DevExpress.XtraGrid.Columns.GridColumn Monday;
        private DevExpress.XtraGrid.Columns.GridColumn Tuesday;
        private DevExpress.XtraGrid.Columns.GridColumn Wednesday;
        private DevExpress.XtraGrid.Columns.GridColumn Thursday;
        private DevExpress.XtraGrid.Columns.GridColumn Friday;
        private DevExpress.XtraGrid.Columns.GridColumn TotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn sMargin;
        private DevExpress.XtraGrid.Columns.GridColumn Revenue;
        private System.Windows.Forms.Button btnCreateInvoices;
        private System.Windows.Forms.Button btnCreatePaySheets;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Columns.GridColumn MonID;
        private DevExpress.XtraGrid.Columns.GridColumn TueID;
        private DevExpress.XtraGrid.Columns.GridColumn WedID;
        private DevExpress.XtraGrid.Columns.GridColumn ThuID;
        private DevExpress.XtraGrid.Columns.GridColumn FriID;
        private System.Windows.Forms.Button btnTotals;
        private System.Windows.Forms.TextBox txtPwd;
    }
}