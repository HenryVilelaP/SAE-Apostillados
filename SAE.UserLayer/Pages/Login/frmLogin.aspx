<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="FrmLogin" %>

<%@ Register src="../../UserControl/CuwLogin.ascx" tagname="CuwLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
   <link href ="../../App_Themes/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    
    
    
     
  
              
               <table   id="table-border_login" border="0" cellpadding="0" style=" height:450px; width:30%; " cellspacing="0" >            
               <tr>
               <td valign="top" style="height:60px;"  align="center"> 
                   <img src="../../Images/Logos/rree_membrete.gif" /> 
               </td>
               </tr>
               <tr>
               <td style="height:10%;"  align="center"  > 
                 <table width="90%"><tr><td> Introduzca su contraseña respectiva y luego haga click en "Ingresar".</td></tr></table> 
               </td>
               </tr>
               <tr>
               <td style="height:40%;"  align="center" valign="middle">
              <uc1:CuwLogin ID="cuwLogin" runat="server" /> 
               </td>
               </tr>
               <tr>
               <td align="center" style="height:7%; "  id="footer" >   Ministerio de Relaciones Exteriores - MRE&nbsp;  &copy; 2010
               </td></tr>
                </table>
               
            
            
    
    
  
    </form>
</body>
</html>
