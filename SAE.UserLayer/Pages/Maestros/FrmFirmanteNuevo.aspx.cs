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
using SAE.UInterfaces;
using SAE.Nullables;

public partial class Pages_Maestros_FrmFirmanteNuevo : UIPage
{


    #region Inicio
    protected override void OnLoad(EventArgs e)
    {
        try
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);"); 

                 FillCargo(ddlCargo);
                 FillEntidad(ddlEntidad);
                 if (Request.QueryString["strParami"] != null) hidCodigoFirmante.Value = Request.QueryString["strParami"];

            if (Request.QueryString["xopc"] != null)
            {
                        if (Request.QueryString["xopc"] == "upParam")
                        {
                            lblTitulo.Text = "Actualización de Firmante";
                            OperacionActual = Operacion.Modificar;
                            FillFirmanteEditar();
                        }
                        else
                        {
                            lblTitulo.Text = "Registro de Firmante";
                            OperacionActual = Operacion.Insertar;
                        }
            }
            else
            {
                lblTitulo.Text = "Registro de Firmante";
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
    
    void FillFirmanteEditar()
    {
       try{
           BFirmante objParam = new BFirmante();
           objParam.Constructor(Conexion);
           EFirmante objEFirmante = new EFirmante();
           objEFirmante.CodigoFirmante = NullInt32.Create(hidCodigoFirmante.Value);
           objEFirmante.Materno = NullString.Empty;
           objEFirmante.Paterno = NullString.Empty;
           objEFirmante.Dni = NullInt32.Empty;
           DataTable dtFirmante = objParam.ListarFirmantes(objEFirmante);

           if (dtFirmante.Rows.Count == 1)
           { 
               txtCodigo.Text = Convert.ToString( dtFirmante.Rows[0]["CODIGOFirmante"]);
               txtNombre.Text = Convert.ToString(dtFirmante.Rows[0]["NOMBRE"]);
               txtPaterno.Text= Convert.ToString(dtFirmante.Rows[0]["PATERNO"]);
               txtMaterno.Text = Convert.ToString(dtFirmante.Rows[0]["MATERNO"]);
               txtDNI.Text = Convert.ToString(dtFirmante.Rows[0]["DNI"]);

               if (ddlCargo.Items.FindByValue(Convert.ToString(dtFirmante.Rows[0]["CODIGOCARGO"])) != null)
                   ddlCargo.Items.FindByValue(Convert.ToString(dtFirmante.Rows[0]["CODIGOCARGO"])).Selected = true;
               if (ddlEntidad.Items.FindByValue(Convert.ToString(dtFirmante.Rows[0]["CODIGOENTIDAD"])) != null)
                   ddlEntidad.Items.FindByValue(Convert.ToString(dtFirmante.Rows[0]["CODIGOENTIDAD"])).Selected = true;
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
            CargarTabla(UIConstantes.PARAMETROS.TABLA_CARGO_AUTORIDAD_FIRMANTE, ddlCargo);
            ddlCargo.Items.Insert(0, new ListItem("<Seleccione>", ""));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    void FillEntidad(DropDownList ddlEntidad)
    {
        try
        {
            CargarTabla(UIConstantes.PARAMETROS.TABLA_ENTIDAD_AUTORIDAD_FIRMANTE, ddlEntidad);
            ddlEntidad.Items.Insert(0, new ListItem("<Seleccione>", ""));
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
            BFirmante pbjBParam = new BFirmante();
            EFirmante pobjEParam = new EFirmante();
            pbjBParam.Constructor(Conexion);

           
            pobjEParam.Nombres = NullString.Create(txtNombre.Text);
            pobjEParam.Paterno = NullString.Create(txtPaterno.Text);
            pobjEParam.Materno = NullString.Create(txtMaterno.Text);
            pobjEParam.Dni = NullInt32.Create(txtDNI.Text);
            pobjEParam.CodigoCargo = NullInt32.Create(ddlCargo.SelectedValue);
            pobjEParam.CodigoEntidad = NullInt32.Create(ddlEntidad.SelectedValue);
          

            switch (OperacionActual)
            {
                case Operacion.Insertar:    pobjEParam.UsuarioRegistro=((EUsuario)Usuario).CodigoUsuario;
                                            pbjBParam.InsertarFirmante(pobjEParam); break;
                case Operacion.Modificar:
                                            pobjEParam.UsuarioModifica=((EUsuario)Usuario).CodigoUsuario;
                                            pobjEParam.CodigoFirmante = NullInt32.Create(txtCodigo.Text);
                                            pbjBParam.ModificarFirmante(pobjEParam); 
                                            break;
            }
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
            if (ddlCargo.SelectedIndex == 0) throw new Exception("Seleccione Cargo del Firmante.");
            Insert();
            Response.Redirect("frmFirmantes.aspx");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }

    }
    #endregion

   
}

