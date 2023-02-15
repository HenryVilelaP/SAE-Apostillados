<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="FrmUsuario, App_Web_2v6kqq6r" %>
<%@ Register src="../../UserControl/CuwBuscarLimpiar.ascx" tagname="CuwBuscarLimpiar" tagprefix="uc1" %>
<%@ Register src="../../UserControl/CuwConfirmar.ascx" tagname="CuwConfirmar" tagprefix="uc2" %>
<%@ Register src="../../UserControl/CuwAceptar.ascx" tagname="CuwAceptar" tagprefix="uc3" %>
<%@ Register src="../../UserControl/CuwFiltroPerfilUsuario.ascx" tagname="CuwFiltroPerfilUsuario" tagprefix="uc4" %>
<%@ Register src="../../UserControl/CuwGrabarCerrar.ascx" tagname="CuwGrabarCerrar" tagprefix="uc5" %>
     

<asp:Content ID="Content2" ContentPlaceHolderID="cphCuerpo" Runat="Server">
 
 

    <script src="../../Scripts/common.js" type="text/javascript"></script>
    <table style="width:100%;">
  <tr><td align="center">
  <div style=" overflow:auto ;"> 
        
    <table style="width:90%;">
        <tr>
            <td>
                <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="Mantenimiento de Usuarios"></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td> &nbsp;</td>
           
        </tr>
        <tr>
            <td align="left">
            
             <asp:Panel ID="pn1" runat="server" BorderWidth=1 CssClass="cajaFiltros">
              <ajax:UpdatePanel runat="server"  ID="upBusqueda" UpdateMode="Conditional">
             <ContentTemplate> 
                              <table width="100%">
                            <tr>
                            <td><asp:Label ID="lblNombres" runat="server" Text="Nombres y Apellidos"></asp:Label>
                               
                                </td>
                            <td >
                            
                                <asp:TextBox ID="txtNombres" autocomplete="off" runat="server" Height="22px" Width="376px"  ></asp:TextBox>
                                <act:AutoCompleteExtender 
                                             ID="txtNombres_AutoCompleteExtender" 
                                             runat="server" 
                                             DelimiterCharacters="" 
                                             Enabled="True" 
                                             ServicePath="../../WebService/SAEService.asmx"
                                             ServiceMethod="GetNombresUsuarios"
                                             TargetControlID="txtNombres"
                                             MinimumPrefixLength="1"
                                             CompletionSetCount ="10"
                                             CompletionInterval="10"
                                             EnableCaching="true"
                                             >
                                </act:AutoCompleteExtender>
                            
                            
                            </td>
                            <td rowspan="4"> 
                                <uc1:CuwBuscarLimpiar ID="cuwBuscarLimpiar" 
                                                    runat="server" 
                                                    OnLimpiarClick="cuwBuscarLimpiar_OnLimpiarClick" 
                                                    OnBuscarClick="cuwBuscarLimpiar_OnBuscarClick"    />
                             
                                </td>
                            </tr>
                            <tr>
                            <td><asp:Label ID="lblOficina" runat="server" Text="Oficina"></asp:Label></td>
                            <td style="width: 511px">
                            <asp:DropDownList ID="ddlOficina" runat="server" />
                            </td>
                            
                            </tr>
                            <tr>
                            <td><asp:Label ID="lblSituacionRegistro" runat="server" Text="Situación"></asp:Label></td>
                            <td style="width: 511px">
                            <asp:DropDownList ID="ddlSituacion" runat="server" />
                            </td>
                            
                            </tr>
                            </table>
                              
            </ContentTemplate>
            <Triggers>
                <ajax:AsyncPostBackTrigger ControlID="cuwBuscarLimpiar" EventName="LimpiarClick" />
                <ajax:AsyncPostBackTrigger ControlID="cuwBuscarLimpiar" EventName="BuscarClick" />
               
                
                </Triggers>
            </ajax:UpdatePanel>                              
                </asp:Panel>
                 
           
                
            </td>
            
        </tr>
        <tr><td style=" height:30px" align="right">
        
            </td></tr>
        <tr>
        <td align="left">
             <ajax:UpdatePanel runat="server"  ID="upControlGrilla" UpdateMode="Conditional">
             <ContentTemplate> 
        
                <table style="width:100%" cellpadding="0" cellspacing="0" >
                <tr>        
                <td class="DivGrillaBorde">
                        <table style="width:100%" cellpadding="0" cellspacing="0" >
                        <tr style=" height:30px">
                        <td class="header-gridview" style="width:6%;" align="center">ID</td>
                        <td class="header-gridview" style="width:20%" align="center">Nombre</td>
                        <td class="header-gridview" style="width:10%" align="center">Dominio</td>
                        <td class="header-gridview" style="width:15%" align="center">Usuario Red</td>
                        <%--<td class="header-gridview" style="width:15%" align="center">Oficina</td>
                        <td class="header-gridview" style="width:15%" align="center">Perfil</td>--%>
                        <td class="header-gridview" style="width:10%" align="center">Situacion</td>
                        <td class="header-gridview" style="width:9%" align="center">Opciones</td>
                        </tr>
                        </table>
                </td>
                </tr>    
                <tr>
                <td>
                                        <div   class="DivGrillaBorde DivGrillaDimension">
                                        <asp:GridView  runat="server"    ID="gvResultado" Width="98%" 
                                                       AutoGenerateColumns="false"   
                                                       OnRowDataBound="gvResultado_RowDataBound" 
                                                       ShowHeader="false" >
                                                <RowStyle BackColor="whitesmoke"   />
                                                <HeaderStyle  CssClass="header-gridview"  />
                                                <AlternatingRowStyle BackColor="White" />
                                                
                                                                                             <Columns>
                                                                                             <asp:TemplateField ItemStyle-Width="6%" >
                                                                                             
                                                                                             <ItemTemplate   >
                                                                                             <asp:CheckBox runat="server" ID="chkUsuario"  Text=<%# Eval("Codigo") %> />
                                                                                             </ItemTemplate>
                                                                                             </asp:TemplateField>
                                                                                              
                                                                                             <asp:BoundField DataField="NombreCompleto" ItemStyle-Width="20%" />
                                                                                             <asp:BoundField DataField="Dominio" ItemStyle-Width="10%" />
                                                                                             <asp:BoundField DataField="UsuarioRed"  ItemStyle-Width="15%" />
                                                                                             <%--<asp:BoundField DataField="OficinaAsignada"  ItemStyle-Width="15%"/>
                                                                                             <asp:BoundField DataField="NombrePerfil" ItemStyle-Width="15%"/>--%>
                                                                                             <asp:BoundField DataField="DescripcionSituacion" ItemStyle-Width="10%"/>
                                                                                             
                                                                                            <asp:TemplateField ItemStyle-Width="9%" ItemStyle-HorizontalAlign="Center">
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                 <asp:ImageButton runat="server" ID="ImgEdit"  CommandArgument=<%# Eval("Codigo") %> CommandName="cmdEditar" OnClick="EditarClick"  ImageUrl="~/Images/Iconos/data_edit.gif" />
                                                                                                 <asp:Label runat="server" ID="lblspace" Text ="&nbsp;&nbsp;&nbsp;" ></asp:Label>
                                                                                                 <asp:ImageButton   runat="server" ID="ImgDelete" CommandArgument=<%# Eval("Codigo") %> CommandName="cmdEliminar" OnClick="EliminarClick"   ImageUrl="~/Images/Iconos/data_delete.gif"  />                                                            
                                                                                            </ItemTemplate>
                                                                                            
                                                                                            </asp:TemplateField>
                                                                                         
                                                                                              
                                                                                            </Columns>
                                        
                                        </asp:GridView>
                                        </div>
                </td>
                </tr>
                <tr>
                <td style=" height:30px;" valign="middle" id="footer">
                                        <table width="100%" border="0">
                                        <tr >
                                        <td >
 
                                        </td>
                                        <td  align="right">
                                            <asp:Label runat="server" ID="lblNumeroRegistro" /></b>
                                        </td>
                                        </tr>
                                            
                                        </table>
                </td>
                </tr>
                </table>
                </ContentTemplate>
                <Triggers >
                <ajax:AsyncPostBackTrigger ControlID="cuwBuscarLimpiar" EventName="LimpiarClick" />
                <ajax:AsyncPostBackTrigger ControlID="cuwBuscarLimpiar" EventName="BuscarClick" /> 
             <%--   <ajax:AsyncPostBackTrigger ControlID="imgBtnSelAll" EventName="Click" /> --%>
                                          
 
                                          
                </Triggers>

                </ajax:UpdatePanel>
             
        </td>
        </tr>
        <tr>
        <td style=" height:30px;" valign="middle" id="Td1">
                                        <table width="100%" border="0">
                                        <tr >
                                        <td >
                                     <%--   <asp:ImageButton ID="imgBtnSelAll" runat="server"   ImageUrl="~/Images/Botones/Bseleccionar_off.gif" onClick="SelectAllChk_Click" />
                                          <asp:ImageButton ID="imgBtnEliminar" runat="server"   ImageUrl="~/Images/Botones/Beliminar_off.gif" />--%>
                                          <asp:ImageButton ID="imgBtnNuevo" runat="server"   ImageUrl="~/Images/Botones/Bnuevo_off.gif" />
                                            
                                        </td>
                                        </tr>
                                            
                                        </table>
         </td>
        </tr>
        
    </table>
       
      
</td></tr>
</table>
  <!--  A = VENTANA DE CONFIRMACION ELIMINACION -->
  <asp:Button runat="server"  ID="btnTest"  Width="0"  Height="0" />
          <act:ModalPopupExtender 
                            ID="mpeConfirmacion" 
                            runat="server" 
                            BackgroundCssClass="BackgroundPopup" 
                            PopupControlID="pnModalPopupConfirmacion"
                            DropShadow="True" 
                            TargetControlID="btnTest" />
                            
                            <asp:Panel ID="pnModalPopupConfirmacion" runat="server" CssClass="CajaDialogoConfirmacion" Style="display: none"> 
                                 <ajax:UpdatePanel runat="server" ID="upPopUpConfirmEliminar">
                                 <ContentTemplate>
                                 
                                     <uc2:CuwConfirmar 
                                     ID="cuwConfirmar" 
                                     runat="server" 
                                     PreguntaText="Desea eliminar los usuarios seleccionados" 
                                     TituloMensajeConfirmacionText="Confirmacion de Eliminación" 
                                     OnCancelarClick="btnCancelar_Click" 
                                     OnConfirmarClick="btnOk_Click" 
                                     Visible="true"/>
                                     
                                     <uc3:CuwAceptar 
                                     ID="cuwAlerta" 
                                     runat="server" 
                                     OnOkClick="Alerta_Click" 
                                     Titulo="Confirmacion de Eliminación" 
                                     Visible="false" /> 
                                                                                         
                                 </ContentTemplate>
                                 <Triggers>
                                          <ajax:AsyncPostBackTrigger ControlID="cuwConfirmar" EventName="CancelarClick" />
                                          <ajax:AsyncPostBackTrigger ControlID="cuwConfirmar" EventName="ConfirmarClick" />
                                          <ajax:AsyncPostBackTrigger ControlID="cuwAlerta" EventName="OkClick" />
                                      
                                 </Triggers>
                                 </ajax:UpdatePanel>
                             </asp:Panel>  
                             
  <!-- END A  -->  
  
  
  <!--  B = VENTANA NUEVO/EDICION  -->                                  
 <act:ModalPopupExtender 
                            ID="mpeNuevoEdicion" 
                            runat="server" 
                            BackgroundCssClass="BackgroundPopup" 
                            PopupControlID="pnModalPopupNuevo"
                            DropShadow="True" 
                            TargetControlID="imgBtnNuevo" 
                             />
                            
                <asp:Panel ID="pnModalPopupNuevo" runat="server" CssClass="CajaDialogoGeneral" Width="450px" Style="display:none">
                            <ajax:UpdatePanel runat="server" ID="upNuevoEdicion" >
                            <ContentTemplate>
                             
                                        <table border= "0" width="99%">
                                        <tr><td colspan="4" class="cabeceraSubTitulo"><asp:Label ID="lblTituloNuevoEdit" runat="server" /></td></tr>
                                       
                                        <tr>
                                        <td><asp:Label Text ="Tipo Documento" runat="server" ID="lblTipoDoc" /></td>
                                        <td>
                                           <asp:DropDownList runat="server" ID="ddlTipoDoc" /> 
                                       
                                        </td>
                                        <td><asp:Label Text ="Num Doc" runat="server" ID="lblNumDocumento" /></td><td> 
                                        <table>
                                        <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtNumDocumento" Width="100px"  />
                                        </td>
                                        <td>
                                           <asp:UpdatePanel ID="upBuscarDNI" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imbBuscar" runat="server" OnClick ="BuscarPersona" ImageUrl="~/Images/Iconos/ico_lupa.gif" />
                                                </ContentTemplate>
                                                <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="imbBuscar" EventName="Click" />
                                                </triggers>
                                                </asp:UpdatePanel>
                                        </td>
                                        
                                        </tr>
                                        
                                        </table>
                                          
                                          
                                        </td>
                                        </tr>
                                        
                                        
                                        <tr>
                                        <td>Nombres</td><td colspan="3"> 
                                            <asp:TextBox runat="server" ID="txtNombre" Width="300px"  />
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>Apellido Paterno</td>
                                        <td> 
                                        <asp:TextBox runat="server" ID="txtApePaterno" Width="150px"  />
                                        </td>
                                        <td>Apellido Materno</td><td> 
                                        <asp:TextBox runat="server" ID="txtApeMaterno" Width="150px" />
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        <td>Dominio</td><td>
                                         <asp:TextBox runat="server" ID="txtDominio" Width="150px" />
                                         </td>
                                        <td>Usuario NT</td><td> 
                                        <asp:TextBox runat="server" ID="txtUserNT" Width="150px"  />
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        <td >Correo</td>
                                        <td align="left"><asp:TextBox runat="server" ID="txtCorreo" Width="150px"/></td>
                                        <td >Situación</td>
                                        <td align="left"><asp:DropDownList runat="server" ID="ddlSituacionNuevo"></asp:DropDownList></td>
                                        </tr>
                                        
                                        <tr>
                                        <td >Pais</td>
                                        <td align="left"><asp:DropDownList runat="server" ID="ddlPais" Width="150px" ></asp:DropDownList></td>
                                        <td >Fecha Nac</td>
                                        <td align="left">
                                        <asp:TextBox runat="server" ID="txtFechaNac" Width="100"/>
                                        <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" Enabled="True"
                                        CssClass="cal_Theme1" PopupButtonID="imgCalendario" Format="dd/MM/yyyy" TargetControlID="txtFechaNac">
                                    </act:CalendarExtender>
                                    <asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif" />
                                        </td>
                                        </tr>
                                        <tr>
                                        <td>Sexo</td><td colspan="3"> 
                                          
                                          <asp:RadioButton runat="server" ID="rbdSexoF" Text="Femenino" GroupName="GrbdSexo"   />
                                          <asp:RadioButton runat="server" ID="rbdSexoM" Text="Masculino" GroupName="GrbdSexo"   />
                                        </td>                                          
                                        </tr>
                                        <tr> <td align="center" colspan="4">
                                                <uc5:CuwGrabarCerrar ID="cuwAccion" OnClose_Click="cuwAccion_Close_Click" OnSave_Click="cuwAccion_Save_Click" runat="server"  />
                                        </td>
                                        </tr>
                                        <tr><td align="center" colspan="4" style="height:30px; ">
                                        <asp:Label runat="server" CssClass="msg_error" ID="lblMsgNuevoEdicion" ></asp:Label>
                                      
                                        
                                        </td></tr>
                                        <tr><td align="left" colspan="4" style="height:30px; ">
                                          
                                            <asp:Label runat="server"  CssClass="validador" ID="lblEtiquetas" Text ="* Campo obligatorio" ></asp:Label>&nbsp;&nbsp;
                                            <asp:Label runat="server" CssClass="validador" ID="Label1" Text ="[*] Formato incorrecto" ></asp:Label>
                                      
                                        
                                        </td></tr>
                                        
                                        </table>
 
                            </ContentTemplate>
                            <Triggers>
                             <ajax:AsyncPostBackTrigger ControlID="cuwAccion" EventName="Close_Click" />
                             <ajax:AsyncPostBackTrigger ControlID="cuwAccion" EventName="Save_Click" />
                            
                               
                            
                            </Triggers>
                            </ajax:UpdatePanel> 
        
    </asp:Panel>
<!---END B-->
   
</asp:Content>
 
