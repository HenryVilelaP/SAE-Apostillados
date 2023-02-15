<%@ control language="C#" autoeventwireup="true" inherits="UserControl_CuwBuscarLimpiar, App_Web_iqtwfiv2" %>
      <table>
    <tr>
        <td valign="top">
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:ImageButton ID="imbBuscar" CausesValidation="false" runat="server" ImageUrl="../Images/botones/Bbuscar_off.gif"
                                    ToolTip="Buscar" onclick="imbBuscar_Click1" />
                            </td>
                            <td valign="top">
                                <asp:ImageButton ID="imbLimpiar" runat="server" ImageUrl="~/Images/Botones/Blimpiar_off.gif"
                                    ToolTip="Limpiar" onclick="imbLimpiar_Click1" />
                            </td>
                        </tr>
                    </table>
  
        </td>
    </tr>
</table>
<script type="text/javascript">
function FC_EfectoBoton(ruta,imagen,objeto){
//  debugger;
	objeto = eval(objeto);
	objeto.src = (ruta + imagen);
	
	 
}
</script>