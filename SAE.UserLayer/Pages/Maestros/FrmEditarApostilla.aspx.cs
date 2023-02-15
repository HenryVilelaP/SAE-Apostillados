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
using SAE.UInterfaces;
using SAE.Nullables;

public partial class Pages_Maestros_FrmEditarApostilla : UIPage
{
    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        
        base.OnLoad(e);
        try
        {
            if (!IsPostBack)
            {
                btnRegistrar.Visible = false;
                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);");
                this.btnCancelar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_on.gif',this);");
                this.btnCancelar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_off.gif',this);"); 
                
                if (Request.QueryString["idAct"] != null)
                {
                    btnRegistrar.Attributes.Add("onclick","return confirm('¿Está seguro de Actualizar la información?');");  
                    
                    if(Request.QueryString["idAct"].Trim().Length>0){
                        hidActuacion.Value =Request.QueryString["idAct"];
                        hidNumeroActuacionApostilla.Value = hidActuacion.Value;
                        OperacionActual = Operacion.Modificar;
                        CargarApostillador();
                        CargarFirmantes();
                        FillTipoDocumento();
                        GetApostilla();
                        ddlApostillador.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString());
        }
    }
    #endregion

    #region Procedimientos y Funciones

    void GetApostilla()
    {
        try
        {
            BActuacion objBActu = new BActuacion();
            EActuacion objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.CodigoActuacion = NullInt32.Create(hidActuacion.Value);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu,NullInt32.Empty);

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                {
                    hidNombreArchivo.Value = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);

                   

                    lblNumeroApostilla.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    txtFecha.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    txtOperacion.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]);
                    txtSerie.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);
                    txtNumeroStiker.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);
                    txtNumeroTicket.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROTICKET"]);
                    if (Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]).Trim().Length == 0)
                    {
                        //imgApos.Attributes.Add("onclick", "alert('No hay archivo pdf asociado a registro de Apostilla.');return false;");
                        //imgApos.ToolTip = "No hay archivo pdf asociado a registro de Apostilla.";
                      
                    }
                    //imgApos.CommandArgument = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);

                    if (ddlApostillador.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOAPOSTILLADOR"])) != null)
                        ddlApostillador.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOAPOSTILLADOR"])).Selected = true;

                    if (ddlFirmante.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOFIRMANTE"])) != null)
                        ddlFirmante.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOFIRMANTE"])).Selected = true;

                    if (ddlTipoDocumento.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOTIPODOCUMENTO"])) != null)
                        ddlTipoDocumento.Items.FindByValue(Convert.ToString(dtActuacion.Rows[0]["CODIGOTIPODOCUMENTO"])).Selected = true;

                    ddlFirmante.Enabled = false;
                    ddlTipoDocumento.Enabled = false;
                    txtOperacion.Enabled = false;
                    txtSerie.Enabled = false;
                    txtNumeroStiker.Enabled = false;
                    txtNumeroTicket.Enabled = false;
                    txtFecha.Enabled = false;
                    imbBtnCal.Enabled = false;

                    EActuacion pobjActuacion = new EActuacion();
                    pobjActuacion.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
                    pobjActuacion.CodigoFirmante = NullInt32.Create(ddlFirmante.SelectedValue);
                    pobjActuacion.CodigoTipoDocumento = NullInt32.Create(ddlTipoDocumento.SelectedValue);
                    pobjActuacion.OperacionBancaria = NullString.Create(txtOperacion.Text);
                    pobjActuacion.FechaApostilla = NullDateTime.Create(txtFecha.Text);
                    pobjActuacion.UsuarioModifica = NullInt32.Empty;
                    pobjActuacion.CodigoActuacion = NullInt32.Create(hidActuacion.Value);
                    pobjActuacion.Serie=NullString.Create(txtSerie.Text);
                    pobjActuacion.NumeroSerie = NullString.Create(txtNumeroStiker.Text);
                    
                   
                    ViewState["ActuacionEditarOriginal"] = pobjActuacion;
                    



                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void GetApostillaResult()
    {
        BActuacion objBActu = null;
        EActuacion objEActu =null;
        try
        {
            objBActu = new BActuacion();
            objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.CodigoActuacion = NullInt32.Create(hidActuacion.Value);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu, NullInt32.Empty);

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                {
                    //hidNombreArchivo.Value = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);
                    lblNumeroApostilla.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    lblFecha.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    this.lblNroOperacion.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]);
                    this.lblserie.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);
                    this.lblNumeroSerie.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);
                    imgApos2.CommandArgument = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);

                    this.lblAutoridad.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]);
                    this.lblApostillador.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);
                    this.lblTipoDoc.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRETIPODOCUMENTO"]);

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
    void CargarApostillador()
    {
        try
        {
            BApostillador objC = new BApostillador();
            EApostillador objEC = new EApostillador();

            objC.Constructor(Conexion);

            objEC.Materno = NullString.Empty;
            objEC.Paterno = NullString.Empty;
            objEC.Nombres = NullString.Empty;
            objEC.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);
            DataTable dt = objC.ListarApostilladores(objEC, NullInt32.Create(varIdOficinaActual ));

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
            ddlFirmante.Items.Insert(0, new ListItem("<Seleccione>", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void CargarTabla (int pitabla, DropDownList ddltabla)
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

            ddltabla.DataSource = dtopcionesPregOA;
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
            CargarTabla(UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR,  ddlTipoDocumento);
            ddlTipoDocumento.Items.Insert(0, new ListItem("<Seleccione>", ""));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void Actualizar()
    {
        string stringNombreDoc = "";
        try
        {
            Validacion();
            BActuacion pbjBParam = new BActuacion();
            EActuacion pobjActuacion = new EActuacion();
            pbjBParam.Constructor(Conexion);
            pobjActuacion.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
            pobjActuacion.CodigoFirmante = NullInt32.Create(ddlFirmante.SelectedValue);
            pobjActuacion.CodigoTipoDocumento = NullInt32.Create(ddlTipoDocumento.SelectedValue);
            pobjActuacion.OperacionBancaria = NullString.Create(txtOperacion.Text);
            pobjActuacion.Serie = NullString.Create(txtSerie.Text);
            pobjActuacion.NumeroSerie = NullString.Create(txtNumeroStiker.Text);
            pobjActuacion.FechaApostilla = NullDateTime.Create(txtFecha.Text);
            pobjActuacion.UsuarioModifica = NullInt32.Create(varIdCodigoAuditoria) ;
            pobjActuacion.CodigoActuacion = NullInt32.Create(hidActuacion.Value);

            switch (OperacionActual)
            {
                case Operacion.Modificar:
                    try
                    {
                        //string strNombreASubir = UpLoadPDF();
                        //pobjActuacion.NombreDocumento = NullString.Create(strNombreASubir);
                         
                        pobjActuacion.NombreDocumento = NullString.Empty;
                        pbjBParam.ModificarActuacion(pobjActuacion);
                    }
                    catch (Exception ex)
                    {
                        EActuacion oEActuacion = (EActuacion)ViewState["ActuacionEditarOriginal"];
                        if (oEActuacion != null) pbjBParam.ModificarActuacion(oEActuacion);
                        throw ex;
                    }
                    break;
            }
           
            pnActualizar.Visible=false;
            pnresultado.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpLoadPDFDelete(string strNombreArchivo)
    {
        try
        {
            string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
            //string ruta_archivo_del = Server.MapPath(carpeta + strNombreArchivo);// ruta fisica
            string ruta_archivo_del =  carpeta + strNombreArchivo;// ruta fisica
            if (File.Exists(ruta_archivo_del)) File.Delete(ruta_archivo_del);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public string UpLoadPDF()
    //{
    //    string strNombreASubir=string.Empty;
    //    try
    //    {
    //        if (fuApostilla.HasFile)
    //        {
    //            string nombreFichero;
    //            strNombreASubir = hidNombreArchivo.Value;

    //            //addon dbs 10/25/2010
    //            if (strNombreASubir.Trim().Length == 0)
    //            {
    //                string NeoNombreFile = (string)(lblNumeroApostilla.Text+DateTime.Now.Ticks.ToString()).Trim();
    //                strNombreASubir= NeoNombreFile + ".pdf";
    //            }
    //            //end addon dbs


    //            HttpPostedFile mifichero = fuApostilla.PostedFile;
    //            nombreFichero = Path.GetFileName(mifichero.FileName);

    //            string strExtension = Path.GetExtension(nombreFichero);
    //            strExtension = strExtension.ToLower();


    //            if (strExtension != ".pdf") throw new Exception("Seleccione solo documento  tipo PDF.");

    //            string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
    //            //string ruta_archivo = Server.MapPath(carpeta + strNombreASubir);// ruta fisica
    //            string ruta_archivo = carpeta + strNombreASubir;// ruta fisica

    //            if (File.Exists(ruta_archivo)) UpLoadPDFDelete(strNombreASubir);

    //            mifichero.SaveAs(ruta_archivo);
    //        }
            
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return strNombreASubir;

    //}

    void Validacion()
    {
        try
        {
            if (txtFecha.Text.Trim().Length == 0) throw new Exception("Ingrese fecha de la apostilla.");
            if (ddlFirmante.SelectedIndex == 0) throw new Exception("Seleccione la autoridad firmante del documento.");
            //if (ddlApostillador.SelectedIndex == 0) throw new Exception("Seleccione la persona que apostilla el documento.");
            if (ddlTipoDocumento.SelectedIndex == 0) throw new Exception("Seleccione tipo de documento a apostillar.");
            if (txtOperacion.Text.Trim().Length == 0) throw new Exception("Ingrese el numero de Operación bancaria.");
            if (txtSerie.Text.Trim().Length == 0) throw new Exception("Ingrese la serie.");
            if (txtNumeroStiker.Text.Trim().Length == 0) throw new Exception("Ingrese el número de la serie.");
            //   if (!(fuApostilla.HasFile)) throw new Exception("Seleccione documento adjuntar para la apostilla.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Eventos

    protected void imgApos_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton lnkVerPDF = (ImageButton)sender;
            string FilePDF = Convert.ToString(lnkVerPDF.CommandArgument);
            if (FilePDF.Trim().Length == 0) throw new Exception("No hay PDF asociado a Apostilla.");
           
            string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
             
            string ruta_archivo = carpeta + FilePDF;// ruta fisica
            if (!(File.Exists(ruta_archivo))) throw new Exception("No hay archivo PDF asociado a Apostilla..");
            Response.AddHeader("content-disposition", "attachment; filename=" + FilePDF);
            Response.ContentType = "Application/pdf";
            Response.WriteFile(ruta_archivo);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(1, ex.Message.ToString());
        }
    }
    protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           Actualizar();
           GetApostillaResult();
           btnCancelar.Visible = false;
           btnRegistrar.Visible = false;
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString()); 
        }
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("FrmBandejaApostillados.aspx",  false);
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
    }
    #endregion

}
