namespace RedboxAddin.Presentation
{
    partial class frmAvailabilitySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvailabilitySheet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSEN = new System.Windows.Forms.CheckBox();
            this.chkNN = new System.Windows.Forms.CheckBox();
            this.chkTA = new System.Windows.Forms.CheckBox();
            this.chkQNN = new System.Windows.Forms.CheckBox();
            this.chkOTT = new System.Windows.Forms.CheckBox();
            this.chkNQT = new System.Windows.Forms.CheckBox();
            this.chkQTS = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEY = new System.Windows.Forms.Button();
            this.chkRec = new System.Windows.Forms.CheckBox();
            this.chkYr1 = new System.Windows.Forms.CheckBox();
            this.chkNur = new System.Windows.Forms.CheckBox();
            this.chkYr2 = new System.Windows.Forms.CheckBox();
            this.chkYr3 = new System.Windows.Forms.CheckBox();
            this.chkYr4 = new System.Windows.Forms.CheckBox();
            this.chkYr5 = new System.Windows.Forms.CheckBox();
            this.chkYr6 = new System.Windows.Forms.CheckBox();
            this.btnKS1 = new System.Windows.Forms.Button();
            this.btnKS2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.71428F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 525);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 137);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1031, 385);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Teacher";
            this.gridColumn1.FieldName = "Teacher";
            this.gridColumn1.MaxWidth = 200;
            this.gridColumn1.MinWidth = 150;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Live";
            this.gridColumn2.FieldName = "Live";
            this.gridColumn2.MaxWidth = 75;
            this.gridColumn2.MinWidth = 50;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Wants";
            this.gridColumn3.FieldName = "Wants";
            this.gridColumn3.MaxWidth = 85;
            this.gridColumn3.MinWidth = 75;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Yr Group";
            this.gridColumn4.FieldName = "YrGroup";
            this.gridColumn4.MaxWidth = 70;
            this.gridColumn4.MinWidth = 50;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "QTS";
            this.gridColumn5.FieldName = "QTS";
            this.gridColumn5.MaxWidth = 40;
            this.gridColumn5.MinWidth = 40;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 40;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "P of A";
            this.gridColumn7.FieldName = "PofA";
            this.gridColumn7.MaxWidth = 40;
            this.gridColumn7.MinWidth = 40;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 40;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CRB";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "NoGo";
            this.gridColumn9.FieldName = "NoGo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Mon";
            this.gridColumn10.FieldName = "Monday";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tue";
            this.gridColumn11.FieldName = "Tuesday";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Wed";
            this.gridColumn12.FieldName = "Wednesday";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Thur";
            this.gridColumn13.FieldName = "Thursday";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Fri";
            this.gridColumn14.FieldName = "Friday";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Controls.Add(this.groupBox6);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1031, 128);
            this.panelTop.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkSEN);
            this.groupBox1.Controls.Add(this.chkNN);
            this.groupBox1.Controls.Add(this.chkTA);
            this.groupBox1.Controls.Add(this.chkQNN);
            this.groupBox1.Controls.Add(this.chkOTT);
            this.groupBox1.Controls.Add(this.chkNQT);
            this.groupBox1.Controls.Add(this.chkQTS);
            this.groupBox1.Location = new System.Drawing.Point(9, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 71);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Qualifications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Match ANY ticked";
            // 
            // chkSEN
            // 
            this.chkSEN.AutoSize = true;
            this.chkSEN.Location = new System.Drawing.Point(139, 45);
            this.chkSEN.Name = "chkSEN";
            this.chkSEN.Size = new System.Drawing.Size(55, 20);
            this.chkSEN.TabIndex = 17;
            this.chkSEN.Text = "SEN";
            this.chkSEN.UseVisualStyleBackColor = true;
            this.chkSEN.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkNN
            // 
            this.chkNN.AutoSize = true;
            this.chkNN.Location = new System.Drawing.Point(77, 45);
            this.chkNN.Name = "chkNN";
            this.chkNN.Size = new System.Drawing.Size(47, 20);
            this.chkNN.TabIndex = 16;
            this.chkNN.Text = "NN";
            this.chkNN.UseVisualStyleBackColor = true;
            this.chkNN.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkTA
            // 
            this.chkTA.AutoSize = true;
            this.chkTA.Location = new System.Drawing.Point(200, 21);
            this.chkTA.Name = "chkTA";
            this.chkTA.Size = new System.Drawing.Size(45, 20);
            this.chkTA.TabIndex = 15;
            this.chkTA.Text = "TA";
            this.chkTA.UseVisualStyleBackColor = true;
            this.chkTA.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkQNN
            // 
            this.chkQNN.AutoSize = true;
            this.chkQNN.Location = new System.Drawing.Point(17, 47);
            this.chkQNN.Name = "chkQNN";
            this.chkQNN.Size = new System.Drawing.Size(57, 20);
            this.chkQNN.TabIndex = 14;
            this.chkQNN.Text = "QNN";
            this.chkQNN.UseVisualStyleBackColor = true;
            this.chkQNN.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkOTT
            // 
            this.chkOTT.AutoSize = true;
            this.chkOTT.Location = new System.Drawing.Point(139, 21);
            this.chkOTT.Name = "chkOTT";
            this.chkOTT.Size = new System.Drawing.Size(55, 20);
            this.chkOTT.TabIndex = 13;
            this.chkOTT.Text = "OTT";
            this.chkOTT.UseVisualStyleBackColor = true;
            this.chkOTT.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkNQT
            // 
            this.chkNQT.AutoSize = true;
            this.chkNQT.Location = new System.Drawing.Point(78, 21);
            this.chkNQT.Name = "chkNQT";
            this.chkNQT.Size = new System.Drawing.Size(56, 20);
            this.chkNQT.TabIndex = 12;
            this.chkNQT.Text = "NQT";
            this.chkNQT.UseVisualStyleBackColor = true;
            this.chkNQT.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkQTS
            // 
            this.chkQTS.AutoSize = true;
            this.chkQTS.Location = new System.Drawing.Point(17, 21);
            this.chkQTS.Name = "chkQTS";
            this.chkQTS.Size = new System.Drawing.Size(55, 20);
            this.chkQTS.TabIndex = 11;
            this.chkQTS.Text = "QTS";
            this.chkQTS.UseVisualStyleBackColor = true;
            this.chkQTS.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.btnEY);
            this.groupBox6.Controls.Add(this.chkRec);
            this.groupBox6.Controls.Add(this.chkYr1);
            this.groupBox6.Controls.Add(this.chkNur);
            this.groupBox6.Controls.Add(this.chkYr2);
            this.groupBox6.Controls.Add(this.chkYr3);
            this.groupBox6.Controls.Add(this.chkYr4);
            this.groupBox6.Controls.Add(this.chkYr5);
            this.groupBox6.Controls.Add(this.chkYr6);
            this.groupBox6.Controls.Add(this.btnKS1);
            this.groupBox6.Controls.Add(this.btnKS2);
            this.groupBox6.Location = new System.Drawing.Point(384, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(350, 110);
            this.groupBox6.TabIndex = 81;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Year Groups";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(253, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Match ALL ticked";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "KS2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "KS1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "EY";
            // 
            // btnEY
            // 
            this.btnEY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEY.Location = new System.Drawing.Point(42, 27);
            this.btnEY.Name = "btnEY";
            this.btnEY.Size = new System.Drawing.Size(15, 15);
            this.btnEY.TabIndex = 20;
            this.btnEY.UseVisualStyleBackColor = true;
            // 
            // chkRec
            // 
            this.chkRec.AutoSize = true;
            this.chkRec.Location = new System.Drawing.Point(174, 24);
            this.chkRec.Name = "chkRec";
            this.chkRec.Size = new System.Drawing.Size(52, 20);
            this.chkRec.TabIndex = 11;
            this.chkRec.Text = "Rec";
            this.chkRec.UseVisualStyleBackColor = true;
            this.chkRec.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr1
            // 
            this.chkYr1.AutoSize = true;
            this.chkYr1.Location = new System.Drawing.Point(109, 50);
            this.chkYr1.Name = "chkYr1";
            this.chkYr1.Size = new System.Drawing.Size(47, 20);
            this.chkYr1.TabIndex = 12;
            this.chkYr1.Text = "Yr1";
            this.chkYr1.UseVisualStyleBackColor = true;
            this.chkYr1.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkNur
            // 
            this.chkNur.AutoSize = true;
            this.chkNur.Location = new System.Drawing.Point(110, 24);
            this.chkNur.Name = "chkNur";
            this.chkNur.Size = new System.Drawing.Size(48, 20);
            this.chkNur.TabIndex = 10;
            this.chkNur.Text = "Nur";
            this.chkNur.UseVisualStyleBackColor = true;
            this.chkNur.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr2
            // 
            this.chkYr2.AutoSize = true;
            this.chkYr2.Location = new System.Drawing.Point(173, 50);
            this.chkYr2.Name = "chkYr2";
            this.chkYr2.Size = new System.Drawing.Size(47, 20);
            this.chkYr2.TabIndex = 13;
            this.chkYr2.Text = "Yr2";
            this.chkYr2.UseVisualStyleBackColor = true;
            this.chkYr2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr3
            // 
            this.chkYr3.AutoSize = true;
            this.chkYr3.Location = new System.Drawing.Point(109, 79);
            this.chkYr3.Name = "chkYr3";
            this.chkYr3.Size = new System.Drawing.Size(47, 20);
            this.chkYr3.TabIndex = 14;
            this.chkYr3.Text = "Yr3";
            this.chkYr3.UseVisualStyleBackColor = true;
            this.chkYr3.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr4
            // 
            this.chkYr4.AutoSize = true;
            this.chkYr4.Location = new System.Drawing.Point(173, 79);
            this.chkYr4.Name = "chkYr4";
            this.chkYr4.Size = new System.Drawing.Size(47, 20);
            this.chkYr4.TabIndex = 15;
            this.chkYr4.Text = "Yr4";
            this.chkYr4.UseVisualStyleBackColor = true;
            this.chkYr4.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr5
            // 
            this.chkYr5.AutoSize = true;
            this.chkYr5.Location = new System.Drawing.Point(231, 79);
            this.chkYr5.Name = "chkYr5";
            this.chkYr5.Size = new System.Drawing.Size(47, 20);
            this.chkYr5.TabIndex = 16;
            this.chkYr5.Text = "Yr5";
            this.chkYr5.UseVisualStyleBackColor = true;
            this.chkYr5.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr6
            // 
            this.chkYr6.AutoSize = true;
            this.chkYr6.Location = new System.Drawing.Point(293, 79);
            this.chkYr6.Name = "chkYr6";
            this.chkYr6.Size = new System.Drawing.Size(47, 20);
            this.chkYr6.TabIndex = 17;
            this.chkYr6.Text = "Yr6";
            this.chkYr6.UseVisualStyleBackColor = true;
            this.chkYr6.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // btnKS1
            // 
            this.btnKS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKS1.Location = new System.Drawing.Point(42, 53);
            this.btnKS1.Name = "btnKS1";
            this.btnKS1.Size = new System.Drawing.Size(15, 15);
            this.btnKS1.TabIndex = 21;
            this.btnKS1.UseVisualStyleBackColor = true;
            // 
            // btnKS2
            // 
            this.btnKS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKS2.Location = new System.Drawing.Point(42, 78);
            this.btnKS2.Name = "btnKS2";
            this.btnKS2.Size = new System.Drawing.Size(15, 15);
            this.btnKS2.TabIndex = 22;
            this.btnKS2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(750, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "Availability Sheet";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(891, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(123, 17);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 6;
            this.dtFrom.ValueChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date:";
            // 
            // frmAvailabilitySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 525);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAvailabilitySheet";
            this.Text = "Availability Sheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAvailabilitySheet_FormClosing);
            this.Load += new System.EventHandler(this.frmAvailabilitySheet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEY;
        private System.Windows.Forms.CheckBox chkRec;
        private System.Windows.Forms.CheckBox chkYr1;
        private System.Windows.Forms.CheckBox chkNur;
        private System.Windows.Forms.CheckBox chkYr2;
        private System.Windows.Forms.CheckBox chkYr3;
        private System.Windows.Forms.CheckBox chkYr4;
        private System.Windows.Forms.CheckBox chkYr5;
        private System.Windows.Forms.CheckBox chkYr6;
        private System.Windows.Forms.Button btnKS1;
        private System.Windows.Forms.Button btnKS2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSEN;
        private System.Windows.Forms.CheckBox chkNN;
        private System.Windows.Forms.CheckBox chkTA;
        private System.Windows.Forms.CheckBox chkQNN;
        private System.Windows.Forms.CheckBox chkOTT;
        private System.Windows.Forms.CheckBox chkNQT;
        private System.Windows.Forms.CheckBox chkQTS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}