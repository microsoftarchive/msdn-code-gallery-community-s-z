using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.Samples.SqlServer.SSIS.SharePointUtilityOnline;
using IDTSInputColumnCollection = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSInputColumnCollection100;
using IDTSExternalMetadataColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSExternalMetadataColumn100;
using IDTSInput = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSInput100;
using IDTSInputColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSInputColumn100;
using IDTSCustomProperty = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSCustomProperty100;
using IDTSVirtualInputColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSVirtualInputColumn100;

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListAdaptersOnline
{
    [DtsPipelineComponent(DisplayName = "SharePoint List Destination Online",
        CurrentVersion = 7,
        IconResource = "Microsoft.Samples.SqlServer.SSIS.SharePointListAdaptersOnline.Icons.SharePointDestination.ico",
        Description = "Add, update, or delete data in SharePoint lists",
        ComponentType = ComponentType.DestinationAdapter)]
    public class SharePointListDestination : PipelineComponent
    {
        private const int DTS_PIPELINE_CTR_ROWSWRITTEN = 103;
        private const string C_SHAREPOINTSITEURL = "SiteUrl";
        private const string C_SHAREPOINTLISTNAME = "SiteListName";
        private const string C_SHAREPOINTLISTVIEWNAME = "SiteListViewName";
        private const string C_SHAREPOINTCULTURE = "SharePointCulture";
        private const string C_BATCHSIZE = "BatchSize";
        private const string C_BATCHTYPE = "BatchType";

        private const string C_USERNAME = "Username";
        private const string C_PASSWORD = "Password";

        private const string C_CONNECTIONMANAGER = "UseConnectionManager";
        private Dictionary<string, int> _bufferLookup;
        private Dictionary<string, DataType> _bufferLookupDataType;
        private Dictionary<string, string> _existingColumnData;
        private CultureInfo _culture;
        private NetworkCredential _credentials;

        #region Design Time Methods
        /// <summary>
        ///  The ProvideComponentProperties() method provides initialization of the the component 
        ///  when the component is first added to the Data Flow designer.
        /// </summary>
        public override void ProvideComponentProperties()
        {
            // Add the Properties
            AddUserProperties();
        }

        private void AddUserProperties()
        {

            // Add Custom Properties
            var sharepointUrl = ComponentMetaData.CustomPropertyCollection.New();
            sharepointUrl.Name = C_SHAREPOINTSITEURL;
            sharepointUrl.Description = "Path to SharePoint site that contains the list.";
            sharepointUrl.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;


            IDTSCustomProperty100 User_Name = ComponentMetaData.CustomPropertyCollection.New();
            User_Name.Name = C_USERNAME;
            User_Name.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
            User_Name.Description = "USER nAME FOR sHAREPOINT ONLINE AUTHENTICATION";
            User_Name.Value = "<user>@<my site>.microsoft.com";
            //User_Name.ID = 2;

            IDTSCustomProperty100 Password = ComponentMetaData.CustomPropertyCollection.New();
            Password.Name = C_PASSWORD;
            Password.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
            Password.EncryptionRequired = true;
            Password.Description = "Password for sharepoint online user";
            Password.Value = "<Password>";
            //Password.ID = 3;


            var sharepointListName = ComponentMetaData.CustomPropertyCollection.New();
            sharepointListName.Name = C_SHAREPOINTLISTNAME;
            sharepointListName.Description = "Name of the SharePoint list to load data from.";
            sharepointListName.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;

            var sharepointListViewName = ComponentMetaData.CustomPropertyCollection.New();
            sharepointListViewName.Name = C_SHAREPOINTLISTVIEWNAME;
            sharepointListViewName.Description = "Name of the view within SharePoint list to load data from.";
            sharepointListViewName.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;

            var sharepointCulture = ComponentMetaData.CustomPropertyCollection.New();
            sharepointCulture.Name = C_SHAREPOINTCULTURE;
            sharepointCulture.Description = "Culture to use when communicating with remote SharePoint Server (en-US).";
            sharepointCulture.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
            sharepointCulture.Value = "en-US";

            var batchSize = ComponentMetaData.CustomPropertyCollection.New();
            batchSize.Name = C_BATCHSIZE;
            batchSize.Value = (short)200;
            batchSize.Description = "# of elements to pull from the Webservice at a time.";
            batchSize.TypeConverter = typeof(short).AssemblyQualifiedName;

            var batchType = ComponentMetaData.CustomPropertyCollection.New();
            batchType.Name = C_BATCHTYPE;
            batchType.Value = Enums.BatchType.Modification;
            batchType.Description = "Determine if the destination rows are Modifications (udpates and inserts), or Deletions.  Updates and Deletes must have an ID Column with the SharePoint ID. ";
            batchType.TypeConverter = typeof(Enums.BatchType).AssemblyQualifiedName;

            var useConnectionManager = ComponentMetaData.CustomPropertyCollection.New();
            useConnectionManager.Name = C_CONNECTIONMANAGER;
            useConnectionManager.Value = Enums.TrueFalseValue.True;
            useConnectionManager.Description = "Whether to use a connection manager for this component";
            useConnectionManager.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;

            var input = ComponentMetaData.InputCollection.New();
            input.Name = "Component Input";
            input.Description = "This is what we see from the upstream component";
            input.HasSideEffects = true;

        }


        /// <summary>
        /// Called at design time and runtime. Establishes a connection using a ConnectionManager in the package.
        /// </summary>
        /// <param name="transaction">Not used.</param>
        public override void AcquireConnections(object transaction)
        {
            // Change default connection to use the system credential
            _credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            _credentials.UserName = ComponentMetaData.CustomPropertyCollection[C_USERNAME].Value;
            _credentials.Password = ComponentMetaData.CustomPropertyCollection[C_PASSWORD].Value;

        }
        /// <summary>
        /// The Validate() function is mostly called during the design-time phase of 
        /// the component. Its main purpose is to perform validation of the contents of the component.
        /// </summary>
        /// <returns></returns>
        [CLSCompliant(false)]
        public override DTSValidationStatus Validate()
        {
            bool canCancel = false;

            if (ComponentMetaData.OutputCollection.Count != 0)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "Unexpected Output found. Destination components do not support outputs.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISCORRUPT;
            }

            if (ComponentMetaData.InputCollection.Count != 1)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "There must be one input into this component.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISCORRUPT;
            }


            if (ComponentMetaData.AreInputColumnsValid == false)
            {
                return DTSValidationStatus.VS_NEEDSNEWMETADATA;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTCULTURE].Value == null) ||
                (((string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTCULTURE].Value).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "A culture for the target SharePoint server must be specified.",
                    "", 0, out canCancel);
            }
            else
            {
                string cultureCode = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTCULTURE].Value;
                var cultureList = CultureInfo.GetCultures(CultureTypes.FrameworkCultures);
                _culture = (from c in cultureList
                            where c.Name.ToUpper(CultureInfo.InvariantCulture) == cultureCode.ToUpper(CultureInfo.InvariantCulture)
                            select c).Single();
                if (_culture == null)
                {
                    // Column names do not match, request new data.
                    ComponentMetaData.FireError(0, ComponentMetaData.Name,
                        "Culture '" + cultureCode + "' is not a recognized MS Framework Language Culture (ex: en-US).",
                        "", 0, out canCancel);
                }
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value == null) ||
                (((string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value).Length == 0))
            {

                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "SharePoint URL has not been set.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value == null) ||
                (((string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "SharePoint URL has not been set.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }


            //Validate UserName and Password
            if ((ComponentMetaData.CustomPropertyCollection[C_USERNAME].Value == null) ||
             ((ComponentMetaData.CustomPropertyCollection[C_USERNAME].Value.ToString()).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "You must set username.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_PASSWORD].Value == null) ||
         ((ComponentMetaData.CustomPropertyCollection[C_PASSWORD].Value.ToString()).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "You must set password.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }




            if ((ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value == null) ||
                (((string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "SharePoint list name has not been set.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_BATCHSIZE].Value == null) ||
                ((short)ComponentMetaData.CustomPropertyCollection[C_BATCHSIZE].Value) == 0)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "Batch Size must be set greater than 0.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_BATCHTYPE].Value == null) ||
                ((ComponentMetaData.CustomPropertyCollection[C_BATCHTYPE].Value.ToString()).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "You must set whether to process the batch as a modification or a deletion.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.InputCollection.Count == 0))
            {
                return DTSValidationStatus.VS_NEEDSNEWMETADATA;
            }

            // Validate the columns defined against an actual SharePoint Site
            var isValid = ValidateSharePointColumns();
            if (isValid != DTSValidationStatus.VS_ISVALID)
                return isValid;

            return base.Validate();
        }

        /// <summary>
        /// Lookup the data dynamically against the SharePoint, and check if the columns marked for output exist
        /// exist and are up to date.
        /// </summary>
        /// <returns></returns>
        private DTSValidationStatus ValidateSharePointColumns()
        {
            bool canCancel;

            // Check the input columns and see if they are the same as the # of columns in the selected list
            string sharepointUrl = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            string listName = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;
            string viewName = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value;

            // Get the column information from SharePoint
            List<SharePointUtilityOnline.DataObject.ColumnData> accessibleColumns = null;
            try
            {
                accessibleColumns = GetAccessibleSharePointColumns(sharepointUrl, listName, viewName);
            }
            catch (SharePointUnhandledException)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "Failed to get list data from SharePoint Webservice - Site: " + sharepointUrl + ", List: " + listName,
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            // Get the field names of the columns
            var fieldNames = (from col in ComponentMetaData.InputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                              select (string)col.CustomPropertyCollection["Id"].Value).ToArray();

            // Join them together and see if we get the full sharepoint column list. 
            if ((from spCol in accessibleColumns
                 join inputCol in fieldNames on spCol.Name equals inputCol
                 select spCol).Count() != fieldNames.Count())
            {
                // Column names do not match, request new data.
                return DTSValidationStatus.VS_NEEDSNEWMETADATA;
            }

            // Verify the field mappings by getting the column and the meta column after joining them together
            var mappedFields =
               from col in
                   ComponentMetaData.InputCollection[0].InputColumnCollection.Cast<IDTSInputColumn>()
               join metaCol in ComponentMetaData.InputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                  on col.ExternalMetadataColumnID equals metaCol.ID
               select new { col, metaCol };

            // Make sure at least one field is mapped.
            if (mappedFields.Count() == 0)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "There are no fields mapped to the output columns.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            // If deleting, make sure one of the columns is mapped to the SharePoint ID column, or 
            // else the adapter will not know what to delete.
            if (((Enums.BatchType)ComponentMetaData.CustomPropertyCollection[C_BATCHTYPE].Value ==
                Enums.BatchType.Deletion))
            {
                if ((from col in mappedFields
                     where (string)col.metaCol.CustomPropertyCollection["Id"].Value == "ID"
                     select col).FirstOrDefault() == null)
                {
                    ComponentMetaData.FireError(0, ComponentMetaData.Name,
                        "You must map a column from the input for the ID output column if deleting data.",
                        "", 0, out canCancel);
                    return DTSValidationStatus.VS_ISBROKEN;
                }
            }

            return DTSValidationStatus.VS_ISVALID;
        }


        /// <summary>
        /// The ReinitializeMetaData() method will be called when the Validate() function returns VS_NEEDSNEWMETADATA. 
        /// Its primary purpose is to repair the component's metadata to a consistent state.
        /// </summary>
        public override void ReinitializeMetaData()
        {
            if (ComponentMetaData.InputCollection.Count > 0)
            {
                var input = ComponentMetaData.InputCollection[0];

                // Capture the existing column names and detail data before data is re-initialized.
                _existingColumnData =
                    (from metaCol in
                         input.ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                     select new
                     {
                         ColumnName = (string)metaCol.Name,
                         SpColName = (string)metaCol.CustomPropertyCollection["Id"].Value
                     }).ToDictionary(a => a.SpColName, a => a.ColumnName);

                // Reset the input columns
                ComponentMetaData.InputCollection[0].InputColumnCollection.RemoveAll();

                // Reload the input path columns
                OnInputPathAttached(ComponentMetaData.InputCollection[0].ID);
            }

            base.ReinitializeMetaData();
        }

        /// <summary>
        /// Setup the metadata and link to this object
        /// </summary>
        /// <param name="inputID"></param>
        public override void OnInputPathAttached(int inputID)
        {
            var input = ComponentMetaData.InputCollection.GetObjectByID(inputID);
            var vInput = input.GetVirtualInput();
            foreach (IDTSVirtualInputColumn vCol in vInput.VirtualInputColumnCollection)
            {
                this.SetUsageType(inputID, vInput, vCol.LineageID, DTSUsageType.UT_READONLY);
            }

            // Load meta information and map to columns
            input.ExternalMetadataColumnCollection.RemoveAll();

            // If the existing columns are not set yet, then initialize them.
            if (_existingColumnData == null)
                _existingColumnData = new Dictionary<string, string>();

            LoadDataSourceInformation(_existingColumnData);
        }

        /// <summary>
        /// Lodas the column data into the dts objects from the datasource for columns
        /// </summary>
        private void LoadDataSourceInformation(Dictionary<string, string> existingColumnData)
        {
            object sharepointUrl = ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            object sharepointListName = ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;

            if (ComponentMetaData.InputCollection.Count == 1)
            {
                var input = ComponentMetaData.InputCollection[0];

                // Reset the values
                if ((sharepointUrl != null) && (sharepointListName != null))
                {
                    CreateExternalMetaDataColumns(input,
                        (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value,
                        (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value,
                        (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value,
                        existingColumnData);
                }
            }
        }

        /// <summary>
        /// Get the columns that are public
        /// </summary>
        /// <param name="sharepointUrl"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        private List<SharePointUtilityOnline.DataObject.ColumnData>
            GetAccessibleSharePointColumns(string sharepointUrl, string listName, string viewName)
        {
            List<SharePointUtilityOnline.DataObject.ColumnData> columnList =
                ListServiceUtility.GetFields(new Uri(sharepointUrl), _credentials, listName, viewName);

            // Pull out the ID Field because we want this to be first in the list, and the other columns
            // will keep their order that SharePoint sends them.
            var idField =
                from c in columnList
                where (c.Name == "ID" || c.Name == "FsObjType")
                select c;

            var accessibleColumns =
                from c in columnList
                where (!c.IsHidden && !c.IsReadOnly)
                select c;

            return idField.Union(accessibleColumns).ToList();
        }

        /// <summary>
        /// Connects to SharePoint and gets any columns on the target
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sharepointUrl"></param>
        /// <param name="listName"></param>
        private void CreateExternalMetaDataColumns(
            IDTSInput input, string sharepointUrl, string listName, string viewName,
            Dictionary<string, string> existingColumnData)
        {
            // No need to load if the Url is bad.
            if ((sharepointUrl == null) || (sharepointUrl.Length == 0))
                return;

            // Need a list to continue
            if ((listName == null) || (listName.Length == 0))
                return;

            input.ExternalMetadataColumnCollection.IsUsed = true;

            // If the list has changed, then we do not want any of the exisiting column data to
            // influence it (provides a way to actually reset the names if needed)
            if (input.Description != listName)
            {
                existingColumnData.Clear();
                input.Description = listName;
            }

            try
            {
                List<SharePointUtilityOnline.DataObject.ColumnData> accessibleColumns =
                    GetAccessibleSharePointColumns(sharepointUrl, listName, viewName);

                // Group the friendly names which are duplicated
                var dupeNames = from n in accessibleColumns
                                group n by n.FriendlyName into g
                                where g.Count() > 1
                                select g.Key;


                foreach (var column in accessibleColumns)
                {
                    // Setup the primary column details from the List
                    var dtsColumnMeta = input.ExternalMetadataColumnCollection.New();
                    if (existingColumnData.ContainsKey(column.Name))
                    {
                        dtsColumnMeta.Name = existingColumnData[column.Name];
                    }
                    else if (dupeNames.Contains(column.FriendlyName))
                    {
                        // Add the more descriptive name after the duplicate names
                        dtsColumnMeta.Name = column.FriendlyName + " (" + column.Name + ")";
                    }
                    else
                    {
                        dtsColumnMeta.Name = column.FriendlyName;
                    }

                    dtsColumnMeta.Description = column.DisplayName;
                    dtsColumnMeta.Length = 0;
                    dtsColumnMeta.Precision = 0;
                    dtsColumnMeta.Scale = 0;
                    if ("Boolean|AllDayEvent|Attachments|CrossProjectLink|Recurrence".Contains(column.SharePointType))
                    {
                        dtsColumnMeta.DataType = DataType.DT_BOOL;
                    }
                    else if (column.SharePointType == "DateTime")
                    {
                        dtsColumnMeta.DataType = DataType.DT_DBTIMESTAMP;
                    }
                    else if ("Number|Currency".Contains(column.SharePointType))
                    {
                        // Max = 100,000,000,000.00000
                        dtsColumnMeta.DataType = DataType.DT_R8;
                    }
                    else if ("Counter|Integer".Contains(column.SharePointType))
                    {
                        dtsColumnMeta.DataType = DataType.DT_I4;
                    }
                    else if ("Guid".Contains(column.SharePointType))
                    {
                        dtsColumnMeta.DataType = DataType.DT_GUID;
                    }
                    else
                    {
                        if (column.MaxLength == -1)
                        {
                            dtsColumnMeta.DataType = DataType.DT_NTEXT;
                            dtsColumnMeta.Length = 0;
                        }
                        else
                        {
                            dtsColumnMeta.DataType = DataType.DT_WSTR;
                            dtsColumnMeta.Length = column.MaxLength;
                        }
                    }

                    var fieldNameMeta = dtsColumnMeta.CustomPropertyCollection.New();
                    fieldNameMeta.Name = "Id";
                    fieldNameMeta.Description = "SharePoint ID";
                    fieldNameMeta.Value = column.Name;

                    // Map any columns found with the same name in the input
                    var foundCol =
                        (from col in input.InputColumnCollection.Cast<IDTSInputColumn>()
                         where col.Name == dtsColumnMeta.Name
                         select col).SingleOrDefault();
                    if (foundCol != null)
                    {
                        foundCol.ExternalMetadataColumnID = dtsColumnMeta.ID;
                    }
                }
            }
            catch (SharePointUnhandledException)
            {
                // Exception happened, so clear the columns, which will invalidate this object.
                input.ExternalMetadataColumnCollection.RemoveAll();
                throw;
            }

        }

        /// <summary>
        /// Enables updating of an existing version of a component to a newer version
        /// </summary>
        /// <param name="pipelineVersion">Seems to always be 0</param>
        public override void PerformUpgrade(int pipelineVersion)
        {
            ComponentMetaData.CustomPropertyCollection["UserComponentTypeName"].Value = this.GetType().AssemblyQualifiedName;

            var sharepointListViewName = FindCustomProperty(C_SHAREPOINTLISTVIEWNAME);
            if (sharepointListViewName == null)
            {
                sharepointListViewName = ComponentMetaData.CustomPropertyCollection.New();
                sharepointListViewName.Name = C_SHAREPOINTLISTVIEWNAME;
                sharepointListViewName.Description = "Name of the view within SharePoint list to load data from.";
                sharepointListViewName.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
            }

            var sharepointCulture = FindCustomProperty(C_SHAREPOINTCULTURE);
            if (sharepointCulture == null)
            {
                sharepointCulture = ComponentMetaData.CustomPropertyCollection.New();
                sharepointCulture.Name = C_SHAREPOINTCULTURE;
                sharepointCulture.Description = "Culture to use when communicating with remote SharePoint Server (en-US).";
                sharepointCulture.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
                sharepointCulture.Value = "en-US";
            }

            var connectionManager = FindCustomProperty(C_CONNECTIONMANAGER);
            if (connectionManager == null)
            {
                connectionManager = ComponentMetaData.CustomPropertyCollection.New();
                connectionManager.Name = C_CONNECTIONMANAGER;
                connectionManager.Value = Enums.TrueFalseValue.True;
                connectionManager.Description = "Whether to use a connection manager for this component";
                connectionManager.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;
            }
        }

        /// <summary>
        /// Finds a property by name if it exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private IDTSCustomProperty FindCustomProperty(string name)
        {
            foreach (IDTSCustomProperty property in ComponentMetaData.CustomPropertyCollection)
            {
                if (property.Name.ToUpper() == name.ToUpper())
                    return property;
            }
            return null;

        }

        #endregion

        #region Runtime Methods
        /// <summary>
        /// Do any initial setup operations
        /// </summary>
        public override void PreExecute()
        {
            base.PreExecute();

            // Get the field names from the input collection
            _bufferLookup = (from col in
                                 ComponentMetaData.InputCollection[0].InputColumnCollection.Cast<IDTSInputColumn>()
                             join metaCol in ComponentMetaData.InputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                                  on col.ExternalMetadataColumnID equals metaCol.ID
                             select new
                             {
                                 Name = (string)metaCol.CustomPropertyCollection["Id"].Value,
                                 BufferColumn = BufferManager.FindColumnByLineageID(ComponentMetaData.InputCollection[0].Buffer, col.LineageID)
                             }).ToDictionary(a => a.Name, a => a.BufferColumn);

            // Get the field data types from the input collection
            _bufferLookupDataType = (from col in
                                         ComponentMetaData.InputCollection[0].InputColumnCollection.Cast<IDTSInputColumn>()
                                     join metaCol in ComponentMetaData.InputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                                          on col.ExternalMetadataColumnID equals metaCol.ID
                                     select new
                                     {
                                         Name = (string)metaCol.CustomPropertyCollection["Id"].Value,
                                         DataType = col.DataType
                                     }).ToDictionary(a => a.Name, a => a.DataType);
        }

        /// <summary>
        /// This is where the data is read from the input buffer
        /// </summary>
        /// <param name="inputID"></param>
        /// <param name="buffer"></param>
        public override void ProcessInput(int inputID, PipelineBuffer buffer)
        {
            string sharepointUrl = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            string sharepointList = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;
            string sharepointListView = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value;
            short batchSize = (short)ComponentMetaData.CustomPropertyCollection[C_BATCHSIZE].Value;
            Enums.BatchType batchType = (Enums.BatchType)ComponentMetaData.CustomPropertyCollection[C_BATCHTYPE].Value;

            if (!buffer.EndOfRowset)
            {
                // Queue the data up for batching by the sharepoint accessor object
                var dataQueue = new List<Dictionary<string, string>>();
                while (buffer.NextRow())
                {
                    var rowData = new Dictionary<string, string>();
                    foreach (var fieldName in _bufferLookup.Keys)
                    {
                        if (buffer.IsNull(_bufferLookup[fieldName]))
                        {
                            // Do nothing, can ignore this field
                        }
                        else
                        {
                            switch (_bufferLookupDataType[fieldName])
                            {
                                case DataType.DT_STR:
                                case DataType.DT_WSTR:
                                    rowData.Add(fieldName, buffer.GetString(_bufferLookup[fieldName]));
                                    break;
                                case DataType.DT_NTEXT:
                                    int colDataLength = (int)buffer.GetBlobLength(_bufferLookup[fieldName]);
                                    byte[] stringData = buffer.GetBlobData(_bufferLookup[fieldName], 0, colDataLength);
                                    rowData.Add(fieldName, Encoding.Unicode.GetString(stringData));
                                    break;
                                case DataType.DT_R4:
                                    rowData.Add(fieldName, buffer.GetSingle(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_CY:
                                    rowData.Add(fieldName, buffer.GetDecimal(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_R8:
                                    rowData.Add(fieldName, buffer.GetDouble(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_UI1:
                                case DataType.DT_I1:
                                case DataType.DT_BOOL:
                                    rowData.Add(fieldName, buffer.GetBoolean(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_UI2:
                                case DataType.DT_I2:
                                    rowData.Add(fieldName, buffer.GetInt16(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_UI4:
                                case DataType.DT_I4:
                                    rowData.Add(fieldName, buffer.GetInt32(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_UI8:
                                case DataType.DT_I8:
                                    rowData.Add(fieldName, buffer.GetInt64(_bufferLookup[fieldName]).ToString(_culture));
                                    break;
                                case DataType.DT_GUID:
                                    rowData.Add(fieldName, buffer.GetGuid(_bufferLookup[fieldName]).ToString());
                                    break;
                                case DataType.DT_DBTIMESTAMP:
                                    rowData.Add(fieldName, buffer.GetDateTime(_bufferLookup[fieldName]).ToString("u").Replace(" ", "T"));
                                    break;
                            }
                        }
                    }
                    dataQueue.Add(rowData);
                }

                bool fireAgain = false;
                if (dataQueue.Count() > 0)
                {
                    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
                    timer.Start();
                    System.Xml.Linq.XElement resultData;
                    if (batchType == Enums.BatchType.Modification)
                    {
                        // Perform the update
                        resultData = SharePointUtilityOnline.ListServiceUtility.UpdateListItems(
                            new Uri(sharepointUrl), _credentials, sharepointList, sharepointListView, dataQueue, batchSize);

                    }
                    else
                    {
                        // Get the IDs read from the buffer
                        var idList = from data in dataQueue
                                     where data["ID"].Trim().Length > 0
                                     select data["ID"];

                        // Delete the list items with IDs
                        resultData = SharePointUtilityOnline.ListServiceUtility.DeleteListItems(
                            new Uri(sharepointUrl), _credentials, sharepointList, sharepointListView, idList);
                    }
                    timer.Stop();
                    var errorRows = from result in resultData.Descendants("errorCode")
                                    select result.Parent;

                    int successRowsWritten = resultData.Elements().Count() - errorRows.Count();
                    string infoMsg = string.Format(CultureInfo.InvariantCulture,
                        "Affected {0} records in list '{1}' at '{2}'. Elapsed time is {3}ms",
                        successRowsWritten,
                        sharepointList,
                        sharepointUrl,
                        timer.ElapsedMilliseconds);
                    ComponentMetaData.FireInformation(0, ComponentMetaData.Name, infoMsg, "", 0, ref fireAgain);
                    ComponentMetaData.IncrementPipelinePerfCounter(
                        DTS_PIPELINE_CTR_ROWSWRITTEN, (uint)successRowsWritten);

                    // Shovel any error rows to the error flow
                    bool cancel;
                    int errorIter = 0;
                    foreach (var row in errorRows)
                    {
                        // Do not flood the error log.
                        errorIter++;
                        if (errorIter > 10)
                        {
                            ComponentMetaData.FireError(0,
                                ComponentMetaData.Name,
                                "Total of " + errorRows.Count().ToString(_culture) + ", only  showing first 10.", "", 0, out cancel);
                            return;

                        }

                        string idString = "";
                        XAttribute attrib = row.Element("row").Attribute("ID");
                        if (attrib != null)
                            idString = "(SP ID=" + attrib.Value + ")";

                        string errorString = string.Format(CultureInfo.InvariantCulture,
                            "Error on row {0}: {1} - {2} {3}",
                            row.Attribute("ID"),
                            row.Element("errorCode").Value,
                            row.Element("errorDescription").Value,
                            idString);

                        ComponentMetaData.FireError(0, ComponentMetaData.Name, errorString, "", 0, out cancel);

                        // Need to throw an exception, or else this step's box is green (should be red), even though the flow
                        // is marked as failure regardless.
                        throw new PipelineProcessException("Errors detected in this component - see SSIS Errors");
                    }
                }
                else
                {
                    ComponentMetaData.FireInformation(0, ComponentMetaData.Name,
                        "No rows found to update in destination.", "", 0, ref fireAgain);
                }
            }
        }
        #endregion
    }
}
