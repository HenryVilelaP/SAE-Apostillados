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


public partial class Pages_Maestros_frmFirmantes :UIPage
{
    
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
       try
        {
            if (!IsPostBack)
            {
                this.btnNuevo.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_on.gif',this);");
                this.btnNuevo.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_off.gif',this);");


                this.btnBuscar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_on.gif',this);");
                this.btnBuscar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BBuscar_off.gif',this);");

                this.btnLimpar.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_on.gif',this);");
                this.btnLimpar.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','Blimpiar_off.gif',this);"); 

                gvFirmante.RowDataBound += new GridViewRowEventHandler(gvFirmante_RowDataBound); 
                CargarFirmantes();
            }
       }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());  
        }
    }
    void CargarFirmantes()
    {
        try
        {
            BFirmante objC = new BFirmante();
            EFirmante objEC = new EFirmante();

            objC.Constructor(Conexion);
              
            objEC.Materno = NullString.Create(txtxMaterno.Text);
            objEC.Paterno = NullString.Create(txtPaterno.Text);
            objEC.Nombres = NullString.Create(txtNombre.Text);
            DataTable dt=objC.ListarFirmantes(objEC);
            
            
            if (dt != null)
            {
                gvFirmante.DataSource = dt;
                gvFirmante.DataBind();
                int pintNumReg = dt.Rows.Count > 0 ? dt.Rows.Count : 0;
                lblNumeroRegistros.Text = string.Format("Número de Registros encontrados : {0}", pintNumReg.ToString());
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    void gvFirmante_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView fila = (DataRowView)e.Row.DataItem;
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                ImageButton btnEdit = (ImageButton)e.Row.FindControl("btnEdit");

               
                btnDelete.Attributes.Add("onclick", "return confirm('¿Está seguro de Eiminar?');");
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
        CargarFirmantes();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());  
        }

    }
    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtxMaterno.Text = string.Empty;
            CargarFirmantes();
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
            BFirmante objParam = new BFirmante();
            objParam.Constructor(Conexion);
            objParam.EliminarFirmante(Convert.ToInt32(imbDelete.CommandArgument));

            CargarFirmantes();
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
            Response.Redirect("frmFirmanteNuevo.aspx?strParami=" + imbDelete.CommandArgument.ToString() + "&xopc=upParam");
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0, ex.Message.ToString());
        }
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
       
            Response.Redirect("frmFirmanteNuevo.aspx");
       
    }
 
}
