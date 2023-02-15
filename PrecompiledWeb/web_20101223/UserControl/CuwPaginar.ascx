<%@ control language="C#" autoeventwireup="true" inherits="UserControl_CuwPaginar, App_Web_g3hjnuh2" %>
<table border="0" cellpadding="0" cellspacing="0" id="tbl_paginacion" runat="server" >
    <tr>
        <td style="width: 50%; height: 24px" align=left>
            <asp:Label ID="lbl_TotalRegistros" runat="server" SkinID="GrillaPie" Text="Total Registros: {0}"></asp:Label></td>
        <td align="center" style="height: 24px">
            <div id="div_BotonesPaginacion" runat="server">
                <asp:ImageButton ID="imb_Inicio" runat="server" align="absMiddle" CausesValidation="False"
                    ImageUrl="../Images/Paginacion/inicio_off.gif" OnClick="imb_Inicio_Click" />&nbsp;
                <asp:ImageButton ID="imb_Anterior" runat="server" align="absMiddle" CausesValidation="False"
                    ImageUrl="../Images/Paginacion/atras_off.gif" OnClick="imb_Anterior_Click" />&nbsp;
                <asp:ImageButton ID="imb_Siguiente" runat="server" align="absMiddle" CausesValidation="False"
                    ImageUrl="../Images/Paginacion/adelante_off.gif" OnClick="imb_Siguiente_Click" />&nbsp;
                <asp:ImageButton ID="imb_Fin" runat="server" align="absMiddle" CausesValidation="False"
                    ImageUrl="../Images/Paginacion/final_off.gif" OnClick="imb_Fin_Click" />
            </div>
        </td>
        <td align="right" style="height: 24px">
            <asp:Label ID="lbl_NroPagina" runat="server" SkinID="GrillaPie" Text="Página {0} de {1}"></asp:Label>
        </td>
    </tr>
</table>
