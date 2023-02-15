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
using SAE.EntityLayer;
using SAE.EntityLayer.Collections;
using SAE.Nullables;
public partial class FrmPerfilUsuario : UIPage
{

    #region  Constantes,propiedades
    
    private const string K_SEPARARADOR = "-";
    private const string K_MSG_NUM_REGISTRO_HALLADOS = " Número de registros encontrados :";
    private const string K_MSG_SIN_RESULTADOS_BUSQUEDA = " No se encontraron resultados en la búsqueda.";
    NullInt32 CodUsuarioSel
    {
        get
        {

            return (NullInt32)ViewState["_codigo_usuario"];
        }
        set
        {
            ViewState.Add("_codigo_usuario", value);
        }
    }
    NullInt32 CodigoPerfilUsuarioOficinaSel
    {
        get
        {

            return (NullInt32)ViewState["_codigo_perfil_usuario_oficina"];
        }
        set
        {
            ViewState.Add("_codigo_perfil_usuario_oficina", value);
        }
    }

    #endregion

    #region Inicio

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if(Page.IsPostBack!=true)
        {
            CodUsuarioSel = NullInt32.Create(0);
        }

        
    }

    #endregion

    #region Metodos

    public void BuscarDatos(object sender, EventArgs e)
    {
        try
        {
            CargarPerfil();
        }catch(Exception ex){
            CScript.MessageBox(0, ex.Message,upBusquedaRegistros );  

        }
    }   
    void CargarPerfil()
    {

        try
        {
            if (txtNombres.Text.Trim().Length <= 0) throw new Exception("Ingrese apellidos y nombres");
            BPerfilUsuario objBPerfilUsuario = null;
            IEPerfilUsuarioCollection objPerfiUsuarios = null;
            BUsuario objBUsuario = null;
            objBPerfilUsuario = new BPerfilUsuario();
            objBUsuario = new BUsuario();



            objBUsuario.Constructor(Conexion);
            objBPerfilUsuario.Constructor(Conexion);

            CodUsuarioSel = NullInt32.Create(objBUsuario.ObtenerCodigoXNombres(txtNombres.Text));
            objPerfiUsuarios= objBPerfilUsuario.ListarPerfilUsuario(CodUsuarioSel.Value ,UIConstantes.Situacion.Todos);
            gvResultado.DataSource = objPerfiUsuarios.Valores ;
            gvResultado.DataBind();
            lblNumeroRegistro.Text = objPerfiUsuarios.Count > 0 ? K_MSG_NUM_REGISTRO_HALLADOS + objPerfiUsuarios.Count.ToString() : K_MSG_SIN_RESULTADOS_BUSQUEDA;

            if(objPerfiUsuarios.Count==0) CScript.MessageBox(0,string.Format("El usuario :{0} no tiene perfiles asociados. Seleccione la opción Nuevo para asignarle perfil",txtNombres.Text),upBusquedaRegistros); 
                

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ValidarRegistroAsigPerfil()
    {
        try
        {
            if (CodUsuarioSel.Value == 0) throw new Exception("Para registrar primero realiza la busqueda de un usuario.");
            if (cuwPerfil.ddl_Ubicacion.SelectedIndex <= 0) throw new Exception("Seleccione ubicación.");
            if (cuwPerfil.ddl_Oficina.SelectedIndex <= 0) throw new Exception("Seleccione oficina.");
          //  if (cuwPerfil.ddl_Unidad.SelectedIndex <= 0) throw new Exception("Seleccione unidad.");
            if (cuwPerfil.ddl_Perfil.SelectedIndex <= 0) throw new Exception("Seleccione perfil.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void InicializarPerfilEditar()
    {
                  
    }
    void ListarOpciones(NullInt32 IDPerfilUsuarioOficina)
    {

        IBOpcion objBOpcion = null;
        IEOpcionCollection objOpciones = null;
        IEOpcionCollection objOpcionesPadre = null;
        IEOpcionCollection objOpcionesHijoA = null;
        try
        {
            objOpcionesPadre = new EOpcionCollection();
            objOpcionesHijoA = new EOpcionCollection();
            objOpciones = new EOpcionCollection();

            objBOpcion = new BOpcion();
            objBOpcion.Constructor(Conexion);


            objOpciones = objBOpcion.ListarOpcionPerfil(NullInt32.Create(cuwPerfil.ddl_Perfil.SelectedValue), Convert.ToInt32(cuwPerfil.ddl_Modulo.SelectedValue),IDPerfilUsuarioOficina);


            foreach (EOpcion opcion in objOpciones.Valores)
            {
                if (opcion.Nivel.UINullable == "1")
                {
                    objOpcionesPadre.Add(opcion.CodigoOpcion.UINullable, opcion);
                    {
                        foreach (EOpcion opcionB in objOpciones.Valores)
                        {
                            if (opcionB.CodigoOpcionPadre.UINullable == opcion.CodigoOpcion.UINullable)
                            {
                                objOpcionesPadre.Add(opcionB.CodigoOpcion.UINullable, opcionB);
                            }
                        }
                    }
                }

            }

            gvPerfil.DataSource = objOpcionesPadre.Valores;
            gvPerfil.DataBind();


        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    void LimpiarOpcionesPerfil()
    {
        gvPerfil.DataSource = null;
        gvPerfil.DataBind();
    }
    #endregion
              
    #region Eventos

    protected void gvResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var objPer = (EPerfilUsuario)e.Row.DataItem;
            
            ImageButton btnEdicion = (ImageButton)e.Row.FindControl("ImgEdit");
            ImageButton botonDel = (ImageButton)e.Row.FindControl("ImgDelete");
            btnEdicion.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_edit_on.gif',this);");
            btnEdicion.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','data_edit.gif',this);");
          
            botonDel.Height = 16;
            botonDel.Width = 16;


            if (objPer.SituacionRegistro.UINullable  == UIConstantes.Situacion.Activo)
            {
                 
                botonDel.ImageUrl = Request.ApplicationPath + "/Images/Iconos/apply_f2.png";
                botonDel.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','apply.png',this);");
                botonDel.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','apply_f2.png',this);");
         
                botonDel.Attributes.Add("onclick", "return confirm('¿Desea inactivar el registro del Perfil?');");
                botonDel.ToolTip = "Click para Inactivar el registro..";
                botonDel.CommandName = UIConstantes.Situacion.Inactivo ;
            }
            else
            {
                botonDel.ImageUrl = Request.ApplicationPath + "/Images/Iconos/apply.png";
                botonDel.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','apply_f2.png',this);");
                botonDel.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Iconos/','apply.png',this);");
                
         
                botonDel.Attributes.Add("onclick", "return confirm('¿Desea activar el registro del Perfil?');");
                botonDel.ToolTip = "Click para Activar el registro..";
                botonDel.CommandName = UIConstantes.Situacion.Activo ;

            }
        }
    }
    protected void EditarClick(object sender, EventArgs e){
        
        IEPerfilUsuarioCollection objPerfiUsuarios = null;
        BPerfilUsuario objBPerfilUsuario = null;
        try
        {
            InicializarPopUp();
            OperacionActual = Operacion.Modificar; 
            ImageButton ImgbtnEdit = (ImageButton)sender;
            lblSubtituloPopUp.Text = "Editar Perfil Usuario" ;
            mpeNuevoPerfilUsuario.Show();

          
            objBPerfilUsuario = new BPerfilUsuario();
            objBPerfilUsuario.Constructor(Conexion);
            objPerfiUsuarios = objBPerfilUsuario.ListarPerfilUsuario(CodUsuarioSel.Value, UIConstantes.Situacion.Todos);
            Int32 cuenta_cod_encontrado = 0;
           
            foreach (EPerfilUsuario objPerfilUsu in objPerfiUsuarios.Valores)
            {
                if (objPerfilUsu.CodigoPerfilUsuarioOfi.Value ==Convert.ToInt32(ImgbtnEdit.CommandArgument.ToString())){
                    cuenta_cod_encontrado++;

                    cuwPerfil.ListadoUbicacion(objPerfilUsu.CodigoUbicacion.Value);
                    cuwPerfil.ListadoOficinas(objPerfilUsu.CodigoOficina.Value);
                    cuwPerfil.ListadoUnidad(objPerfilUsu.CodigoUnidad.Value);
                    cuwPerfil.ListadoModulo(objPerfilUsu.CodigoModulo.Value);
                    cuwPerfil.ListadoModulo(objPerfilUsu.CodigoModulo.Value);
                    cuwPerfil.ListadoPerfil(objPerfilUsu.CodigoPerfil.Value);
                    ListarOpciones(objPerfilUsu.CodigoPerfilUsuarioOfi);
                    cuwPerfil.Enabled(false);
                    CodigoPerfilUsuarioOficinaSel = objPerfilUsu.CodigoPerfilUsuarioOfi;
 
                    break;
                }
                
            }
                if (cuenta_cod_encontrado == 0){
                    throw new Exception("No existe el usuario con el codigo buscado.");
                }
            
            }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    protected void EliminarClick(object sender, EventArgs e)
    {
        var objPerfilUsuario = (BPerfilUsuario)null;
        var objEApostillador = (EApostillador)null;
        try
        {
            objPerfilUsuario = new BPerfilUsuario();
            objPerfilUsuario.Constructor(Conexion);
            string pstrSituacion=string.Empty ;
            var btnEliminar = (ImageButton)sender;
            bool blVlida = btnEliminar.CommandName != UIConstantes.Situacion.Inactivo && btnEliminar.CommandName != UIConstantes.Situacion.Activo;

            if (blVlida) throw new Exception("Error al cambiar la situación del registro.");
            if (btnEliminar.CommandName == UIConstantes.Situacion.Activo) pstrSituacion = UIConstantes.Situacion.Activo;
            if (btnEliminar.CommandName == UIConstantes.Situacion.Inactivo) pstrSituacion = UIConstantes.Situacion.Inactivo;

            objEApostillador = new EApostillador();
            objEApostillador.CodigoApostillador =  CodUsuarioSel;
            objEApostillador.UsuarioModifica = NullInt32.Create(varIdCodigoAuditoria);
            objEApostillador.SituacionRegistro = NullString.Create(pstrSituacion);

            objPerfilUsuario.ActualizarSituacionRegistro(Convert.ToInt32(btnEliminar.CommandArgument), pstrSituacion, objEApostillador);
            CargarPerfil();
            upBusquedaRegistros.Update();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBusquedaRegistros);
        }
        finally
        {
            objPerfilUsuario = null;
        }

    }
    protected void RegistrarPerfilClick(object sender, EventArgs e)
    {
        IBPerfilUsuario objPerfilBusuario = null;
        EDetallePerfilUsuarioCollection objPerfilOpcionesUsuario = null;
        try
        {
            objPerfilOpcionesUsuario = new EDetallePerfilUsuarioCollection();
            foreach (GridViewRow fila in gvPerfil.Rows)
            {
                RadioButtonList OpcionSel= (RadioButtonList)fila.Cells[0].FindControl("OpcionSel");
                EPerfilUsuarioDetalle oPerfilUsuDeta=new EPerfilUsuarioDetalle ();

                oPerfilUsuDeta.TipoOpcion=OpcionSel.SelectedValue.ToString();
                oPerfilUsuDeta.CodigoOpcion=  Convert.ToInt32(fila.Cells[2].Text);
                if (OperacionActual == Operacion.Modificar) oPerfilUsuDeta.CodigoPerfilUsuarioOf = CodigoPerfilUsuarioOficinaSel.Value;
                else oPerfilUsuDeta.CodigoPerfilUsuarioOf = 0;

                objPerfilOpcionesUsuario.Add(oPerfilUsuDeta.CodigoOpcion.ToString(), oPerfilUsuDeta);
            }

            if (CodUsuarioSel.Value == 0) throw new Exception("Para asignar perfil a un usuario primero debe realizar la búsqueda del usuario y luego ingresar a esta opción.");
            if (objPerfilOpcionesUsuario.Count == 0) throw new Exception("No existen opciones para el perfil seleccionado.");
            ValidarRegistroAsigPerfil();
            objPerfilBusuario = new BPerfilUsuario();
            objPerfilBusuario.Constructor(Conexion);

            ///addon 20100927 verificacioin si es Modulo de apostillas y perfil seleccionado es apostillador 
            int pintPerfilApostillador, pintModulo;
            bool blEsApostillador = false;
            pintModulo = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["ModuloDefatult"]);
            pintPerfilApostillador = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["CodigoPerfilApostillador"]);
            if (varIdModuloSel == pintModulo && pintPerfilApostillador == Convert.ToInt32(cuwPerfil.ddl_Perfil.SelectedValue)) blEsApostillador = true;
            ///end addon
            
            switch(OperacionActual)
            {
                case Operacion.Insertar :  objPerfilBusuario.InsertarPerfilUsuario(Convert.ToInt32(cuwPerfil.ddl_Perfil.SelectedValue),
                                                                                    CodUsuarioSel.Value,
                                                                                    Convert.ToInt32(cuwPerfil.ddl_Oficina.SelectedValue),
                                                                                    varIdCodigoAuditoria,
                                                                                    objPerfilOpcionesUsuario, blEsApostillador
                                                                                    );
                                            break;
                case Operacion.Modificar:   objPerfilBusuario.ModificarPerfilUsuario(objPerfilOpcionesUsuario);                  
                                            break;
                default: throw new Exception("No se pudo realizar ninguna acción."); break;

            }
            CargarPerfil();
            upBusquedaRegistros.Update();
            mpeNuevoPerfilUsuario.Hide();
            InicializarPopUp();
            CScript.MessageBox(0, "Grabado Correctamente", upPerfilUsuario);  

          }
        catch (Exception ex)
        {
             CScript.MessageBox(0,ex.Message,upPerfilUsuario  );
        }
        finally{
            objPerfilBusuario = null;
        }

    }
    public void LimpiarFiltro(object sender, EventArgs e)
    {
        CodUsuarioSel = NullInt32.Empty;
        txtNombres.Text = string.Empty;
        gvResultado.DataSource = null;
        gvResultado.DataBind();
        lblNumeroRegistro.Text = string.Empty; 
     
    }
    public void ClosePopup(object sender, EventArgs e)
    {
        try
        {
           mpeNuevoPerfilUsuario.Hide();
           InicializarPopUp();
           
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    private void InicializarPopUp()
    {
        lblSubtituloPopUp.Text = "Registrar Perfil Usuario";
        cuwPerfil.Enabled(true);
        gvPerfil.DataSource = null;
        gvPerfil.DataBind();
        cuwPerfil.ddl_Ubicacion.ClearSelection() ;

        cuwPerfil.ddl_Unidad.Items.Clear();
        cuwPerfil.ddl_Oficina.Items.Clear();
        cuwPerfil.ddl_Modulo.Items.Clear();
        cuwPerfil.ddl_Perfil.Items.Clear();
        
        cuwPerfil.addItemSeleccione(cuwPerfil.ddl_Unidad);
        cuwPerfil.addItemSeleccione(cuwPerfil.ddl_Oficina);
        cuwPerfil.addItemSeleccione(cuwPerfil.ddl_Modulo);
        cuwPerfil.addItemSeleccione(cuwPerfil.ddl_Perfil);
        OperacionActual = Operacion.Insertar;
        CodigoPerfilUsuarioOficinaSel = NullInt32.Empty;


         
        
        


    }

    #endregion

    #region Eventos Controles PopUp


    public void ModuloIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LimpiarOpcionesPerfil();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    public void UnidadIndexChanged(object sender, EventArgs e)
    {
        try
        {
          //  LimpiarOpcionesPerfil();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    public void OficinaIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LimpiarOpcionesPerfil();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    public void UbicacionIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LimpiarOpcionesPerfil();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upPerfilUsuario);
        }
    }
    public void PerfilIndexChanged(object sender, EventArgs e)
    {
       try
         {
           ListarOpciones(NullInt32.Empty);           
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message , upPerfilUsuario);
        }
    }

    public void gvPerfil_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;

            ImageButton MinButton = (ImageButton)e.Row.Cells[0].FindControl("MinBT");
            MinButton.CommandArgument = e.Row.RowIndex.ToString();
            ImageButton addButton = (ImageButton)e.Row.Cells[0].FindControl("PluseBT");
            addButton.CommandArgument = e.Row.RowIndex.ToString();
      
        }
    }
    public void gvPerfil_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ShowHide = e.Row.Cells[1].Text;
            RadioButtonList OpcionSel = (RadioButtonList)e.Row.FindControl("OpcionSel");
            EOpcion  item=(EOpcion)e.Row.DataItem;
            if (OpcionSel != null)
            {
                foreach (ListItem rdbtn in OpcionSel.Items){
                    if (rdbtn.Value == item.TipoAcceso.UINullable)rdbtn.Selected = true;
                }
            }
            if (ShowHide != "0")
            {
                ImageButton Bt_Min = (ImageButton)e.Row.Cells[0].FindControl("MinBT");
                Bt_Min.Visible = false;
                ImageButton Bt_plus = (ImageButton)e.Row.Cells[0].FindControl("PluseBT");
                Bt_plus.Visible = false;
            }
            else
            {
                e.Row.Cells[4].Visible = false;
            }
        }
    }
    protected void despliegue(string NodoPadre, bool fl_FilaVisible,bool fl_BotonPlusVisible)
    {
       
        foreach (GridViewRow fila in gvPerfil.Rows)
        {
            if (fila.Cells[1].Text == NodoPadre)
            {
                fila.Visible = fl_FilaVisible;
            }
            if (fila.Cells[2].Text == NodoPadre)
            {
                ImageButton Bt_Min = (ImageButton)fila.Cells[0].FindControl("MinBT");
                Bt_Min.Visible = fl_FilaVisible;
                ImageButton Bt_plus = (ImageButton)fila.Cells[0].FindControl("PluseBT");
                Bt_plus.Visible = fl_BotonPlusVisible;

            }
        }
    }
    public void gvPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "_Show")
            despliegue(e.CommandArgument.ToString(), true, false);
        if (e.CommandName == "_Hide")
            despliegue(e.CommandArgument.ToString(), false,true);
    }

    #endregion
}
