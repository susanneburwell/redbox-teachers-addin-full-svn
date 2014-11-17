namespace RedboxAddin.Presentation
{
    partial class frmBookingOverTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookingOverTime));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblCharge = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRateValue = new System.Windows.Forms.Label();
            this.lblChargeValue = new System.Windows.Forms.Label();
            this.chkHalfDay = new System.Windows.Forms.CheckBox();
            this.radOT = new System.Windows.Forms.RadioButton();
            this.radSick = new System.Windows.Forms.RadioButton();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 27);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(22, 67);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(106, 16);
            this.lblRate.TabIndex = 117;
            this.lblRate.Text = "Additional Rate :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(173, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 16);
            this.label14.TabIndex = 118;
            this.label14.Text = "£";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(194, 64);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(63, 22);
            this.txtRate.TabIndex = 116;
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Location = new System.Drawing.Point(22, 96);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(121, 16);
            this.lblCharge.TabIndex = 114;
            this.lblCharge.Text = "Additional Charge :";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(173, 96);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(15, 16);
            this.label76.TabIndex = 115;
            this.label76.Text = "£";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(195, 93);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(63, 22);
            this.txtCharge.TabIndex = 113;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(327, 64);
            this.txtHours.MaxLength = 2;
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(34, 22);
            this.txtHours.TabIndex = 119;
            this.txtHours.TextChanged += new System.EventHandler(this.txtHours_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 114;
            this.label1.Text = "HH :";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(22, 227);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(432, 103);
            this.txtNotes.TabIndex = 121;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 122;
            this.label6.Text = "Notes :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 27);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(202, 337);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 27);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(420, 64);
            this.txtMinutes.MaxLength = 2;
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(34, 22);
            this.txtMinutes.TabIndex = 119;
            this.txtMinutes.TextChanged += new System.EventHandler(this.txtMinutes_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 114;
            this.label3.Text = "MM :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 127;
            this.label4.Text = "Booking Rate :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 128;
            this.label5.Text = "£";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 124;
            this.label7.Text = "Booking Charge :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 125;
            this.label8.Text = "£";
            // 
            // lblRateValue
            // 
            this.lblRateValue.AutoSize = true;
            this.lblRateValue.Location = new System.Drawing.Point(199, 9);
            this.lblRateValue.Name = "lblRateValue";
            this.lblRateValue.Size = new System.Drawing.Size(32, 16);
            this.lblRateValue.TabIndex = 129;
            this.lblRateValue.Text = "0.00";
            // 
            // lblChargeValue
            // 
            this.lblChargeValue.AutoSize = true;
            this.lblChargeValue.Location = new System.Drawing.Point(199, 38);
            this.lblChargeValue.Name = "lblChargeValue";
            this.lblChargeValue.Size = new System.Drawing.Size(32, 16);
            this.lblChargeValue.TabIndex = 130;
            this.lblChargeValue.Text = "0.00";
            // 
            // chkHalfDay
            // 
            this.chkHalfDay.Location = new System.Drawing.Point(295, 9);
            this.chkHalfDay.Name = "chkHalfDay";
            this.chkHalfDay.Size = new System.Drawing.Size(159, 42);
            this.chkHalfDay.TabIndex = 131;
            this.chkHalfDay.Text = "Rates are Half Day rates";
            this.chkHalfDay.UseVisualStyleBackColor = true;
            this.chkHalfDay.CheckedChanged += new System.EventHandler(this.chkHalfDay_CheckedChanged);
            // 
            // radOT
            // 
            this.radOT.AutoSize = true;
            this.radOT.Checked = true;
            this.radOT.Location = new System.Drawing.Point(25, 152);
            this.radOT.Name = "radOT";
            this.radOT.Size = new System.Drawing.Size(305, 20);
            this.radOT.TabIndex = 132;
            this.radOT.TabStop = true;
            this.radOT.Text = "Overtime (Generate additional line in load plan)";
            this.radOT.UseVisualStyleBackColor = true;
            this.radOT.CheckedChanged += new System.EventHandler(this.radOTSick_CheckedChanged);
            // 
            // radSick
            // 
            this.radSick.AutoSize = true;
            this.radSick.Location = new System.Drawing.Point(25, 177);
            this.radSick.Name = "radSick";
            this.radSick.Size = new System.Drawing.Size(362, 20);
            this.radSick.TabIndex = 133;
            this.radSick.Text = "Sick/Appointments (Reduce rate and Charge in Booking)";
            this.radSick.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(25, 128);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(201, 18);
            this.lblInfo.TabIndex = 134;
            this.lblInfo.Text = "Add New Line in Loadplan";
            // 
            // frmBookingOverTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 373);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.radSick);
            this.Controls.Add(this.radOT);
            this.Controls.Add(this.chkHalfDay);
            this.Controls.Add(this.lblChargeValue);
            this.Controls.Add(this.lblRateValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBookingOverTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Booking overtime";
            this.Load += new System.EventHandler(this.frmBookingOverTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRateValue;
        private System.Windows.Forms.Label lblChargeValue;
        private System.Windows.Forms.CheckBox chkHalfDay;
        private System.Windows.Forms.RadioButton radOT;
        private System.Windows.Forms.RadioButton radSick;
        private System.Windows.Forms.Label lblInfo;
    }
}