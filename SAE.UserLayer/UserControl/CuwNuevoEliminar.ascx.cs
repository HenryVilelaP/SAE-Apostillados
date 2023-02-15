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

public partial class UserControl_CuwNuevoEliminar : System.Web.UI.UserControl
{


    public event ImageClickEventHandler SeleccionarClick
    {

        add {
            this.imgBtnSelAll.Click += value;
        }
        remove {
            this.imgBtnSelAll.Click -= value;
        }
    }
    public event ImageClickEventHandler NuevoClick
    {

        add
        {
            this.imgBtnNuevo.Click  += value;
        }
        remove
        {
            this.imgBtnNuevo.Click -= value;
        }
    }
    public event  ImageClickEventHandler   EliminarClick
    {

        add
        {
            this.imgBtnEliminar.Click += value;
       
        }
        remove
        {
            this.imgBtnEliminar.Click -= value;
        }
    }

    delegate void VisibilidadControl(bool valor);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {
            imgBtnSelAll.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bseleccionar_on.gif',this);");
            imgBtnSelAll.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bseleccionar_off.gif',this);");
            imgBtnNuevo.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bnuevo_on.gif',this);");
            imgBtnNuevo.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bnuevo_off.gif',this);");
            imgBtnEliminar.Attributes.Add("onMouseOver", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Beliminar_on.gif',this);");
            imgBtnEliminar.Attributes.Add("onMouseOut", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Beliminar_off.gif',this);");
        }
    }
    VisibilidadControl visible;
    public void imgEliminarVisible(bool valor) 
    {
        imgBtnEliminar.Visible   = valor; 
    }
    public void imgNuevoVisible(bool valor)
    {
        imgBtnNuevo.Visible = valor;
    }
    public void imgSeleccionVisible(bool valor)
    {
        imgBtnSelAll.Visible = valor;
    }
     
   
}
