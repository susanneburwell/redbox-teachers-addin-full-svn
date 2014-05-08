namespace RedboxAddin
{
    partial class frmUpdateBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateBookings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDelete = new System.Windows.Forms.RadioButton();
            this.radUpdate = new System.Windows.Forms.RadioButton();
            this.lblAction = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSet = new System.Windows.Forms.GroupBox();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.chkRate = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkCharge = new System.Windows.Forms.CheckBox();
            this.label76 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDelete);
            this.groupBox1.Controls.Add(this.radUpdate);
            this.groupBox1.Location = new System.Drawing.Point(31, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select:";
            // 
            // radDelete
            // 
            this.radDelete.AutoSize = true;
            this.radDelete.Location = new System.Drawing.Point(24, 47);
            this.radDelete.Name = "radDelete";
            this.radDelete.Size = new System.Drawing.Size(126, 20);
            this.radDelete.TabIndex = 1;
            this.radDelete.Text = "Delete Bookings";
            this.radDelete.UseVisualStyleBackColor = true;
            // 
            // radUpdate
            // 
            this.radUpdate.AutoSize = true;
            this.radUpdate.Checked = true;
            this.radUpdate.Location = new System.Drawing.Point(24, 21);
            this.radUpdate.Name = "radUpdate";
            this.radUpdate.Size = new System.Drawing.Size(131, 20);
            this.radUpdate.TabIndex = 0;
            this.radUpdate.TabStop = true;
            this.radUpdate.Text = "Update Bookings";
            this.radUpdate.UseVisualStyleBackColor = true;
            this.radUpdate.CheckedChanged += new System.EventHandler(this.radUpdate_CheckedChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(31, 14);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(147, 20);
            this.lblAction.TabIndex = 1;
            this.lblAction.Text = "Update Bookings";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(270, 124);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(31, 44);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(103, 20);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From Today";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Set date to the first date you want to change";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Charge:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Description:";
            // 
            // grpSet
            // 
            this.grpSet.Controls.Add(this.chkDescription);
            this.grpSet.Controls.Add(this.chkRate);
            this.grpSet.Controls.Add(this.txtDescription);
            this.grpSet.Controls.Add(this.chkCharge);
            this.grpSet.Controls.Add(this.label76);
            this.grpSet.Controls.Add(this.txtCharge);
            this.grpSet.Controls.Add(this.label14);
            this.grpSet.Controls.Add(this.txtRate);
            this.grpSet.Controls.Add(this.label5);
            this.grpSet.Controls.Add(this.label4);
            this.grpSet.Controls.Add(this.label3);
            this.grpSet.Location = new System.Drawing.Point(35, 180);
            this.grpSet.Name = "grpSet";
            this.grpSet.Size = new System.Drawing.Size(519, 149);
            this.grpSet.TabIndex = 9;
            this.grpSet.TabStop = false;
            this.grpSet.Text = "Set:";
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescription.Location = new System.Drawing.Point(235, 80);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(131, 19);
            this.chkDescription.TabIndex = 119;
            this.chkDescription.Text = "Update Description";
            this.chkDescription.UseVisualStyleBackColor = true;
            // 
            // chkRate
            // 
            this.chkRate.AutoSize = true;
            this.chkRate.Checked = true;
            this.chkRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRate.Location = new System.Drawing.Point(236, 48);
            this.chkRate.Name = "chkRate";
            this.chkRate.Size = new System.Drawing.Size(95, 19);
            this.chkRate.TabIndex = 118;
            this.chkRate.Text = "Update Rate";
            this.chkRate.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(126, 105);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(287, 22);
            this.txtDescription.TabIndex = 117;
            // 
            // chkCharge
            // 
            this.chkCharge.AutoSize = true;
            this.chkCharge.Checked = true;
            this.chkCharge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCharge.Location = new System.Drawing.Point(236, 17);
            this.chkCharge.Name = "chkCharge";
            this.chkCharge.Size = new System.Drawing.Size(109, 19);
            this.chkCharge.TabIndex = 117;
            this.chkCharge.Text = "Update Charge";
            this.chkCharge.UseVisualStyleBackColor = true;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(104, 18);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(15, 16);
            this.label76.TabIndex = 116;
            this.label76.Text = "£";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(126, 15);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(63, 22);
            this.txtCharge.TabIndex = 115;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(107, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 16);
            this.label14.TabIndex = 114;
            this.label14.Text = "£";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(126, 46);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(63, 22);
            this.txtRate.TabIndex = 113;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(441, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(113, 27);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmUpdateBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 353);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpdateBookings";
            this.Text = "Update Bookings";
            this.Load += new System.EventHandler(this.frmUpdateBookings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSet.ResumeLayout(false);
            this.grpSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDelete;
        private System.Windows.Forms.RadioButton radUpdate;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpSet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.CheckBox chkRate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkCharge;
        private System.Windows.Forms.Button btnUpdate;
    }
}