namespace RedboxAddin.Presentation
{
    partial class frmTeacherUpdate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeacherUpdate));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDblBkgs = new System.Windows.Forms.Button();
            this.grpAvailability = new System.Windows.Forms.GroupBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.chkThu = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.radPriority = new System.Windows.Forms.RadioButton();
            this.radGuaranteed = new System.Windows.Forms.RadioButton();
            this.radOffered = new System.Windows.Forms.RadioButton();
            this.radUnavail = new System.Windows.Forms.RadioButton();
            this.radAvail = new System.Windows.Forms.RadioButton();
            this.radTexted = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkAccepted = new System.Windows.Forms.CheckBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.chkPast = new System.Windows.Forms.CheckBox();
            this.groupBoxTeacher = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoLastName = new System.Windows.Forms.RadioButton();
            this.rdoFirstName = new System.Windows.Forms.RadioButton();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAvailability = new System.Windows.Forms.RadioButton();
            this.radAbs = new System.Windows.Forms.RadioButton();
            this.gcGuaranteed = new DevExpress.XtraGrid.GridControl();
            this.gvGuaranteed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.flashtimer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.grpAvailability.SuspendLayout();
            this.grpAbsence.SuspendLayout();
            this.groupBoxTeacher.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gcGuaranteed, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 404F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 673);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDblBkgs);
            this.panelTop.Controls.Add(this.grpAvailability);
            this.panelTop.Controls.Add(this.grpAbsence);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblType);
            this.panelTop.Controls.Add(this.chkFuture);
            this.panelTop.Controls.Add(this.chkPast);
            this.panelTop.Controls.Add(this.groupBoxTeacher);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(902, 398);
            this.panelTop.TabIndex = 0;
            // 
            // btnDblBkgs
            // 
            this.btnDblBkgs.BackColor = System.Drawing.Color.Crimson;
            this.btnDblBkgs.ForeColor = System.Drawing.Color.White;
            this.btnDblBkgs.Location = new System.Drawing.Point(587, 60);
            this.btnDblBkgs.Name = "btnDblBkgs";
            this.btnDblBkgs.Size = new System.Drawing.Size(187, 48);
            this.btnDblBkgs.TabIndex = 107;
            this.btnDblBkgs.Text = "Booking clash found";
            this.btnDblBkgs.UseVisualStyleBackColor = false;
            this.btnDblBkgs.Visible = false;
            this.btnDblBkgs.Click += new System.EventHandler(this.btnDblBkgs_Click);
            // 
            // grpAvailability
            // 
            this.grpAvailability.Controls.Add(this.txtNotes);
            this.grpAvailability.Controls.Add(this.dtFrom);
            this.grpAvailability.Controls.Add(this.chkFri);
            this.grpAvailability.Controls.Add(this.chkThu);
            this.grpAvailability.Controls.Add(this.chkWed);
            this.grpAvailability.Controls.Add(this.chkTue);
            this.grpAvailability.Controls.Add(this.chkMon);
            this.grpAvailability.Controls.Add(this.lblDays);
            this.grpAvailability.Controls.Add(this.label9);
            this.grpAvailability.Controls.Add(this.radPriority);
            this.grpAvailability.Controls.Add(this.radGuaranteed);
            this.grpAvailability.Controls.Add(this.radOffered);
            this.grpAvailability.Controls.Add(this.radUnavail);
            this.grpAvailability.Controls.Add(this.radAvail);
            this.grpAvailability.Controls.Add(this.radTexted);
            this.grpAvailability.Controls.Add(this.label7);
            this.grpAvailability.Controls.Add(this.label3);
            this.grpAvailability.Controls.Add(this.btnDelete);
            this.grpAvailability.Controls.Add(this.btnSave);
            this.grpAvailability.Controls.Add(this.chkAccepted);
            this.grpAvailability.Controls.Add(this.dtTo);
            this.grpAvailability.Controls.Add(this.label5);
            this.grpAvailability.Controls.Add(this.label4);
            this.grpAvailability.Controls.Add(this.label2);
            this.grpAvailability.Location = new System.Drawing.Point(12, 169);
            this.grpAvailability.Name = "grpAvailability";
            this.grpAvailability.Size = new System.Drawing.Size(882, 216);
            this.grpAvailability.TabIndex = 20;
            this.grpAvailability.TabStop = false;
            this.grpAvailability.Text = "Log new Availability";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(19, 43);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(189, 27);
            this.dtFrom.TabIndex = 7;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.Checked = true;
            this.chkFri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFri.Location = new System.Drawing.Point(294, 72);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(46, 21);
            this.chkFri.TabIndex = 121;
            this.chkFri.Text = "Fri";
            this.chkFri.UseVisualStyleBackColor = true;
            // 
            // chkThu
            // 
            this.chkThu.AutoSize = true;
            this.chkThu.Checked = true;
            this.chkThu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThu.Location = new System.Drawing.Point(233, 72);
            this.chkThu.Name = "chkThu";
            this.chkThu.Size = new System.Drawing.Size(55, 21);
            this.chkThu.TabIndex = 120;
            this.chkThu.Text = "Thu";
            this.chkThu.UseVisualStyleBackColor = true;
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.Checked = true;
            this.chkWed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWed.Location = new System.Drawing.Point(167, 72);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(59, 21);
            this.chkWed.TabIndex = 119;
            this.chkWed.Text = "Wed";
            this.chkWed.UseVisualStyleBackColor = true;
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.Checked = true;
            this.chkTue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTue.Location = new System.Drawing.Point(106, 72);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(55, 21);
            this.chkTue.TabIndex = 118;
            this.chkTue.Text = "Tue";
            this.chkTue.UseVisualStyleBackColor = true;
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.Checked = true;
            this.chkMon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMon.Location = new System.Drawing.Point(44, 72);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(57, 21);
            this.chkMon.TabIndex = 117;
            this.chkMon.Text = "Mon";
            this.chkMon.UseVisualStyleBackColor = true;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(41, 71);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(64, 21);
            this.lblDays.TabIndex = 122;
            this.lblDays.Text = "lblDays";
            this.lblDays.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "Notes :";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(80, 169);
            this.txtNotes.MaxLength = 75;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(320, 44);
            this.txtNotes.TabIndex = 32;
            // 
            // radPriority
            // 
            this.radPriority.AutoSize = true;
            this.radPriority.BackColor = System.Drawing.Color.PeachPuff;
            this.radPriority.Location = new System.Drawing.Point(471, 74);
            this.radPriority.Name = "radPriority";
            this.radPriority.Size = new System.Drawing.Size(83, 25);
            this.radPriority.TabIndex = 31;
            this.radPriority.Text = "Priority";
            this.radPriority.UseVisualStyleBackColor = false;
            // 
            // radGuaranteed
            // 
            this.radGuaranteed.AutoSize = true;
            this.radGuaranteed.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.radGuaranteed.Location = new System.Drawing.Point(725, 45);
            this.radGuaranteed.Name = "radGuaranteed";
            this.radGuaranteed.Size = new System.Drawing.Size(115, 25);
            this.radGuaranteed.TabIndex = 31;
            this.radGuaranteed.Text = "guaranteed";
            this.radGuaranteed.UseVisualStyleBackColor = false;
            // 
            // radOffered
            // 
            this.radOffered.AutoSize = true;
            this.radOffered.Location = new System.Drawing.Point(471, 48);
            this.radOffered.Name = "radOffered";
            this.radOffered.Size = new System.Drawing.Size(163, 25);
            this.radOffered.TabIndex = 30;
            this.radOffered.Text = "guarantee offered";
            this.radOffered.UseVisualStyleBackColor = true;
            // 
            // radUnavail
            // 
            this.radUnavail.AutoSize = true;
            this.radUnavail.BackColor = System.Drawing.Color.Orange;
            this.radUnavail.Location = new System.Drawing.Point(724, 18);
            this.radUnavail.Name = "radUnavail";
            this.radUnavail.Size = new System.Drawing.Size(114, 25);
            this.radUnavail.TabIndex = 29;
            this.radUnavail.Text = "unavailable";
            this.radUnavail.UseVisualStyleBackColor = false;
            // 
            // radAvail
            // 
            this.radAvail.AutoSize = true;
            this.radAvail.BackColor = System.Drawing.Color.LightGreen;
            this.radAvail.Location = new System.Drawing.Point(604, 22);
            this.radAvail.Name = "radAvail";
            this.radAvail.Size = new System.Drawing.Size(96, 25);
            this.radAvail.TabIndex = 28;
            this.radAvail.Text = "available";
            this.radAvail.UseVisualStyleBackColor = false;
            // 
            // radTexted
            // 
            this.radTexted.AutoSize = true;
            this.radTexted.BackColor = System.Drawing.Color.Pink;
            this.radTexted.Checked = true;
            this.radTexted.Location = new System.Drawing.Point(472, 21);
            this.radTexted.Name = "radTexted";
            this.radTexted.Size = new System.Drawing.Size(78, 25);
            this.radTexted.TabIndex = 27;
            this.radTexted.TabStop = true;
            this.radTexted.Text = "texted";
            this.radTexted.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(578, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(293, 39);
            this.label7.TabIndex = 26;
            this.label7.Text = "Highlight existing guaranteed days (below) and select delete to remove the guaran" +
    "tee.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(578, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Select Save to save the guaranteed days";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(447, 77);
            this.label2.TabIndex = 24;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(472, 138);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 32);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkAccepted
            // 
            this.chkAccepted.AutoSize = true;
            this.chkAccepted.Checked = true;
            this.chkAccepted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccepted.Location = new System.Drawing.Point(472, 180);
            this.chkAccepted.Name = "chkAccepted";
            this.chkAccepted.Size = new System.Drawing.Size(183, 25);
            this.chkAccepted.TabIndex = 19;
            this.chkAccepted.Text = "Guarantee Accepted";
            this.chkAccepted.UseVisualStyleBackColor = true;
            this.chkAccepted.Visible = false;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(211, 43);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(189, 27);
            this.dtTo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "From:";
            // 
            // grpAbsence
            // 
            this.grpAbsence.Controls.Add(this.label1);
            this.grpAbsence.Controls.Add(this.txtDetails);
            this.grpAbsence.Controls.Add(this.label6);
            this.grpAbsence.Location = new System.Drawing.Point(12, 206);
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.Size = new System.Drawing.Size(699, 176);
            this.grpAbsence.TabIndex = 22;
            this.grpAbsence.TabStop = false;
            this.grpAbsence.Text = "Record Absence";
            this.grpAbsence.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 59);
            this.label1.TabIndex = 15;
            this.label1.Text = "This lets you record an absence on an existing booking record for billing/payment" +
    " puposes. \r\nPlease enter any notes (left) and then right click the booking (belo" +
    "w) and select the absence type";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(97, 21);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(288, 56);
            this.txtDetails.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(29, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 39);
            this.label6.TabIndex = 14;
            this.label6.Text = "Details Notes:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(790, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 32);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(523, 21);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(155, 31);
            this.lblType.TabIndex = 21;
            this.lblType.Text = "Availability";
            // 
            // chkFuture
            // 
            this.chkFuture.AutoSize = true;
            this.chkFuture.Checked = true;
            this.chkFuture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFuture.Location = new System.Drawing.Point(692, 122);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(174, 25);
            this.chkFuture.TabIndex = 17;
            this.chkFuture.Text = "Show Future Dates";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // chkPast
            // 
            this.chkPast.AutoSize = true;
            this.chkPast.Location = new System.Drawing.Point(528, 122);
            this.chkPast.Name = "chkPast";
            this.chkPast.Size = new System.Drawing.Size(158, 25);
            this.chkPast.TabIndex = 16;
            this.chkPast.Text = "Show Past Dates";
            this.chkPast.UseVisualStyleBackColor = true;
            this.chkPast.CheckedChanged += new System.EventHandler(this.chkPast_CheckedChanged);
            // 
            // groupBoxTeacher
            // 
            this.groupBoxTeacher.Controls.Add(this.label8);
            this.groupBoxTeacher.Controls.Add(this.rdoLastName);
            this.groupBoxTeacher.Controls.Add(this.rdoFirstName);
            this.groupBoxTeacher.Controls.Add(this.cmbTeacher);
            this.groupBoxTeacher.Controls.Add(this.lblTeacher);
            this.groupBoxTeacher.Location = new System.Drawing.Point(12, 9);
            this.groupBoxTeacher.Name = "groupBoxTeacher";
            this.groupBoxTeacher.Size = new System.Drawing.Size(453, 86);
            this.groupBoxTeacher.TabIndex = 11;
            this.groupBoxTeacher.TabStop = false;
            this.groupBoxTeacher.Text = "Search Teacher";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sort by:";
            // 
            // rdoLastName
            // 
            this.rdoLastName.AutoSize = true;
            this.rdoLastName.Checked = true;
            this.rdoLastName.Location = new System.Drawing.Point(172, 19);
            this.rdoLastName.Name = "rdoLastName";
            this.rdoLastName.Size = new System.Drawing.Size(108, 25);
            this.rdoLastName.TabIndex = 1;
            this.rdoLastName.TabStop = true;
            this.rdoLastName.Text = "Last name";
            this.rdoLastName.UseVisualStyleBackColor = true;
            this.rdoLastName.CheckedChanged += new System.EventHandler(this.rdoLastName_CheckedChanged);
            // 
            // rdoFirstName
            // 
            this.rdoFirstName.AutoSize = true;
            this.rdoFirstName.Location = new System.Drawing.Point(290, 19);
            this.rdoFirstName.Name = "rdoFirstName";
            this.rdoFirstName.Size = new System.Drawing.Size(110, 25);
            this.rdoFirstName.TabIndex = 0;
            this.rdoFirstName.Text = "First name";
            this.rdoFirstName.UseVisualStyleBackColor = true;
            this.rdoFirstName.CheckedChanged += new System.EventHandler(this.rdoFirstName_CheckedChanged);
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(97, 47);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(303, 27);
            this.cmbTeacher.TabIndex = 0;
            this.cmbTeacher.SelectedIndexChanged += new System.EventHandler(this.cmbTeacher_SelectedIndexChanged);
            this.cmbTeacher.SelectionChangeCommitted += new System.EventHandler(this.cmbTeacher_SelectionChangeCommitted);
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(16, 50);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(76, 21);
            this.lblTeacher.TabIndex = 1;
            this.lblTeacher.Text = "Teacher:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radAvailability);
            this.groupBox1.Controls.Add(this.radAbs);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 66);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radAvailability
            // 
            this.radAvailability.AutoSize = true;
            this.radAvailability.Checked = true;
            this.radAvailability.Location = new System.Drawing.Point(20, 26);
            this.radAvailability.Name = "radAvailability";
            this.radAvailability.Size = new System.Drawing.Size(178, 25);
            this.radAvailability.TabIndex = 1;
            this.radAvailability.TabStop = true;
            this.radAvailability.Text = "Register Availability";
            this.radAvailability.UseVisualStyleBackColor = true;
            // 
            // radAbs
            // 
            this.radAbs.AutoSize = true;
            this.radAbs.Location = new System.Drawing.Point(224, 26);
            this.radAbs.Name = "radAbs";
            this.radAbs.Size = new System.Drawing.Size(161, 25);
            this.radAbs.TabIndex = 0;
            this.radAbs.Text = "Register Absence";
            this.radAbs.UseVisualStyleBackColor = true;
            this.radAbs.CheckedChanged += new System.EventHandler(this.radAbs_CheckedChanged);
            // 
            // gcGuaranteed
            // 
            this.gcGuaranteed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGuaranteed.Location = new System.Drawing.Point(3, 407);
            this.gcGuaranteed.MainView = this.gvGuaranteed;
            this.gcGuaranteed.Name = "gcGuaranteed";
            this.gcGuaranteed.Size = new System.Drawing.Size(902, 263);
            this.gcGuaranteed.TabIndex = 1;
            this.gcGuaranteed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuaranteed});
            this.gcGuaranteed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gcGuaranteed_MouseDown);
            // 
            // gvGuaranteed
            // 
            this.gvGuaranteed.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.ID});
            this.gvGuaranteed.GridControl = this.gcGuaranteed;
            this.gvGuaranteed.Name = "gvGuaranteed";
            this.gvGuaranteed.OptionsSelection.MultiSelect = true;
            this.gvGuaranteed.OptionsView.ShowGroupPanel = false;
            this.gvGuaranteed.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvGuaranteed.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvGuaranteed_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.DisplayFormat.FormatString = "ddd dd MMM yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "dte";
            this.gridColumn1.MaxWidth = 200;
            this.gridColumn1.MinWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 132;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Description";
            this.gridColumn2.FieldName = "Text";
            this.gridColumn2.MaxWidth = 300;
            this.gridColumn2.MinWidth = 100;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Details";
            this.gridColumn3.FieldName = "Details";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "Status";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 194;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "status.png");
            this.imageList1.Images.SetKeyName(1, "found.png");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 2500;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // flashtimer1
            // 
            this.flashtimer1.Interval = 500;
            this.flashtimer1.Tick += new System.EventHandler(this.flashtimer1_Tick);
            // 
            // frmTeacherUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTeacherUpdate";
            this.Text = "Update Teacher";
            this.Load += new System.EventHandler(this.frmTeacherUpdate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpAvailability.ResumeLayout(false);
            this.grpAvailability.PerformLayout();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
            this.groupBoxTeacher.ResumeLayout(false);
            this.groupBoxTeacher.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radAvailability;
        private System.Windows.Forms.RadioButton radAbs;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gcGuaranteed;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuaranteed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.CheckBox chkPast;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.CheckBox chkAccepted;
        private System.Windows.Forms.Label lblType;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpAbsence;
        private System.Windows.Forms.GroupBox grpAvailability;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radGuaranteed;
        private System.Windows.Forms.RadioButton radOffered;
        private System.Windows.Forms.RadioButton radUnavail;
        private System.Windows.Forms.RadioButton radAvail;
        private System.Windows.Forms.RadioButton radTexted;
        private System.Windows.Forms.GroupBox groupBoxTeacher;
        private System.Windows.Forms.RadioButton rdoLastName;
        private System.Windows.Forms.RadioButton rdoFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnDblBkgs;
        private System.Windows.Forms.Timer flashtimer1;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.RadioButton radPriority;
    }
}