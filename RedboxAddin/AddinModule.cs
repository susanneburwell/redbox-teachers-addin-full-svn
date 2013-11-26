using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Outlook = Microsoft.Office.Interop.Outlook;
using RedboxAddin.Presentation;
using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;


namespace RedboxAddin
{
    /// <summary>
    ///   Add-in Express Add-in Module
    /// </summary>
    [GuidAttribute("2A2C28B3-E89D-4345-92A6-F778AB2085CC"), ProgId("RedboxAddin.AddinModule")]
    public class AddinModule : AddinExpress.MSO.ADXAddinModule
    {
        public AddinModule()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            // Please add any initialization code to the AddinInitialize event handler
        }

        private ADXRibbonTab adxRibbonTab1;
        private ADXRibbonGroup adxRibbonGroup1;
        private ADXRibbonButton adxRibbonButtonAddNew;
        private AddinExpress.OL.ADXOlFormsManager adxOlFormsManagerRedbox;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmBotNavi;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmExplorer;
        private ADXRibbonButton adxRibbonButton2;
        private ImageList imageList1;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmReminders;
        private ADXRibbonButton adxRibbonButton1;
        private ADXRibbonButton rbAbout;
        private ADXOlExplorerCommandBar commandBarRedboxAddin;
        private ADXCommandBarButton cbBtnNewContact;
        private ADXCommandBarButton cbBtnContacts;
        private ADXCommandBarButton cbBtnNewReminders;
        private ADXCommandBarButton cbBtnAbout;
        private ImageList imageList2;
        private ADXRibbonButton rbCheckForUpdates;
        private ADXCommandBarButton cbBtnCheckForUpdates;
        private ADXRibbonTab adxtab;
        private ADXRibbonGroup adxRibbonGroup2;
        private ADXRibbonButton adxNewRequest;
        private ADXRibbonButton adxTeacherUpdate;
        private ADXRibbonMenu adxOptions;
        private ADXRibbonButton adxImportXL;
        private ADXRibbonButton adxImport;
        private ADXRibbonButton adxImportSchools;
        private ADXRibbonButton adxEditSchool;
        private ADXRibbonButton adxProcess;
        private ADXRibbonButton adxBookings;
        private ADXRibbonButton adxImportKeyRef;
        private ADXRibbonButton adxAvail;
        private ADXRibbonButton adxLoadPlan;
        private ADXRibbonButton adxPivot;

        #region Component Designer generated code
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddinModule));
            this.adxRibbonTab1 = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxRibbonGroup1 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.adxRibbonButtonAddNew = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.adxRibbonButton2 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonButton1 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.rbCheckForUpdates = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.rbAbout = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxOlFormsManagerRedbox = new AddinExpress.OL.ADXOlFormsManager(this.components);
            this.olFrmBotNavi = new AddinExpress.OL.ADXOlFormsCollectionItem(this.components);
            this.olFrmExplorer = new AddinExpress.OL.ADXOlFormsCollectionItem(this.components);
            this.olFrmReminders = new AddinExpress.OL.ADXOlFormsCollectionItem(this.components);
            this.commandBarRedboxAddin = new AddinExpress.MSO.ADXOlExplorerCommandBar(this.components);
            this.cbBtnNewContact = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.cbBtnContacts = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.cbBtnNewReminders = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.cbBtnCheckForUpdates = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.cbBtnAbout = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxtab = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxRibbonGroup2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.adxNewRequest = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTeacherUpdate = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxBookings = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxAvail = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxLoadPlan = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxOptions = new AddinExpress.MSO.ADXRibbonMenu(this.components);
            this.adxImportXL = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportSchools = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportKeyRef = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImport = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxEditSchool = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxProcess = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxPivot = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // adxRibbonTab1
            // 
            this.adxRibbonTab1.Caption = "Redbox";
            this.adxRibbonTab1.Controls.Add(this.adxRibbonGroup1);
            this.adxRibbonTab1.Id = "adxRibbonTab_53cd27d9f4444a159945725686081d67";
            this.adxRibbonTab1.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxRibbonGroup1
            // 
            this.adxRibbonGroup1.Caption = "Redbox";
            this.adxRibbonGroup1.Controls.Add(this.adxRibbonButtonAddNew);
            this.adxRibbonGroup1.Controls.Add(this.adxRibbonButton2);
            this.adxRibbonGroup1.Controls.Add(this.adxRibbonButton1);
            this.adxRibbonGroup1.Controls.Add(this.rbCheckForUpdates);
            this.adxRibbonGroup1.Controls.Add(this.rbAbout);
            this.adxRibbonGroup1.Id = "adxRibbonGroup_6734d4c82ad242c3877678c1deb9c903";
            this.adxRibbonGroup1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup1.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxRibbonButtonAddNew
            // 
            this.adxRibbonButtonAddNew.Caption = "Add New Contact";
            this.adxRibbonButtonAddNew.Id = "adxRibbonButton_49bde1ee56194b4db27be190ce71ad0a";
            this.adxRibbonButtonAddNew.Image = 0;
            this.adxRibbonButtonAddNew.ImageList = this.imageList1;
            this.adxRibbonButtonAddNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButtonAddNew.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxRibbonButtonAddNew.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxRibbonButtonAddNew.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton1_OnClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1354806935_contact-new.png");
            this.imageList1.Images.SetKeyName(1, "1354807003_contacts.png");
            this.imageList1.Images.SetKeyName(2, "1354812073_stock_appointment-reminder.png");
            this.imageList1.Images.SetKeyName(3, "Actions-help-about.ico");
            this.imageList1.Images.SetKeyName(4, "1359478888_arrow_circle_double.png");
            // 
            // adxRibbonButton2
            // 
            this.adxRibbonButton2.Caption = "Contacts";
            this.adxRibbonButton2.Id = "adxRibbonButton_d92afb6db82e440b9e5ddef80c82acc5";
            this.adxRibbonButton2.Image = 1;
            this.adxRibbonButton2.ImageList = this.imageList1;
            this.adxRibbonButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButton2.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxRibbonButton2.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxRibbonButton2.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton2_OnClick);
            // 
            // adxRibbonButton1
            // 
            this.adxRibbonButton1.Caption = "Reminders";
            this.adxRibbonButton1.Id = "adxRibbonButton_f7e5bba1d2434cada191792dda851b4d";
            this.adxRibbonButton1.Image = 2;
            this.adxRibbonButton1.ImageList = this.imageList1;
            this.adxRibbonButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButton1.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxRibbonButton1.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxRibbonButton1.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton1_OnClick_1);
            // 
            // rbCheckForUpdates
            // 
            this.rbCheckForUpdates.Caption = "Check for updates";
            this.rbCheckForUpdates.Id = "adxRibbonButton_c3509caccef84deaa985738557cfdee5";
            this.rbCheckForUpdates.Image = 4;
            this.rbCheckForUpdates.ImageList = this.imageList2;
            this.rbCheckForUpdates.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.rbCheckForUpdates.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.rbCheckForUpdates.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.rbCheckForUpdates_OnClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "1355480871_Information.png");
            this.imageList2.Images.SetKeyName(1, "1355480886_alarm-clock--pencil.png");
            this.imageList2.Images.SetKeyName(2, "1355480893_contact-new.png");
            this.imageList2.Images.SetKeyName(3, "1355480900_contact.png");
            this.imageList2.Images.SetKeyName(4, "1359478888_arrow_circle_double.png");
            // 
            // rbAbout
            // 
            this.rbAbout.Caption = "About";
            this.rbAbout.Id = "adxRibbonButton_2935eab4f09b4c25a9abeceb0c79dc52";
            this.rbAbout.Image = 3;
            this.rbAbout.ImageList = this.imageList1;
            this.rbAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.rbAbout.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.rbAbout.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.rbAbout_OnClick);
            // 
            // adxOlFormsManagerRedbox
            // 
            this.adxOlFormsManagerRedbox.Items.Add(this.olFrmBotNavi);
            this.adxOlFormsManagerRedbox.Items.Add(this.olFrmExplorer);
            this.adxOlFormsManagerRedbox.Items.Add(this.olFrmReminders);
            this.adxOlFormsManagerRedbox.ADXBeforeFolderSwitchEx += new AddinExpress.OL.ADXOlFormsManager.BeforeFolderSwitchEx_EventHandler(this.adxOlFormsManagerRedbox_ADXBeforeFolderSwitchEx);
            this.adxOlFormsManagerRedbox.SetOwner(this);
            // 
            // olFrmBotNavi
            // 
            this.olFrmBotNavi.ExplorerItemTypes = ((AddinExpress.OL.ADXOlExplorerItemTypes)((((((((AddinExpress.OL.ADXOlExplorerItemTypes.olMailItem | AddinExpress.OL.ADXOlExplorerItemTypes.olAppointmentItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olContactItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olTaskItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olJournalItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olNoteItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olPostItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olDistributionListItem)));
            this.olFrmBotNavi.ExplorerLayout = AddinExpress.OL.ADXOlExplorerLayout.BottomNavigationPane;
            this.olFrmBotNavi.FormClassName = "RedboxAddin.Presentation.frmBotNavi";
            this.olFrmBotNavi.IsHiddenStateAllowed = false;
            this.olFrmBotNavi.IsMinimizedStateAllowed = false;
            this.olFrmBotNavi.RegionBorder = AddinExpress.OL.ADXRegionBorderStyle.None;
            this.olFrmBotNavi.Splitter = AddinExpress.OL.ADXOlSplitterBehavior.None;
            this.olFrmBotNavi.UseOfficeThemeForBackground = true;
            // 
            // olFrmExplorer
            // 
            this.olFrmExplorer.Enabled = false;
            this.olFrmExplorer.ExplorerItemTypes = ((AddinExpress.OL.ADXOlExplorerItemTypes)((((((((AddinExpress.OL.ADXOlExplorerItemTypes.olMailItem | AddinExpress.OL.ADXOlExplorerItemTypes.olAppointmentItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olContactItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olTaskItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olJournalItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olNoteItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olPostItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olDistributionListItem)));
            this.olFrmExplorer.ExplorerLayout = AddinExpress.OL.ADXOlExplorerLayout.WebViewPane;
            this.olFrmExplorer.FolderName = "Inbox";
            this.olFrmExplorer.FormClassName = "RedboxAddin.Presentation.frmContactExp";
            this.olFrmExplorer.UseOfficeThemeForBackground = true;
            // 
            // olFrmReminders
            // 
            this.olFrmReminders.Enabled = false;
            this.olFrmReminders.ExplorerItemTypes = ((AddinExpress.OL.ADXOlExplorerItemTypes)((((((((AddinExpress.OL.ADXOlExplorerItemTypes.olMailItem | AddinExpress.OL.ADXOlExplorerItemTypes.olAppointmentItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olContactItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olTaskItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olJournalItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olNoteItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olPostItem) 
            | AddinExpress.OL.ADXOlExplorerItemTypes.olDistributionListItem)));
            this.olFrmReminders.ExplorerLayout = AddinExpress.OL.ADXOlExplorerLayout.WebViewPane;
            this.olFrmReminders.FolderName = "Redbox";
            this.olFrmReminders.FormClassName = "RedboxAddin.Presentation.frmReminderExp";
            this.olFrmReminders.UseOfficeThemeForBackground = true;
            // 
            // commandBarRedboxAddin
            // 
            this.commandBarRedboxAddin.CommandBarName = "commandBarRedboxAddin";
            this.commandBarRedboxAddin.CommandBarTag = "896a1eff-b600-4086-a344-58ba75329f44";
            this.commandBarRedboxAddin.Controls.Add(this.cbBtnNewContact);
            this.commandBarRedboxAddin.Controls.Add(this.cbBtnContacts);
            this.commandBarRedboxAddin.Controls.Add(this.cbBtnNewReminders);
            this.commandBarRedboxAddin.Controls.Add(this.cbBtnCheckForUpdates);
            this.commandBarRedboxAddin.Controls.Add(this.cbBtnAbout);
            this.commandBarRedboxAddin.ItemTypes = ((AddinExpress.MSO.ADXOlExplorerItemTypes)((((((((AddinExpress.MSO.ADXOlExplorerItemTypes.olMailItem | AddinExpress.MSO.ADXOlExplorerItemTypes.olAppointmentItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olContactItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olTaskItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olJournalItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olNoteItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olPostItem) 
            | AddinExpress.MSO.ADXOlExplorerItemTypes.olDistributionListItem)));
            this.commandBarRedboxAddin.Temporary = true;
            this.commandBarRedboxAddin.UpdateCounter = 14;
            // 
            // cbBtnNewContact
            // 
            this.cbBtnNewContact.Caption = "Add New Contact";
            this.cbBtnNewContact.ControlTag = "49f434a7-5fd1-47dc-a5dd-e2596bd7ba7c";
            this.cbBtnNewContact.Image = 2;
            this.cbBtnNewContact.ImageList = this.imageList2;
            this.cbBtnNewContact.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnNewContact.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnNewContact.Temporary = true;
            this.cbBtnNewContact.UpdateCounter = 12;
            this.cbBtnNewContact.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnNewContact_Click);
            // 
            // cbBtnContacts
            // 
            this.cbBtnContacts.BeginGroup = true;
            this.cbBtnContacts.Caption = "Contacts";
            this.cbBtnContacts.ControlTag = "3463cc09-0c3a-4b69-9612-ff1f887f2fcf";
            this.cbBtnContacts.Image = 3;
            this.cbBtnContacts.ImageList = this.imageList2;
            this.cbBtnContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnContacts.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnContacts.Temporary = true;
            this.cbBtnContacts.UpdateCounter = 15;
            this.cbBtnContacts.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnContacts_Click);
            // 
            // cbBtnNewReminders
            // 
            this.cbBtnNewReminders.BeginGroup = true;
            this.cbBtnNewReminders.Caption = "Reminders";
            this.cbBtnNewReminders.ControlTag = "d31dac5d-c015-4c3b-bd62-ea8b2f5f528d";
            this.cbBtnNewReminders.Image = 1;
            this.cbBtnNewReminders.ImageList = this.imageList2;
            this.cbBtnNewReminders.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnNewReminders.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnNewReminders.Temporary = true;
            this.cbBtnNewReminders.UpdateCounter = 12;
            this.cbBtnNewReminders.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnNewReminders_Click);
            // 
            // cbBtnCheckForUpdates
            // 
            this.cbBtnCheckForUpdates.Caption = "Check for updates";
            this.cbBtnCheckForUpdates.ControlTag = "e6337c0d-637b-4ab6-9030-170fa872ffa6";
            this.cbBtnCheckForUpdates.Image = 4;
            this.cbBtnCheckForUpdates.ImageList = this.imageList2;
            this.cbBtnCheckForUpdates.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnCheckForUpdates.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnCheckForUpdates.Temporary = true;
            this.cbBtnCheckForUpdates.UpdateCounter = 7;
            this.cbBtnCheckForUpdates.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnCheckForUpdates_Click);
            // 
            // cbBtnAbout
            // 
            this.cbBtnAbout.BeginGroup = true;
            this.cbBtnAbout.Caption = "About";
            this.cbBtnAbout.ControlTag = "8003f131-9050-473a-b6cc-ab68d48387bb";
            this.cbBtnAbout.Image = 0;
            this.cbBtnAbout.ImageList = this.imageList2;
            this.cbBtnAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnAbout.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnAbout.Temporary = true;
            this.cbBtnAbout.UpdateCounter = 12;
            this.cbBtnAbout.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnAbout_Click);
            // 
            // adxtab
            // 
            this.adxtab.Caption = "Redbox";
            this.adxtab.Controls.Add(this.adxRibbonGroup2);
            this.adxtab.Id = "adxRibbonTab_6009b89e68584fae8b43fda66b3b5ffb";
            this.adxtab.IdMso = "TabMail";
            this.adxtab.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxRibbonGroup2
            // 
            this.adxRibbonGroup2.Caption = "Redbox";
            this.adxRibbonGroup2.Controls.Add(this.adxNewRequest);
            this.adxRibbonGroup2.Controls.Add(this.adxTeacherUpdate);
            this.adxRibbonGroup2.Controls.Add(this.adxBookings);
            this.adxRibbonGroup2.Controls.Add(this.adxAvail);
            this.adxRibbonGroup2.Controls.Add(this.adxLoadPlan);
            this.adxRibbonGroup2.Controls.Add(this.adxPivot);
            this.adxRibbonGroup2.Controls.Add(this.adxOptions);
            this.adxRibbonGroup2.Id = "adxRibbonGroup_b645fd8a59e6427e97a0a4d666af69d2";
            this.adxRibbonGroup2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup2.InsertBeforeIdMso = "GroupMailDelete";
            this.adxRibbonGroup2.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxNewRequest
            // 
            this.adxNewRequest.Caption = "New Request";
            this.adxNewRequest.Id = "adxRibbonButton_6bd6e6c1524f424690d570077e270772";
            this.adxNewRequest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxNewRequest.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxNewRequest.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxNewRequest_OnClick);
            // 
            // adxTeacherUpdate
            // 
            this.adxTeacherUpdate.Caption = "Teacher Update";
            this.adxTeacherUpdate.Id = "adxRibbonButton_3cc7dd443a5a4d3188c35ce21f8f7907";
            this.adxTeacherUpdate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxTeacherUpdate.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxBookings
            // 
            this.adxBookings.Caption = "View Bookings";
            this.adxBookings.Id = "adxRibbonButton_84914fb391a242d6a1a80e9d661c9eb7";
            this.adxBookings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxBookings.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxBookings.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxBookings_OnClick);
            // 
            // adxAvail
            // 
            this.adxAvail.Caption = "Availability Sheet";
            this.adxAvail.Id = "adxRibbonButton_bb8da1a4e609499396d30b190eaa54e2";
            this.adxAvail.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxAvail.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxAvail.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxAvail_OnClick);
            // 
            // adxLoadPlan
            // 
            this.adxLoadPlan.Caption = "Load Plan";
            this.adxLoadPlan.Id = "adxRibbonButton_f2091261af184203ba2efe10ba3a1b1e";
            this.adxLoadPlan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxLoadPlan.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxLoadPlan.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxLoadPlan_OnClick);
            // 
            // adxOptions
            // 
            this.adxOptions.Caption = "Options";
            this.adxOptions.Controls.Add(this.adxImportXL);
            this.adxOptions.Controls.Add(this.adxImportSchools);
            this.adxOptions.Controls.Add(this.adxImportKeyRef);
            this.adxOptions.Controls.Add(this.adxImport);
            this.adxOptions.Controls.Add(this.adxEditSchool);
            this.adxOptions.Controls.Add(this.adxProcess);
            this.adxOptions.Id = "adxRibbonMenu_c2f3769eeaa34668aca908c7e5314288";
            this.adxOptions.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxOptions.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxImportXL
            // 
            this.adxImportXL.Caption = "Import from Availability Sheet";
            this.adxImportXL.Id = "adxRibbonButton_8c1d915dd9a74f43b56f48fea09f25b2";
            this.adxImportXL.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportXL.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxImportXL.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportXL_OnClick);
            // 
            // adxImportSchools
            // 
            this.adxImportSchools.Caption = "Import Schools";
            this.adxImportSchools.Id = "adxRibbonButton_bc74cfe469fa4a51861db52615a98902";
            this.adxImportSchools.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportSchools.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxImportSchools.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportSchools_OnClick);
            // 
            // adxImportKeyRef
            // 
            this.adxImportKeyRef.Caption = "Import Key Refs";
            this.adxImportKeyRef.Id = "adxRibbonButton_2c1b57b139ce4e95908deb5cf24ccac6";
            this.adxImportKeyRef.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportKeyRef.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxImportKeyRef.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportKeyRef_OnClick);
            // 
            // adxImport
            // 
            this.adxImport.Caption = "Import from Excel";
            this.adxImport.Id = "adxRibbonButton_e3ccc303b7d645d9b2ddb9db31c95e78";
            this.adxImport.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImport.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxImport.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImport_OnClick);
            // 
            // adxEditSchool
            // 
            this.adxEditSchool.Caption = "Edit Schools";
            this.adxEditSchool.Id = "adxRibbonButton_f7a0bbf4cfcf4c06a068b35846838e5a";
            this.adxEditSchool.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxEditSchool.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxEditSchool.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxEditSchool_OnClick);
            // 
            // adxProcess
            // 
            this.adxProcess.Caption = "Process Teachers";
            this.adxProcess.Id = "adxRibbonButton_ecb2644624dc4d8cbb57063b2b841a00";
            this.adxProcess.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxProcess.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxProcess.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxProcess_OnClick);
            // 
            // adxPivot
            // 
            this.adxPivot.Caption = "Pivot Grid";
            this.adxPivot.Id = "adxRibbonButton_0b7f30f7815047beaeae043c569fcf44";
            this.adxPivot.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxPivot.Ribbons = ((AddinExpress.MSO.ADXRibbons)(((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose) 
            | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.adxPivot.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxPivot_OnClick);
            // 
            // AddinModule
            // 
            this.AddinName = "RedboxAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;
            this.AddinInitialize += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinInitialize);
            this.AddinStartupComplete += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinStartupComplete);

        }
        #endregion

        #region Add-in Express automatic code

        // Required by Add-in Express - do not modify
        // the methods within this region

        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }

        [ComRegisterFunctionAttribute]
        public static void AddinRegister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
        }

        [ComUnregisterFunctionAttribute]
        public static void AddinUnregister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
        }

        public override void UninstallControls()
        {
            base.UninstallControls();
        }

        #endregion

        public static new AddinModule CurrentInstance
        {
            get
            {
                return AddinExpress.MSO.ADXAddinModule.CurrentInstance as AddinModule;
            }
        }

        public Outlook._Application OutlookApp
        {
            get
            {
                return (HostApplication as Outlook._Application);
            }
        }

        private void AddinModule_AddinInitialize(object sender, EventArgs e)
        {
            try
            {
                Globals.objOutlook = (Outlook._Application)HostApplication;
                Globals.objNS = Globals.objOutlook.GetNamespace("MAPI");
            }
            catch (Exception) { return; }

            //switch off commandbar if OL2010 or above
            if (commandBarRedboxAddin.UseForRibbon && this.HostMajorVersion > 12) commandBarRedboxAddin.UseForRibbon = false;

            Debug.InitialiseTrace();
            DavSettings.LoadDavSettings();
            Debug.SetDebugLevel();
            var mapiObject = Globals.objNS.MAPIOBJECT;
            RedemptionCode.InitialiseRedemption(ref mapiObject);
        }

        private void AddinModule_AddinStartupComplete(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager();
            dbm.CheckDatabase();
        }

        private void adxRibbonButton1_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmViewContact frmObj = new frmViewContact();
            frmObj.ShowDialog();
            // var form = (frmContactExp)this.adxOlFormsManagerRedbox.Items[1].GetCurrentForm(AddinExpress.OL.EmbeddedFormStates.Visible);            
        }

        private void adxOlFormsManagerRedbox_ADXBeforeFolderSwitchEx(object sender, AddinExpress.OL.BeforeFolderSwitchExEventArgs args)
        {
            Outlook.MAPIFolder destFolder = null;
            try
            {
                destFolder = args.DstFolder as Outlook.MAPIFolder;
                if (destFolder.Name == "Redbox Contacts")
                {
                    this.olFrmReminders.Enabled = false;
                    this.olFrmExplorer.Enabled = true;
                }
                else if (destFolder.Name == "Redbox Reminders")
                {
                    this.olFrmReminders.Enabled = true;
                    this.olFrmExplorer.Enabled = false;
                }
                else
                {
                    this.olFrmExplorer.Enabled = false;
                    this.olFrmReminders.Enabled = false;
                }
                Application.DoEvents();
            }
            finally
            {
                if (destFolder != null) Marshal.ReleaseComObject(destFolder);
            }

        }

        private void adxRibbonButton2_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            Outlook.Explorer currentExplorer = null;
            Outlook.MAPIFolder redboxFolder = null;
            Outlook.MAPIFolder oInbox = null;
            Outlook.MAPIFolder oPublicFolderRoot = null;
            Outlook.Folders oFolders = null;
            try
            {
                currentExplorer = Globals.objOutlook.ActiveExplorer();
                oInbox = Globals.objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                oPublicFolderRoot = (Outlook.MAPIFolder)oInbox.Parent;
                oFolders = oPublicFolderRoot.Folders;
                bool folderFound = false;

                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder Folder in oFolders)
                {
                    try
                    {
                        string foldername = Folder.Name;
                        if (foldername == "Redbox Contacts")
                        {
                            currentExplorer.SelectFolder(Folder);
                            folderFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in the folder Loop :- " + ex.Message);
                    }
                    finally
                    {
                        if (Folder != null) Marshal.ReleaseComObject(Folder);
                    }
                }
                if (!folderFound)
                {
                    redboxFolder = oFolders.Add("Redbox Contacts");
                    currentExplorer.SelectFolder(redboxFolder);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error when showing the redbox explorer :- " + ex.Message);
            }
            finally
            {
                if (redboxFolder != null) Marshal.ReleaseComObject(redboxFolder);
                if (currentExplorer != null) Marshal.ReleaseComObject(currentExplorer);
                GC.Collect();
            }

        }

        private void adxRibbonButton1_OnClick_1(object sender, IRibbonControl control, bool pressed)
        {
            Outlook.Explorer currentExplorer = null;
            Outlook.MAPIFolder redboxFolder = null;
            Outlook.MAPIFolder oInbox = null;
            Outlook.MAPIFolder oPublicFolderRoot = null;
            Outlook.Folders oFolders = null;
            try
            {
                currentExplorer = Globals.objOutlook.ActiveExplorer();
                oInbox = Globals.objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                oPublicFolderRoot = (Outlook.MAPIFolder)oInbox.Parent;
                oFolders = oPublicFolderRoot.Folders;
                bool folderFound = false;

                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder Folder in oFolders)
                {
                    try
                    {
                        string foldername = Folder.Name;
                        if (foldername == "Redbox Reminders")
                        {
                            currentExplorer.SelectFolder(Folder);
                            folderFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in the folder Loop :- " + ex.Message);
                    }
                    finally
                    {
                        if (Folder != null) Marshal.ReleaseComObject(Folder);
                    }
                }
                if (!folderFound)
                {
                    redboxFolder = oFolders.Add("Redbox Reminders");
                    currentExplorer.SelectFolder(redboxFolder);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error when showing the redbox explorer :- " + ex.Message);
            }
            finally
            {
                if (redboxFolder != null) Marshal.ReleaseComObject(redboxFolder);
                if (currentExplorer != null) Marshal.ReleaseComObject(currentExplorer);
                GC.Collect();
            }
        }

        private void rbAbout_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmAbout frmObj = new frmAbout();
            frmObj.Show();
        }

        private void cbBtnAbout_Click(object sender)
        {
            frmAbout frmObj = new frmAbout();
            frmObj.Show();
        }

        private void cbBtnNewReminders_Click(object sender)
        {
            Outlook.Explorer currentExplorer = null;
            Outlook.MAPIFolder redboxFolder = null;
            Outlook.MAPIFolder oInbox = null;
            Outlook.MAPIFolder oPublicFolderRoot = null;
            Outlook.Folders oFolders = null;
            try
            {
                currentExplorer = Globals.objOutlook.ActiveExplorer();
                oInbox = Globals.objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                oPublicFolderRoot = (Outlook.MAPIFolder)oInbox.Parent;
                oFolders = oPublicFolderRoot.Folders;
                bool folderFound = false;

                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder Folder in oFolders)
                {
                    try
                    {
                        string foldername = Folder.Name;
                        if (foldername == "Redbox Reminders")
                        {
                            currentExplorer.SelectFolder(Folder);
                            folderFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in the folder Loop :- " + ex.Message);
                    }
                    finally
                    {
                        if (Folder != null) Marshal.ReleaseComObject(Folder);
                    }
                }
                if (!folderFound)
                {
                    redboxFolder = oFolders.Add("Redbox Reminders");
                    currentExplorer.SelectFolder(redboxFolder);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error when showing the redbox explorer :- " + ex.Message);
            }
            finally
            {
                if (redboxFolder != null) Marshal.ReleaseComObject(redboxFolder);
                if (currentExplorer != null) Marshal.ReleaseComObject(currentExplorer);
                GC.Collect();
            }
        }

        private void cbBtnContacts_Click(object sender)
        {
            Outlook.Explorer currentExplorer = null;
            Outlook.MAPIFolder redboxFolder = null;
            Outlook.MAPIFolder oInbox = null;
            Outlook.MAPIFolder oPublicFolderRoot = null;
            Outlook.Folders oFolders = null;
            try
            {
                currentExplorer = Globals.objOutlook.ActiveExplorer();
                oInbox = Globals.objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                oPublicFolderRoot = (Outlook.MAPIFolder)oInbox.Parent;
                oFolders = oPublicFolderRoot.Folders;
                bool folderFound = false;

                foreach (Microsoft.Office.Interop.Outlook.MAPIFolder Folder in oFolders)
                {
                    try
                    {
                        string foldername = Folder.Name;
                        if (foldername == "Redbox Contacts")
                        {
                            currentExplorer.SelectFolder(Folder);
                            folderFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.DebugMessage(2, "Error in the folder Loop :- " + ex.Message);
                    }
                    finally
                    {
                        if (Folder != null) Marshal.ReleaseComObject(Folder);
                    }
                }
                if (!folderFound)
                {
                    redboxFolder = oFolders.Add("Redbox Contacts");
                    currentExplorer.SelectFolder(redboxFolder);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error when showing the redbox explorer :- " + ex.Message);
            }
            finally
            {
                if (redboxFolder != null) Marshal.ReleaseComObject(redboxFolder);
                if (currentExplorer != null) Marshal.ReleaseComObject(currentExplorer);
                GC.Collect();
            }
        }

        private void cbBtnNewContact_Click(object sender)
        {
            frmViewContact frmObj = new frmViewContact();
            frmObj.ShowDialog();
        }

        private void rbCheckForUpdates_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            CheckUpdates();
        }

        public void CheckUpdates()
        {
            try
            {
                if (IsMSINetworkDeployed() & IsMSIUpdatable())
                {
                    string updateUrl = CheckForMSIUpdates();

                    if ((string.IsNullOrEmpty(updateUrl) == false))
                    {
                        if (MessageBox.Show("A new version of the Outlook Add-In was found. Would you like to install the update?", "Redbox Addin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(updateUrl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No updates found for the Outlook Add-In", "Redbox Addin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error checking For Updates : " + ex.Message);
            }
        }

        private void cbBtnCheckForUpdates_Click(object sender)
        {
            CheckUpdates();
        }

        private void adxNewRequest_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmNewRequest fnr = Application.OpenForms["frmNewRequest"] as frmNewRequest;
            if (fnr == null)
            {
                fnr = new frmNewRequest();
                fnr.Show();
            }
            else
            {
                fnr.BringToFront();
            }
        }

        private void adxImportXL_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.Import(openFileDialog1.FileName);
            }
        }

        private void adxImport_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmImport fi = Application.OpenForms["frmImport"] as frmImport;
            if (fi == null)
            {
                fi = new frmImport();
                fi.Show();
            }
            else
            {
                fi.BringToFront();
            }
        }

        private void adxImportSchools_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (ExcelImporter.ImportSchools(openFileDialog1.FileName)) MessageBox.Show("Imported");
                else MessageBox.Show("Import failed");
                
            }
        }

        private void adxEditSchool_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmEditSchool es = Application.OpenForms["frmEditSchool"] as frmEditSchool;
            if (es == null)
            {
                es = new frmEditSchool();
                es.Show();
            }
            else
            {
                es.BringToFront();
            }
        }

        private void adxProcess_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            DBManager dbm = new DBManager();
            dbm.CheckAndUpdateTeachers();

        }

        private void adxBookings_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmViewBookings vb = Application.OpenForms["frmViewBookings"] as frmViewBookings;
            if (vb == null)
            {
                vb = new frmViewBookings();
                vb.Show();
            }
            else
            {
                vb.BringToFront();
            }
        }

        private void adxImportKeyRef_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.ImportKeyRefs(openFileDialog1.FileName);
            }
        }

        private void adxAvail_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmAvailabilitySheet av = Application.OpenForms["frmAvailabilitySheet"] as frmAvailabilitySheet;
            if (av == null)
            {
                av = new frmAvailabilitySheet();
                av.Show();
            }
            else
            {
                av.BringToFront();
            }
        }

        private void adxLoadPlan_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmLoadPlan lp = Application.OpenForms["frmLoadPlan"] as frmLoadPlan;
            if (lp == null)
            {
                lp = new frmLoadPlan();
                lp.Show();
            }
            else
            {
                lp.BringToFront();
            }
        }

        private void adxPivot_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmLoadPivot lp = Application.OpenForms["frmLoadPivot"] as frmLoadPivot;
            if (lp == null)
            {
                lp = new frmLoadPivot();
                lp.Show();
            }
            else
            {
                lp.BringToFront();
            }
        }




    }
}

