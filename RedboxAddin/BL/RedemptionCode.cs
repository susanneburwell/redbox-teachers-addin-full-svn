using System;
using Redemption;
using System.IO;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Xml;


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
                RedemptionLoader_DllLocation64Bit_FilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Davton\\RedboxAddin\\Redemption64.dll";
                RedemptionLoader_DllLocation32Bit_FilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Davton\\RedboxAddin\\Redemption.dll";
                AppDataFilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Davton\\RedboxAddin";

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
                Debug.DebugMessage(4, "Outlook UserName : "+OutlookUserName);
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
                finally { //Marshal.ReleaseComObject(rMail); 
                    Marshal.ReleaseComObject(rAddEntry); }

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


    } //class RedemptionCode
}
