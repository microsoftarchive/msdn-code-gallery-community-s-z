using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
namespace SyncMyAddress
{
    public partial class ThisAddIn
    {
        private CommandBar menuBar;
        private CommandBarPopup newMenuBar;
        private CommandBarButton btnSyncAddresses;
        private CommandBarButton btnImportAddresses;
        private CommandBarButton btnExportAddresses;
        private string menuTag = "SyncMyAddresses";

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            RemoveMenubar();
            AddMenuBar();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        private void AddMenuBar()
        {
            try
            {

                CommandBarPopup foundMenu = (CommandBarPopup)
                    this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.
                    FindControl(MsoControlType.msoControlPopup,
                    missing, menuTag, true, true);

                if (foundMenu == null)
                {

                    // Get the current menu bar.
                    this.menuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;

                    // Add a new item to the menu bar.
                    this.newMenuBar = (CommandBarPopup)menuBar.Controls.Add(
                                       MsoControlType.msoControlPopup, missing,
                                       missing, missing, false);

                    // Add the menu bar if it doesn't exist.
                    if (this.newMenuBar != null)
                    {
                        this.newMenuBar.Caption = "&Sync My Addresses";
                        this.newMenuBar.Tag = this.menuTag;
                        // Make our result visible.
                        this.newMenuBar.Visible = true;

                        // Add a new menu item to the menu.
                        this.btnImportAddresses = (CommandBarButton)newMenuBar.Controls.Add(
                                              MsoControlType.msoControlButton, missing,
                                              missing, 1, true);

                        // Layout the menu item.
                        this.btnImportAddresses.Style = MsoButtonStyle.msoButtonIconAndCaption;
                        this.btnImportAddresses.Caption = "&Import Addresses";
                        this.btnImportAddresses.FaceId = 40; // Looking Glass icon
                        this.btnImportAddresses.Click += new _CommandBarButtonEvents_ClickEventHandler(this.btnImportAddresses_Click);

                        // Make our result visible.
                        this.newMenuBar.Visible = true;

                        // Add a new menu item to the menu.
                        this.btnExportAddresses = (CommandBarButton)newMenuBar.Controls.Add(
                                              MsoControlType.msoControlButton, missing,
                                              missing, 1, true);

                        // Layout the menu item.
                        this.btnExportAddresses.Style = MsoButtonStyle.msoButtonIconAndCaption;
                        this.btnExportAddresses.Caption = "&Export Addresses";
                        this.btnExportAddresses.FaceId = 38; // Looking Glass icon
                        this.btnExportAddresses.Click += new _CommandBarButtonEvents_ClickEventHandler(this.btnExportAddresses_Click);


                        // Make our result visible.
                        this.newMenuBar.Visible = true;
             
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportAddresses_Click(CommandBarButton ctrl, ref bool cancel)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // System.Data.DataSet ds = new System.Data.DataSet();
                EmployeeTableAdapters.EmployeesTableAdapter td = new SyncMyAddress.EmployeeTableAdapters.EmployeesTableAdapter();
                Employee.EmployeesDataTable ds = new Employee.EmployeesDataTable();
                ds = td.GetData();

                MAPIFolder contactsFolder = Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);

                //Outlook.ContactItem contactItem;
                Outlook.Items contacts;
                contacts = contactsFolder.Items.Restrict("[MessageClass]='IPM.Contact'");

                foreach (System.Data.DataRow dr in ds.Rows)
                {
                    Outlook.ContactItem existingContact = (Outlook.ContactItem)contacts.Find("[Email1Address] = '" + dr["EmailID"] + "'");
                    if (existingContact != null)
                    {
                        existingContact.FirstName = (dr["FullName"] == null) ? string.Empty : dr["FullName"].ToString();
                        existingContact.CustomerID = (dr["EmpID"] == null) ? string.Empty : dr["EmpID"].ToString();
                        existingContact.JobTitle = (dr["Designation"] == null) ? string.Empty : dr["Designation"].ToString();
                        existingContact.Department = (dr["Department"] == null) ? string.Empty : dr["Department"].ToString();
                        existingContact.Email1Address = (dr["EmailID"] == null) ? string.Empty : dr["EmailID"].ToString();
                        existingContact.ManagerName = (dr["ManagerID"] == null) ? string.Empty : dr["ManagerID"].ToString();
                        existingContact.WebPage = "www.appsassociates.com";
                        existingContact.Save();
                    }
                    else
                    {
                        Outlook.ContactItem newContact = Application.CreateItem(Outlook.OlItemType.olContactItem) as Outlook.ContactItem;
                        newContact.FirstName = (dr["FullName"] == null) ? string.Empty : dr["FullName"].ToString();
                        newContact.CustomerID = (dr["EmpID"] == null) ? string.Empty : dr["EmpID"].ToString();
                        newContact.JobTitle = (dr["Designation"] == null) ? string.Empty : dr["Designation"].ToString();
                        newContact.Department = (dr["Department"] == null) ? string.Empty : dr["Department"].ToString();
                        newContact.Email1Address = (dr["EmailID"] == null) ? string.Empty : dr["EmailID"].ToString();
                        newContact.ManagerName = (dr["ManagerID"] == null) ? string.Empty : dr["ManagerID"].ToString();
                        newContact.WebPage = "www.appsassociates.com";
                        newContact.Save();
                    }
                }
                MessageBox.Show("Successfully Imported...!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Sync Process is not completed. Error Message: " + ex.Message);
            }
            catch
            {
                MessageBox.Show("Sync Process is not completed");
            }
            Cursor.Current = Cursors.Default;
        }

        // exporting from outlook to SQL server
        private void btnExportAddresses_Click(CommandBarButton ctrl, ref bool cancel)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Getting data from Database
                EmployeeTableAdapters.EmployeesTableAdapter td = new SyncMyAddress.EmployeeTableAdapters.EmployeesTableAdapter();
                Employee.EmployeesDataTable ds = new Employee.EmployeesDataTable();
                ds = td.GetData();

                //Getting outlook contacts folder
                MAPIFolder contactsFolder = Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);

                //Here i am getting only contacts from contacts folder.
                Outlook.Items contacts;
                contacts = contactsFolder.Items.Restrict("[MessageClass]='IPM.Contact'");

                
                foreach (Outlook.ContactItem contact in contacts)
                {
                    System.Data.DataRow []existingContact = null;
                    if (ds.Rows.Count > 0)
                    {
                        //Checking if the contact exists in database or not.
                        existingContact = ds.Select("EmailID = '" + contact.Email1Address + "'");                        
                    }
                    //if it exists, update if any information is updated inside
                    if (existingContact != null && existingContact.Length>0)
                    {
                        if (existingContact[0] != null)
                        {
                            System.Data.DataRow existsContact = existingContact[0];
                            existsContact["FullName"] = (contact.FullName == null) ? string.Empty : contact.FullName.ToString();
                            existsContact["Designation"] = (contact.JobTitle == null) ? string.Empty : contact.JobTitle.ToString();
                            existsContact["Department"] = (contact.Department == null) ? string.Empty : contact.Department.ToString();
                            existsContact["EmailID"] = (contact.Email1Address == null) ? string.Empty : contact.Email1Address.ToString();
                            existsContact["ManagerID"] = (contact.ManagerName == null) ? string.Empty : contact.ManagerName.ToString();
                            td.Update(existsContact);
                        }
                    }
                    else
                    {
                        System.Data.DataRow newContact = ds.NewEmployeesRow();
                        newContact["FullName"] = (contact.FullName == null) ? string.Empty : contact.FullName.ToString();                        
                        newContact["Designation"] = (contact.JobTitle == null) ? string.Empty : contact.JobTitle.ToString();
                        newContact["Department"] = (contact.Department == null) ? string.Empty : contact.Department.ToString();
                        newContact["EmailID"] = (contact.Email1Address == null) ? string.Empty : contact.Email1Address.ToString();
                        newContact["ManagerID"] = (contact.ManagerName == null) ? string.Empty : contact.ManagerName.ToString();
                        ds.Rows.Add(newContact);
                        ds.AcceptChanges();
                        td.Insert(contact.FullName, contact.JobTitle, contact.Email1Address, contact.Department, contact.ManagerName, DateTime.Today, string.Empty, string.Empty);
                    }
                }
                
                MessageBox.Show("Successfully Exported...!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Sync Process is not completed. Error Message: " + ex.Message);
            }
            catch
            {
                MessageBox.Show("Sync Process is not completed");
            }
            Cursor.Current = Cursors.Default;
        }

        private void RemoveMenubar()
        {
            // If the menu already exists, remove it.
            try
            {
                CommandBarPopup foundMenu = (CommandBarPopup)
                    this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.
                    FindControl(MsoControlType.msoControlPopup,
                    missing, menuTag, true, true);

                if (foundMenu != null)
                {
                    foundMenu.Delete(true);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
