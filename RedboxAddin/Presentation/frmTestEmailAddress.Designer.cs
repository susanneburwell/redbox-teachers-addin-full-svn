namespace RedboxAddin.Presentation
{
    partial class frmTestEmailAddress
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
            this.lblTestEmail = new System.Windows.Forms.Label();
            this.txtTestEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblInvalidMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTestEmail
            // 
            this.lblTestEmail.AutoSize = true;
            this.lblTestEmail.Location = new System.Drawing.Point(12, 26);
            this.lblTestEmail.Name = "lblTestEmail";
            this.lblTestEmail.Size = new System.Drawing.Size(60, 13);
            this.lblTestEmail.TabIndex = 0;
            this.lblTestEmail.Text = "Test E-Mail";
            // 
            // txtTestEmail
            // 
            this.txtTestEmail.Location = new System.Drawing.Point(78, 23);
            this.txtTestEmail.Name = "txtTestEmail";
            this.txtTestEmail.Size = new System.Drawing.Size(316, 20);
            this.txtTestEmail.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(319, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblInvalidMsg
            // 
            this.lblInvalidMsg.AutoSize = true;
            this.lblInvalidMsg.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidMsg.Location = new System.Drawing.Point(75, 56);
            this.lblInvalidMsg.Name = "lblInvalidMsg";
            this.lblInvalidMsg.Size = new System.Drawing.Size(0, 13);
            this.lblInvalidMsg.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTestEmailAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 84);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInvalidMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTestEmail);
            this.Controls.Add(this.lblTestEmail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestEmailAddress";
            this.Text = "Test Email";
            this.Load += new System.EventHandler(this.frmTestEmailAddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestEmail;
        private System.Windows.Forms.TextBox txtTestEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInvalidMsg;
        private System.Windows.Forms.Button btnCancel;
    }
}