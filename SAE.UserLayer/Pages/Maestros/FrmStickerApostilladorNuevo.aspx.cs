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

using System.IO;
using SAE.UInterfaces;
using SAE.BusinessLayer;
using SAE.EntityLayer;
using SAE.EntityLayer.Collections;
using SAE.UInterfaces;
using SAE.Nullables;

public partial class Pages_Maestros_FrmStickerApostilladorNuevo : UIPage
{


    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        try
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                CargarUbicacion();
                ddlUbicacion.Items.Insert(0, new ListItem("<Seleccione>", "-1"));
                ddlApostillador.Items.Insert(0, new ListItem("<Seleccione>", "-1"));
                ddlOficina.Items.Insert(0, new ListItem("<Seleccione>", "-1"));

                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);");
                CargarSituacion();
         
                 if (Request.QueryString["strParami"] != null) hidCodigoStickerApostillador.Value = Request.QueryString["strParami"];

            if (Request.QueryString["xopc"] != null)
            {
                        if (Request.QueryString["xopc"] == "upParam")
                        {
                            lblTitulo.Text = "Actualización de Asignación de Sticker Apostillador";
                            OperacionActual = Operacion.Modificar;
                            FillApostilladorEditar();
                        }
                        else
                        {
                            lblTitulo.Text = "Asignar de Series de Sticker a Apostillador";
                            OperacionActual = Operacion.Insertar;
                        }
            }
            else
            {
                lblTitulo.Text = "Asignar de Series de Sticker a Apostillador";
                OperacionActual = Operacion.Insertar;
            }
           
            }
      
       }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }

    #endregion


    #region Metodos
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
    void CargarSituacion()
    {
        try
        {
            ddlSituacion.Items.Add(new ListItem("Activo", UIConstantes.Situacion.Activo));
            ddlSituacion.Items.Add(new ListItem("Inactivo", UIConstantes.Situacion.Inactivo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void FillApostilladorEditar()
    {
       try{
           BStickerApostillador objParam = new BStickerApostillador();
           EStickerApostillador objEStickerApostillador = new EStickerApostillador();
           IEStickerApostilladorCollection objStikersAsignados = null;
           objParam.Constructor(Conexion);
           objEStickerApostillador.CodigoStikerApostillador = NullInt32.Create(hidCodigoStickerApostillador.Value);
           objStikersAsignados = objParam.ListarStickerAsignados(objEStickerApostillador);
           
           foreach( EStickerApostillador objEStickers in  objStikersAsignados  ){
               txtCodigo.Text = objEStickers.CodigoStikerApostillador.UINullable;
               txtSerie.Text = objEStickers.Serie.UINullable;
               txtInicial.Text = objEStickers.CorrelativoInicial.UINullable;
               txtFinal.Text = objEStickers.CorrelativoFinal.UINullable;
               string pstrSituacion = objEStickers.SituacionRegistro.UINullable; 

               if (ddlSituacion.Items.FindByValue(pstrSituacion) != null) ddlSituacion.Items.FindByValue(pstrSituacion).Selected = true;
               if (ddlUbicacion.Items.FindByValue(objEStickers.CodigoUbicacionOficina.UINullable) != null) ddlUbicacion.Items.FindByValue(objEStickers.CodigoUbicacionOficina.UINullable).Selected = true;
               ddlUbicacion.Enabled = false;
               ddlApostillador.Items.Clear();
               ddlApostillador.Items.Insert(0, new ListItem(objEStickers.NombresApostillador.UINullable, objEStickers.CodigoApostillador.UINullable));
               ddlApostillador.Enabled = false;
               ddlOficina.Items.Clear();
               ddlOficina.Items.Insert(0, new ListItem(objEStickers.Oficina.UINullable, objEStickers.CodigoOficina.UINullable));
               ddlOficina.Enabled = false;

           }
       }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    void FillCargo(DropDownList ddlCargo)
    {
        try
        {
            CargarTabla(UIConstantes.PARAMETROS.TABLA_CARGO_APOSTILLADOR, ddlCargo);
            ddlCargo.Items.Insert(0, new ListItem("<Seleccione>", ""));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    void CargarTabla(int pitabla, DropDownList ddlCarga)
    {
        try
        {

            BParametro objParam = new BParametro();
            objParam.Constructor(Conexion);
            EParametro objEParametro = new EParametro();
            objEParametro.CodigoTabla = NullInt32.Create(pitabla);
            objEParametro.CodigoRegistro = NullInt32.Empty;
            objEParametro.CodigoParametro = NullInt32.Empty;
            DataTable dtopcionesPregOA = objParam._ListarParametros(objEParametro, string.Empty);

            ddlCarga.DataSource = dtopcionesPregOA;
            ddlCarga.DataTextField = "NOMBREPARAMETRO";
            ddlCarga.DataValueField = "CODIGOPARAMETRO";
            ddlCarga.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    void Insert()
    {
        try
        {
            int intSerie, intCorrIncial, intCorrFinal;
            #region validacion de datos numéricos
            
            try
            {
               intSerie= Convert.ToInt32(txtSerie.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Ingrese valor numérico a la serie.");
            }
            try
            {
                intCorrIncial=Convert.ToInt32(txtInicial.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Ingrese valor numérico a correlativo inicial.");
            }
            try
            {
                intCorrFinal=Convert.ToInt32(txtFinal.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Ingrese valor numérico a correlativo inicial.");
            }
            #endregion

            BStickerApostillador pbjBParam = new BStickerApostillador();
            EStickerApostillador pobjEParam = new EStickerApostillador();
            pbjBParam.Constructor(Conexion);
     
            pobjEParam.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
            pobjEParam.CodigoOficina = NullInt32.Create(ddlOficina.SelectedValue);
            pobjEParam.Serie = NullString.Create(intSerie.ToString());
            pobjEParam.CorrelativoInicial = NullString.Create(intCorrIncial.ToString());
            pobjEParam.CorrelativoFinal = NullString.Create(intCorrFinal.ToString());
            pobjEParam.SituacionRegistro = NullString.Create(ddlSituacion.SelectedValue); 
            pobjEParam.UsuarioOficinaPerfilRegistro=NullInt32.Create(varIdCodigoAuditoria);

            switch (OperacionActual)
            {
                case Operacion.Insertar: pbjBParam.InsertarStickerApostillador(pobjEParam); break;

                case Operacion.Modificar: pobjEParam.CodigoStikerApostillador = NullInt32.Create(txtCodigo.Text);
                                          pobjEParam.UsuarioOficinaPerfilModifica = NullInt32.Create(varIdCodigoAuditoria);
                                          pbjBParam.ModificarStickerApostillador(pobjEParam); break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
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

    
    #endregion

    #region Eventos


    protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            if(OperacionActual==Operacion.Insertar){
                    if (this.ddlUbicacion.SelectedIndex == 0) throw new Exception("Seleccione la ubicación de la oficina del Apostillador.");
                    if (this.ddlOficina.SelectedIndex == 0) throw new Exception("Seleccione la Oficina del Apostillador.");
                    if (this.ddlApostillador.SelectedIndex == 0) throw new Exception("Seleccione Apostillador."); 
            }

            if (txtSerie.Text.Length == 0) throw new Exception("Ingrese número de serie.");
            if (txtInicial.Text.Length == 0) throw new Exception("Ingrese número correlativo inicial de serie.");
            if (txtFinal.Text.Length == 0) throw new Exception("Ingrese número correlativo final de serie."); 

            Insert();
            Response.Redirect("FrmBandejaStikers.aspx");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
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
    #endregion

   
}

