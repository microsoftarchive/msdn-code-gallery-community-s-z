# Windows 10 #UWP Apps: Calendar Controls (C#-XAML)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows 10
- Universal Windows App Development
- Universal Windows Platform
## Topics
- CalendarView Controls in windows 10 C#-Xaml
## Updated
- 03/05/2016
## Description

<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Introduction:</strong></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In&nbsp;</span><a href="http://bsubramanyamraju.blogspot.in/2014/06/windowsphone-80-vs-windowsphone-81new.html">prev</a><span style="font-family:verdana,sans-serif">&nbsp;post i was
 explained about how to use TimePicker &amp; DatePicker controls in WinRT windows phone 8.1.But the DatePicker is optimized for picking a known date, such as a date of birth, where the context of the calendar is not important. Fortunately from Windows 10 OS(version
 10.0.10240.0) Microsoft introduce&nbsp;<a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendarview.aspx">CalendarView&nbsp;</a>&amp;&nbsp;<a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendardatepicker.aspx">CalendarDatePicker&nbsp;</a>controls,
 so these controls can gives you a standardized way to let users view and interact with a calendar.</span><span style="font-family:verdana,sans-serif">&nbsp;</span></span></p>
<p><span style="font-size:small">You can also read this article at my original blog from
<a href="http://bsubramanyamraju.blogspot.com/2016/03/windows-10-uwp-apps-now-calendar.html" target="_blank">
here</a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-U8hrFXODqog/Vtu9bEw1Z1I/AAAAAAAACbw/LBgqULodtgc/s1600/2.Output3.png"><img src="https://3.bp.blogspot.com/-U8hrFXODqog/Vtu9bEw1Z1I/AAAAAAAACbw/LBgqULodtgc/s1600/2.Output3.png" border="0" alt=""></a></span></p>
<p class="separator"><span style="font-size:small">&nbsp;<strong style="font-size:small">Requirements:</strong></span></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article is targeted for windows 10 Universal Windows Platform(Version 1511) , so make sure you&rsquo;ve downloaded and installed the latest Windows 10 SDK from&nbsp;<a href="https://dev.windows.com/en-us/downloads">h
 ere</a>.</span> </li><li><span style="font-family:verdana,sans-serif; font-size:small">I assumes that you&rsquo;re going to test your app on the Windows Phone emulator. If you want to test your app on a phone, you have to take some additional steps. For more info, see&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/dn614128.aspx">Register
 your Windows Phone device for development</a>.</span> </li><li><span style="font-family:verdana,sans-serif; font-size:small">This post assumes&nbsp;you&rsquo;re using&nbsp;<strong>Microsoft Visual Studio 2015 or Later.</strong></span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This article is developed on windows 8.1 machine. So Visual Studio settings may differ from windows 10 OS VS.</span>
</li></ul>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Note:</strong>&nbsp;Windows 10 SDK works best on the Windows 10 operating system. And it is&nbsp;</span><span style="font-family:verdana,sans-serif">also supported on: Windows
 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2, but n</span><span style="font-family:verdana,sans-serif">ot all tools are supported on these operating systems.</span>&nbsp;</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Description:</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">This article can explain you about below topics</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. How to create new project in Windows 10?</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">2. How to use CalendarView control in Windows 10?</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">3. How to use CalendarDatePicker control in Windows 10?</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">4. How to run Windows 10 UWP app in emulator?</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small"><br>
<strong>1. How to create new project in Windows 10?</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Before to use&nbsp;calendar&nbsp;controls, first we need to create new project.&nbsp;</span></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">Launch Visual Studio 2015</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">On the File menu, select New &gt; Project.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">The New Project dialog appears. The left pane of the dialog lets you select the type of templates to display.In the left pane, expand&nbsp;<strong>Installed</strong>&nbsp;&gt;&nbsp;<strong>Templates&nbsp;</strong>&gt;&nbsp;<strong>Visual
 C#</strong>&nbsp;&gt;&nbsp;<strong>Windows</strong>, then pick the&nbsp;<strong>Universal&nbsp;</strong>template group. The dialog's center pane displays a list of project templates for Universal Windows Platform (UWP) apps.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">In the center pane, select the Blank App (Universal Windows) template.The Blank App template creates a minimal UWP app that compiles and runs, but contains no user-interface controls or data.
 You add controls to the app over the course of this tutorial.In the Name text box, type &quot;<strong>UWPCalenderControl</strong>&quot;.Click OK to create the project.</span>
</li></ul>
<p><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-NsUsbrH3jo8/Vtr77pMZvAI/AAAAAAAACbA/nTpTclwgnzA/s1600/1.NewProject.PNG"><img src="https://3.bp.blogspot.com/-NsUsbrH3jo8/Vtr77pMZvAI/AAAAAAAACbA/nTpTclwgnzA/s640/1.NewProject.PNG" border="0" alt="" width="640" height="390"></a></span></p>
<span style="font-size:small"><span style="font-family:verdana,sans-serif">
<p class="separator">Visual Studio creates your project and displays it in the Solution Explorer.</p>
<p class="separator"><a href="https://4.bp.blogspot.com/-ppLBaXT3E1c/Vtr8rP1nRsI/AAAAAAAACbE/iJUKk14uhGo/s1600/1.NewProject1.PNG"><img src="https://4.bp.blogspot.com/-ppLBaXT3E1c/Vtr8rP1nRsI/AAAAAAAACbE/iJUKk14uhGo/s1600/1.NewProject1.PNG" border="0" alt=""></a></p>
</span><strong><span style="font-family:verdana,sans-serif">2.&nbsp;</span><span style="font-family:verdana,sans-serif">How to use&nbsp;CalendarView&nbsp;control in Windows 10?</span></strong>
</span>
<p><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;Now its time to use calendar controls and from windows 10 OS we have an in-built class called&nbsp;CalendarView, which can provide a standardized way to let users view and interact with
 a calendar. If you need to let a user select multiple dates, you must use a CalendarView.</span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">Okay now lets start to use&nbsp;</span><span style="font-family:verdana,sans-serif">CalendarView in our MainPage.xaml like below:</span>&nbsp;</span></p>
<ol class="dp-xml">
<li class="alt"><span style="color:#000000; font-size:small"><span class="tag">&lt;</span><span class="tag-name">CalendarView&nbsp;x:Name=&quot;MyCalendarView</span>&nbsp;<span class="attribute">DisplayMode</span>=<span class="attribute-value">&quot;Month&quot;&nbsp;SelectionMode=&quot;Multiple&quot;</span>&nbsp;<span class="attribute">CalendarItemBackground</span>=<span class="attribute-value">&quot;LightBlue&quot;</span>&nbsp;<span class="attribute">BorderBrush</span>=<span class="attribute-value">&quot;Orange&quot;</span>&nbsp;<span class="attribute">BorderThickness</span>=<span class="attribute-value">&quot;3&quot;</span><span class="tag">/&gt;</span>&nbsp;&nbsp;</span>
</li></ol>
<p><span style="font-family:verdana,sans-serif; font-size:small">In above code&nbsp;</span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">SelectionMode property is set to Multiple to let a user select multiple dates.&nbsp;</span><span style="font-family:verdana,sans-serif">DisplayMode property is useful to set calendar
 startup view and it is having three values(Month,Year,Decade). By default, it starts with the month view open.</span>&nbsp;</span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-UtqVgBPos8Q/VtsM9QwJD6I/AAAAAAAACbY/5heSimEobv0/s1600/CalendarView.png"><img src="https://1.bp.blogspot.com/-UtqVgBPos8Q/VtsM9QwJD6I/AAAAAAAACbY/5heSimEobv0/s640/CalendarView.png" border="0" alt="" width="640" height="290"></a></span></p>
<p>&nbsp;</p>
<p><span style="font-family:verdana,sans-serif; font-size:small">So when users click the header in the month view to open the year view, and click the header in the year view to open the decade view. Users pick a year in the decade view to return to the year
 view, and pick a month in the year view to return to the month view. The two arrows to the side of the header navigate forward or backward by month, by year, or by decade.</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">And in C# code we can also set selected date, MinDate &amp; MaxDate like below:</span></p>
<p>&nbsp;</p>
<ol class="dp-c">
<li class="alt"><span style="color:#000000; font-size:small">MyCalendarView.SelectedDates.Add(<span class="keyword" style="color:#006699">new</span>&nbsp;DateTime(2016,&nbsp;3,&nbsp;11));<span class="comment" style="color:#008200">//&nbsp;Set&nbsp;selected&nbsp;date&nbsp;is&nbsp;March&nbsp;3rd&nbsp;2016);</span>&nbsp;&nbsp;</span>
</li><li><span style="color:#000000; font-size:small">MyCalendarView.MinDate&nbsp;=&nbsp;<span class="keyword" style="color:#006699">new</span>&nbsp;DateTime(2016,&nbsp;2,&nbsp;28);<span class="comment" style="color:#008200">//Min&nbsp;date&nbsp;is&nbsp;FEB&nbsp;28th&nbsp;2016</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small"><span style="color:#000000">MyCalendarView.MaxDate&nbsp;=&nbsp;DateTime.Now.AddMonths(3);&nbsp;</span>//Max date is 3 months from current date</span>
</li><li class="alt"><span style="font-size:small"><span style="font-family:consolas,'courier new',courier,mono,serif">MyCalendarView.NumberOfWeeksInView = 6;</span><span class="comment" style="color:#008200">//Month view show 6 weeks at a time</span>&nbsp;&nbsp;</span>
</li></ol>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>3.&nbsp;</strong></span><span style="font-family:verdana,sans-serif"><strong>How to use CalendarDatePicker control in Windows 10?</strong></span></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">The CalendarView gives you a standardized way to let users view and interact with a calendar. If you need to let a user select multiple dates, you must use a CalendarView.
 If you need to let a user pick only a single date and don&rsquo;t need a calendar to be always visible, consider using a CalendarDatePicker or DatePicker control. &nbsp;So&nbsp;</span>CalendarDatePicker&nbsp;can represents a control that allows a user to pick
 a date from a calendar display.</span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">Okay now lets start to use&nbsp;</span><span style="font-family:verdana,sans-serif">CalendarDatePicker&nbsp;in our MainPage.xaml like below:</span></span></p>
<ol class="dp-xml">
<li class="alt"><span style="font-size:small"><span class="tag">&lt;</span><span class="tag-name">CalendarDatePicker</span>&nbsp;<span class="attribute">x:Name</span>=<span class="attribute-value">&quot;MyCalendarDatePicker&quot;</span><span class="tag">/&gt;</span>&nbsp;&nbsp;</span>
</li></ol>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">But we can also add more below properties to&nbsp;</span>CalendarDatePicker</span></p>
<p class="separator">&nbsp;</p>
<ul>
<li><span style="font-size:small">customize Header</span> </li><li><span style="font-family:verdana,sans-serif; font-size:small">PlaceholderText</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">We can also set DateFormat</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">DisplayMode of calendar(Month, Year, Decade)</span>
</li></ul>
<p>&nbsp;</p>
<ol class="dp-xml">
<li class="alt"><span style="font-size:small"><span class="tag">&lt;</span><span class="tag-name">CalendarDatePicker</span>&nbsp;<span class="attribute">x:Name</span>=<span class="attribute-value">&quot;MyCalendarDatePicker&quot;</span>&nbsp;<span class="attribute">Grid.Row</span>=<span class="attribute-value">&quot;0&quot;</span>&nbsp;<span class="attribute">DisplayMode</span>=<span class="attribute-value">&quot;Month&quot;</span>&nbsp;<span class="attribute">IsCalendarOpen</span>=<span class="attribute-value">&quot;True&quot;</span>&nbsp;<span class="attribute">DateChanged</span>=<span class="attribute-value">&quot;MyCalendarDatePicker_DateChanged&quot;</span>&nbsp;<span class="attribute">DateFormat</span>&nbsp;=&nbsp;<span class="attribute-value">&quot;{}{dayofweek.full}&lrm;,&nbsp;&lrm;{month.full}&lrm;&nbsp;&lrm;{day.integer}&lrm;,&nbsp;&lrm;{year.full}&quot;</span>&nbsp;<span class="attribute">PlaceholderText</span>=<span class="attribute-value">&quot;Choose&nbsp;your&nbsp;date&quot;</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li><span class="comments" style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--Customising&nbsp;CalendarDatePicker&nbsp;HeaderTemplate&nbsp;--&gt;&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;</span><span class="tag-name">CalendarDatePicker.HeaderTemplate</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;</span><span class="tag-name">DataTemplate</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;</span><span class="tag-name">TextBlock</span>&nbsp;<span class="attribute">FontSize</span>=<span class="attribute-value">&quot;18&quot;</span>&nbsp;<span class="attribute">FontWeight</span>=<span class="attribute-value">&quot;Bold&quot;</span>&nbsp;<span class="attribute">Foreground</span>=<span class="attribute-value">&quot;Green&quot;</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;</span><span class="tag-name">Underline</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Windows&nbsp;10&nbsp;Calendar&nbsp;control&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;/</span><span class="tag-name">Underline</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;/</span><span class="tag-name">TextBlock</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;/</span><span class="tag-name">DataTemplate</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;/</span><span class="tag-name">CalendarDatePicker.HeaderTemplate</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="tag">&lt;/</span><span class="tag-name">CalendarDatePicker</span><span class="tag">&gt;</span>&nbsp;&nbsp;</span>
</li></ol>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">And in C# code we can also set selected date, MinDate &amp; MaxDate like below:</span></p>
<ol class="dp-c">
<li class="alt"><span style="font-size:small">MyCalendarDatePicker.Date&nbsp;=&nbsp;<span class="keyword">new</span>&nbsp;DateTime(2016,&nbsp;3,&nbsp;11);<span class="comment">//Selected&nbsp;date&nbsp;is&nbsp;March&nbsp;3rd&nbsp;2016</span>&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">MyCalendarDatePicker.MinDate&nbsp;=&nbsp;<span class="keyword">new</span>&nbsp;DateTime(2016,&nbsp;2,&nbsp;28);<span class="comment">//FEB&nbsp;28th&nbsp;2016</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">MyCalendarDatePicker.MaxDate&nbsp;=&nbsp;DateTime.Now.AddMonths(3);<span class="comment">//Max&nbsp;date&nbsp;is&nbsp;3&nbsp;months&nbsp;from&nbsp;current&nbsp;date</span>&nbsp;&nbsp;</span>
</li></ol>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">We can get selected date of calendar view in 'DateChanged' event and in below code I am trying to display selected date in ContentDialog.</span></p>
<ol class="dp-c">
<li class="alt"><span style="font-size:small"><span class="keyword">private</span>&nbsp;<span class="keyword">void</span>&nbsp;MyCalendarDatePicker_DateChanged(CalendarDatePicker&nbsp;sender,&nbsp;CalendarDatePickerDateChangedEventArgs&nbsp;args)&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp; &nbsp; {&nbsp;&nbsp;</span> </li><li class="alt"><span class="comment" style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;//Checking&nbsp;selected&nbsp;date&nbsp;is&nbsp;null&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<span class="keyword">if</span>&nbsp;(args.NewDate&nbsp;!=&nbsp;<span class="keyword">null</span>)&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span>
</li><li><span class="comment" style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/*&nbsp;Getting&nbsp;selected&nbsp;new&nbsp;date&nbsp;value*/&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayDate(args.NewDate.Value.ToString());&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp; &nbsp; &nbsp;}&nbsp;&nbsp;</span>
</li><li><span style="font-size:small"><span class="keyword">private</span>&nbsp;async&nbsp;<span class="keyword">void</span>&nbsp;DisplayDate(<span class="keyword">string</span>&nbsp;SelectedDate)&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp; &nbsp; &nbsp;{&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ContentDialog&nbsp;noWifiDialog&nbsp;=&nbsp;<span class="keyword">new</span>&nbsp;ContentDialog()&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="string">&quot;Windows&nbsp;10&nbsp;Calendar&nbsp;Control&quot;</span>,&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content&nbsp;=&nbsp;<span class="string">&quot;Selected&nbsp;date&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;SelectedDate,&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PrimaryButtonText&nbsp;=&nbsp;<span class="string">&quot;Ok&quot;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; };&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;noWifiDialog.Margin&nbsp;=&nbsp;<span class="keyword">new</span>&nbsp;Thickness(0,&nbsp;100,&nbsp;0,&nbsp;0);&nbsp;&nbsp;</span>
</li><li class="alt"><span style="font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;noWifiDialog.ShowAsync();&nbsp;&nbsp;</span>
</li><li><span style="font-size:small">&nbsp; &nbsp; &nbsp; } &nbsp;</span> </li></ol>
<p><span style="font-size:small"><strong>4. How to run Windows 10 UWP app in emulator?</strong></span></p>
<p><span style="font-size:small">Now its time to test our sample, so follow below steps to run the app.</span></p>
<p><span style="font-size:small"><strong>Step 1:&nbsp;</strong><span style="font-family:verdana,sans-serif">In addition to the options to&nbsp;<strong>Debug&nbsp;</strong>on a desktop device, Visual Studio provides options for deploying and debugging your app
 on a physical mobile device connected to the computer, or on a mobile device emulator. You can choose among emulators for devices with different memory and display configurations like below</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-UKOk1pFvA4Q/VtvMfguNRfI/AAAAAAAACcA/qP5qCZIuIh0/s1600/Emulator.PNG"><img src="https://1.bp.blogspot.com/-UKOk1pFvA4Q/VtvMfguNRfI/AAAAAAAACcA/qP5qCZIuIh0/s1600/Emulator.PNG" border="0" alt=""></a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><strong>Note:&nbsp;</strong></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">1. It's a good idea to test your app on a deivce with a small screen and limited memory, so use the Emulator 10.0.10240.0 WVGA 4 inch 512MB option.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">2. If you want to test our app in physical device, you must&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/dn614128.aspx">Register your Windows
 Phone device for development</a>.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">3. If you already have .APPx file, you can deploy it from&nbsp;<a href="http://bsubramanyamraju.blogspot.in/2016/02/windows-10-uwp-apps-how-to-deploy-appx.html" target="_blank">WinAppDeployCmd.exe</a>&nbsp;tool</span></p>
<span style="font-family:verdana,sans-serif; font-size:small">
<p class="separator">&nbsp;</p>
<p class="separator">After selecting emulator/device, From the&nbsp;<strong>Debug</strong>&nbsp;menu, click&nbsp;<strong>Start Debugging&nbsp;</strong>or Press F5. Then we can found below screen on emulator/device:</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-g3yIyipOegA/VtvOv5Wkx7I/AAAAAAAACcI/TOnWnpm0ZOY/s1600/2.Output1.PNG"><img src="https://1.bp.blogspot.com/-g3yIyipOegA/VtvOv5Wkx7I/AAAAAAAACcI/TOnWnpm0ZOY/s400/2.Output1.PNG" border="0" alt="" width="212" height="400"></a></p>
<p class="separator"><a href="https://3.bp.blogspot.com/-ycKuK06BIVE/VtvOv5_iJ8I/AAAAAAAACcM/7Mo5fQwo6nY/s1600/2.Output2.PNG"><img src="https://3.bp.blogspot.com/-ycKuK06BIVE/VtvOv5_iJ8I/AAAAAAAACcM/7Mo5fQwo6nY/s400/2.Output2.PNG" border="0" alt="" width="212" height="400"></a></p>
<p>&nbsp;</p>
<p class="separator"><strong><span style="font-family:verdana,sans-serif">Important Notes:</span></strong></p>
</span>
<div>
<div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. A user can clear the selected date by clicking the selected date in the calendar view to deselect it.</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">2. By default, the minimum date shown in the CalendarView is 100 years prior to the current date, and the maximum date shown is 100 years past the current date. You can change the minimum and
 maximum dates that the calendar shows by setting the MinDate and MaxDate properties.</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">3. By default, the month view shows 6 weeks at a time. You can change the number of weeks shown by setting the NumberOfWeeksInView property. The minimum number of weeks to show is 2; the maximum
 is 8.</span></p>
</div>
<p class="separator">&nbsp;</p>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">4. This sample will be work on all window 10 devices OS devices. And this sample was tested in Emulator &amp; Lumia 735 device with Windows 10 OS (</span><span style="font-family:verdana,sans-serif">version
 1511</span><span style="font-family:verdana,sans-serif">)</span><span style="font-family:verdana,sans-serif">.</span></span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">5. W</span><span style="font-family:verdana,sans-serif">indows 10 SDK works best on the Windows 10 operating system. And it is&nbsp;</span><span style="font-family:verdana,sans-serif">also
 supported on: Windows 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2, but n</span><span style="font-family:verdana,sans-serif">ot all tools are supported on these operating systems</span></span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">6.&nbsp;</span><span style="font-family:verdana,sans-serif">This article is developed on windows 8.1 OS Machine with 64 bit.</span><span style="font-family:verdana,sans-serif">&nbsp;</span></span></p>
<p class="separator"><span style="font-size:small"><strong>Help me with feedback:</strong></span></p>
<p class="separator"><span style="font-size:small"><strong>&nbsp;</strong>Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">&nbsp;star
 rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice).&nbsp;</span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif"><br>
</span></span></p>
</div>
</div>
</div>
<h2>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">Follow me always at&nbsp;&nbsp;</span><a class="account-group x_x_x_js-account-group x_x_x_js-action-profile x_x_x_js-user-profile-link x_x_x_js-nav" href="https://twitter.com/Subramanyam_B" style="font-family:verdana,sans-serif; font-size:small"><span class="username js-action-profile-name" style="color:#8899a6"><span style="color:#b1bbc3">@</span>Subramanyam_B</span>&nbsp;</a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Have a nice day by<span style="color:#000000">&nbsp;</span><a href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
</h2>
</div>
