# State-Based Navigation Code Sample using the Prism Library 5.0 for WPF
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- .NET Framework
## Topics
- Navigation
- Prism
- Prism Navigation
## Updated
- 08/21/2014
## Description

<h1>Introduction</h1>
<p>The State-Based Navigation QuickStart sample demonstrates navigation using the WPF Visual State Manager (VSM) with the Model-View-ViewModel (MVVM) pattern and the Prism Library. This approach uses the Visual State Manager to define the different application
 states that the application has, define animations for both the states and the transitions between states; the animations associated to states are active while the state is active for the duration of the specified timeline.</p>
<p>One important aspect of application design is getting the navigation right. To define the navigation of the application, you need to design the screens, interaction, and the visual appearance of the application.&nbsp;</p>
<p>The QuickStart highlights the key elements and considerations to implement an approach for navigation that uses the VSM. For more information about the VSM, see
<a href="http://msdn.microsoft.com/en-us/library/system.windows.visualstatemanager.aspx">
VisualStateManager Class</a> on MSDN. In this QuickStart, most of the UI is in a few classes (the
<strong>ChatView</strong> and <strong>SendMessagePopupView</strong> classes), and the visual states determine what is shown and how to go from one state to another. Some states change visibility of elements within the view, some states change enablement, and
 some states activate components.&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p class="ppBodyText">This QuickStart requires Microsoft Visual Studio 2012 or later and the .NET Framework 4.5.1.</p>
<p class="ppProcedureStart">To build and run the MVVM QuickStart</p>
<ol>
<li>In Visual Studio, open the solution file State-Based Navigation_Desktop\State-Based Navigation.sln.
</li><li>In the&nbsp;<strong>Build</strong>&nbsp;menu, click&nbsp;<strong>Rebuild Solution</strong>.
</li><li>Press F5 to run the QuickStart. </li></ol>
<p><span style="font-size:2em">More Information</span></p>
<p><em><em>or more information on the MVVM QuickStart, see the associated&nbsp;<a href="http://aka.ms/prism-wpf-QSStateBasedNavDoc">documentation&nbsp;</a>on MSDN.&nbsp;</em></em></p>
