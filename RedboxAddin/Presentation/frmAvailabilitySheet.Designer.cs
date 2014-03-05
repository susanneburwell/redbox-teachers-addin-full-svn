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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvailabilitySheet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.chkJustBookings = new System.Windows.Forms.CheckBox();
            this.btnDblBkgs = new System.Windows.Forms.Button();
            this.bnFwd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpQual = new System.Windows.Forms.GroupBox();
            this.chkTeacher = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSEN = new System.Windows.Forms.CheckBox();
            this.chkNN = new System.Windows.Forms.CheckBox();
            this.chkTA = new System.Windows.Forms.CheckBox();
            this.chkQNN = new System.Windows.Forms.CheckBox();
            this.chkOTT = new System.Windows.Forms.CheckBox();
            this.chkNQT = new System.Windows.Forms.CheckBox();
            this.chkQTS = new System.Windows.Forms.CheckBox();
            this.grpYearGroups = new System.Windows.Forms.GroupBox();
            this.chkGuaranteed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLongTerm = new System.Windows.Forms.CheckBox();
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
            this.availabilityGrid1 = new RedboxAddin.UC.AvailabilityGrid();
            this.panelRibbon = new System.Windows.Forms.Panel();
            this.btnCreatePaySheets = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.CheckDoubleBookingsTimer1 = new System.Windows.Forms.Timer(this.components);
            this.flashtimer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.grpQual.SuspendLayout();
            this.grpYearGroups.SuspendLayout();
            this.panelRibbon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.availabilityGrid1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelRibbon, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 662);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.chkJustBookings);
            this.panelTop.Controls.Add(this.btnDblBkgs);
            this.panelTop.Controls.Add(this.bnFwd);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.grpQual);
            this.panelTop.Controls.Add(this.grpYearGroups);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.dtFrom);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 43);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1002, 169);
            this.panelTop.TabIndex = 0;
            // 
            // chkJustBookings
            // 
            this.chkJustBookings.AutoSize = true;
            this.chkJustBookings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkJustBookings.Location = new System.Drawing.Point(848, 129);
            this.chkJustBookings.Name = "chkJustBookings";
            this.chkJustBookings.Size = new System.Drawing.Size(147, 20);
            this.chkJustBookings.TabIndex = 89;
            this.chkJustBookings.Text = "Just Show Bookings";
            this.chkJustBookings.UseVisualStyleBackColor = true;
            this.chkJustBookings.CheckedChanged += new System.EventHandler(this.chkJustBookings_CheckedChanged);
            // 
            // btnDblBkgs
            // 
            this.btnDblBkgs.BackColor = System.Drawing.Color.Crimson;
            this.btnDblBkgs.ForeColor = System.Drawing.Color.White;
            this.btnDblBkgs.Location = new System.Drawing.Point(740, 56);
            this.btnDblBkgs.Name = "btnDblBkgs";
            this.btnDblBkgs.Size = new System.Drawing.Size(255, 30);
            this.btnDblBkgs.TabIndex = 86;
            this.btnDblBkgs.Text = "Double Bookings Detected";
            this.btnDblBkgs.UseVisualStyleBackColor = false;
            this.btnDblBkgs.Visible = false;
            this.btnDblBkgs.Click += new System.EventHandler(this.btnDblBkgs_Click);
            // 
            // bnFwd
            // 
            this.bnFwd.Location = new System.Drawing.Point(323, 18);
            this.bnFwd.Name = "bnFwd";
            this.bnFwd.Size = new System.Drawing.Size(35, 23);
            this.bnFwd.TabIndex = 84;
            this.bnFwd.Text = ">>";
            this.bnFwd.UseVisualStyleBackColor = true;
            this.bnFwd.Click += new System.EventHandler(this.bnFwd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(280, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(37, 23);
            this.btnBack.TabIndex = 83;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpQual
            // 
            this.grpQual.Controls.Add(this.chkTeacher);
            this.grpQual.Controls.Add(this.label2);
            this.grpQual.Controls.Add(this.chkSEN);
            this.grpQual.Controls.Add(this.chkNN);
            this.grpQual.Controls.Add(this.chkTA);
            this.grpQual.Controls.Add(this.chkQNN);
            this.grpQual.Controls.Add(this.chkOTT);
            this.grpQual.Controls.Add(this.chkNQT);
            this.grpQual.Controls.Add(this.chkQTS);
            this.grpQual.Location = new System.Drawing.Point(9, 48);
            this.grpQual.Name = "grpQual";
            this.grpQual.Size = new System.Drawing.Size(349, 106);
            this.grpQual.TabIndex = 82;
            this.grpQual.TabStop = false;
            this.grpQual.Text = "Qualifications";
            // 
            // chkTeacher
            // 
            this.chkTeacher.AutoSize = true;
            this.chkTeacher.Location = new System.Drawing.Point(17, 76);
            this.chkTeacher.Name = "chkTeacher";
            this.chkTeacher.Size = new System.Drawing.Size(78, 20);
            this.chkTeacher.TabIndex = 19;
            this.chkTeacher.Text = "Teacher";
            this.chkTeacher.UseVisualStyleBackColor = true;
            this.chkTeacher.CheckedChanged += new System.EventHandler(this.CheckedChanged);
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
            this.chkSEN.Location = new System.Drawing.Point(172, 50);
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
            this.chkNN.Location = new System.Drawing.Point(93, 50);
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
            this.chkTA.Location = new System.Drawing.Point(172, 76);
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
            this.chkQNN.Location = new System.Drawing.Point(17, 50);
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
            this.chkOTT.Location = new System.Drawing.Point(172, 21);
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
            this.chkNQT.Location = new System.Drawing.Point(93, 21);
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
            // grpYearGroups
            // 
            this.grpYearGroups.Controls.Add(this.chkGuaranteed);
            this.grpYearGroups.Controls.Add(this.label3);
            this.grpYearGroups.Controls.Add(this.chkLongTerm);
            this.grpYearGroups.Controls.Add(this.label9);
            this.grpYearGroups.Controls.Add(this.label8);
            this.grpYearGroups.Controls.Add(this.label7);
            this.grpYearGroups.Controls.Add(this.btnEY);
            this.grpYearGroups.Controls.Add(this.chkRec);
            this.grpYearGroups.Controls.Add(this.chkYr1);
            this.grpYearGroups.Controls.Add(this.chkNur);
            this.grpYearGroups.Controls.Add(this.chkYr2);
            this.grpYearGroups.Controls.Add(this.chkYr3);
            this.grpYearGroups.Controls.Add(this.chkYr4);
            this.grpYearGroups.Controls.Add(this.chkYr5);
            this.grpYearGroups.Controls.Add(this.chkYr6);
            this.grpYearGroups.Controls.Add(this.btnKS1);
            this.grpYearGroups.Controls.Add(this.btnKS2);
            this.grpYearGroups.Location = new System.Drawing.Point(384, 9);
            this.grpYearGroups.Name = "grpYearGroups";
            this.grpYearGroups.Size = new System.Drawing.Size(350, 145);
            this.grpYearGroups.TabIndex = 81;
            this.grpYearGroups.TabStop = false;
            this.grpYearGroups.Text = "Year Groups";
            // 
            // chkGuaranteed
            // 
            this.chkGuaranteed.AutoSize = true;
            this.chkGuaranteed.Location = new System.Drawing.Point(231, 116);
            this.chkGuaranteed.Name = "chkGuaranteed";
            this.chkGuaranteed.Size = new System.Drawing.Size(98, 20);
            this.chkGuaranteed.TabIndex = 88;
            this.chkGuaranteed.Text = "Guaranteed";
            this.chkGuaranteed.UseVisualStyleBackColor = true;
            this.chkGuaranteed.Click += new System.EventHandler(this.CheckedChanged);
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
            // chkLongTerm
            // 
            this.chkLongTerm.AutoSize = true;
            this.chkLongTerm.Location = new System.Drawing.Point(79, 116);
            this.chkLongTerm.Name = "chkLongTerm";
            this.chkLongTerm.Size = new System.Drawing.Size(92, 20);
            this.chkLongTerm.TabIndex = 87;
            this.chkLongTerm.Text = "Long Term";
            this.chkLongTerm.UseVisualStyleBackColor = true;
            this.chkLongTerm.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "KS2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "KS1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
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
            this.btnEY.Click += new System.EventHandler(this.btnEY_Click);
            // 
            // chkRec
            // 
            this.chkRec.AutoSize = true;
            this.chkRec.Location = new System.Drawing.Point(168, 24);
            this.chkRec.Name = "chkRec";
            this.chkRec.Size = new System.Drawing.Size(52, 20);
            this.chkRec.TabIndex = 11;
            this.chkRec.Text = "Rec";
            this.chkRec.UseVisualStyleBackColor = true;
            this.chkRec.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr1
            // 
            this.chkYr1.AutoSize = true;
            this.chkYr1.Location = new System.Drawing.Point(79, 56);
            this.chkYr1.Name = "chkYr1";
            this.chkYr1.Size = new System.Drawing.Size(47, 20);
            this.chkYr1.TabIndex = 12;
            this.chkYr1.Text = "Yr1";
            this.chkYr1.UseVisualStyleBackColor = true;
            this.chkYr1.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkNur
            // 
            this.chkNur.AutoSize = true;
            this.chkNur.Location = new System.Drawing.Point(80, 24);
            this.chkNur.Name = "chkNur";
            this.chkNur.Size = new System.Drawing.Size(48, 20);
            this.chkNur.TabIndex = 10;
            this.chkNur.Text = "Nur";
            this.chkNur.UseVisualStyleBackColor = true;
            this.chkNur.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr2
            // 
            this.chkYr2.AutoSize = true;
            this.chkYr2.Location = new System.Drawing.Point(167, 56);
            this.chkYr2.Name = "chkYr2";
            this.chkYr2.Size = new System.Drawing.Size(47, 20);
            this.chkYr2.TabIndex = 13;
            this.chkYr2.Text = "Yr2";
            this.chkYr2.UseVisualStyleBackColor = true;
            this.chkYr2.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr3
            // 
            this.chkYr3.AutoSize = true;
            this.chkYr3.Location = new System.Drawing.Point(79, 87);
            this.chkYr3.Name = "chkYr3";
            this.chkYr3.Size = new System.Drawing.Size(47, 20);
            this.chkYr3.TabIndex = 14;
            this.chkYr3.Text = "Yr3";
            this.chkYr3.UseVisualStyleBackColor = true;
            this.chkYr3.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr4
            // 
            this.chkYr4.AutoSize = true;
            this.chkYr4.Location = new System.Drawing.Point(167, 87);
            this.chkYr4.Name = "chkYr4";
            this.chkYr4.Size = new System.Drawing.Size(47, 20);
            this.chkYr4.TabIndex = 15;
            this.chkYr4.Text = "Yr4";
            this.chkYr4.UseVisualStyleBackColor = true;
            this.chkYr4.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr5
            // 
            this.chkYr5.AutoSize = true;
            this.chkYr5.Location = new System.Drawing.Point(231, 87);
            this.chkYr5.Name = "chkYr5";
            this.chkYr5.Size = new System.Drawing.Size(47, 20);
            this.chkYr5.TabIndex = 16;
            this.chkYr5.Text = "Yr5";
            this.chkYr5.UseVisualStyleBackColor = true;
            this.chkYr5.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // chkYr6
            // 
            this.chkYr6.AutoSize = true;
            this.chkYr6.Location = new System.Drawing.Point(293, 87);
            this.chkYr6.Name = "chkYr6";
            this.chkYr6.Size = new System.Drawing.Size(47, 20);
            this.chkYr6.TabIndex = 17;
            this.chkYr6.Text = "Yr6";
            this.chkYr6.UseVisualStyleBackColor = true;
            this.chkYr6.Click += new System.EventHandler(this.CheckedChanged);
            // 
            // btnKS1
            // 
            this.btnKS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKS1.Location = new System.Drawing.Point(42, 59);
            this.btnKS1.Name = "btnKS1";
            this.btnKS1.Size = new System.Drawing.Size(15, 15);
            this.btnKS1.TabIndex = 21;
            this.btnKS1.UseVisualStyleBackColor = true;
            this.btnKS1.Click += new System.EventHandler(this.btnKS1_Click);
            // 
            // btnKS2
            // 
            this.btnKS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKS2.Location = new System.Drawing.Point(42, 86);
            this.btnKS2.Name = "btnKS2";
            this.btnKS2.Size = new System.Drawing.Size(15, 15);
            this.btnKS2.TabIndex = 22;
            this.btnKS2.UseVisualStyleBackColor = true;
            this.btnKS2.Click += new System.EventHandler(this.btnKS2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(739, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "Availability Sheet";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(804, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(191, 30);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(72, 16);
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
            // availabilityGrid1
            // 
            this.availabilityGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availabilityGrid1.Location = new System.Drawing.Point(4, 219);
            this.availabilityGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.availabilityGrid1.Name = "availabilityGrid1";
            this.availabilityGrid1.Size = new System.Drawing.Size(1000, 439);
            this.availabilityGrid1.TabIndex = 1;
            // 
            // panelRibbon
            // 
            this.panelRibbon.Controls.Add(this.btnCreatePaySheets);
            this.panelRibbon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRibbon.Location = new System.Drawing.Point(3, 3);
            this.panelRibbon.Name = "panelRibbon";
            this.panelRibbon.Size = new System.Drawing.Size(1002, 34);
            this.panelRibbon.TabIndex = 2;
            // 
            // btnCreatePaySheets
            // 
            this.btnCreatePaySheets.Location = new System.Drawing.Point(804, 3);
            this.btnCreatePaySheets.Name = "btnCreatePaySheets";
            this.btnCreatePaySheets.Size = new System.Drawing.Size(188, 28);
            this.btnCreatePaySheets.TabIndex = 88;
            this.btnCreatePaySheets.Text = "Create PaySheets";
            this.btnCreatePaySheets.UseVisualStyleBackColor = true;
            this.btnCreatePaySheets.Visible = false;
            this.btnCreatePaySheets.Click += new System.EventHandler(this.btnCreatePaySheets_Click);
            // 
            // CheckDoubleBookingsTimer1
            // 
            this.CheckDoubleBookingsTimer1.Tick += new System.EventHandler(this.CheckDoubleBookingsTimer1_Tick);
            // 
            // flashtimer1
            // 
            this.flashtimer1.Tick += new System.EventHandler(this.flashtimer1_Tick);
            // 
            // frmAvailabilitySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAvailabilitySheet";
            this.Text = "Availability Sheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAvailabilitySheet_FormClosing);
            this.Load += new System.EventHandler(this.frmAvailabilitySheet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpQual.ResumeLayout(false);
            this.grpQual.PerformLayout();
            this.grpYearGroups.ResumeLayout(false);
            this.grpYearGroups.PerformLayout();
            this.panelRibbon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpYearGroups;
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
        private System.Windows.Forms.GroupBox grpQual;
        private System.Windows.Forms.CheckBox chkSEN;
        private System.Windows.Forms.CheckBox chkNN;
        private System.Windows.Forms.CheckBox chkTA;
        private System.Windows.Forms.CheckBox chkQNN;
        private System.Windows.Forms.CheckBox chkOTT;
        private System.Windows.Forms.CheckBox chkNQT;
        private System.Windows.Forms.CheckBox chkQTS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnFwd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnDblBkgs;
        private System.Windows.Forms.Timer CheckDoubleBookingsTimer1;
        private UC.AvailabilityGrid availabilityGrid1;
        private System.Windows.Forms.Timer flashtimer1;
        private System.Windows.Forms.CheckBox chkTeacher;
        private System.Windows.Forms.CheckBox chkGuaranteed;
        private System.Windows.Forms.CheckBox chkLongTerm;
        private System.Windows.Forms.Button btnCreatePaySheets;
        private System.Windows.Forms.CheckBox chkJustBookings;
        private System.Windows.Forms.Panel panelRibbon;
    }
}