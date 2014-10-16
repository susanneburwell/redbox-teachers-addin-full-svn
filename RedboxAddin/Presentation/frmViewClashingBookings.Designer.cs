namespace RedboxAddin.Presentation
{
    partial class frmViewClashingBookings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MasterBookingID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SchoolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.days = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.47634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.523659F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 467);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(508, 94);
            this.panelTop.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(469, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "1. Select the master booking in the top table to see bookings in the lower table." +
    "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(424, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "2. Double click the booking in the lower table to edit.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Clashing Bookings";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 103);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(508, 351);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MasterBookingID,
            this.contactID,
            this.FirstName,
            this.LastName,
            this.SchoolName,
            this.Date,
            this.num,
            this.days});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // MasterBookingID
            // 
            this.MasterBookingID.Caption = "MasterBookingID";
            this.MasterBookingID.FieldName = "MasterBookingID";
            this.MasterBookingID.Name = "MasterBookingID";
            // 
            // contactID
            // 
            this.contactID.Caption = "contactID";
            this.contactID.FieldName = "contactID";
            this.contactID.Name = "contactID";
            // 
            // FirstName
            // 
            this.FirstName.Caption = "FirstName";
            this.FirstName.FieldName = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.OptionsColumn.AllowEdit = false;
            this.FirstName.OptionsColumn.ReadOnly = true;
            this.FirstName.Visible = true;
            this.FirstName.VisibleIndex = 0;
            this.FirstName.Width = 80;
            // 
            // LastName
            // 
            this.LastName.Caption = "LastName";
            this.LastName.FieldName = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.OptionsColumn.AllowEdit = false;
            this.LastName.OptionsColumn.ReadOnly = true;
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 1;
            this.LastName.Width = 81;
            // 
            // SchoolName
            // 
            this.SchoolName.Caption = "SchoolName";
            this.SchoolName.FieldName = "SchoolName";
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.OptionsColumn.AllowEdit = false;
            this.SchoolName.OptionsColumn.ReadOnly = true;
            this.SchoolName.Visible = true;
            this.SchoolName.VisibleIndex = 2;
            this.SchoolName.Width = 85;
            // 
            // Date
            // 
            this.Date.Caption = "Date";
            this.Date.FieldName = "Date";
            this.Date.Name = "Date";
            this.Date.OptionsColumn.AllowEdit = false;
            this.Date.OptionsColumn.ReadOnly = true;
            this.Date.Visible = true;
            this.Date.VisibleIndex = 3;
            this.Date.Width = 50;
            // 
            // num
            // 
            this.num.Caption = "num";
            this.num.FieldName = "num";
            this.num.Name = "num";
            // 
            // days
            // 
            this.days.Caption = "days";
            this.days.FieldName = "days";
            this.days.Name = "days";
            // 
            // frmViewClashingBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 467);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmViewClashingBookings";
            this.Text = " View Clashing-Bookings";
            this.Load += new System.EventHandler(this.frmViewClashingBookings_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SchoolName;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn MasterBookingID;
        private DevExpress.XtraGrid.Columns.GridColumn contactID;
        private DevExpress.XtraGrid.Columns.GridColumn FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn num;
        private DevExpress.XtraGrid.Columns.GridColumn days;
    }
}