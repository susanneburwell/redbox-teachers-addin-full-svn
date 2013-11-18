namespace RedboxAddin.Presentation
{
    partial class frmAttributePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttributePicker));
            this.lboxAttAddables = new DevExpress.XtraEditors.ListBoxControl();
            this.lboxAttAdded = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAddAtt = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveAtt = new DevExpress.XtraEditors.SimpleButton();
            this.panelAtt = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.txtNewAttribute = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lboxAttAddables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxAttAdded)).BeginInit();
            this.panelAtt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxAttAddables
            // 
            this.lboxAttAddables.Location = new System.Drawing.Point(9, 9);
            this.lboxAttAddables.Name = "lboxAttAddables";
            this.lboxAttAddables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxAttAddables.Size = new System.Drawing.Size(220, 226);
            this.lboxAttAddables.TabIndex = 0;
            this.lboxAttAddables.DoubleClick += new System.EventHandler(this.lboxAttAddables_DoubleClick);
            // 
            // lboxAttAdded
            // 
            this.lboxAttAdded.Location = new System.Drawing.Point(329, 9);
            this.lboxAttAdded.Name = "lboxAttAdded";
            this.lboxAttAdded.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxAttAdded.Size = new System.Drawing.Size(220, 226);
            this.lboxAttAdded.TabIndex = 1;
            this.lboxAttAdded.DoubleClick += new System.EventHandler(this.lboxAttAdded_DoubleClick);
            // 
            // btnAddAtt
            // 
            this.btnAddAtt.Location = new System.Drawing.Point(240, 83);
            this.btnAddAtt.Name = "btnAddAtt";
            this.btnAddAtt.Size = new System.Drawing.Size(75, 23);
            this.btnAddAtt.TabIndex = 0;
            this.btnAddAtt.Text = "Add ->";
            this.btnAddAtt.Click += new System.EventHandler(this.btnAddAtt_Click);
            // 
            // btnRemoveAtt
            // 
            this.btnRemoveAtt.Location = new System.Drawing.Point(240, 112);
            this.btnRemoveAtt.Name = "btnRemoveAtt";
            this.btnRemoveAtt.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAtt.TabIndex = 1;
            this.btnRemoveAtt.Text = "<- Remove";
            this.btnRemoveAtt.Click += new System.EventHandler(this.btnRemoveAtt_Click);
            // 
            // panelAtt
            // 
            this.panelAtt.Controls.Add(this.lboxAttAddables);
            this.panelAtt.Controls.Add(this.btnRemoveAtt);
            this.panelAtt.Controls.Add(this.lboxAttAdded);
            this.panelAtt.Controls.Add(this.btnAddAtt);
            this.panelAtt.Location = new System.Drawing.Point(12, 12);
            this.panelAtt.Name = "panelAtt";
            this.panelAtt.Size = new System.Drawing.Size(560, 245);
            this.panelAtt.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(500, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(419, 263);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(252, 263);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(42, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtNewAttribute
            // 
            this.txtNewAttribute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAttribute.Location = new System.Drawing.Point(21, 263);
            this.txtNewAttribute.Name = "txtNewAttribute";
            this.txtNewAttribute.Size = new System.Drawing.Size(220, 21);
            this.txtNewAttribute.TabIndex = 2;
            // 
            // frmAttributePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 295);
            this.Controls.Add(this.txtNewAttribute);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelAtt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(381, 333);
            this.Name = "frmAttributePicker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attributes";
            ((System.ComponentModel.ISupportInitialize)(this.lboxAttAddables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxAttAdded)).EndInit();
            this.panelAtt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lboxAttAddables;
        private DevExpress.XtraEditors.ListBoxControl lboxAttAdded;
        private DevExpress.XtraEditors.SimpleButton btnAddAtt;
        private DevExpress.XtraEditors.SimpleButton btnRemoveAtt;
        private System.Windows.Forms.Panel panelAtt;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.TextBox txtNewAttribute;
    }
}