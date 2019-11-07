# Windows Azure AD Graph API Helper Library
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Window Azure Active Directory
## Topics
- REST
- windows azure active directory
- Windows Azure Rest API
## Updated
- 05/13/2014
## Description

<h1><span style="color:#ff0000; font-size:large">Note: this library is outdated, and has been replaced.&nbsp;&nbsp;<em>A new C# Library is now available&nbsp;as a Nuget package from:</em></span></h1>
<p><span style="font-size:small"><em><a href="http://www.nuget.org/packages/Microsoft.Azure.ActiveDirectory.GraphClient">http://www.nuget.org/packages/Microsoft.Azure.ActiveDirectory.GraphClient</a></em></span></p>
<p><span style="font-size:small"><em>------------------------------------------------------------------------------------------------<br>
</em></span></p>
<p><span style="font-size:small"><em>This a small helper library which includes the Service Reference for the&nbsp;2013-04-05 version of the Windows Azure AD Graph API&nbsp;and helper methods for setting up the required headers (including authorization), query
 parameters etc.</em></span></p>
<h1><span>How to Use this Project</span></h1>
<p><em>Include the Windows Azure AD Graph API Helper Project as part of your Visual Studio Graph API solution</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This helper class includes methods for acquiring and validating the Azure AD Authentication (JWT) Token, and helper methods for accessing Users, Groups, Roles, Applications etc.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace Microsoft.WindowsAzure.ActiveDirectory.GraphHelper
{
    /// &lt;summary&gt;
    /// Helper class to fetch tokens from AAD for talking to AAD Graph Service.
    /// &lt;/summary&gt;
    public static class DirectoryDataServiceAuthorizationHelper
    {
        /// &lt;summary&gt;
        /// Function for getting a token from ACS using Application Service principal Id and Password.
        /// &lt;/summary&gt;
        public static AADJWTToken GetAuthorizationToken(string tenantName, string appPrincipalId, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(StringConstants.AzureADSTSURL, tenantName));
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            string postData = &quot;grant_type=client_credentials&quot;;            
            postData &#43;= &quot;&amp;resource=&quot; &#43; HttpUtility.UrlEncode(StringConstants.GraphPrincipalId);
            postData &#43;= &quot;&amp;client_id=&quot; &#43; HttpUtility.UrlEncode(appPrincipalId);
            postData &#43;= &quot;&amp;client_secret=&quot; &#43; HttpUtility.UrlEncode(password);
            byte[] data = encoding.GetBytes(postData);
            request.Method = &quot;POST&quot;;
            request.ContentType = &quot;application/x-www-form-urlencoded&quot;;
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AADJWTToken));
                    AADJWTToken token = (AADJWTToken)(ser.ReadObject(stream));
                    return token;
                }
            }
        }
    }
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;Microsoft.WindowsAzure.ActiveDirectory.GraphHelper&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Helper&nbsp;class&nbsp;to&nbsp;fetch&nbsp;tokens&nbsp;from&nbsp;AAD&nbsp;for&nbsp;talking&nbsp;to&nbsp;AAD&nbsp;Graph&nbsp;Service.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DirectoryDataServiceAuthorizationHelper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Function&nbsp;for&nbsp;getting&nbsp;a&nbsp;token&nbsp;from&nbsp;ACS&nbsp;using&nbsp;Application&nbsp;Service&nbsp;principal&nbsp;Id&nbsp;and&nbsp;Password.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;AADJWTToken&nbsp;GetAuthorizationToken(<span class="cs__keyword">string</span>&nbsp;tenantName,&nbsp;<span class="cs__keyword">string</span>&nbsp;appPrincipalId,&nbsp;<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)WebRequest.Create(String.Format(StringConstants.AzureADSTSURL,&nbsp;tenantName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Text.ASCIIEncoding&nbsp;encoding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Text.ASCIIEncoding();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;postData&nbsp;=&nbsp;<span class="cs__string">&quot;grant_type=client_credentials&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;resource=&quot;</span>&nbsp;&#43;&nbsp;HttpUtility.UrlEncode(StringConstants.GraphPrincipalId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;client_id=&quot;</span>&nbsp;&#43;&nbsp;HttpUtility.UrlEncode(appPrincipalId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;client_secret=&quot;</span>&nbsp;&#43;&nbsp;HttpUtility.UrlEncode(password);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;data&nbsp;=&nbsp;encoding.GetBytes(postData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/x-www-form-urlencoded&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;data.Length;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Stream&nbsp;stream&nbsp;=&nbsp;request.GetRequestStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream.Write(data,&nbsp;<span class="cs__number">0</span>,&nbsp;data.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;response&nbsp;=&nbsp;request.GetResponse())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;stream&nbsp;=&nbsp;response.GetResponseStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractJsonSerializer&nbsp;ser&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractJsonSerializer(<span class="cs__keyword">typeof</span>(AADJWTToken));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AADJWTToken&nbsp;token&nbsp;=&nbsp;(AADJWTToken)(ser.ReadObject(stream));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;token;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>AADJWTToken.cs - Class for&nbsp;tokens from Windows Azure AD Authentication, includes methods to check for token expiry.</em>
</li><li><em><em>DirectoryDataService_partial.cs - partial class for the DirectoryDataService, which includes a Helper method for a service constructor that uses the token and&nbsp;specifies the Graph API version.</em></em>
</li><li>DirectoryDataServiceAuthorizationHelper.cs - helper class for authenticating and fetching a token from Windows Azure AD Authentication, and communicating to the Graph API.
</li></ul>
<h1>More Information</h1>
<p><em>Download the complete MVC Sample Application for the Graph API, that shows how to use this helper class
<a href="http://code.msdn.microsoft.com/Write-Sample-App-for-79e55502">http://code.msdn.microsoft.com/Write-Sample-App-for-79e55502</a></em></p>
