﻿using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Outlook = Microsoft.Office.Interop.Outlook;
using RedboxAddin.Presentation;
using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
using System.Linq;
using System.Collections.Generic;



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

        private ADXRibbonTab adxTabMail;
        private ADXRibbonGroup adxGrpRedbox;
        private ADXRibbonButton adxRibbonButtonAddNew;
        private AddinExpress.OL.ADXOlFormsManager adxOlFormsManagerRedbox;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmBotNavi;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmExplorer;
        private ADXRibbonButton adxContacts;
        private ImageList imageList48;
        private AddinExpress.OL.ADXOlFormsCollectionItem olFrmReminders;
        private ADXRibbonButton adxReminders;
        private ADXRibbonButton rbAbout;
        private ADXOlExplorerCommandBar commandBarRedboxAddin;
        private ADXCommandBarButton cbBtnNewContact;
        private ADXCommandBarButton cbBtnContacts;
        private ADXCommandBarButton cbBtnNewReminders;
        private ADXCommandBarButton cbBtnAbout;
        private ImageList imageList16;
        private ADXRibbonButton rbCheckForUpdates;
        private ADXCommandBarButton cbBtnCheckForUpdates;
        private ADXRibbonTab adxtab;
        private ADXRibbonGroup adxGRPRedbox2;
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
        private ADXRibbonButton adxImportContacts;
        private ADXRibbonButton adxUpdateContacts;
        private ADXRibbonButton adxMarkCurrent;
        private ADXRibbonButton adxTimeSheet;
        private ADXRibbonButton adxCheckContactnames;
        private ADXRibbonButton adxSendVetting;
        private ADXRibbonTab adxTabAppt;
        private ADXRibbonMenu adxRibbonMenu1;
        private ADXRibbonButton adxTeacherContacts;
        private ADXRibbonButton adxSchoolContacts;
        private ImageList imageList32;

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
            this.adxTabMail = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxGrpRedbox = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.adxRibbonButtonAddNew = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList48 = new System.Windows.Forms.ImageList(this.components);
            this.adxContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxReminders = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.rbCheckForUpdates = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
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
            this.adxGRPRedbox2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.adxNewRequest = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTeacherUpdate = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxBookings = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxAvail = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxLoadPlan = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxPivot = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTimeSheet = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxSendVetting = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxOptions = new AddinExpress.MSO.ADXRibbonMenu(this.components);
            this.adxImportXL = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportSchools = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportKeyRef = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImport = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxEditSchool = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxProcess = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxUpdateContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxMarkCurrent = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxCheckContactnames = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTabAppt = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxRibbonMenu1 = new AddinExpress.MSO.ADXRibbonMenu(this.components);
            this.adxTeacherContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxSchoolContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            // 
            // adxTabMail
            // 
            this.adxTabMail.Caption = "Redbox";
            this.adxTabMail.Controls.Add(this.adxGrpRedbox);
            this.adxTabMail.Id = "adxRibbonTab_53cd27d9f4444a159945725686081d67";
            this.adxTabMail.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxGrpRedbox
            // 
            this.adxGrpRedbox.Caption = "Redbox";
            this.adxGrpRedbox.Controls.Add(this.adxRibbonButtonAddNew);
            this.adxGrpRedbox.Controls.Add(this.adxContacts);
            this.adxGrpRedbox.Controls.Add(this.adxReminders);
            this.adxGrpRedbox.Controls.Add(this.rbCheckForUpdates);
            this.adxGrpRedbox.Controls.Add(this.rbAbout);
            this.adxGrpRedbox.Id = "adxRibbonGroup_6734d4c82ad242c3877678c1deb9c903";
            this.adxGrpRedbox.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxGrpRedbox.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxRibbonButtonAddNew
            // 
            this.adxRibbonButtonAddNew.Caption = "Add New Contact";
            this.adxRibbonButtonAddNew.Id = "adxRibbonButton_49bde1ee56194b4db27be190ce71ad0a";
            this.adxRibbonButtonAddNew.Image = 0;
            this.adxRibbonButtonAddNew.ImageList = this.imageList48;
            this.adxRibbonButtonAddNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButtonAddNew.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxRibbonButtonAddNew.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxRibbonButtonAddNew.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton1_OnClick);
            // 
            // imageList48
            // 
            this.imageList48.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList48.ImageStream")));
            this.imageList48.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList48.Images.SetKeyName(0, "1354806935_contact-new.png");
            this.imageList48.Images.SetKeyName(1, "1354807003_contacts.png");
            this.imageList48.Images.SetKeyName(2, "1354812073_stock_appointment-reminder.png");
            this.imageList48.Images.SetKeyName(3, "Actions-help-about.ico");
            this.imageList48.Images.SetKeyName(4, "1359478888_arrow_circle_double.png");
            this.imageList48.Images.SetKeyName(5, "1393346605_Teacher.png");
            // 
            // adxContacts
            // 
            this.adxContacts.Caption = "Contacts";
            this.adxContacts.Id = "adxRibbonButton_d92afb6db82e440b9e5ddef80c82acc5";
            this.adxContacts.Image = 1;
            this.adxContacts.ImageList = this.imageList48;
            this.adxContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxContacts.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxContacts.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton2_OnClick);
            // 
            // adxReminders
            // 
            this.adxReminders.Caption = "Reminders";
            this.adxReminders.Id = "adxRibbonButton_f7e5bba1d2434cada191792dda851b4d";
            this.adxReminders.Image = 2;
            this.adxReminders.ImageList = this.imageList48;
            this.adxReminders.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxReminders.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxReminders.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxReminders.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonButton1_OnClick_1);
            // 
            // rbCheckForUpdates
            // 
            this.rbCheckForUpdates.Caption = "Check for updates";
            this.rbCheckForUpdates.Id = "adxRibbonButton_c3509caccef84deaa985738557cfdee5";
            this.rbCheckForUpdates.Image = 4;
            this.rbCheckForUpdates.ImageList = this.imageList16;
            this.rbCheckForUpdates.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.rbCheckForUpdates.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.rbCheckForUpdates.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.rbCheckForUpdates_OnClick);
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "1355480871_Information.png");
            this.imageList16.Images.SetKeyName(1, "1355480886_alarm-clock--pencil.png");
            this.imageList16.Images.SetKeyName(2, "1355480893_contact-new.png");
            this.imageList16.Images.SetKeyName(3, "1355480900_contact.png");
            this.imageList16.Images.SetKeyName(4, "1359478888_arrow_circle_double.png");
            this.imageList16.Images.SetKeyName(5, "status.png");
            // 
            // rbAbout
            // 
            this.rbAbout.Caption = "About";
            this.rbAbout.Id = "adxRibbonButton_2935eab4f09b4c25a9abeceb0c79dc52";
            this.rbAbout.Image = 3;
            this.rbAbout.ImageList = this.imageList48;
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
            this.commandBarRedboxAddin.UpdateCounter = 16;
            // 
            // cbBtnNewContact
            // 
            this.cbBtnNewContact.Caption = "Add New Contact";
            this.cbBtnNewContact.ControlTag = "49f434a7-5fd1-47dc-a5dd-e2596bd7ba7c";
            this.cbBtnNewContact.Image = 2;
            this.cbBtnNewContact.ImageList = this.imageList16;
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
            this.cbBtnContacts.ImageList = this.imageList16;
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
            this.cbBtnNewReminders.ImageList = this.imageList16;
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
            this.cbBtnCheckForUpdates.ImageList = this.imageList16;
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
            this.cbBtnAbout.ImageList = this.imageList16;
            this.cbBtnAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cbBtnAbout.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this.cbBtnAbout.Temporary = true;
            this.cbBtnAbout.UpdateCounter = 12;
            this.cbBtnAbout.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.cbBtnAbout_Click);
            // 
            // adxtab
            // 
            this.adxtab.Caption = "Contacts";
            this.adxtab.Controls.Add(this.adxGRPRedbox2);
            this.adxtab.Id = "adxRibbonTab_6009b89e68584fae8b43fda66b3b5ffb";
            this.adxtab.IdMso = "TabMail";
            this.adxtab.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxGRPRedbox2
            // 
            this.adxGRPRedbox2.Caption = "Redbox";
            this.adxGRPRedbox2.Controls.Add(this.adxNewRequest);
            this.adxGRPRedbox2.Controls.Add(this.adxTeacherUpdate);
            this.adxGRPRedbox2.Controls.Add(this.adxBookings);
            this.adxGRPRedbox2.Controls.Add(this.adxAvail);
            this.adxGRPRedbox2.Controls.Add(this.adxOptions);
            this.adxGRPRedbox2.Controls.Add(this.adxTeacherContacts);
            this.adxGRPRedbox2.Controls.Add(this.adxSchoolContacts);
            this.adxGRPRedbox2.Controls.Add(this.adxRibbonMenu1);
            this.adxGRPRedbox2.Id = "adxRibbonGroup_b645fd8a59e6427e97a0a4d666af69d2";
            this.adxGRPRedbox2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxGRPRedbox2.InsertBeforeIdMso = "GroupMailDelete";
            this.adxGRPRedbox2.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxNewRequest
            // 
            this.adxNewRequest.Caption = "New Request";
            this.adxNewRequest.Id = "adxRibbonButton_6bd6e6c1524f424690d570077e270772";
            this.adxNewRequest.Image = 13;
            this.adxNewRequest.ImageList = this.imageList32;
            this.adxNewRequest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxNewRequest.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxNewRequest.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxNewRequest.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxNewRequest_OnClick);
            // 
            // adxTeacherUpdate
            // 
            this.adxTeacherUpdate.Caption = "Teacher Update";
            this.adxTeacherUpdate.Id = "adxRibbonButton_3cc7dd443a5a4d3188c35ce21f8f7907";
            this.adxTeacherUpdate.Image = 5;
            this.adxTeacherUpdate.ImageList = this.imageList48;
            this.adxTeacherUpdate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxTeacherUpdate.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxTeacherUpdate.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.adxTeacherUpdate.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxTeacherUpdate_OnClick);
            // 
            // adxBookings
            // 
            this.adxBookings.Caption = "View Bookings";
            this.adxBookings.Id = "adxRibbonButton_84914fb391a242d6a1a80e9d661c9eb7";
            this.adxBookings.Image = 14;
            this.adxBookings.ImageList = this.imageList32;
            this.adxBookings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxBookings.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxBookings.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxBookings_OnClick);
            // 
            // adxAvail
            // 
            this.adxAvail.Caption = "Availability Sheet";
            this.adxAvail.Id = "adxRibbonButton_bb8da1a4e609499396d30b190eaa54e2";
            this.adxAvail.Image = 8;
            this.adxAvail.ImageList = this.imageList32;
            this.adxAvail.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxAvail.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxAvail.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxAvail_OnClick);
            // 
            // adxLoadPlan
            // 
            this.adxLoadPlan.Caption = "Load Plan";
            this.adxLoadPlan.Id = "adxRibbonButton_f2091261af184203ba2efe10ba3a1b1e";
            this.adxLoadPlan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxLoadPlan.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxLoadPlan.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxLoadPlan_OnClick);
            // 
            // adxPivot
            // 
            this.adxPivot.Caption = "Pivot Grid";
            this.adxPivot.Id = "adxRibbonButton_0b7f30f7815047beaeae043c569fcf44";
            this.adxPivot.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxPivot.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxPivot.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxPivot_OnClick);
            // 
            // adxTimeSheet
            // 
            this.adxTimeSheet.Caption = "Time Sheets";
            this.adxTimeSheet.Id = "adxRibbonButton_2117e4350adc466b9996232a245b3394";
            this.adxTimeSheet.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxTimeSheet.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxTimeSheet.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxTimeSheet_OnClick);
            // 
            // adxSendVetting
            // 
            this.adxSendVetting.Caption = "Send Vetting Details";
            this.adxSendVetting.Id = "adxRibbonButton_d85eda28b374424aa2acc3bfba75d0e2";
            this.adxSendVetting.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxSendVetting.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxSendVetting.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxSendVetting_OnClick);
            // 
            // adxOptions
            // 
            this.adxOptions.Caption = "Admin";
            this.adxOptions.Controls.Add(this.adxLoadPlan);
            this.adxOptions.Controls.Add(this.adxTimeSheet);
            this.adxOptions.Controls.Add(this.adxSendVetting);
            this.adxOptions.Controls.Add(this.adxEditSchool);
            this.adxOptions.Id = "adxRibbonMenu_c2f3769eeaa34668aca908c7e5314288";
            this.adxOptions.Image = 5;
            this.adxOptions.ImageList = this.imageList32;
            this.adxOptions.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxOptions.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxImportXL
            // 
            this.adxImportXL.Caption = "Import from Availability Sheet";
            this.adxImportXL.Id = "adxRibbonButton_8c1d915dd9a74f43b56f48fea09f25b2";
            this.adxImportXL.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportXL.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxImportXL.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportXL_OnClick);
            // 
            // adxImportSchools
            // 
            this.adxImportSchools.Caption = "Import Schools";
            this.adxImportSchools.Id = "adxRibbonButton_bc74cfe469fa4a51861db52615a98902";
            this.adxImportSchools.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportSchools.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxImportSchools.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportSchools_OnClick);
            // 
            // adxImportKeyRef
            // 
            this.adxImportKeyRef.Caption = "Import Key Refs";
            this.adxImportKeyRef.Id = "adxRibbonButton_2c1b57b139ce4e95908deb5cf24ccac6";
            this.adxImportKeyRef.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportKeyRef.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxImportKeyRef.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportKeyRef_OnClick);
            // 
            // adxImport
            // 
            this.adxImport.Caption = "Import from Excel";
            this.adxImport.Id = "adxRibbonButton_e3ccc303b7d645d9b2ddb9db31c95e78";
            this.adxImport.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImport.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxImport.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImport_OnClick);
            // 
            // adxEditSchool
            // 
            this.adxEditSchool.Caption = "Edit Schools";
            this.adxEditSchool.Id = "adxRibbonButton_f7a0bbf4cfcf4c06a068b35846838e5a";
            this.adxEditSchool.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxEditSchool.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxEditSchool.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxEditSchool_OnClick);
            // 
            // adxProcess
            // 
            this.adxProcess.Caption = "Process Teachers";
            this.adxProcess.Id = "adxRibbonButton_ecb2644624dc4d8cbb57063b2b841a00";
            this.adxProcess.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxProcess.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxProcess.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxProcess_OnClick);
            // 
            // adxImportContacts
            // 
            this.adxImportContacts.Caption = "Import Contacts";
            this.adxImportContacts.Id = "adxRibbonButton_038dc2864f8048b98526fdf69e514fd1";
            this.adxImportContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxImportContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxImportContacts.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxImportContacts_OnClick);
            // 
            // adxUpdateContacts
            // 
            this.adxUpdateContacts.Caption = "Clean Contact Names";
            this.adxUpdateContacts.Id = "adxRibbonButton_afb82f1c8fe342c98a8899b512567222";
            this.adxUpdateContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxUpdateContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxUpdateContacts.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxUpdateContacts_OnClick);
            // 
            // adxMarkCurrent
            // 
            this.adxMarkCurrent.Caption = "MarkAllCurrent";
            this.adxMarkCurrent.Id = "adxRibbonButton_7f8c8205befe40f786e6de61abe4bd3c";
            this.adxMarkCurrent.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxMarkCurrent.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxMarkCurrent.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxMarkCurrent_OnClick);
            // 
            // adxCheckContactnames
            // 
            this.adxCheckContactnames.Caption = "Check Contact Names in Excel";
            this.adxCheckContactnames.Id = "adxRibbonButton_4b3ceafd9086415398a453218d062d5d";
            this.adxCheckContactnames.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCheckContactnames.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxCheckContactnames.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxCheckContactnames_OnClick);
            // 
            // adxTabAppt
            // 
            this.adxTabAppt.Caption = "adxRibbonTab1";
            this.adxTabAppt.Id = "adxRibbonTab_b1048884135f4ceabfd13019f1b726d7";
            this.adxTabAppt.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // adxRibbonMenu1
            // 
            this.adxRibbonMenu1.Caption = "Maintenance";
            this.adxRibbonMenu1.Controls.Add(this.adxImportXL);
            this.adxRibbonMenu1.Controls.Add(this.adxImportSchools);
            this.adxRibbonMenu1.Controls.Add(this.adxImportKeyRef);
            this.adxRibbonMenu1.Controls.Add(this.adxImport);
            this.adxRibbonMenu1.Controls.Add(this.adxProcess);
            this.adxRibbonMenu1.Controls.Add(this.adxImportContacts);
            this.adxRibbonMenu1.Controls.Add(this.adxUpdateContacts);
            this.adxRibbonMenu1.Controls.Add(this.adxMarkCurrent);
            this.adxRibbonMenu1.Controls.Add(this.adxCheckContactnames);
            this.adxRibbonMenu1.Controls.Add(this.adxPivot);
            this.adxRibbonMenu1.Id = "adxRibbonMenu_ce459db124dd49b687736d6d60802b44";
            this.adxRibbonMenu1.Image = 17;
            this.adxRibbonMenu1.ImageList = this.imageList32;
            this.adxRibbonMenu1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonMenu1.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxTeacherContacts
            // 
            this.adxTeacherContacts.Caption = "Teacher Contacts";
            this.adxTeacherContacts.Id = "adxRibbonButton_37a1b212a62b432f9f97155d44de1c9c";
            this.adxTeacherContacts.Image = 15;
            this.adxTeacherContacts.ImageList = this.imageList32;
            this.adxTeacherContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxTeacherContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxSchoolContacts
            // 
            this.adxSchoolContacts.Caption = "School Contacts";
            this.adxSchoolContacts.Id = "adxRibbonButton_4583c1d3b7e94cdabe3c3da91a6fd656";
            this.adxSchoolContacts.Image = 16;
            this.adxSchoolContacts.ImageList = this.imageList32;
            this.adxSchoolContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxSchoolContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "1393347085_notification_add.png");
            this.imageList32.Images.SetKeyName(1, "1393347046_notification_error.png");
            this.imageList32.Images.SetKeyName(2, "1393346933_file_search.png");
            this.imageList32.Images.SetKeyName(3, "1393346921_folder_empty.png");
            this.imageList32.Images.SetKeyName(4, "1393346907_user_add.png");
            this.imageList32.Images.SetKeyName(5, "1393346996_document_edit.png");
            this.imageList32.Images.SetKeyName(6, "1393346876_player_play.png");
            this.imageList32.Images.SetKeyName(7, "1393346972_notification_done.png");
            this.imageList32.Images.SetKeyName(8, "1393346966_user_manage.png");
            this.imageList32.Images.SetKeyName(9, "1393346961_message.png");
            this.imageList32.Images.SetKeyName(10, "1393346841_notification_warning.png");
            this.imageList32.Images.SetKeyName(11, "1393346941_mail_send.png");
            this.imageList32.Images.SetKeyName(12, "1393346804_mail.png");
            this.imageList32.Images.SetKeyName(13, "1393346781_file_add.png");
            this.imageList32.Images.SetKeyName(14, "1393346767_folder_search.png");
            this.imageList32.Images.SetKeyName(15, "1393346492_Teacher.png");
            this.imageList32.Images.SetKeyName(16, "1393346122_Two-storied_house.png");
            this.imageList32.Images.SetKeyName(17, "1393346665_gear.png");
            // 
            // AddinModule
            // 
            this.AddinName = "RedboxAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;
            this.AddinInitialize += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinInitialize);

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
            frmMasterBooking fnr = Application.OpenForms["frmNewRequest"] as frmMasterBooking;
            if (fnr == null)
            {
                fnr = new frmMasterBooking();
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
                ExcelImporter.Import(openFileDialog1.FileName,false,false,false,0,280);
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
            LINQmanager.CheckAndUpdateTeachers();
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

        private void adxTimeSheet_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmTimeSheets ts = Application.OpenForms["frmTimeSheets"] as frmTimeSheets;
            if (ts == null)
            {
                ts = new frmTimeSheets();
                ts.Show();
            }
            else
            {
                ts.BringToFront();
            }
        }
        private void adxSendVetting_OnClick(object sender, IRibbonControl control, bool pressed)
        {

            frmSendVetting sv = Application.OpenForms["frmSendVetting"] as frmSendVetting;
            if (sv == null)
            {
                sv = new frmSendVetting();
                sv.Show();
            }
            else
            {
                sv.BringToFront();
            }
        }

        private void adxTeacherUpdate_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmTeacherUpdate lp = Application.OpenForms["frmTeacherUpdate"] as frmTeacherUpdate;
            if (lp == null)
            {
                lp = new frmTeacherUpdate();
                lp.Show();
            }
            else
            {
                lp.BringToFront();
            }
        }

        private void adxImportContacts_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            if (MessageBox.Show("This will add new contacts to the current contact data and should only be used before the system is live." +
                "/RDo you want to proceed?", "Carefull!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OLDDBManager odb = new OLDDBManager();
                List<RContact> contacts = odb.GetOldContacts();

                DBManager db = new DBManager();
                int count = 0;
                foreach (RContact c in contacts)
                {
                    count+=1;
                    db.AddContact(c);
                }

                MessageBox.Show(count.ToString() + " contacts added.");

            }
        }

        private void adxUpdateContacts_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            DBManager db = new DBManager();
            db.CleanContactNames();

        }

        private void adxMarkCurrent_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            DBManager db = new DBManager();
            db.MarkAllCurrent();
        }

        private void adxCheckContactnames_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.CheckNamesInExcel(openFileDialog1.FileName);
            }
            
        }

      

       




    }
}

