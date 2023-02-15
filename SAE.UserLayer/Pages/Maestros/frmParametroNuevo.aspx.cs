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
//using SAE.EntityLayer.Collections;
using SAE.UInterfaces;
using SAE.Nullables;

public partial class Pages_Maestros_frmParametroNuevo :UIPage
{

    protected override void OnLoad(EventArgs e)
    {
        try
        {
            base.OnLoad(e);
            

              
            //gvparametros.RowDataBound += new GridViewRowEventHandler(gvparametros_RowDataBound);
           
            if (!IsPostBack)
            {
                this.btnRegistrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_on.gif',this);");
                this.btnRegistrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BRegistrar_off.gif',this);"); 

                if (Request.QueryString["strParam"] != null) hidCodigoTabla.Value = Request.QueryString["strParam"];
                if (Request.QueryString["strParami"] != null) hidCodigoParametro.Value = Request.QueryString["strParami"];

            if (Request.QueryString["xopc"] != null)
            {
                        if (Request.QueryString["xopc"] == "upParam")
                        {
                            ddltabla.Enabled = false;
                            lblTitulo.Text = "Actualización de Parametro";
                            OperacionActual = Operacion.Modificar;
                            chkEliminar.Visible = false;
                            chkModificar.Visible = false;
                            lblchkU.Visible = false;
                            lblchkD.Visible = false;
                            cargarParametroEditar();
                        }
                        else
                        {
                            lblTitulo.Text = "Registro de Parametro";
                            OperacionActual = Operacion.Insertar;
                        }
            }
            else
            {
                lblTitulo.Text = "Registro de Parametro";
                OperacionActual = Operacion.Insertar;
            }
                cargarTablas();
            }

             



        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }

    void cargarParametroEditar()
    {
       try{
           BParametro objParam = new BParametro();
           objParam.Constructor(Conexion);
           EParametro objEParametro = new EParametro();
           objEParametro.CodigoTabla = NullInt32.Create(-1);
           objEParametro.CodigoRegistro = NullInt32.Empty;
           objEParametro.CodigoParametro = NullInt32.Create(hidCodigoParametro.Value); 
           DataTable dtParametro = objParam._ListarParametros(objEParametro, string.Empty);

           if (dtParametro.Rows.Count == 1)
           {
               txtCodigo.Text = Convert.ToString( dtParametro.Rows[0]["CODIGOPARAMETRO"]);
               txtNombre.Text = Convert.ToString(dtParametro.Rows[0]["NOMBREPARAMETRO"]);
               txtValorNumerico.Text= Convert.ToString(dtParametro.Rows[0]["VALORNUMERICO"]);
               txtValorTexto.Text  = Convert.ToString( dtParametro.Rows[0]["VALORTEXTO"]);


           }

       }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    void cargarTablas()
    {
        try
        {
            BParametro objParam = new BParametro();
            objParam.Constructor(Conexion);
            EParametro objEParametro = new EParametro();
            objEParametro.CodigoTabla = NullInt32.Create(-1);
            objEParametro.CodigoRegistro = NullInt32.Empty;
            objEParametro.CodigoParametro = NullInt32.Empty;
            DataTable dtopcionesPregOA = objParam._ListarParametros(objEParametro, string.Empty);

            ddltabla.DataSource = dtopcionesPregOA;
            ddltabla.DataTextField = "NOMBREPARAMETRO";
            ddltabla.DataValueField = "CODIGOTABLA";
            ddltabla.DataBind();

            if (ddltabla.Items.FindByValue(hidCodigoTabla.Value) != null)
                ddltabla.Items.FindByValue(hidCodigoTabla.Value).Selected = true;
            ddltabla.Items.Insert(0, new ListItem("<Seleccione>", "0"));
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddltabla.SelectedIndex <= 0) throw new Exception("Seleccione Tabla.");

            
            BParametro pbjBParam = new BParametro();
            EParametro pobjEParam = new EParametro();
            pbjBParam.Constructor(Conexion);

            pobjEParam.CodigoTabla = NullInt32.Create(ddltabla.SelectedValue);
            pobjEParam.Descripcion= NullString.Create(txtNombre.Text);
            pobjEParam.ValorNumerico= NullDecimal.Create(txtValorNumerico.Text) ;
            pobjEParam.Valortexto = NullString.Create(txtValorTexto.Text);

            string strModi="N"; 
            string strElim="N";

            if (chkModificar.Checked) strModi = "S" ;
            if (chkEliminar.Checked) strElim = "S" ;

            pobjEParam.FlagModificar = NullString.Create(strModi);
            pobjEParam.FlagEliminar = NullString.Create(strElim);

            switch (OperacionActual)
            {
                case Operacion.Insertar: pbjBParam.InsertarParametro(pobjEParam); break;
                case Operacion.Modificar:
                    pobjEParam.CodigoParametro = NullInt32.Create(txtCodigo.Text);
                                            pbjBParam.ModificarParametro(pobjEParam);
                                            break;
            }
            
            Response.Redirect("frmParametro.aspx");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }

    }
    
}

