<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmBandejaApostillados, App_Web_rjotmaad" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">




<div>
    <table width="100%" border="0"> 
       <tr><td style=" height:40px;">
<asp:label runat="server"  Text="Bandeja  de Apostillas" ID="lbltitulo" CssClass="titulo"></asp:label>
<hr />
</td></tr>
        <tr>
        <td></td>
        </tr>  
        <tr>
        <td >
        
        <asp:Panel ID="pn1" runat="server" BorderWidth=1 CssClass="cajaFiltros">
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
                             <td rowspan="3" align="right">&nbsp;&nbsp;&nbsp;&nbsp;
      <%--  <asp:Button runat="server" ID="brnBuscar" Text="Buscar" onclick="btnBuscar_Click" />--%>
         <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/Botones/BBuscar_off.gif" onclick="btnBuscar_Click"    />&nbsp;&nbsp;&nbsp;
        <asp:ImageButton runat="server" ID="btnLimpar" ImageUrl="~/Images/Botones/Blimpiar_off.gif" onclick="btnLimpiar_Click"    />
      
        </td>
        </tr>
        <tr>
         
                            
                    
        <td style=" height:30px;" class="etiqueta"><asp:Label ID="lblNombre"  runat="server" Text="Fecha" /></td>
        <td>
        <asp:TextBox runat="server" ID="txtFecha" Width=70></asp:TextBox>
        <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                    TargetControlID="txtFecha" PopupButtonID="imbBtnCal" Format="dd/MM/yyyy">
                                </act:CalendarExtender>
                                <asp:ImageButton ID="imbBtnCal" runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif"  ToolTip="Seleccione Fecha" />
        </td>
        <td class="etiqueta"><asp:Label ID="lblPaterno"  runat="server" Text="Número de Apostilla" /></td>
        <td><asp:TextBox runat="server" ID="txtNumeroApostilla"></asp:TextBox></td>
        <td class="etiqueta">Situación </td>
        <td><asp:DropDownList runat="server" ID="ddlSituacion" ></asp:DropDownList> </td>
       
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
                        <td class="header-gridview" style="width:4%;" align="center">RGE</td>
                        <td class="header-gridview" style="width:4%;" align="center">RGE-OFI</td>
                        <td class="header-gridview" style="width:4%;" align="center">RGE-APOS</td>
                        <td class="header-gridview" style="width:15%" align="center">Nro Apostilla</td>
                        <td class="header-gridview" style="width:10%" align="center">Oficina</td>
                        <td class="header-gridview" style="width:19%" align="center">Apostillador</td>
                        <td class="header-gridview" style="width:10%" align="center">Operación Bancaria</td>
                        <td class="header-gridview" style="width:15%" align="center">Tipo Documento</td>
                        <td class="header-gridview" style="width:10%" align="center">Fecha</td>
                        <td class="header-gridview" style="width:8%" align="center">Estado</td>
                        <td class="header-gridview" style="width:8%" align="center">Opciones</td>
                        </tr>
                        </table>
                </td>
                </tr>    
                <tr>
                <td>
          <div   class="DivGrillaBorde DivGrillaDimension">
            <asp:GridView runat="server"  ID="gvApostillas" Width="98%" AutoGenerateColumns="false"  ShowHeader="false" CssClass="DivGrillaBorde GridViewStyle" Height="37px"   >
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
              <Columns>
              
              <asp:BoundField DataField="CODIGOACTUACION"  HeaderText="ID" HeaderStyle-CssClass="header-gridview"   >
              <ItemStyle   Width="4%"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="CODIGOACTUACIONOFICINA"  HeaderText="ID" HeaderStyle-CssClass="header-gridview" >
              <ItemStyle  Width="4%"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="CORRELATIVO"  HeaderText="ID" HeaderStyle-CssClass="header-gridview" >
               <ItemStyle  Width="4%"></ItemStyle>
              </asp:BoundField>
              
              <asp:BoundField DataField="NUMEROAPOSTILLA"  HeaderText="Nro Apostilla" HeaderStyle-CssClass="header-gridview" >
                <ItemStyle  Width="15%"></ItemStyle>
              </asp:BoundField>
               
              <asp:BoundField DataField="OFICINA" HeaderText="Apostillador" HeaderStyle-CssClass="header-gridview" >
               <ItemStyle  Width="10%"></ItemStyle>
              </asp:BoundField>
               
               <asp:BoundField DataField="NOMBRESAPOSTILLADOR" HeaderText="Apostillador" HeaderStyle-CssClass="header-gridview" >
               <ItemStyle  Width="20%"></ItemStyle>
              </asp:BoundField>
             
              <asp:BoundField DataField="OPERACIONBANCARIA" HeaderText="Operación Bancaria" HeaderStyle-CssClass="header-gridview" >
               <ItemStyle  Width="10%"></ItemStyle>
              </asp:BoundField>	

              <asp:BoundField DataField="NOMBRETIPODOCUMENTO" HeaderText="Tipo Documento" HeaderStyle-CssClass="header-gridview" >
              <ItemStyle  Width="15%"></ItemStyle>
              </asp:BoundField>	
              <asp:BoundField DataField="FECHAAPOSTILLA" DataFormatString="{0:d}" HeaderText="Fecha" HeaderStyle-CssClass="header-gridview" >
              <HeaderStyle CssClass="header-gridview"  Width="10%"></HeaderStyle>
              </asp:BoundField>	
              	
              	<asp:BoundField DataField="SITUACIONDESCRIPCION" HeaderText="Estado" HeaderStyle-CssClass="header-gridview" >
              <HeaderStyle CssClass="header-gridview"  Width="8%"></HeaderStyle>
              </asp:BoundField>	
              <asp:TemplateField  HeaderStyle-CssClass="header-gridview"   HeaderText="Opciones"> 
              <ItemTemplate  >
              
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server" ID="btnDelete" 
                      CommandArgument='<%# Eval("CODIGOACTUACION") %>' CommandName="_delete" 
                      ImageUrl="~/Images/Iconos/data_delete_on.gif" onclick="btnDelete_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:ImageButton runat="server"  CommandArgument='<%# Eval("CODIGOACTUACION") %>' onclick="btnEdit_Click" ID="btnEdit" ImageUrl="~/Images/Iconos/data_edit_on.gif" />
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
       
        </td>
        </tr>
        </table>
    </div>
</asp:Content>

