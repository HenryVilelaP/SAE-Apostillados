<%@ control language="C#" autoeventwireup="true" inherits="UserControl_CuwLogin, App_Web_vup9dlmv" %>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="margin-bottom: 1px">
            <tr>
                <td>
                    <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario NT"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
                       </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                 <td colspan="2" align="center" style=" height:10px">
                  
                </td>
                 </tr>
                  <tr>
                 <td colspan="2" align="center">
                    <asp:ImageButton ID="btnAceptar"  ImageUrl="~/Images/Botones/BIngresar_off.gif" runat="server" Text="Ingresar" />
                </td>
                 </tr>
            <tr>
                <td colspan="2" align="center">
                   <div  id="apDivProgresoLogin" >
                                         <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
                                               <ProgressTemplate   >
                                                  <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr><td>
                                                    <%--Verificando Información..<img src="../../img/small-waitajax-loader.gif" />--%>
                                                    Verificando Información...<%--<img alt='' src="../../Images/Iconos/barr-cicle-ajax-loader.gif" />--%>
                                                    </td></tr>
                                                    </table>
                                                    
                                                
                                            </ProgressTemplate>
                                            </asp:UpdateProgress> 
            </div>   <br />
                 <asp:Label ID="lblMensajeErrorLogin" CssClass="msg_error" runat="server"  ></asp:Label>
                 
                </td>
            </tr>
            
        </table>
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnAceptar" EventName="Click" />
    
    </Triggers>
</asp:UpdatePanel>

     


    <script type="text/javascript">
function FC_EfectoBoton(ruta,imagen,objeto){
//  debugger;
	objeto = eval(objeto);
	objeto.src = (ruta + imagen);
}
</script>


    
 
