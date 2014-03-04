namespace RedboxAddin.Presentation
{
    partial class frmSendVetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendVetting));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Selected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.School = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Booking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BookingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SchoolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBot = new System.Windows.Forms.Panel();
            this.chkSendAuto = new System.Windows.Forms.CheckBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.radAny = new System.Windows.Forms.RadioButton();
            this.radShowConfirmed = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBot.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "This sends an automated email for all bookings starting starting \r\non the given d" +
    "ate, whose status is \'confimed\'.";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(571, 24);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(25, 11);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 7;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 53);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(991, 391);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Selected,
            this.Date,
            this.School,
            this.Teacher,
            this.Booking,
            this.Status,
            this.BookingID,
            this.ContactID,
            this.SchoolID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // Selected
            // 
            this.Selected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Selected.FieldName = "Selected";
            this.Selected.MaxWidth = 30;
            this.Selected.Name = "Selected";
            this.Selected.Visible = true;
            this.Selected.VisibleIndex = 0;
            this.Selected.Width = 28;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // Date
            // 
            this.Date.Caption = "Date";
            this.Date.FieldName = "Date";
            this.Date.MaxWidth = 150;
            this.Date.MinWidth = 70;
            this.Date.Name = "Date";
            this.Date.Visible = true;
            this.Date.VisibleIndex = 1;
            this.Date.Width = 70;
            // 
            // School
            // 
            this.School.Caption = "School";
            this.School.FieldName = "SchoolName";
            this.School.MaxWidth = 200;
            this.School.MinWidth = 150;
            this.School.Name = "School";
            this.School.Visible = true;
            this.School.VisibleIndex = 2;
            this.School.Width = 150;
            // 
            // Teacher
            // 
            this.Teacher.Caption = "Teacher";
            this.Teacher.FieldName = "Teacher";
            this.Teacher.MaxWidth = 200;
            this.Teacher.MinWidth = 100;
            this.Teacher.Name = "Teacher";
            this.Teacher.Visible = true;
            this.Teacher.VisibleIndex = 3;
            this.Teacher.Width = 150;
            // 
            // Booking
            // 
            this.Booking.Caption = "Booking";
            this.Booking.FieldName = "Description";
            this.Booking.MaxWidth = 450;
            this.Booking.MinWidth = 70;
            this.Booking.Name = "Booking";
            this.Booking.Visible = true;
            this.Booking.VisibleIndex = 4;
            this.Booking.Width = 150;
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "BookingStatus";
            this.Status.MaxWidth = 100;
            this.Status.MinWidth = 50;
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.VisibleIndex = 5;
            // 
            // BookingID
            // 
            this.BookingID.Caption = "MasterBookingID";
            this.BookingID.FieldName = "MasterBookingID";
            this.BookingID.Name = "BookingID";
            // 
            // ContactID
            // 
            this.ContactID.Caption = "ContactID";
            this.ContactID.FieldName = "ContactID";
            this.ContactID.Name = "ContactID";
            // 
            // SchoolID
            // 
            this.SchoolID.Caption = "SchoolID";
            this.SchoolID.FieldName = "SchoolID";
            this.SchoolID.Name = "SchoolID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelBot, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(997, 522);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panelBot
            // 
            this.panelBot.Controls.Add(this.chkSendAuto);
            this.panelBot.Controls.Add(this.label1);
            this.panelBot.Controls.Add(this.btnSend);
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBot.Location = new System.Drawing.Point(3, 450);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(991, 69);
            this.panelBot.TabIndex = 0;
            // 
            // chkSendAuto
            // 
            this.chkSendAuto.AutoSize = true;
            this.chkSendAuto.Location = new System.Drawing.Point(666, 31);
            this.chkSendAuto.Name = "chkSendAuto";
            this.chkSendAuto.Size = new System.Drawing.Size(142, 20);
            this.chkSendAuto.TabIndex = 2;
            this.chkSendAuto.Text = "Send Automatically";
            this.toolTip1.SetToolTip(this.chkSendAuto, "If you tick this the emails will be sent without being seen by you.");
            this.chkSendAuto.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.radAny);
            this.panelTop.Controls.Add(this.radShowConfirmed);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(991, 44);
            this.panelTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(918, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radAny
            // 
            this.radAny.AutoSize = true;
            this.radAny.Location = new System.Drawing.Point(700, 11);
            this.radAny.Name = "radAny";
            this.radAny.Size = new System.Drawing.Size(89, 20);
            this.radAny.TabIndex = 9;
            this.radAny.Text = "Any Status";
            this.radAny.UseVisualStyleBackColor = true;
            // 
            // radShowConfirmed
            // 
            this.radShowConfirmed.AutoSize = true;
            this.radShowConfirmed.Checked = true;
            this.radShowConfirmed.Location = new System.Drawing.Point(795, 11);
            this.radShowConfirmed.Name = "radShowConfirmed";
            this.radShowConfirmed.Size = new System.Drawing.Size(117, 20);
            this.radShowConfirmed.TabIndex = 8;
            this.radShowConfirmed.TabStop = true;
            this.radShowConfirmed.Text = "Confirmed Only";
            this.radShowConfirmed.UseVisualStyleBackColor = true;
            // 
            // frmSendVetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSendVetting";
            this.Text = "Send Vetting Details";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelBot.ResumeLayout(false);
            this.panelBot.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Selected;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn School;
        private DevExpress.XtraGrid.Columns.GridColumn Teacher;
        private DevExpress.XtraGrid.Columns.GridColumn Booking;
        private DevExpress.XtraGrid.Columns.GridColumn BookingID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelBot;
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraGrid.Columns.GridColumn ContactID;
        private DevExpress.XtraGrid.Columns.GridColumn SchoolID;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private System.Windows.Forms.RadioButton radAny;
        private System.Windows.Forms.RadioButton radShowConfirmed;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkSendAuto;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}