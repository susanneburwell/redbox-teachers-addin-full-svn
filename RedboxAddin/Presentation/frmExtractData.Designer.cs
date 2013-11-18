namespace RedboxAddin.Presentation
{
    partial class frmExtractData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractData));
            this.button1 = new System.Windows.Forms.Button();
            this.txtFolderID = new System.Windows.Forms.TextBox();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.btnUpdatePictures = new System.Windows.Forms.Button();
            this.btnUpdateRefBy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(503, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Extract";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFolderID
            // 
            this.txtFolderID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderID.Location = new System.Drawing.Point(56, 31);
            this.txtFolderID.Name = "txtFolderID";
            this.txtFolderID.Size = new System.Drawing.Size(367, 21);
            this.txtFolderID.TabIndex = 23;
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Location = new System.Drawing.Point(439, 29);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(58, 23);
            this.btnPickFolder.TabIndex = 24;
            this.btnPickFolder.Text = "Pick";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // btnUpdatePictures
            // 
            this.btnUpdatePictures.Enabled = false;
            this.btnUpdatePictures.Location = new System.Drawing.Point(12, 58);
            this.btnUpdatePictures.Name = "btnUpdatePictures";
            this.btnUpdatePictures.Size = new System.Drawing.Size(101, 23);
            this.btnUpdatePictures.TabIndex = 25;
            this.btnUpdatePictures.Text = "Update Pictures";
            this.btnUpdatePictures.UseVisualStyleBackColor = true;
            this.btnUpdatePictures.Click += new System.EventHandler(this.btnUpdatePictures_Click);
            // 
            // btnUpdateRefBy
            // 
            this.btnUpdateRefBy.Location = new System.Drawing.Point(439, 58);
            this.btnUpdateRefBy.Name = "btnUpdateRefBy";
            this.btnUpdateRefBy.Size = new System.Drawing.Size(122, 23);
            this.btnUpdateRefBy.TabIndex = 26;
            this.btnUpdateRefBy.Text = "Update Ref By";
            this.btnUpdateRefBy.UseVisualStyleBackColor = true;
            this.btnUpdateRefBy.Click += new System.EventHandler(this.btnUpdateRefBy_Click);
            // 
            // frmExtractData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 91);
            this.Controls.Add(this.btnUpdateRefBy);
            this.Controls.Add(this.btnUpdatePictures);
            this.Controls.Add(this.btnPickFolder);
            this.Controls.Add(this.txtFolderID);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtractData";
            this.Text = "Extract Contacts";
            this.Load += new System.EventHandler(this.frmExtractData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFolderID;
        private System.Windows.Forms.Button btnPickFolder;
        private System.Windows.Forms.Button btnUpdatePictures;
        private System.Windows.Forms.Button btnUpdateRefBy;
    }
}