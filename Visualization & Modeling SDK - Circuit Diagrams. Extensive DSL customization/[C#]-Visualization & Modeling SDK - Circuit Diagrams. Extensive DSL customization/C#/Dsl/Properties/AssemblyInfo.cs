#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"Fabrikam AG")]
[assembly: AssemblyProduct(@"Circuits etc")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"Fabrikam.Circuits.DslPackage, PublicKey=00240000048000009400000006020000002400005253413100040000010001004B59334E8C80B6FB8379BECB6A0F417F809469C29B4E2627448A14F4FE57AB18FF429945E96A705660B1D7EE146514EF701395A596D10965F0EBC983EC0B178AD92F4ED41CA165B9D4477DF4B9FD9D8FB1F6E8A2668D8BF3D1DAD81C5CB8804B6C2E0D2060C7E77463595F5D77D999417A0D23B5C2FF4E000B5920696912DEBA")]