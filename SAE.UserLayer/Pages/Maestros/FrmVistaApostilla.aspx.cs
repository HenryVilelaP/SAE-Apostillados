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
public partial class Pages_Maestros_FrmVistaApostilla : UIPage
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //var obBParam = (BParametro)null;
        //var obEParam = (EParametro)null;
        var boficina = (BOficina)null;
        try
        {
            ValidarSesion();
        }
        catch (Exception ex)
        {
            Response.Write("<center>" + ex.Message + "<br>Cierre esta ventana y vuelva ingresar al sistema.<br><a href=# onclick='window.close();'>cerrar</a></center>");
            Response.End();
        }
        try
        {
            if (!(Page.IsPostBack))
            {
                if (Request.QueryString["idTicketAct"] != null)
                {

                    //obBParam = new BParametro();
                    //obEParam = new EParametro();
                    //obEParam.CodigoTabla = NullInt32.Create(UIConstantes.PARAMETROS.TABLA_CONFIGURACION_SISTEMA);
                    //obEParam.CodigoRegistro = NullInt32.Create(UIConstantes.CONFIGURACION.RUTA_WEB_STICKER_APOSTILLA);
                    //obEParam.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);
                    //obBParam.Constructor(Conexion);
                    //IEParametro oparamcollect = obBParam.ObtenerParametro(obEParam);
                    //if(oparamcollect!=null)lbllink.Text = oparamcollect.Valortexto.UINullable.ToLower();
                 
                    

                    string srtNumeroActuacion = Request.QueryString["idTicketAct"];
                    BActuacion objact = new BActuacion();
                    EActuacion objeAct = new EActuacion();
                    objeAct.CodigoActuacion = NullInt32.Create(srtNumeroActuacion);
                    objact.Constructor(Conexion);
                    DataTable dtActuacion = objact.ListarActuaciones(objeAct, NullInt32.Empty);
                                                                              
                    
                    if (dtActuacion != null)
                    {
                        if (dtActuacion.Rows.Count == 1)
                        {
                            boficina = new BOficina();
                            boficina.Constructor(Conexion);
                            IEOficina objEOficina=boficina.ObtenerOficina(NullInt32.Create(varIdOficinaActual));
                            if (objEOficina == null) {  throw new Exception("No se pudo obtener el nombre de la oficina actual."); }
                            lblAt.Text = objEOficina.NombreOficina.ToUpper() ;


                            lblPais.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaPais"]);
                            lblBy.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                            lblMRE.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaEntidad"]);
                            lblDireccion.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["VistaApostillaFirmaDir"]);
                            lbllink.Text = Convert.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["LinkConsultaWeb"]);



                            lblThe.Text = Convert.ToDateTime(dtActuacion.Rows[0]["FECHAAPOSTILLA"]).ToShortDateString();
                            lblNro.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROAPOSTILLA"]);
                            lblFirma.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESFIRMANTE"]).ToUpper();
                            lblApostillador.Text = Convert.ToString(dtActuacion.Rows[0]["NOMBRESAPOSTILLADOR"]);
                            lblSerie.Text = Convert.ToString(dtActuacion.Rows[0]["SERIE"]);
                            lblNumeroCorrelativo.Text = Convert.ToString(dtActuacion.Rows[0]["NUMEROSERIE"]);

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

                            string strRutaCompartido = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaFirmas"];
                            string strNombreFile = Convert.ToString(dtActuacion.Rows[0]["NOMBREARCHIVOFIRMA"]);
                            string strRutaCompleta = strRutaCompartido + strNombreFile;
                            imgFirma.ImageUrl = strRutaCompleta;

                            if (Request.QueryString["signature"] != null)
                            {
                                if (Request.QueryString["signature"] == "0") imgFirma.Visible = false;
                            }

                            objParam = null;
                            objEparam = null;
                        }
                    }
                    objact = null;
                    objeAct = null;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            Response.End();
        }
        finally
        {
             //obBParam = null;
             //obEParam = null;
             boficina = null;
        }

    }
    protected void ValidarSesion()
    {
        String _url = Request.ApplicationPath + System.Web.Configuration.WebConfigurationManager.AppSettings["RutaLogin"];
        try
        {
            if (Session["Usuario"] == null)
            {
                Session.RemoveAll();
                Session.Abandon();
                throw new Exception("Su sesión ha finalizado");
            }

        }
        catch (System.NullReferenceException ex)
        {
            if (Context.Session.Equals(null))
            {
                throw new Exception("Su sesión ha finalizado");
            }
            else
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
