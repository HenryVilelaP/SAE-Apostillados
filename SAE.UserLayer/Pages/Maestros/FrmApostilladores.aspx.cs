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



using System.Collections.Generic;

using SAE.UInterfaces;
using SAE.BusinessLayer;
using SAE.EntityLayer;
//using SAE.EntityLayer.Collections;
using SAE.UInterfaces;
using SAE.Nullables;


public partial class Pages_Maestros_frmApostilladores :UIPage
{
    
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
       try
        {
           gvApostillador.RowDataBound += new GridViewRowEventHandler(gvApostillador_RowDataBound);
            if (!IsPostBack)
            {
               
               
                this.btnNuevo.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_on.gif',this);");
                this.btnNuevo.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_off.gif',this);");


                this.btnBuscar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_on.gif',this);");
                this.btnBuscar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_off.gif',this);");

                this.btnLimpar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_on.gif',this);");
                this.btnLimpar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_off.gif',this);"); 

                CargarApostilladors();
            }
       }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());  
        }
    }
    void CargarApostilladors()
    {
        try
        {
            BApostillador objC = new BApostillador();
            EApostillador objEC = new EApostillador();

            objC.Constructor(Conexion);
              
            objEC.Materno = NullString.Create(txtxMaterno.Text);
            objEC.Paterno = NullString.Create(txtPaterno.Text);
            objEC.Nombres = NullString.Create(txtNombre.Text);
            DataTable dt=objC.ListarApostilladores(objEC,NullInt32.Empty );
            
            
            if (dt != null)
            {
                gvApostillador.DataSource = dt;
                gvApostillador.DataBind();
                int pintNumReg = dt.Rows.Count > 0 ? dt.Rows.Count : 0;
                lblNumeroRegistros.Text = string.Format("Número de Registros encontrados : {0}", pintNumReg.ToString());
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void gvApostillador_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                ImageButton btnEdit = (ImageButton)e.Row.FindControl("btnEdit");
                Image imgFirma = (Image)e.Row.FindControl("imgFirma");

               // imgFirma.ImageUrl = string.Format("frmVerFirma.aspx?idApos={0}", fila["CODIGOAPOSTILLADOR"]);

                string strRutaCompartido = System.Web.Configuration.WebConfigurationManager.AppSettings["carpetaFirmaslocal"];
                string strNombreFile =Convert.ToString( fila["NOMBREARCHIVOFIRMA"]);
                string strRutaCompleta=strRutaCompartido + strNombreFile;

                if (System.IO.File.Exists(strRutaCompleta))
                {
                    imgFirma.ImageUrl = strRutaCompleta;
                }
                else
                {
                    imgFirma.Visible = false;
                }
                    
                btnDelete.Attributes.Add("onclick", "return confirm('¿Esta seguro de Eiminar?');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void brnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        
        try{
        CargarApostilladors();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());  
        }

    }
    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        
        try{
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtxMaterno.Text = string.Empty;
            CargarApostilladors();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());  
        }

    }
    
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imbDelete = (ImageButton)sender;
            BApostillador objParam = new BApostillador();
            objParam.Constructor(Conexion);
            objParam.EliminarApostillador(Convert.ToInt32(imbDelete.CommandArgument));

            CargarApostilladors();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imbDelete = (ImageButton)sender;
            Response.Redirect("frmApostilladorNuevo.aspx?strParami=" + imbDelete.CommandArgument.ToString() + "&xopc=upParam");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("frmApostilladorNuevo.aspx");
       
    }

    
 
}
