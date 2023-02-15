<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmBandejaStikers, App_Web_gxtujfme" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">




<div>
    <table width="100%" border="0"> 
       <tr><td style=" height:40px;">
<asp:label runat="server"  Text="Bandeja  Asignaci&oacute;n de Stickers a Apostilladores" ID="lbltitulo" CssClass="titulo"></asp:label>
<hr />
</td></tr>
        <tr>
        <td></td>
        </tr>  
        <tr>
        <td >
        
        <asp:Panel ID="pn1" runat="server" BorderWidth="1" CssClass="cajaFiltros">
        <table width="100%" >
        <tr>
        <td>
        
         <asp:UpdatePanel runat="server" ID="upBandejaStickerApostilla" EnableViewState="true">
        <ContentTemplate>
        
        <table width="100%" border="0" >
         
         <tr>
         <td class="etiqueta">Ubicación</td>
                            <td>
                          
                            <asp:DropDownList runat="server" ID="ddlUbicacion" 
                                    onselectedindexchanged="ddlUbicacion_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                            </td>
                            <td class="etiqueta">Oficina</td>
                            <td>
                            <asp:DropDownList runat="server" ID="ddlOficina" 
                                    onselectedindexchanged="ddlOficina_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td class="etiqueta">Apostillador</td>
                            <td>
                            <asp:DropDownList runat="server" ID="ddlApostillador" ></asp:DropDownList>
                            </td>
                            
        </tr>
         <tr>
         
                            
      <td class="etiqueta">Serie </td>
        <td  colspan="1"><asp:DropDownList runat="server" ID="ddlSerie" ></asp:DropDownList> </td>              
        
        <td class="etiqueta">Situación </td>
        <td  colspan="3"><asp:DropDownList runat="server" ID="ddlSituacion" ></asp:DropDownList> </td>
        
        </tr>
        
      
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td align="right">
        
        <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/Botones/BBuscar_off.gif" onclick="btnBuscar_Click"    />&nbsp;&nbsp;&nbsp;
        <asp:ImageButton runat="server" ID="btnLimpar" ImageUrl="~/Images/Botones/Blimpiar_off.gif" onclick="btnLimpiar_Click"    />
        </td>
        </tr>
        </table>
        </asp:Panel>
        </td>
       </tr>
        <tr>
        <td style=" height:15px" valign="bottom" colspan="8">
        </td>
        </tr>
        <tr><td colspan="8">
      
                                                   <table style="width:100%" cellpadding="0" cellspacing="0" >
                                                            <tr>        
                                                            <td class="DivGrillaBorde">
                                                                    <table style="width:100%" cellpadding="0" cellspacing="0" border="0" >
                                                                    <tr style=" height:30px">
                                                                    <td class="header-gridview" style="width:4%;" align="center">ID</td>
                                                                    <td class="header-gridview" style="width:25%;" align="center">Apostillador</td>
                                                                    <td class="header-gridview" style="width:25%;" align="center">Oficina</td>
                                                                    <td class="header-gridview" style="width:6%" align="left">Nro Serie</td>
                                                                    <td class="header-gridview" style="width:12%" align="left">Correlativo Inicial</td>
                                                                    <td class="header-gridview" style="width:10%" align="left">Correlativo Final</td>
                                                                    <td class="header-gridview" style="width:10%" align="center">Estado</td>
                                                                    <td class="header-gridview" style="width:8%" align="center">Opciones</td>
                                                                    </tr>
                                                                    </table>
                                                            </td>
                                                            </tr>    
                                                            <tr>
                                                            <td>
                                                      <div   class="DivGrillaBorde DivGrillaDimension">
                                                        <asp:GridView runat="server"  ID="gvStickerApostillador" Width="98%" AutoGenerateColumns="false"  ShowHeader="false" CssClass="DivGrillaBorde GridViewStyle" Height="37px"   >
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                          <Columns>
                                                          <asp:TemplateField ItemStyle-Width="4%">
                                                          <ItemTemplate >
                                                          <asp:Label runat="server" ID="lblCodigo" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField  >
                                                          <asp:TemplateField ItemStyle-Width="25%">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblApostilladores" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField >
                                                          <asp:TemplateField ItemStyle-Width="25%">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblOficinas" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblSerie" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField  ItemStyle-Width="12%"  ItemStyle-HorizontalAlign="Center">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblCorrelativoInicial" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblCorrelativoFinal" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField ItemStyle-Width="10%"  ItemStyle-HorizontalAlign="Center">
                                                          <ItemTemplate>
                                                          <asp:Label runat="server" ID="lblSituacion" ></asp:Label>
                                                          </ItemTemplate>
                                                          </asp:TemplateField>
                                                          
                                                          <asp:TemplateField ItemStyle-Width="8%" HeaderStyle-CssClass="header-gridview"   HeaderText="Opciones"> 
                                                          <ItemTemplate  >
                                                          
                                                         &nbsp; 
                                                         <asp:ImageButton runat="server"   ID="btnDelete"  CommandName="_delete" ToolTip="Eliminar Apostilla" ImageUrl="~/Images/Iconos/data_delete.gif" onclick="btnDelete_Click" />
                                                         &nbsp; 
                                                         <asp:ImageButton runat="server"    onclick="btnEdit_Click" ID="btnEdit" ToolTip="Editar Apostilla" ImageUrl="~/Images/Iconos/data_edit.gif" />
                                                         
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
        
        <tr>
        <td style=" height:30px" valign="bottom">
        <%--<asp:Button runat="server" ID="btnNuevo" Text ="Nuevo Apostillador" onclick="btnNuevo_Click" />--%>
        <asp:ImageButton runat="server" ID="btnNuevo"  ImageUrl="~/Images/Botones/Bnuevo_off.gif" onclick="btnNuevo_Click"     />
        </td>
        </tr>
        </table>
        
        
      
    </div>
</asp:Content>

