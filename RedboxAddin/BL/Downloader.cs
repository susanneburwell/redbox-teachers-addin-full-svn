using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RedboxAddin.BL
{
    class Downloader
    {
        static public bool URLExists(string url)
        {
            bool result = false;

            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 5000; // miliseconds
            webRequest.Method = "HEAD";

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
                result = true;
            }
            catch (WebException webException)
            {
                Debug.DebugMessage(2, url + " doesn't exist: " + webException.Message);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }

        static public void GetXML(string url)
        {
            if (URLExists(url))
            {
                try
                {
                    string foundversion = FindLatestVersion(url);
                    if (foundversion == null)
                    {
                        MessageBox.Show("It was not possible to check for updates", "Redbox Addin Update");
                    }
                    else
                    {
                        //find current version
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                        string currentversion = fvi.ProductVersion;

                        if (string.Compare(currentversion, foundversion, true) == 0)
                        {
                            //same version
                            MessageBox.Show("You already have the most up to date version", "Redbox Addin Update");
                        }
                        else if (string.Compare(currentversion, foundversion, true) > 0)
                        {
                            //more recent version
                            MessageBox.Show("You appear to have a version more recent than the update version. NO action required.", "Redbox Addin Update");
                        }
                        else
                        {
                            //needs upgrading
                            if (MessageBox.Show("A new version of the Outlook Add-In was found. Would you like to install the update?", "Redbox Addin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
                            {
                                string downloadfile = "http://www.davton1.com/redbox/" + "1033/" + foundversion + "/redboxaddin.exe";
                                using (WebClient myWebClient = new WebClient())
                                {
                                    string myStringWebResource = downloadfile;
                                    string downloadsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                                    string filepath = downloadsFolderPath + "/redboxaddin.exe";
                                    // Download the Web resource and save it into the current filesystem folder.
                                    myWebClient.DownloadFile(myStringWebResource, filepath);
                                    try
                                    {
                                        Process.Start(filepath);
                                        MessageBox.Show("Please close Outlook and continue the installation", "Redbox Addin Update");
                                    }
                                    catch (Exception ex2)
                                    {
                                        MessageBox.Show("Error. There was a problem starting the downloaded file. Please call your support. " + 
                                        "Error details: " + ex2.Message, "Redbox Addin Update");

                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("We could not find the update file. No update is possible currently", "Redbox Addin Update");

            }
        }

        static private string FindLatestVersion(string url)
        {
            try
            {


                XElement root = XElement.Load(url);
                IEnumerable<XElement> products =
                    from el in root.Elements()
                    select el;
                foreach (XElement el in products)
                {
                    IEnumerable<XElement> versions =
                    from el2 in el.Elements()
                    orderby el2.Attribute("name").Value descending
                    select el2;
                    foreach (XElement el2 in versions)
                    {
                        string version = el2.Attribute("name").Value.ToString();
                        return version;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding latest Version: " + ex.Message);
            }

        }
    }
}
