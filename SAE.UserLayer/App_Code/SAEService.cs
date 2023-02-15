using System;
using System.Data;
using System.Collections.Generic ;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using SAE.BusinessLayer;
using SAE.EntityLayer ;
using SAE.EntityLayer.Collections;
using SAE.UInterfaces;
using SAE.Nullables; 

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
//[WebService(Namespace = "http://microsoft.com/webservices")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]




public class SAEService : System.Web.Services.WebService
{
    private const string K_SEPARARADOR = " - ";

    public SAEService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetNombresUsuariosB(string prefixText, int count)
    {


        BUsuario objUsuario = null;
        EUsuario objEUsuario = null;
        IEUsuarioCollection objColl = null;
        try
        {
            objUsuario = new BUsuario();
            objEUsuario = new EUsuario();

            objEUsuario.Codigo = NullInt32.Empty;
            objEUsuario.SituacionRegistro = NullString.Empty;
            objEUsuario.Dominio = NullString.Empty;
            objEUsuario.UsuarioRed = NullString.Empty;


            objUsuario.Constructor(new UIPage().Conexion);
            objColl = objUsuario.ListarUsuarios(objEUsuario, NullInt32.Empty);


            List<string> responses = new List<string>();
            foreach (IEUsuario objeusu in objColl.Valores)
            {
                if (objeusu.NombreCompleto.UINullable.ToUpper().StartsWith(prefixText.ToUpper()))
                //if (objeusu.NombreCompleto.UINullable.ToUpper().IndexOf(prefixText.ToUpper())!=-1)
                    responses.Add(objeusu.NombreCompleto.UINullable);
            }

            return responses.ToArray();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    
    
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetNombresUsuarios(string prefixText, int count)
    {


        BUsuario objUsuario = null;
        EUsuario objEUsuario = null;
        IEUsuarioCollection objColl = null;
        try
        {
            objUsuario = new BUsuario();
            objEUsuario = new EUsuario();

            objEUsuario.Codigo = NullInt32.Empty;
            objEUsuario.SituacionRegistro = NullString.Empty;
            objEUsuario.Dominio = NullString.Empty;
            objEUsuario.UsuarioRed = NullString.Empty;


            objUsuario.Constructor(new UIPage().Conexion);
            objColl = objUsuario.ListarUsuarios(objEUsuario,NullInt32.Empty );


            List<string> responses = new List<string>();
            foreach (IEUsuario objeusu in objColl.Valores)
            {
                if (objeusu.NombreCompleto.UINullable.ToUpper().StartsWith(prefixText.ToUpper()))
                    //if (objeusu.NombreCompleto.UINullable.ToUpper().IndexOf(prefixText.ToUpper())!=-1)
                    responses.Add(objeusu.NombreCompleto.UINullable);
            }

            return responses.ToArray();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }


    
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetNombresAutoridadFirmante(string prefixText, int count)
    {


        BFirmante objC = null;
        EFirmante objEC = null;

        try
        {
            objC = new BFirmante();
            objEC = new EFirmante();

            objC.Constructor(new UIPage().Conexion);

            objEC.Materno = NullString.Empty;
            objEC.Paterno = NullString.Empty;
            objEC.Nombres = NullString.Empty;
            objEC.SituacionRegistro = NullString.Create(UIConstantes.Situacion.Activo);
            DataTable dtAutoridadesFirmates = objC.ListarFirmantes(objEC);





            List<string> responses = new List<string>();

            foreach (DataRow Autoridad in dtAutoridadesFirmates.Rows)
            {
                if (Convert.ToString(Autoridad["NOMBRES"]).ToUpper().StartsWith(prefixText.ToUpper()))
                        responses.Add(Convert.ToString(Autoridad["NOMBRES"]));
            }

            return responses.ToArray();

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

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetNombresTipoDocumento(string prefixText, int count)
    {


        BParametro objParam = null;
        EParametro objEParametro = null;

        try
        {
            objParam = new BParametro();
            objEParametro = new EParametro();

            objParam.Constructor(new UIPage().Conexion);

            objEParametro.CodigoTabla = NullInt32.Create(UIConstantes.PARAMETROS.TABLA_DOCUMENTO_APOSTILLAR);
            objEParametro.CodigoRegistro = NullInt32.Empty;
            objEParametro.CodigoParametro = NullInt32.Empty;
            DataTable dtTipoDocumentos = objParam._ListarParametros(objEParametro, string.Empty);


            List<string> responses = new List<string>();

            foreach (DataRow documentos in dtTipoDocumentos.Rows)
            {
                if (Convert.ToString(documentos["NOMBREPARAMETRO"]).ToUpper().StartsWith(prefixText.ToUpper()))
                    responses.Add(Convert.ToString(documentos["NOMBREPARAMETRO"]));
            }

            return responses.ToArray();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objParam = null;
            objEParametro = null;
        }

    }
    
 
}

