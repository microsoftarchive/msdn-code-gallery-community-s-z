# Work with importing data
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Dynamics CRM SDK
## Updated
- 12/18/2017
## Description

<h1>Work with importing data</h1>
<p>If you want to import data into Microsoft Dynamics 365, you can use the <em>data import</em> feature. Data import lets you upload data from various customer relationship management systems and data sources into Microsoft Dynamics 365. You can import data
 into standard and customized attributes of most business and custom entities. You can also include related data, such as notes and attachments.</p>
<p>Microsoft Dynamics 365 includes a web application tool called Import Data Wizard. You use this tool to import data records from one or more comma-separated values (.csv), XML Spreadsheet 2003 (.xml), or text files.</p>
<p>The Microsoft Dynamics 365 web services provide the following additional capabilities that aren&rsquo;t available in the Import Data Wizard:<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Create data maps that include complex transformation mapping, such as concatenation, split, and replace.</p>
<li>Define custom transformation mapping. </li><li>View source data that is stored inside the temporary parse tables. </li><li>Access error logs to build custom error reporting tools with improved error logging views.
</li><li>Run data import by using command-line scripts. </li><li>Add <strong>LookupMap</strong>XML tags in the data map to indicate that the data lookup will be initiated and performed on a source file that is used in the import.
</li><li>Add custom <strong>OwnerMetadata</strong>XML tags in the data map to match the user records in the source file with the records of the user (system user) in Microsoft Dynamics 365.
</li><li>Use optional validation checks.
<p>To implement data import, you typically do the following:<strong>&nbsp;</strong><em></em></p>
<ul>
<li>Create a comma-separated values (CSV), XML Spreadsheet 2003 (XMLSS), or text source file.
</li><li>Parse the import file. </li><li>Upload the content from a source file to the associated import file. </li><li>Associate an import file with a data map. </li><li>Create a data map or use an existing data map. </li><li>Upload the transformed data into the target Microsoft Dynamics 365 server. </li><li>Transform the parsed data. </li></ul>
<p>You can import data from one source file or several source files. A source file can contain data for one entity type or multiple entity types.</p>
<p>Parsing, transforming, and uploading of data is done by the asynchronous jobs that run in the background.</p>
<p>The <strong>DataImport.sln</strong> file contains the following code samples.<strong></strong><em></em></p>
<h2>Requirements</h2>
<p>For more information about the requirements for running the sample code provided here, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code">
Use the sample and helper code</a>.</p>
<h2>Sample: Export and import a data map</h2>
<p>The sample shows how to create an import map (data map) in Microsoft Dynamics 365, export it as an XML formatted data, import modified mappings, and create a new import map in Dynamics 365 based on the imported mappings.</p>
<p>See the&nbsp;<strong>UsingExportAndImportMappings.cs</strong><em></em> sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-export-import-data-map">
Sample: Export and import a data map</a> and <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/create-data-maps-for-import" tabindex="0">
Create data maps for import</a></p>
<h2>Sample: Import data using complex data map</h2>
<p>The sample shows how to to create new records in Microsoft Dynamics 365 by using data import. The sample uses a complex data map.</p>
<p>See the <strong>ImportWithCreate.cs</strong> and&nbsp;<strong>BulkImportHelper.cs<em></em></strong> sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-import-data-complex-data-map">
Sample: Import data using complex data map</a> and <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/configure-data-import" tabindex="0">
Configure data import</a> <strong></strong><em></em></p>
</li>