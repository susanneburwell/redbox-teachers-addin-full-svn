namespace RedboxAddin.Presentation
{
    partial class frmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numFirst = new System.Windows.Forms.NumericUpDown();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.numLast = new System.Windows.Forms.NumericUpDown();
            this.lblL = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.chkTeacher = new System.Windows.Forms.CheckBox();
            this.chkTA = new System.Windows.Forms.CheckBox();
            this.chkCurrent = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select File:";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(145, 34);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(93, 33);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "select";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(260, 37);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(105, 20);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "Not Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Row:";
            // 
            // numFirst
            // 
            this.numFirst.Location = new System.Drawing.Point(145, 73);
            this.numFirst.Name = "numFirst";
            this.numFirst.Size = new System.Drawing.Size(93, 26);
            this.numFirst.TabIndex = 4;
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(260, 75);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(105, 20);
            this.lblFirst.TabIndex = 5;
            this.lblFirst.Text = "Not Selected";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(260, 115);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(105, 20);
            this.lblLast.TabIndex = 8;
            this.lblLast.Text = "Not Selected";
            // 
            // numLast
            // 
            this.numLast.Location = new System.Drawing.Point(145, 113);
            this.numLast.Name = "numLast";
            this.numLast.Size = new System.Drawing.Size(93, 26);
            this.numLast.TabIndex = 7;
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(50, 118);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(85, 20);
            this.lblL.TabIndex = 6;
            this.lblL.Text = "Last Row:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(507, 187);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 29);
            this.btnImport.TabIndex = 29;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // chkTeacher
            // 
            this.chkTeacher.AutoSize = true;
            this.chkTeacher.Location = new System.Drawing.Point(65, 175);
            this.chkTeacher.Name = "chkTeacher";
            this.chkTeacher.Size = new System.Drawing.Size(92, 24);
            this.chkTeacher.TabIndex = 30;
            this.chkTeacher.Text = "Teacher";
            this.chkTeacher.UseVisualStyleBackColor = true;
            // 
            // chkTA
            // 
            this.chkTA.AutoSize = true;
            this.chkTA.Location = new System.Drawing.Point(65, 214);
            this.chkTA.Name = "chkTA";
            this.chkTA.Size = new System.Drawing.Size(52, 24);
            this.chkTA.TabIndex = 31;
            this.chkTA.Text = "TA";
            this.chkTA.UseVisualStyleBackColor = true;
            // 
            // chkCurrent
            // 
            this.chkCurrent.AutoSize = true;
            this.chkCurrent.Location = new System.Drawing.Point(65, 256);
            this.chkCurrent.Name = "chkCurrent";
            this.chkCurrent.Size = new System.Drawing.Size(87, 24);
            this.chkCurrent.TabIndex = 32;
            this.chkCurrent.Text = "Current";
            this.chkCurrent.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(263, 145);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 29);
            this.btnCheck.TabIndex = 33;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 540);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.chkCurrent);
            this.Controls.Add(this.chkTA);
            this.Controls.Add(this.chkTeacher);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.numLast);
            this.Controls.Add(this.lblL);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.numFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImport";
            this.Text = "Import";
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numFirst;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.NumericUpDown numLast;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chkTeacher;
        private System.Windows.Forms.CheckBox chkTA;
        private System.Windows.Forms.CheckBox chkCurrent;
        private System.Windows.Forms.Button btnCheck;
    }
}