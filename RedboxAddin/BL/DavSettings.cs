using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Debug = RedboxAddin.BL.Debug;

public static class DavSettings
{
    static List<Prop> PropList = new List<Prop>();
    //Specify the name of your product here
    static string ProductName = "RedboxAddin";

    public static void LoadDavSettings()
    {
        try
        {
            try
            {
                PropList.Clear();
                string XMLSTring = "";
                StreamReader ioFile = null;
                var myFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\" + ProductName + "\\Settings.xml";
                //var myAllUserFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "\\RedboxAddin\\Settings.xml";
                Debug.DebugMessage(3, "AllUserFilePath: " + myFilePath);
                if (File.Exists(myFilePath))
                {
                    ioFile = new StreamReader(myFilePath);
                    XMLSTring = ioFile.ReadToEnd();
                    ioFile.Close();
                }
                else
                {
                    Debug.DebugMessage(3, "Settings.xml was not found. Unable to load settings ");
                    return;
                }

                // Go through the XML and process
                XmlDocument m_xmld = null;
                XmlNodeList m_nodelist = null;
                XmlNode m_node = null;
                //Create the XML Document

                m_xmld = new XmlDocument();
                //Load the Xml file
                System.IO.StringReader strReader = new System.IO.StringReader(XMLSTring);
                m_xmld.Load(strReader);


                int count = m_xmld.DocumentElement.ChildNodes.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    string myPropName = CheckString(m_xmld.DocumentElement.ChildNodes.Item(i).Name);
                    string myPropValue = CheckString(m_xmld.DocumentElement.ChildNodes.Item(i).InnerText);
                    PropList.Add(new Prop
                    {
                        PropName = myPropName,
                        PropValue = myPropValue
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.DebugMessage(3, "Error Loading PreConfig :- " + ex.Message);
            }

        }
        catch (Exception ex)
        {
        }
    }

    public static void SetDavValue(string myPropName, string myValue)
    {
        try
        {
            bool isNew = true;
            foreach (Prop Prop_loopVariable in PropList)
            {

                if (Prop_loopVariable.PropName == myPropName)
                {
                    Prop_loopVariable.PropValue = myValue;
                    isNew = false;
                }
            }
            if (isNew)
            {
                PropList.Add(new Prop
                {
                    PropName = myPropName,
                    PropValue = myValue
                });
            }
        }
        catch (Exception ex)
        {
            Debug.DebugMessage(2, "Error Setting Value :- " + ex.Message);
        }
    }

    public static void SaveDavSettings()
    {
        try
        {
            // Create the XML String
            XmlDocument myXMLdoc = new XmlDocument();

            XmlDeclaration myDeclare = myXMLdoc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            myXMLdoc.InsertBefore(myDeclare, myXMLdoc.DocumentElement);
            XmlElement myRoot = null;
            myRoot = myXMLdoc.CreateElement("Settings");
            myXMLdoc.InsertAfter(myRoot, myDeclare);
            foreach (Prop Prop_loopVariable in PropList)
            {
                AddField(myXMLdoc, myRoot, Prop_loopVariable.PropName, Prop_loopVariable.PropValue);
            }

            string myXMLString = myXMLdoc.OuterXml;


            //Writing on Current User's  Application Data folder
            StreamWriter ioFile = null;
            var myFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\" + ProductName + "\\Settings.xml";
            if (File.Exists(myFilePath))
            {
                File.Delete(myFilePath);
            }
            DirectoryInfo d1 = Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\" + ProductName + "");
            ioFile = new StreamWriter(myFilePath);
            ioFile.WriteLine(myXMLString);
            ioFile.Close();

            //Writing on All Users  Application Data folder
            StreamWriter ioFile2 = null;
            var myAllUsersFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "\\" + ProductName + "\\Settings.xml";
            if (File.Exists(myAllUsersFilePath))
            {
                File.Delete(myAllUsersFilePath);
            }
            DirectoryInfo d2 = Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "\\" + ProductName + "");

            ioFile2 = new StreamWriter(myAllUsersFilePath);
            ioFile2.WriteLine(myXMLString);
            ioFile2.Close();
        }
        catch (Exception ex)
        {
            Debug.DebugMessage(2, "Error Saving Settings :- " + ex.Message);
        }
    }

    public static string getDavValue(string myPropName)
    {
        try
        {
            foreach (Prop Prop_loopVariable in PropList)
            {

                if (Prop_loopVariable.PropName == myPropName)
                    return (string)Prop_loopVariable.PropValue;
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public class Prop
    {
        string fPropName;

        string fPropValue;
        public string PropName
        {
            get { return fPropName; }
            set { fPropName = (string)value; }
        }

        public string PropValue
        {
            get { return fPropValue; }
            set { fPropValue = (string)value; }
        }
    }

    public static void AddField(XmlDocument XMLdoc, XmlElement xmlParent, string Name, string myData, string myType = "text")
    {
        //* This adds a child Field to a parent Appointment
        try
        {
            XmlElement myField = null;
            myField = XMLdoc.CreateElement(Name);
            if (!(myType == "text"))
                myField.SetAttribute("type", myType);
            myField.InnerText = myData;
            xmlParent.AppendChild(myField);
        }
        catch (Exception ex)
        {
            Debug.DebugMessage(1, "DavSettings Error: Error in function AddField() :- " + ex.Message);
        }
    }

    public static string CheckString(object myObject)
    {
        try
        {
            if (System.DBNull.Value == myObject)
            {
                return "";
            }
            else if (myObject == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(myObject);
            }
        }
        catch (Exception ex)
        {
            Debug.DebugMessage(2, "CheckString Failed :- " + ex.Message);
            return "";
        }
    }

}