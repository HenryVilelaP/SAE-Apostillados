<%@ control language="C#" autoeventwireup="true" inherits="CuwGrabarCerrar, App_Web_iqtwfiv2" %>
<table>
    <tr>
        <td style="height: 21px">
            <asp:ImageButton ID="imbGrabar" runat="server" AlternateText="Grabar" CausesValidation="true"
                ImageUrl="~/Images/botones/bgrabar_off.gif" /></td>
        <td style="height: 21px">
        </td>
        <td style="height: 21px">
            <asp:ImageButton ID="imbCerrar" runat="server" AlternateText="Cerrar" CausesValidation="false"
                ImageUrl="~/Images/botones/Bcerrar_off.gif" /></td>
    </tr>
<act:ConfirmButtonExtender ID="ConfirmButtonExtender1"  ConfirmText="¿Desea grabar el registro?"  TargetControlID="imbGrabar" runat="server" />
    
</table>
   <script>
function FC_EfectoBoton(ruta,imagen,objeto){
//  debugger;
	objeto = eval(objeto);
	objeto.src = (ruta + imagen);
}
</script>