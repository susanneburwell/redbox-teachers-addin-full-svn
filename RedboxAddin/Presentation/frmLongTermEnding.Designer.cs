namespace RedboxAddin.Presentation
{
    partial class frmLongTermEnding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLongTermEnding));
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gcLongTermEditing = new DevExpress.XtraGrid.GridControl();
            this.gvLongTermEditing = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.School = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Details = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MasterBookingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BookingStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLongTermEditing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLongTermEditing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.lblTo);
            this.pnlSearch.Controls.Add(this.lblFrom);
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(810, 68);
            this.pnlSearch.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.gcLongTermEditing);
            this.pnlGrid.Location = new System.Drawing.Point(0, 68);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(810, 531);
            this.pnlGrid.TabIndex = 15;
            // 
            // gcLongTermEditing
            // 
            this.gcLongTermEditing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLongTermEditing.Location = new System.Drawing.Point(0, 0);
            this.gcLongTermEditing.MainView = this.gvLongTermEditing;
            this.gcLongTermEditing.Name = "gcLongTermEditing";
            this.gcLongTermEditing.Size = new System.Drawing.Size(810, 531);
            this.gcLongTermEditing.TabIndex = 4;
            this.gcLongTermEditing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLongTermEditing});
            // 
            // gvLongTermEditing
            // 
            this.gvLongTermEditing.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Date,
            this.School,
            this.Teacher,
            this.Details,
            this.MasterBookingID,
            this.BookingStatus});
            this.gvLongTermEditing.GridControl = this.gcLongTermEditing;
            this.gvLongTermEditing.Name = "gvLongTermEditing";
            this.gvLongTermEditing.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Date, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvLongTermEditing.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvLongTermEditing_RowClick);
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
            this.Teacher.FieldName = "FullName";
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
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.EditValue = null;
            this.dtpTo.Location = new System.Drawing.Point(309, 25);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dtpTo.MinimumSize = new System.Drawing.Size(170, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpTo.Size = new System.Drawing.Size(212, 20);
            this.dtpTo.TabIndex = 35;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.EditValue = null;
            this.dtpFrom.Location = new System.Drawing.Point(48, 25);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dtpFrom.MinimumSize = new System.Drawing.Size(170, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFrom.Size = new System.Drawing.Size(212, 20);
            this.dtpFrom.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(536, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(283, 28);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 32;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 27);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 31;
            this.lblFrom.Text = "From";
            // 
            // frmLongTermEnding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 601);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLongTermEnding";
            this.Text = "Long Term Ending";
            this.Load += new System.EventHandler(this.frmLongTermEnding_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLongTermEditing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLongTermEditing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlGrid;
        private DevExpress.XtraGrid.GridControl gcLongTermEditing;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLongTermEditing;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn School;
        private DevExpress.XtraGrid.Columns.GridColumn Teacher;
        private DevExpress.XtraGrid.Columns.GridColumn Details;
        private DevExpress.XtraGrid.Columns.GridColumn MasterBookingID;
        private DevExpress.XtraGrid.Columns.GridColumn BookingStatus;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
    }
}