[Installation]
After successful build, execute Registration.bat with elevated administrator privileges. The batch
file has menu options you can use to register for Solid Edge x86 or x64. Technically speaking, you
can register for both and it won't hurt anything. Just be sure to unregister the addin when you're done.

[Debugging]
In the project properties, navigate to the 'Debug' page. Set the 'Start Action' to 'Start external program'
and choose the path to Edge.exe. Set breakpoints as needed. Depending on the specified
 'AddInEnvironmentCategory' attribute(s), the addin will be initialized by Solid Edge.

[Win32 Resources]
The project file (XML) has been manually edited to include the <Win32Resource> element. This
instructs the compiler to include the Win32 resource into the build. Solid Edge uses these resources
for things like EdgeBar, CommandBar, etc.

<Project>
  <PropertyGroup>
    <Win32Resource>Resources.res</Win32Resource>
  </PropertyGroup>
</Project>