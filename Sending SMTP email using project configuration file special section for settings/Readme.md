# Sending SMTP email using project configuration file special section for settings
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SMTP
## Topics
- SMTP
- Configuration
## Updated
- 02/19/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample demonstrates how to store elements that an application would need to send SMTP email messages in a fashion that allows changes without the need to compile the project each time one wants to test a different
 port or host for instance. &nbsp;Also shown is how to test your code without actually sending email messages and instead send these messages to a file which can be examined in notepad or when Microsoft Outlook is installed the file when double clicked will
 be opened in Microsoft Outlook.</span></p>
<p><br>
<span style="font-size:small">Sticking with how elements are read in the methods below, alternates would be to read elements from a comma-delimited text file, an xml file or perhaps from a table in a database. &nbsp;What the alternate methods can&rsquo;t do
 is redirect messages to a file. You could store elements in the alternate file types coupled with setting up for sending messages to a file for development/debug proposes.</span><br>
<br>
<span style="font-size:small">I first used the methods below first in a Visual Studio unit test calling code in a class project then used these methods within a web api solution calling the same class project used in the unit test. The difference was that in
 the web api solution the elements were stored in web.config (debug section) while for the unit project stored in the app.config file.</span><br>
<br>
<span style="font-size:small">We start by opening (in this case) app.config for a project and added in the mail settings section group as shown in the red rectangle. Next add in the pieces you want to have available at runtime. In the image below we want to
 be able to change from (whom the message is from), host (the host server responsible for sending messages), port (port used to send messages) user name and password (used when credentials are needed by the host server to send messages). There are other parts
 such as enableSsl which is not being used in the code example.&nbsp;&nbsp;</span></p>
<p><img id="145666" src="145666-figure1.png" alt="" width="559" height="284"></p>
<p><span style="font-size:small">Before continuing the code shown below reads the setting above but you can also write settings back to the configuration file using save method of the ConfigurationManager used to read the settings.<br>
<br>
In the project there is a class named MailConfiguration.cs which in the constructor reads settings from the app.config (or web.config) file. Please note there is assertion to handle general exceptions such as there is a element for port but it&rsquo;s not set.
 When ConfigurationManager reads Port in the case there is no Port an exception is thrown. To keep this example simple I only show read operations, no write operations.</span></p>
<h2><span style="font-size:small">Special notes</span></h2>
<p><span style="font-size:small">The app.config file has no values for any of the elements, you need to populate them before running the sample project. Suggestions, for &lsquo;From&rsquo; use your own email address (do the same for the to email address in
 form1), for host, if using Comcast the host would be smtp.comcast.net, keeping with Comcast the port (at this time) would be 587. userName and password are the same as what you use to login to your email account.</span></p>
<p><span style="font-size:small">If you want to write to the specifiedPickupDirectory path the path into this element. What I did for the unit test project was to write a post build event that created a folder named EmailDump then wrote code to set the PickupDirectoryLocation
 with the following which points to the bin\Debug\EmailDump folder.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string folderName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, &quot;EmailDump&quot;);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;folderName&nbsp;=&nbsp;System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="cs__string">&quot;EmailDump&quot;</span>);</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The reason for dynamically creating the folder is that there is a potential for up to eight developers running this test and six testers that may run the test. We currently have 100&#43; unit test that each developer runs each day
 before beginning to code. For a single developer that is not needed.</span><br>
<br>
<span style="font-size:small">Without actually sending a message it would be difficult to see how reading the elements from the configuration file works.</span><br>
<br>
<span style="font-size:small">The main form in the project has two buttons that permit sending a plain text or html body message with no frills. In regards to no frills, we could setup from, to, cc and bcc to use friendly names so that instead of simply showing
 email addresses we have the capability to show actual names. The third button will empty all files in the EmailDump folder so if you are doing many test we don&rsquo;t fill up the pickup folder.</span><br>
<br>
<span style="font-size:small">There is a checkbox, by default it is not checked which instructs emails to be actually sent while checking the check box will redirect messages to the pickup folder (EMailDump).</span><br>
<br>
<span style="font-size:small">Messages are sent asynchronously and the code makes use of a delegate which will indicate if the message was sent, if not what was the error. In regards to errors, if there is an error you may need to examine the inner exception
 for details.</span><br>
<br>
<span style="font-size:small">When sending a message that code is wrapped in a try-catch and looks for smtp specific exceptions first then if none drops down to general exception. The most likely reason for an error is bad port or host then of course bad email
 addressed. Here console.writeline is used but for a production application writing to a log would be in order.&nbsp;</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Update <span style="background-color:#ffff99">
2/19/2016</span></span></strong></p>
<ul>
<li><span style="font-size:small">Added a class library for reading settings using a slightly different method to obtain information and a unit test then decided to add a vb.net version but not a unit test.</span>
</li><li><span style="font-size:small">Moved from VS2013 to VS2015</span> </li></ul>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports System.Configuration
Imports System.Net.Configuration
''' &lt;summary&gt;
''' Responsible for retrieving settings for use when sending Smtp email messages in the app
''' and also in unit test.
''' &lt;/summary&gt;
''' &lt;remarks&gt;
''' - variable smtpSection provides the ability to read elements from app.config or web.config
''' - MailConfigurationTest provides a unit test for testing this class.
''' &lt;/remarks&gt;
Public Class MailConfiguration
    Private smtpSection As SmtpSection = (TryCast(ConfigurationManager.GetSection(&quot;system.net/mailSettings/smtp&quot;), SmtpSection))
    ''' &lt;summary&gt;
    ''' Location of configuration file
    ''' &lt;/summary&gt;
    Public ReadOnly Property ConfigurationFileName() As String
        Get
            Try
                Return smtpSection.ElementInformation.Source
            Catch e1 As Exception

                Return &quot;&quot;
            End Try
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' Email address for the system
    ''' &lt;/summary&gt;
    Public ReadOnly Property FromAddress() As String
        Get
            Return smtpSection.From
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' Gets the name or IP address of the host used for SMTP transactions.
    ''' &lt;/summary&gt;
    Public ReadOnly Property Host() As String
        Get
            Return smtpSection.Network.Host
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' Gets the port used for SMTP transactions
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;default host is 25&lt;/remarks&gt;
    Public ReadOnly Property Port() As Integer
        Get
            Return smtpSection.Network.Port
        End Get
    End Property
    ''' &lt;summary&gt;
    ''' Gets a value that specifies the amount of time after 
    ''' which a synchronous Send call times out.
    ''' &lt;/summary&gt;
    Public ReadOnly Property TimeOut() As Integer
        Get
            Return 2000
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return &quot;From: [&quot; &amp; FromAddress &amp; &quot;] Host: [&quot; &amp; Host &amp; &quot;] Port: [&quot; &amp; Port &amp; &quot;]&quot;
    End Function
End Class
</pre>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MailConfigurationLibrary
{
    /// &lt;summary&gt;
    /// Responsible for retrieving settings for use when sending Smtp email messages in the app
    /// and also in unit test.
    /// &lt;/summary&gt;
    /// &lt;remarks&gt;
    /// - variable smtpSection provides the ability to read elements from app.config or web.config
    /// - MailConfigurationTest provides a unit test for testing this class.
    /// &lt;/remarks&gt;
    public class MailConfiguration
    {
        private SmtpSection smtpSection = (ConfigurationManager.GetSection(&quot;system.net/mailSettings/smtp&quot;) as SmtpSection);
        /// &lt;summary&gt;
        /// Location of configuration file
        /// &lt;/summary&gt;
        public string ConfigurationFileName {
            get
            {
                try
                {
                    return smtpSection.ElementInformation.Source;
                }
                catch (Exception)
                {

                    return &quot;&quot;;
                }

            } }
        /// &lt;summary&gt;
        /// Email address for the system
        /// &lt;/summary&gt;
        public string FromAddress { get { return smtpSection.From; } }
        /// &lt;summary&gt;
        /// Gets the name or IP address of the host used for SMTP transactions.
        /// &lt;/summary&gt;
        public string Host { get { return smtpSection.Network.Host; } }
        /// &lt;summary&gt;
        /// Gets the port used for SMTP transactions
        /// &lt;/summary&gt;
        /// &lt;remarks&gt;default host is 25&lt;/remarks&gt;
        public int Port { get { return smtpSection.Network.Port; } }
        /// &lt;summary&gt;
        /// Gets a value that specifies the amount of time after 
        /// which a synchronous Send call times out.
        /// &lt;/summary&gt;
        public int TimeOut { get { return 2000; } }
        public override string ToString()
        {
            return &quot;From: [&quot; &#43; FromAddress &#43; &quot;] Host: [&quot; &#43; Host &#43; &quot;] Port: [&quot; &#43; Port &#43; &quot;]&quot;;
        }
    }
}
</pre>
<div class="preview">
<pre class="js">Imports&nbsp;System.Configuration&nbsp;
Imports&nbsp;System.Net.Configuration&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;Responsible&nbsp;<span class="js__statement">for</span>&nbsp;retrieving&nbsp;settings&nbsp;<span class="js__statement">for</span>&nbsp;use&nbsp;when&nbsp;sending&nbsp;Smtp&nbsp;email&nbsp;messages&nbsp;<span class="js__operator">in</span>&nbsp;the&nbsp;app&nbsp;
<span class="js__string">''</span>'&nbsp;and&nbsp;also&nbsp;<span class="js__operator">in</span>&nbsp;unit&nbsp;test.&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;-&nbsp;variable&nbsp;smtpSection&nbsp;provides&nbsp;the&nbsp;ability&nbsp;to&nbsp;read&nbsp;elements&nbsp;from&nbsp;app.config&nbsp;or&nbsp;web.config&nbsp;
<span class="js__string">''</span>'&nbsp;-&nbsp;MailConfigurationTest&nbsp;provides&nbsp;a&nbsp;unit&nbsp;test&nbsp;<span class="js__statement">for</span>&nbsp;testing&nbsp;<span class="js__operator">this</span>&nbsp;class.&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/remarks&gt;&nbsp;
Public&nbsp;Class&nbsp;MailConfiguration&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;smtpSection&nbsp;As&nbsp;SmtpSection&nbsp;=&nbsp;(TryCast(ConfigurationManager.GetSection(<span class="js__string">&quot;system.net/mailSettings/smtp&quot;</span>),&nbsp;SmtpSection))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Location&nbsp;of&nbsp;configuration&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;ReadOnly&nbsp;Property&nbsp;ConfigurationFileName()&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;smtpSection.ElementInformation.Source&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;e1&nbsp;As&nbsp;Exception&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Email&nbsp;address&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;system&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;ReadOnly&nbsp;Property&nbsp;FromAddress()&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;smtpSection.From&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Gets&nbsp;the&nbsp;name&nbsp;or&nbsp;IP&nbsp;address&nbsp;of&nbsp;the&nbsp;host&nbsp;used&nbsp;<span class="js__statement">for</span>&nbsp;SMTP&nbsp;transactions.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;ReadOnly&nbsp;Property&nbsp;Host()&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;smtpSection.Network.Host&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Gets&nbsp;the&nbsp;port&nbsp;used&nbsp;<span class="js__statement">for</span>&nbsp;SMTP&nbsp;transactions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;<span class="js__statement">default</span>&nbsp;host&nbsp;is&nbsp;<span class="js__num">25</span>&lt;/remarks&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;ReadOnly&nbsp;Property&nbsp;Port()&nbsp;As&nbsp;Integer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;smtpSection.Network.Port&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Gets&nbsp;a&nbsp;value&nbsp;that&nbsp;specifies&nbsp;the&nbsp;amount&nbsp;of&nbsp;time&nbsp;after&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;which&nbsp;a&nbsp;synchronous&nbsp;Send&nbsp;call&nbsp;times&nbsp;out.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;ReadOnly&nbsp;Property&nbsp;TimeOut()&nbsp;As&nbsp;Integer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;<span class="js__num">2000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Overrides&nbsp;<span class="js__object">Function</span>&nbsp;ToString()&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;<span class="js__string">&quot;From:&nbsp;[&quot;</span>&nbsp;&amp;&nbsp;FromAddress&nbsp;&amp;&nbsp;<span class="js__string">&quot;]&nbsp;Host:&nbsp;[&quot;</span>&nbsp;&amp;&nbsp;Host&nbsp;&amp;&nbsp;<span class="js__string">&quot;]&nbsp;Port:&nbsp;[&quot;</span>&nbsp;&amp;&nbsp;Port&nbsp;&amp;&nbsp;<span class="js__string">&quot;]&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span>&nbsp;
End&nbsp;Class&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span>
<p></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<ul>
</ul>
<h1>More Information</h1>
<p><span style="font-size:small">See also, <a href="https://msdn.microsoft.com/en-us/library/system.net.configuration.mailsettingssectiongroup(v=vs.110).aspx" target="_blank">
MailSettingsSectionGroup class</a>.</span></p>
