# Sample: Create, retrieve, update, and delete (late bound)
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- CRUD operations in Dynamics 365
- Late bindind in Dynamics 365
## Updated
- 03/27/2018
## Description

<div class="content">
<div>
<div class="topic">
<h1 class="title">Sample: Create, retrieve, update, and delete (late bound)</h1>
<div id="mainSection">
<div id="mainBody">
<div class="introduction">
<p><span>This sample code is for Microsoft Dynamics 365 (online &amp; on-premises)</span>.&nbsp; It can be found in the files CRUDOperationsDE.cs and CompoundCreateUpdateDE.cs in the download package, Dyn365LateBound.zip.&nbsp; The package also contains supporting
 files, including helper code and Visual Studio configuration files. &nbsp;</p>
<p>The code in the first file sample demonstrates the basic CRUD (create, retrieve, update, and delete) operations on an account record using a late-bound Entity&nbsp;class instance. It uses a column set to define which optional attributes, specifically name
 and ownerid, should be retrieved. It then updates several attributes (of varying types), including postal code (string), revenue (Money), and creditonhold (boolean). Finally it prompts the user to delete this new account record.</p>
<p>The code in the second file demonstrates how to create and use compound Create and Update statements, and follows a similar construction.</p>
</div>
<div class="section">
<h2 class="heading">Requirements</h2>
<div class="section">
<p>For more information about the requirements for running the sample code provided in this package, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code" target="_blank">
Use the sample and helper code</a>.</p>
</div>
</div>
<div class="section">
<h2 class="heading">Example</h2>
<div class="description">
<div class="section">
<p>This sample demonstrates the create, retrieve, update, and delete operations on an account using the late bound Entity class.&nbsp; This code is found in the source file&nbsp;CRUDOperationsDE.cs. &nbsp;<strong>&nbsp;</strong><em>&nbsp;</em></p>
</div>
</div>
<div class="codeSnippetContainer" id="code-snippet-1">
<div class="code">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp">      

using System;
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ServiceModel.aspx" target="_blank" title="Auto generated link to System.ServiceModel">System.ServiceModel</a>;
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ServiceModel.Description.aspx" target="_blank" title="Auto generated link to System.ServiceModel.Description">System.ServiceModel.Description</a>;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// found in the SDK\bin folder.
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk">Microsoft.Xrm.Sdk</a>;
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.Client.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk.Client">Microsoft.Xrm.Sdk.Client</a>;
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.Query.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk.Query">Microsoft.Xrm.Sdk.Query</a>;
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.Discovery.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk.Discovery">Microsoft.Xrm.Sdk.Discovery</a>;

namespace Microsoft.Crm.Sdk.Samples
{
    /// &lt;summary&gt;
    /// Demonstrates how to do basic entity operations like create, retrieve,
    /// update, and delete.
    /// If you want to run this sample repeatedly, you have the option to 
    /// delete all the records created at the end of execution.
    /// &lt;/summary&gt;
    public class CRUDOperationsDE
    {
        #region Class Level Members
        /// &lt;summary&gt;
        /// Stores the organization service proxy.
        /// &lt;/summary&gt;
        private OrganizationServiceProxy _serviceProxy;
        private IOrganizationService _service;

        // Define the IDs needed for this sample.
        private Guid _accountId;

        #endregion Class Level Members

        #region How To Sample Code
        /// &lt;summary&gt;
        /// Create and configure the organization service proxy.
        /// Create an account record
        /// Retrieve the account record
        /// Update the account record
        /// Optionally delete any entity records that were created for this sample.
       /// &lt;/summary&gt;
        /// &lt;param name=&quot;serverConfig&quot;&gt;Contains server connection information.&lt;/param&gt;
        /// &lt;param name=&quot;promptForDelete&quot;&gt;When True, the user will be prompted to delete
        /// all created entities.&lt;/param&gt;
        public void Run(ServerConnection.Configuration serverConfig, bool promptForDelete)
        {
            try
            {

                // Connect to the Organization service. 
                // The using statement assures that the service proxy will be properly disposed.
                using (_serviceProxy = new OrganizationServiceProxy(serverConfig.OrganizationUri, serverConfig.HomeRealmUri,serverConfig.Credentials, serverConfig.DeviceCredentials))
                {
                    _service = (IOrganizationService)_serviceProxy;

                    // Instaniate an account object.
                    Entity account = new Entity(&quot;account&quot;);

                    // Set the required attributes. For account, only the name is required. 
                    // See the Entity Metadata topic in the SDK documentatio to determine 
                    // which attributes must be set for each entity.
                    account[&quot;name&quot;] = &quot;Fourth Coffee&quot;;

                    // Create an account record named Fourth Coffee.
                    _accountId = _service.Create(account);

                    Console.Write(&quot;{0} {1} created, &quot;, account.LogicalName, account.Attributes[&quot;name&quot;]);

                    // Create a column set to define which attributes should be retrieved.
                    ColumnSet attributes = new ColumnSet(new string[] { &quot;name&quot;, &quot;ownerid&quot; });

                    // Retrieve the account and its name and ownerid attributes.
                    account = _service.Retrieve(account.LogicalName, _accountId, attributes);
                    Console.Write(&quot;retrieved, &quot;);

                    // Update the postal code attribute.
                    account[&quot;address1_postalcode&quot;] = &quot;98052&quot;;

                    // The address 2 postal code was set accidentally, so set it to null.
                    account[&quot;address2_postalcode&quot;] = null;

                    // Shows use of Money.
                    account[&quot;revenue&quot;] = new Money(5000000);

                    // Shows use of boolean.
                    account[&quot;creditonhold&quot;] = false;

                    // Update the account.
                    _service.Update(account);
                    Console.WriteLine(&quot;and updated.&quot;);

                    // Delete the account.
                    bool deleteRecords = true;

                    if (promptForDelete)
                    {
                        Console.WriteLine(&quot;\nDo you want these entity records deleted? (y/n) [y]: &quot;);
                        String answer = Console.ReadLine();

                        deleteRecords = (answer.StartsWith(&quot;y&quot;) || answer.StartsWith(&quot;Y&quot;) || answer == String.Empty);
                    }

                    if (deleteRecords)
                    {
                        _service.Delete(&quot;account&quot;, _accountId);

                        Console.WriteLine(&quot;Entity record(s) have been deleted.&quot;);
                    }

                }
            }

            // Catch any service fault exceptions that Microsoft Dynamics CRM throws.
            catch (FaultException&lt;Microsoft.Xrm.Sdk.OrganizationServiceFault&gt;)
            {
                // You can handle an exception here or pass it back to the calling method.
                throw;
            }
        }

        #endregion How To Sample Code

        #region Main
        /// &lt;summary&gt;
        /// Standard Main() method used by most SDK samples.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;args&quot;&gt;&lt;/param&gt;
        static public void Main(string[] args)
        {
            try
            {
                // Obtain the target organization's Web address and client logon 
                // credentials from the user.
                ServerConnection serverConnect = new ServerConnection();
                ServerConnection.Configuration config = serverConnect.GetServerConfiguration();

                CRUDOperationsDE app = new CRUDOperationsDE();
                app.Run(config, true);
            }
            catch (FaultException&lt;Microsoft.Xrm.Sdk.OrganizationServiceFault&gt; ex)
            {
                Console.WriteLine(&quot;The application terminated with an error.&quot;);
                Console.WriteLine(&quot;Timestamp: {0}&quot;, ex.Detail.Timestamp);
                Console.WriteLine(&quot;Code: {0}&quot;, ex.Detail.ErrorCode);
                Console.WriteLine(&quot;Message: {0}&quot;, ex.Detail.Message);
                Console.WriteLine(&quot;Plugin Trace: {0}&quot;, ex.Detail.TraceText);
                Console.WriteLine(&quot;Inner Fault: {0}&quot;,
                    null == ex.Detail.InnerFault ? &quot;No Inner Fault&quot; : &quot;Has Inner Fault&quot;);
            }
            catch (<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.TimeoutException.aspx" target="_blank" title="Auto generated link to System.TimeoutException">System.TimeoutException</a> ex)
            {
                Console.WriteLine(&quot;The application terminated with an error.&quot;);
                Console.WriteLine(&quot;Message: {0}&quot;, ex.Message);
                Console.WriteLine(&quot;Stack Trace: {0}&quot;, ex.StackTrace);
                Console.WriteLine(&quot;Inner Fault: {0}&quot;,
                    null == ex.InnerException.Message ? &quot;No Inner Fault&quot; : ex.InnerException.Message);
            }
            catch (<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Exception.aspx" target="_blank" title="Auto generated link to System.Exception">System.Exception</a> ex)
            {
                Console.WriteLine(&quot;The application terminated with an error.&quot;);
                Console.WriteLine(ex.Message);

                // Display the details of the inner exception.
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);

                    FaultException&lt;Microsoft.Xrm.Sdk.OrganizationServiceFault&gt; fe = ex.InnerException
                        as FaultException&lt;Microsoft.Xrm.Sdk.OrganizationServiceFault&gt;;
                    if (fe != null)
                    {
                        Console.WriteLine(&quot;Timestamp: {0}&quot;, fe.Detail.Timestamp);
                        Console.WriteLine(&quot;Code: {0}&quot;, fe.Detail.ErrorCode);
                        Console.WriteLine(&quot;Message: {0}&quot;, fe.Detail.Message);
                        Console.WriteLine(&quot;Plugin Trace: {0}&quot;, fe.Detail.TraceText);
                        Console.WriteLine(&quot;Inner Fault: {0}&quot;,
                            null == fe.Detail.InnerFault ? &quot;No Inner Fault&quot; : &quot;Has Inner Fault&quot;);
                    }
                }
            }
            // Additional exceptions to catch: SecurityTokenValidationException, ExpiredSecurityTokenException,
            // SecurityAccessDeniedException, MessageSecurityException, and SecurityNegotiationException.

            finally
            {

                Console.WriteLine(&quot;Press &lt;Enter&gt; to exit.&quot;);
                Console.ReadLine();
            }

        }
        #endregion Main
    }
}

    </pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<hr class="codeDivider">
</div>
</div>
<div class="LW_CollapsibleArea_Container">
<div class="LW_CollapsibleArea_TitleDiv"><span class="LW_CollapsibleArea_Title">See Also</span>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<p><a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice?view=dynamics-general-ce-9" target="_blank">IOrganizationService</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create?view=dynamics-general-ce-9">Create</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.retrieve?view=dynamics-general-ce-9">Retrieve</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.update?view=dynamics-general-ce-9">Update</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.delete?view=dynamics-general-ce-9">Delete</a><br>
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/helper-code-serverconnection-class">Helper code: ServerConnection class</a></p>
</div>
<p>&nbsp;</p>
</div>
</div>
</div>
</div>
</div>
