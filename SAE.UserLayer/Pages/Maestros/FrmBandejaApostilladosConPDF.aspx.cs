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
using SAE.UInterfaces;
using SAE.Nullables;

public partial class Pages_Maestros_FrmBandejaApostilladosConPDF : UIPage
{
    #region Inicio
    decimal NumeroRegistrosTotal
    {
        get
        {
            return Convert.ToDecimal(ViewState["_NumeroRegistrosTotal"]); 
        }
        set
        {
            ViewState["_NumeroRegistrosTotal"] = value;
        }
    }
    decimal NumeroPaginasTotal
    {
        get
        {
            return Convert.ToDecimal(ViewState["_NumeroPaginasTotal"]);
        }
        set
        {
            ViewState["_NumeroPaginasTotal"] = value;
        }
    }
    decimal NumeroPaginaActual
    {
        get
        {
            return Convert.ToDecimal(ViewState["_NumeroPaginaActual"]);
        }
        set
        {
            ViewState["_NumeroPaginaActual"] = value;
        }
    }
    decimal NumeroRegistrosXPagina
    {
        get
        {
            return Convert.ToDecimal(ViewState["_NumeroRegistrosXPagina"]);
        }
        set
        {
            ViewState["_NumeroRegistrosXPagina"] = value;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        try
        {
            gvApostillas.RowDataBound += new GridViewRowEventHandler(gvApostillas_RowDataBound);
            imgbtnStart.Click += new ImageClickEventHandler(imgbtnStart_Click);
            imgbtnNext.Click += new ImageClickEventHandler(imgbtnNext_Click);
            imgbtnBack.Click += new ImageClickEventHandler(imgbtnBack_Click);
            imgbtnEnd.Click += new ImageClickEventHandler(imgbtnEnd_Click);

            base.OnLoad(e);
            if (!IsPostBack)
            {
                btnRegistrar.Attributes.Add("onclick", "return confirm('¿Está seguro de Actualizar?');");
                NumeroPaginasTotal = 0;
                NumeroPaginaActual = 0;
                NumeroRegistrosXPagina =Convert.ToDecimal( System.Web.Configuration.WebConfigurationManager.AppSettings["NumeroRegistroPorPagina"]);
                lblNumRegistrosXPagina.Text = string.Format("N&uacute;mero de Registros por Pagina : {0}", NumeroRegistrosXPagina.ToString());

                InicializarBotones();
                CargarUbicacion(ddlUbicacion);
                CargarSeries();
 
                PaginacionVisible(false);

                if (varIdPerfilActual.ToString() == UIConstantes.Perfil.ADMINISTRADOR)
               {
                    ddlUbicacion.Items.Insert(0, new ListItem("<Todos>", "0"));
                    ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
                    ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
                }
                else
                {
                    ddlApostillador.Items.Clear();
                    ddlOficina.Items.Clear();
                    CargarMisiones(0, ddlOficina);
                    CargarApostillador(0, ddlApostillador);
                    ddlUbicacion.Enabled = false; 
                    ddlOficina.Enabled = false;
                    ddlApostillador.Enabled = false;
                    setValueDDL(ddlUbicacion, varIdUbicacionOficinaSel.ToString());
                    setValueDDL(ddlOficina, varIdOficinaActual.ToString());
                    setValueDDL(ddlApostillador, ((EUsuario)Usuario).CodigoUsuario.UINullable);
                }
           }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }

    #endregion
    
    #region procedimientos y funciones

      public void vistaApostilla(int pintCodigoActuacion){

        BActuacion objBActu = null;
        EActuacion objEActu = null;
        
        try{
            objBActu = new BActuacion();
            objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.CodigoActuacion = NullInt32.Create(pintCodigoActuacion);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu, NullInt32.Empty);

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                {
                    #region Apostilla Encontrada

                    hidActuacion.Value = Convert.ToString(dtActuacion.Rows[0]["CODIGOACTUACION"]);
                    hidNombrePDfApostilla.Value = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);

                    string pstrCodigoUbiOficina = Convert.ToString(dtActuacion.Rows[0]["CODIGOUBICACIONOFICINA"]);
                    string pstrCodigoOfiApos = Convert.ToString(dtActuacion.Rows[0]["CODIGOOFICINA"]);
                    string pstrCodigoApos = Convert.ToString(dtActuacion.Rows[0]["CODIGOAPOSTILLADOR"]);

                    string pstrCodigoAutoridadFirmante = Convert.ToString(dtActuacion.Rows[0]["CODIGOFIRMANTE"]);
                    string pstrCodigoTipoDoc = Convert.ToString(dtActuacion.Rows[0]["CODIGOTIPODOCUMENTO"]);
                     
                    txtFechaEdicion.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    lblNumeroApostilla.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    txtOperacion.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]); 
                    txtNumeroStiker.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);
                    txtSerie.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);

                    CargarUbicacion(ddlUbicacionEdicion);
                    setValueDDL(ddlUbicacionEdicion, pstrCodigoUbiOficina);

                    CargarMisiones(Convert.ToInt32(ddlUbicacionEdicion.SelectedValue), ddlOficinaApostilladorEdicion);
                    setValueDDL(ddlOficinaApostilladorEdicion, pstrCodigoOfiApos);

                    CargarApostillador(Convert.ToInt32(ddlOficinaApostilladorEdicion.SelectedValue), ddlApostilladorEdicion);
                    ddlApostilladorEdicion.Items.Insert(0, new ListItem("<Seleccione>", ""));
                    setValueDDL(ddlApostilladorEdicion, pstrCodigoApos);

                    setValueDDL(ddlFirmante, pstrCodigoAutoridadFirmante);
                    setValueDDL(ddlTipoDocumento, pstrCodigoTipoDoc);

                    ddlUbicacionEdicion.Enabled = false;
                    ddlOficinaApostilladorEdicion.Enabled = false;

                    
                 
                    #endregion fin vista
                }
            }
                }catch(Exception ex){

                    throw ex;

                }finally{

                    objBActu = null;
                    objEActu = null;
                   
                }

    }
      public void InicializarBotones(){
        try{
                this.imgbtnStart.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','ico_quitar_todos_on.gif',this);");
                this.imgbtnStart.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','ico_quitar_todos_off.gif',this);");
                this.imgbtnNext.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','ico_agregar_uno_on.gif',this);");
                this.imgbtnNext.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','ico_agregar_uno_off.gif',this);");
                this.imgbtnBack.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','ico_quitar_uno_on.gif',this);");
                this.imgbtnBack.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','ico_quitar_uno_off.gif',this);");
                this.imgbtnEnd.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','ico_agregar_todos_on.gif',this);");
                this.imgbtnEnd.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','ico_agregar_todos_off.gif',this);");

                this.btnBuscar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_on.gif',this);");
                this.btnBuscar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_off.gif',this);");
                this.btnLimpar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_on.gif',this);");
                this.btnLimpar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_off.gif',this);");

                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);");

                this.btnCancelar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_on.gif',this);");
                this.btnCancelar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_off.gif',this);");

        }catch(Exception ex){
             throw ex;
        }
    }
      void Buscar(int pintPagInicial,int pintNumRegPaginado)
    {
        try
        {
            string strMensajeNotFound = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["message_not_found_apostilla"]);
            BActuacion objBActu = new BActuacion();
            objBActu.Constructor(Conexion);
            DataTable dtActuacion = objBActu.ListarActuacionConPDFPaginado(SetEActuacionBusqueda(), NullInt32.Create(ddlUbicacion.SelectedValue), pintPagInicial, pintNumRegPaginado);
            if (dtActuacion != null)
            {
                gvApostillas.DataSource = dtActuacion;
                gvApostillas.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
      protected EActuacion SetEActuacionBusqueda()
    {
        EActuacion objEActu = null;
        try
        {
            objEActu = new EActuacion();
            objEActu.NumeroApostilla = NullString.Create(txtNumeroApostilla.Text);
            objEActu.FechaApostilla = NullDateTime.Create(txtFecha.Text);
            objEActu.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
            objEActu.CodigoOficina = NullInt32.Create(ddlOficina.SelectedValue);
            objEActu.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);
            objEActu.CodigoTipoDocumento = NullInt32.Empty;
            objEActu.OperacionBancaria = NullString.Empty;
            objEActu.Serie = NullString.Create(ddlSeries.SelectedValue);
        }
        catch (Exception ex)
        {
            objEActu = null;
            throw ex;
        }
        return objEActu;

    }
      string  GetNombreDocumentoApostilla(int idActuacion)
    {
        string strNombreFicheroPdf =string.Empty;
        BActuacion objBActu =null;
        EActuacion objEActu = null;
        try
        {
            objBActu = new BActuacion();
            objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.CodigoActuacion = NullInt32.Create(idActuacion);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu, NullInt32.Empty);
            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1) strNombreFicheroPdf = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBActu =null;
            objEActu = null;
        }
        return strNombreFicheroPdf;
    }
      void PaginacionVisible(bool valor)
    {
        try
        {
            imgbtnStart.Visible = valor;
            imgbtnNext.Visible = valor;
            imgbtnBack.Visible = valor;
            imgbtnEnd.Visible = valor;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
      void PaginacionEnabled(bool valor)
    {
        try
        {
            imgbtnStart.Enabled = valor;
            imgbtnNext.Enabled = valor;
            imgbtnBack.Enabled = valor;
            imgbtnEnd.Enabled = valor;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
      //  void CargarApostilladorEdicion()
    //{
    //    BApostillador objC = null;
    //    EApostillador objEC = null;
    //    try
    //    {
    //        objC = new BApostillador();
    //        objEC = new EApostillador();

    //        objC.Constructor(Conexion);

    //        objEC.Materno = NullString.Empty;
    //        objEC.Paterno = NullString.Empty;
    //        objEC.Nombres = NullString.Empty;
    //        objEC.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Todos);
    //        DataTable dt = objC.ListarApostilladores(objEC, NullInt32.Create(varIdOficinaActual));

    //        ddlApostilladorEdicion.DataSource = dt;
    //        ddlApostilladorEdicion.DataTextField = "NOMBRES";
    //        ddlApostilladorEdicion.DataValueField = "CODIGOAPOSTILLADOR";
    //        ddlApostilladorEdicion.DataBind();
    //        ddlApostilladorEdicion.Items.Insert(0, new ListItem("<Seleccione>", ""));

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        objC = null;
    //        objEC = null;
    //    }
    //}
      void CargarFirmantes()
    {
        try
        {
            BFirmante objC = new BFirmante();
            EFirmante objEC = new EFirmante();

            objC.Constructor(Conexion);

            objEC.Materno = NullString.Empty;
            objEC.Paterno = NullString.Empty;
            objEC.Nombres = NullString.Empty;
            DataTable dt = objC.ListarFirmantes(objEC);

            ddlFirmante.DataSource = dt;
            ddlFirmante.DataTextField = "NOMBRES";
            ddlFirmante.DataValueField = "CODIGOFIRMANTE";
            ddlFirmante.DataBind();
            ddlFirmante.Items.Insert(0, new ListItem("<Seleccione>", ""));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
      void CargarTabla(int pitabla, DropDownList ddltabla)
    {
        try
        {
            BParametro objParam = new BParametro();
            objParam.Constructor(Conexion);
            EParametro objEParametro = new EParametro();
            objEParametro.CodigoTabla = NullInt32.Create(pitabla);
            objEParametro.CodigoRegistro = NullInt32.Empty;
            objEParametro.CodigoParametro = NullInt32.Empty;
            DataTable dtListaParame = objParam._ListarParametros(objEParametro, string.Empty);


            if (UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR == pitabla)
            {
                DataView dvDataSort;
                dvDataSort = new DataView(dtListaParame);
                dvDataSort.Sort = "NOMBREPARAMETRO ASC";
                ddltabla.DataSource = dvDataSort;
            }
            else
            {
                ddltabla.DataSource = dtListaParame;
            }

            ddltabla.DataTextField = "NOMBREPARAMETRO";
            ddltabla.DataValueField = "CODIGOPARAMETRO";
            ddltabla.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
      void FillTipoDocumento()
    {
        try
        {
            CargarTabla(UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR, ddlTipoDocumento);
            ddlTipoDocumento.Items.Insert(0, new ListItem("<Seleccione>", ""));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    #region Filtros
    void CargarSeries()
    {
        BActuacion objBActu= null;

        try
        {
            objBActu = new BActuacion();
            objBActu.Constructor(Conexion);
            DataTable dtSeries = objBActu.ListarSerieActuacionConPDF();
            Bind(ddlSeries, dtSeries, "SERIES", "SERIES");
            ddlSeries.Items.Insert(0, new ListItem("<Todos>", ""));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBActu = null;
        }

    }
    void CargarUbicacion(DropDownList ddlUbicacionCtrl)
    {
        BParametro objBParam = null;
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


            objColeccion = objBParam.ListarParametros(objParam, "");
            UIPage.Bind(ddlUbicacionCtrl, objColeccion.Valores, "CodigoParametro", "Descripcion");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBParam = null;
            objUIPage = null;
            objParam = null;
        }

    }
    void CargarMisiones(Int32 intCodigoUbicacion, DropDownList ddlOficinaCtrl)
    {
        BOficina objBMision = null;
        try
        {
            IEOficinaCollection objMisiones;
            objBMision = new BOficina();
            objBMision.Constructor(new UIPage().Conexion);
            objMisiones = objBMision.ListarOficina(NullInt32.Empty, NullInt32.Create(intCodigoUbicacion));
            UIPage.Bind(ddlOficinaCtrl, objMisiones.Valores, "CodigoOficina", "NombreOficina");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBMision = null;
        }
    }
    void CargarApostillador(Int32 pinCodigoOficina, DropDownList ddlApostilladorCtrl)
    {
        try
        {
            BApostillador objC = new BApostillador();
            EApostillador objEC = new EApostillador();
            objC.Constructor(Conexion);
            objEC.Materno = NullString.Empty;
            objEC.Paterno = NullString.Empty;
            objEC.Nombres = NullString.Empty;
            DataTable dt = objC.ListarApostilladores(objEC, NullInt32.Create(pinCodigoOficina));

            ddlApostilladorCtrl.DataSource = dt;
            ddlApostilladorCtrl.DataTextField = "NOMBRES";
            ddlApostilladorCtrl.DataValueField = "CODIGOAPOSTILLADOR";
            ddlApostilladorCtrl.DataBind();

            objC = null;
            objEC = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void setValueDDL(DropDownList obj, string codigoSel)
    {
        if (obj.Items.FindByValue(codigoSel.ToString()) != null) obj.Items.FindByValue(codigoSel.ToString()).Selected = true;
    }
    #endregion

      void Validacion()
    {
        try
        { 
            if (txtFechaEdicion.Text.Trim().Length == 0) throw new Exception("Ingrese fecha de la apostilla.");
            if (ddlFirmante.SelectedIndex == 0) throw new Exception("Seleccione la autoridad firmante del documento.");
            if (ddlApostilladorEdicion.SelectedIndex == 0) throw new Exception("Seleccione la persona que apostilla el documento.");
            if (ddlTipoDocumento.SelectedIndex == 0) throw new Exception("Seleccione tipo de documento a apostillar.");
            if (txtOperacion.Text.Trim().Length == 0) throw new Exception("Ingrese el numero de Operación bancaria.");
            if (txtSerie.Text.Trim().Length == 0) throw new Exception("Ingrese la serie.");
            if (txtNumeroStiker.Text.Trim().Length == 0) throw new Exception("Ingrese el número de la serie.");
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
      protected void Actualizar()
    {
        BActuacion pbjBParam = null;
        EActuacion pobjActuacion = null;
        try
        {
            Validacion();
            pbjBParam = new BActuacion();
            pobjActuacion = new EActuacion();
            pbjBParam.Constructor(Conexion);
            pobjActuacion.CodigoApostillador = NullInt32.Create(ddlApostilladorEdicion.SelectedValue);
            pobjActuacion.CodigoFirmante = NullInt32.Create(ddlFirmante.SelectedValue);
            pobjActuacion.CodigoTipoDocumento = NullInt32.Create(ddlTipoDocumento.SelectedValue);
            pobjActuacion.OperacionBancaria = NullString.Create(txtOperacion.Text);
            pobjActuacion.Serie = NullString.Create(txtSerie.Text);
            pobjActuacion.NumeroSerie = NullString.Create(txtNumeroStiker.Text);
            pobjActuacion.FechaApostilla = NullDateTime.Create(txtFechaEdicion.Text);
            pobjActuacion.UsuarioOficinaPerfilModifica = NullInt32.Create(varIdCodigoAuditoria);
            pobjActuacion.CodigoActuacion = NullInt32.Create(hidActuacion.Value);
            pobjActuacion.NombreDocumento = NullString.Create(hidNombrePDfApostilla.Value);

            pbjBParam.ModificarActuacion(pobjActuacion);



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            pbjBParam = null;
            pobjActuacion = null;
        }
    }
    
    #endregion

    #region Eventos Paginado

    void Paginar()
    {
        try
        {
            BActuacion objBActu = new BActuacion();
            objBActu.Constructor(Conexion);
            NumeroRegistrosTotal = objBActu.NumeroRegistrosEncontradosConPDF(SetEActuacionBusqueda(), NullInt32.Create(ddlUbicacion.SelectedValue));
            NumeroPaginasTotal = Math.Ceiling(NumeroRegistrosTotal / (NumeroRegistrosXPagina + 1));

            lblNumeroRegistros.Text = string.Format("Número de Registros encontrados : {0}", NumeroRegistrosTotal.ToString());
            lblPagina.Text = string.Format("Página {0} de {1} ", NumeroPaginaActual, NumeroPaginasTotal);
            PaginacionVisible(true);

            if (NumeroRegistrosTotal <= NumeroRegistrosXPagina)
            {
                PaginacionEnabled(false);
            }
            else
            {
                PaginacionEnabled(true);
            }
            if (NumeroPaginasTotal == 0)
            {
                PaginacionVisible(false);
                lblPagina.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void imgbtnEnd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            NumeroPaginaActual = NumeroPaginasTotal;
            Buscar((int)NumeroPaginaActual, (int)NumeroRegistrosXPagina);
            Paginar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    void imgbtnBack_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if ((NumeroPaginaActual - 1) >= 1)
            {
                NumeroPaginaActual--;
                Buscar((int)NumeroPaginaActual, (int)NumeroRegistrosXPagina);
                Paginar();
            }
            else
            {
               throw new Exception("Ha llegado a la pagina inicial.");
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if ((NumeroPaginaActual + 1) <= NumeroPaginasTotal)
            {
                NumeroPaginaActual++;
                Buscar((int)NumeroPaginaActual, (int)NumeroRegistrosXPagina);
                Paginar();
            }
            else
            {
                 throw new Exception("Ha llegado a la pagina final.");
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    void imgbtnStart_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            NumeroPaginaActual=1;
            Buscar((int)NumeroPaginaActual, (int)NumeroRegistrosXPagina);
            Paginar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }

    #endregion

    #region Eventos
  
    protected void imgApos_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ImageButton lnkVerPDF = (ImageButton)sender;
            int pintCodigoActuacion = Convert.ToInt32(lnkVerPDF.CommandArgument);
            string FilePDF = GetNombreDocumentoApostilla(pintCodigoActuacion);

            if (FilePDF.Trim().Length == 0)
            {
                vistaApostillaSticker(pintCodigoActuacion);
                mpeVerApostilla.Show();
            }
            else
            {
                string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillasWeb"];
                string ruta_archivo = carpeta + FilePDF;// ruta fisica
                string js = string.Format("javascript:window.open('{0}','null','toolbar=no,directories=no,status=no,menubar=no,scrollbars=no');", ruta_archivo);
                CScript.RegistrarScriptBlock("popup", js, upBandejaApostilla); 
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(1, ex.Message.ToString(), upBandejaApostilla);
        }
    }
    void gvApostillas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                ImageButton btnEdit = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton btnView = (ImageButton)e.Row.FindControl("btnView");

               
                if (btnDelete != null && btnEdit != null && btnView != null) {

                    btnDelete.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_delete_on.gif',this);");
                    btnDelete.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_delete.gif',this);");
                    btnEdit.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_edit_on.gif',this);");
                    btnEdit.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_edit.gif',this);");
                    btnView.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_view_on.gif',this);");
                    btnView.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_view.gif',this);");
                    
                     if (fila["SITUACION"].ToString() == UIConstantes.Situacion.Inactivo)
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnView.Enabled = false;

                        btnEdit.ToolTip = "Opción deshabilitada. Registro inactivo.";
                        btnDelete.ToolTip = "Opción deshabilitada. Registro inactivo.";
                        btnView.ToolTip = "Opción deshabilitada. Registro inactivo.";
                     }
                }
                e.Row.Cells[8].Text =Convert.ToDateTime(fila["FECHAAPOSTILLA"]).ToShortDateString();
                btnDelete.Attributes.Add("onclick", "return confirm('¿Está seguro de Eliminar?');");

                if (varIdPerfilActual.ToString() != UIConstantes.Perfil.APOSTILLADOR)
                {
                    btnDelete.Visible = false;
                   // btnEdit.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
          
            CargarFirmantes();
            FillTipoDocumento();
            
            ImageButton btnEdit = (ImageButton)sender;
            int pintCodigoActuacion = Convert.ToInt32(btnEdit.CommandArgument); 
            
            vistaApostilla(pintCodigoActuacion);

            BuscarCargoAutoridad(sender, e);
            mpeEditarApostilla.Show(); 
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    public void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnDelte = (ImageButton)sender;
            BActuacion ObjBActu = new BActuacion();
            ObjBActu.Constructor(Conexion);
            ObjBActu.ActualizarSituacion(Convert.ToInt32(btnDelte.CommandArgument), UIConstantes.Situacion.Inactivo, varIdCodigoAuditoria);
            ObjBActu = null;
            Buscar((int)NumeroPaginaActual,(int)NumeroRegistrosXPagina);
            Paginar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            NumeroPaginaActual = 1;
            Buscar((int)NumeroPaginaActual, (int)NumeroRegistrosXPagina);
            Paginar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtFecha.Text = string.Empty;
            txtNumeroApostilla.Text = string.Empty;
          

            gvApostillas.DataSource = null;
            gvApostillas.DataBind();
            lblNumeroRegistros.Text = string.Empty;
            lblPagina.Text = string.Empty;
            PaginacionVisible(false);
            NumeroPaginasTotal = 0;
            NumeroPaginaActual = 0;
            ddlSeries.ClearSelection();
            if (varIdPerfilActual.ToString() != UIConstantes.Perfil.APOSTILLADOR)
            {
                ddlUbicacion.ClearSelection();
                ddlOficina.Items.Clear();
                ddlApostillador.Items.Clear();
                ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
                ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upBandejaApostilla);
        }
    }
    
    #endregion

    #region Evento Ajax

    protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["TiempoAjax"])); 
            CargarMisiones(Convert.ToInt32(ddlUbicacion.SelectedValue), ddlOficina);
            ddlApostillador.Items.Clear();
            ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
            ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString(), upBandejaApostilla);
        }
    }
    protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["TiempoAjax"])); 
            ddlApostillador.Items.Clear();
            CargarApostillador(Convert.ToInt32(ddlOficina.SelectedValue), ddlApostillador);
            ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString(), upBandejaApostilla);
        }
    }
    protected void imgCerrar_Click(object sender, ImageClickEventArgs e)
    {
   
        try
        {
            mpeEditarApostilla.Hide();
            
        }
        catch (Exception ex)
        {
            CScript.MessageBox(1, ex.Message.ToString(), upEdicionApostilla);
        }
    }
    public void BuscarCargoAutoridad(object sender, EventArgs e)
    {
        try
        {
            BFirmante objParam = new BFirmante();
            EFirmante objEparam = new EFirmante();
            objParam.Constructor(Conexion);
            objEparam.CodigoFirmante = NullInt32.Create(ddlFirmante.SelectedValue);
            DataTable dtParam = objParam.ListarFirmantes(objEparam);

            if (dtParam != null)
            {
                
                switch (dtParam.Rows.Count)
                {
                    case 1: lblCargoAutoridad.Text = string.Format("&nbsp;Cargo    : {0}", Convert.ToString(dtParam.Rows[0]["CARGO"]));
                        lblEntidad.Text = string.Format("&nbsp;Entidad  : {0}", Convert.ToString(dtParam.Rows[0]["ENTIDAD"]));
                        break;
                    case 0: lblCargoAutoridad.Text = string.Empty;
                        lblEntidad.Text = string.Empty;
                        break;
                    default: lblCargoAutoridad.Text = string.Empty; lblEntidad.Text = string.Empty;
                        throw new Exception("Existen varias cargos asociados a la Autoridad firmante.");

                }

            }
            else
            {
                throw new Exception("No se obtuvo resultados de la búsqueda.");
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upEdicionApostilla);
        }


    }
    protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Actualizar();
            CScript.MessageBox(0, "Datos de apostilla actualizados correctamente.", upEdicionApostilla);
            btnBuscar_Click(sender, e);
            upBandejaApostilla.Update();
            mpeEditarApostilla.Hide();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upEdicionApostilla);
        }
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    { 
        try
        {

            imgCerrar_Click(sender, e);
          
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message,upEdicionApostilla);
        }
     
       }


    #endregion

    public void vistaApostillaSticker(int pintCodigoActuacion)
    {

        BActuacion objBActu = null;
        EActuacion objEActu = null;

        try
        {
            objBActu = new BActuacion();
            objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.CodigoActuacion = NullInt32.Create(pintCodigoActuacion);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu, NullInt32.Empty);

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                {
                    #region Vista APostilla
                    //muestra datos de la ApostillaPreView en previen
                    lblPais.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaPais"]);
                    //lblAt.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaLugar"]);
                    lblBy.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                    lblMRE.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                    lblDireccion.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaFirmaDir"]);


                    lblAt.Text = Convert.ToString(dtActuacion.Rows[0]["OFICINA"]).ToUpper(); ;
                    lblThe.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    lblNro.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    lblFirma.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]).ToUpper();
                    _lblApostilladorVista.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);

                    BFirmante objParam = new BFirmante();
                    EFirmante objEparam = new EFirmante();
                    objParam.Constructor(Conexion);
                    objEparam.CodigoFirmante = NullInt32.Create(Convert.ToString(dtActuacion.Rows[0]["CODIGOFIRMANTE"]));
                    DataTable dtParam = objParam.ListarFirmantes(objEparam);
                    if (dtParam != null)
                    {
                        if (dtParam.Rows.Count == 1)
                        {
                            lblCargoFirmante.Text = Convert.ToString(dtParam.Rows[0]["CARGO"]).ToUpper();
                            Label4.Text = Convert.ToString(dtParam.Rows[0]["ENTIDAD"]).ToUpper();
                        }
                    }
                    lblSeries.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);
                    lblNumeroCorrelativo.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);

                    string strRutaCompartido = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaFirmas"];
                    string strNombreFile = Convert.ToString(dtActuacion.Rows[0]["NOMBREARCHIVOFIRMA"]);
                    string strRutaCompleta = strRutaCompartido + strNombreFile;
                    imgFirma.ImageUrl = strRutaCompleta;
                    ////fin datos apostillado preview
                    #endregion fin vista
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {

            objBActu = null;
            objEActu = null;

        }

    }

    protected void imgVerCerrar_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            mpeVerApostilla .Hide();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(1, ex.Message.ToString(), upVistaApostilla);
        }
    }


    
}
