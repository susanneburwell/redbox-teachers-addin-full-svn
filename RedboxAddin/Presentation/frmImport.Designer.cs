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
            this.label3 = new System.Windows.Forms.Label();
            this.numLast = new System.Windows.Forms.NumericUpDown();
            this.lblLast = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblCol1 = new System.Windows.Forms.Label();
            this.lblCol2 = new System.Windows.Forms.Label();
            this.lblCol3 = new System.Windows.Forms.Label();
            this.lblCol4 = new System.Windows.Forms.Label();
            this.lblCol5 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).BeginInit();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select File:";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(136, 34);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
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
            this.lblFile.Size = new System.Drawing.Size(86, 16);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "Not Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Row:";
            // 
            // numFirst
            // 
            this.numFirst.Location = new System.Drawing.Point(136, 73);
            this.numFirst.Name = "numFirst";
            this.numFirst.Size = new System.Drawing.Size(93, 22);
            this.numFirst.TabIndex = 4;
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(260, 75);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(86, 16);
            this.lblFirst.TabIndex = 5;
            this.lblFirst.Text = "Not Selected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Not Selected";
            // 
            // numLast
            // 
            this.numLast.Location = new System.Drawing.Point(136, 113);
            this.numLast.Name = "numLast";
            this.numLast.Size = new System.Drawing.Size(93, 22);
            this.numLast.TabIndex = 7;
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(50, 118);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(66, 16);
            this.lblLast.TabIndex = 6;
            this.lblLast.Text = "Last Row:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 92);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 20);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Col 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(34, 118);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 20);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "Col 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(34, 144);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(57, 20);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "Col 3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(34, 170);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(57, 20);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Text = "Col 4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(34, 196);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(57, 20);
            this.checkBox5.TabIndex = 18;
            this.checkBox5.Text = "Col 5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(247, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 22);
            this.textBox1.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(247, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 22);
            this.textBox2.TabIndex = 20;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(247, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(222, 22);
            this.textBox3.TabIndex = 21;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(247, 168);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(222, 22);
            this.textBox4.TabIndex = 22;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(247, 194);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(222, 22);
            this.textBox5.TabIndex = 23;
            // 
            // lblCol1
            // 
            this.lblCol1.AutoSize = true;
            this.lblCol1.Location = new System.Drawing.Point(120, 92);
            this.lblCol1.Name = "lblCol1";
            this.lblCol1.Size = new System.Drawing.Size(49, 16);
            this.lblCol1.TabIndex = 24;
            this.lblCol1.Text = "lblCol1";
            // 
            // lblCol2
            // 
            this.lblCol2.AutoSize = true;
            this.lblCol2.Location = new System.Drawing.Point(120, 118);
            this.lblCol2.Name = "lblCol2";
            this.lblCol2.Size = new System.Drawing.Size(45, 16);
            this.lblCol2.TabIndex = 25;
            this.lblCol2.Text = "label4";
            // 
            // lblCol3
            // 
            this.lblCol3.AutoSize = true;
            this.lblCol3.Location = new System.Drawing.Point(120, 144);
            this.lblCol3.Name = "lblCol3";
            this.lblCol3.Size = new System.Drawing.Size(45, 16);
            this.lblCol3.TabIndex = 26;
            this.lblCol3.Text = "label4";
            // 
            // lblCol4
            // 
            this.lblCol4.AutoSize = true;
            this.lblCol4.Location = new System.Drawing.Point(120, 171);
            this.lblCol4.Name = "lblCol4";
            this.lblCol4.Size = new System.Drawing.Size(45, 16);
            this.lblCol4.TabIndex = 27;
            this.lblCol4.Text = "label4";
            // 
            // lblCol5
            // 
            this.lblCol5.AutoSize = true;
            this.lblCol5.Location = new System.Drawing.Point(120, 200);
            this.lblCol5.Name = "lblCol5";
            this.lblCol5.Size = new System.Drawing.Size(45, 16);
            this.lblCol5.TabIndex = 28;
            this.lblCol5.Text = "label4";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(34, 315);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 29;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Field Names";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Table Name:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(120, 31);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(349, 22);
            this.txtTableName.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "sql:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(123, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(346, 103);
            this.label7.TabIndex = 34;
            this.label7.Text = "sql";
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.textBox5);
            this.grpBox.Controls.Add(this.label7);
            this.grpBox.Controls.Add(this.checkBox1);
            this.grpBox.Controls.Add(this.label6);
            this.grpBox.Controls.Add(this.checkBox2);
            this.grpBox.Controls.Add(this.txtTableName);
            this.grpBox.Controls.Add(this.checkBox3);
            this.grpBox.Controls.Add(this.label5);
            this.grpBox.Controls.Add(this.checkBox4);
            this.grpBox.Controls.Add(this.label4);
            this.grpBox.Controls.Add(this.checkBox5);
            this.grpBox.Controls.Add(this.btnImport);
            this.grpBox.Controls.Add(this.textBox1);
            this.grpBox.Controls.Add(this.lblCol5);
            this.grpBox.Controls.Add(this.textBox2);
            this.grpBox.Controls.Add(this.lblCol4);
            this.grpBox.Controls.Add(this.textBox3);
            this.grpBox.Controls.Add(this.lblCol3);
            this.grpBox.Controls.Add(this.textBox4);
            this.grpBox.Controls.Add(this.lblCol2);
            this.grpBox.Controls.Add(this.lblCol1);
            this.grpBox.Location = new System.Drawing.Point(15, 149);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(641, 379);
            this.grpBox.TabIndex = 35;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Database Info";
            this.grpBox.Visible = false;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 540);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numLast);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.numFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmImport";
            this.Text = "Import";
            ((System.ComponentModel.ISupportInitialize)(this.numFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLast)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numLast;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblCol1;
        private System.Windows.Forms.Label lblCol2;
        private System.Windows.Forms.Label lblCol3;
        private System.Windows.Forms.Label lblCol4;
        private System.Windows.Forms.Label lblCol5;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpBox;
    }
}