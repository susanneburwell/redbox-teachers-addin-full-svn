namespace RedboxAddin.Presentation
{
    partial class frmLoadPivot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadPivot));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pivotGridControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 673);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.radCustom);
            this.panelTop.Controls.Add(this.radMonth);
            this.panelTop.Controls.Add(this.radWeek);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.dtTo);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(4, 4);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(936, 62);
            this.panelTop.TabIndex = 0;
            // 
            // radCustom
            // 
            this.radCustom.AutoSize = true;
            this.radCustom.Location = new System.Drawing.Point(468, 7);
            this.radCustom.Name = "radCustom";
            this.radCustom.Size = new System.Drawing.Size(88, 24);
            this.radCustom.TabIndex = 24;
            this.radCustom.Text = "Custom";
            this.radCustom.UseVisualStyleBackColor = true;
            this.radCustom.Click += new System.EventHandler(this.SetDates);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Location = new System.Drawing.Point(379, 7);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(76, 24);
            this.radMonth.TabIndex = 23;
            this.radMonth.Text = "Month";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.Click += new System.EventHandler(this.SetDates);
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.Checked = true;
            this.radWeek.Location = new System.Drawing.Point(291, 8);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(72, 24);
            this.radWeek.TabIndex = 22;
            this.radWeek.TabStop = true;
            this.radWeek.Text = "Week";
            this.radWeek.UseVisualStyleBackColor = true;
            this.radWeek.Click += new System.EventHandler(this.SetDates);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(78, 5);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 26);
            this.dtFrom.TabIndex = 18;
            this.dtFrom.ValueChanged += new System.EventHandler(this.RefreshGrid);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "From:";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(78, 32);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 26);
            this.dtTo.TabIndex = 20;
            this.dtTo.Visible = false;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(712, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 46);
            this.label1.TabIndex = 17;
            this.label1.Text = "Load Pivot";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(82, 36);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(45, 20);
            this.lblTo.TabIndex = 25;
            this.lblTo.Text = "lblTo";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7});
            this.pivotGridControl1.Location = new System.Drawing.Point(3, 73);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(938, 597);
            this.pivotGridControl1.TabIndex = 1;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "School";
            this.pivotGridField1.FieldName = "School";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "Name";
            this.pivotGridField2.FieldName = "Name";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 1;
            this.pivotGridField3.Caption = "Rate";
            this.pivotGridField3.FieldName = "Rate";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField4.AreaIndex = 2;
            this.pivotGridField4.Caption = "Charge";
            this.pivotGridField4.FieldName = "Charge";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField5.AreaIndex = 0;
            this.pivotGridField5.Caption = "Description";
            this.pivotGridField5.FieldName = "Description";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField6.AreaIndex = 4;
            this.pivotGridField6.Caption = "Margin";
            this.pivotGridField6.FieldName = "Margin";
            this.pivotGridField6.Name = "pivotGridField6";
            this.pivotGridField6.RunningTotal = true;
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField7.AreaIndex = 3;
            this.pivotGridField7.Caption = "Date";
            this.pivotGridField7.FieldName = "Date";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // frmLoadPivot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadPivot";
            this.Text = "Load Plan";
            this.Load += new System.EventHandler(this.frmLoadPlan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radWeek;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
    }
}