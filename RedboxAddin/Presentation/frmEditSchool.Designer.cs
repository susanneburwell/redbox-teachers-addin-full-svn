﻿namespace RedboxAddin.Presentation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNotes = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
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
            this.cmbSchool.Size = new System.Drawing.Size(248, 28);
            this.cmbSchool.TabIndex = 0;
            this.cmbSchool.SelectionChangeCommitted += new System.EventHandler(this.cmbSchool_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
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
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.AutoSize = true;
            this.lblSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.Location = new System.Drawing.Point(135, 54);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(222, 39);
            this.lblSchoolName.TabIndex = 4;
            this.lblSchoolName.Text = "School Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(135, 112);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(245, 26);
            this.txtShortName.TabIndex = 6;
            // 
            // chkRequirePofA
            // 
            this.chkRequirePofA.AutoSize = true;
            this.chkRequirePofA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRequirePofA.Location = new System.Drawing.Point(403, 114);
            this.chkRequirePofA.Name = "chkRequirePofA";
            this.chkRequirePofA.Size = new System.Drawing.Size(293, 24);
            this.chkRequirePofA.TabIndex = 7;
            this.chkRequirePofA.Text = "Requires Proof of Address?           ";
            this.chkRequirePofA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Main Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "Emails \r\n(Timesheet)*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telephone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fax";
            // 
            // txtMainContact
            // 
            this.txtMainContact.Location = new System.Drawing.Point(135, 151);
            this.txtMainContact.Name = "txtMainContact";
            this.txtMainContact.Size = new System.Drawing.Size(245, 26);
            this.txtMainContact.TabIndex = 12;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(135, 306);
            this.txtEmailAddress.Multiline = true;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(605, 56);
            this.txtEmailAddress.TabIndex = 13;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(135, 187);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(245, 26);
            this.txtTel.TabIndex = 14;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(135, 230);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(245, 26);
            this.txtFax.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Day Charge";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(403, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "1/2 Day Charge";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Long Term Day Charge";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(403, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Long Term 1/2 Day Charge";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(757, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 40);
            this.btnSave.TabIndex = 24;
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
            this.label12.Size = new System.Drawing.Size(225, 46);
            this.label12.TabIndex = 25;
            this.label12.Text = "Edit School";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(572, 57);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(43, 20);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "lblID";
            this.lblID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(757, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(214, 40);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close without Saving";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(612, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "£";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(612, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "£";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(612, 232);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "£";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(612, 272);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "£";
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(135, 61);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(248, 26);
            this.txtSchoolName.TabIndex = 32;
            this.txtSchoolName.Visible = false;
            // 
            // txtDayCharge
            // 
            this.txtDayCharge.Location = new System.Drawing.Point(633, 149);
            this.txtDayCharge.Name = "txtDayCharge";
            this.txtDayCharge.Size = new System.Drawing.Size(100, 26);
            this.txtDayCharge.TabIndex = 33;
            this.txtDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtDayCharge_Validating);
            // 
            // txtHfDayCharge
            // 
            this.txtHfDayCharge.Location = new System.Drawing.Point(633, 186);
            this.txtHfDayCharge.Name = "txtHfDayCharge";
            this.txtHfDayCharge.Size = new System.Drawing.Size(100, 26);
            this.txtHfDayCharge.TabIndex = 34;
            this.txtHfDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtHfDayCharge_Validating);
            // 
            // txtLTDay
            // 
            this.txtLTDay.Location = new System.Drawing.Point(633, 229);
            this.txtLTDay.Name = "txtLTDay";
            this.txtLTDay.Size = new System.Drawing.Size(100, 26);
            this.txtLTDay.TabIndex = 35;
            this.txtLTDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTDay_Validating);
            // 
            // txtLTHfDay
            // 
            this.txtLTHfDay.Location = new System.Drawing.Point(633, 269);
            this.txtLTHfDay.Name = "txtLTHfDay";
            this.txtLTHfDay.Size = new System.Drawing.Size(100, 26);
            this.txtLTHfDay.TabIndex = 36;
            this.txtLTHfDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTHfDay_Validating);
            // 
            // txtVettingEmails
            // 
            this.txtVettingEmails.Location = new System.Drawing.Point(135, 368);
            this.txtVettingEmails.Multiline = true;
            this.txtVettingEmails.Name = "txtVettingEmails";
            this.txtVettingEmails.Size = new System.Drawing.Size(608, 73);
            this.txtVettingEmails.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 371);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 40);
            this.label17.TabIndex = 37;
            this.label17.Text = "Emails \r\n(Vetting)*";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(139, 449);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(787, 26);
            this.label18.TabIndex = 39;
            this.label18.Text = "* separate multiple emails with a semi colon. e.g. admin@school1.com; bursar@scho" +
    "ol1.com";
            // 
            // chkUseFaxForTimeSheets
            // 
            this.chkUseFaxForTimeSheets.AutoSize = true;
            this.chkUseFaxForTimeSheets.Location = new System.Drawing.Point(135, 259);
            this.chkUseFaxForTimeSheets.Name = "chkUseFaxForTimeSheets";
            this.chkUseFaxForTimeSheets.Size = new System.Drawing.Size(217, 24);
            this.chkUseFaxForTimeSheets.TabIndex = 40;
            this.chkUseFaxForTimeSheets.Text = "Use Fax for Time Sheets";
            this.chkUseFaxForTimeSheets.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(757, 130);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAddress.Size = new System.Drawing.Size(230, 94);
            this.txtAddress.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(753, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(234, 55);
            this.label19.TabIndex = 42;
            this.label19.Text = "Address (Only first 5 lines show on Sage)";
            // 
            // txtSageAccountRef
            // 
            this.txtSageAccountRef.Location = new System.Drawing.Point(757, 269);
            this.txtSageAccountRef.Name = "txtSageAccountRef";
            this.txtSageAccountRef.Size = new System.Drawing.Size(230, 26);
            this.txtSageAccountRef.TabIndex = 44;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(757, 250);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 20);
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
            // panel1
            // 
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 20);
            this.label21.TabIndex = 54;
            this.label21.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(0, 0);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(864, 149);
            this.txtNotes.TabIndex = 39;
            // 
            // frmEditSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
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
    }
}