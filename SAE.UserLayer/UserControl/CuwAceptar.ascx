<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CuwAceptar.ascx.cs" Inherits="UserControl_CuwAceptar" %>

 <div>                          
     <table width="100%"  border="0" cellpadding="0" cellspacing="0">
     <tr><td id="footer"><asp:Label runat="server" ID="lblTituloPop" />  </td></tr>  
     <tr><td align="center">
                     <br /><br />
                     <asp:Label runat="server" ID="lblMensaje" />
                     <br /><br />
     </td></tr>
     <tr>
     <td align="center" style="width:50%; height:40px; " valign="middle">
           <asp:Button ID="btnOk" runat="server" Text="Aceptar" />
          
     </td>
     </tr>
     </table>
 </div> 
