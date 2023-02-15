using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
 

/// <summary>
/// Summary description for CScript
/// </summary>
public class CScript
{
    public CScript()
    {
        //
        // TODO: Add constructor logic here
        //
    }

      public static Boolean   IsInAsyncPostBack(Page  pg_Pagina) {
        return System.Web.UI.ScriptManager.GetCurrent(pg_Pagina).IsInAsyncPostBack;
      }

    public static void RegistrarScriptBlock(string pstrClave , string pstrScript)   {
        RegistrarScriptBlock(pstrClave, pstrScript, null);
    }
    public static void RegistrarScriptBlock(string pstrClave , string pstrScript ,Control pctlControl){
        Page pg_Pagina = (Page) HttpContext.Current.Handler;
        if (IsInAsyncPostBack(pg_Pagina)){
                     if (pctlControl ==null) pctlControl = pg_Pagina;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(pctlControl, pctlControl.GetType(), pstrClave, pstrScript, true);
        }else{
                    pg_Pagina.ClientScript.RegisterClientScriptBlock(pg_Pagina.GetType(), pstrClave, pstrScript, true);
        }
    }

    public static void RegistrarScriptStartup(string str_pClave , string str_pScript) {
        RegistrarScriptStartup(str_pClave, str_pScript, null) ;
    }

    public static void RegistrarScriptStartup(string pstrClave, string pstrScript ,Control pctlControl){
        Page pg_Pagina  = (Page)HttpContext.Current.Handler;
        if (IsInAsyncPostBack(pg_Pagina)) {
            if(pctlControl == null) pctlControl = pg_Pagina;
            System.Web.UI.ScriptManager.RegisterStartupScript(pctlControl, pctlControl.GetType(), pstrClave, pstrScript, true);
        }else{
            pg_Pagina.ClientScript.RegisterStartupScript(pg_Pagina.GetType(), pstrClave, pstrScript, true);
        }
    }

     
    public static void MessageBox(int pintMsgBox,string pstrMensaje){
        RegisterMessageBox(pintMsgBox, pstrMensaje, null, String.Empty) ;
    }

    public static void MessageBox(int pintMsgBox, string pstrMensaje, Control pctlAsyncTarget)
    {
        RegisterMessageBox(pintMsgBox, pstrMensaje, pctlAsyncTarget, String.Empty)                      ;
    }

    public static void MessageBox(int pintMsgBox, string pstrMensaje, string pstrURL)
    {
        RegisterMessageBox(pintMsgBox, pstrMensaje, null, pstrURL)  ;
    }

    public static void RegisterMessageBox(int pintMsgBox, string pstrMensaje,Control pctlAsyncTarget , string pstrURL){
        pintMsgBox += 1;
        Page pg_Pagina = (Page)HttpContext.Current.Handler;

        pstrMensaje = pstrMensaje.Replace("'", string.Empty);
        pstrMensaje = pstrMensaje.Replace("\n", "\\n");
        pstrMensaje = pstrMensaje.Replace("\r", "\\r");

        if (pstrURL.Length > 0 ) pstrURL = String.Format("window.location = '{0}';", pstrURL);

        System.Web.UI.ScriptManager obj_ScManager    = System.Web.UI.ScriptManager.GetCurrent(pg_Pagina) ;

        if (obj_ScManager.IsInAsyncPostBack  && pctlAsyncTarget !=null) {
            ScriptManager.RegisterStartupScript(pctlAsyncTarget, pctlAsyncTarget.GetType(), String.Format("__alert{0}", pintMsgBox), String.Format(" alert('{0}');{1}",pstrMensaje, pstrURL), true);
    }else{
            pg_Pagina.ClientScript.RegisterStartupScript(pg_Pagina.GetType(),  String.Format("__alert{0}", pintMsgBox), String.Format(" alert('{0}');{1}", pstrMensaje, pstrURL), true);
    }
    }

   



}
