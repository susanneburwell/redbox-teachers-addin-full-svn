﻿using System;
using Redemption;
using System.IO;
using Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Xml;
using RedboxAddin.DL;
using RedboxAddin.Models;


namespace RedboxAddin.BL
{
    public static class RedemptionCode
    {
        public static RDOSession rSession;
        internal static string OutlookUserName = "";
        internal static string OutlookVersion = "";
        internal static string RedemptionVersion = "";
        internal static string ExchangeServerName = "";
        internal static string RedemptionLoader_DllLocation32Bit_FilePath;
        internal static string RedemptionLoader_DllLocation64Bit_FilePath;
        private static string AppDataFilePath;
        //This Function initialize the Redemption
        public static Boolean InitialiseRedemption(ref Object MAPIObject)
        {
            try
            {
                RedemptionLoader_DllLocation64Bit_FilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\RedboxAddin\\Redemption64.dll";
                RedemptionLoader_DllLocation32Bit_FilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\RedboxAddin\\Redemption.dll";
                AppDataFilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\RedboxAddin";
                Debug.DebugMessage(1, "Redemption FilePath:- " + RedemptionLoader_DllLocation32Bit_FilePath);

                if (File.Exists(RedemptionLoader_DllLocation32Bit_FilePath) && File.Exists(RedemptionLoader_DllLocation64Bit_FilePath))
                {
                    RedemptionLoader.DllLocation32Bit = RedemptionLoader_DllLocation32Bit_FilePath;
                    RedemptionLoader.DllLocation64Bit = RedemptionLoader_DllLocation64Bit_FilePath;
                }
                else
                {
                    return false;
                }//End If
                rSession = RedemptionLoader.new_RDOSession();
                rSession.MAPIOBJECT = MAPIObject;

                OutlookUserName = rSession.CurrentUser.Name;
                Debug.DebugMessage(4, "Outlook UserName : " + OutlookUserName);
                OutlookVersion = rSession.OutlookVersion;
                Debug.DebugMessage(4, "Outlook Version : " + OutlookVersion);
                ExchangeServerName = rSession.ExchangeMailboxServerName;
                Debug.DebugMessage(4, "Exchange ServerName : " + ExchangeServerName);
                Debug.DebugMessage(4, "Redemption Version : " + rSession.Version);

                Debug.DebugMessage(4, "Redemption initialized successfully.");
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "***Error Initialising Redemption. :- " + ex.Message);
            }
            return false;
        }//InitialiseRedemption

        //This function returns the Sender Email Address of a MailItem
        public static string GetSenderAddressFromItem(RDOMail rMail)
        {
            //** Returns the email address if the first RECIPIENT of the email
            //** to get the sender emailaddress just use oMail.SenderEmailAddress
            try
            {
                RDOAddressEntry rAddEntry = rMail.Sender;
                string myEmailAddress = "";
                try
                {
                    //* Get email address (deal with case where it is an internal address)
                    if (rAddEntry == null) { myEmailAddress = rMail.SenderEmailAddress; }
                    else
                    {
                        //oAddEntry may have different types of addresses
                        if (rAddEntry.Type.ToLower() == "smtp")
                        {
                            myEmailAddress = rAddEntry.Address;
                        }
                        else
                        {
                            myEmailAddress = rAddEntry.SMTPAddress;
                        }
                    }
                    return myEmailAddress;
                }
                catch (System.Exception ex)
                {
                    Debug.DebugMessage(2, "Error in GetSenderAddressFromItem :- " + ex.Message);
                    return "Error";
                }
                finally
                { //Marshal.ReleaseComObject(rMail); 
                    Marshal.ReleaseComObject(rAddEntry);
                }

            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in GetSenderAddressFromItem (2) :- " + ex.Message);
                return "Error";
            }
            //Execution path can never get here as all previous code paths terminate in return.
            //return "Error"; 

        } //GetSenderAddressFromItem


        /// <summary>
        /// 
        /// </summary>
        /// <param name="outlookUserName"></param>
        /// <param name="exchangeServerName"></param>
        /// <param name="OutlookVersion"></param>
        /// <param name="RedemptionVerion"></param>
        //static void CreateRedemptionDataFile(string outlookUserName, string exchangeServerName, string OutlookVersion, string RedemptionVerion,string BitVersion)
        // {
        //     try
        //     {
        //           if (!Directory.Exists(AppDataFilePath))
        //             Directory.CreateDirectory(AppDataFilePath);

        //         XmlTextWriter writer = new XmlTextWriter(AppDataFilePath + "\\RedemptionData.xml", System.Text.Encoding.UTF8);
        //         writer.WriteStartDocument(true);
        //         writer.Formatting = Formatting.Indented;
        //         writer.Indentation = 2;

        //         writer.WriteStartElement("Redemption");

        //         writer.WriteStartElement("OutlookUserName");
        //         writer.WriteString(outlookUserName);
        //         writer.WriteEndElement();

        //         writer.WriteStartElement("ExchangeServerName");
        //         writer.WriteString(exchangeServerName);
        //         writer.WriteEndElement();

        //         writer.WriteStartElement("OutlookVersion");
        //         writer.WriteString(OutlookVersion);
        //         writer.WriteEndElement();

        //         writer.WriteStartElement("RedemptionVerion");
        //         writer.WriteString(RedemptionVerion);
        //         writer.WriteEndElement();

        //         writer.WriteStartElement("BitVersion");
        //         writer.WriteString(BitVersion);
        //         writer.WriteEndElement();

        //         writer.WriteEndElement();

        //         writer.WriteEndDocument();
        //         writer.Close();
        //     }
        //     catch (System.Exception  ex)
        //     {
        //        Debug.DebugMessage(2, "***CreateRedemptionDataFile :- " + ex.Message);
        //     }
        // }


        internal static bool SendVettingDetails(string contactID, string schoolID, bool sendImmediately,
            string startDate = null, string endDate = null, string yearGroup = null)
        {
            MailItem oMail = null;
            try
            {
                //Get the contact
                RContact contactObj = null;
                try
                {
                    long contID = Convert.ToInt64(contactID);
                    contactObj = new DBManager().GetContact(contID);
                }
                catch (System.Exception ex)
                {
                    Debug.DebugMessage(2, "Error in SendVettingDetails(1) : " + ex.Message);
                }
                if (contactObj == null) return false;

                //Get the email addresses
                long schID = Convert.ToInt64(schoolID);
                School school = LINQmanager.GetSchoolbyID(schID);
                //DBManager dbm = new DBManager();
                string vettingEmailAddresses = school.VettingEmails;
                if (vettingEmailAddresses == null) return false;


                //Create the Mail
                oMail = CreateVettingMessage(contactObj,  startDate ,  endDate ,  yearGroup );
                oMail.To = vettingEmailAddresses; //must be a semicolon delimited list


                //if required - Create a word doc from teh html
                //createWordDoc(oMail.HTMLBody);

                //Send the mail
                if (sendImmediately)
                {
                    oMail.Send();
                    return true;
                }
                else
                {
                    oMail.Save();
                    oMail.Display();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in SendVettingDetails: " + ex.Message);
                return false;
            }
            finally
            {
                if (oMail != null) Marshal.ReleaseComObject(oMail);
            }

        }

        private static void createWordDoc(string html)
        {
            try
            {

                //Create temp file
                string filePath = Path.GetTempPath() + "redboxTemp.html";
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, html);



                Word.Application oWord = new Word.Application();
                Word.Document oDoc = oWord.Documents.Add();
                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add();
                oPara1.Range.Text = "Heading 1";
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */ 
                Word.Range oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                oRng.InsertFile(filePath);

                oWord.Visible = true;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private static MailItem CreateVettingMessage(RContact contactObj, string startDate = null, string endDate = null, string yearGroup = null)
        {
            //Create the message

            RDOFolder rFolderDrafts = null;
            RDOItems rItems = null;
            Redemption.RDOMail rMail = null;
            RDOAttachments colAttach = null;
            RDOAttachment myAttach = null;
            MailItem oMail = null;
            try
            {
                string myEntryID = "";
                string TableMiddle = "";
                string TableBottom = "";
                string Replacement1 = "";
                string Replacement2 = "";
                string myPic = "";
                string myBody = "";
                string txtBody = "";

                //set supply date
                string supplyDate = "01/01/0001"  ;
                if (startDate != null) supplyDate = startDate;
                if ((endDate != null) && (endDate != startDate)) supplyDate = supplyDate + " to " + endDate;

                //set year group
                if (yearGroup==null) yearGroup = "";
                 

                string contentID = "myident";
                string TableTop = "<table border=" + (char)(34) + "1" + (char)(34) + "width=" + (char)(34) + "100%" +
                                  "id=" + (char)(34) + "table1" + (char)(34) + "height=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine +
                                  "<tr>" + Environment.NewLine + "<td width=" + (char)(34) + "200" + (char)(34) + " >" + Environment.NewLine;
                rFolderDrafts = RedemptionCode.rSession.GetDefaultFolder(rdoDefaultFolders.olFolderDrafts);
                rItems = rFolderDrafts.Items;
                rMail = (RDOMail)rItems.Add("IPM.Note");
                colAttach = rMail.Attachments;
                //AddAttachments(ref colAttach);

                //Add Attachments
                try
                {
                    if (contactObj.SendBankStatement)
                    {
                        if (!string.IsNullOrWhiteSpace(contactObj.BankStatementLocation))
                        {
                            RDOAttachment rAttachment = colAttach.Add(contactObj.BankStatementLocation);
                            if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                        }
                    }
                    if (contactObj.SendPassport)
                    {
                        if (!string.IsNullOrWhiteSpace(contactObj.PassportLocation))
                        {
                            RDOAttachment rAttachment = colAttach.Add(contactObj.PassportLocation);
                            if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                        }
                    }
                    if (contactObj.SendVisa)
                    {
                        if (!string.IsNullOrWhiteSpace(contactObj.VisaLocation))
                        {
                            RDOAttachment rAttachment = colAttach.Add(contactObj.VisaLocation);
                            if (rAttachment != null) Marshal.ReleaseComObject(rAttachment);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.DebugMessage(2, "Error in AddAttachments :- " + ex.Message);
                }


                rMail.Body = " ";
                try
                {
                    myAttach = colAttach.Add(contactObj.PhotoLocation, OlAttachmentType.olByValue, rMail.Body.Length, Type.Missing);
                    myAttach.Hidden = true;
                    myAttach.set_Fields(0x370E001E, "image/jpeg");
                    myAttach.set_Fields(0x3712001E, "myident");

                    myAttach.ContentID = contentID;
                }
                catch (System.Exception ex) { Debug.DebugMessage(2, "Error attaching pictures in the " + ex.Message); }

                rMail.Save();
                myEntryID = rMail.EntryID;

                oMail = (MailItem)Globals.objNS.GetItemFromID(myEntryID);

                myPic = "<DIV>" + Environment.NewLine + "<IMG style=" + " border=0 hspace=0 alt=myPic align=baseline src=cid:myident width=200 height=200>" + Environment.NewLine + "</DIV>" + Environment.NewLine;
                TableMiddle = "</td>" + Environment.NewLine + "<td><FONT SIZE=2 FACE=" + (char)34 + "Arial" + (char)34 + ">";
                //txtBody = txtBody + "Date of Supply: " + contactObj.DateOfSupply.ToShortDateString() + Environment.NewLine;
                txtBody = txtBody + "Date of Supply: " + supplyDate + Environment.NewLine;
                txtBody = txtBody + Environment.NewLine + "Supply Requirement: Basic Cover" + Environment.NewLine + Environment.NewLine;
                txtBody = txtBody + "Teacher Name: " + contactObj.FullName + Environment.NewLine + Environment.NewLine;
                //txtBody = txtBody + "Year Group: " + contactObj.YearGroup + Environment.NewLine;
                txtBody = txtBody + "Year Group: " + yearGroup + Environment.NewLine;
                txtBody = txtBody + Environment.NewLine + "Qualification: " + contactObj.Qualification;
                if (contactObj.QTS)
                {
                    txtBody = txtBody + Environment.NewLine + "QTS? Yes";
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "QTS? No";
                }

                if (contactObj.NQT)
                {
                    txtBody = txtBody + Environment.NewLine + "NQT? Yes";
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "NQT? No";
                }

                if (contactObj.Instructor) { txtBody = txtBody + Environment.NewLine + "Instructor? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Instructor? No"; }

                if (contactObj.OverseasTrainedTeacher) { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Overseas Trained Teacher? No"; }

                if (contactObj.CVReceived) { txtBody = txtBody + Environment.NewLine + "CV Received? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "CV Received? No"; }

                if (contactObj.RedboxCRB) { txtBody = txtBody + Environment.NewLine + "Red Box CRB? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Red Box CRB? No"; }

                txtBody = txtBody + Environment.NewLine + "Red Box CRB Form Ref: " + contactObj.CRBFormRef;
                txtBody = txtBody + Environment.NewLine + "CRB Number: " + contactObj.CRBNumber;

                if (contactObj.CRBValidFrom != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "CRB Valid from: " + contactObj.CRBValidFrom.ToShortDateString();
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "CRB Valid from: None";
                }

                if (contactObj.AdditionalInfoOnCRB) { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Cautions/Convictions on CRB? No"; }

                if (contactObj.UpdateService) { txtBody = txtBody + Environment.NewLine + "DBS Update Service? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "DBS Update Service? No"; }

                if (contactObj.VisaExpiryDate != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: " + contactObj.VisaExpiryDate.ToShortDateString();
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Expiry Date: None";
                }

                if (!string.IsNullOrEmpty(contactObj.VisaType))
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Type: " + contactObj.VisaType;
                }
                else
                {
                    txtBody = txtBody + Environment.NewLine + "Visa Type: None";
                }

                if (contactObj.IDChecked) { txtBody = txtBody + Environment.NewLine + "ID checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "ID checked? No"; }

                if (contactObj.OverseasPoliceCheck) { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Overseas Police Check? No"; }

                if (contactObj.ReferencesChecked) { txtBody = txtBody + Environment.NewLine + "All References checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "All References checked? No"; }

                if (contactObj.List99) { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "List 99 undertaken? No"; }

                if (contactObj.MedicalChecklist) { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Medical Checklist checked? No"; }

                if (contactObj.ProofOfAddress) { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? Yes"; }
                else { txtBody = txtBody + Environment.NewLine + "Proof of Address checked? No"; }

                if (contactObj.RegistrationDate != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "Date of Registration: " + contactObj.RegistrationDate.ToShortDateString();
                }
                else { txtBody = txtBody + Environment.NewLine + "Date of Registration: None"; }

                txtBody = txtBody + Environment.NewLine + "GTC Number: " + contactObj.GTCNumber;

                if (contactObj.GTCCheckDate != DateTime.MinValue)
                {
                    txtBody = txtBody + Environment.NewLine + "GTC Check Date: " + contactObj.GTCCheckDate.ToShortDateString();
                }
                else { txtBody = txtBody + Environment.NewLine + "GTC Check Date: None"; }

                if (!string.IsNullOrWhiteSpace(contactObj.BirthDate))
                {
                    txtBody = txtBody + Environment.NewLine + "Date of Birth: " + contactObj.BirthDate;
                }
                else { txtBody = txtBody + Environment.NewLine + "Date of Birth: None"; }

                txtBody = txtBody + Environment.NewLine;
                TableBottom = "</td>" + Environment.NewLine + "</tr>" + Environment.NewLine + "</table>";
                Replacement1 = "<BODY>" + Environment.NewLine + TableTop + myPic + TableMiddle;
                Replacement2 = TableBottom + "</BODY>";

                oMail.Subject = contactObj.FullName;
                oMail.Body = txtBody;

                //send attachments

                string myText = oMail.HTMLBody;
                myText = myText.Replace("<BODY>", Replacement1);
                myText = myText.Replace("</BODY>", Replacement2);
                oMail.HTMLBody = myText;

                return oMail;
            }
            catch (System.Exception ex)
            {
                Debug.DebugMessage(2, "Error in Send Details : " + ex.Message);
                return null;
            }
            finally
            {
                //if (oMail != null) Marshal.ReleaseComObject(oMail);
                if (myAttach != null) Marshal.ReleaseComObject(myAttach);
                if (colAttach != null) Marshal.ReleaseComObject(colAttach);
                if (rMail != null) Marshal.ReleaseComObject(rMail);
                if (rItems != null) Marshal.ReleaseComObject(rItems);
                if (rFolderDrafts != null) Marshal.ReleaseComObject(rFolderDrafts);
                GC.Collect();
            }
        }



    }
}
