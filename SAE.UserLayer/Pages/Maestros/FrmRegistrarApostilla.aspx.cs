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

using System.Drawing;
//using ExpertPdf.HtmlToPdf;

public partial class Pages_Maestros_FrmRegistrarApostilla : UIPage
{
    //Agregado por: Edgar Huarcaya C.
    private const string K_TIPO_LEGALIZA = "_Legaliza";
    private const string K_TIPO_APORTILLA = "_Apostilla";
        
    #region INICIO

    public string NumeroApostilladoGenerado{
        get{
        return (string)ViewState["_numero_apostillado"];
        }
        set{
            ViewState["_numero_apostillado"]=value;
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        
        base.OnLoad(e);
        try
        {
            txtSerie.ReadOnly = true;
            txtNumeroStiker.ReadOnly = true;
            fuApostilla.Visible = false;

           if (!IsPostBack)
            {

                if (Request.QueryString["pstrTipTram"] != null) Session[K_TIPO_LEGALIZA] = Request.QueryString["pstrTipTram"];

                imgBtnNext.Attributes.Add("onclick", "return confirm('¿Está seguro de Apostillar?');");
                imgBtnAnular.Attributes.Add("onclick", "return confirm('¿Está seguro de Anular el registro de Apostilla?');");
                NumeroApostilladoGenerado = string.Empty;
                txtFecha.Text = DateTime.Now.ToShortDateString();
               

               //boton cancelar
                this.imgBtnAnular.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_on.gif',this);");
                this.imgBtnAnular.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_off.gif',this);");
               //boton finalizar 
                this.imgBtnNext.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BFinalizar_on.gif',this);");
                this.imgBtnNext.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BFinalizar_off.gif',this);");
               //boton atrás
                this.imgBtnBack.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BBack_on.gif',this);");
                this.imgBtnBack.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BBack_off.gif',this);");
                //boton Siguiente
                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BNext_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BNext_off.gif',this);");
                btnRegistrar.Attributes.Add("onclick","return validate_paso1();"); 
               //boton cancelar primer paso
                this.btnCancelar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_on.gif',this);");
                this.btnCancelar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BCancelar_off.gif',this);"); 
                
                CargarApostillador();
                CargarFirmantes();
                FillTipoDocumento();
                OperacionActual = Operacion.Insertar;
                VisiblePaso(1);

            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString());
        }
    }

    #endregion

    #region Procedimientos y Funciones

    void VisiblePaso(int NumeroPaso)
    {
        switch(NumeroPaso){

            case 1: pnStep1.Visible = true;
                    pnStep2.Visible = false;
                    pnStep3.Visible = false;
                    break;
            case 2: pnStep1.Visible = false;
                    pnStep2.Visible = true;
                    pnStep3.Visible = false;
                    break;
            case 3: pnStep1.Visible = false;
                    pnStep2.Visible = false;
                    pnStep3.Visible = true;
                    break;
            default: pnStep1.Visible = true;
                    pnStep2.Visible = false;
                    pnStep3.Visible = false;
                    break;

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
            DataTable dt = objC.ListarApostilladores(objEC,NullInt32.Empty );

            ddlApostillador.DataSource = dt;
            ddlApostillador.DataTextField = "NOMBRES";
            ddlApostillador.DataValueField = "CODIGOAPOSTILLADOR";
            ddlApostillador.DataBind();

            //ADDON DBS 06 20 2010 : SI ES APOSTILLADOR SE BLOQUEA Y APARECE POR DEFAULT SU NOMBRE
            if (UIConstantes.Perfil.APOSTILLADOR == varIdPerfilActual.ToString())
            {
                ddlApostillador.Enabled = false;
                string pCodigoUsuarioActual = (((EUsuario)Usuario).CodigoUsuario.UINullable);

                if (ddlApostillador.Items.FindByValue(pCodigoUsuarioActual) != null)
                {
                    ddlApostillador.Items.FindByValue(pCodigoUsuarioActual).Selected = true;
                }
                else
                {
                    ddlApostillador.Items.Clear();
                    btnRegistrar.ToolTip = "Opción deshabilitada. Usuario No se encuentra asignado como apostillador.";
                    btnRegistrar.Enabled = false;
                    throw new Exception("El usuario que ha ingresado al sistema no está asignado como Apostillador. Ud no podrá Apostillar");
                }
            }
            else
            {
                ddlApostillador.Items.Insert(0, new ListItem("<Seleccione>", "0"));
            }
           //END ADDON

            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void CargarFirmantes()
    {
        BFirmante objC = null;
        EFirmante objEC = null;
        try
        {
            objC = new BFirmante();
            objEC = new EFirmante();

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
        finally
        {
            objC = null;
            objEC = null;
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

            if (UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR == pitabla)
            {
                DataView dvDataSort;
                dvDataSort = new DataView(dtopcionesPregOA);
                dvDataSort.Sort="NOMBREPARAMETRO ASC";
                ddltabla.DataSource = dvDataSort;
                
            }else{
                ddltabla.DataSource = dtopcionesPregOA;
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
            CargarTabla(UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR,  ddlTipoDocumento);
            ddlTipoDocumento.Items.Insert(0, new ListItem("<Seleccione>", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected string RegistrarPaso1()
    {

        try
        {
            ValidacionPaso1();
            BActuacion pbjBParam = new BActuacion();
            EActuacion pobjActuacion = new EActuacion();
            pbjBParam.Constructor(Conexion);


            pobjActuacion.CodigoApostillador = NullInt32.Create(ddlApostillador.SelectedValue);
            pobjActuacion.CodigoFirmante = NullInt32.Create(ddlFirmante.SelectedValue);
            pobjActuacion.CodigoTipoDocumento = NullInt32.Create(ddlTipoDocumento.SelectedValue);
            pobjActuacion.OperacionBancaria = NullString.Create(txtOperacion.Text);
            pobjActuacion.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Inactivo);
            pobjActuacion.CodigoOficina = NullInt32.Create(varIdOficinaActual);
            pobjActuacion.NumeroTicket = NullString.Create(txtNumeroTicket.Text);
           
           if (Request.Form["ctl00$cphCuerpo$txtFecha"] != null){
                pobjActuacion.FechaApostilla = NullDateTime.Create(Request.Form["ctl00$cphCuerpo$txtFecha"]);
                txtFecha.Text = Request.Form["ctl00$cphCuerpo$txtFecha"];
            }
            else{
                throw new Exception("Seleccione Fecha."); 
            }


            pobjActuacion.UsuarioOficinaPerfilRegistro = NullInt32.Create(varIdCodigoAuditoria);

            if (NumeroApostilladoGenerado.Length > 0)
            {
                pobjActuacion.NumeroApostilla = NullString.Create(NumeroApostilladoGenerado);
                pobjActuacion.UsuarioOficinaPerfilModifica = NullInt32.Create(varIdCodigoAuditoria);
                OperacionActual = Operacion.Modificar;
            }

            GenerarCorrelativo(Convert.ToInt32( ddlApostillador.SelectedValue), varIdOficinaActual);

            switch (OperacionActual)
            {
                case Operacion.Insertar: if (NumeroApostilladoGenerado.Length == 0) NumeroApostilladoGenerado = pbjBParam.InsertarActuacion(pobjActuacion); break;
                case Operacion.Modificar: pbjBParam.ModificarActuacion_X_NumApostilla(pobjActuacion); break;
            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return NumeroApostilladoGenerado;

    }
    public void GenerarCorrelativo(int pintCodigoApostillador, int pintCodigoOficina){
          
            var pbjBParam = (BActuacion)null;
            var pobjActuacion = (EActuacion)null;

        try{
              pbjBParam = new BActuacion();
             pobjActuacion = new EActuacion();
            pbjBParam.Constructor(Conexion);

            pobjActuacion.CodigoApostillador = NullInt32.Create(pintCodigoApostillador);
            pobjActuacion.CodigoOficina = NullInt32.Create(pintCodigoOficina);
           
            DataTable dtCorrelativo = pbjBParam.ObtieneCorrelativoSerie(pobjActuacion);
            if (dtCorrelativo != null)
            {
                if (dtCorrelativo.Rows.Count == 1)
                {
                    txtNumeroStiker.Text = Convert.ToString(dtCorrelativo.Rows[0]["CORRELATIVOSERIE"]);
                    txtSerie.Text = Convert.ToString(dtCorrelativo.Rows[0]["SERIE"]);
                }
                else
                   throw new Exception("Error al Generar Correlativo de sticker b.");
            }
            else
                throw new Exception("Error al Generar Correlativo de sticker.");

        } catch (Exception ex)
        {
            throw ex;
        }finally{

            pbjBParam=null;
            pobjActuacion=null;
        }

    }

    //METODOS COMENTADOS SUBIR PDF
    //public void UpLoadPDFDelete(string strNombreArchivo)
    //{
    //    try
    //    {
    //        string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
    //        //string ruta_archivo_del = Server.MapPath(carpeta + strNombreArchivo);// ruta fisica
    //        string ruta_archivo_del =   carpeta + strNombreArchivo ;// ruta fisica
    //        if (File.Exists(ruta_archivo_del)) File.Delete(ruta_archivo_del);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    //public string UpLoadPDF(string strNombreASubir)
    //{

    //    string nombreFichero, strNombreArchivo;
    //    try
    //    {

    //        if (fuApostilla.HasFile)
    //        {
    //            HttpPostedFile mifichero = fuApostilla.PostedFile;
    //            nombreFichero = Path.GetFileName(mifichero.FileName);

    //            string strExtension = Path.GetExtension(nombreFichero);
    //            strNombreArchivo = strNombreASubir;// Path.GetFileNameWithoutExtension(nombreFichero);
    //            strExtension = strExtension.ToLower();

    //            strNombreArchivo = strNombreArchivo + strExtension;

    //            if (strExtension != ".pdf") throw new Exception("Seleccione solo documento  tipo PDF.");
    //            string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
                
    //            //string ruta_archivo = Server.MapPath(carpeta + strNombreArchivo);// ruta fisica
    //            string ruta_archivo = carpeta + strNombreArchivo;// ruta fisica
                

    //            if (File.Exists(ruta_archivo)) throw new Exception("El nombre del archivo ha subir ya existe.");

    //            mifichero.SaveAs(ruta_archivo);
    //        }
    //        else
    //        {
    //            throw new Exception("Seleccione archivo pdf para subir.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //    return strNombreArchivo;
    //}

    void ValidacionPaso1()
    {
        try
        {
            if (txtFecha.Text.Trim().Length == 0) throw new Exception("Ingrese fecha de la apostilla.");
            if (ddlFirmante.SelectedIndex == 0) throw new Exception("Seleccione la autoridad firmante del documento.");

            if (UIConstantes.Perfil.APOSTILLADOR != varIdPerfilActual.ToString())
            {
                if (ddlApostillador.SelectedIndex == 0) throw new Exception("Seleccione la persona que apostilla el documento.");
            }
            if (ddlTipoDocumento.SelectedIndex == 0) throw new Exception("Seleccione tipo de documento a apostillar.");
            if (txtOperacion.Text.Trim().Length == 0) throw new Exception("Ingrese el número de Operación bancaria.");
            if (txtNumeroTicket.Text.Trim().Length == 0) throw new Exception("Ingrese el número de Ticket.");

            
          
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void ValidacionPaso2()
    {
        try
        {
            //if (txtFecha.Text.Trim().Length == 0) throw new Exception("Ingrese fecha de la apostilla.");
            //if (ddlFirmante.SelectedIndex == 0) throw new Exception("Seleccione la autoridad firmante del documento.");
            //if (ddlApostillador.SelectedIndex == 0) throw new Exception("Seleccione la persona que apostilla el documento.");
            //if (ddlTipoDocumento.SelectedIndex == 0) throw new Exception("Seleccione tipo de documento a apostillar.");
            if (txtSerie.Text.Trim().Length == 0) throw new Exception("El sistema no ha generado la serie.");
            if (txtNumeroStiker.Text.Trim().Length == 0) throw new Exception("El sistema no ha generado el número de la serie.");
           // if (!(fuApostilla.HasFile)) throw new Exception("Seleccione documento adjuntar para la apostilla.");

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void ResultadoFinal()
    {
        try
        {
            BActuacion objBActu = new BActuacion();
            EActuacion objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.NumeroApostilla = NullString.Create(NumeroApostilladoGenerado);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu,NullInt32.Empty );

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                {
                    lblNumeroApostillaStep3.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    lblFirmanteStep3.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]);
                    lblFechaStep3.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    lblApostilladorStep3.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);
                    lblOperacionStep3.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]);
                    lblTipoDocumentoStep3.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRETIPODOCUMENTO"]);
                    lblSerie.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);
                    lblNumeroSerie.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);
                    lblTicketStep3.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROTICKET"]);
                    lblTipoDocumentoStep3.Text = lblTipoDocumentoStep3.Text + "&nbsp;&nbsp;(" + lblPrecio.Text + ")";
                    lblFirmanteStep3.Text = lblFirmanteStep3.Text + "&nbsp;&nbsp;(" + lblCargoAutoridad.Text + "&nbsp;,&nbsp;" + lblEntidad.Text + ")"; 
                    //addon dbs 25/10/2010
                   // imgApos.CommandArgument = Convert.ToString(dtActuacion.Rows[0]["NOMBREDOCUMENTO"]);

                }

            }
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
            string FilePDF = Convert.ToString(lnkVerPDF.CommandArgument);
            if (FilePDF.Trim().Length == 0) throw new Exception("No hay PDF asociado a Apostilla registrada.");

            string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"];
            //string ruta_archivo = Server.MapPath(carpeta + FilePDF);// ruta fisica
            string ruta_archivo = carpeta + FilePDF;// ruta fisica
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
        var boficina = (BOficina)null;
        try
        {

            string strnumeroApostillaGenerado = RegistrarPaso1();

            BActuacion objBActu = new BActuacion();
            EActuacion objEActu = new EActuacion();
            objBActu.Constructor(Conexion);
            objEActu.NumeroApostilla = NullString.Create(strnumeroApostillaGenerado);
            DataTable dtActuacion = objBActu.ListarActuaciones(objEActu, NullInt32.Empty);

            if (dtActuacion != null)
            {
                if (dtActuacion.Rows.Count == 1)
                { 
                    
                    lblNumeroApostilla.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    lblFirmante.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]);
                    lblFecha.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    lblApostillador.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);
                    lblOperacion.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]);
                    lblTipoDocumento.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRETIPODOCUMENTO"]);
                    lblOperacion.Text = Convert.ToString(dtActuacion.Rows[0]["OPERACIONBANCARIA"]);
                    lblTicket.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROTICKET"]);

                    lblTipoDocumento.Text = lblTipoDocumento.Text + "&nbsp;&nbsp;(" + lblPrecio.Text + ")";
                    lblFirmante.Text = lblFirmante.Text + "&nbsp;&nbsp;(" + lblCargoAutoridad.Text + "&nbsp;,&nbsp;" + lblEntidad.Text + ")"; 

                    hidNumeroActuacionApostilla.Value = Convert.ToString(dtActuacion.Rows[0]["CODIGOACTUACION"]);


                    #region Vista APostilla

                    //muestra datos de la ApostillaPreView en previen
                    lblPais.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaPais"]);
                    lblAt.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaLugar"]);
                    lblBy.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                    lblMRE.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                    lblDireccion.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaFirmaDir"]);
                    //addon dbs datos de la oficina actual
                    boficina = new BOficina();
                    boficina.Constructor(Conexion);
                    IEOficina objEOficina = boficina.ObtenerOficina(NullInt32.Create(varIdOficinaActual));
                    if (objEOficina == null) { throw new Exception("No se pudo obtener el nombre de la oficina actual."); }
                    lblAt.Text = objEOficina.NombreOficina.ToUpper();
                    //end datos oficina actual



                    lblThe.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                    lblNro.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                    lblFirma.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]).ToUpper();
                    lblApostillador.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);
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
                    lblSeries.Text = txtSerie.Text;
                    lblNumeroCorrelativo.Text = txtNumeroStiker.Text;
                    //imgFirma.ImageUrl = string.Format("frmVerFirma.aspx?idApos={0}", Convert.ToString(dtActuacion.Rows[0]["CODIGOAPOSTILLADOR"]));
                    string strRutaCompartido = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaFirmas"];
                    string strNombreFile = Convert.ToString(dtActuacion.Rows[0]["NOMBREARCHIVOFIRMA"]);
                    string strRutaCompleta = strRutaCompartido + strNombreFile;
                    imgFirma.ImageUrl = strRutaCompleta;
                    ////fin datos apostillado preview
                    #endregion fin vista

                    VisiblePaso(2);

                }

            }


        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
        finally
        {
            boficina = null;
        }
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        BActuacion pbjBParam = null;
        try
        {
            if (NumeroApostilladoGenerado.Length > 0)
            {
                pbjBParam = new BActuacion();
                pbjBParam.Constructor(Conexion);
                pbjBParam.EliminarActuacionXnumeroApostilla(NumeroApostilladoGenerado);
                Response.Redirect("FrmRegistrarApostilla.aspx", false);
            }
            else
            {
                VisiblePaso(1);

                txtFecha.Text = DateTime.Now.ToShortDateString();
                txtOperacion.Text = string.Empty;
                lblCargoAutoridad.Text = string.Empty;
                lblPrecio.Text = string.Empty; 

                ddlFirmante.ClearSelection();
                ddlApostillador.ClearSelection();
                ddlTipoDocumento.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message);
        }
        finally
        {
            pbjBParam = null;
        }
    }

  
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
     {
         try
         {
             VisiblePaso(1);
 
         }
         catch (Exception ex)
         {
             CScript.MessageBox(0, ex.Message);
         }
     }
    protected void btnNextGrabarFinal_Click(object sender, ImageClickEventArgs e)
     {
         string strNombreArchivo = string.Empty;
         try
         {
             ValidacionPaso2();
             BActuacion pbjBParam = null;
             try
             {
                 if (this.NumeroApostilladoGenerado.Length == 0) throw new Exception("Error de Sistema: No se ha generado el Numero del Apostilla.");

                 //string NeoNombreFile = NumeroApostilladoGenerado + DateTime.Now.Ticks.ToString();
                 //strNombreArchivo = NeoNombreFile+".pdf";
                 /////creamos el pdf
                 //CrearPDF(NumeroApostilladoGenerado, strNombreArchivo);


                 //actualizamos el registro como apostilla finalizado y registramos la serie y correlativo
                 pbjBParam = new BActuacion();
                 pbjBParam.Constructor(Conexion);
                 pbjBParam.ActualizarNombreArchivoApostilla(NumeroApostilladoGenerado, strNombreArchivo, UIConstantes.Situacion.Activo, txtSerie.Text, txtNumeroStiker.Text);

                

                 // muestra el resultado final del proceso
                 ResultadoFinal();
                 VisiblePaso(3);

                 //limpia el numero de apostilla generado para iniciar otro proceso de apostilla
                 NumeroApostilladoGenerado = string.Empty;
             }
             catch (Exception ex)
             {
                 //deshacemos los cambios
                 //UpLoadPDFDelete(strNombreArchivo);
                 pbjBParam = new BActuacion();
                 pbjBParam.Constructor(Conexion);
                 pbjBParam.ActualizarNombreArchivoApostilla(NumeroApostilladoGenerado, string.Empty,UIConstantes.Situacion.Inactivo,string.Empty,string.Empty  );
                 //
                 throw ex;
             }
             finally
             {
                 pbjBParam = null;
             }
         }
         catch (Exception ex)
         {
             CScript.MessageBox(0, ex.Message);
         }
     }
    protected void btnAnularApostilla_Click(object sender, ImageClickEventArgs e)
    {
        BActuacion pbjBParam = null;
        try{
            
            
            if (NumeroApostilladoGenerado.Length > 0)
            {
                pbjBParam = new BActuacion();
                pbjBParam.Constructor(Conexion);
                pbjBParam.EliminarActuacionXnumeroApostilla(NumeroApostilladoGenerado);
                Response.Redirect("FrmRegistrarApostilla.aspx", false);
            }
            
        }
        catch (Exception ex){
           
            CScript.MessageBox(0, ex.Message);

        }finally{

            pbjBParam = null;
       }
     }

    //void CrearPDF(string pstrNumApos,string pstrNombrePdf)
    //{
    //    try
    //    {
    //        PdfConverter pdfConverter = new PdfConverter();
    //        pdfConverter.PdfDocumentOptions.ShowHeader = false;

    //        pdfConverter.PdfFooterOptions.FooterText = "Sample footer: XXXXXXX     You can change color, font and other options";
    //        pdfConverter.PdfFooterOptions.FooterTextColor = Color.Blue;
    //        pdfConverter.PdfFooterOptions.DrawFooterLine = false;
    //        pdfConverter.PdfFooterOptions.ShowPageNumber = false;

    //        //pdfConverter.LicenseKey = "put your serial number here";
    //         string strRutaFileWeb=Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DirPageWeb"]);
    //         string url = string.Format(strRutaFileWeb + "/Pages/Maestros/FrmVistaApostillaPDF.aspx?id_NumApostilla={0}&id_Oficina={1}", pstrNumApos,varIdOficinaActual.ToString());
    //         string path_file_server = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaApostillas"]);
           
    //         pdfConverter.SavePdfFromUrlToFile(url, path_file_server + pstrNombrePdf);

          
            

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
  
    #endregion

    #region Eventos AJAX

    public void BuscarTarifa(object sender, EventArgs e)
    {
        try
        {
            BParametro objParam = new BParametro();
            EParametro objEparam = new EParametro();
            objParam.Constructor(Conexion);
            objEparam.CodigoParametro = NullInt32.Create(ddlTipoDocumento.SelectedValue);
            objEparam.CodigoTabla = NullInt32.Create(-1);
            objEparam.CodigoRegistro = NullInt32.Create(-1);
            DataTable dtParam = objParam._ListarParametros(objEparam, UIConstantes.Situacion.Todos);

            if (dtParam != null)
            {

                switch (dtParam.Rows.Count)
                {
                    case 1: lblPrecio.Text = "&nbsp;Tarifa : " + Convert.ToString(dtParam.Rows[0]["VALORTEXTO"]) + "&nbsp;" + Convert.ToString(dtParam.Rows[0]["VALORNUMERICO"]);
                        break;
                    case 0: lblPrecio.Text = string.Empty;
                        break;
                    default: lblPrecio.Text = string.Empty;
                        throw new Exception("Existen varias tarifas asociados al tipo de documento.");

                }

            }
            else
            {
                throw new Exception("No se obtuvo resultados de la búsqueda.");
            }
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message, upCargaPrecio);
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
            CScript.MessageBox(0, ex.Message, upCargoAutoridad);
        }


    }

    #endregion
}




