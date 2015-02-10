namespace RedboxAddin.Presentation
{
    partial class frmEditSchool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSchool));
            this.cmbSchool = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSchoolName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.chkRequirePofA = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMainContact = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.txtDayCharge = new System.Windows.Forms.TextBox();
            this.txtHfDayCharge = new System.Windows.Forms.TextBox();
            this.txtLTDay = new System.Windows.Forms.TextBox();
            this.txtLTHfDay = new System.Windows.Forms.TextBox();
            this.txtVettingEmails = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chkUseFaxForTimeSheets = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSageAccountRef = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAddNotes = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radCalcRate = new System.Windows.Forms.RadioButton();
            this.radSchoolRate = new System.Windows.Forms.RadioButton();
            this.radRateTeacher = new System.Windows.Forms.RadioButton();
            this.txtTALTHfDayRate = new System.Windows.Forms.TextBox();
            this.txtTALTDayRate = new System.Windows.Forms.TextBox();
            this.txtTAHfDayRate = new System.Windows.Forms.TextBox();
            this.txtTADayrate = new System.Windows.Forms.TextBox();
            this.txtLTHfDayRate = new System.Windows.Forms.TextBox();
            this.txtLTDayRate = new System.Windows.Forms.TextBox();
            this.txtHfDayRate = new System.Windows.Forms.TextBox();
            this.txtDayRate = new System.Windows.Forms.TextBox();
            this.chkVettingAM = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTALTHfDay = new System.Windows.Forms.TextBox();
            this.txtTALTDay = new System.Windows.Forms.TextBox();
            this.txtTAHfDayCharge = new System.Windows.Forms.TextBox();
            this.txtTADayCharge = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSchool
            // 
            this.cmbSchool.FormattingEnabled = true;
            this.cmbSchool.Location = new System.Drawing.Point(135, 11);
            this.cmbSchool.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSchool.Name = "cmbSchool";
            this.cmbSchool.Size = new System.Drawing.Size(248, 24);
            this.cmbSchool.TabIndex = 0;
            this.cmbSchool.SelectionChangeCommitted += new System.EventHandler(this.cmbSchool_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "School";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(403, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.AutoSize = true;
            this.lblSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.Location = new System.Drawing.Point(135, 54);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(176, 31);
            this.lblSchoolName.TabIndex = 1;
            this.lblSchoolName.Text = "School Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(135, 112);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(245, 22);
            this.txtShortName.TabIndex = 2;
            // 
            // chkRequirePofA
            // 
            this.chkRequirePofA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRequirePofA.Location = new System.Drawing.Point(402, 54);
            this.chkRequirePofA.Name = "chkRequirePofA";
            this.chkRequirePofA.Size = new System.Drawing.Size(238, 20);
            this.chkRequirePofA.TabIndex = 10;
            this.chkRequirePofA.Text = "Requires Proof of Address?           ";
            this.chkRequirePofA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Main Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Emails \r\n(Timesheet)*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telephone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fax";
            // 
            // txtMainContact
            // 
            this.txtMainContact.Location = new System.Drawing.Point(135, 151);
            this.txtMainContact.Name = "txtMainContact";
            this.txtMainContact.Size = new System.Drawing.Size(245, 22);
            this.txtMainContact.TabIndex = 3;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(135, 306);
            this.txtEmailAddress.Multiline = true;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(609, 56);
            this.txtEmailAddress.TabIndex = 7;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(135, 187);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(245, 22);
            this.txtTel.TabIndex = 4;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(135, 230);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(245, 22);
            this.txtFax.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(393, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Day Charge";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "1/2 Day Chg";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "LT Day";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(393, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "LT 1/2 Day";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(756, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 40);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(563, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 37);
            this.label12.TabIndex = 25;
            this.label12.Text = "Edit School";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(522, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 16);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "lblID";
            this.lblID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(757, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 40);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close without Saving";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(503, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "£";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(503, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 16);
            this.label14.TabIndex = 29;
            this.label14.Text = "£";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(503, 232);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "£";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(503, 272);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "£";
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(135, 61);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(248, 22);
            this.txtSchoolName.TabIndex = 1;
            this.txtSchoolName.Visible = false;
            // 
            // txtDayCharge
            // 
            this.txtDayCharge.Location = new System.Drawing.Point(524, 149);
            this.txtDayCharge.Name = "txtDayCharge";
            this.txtDayCharge.Size = new System.Drawing.Size(50, 22);
            this.txtDayCharge.TabIndex = 11;
            this.txtDayCharge.Text = "120";
            this.txtDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtDayCharge_Validating);
            // 
            // txtHfDayCharge
            // 
            this.txtHfDayCharge.Location = new System.Drawing.Point(524, 186);
            this.txtHfDayCharge.Name = "txtHfDayCharge";
            this.txtHfDayCharge.Size = new System.Drawing.Size(50, 22);
            this.txtHfDayCharge.TabIndex = 12;
            this.txtHfDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtHfDayCharge_Validating);
            // 
            // txtLTDay
            // 
            this.txtLTDay.Location = new System.Drawing.Point(524, 229);
            this.txtLTDay.Name = "txtLTDay";
            this.txtLTDay.Size = new System.Drawing.Size(50, 22);
            this.txtLTDay.TabIndex = 13;
            this.txtLTDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTDay_Validating);
            // 
            // txtLTHfDay
            // 
            this.txtLTHfDay.Location = new System.Drawing.Point(524, 269);
            this.txtLTHfDay.Name = "txtLTHfDay";
            this.txtLTHfDay.Size = new System.Drawing.Size(50, 22);
            this.txtLTHfDay.TabIndex = 14;
            this.txtLTHfDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTHfDay_Validating);
            // 
            // txtVettingEmails
            // 
            this.txtVettingEmails.Location = new System.Drawing.Point(135, 368);
            this.txtVettingEmails.Multiline = true;
            this.txtVettingEmails.Name = "txtVettingEmails";
            this.txtVettingEmails.Size = new System.Drawing.Size(608, 73);
            this.txtVettingEmails.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 371);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 32);
            this.label17.TabIndex = 37;
            this.label17.Text = "Emails \r\n(Vetting)*";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(139, 443);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(787, 18);
            this.label18.TabIndex = 39;
            this.label18.Text = "* separate multiple emails with a semi colon. e.g. admin@school1.com; bursar@scho" +
    "ol1.com";
            // 
            // chkUseFaxForTimeSheets
            // 
            this.chkUseFaxForTimeSheets.AutoSize = true;
            this.chkUseFaxForTimeSheets.Location = new System.Drawing.Point(135, 259);
            this.chkUseFaxForTimeSheets.Name = "chkUseFaxForTimeSheets";
            this.chkUseFaxForTimeSheets.Size = new System.Drawing.Size(174, 20);
            this.chkUseFaxForTimeSheets.TabIndex = 6;
            this.chkUseFaxForTimeSheets.Text = "Use Fax for Time Sheets";
            this.chkUseFaxForTimeSheets.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(756, 148);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAddress.Size = new System.Drawing.Size(230, 94);
            this.txtAddress.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(757, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(234, 55);
            this.label19.TabIndex = 42;
            this.label19.Text = "Address (Only first 5 lines show on Sage)";
            // 
            // txtSageAccountRef
            // 
            this.txtSageAccountRef.Location = new System.Drawing.Point(757, 269);
            this.txtSageAccountRef.Name = "txtSageAccountRef";
            this.txtSageAccountRef.Size = new System.Drawing.Size(230, 22);
            this.txtSageAccountRef.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(754, 250);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 16);
            this.label20.TabIndex = 43;
            this.label20.Text = "Sage Acct Ref";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 655);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 503);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNotes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtNotes);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 149);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 16);
            this.label21.TabIndex = 54;
            this.label21.Text = "Notes:";
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotes.Location = new System.Drawing.Point(15, 40);
            this.btnAddNotes.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Size = new System.Drawing.Size(73, 48);
            this.btnAddNotes.TabIndex = 53;
            this.btnAddNotes.Text = "Add Notes";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(0, 0);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(864, 149);
            this.txtNotes.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radCalcRate);
            this.panel1.Controls.Add(this.radSchoolRate);
            this.panel1.Controls.Add(this.radRateTeacher);
            this.panel1.Controls.Add(this.txtTALTHfDayRate);
            this.panel1.Controls.Add(this.txtTALTDayRate);
            this.panel1.Controls.Add(this.txtTAHfDayRate);
            this.panel1.Controls.Add(this.txtTADayrate);
            this.panel1.Controls.Add(this.txtLTHfDayRate);
            this.panel1.Controls.Add(this.txtLTDayRate);
            this.panel1.Controls.Add(this.txtHfDayRate);
            this.panel1.Controls.Add(this.txtDayRate);
            this.panel1.Controls.Add(this.chkVettingAM);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtTALTHfDay);
            this.panel1.Controls.Add(this.txtTALTDay);
            this.panel1.Controls.Add(this.txtTAHfDayCharge);
            this.panel1.Controls.Add(this.txtTADayCharge);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtVettingEmails);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtSageAccountRef);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtEmailAddress);
            this.panel1.Controls.Add(this.chkUseFaxForTimeSheets);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSchoolName);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.cmbSchool);
            this.panel1.Controls.Add(this.txtLTHfDay);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtLTDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblSchoolName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtHfDayCharge);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.txtShortName);
            this.panel1.Controls.Add(this.txtDayCharge);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkRequirePofA);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtMainContact);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 494);
            this.panel1.TabIndex = 1;
            // 
            // radCalcRate
            // 
            this.radCalcRate.AutoSize = true;
            this.radCalcRate.Location = new System.Drawing.Point(403, 106);
            this.radCalcRate.Name = "radCalcRate";
            this.radCalcRate.Size = new System.Drawing.Size(190, 20);
            this.radCalcRate.TabIndex = 64;
            this.radCalcRate.Text = "Calculate Rate from Charge";
            this.radCalcRate.UseVisualStyleBackColor = true;
            // 
            // radSchoolRate
            // 
            this.radSchoolRate.AutoSize = true;
            this.radSchoolRate.Location = new System.Drawing.Point(580, 80);
            this.radSchoolRate.Name = "radSchoolRate";
            this.radSchoolRate.Size = new System.Drawing.Size(128, 20);
            this.radSchoolRate.TabIndex = 63;
            this.radSchoolRate.Text = "Use School Rate";
            this.radSchoolRate.UseVisualStyleBackColor = true;
            this.radSchoolRate.CheckedChanged += new System.EventHandler(this.radSchoolRate_CheckedChanged);
            // 
            // radRateTeacher
            // 
            this.radRateTeacher.AutoSize = true;
            this.radRateTeacher.Checked = true;
            this.radRateTeacher.Location = new System.Drawing.Point(403, 80);
            this.radRateTeacher.Name = "radRateTeacher";
            this.radRateTeacher.Size = new System.Drawing.Size(137, 20);
            this.radRateTeacher.TabIndex = 62;
            this.radRateTeacher.TabStop = true;
            this.radRateTeacher.Text = "Use Teacher Rate";
            this.radRateTeacher.UseVisualStyleBackColor = true;
            // 
            // txtTALTHfDayRate
            // 
            this.txtTALTHfDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTALTHfDayRate.Location = new System.Drawing.Point(694, 268);
            this.txtTALTHfDayRate.Name = "txtTALTHfDayRate";
            this.txtTALTHfDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtTALTHfDayRate.TabIndex = 61;
            // 
            // txtTALTDayRate
            // 
            this.txtTALTDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTALTDayRate.Location = new System.Drawing.Point(694, 228);
            this.txtTALTDayRate.Name = "txtTALTDayRate";
            this.txtTALTDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtTALTDayRate.TabIndex = 60;
            // 
            // txtTAHfDayRate
            // 
            this.txtTAHfDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTAHfDayRate.Location = new System.Drawing.Point(694, 185);
            this.txtTAHfDayRate.Name = "txtTAHfDayRate";
            this.txtTAHfDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtTAHfDayRate.TabIndex = 59;
            // 
            // txtTADayrate
            // 
            this.txtTADayrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTADayrate.Location = new System.Drawing.Point(694, 148);
            this.txtTADayrate.Name = "txtTADayrate";
            this.txtTADayrate.Size = new System.Drawing.Size(50, 22);
            this.txtTADayrate.TabIndex = 58;
            this.txtTADayrate.Text = "120";
            // 
            // txtLTHfDayRate
            // 
            this.txtLTHfDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtLTHfDayRate.Location = new System.Drawing.Point(580, 269);
            this.txtLTHfDayRate.Name = "txtLTHfDayRate";
            this.txtLTHfDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtLTHfDayRate.TabIndex = 57;
            // 
            // txtLTDayRate
            // 
            this.txtLTDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtLTDayRate.Location = new System.Drawing.Point(580, 229);
            this.txtLTDayRate.Name = "txtLTDayRate";
            this.txtLTDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtLTDayRate.TabIndex = 56;
            // 
            // txtHfDayRate
            // 
            this.txtHfDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtHfDayRate.Location = new System.Drawing.Point(580, 186);
            this.txtHfDayRate.Name = "txtHfDayRate";
            this.txtHfDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtHfDayRate.TabIndex = 55;
            // 
            // txtDayRate
            // 
            this.txtDayRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDayRate.Location = new System.Drawing.Point(580, 149);
            this.txtDayRate.Name = "txtDayRate";
            this.txtDayRate.Size = new System.Drawing.Size(50, 22);
            this.txtDayRate.TabIndex = 54;
            this.txtDayRate.Text = "120";
            // 
            // chkVettingAM
            // 
            this.chkVettingAM.AutoSize = true;
            this.chkVettingAM.Location = new System.Drawing.Point(14, 464);
            this.chkVettingAM.Name = "chkVettingAM";
            this.chkVettingAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVettingAM.Size = new System.Drawing.Size(136, 20);
            this.chkVettingAM.TabIndex = 51;
            this.chkVettingAM.Text = "               Vetting AM";
            this.chkVettingAM.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(929, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 27);
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(635, 127);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 16);
            this.label23.TabIndex = 49;
            this.label23.Text = "TA";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(521, 127);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 16);
            this.label22.TabIndex = 48;
            this.label22.Text = "Teacher";
            // 
            // txtTALTHfDay
            // 
            this.txtTALTHfDay.Location = new System.Drawing.Point(638, 269);
            this.txtTALTHfDay.Name = "txtTALTHfDay";
            this.txtTALTHfDay.Size = new System.Drawing.Size(50, 22);
            this.txtTALTHfDay.TabIndex = 18;
            // 
            // txtTALTDay
            // 
            this.txtTALTDay.Location = new System.Drawing.Point(638, 229);
            this.txtTALTDay.Name = "txtTALTDay";
            this.txtTALTDay.Size = new System.Drawing.Size(50, 22);
            this.txtTALTDay.TabIndex = 17;
            // 
            // txtTAHfDayCharge
            // 
            this.txtTAHfDayCharge.Location = new System.Drawing.Point(638, 186);
            this.txtTAHfDayCharge.Name = "txtTAHfDayCharge";
            this.txtTAHfDayCharge.Size = new System.Drawing.Size(50, 22);
            this.txtTAHfDayCharge.TabIndex = 16;
            // 
            // txtTADayCharge
            // 
            this.txtTADayCharge.Location = new System.Drawing.Point(638, 149);
            this.txtTADayCharge.Name = "txtTADayCharge";
            this.txtTADayCharge.Size = new System.Drawing.Size(50, 22);
            this.txtTADayCharge.TabIndex = 15;
            // 
            // frmEditSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 655);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditSchool";
            this.Text = "Edit School";
            this.Load += new System.EventHandler(this.frmEditSchool_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSchool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSchoolName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.CheckBox chkRequirePofA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMainContact;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.TextBox txtDayCharge;
        private System.Windows.Forms.TextBox txtHfDayCharge;
        private System.Windows.Forms.TextBox txtLTDay;
        private System.Windows.Forms.TextBox txtLTHfDay;
        private System.Windows.Forms.TextBox txtVettingEmails;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkUseFaxForTimeSheets;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSageAccountRef;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnAddNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtTALTHfDay;
        private System.Windows.Forms.TextBox txtTALTDay;
        private System.Windows.Forms.TextBox txtTAHfDayCharge;
        private System.Windows.Forms.TextBox txtTADayCharge;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkVettingAM;
        private System.Windows.Forms.TextBox txtTALTHfDayRate;
        private System.Windows.Forms.TextBox txtTALTDayRate;
        private System.Windows.Forms.TextBox txtTAHfDayRate;
        private System.Windows.Forms.TextBox txtTADayrate;
        private System.Windows.Forms.TextBox txtLTHfDayRate;
        private System.Windows.Forms.TextBox txtLTDayRate;
        private System.Windows.Forms.TextBox txtHfDayRate;
        private System.Windows.Forms.TextBox txtDayRate;
        private System.Windows.Forms.RadioButton radCalcRate;
        private System.Windows.Forms.RadioButton radSchoolRate;
        private System.Windows.Forms.RadioButton radRateTeacher;
    }
}