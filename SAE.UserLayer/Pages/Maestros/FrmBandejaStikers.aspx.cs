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

public partial class Pages_Maestros_FrmBandejaStikers : UIPage
{
    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        try
        {
            gvStickerApostillador.RowDataBound += new GridViewRowEventHandler(gvStickerApostillador_RowDataBound);
            base.OnLoad(e);
          
            if (!IsPostBack)
            {
                CargarUbicacion();
                listarSeries();
                FillSituacionDll(ddlSituacion);
                setValueDDL(ddlSituacion, UIConstantes.Situacion.Activo);

                if (varIdPerfilActual.ToString() == UIConstantes.Perfil.ADMINISTRADOR)
                {
                    ddlUbicacion.Items.Insert(0, new ListItem("<Todos>", "0"));
                    ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
                    ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
                    ddlSerie.Items.Insert(0, new ListItem("<Todos>", UIConstantes.Situacion.Todos));
                }
                else
                {
                    ddlApostillador.Items.Clear();
                    ddlOficina.Items.Clear();

                    CargarMisiones(0);
                    CargarApostillador(0);

                    ddlUbicacion.Enabled = false; 
                    ddlOficina.Enabled = false;
                    ddlApostillador.Enabled = false;


                    setValueDDL(ddlUbicacion, varIdUbicacionOficinaSel.ToString());
                    setValueDDL(ddlOficina, varIdOficinaActual.ToString());
                    setValueDDL(ddlApostillador, ((EUsuario)Usuario).CodigoUsuario.UINullable);
                }
                this.btnBuscar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_on.gif',this);");
                this.btnBuscar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_off.gif',this);");

                this.btnLimpar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_on.gif',this);");
                this.btnLimpar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_off.gif',this);");
                
                Buscar();
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }

    }
    #endregion


    #region procedimientos y funciones

    public void FillSituacionDll(DropDownList control)
    {

        try
        {
            control.Items.Add(new ListItem("<Todos>", UIConstantes.Situacion.Todos));
            control.Items.Add(new ListItem("Activo", UIConstantes.Situacion.Activo));
            control.Items.Add(new ListItem("Inactivo", UIConstantes.Situacion.Inactivo));
            control.Items.Add(new ListItem("Terminado", UIConstantes.Situacion.Terminado));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    void Buscar()
    {
        try
        {
            string strMensajeNotFound = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["message_not_found_apostilla"]);

            BStickerApostillador objBActu = new BStickerApostillador();
            EStickerApostillador objEActu = new EStickerApostillador();
            objBActu.Constructor(Conexion);
         
            objEActu.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
            objEActu.CodigoOficina = NullInt32.Create(ddlOficina.SelectedValue);
            objEActu.SituacionRegistro = NullString.Create(ddlSituacion.SelectedValue);
            objEActu.Serie = NullString.Create(ddlSerie.SelectedValue);

            IEStickerApostilladorCollection dtStickerApostillador = objBActu.ListarStickerAsignados(objEActu);

            if (dtStickerApostillador != null)
            {
                gvStickerApostillador.DataSource = dtStickerApostillador.Valores;
                gvStickerApostillador.DataBind();

                int pintNumReg = dtStickerApostillador.Count>0 ? dtStickerApostillador.Count:0;
                lblNumeroRegistros.Text = string.Format("Número de Registros encontrados : {0}",pintNumReg.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Filtros

    void CargarUbicacion()
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
            UIPage.Bind(ddlUbicacion, objColeccion.Valores, "CodigoParametro", "Descripcion");



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
    void CargarMisiones(Int32 intCodigoUbicacion)
    {

        BOficina objBMision = null;
        try
        {


            IEOficinaCollection objMisiones;

            objBMision = new BOficina();

            objBMision.Constructor(new UIPage().Conexion);

            objMisiones = objBMision.ListarOficina(NullInt32.Empty, NullInt32.Create(intCodigoUbicacion));
            UIPage.Bind(ddlOficina, objMisiones.Valores, "CodigoOficina", "NombreOficina");



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
    void CargarApostillador(Int32 pinCodigoOficina)
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

            ddlApostillador.DataSource = dt;
            ddlApostillador.DataTextField = "NOMBRES";
            ddlApostillador.DataValueField = "CODIGOAPOSTILLADOR";
            ddlApostillador.DataBind();


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
    void listarSeries()
    {

        try{
        ddlSerie.Items.Clear();
        BStickerApostillador objBActu = new BStickerApostillador();
        EStickerApostillador objEActu = new EStickerApostillador();
        objBActu.Constructor(Conexion);


        objEActu.CodigoApostillador = NullInt32.Empty;
        objEActu.CodigoOficina = NullInt32.Empty;
        objEActu.SituacionRegistro =NullString.Empty;

        DataTable dtStickerApostillador = objBActu.ListarSerie();

        Bind(ddlSerie, dtStickerApostillador, "SERIE", "SERIE");

        
            
        }
     catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #endregion

    #region Eventos
     
    void gvStickerApostillador_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IEStickerApostillador objEntidadStikerApos = (EStickerApostillador)e.Row.DataItem;
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                ImageButton btnEdit = (ImageButton)e.Row.FindControl("btnEdit");
               // ImageButton btnView = (ImageButton)e.Row.FindControl("btnView");


                Label lblCodigo = (Label)e.Row.FindControl("lblCodigo");
                Label lblApostilladores = (Label)e.Row.FindControl("lblApostilladores");
                Label lblOficinas = (Label)e.Row.FindControl("lblOficinas");
                Label lblSerie = (Label)e.Row.FindControl("lblSerie");
                Label lblCorrelativoInicial = (Label)e.Row.FindControl("lblCorrelativoInicial");
                Label lblCorrelativoFinal = (Label)e.Row.FindControl("lblCorrelativoFinal");
                Label lblSituacion = (Label)e.Row.FindControl("lblSituacion");
                    
                if(lblCodigo!=null){
                  lblCodigo.Text=objEntidadStikerApos.CodigoStikerApostillador.UINullable;
                  lblApostilladores.Text=objEntidadStikerApos.NombresApostillador.UINullable;
                  lblOficinas.Text=objEntidadStikerApos.Oficina.UINullable;
                  lblSerie.Text=objEntidadStikerApos.Serie.UINullable;
                  lblCorrelativoInicial.Text=objEntidadStikerApos.CorrelativoInicial.UINullable;
                  lblCorrelativoFinal.Text=objEntidadStikerApos.CorrelativoFinal.UINullable;
                  lblSituacion.Text = objEntidadStikerApos.DescripcionSituacion;

                }
                
                if (btnDelete != null && btnEdit != null ) {
                    btnDelete.Attributes.Add("onclick", "return confirm('¿Está seguro de eliminar el registro?');");
                    btnDelete.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_delete_on.gif',this);");
                    btnDelete.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_delete.gif',this);");
                    btnEdit.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_edit_on.gif',this);");
                    btnEdit.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_edit.gif',this);");

                    if (objEntidadStikerApos.SituacionRegistro.UINullable == UIConstantes.Situacion.Terminado)
                    {
                        
                        btnEdit.ToolTip = "No se puede editar. Toda la serie ya ha sido utilizada.";
                        btnDelete.ToolTip = "No se puede eliminar. Toda la serie ya ha sido utilizada.";
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    //btnView.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Iconos/','data_view_on.gif',this);");
                    //btnView.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Iconos/','data_view.gif',this);");

                    btnDelete.CommandArgument = objEntidadStikerApos.CodigoStikerApostillador.UINullable;
                    btnEdit.CommandArgument = objEntidadStikerApos.CodigoStikerApostillador.UINullable;

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
            ImageButton btnEdit = (ImageButton)sender;
            string strCodigoStickerApos =btnEdit.CommandArgument;
            Response.Redirect(string.Format("FrmStickerApostilladorNuevo.aspx?strParami={0}&xopc=upParam", strCodigoStickerApos), false);
           
        }
        catch (Exception ex)
        {
             CScript.MessageBox(0, ex.Message);
        }

    }
    public void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton btnDelte = (ImageButton)sender;
            BStickerApostillador ObjBActu = new BStickerApostillador();
            ObjBActu.Constructor(Conexion);
            ObjBActu.ActualizarSituacion(Convert.ToInt32(btnDelte.CommandArgument), UIConstantes.Situacion.Inactivo, varIdCodigoAuditoria);
            ObjBActu = null;
            Buscar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Buscar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

          
                ddlSituacion.ClearSelection();
                setValueDDL(ddlSituacion, UIConstantes.Situacion.Activo);
                ddlSerie.ClearSelection();
                ddlUbicacion.ClearSelection();

                ddlOficina.Items.Clear();
                ddlApostillador.Items.Clear();

                ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
                ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
            
                Buscar();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CargarMisiones(Convert.ToInt32(ddlUbicacion.SelectedValue));
            ddlApostillador.Items.Clear();
            ddlOficina.Items.Insert(0, new ListItem("<Todos>", "0"));
            ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }
    protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlApostillador.Items.Clear();


            CargarApostillador(Convert.ToInt32(ddlOficina.SelectedValue));
            ddlApostillador.Items.Insert(0, new ListItem("<Todos>", "0"));
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
     
         try
        {
            Response.Redirect("FrmStickerApostilladorNuevo.aspx", false);
            
        }
        catch (Exception ex)
        {
             CScript.MessageBox(0, ex.Message);
        }

    }
    #endregion
}
