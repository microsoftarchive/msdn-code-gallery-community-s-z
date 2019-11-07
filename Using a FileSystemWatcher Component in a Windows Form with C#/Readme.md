# Using a FileSystemWatcher Component in a Windows Form with C#
## Requires
- Visual Studio 2002
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- File System
## Updated
- 08/23/2011
## Description

<h1>Introduction</h1>
<p class="Text">The FileSystemWatcher Class monitors the file system and raises events whenever a specified Directory or file within a specified Directory changes. This class can watch for changes within the directory to include sub directories and can monitor
 directories on a local machine, a network drive, or a remote computer.</p>
<h1>How to Use</h1>
<p class="Text">Open the solution in Visual Studio.NET.</p>
<h1>Description</h1>
<p class="Text">In this example, whenever an event is raised for a file that is changed, deleted, or created in the specified directory, the FileMonitor_Changed event is called, which raises a message box to notify the user. When the event for a file that
 has been renamed is raised, then the FileMonitor_OnRenamed event handler is called. This also raises a message box to notify the user. To enable the FileSystemWatcher object to raise these events, the EnableRaisingEvents property must be set to &ldquo;true&rdquo;.
 This can be set when the component is added to the designer, but can also be set programmatically, which is demonstrated in the OnClick event of both the Start and Stop command buttons.</p>
<p class="Text">This example provides an interface for the user to enter a valid directory, select a filter, and then determine whether the monitor should watch sub-directories. Once the information is entered, the user can click the Start command button
 to set the configuration and begin the watch. In the click event for the &ldquo;Start&rdquo; button, the application checks for the values on the form and sets the properties for the FileSystemWatcher FileMonitor. Here the application is only concerned with
 setting the Path, Filter, and IncludeSubDirectories properties. Notice also that it has set the NotifyFilter property. This is done without the user input, but this information could easily be requested from the user.</p>
<p class="Text">The Path property gets or sets the path to the directory to watch. The Filter property gets or sets the filter string to determine which files are monitored in a directory. The default value for this property is &ldquo;*.*&rdquo;, but the
 developer may set this property to watch for any valid file type (.txt, .doc, .xls). If the developer chooses to monitor a specific file, then a file name may be used (MyTextDocument.txt, for example). The IncludeSubDirectories property is a boolean property
 which gets or sets the value to determine if the watcher will monitor subdirectories of the Path property. The NotifyFilter property, which is set by the application in this example, allows the developer to determine the types of changes to monitor. The available
 values from the NotifyFilters enumeration are: Attributes, CreationTime, DirectoryName, FileName, LastAccess, LastWrite, Security, and Size.</p>
<p class="Text">You should also take a look at the Creating A Windows Service sample which also uses the FileSystemWatcher component. This sample uses a background service to monitor files and obtains it configuration information from a configuration file.</p>
