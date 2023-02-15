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

public partial class UserControl_CuwAceptar : System.Web.UI.UserControl
{
    #region Propiedades
    
    public event EventHandler OkClick
    {
        add
        {
            this.btnOk.Click += value;
        }
        remove
        {
            this.btnOk.Click -= value;  
        }
    }

    public String Titulo
    {
        get
        {
            return lblTituloPop.Text;

        }
        set
        {
            lblTituloPop.Text = value;

        }
    }

    public String Mensaje
    {
        get
        {
            return this.lblMensaje.Text;

        }
        set
        {
            lblMensaje.Text = value;

        }
    }

    public String EstiloMensaje
    {

        set {  this.lblMensaje.CssClass = value; }
    }

    #endregion
}
