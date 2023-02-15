using System;
using System.Threading ;
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
using System.DirectoryServices;
using SAE.BusinessLayer;
using SAE.UInterfaces;
using SAE.EntityLayer.Collections ;
using SAE.EntityLayer;

using SAE.Nullables;



public partial class UserControl_CuwLogin : System.Web.UI.UserControl
{
    

#region Propiedades ,Atributos y Constantes


    private const string K_MSG_USUARIO_BLOQUEADO = "Usuario bloqueado,comuníquese con el administrador.";
    private const string K_USUARIO_NO_EXISTE = "Error : No existe usuario registrado en el SAE.";
    private const string K_NOMBRE_USUARIO = "NombreUsuario";
    private const string K_USUARIO = "Usuario";
    private const string K_MAIL_TEXT = "mail";
    private const string K_RUTA_DEFAULT = "RutaDefault";
    private const string K_MSG_USARIO_CLAVE_INCORRECTO = "Error : No existe usuario y dominio registrado en el SAE.";
    private const string K_ICONO_WARNING = "<img src='../../Images/Iconos/warning.png' />";
    private const string K_ERROR_AUTENTIFICACION_ACTIVE = "Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta. ";
    private const string K_BARRAS = "\\";
    private const string K_LOGON_USER_TEXT = "LOGON_USER";
    private const string K_CODIGO_AUDITOR = "_CodigoAuditor";


    public String EtiquetaNombreUsuario
    {
        get {

            return this.lblNombreUsuario.Text ; 
        }
        set
        {

            this.lblNombreUsuario.Text = value;
        }
    }
    public String EtiquertaPassword
    {
        get
        {

            return this.lblPassword.Text ;
        }
        set
        {
             this.lblPassword.Text=value;
        }
    }
    public String NombreUsuario
    {
        get
        {

            return this.txtUsuario.Text ;
        }
        set
        {
            this.txtUsuario.Text = value; 
        }
    }
    public String Password
    {
        get
        {

            return this.txtPassword.Text ; 
        }
        set
        {
            this.txtPassword.Text = value; 
        }
    }
    public String  MensajeLogin
    {
        get
        {

            return this.lblMensajeErrorLogin.Text  ;
        }
        set
        {
            this.lblMensajeErrorLogin.Text = value;
        }
    }






#endregion

    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnAceptar.Click += new ImageClickEventHandler(btnAceptar_Click);
            if (!(Page.IsPostBack)){

                this.txtUsuario.Text = Request.ServerVariables[K_LOGON_USER_TEXT];
                this.txtUsuario.ReadOnly = true;
                if (Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["UserLogeoEnabled"]) == 'S'.ToString()) this.txtUsuario.ReadOnly = false;
                
                this.btnAceptar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BIngresar_on.gif',this);");
                this.btnAceptar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BIngresar_off.gif',this);"); 
            }
    }
   

    void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        this.lblMensajeErrorLogin.Text = string.Empty;
        BUsuario objBUsuario = null;
        try
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["TiempoAjax"])); 
            IEUsuario objEUsuario=null;
           
            DirectoryEntry objUser = null;
             
            string strUsuarioNT, strDominio=string.Empty ;
            int intPos = 0;
            intPos= txtUsuario.Text.IndexOf(K_BARRAS);
            if (intPos > 0) intPos++;
            strUsuarioNT = txtUsuario.Text.Substring(intPos, txtUsuario.Text.Length - intPos);
            strDominio = txtUsuario.Text.Substring(0, intPos-1);
            
            objUser = this.ActiveDirectoryValidator(strUsuarioNT, this.txtPassword.Text);

            objBUsuario = new BUsuario();
            objBUsuario.Constructor(new SAE.UInterfaces.UIPage().Conexion );
            objEUsuario= objBUsuario.ObtenerUsuarioLoginNT( strUsuarioNT,strDominio,UIConstantes.Situacion.Activo);
             if (objEUsuario != null)
             {
                  
                 if (objEUsuario.SituacionRegistro.UINullable.Equals(UIConstantes.Situacion.Bloqueado))
                     throw new Exception(K_MSG_USUARIO_BLOQUEADO);
                 if (objEUsuario.SituacionRegistro.UINullable.Equals(UIConstantes.Situacion.Inactivo))
                     throw new Exception(K_USUARIO_NO_EXISTE);

                 Session.Add(K_NOMBRE_USUARIO, objUser.Username);
                 objEUsuario.Correo = NullString.Create (objUser.Properties[K_MAIL_TEXT].Value.ToString());
                 Session.Add(K_USUARIO, objEUsuario);

                 var rutaInicial = (string)Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings[K_RUTA_DEFAULT];
                 Response.Redirect(rutaInicial);  
             }
             else
             {
                 throw new Exception(K_MSG_USARIO_CLAVE_INCORRECTO);
             }

        }
        catch (Exception ex)
        {
            //this.lblMensajeErrorLogin.Text = ex.Message + K_ICONO_WARNING;  
            CScript.MessageBox(0, ex.Message, UpdatePanel1);
        }
         

       
    }

      
       DirectoryEntry ActiveDirectoryValidator(String  txtUser   ,  String txtpwd  ) {

        DirectoryEntry objUser =null;
        try
        {

            

            String strProtocolo = System.Web.Configuration.WebConfigurationManager.AppSettings["ProtocoloAcceso"];
            String strNombreDominioInferior = System.Web.Configuration.WebConfigurationManager.AppSettings["NombreDominioInferior"];
            String strDominioSuperiorA = System.Web.Configuration.WebConfigurationManager.AppSettings["DominioSuperiorA"];
            String strDominioSuperiorB = System.Web.Configuration.WebConfigurationManager.AppSettings["DominioSuperiorB"];
            String strDominioCompleto = strNombreDominioInferior + "." + strDominioSuperiorA + "." + strDominioSuperiorB;

            String strDominio = strProtocolo + "://" + strDominioCompleto + "/DC=" + strNombreDominioInferior + ", DC=" + strDominioSuperiorA + ", DC=" + strDominioSuperiorB;
            DirectoryEntry objDirectoryEntry = new DirectoryEntry(strDominio, txtUser, txtpwd, AuthenticationTypes.Secure);

            DirectorySearcher objDirectorySearcher = new DirectorySearcher(objDirectoryEntry);
            SearchResult objSearchResult;
            objDirectorySearcher.Filter = "(SAMAccountName=" + txtUser + ")";
            objSearchResult = objDirectorySearcher.FindOne();

            if (objSearchResult != null)
            { objUser = objSearchResult.GetDirectoryEntry(); }
            else
            {
                throw new Exception(K_ERROR_AUTENTIFICACION_ACTIVE); 

            }

            return objUser;
        }                                                 
        catch(Exception ex)
            {
                        throw ex;
            }
      
        }
}
