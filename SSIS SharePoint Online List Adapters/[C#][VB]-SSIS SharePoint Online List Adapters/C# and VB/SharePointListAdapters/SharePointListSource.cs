using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.Samples.SqlServer.SSIS.SharePointUtility;
using IDTSInputColumnCollection = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSInputColumnCollection100;
using IDTSExternalMetadataColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSExternalMetadataColumn100;
using IDTSOutput = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSOutput100;
using IDTSOutputColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSOutputColumn100;
using IDTSCustomProperty = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSCustomProperty100;
using IDTSVirtualInputColumn = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSVirtualInputColumn100;
using IDTSRuntimeConnection = Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSRuntimeConnection100;

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListAdapters
{
	[DtsPipelineComponent(DisplayName = "SharePoint List Source",
		CurrentVersion = 8,
		IconResource = "Microsoft.Samples.SqlServer.SSIS.SharePointListAdapters.Icons.SharePointSource.ico",
		Description = "Extract data from SharePoint lists",
		ComponentType = ComponentType.SourceAdapter)]
    public class SharePointListSource : PipelineComponent
    {
        private const int DTS_PIPELINE_CTR_ROWSREAD = 101;
        private const int CURRENT_PROP_TOTAL = 6;
        private const string C_SHAREPOINTSITEURL = "SiteUrlNick";
        private const string C_SHAREPOINTLISTNAME = "SiteListName";
        private const string C_SHAREPOINTLISTVIEWNAME = "SiteListViewName";

        private const string C_USERNAME = "Username";
        private const string C_PASSWORD = "Password";


        private const string C_SHAREPOINTCULTURE = "SharePointCulture";
        private const string C_CAMLQUERY = "CamlQuery";
        private const string C_BATCHSIZE = "BatchSize";
        private const string C_ISRECURSIVE = "IsRecursive";
        private const string C_INCLUDEFOLDERS = "IncludeFolders";
        private const string C_INCLUDEHIDDEN = "IncludeHiddenColumns";
        private const string C_DECODELOOKUPS = "DecodeLookupColumns";
        private const string C_CONNECTIONMANAGER = "UseConnectionManager";
        private Dictionary<string, int> _bufferLookup;
        private Dictionary<string, DataType> _bufferLookupDataType;
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
            sharepointUrl.Description = "Path to SharePoint site / subsite that contains the list.";
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

            var sharepointCamlQuery = ComponentMetaData.CustomPropertyCollection.New();
            sharepointCamlQuery.Name = C_CAMLQUERY;
            sharepointCamlQuery.Description = "CAML Query to use to more specifically pull back the rows you are interested in from SharePoint (Look up syntax of using this XML Element: <Query />)";
            sharepointCamlQuery.Value = "<Query />";
            sharepointCamlQuery.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;

            var batchSize = ComponentMetaData.CustomPropertyCollection.New();
            batchSize.Name = C_BATCHSIZE;
            batchSize.Value = (short)1000;
            batchSize.Description = "# of elements to pull from the Webservice at a time.";
            batchSize.TypeConverter = typeof(short).AssemblyQualifiedName;

            var isRecursive = ComponentMetaData.CustomPropertyCollection.New();
            isRecursive.Name = C_ISRECURSIVE;
            isRecursive.Value = Enums.TrueFalseValue.False;
            isRecursive.Description = "When loading items, should subfolders within the list also be loaded. Set to 'true' to load child folders.";
            isRecursive.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;

            var includeFolders = ComponentMetaData.CustomPropertyCollection.New();
            includeFolders.Name = C_INCLUDEFOLDERS;
            includeFolders.Value = Enums.TrueFalseValue.False;
            includeFolders.Description = "Whether to return folders with the list content";
            includeFolders.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;

            var includeHidden = ComponentMetaData.CustomPropertyCollection.New();
            includeHidden.Name = C_INCLUDEHIDDEN;
            includeHidden.Value = Enums.TrueFalseValue.False;
            includeHidden.Description = "Whether to return colunmns SharePoint considers hidden";
            includeHidden.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;
            var decodeLookups = ComponentMetaData.CustomPropertyCollection.New();
            decodeLookups.Name = C_DECODELOOKUPS;
            decodeLookups.Value = Enums.TrueFalseValue.False;
            decodeLookups.Description = "Whether to decode lookups and make an ID/Value column for each (newline delimited)";
            decodeLookups.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;

            var useConnectionManager = ComponentMetaData.CustomPropertyCollection.New();
            useConnectionManager.Name = C_CONNECTIONMANAGER;
            useConnectionManager.Value = Enums.TrueFalseValue.True;
            useConnectionManager.Description = "Whether to use a connection manager for this component";
            useConnectionManager.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;
            
            

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

            if ((ComponentMetaData.CustomPropertyCollection[C_ISRECURSIVE].Value == null) ||
                ((ComponentMetaData.CustomPropertyCollection[C_ISRECURSIVE].Value.ToString()).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "You must set whether to process the list recursively.",
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





            if ((ComponentMetaData.CustomPropertyCollection[C_INCLUDEFOLDERS].Value == null) ||
                ((ComponentMetaData.CustomPropertyCollection[C_INCLUDEFOLDERS].Value.ToString()).Length == 0))
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "You must set whether to include folders in the list output.",
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            if ((ComponentMetaData.CustomPropertyCollection[C_CAMLQUERY].Value == null) ||
                ((ComponentMetaData.CustomPropertyCollection[C_CAMLQUERY].Value.ToString()).Length != 0))
            {
                try
                {
                    XElement.Parse((string)ComponentMetaData.CustomPropertyCollection[C_CAMLQUERY].Value);
                }
                catch (System.Xml.XmlException)
                {
                    ComponentMetaData.FireError(0, ComponentMetaData.Name,
                        "The syntax for the CAML query provided is invalid XML.",
                        "", 0, out canCancel);
                    return DTSValidationStatus.VS_ISBROKEN;
                }
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

            if ((ComponentMetaData.OutputCollection.Count == 0))
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

            string sharepointUrl = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            string listName = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;
            string viewName = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value;
            // Get the column information from SharePoint
            List<SharePointUtility.DataObject.ColumnData> accessibleColumns = null;
            try
            {
                accessibleColumns = GetAccessibleSharePointColumns(sharepointUrl, listName, viewName);
            }
            catch (ApplicationException)
            {
                ComponentMetaData.FireError(0, ComponentMetaData.Name,
                    "Failed to get list data from SharePoint Webservice - Site: " + sharepointUrl + ", List: " + listName,
                    "", 0, out canCancel);
                return DTSValidationStatus.VS_ISBROKEN;
            }

            // Check the output columns and see if they are the same as the 
            // # of columns in the selected list
            if (accessibleColumns.Count < ComponentMetaData.OutputCollection[0].OutputColumnCollection.Count)
            {
                // Check to see if the columns match up
                return DTSValidationStatus.VS_NEEDSNEWMETADATA;
            }

            // Get the field names of the columns
            var fieldNames = (from col in ComponentMetaData.OutputCollection[0].OutputColumnCollection.Cast<IDTSOutputColumn>()
                              select (string)col.CustomPropertyCollection[0].Value).ToArray();


            // Join them together and see if the sharepoints in the metadata are the same as those
            // on the SharePoint site
            if ((from spCol in accessibleColumns
                 join outputCol in fieldNames on spCol.Name equals outputCol
                 select spCol).Count() != ComponentMetaData.OutputCollection[0].OutputColumnCollection.Count)
            {
                // Column names do not match, request new data.
                return DTSValidationStatus.VS_NEEDSNEWMETADATA;
            }

            return DTSValidationStatus.VS_ISVALID;
        }

        /// <summary>
        /// The ReinitializeMetaData() method will be called when the Validate() function returns VS_NEEDSNEWMETADATA. 
        /// Its primary purpose is to repair the component's metadata to a consistent state.
        /// </summary>
        public override void ReinitializeMetaData()
        {
            IDTSOutput output;
            var existingColumnData = new Dictionary<string, string>();

            if (ComponentMetaData.OutputCollection.Count == 0)
            {
                output = ComponentMetaData.OutputCollection.New();
                output.Name = "Public List Output";
                output.ExternalMetadataColumnCollection.IsUsed = true;
            }
            else
            {
                output = ComponentMetaData.OutputCollection[0];

                // Capture the existing column names and detail data
                existingColumnData =
                    (from col in
                         output.OutputColumnCollection.Cast<IDTSOutputColumn>()
                     join metaCol in output.ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                          on col.ExternalMetadataColumnID equals metaCol.ID
                     select new
                     {
                         ColumnName = (string)col.Name,
                         SpColName = (string)metaCol.CustomPropertyCollection["Id"].Value
                     }).ToDictionary(a => a.SpColName, a => a.ColumnName);

                output.OutputColumnCollection.RemoveAll();
                output.ExternalMetadataColumnCollection.RemoveAll();
            }

            // Reload in the output objects
            LoadDataSourceInformation(output, existingColumnData);

            base.ReinitializeMetaData();
        }

        /// <summary>
        /// Lodas the column data into the dts objects from the datasource for columns
        /// </summary>
        private void LoadDataSourceInformation(IDTSOutput output, Dictionary<string, string> existingColumnData)
        {
            object sharepointUrl = ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            object sharepointListName = ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;

            // Reset the values
            if ((sharepointUrl != null) && (sharepointListName != null))
            {
                CreateExternalMetaDataColumns(output,
                    (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value,
                    (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value,
                    (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value,
                    existingColumnData);
            }
        }

        /// <summary>
        /// Get the columns that are public
        /// </summary>
        /// <param name="sharepointUrl"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        private List<SharePointUtility.DataObject.ColumnData> GetAccessibleSharePointColumns(string sharepointUrl, string listName, string viewName)
        {
            List<SharePointUtility.DataObject.ColumnData> columnList =
                ListServiceUtility.GetFields(new Uri(sharepointUrl), _credentials, listName, viewName);

            // Pull out the ID Field because we want this to be first in the list, and the other columns
            // will keep their order that SharePoint sends them.
            var idField =
                from c in columnList
                where c.Name == "ID"
                select c;

            bool expandLookups = false;
            var expandLookupsProperty = FindCustomProperty(C_DECODELOOKUPS);
            if ((Enums.TrueFalseValue)expandLookupsProperty.Value == Enums.TrueFalseValue.True)
                expandLookups = true;

            
            // Consult the property to determine if we're doing any filtering here
            bool includeHidden = false;
            var includeHiddenProperty = FindCustomProperty(C_INCLUDEHIDDEN);
            if ((Enums.TrueFalseValue) includeHiddenProperty.Value == Enums.TrueFalseValue.True)
                includeHidden = true;

            var accessibleColumns =
                (from c in columnList
                where (c.IsHidden == includeHidden
                  || c.IsHidden == false) 
                select c).ToArray();

            if (expandLookups)
            {
                // Add the columns that are not raw and remove the 'raw' columns.
                var lookupColumns =
                    from c in accessibleColumns
                    where c.LookupFieldDisplay != SharePointUtility.DataObject.ColumnData.EncodedFieldDisplayEnum.DisplayRaw
                    select c;

                var exclusionList = 
                    from x in accessibleColumns
                    join c in lookupColumns on x.SourceFieldName equals c.SourceFieldName
                    where x.LookupFieldDisplay == SharePointUtility.DataObject.ColumnData.EncodedFieldDisplayEnum.DisplayRaw
                    select x;

                var outputColumns = accessibleColumns.Except(exclusionList);

                return idField.Union(outputColumns).ToList();
            }
            else
            {
                // Add the columns that are not raw and remove the 'raw' columns.
                var lookupColumns =
                    from c in accessibleColumns
                    where c.LookupFieldDisplay != SharePointUtility.DataObject.ColumnData.EncodedFieldDisplayEnum.DisplayRaw
                    select c;

                var outputColumns = accessibleColumns.Except(lookupColumns);

                return idField.Union(outputColumns).ToList();
            
            }
        }

        /// <summary>
        /// Connects to SharePoint and gets any columns on the target
        /// </summary>
        /// <param name="output"></param>
        /// <param name="p"></param>
        private void CreateExternalMetaDataColumns(
            IDTSOutput output, string sharepointUrl, string listName, string viewName,
            Dictionary<string, string> existingColumnData)
        {
            // No need to load if the Url is bad.
            if ((sharepointUrl == null) || (sharepointUrl.Length == 0))
                return;

            // Need a list to continue
            if ((listName == null) || (listName.Length == 0))
                return;

            // If the list has changed, then we do not want any of the exisiting column data to
            // influence it (provides a way to actually reset the names if needed)
            if (output.Description != listName)
            {
                existingColumnData.Clear();
                output.Description = listName;
            }

            try
            {
                List<SharePointUtility.DataObject.ColumnData> accessibleColumns =
                    GetAccessibleSharePointColumns(sharepointUrl, listName, viewName);

                // Group the friendly names which are duplicated
                var dupeNames = from n in accessibleColumns
                                group n by n.FriendlyName into g
                                where g.Count() > 1
                                select g.Key;

                foreach (var column in accessibleColumns)
                {
                    // Setup the primary column details from the List
                    IDTSExternalMetadataColumn dtsColumnMeta = output.ExternalMetadataColumnCollection.New();
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

                    IDTSCustomProperty fieldNameMeta = dtsColumnMeta.CustomPropertyCollection.New();
                    fieldNameMeta.Name = "Id";
                    fieldNameMeta.Description = "SharePoint ID";
                    fieldNameMeta.Value = column.Name;

                    // Create default output columns for all of the fields returned and link to the original columns
                    IDTSOutputColumn dtsColumn = output.OutputColumnCollection.New();
                    dtsColumn.Name = dtsColumnMeta.Name;
                    dtsColumn.Description = dtsColumnMeta.Description;
                    dtsColumn.ExternalMetadataColumnID = dtsColumnMeta.ID;

                    IDTSCustomProperty fieldName = dtsColumn.CustomPropertyCollection.New();
                    fieldName.Name = fieldNameMeta.Name;
                    fieldName.Description = fieldNameMeta.Description;
                    fieldName.Value = fieldNameMeta.Value;

                    dtsColumn.SetDataTypeProperties(
                        dtsColumnMeta.DataType, dtsColumnMeta.Length, dtsColumnMeta.Precision, dtsColumnMeta.Scale, 0);
                }
            }
            catch (ApplicationException)
            {
                // Exception happened, so clear the columns, which will invalidate this object.
                output.ExternalMetadataColumnCollection.RemoveAll();
            }

        }

        /// <summary>
        /// Allow the user to change a String to a NText, although this may affect performance.
        /// </summary>
        /// <param name="outputID"></param>
        /// <param name="outputColumnID"></param>
        /// <param name="dataType"></param>
        /// <param name="length"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="codePage"></param>
        public override void SetOutputColumnDataTypeProperties(int outputID, int outputColumnID, Microsoft.SqlServer.Dts.Runtime.Wrapper.DataType dataType, int length, int precision, int scale, int codePage)
        {
            var outputColl = this.ComponentMetaData.OutputCollection;
            IDTSOutput output = outputColl.GetObjectByID(outputID);

            var columnColl = output.OutputColumnCollection;
            IDTSOutputColumn column = columnColl.GetObjectByID(outputColumnID);

            var sourceColl = output.ExternalMetadataColumnCollection;
            IDTSExternalMetadataColumn columnSource = sourceColl.GetObjectByID(column.ExternalMetadataColumnID);

            if (((column.DataType == DataType.DT_WSTR) || (column.DataType == DataType.DT_NTEXT))
                && ((dataType == DataType.DT_NTEXT) || (dataType == DataType.DT_WSTR)))
            {
                column.SetDataTypeProperties(dataType, length, precision, scale, codePage);
            }
            else
            {
                base.SetOutputColumnDataTypeProperties(outputID, outputColumnID, dataType, length, precision, scale, codePage);
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

            var includeHidden = FindCustomProperty(C_INCLUDEHIDDEN);
            if (includeHidden == null)
            {
                includeHidden = ComponentMetaData.CustomPropertyCollection.New();
                includeHidden.Name = C_INCLUDEHIDDEN;
                includeHidden.Value = Enums.TrueFalseValue.False;
                includeHidden.Description = "Whether to return colunmns SharePoint considers hidden";
                includeHidden.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;
            }

            var decodeLookups = FindCustomProperty(C_DECODELOOKUPS);
            if (decodeLookups == null)
            {
                decodeLookups = ComponentMetaData.CustomPropertyCollection.New();
                decodeLookups.Name = C_DECODELOOKUPS;
                decodeLookups.Value = Enums.TrueFalseValue.False;
                decodeLookups.Description = "Whether to decode lookups and make an ID/Value column for each (newline delimited)";
                decodeLookups.TypeConverter = typeof(Enums.TrueFalseValue).AssemblyQualifiedName;
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
                                 ComponentMetaData.OutputCollection[0].OutputColumnCollection.Cast<IDTSOutputColumn>()
                             join metaCol in ComponentMetaData.OutputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                                  on col.ExternalMetadataColumnID equals metaCol.ID
                             select new
                             {
                                 Name = (string)metaCol.CustomPropertyCollection["Id"].Value,
                                 BufferColumn = BufferManager.FindColumnByLineageID(ComponentMetaData.OutputCollection[0].Buffer, col.LineageID)
                             }).ToDictionary(a => a.Name, a => a.BufferColumn);

            // Get the field data types from the input collection
            _bufferLookupDataType = (from col in
                                         ComponentMetaData.OutputCollection[0].OutputColumnCollection.Cast<IDTSOutputColumn>()
                                     join metaCol in ComponentMetaData.OutputCollection[0].ExternalMetadataColumnCollection.Cast<IDTSExternalMetadataColumn>()
                                          on col.ExternalMetadataColumnID equals metaCol.ID
                                     select new
                                     {
                                         Name = (string)metaCol.CustomPropertyCollection["Id"].Value,
                                         DataType = metaCol.DataType
                                     }).ToDictionary(a => a.Name, a => a.DataType);
        }

        /// <summary>
        /// This is where the data is loaded into the output buffer
        /// </summary>
        /// <param name="outputs"></param>
        /// <param name="outputIDs"></param>
        /// <param name="buffers"></param>
        public override void PrimeOutput(int outputs, int[] outputIDs, PipelineBuffer[] buffers)
        {
            string sharepointUrl = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTSITEURL].Value;
            string sharepointList = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTNAME].Value;
            string sharepointListView = (string)ComponentMetaData.CustomPropertyCollection[C_SHAREPOINTLISTVIEWNAME].Value;
            XElement camlQuery = XElement.Parse((string)ComponentMetaData.CustomPropertyCollection[C_CAMLQUERY].Value);
            short batchSize = (short)ComponentMetaData.CustomPropertyCollection[C_BATCHSIZE].Value;
            Enums.TrueFalseValue isRecursive = (Enums.TrueFalseValue)ComponentMetaData.CustomPropertyCollection[C_ISRECURSIVE].Value;
            Enums.TrueFalseValue includeFolders = (Enums.TrueFalseValue)ComponentMetaData.CustomPropertyCollection[C_INCLUDEFOLDERS].Value;
            PipelineBuffer outputBuffer = buffers[0];

            // Get the field names from the output collection
            var fieldNames = (from col in
                                  ComponentMetaData.OutputCollection[0].OutputColumnCollection.Cast<IDTSOutputColumn>()
                              select (string)col.CustomPropertyCollection[0].Value).ToArray();

            // Load the data from sharepoint
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var listData = SharePointUtility.ListServiceUtility.GetListItemData(
                new Uri(sharepointUrl), _credentials, sharepointList, sharepointListView, fieldNames, camlQuery,
                isRecursive == Enums.TrueFalseValue.True ? true : false, batchSize);
            timer.Stop();
            bool fireAgain = false;

            int actualRowCount = 0;
            foreach (var row in listData)
            {
                // Determine if we should continue based on if this is a folder item or not (filter can be pushed up to CAML if
                // perf becomes an issue)
                bool canContinue = true;
                if ((row.ContainsKey("ContentType")) &&
                    (row["ContentType"] == "Folder") &&
                    (includeFolders == Enums.TrueFalseValue.False))
                {
                    canContinue = false;
                }

                if (canContinue)
                {
                    actualRowCount++;
                    outputBuffer.AddRow();
                    foreach (var fieldName in _bufferLookup.Keys)
                    {
                        if (row.ContainsKey(fieldName))
                        {
                            switch (_bufferLookupDataType[fieldName])
                            {
                                case DataType.DT_NTEXT:
                                    outputBuffer.AddBlobData(_bufferLookup[fieldName],
                                        Encoding.Unicode.GetBytes(row[fieldName].ToString()));
                                    break;
                                case DataType.DT_WSTR:
                                    outputBuffer.SetString(_bufferLookup[fieldName], row[fieldName]);
                                    break;
                                case DataType.DT_R8:
                                    outputBuffer.SetDouble(_bufferLookup[fieldName], double.Parse(row[fieldName], _culture));
                                    break;
                                case DataType.DT_I4:
                                    outputBuffer.SetInt32(_bufferLookup[fieldName], int.Parse(row[fieldName], _culture));
                                    break;
                                case DataType.DT_BOOL:
                                    outputBuffer.SetBoolean(_bufferLookup[fieldName], (int.Parse(row[fieldName], _culture) == 1));
                                    break;
                                case DataType.DT_GUID:
                                    outputBuffer.SetGuid(_bufferLookup[fieldName], new Guid(row[fieldName]));
                                    break;
                                case DataType.DT_DBTIMESTAMP:
                                    outputBuffer.SetDateTime(_bufferLookup[fieldName], DateTime.Parse(row[fieldName], _culture));
                                    break;
                            }
                        }
                        else
                        {
                            switch (_bufferLookupDataType[fieldName])
                            {
                                case DataType.DT_NTEXT:
                                    outputBuffer.AddBlobData(_bufferLookup[fieldName],
                                        Encoding.Unicode.GetBytes(String.Empty));
                                    break;
                                case DataType.DT_WSTR:
                                    outputBuffer.SetString(_bufferLookup[fieldName], String.Empty);
                                    break;
                                case DataType.DT_BOOL:
                                    outputBuffer.SetBoolean(_bufferLookup[fieldName], false);
                                    break;
                                default:
                                    outputBuffer.SetNull(_bufferLookup[fieldName]);
                                    break;
                            }

                        }
                    }
                }
            }

            string infoMsg = string.Format(CultureInfo.InvariantCulture,
                "Loaded {0} records from list '{1}' at '{2}'. Elapsed time is {3}ms",
                actualRowCount,
                sharepointList,
                sharepointUrl,
                timer.ElapsedMilliseconds);
            ComponentMetaData.FireInformation(0, ComponentMetaData.Name, infoMsg, "", 0, ref fireAgain);
            ComponentMetaData.IncrementPipelinePerfCounter(
                DTS_PIPELINE_CTR_ROWSREAD, (uint)actualRowCount);


            outputBuffer.SetEndOfRowset();
        }

        #endregion
    }

}
