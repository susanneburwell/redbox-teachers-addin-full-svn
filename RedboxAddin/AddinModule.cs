using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;
using RedboxAddin.Presentation;
using RedboxAddin.BL;
using RedboxAddin.DL;
using RedboxAddin.Models;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;

//2.0.22 10th Mar 2014 DT  Fixed colours in availability sheet
//2.0.23 17th Mar 2014 DT  Updates to Master Booking form for existing items. Add 'Attend School that has MMRV' checkbox.
//2.0.24 18Mar 2014 DT Change teacher drop down to only include current teachers
//2.0.34 7th May 2014 DT Fix Add School so it works!
//2.0.37 7th May 2014 DT Add option to update or delete bookings from Master Booking View
//2.0.38 13th May 2014 Changes to load plan, timesheets, events added to outlook calendar
//2.0.39 16th May 2014 DT Show guaranteed /offered/accepted in load plan. Fixes to load plan and paysheets. Manage double bookings for half days
//2.0.40 DT show 'Current' in Contacts View
//2.0.41 30th July 2014 DT Fix bug where new contacts were not saving correctly.
//2.0.42 15Aug 2014 DT TA Rates for schools were not saved anywhere. Implemented in database and MasterBooking
//2.0.47 03 Sept 2014 DT Interim build before starting full availability for teachers
//2.0.48 09 Sept 2014 DT Availability includes Guarantee and texted, available, unavailable. New bookings are provisional and confirmed plus other bug fixes
//2.0.49 10Sept14 DT Swapped to per machine installation. Master bookings can now update rate and charge for all sub bookings
//2.0.52 10Sept14 DT Per machine installation and relevant changes to file locations (Redemption / Settings)
//2.0.53 18Sept14 DT Fixes to invoices and payruns to manage missing data. Password protect totals on load plan.
//2.0.54 18Sept04 DT Add ability to delete individual bookings using the right click key on Masterbookings
//2.0.55 25Sept 2014 Add columns to Contacts View. Bulk update for descritpion. Delete option for schools. Fix save and new.
//                   Bulk delete for individual bookings, Fix dates when selecting, Cancelled bookings management
//2.0.67 14th Nov 2014 Additional payments added to paysheet and invoices as well as load plan.
//2.0.72 15th Dec DT Minor bug fixes after 2.0.71. Time set to 24hour / view bookings filter was erroneously blocked 
//2.0.73    16th Dec 2014 Changed back to per machine installation
//2.0.74 16Dec added missing file to installation (addinexpress toolbar controls)
//2.0.75 30thjan2015 DT Added lots of contact fields for date items checked and updated the vetting email.
//2.0.77 3Feb2015 DT Add summary notes to summary page. Check NoGo when changing teachers. Set status to unassigned when changing teacher. 
//                      Teachers are not permanently deleted but have a flag set to 'Deleted'. 
//                      Don't allow master booking to be deleted if there are past bookings for this master booking
//2.0.78 4Feb2015   DT  Create report to show DBS expiring and LT 12wk/12month. Add coplours to view bookings, Create an option for schools - always pay this rate (£130)
//2.0.80 10Feb2014 DT Three options for creating rate - school rate, teacher rate, calculate rate. Also built ratechange into teacher change

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
        private ADXRibbonMenu adxRibbonMenu1;
        private ADXRibbonButton adxTeacherContacts;
        private ImageList imageList32;
        private ADXOlExplorerCommandBar adxCommandBar2;
        private ADXCommandBarButton adxcbNewRequest;
        private ADXCommandBarButton adxcbTeacherUpdate;
        private ADXCommandBarButton adxcbViewBookings;
        private ADXCommandBarButton adxcbAvail;
        private ADXCommandBarButton adxcbTeacherContacts;
        private ADXCommandBarPopup adxCommandBarPopup1;
        private ADXCommandBarButton adxcbLoadPlan;
        private ADXCommandBarButton adxcbTimeSheets;
        private ADXCommandBarButton adxcbSendVetting;
        private ADXCommandBarButton adxcbEditSchools;
        private ADXCommandBarPopup adxCommandBarPopup2;
        private ADXCommandBarButton adxCommandBarButton10;
        private ADXCommandBarButton adxCommandBarButton11;
        private ADXCommandBarButton adxCommandBarButton12;
        private ADXCommandBarButton adxCommandBarButton13;
        private ADXCommandBarButton adxCommandBarButton14;
        private ADXCommandBarButton adxCommandBarButton15;
        private ADXCommandBarButton adxCommandBarButton16;
        private ADXCommandBarButton adxCommandBarButton17;
        private ADXCommandBarButton adxCommandBarButton18;
        private ADXRibbonButton adxCapture;
        private ADXCommandBarButton adxcbCapture;
        private ADXCommandBarButton adxCommandBarButton1;
        private ADXCommandBarButton adxcbEditPaymentTypes;
        private ADXRibbonButton adxEditPaymentTypes;
        private ADXRibbonButton adxRibbonDCR;
        private ADXCommandBarButton adxDailyContactReport;

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
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.adxTeacherUpdate = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxBookings = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxAvail = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxOptions = new AddinExpress.MSO.ADXRibbonMenu(this.components);
            this.adxLoadPlan = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTimeSheet = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxSendVetting = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxEditSchool = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxEditPaymentTypes = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonDCR = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxTeacherContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonMenu1 = new AddinExpress.MSO.ADXRibbonMenu(this.components);
            this.adxImportXL = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportSchools = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportKeyRef = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImport = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxProcess = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxImportContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxUpdateContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxMarkCurrent = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxCheckContactnames = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxPivot = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxCapture = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxCommandBar2 = new AddinExpress.MSO.ADXOlExplorerCommandBar(this.components);
            this.adxcbNewRequest = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbTeacherUpdate = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbViewBookings = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbAvail = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbTeacherContacts = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbCapture = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarPopup1 = new AddinExpress.MSO.ADXCommandBarPopup(this.components);
            this.adxcbLoadPlan = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbTimeSheets = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbSendVetting = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbEditSchools = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxcbEditPaymentTypes = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxDailyContactReport = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarPopup2 = new AddinExpress.MSO.ADXCommandBarPopup(this.components);
            this.adxCommandBarButton10 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton11 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton12 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton13 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton14 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton15 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton16 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton17 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton18 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxCommandBarButton1 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
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
            this.commandBarRedboxAddin.UpdateCounter = 30;
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
            this.adxGRPRedbox2.Controls.Add(this.adxRibbonMenu1);
            this.adxGRPRedbox2.Controls.Add(this.adxCapture);
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
            // adxOptions
            // 
            this.adxOptions.Caption = "Admin";
            this.adxOptions.Controls.Add(this.adxLoadPlan);
            this.adxOptions.Controls.Add(this.adxTimeSheet);
            this.adxOptions.Controls.Add(this.adxSendVetting);
            this.adxOptions.Controls.Add(this.adxEditSchool);
            this.adxOptions.Controls.Add(this.adxEditPaymentTypes);
            this.adxOptions.Controls.Add(this.adxRibbonDCR);
            this.adxOptions.Id = "adxRibbonMenu_c2f3769eeaa34668aca908c7e5314288";
            this.adxOptions.Image = 5;
            this.adxOptions.ImageList = this.imageList32;
            this.adxOptions.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxOptions.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            // 
            // adxLoadPlan
            // 
            this.adxLoadPlan.Caption = "Load Plan";
            this.adxLoadPlan.Id = "adxRibbonButton_f2091261af184203ba2efe10ba3a1b1e";
            this.adxLoadPlan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxLoadPlan.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxLoadPlan.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxLoadPlan_OnClick);
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
            // adxEditSchool
            // 
            this.adxEditSchool.Caption = "Edit Schools";
            this.adxEditSchool.Id = "adxRibbonButton_f7a0bbf4cfcf4c06a068b35846838e5a";
            this.adxEditSchool.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxEditSchool.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxEditSchool.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxEditSchool_OnClick);
            // 
            // adxEditPaymentTypes
            // 
            this.adxEditPaymentTypes.Caption = "Edit Payment Types";
            this.adxEditPaymentTypes.Id = "adxRibbonButton_4fad77e7b36048b893b8582a9888c3f4";
            this.adxEditPaymentTypes.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxEditPaymentTypes.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxEditPaymentTypes.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxEditPaymentTypes_OnClick);
            // 
            // adxRibbonDCR
            // 
            this.adxRibbonDCR.Caption = "Daily Contact Report";
            this.adxRibbonDCR.Id = "adxRibbonButton_4074e733ed8d467187141363ea75c48b";
            this.adxRibbonDCR.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonDCR.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxRibbonDCR.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxRibbonDCR_OnClick);
            // 
            // adxTeacherContacts
            // 
            this.adxTeacherContacts.Caption = "Teacher Contacts";
            this.adxTeacherContacts.Id = "adxRibbonButton_37a1b212a62b432f9f97155d44de1c9c";
            this.adxTeacherContacts.Image = 15;
            this.adxTeacherContacts.ImageList = this.imageList32;
            this.adxTeacherContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxTeacherContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxTeacherContacts.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxTeacherContacts_OnClick);
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
            // adxPivot
            // 
            this.adxPivot.Caption = "Pivot Grid";
            this.adxPivot.Id = "adxRibbonButton_0b7f30f7815047beaeae043c569fcf44";
            this.adxPivot.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxPivot.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxPivot.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxPivot_OnClick);
            // 
            // adxCapture
            // 
            this.adxCapture.Caption = "Capture Message";
            this.adxCapture.Id = "adxRibbonButton_b440cc27e09a4637ba135bb104383e5f";
            this.adxCapture.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCapture.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookExplorer;
            this.adxCapture.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.adxCapture_OnClick);
            // 
            // adxCommandBar2
            // 
            this.adxCommandBar2.CommandBarName = "Redbox2";
            this.adxCommandBar2.CommandBarTag = "29d0e898-55ff-44f1-8f9b-d8e31af3c190";
            this.adxCommandBar2.Controls.Add(this.adxcbNewRequest);
            this.adxCommandBar2.Controls.Add(this.adxcbTeacherUpdate);
            this.adxCommandBar2.Controls.Add(this.adxcbViewBookings);
            this.adxCommandBar2.Controls.Add(this.adxcbAvail);
            this.adxCommandBar2.Controls.Add(this.adxcbTeacherContacts);
            this.adxCommandBar2.Controls.Add(this.adxcbCapture);
            this.adxCommandBar2.Controls.Add(this.adxCommandBarPopup1);
            this.adxCommandBar2.Controls.Add(this.adxCommandBarPopup2);
            this.adxCommandBar2.Temporary = true;
            this.adxCommandBar2.UpdateCounter = 12;
            // 
            // adxcbNewRequest
            // 
            this.adxcbNewRequest.Caption = "New Request";
            this.adxcbNewRequest.ControlTag = "141759d0-9089-43ac-bfad-4b21bc638a89";
            this.adxcbNewRequest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbNewRequest.Temporary = true;
            this.adxcbNewRequest.UpdateCounter = 6;
            this.adxcbNewRequest.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbNewRequest_Click);
            // 
            // adxcbTeacherUpdate
            // 
            this.adxcbTeacherUpdate.Caption = "Teacher Update";
            this.adxcbTeacherUpdate.ControlTag = "d626eb74-a26b-44bc-8c6e-4c8ecc0c73c9";
            this.adxcbTeacherUpdate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbTeacherUpdate.Temporary = true;
            this.adxcbTeacherUpdate.UpdateCounter = 4;
            this.adxcbTeacherUpdate.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbTeacherUpdate_Click);
            // 
            // adxcbViewBookings
            // 
            this.adxcbViewBookings.Caption = "View Bookings";
            this.adxcbViewBookings.ControlTag = "b87c0c7a-cc27-4c9f-8c00-5d1f5e4b3617";
            this.adxcbViewBookings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbViewBookings.Temporary = true;
            this.adxcbViewBookings.UpdateCounter = 5;
            this.adxcbViewBookings.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbViewBookings_Click);
            // 
            // adxcbAvail
            // 
            this.adxcbAvail.Caption = "Availability Sheet";
            this.adxcbAvail.ControlTag = "9553bc12-cc90-469f-8f3f-308bd5d79481";
            this.adxcbAvail.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbAvail.Temporary = true;
            this.adxcbAvail.UpdateCounter = 4;
            this.adxcbAvail.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbAvail_Click);
            // 
            // adxcbTeacherContacts
            // 
            this.adxcbTeacherContacts.Caption = "Teacher Contacts";
            this.adxcbTeacherContacts.ControlTag = "7b51eb78-2d5d-40ea-8322-3d291ffd3118";
            this.adxcbTeacherContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbTeacherContacts.Temporary = true;
            this.adxcbTeacherContacts.UpdateCounter = 4;
            this.adxcbTeacherContacts.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbTeacherContacts_Click);
            // 
            // adxcbCapture
            // 
            this.adxcbCapture.Caption = "Capture Message";
            this.adxcbCapture.ControlTag = "5324fa66-098b-4c1d-8b2e-1092fccbadac";
            this.adxcbCapture.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbCapture.Temporary = true;
            this.adxcbCapture.UpdateCounter = 4;
            this.adxcbCapture.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbCapture_Click);
            // 
            // adxCommandBarPopup1
            // 
            this.adxCommandBarPopup1.Caption = "Admin";
            this.adxCommandBarPopup1.Controls.Add(this.adxcbLoadPlan);
            this.adxCommandBarPopup1.Controls.Add(this.adxcbTimeSheets);
            this.adxCommandBarPopup1.Controls.Add(this.adxcbSendVetting);
            this.adxCommandBarPopup1.Controls.Add(this.adxcbEditSchools);
            this.adxCommandBarPopup1.Controls.Add(this.adxcbEditPaymentTypes);
            this.adxCommandBarPopup1.Controls.Add(this.adxDailyContactReport);
            this.adxCommandBarPopup1.ControlTag = "049113cd-d4a7-4d94-9e8a-f9bcc775fb2f";
            this.adxCommandBarPopup1.Temporary = true;
            this.adxCommandBarPopup1.UpdateCounter = 1;
            // 
            // adxcbLoadPlan
            // 
            this.adxcbLoadPlan.Caption = "Load Plan";
            this.adxcbLoadPlan.ControlTag = "932c961a-cf73-424c-9bac-b68e7a846f98";
            this.adxcbLoadPlan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbLoadPlan.Temporary = true;
            this.adxcbLoadPlan.UpdateCounter = 4;
            this.adxcbLoadPlan.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbLoadPlan_Click);
            // 
            // adxcbTimeSheets
            // 
            this.adxcbTimeSheets.Caption = "Time Sheets";
            this.adxcbTimeSheets.ControlTag = "30a96596-a5f5-4132-9477-fb1d9a3647f3";
            this.adxcbTimeSheets.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbTimeSheets.Temporary = true;
            this.adxcbTimeSheets.UpdateCounter = 4;
            this.adxcbTimeSheets.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbTimeSheets_Click);
            // 
            // adxcbSendVetting
            // 
            this.adxcbSendVetting.Caption = "Send Vetting Details";
            this.adxcbSendVetting.ControlTag = "721c0252-926f-4add-94e4-512fc1932b88";
            this.adxcbSendVetting.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbSendVetting.Temporary = true;
            this.adxcbSendVetting.UpdateCounter = 4;
            this.adxcbSendVetting.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbSendVetting_Click);
            // 
            // adxcbEditSchools
            // 
            this.adxcbEditSchools.Caption = "Edit Schools";
            this.adxcbEditSchools.ControlTag = "aae4eb01-d310-43bd-a8a6-bba1a4a5d4b4";
            this.adxcbEditSchools.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbEditSchools.Temporary = true;
            this.adxcbEditSchools.UpdateCounter = 4;
            this.adxcbEditSchools.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbEditSchools_Click);
            // 
            // adxcbEditPaymentTypes
            // 
            this.adxcbEditPaymentTypes.Caption = "Edit Payment Types";
            this.adxcbEditPaymentTypes.ControlTag = "18bcc0de-4932-4246-bdbc-e04045ec7dd0";
            this.adxcbEditPaymentTypes.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxcbEditPaymentTypes.Temporary = true;
            this.adxcbEditPaymentTypes.UpdateCounter = 4;
            this.adxcbEditPaymentTypes.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxcbEditPaymentTypes_Click);
            // 
            // adxDailyContactReport
            // 
            this.adxDailyContactReport.Caption = "Daily Contact Report";
            this.adxDailyContactReport.ControlTag = "7772cc69-ef76-4ae7-823e-1b35daac387d";
            this.adxDailyContactReport.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxDailyContactReport.Temporary = true;
            this.adxDailyContactReport.UpdateCounter = 4;
            this.adxDailyContactReport.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxDailyContactReport_Click);
            // 
            // adxCommandBarPopup2
            // 
            this.adxCommandBarPopup2.Caption = "Maintenance";
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton10);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton11);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton12);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton13);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton14);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton15);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton16);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton17);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton18);
            this.adxCommandBarPopup2.Controls.Add(this.adxCommandBarButton1);
            this.adxCommandBarPopup2.ControlTag = "996554fe-616d-4125-9176-8496a9599f0b";
            this.adxCommandBarPopup2.Temporary = true;
            this.adxCommandBarPopup2.UpdateCounter = 4;
            this.adxCommandBarPopup2.Visible = false;
            // 
            // adxCommandBarButton10
            // 
            this.adxCommandBarButton10.Caption = "Import From Availability Sheet";
            this.adxCommandBarButton10.ControlTag = "eddb1f65-501a-48e8-ac1a-68720bb4952f";
            this.adxCommandBarButton10.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton10.Temporary = true;
            this.adxCommandBarButton10.UpdateCounter = 1;
            // 
            // adxCommandBarButton11
            // 
            this.adxCommandBarButton11.Caption = "Import Schools";
            this.adxCommandBarButton11.ControlTag = "4fce2a44-e534-47be-8d3e-af9e4458954f";
            this.adxCommandBarButton11.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton11.Temporary = true;
            this.adxCommandBarButton11.UpdateCounter = 1;
            // 
            // adxCommandBarButton12
            // 
            this.adxCommandBarButton12.Caption = "Import Key Refs";
            this.adxCommandBarButton12.ControlTag = "d9c3d784-6455-413a-8dcf-ecbaee7fe7b2";
            this.adxCommandBarButton12.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton12.Temporary = true;
            this.adxCommandBarButton12.UpdateCounter = 1;
            // 
            // adxCommandBarButton13
            // 
            this.adxCommandBarButton13.Caption = "Import From Excel";
            this.adxCommandBarButton13.ControlTag = "4928c942-170b-4afd-a0b7-121fd5c4e4cd";
            this.adxCommandBarButton13.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton13.Temporary = true;
            this.adxCommandBarButton13.UpdateCounter = 1;
            // 
            // adxCommandBarButton14
            // 
            this.adxCommandBarButton14.Caption = "Process Teachers";
            this.adxCommandBarButton14.ControlTag = "46ff1e1f-dc68-467c-9f21-68b86758f002";
            this.adxCommandBarButton14.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton14.Temporary = true;
            this.adxCommandBarButton14.UpdateCounter = 1;
            // 
            // adxCommandBarButton15
            // 
            this.adxCommandBarButton15.Caption = "Import Contacts";
            this.adxCommandBarButton15.ControlTag = "5abb61e5-d538-406b-b046-7101169d940d";
            this.adxCommandBarButton15.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton15.Temporary = true;
            this.adxCommandBarButton15.UpdateCounter = 1;
            // 
            // adxCommandBarButton16
            // 
            this.adxCommandBarButton16.Caption = "Clean Contact names";
            this.adxCommandBarButton16.ControlTag = "a9aba8eb-90ea-4e4f-bdf3-f328c8dd0e29";
            this.adxCommandBarButton16.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton16.Temporary = true;
            this.adxCommandBarButton16.UpdateCounter = 1;
            // 
            // adxCommandBarButton17
            // 
            this.adxCommandBarButton17.Caption = "Mark All Current";
            this.adxCommandBarButton17.ControlTag = "7946fa1e-c7ef-4ae7-8e14-dc3bc8033db3";
            this.adxCommandBarButton17.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton17.Temporary = true;
            this.adxCommandBarButton17.UpdateCounter = 1;
            // 
            // adxCommandBarButton18
            // 
            this.adxCommandBarButton18.Caption = "Check Contact names in Excel";
            this.adxCommandBarButton18.ControlTag = "21e50b50-3c46-4606-8a39-7cb26c83fd60";
            this.adxCommandBarButton18.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton18.Temporary = true;
            this.adxCommandBarButton18.UpdateCounter = 1;
            // 
            // adxCommandBarButton1
            // 
            this.adxCommandBarButton1.Caption = "Update Database";
            this.adxCommandBarButton1.ControlTag = "e80fbd5c-4cd3-4284-bdad-7a7faead1575";
            this.adxCommandBarButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton1.Temporary = true;
            this.adxCommandBarButton1.UpdateCounter = 3;
            this.adxCommandBarButton1.Click += new AddinExpress.MSO.ADXClick_EventHandler(this.adxCommandBarButton1_Click);
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
                oPublicFolderRoot = oInbox.Parent as Outlook.MAPIFolder;
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
                oPublicFolderRoot = oInbox.Parent as Outlook.MAPIFolder;
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
                oPublicFolderRoot = oInbox.Parent as Outlook.MAPIFolder;
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
            ViewContacts();
        }

        private void adxTeacherContacts_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ViewContacts();
        }

        private void adxcbTeacherContacts_Click(object sender)
        {
            ViewContacts();
        }

        private void cbBtnNewContact_Click(object sender)
        {
            frmViewContact frmObj = new frmViewContact();
            frmObj.ShowDialog();
        }

        private void rbCheckForUpdates_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            CheckDavtonUpdates();
            //CheckUpdates();
        }

        public void CheckUpdates()
        {
            try
            {
                string updateUrl = CheckForMSIUpdates();
                if (IsMSINetworkDeployed())
                {
                    if (IsMSIUpdatable())
                    {

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
                    else
                    {
                        MessageBox.Show("This installation is not MSI updatable. No updates found for the Outlook Add-In", "Redbox Addin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This installation was not MSI installed. No updates found for the Outlook Add-In", "Redbox Addin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error checking For Updates : " + ex.Message);
            }
        }

        public void CheckDavtonUpdates()
        {
            try
            {
                string updateUrl = "http://www.davton1.com/redbox/version_info.xml";

                Downloader.GetXML(updateUrl);


            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error checking For Updates : " + ex.Message);
            }
        }


        private void cbBtnCheckForUpdates_Click(object sender)
        {
            CheckDavtonUpdates();
            //CheckUpdates();
        }

        private void adxNewRequest_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            NewRequest();
        }

        private void adxImportXL_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.Import(openFileDialog1.FileName, false, false, false, 0, 252);
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
            EditSchools();
        }

        private void adxcbEditSchools_Click(object sender)
        {
            EditSchools();
        }

        private void adxProcess_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            LINQmanager.CheckAndUpdateTeachers();
        }

        private void adxBookings_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ViewBookings();
        }

        private void adxcbViewBookings_Click(object sender)
        {
            ViewBookings();
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
            AvailabilitySheet();
        }

        private void adxcbAvail_Click(object sender)
        {
            AvailabilitySheet();
        }

        private void adxLoadPlan_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            LoadPlan();
        }

        private void adxcbLoadPlan_Click(object sender)
        {
            LoadPlan();
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
            TimeSheets();
        }

        private void adxcbTimeSheets_Click(object sender)
        {
            TimeSheets();
        }

        private void adxSendVetting_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            SendVetting();
        }

        private void adxcbSendVetting_Click(object sender)
        {
            SendVetting();
        }

        private void adxTeacherUpdate_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            TeacherUpdate();
        }

        private void adxcbTeacherUpdate_Click(object sender)
        {
            TeacherUpdate();
        }

        private void adxImportContacts_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            //if (MessageBox.Show("This will add new contacts to the current contact data and should only be used before the system is live." +
            //    "/RDo you want to proceed?", "Carefull!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    OLDDBManager odb = new OLDDBManager();
            //    List<RContact> contacts = odb.GetOldContacts();

            //    DBManager db = new DBManager();
            //    int count = 0;
            //    foreach (RContact c in contacts)
            //    {
            //        count += 1;
            //        db.AddContact(c);
            //    }

            //    MessageBox.Show(count.ToString() + " contacts added.");

            //}
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

        private void adxcbNewRequest_Click(object sender)
        {
            NewRequest();
        }

        private void adxcbCapture_Click(object sender)
        {
            CaptureMessage();
        }

        private void adxCapture_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            CaptureMessage();
        }

        private void adxCommandBarButton1_Click(object sender)
        {
            //updateDatabase
            DBManager dbm = new DBManager();
            string response = dbm.UpdateDatabase();
            MessageBox.Show(response);
        }

        private void adxcbEditPaymentTypes_Click(object sender)
        {
            EditPaymentTypes();
        }

        private void adxEditPaymentTypes_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            EditPaymentTypes();
        }

        #region actions

        private void EditPaymentTypes()
        {
            frmEditPaymentTypes fep = Application.OpenForms["frmEditPaymentTypes"] as frmEditPaymentTypes;
            if (fep == null)
            {
                fep = new frmEditPaymentTypes();
                fep.Show();
            }
            else
            {
                fep.BringToFront();
            }
        }

        private void NewRequest()
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

        private void TeacherUpdate()
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

        private void ViewBookings()
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

        private void AvailabilitySheet()
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

        private void LoadPlan()
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

        private void ViewContacts()
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
                oPublicFolderRoot = oInbox.Parent as Outlook.MAPIFolder;
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
                            //currentExplorer.CurrentFolder = Folder;
                            //Folder.Display();
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

        private void TimeSheets()
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

        private void SendVetting()
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

        private void EditSchools()
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

        private void CaptureMessage()
        {

            try
            {
                Outlook.Explorer oEx = Globals.objOutlook.ActiveExplorer();
                Outlook.Selection oSel = oEx.Selection;

                Outlook.MailItem oMail = null;
                try
                {
                    oMail = oSel[1] as Outlook.MailItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select a Mail item to capture.");
                    return;
                }
                if (oMail == null)
                {
                    MessageBox.Show("Error: The mail item could not be selected.");
                    return;
                }

                string from = oMail.SenderName;
                string fromAddress = oMail.SenderEmailAddress;

                if (from == fromAddress) fromAddress = "";
                else if (fromAddress.IndexOf('=') != -1) fromAddress = ""; //this removes exchange type email addresses
                else fromAddress = "<" + fromAddress + ">";
                string sent = oMail.ReceivedTime.ToLongDateString() + " " + oMail.ReceivedTime.ToShortTimeString();
                string to = oMail.To;
                string subject = oMail.Subject;
                string filename = subject.Replace("re:", "").Replace("RE:", "").Replace("Re:", "");

                string timeSheetfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Davton Files\\TimeSheets";

                //get the required filename
                frmFileName fn = new frmFileName(filename);
                fn.ShowDialog();
                string fileNameToUse = fn.FileName;
                if (fileNameToUse == null) return;
                if (fn.FolderName != null) timeSheetfolder = fn.FolderName;
                if (!Directory.Exists(timeSheetfolder)) Directory.CreateDirectory(timeSheetfolder);
                //***********************************



                Outlook.Inspector oInsp = oMail.GetInspector;
                Word.Document wDoc = oInsp.WordEditor;
                Word.Application wApp = wDoc.Parent as Word.Application;
                string tempwordfolder = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\Davton Files\\temp";
                if (!Directory.Exists(tempwordfolder)) Directory.CreateDirectory(tempwordfolder);
                string tempwordpath = tempwordfolder + "\\temp.doc";
                wDoc.SaveAs(tempwordpath);

                if (oInsp != null) Marshal.ReleaseComObject(oInsp);
                if (oMail != null) Marshal.ReleaseComObject(oMail);
                if (oSel != null) Marshal.ReleaseComObject(oSel);
                if (oEx != null) Marshal.ReleaseComObject(oEx);
                if (wDoc != null) Marshal.ReleaseComObject(wDoc);

                Word.Application wApp2 = new Word.Application();
                Word.Document wDoc2 = wApp2.Documents.Add(tempwordpath);

                Word.Range rng = wDoc2.Range(0, 0);
                rng.Text = "\n\n\n";

                Word.Range rng1 = wDoc2.Range(0, 0);
                rng1.Paragraphs.TabStops.Add(80, Word.WdTabAlignment.wdAlignTabLeft);
                rng1.Text = "Subject:\t" + subject + "\n\n\n";
                rng1.Font.Size = 12;
                rng1.Font.Name = "Arial";
                rng1.Font.Bold = 1;
                Word.Border border = rng1.Paragraphs[1].Borders[Word.WdBorderType.wdBorderBottom];
                border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                border.LineWidth = Word.WdLineWidth.wdLineWidth600pt;
                border.Visible = true;

                Word.Range rng2 = wDoc2.Range(0, 0);
                rng2.Paragraphs.TabStops.Add(80, Word.WdTabAlignment.wdAlignTabLeft);
                rng2.Text = "To:\t" + to + "\n";
                rng2.Font.Size = 12;
                rng2.Font.Name = "Arial";
                rng2.Font.Bold = 1;

                Word.Range rng3 = wDoc2.Range(0, 0);
                rng3.Paragraphs.TabStops.Add(80, Word.WdTabAlignment.wdAlignTabLeft);
                rng3.Text = "Sent:\t" + sent + "\n";
                rng3.Font.Size = 12;
                rng3.Font.Name = "Arial";
                rng3.Font.Bold = 1;

                Word.Range rng4 = wDoc2.Range(0, 0);
                rng4.Paragraphs.TabStops.Add(80, Word.WdTabAlignment.wdAlignTabLeft);
                rng4.Text = "From:\t" + from + " " + fromAddress + "\n";
                rng4.Font.Size = 12;
                rng4.Font.Name = "Arial";
                rng4.Font.Bold = 1;




                string timesheetpath = timeSheetfolder + "\\" + fileNameToUse + ".pdf";
                wDoc2.SaveAs(timesheetpath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                // wApp2.Visible = true;
                wDoc2.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                wApp2.Quit();
                if (wDoc2 != null) Marshal.ReleaseComObject(wDoc2);
                if (wApp2 != null) Marshal.ReleaseComObject(wApp2);

            }
            catch (Exception ex)
            {
                Debug.DebugMessage(2, "Error in CaptureMessage :- " + ex.Message);
                MessageBox.Show("Message capture failed! (" + ex.Message + ")");
            }
            finally
            {
                GC.Collect();
            }
        }



        #endregion

        private void adxDailyContactReport_Click(object sender)
        {
            frmReport fr = new frmReport();
            fr.Show();
        }

        private void adxRibbonDCR_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            frmReport fr = new frmReport();
            fr.Show();
        }











    }
}

