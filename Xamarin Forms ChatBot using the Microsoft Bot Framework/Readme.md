# Xamarin Forms ChatBot using the Microsoft Bot Framework
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Xamarin.Android
- Xamarin.iOS
- Xamarin.Forms
- UWP
- Microsoft Bot Framework
- Bots
## Topics
- Xamarin.Forms
- Microsoft Bot Framework
## Updated
- 06/10/2017
## Description

<p><span id="docs-internal-guid-2646162d-90eb-f328-ca36-12a7ca2294b6">&nbsp;</span></p>
<h1 dir="ltr">Introduction:</h1>
<p dir="ltr"><span style="font-size:small">The Bots Framework that run inside skype ,web chat , Facebook ,Message ,etc. Users can interact with bots by sending them messages, commands and&nbsp;inline requests. You control your bots using HTTPS requests to our&nbsp;bot
 API.</span></p>
<p dir="ltr"><span style="font-size:small">In this article, how you can integrate a bot right into your Xamarin.Forms application via the Microsoft Bot Framework Web bots.</span></p>
<p dir="ltr"><span style="font-size:small"><img id="174299" src="174299-t6g5bojnm5.gif" alt="" width="376" height="489"><br>
</span></p>
<h1 dir="ltr"><span>Create new bot Application:</span></h1>
<p dir="ltr"><span style="font-size:small">You can read my previous article for Getting Started with Bots Using Visual Studio 2017 from following URL&nbsp;</span></p>
<p dir="ltr"><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Getting-Started-with-4ae6fdb0?redir=0">1.Getting Started with Building Bots using Visual Studio 2017</a></span></p>
<h1 dir="ltr"><span>Publish Bot Application to Azure:</span></h1>
<p dir="ltr"><span style="font-size:small">You can read my previous articles for publish bot application to azure from following URL&nbsp;</span></p>
<p dir="ltr"><a href="https://code.msdn.microsoft.com/Getting-Started-Deploy-a-cfc825ad?redir=0"><span style="font-size:small">1.Getting Started Deploy a bot to Azure using Visual studio 2017</span></a></p>
<p dir="ltr">&nbsp;</p>
<h1 dir="ltr"><span>Generate Web Chat Code:</span></h1>
<p dir="ltr"><span style="font-size:small">After publish you bots into azure, you can generate web Chat html code from bots portal as per below
</span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 1</strong><br class="kix-line-break">
Sign in to the Bot framework Portal - https://dev.botframework.com/</span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 2</strong><br class="kix-line-break">
Click My Bots </span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 3</strong><br class="kix-line-break">
Select your bot that you want to generate code</span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 4:</span></strong></p>
<p dir="ltr"><span style="font-size:small">Click on Get bot embed Codes &gt; Click on Web Chat icon &gt; Click on (Click here to open Web Chat configuration page)</span></p>
<p dir="ltr"><span><img src=":-q5ia-2gtphhqntqguhfqv8wuq5jkmm3krlv__etbr2kluycqnl5-34jnwc8r9i_ytr8cnirg_pb99mfuczivg4z09qv_enauurpoealqji-d-fyay7ovthdkcxuh2kgzpot1_tdr7ffyo3vdeg" alt="" width="623" height="147"></span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 5:</span></strong></p>
<p dir="ltr"><span style="font-size:small">It will navigate to new web page for configuration and click on &#43; Add New Site &gt; Provide site or application name &gt; Click on Done</span></p>
<p dir="ltr"><span><img src=":-lem8-iqupi_jut9uvoig976kwe-_4-5gbydbyhaqfssrb-nv54vkfkxjkhacjnnrc8z4vudp1aqamvgdpx4shcpcxrcy16pmzidto5bed_x67c6gunoeadpwa7w3b_h4xoxdwxqyydml8zllng" alt="" width="624" height="378"></span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 6:</span></strong></p>
<p dir="ltr"><span style="font-size:small">You can copy your secret keys and embed code for integrate to xamarin forms application
</span></p>
<p dir="ltr"><span><img src=":-en6knv0mvb34typz1gaqtt6fomulbtx2nnyhtcmtgxskiu3kv9n5miykytgoe1qbk_t7pbmrdslfzhem-p1q6csehmymgutc1asdiyymizxbm87fc6xbcg93svcxzr5tgudsx78aeg8saymwvw" alt="" width="624" height="395"></span></p>
<h1 dir="ltr"><strong>Create new Xamarin .Forms Application :</strong></h1>
<p dir="ltr"><span style="font-size:small">Go to Run (Windows key &#43;R) &gt; type Devenv.exe or select from Windows Application list and select New project from File menu &gt; New Project (ctrl &#43;Shift&#43;N) or click More project template from VS Start screen.</span></p>
<p dir="ltr"><span><img src=":-vtwvgrpd0ln4vwxbykmlytcbc9xbwy5kbbcuxnaenxliyrf1ipzvloae_wqa89a3atom5dltyxwtnd6upidt0tytypice7we4q1pjngw4p5dubdkishyx6wnsora6bwj4b9oi8sfkqfhszv2rq" alt="" width="409" height="285"></span></p>
<p dir="ltr"><span style="font-size:small">New Project &gt;select Cross -Platform from Template &gt; Cross platform App(Xamarin.Forms or native). It will show the screen, as shown below.</span></p>
<p dir="ltr"><span><img src=":-d6w8bxin3uhbyab58qzfc0mnbq1ikpn4db_ff5t9tewzt_prhosimpyydelem3mnv_ptyincn_kxyrsyxu_gx1fh2gtlhbhvzoakdpdtuamj5kir7q5lvanb7xznlbzpnhu-k-vty7pcbygneg" alt="" width="596" height="326"></span></p>
<p dir="ltr"><span style="font-size:small">You can find above screen only on VS 2017. Select Blank apps &gt; select Xamarin.Forms &nbsp;&gt; Select PCL and click on Ok .it will generate all the mobile platform project with PC</span></p>
<p dir="ltr"><span><img src=":-xbtplygitopjvbwppa7yqakrbdcx2hiy0jfgxlostrmzcvfouzkjj7xm1cspo9783ebz0-61pzgqo26dvftlyk0ubojgdbwqgwqsnjfi9lq8t4c33ctetnw0vvztwrsxnobbiywpu5wpqh3axq" alt="" width="356" height="286"></span></p>
<p dir="ltr"><span style="font-size:small">Open your MainPage.xaml file add webview control with following code for web chat enable</span></p>
<p dir="ltr"><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">  &lt;StackLayout WidthRequest=&quot;300&quot; HeightRequest=&quot;500&quot; &gt;

       &lt;Image Source=&quot;profile.png&quot; WidthRequest=&quot;200&quot; HeightRequest=&quot;200&quot;&gt;&lt;/Image&gt;

       &lt;Label Text=&quot;Live Chat with Suthahar via C Sharp corner&quot; FontSize=&quot;20&quot; &gt;&lt;/Label&gt;

       &lt;WebView x:Name=&quot;webview&quot; Source=&quot;https://webchat.botframework.com/embed/DevEnvExeBot?s=8XGcUROXkAA.cwA.pZo.8pJ-6oQ3sJRpxq0tqIo9uLPji4oxBQuz2pW5qWobw2c&quot;

                WidthRequest=&quot;300&quot; HeightRequest=&quot; 300&quot;&gt;&lt;/WebView&gt;

   &lt;/StackLayout&gt;</pre>
<div class="preview">
<pre class="xaml">&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;500&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;profile.png&quot;</span>&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;200&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Image&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Live&nbsp;Chat&nbsp;with&nbsp;Suthahar&nbsp;via&nbsp;C&nbsp;Sharp&nbsp;corner&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Label&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;WebView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;webview&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;https://webchat.botframework.com/embed/DevEnvExeBot?s=8XGcUROXkAA.cwA.pZo.8pJ-6oQ3sJRpxq0tqIo9uLPji4oxBQuz2pW5qWobw2c&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;&nbsp;300&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/WebView&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">Now you can run the application in windows ,Android and iOS</span></p>
<p dir="ltr"><span><img src=":-9zpxc9eyecja6fp8frv7iv-scfyeoendadeg7nfaoy4lzde5dc5ikzzjoanwpodv83g7qh4lbntl6anu9dd2bkp4c8irdeudups2jbw4ofjgc_-hxtvtpmacl2akwflx9gb2uizlfm_jc5ozrw" alt="" width="198" height="404"></span><span><img src=":-dkg8staxuippplae5exjrpnsin6ruqppl_qcxk-zp5ktk_ssfgtpavnpghvhbi7jivzhjspfh7phqciul_rc5tikurt6vrbyemyi2mm67noot0mbxp98iygq4k8uslwo-cpyaiwp8j11zpldgw" alt="" width="212" height="396"></span><span><img src=":-doginm_e54m8zkcbnfixgvqz1riz7g0dexckzpu_yjbwbqufbjsl4elqmhovnxxt9ph5enype-96t6itam0x5sfp7dbr0yojz01u2v2ttx2cgdivjqcfersdftsagmnshrgjpm_pctml3stipg" alt="" width="195" height="398"></span></p>
<p dir="ltr">&nbsp;</p>
<h1 dir="ltr"><span>Summary</span></h1>
<p dir="ltr"><span style="font-size:small">In this article, your learned how to create a Bot application, publish Bot to Azure and bot implementation to Xamarin Forms using Visual Studio 2017. If you have any questions/ feedback/ issues, please write in the
 comment box.</span></p>
<p dir="ltr">&nbsp;</p>
<p dir="ltr">&nbsp;</p>
<p dir="ltr">&nbsp;</p>
<div></div>
