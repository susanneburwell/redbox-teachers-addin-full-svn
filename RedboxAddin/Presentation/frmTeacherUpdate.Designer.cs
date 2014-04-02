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
            this.chkShowGuarantees = new System.Windows.Forms.CheckBox();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.chkPast = new System.Windows.Forms.CheckBox();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.radOther = new System.Windows.Forms.RadioButton();
            this.radSick = new System.Windows.Forms.RadioButton();
            this.radAAL = new System.Windows.Forms.RadioButton();
            this.radAA = new System.Windows.Forms.RadioButton();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGuar = new System.Windows.Forms.RadioButton();
            this.radAbs = new System.Windows.Forms.RadioButton();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.gcGuaranteed = new DevExpress.XtraGrid.GridControl();
            this.gvGuaranteed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.grpAbsence.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 814);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.chkShowGuarantees);
            this.panelTop.Controls.Add(this.chkFuture);
            this.panelTop.Controls.Add(this.chkPast);
            this.panelTop.Controls.Add(this.grpAbsence);
            this.panelTop.Controls.Add(this.txtDetails);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.dtTo);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.lblTeacher);
            this.panelTop.Controls.Add(this.cmbTeacher);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(4, 4);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 214);
            this.panelTop.TabIndex = 0;
            // 
            // chkShowGuarantees
            // 
            this.chkShowGuarantees.AutoSize = true;
            this.chkShowGuarantees.Checked = true;
            this.chkShowGuarantees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGuarantees.Location = new System.Drawing.Point(274, 157);
            this.chkShowGuarantees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShowGuarantees.Name = "chkShowGuarantees";
            this.chkShowGuarantees.Size = new System.Drawing.Size(164, 24);
            this.chkShowGuarantees.TabIndex = 18;
            this.chkShowGuarantees.Text = "Show Guaranteed";
            this.chkShowGuarantees.UseVisualStyleBackColor = true;
            // 
            // chkFuture
            // 
            this.chkFuture.AutoSize = true;
            this.chkFuture.Checked = true;
            this.chkFuture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFuture.Location = new System.Drawing.Point(39, 186);
            this.chkFuture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(175, 24);
            this.chkFuture.TabIndex = 17;
            this.chkFuture.Text = "Show Future Dates";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // chkPast
            // 
            this.chkPast.AutoSize = true;
            this.chkPast.Location = new System.Drawing.Point(39, 157);
            this.chkPast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPast.Name = "chkPast";
            this.chkPast.Size = new System.Drawing.Size(161, 24);
            this.chkPast.TabIndex = 16;
            this.chkPast.Text = "Show Past Dates";
            this.chkPast.UseVisualStyleBackColor = true;
            this.chkPast.CheckedChanged += new System.EventHandler(this.chkPast_CheckedChanged);
            // 
            // grpAbsence
            // 
            this.grpAbsence.Controls.Add(this.radOther);
            this.grpAbsence.Controls.Add(this.radSick);
            this.grpAbsence.Controls.Add(this.radAAL);
            this.grpAbsence.Controls.Add(this.radAA);
            this.grpAbsence.Location = new System.Drawing.Point(272, 59);
            this.grpAbsence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAbsence.Size = new System.Drawing.Size(204, 90);
            this.grpAbsence.TabIndex = 15;
            this.grpAbsence.TabStop = false;
            this.grpAbsence.Text = "Absence Type";
            // 
            // radOther
            // 
            this.radOther.AutoSize = true;
            this.radOther.Checked = true;
            this.radOther.Location = new System.Drawing.Point(104, 53);
            this.radOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radOther.Name = "radOther";
            this.radOther.Size = new System.Drawing.Size(72, 24);
            this.radOther.TabIndex = 3;
            this.radOther.TabStop = true;
            this.radOther.Text = "Other";
            this.radOther.UseVisualStyleBackColor = true;
            // 
            // radSick
            // 
            this.radSick.AutoSize = true;
            this.radSick.Location = new System.Drawing.Point(27, 53);
            this.radSick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radSick.Name = "radSick";
            this.radSick.Size = new System.Drawing.Size(62, 24);
            this.radSick.TabIndex = 2;
            this.radSick.Text = "Sick";
            this.radSick.UseVisualStyleBackColor = true;
            // 
            // radAAL
            // 
            this.radAAL.AutoSize = true;
            this.radAAL.Location = new System.Drawing.Point(104, 27);
            this.radAAL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radAAL.Name = "radAAL";
            this.radAAL.Size = new System.Drawing.Size(62, 24);
            this.radAAL.TabIndex = 1;
            this.radAAL.Text = "AAL";
            this.radAAL.UseVisualStyleBackColor = true;
            // 
            // radAA
            // 
            this.radAA.AutoSize = true;
            this.radAA.Location = new System.Drawing.Point(27, 27);
            this.radAA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radAA.Name = "radAA";
            this.radAA.Size = new System.Drawing.Size(52, 24);
            this.radAA.TabIndex = 0;
            this.radAA.Text = "AA";
            this.radAA.UseVisualStyleBackColor = true;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(501, 115);
            this.txtDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(451, 51);
            this.txtDetails.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Details/Notes";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(852, 174);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGuar);
            this.groupBox1.Controls.Add(this.radAbs);
            this.groupBox1.Location = new System.Drawing.Point(39, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(220, 90);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radGuar
            // 
            this.radGuar.AutoSize = true;
            this.radGuar.Location = new System.Drawing.Point(23, 53);
            this.radGuar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radGuar.Name = "radGuar";
            this.radGuar.Size = new System.Drawing.Size(161, 24);
            this.radGuar.TabIndex = 1;
            this.radGuar.Text = "Guaranteed Work";
            this.radGuar.UseVisualStyleBackColor = true;
            // 
            // radAbs
            // 
            this.radAbs.AutoSize = true;
            this.radAbs.Checked = true;
            this.radAbs.Location = new System.Drawing.Point(23, 21);
            this.radAbs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radAbs.Name = "radAbs";
            this.radAbs.Size = new System.Drawing.Size(163, 24);
            this.radAbs.TabIndex = 0;
            this.radAbs.TabStop = true;
            this.radAbs.Text = "Register Absence";
            this.radAbs.UseVisualStyleBackColor = true;
            this.radAbs.CheckedChanged += new System.EventHandler(this.radAbs_CheckedChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(588, 27);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(257, 26);
            this.dtFrom.TabIndex = 7;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "From:";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(588, 61);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(257, 26);
            this.dtTo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "To:";
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(35, 26);
            this.lblTeacher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(75, 20);
            this.lblTeacher.TabIndex = 1;
            this.lblTeacher.Text = "Teacher:";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(169, 22);
            this.cmbTeacher.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(305, 28);
            this.cmbTeacher.TabIndex = 0;
            this.cmbTeacher.SelectionChangeCommitted += new System.EventHandler(this.cmbTeacher_SelectionChangeCommitted);
            // 
            // gcGuaranteed
            // 
            this.gcGuaranteed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGuaranteed.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcGuaranteed.Location = new System.Drawing.Point(4, 226);
            this.gcGuaranteed.MainView = this.gvGuaranteed;
            this.gcGuaranteed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcGuaranteed.Name = "gcGuaranteed";
            this.gcGuaranteed.Size = new System.Drawing.Size(1000, 584);
            this.gcGuaranteed.TabIndex = 1;
            this.gcGuaranteed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuaranteed});
            // 
            // gvGuaranteed
            // 
            this.gvGuaranteed.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvGuaranteed.GridControl = this.gcGuaranteed;
            this.gvGuaranteed.Name = "gvGuaranteed";
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
            // frmTeacherUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 814);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTeacherUpdate";
            this.Text = "Update Teacher";
            this.Load += new System.EventHandler(this.frmTeacherUpdate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpAbsence;
        private System.Windows.Forms.RadioButton radOther;
        private System.Windows.Forms.RadioButton radSick;
        private System.Windows.Forms.RadioButton radAAL;
        private System.Windows.Forms.RadioButton radAA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.CheckBox chkPast;
        private System.Windows.Forms.CheckBox chkShowGuarantees;
    }
}