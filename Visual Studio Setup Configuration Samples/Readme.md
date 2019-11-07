# Visual Studio Setup Configuration Samples
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Interop
- Visual Studio "15"
- Smart Pointers
## Topics
- Visual Studio "15"
- Product Instances
## Updated
- 09/10/2016
## Description

<p>The included samples show how to use the new setup configuration API for discovering instances of Visual Studio &quot;15&quot;.</p>
<h2>Visual Studio Instances</h2>
<p>You can install multiple instances of Visual Studio with different workloads, or from different channels or versions. The majority of components are now lightweight installs using the same container format as VSIX packages for faster installs and cleaner
 uninstalls.</p>
<p>This change to the Visual Studio platform requires new ways of discovering Visual Studio where simple registry detection does not provide the flexibility required in many scenarios.</p>
<p>The new setup configuration API provides simple access for native and managed code, as well as a means to output JSON, XML, or other formats for consumption in batch or PowerShell scripts.</p>
<h2>Available Packages</h2>
<p>The following packages are available on <a href="https://nuget.org">nuget.org</a> that provide access to the setup configuration API.</p>
<ul>
<li><a href="https://www.nuget.org/packages/Microsoft.VisualStudio.Setup.Configuration.Native/">Microsoft.VisualStudio.Setup.Configuration.Native</a><br>
Adds the header location and automatically links the library. You only need to add the `#include` as shown below.
</li><li><a href="https://www.nuget.org/packages/Microsoft.VisualStudio.Setup.Configuration.Interop/">Microsoft.VisualStudio.Setup.Configuration.Interop</a><br>
Provides embeddable interop types. If the interop types are embedded you do not need to redistribute additional assemblies. Simply instantiate the `SetupConfiguration` runtime callable wrapper (RCW) as shown below.
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">// Assembly references are automatically added
string GetInstanceId()
{
    var configuration = new SetupConfiguration();
    var instance = configuration.GetInstanceForCurrentProcess();

    return instance?.GetInstanceId();
}</pre>
<pre class="hidden">' Assembly references are automatically added
Function GetInstanceId() As String
    Dim configuration = New SetupConfiguration()
    Dim instance = configuration.GetInstanceForCurrentProcess()
    If Not instance Is Nothing Then
        Return instance.GetInstanceId()
    End If

    Return Nothing
End Function</pre>
<pre class="hidden">// Header location and link to .lib added automatically.
#include &lt;comdef.h&gt;
#include &lt;comutil.h&gt;
#include &lt;Setup.Configuration.h&gt;

HRESULT GetInstanceId(_In_ BSTR* pbstrInstanceId)
{
    if (!pbstrInstanceId)
    {
        return E_POINTER;
    }

    HRESULT hr = S_OK;
    *pbstrInstanceId = NULL;

    ISetupConfigurationPtr pConfiguration(__uuidof(SetupConfiguration));
    ISetupInstancePtr pInstance;

    hr = pConfiguration-&gt;GetInstanceForCurrentProcess(&amp;pInstance);
    if (SUCCEEDED(hr))
    {
        bstr_t bstrInstanceId;
        hr = pInstance-&gt;GetInstanceId(bstrInstanceId.GetAddress());
        if (SUCCEEDED(hr))
        {
            *pbstrInstanceId = bstrInstanceId.Detach();
        }
    }

    return hr;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Assembly&nbsp;references&nbsp;are&nbsp;automatically&nbsp;added</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;GetInstanceId()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;configuration&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SetupConfiguration();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;instance&nbsp;=&nbsp;configuration.GetInstanceForCurrentProcess();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;instance?.GetInstanceId();&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>Updates</h2>
<p>For the most recent updates to these samples, please see <a href="https://github.com/microsoft/vs-setup-samples">
https://github.com/microsoft/vs-setup-samples</a>.</p>
