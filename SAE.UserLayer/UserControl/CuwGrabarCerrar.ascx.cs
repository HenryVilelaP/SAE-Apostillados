using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CuwGrabarCerrar : System.Web.UI.UserControl
{


    public string MensajeConfirmacion
    {
        get
        {
            return this.ConfirmButtonExtender1.ConfirmText;  
        }
        set
        {
           this.ConfirmButtonExtender1.ConfirmText = value;
        }


    }
    public event EventHandler Save_Click;
    public event EventHandler Close_Click;
    public ImageButton imgGrabar
   
    {
        
        get
        {
            return this.imbGrabar; 
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        this.imbGrabar.Click +=new ImageClickEventHandler(imbGrabar_Click); 
        this.imbCerrar.Click+=new ImageClickEventHandler(imbCerrar_Click);

        
        imbCerrar.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bcerrar_on.gif',this);");
        imbCerrar.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bcerrar_off.gif',this);");

        imbGrabar.Attributes.Add("onmouseover", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bgrabar_on.gif',this);");
        imbGrabar.Attributes.Add("onmouseout", "return FC_EfectoBoton('" + Request.ApplicationPath + "/Images/Botones/','Bgrabar_off.gif',this);");
         

    }


          
    protected void imbGrabar_Click(object sender, EventArgs e)
    {

        if (Save_Click!=null)  Save_Click(this, e); 
    }
    protected void imbCerrar_Click(object sender, EventArgs e)
    {

        if (Close_Click != null) Close_Click(this, e); 
    }
    public void AddSaveClient(string key,string valor){

        this.imbGrabar.Attributes.Add(key, valor);   

    }

    public Boolean VisibleCerrar
    {
        get {

           return imbCerrar.Visible; 
        }
        set
        {
            imbCerrar.Visible = value;

        }
    }
    public Boolean VisibleGrabar
    {
        get
        {

            return imbGrabar.Visible;
        }
        set
        {
            imbGrabar.Visible = value;

        }
    }

}
