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

public partial class UserControl_CuwConfirmar : System.Web.UI.UserControl
{
    public event EventHandler ConfirmarClick;
    public event EventHandler CancelarClick;


    #region Property 

   
    public String TituloMensajeConfirmacionText
    {
        get
        {
            return lblTituloPop.Text ;  

        }
        set {
            lblTituloPop.Text=value;          
        
        }
    }
    public String MensajeConfirmacionOkText
    {
        get
        {
            return lblMensajeEliminar.Text; 

        }
        set
        {
            lblMensajeEliminar.Text = value;
              
        }
    }
    public String PreguntaText
    {
        get
        {
            return lblPregunta.Text; 

        }
        set
        {
            lblPregunta.Text = "¿" + value + "?";

        }
    }
    public String EstiloMensaje
    {

        set { lblMensajeEliminar.CssClass = value; }
    }
    #endregion

    #region Evento

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (ConfirmarClick != null) ConfirmarClick(this, e);
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        if (CancelarClick != null) CancelarClick(this, e); 
    }
}
    #endregion

