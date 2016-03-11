// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionInfo.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//   SolutionInfo.cs - Version information for an assembly
//   General Information about an assembly is controlled through the following 
//   set of attributes. Change these attribute values to modify the information
//   associated with an assembly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//

[assembly: AssemblyCompany("Cognite")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.1.0")]

#if (DEBUG)
[assembly: AssemblyFileVersion("1.0.1.1")]
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyFileVersion("1.0.1.0")]
[assembly: AssemblyConfiguration("RELEASE")]
#endif
