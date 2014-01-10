namespace RedboxAddin.UC
{
    partial class AvailabilityGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailabilityGrid));
            this.Teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Live = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wants = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YrGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PofA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoGo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TueColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WedColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FriColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MonStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TueStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WedStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FriStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Teacher
            // 
            this.Teacher.Caption = "Teacher";
            this.Teacher.FieldName = "Teacher";
            this.Teacher.MaxWidth = 200;
            this.Teacher.MinWidth = 150;
            this.Teacher.Name = "Teacher";
            this.Teacher.OptionsColumn.AllowEdit = false;
            this.Teacher.OptionsColumn.ReadOnly = true;
            this.Teacher.Visible = true;
            this.Teacher.VisibleIndex = 0;
            this.Teacher.Width = 150;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1024, 504);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Teacher,
            this.Live,
            this.Wants,
            this.YrGroup,
            this.QTS,
            this.PofA,
            this.CRB,
            this.NoGo,
            this.Mon,
            this.MonG,
            this.Tue,
            this.Wed,
            this.Thur,
            this.Fri,
            this.MonColor,
            this.TueColor,
            this.WedColor,
            this.ThuColor,
            this.FriColor,
            this.MonStatus,
            this.TueStatus,
            this.WedStatus,
            this.ThuStatus,
            this.FriStatus});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Column = this.Teacher;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = " !IsNullOrEmpty([MonG])";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.MonG, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // Live
            // 
            this.Live.Caption = "Live";
            this.Live.FieldName = "Live";
            this.Live.MaxWidth = 75;
            this.Live.MinWidth = 50;
            this.Live.Name = "Live";
            this.Live.OptionsColumn.AllowEdit = false;
            this.Live.OptionsColumn.ReadOnly = true;
            this.Live.Visible = true;
            this.Live.VisibleIndex = 1;
            // 
            // Wants
            // 
            this.Wants.Caption = "Wants";
            this.Wants.FieldName = "Wants";
            this.Wants.MaxWidth = 85;
            this.Wants.MinWidth = 75;
            this.Wants.Name = "Wants";
            this.Wants.OptionsColumn.AllowEdit = false;
            this.Wants.OptionsColumn.ReadOnly = true;
            this.Wants.Visible = true;
            this.Wants.VisibleIndex = 2;
            // 
            // YrGroup
            // 
            this.YrGroup.Caption = "Yr Group";
            this.YrGroup.FieldName = "YrGroup";
            this.YrGroup.MaxWidth = 70;
            this.YrGroup.MinWidth = 50;
            this.YrGroup.Name = "YrGroup";
            this.YrGroup.OptionsColumn.AllowEdit = false;
            this.YrGroup.OptionsColumn.ReadOnly = true;
            this.YrGroup.Visible = true;
            this.YrGroup.VisibleIndex = 3;
            this.YrGroup.Width = 70;
            // 
            // QTS
            // 
            this.QTS.Caption = "QTS";
            this.QTS.FieldName = "QTS";
            this.QTS.MaxWidth = 40;
            this.QTS.MinWidth = 40;
            this.QTS.Name = "QTS";
            this.QTS.OptionsColumn.AllowEdit = false;
            this.QTS.OptionsColumn.ReadOnly = true;
            this.QTS.Visible = true;
            this.QTS.VisibleIndex = 4;
            this.QTS.Width = 40;
            // 
            // PofA
            // 
            this.PofA.Caption = "P of A";
            this.PofA.FieldName = "PofA";
            this.PofA.MaxWidth = 40;
            this.PofA.MinWidth = 40;
            this.PofA.Name = "PofA";
            this.PofA.OptionsColumn.AllowEdit = false;
            this.PofA.OptionsColumn.ReadOnly = true;
            this.PofA.Visible = true;
            this.PofA.VisibleIndex = 5;
            this.PofA.Width = 40;
            // 
            // CRB
            // 
            this.CRB.Caption = "CRB";
            this.CRB.Name = "CRB";
            this.CRB.OptionsColumn.AllowEdit = false;
            this.CRB.OptionsColumn.ReadOnly = true;
            this.CRB.Visible = true;
            this.CRB.VisibleIndex = 6;
            // 
            // NoGo
            // 
            this.NoGo.Caption = "NoGo";
            this.NoGo.FieldName = "NoGo";
            this.NoGo.Name = "NoGo";
            this.NoGo.OptionsColumn.AllowEdit = false;
            this.NoGo.OptionsColumn.ReadOnly = true;
            this.NoGo.Visible = true;
            this.NoGo.VisibleIndex = 7;
            // 
            // Mon
            // 
            this.Mon.Caption = "Mon";
            this.Mon.FieldName = "Monday";
            this.Mon.Name = "Mon";
            this.Mon.OptionsColumn.AllowEdit = false;
            this.Mon.OptionsColumn.ReadOnly = true;
            this.Mon.Visible = true;
            this.Mon.VisibleIndex = 8;
            // 
            // MonG
            // 
            this.MonG.Caption = "Guaranteed";
            this.MonG.FieldName = "MonG";
            this.MonG.Name = "MonG";
            this.MonG.Visible = true;
            this.MonG.VisibleIndex = 13;
            // 
            // Tue
            // 
            this.Tue.Caption = "Tue";
            this.Tue.FieldName = "Tuesday";
            this.Tue.Name = "Tue";
            this.Tue.OptionsColumn.AllowEdit = false;
            this.Tue.OptionsColumn.ReadOnly = true;
            this.Tue.Visible = true;
            this.Tue.VisibleIndex = 9;
            // 
            // Wed
            // 
            this.Wed.Caption = "Wed";
            this.Wed.FieldName = "Wednesday";
            this.Wed.Name = "Wed";
            this.Wed.OptionsColumn.AllowEdit = false;
            this.Wed.OptionsColumn.ReadOnly = true;
            this.Wed.Visible = true;
            this.Wed.VisibleIndex = 10;
            // 
            // Thur
            // 
            this.Thur.Caption = "Thur";
            this.Thur.FieldName = "Thursday";
            this.Thur.Name = "Thur";
            this.Thur.OptionsColumn.AllowEdit = false;
            this.Thur.OptionsColumn.ReadOnly = true;
            this.Thur.Visible = true;
            this.Thur.VisibleIndex = 11;
            // 
            // Fri
            // 
            this.Fri.Caption = "Fri";
            this.Fri.FieldName = "Friday";
            this.Fri.Name = "Fri";
            this.Fri.OptionsColumn.AllowEdit = false;
            this.Fri.OptionsColumn.ReadOnly = true;
            this.Fri.Visible = true;
            this.Fri.VisibleIndex = 12;
            // 
            // MonColor
            // 
            this.MonColor.Caption = "MonColor";
            this.MonColor.FieldName = "MonColor";
            this.MonColor.Name = "MonColor";
            this.MonColor.ShowUnboundExpressionMenu = true;
            // 
            // TueColor
            // 
            this.TueColor.Caption = "TueColor";
            this.TueColor.FieldName = "TueColor";
            this.TueColor.Name = "TueColor";
            // 
            // WedColor
            // 
            this.WedColor.Caption = "WedColor";
            this.WedColor.FieldName = "WedColor";
            this.WedColor.Name = "WedColor";
            // 
            // ThuColor
            // 
            this.ThuColor.Caption = "ThuColor";
            this.ThuColor.FieldName = "ThuColor";
            this.ThuColor.Name = "ThuColor";
            // 
            // FriColor
            // 
            this.FriColor.Caption = "FriColor";
            this.FriColor.FieldName = "FriColor";
            this.FriColor.Name = "FriColor";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "status.png");
            this.imageList1.Images.SetKeyName(1, "found.png");
            // 
            // MonStatus
            // 
            this.MonStatus.Caption = "MonStatus";
            this.MonStatus.FieldName = "MonStatus";
            this.MonStatus.Name = "MonStatus";
            // 
            // TueStatus
            // 
            this.TueStatus.Caption = "TueStatus";
            this.TueStatus.Name = "TueStatus";
            // 
            // WedStatus
            // 
            this.WedStatus.Caption = "WedStatus";
            this.WedStatus.Name = "WedStatus";
            // 
            // ThuStatus
            // 
            this.ThuStatus.Caption = "ThuStatus";
            this.ThuStatus.Name = "ThuStatus";
            // 
            // FriStatus
            // 
            this.FriStatus.Caption = "FriStatus";
            this.FriStatus.Name = "FriStatus";
            // 
            // AvailabilityGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "AvailabilityGrid";
            this.Size = new System.Drawing.Size(1024, 504);
            this.Load += new System.EventHandler(this.AvailabilityGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Teacher;
        private DevExpress.XtraGrid.Columns.GridColumn Live;
        private DevExpress.XtraGrid.Columns.GridColumn Wants;
        private DevExpress.XtraGrid.Columns.GridColumn YrGroup;
        private DevExpress.XtraGrid.Columns.GridColumn QTS;
        private DevExpress.XtraGrid.Columns.GridColumn PofA;
        private DevExpress.XtraGrid.Columns.GridColumn CRB;
        private DevExpress.XtraGrid.Columns.GridColumn NoGo;
        private DevExpress.XtraGrid.Columns.GridColumn Mon;
        private DevExpress.XtraGrid.Columns.GridColumn MonG;
        private DevExpress.XtraGrid.Columns.GridColumn Tue;
        private DevExpress.XtraGrid.Columns.GridColumn Wed;
        private DevExpress.XtraGrid.Columns.GridColumn Thur;
        private DevExpress.XtraGrid.Columns.GridColumn Fri;
        private DevExpress.XtraGrid.Columns.GridColumn MonColor;
        private DevExpress.XtraGrid.Columns.GridColumn TueColor;
        private DevExpress.XtraGrid.Columns.GridColumn WedColor;
        private DevExpress.XtraGrid.Columns.GridColumn ThuColor;
        private DevExpress.XtraGrid.Columns.GridColumn FriColor;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Columns.GridColumn MonStatus;
        private DevExpress.XtraGrid.Columns.GridColumn TueStatus;
        private DevExpress.XtraGrid.Columns.GridColumn WedStatus;
        private DevExpress.XtraGrid.Columns.GridColumn ThuStatus;
        private DevExpress.XtraGrid.Columns.GridColumn FriStatus;
    }
}
