namespace RedboxAddin.Presentation
{
    partial class frmViewReminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewReminder));
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtCompletedBy = new System.Windows.Forms.TextBox();
            this.lblCompletedBy = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddNotes = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(69, 33);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(368, 21);
            this.txtSubject.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(69, 130);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(368, 103);
            this.txtNotes.TabIndex = 5;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(7, 100);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(43, 13);
            this.label71.TabIndex = 24;
            this.label71.Text = "Due On";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(7, 133);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(35, 13);
            this.label70.TabIndex = 25;
            this.label70.Text = "Notes";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(7, 36);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(43, 13);
            this.label66.TabIndex = 27;
            this.label66.Text = "Subject";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Due",
            "InProgress",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(69, 67);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(141, 21);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Status";
            // 
            // dtDueDate
            // 
            this.dtDueDate.CustomFormat = "dd-MMM-yyyy HH:mm";
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDueDate.Location = new System.Drawing.Point(69, 95);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(169, 22);
            this.dtDueDate.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(19, 264);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 14);
            this.linkLabel1.TabIndex = 44;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View Contact";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtCompletedBy
            // 
            this.txtCompletedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompletedBy.Location = new System.Drawing.Point(299, 67);
            this.txtCompletedBy.Name = "txtCompletedBy";
            this.txtCompletedBy.Size = new System.Drawing.Size(138, 21);
            this.txtCompletedBy.TabIndex = 2;
            // 
            // lblCompletedBy
            // 
            this.lblCompletedBy.AutoSize = true;
            this.lblCompletedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedBy.Location = new System.Drawing.Point(220, 71);
            this.lblCompletedBy.Name = "lblCompletedBy";
            this.lblCompletedBy.Size = new System.Drawing.Size(73, 13);
            this.lblCompletedBy.TabIndex = 46;
            this.lblCompletedBy.Text = "Completed By";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(382, 260);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNotes);
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Controls.Add(this.label66);
            this.groupBox1.Controls.Add(this.label70);
            this.groupBox1.Controls.Add(this.txtCompletedBy);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.lblCompletedBy);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.dtDueDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 245);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminder Info";
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotes.Location = new System.Drawing.Point(6, 155);
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Size = new System.Drawing.Size(42, 35);
            this.btnAddNotes.TabIndex = 4;
            this.btnAddNotes.Text = "Add notes";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(301, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmViewReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 295);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewReminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.frmViewReminder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtCompletedBy;
        private System.Windows.Forms.Label lblCompletedBy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNotes;

    }
}