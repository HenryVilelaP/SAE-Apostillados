using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SAE.BusinessLayer;
using SAE.EntityLayer.Collections;
using SAE.EntityLayer;
using SAE.Nullables;
using SAE.UInterfaces;


public partial class CuwMenu : System.Web.UI.UserControl
{

    #region  Propiedades y Constantes
    
    MenuItem varmenu = null; 
    MenuItem mhijo = null;
    private const string K_RUTA_DEFAULT = "RutaDefault";
    private const string K_SESION_ID_PERFIL = "_IdPerfilActual";
    private const string K_SESSION_ID_PERFIL_USUARIO_OFICINA = "_IDPerfilUsuarioOficina";

    #endregion

     
    public void cargarMenu(IEOpcionCollection objOpcions, Int32 pintModulo)
    {
        mnuPrincipal.Items.Clear();
        int intPerfil = 0;
        NullInt32 intPerfilUsuOfic = NullInt32.Empty ;

        if (Session["IdModuloSel"] != null)
        {
            if (Request.QueryString["pstrPerfil"] != null) Session[K_SESION_ID_PERFIL] = Request.QueryString["pstrPerfil"];
            if (Request.QueryString["pstrCodPerfilUsuOfic"] != null) Session[K_SESSION_ID_PERFIL_USUARIO_OFICINA] = Request.QueryString["pstrCodPerfilUsuOfic"];

            objOpcions = null;
            BOpcion objOpcion = new BOpcion();
            objOpcion.Constructor(new UIPage().Conexion);
            objOpcions = new EOpcionCollection();

            intPerfil = Convert.ToInt16(Session[K_SESION_ID_PERFIL]);
            intPerfilUsuOfic = NullInt32.Create(Convert.ToInt32(Session[K_SESSION_ID_PERFIL_USUARIO_OFICINA]));
            objOpcions = objOpcion.ListarOpcionPerfil(NullInt32.Create(intPerfil), pintModulo, intPerfilUsuOfic);
            foreach (IEOpcion _objOpcion in objOpcions.Valores)
            {
                if (_objOpcion.CodigoOpcionPadre.Value == 0)
                {
                    varmenu = new MenuItem();
                    varmenu.Text = _objOpcion.Nombre.UINullable;
                    varmenu.Value = _objOpcion.CodigoOpcion.UINullable;
                    varmenu.NavigateUrl = _objOpcion.Ruta.UINullable;
                    mnuPrincipal.Items.Add(varmenu);
                    if (!cargarMenuHijo(objOpcions)) mnuPrincipal.Items.Remove(varmenu);
                }
            }
            //carga el switch de perfil en caso tenga mas de un perfil para el Modulo seleccionado
            IEUsuario objUsuario = (IEUsuario)Session["Usuario"];
            IBPerfilUsuario objBPUsu = new BPerfilUsuario();
            IEPerfilUsuarioCollection objCollectionPerfilUsu = new EPerfilUsuarioCollection();
            objBPUsu.Constructor (new UIPage().Conexion );

            objCollectionPerfilUsu = objBPUsu.ListarPerfilUsuarioXModulo(objUsuario.Codigo.Value, UIConstantes.Situacion.Activo, pintModulo);
            if (objCollectionPerfilUsu.Count > 0) FP_AddPerfilSwitch(objCollectionPerfilUsu);
        }
    }

 
    void FP_AddPerfilSwitch( IEPerfilUsuarioCollection colPerfiles) {

                 varmenu = new MenuItem();
                 varmenu.Text = "Perfil";
                 varmenu.Value = "999";
                 varmenu.NavigateUrl = "";

                 mnuPrincipal.Items.Add(varmenu);
                                        
          foreach(EPerfilUsuario oPerfil in colPerfiles.Valores )
             {
                 mhijo = new MenuItem();
                 mhijo.Text = "   " + oPerfil.NombrePerfil.UINullable;
                 mhijo.Value = oPerfil.CodigoPerfil.UINullable ;
                 mhijo.NavigateUrl = Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings[K_RUTA_DEFAULT] + "?pstrPerfil=" + oPerfil.CodigoPerfil.UINullable + "&pstrCodPerfilUsuOfic=" + oPerfil.CodigoPerfilUsuarioOfi.UINullable ;
                 mhijo.ImageUrl = "~/images/iconos/icon-16-config.png";
                 mhijo.ToolTip = "cambiar perfil";
                 varmenu.ChildItems.Add(mhijo);
              
             }
    }

     
     protected bool cargarMenuHijo(IEOpcionCollection objOpcions)
     {
         Int32 num_hijos_econtrados = 0;
         foreach (IEOpcion objOpcion in objOpcions.Valores )
         {
             if (varmenu.Value == objOpcion.CodigoOpcionPadre.UINullable)
             {      
                 if (objOpcion.TipoAcceso.UINullable != SAE.UInterfaces.UIConstantes.TIPO_ACCESO_OPCION.NONE)
                 {
                     mhijo = new MenuItem();
                     mhijo.Text = "   " + objOpcion.Nombre.UINullable;
                     mhijo.Value = objOpcion.CodigoOpcion.UINullable;
                     mhijo.NavigateUrl = Request.ApplicationPath + objOpcion.Ruta.UINullable;
                     mhijo.ImageUrl = "~/images/iconos/app.gif";
                     varmenu.ChildItems.Add(mhijo);
                     num_hijos_econtrados++;
                 }
             }
         }
         if (num_hijos_econtrados == 0) return false;
         else return true;

     }
    
}
