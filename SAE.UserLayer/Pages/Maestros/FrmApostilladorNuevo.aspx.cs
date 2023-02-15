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

public partial class Pages_Maestros_FrmApostilladorNuevo : UIPage
{


    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        try
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                this.btnRegistrar.Attributes.Add("onclick", "return confirm('¿Está seguro de actualizar la Firma del apostillador?');");
                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);");
                CargarSituacion();
                //FillCargo(ddlCargo);
                 if (Request.QueryString["strParami"] != null) hidCodigoApostillador.Value = Request.QueryString["strParami"];

            if (Request.QueryString["xopc"] != null)
            {
                        if (Request.QueryString["xopc"] == "upParam")
                        {
                            lblTitulo.Text = "Actualizar Firma del Apostillador";
                            OperacionActual = Operacion.Modificar;
                            FillApostilladorEditar();
                        }
                        else
                        {
                            lblTitulo.Text = "Registro de Apostillador";
                            OperacionActual = Operacion.Insertar;
                        }
            }
            else
            {
                lblTitulo.Text = "Registro de Apostillador";
                OperacionActual = Operacion.Insertar;
            }
            ddlSituacion.Enabled = false; 
            }
      
       }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }

    #endregion


    #region Metodos
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
           BApostillador objParam = new BApostillador();
           objParam.Constructor(Conexion);
           EApostillador objEApostillador = new EApostillador();
           objEApostillador.CodigoApostillador = NullInt32.Create(hidCodigoApostillador.Value);
           objEApostillador.Materno = NullString.Empty;
           objEApostillador.Paterno = NullString.Empty;
           objEApostillador.Dni = NullInt32.Empty;
           DataTable dtApostillador = objParam.ListarApostilladores(objEApostillador, NullInt32.Empty);

           if (dtApostillador.Rows.Count == 1)
           { 
               txtCodigo.Text = Convert.ToString( dtApostillador.Rows[0]["CODIGOAPOSTILLADOR"]);
               txtNombre.Text = Convert.ToString(dtApostillador.Rows[0]["NOMBRE"]);
               txtPaterno.Text= Convert.ToString(dtApostillador.Rows[0]["PATERNO"]);
               txtMaterno.Text = Convert.ToString(dtApostillador.Rows[0]["MATERNO"]);
              
               // txtDNI.Text = Convert.ToString(dtApostillador.Rows[0]["DNI"]);
               //if (ddlCargo.Items.FindByValue(Convert.ToString(dtApostillador.Rows[0]["CODIGOCARGO"])) != null)
               //    ddlCargo.Items.FindByValue(Convert.ToString(dtApostillador.Rows[0]["CODIGOCARGO"])).Selected = true;

               string pstrSituacion = Convert.ToString(dtApostillador.Rows[0]["SITUACION"]);
               if (ddlSituacion.Items.FindByValue(pstrSituacion) != null) ddlSituacion.Items.FindByValue(pstrSituacion).Selected = true; 
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
            BApostillador pbjBParam = new BApostillador();
            EApostillador pobjEParam = new EApostillador();
            pbjBParam.Constructor(Conexion);
           // pobjEParam.CodigoCargo = NullInt32.Create(ddlCargo.SelectedValue);
            pobjEParam.SituacionRegistro = NullString.Create( ddlSituacion.SelectedValue  ); 

            switch (OperacionActual)
            {
                case Operacion.Modificar:
                                            pobjEParam.UsuarioOficinaPerfilModifica=NullInt32.Create(varIdCodigoAuditoria);
                                            pobjEParam.CodigoApostillador = NullInt32.Create(txtCodigo.Text);
                                            //pobjEParam.Firma = LeerImagen();
                                            pobjEParam.NombreArchivoFirma = NullString.Create(UpLoadImagen(pobjEParam.CodigoApostillador.UINullable));
                                            pbjBParam.ModificarApostillador(pobjEParam); 
                                            break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
   

    //byte[] LeerImagen()
    //{
    //    byte[] image = null;
    //    try
    //    {

    //        if (fuFirma.HasFile)
    //        {
    //            string pesoImagenValidar = System.Web.Configuration.WebConfigurationManager.AppSettings["PesoKbImagenFirma"];
    //            string strExtension = Convert.ToString(Path.GetExtension(fuFirma.PostedFile.FileName)).ToLower();

    //            if (pesoImagenValidar == string.Empty) throw new Exception("No hay valor del peso de imagen a valiar en el web config.");
    //            if (strExtension != ".gif" && strExtension != ".bmp" && strExtension != ".jpg" && strExtension != ".jpeg" && strExtension != ".png") throw new Exception("Seleccione solo documento  tipo imágen.");
    //            if (fuFirma.PostedFile.ContentLength < Convert.ToUInt32(pesoImagenValidar)) throw new Exception("peso de firma debe ser menor a 2 Mb.");


    //            using (BinaryReader reader = new BinaryReader(fuFirma.PostedFile.InputStream))
    //            {
    //                image = reader.ReadBytes(fuFirma.PostedFile.ContentLength);

    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        image = null;
    //        throw ex;

    //    }
    //    return image;
    //}

    public string UpLoadImagen(string strNombreASubir)
    {

        string nombreFichero, strNombreArchivo;
        try
        {

            if (fuFirma.HasFile)
            {
                HttpPostedFile mifichero = fuFirma.PostedFile;
                nombreFichero = Path.GetFileName(mifichero.FileName);

                string strExtension = Path.GetExtension(nombreFichero);
                strNombreArchivo = strNombreASubir; 
                strExtension = strExtension.ToLower();

                strNombreArchivo = strNombreArchivo + strExtension;

                if (strExtension == ".gif" || strExtension == ".bmp" || strExtension == ".jpg" || strExtension == ".jpeg" || strExtension == ".png")
                {
                    string carpeta = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaFirmaslocal"];
                    string ruta_archivo = carpeta + strNombreArchivo;
                    // if (File.Exists(ruta_archivo)) throw new Exception("El nombre del archivo ha subir ya existe.");
                    mifichero.SaveAs(ruta_archivo);
                }
                else
                {
                    throw new Exception("Seleccione sólo documento  tipo imágen.");
                }

            }
            else
            {
                throw new Exception("Seleccione imágen de la firma para actualizar.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return strNombreArchivo;
    }
    #endregion

    #region Eventos


    protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Insert();
            Response.Redirect("frmApostilladores.aspx");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }

    }
    #endregion

   
}

