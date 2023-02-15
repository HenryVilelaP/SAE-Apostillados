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

public partial class UserControl_CuwBuscarLimpiar : System.Web.UI.UserControl
{
    public event EventHandler LimpiarClick;
    public event EventHandler BuscarClick;

    [System.Diagnostics.DebuggerHidden]   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {
                             

       imbBuscar.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bbuscar_on.gif',this);");
       imbBuscar.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bbuscar_off.gif',this);");

       imbLimpiar.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Blimpiar_on.gif',this);");
       imbLimpiar.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Blimpiar_off.gif',this);");
         
        }
    }

  
    protected void imbBuscar_Click1(object sender, ImageClickEventArgs e)
    {
        if (BuscarClick != null) BuscarClick(this, e);
           
    }
    protected void imbLimpiar_Click1(object sender, ImageClickEventArgs e)
    {
        if (LimpiarClick != null) LimpiarClick(this, e); 
    }
}
                               