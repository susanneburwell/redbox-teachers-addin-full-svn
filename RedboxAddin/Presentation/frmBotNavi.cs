using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AddinExpress.OL;
using RedboxAddin.BL;
  
namespace RedboxAddin.Presentation
{
    public partial class frmBotNavi : AddinExpress.OL.ADXOlForm
    {
        public frmBotNavi()
        {
            InitializeComponent();
        }

        private void frmBotNavi_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Explorer currentExplorer = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder redboxFolder = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder oInbox = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder oPublicFolderRoot = null;
            Microsoft.Office.Interop.Outlook.Folders oFolders = null;
            try
            {
                currentExplorer = Globals.objOutlook.ActiveExplorer();
                oInbox = Globals.objNS.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                oPublicFolderRoot = (Microsoft.Office.Interop.Outlook.MAPIFolder)oInbox.Parent;
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

        private void frmBotNavi_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void frmBotNavi_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(220, 224, 229);
        }

        private void frmBotNavi_Load(object sender, EventArgs e)
        {
            
        }
    }
}
