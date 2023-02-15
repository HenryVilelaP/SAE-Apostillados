<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_frmFirmantes, App_Web_rgv28-gm" %>
 
 
<asp:Content ID="Content2" ContentPlaceHolderID="cphCuerpo" Runat="Server">
 <div>
    <table width="100%"> 
       <tr><td style=" height:40px;">
<asp:label runat="server"  Text="Mantenimiento de Autoridades Firmantes" ID="lbltitulo" CssClass="titulo"></asp:label>
<hr />
</td></tr>
        <tr>
        <td></td>
        </tr>  
        <tr>
        <td>
        <table width="100%" border=0>
        
        <tr>
        <td style=" height:30px;"><asp:Label ID="lblNombre"  runat="server" Text="Nombre" /></td>
        <td><asp:TextBox runat="server" ID="txtNombre"></asp:TextBox></td>
        <td><asp:Label ID="lblPaterno"  runat="server" Text="Apellido Paterno" /></td>
        <td><asp:TextBox runat="server" ID="txtPaterno"></asp:TextBox></td>
        <td><asp:Label ID="lblMaterno"  runat="server" Text="Apellido Materno" /></td>
        <td><asp:TextBox runat="server" ID="txtxMaterno"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        
      <%--  <asp:Button runat="server" ID="brnBuscar" Text="Buscar" onclick="brnBuscar_Click" />--%>
          <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/Botones/BBuscar_off.gif" onclick="brnBuscar_Click"    />&nbsp;&nbsp;&nbsp;
        <asp:ImageButton runat="server" ID="btnLimpar" ImageUrl="~/Images/Botones/Blimpiar_off.gif" onclick="btnLimpiar_Click"    />
        
        
        </td>
        </tr>
        <tr>
        <td style=" height:15px" valign="bottom" colspan="6">
        </td>
        </tr>
        <tr><td colspan="6">
       <table style="width:100%" cellpadding="0" cellspacing="0" >
                <tr>        
                <td class="DivGrillaBorde">
                        <table style="width:100%" cellpadding="0" cellspacing="0" border="0" >
                        <tr style=" height:30px">
                        <td class="header-gridview" style="width:10%;" align="left">&nbsp;ID</td>
                        <td class="header-gridview" style="width:30%" align="center">Nombres y Apellidos</td>
                        <td class="header-gridview" style="width:20%" align="center">Cargo</td>
                        <td class="header-gridview" style="width:20%" align="center">Entidad</td>
                        <td class="header-gridview" style="width:10%" align="center">DNI</td>
                        <td class="header-gridview" style="width:10%" align="left">Operaciones</td>
                        
                        </tr>
                        </table>
                </td>
                </tr>    
                <tr>
                <td>
          <div   class="DivGrillaBorde DivGrillaDimension">
        
            <asp:GridView runat="server"  ID="gvFirmante" Width="98%" ShowHeader="false"  AutoGenerateColumns="false" CssClass="DivGrillaBorde GridViewStyle" Height="37px"   >
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
              <Columns>
              
              <asp:BoundField DataField="CODIGOFIRMANTE"  ItemStyle-Width="10%" />
              <asp:BoundField DataField="NOMBRES"  ItemStyle-Width="30%" />
              <asp:BoundField DataField="CARGO"   ItemStyle-Width="20%" />
              <asp:BoundField DataField="ENTIDAD"   ItemStyle-Width="20%" />
              <asp:BoundField DataField="DNI"   ItemStyle-Width="10%" />
              <asp:TemplateField  HeaderStyle-CssClass="header-gridview"  ItemStyle-Width="10%"> 
              <ItemTemplate >
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server" ID="btnDelete" 
                      CommandArgument='<%# Eval("CODIGOFIRMANTE") %>' CommandName="_delete" 
                      ImageUrl="~/Images/Iconos/data_delete_on.gif" onclick="btnDelete_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server"  CommandArgument='<%# Eval("CODIGOFIRMANTE") %>' onclick="btnEdit_Click" ID="btnEdit" ImageUrl="~/Images/Iconos/data_edit_on.gif" />
              </ItemTemplate>

<HeaderStyle CssClass="header-gridview"></HeaderStyle>
              </asp:TemplateField>
                                  
              </Columns>
              
              </asp:GridView>
        </div></td></tr>
        <tr><td style="height:30px" valign="middle">
        <asp:Label runat="server" ID="lblNumeroRegistros"></asp:Label>
        </td></tr>
        
        </table>
        
        
        
        </td></tr>
        </table>
        
        
        </td>
        </tr> 
        <tr>
        <td style=" height:30px" valign="bottom">
        <%--<asp:Button runat="server" ID="btnNuevo" Text ="Nuevo Autoridad Firmante" onclick="btnNuevo_Click" />--%>
         <asp:ImageButton runat="server" ID="btnNuevo" ImageUrl="~/Images/Botones/Bnuevo_off.gif" onclick="btnNuevo_Click"    />
        </td>
        </tr>
        </table>
    </div>
    
            
</asp:Content>
