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
            this.Location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wants = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YrGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PofA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NoGo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TueColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WedColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FriColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TueStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WedStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FriStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RWInc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BSL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstAid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Guar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LongTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TeacherID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.gridControl1.ToolTipController = this.toolTipController1;
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
            this.Location,
            this.Wants,
            this.YrGroup,
            this.QTS,
            this.PofA,
            this.CRB,
            this.NoGo,
            this.Mon,
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
            this.FriStatus,
            this.RWInc,
            this.BSL,
            this.FirstAid,
            this.Guar,
            this.LongTerm,
            this.TeacherID});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Column = this.Teacher;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = " !IsNullOrEmpty([Guar])";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Guar, DevExpress.Data.ColumnSortOrder.Descending)});
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
            // Location
            // 
            this.Location.Caption = "Location";
            this.Location.FieldName = "Location";
            this.Location.Name = "Location";
            this.Location.OptionsColumn.AllowEdit = false;
            this.Location.OptionsColumn.ReadOnly = true;
            this.Location.Visible = true;
            this.Location.VisibleIndex = 2;
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
            this.Wants.VisibleIndex = 3;
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
            this.YrGroup.VisibleIndex = 4;
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
            this.QTS.VisibleIndex = 5;
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
            this.PofA.VisibleIndex = 6;
            this.PofA.Width = 40;
            // 
            // CRB
            // 
            this.CRB.Caption = "DBS";
            this.CRB.FieldName = "CRB";
            this.CRB.Name = "CRB";
            this.CRB.OptionsColumn.AllowEdit = false;
            this.CRB.OptionsColumn.ReadOnly = true;
            this.CRB.Visible = true;
            this.CRB.VisibleIndex = 7;
            // 
            // NoGo
            // 
            this.NoGo.Caption = "NoGo";
            this.NoGo.FieldName = "NoGo";
            this.NoGo.Name = "NoGo";
            this.NoGo.OptionsColumn.AllowEdit = false;
            this.NoGo.OptionsColumn.ReadOnly = true;
            this.NoGo.Visible = true;
            this.NoGo.VisibleIndex = 8;
            // 
            // Mon
            // 
            this.Mon.Caption = "Mon";
            this.Mon.FieldName = "Monday";
            this.Mon.Name = "Mon";
            this.Mon.OptionsColumn.AllowEdit = false;
            this.Mon.OptionsColumn.ReadOnly = true;
            this.Mon.Visible = true;
            this.Mon.VisibleIndex = 9;
            // 
            // Tue
            // 
            this.Tue.Caption = "Tue";
            this.Tue.FieldName = "Tuesday";
            this.Tue.Name = "Tue";
            this.Tue.OptionsColumn.AllowEdit = false;
            this.Tue.OptionsColumn.ReadOnly = true;
            this.Tue.Visible = true;
            this.Tue.VisibleIndex = 10;
            // 
            // Wed
            // 
            this.Wed.Caption = "Wed";
            this.Wed.FieldName = "Wednesday";
            this.Wed.Name = "Wed";
            this.Wed.OptionsColumn.AllowEdit = false;
            this.Wed.OptionsColumn.ReadOnly = true;
            this.Wed.Visible = true;
            this.Wed.VisibleIndex = 11;
            // 
            // Thur
            // 
            this.Thur.Caption = "Thur";
            this.Thur.FieldName = "Thursday";
            this.Thur.Name = "Thur";
            this.Thur.OptionsColumn.AllowEdit = false;
            this.Thur.OptionsColumn.ReadOnly = true;
            this.Thur.Visible = true;
            this.Thur.VisibleIndex = 12;
            // 
            // Fri
            // 
            this.Fri.Caption = "Fri";
            this.Fri.FieldName = "Friday";
            this.Fri.Name = "Fri";
            this.Fri.OptionsColumn.AllowEdit = false;
            this.Fri.OptionsColumn.ReadOnly = true;
            this.Fri.Visible = true;
            this.Fri.VisibleIndex = 13;
            // 
            // MonColor
            // 
            this.MonColor.Caption = "MonColor";
            this.MonColor.FieldName = "MonColor";
            this.MonColor.Name = "MonColor";
            this.MonColor.OptionsColumn.AllowEdit = false;
            this.MonColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.MonColor.OptionsColumn.AllowMove = false;
            this.MonColor.OptionsColumn.AllowShowHide = false;
            this.MonColor.OptionsColumn.ReadOnly = true;
            this.MonColor.ShowUnboundExpressionMenu = true;
            // 
            // TueColor
            // 
            this.TueColor.Caption = "TueColor";
            this.TueColor.FieldName = "TueColor";
            this.TueColor.Name = "TueColor";
            this.TueColor.OptionsColumn.AllowEdit = false;
            this.TueColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TueColor.OptionsColumn.AllowMove = false;
            this.TueColor.OptionsColumn.AllowShowHide = false;
            this.TueColor.OptionsColumn.ReadOnly = true;
            // 
            // WedColor
            // 
            this.WedColor.Caption = "WedColor";
            this.WedColor.FieldName = "WedColor";
            this.WedColor.Name = "WedColor";
            this.WedColor.OptionsColumn.AllowEdit = false;
            this.WedColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.WedColor.OptionsColumn.AllowMove = false;
            this.WedColor.OptionsColumn.AllowShowHide = false;
            this.WedColor.OptionsColumn.ReadOnly = true;
            // 
            // ThuColor
            // 
            this.ThuColor.Caption = "ThuColor";
            this.ThuColor.FieldName = "ThuColor";
            this.ThuColor.Name = "ThuColor";
            this.ThuColor.OptionsColumn.AllowEdit = false;
            this.ThuColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ThuColor.OptionsColumn.AllowMove = false;
            this.ThuColor.OptionsColumn.AllowShowHide = false;
            this.ThuColor.OptionsColumn.ReadOnly = true;
            // 
            // FriColor
            // 
            this.FriColor.Caption = "FriColor";
            this.FriColor.FieldName = "FriColor";
            this.FriColor.Name = "FriColor";
            this.FriColor.OptionsColumn.AllowEdit = false;
            this.FriColor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FriColor.OptionsColumn.AllowMove = false;
            this.FriColor.OptionsColumn.AllowShowHide = false;
            this.FriColor.OptionsColumn.ReadOnly = true;
            // 
            // MonStatus
            // 
            this.MonStatus.Caption = "MonStatus";
            this.MonStatus.FieldName = "MonStatus";
            this.MonStatus.Name = "MonStatus";
            this.MonStatus.OptionsColumn.AllowEdit = false;
            this.MonStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.MonStatus.OptionsColumn.AllowMove = false;
            this.MonStatus.OptionsColumn.AllowShowHide = false;
            this.MonStatus.OptionsColumn.ReadOnly = true;
            // 
            // TueStatus
            // 
            this.TueStatus.Caption = "TueStatus";
            this.TueStatus.Name = "TueStatus";
            this.TueStatus.OptionsColumn.AllowEdit = false;
            this.TueStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TueStatus.OptionsColumn.AllowMove = false;
            this.TueStatus.OptionsColumn.AllowShowHide = false;
            this.TueStatus.OptionsColumn.ReadOnly = true;
            // 
            // WedStatus
            // 
            this.WedStatus.Caption = "WedStatus";
            this.WedStatus.Name = "WedStatus";
            this.WedStatus.OptionsColumn.AllowEdit = false;
            this.WedStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.WedStatus.OptionsColumn.AllowMove = false;
            this.WedStatus.OptionsColumn.AllowShowHide = false;
            this.WedStatus.OptionsColumn.ReadOnly = true;
            // 
            // ThuStatus
            // 
            this.ThuStatus.Caption = "ThuStatus";
            this.ThuStatus.Name = "ThuStatus";
            this.ThuStatus.OptionsColumn.AllowEdit = false;
            this.ThuStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ThuStatus.OptionsColumn.AllowMove = false;
            this.ThuStatus.OptionsColumn.AllowShowHide = false;
            this.ThuStatus.OptionsColumn.ReadOnly = true;
            // 
            // FriStatus
            // 
            this.FriStatus.Caption = "FriStatus";
            this.FriStatus.Name = "FriStatus";
            this.FriStatus.OptionsColumn.AllowEdit = false;
            this.FriStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FriStatus.OptionsColumn.AllowMove = false;
            this.FriStatus.OptionsColumn.AllowShowHide = false;
            this.FriStatus.OptionsColumn.ReadOnly = true;
            // 
            // RWInc
            // 
            this.RWInc.Caption = "RWInc";
            this.RWInc.FieldName = "RWInc";
            this.RWInc.Name = "RWInc";
            this.RWInc.OptionsColumn.AllowEdit = false;
            this.RWInc.OptionsColumn.ReadOnly = true;
            this.RWInc.Visible = true;
            this.RWInc.VisibleIndex = 14;
            // 
            // BSL
            // 
            this.BSL.Caption = "BSL";
            this.BSL.FieldName = "BSL";
            this.BSL.Name = "BSL";
            this.BSL.OptionsColumn.AllowEdit = false;
            this.BSL.OptionsColumn.ReadOnly = true;
            this.BSL.Visible = true;
            this.BSL.VisibleIndex = 15;
            // 
            // FirstAid
            // 
            this.FirstAid.Caption = "FirstAid";
            this.FirstAid.FieldName = "FirstAid";
            this.FirstAid.Name = "FirstAid";
            this.FirstAid.OptionsColumn.AllowEdit = false;
            this.FirstAid.OptionsColumn.ReadOnly = true;
            this.FirstAid.Visible = true;
            this.FirstAid.VisibleIndex = 16;
            // 
            // Guar
            // 
            this.Guar.Caption = "Guaranteed";
            this.Guar.FieldName = "Guar";
            this.Guar.Name = "Guar";
            this.Guar.OptionsColumn.AllowEdit = false;
            this.Guar.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Guar.OptionsColumn.AllowShowHide = false;
            this.Guar.OptionsColumn.ReadOnly = true;
            this.Guar.Visible = true;
            this.Guar.VisibleIndex = 17;
            // 
            // LongTerm
            // 
            this.LongTerm.Caption = "Long Term";
            this.LongTerm.FieldName = "LongTerm";
            this.LongTerm.Name = "LongTerm";
            this.LongTerm.Visible = true;
            this.LongTerm.VisibleIndex = 18;
            // 
            // TeacherID
            // 
            this.TeacherID.Caption = "TeacherID";
            this.TeacherID.FieldName = "TeacherID";
            this.TeacherID.Name = "TeacherID";
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "status.png");
            this.imageList1.Images.SetKeyName(1, "found.png");
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
        private DevExpress.XtraGrid.Columns.GridColumn Guar;
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
        private DevExpress.XtraGrid.Columns.GridColumn Location;
        private DevExpress.XtraGrid.Columns.GridColumn RWInc;
        private DevExpress.XtraGrid.Columns.GridColumn BSL;
        private DevExpress.XtraGrid.Columns.GridColumn FirstAid;
        private DevExpress.XtraGrid.Columns.GridColumn LongTerm;
        private DevExpress.XtraGrid.Columns.GridColumn TeacherID;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
