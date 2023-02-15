<%@ control language="C#" autoeventwireup="true" inherits="UserControl_CuwConfirmar, App_Web_usi1lpbn" %>
 

 <div>                          
     <table width="100%"  border="0" cellpadding="0" cellspacing="0">
     <tr><td colspan="2" id="footer"><asp:Label runat="server" ID="lblTituloPop" />  </td></tr>  
     <tr><td colspan="2" align="center">
                     <br /><br />
                     <asp:Label runat="server" ID="lblPregunta" />
                     <br /><br />
     </td></tr>
     <tr><td align="right" style="width:50%">
           <asp:Button ID="btnOk" runat="server" Text="Aceptar" onclick="btnOk_Click"   />&nbsp;</td>
     <td align="left"  style="width:50%">
           <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" 
               onclick="btnCancelar_Click"     /></td></tr>
           
     <tr><td colspan="2" style="height:30px" valign="middle" align="center">&nbsp;<asp:Label runat="server" ID="lblMensajeEliminar"/> </td></tr>
     </table>
 </div>                  


 

