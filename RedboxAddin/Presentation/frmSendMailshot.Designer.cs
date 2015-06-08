namespace RedboxAddin.Presentation
{
    partial class frmSendMailshot
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
            this.grdCurrntUsers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkTeachers = new System.Windows.Forms.CheckBox();
            this.chkSchool = new System.Windows.Forms.CheckBox();
            this.btnSendNow = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblSending = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTestEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrntUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCurrntUsers
            // 
            this.grdCurrntUsers.AllowUserToAddRows = false;
            this.grdCurrntUsers.BackgroundColor = System.Drawing.Color.White;
            this.grdCurrntUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCurrntUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCurrntUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.grdCurrntUsers.Location = new System.Drawing.Point(2, 111);
            this.grdCurrntUsers.Name = "grdCurrntUsers";
            this.grdCurrntUsers.Size = new System.Drawing.Size(542, 541);
            this.grdCurrntUsers.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // chkTeachers
            // 
            this.chkTeachers.AutoSize = true;
            this.chkTeachers.Checked = true;
            this.chkTeachers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTeachers.Location = new System.Drawing.Point(12, 28);
            this.chkTeachers.Name = "chkTeachers";
            this.chkTeachers.Size = new System.Drawing.Size(71, 17);
            this.chkTeachers.TabIndex = 1;
            this.chkTeachers.Text = "Teachers";
            this.chkTeachers.UseVisualStyleBackColor = true;
            this.chkTeachers.CheckedChanged += new System.EventHandler(this.chkTeachers_CheckedChanged);
            // 
            // chkSchool
            // 
            this.chkSchool.AutoSize = true;
            this.chkSchool.Location = new System.Drawing.Point(12, 60);
            this.chkSchool.Name = "chkSchool";
            this.chkSchool.Size = new System.Drawing.Size(64, 17);
            this.chkSchool.TabIndex = 2;
            this.chkSchool.Text = "Schools";
            this.chkSchool.UseVisualStyleBackColor = true;
            this.chkSchool.CheckedChanged += new System.EventHandler(this.chkSchool_CheckedChanged);
            // 
            // btnSendNow
            // 
            this.btnSendNow.Location = new System.Drawing.Point(346, 56);
            this.btnSendNow.Name = "btnSendNow";
            this.btnSendNow.Size = new System.Drawing.Size(75, 23);
            this.btnSendNow.TabIndex = 3;
            this.btnSendNow.Text = "Send Now";
            this.btnSendNow.UseVisualStyleBackColor = true;
            this.btnSendNow.Click += new System.EventHandler(this.btnSendNow_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(427, 56);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblSending
            // 
            this.lblSending.AutoSize = true;
            this.lblSending.Location = new System.Drawing.Point(156, 29);
            this.lblSending.Name = "lblSending";
            this.lblSending.Size = new System.Drawing.Size(0, 13);
            this.lblSending.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(427, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Change";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTestEmail
            // 
            this.lblTestEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestEmail.Location = new System.Drawing.Point(12, 88);
            this.lblTestEmail.Name = "lblTestEmail";
            this.lblTestEmail.Size = new System.Drawing.Size(409, 18);
            this.lblTestEmail.TabIndex = 8;
            this.lblTestEmail.Text = "Test E-Mail";
            this.lblTestEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmSendMailshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 656);
            this.Controls.Add(this.lblTestEmail);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSending);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSendNow);
            this.Controls.Add(this.chkSchool);
            this.Controls.Add(this.chkTeachers);
            this.Controls.Add(this.grdCurrntUsers);
            this.Name = "frmSendMailshot";
            this.Text = "Send Mailshot";
            this.Load += new System.EventHandler(this.frmSendMailshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrntUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCurrntUsers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.CheckBox chkTeachers;
        private System.Windows.Forms.CheckBox chkSchool;
        private System.Windows.Forms.Button btnSendNow;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblSending;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTestEmail;

    }
}