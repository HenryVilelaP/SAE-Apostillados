<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_frmParametro, App_Web_rjotmaad" title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphCuerpo" Runat="Server">
 <div>
    <table width="100%"> 
        <tr><td style=" height:40px;">
<asp:label runat="server"  Text="Mantenimiento de Parametros" ID="lbltitulo" CssClass="titulo"></asp:label>
<hr />
</td></tr>
        <tr>
        <td></td>
        </tr>  
        <tr>
        <td>
        <table width="100%">
        
        <tr><td>
        <asp:Label ID="lblTabla"  runat="server" Text="Tabla" />
        </td><td>
        <asp:DropDownList runat="server" ID="ddltabla"  AutoPostBack="true"
                    onselectedindexchanged="ddltabla_SelectedIndexChanged" />
        </td></tr>
        <tr>
        <td style=" height:15px" valign="bottom">
        </td>
        </tr>
        <tr><td colspan="2">
      <table style="width:100%" cellpadding="0" cellspacing="0" >
                <tr>        
                <td class="DivGrillaBorde">
                        <table style="width:100%" cellpadding="0" cellspacing="0" border="0" >
                        <tr style=" height:30px">
                        <td class="header-gridview" style="width:10%;" align="left">ID Parametro</td>
                        <td class="header-gridview" style="width:10%" align="left">ID Tabla</td>
                        <td class="header-gridview" style="width:10%" align="left">ID Registro</td>
                        <td class="header-gridview" style="width:20%" align="center">Descripción</td>
                        <td class="header-gridview" style="width:10%" align="left">Valor Numerico</td>
                        <td class="header-gridview" style="width:7%" align="left">Valor Texto</td>
                        <td class="header-gridview" style="width:13%" align="center">Modificable</td>
                        <td class="header-gridview" style="width:10%" align="left">Eliminable</td>
                        <td class="header-gridview" style="width:10%" align="left">Operaciones</td>
                        
                        </tr>
                        </table>
                </td>
                </tr>    
                <tr>
                <td>
          <div   class="DivGrillaBorde DivGrillaDimension">
        
            <asp:GridView runat="server"  ID="gvparametros" Width="99%" ShowHeader="false" AutoGenerateColumns="false" CssClass="DivGrillaBorde GridViewStyle" Height="37px"   >
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
              <Columns>
              <asp:BoundField DataField="CODIGOPARAMETRO"  HeaderStyle-CssClass="header-gridview"  ItemStyle-Width="10%" />
              <asp:BoundField DataField="CODIGOTABLA"  HeaderStyle-CssClass="header-gridview"   ItemStyle-Width="10%" />
              <asp:BoundField DataField="CODIGOREGISTRO"   HeaderStyle-CssClass="header-gridview"  ItemStyle-Width="10%" />
              <asp:BoundField DataField="NOMBREPARAMETRO" HeaderStyle-CssClass="header-gridview"   ItemStyle-Width="20%" />
              <asp:BoundField DataField="VALORNUMERICO"    HeaderStyle-CssClass="header-gridview"  ItemStyle-Width="10%" />
              <asp:BoundField DataField="VALORTEXTO"    HeaderStyle-CssClass="header-gridview" ItemStyle-Width="10%" />
              <asp:BoundField DataField="FLAGMODIFICAR"     HeaderStyle-CssClass="header-gridview" ItemStyle-Width="10%"  />
             <asp:BoundField DataField="FLAGELIMINAR"   HeaderStyle-CssClass="header-gridview" ItemStyle-Width="10%" />
              <asp:TemplateField  HeaderStyle-CssClass="header-gridview"    ItemStyle-Width="10%" > 
              <ItemTemplate >
              
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server" ID="btnDelete" 
                      CommandArgument='<%# Eval("CODIGOPARAMETRO") %>' CommandName="_delete" 
                      ImageUrl="~/Images/Iconos/data_delete_on.gif" onclick="btnDelete_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server"  CommandArgument='<%# Eval("CODIGOPARAMETRO") %>' onclick="btnEdit_Click" ID="btnEdit" ImageUrl="~/Images/Iconos/data_edit_on.gif" />
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
        <%--<asp:Button runat="server" ID="btnNuevo" Text ="Nuevo Parametro" onclick="btnNuevo_Click" />--%>
         <asp:ImageButton runat="server" ID="btnNuevo" ImageUrl="~/Images/Botones/Bnuevo_off.gif" onclick="btnNuevo_Click"    />
        </td>
        </tr>
        </table>
    </div>
    
            
</asp:Content>

