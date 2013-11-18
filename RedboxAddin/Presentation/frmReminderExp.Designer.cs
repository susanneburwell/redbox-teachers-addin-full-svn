namespace RedboxAddin.Presentation
{
    partial class frmReminderExp
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkShowComplete = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.cmbReminderType = new System.Windows.Forms.ComboBox();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.radioGroupSent = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(912, 498);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumnID,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Due Date";
            this.gridColumn1.FieldName = "DueDate";
            this.gridColumn1.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Type";
            this.gridColumn2.FieldName = "Type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Subject";
            this.gridColumn3.FieldName = "Subject";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "Status";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "reminderID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Notes";
            this.gridColumn6.FieldName = "Notes";
            this.gridColumn6.Name = "gridColumn6";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 568);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.chkShowComplete);
            this.panel1.Controls.Add(this.label70);
            this.panel1.Controls.Add(this.cmbReminderType);
            this.panel1.Controls.Add(this.dateEditEnd);
            this.panel1.Controls.Add(this.dateEditStart);
            this.panel1.Controls.Add(this.radioGroupSent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 70);
            this.panel1.TabIndex = 1;
            // 
            // chkShowComplete
            // 
            this.chkShowComplete.AutoSize = true;
            this.chkShowComplete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowComplete.Location = new System.Drawing.Point(579, 43);
            this.chkShowComplete.Name = "chkShowComplete";
            this.chkShowComplete.Size = new System.Drawing.Size(113, 18);
            this.chkShowComplete.TabIndex = 61;
            this.chkShowComplete.Text = "Show Complete";
            this.chkShowComplete.UseVisualStyleBackColor = true;
            this.chkShowComplete.CheckedChanged += new System.EventHandler(this.chkShowComplete_CheckedChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(483, 15);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(90, 14);
            this.label70.TabIndex = 43;
            this.label70.Text = "Reminder Type";
            // 
            // cmbReminderType
            // 
            this.cmbReminderType.BackColor = System.Drawing.Color.White;
            this.cmbReminderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReminderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReminderType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReminderType.FormattingEnabled = true;
            this.cmbReminderType.Items.AddRange(new object[] {
            "ALL",
            "12QP",
            "1Year",
            "CRB Expiry",
            "Redbox Start",
            "Visa Expiry"});
            this.cmbReminderType.Location = new System.Drawing.Point(579, 12);
            this.cmbReminderType.Name = "cmbReminderType";
            this.cmbReminderType.Size = new System.Drawing.Size(141, 22);
            this.cmbReminderType.TabIndex = 42;
            this.cmbReminderType.SelectedIndexChanged += new System.EventHandler(this.cmbReminderType_SelectedIndexChanged);
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(814, 35);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dateEditEnd.Properties.Appearance.Options.UseForeColor = true;
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEnd.Size = new System.Drawing.Size(86, 20);
            this.dateEditEnd.TabIndex = 11;
            this.dateEditEnd.Visible = false;
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(730, 35);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dateEditStart.Properties.Appearance.Options.UseForeColor = true;
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStart.Size = new System.Drawing.Size(78, 20);
            this.dateEditStart.TabIndex = 10;
            this.dateEditStart.Visible = false;
            // 
            // radioGroupSent
            // 
            this.radioGroupSent.Location = new System.Drawing.Point(7, 7);
            this.radioGroupSent.Name = "radioGroupSent";
            this.radioGroupSent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupSent.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupSent.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.radioGroupSent.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupSent.Properties.Appearance.Options.UseFont = true;
            this.radioGroupSent.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroupSent.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Overdue"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Today"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tomorrow"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "This Week"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Next Week"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "This Month"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Next Month")});
            this.radioGroupSent.Size = new System.Drawing.Size(449, 57);
            this.radioGroupSent.TabIndex = 1;
            this.radioGroupSent.SelectedIndexChanged += new System.EventHandler(this.radioGroupSent_SelectedIndexChanged);
            // 
            // frmReminderExp
            // 
            this.ClientSize = new System.Drawing.Size(912, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReminderExp";
            this.Text = "View";
            this.Load += new System.EventHandler(this.frmReminderExp_Load);
            this.VisibleChanged += new System.EventHandler(this.frmReminderExp_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSent.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.RadioGroup radioGroupSent;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private System.Windows.Forms.ComboBox cmbReminderType;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.CheckBox chkShowComplete;
    }
}
