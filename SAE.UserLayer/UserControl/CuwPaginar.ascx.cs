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
using System.ComponentModel;

public partial class UserControl_CuwPaginar : System.Web.UI.UserControl
{

    public event EventHandler OnInicioClick;
    public event EventHandler OnSiguienteClick;
    public event EventHandler OnAtrasClick;
    public event EventHandler OnFinClick;


    #region Propiedades

    public string  width { 
       
        set{
       
            tbl_paginacion.Width =value ;  
        }


    }

    public bool Enabled 
    {
       
        set{
                    this.botonAnterior.Enabled  = value;
                    this.botonFin.Enabled = value;
                    this.botonInicio.Enabled = value;
                    this.botonSgte.Enabled = value;
        }
    }
    public double NroPaginaTotal
    {
        get
        {
            if (ViewState["_ListadoNroPaginaTotal"] == null)
                ViewState["_ListadoNroPaginaTotal"] = 0;
            return Convert.ToDouble (ViewState["_ListadoNroPaginaTotal"]);
        }
        set
        {
            ViewState["_ListadoNroPaginaTotal"] = value;
        }
    }       
    public int NroPaginaActual
    {
        get
        {
            if (ViewState["_ListadoNroPaginaActual"] == null)
                ViewState["_ListadoNroPaginaActual"] = 0;
            return Convert.ToInt32(ViewState["_ListadoNroPaginaActual"]);
        }
        set
        {
            ViewState["_ListadoNroPaginaActual"] = value;
        }
    }           
    public int TotalRegistros {
        get{
            if (ViewState["_ListadoTotalRegistros"] == null) ViewState["_ListadoTotalRegistros"] = 0;
            return Convert.ToInt32(ViewState["_ListadoTotalRegistros"]) ;
        }
        set{
            ViewState["_ListadoTotalRegistros"] = value      ;
        }
    }

    public int NroRegistrosPagina{ 
        get{
            if( ViewState["_ListadoNroRegistrosPagina"] ==null) ViewState["_ListadoNroRegistrosPagina"] = 0  ;
            return Convert.ToInt32(ViewState["_ListadoNroRegistrosPagina"])        ;
        }
        set{
            ViewState["_ListadoNroRegistrosPagina"] = value ;
        }
    }

    public String EtiquetaTotalRegistros{
        get{
            if (ViewState["_EtiquetaTotalRegistros"] ==null) ViewState["_EtiquetaTotalRegistros"] = lbl_TotalRegistros.Text;
            return ViewState["_EtiquetaTotalRegistros"].ToString();
        }
       set{
            ViewState["_EtiquetaTotalRegistros"] = value;
        }
    }

    public String EtiquetaNroPagina {
        get{
            if (ViewState["_EtiquetaNroPagina"] ==null) ViewState["_EtiquetaNroPagina"] = lbl_NroPagina.Text;
            return ViewState["_EtiquetaNroPagina"].ToString();
        }
       set{
            ViewState["_EtiquetaNroPagina"] = value;
        }
    }

    public String TotalRegistrosMostrado{
        get{
            return this.lbl_TotalRegistros.Text;
        }
       set{
            this.lbl_TotalRegistros.Text = value;
        }
    }

    public String NroPaginaMostrado{
        get{
            return this.lbl_NroPagina.Text;
        }
       set{
            this.lbl_NroPagina.Text = value;
        }
    }

    public  ImageButton botonInicio{
        get{
            return imb_Inicio;
        }
    }
    public  ImageButton botonAnterior{
        get{
            return this.imb_Anterior;
        }
    }
    public  ImageButton botonSgte{
        get{
            return this.imb_Siguiente;
        }
    }
    public  ImageButton botonFin{
        get{
            return this.imb_Fin;
        }
    }
    #endregion



    protected void Page_Load(object sender, EventArgs e)
    {


           if(!(Page.IsPostBack)){
                imb_Inicio.Attributes.Add("onMouseOver", "javascript:FC_EfectoBoton('../Images/Paginacion/','inicio_on.gif',this);");
                imb_Inicio.Attributes.Add("onMouseOut", "javascript:FC_EfectoBoton('../Images/Paginacion/','inicio_off.gif',this);")         ;
                imb_Anterior.Attributes.Add("onMouseOver", "javascript:FC_EfectoBoton('../Images/Paginacion/','atras_on.gif',this);")       ;
                imb_Anterior.Attributes.Add("onMouseOut", "javascript:FC_EfectoBoton('../Images/Paginacion/','atras_off.gif',this);")      ;
                imb_Siguiente.Attributes.Add("onMouseOver", "javascript:FC_EfectoBoton('../Images/Paginacion/','adelante_on.gif',this);") ;
                imb_Siguiente.Attributes.Add("onMouseOut", "javascript:FC_EfectoBoton('../Images/Paginacion/','adelante_off.gif',this);");
                imb_Fin.Attributes.Add("onMouseOver", "javascript:FC_EfectoBoton('../Images/Paginacion/','final_on.gif',this);");
                imb_Fin.Attributes.Add("onMouseOut", "javascript:FC_EfectoBoton('../Images/Paginacion/','final_off.gif',this);");
           }
    }

    public void Inicializar()
    {
        NroPaginaTotal = TotalRegistros = NroPaginaActual = 0;

    }
    protected void imb_Inicio_Click(object sender, ImageClickEventArgs e)
    {
        if (this.OnInicioClick != null) OnInicioClick(this, e); 
    }
    protected void imb_Anterior_Click(object sender, ImageClickEventArgs e)
    {
        if (this.OnAtrasClick != null) OnAtrasClick(this, e);
    }
    protected void imb_Siguiente_Click(object sender, ImageClickEventArgs e)
    {
        if (this.OnSiguienteClick != null) OnSiguienteClick(this, e);
    }
    protected void imb_Fin_Click(object sender, ImageClickEventArgs e)
    {
        if (this.OnFinClick != null) OnFinClick(this, e);
    }

     public void Paginar(int pintNroPagina   ){

         this.Visible = (NroPaginaActual <= NroPaginaTotal);
         this.TotalRegistrosMostrado = String.Format(this.EtiquetaTotalRegistros, TotalRegistros);
         this.NroPaginaMostrado = String.Format(this.EtiquetaNroPagina, pintNroPagina, NroPaginaTotal);
    }

    



}
