namespace RedboxAddin.Presentation
{
    partial class frmTeacherUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeacherUpdate));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.grpbx2 = new System.Windows.Forms.GroupBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.chkAccepted = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.chkPast = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGuar = new System.Windows.Forms.RadioButton();
            this.radAbs = new System.Windows.Forms.RadioButton();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.gcGuaranteed = new DevExpress.XtraGrid.GridControl();
            this.gvGuaranteed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.grpbx2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gcGuaranteed, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblType);
            this.panelTop.Controls.Add(this.grpbx2);
            this.panelTop.Controls.Add(this.chkFuture);
            this.panelTop.Controls.Add(this.chkPast);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Controls.Add(this.lblTeacher);
            this.panelTop.Controls.Add(this.cmbTeacher);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(750, 231);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(653, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(407, 21);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(198, 25);
            this.lblType.TabIndex = 21;
            this.lblType.Text = "Register Absence";
            // 
            // grpbx2
            // 
            this.grpbx2.Controls.Add(this.dtFrom);
            this.grpbx2.Controls.Add(this.chkAccepted);
            this.grpbx2.Controls.Add(this.label5);
            this.grpbx2.Controls.Add(this.dtTo);
            this.grpbx2.Controls.Add(this.txtDetails);
            this.grpbx2.Controls.Add(this.label6);
            this.grpbx2.Controls.Add(this.label4);
            this.grpbx2.Controls.Add(this.btnSave);
            this.grpbx2.Location = new System.Drawing.Point(30, 103);
            this.grpbx2.Name = "grpbx2";
            this.grpbx2.Size = new System.Drawing.Size(711, 113);
            this.grpbx2.TabIndex = 20;
            this.grpbx2.TabStop = false;
            this.grpbx2.Text = "Record Absence";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(83, 22);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(194, 22);
            this.dtFrom.TabIndex = 7;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // chkAccepted
            // 
            this.chkAccepted.AutoSize = true;
            this.chkAccepted.Checked = true;
            this.chkAccepted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccepted.Location = new System.Drawing.Point(381, 80);
            this.chkAccepted.Name = "chkAccepted";
            this.chkAccepted.Size = new System.Drawing.Size(151, 20);
            this.chkAccepted.TabIndex = 19;
            this.chkAccepted.Text = "Guarantee Accepted";
            this.chkAccepted.UseVisualStyleBackColor = true;
            this.chkAccepted.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "To:";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(83, 50);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(194, 22);
            this.dtTo.TabIndex = 9;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(381, 24);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(317, 42);
            this.txtDetails.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(302, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 43);
            this.label6.TabIndex = 14;
            this.label6.Text = "Details/\r\nNotes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "From:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(623, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkFuture
            // 
            this.chkFuture.AutoSize = true;
            this.chkFuture.Checked = true;
            this.chkFuture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFuture.Location = new System.Drawing.Point(559, 66);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(139, 20);
            this.chkFuture.TabIndex = 17;
            this.chkFuture.Text = "Show Future Dates";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // chkPast
            // 
            this.chkPast.AutoSize = true;
            this.chkPast.Location = new System.Drawing.Point(411, 65);
            this.chkPast.Name = "chkPast";
            this.chkPast.Size = new System.Drawing.Size(129, 20);
            this.chkPast.TabIndex = 16;
            this.chkPast.Text = "Show Past Dates";
            this.chkPast.UseVisualStyleBackColor = true;
            this.chkPast.CheckedChanged += new System.EventHandler(this.chkPast_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGuar);
            this.groupBox1.Controls.Add(this.radAbs);
            this.groupBox1.Location = new System.Drawing.Point(29, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 49);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radGuar
            // 
            this.radGuar.AutoSize = true;
            this.radGuar.Location = new System.Drawing.Point(173, 17);
            this.radGuar.Name = "radGuar";
            this.radGuar.Size = new System.Drawing.Size(132, 20);
            this.radGuar.TabIndex = 1;
            this.radGuar.Text = "Guaranteed Work";
            this.radGuar.UseVisualStyleBackColor = true;
            // 
            // radAbs
            // 
            this.radAbs.AutoSize = true;
            this.radAbs.Checked = true;
            this.radAbs.Location = new System.Drawing.Point(19, 17);
            this.radAbs.Name = "radAbs";
            this.radAbs.Size = new System.Drawing.Size(134, 20);
            this.radAbs.TabIndex = 0;
            this.radAbs.TabStop = true;
            this.radAbs.Text = "Register Absence";
            this.radAbs.UseVisualStyleBackColor = true;
            this.radAbs.CheckedChanged += new System.EventHandler(this.radAbs_CheckedChanged);
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(45, 21);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(62, 16);
            this.lblTeacher.TabIndex = 1;
            this.lblTeacher.Text = "Teacher:";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(113, 18);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(244, 24);
            this.cmbTeacher.TabIndex = 0;
            this.cmbTeacher.SelectionChangeCommitted += new System.EventHandler(this.cmbTeacher_SelectionChangeCommitted);
            // 
            // gcGuaranteed
            // 
            this.gcGuaranteed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGuaranteed.Location = new System.Drawing.Point(3, 240);
            this.gcGuaranteed.MainView = this.gvGuaranteed;
            this.gcGuaranteed.Name = "gcGuaranteed";
            this.gcGuaranteed.Size = new System.Drawing.Size(750, 418);
            this.gcGuaranteed.TabIndex = 1;
            this.gcGuaranteed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuaranteed});
            this.gcGuaranteed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gcGuaranteed_MouseDown);
            // 
            // gvGuaranteed
            // 
            this.gvGuaranteed.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.ID});
            this.gvGuaranteed.GridControl = this.gcGuaranteed;
            this.gvGuaranteed.Name = "gvGuaranteed";
            this.gvGuaranteed.OptionsSelection.MultiSelect = true;
            this.gvGuaranteed.OptionsView.ShowGroupPanel = false;
            this.gvGuaranteed.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.DisplayFormat.FormatString = "ddd dd MMM yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "dte";
            this.gridColumn1.MaxWidth = 200;
            this.gridColumn1.MinWidth = 200;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Type";
            this.gridColumn2.FieldName = "Type";
            this.gridColumn2.MaxWidth = 300;
            this.gridColumn2.MinWidth = 300;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 300;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Details";
            this.gridColumn3.FieldName = "Details";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "Status";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "status.png");
            this.imageList1.Images.SetKeyName(1, "found.png");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 2500;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // frmTeacherUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTeacherUpdate";
            this.Text = "Update Teacher";
            this.Load += new System.EventHandler(this.frmTeacherUpdate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpbx2.ResumeLayout(false);
            this.grpbx2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radGuar;
        private System.Windows.Forms.RadioButton radAbs;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gcGuaranteed;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuaranteed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.CheckBox chkPast;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.CheckBox chkAccepted;
        private System.Windows.Forms.GroupBox grpbx2;
        private System.Windows.Forms.Label lblType;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Button btnRefresh;
    }
}