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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSchool
            // 
            this.cmbSchool.FormattingEnabled = true;
            this.cmbSchool.Location = new System.Drawing.Point(146, 23);
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
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "School";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(415, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.AutoSize = true;
            this.lblSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.Location = new System.Drawing.Point(140, 65);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(176, 31);
            this.lblSchoolName.TabIndex = 4;
            this.lblSchoolName.Text = "School Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(146, 109);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(245, 22);
            this.txtShortName.TabIndex = 6;
            // 
            // chkRequirePofA
            // 
            this.chkRequirePofA.AutoSize = true;
            this.chkRequirePofA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRequirePofA.Location = new System.Drawing.Point(444, 111);
            this.chkRequirePofA.Name = "chkRequirePofA";
            this.chkRequirePofA.Size = new System.Drawing.Size(225, 20);
            this.chkRequirePofA.TabIndex = 7;
            this.chkRequirePofA.Text = "Requires Proof of Address?           ";
            this.chkRequirePofA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Main Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email (Timesheet)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telephone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fax";
            // 
            // txtMainContact
            // 
            this.txtMainContact.Location = new System.Drawing.Point(146, 146);
            this.txtMainContact.Name = "txtMainContact";
            this.txtMainContact.Size = new System.Drawing.Size(245, 22);
            this.txtMainContact.TabIndex = 12;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(146, 258);
            this.txtEmailAddress.Multiline = true;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailAddress.Size = new System.Drawing.Size(245, 41);
            this.txtEmailAddress.TabIndex = 13;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(146, 182);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(245, 22);
            this.txtTel.TabIndex = 14;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(146, 219);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(245, 22);
            this.txtFax.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Day Charge";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "1/2 Day Charge";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(444, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Long Term Day Charge";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(444, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Long Term 1/2 Day Charge";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 27);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(575, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 37);
            this.label12.TabIndex = 25;
            this.label12.Text = "Edit School";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(579, 58);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 16);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "lblID";
            this.lblID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(582, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(172, 27);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close without Saving";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(633, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "£";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(633, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 16);
            this.label14.TabIndex = 29;
            this.label14.Text = "£";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(633, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "£";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(633, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "£";
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(146, 73);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(248, 22);
            this.txtSchoolName.TabIndex = 32;
            this.txtSchoolName.Visible = false;
            // 
            // txtDayCharge
            // 
            this.txtDayCharge.Location = new System.Drawing.Point(654, 146);
            this.txtDayCharge.Name = "txtDayCharge";
            this.txtDayCharge.Size = new System.Drawing.Size(100, 22);
            this.txtDayCharge.TabIndex = 33;
            this.txtDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtDayCharge_Validating);
            // 
            // txtHfDayCharge
            // 
            this.txtHfDayCharge.Location = new System.Drawing.Point(654, 183);
            this.txtHfDayCharge.Name = "txtHfDayCharge";
            this.txtHfDayCharge.Size = new System.Drawing.Size(100, 22);
            this.txtHfDayCharge.TabIndex = 34;
            this.txtHfDayCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtHfDayCharge_Validating);
            // 
            // txtLTDay
            // 
            this.txtLTDay.Location = new System.Drawing.Point(654, 220);
            this.txtLTDay.Name = "txtLTDay";
            this.txtLTDay.Size = new System.Drawing.Size(100, 22);
            this.txtLTDay.TabIndex = 35;
            this.txtLTDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTDay_Validating);
            // 
            // txtLTHfDay
            // 
            this.txtLTHfDay.Location = new System.Drawing.Point(654, 260);
            this.txtLTHfDay.Name = "txtLTHfDay";
            this.txtLTHfDay.Size = new System.Drawing.Size(100, 22);
            this.txtLTHfDay.TabIndex = 36;
            this.txtLTHfDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtLTHfDay_Validating);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 305);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(245, 159);
            this.textBox1.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 311);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 16);
            this.label17.TabIndex = 37;
            this.label17.Text = "Email (Vetting)";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(153, 467);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(283, 41);
            this.label18.TabIndex = 39;
            this.label18.Text = "* separate multiple emails with a semi colon, e.g. \r\nadmin@school1.com; bursar@sc" +
    "hool1.com";
            // 
            // frmEditSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 511);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtLTHfDay);
            this.Controls.Add(this.txtLTDay);
            this.Controls.Add(this.txtHfDayCharge);
            this.Controls.Add(this.txtDayCharge);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.txtMainContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkRequirePofA);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSchoolName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSchool);
            this.Controls.Add(this.txtSchoolName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditSchool";
            this.Text = "Edit School";
            this.Load += new System.EventHandler(this.frmEditSchool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}