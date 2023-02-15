using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SAE.BusinessLayer;
using SAE.EntityLayer.Collections;
using SAE.Nullables;
using SAE.UInterfaces;
using SAE.EntityLayer;

public partial class UserControl_CuwFiltroPerfilUsuario : System.Web.UI.UserControl
{
   
   #region  Propiedades

    public event EventHandler UbicacionSelectedIndexChanged;
    public event EventHandler OficinaSelectedIndexChanged;
    public event EventHandler UnidadSelectedIndexChanged;    
    public event EventHandler ModuloSelectedIndexChanged;
    public event EventHandler PerfilSelectedIndexChanged;
    private const string K_MSG_ERROR_ADD_ITEM = "add item ddl.Perfil";
    private const string K_SELECCIONE_TEXT = "<Seleccione>";
    private Int32 codigoUnidadSel=0 ;        

    public DropDownList ddl_Unidad
    {

        get
        {
            return ddlUnidad;
        }
        set
        {
            ddlUnidad = value;
        }
    }
    public DropDownList ddl_Ubicacion
    {

        get
        {
            return ddlUbicacion;
        }
        set
        {
            ddlUbicacion = value;
        }
    }
    public DropDownList ddl_Perfil
    {

        get
        {
            return ddlPerfil;
        }
        set
        {
            ddlPerfil = value;
        }
    }
    public DropDownList ddl_Oficina
    {

        get
        {
            return ddlOficina;
        }
        set
        {
            ddlOficina = value;
        }
    }
    public DropDownList ddl_Modulo
    {

        get
        {
            return ddlModulo;
        }
        set
        {
            ddlModulo = value;
        }
    }
    public Int32 CodigoUnidadSel
    {
        get
        {
            return codigoUnidadSel;
        }
        set
        {
            codigoUnidadSel = value;
        }
    }

   #endregion

   #region Inicio
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))
        {
            lblPerfil.Text = "Perfil";
            lblUbicacion.Text = "Ubicación";
            
            //lblUnidad.Text = "Unidad";
            
            lblUnidad.Visible = false;
            ddlUnidad.Visible = false; 
            InicializarCombos();
        }
    }

    #endregion

   #region Eventos

    public void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        ddlPerfil.Items.Clear();
        ddlOficina.Items.Clear();
        ddlUnidad.Items.Clear();
        ddlModulo.Items.Clear();

        addItemSeleccione(ddlOficina);
        addItemSeleccione(ddlPerfil);
        addItemSeleccione(ddlUnidad);
        addItemSeleccione(ddlModulo);

        CargarMisiones(-1);
        if (UbicacionSelectedIndexChanged != null) UbicacionSelectedIndexChanged(this, e);
      
    }
    protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPerfil.Items.Clear();
            ddlModulo.Items.Clear();
            addItemSeleccione(ddlPerfil);
            addItemSeleccione(ddlModulo);

            CargarUnidad(-1);
            CargarModulo(-1);//nuevo 24092010
            if (OficinaSelectedIndexChanged != null) OficinaSelectedIndexChanged(this, e);
        }
        catch (Exception ex)
        {

            MsgError(ex, "Cargar Unidad ");

        }
    }
    protected void ddlUnidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPerfil.Items.Clear();
            ddlModulo.Items.Clear();
            addItemSeleccione(ddlPerfil);
            addItemSeleccione(ddlModulo);
            CargarModulo(-1);
            if (UnidadSelectedIndexChanged != null) UnidadSelectedIndexChanged(this, e);
          
        }
        catch (Exception ex)
        {

            MsgError(ex, "Cargar Modulo");

        }
    }
    protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPerfil.Items.Clear();
            CargarPerfil(-1);

            if (ModuloSelectedIndexChanged != null) ModuloSelectedIndexChanged(this, e);
            
        }
        catch (Exception ex)
        {
            MsgError(ex, "Cargar Perfil");
        }
    }
    protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PerfilSelectedIndexChanged != null) PerfilSelectedIndexChanged(this, e);
    }
    
    #endregion

   #region Procedimientos y Funciones

    public void ListadoUbicacion(Int32 intCodigoUbicacion)
    {

        ddlPerfil.Items.Clear();
        ddlOficina.Items.Clear();
        ddlUnidad.Items.Clear();
        ddlModulo.Items.Clear();

        addItemSeleccione(ddlOficina);
        addItemSeleccione(ddlPerfil);
        addItemSeleccione(ddlUnidad);
        addItemSeleccione(ddlModulo);

        this.CargarUbicacion(intCodigoUbicacion);

    }
    public void ListadoOficinas(Int32 intCodigoOficina)
    {
      
            ddlPerfil.Items.Clear();
            ddlOficina.Items.Clear();
            ddlUnidad.Items.Clear();
            ddlModulo.Items.Clear();

            addItemSeleccione(ddlPerfil);
            addItemSeleccione(ddlUnidad);
            addItemSeleccione(ddlModulo);

            CargarMisiones(intCodigoOficina);
     
    }
    public void ListadoUnidad(Int32 intCodigoUnidad)
    {

        ddlPerfil.Items.Clear();
        ddlUnidad.Items.Clear();
        ddlModulo.Items.Clear();
        addItemSeleccione(ddlPerfil);
        addItemSeleccione(ddlModulo);

        CargarUnidad(intCodigoUnidad);

    }
    public void ListadoModulo(Int32 intCodigoModulo)
    {
        ddlPerfil.Items.Clear();
        ddlModulo.Items.Clear();
        addItemSeleccione(ddlPerfil);
        addItemSeleccione(ddlModulo);
        CargarModulo(intCodigoModulo);
    }
    public void ListadoPerfil(Int32 intCodigoPerfil)
    {
        ddlPerfil.Items.Clear();
        CargarPerfil(intCodigoPerfil);
    }

    void CargarUbicacion(Int32 intCodigoUbicacionSel)
    {
             BParametro objBParam=null;
             UIPage objUIPage = null;
             EParametro objParam = null;
             try
             {
                 objBParam = new BParametro();
                   objUIPage = new UIPage();
                 IEParametroCollection objColeccion;
                 objBParam.Constructor(objUIPage.Conexion);

                   objParam = new EParametro();
                   objParam.CodigoTabla = NullInt32.Create(UIConstantes.PARAMETROS.TABLA_UBICACION);
                   objParam.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);


                 objColeccion = objBParam.ListarParametros(objParam,"");
                 UIPage.Bind(ddlUbicacion, objColeccion.Valores, "CodigoParametro", "Descripcion");
                 addItemSeleccione(ddlUbicacion);
                 setValueDDL(ddlUbicacion, intCodigoUbicacionSel);
                 
             }
             catch (Exception ex)
             {
                 MsgError(ex,"Cargar Ubicacion");
             }
            finally
            {
               objBParam = null;
               objUIPage = null;
               objParam = null;
            }

    }
    void CargarMisiones(Int32 intCodigoOficina)
    {

        BOficina objBMision = null;
        try
        {


            IEOficinaCollection objMisiones;

            objBMision = new BOficina();

            objBMision.Constructor(new UIPage().Conexion);

            objMisiones = objBMision.ListarOficina(NullInt32.Empty, NullInt32.Create(ddlUbicacion.SelectedValue));
            UIPage.Bind(ddlOficina, objMisiones.Valores, "CodigoOficina", "NombreOficina");
            addItemSeleccione(ddlOficina);
            setValueDDL(ddlOficina, intCodigoOficina);
        }
        catch (Exception ex)
        {
            MsgError(ex, "Cargar Oficina");
        }
        finally
        {

            objBMision = null;

        }

    }
    void CargarUnidad(Int32 intCodigoUnidad)
    {
        BUnidad objBUni = null;
        UIPage objUIPage = null;
        EUnidad oUnidad = null;

        try
        {
            objBUni = new BUnidad();
            objUIPage = new UIPage();
            oUnidad = new EUnidad();


            IEUnidadCollection objColeccion;

            objBUni.Constructor(objUIPage.Conexion);
            oUnidad.CodigoParamUbicacion = NullInt32.Create(ddlUbicacion.SelectedValue);
            oUnidad.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);
            objColeccion = objBUni.ListarUnidad(oUnidad);

            UIPage.Bind(ddlUnidad, objColeccion.Valores, "CodigoUnidad", "NombreUnidad");
            addItemSeleccione(ddlUnidad);
            setValueDDL(ddlUnidad, intCodigoUnidad);
        }
        catch (Exception ex)
        {
            MsgError(ex, "Cargar Unidad: ");
        }
        finally
        {
            objBUni = null;
            objUIPage = null;
            oUnidad = null;
        }
    }
    void CargarModulo(Int32 intCodigoModulo)
    {

        IBModulo objBModulo = null;
        try
        {


            IEModuloCollection objBModulos;

            objBModulo = new BModulo();

            objBModulo.Constructor(new UIPage().Conexion);

            objBModulos = objBModulo.ListarModulo(NullInt32.Create(Convert.ToInt32(WebConfigurationManager.AppSettings["IdSistema"])), UIConstantes.Situacion.Activo);
            UIPage.Bind(ddlModulo, objBModulos.Valores, "CodigoModulo", "Nombre");
            addItemSeleccione(ddlModulo);
            setValueDDL(ddlModulo, intCodigoModulo);


        }
        catch (Exception ex)
        {
            MsgError(ex, "Cargar Modulo");
        }
        finally
        {

            objBModulo = null;

        }

    }
    void CargarPerfil(Int32 intCodigoPerfil)
        {

            BPerfil objBParam = null;
            UIPage objUIPage = null;

            try
            {
                objBParam = new BPerfil();
                objUIPage = new UIPage();
                IEPerfilCollection objColeccion;
                objBParam.Constructor(objUIPage.Conexion);

                objColeccion = objBParam.ListarPerfilPorUbicacionModulo(NullInt32.Create(ddlUbicacion.SelectedValue), NullInt32.Create(ddlUnidad.SelectedValue), NullString.Create(UIConstantes.Situacion.Activo), NullInt32.Create(ddlModulo.SelectedValue));


                UIPage.Bind(ddlPerfil, objColeccion.Valores, "CodigoPerfil", "NombrePerfil");
                addItemSeleccione(ddlPerfil);
                setValueDDL(ddlPerfil, intCodigoPerfil);

            }
            catch (Exception ex)
            {
                MsgError(ex, "Cargar Perfil");
            }
            finally
            {
                objBParam = null;
                objUIPage = null;

            }

        }
    void MsgError(Exception ex, String Titulo)
     {
       
         CScript.MessageBox(0, ex.Message, upFiltroPerfilUsuario);
     }

    public void addItemSeleccione(DropDownList obj)
     {
         try
         {
             obj.Items.Insert(0, new ListItem(K_SELECCIONE_TEXT, "-1"));
         }
         catch (Exception ex)
         {
             MsgError(ex, K_MSG_ERROR_ADD_ITEM);
         }
     }
    void setValueDDL( DropDownList obj,Int32 codigoSel)
    {
        if (obj.Items.FindByValue(codigoSel.ToString()) != null) obj.Items.FindByValue(codigoSel.ToString()).Selected = true;
    }
    public void  SettingPerfil(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad,NullInt32 pintCodigoMision,NullInt32 pintCodigoPerfil)
    {
       try
       {
        if (ddlUbicacion.Items.FindByValue(pintCodigoUbicacion.UINullable) != null)
        {
            ddlUbicacion.ClearSelection();
            ddlUbicacion.Items.FindByValue(pintCodigoUbicacion.UINullable).Selected = true;
            CargarUnidad(-1);
            if (ddlUnidad.Items.FindByValue(pintCodigoUnidad.UINullable) != null)
            {
                ddlUnidad.ClearSelection();
                ddlUnidad.Items.FindByValue(pintCodigoUnidad.UINullable).Selected = true;
                CargarPerfil(-1);
                ddlPerfil.ClearSelection();
                if (!(ddlPerfil.Items.FindByValue(pintCodigoPerfil.UINullable).Equals(null)))
                   ddlPerfil.Items.FindByValue(pintCodigoPerfil.UINullable).Selected = true; 
            }
        }
    } catch (Exception ex)
        {
            MsgError(ex, "Setting perfiles");
        }

    }
    public void InicializarCombos()
    {
       
        CargarUbicacion(-1);

        ddlUnidad.Items.Clear();
        ddlOficina.Items.Clear();
        ddlPerfil.Items.Clear();
        ddlModulo.Items.Clear();  

        addItemSeleccione(ddlUnidad);
        addItemSeleccione(ddlOficina);
        addItemSeleccione(ddlPerfil);
        addItemSeleccione(ddlModulo);
        

        

    }
    public void Enabled(Boolean valor)
    {

     ddlUbicacion.Enabled = valor;            
     ddlOficina.Enabled = valor;
     ddlUnidad.Enabled = valor;
     ddlModulo.Enabled = valor;
     ddlPerfil.Enabled = valor;
        
    }

  
    #endregion

}
