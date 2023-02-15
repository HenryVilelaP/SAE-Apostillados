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

public partial class Pages_Maestros_frmPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // DropDownList1.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);

        if (!(Page.IsPostBack))
        {
            for (int c = 0; c <= 20; c++)
            {
                DropDownList1.Items.Add(new ListItem(c.ToString(), c.ToString() + "oooooooooooo"));

            }
        }
    }

    //void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //}
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.TextBox1.Text = DropDownList1.SelectedValue;  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = DropDownList1.SelectedValue;  
    }
}
