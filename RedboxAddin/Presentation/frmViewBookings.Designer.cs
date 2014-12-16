namespace RedboxAddin.Presentation
{
    partial class frmViewBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBookings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.School = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Details = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterBookingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BookingStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.bnFwd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chkUnassigned = new System.Windows.Forms.CheckBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkTeach = new System.Windows.Forms.CheckBox();
            this.chkSch = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.cmbSchool = new System.Windows.Forms.ComboBox();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radLT = new System.Windows.Forms.RadioButton();
            this.radnoLT = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TopPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.97248F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.02752F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(857, 392);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Date,
            this.School,
            this.Teacher,
            this.Details,
            this.MasterBookingID,
            this.BookingStatus,
            this.LT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Date, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Date
            // 
            this.Date.Caption = "Date";
            this.Date.DisplayFormat.FormatString = "ddd dd MMM yyyy";
            this.Date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Date.FieldName = "Date";
            this.Date.MaxWidth = 150;
            this.Date.MinWidth = 50;
            this.Date.Name = "Date";
            this.Date.OptionsColumn.AllowEdit = false;
            this.Date.OptionsColumn.ReadOnly = true;
            this.Date.Visible = true;
            this.Date.VisibleIndex = 0;
            this.Date.Width = 137;
            // 
            // School
            // 
            this.School.Caption = "School";
            this.School.FieldName = "SchoolName";
            this.School.MaxWidth = 250;
            this.School.MinWidth = 50;
            this.School.Name = "School";
            this.School.OptionsColumn.AllowEdit = false;
            this.School.OptionsColumn.ReadOnly = true;
            this.School.Visible = true;
            this.School.VisibleIndex = 1;
            this.School.Width = 183;
            // 
            // Teacher
            // 
            this.Teacher.Caption = "Teacher";
            this.Teacher.FieldName = "Teacher";
            this.Teacher.MaxWidth = 250;
            this.Teacher.MinWidth = 50;
            this.Teacher.Name = "Teacher";
            this.Teacher.OptionsColumn.AllowEdit = false;
            this.Teacher.OptionsColumn.ReadOnly = true;
            this.Teacher.Visible = true;
            this.Teacher.VisibleIndex = 2;
            this.Teacher.Width = 183;
            // 
            // Details
            // 
            this.Details.Caption = "Description";
            this.Details.FieldName = "Description";
            this.Details.MaxWidth = 400;
            this.Details.MinWidth = 50;
            this.Details.Name = "Details";
            this.Details.OptionsColumn.AllowEdit = false;
            this.Details.OptionsColumn.ReadOnly = true;
            this.Details.Visible = true;
            this.Details.VisibleIndex = 3;
            this.Details.Width = 100;
            // 
            // MasterBookingID
            // 
            this.MasterBookingID.Caption = "MasterBookingID";
            this.MasterBookingID.FieldName = "MasterBookingID";
            this.MasterBookingID.Name = "MasterBookingID";
            this.MasterBookingID.OptionsColumn.ReadOnly = true;
            // 
            // BookingStatus
            // 
            this.BookingStatus.Caption = "BookingStatus";
            this.BookingStatus.FieldName = "BookingStatus";
            this.BookingStatus.MaxWidth = 250;
            this.BookingStatus.MinWidth = 50;
            this.BookingStatus.Name = "BookingStatus";
            this.BookingStatus.Visible = true;
            this.BookingStatus.VisibleIndex = 4;
            this.BookingStatus.Width = 165;
            // 
            // LT
            // 
            this.LT.Caption = "LT";
            this.LT.FieldName = "LT";
            this.LT.Name = "LT";
            this.LT.OptionsColumn.ReadOnly = true;
            this.LT.Visible = true;
            this.LT.VisibleIndex = 5;
            this.LT.Width = 50;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.radnoLT);
            this.TopPanel.Controls.Add(this.radLT);
            this.TopPanel.Controls.Add(this.radAll);
            this.TopPanel.Controls.Add(this.radMonth);
            this.TopPanel.Controls.Add(this.radWeek);
            this.TopPanel.Controls.Add(this.bnFwd);
            this.TopPanel.Controls.Add(this.btnBack);
            this.TopPanel.Controls.Add(this.chkUnassigned);
            this.TopPanel.Controls.Add(this.chkStatus);
            this.TopPanel.Controls.Add(this.cmbStatus);
            this.TopPanel.Controls.Add(this.lblStatus);
            this.TopPanel.Controls.Add(this.btnSearch);
            this.TopPanel.Controls.Add(this.chkTeach);
            this.TopPanel.Controls.Add(this.chkSch);
            this.TopPanel.Controls.Add(this.chkDate);
            this.TopPanel.Controls.Add(this.lblTeacher);
            this.TopPanel.Controls.Add(this.cmbTeacher);
            this.TopPanel.Controls.Add(this.dtFrom);
            this.TopPanel.Controls.Add(this.label4);
            this.TopPanel.Controls.Add(this.dtTo);
            this.TopPanel.Controls.Add(this.label5);
            this.TopPanel.Controls.Add(this.lblSchool);
            this.TopPanel.Controls.Add(this.cmbSchool);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(3, 3);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(857, 141);
            this.TopPanel.TabIndex = 0;
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Location = new System.Drawing.Point(758, 44);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(62, 20);
            this.radMonth.TabIndex = 88;
            this.radMonth.Text = "Month";
            this.radMonth.UseVisualStyleBackColor = true;
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.Location = new System.Drawing.Point(758, 16);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(62, 20);
            this.radWeek.TabIndex = 87;
            this.radWeek.Text = "Week";
            this.radWeek.UseVisualStyleBackColor = true;
            this.radWeek.CheckedChanged += new System.EventHandler(this.radWeek_CheckedChanged);
            // 
            // bnFwd
            // 
            this.bnFwd.Location = new System.Drawing.Point(709, 71);
            this.bnFwd.Name = "bnFwd";
            this.bnFwd.Size = new System.Drawing.Size(40, 31);
            this.bnFwd.TabIndex = 86;
            this.bnFwd.Text = ">>";
            this.bnFwd.UseVisualStyleBackColor = true;
            this.bnFwd.Click += new System.EventHandler(this.bnFwd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(549, 73);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(37, 31);
            this.btnBack.TabIndex = 85;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // chkUnassigned
            // 
            this.chkUnassigned.AutoSize = true;
            this.chkUnassigned.Location = new System.Drawing.Point(99, 105);
            this.chkUnassigned.Name = "chkUnassigned";
            this.chkUnassigned.Size = new System.Drawing.Size(189, 20);
            this.chkUnassigned.TabIndex = 20;
            this.chkUnassigned.Text = "Find Unassigned Bookings";
            this.chkUnassigned.UseVisualStyleBackColor = true;
            this.chkUnassigned.CheckedChanged += new System.EventHandler(this.chkUnassigned_CheckedChanged);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(305, 75);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(182, 20);
            this.chkStatus.TabIndex = 19;
            this.chkStatus.Text = "Search By Booking Status";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(99, 75);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 18;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 16);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(759, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 38);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkTeach
            // 
            this.chkTeach.AutoSize = true;
            this.chkTeach.Location = new System.Drawing.Point(305, 47);
            this.chkTeach.Name = "chkTeach";
            this.chkTeach.Size = new System.Drawing.Size(143, 20);
            this.chkTeach.TabIndex = 15;
            this.chkTeach.Text = "Search By Teacher";
            this.chkTeach.UseVisualStyleBackColor = true;
            // 
            // chkSch
            // 
            this.chkSch.AutoSize = true;
            this.chkSch.Location = new System.Drawing.Point(305, 15);
            this.chkSch.Name = "chkSch";
            this.chkSch.Size = new System.Drawing.Size(134, 20);
            this.chkSch.TabIndex = 14;
            this.chkSch.Text = "Search By School";
            this.chkSch.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Location = new System.Drawing.Point(549, 110);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(121, 20);
            this.chkDate.TabIndex = 13;
            this.chkDate.Text = "Search By Date";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(30, 48);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(62, 16);
            this.lblTeacher.TabIndex = 11;
            this.lblTeacher.Text = "Teacher:";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(99, 44);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 24);
            this.cmbTeacher.TabIndex = 12;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(549, 13);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "From:";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(549, 43);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 22);
            this.dtTo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "To:";
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(30, 15);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(53, 16);
            this.lblSchool.TabIndex = 2;
            this.lblSchool.Text = "School:";
            // 
            // cmbSchool
            // 
            this.cmbSchool.FormattingEnabled = true;
            this.cmbSchool.Location = new System.Drawing.Point(99, 13);
            this.cmbSchool.Name = "cmbSchool";
            this.cmbSchool.Size = new System.Drawing.Size(200, 24);
            this.cmbSchool.TabIndex = 3;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Location = new System.Drawing.Point(327, 110);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(41, 20);
            this.radAll.TabIndex = 89;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radLT
            // 
            this.radLT.AutoSize = true;
            this.radLT.Location = new System.Drawing.Point(385, 110);
            this.radLT.Name = "radLT";
            this.radLT.Size = new System.Drawing.Size(42, 20);
            this.radLT.TabIndex = 90;
            this.radLT.Text = "LT";
            this.radLT.UseVisualStyleBackColor = true;
            this.radLT.CheckedChanged += new System.EventHandler(this.radLT_CheckedChanged);
            // 
            // radnoLT
            // 
            this.radnoLT.AutoSize = true;
            this.radnoLT.Location = new System.Drawing.Point(445, 110);
            this.radnoLT.Name = "radnoLT";
            this.radnoLT.Size = new System.Drawing.Size(60, 20);
            this.radnoLT.TabIndex = 91;
            this.radnoLT.Text = "no LT";
            this.radnoLT.UseVisualStyleBackColor = true;
            this.radnoLT.CheckedChanged += new System.EventHandler(this.radLT_CheckedChanged);
            // 
            // frmViewBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmViewBookings";
            this.Text = "View Bookings";
            this.Load += new System.EventHandler(this.frmViewBookings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.ComboBox cmbSchool;
        private System.Windows.Forms.CheckBox chkTeach;
        private System.Windows.Forms.CheckBox chkSch;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn School;
        private DevExpress.XtraGrid.Columns.GridColumn Teacher;
        private DevExpress.XtraGrid.Columns.GridColumn Details;
        private DevExpress.XtraGrid.Columns.GridColumn MasterBookingID;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkUnassigned;
        private DevExpress.XtraGrid.Columns.GridColumn BookingStatus;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radWeek;
        private System.Windows.Forms.Button bnFwd;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraGrid.Columns.GridColumn LT;
        private System.Windows.Forms.RadioButton radnoLT;
        private System.Windows.Forms.RadioButton radLT;
        private System.Windows.Forms.RadioButton radAll;

    }
}