namespace RedboxAddin.Presentation
{
    partial class frmSelectAvailable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectAvailable));
            this.chkAM = new System.Windows.Forms.CheckBox();
            this.chkPM = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkAM
            // 
            this.chkAM.AutoSize = true;
            this.chkAM.Checked = true;
            this.chkAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAM.Location = new System.Drawing.Point(15, 37);
            this.chkAM.Name = "chkAM";
            this.chkAM.Size = new System.Drawing.Size(42, 17);
            this.chkAM.TabIndex = 0;
            this.chkAM.Text = "AM";
            this.chkAM.UseVisualStyleBackColor = true;
            // 
            // chkPM
            // 
            this.chkPM.AutoSize = true;
            this.chkPM.Location = new System.Drawing.Point(90, 37);
            this.chkPM.Name = "chkPM";
            this.chkPM.Size = new System.Drawing.Size(42, 17);
            this.chkPM.TabIndex = 1;
            this.chkPM.Text = "PM";
            this.chkPM.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select the available ";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(171, 33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSelectAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 69);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPM);
            this.Controls.Add(this.chkAM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectAvailable";
            this.Text = "Select Available";            
            this.Load += new System.EventHandler(this.frmSelectAvailable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAM;
        private System.Windows.Forms.CheckBox chkPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
    }
}