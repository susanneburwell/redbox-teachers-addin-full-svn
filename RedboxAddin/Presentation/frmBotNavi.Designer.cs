namespace RedboxAddin.Presentation
{
    partial class frmBotNavi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
  
  
        /// <summary>
        /// Clean uppreparation[n++] = " any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
  
        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(48, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(103, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Redbox Contacts";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RedboxAddin.Properties.Resources._1354796819_contact;
            this.pictureBox1.Location = new System.Drawing.Point(10, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 25);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmBotNavi
            // 
            this.ClientSize = new System.Drawing.Size(186, 31);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBotNavi";
            this.Text = "Redbox";
            this.Load += new System.EventHandler(this.frmBotNavi_Load);
            this.Click += new System.EventHandler(this.frmBotNavi_Click);
            this.MouseEnter += new System.EventHandler(this.frmBotNavi_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.frmBotNavi_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
