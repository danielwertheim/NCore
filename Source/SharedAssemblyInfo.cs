using System.Runtime.InteropServices;
using System.Reflection;

#if DEBUG
[assembly: AssemblyProduct("NCore (Debug)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyProduct("NCore (Release)")]
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyDescription("Core stuff.")]
[assembly: AssemblyCompany("Daniel Wertheim")]
[assembly: AssemblyCopyright("Copyright © Daniel Wertheim")]
[assembly: AssemblyTrademark("")]

[assembly: AssemblyVersion("0.35.0")]
[assembly: AssemblyFileVersion("0.35.0")]
