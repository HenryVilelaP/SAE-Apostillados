<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CuwFiltroPerfilUsuario.ascx.cs" Inherits="UserControl_CuwFiltroPerfilUsuario" %>


 <asp:UpdatePanel ID="upFiltroPerfilUsuario" runat="server">
<ContentTemplate>    
<table border="0" cellpadding=2 width=100% >
   
<tr>
<td><asp:Label ID="lblUbicacion" runat="server" Text=""></asp:Label>  </td>
<td><asp:DropDownList ID="ddlUbicacion" runat="server"   Width="200px"  AutoPostBack="true" onselectedindexchanged="ddlUbicacion_SelectedIndexChanged" /> </td>
</tr>
<tr>
<td><asp:Label ID="lblOficina" runat="server" Text="Oficina"  ></asp:Label> </td>
<td><asp:DropDownList ID="ddlOficina" runat="server"   Width="200px" AutoPostBack="true" onselectedindexchanged="ddlOficina_SelectedIndexChanged"  /> </td>
</tr>
<tr>
<td> <asp:Label ID="lblUnidad" runat="server" Text=""></asp:Label> </td>
<td><asp:DropDownList ID="ddlUnidad" runat="server"  Width="200px" AutoPostBack="true" onselectedindexchanged="ddlUnidad_SelectedIndexChanged" /> </td>
</tr>
<tr>
<td colspan="2">
    <table border="0"  cellpadding=2 class="bg_fondo_tabla" >
    <tr><td colspan="2" style=" margin-top:30;"></td></tr>
    <tr>
    <td>
           <asp:Label ID="lblModulo" runat="server" Text="Modulo"  ></asp:Label> 
    </td>
    <td  colspan="3">
           <asp:DropDownList ID="ddlModulo"  Width="200px" runat="server" AutoPostBack="true" onselectedindexchanged="ddlModulo_SelectedIndexChanged" /></td>
    </tr>
    <tr>
    <td>
            <asp:Label ID="lblPerfil" runat="server" Text=""></asp:Label> 
    </td>
            <td  colspan="3"><asp:DropDownList ID="ddlPerfil"  Width="200px" runat="server" AutoPostBack="true" onselectedindexchanged="ddlPerfil_SelectedIndexChanged" />
    </td>
    </tr>
    </table>
</td></tr> 
<tr>
<td colspan="2"><asp:Label runat="server" ID="lblMsgError"></asp:Label></td>
</tr>
 
</table>
</ContentTemplate>
 <Triggers>
 <ajax:AsyncPostBackTrigger  ControlID="ddlUbicacion" EventName="SelectedIndexChanged"/>
 <ajax:AsyncPostBackTrigger  ControlID="ddlModulo" EventName="SelectedIndexChanged"/>
 <ajax:AsyncPostBackTrigger  ControlID="ddlUnidad" EventName="SelectedIndexChanged"/>
 <ajax:AsyncPostBackTrigger  ControlID="ddlPerfil" EventName="SelectedIndexChanged"/>
 </Triggers>
</asp:UpdatePanel>