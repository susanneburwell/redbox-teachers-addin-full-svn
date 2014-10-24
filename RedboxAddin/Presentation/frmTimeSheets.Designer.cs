﻿namespace RedboxAddin.Presentation
{
    partial class frmTimeSheets
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeSheets));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.chkSendAuto = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbSchool = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bnFwd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.School = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.days = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DayRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1005, 673);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.chkSendAuto);
            this.panelTop.Controls.Add(this.btnSend);
            this.panelTop.Controls.Add(this.cmbSchool);
            this.panelTop.Controls.Add(this.btnNext);
            this.panelTop.Controls.Add(this.btnPrev);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.bnFwd);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(5, 5);
            this.panelTop.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(995, 76);
            this.panelTop.TabIndex = 0;
            // 
            // chkSendAuto
            // 
            this.chkSendAuto.AutoSize = true;
            this.chkSendAuto.Location = new System.Drawing.Point(653, 48);
            this.chkSendAuto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSendAuto.Name = "chkSendAuto";
            this.chkSendAuto.Size = new System.Drawing.Size(174, 24);
            this.chkSendAuto.TabIndex = 34;
            this.chkSendAuto.Text = "Send Automatically";
            this.chkSendAuto.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(645, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(93, 32);
            this.btnSend.TabIndex = 33;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbSchool
            // 
            this.cmbSchool.FormattingEnabled = true;
            this.cmbSchool.Location = new System.Drawing.Point(165, 43);
            this.cmbSchool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSchool.Name = "cmbSchool";
            this.cmbSchool.Size = new System.Drawing.Size(265, 28);
            this.cmbSchool.TabIndex = 32;
            this.cmbSchool.TextChanged += new System.EventHandler(this.cmbSchool_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(552, 43);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(63, 28);
            this.btnNext.TabIndex = 31;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(464, 43);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(63, 28);
            this.btnPrev.TabIndex = 30;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "School:";
            // 
            // bnFwd
            // 
            this.bnFwd.Location = new System.Drawing.Point(552, 9);
            this.bnFwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bnFwd.Name = "bnFwd";
            this.bnFwd.Size = new System.Drawing.Size(63, 28);
            this.bnFwd.TabIndex = 27;
            this.bnFwd.Text = ">>";
            this.bnFwd.UseVisualStyleBackColor = true;
            this.bnFwd.Click += new System.EventHandler(this.bnFwd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(464, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(63, 28);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(165, 10);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(265, 26);
            this.dtFrom.TabIndex = 18;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Week Beginning:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(748, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 46);
            this.label1.TabIndex = 17;
            this.label1.Text = "Time Sheets";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(5, 91);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(995, 577);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.AppearancePrint.HeaderPanel.Image = global::RedboxAddin.Properties.Resources.red_box_logo;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseImage = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.School,
            this.FullName,
            this.days,
            this.numDays,
            this.DayRate,
            this.Total,
            this.Description});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", null, "£{0:c}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Redbox Teachers Timesheet";
            // 
            // School
            // 
            this.School.Caption = "School";
            this.School.FieldName = "SchoolName";
            this.School.MaxWidth = 200;
            this.School.MinWidth = 100;
            this.School.Name = "School";
            this.School.Width = 189;
            // 
            // FullName
            // 
            this.FullName.Caption = "FullName";
            this.FullName.FieldName = "FullName";
            this.FullName.MaxWidth = 300;
            this.FullName.MinWidth = 100;
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 0;
            this.FullName.Width = 186;
            // 
            // days
            // 
            this.days.Caption = "Days";
            this.days.FieldName = "days";
            this.days.MaxWidth = 200;
            this.days.MinWidth = 50;
            this.days.Name = "days";
            this.days.Visible = true;
            this.days.VisibleIndex = 1;
            this.days.Width = 186;
            // 
            // numDays
            // 
            this.numDays.Caption = "No. of days";
            this.numDays.FieldName = "numDays";
            this.numDays.MaxWidth = 150;
            this.numDays.MinWidth = 50;
            this.numDays.Name = "numDays";
            this.numDays.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "numDays", "{0} days")});
            this.numDays.Visible = true;
            this.numDays.VisibleIndex = 2;
            this.numDays.Width = 94;
            // 
            // DayRate
            // 
            this.DayRate.Caption = "Daily Rate";
            this.DayRate.DisplayFormat.FormatString = "{0:c}";
            this.DayRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DayRate.FieldName = "DayRate";
            this.DayRate.MaxWidth = 80;
            this.DayRate.MinWidth = 50;
            this.DayRate.Name = "DayRate";
            // 
            // Total
            // 
            this.Total.Caption = "Total";
            this.Total.DisplayFormat.FormatString = "{0:c}";
            this.Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Total.FieldName = "Total";
            this.Total.MaxWidth = 100;
            this.Total.MinWidth = 80;
            this.Total.Name = "Total";
            this.Total.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:c}")});
            this.Total.Width = 80;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "Description";
            this.Description.MaxWidth = 250;
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 3;
            this.Description.Width = 150;
            // 
            // frmTimeSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimeSheets";
            this.Text = "Time Sheets";
            this.Load += new System.EventHandler(this.frmTimeSheets_Load);
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
        private System.Windows.Forms.ComboBox cmbSchool;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnFwd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn School;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn numDays;
        private DevExpress.XtraGrid.Columns.GridColumn DayRate;
        private DevExpress.XtraGrid.Columns.GridColumn Total;
        private DevExpress.XtraGrid.Columns.GridColumn days;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox chkSendAuto;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
    }
}