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
[assembly: AssemblyCompany(@"Company Name")]
[assembly: AssemblyProduct(@"LanguageSm")]
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
[assembly: InternalsVisibleTo(@"CompanyName.LanguageSm.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100834EFB7FEF2C6BF5DE670B91E0F0CA76FD6FDED17FC60C74CF8D70634A2D87772F39D782F4A1C9FA4F41D6137B01AA761EB1EA73C2DCA0D5FEACC70F3A475E629F7FACFC4F5933F1A255C523FBEE68860D96F37896B83B566882D01FEBC0DD683264F3C4539056BD4BD9605C5BE67E6777B1563EA4F3EC07A8B1DF66FE1322A8")]