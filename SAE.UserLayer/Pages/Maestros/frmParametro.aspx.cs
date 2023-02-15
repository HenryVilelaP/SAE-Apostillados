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

public partial class Pages_Maestros_frmParametro :  UIPage
{

    protected override void OnLoad(EventArgs e)
    {
        try
        {
                base.OnLoad(e);

                gvparametros.RowDataBound += new GridViewRowEventHandler(gvparametros_RowDataBound); 
                if (!IsPostBack)
                {
                    this.btnNuevo.Attributes.Add("onmouseover", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_on.gif',this);");
                    this.btnNuevo.Attributes.Add("onmouseout", "return FC_EfectoBoton('../../Images/Botones/','BNuevo_off.gif',this);"); 
                    cargarTablas();
                }
         }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString() );  
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
        ddltabla.Items.Insert(0, new ListItem("<Seleccione>", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        } 
    }

    void gvparametros_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DataRowView fila = (DataRowView)e.Row.DataItem;
                ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                ImageButton btnEdit = (ImageButton)e.Row.FindControl("btnEdit");

                if (Convert.ToString (fila.Row["FLAGMODIFICAR"])=="N")
                {
                    btnEdit.ImageUrl = "~/Images/Iconos/data_edit.gif";
                    btnEdit.Enabled = false;
                    btnEdit.ToolTip = "Opción desactivada.";
                }
                if (Convert.ToString (fila.Row["FLAGELIMINAR"]) == "N")
                {
                    btnDelete.ImageUrl = "~/Images/Iconos/data_delete.gif";
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "Opción desactivada.";
                }
                btnDelete.Attributes.Add("onclick", "return confirm('¿Esta seguro de Eiminar?');"); 
            }
        }
        catch (Exception ex)
        {
            throw ex;
        } 

    }
    protected void Cargarparametros() {
        try
        {
        BParametro objParam = new BParametro();
        objParam.Constructor(Conexion);
        EParametro objEParametro = new EParametro();
        objEParametro.CodigoTabla = NullInt32.Create(ddltabla.SelectedValue);
        objEParametro.CodigoRegistro = NullInt32.Empty;
        objEParametro.CodigoParametro = NullInt32.Empty;
        DataTable dtopcionesPregOA = objParam._ListarParametros(objEParametro, string.Empty);


        if (dtopcionesPregOA != null)
        {
            gvparametros.DataSource = dtopcionesPregOA;
            gvparametros.DataBind();

            int pintNumReg = dtopcionesPregOA.Rows.Count > 0 ? dtopcionesPregOA.Rows.Count : 0;
            lblNumeroRegistros.Text = string.Format("Número de Registros encontrados : {0}", pintNumReg.ToString());
        }


        }
        catch (Exception ex)
        {
            throw ex;
        } 
    }

    

    protected void ddltabla_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        Cargarparametros();
         }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString() );  
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imbDelete = (ImageButton)sender;
            BParametro objParam = new BParametro();
            objParam.Constructor(Conexion);
            objParam.EliminarParametro(Convert.ToInt32(imbDelete.CommandArgument));

            Cargarparametros();
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString() );  
        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imbDelete = (ImageButton)sender;
            Response.Redirect("frmParametroNuevo.aspx?strParam=" + ddltabla.SelectedValue.ToString() + "&strParami=" + imbDelete.CommandArgument.ToString() + "&xopc=upParam");
             



           
        }
        catch (Exception ex)
        {
            CScript.MessageBox(0,ex.Message.ToString() );  
        }
    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        if (ddltabla.SelectedIndex > 0)
        {
            Response.Redirect("frmParametroNuevo.aspx?strParam=" + ddltabla.SelectedValue.ToString());
        }
        else
        {
            CScript.MessageBox(0,"Seleccione a que Tabla desea agregar un registro.");  
        }
    }
}
