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
using SAE.UInterfaces;
using SAE.BusinessLayer;
using SAE.EntityLayer ;
using SAE.EntityLayer.Collections;
using SAE.Nullables;
using System.Text;
public partial class  FrmUsuario : UIPage
{

    #region Propiedades , Constantes


    private const string K_CSS_ERROR = "msg_error";
    private const string K_CSS_OK = "msg_ok";
    private const string K_MSG_ELIMINACION_OK = "Eliminado correctamente ";
    private const string K_SELECCIONE_USUARIOS = " Seleccione usuarios para eliminar.";
    private const string K_MSG_SIN_RESULTADOS_BUSQUEDA = " No se encontraron resultados en la búsqueda. ";
    private const string K_ITEM_TODOS = "<Todos>";
    private const string K_MSG_ACTUALIZACION_OK = "Actualizado correctamente";
    private const string K_MSG_REGISTRO_OK = "Registrado correctamente";
    private const string K_MSG_OPERACION_ERROR = "Operacion incorrecta";
    private const string K_MSG_VALIDACION_FORMULARIO = "   * Campos obligatorios<br>   [*] Formato incorrecto   ";
    private const string K_CTRL_CHKUSUARIO_GRILLA = "chkUsuario";
    private const string K_MSG_ELIMINACION = "¿Desea eliminar el registro?";
    private const string K_CMD_ELIMINAR = "cmdEliminar";
    private const string K_MSG_TITULO_MODIFICAR_USUARIO = "Modificar Usuario";
    private const string K_CMD_EDITAR = "cmdEditar";
    private const string K_MSG_NUM_REGISTRO_HALLADOS = " Número de registros encontrados :";
    private const string K_MSG_TITULO_NUEVO_USUARIO = "Registrar Nuevo Usuario";
    private const string K_MSG_ERROR_CARGAR_USUARIO = "Error al listar usuario : ";
    private const string K_CLAVE = "key";
    private const string K_JS_ALERTA = "alert('{0}');";
    private const string K_CARACTER_COMODIN = "'";
    private const string K_ERROR_CARGAR_MISION = "Cargar Oficinas : ";
    private NullInt32 CodigoEliminar
    {
        get
        {
            return (NullInt32)ViewState["_CodigoEliminar"];
        }
        set
        {
            ViewState["_CodigoEliminar"] = value;
        }
    }
    private NullInt32 CodigoEdicion
    {
        get
        {
            return (NullInt32)ViewState["_CodigoEdicion"];
        }
        set
        {
            ViewState["_CodigoEdicion"] = value;
        }
    }


    #endregion

    
    #region Inicio
  
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        try
        {
            if (!(Page.IsPostBack))
            {

                Inicializar();
                
                //imgBtnSelAll.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bseleccionar_on.gif',this);");
                //imgBtnSelAll.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bseleccionar_off.gif',this);");
                imgBtnNuevo.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bnuevo_on.gif',this);");
                imgBtnNuevo.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bnuevo_off.gif',this);");
                //imgBtnEliminar.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Beliminar_on.gif',this);");
                //imgBtnEliminar.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Beliminar_off.gif',this);");
                txtNumDocumento.Attributes.Add("onkeypress", "return solonumeros(event);");
              

                _FillSituacionDll(ddlSituacion);
                _FillSituacionDll(ddlSituacionNuevo);

                if (ddlSituacionNuevo.Items.FindByValue(UIConstantes.Situacion.Todos) != null) ddlSituacionNuevo.Items.Remove(ddlSituacionNuevo.Items.FindByValue(UIConstantes.Situacion.Todos));
                if (ddlSituacionNuevo.Items.FindByValue(UIConstantes.Situacion.Activo) != null) ddlSituacionNuevo.Items.FindByValue(UIConstantes.Situacion.Activo).Selected = true;

                pnModalPopupNuevo.Load += new EventHandler(pnModalPopupNuevo_Load);
 
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    
        
    }
    public void _FillSituacionDll(DropDownList control){

        try
        {  
            control.Items.Add(new ListItem("<Todos>", UIConstantes.Situacion.Todos));
            control.Items.Add(new ListItem("Activo", UIConstantes.Situacion.Activo));
            control.Items.Add(new ListItem("Bloqueado", UIConstantes.Situacion.Bloqueado));
            control.Items.Add(new ListItem("Inactivo", UIConstantes.Situacion.Inactivo));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    protected void gvResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEdicion=(ImageButton )e.Row.FindControl("ImgEdit");
            ImageButton botonDel = (ImageButton)e.Row.FindControl("ImgDelete");
               
            btnEdicion.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_edit_on.gif',this);");
            btnEdicion.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_edit.gif',this);");

            botonDel.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_delete_on.gif',this);");
            botonDel.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_delete.gif',this);");
        } 
    }
   
    #endregion
                 
 
    #region Eventos

    protected void pnModalPopupNuevo_Load(object sender, EventArgs e)
    {
        lblTituloNuevoEdit.Text = OperacionActual == Operacion.Insertar ? K_MSG_TITULO_NUEVO_USUARIO : K_MSG_TITULO_MODIFICAR_USUARIO;
    }

    protected void BuscarPersona(object sender, ImageClickEventArgs e)
    {
        BPersona objPersona = null;
        try
        {
            IEPersona objEPersona = null;
            objPersona = new BPersona();
            objPersona.Constructor(Conexion);

            ValidarExistenciaUsuario();
            objEPersona = objPersona.ListarPersonaPorDocumento(Convert.ToInt32(ddlTipoDoc.SelectedItem.Value), Convert.ToInt32(txtNumDocumento.Text));

            if (objEPersona == null) throw new Exception("No existe registro del documento ingresado. Ingrese Datos del nuevo usuario.");
            txtApeMaterno.Text = objEPersona.ApellidoMaterno.UINullable;
            txtApePaterno.Text = objEPersona.ApellidoPaterno.UINullable;
            txtNombre.Text = objEPersona.Nombres.UINullable;
            txtFechaNac.Text = objEPersona.FechaNacimineto.Value.ToShortDateString();

            if (ddlPais.Items.FindByValue(objEPersona.CodigoPaisNacimineto.UINullable) != null)
            {
                ddlPais.ClearSelection();
                ddlPais.Items.FindByValue(objEPersona.CodigoPaisNacimineto.UINullable).Selected = true;
            }

        }
        catch (Exception ex)
        {

            CScript.MessageBox(0, ex.Message, upBuscarDNI);
            txtApeMaterno.Text = string.Empty;
            txtApePaterno.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
        finally
        {
            objPersona = null;

        }




    }

    protected void cuwAccion_Close_Click(object sender, EventArgs e)
    {
        try
        {
            lblTituloNuevoEdit.Text = K_MSG_TITULO_NUEVO_USUARIO;
            lblMsgNuevoEdicion.Text = string.Empty;
            NuevoEdicionInicial();
            CargarUsuarios(); 
            upControlGrilla.Update();
            mpeNuevoEdicion.Hide();
         
            cuwAccion.imgGrabar.Enabled = true;
        }
        catch (Exception ex)
        {
            lblMsgNuevoEdicion.CssClass = K_CSS_ERROR;
            lblMsgNuevoEdicion.Text = ex.Message; 
        }
    }

    protected void cuwAccion_Save_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (Page.IsValid.Equals(true))
            {

                                switch(OperacionActual)
                                {
                                    case Operacion.Insertar:
                                        {
                                            
                                            GrabarUsuario();
                                            CScript.MessageBox(0, K_MSG_REGISTRO_OK, upNuevoEdicion);  
                                            NuevoEdicionInicial();
                                            break;
                                        }
                                    case Operacion.Modificar: 
                                        {
                                            GrabarUsuario();
                                            CScript.MessageBox(0, K_MSG_ACTUALIZACION_OK, upNuevoEdicion);  
                                            OperacionActual = Operacion.Insertar; 
                                            break;
                                        }
                                    default: new Exception(K_MSG_OPERACION_ERROR); 
                                            break;
                                }
            }
            else                  
            {
                  throw  new Exception(K_MSG_VALIDACION_FORMULARIO); 
            }
            
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upNuevoEdicion);  
        }
    }

    protected void SelectAllChk_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvResultado.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl(K_CTRL_CHKUSUARIO_GRILLA);
            if (chk != null)
               chk.Checked = chk.Checked.Equals(true) ? false : true;
            
        }
    }

    protected void EditarClick(object sender, EventArgs e)
    {
        try
        {
            ImageButton imgbtn = (ImageButton)sender;
            if (imgbtn.CommandName.Equals(K_CMD_EDITAR))
            {
                NuevoEdicionInicial();
                OperacionActual  = Operacion.Modificar ;
                CodigoEdicion= NullInt32.Create(Convert.ToInt32(imgbtn.CommandArgument));
                lblTituloNuevoEdit.Text = K_MSG_TITULO_MODIFICAR_USUARIO;
                CargarUsuario(CodigoEdicion);
                mpeNuevoEdicion.Show();
            }
        }
        catch (Exception ex)
        {
            cuwConfirmar.MensajeConfirmacionOkText = ex.Message;
        }
    }

    protected void EliminarClick(object sender, EventArgs e)
    {
        try{
            ImageButton imgbtn = (ImageButton)sender;
            if (imgbtn.CommandName.Equals (K_CMD_ELIMINAR)){
                TipoEliminacion = Eliminacion.Unica;
                CodigoEliminar = NullInt32.Create(Convert.ToInt32(imgbtn.CommandArgument));
                cuwConfirmar.PreguntaText = K_MSG_ELIMINACION;
                mpeConfirmacion.Show();
            }              
        }catch (Exception ex){
            cuwConfirmar.MensajeConfirmacionOkText = ex.Message;
        } 
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Boolean exito = false;
        IEUsuario objEUsuario = null;
        IEUsuarioCollection objEUsuarios = null;
        try
        {
            cuwConfirmar.EstiloMensaje = K_CSS_ERROR;
            cuwAlerta.EstiloMensaje = K_CSS_ERROR;
            if( Eliminacion.Unica.Equals(TipoEliminacion)){

                exito = eliminarUsuario(CodigoEliminar.Value);

            }else{

                objEUsuarios = new EUsuarioCollection();
                foreach (GridViewRow row in gvResultado.Rows) {
                    CheckBox chk = (CheckBox)row.FindControl(K_CTRL_CHKUSUARIO_GRILLA);
                    if (chk != null){
                        if (chk.Checked.Equals(true)){
                            objEUsuario = new EUsuario();
                            objEUsuario.Codigo = NullInt32.Create(chk.Text);
                            objEUsuario.UsuarioModifica = NullInt32.Create(varIdCodigoAuditoria);
                            objEUsuarios.Add(objEUsuario.Codigo.UINullable, objEUsuario);
                            objEUsuario = null;
                        }
                    }
                }

                exito = eliminarUsuario(objEUsuarios);
            }
        }
        catch (Exception ex)
        {
            cuwConfirmar.MensajeConfirmacionOkText = ex.Message;
        }
        finally
        {
            if (exito.Equals(true)){
                cuwConfirmar.Visible = false;
                cuwAlerta.Visible = true;
                TipoEliminacion=Eliminacion.Ninguna ;
            }
            objEUsuarios = null;
        }
          
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            cuwConfirmar.MensajeConfirmacionOkText = string.Empty ;
            mpeConfirmacion.Hide();
        }
        catch (Exception ex)
        {
            cuwConfirmar.MensajeConfirmacionOkText = ex.Message;

        }
    }

    protected void cuwBuscarLimpiar_OnBuscarClick(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["TiempoAjax"]));
            CargarUsuarios(); 
        }
        catch (Exception ex)
        {
           CScript.MessageBox(0, ex.Message, upControlGrilla);
        }
    }

    protected void cuwBuscarLimpiar_OnLimpiarClick(object sender, EventArgs e)
    {
        try
        {
            gvResultado.DataSource = null;
            gvResultado.DataBind();
            lblNumeroRegistro.Text = K_MSG_NUM_REGISTRO_HALLADOS + " 0 ";
            txtNombres.Text = string.Empty ;
            ddlOficina.SelectedIndex = 0;
            ddlSituacion.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBusqueda);
        }
    }

    protected void Alerta_Click(object sender, EventArgs e)
    {
        
        try
        {
            cuwConfirmar.Visible = true;
            cuwAlerta.Visible = false;
            cuwConfirmar.MensajeConfirmacionOkText = string.Empty;
            CargarUsuarios();
            upControlGrilla.Update();
            mpeConfirmacion.Hide();
        }
        catch (Exception ex)
        {
            cuwConfirmar.MensajeConfirmacionOkText = ex.Message;
        }
         
    }
           

    #endregion            


    #region Procedimientos y Funciones

    private void Inicializar()
    {
        try
        {
           CargarOficina();
           CargarPais();
           CargarTipoDocumenentos();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void CargarUsuario(NullInt32 codigo) {
        BUsuario objUsuario = null;
        IEUsuario objEusu = null;
        try
        {
            objUsuario = new BUsuario();
            objEusu = new EUsuario();
            objUsuario.Constructor(Conexion);

            objEusu = objUsuario.ObtenerUsuario(codigo);

            txtNombre.Text = objEusu.Nombres.UINullable;
            txtApePaterno.Text = objEusu.ApellidoPaterno.UINullable;
            txtApeMaterno.Text = objEusu.ApellidoMaterno.UINullable;
            txtCorreo.Text = objEusu.Correo.UINullable;
            txtDominio.Text = objEusu.Dominio.UINullable;
            txtUserNT.Text = objEusu.UsuarioRed.UINullable;
            txtFechaNac.Text = objEusu.FechaNacimineto.Value.ToShortDateString() ;
            if (ddlSituacionNuevo.Items.FindByValue(objEusu.SituacionRegistro.UINullable)!=null )
            {
                ddlSituacionNuevo.ClearSelection();
                ddlSituacionNuevo.Items.FindByValue(objEusu.SituacionRegistro.UINullable).Selected = true;
            }
            if (ddlPais.Items.FindByValue(objEusu.CodigoPaisNacimineto.UINullable) != null)
            {
                ddlPais.ClearSelection();
                ddlPais.Items.FindByValue(objEusu.CodigoPaisNacimineto.UINullable).Selected = true;
            }
          
            ddlTipoDoc.Visible  = false;
            txtNumDocumento.Visible = false;
            imbBuscar.Visible = false;
            lblNumDocumento.Visible = false;
            lblTipoDoc.Visible = false;

            if (objEusu.Sexo.UINullable.Equals(UIConstantes.Sexo.Masculino))
                rbdSexoM.Checked = true;
           else
                rbdSexoF.Checked = true;
          


             
        }
        catch (Exception ex) {
            throw ex;
        }finally{
            objUsuario = null;
        }
    
    }

    Boolean eliminarUsuario(Int32 pintCodigo)
    {
        Boolean exito = false;
        BUsuario objBUsuario = null;
        try
        {
            objBUsuario = new BUsuario();
            objBUsuario.Constructor(Conexion);
            objBUsuario.Eliminar(pintCodigo, varIdCodigoAuditoria);
            SettingAlert();
            exito = true;
        }
        catch (Exception ex) { throw ex; }
        finally { objBUsuario = null; }

        return exito;
    }

    Boolean eliminarUsuario(IEUsuarioCollection objEUsuarios)
    {
        Boolean exito = false;
        BUsuario objBUsuario = null;
        try
        {
            if (objEUsuarios.Count.Equals(0))
            {
                exito = false;
                throw new Exception(K_SELECCIONE_USUARIOS);
            }
            else
            {
                objBUsuario = new BUsuario();
                objBUsuario.Constructor(Conexion);
                objBUsuario.Eliminar(objEUsuarios);
                SettingAlert();
                exito = true;
            }
        }
        catch (Exception ex) { throw ex; }
        finally { objBUsuario = null; }

        return exito;
    }

    void SettingAlert()
    {
        cuwAlerta.EstiloMensaje = K_CSS_OK;
        cuwAlerta.Mensaje = K_MSG_ELIMINACION_OK;
        CScript.MessageBox(0, K_MSG_ELIMINACION_OK, upPopUpConfirmEliminar);
    }

    void CargarUsuarios()
    {

        try
        {
             EUsuario objEusuario = null;
             BUsuario objBusuario = null;
             IEUsuarioCollection objUusuarios;
            objBusuario = new BUsuario();
            objEusuario = new EUsuario();

            objEusuario.Codigo = NullInt32.Empty;
            objEusuario.SituacionRegistro = NullString.Create(ddlSituacion.SelectedValue);
            objEusuario.Dominio=NullString.Empty;
            objEusuario.UsuarioRed = NullString.Empty;
            objEusuario.NombreCompleto = NullString.Create(txtNombres.Text);
           

            objBusuario.Constructor(Conexion);

            objUusuarios=objBusuario.ListarUsuarios(objEusuario,NullInt32.Create(ddlOficina.SelectedValue));
            gvResultado.DataSource = objUusuarios.Valores;
            gvResultado.DataBind();
            lblNumeroRegistro.Text = objUusuarios.Count > 0 ? K_MSG_NUM_REGISTRO_HALLADOS + objUusuarios.Count.ToString() : K_MSG_SIN_RESULTADOS_BUSQUEDA;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void CargarOficina()
    {

        BOficina objBOficina = null;
        try
        {


            IEOficinaCollection objOficinas;
            objBOficina = new BOficina();
            objBOficina.Constructor(Conexion);

            objOficinas = objBOficina.ListarOficina(NullInt32.Empty, NullInt32.Empty);
            Bind(ddlOficina, objOficinas.Valores , "CodigoOficina", "NombreOficina");
            addItemTodos(ddlOficina); 
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally{

            objBOficina = null;

        }
        
    }

    void CargarTipoDocumenentos()
    {

        BParametro objBParam = null;
        try
        {


            IEParametroCollection objParametros;

            objBParam = new BParametro();
            objBParam.Constructor(Conexion);

            EParametro objEParametro = new EParametro();

            objEParametro.CodigoTabla = NullInt32.Create(UIConstantes.PARAMETROS.TABLA_TIPO_DOCUMENTO_IDENTIDAD);
            objEParametro.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);

            objParametros = objBParam.ListarParametros(objEParametro, UIConstantes.Situacion.Activo);
            Bind(ddlTipoDoc, objParametros.Valores, "CodigoParametro", "Descripcion");

            if (ddlTipoDoc.Items.FindByText("DNI") != null) ddlTipoDoc.Items.FindByText("DNI").Selected = true;
            ddlTipoDoc.Enabled = false;
             

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            objBParam = null;

        }

    }

    void CargarPais()
    {
        BPais objBPais = null;
        try
        {


            IEPaisCollection objpaises;
            objBPais = new BPais();
            objBPais.Constructor(Conexion);

            IEPais objEPais = new EPais();
            objEPais.CodigoPais = NullInt32.Empty;
            objpaises = objBPais.ListarPais(objEPais);
            Bind(ddlPais, objpaises.Valores, "CodigoPais", "NombrePais");
            if (ddlPais.Items.FindByText("PERU") != null)  ddlPais.Items.FindByText("PERU").Selected = true;
            


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            objBPais = null;

        }

    }

    void NuevoEdicionInicial()
    {
        try
        {
            txtApeMaterno.Text = string.Empty;
            txtApePaterno.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDominio.Text = string.Empty;
            txtUserNT.Text = string.Empty;
            OperacionActual = Operacion.Insertar;
            txtNumDocumento.Text = string.Empty;
            txtFechaNac.Text = string.Empty;

            
            txtNumDocumento.Visible = true;
            
            lblTipoDoc.Visible = true;
            rbdSexoF.Checked = false;
            rbdSexoM.Checked = false;
            ddlTipoDoc.ClearSelection();
            imbBuscar.Visible = true;
            lblNumDocumento.Visible = true;
            ddlTipoDoc.Visible = true;
            ddlPais.ClearSelection();
            ddlSituacionNuevo.ClearSelection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void GrabarUsuario()
    {
        var objEUsuario = (EUsuario)null;
        var objEDoc = (EDocumento)null;
        var objBUsuario = (BUsuario)null;
        try
        {
            ValidarInsertarUsuario();
            if (OperacionActual == Operacion.Insertar) ValidarExistenciaUsuario();    
        
            objBUsuario = new BUsuario();
            objEUsuario = new EUsuario();
           objEDoc = new EDocumento();

            objBUsuario.Constructor(Conexion);

     
            objEUsuario.Correo = NullString.Create(txtCorreo.Text);
            objEUsuario.Dominio = NullString.Create(txtDominio.Text);
            objEUsuario.UsuarioRed = NullString.Create(txtUserNT.Text);
            objEUsuario.SituacionRegistro = NullString.Create(ddlSituacionNuevo.SelectedValue);
            objEUsuario.Nombres = NullString.Create(txtNombre.Text);
            objEUsuario.ApellidoPaterno = NullString.Create(txtApePaterno.Text);
            objEUsuario.ApellidoMaterno = NullString.Create(txtApeMaterno.Text);
            objEUsuario.CodigoPaisNacimineto = NullInt32.Create(ddlPais.SelectedValue);
            objEUsuario.FechaNacimineto = NullDateTime.Create(txtFechaNac.Text);
            objEDoc.CodigoTipoDoc = NullInt32.Create(ddlTipoDoc.SelectedValue );
            objEDoc.NumeroDocumento  = NullString.Create(txtNumDocumento.Text); 
 
            if(rbdSexoF.Checked == true) objEUsuario.Sexo = NullString.Create(UIConstantes.Sexo.Femenino);
            if(rbdSexoM.Checked == true) objEUsuario.Sexo = NullString.Create(UIConstantes.Sexo.Masculino);
           
            if (objEUsuario.Sexo.UINullable != UIConstantes.Sexo.Masculino)
                if (objEUsuario.Sexo.UINullable != UIConstantes.Sexo.Femenino)
                    throw new Exception("Seleccione Sexo.");

            switch (OperacionActual)
            {
                case Operacion.Insertar:
                    {
                        objEUsuario.UsuarioOficinaPerfilRegistro = NullInt32.Create(varIdCodigoAuditoria);
                        objBUsuario.Insertar(objEUsuario, objEDoc);
                        break;
                    }
                case Operacion.Modificar:
                    {
                        objEUsuario.Codigo = CodigoEdicion;
                        objEUsuario.CodigoPersona = CodigoEdicion;
                        objEUsuario.UsuarioOficinaPerfilModifica = NullInt32.Create(varIdCodigoAuditoria);
                        objBUsuario.Actualizar(objEUsuario);
                        break;

                    }
                default: new Exception(K_MSG_OPERACION_ERROR);
                    break;
            }
            cuwAccion.imgGrabar.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objEUsuario = null;
            objBUsuario = null;
        }
       

    }

    void ValidarInsertarUsuario()
    {
        try
        {
                if (OperacionActual == Operacion.Insertar) if (txtNumDocumento.Text.Trim().Length == 0) throw new Exception("Ingrese Documento.");
                if (txtNombre.Text.Trim().Length == 0) throw new Exception("Ingrese Nombre.");
                if (txtApePaterno.Text.Trim().Length == 0) throw new Exception("Ingrese Apellido Paterno");
                if (txtApeMaterno.Text.Trim().Length == 0) throw new Exception("Ingrese Apellido Materno.");
                if (txtDominio.Text.Trim().Length == 0) throw new Exception("Ingrese dominio.");
                if (txtUserNT.Text.Trim().Length == 0) throw new Exception("Ingrese usuario de Red.");
                if (txtCorreo.Text.Trim().Length == 0) throw new Exception("Ingrese correo.");
                if (txtFechaNac.Text.Trim().Length == 0) throw new Exception("Ingrese fecha de nacimiento.");
                if (!(IsMail(txtCorreo.Text))) throw new Exception("Correo tiene formato incorrecto.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void ValidarExistenciaUsuario()
    {
        BUsuario objUsuario = null;
        IEUsuario objEUsuario = null;
        try
        {
            if (txtNumDocumento.Text.Trim().Length == 0) throw new Exception("Ingrese Documento.");
            objUsuario = new BUsuario();
            objUsuario.Constructor(Conexion);
            objEUsuario = objUsuario.ListarUsuarioPorDocumento(Convert.ToInt32(0), Convert.ToInt32(txtNumDocumento.Text));
            if (objEUsuario != null) throw new Exception("Usuario ya ha sido registrado.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objUsuario = null;
            objEUsuario = null;
        }

    }
   
    #endregion

 
}
