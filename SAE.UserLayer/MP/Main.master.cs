using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAE.UInterfaces ;
using SAE.BusinessLayer;
using SAE.EntityLayer;
using SAE.EntityLayer.Collections ;
using SAE.Nullables;


public partial class MP_Main : System.Web.UI.MasterPage
{
    private const string K_SESION_ID_OFICINA = "_IdOficinaActual";
    private const string K_SESION_ID_PERFIL = "_IdPerfilActual";
    private const string K_SESSION_ID_PERFIL_USUARIO_OFICINA = "_IDPerfilUsuarioOficina";
    private const string K_SESSION_ID_UNIDAD = "_IdUnidadActual";
    private const string K_SESSION_ID_UBICACION = "_IdUbicacionOficina";
    private const string K_IMAGEN_ICONO_MODULO = "/Images/Iconos/bullet03.gif";

#region Propiedades

     
#endregion
       
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        try
        {
            ValidarSesion();
        }catch (Exception ex){
            CScript.MessageBox(0, ex.Message);   
        }
        int pintModulo = 0;
        IEUsuario obUsuario = null;

       try
        {
            //obUsuario = (IEUsuario)Session["Usuario"];
            //(obUsuario.Codigo.Value);
            //if (Session["NombreModuloSel"] != null)
            //{
            //    lblModulo.Text = (string)Session["NombreModuloSel"];
            //    imgModulo.Src = Request.ApplicationPath + K_IMAGEN_ICONO_MODULO;
            //    imgModulo.Visible = true;
            //    pintModulo = Convert.ToInt32((string)Session["IdModuloSel"]);
            //}
           pintModulo = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["ModuloDefatult"]);
           Session["IdModuloSel"] = pintModulo;
           Session["NombreModuloSel"] = "Apostillas";
         
           

           if (!IsPostBack)
            {
              
                HtmlGenericControl Include = new HtmlGenericControl("script");
                String _url = string.Empty;

                Include.Attributes.Add("type", "text/javascript");
                Include.Attributes.Add("type", "text/css");
                Include.Attributes.Add("src", Request.ApplicationPath + "/Scripts/common.js");
                Include.Attributes.Add("src", Request.ApplicationPath + "/App_Themes/Default.css");
                this.Page.Header.Controls.Add(Include);

                imgLogo.Src = Request.ApplicationPath + "/Images/Logos/rree_membrete.gif";
                imgLogo.Visible = true;
                
                obUsuario = (IEUsuario)Session["Usuario"];

                if (obUsuario.Opcions != null)
                {
                  
                    if (Request.QueryString["pstrPerfil"] != null) Session[K_SESION_ID_PERFIL] = Request.QueryString["pstrPerfil"];

                    #region SI Tiene varios o solo un perfil
                    if (Session[K_SESION_ID_PERFIL] != null)
                    {
                        foreach (EPerfilUsuario oEperfil in obUsuario.Perfiles.Valores)
                        {
                            if (oEperfil.CodigoPerfil.Equals(NullInt32.Create(Session[K_SESION_ID_PERFIL].ToString())))
                                InicializarSesionUsuario(oEperfil);
                        }
                    }
                    else
                    {
                        EPerfilUsuario oEperfil = (EPerfilUsuario)obUsuario.Perfiles.Valores[0];
                        InicializarSesionUsuario(oEperfil);
                    }
                    #endregion

                    IEOpcionCollection objOpcions;
                    objOpcions = (IEOpcionCollection)obUsuario.Opcions;
                    CuwMenuPrincipal.cargarMenu(objOpcions, pintModulo);
                    lblUsuario.Text = obUsuario.NombreCompleto.UINullable;
                }
                else
                {
                    _url = Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings["RutaLogin"];
                    Response.Redirect(_url);
                }
            }
            else
            {
                IEUsuario _obUsuario = (IEUsuario)Session["Usuario"];
                if (_obUsuario.Opcions != null)
                {
                    IEOpcionCollection objOpcions;
                    objOpcions = (IEOpcionCollection)_obUsuario.Opcions;
                    CuwMenuPrincipal.cargarMenu(objOpcions, pintModulo);
                }
            }

           

        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);   
        }
        
    }
    //void ListarModulo(Int32 pintCodigoUsu)
    //{

    //    BModulo objModulo = new BModulo();
    //    IEModuloCollection modulos = null;

    //    objModulo.Constructor(new UIPage().Conexion);
    //    modulos = objModulo.ListarModuloXUsuario(pintCodigoUsu, UIConstantes.Situacion.Activo);


    //    foreach (EModulo emodulo in modulos.Valores )
    //    {
    //                    Image img=new Image ();            
    //                    LinkButton btnlnk = new LinkButton();
    //                    btnlnk.CssClass = "enlaceboton";
    //                    btnlnk.ID = emodulo.CodigoModulo.UINullable;
    //                    btnlnk.Text = emodulo.Nombre.UINullable.ToUpper() + "&nbsp;&nbsp;&nbsp;&nbsp;";
    //                    btnlnk.ToolTip = "ir al módulo "  +emodulo.Nombre.UINullable;
    //                    btnlnk.Click  += new EventHandler(btn_Click);
    //                    img.ImageUrl = Request.ApplicationPath + K_IMAGEN_ICONO_MODULO;
    //                    img.ID = "img" + emodulo.CodigoModulo.UINullable;
    //                    btnlnk.PostBackUrl = Request.ApplicationPath + "/Pages/Default.aspx";


    //                    phModulo.Controls.Add(img);
    //                    phModulo.Controls.Add(btnlnk);  
    //    }

    //}



    void btn_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton btn = (LinkButton)sender;
            UIPage objPage = new UIPage();
            Session["IdModuloSel"] = btn.ID.ToString();
            Session["NombreModuloSel"] = btn.Text.ToString();
            Session["_idPerfilActual"] = -1;

            lblModulo.Text = btn.Text;
            imgModulo.Visible = true;
           
            imgModulo.Src = Request.ApplicationPath + K_IMAGEN_ICONO_MODULO;

            int pintModuloDefatult = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["ModuloDefatult"]);     
            IEUsuario obUsuario = (IEUsuario)Session["Usuario"];
            if (obUsuario.Opcions != null)
            {

                IEOpcionCollection objOpcions;
                objOpcions = (IEOpcionCollection)obUsuario.Opcions;
                CuwMenuPrincipal.cargarMenu(objOpcions, Convert.ToInt32(btn.ID));
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void InicializarSesionUsuario(EPerfilUsuario oEperfil)
    {
        try
        {
            lblPerfil.Text = oEperfil.NombrePerfil.UINullable;
            lblOficina.Text = oEperfil.NombreOficina.UINullable;
            Session.Add(K_SESSION_ID_PERFIL_USUARIO_OFICINA, oEperfil.CodigoPerfilUsuarioOfi.UINullable);
            Session.Add(K_SESION_ID_PERFIL, oEperfil.CodigoPerfil.UINullable);
            Session.Add(K_SESION_ID_OFICINA, oEperfil.CodigoOficina.UINullable);
            //Session.Add(K_SESSION_ID_UNIDAD, oEperfil.CodigoUnidad.UINullable);
            Session.Add(K_SESSION_ID_UBICACION, oEperfil.CodigoUbicacion.UINullable);
            
            
        }
        catch(Exception ex)
        {
            CScript.MessageBox (0,ex.Message); 
        }
    }

 

    protected void imgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect(HttpContext.Current.Request.ApplicationPath + "/Pages/Login/frmLogin.aspx");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);   
        }
        
    }

    protected void ValidarSesion()
    {
         String _url   = Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings["RutaLogin"];
        try
        {                           
            if( Session["Usuario"]==null){
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect(_url,false);
            }
        
        }
        catch(  System.NullReferenceException ex ){
                if( Context.Session.Equals (null)){
                    Response.Redirect(_url,false)       ;
                }else{                                 
                        throw ex;
                }
        }
        catch ( Exception ex){
            throw ex;
        }
    }
        
}
