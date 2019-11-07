# Windows Firewall へルールを追加する
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Win32
- .NET Framework
- Visual C Sharp
## Topics
- Firewall Rules
## Updated
- 05/21/2012
## Description

<h1>Introduction</h1>
<p>Windows Firewall へルールを追加する C#のサンプルです。Visual Basic Script や C&#43;&#43;のサンプルはありますが、C#でサンプルが無いので作成しました。C# では、COM 互換の機能を利用してインターフェースを利用します。但し、WindowsXP 上で開発しますと、HNetCfg.FwMgr インタフェースのみしか扱えないため Windows 7 上での開発して下さい。</p>
<p>&nbsp;&nbsp;インターフェースは、COMなので、インターフェースのの利用方法は、Visual Basic Script や C&#43;&#43;のサンプルがとっても役に立ちます。More Information に載せておきますので、見て下さい。</p>
<p style="text-align:left">設定するルールは次のようになっています。</p>
<ul>
<li>
<div style="text-align:left">ルール名：Outbound_Rule</div>
</li><li>プロトコル：TCP </li><li>ローカルポート：4000 </li><li>アクション：許可 </li></ul>
<p>具体的には、次のようなコードになっています。これらの値を変えていろいろと試してください。</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Name = &quot;Outbound_Rule&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Description = &quot;Allow outbound network traffic from my Application over TCP port 4000&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.ApplicationName = @&quot;%systemDrive%\Program Files\MyApplication.exe&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.LocalPorts = &quot;4000&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Enabled = true&nbsp; ;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Grouping = &quot;@firewallapi.dll,-23255&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Profiles = CurrentProfiles;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NewRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;</p>
<h1><span>Building the Sample</span></h1>
<p>Visual Studio2010にてコンパイルしてください。</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>C# では、COM 互換の機能を利用してインターフェースを利用します。但し、WindowsXP<br>
上で開発しますと、HNetCfg.FwMgr インタフェースのみしか扱えないため Windows 7 <br>
上での開発をお勧め致します。</p>
<p>1. INetFwPolicy2 インターフェース を追加する方法<br>
&nbsp;1) Visual Studio のメニューより「プロジェクト」「参照の追加」を選択します。<br>
&nbsp;2)「COM」タブを選択します。<br>
&nbsp;3) コンポーネント名 NetFwTypeLib を選択します。<br>
&nbsp;4) [OK]ボタンを押し、追加を行います。</p>
<p><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        static void Main(string[] args)
        {
            // Create the FwPolicy2 object.
            Type NetFwPolicy2Type = Type.GetTypeFromProgID(&quot;HNetCfg.FwPolicy2&quot;,false);
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(NetFwPolicy2Type);

            // Get the Rules object
            INetFwRules RulesObject = fwPolicy2.Rules; 

            int CurrentProfiles = fwPolicy2.CurrentProfileTypes;

            // Create a Rule Object.
            Type NetFwRuleType = Type.GetTypeFromProgID(&quot;HNetCfg.FWRule&quot;,false);
            INetFwRule NewRule = (INetFwRule)Activator.CreateInstance(NetFwRuleType);
    
            NewRule.Name = &quot;Outbound_Rule&quot;;
            NewRule.Description = &quot;Allow outbound network traffic from my Application over TCP port 4000&quot;;
            NewRule.ApplicationName = @&quot;%systemDrive%\Program Files\MyApplication.exe&quot;;
            NewRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            NewRule.LocalPorts = &quot;4000&quot;;
            NewRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            NewRule.Enabled = true  ;
            NewRule.Grouping = &quot;@firewallapi.dll,-23255&quot;;
            NewRule.Profiles = CurrentProfiles;
            NewRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
        
            // Add a new rule
            RulesObject.Add(NewRule);

        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;FwPolicy2&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;NetFwPolicy2Type&nbsp;=&nbsp;Type.GetTypeFromProgID(<span class="cs__string">&quot;HNetCfg.FwPolicy2&quot;</span>,<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INetFwPolicy2&nbsp;fwPolicy2&nbsp;=&nbsp;(INetFwPolicy2)Activator.CreateInstance(NetFwPolicy2Type);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;Rules&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INetFwRules&nbsp;RulesObject&nbsp;=&nbsp;fwPolicy2.Rules;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;CurrentProfiles&nbsp;=&nbsp;fwPolicy2.CurrentProfileTypes;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;Rule&nbsp;Object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;NetFwRuleType&nbsp;=&nbsp;Type.GetTypeFromProgID(<span class="cs__string">&quot;HNetCfg.FWRule&quot;</span>,<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INetFwRule&nbsp;NewRule&nbsp;=&nbsp;(INetFwRule)Activator.CreateInstance(NetFwRuleType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Outbound_Rule&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Description&nbsp;=&nbsp;<span class="cs__string">&quot;Allow&nbsp;outbound&nbsp;network&nbsp;traffic&nbsp;from&nbsp;my&nbsp;Application&nbsp;over&nbsp;TCP&nbsp;port&nbsp;4000&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.ApplicationName&nbsp;=&nbsp;@<span class="cs__string">&quot;%systemDrive%\Program&nbsp;Files\MyApplication.exe&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Protocol&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.LocalPorts&nbsp;=&nbsp;<span class="cs__string">&quot;4000&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Direction&nbsp;=&nbsp;NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;&nbsp;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Grouping&nbsp;=&nbsp;<span class="cs__string">&quot;@firewallapi.dll,-23255&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Profiles&nbsp;=&nbsp;CurrentProfiles;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NewRule.Action&nbsp;=&nbsp;NET_FW_ACTION_.NET_FW_ACTION_ALLOW;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;new&nbsp;rule</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RulesObject.Add(NewRule);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program.cs.</em> </li></ul>
<h1>More Information</h1>
<p>&nbsp;Adding an Outbound Rule<br>
<a href="http://msdn.microsoft.com/en-us/library/aa364699(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa364699(v=VS.85).aspx</a></p>
<p>C&#43;&#43;のサンプル<br>
C:\Program Files\Microsoft SDKs\Windows\v7.1\Samples\security\windowsfirewall\add_outbound_rule</p>
