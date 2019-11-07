# UI Composition Code Sample using the Prism Library 5.0 for WPF
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET
- XAML
## Topics
- Prism
- UI Composition
- Prism UI Composition
## Updated
- 08/21/2014
## Description

<h1>Introduction</h1>
<p class="ppBodyText">The UI Composition QuickStart sample illustrates how to use both the view discovery and view injection approaches for user interface (UI) composition with the Prism Library 5.0 for WPF. When using view discovery, modules can register
 views against a particular named location. When that location is displayed at run time, any views that have been registered for that location will be automatically created and displayed within it. In the view injection approach, views are programmatically
 added or removed from a named location by the modules that manage them. To enable this, the application contains a registry of named locations in the UI, and a module can look up one of the locations using the registry and then programmatically inject views
 into it.</p>
<p class="ppBodyText">The QuickStart&nbsp;illustrates the following:</p>
<ul>
<li><strong>Shell view</strong>. This is the application's main window. This window contains both the left and main regions.
</li><li><strong>Left region</strong>. This region contains the view that includes the list of employees, through view discovery.
</li><li><strong>Employees List view</strong>. This view displays a list of employees.
</li><li><strong>Main region</strong>. This region has the employee summary view injected into it.
</li><li><strong>Employee Summary view</strong>. This view displays information for an employee and contains a tab region. It is added to the application via view injection.
</li><li><strong>Tab region</strong>. The tab region resides in the employee summary view, and has the employee details and projects views added via view discovery.
</li><li><strong>Employee Details view</strong>. This view shows the details about the selected employee.
</li><li><strong>Employees Projects view</strong>. This view displays the list of projects an employee is working on.
</li></ul>
<p class="ppBodyText">&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p class="ppBodyText">This QuickStart requires Microsoft Visual Studio 2012 or later and the .NET Framework 4.5.1.</p>
<p class="ppProcedureStart">To build and run the MVVM QuickStart</p>
<ol>
<li>In Visual Studio, open the solution file UIComposition_Desktop\UICompositionQuickstart_Desktop.sln.
</li><li>In the&nbsp;<strong>Build</strong>&nbsp;menu, click&nbsp;<strong>Rebuild Solution</strong>.
</li><li>Press F5 to run the QuickStart. </li></ol>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em><em>For more information on the QuickStart, see the associated&nbsp;<a href="http://aka.ms/prism-wpf-QSUICompositionDoc">documentation&nbsp;</a>on MSDN.&nbsp;</em></em></p>
