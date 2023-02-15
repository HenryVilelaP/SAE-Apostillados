using  System.EnterpriseServices;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// La información general sobre un ensamblado se controla mediante el siguiente 
// conjunto de atributos. Cambie estos atributos para modificar la información
// asociada con un ensamblado.
[assembly: AssemblyTitle("SAE.BusinessLayer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("MRE")]
[assembly: AssemblyProduct("SAE.BusinessLayer")]
[assembly: AssemblyCopyright("© MRE")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Si establece ComVisible como false hace que los tipos de este ensamblado no sean visibles 
// a los componentes COM. Si necesita obtener acceso a un tipo en este ensamblado desde 
// COM, establezca el atributo ComVisible como true en este tipo.
[assembly: ComVisible(true)]

// El siguiente GUID sirve como identificador de la biblioteca de tipos si este proyecto se expone a COM
[assembly: Guid("91F4954A-2E07-4d8b-8F0E-671A706F1FFA")]

// La información de versión de un ensamblado consta de los cuatro valores siguientes:
//          9889D179-2F6D-3825-A0F3-EF5E999F3956
//      Versión principal
//      Versión secundaria 
//      Número de versión de compilación
//      Revisión
//
// Puede especificar todos los valores o puede establecer como valores predeterminados los números de revisión y generación 
// mediante el asterisco ('*'), como se muestra a continuación:
[assembly: ApplicationAccessControl(false,
AccessChecksLevel = AccessChecksLevelOption.ApplicationComponent,
Authentication = AuthenticationOption.Packet,
ImpersonationLevel = ImpersonationLevelOption.Impersonate)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: ApplicationActivation(ActivationOption.Library)]
[assembly: Description("Acceso al Negocio")]
[assembly: ApplicationName("SAE.BusinessLayer")]
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyName("SAE.snk")]
