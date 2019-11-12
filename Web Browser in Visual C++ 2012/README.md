# Web Browser in Visual C++ 2012
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Web
- explorer
- Web Browser
- Visual  C++
- Text Viewer
- HTML functions
## Topics
- Visual C++
- Web Browser
- HTML functions
- Equations for Web Browsing and Search Engine
- Explorer and Text File Viewer
## Updated
- 07/15/2013
## Description

<h1>Introduction</h1>
<div><em>The Web Browser in Visual C&#43;&#43; 2012 is an example of Visual C&#43;&#43; coding for the application, similar to the Visual Basic Explorer and Web Browser. The application is able to run with the Microsoft search engine, perform as an explorer, run HTML, open
 text files, and surf the web.</em></div>
<h1><span>Building the Sample</span></h1>
<div><em>The code is built on Visual Studio 2008 and is able to run with Visual Studio 2012. There is an error when running the explorer, but additional error coding is able to be done and the command for eg: for explorer is &quot;C:/&quot;</em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em><img id="92383" src="92383-engineering%20and%20computer%20works%20windows%20phone%20application.png" alt="" width="1280" height="800"><img id="92384" src="92384-engineering%20and%20computer%20works%20control%20system%20phone%20application.png" alt="" width="1280" height="800"></em></div>
<div><img id="92385" src="92385-engineering%20and%20computer%20works%20home%20page.png" alt="" width="1280" height="800"><img id="92386" src="92386-engineering%20and%20computer%20works%20explorer.png" alt="" width="1280" height="800"><img id="92387" src="92387-engineering%20and%20computer%20works.png" alt="" width="1280" height="800">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__preproc">#pragma&nbsp;once</span>&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Test&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System::ComponentModel;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System::Collections;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System::Windows::Forms;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System::Data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<span class="cs__keyword">namespace</span>&nbsp;System::Drawing;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;fail();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Summary&nbsp;for&nbsp;Form1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;WARNING:&nbsp;If&nbsp;you&nbsp;change&nbsp;the&nbsp;name&nbsp;of&nbsp;this&nbsp;class,&nbsp;you&nbsp;will&nbsp;need&nbsp;to&nbsp;change&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Resource&nbsp;File&nbsp;Name'&nbsp;property&nbsp;for&nbsp;the&nbsp;managed&nbsp;resource&nbsp;compiler&nbsp;tool</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;associated&nbsp;with&nbsp;all&nbsp;.resx&nbsp;files&nbsp;this&nbsp;class&nbsp;depends&nbsp;on.&nbsp;&nbsp;Otherwise,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the&nbsp;designers&nbsp;will&nbsp;not&nbsp;be&nbsp;able&nbsp;to&nbsp;interact&nbsp;properly&nbsp;with&nbsp;localized</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resources&nbsp;associated&nbsp;with&nbsp;this&nbsp;form.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">ref</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;<span class="cs__keyword">public</span>&nbsp;System::Windows::Forms::Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//TODO:&nbsp;Add&nbsp;the&nbsp;constructor&nbsp;code&nbsp;here</span>&nbsp;
<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;textBox1-&gt;Text=&nbsp;&quot;c:/&quot;;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;Navigate(&quot;www.msn.com&quot;);&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//else&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
textBox1-&gt;Text=<span class="cs__string">&quot;english.cntv.cn/live&quot;</span>;&nbsp;
textBox1-&gt;Update()&nbsp;;&nbsp;
&nbsp;
webBrowser1-&gt;Navigate(textBox1-&gt;Text);&nbsp;
&nbsp;
textBox1-&gt;Text=<span class="cs__string">&quot;&quot;</span>;&nbsp;
<span class="cs__com">//textBox1-&gt;SelectedText&nbsp;=&quot;&quot;;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//textBox1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Clean&nbsp;up&nbsp;any&nbsp;resources&nbsp;being&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(components)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;delete&nbsp;components;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Windows::Forms::Button^&nbsp;&nbsp;button1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>:&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>:&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>:&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Windows::Forms::TextBox^&nbsp;&nbsp;textBox1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Windows::Forms::WebBrowser^&nbsp;&nbsp;webBrowser1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Windows::Forms::WebBrowser^&nbsp;&nbsp;webBrowser2;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Required&nbsp;designer&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System::ComponentModel::Container&nbsp;^components;<span class="cs__preproc">&nbsp;
&nbsp;
#pragma&nbsp;region&nbsp;Windows&nbsp;Form&nbsp;Designer&nbsp;generated&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Required&nbsp;method&nbsp;for&nbsp;Designer&nbsp;support&nbsp;-&nbsp;do&nbsp;not&nbsp;modify</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;the&nbsp;contents&nbsp;of&nbsp;this&nbsp;method&nbsp;with&nbsp;the&nbsp;code&nbsp;editor.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;InitializeComponent(<span class="cs__keyword">void</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Button());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::TextBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::WebBrowser());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::WebBrowser());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;SuspendLayout();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;button1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cs__number">480</span>,&nbsp;<span class="cs__number">45</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;Name&nbsp;=&nbsp;L<span class="cs__string">&quot;button1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">93</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;TabIndex&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;Text&nbsp;=&nbsp;L<span class="cs__string">&quot;Clear&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;UseVisualStyleBackColor&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;button1-&gt;Click&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cs__keyword">this</span>,&nbsp;&amp;Form1::button1_Click);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;textBox1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cs__number">48</span>,&nbsp;<span class="cs__number">46</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1-&gt;Name&nbsp;=&nbsp;L<span class="cs__string">&quot;textBox1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">399</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1-&gt;TabIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;textBox1-&gt;TextChanged&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cs__keyword">this</span>,&nbsp;&amp;Form1::textBox1_TextChanged);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;webBrowser1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;Dock&nbsp;=&nbsp;System::Windows::Forms::DockStyle::Fill;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;MinimumSize&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;Name&nbsp;=&nbsp;L<span class="cs__string">&quot;webBrowser1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;ScriptErrorsSuppressed&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">848</span>,&nbsp;<span class="cs__number">407</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;TabIndex&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser1-&gt;DocumentCompleted&nbsp;&#43;=&nbsp;gcnew&nbsp;System::Windows::Forms::WebBrowserDocumentCompletedEventHandler(<span class="cs__keyword">this</span>,&nbsp;&amp;Form1::webBrowser1_DocumentCompleted_1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;webBrowser2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cs__number">655</span>,&nbsp;<span class="cs__number">45</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;MinimumSize&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;Name&nbsp;=&nbsp;L<span class="cs__string">&quot;webBrowser2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;ScriptErrorsSuppressed&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;TabIndex&nbsp;=&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;Visible&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;webBrowser2-&gt;DocumentCompleted&nbsp;&#43;=&nbsp;gcnew&nbsp;System::Windows::Forms::WebBrowserDocumentCompletedEventHandler(<span class="cs__keyword">this</span>,&nbsp;&amp;Form1::webBrowser2_DocumentCompleted);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Form1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;AutoScaleDimensions&nbsp;=&nbsp;System::Drawing::SizeF(<span class="cs__number">6</span>,&nbsp;<span class="cs__number">13</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;AutoScaleMode&nbsp;=&nbsp;System::Windows::Forms::AutoScaleMode::Font;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;ClientSize&nbsp;=&nbsp;System::Drawing::Size(<span class="cs__number">848</span>,&nbsp;<span class="cs__number">407</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cs__keyword">this</span>-&gt;webBrowser2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cs__keyword">this</span>-&gt;button1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cs__keyword">this</span>-&gt;textBox1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cs__keyword">this</span>-&gt;webBrowser1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Name&nbsp;=&nbsp;L<span class="cs__string">&quot;Form1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;Text&nbsp;=&nbsp;L<span class="cs__string">&quot;Web&nbsp;Browser&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;WindowState&nbsp;=&nbsp;System::Windows::Forms::FormWindowState::Maximized;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;ResumeLayout(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>-&gt;PerformLayout();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
#pragma&nbsp;endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Void&nbsp;button1_Click(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;On&nbsp;error&nbsp;goto&nbsp;errorhandler</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//private:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;button1(void)</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//__try&nbsp;&nbsp;&nbsp;&nbsp;{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;Navigate(textBox1-&gt;Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;ActiveXInstance(textBox1-&gt;Text);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;OnDoubleClick-&gt;Navigating(textBox1-&gt;Refresh);&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;Refresh&nbsp;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1-&gt;Text=<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;textBox1-&gt;Text;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fail();&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;__except&nbsp;will&nbsp;only&nbsp;catch&nbsp;an&nbsp;exception&nbsp;here</span>&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;__except(EXCEPTION_EXECUTE_HANDLER)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;if&nbsp;the&nbsp;exception&nbsp;was&nbsp;not&nbsp;caught&nbsp;by&nbsp;the&nbsp;catch(...)&nbsp;inside&nbsp;fail()</span>&nbsp;
&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;cout&nbsp;&lt;&lt;&nbsp;&quot;An&nbsp;exception&nbsp;was&nbsp;caught&nbsp;in&nbsp;__except.&quot;&nbsp;&lt;&lt;&nbsp;endl;</span>&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;private:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Clean&nbsp;up&nbsp;any&nbsp;resources&nbsp;being&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~button1()</span>&nbsp;
<span class="cs__com">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(webBrowser1)</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;delete&nbsp;webBrowser1;</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Void&nbsp;textBox1_TextChanged(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;Navigate(textBox1-&gt;Text&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;webBrowser1-&gt;Navigate(textBox1-&gt;Text)=webBrowser2-&gt;Navigate(textBox1-&gt;Text)&nbsp;&nbsp;;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Void&nbsp;webBrowser1_DocumentCompleted(System::Object^&nbsp;&nbsp;sender,&nbsp;System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//ebBrowser1-&gt;Navigate&nbsp;(textBox1-&gt;Text);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>:&nbsp;System::Void&nbsp;webBrowser1_DocumentCompleted_1(System::Object^&nbsp;&nbsp;sender,&nbsp;System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//textBox1-&gt;Text=&quot;&quot;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;webBrowser1-&gt;Navigate(textBox1-&gt;Text)&nbsp;&nbsp;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1-&gt;Update();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">private</span>:&nbsp;System::Void&nbsp;webBrowser2_DocumentCompleted(System::Object^&nbsp;&nbsp;sender,&nbsp;System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Form1</em> </li></ul>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<div>#pragma</div>
</span>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">once</span></span></span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
<br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<div>namespace</div>
</span>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">Test {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::ComponentModel;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Collections;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Data;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">using</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Drawing;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 fail();</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// Summary for Form1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// WARNING: If you change the name of this class,
 you will need to change the</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 'Resource File Name' property for the managed resource compiler tool</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 associated with all .resx files this class depends on.&nbsp; Otherwise,</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 the designers will not be able to interact properly with localized</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 resources associated with this form.</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;/summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">public</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">ref</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">class</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 : </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">public</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form</span></span></span></div>
<div><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>{</div>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">public</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>Form1()</div>
<br>
<div>{</div>
<br>
<div>&nbsp;</div>
<br>
<div>InitializeComponent();</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//TODO: Add the constructor code here</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
<div>//</div>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// textBox1-&gt;Text= &quot;c:/&quot;;
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1-&gt;Navigate(&quot;www.msn.com&quot;);
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//else
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
<br>
<div>textBox1-&gt;Text=</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;english.cntv.cn/live&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>textBox1-&gt;Update() ;</div>
<br>
<br>
<div>webBrowser1-&gt;Navigate(textBox1-&gt;Text);</div>
<br>
<br>
<div>textBox1-&gt;Text=</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</span></span><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">
<div>//textBox1-&gt;SelectedText =&quot;&quot;;</div>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//textBox1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>}</div>
<br>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">protected</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// Clean up any resources being used.</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;/summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>~Form1()</div>
<br>
<div>{</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">if</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 (components)</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>{</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">delete</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 components;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>}</div>
<br>
<div>}</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Button</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
 button1;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">protected</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">protected</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>&nbsp;</div>
<br>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">protected</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">TextBox</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
 textBox1;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowser</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
 webBrowser1;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowser</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
 webBrowser2;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// Required designer variable.</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;/summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>System::ComponentModel::</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Container</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 ^components;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<div>#pragma</div>
</span>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">region</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 Windows Form Designer generated code</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// Required method for Designer support - do
 not modify</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// the contents of this method with the code
 editor.</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;/summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 InitializeComponent(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>{</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1
 = (</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Button</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">());</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1
 = (</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">TextBox</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">());</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1
 = (</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowser</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">());</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2
 = (</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowser</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">());</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;SuspendLayout();</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// button1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;Location
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Point</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(480,
 45);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;Name
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;button1&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;Size
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(93,
 20);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;TabIndex
 = 0;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;Text
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;Clear&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;UseVisualStyleBackColor
 = </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">true</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1-&gt;Click
 &#43;= </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">EventHandler</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 &amp;</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::button1_Click);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// textBox1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1-&gt;Location
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Point</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(48,
 46);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1-&gt;Name
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;textBox1&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1-&gt;Size
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(399,
 20);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1-&gt;TabIndex
 = 1;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1-&gt;TextChanged
 &#43;= </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">EventHandler</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 &amp;</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::textBox1_TextChanged);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;Dock
 = System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">DockStyle</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::</span></span><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small">Fill</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;Location
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Point</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(0,
 0);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;MinimumSize
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(20,
 20);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;Name
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;webBrowser1&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;ScriptErrorsSuppressed
 = </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">true</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;Size
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(848,
 407);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;TabIndex
 = 2;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1-&gt;DocumentCompleted
 &#43;= </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowserDocumentCompletedEventHandler</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 &amp;</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::webBrowser1_DocumentCompleted_1);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser2</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;Location
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Point</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(655,
 45);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;MinimumSize
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(20,
 20);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;Name
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;webBrowser2&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;ScriptErrorsSuppressed
 = </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">true</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;Size
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(20,
 20);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;TabIndex
 = 3;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;Visible
 = </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">false</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2-&gt;DocumentCompleted
 &#43;= </span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowserDocumentCompletedEventHandler</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 &amp;</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::webBrowser2_DocumentCompleted);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// Form1</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;AutoScaleDimensions
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">SizeF</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(6,
 13);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;AutoScaleMode
 = System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">AutoScaleMode</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::</span></span><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small">Font</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;ClientSize
 = System::Drawing::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Size</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">(848,
 407);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Controls-&gt;Add(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser2);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Controls-&gt;Add(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;button1);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Controls-&gt;Add(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;textBox1);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Controls-&gt;Add(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;webBrowser1);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Name
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;Form1&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;Text
 = L</span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;Web Browser&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;WindowState
 = System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">FormWindowState</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::</span></span><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small"><span style="color:#2f4f4f; font-family:Consolas; font-size:x-small">Maximized</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;ResumeLayout(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">false</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">);</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">this</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">-&gt;PerformLayout();</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
<div>}</div>
<br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<div>#pragma</div>
</span>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">endregion</span></span></span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 button1_Click(System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Object</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">sender</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">EventArgs</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">e</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)
 {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// On error goto errorhandler</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//private:</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// button1(void)</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//__try {</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
<br>
<div>webBrowser1-&gt;Navigate(textBox1-&gt;Text);</div>
<br>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1-&gt;ActiveXInstance(textBox1-&gt;Text);</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1-&gt;OnDoubleClick-&gt;Navigating(textBox1-&gt;Refresh);&nbsp;&nbsp;
</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
<br>
<div>webBrowser1-&gt;Refresh ();</div>
<br>
<div>textBox1-&gt;Text=</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;&quot;</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">;</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// textBox1-&gt;Text;</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// fail(); }</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
<br>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// __except will only catch an exception here</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// __except(EXCEPTION_EXECUTE_HANDLER)</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>{&nbsp;&nbsp;</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// if the exception was not caught by the catch(...)
 inside fail()</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//&nbsp;&nbsp;&nbsp; cout &lt;&lt; &quot;An exception
 was caught in __except.&quot; &lt;&lt; endl;</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;&nbsp; }</div>
<br>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
<br>
<div>&nbsp;</div>
<br>
</span></span><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">
<div>// private:</div>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">/// Clean up any resources being used.</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">///
</span></span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">&lt;/summary&gt;</span></span></span></div>
<div><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">
<div>// ~button1()</div>
<br>
<div>/// {</div>
<br>
<div>// if (webBrowser1)</div>
<br>
<div>// {</div>
<br>
<div>// delete webBrowser1;</div>
<br>
<div>// }</div>
<br>
<div>// }</div>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>}</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 textBox1_TextChanged(System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Object</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">sender</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">EventArgs</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">e</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)
 {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
<br>
<div>webBrowser1-&gt;Navigate(textBox1-&gt;Text );</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1-&gt;Navigate(textBox1-&gt;Text)=webBrowser2-&gt;Navigate(textBox1-&gt;Text)
 ; </span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>}</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 webBrowser1_DocumentCompleted(System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Object</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">sender</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowserDocumentCompletedEventArgs</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">e</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)
 {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//ebBrowser1-&gt;Navigate (textBox1-&gt;Text);</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>}</div>
<br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">private</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">:
 System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 webBrowser1_DocumentCompleted_1(System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Object</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">sender</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowserDocumentCompletedEventArgs</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">e</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)
 {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">//textBox1-&gt;Text=&quot;&quot;;</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// webBrowser1-&gt;Navigate(textBox1-&gt;Text)&nbsp;
 ;</span></span></span></div>
<div><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>textBox1-&gt;Update();</div>
<br>
<div>}</div>
<br>
<br>
<div>&nbsp;</div>
<br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<div>private</div>
</span>
<div>&nbsp;</div>
</span>
<div>&nbsp;</div>
</span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">: System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Void</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 webBrowser2_DocumentCompleted(System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Object</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">sender</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">,
 System::Windows::Forms::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">WebBrowserDocumentCompletedEventArgs</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">^&nbsp;
</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">e</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)
 {</span></span></div>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<div>}</div>
<br>
<div>};</div>
<br>
<div>&nbsp;</div>
<br>
<div>}</div>
<br>
</span></span></div>
<ul>
<li><em><em>Test.cpp</em></em> </li></ul>
<p><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"></p>
<p>// Test.cpp : main project file.</p>
<br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<p>#include</p>
</span>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;stdafx.h&quot;</span></span></span></p>
<p><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"></p>
<p>#include</p>
</span>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small">&quot;Form1.h&quot;</span></span></span></p>
<p><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><span style="color:#a31515; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"></p>
<p>using</p>
</span>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">namespace</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 Test;</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
</p>
<p>[STAThreadAttribute]</p>
<br>
</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">
<p>int</p>
</span>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">main(</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">array</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">&lt;System::</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">String</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 ^&gt; ^</span></span><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small"><span style="color:#808080; font-family:Consolas; font-size:x-small">args</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">)</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</p>
<p>{</p>
<br>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// Enabling Windows XP visual effects before any
 controls are created</span></span></span></p>
<p><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></p>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Application</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::EnableVisualStyles();</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</p>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Application</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::SetCompatibleTextRenderingDefault(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">false</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">);
</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
<br>
</p>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small">// Create the main window and run it</span></span></span></p>
<p><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><span style="color:#008000; font-family:Consolas; font-size:x-small"><br>
</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></p>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Application</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">::Run(</span></span><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">gcnew</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
</span></span><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small"><span style="color:#2b91af; font-family:Consolas; font-size:x-small">Form1</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">());</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</p>
<p>&nbsp;</p>
</span>
<p>&nbsp;</p>
</span>
<p></p>
<p><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small"><span style="color:#0000ff; font-family:Consolas; font-size:x-small">return</span></span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
 0;</span></span></p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"><br>
</p>
<p>}</p>
</span></span>
<p></p>
<h1>More Information</h1>
<div><em>The codes for the programs are from Engineering and Computer Works.Please contact Engineering and Computer Works(<a href="http://engineeringcomputerworks.com">http://engineeringcomputerworks.com</a>) for more information or&nbsp;<a href="mailto:chanjunthoong@theiet.org">chanjunthoong@theiet.org</a>.</em></div>
