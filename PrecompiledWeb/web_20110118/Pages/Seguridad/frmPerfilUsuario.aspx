<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="FrmPerfilUsuario, App_Web_h9qob8ft" title="Untitled Page" %>

<%@ Register src="../../UserControl/CuwBuscarLimpiar.ascx" tagname="CuwBuscarLimpiar" tagprefix="uc1" %>

<%@ Register src="../../UserControl/CuwFiltroPerfilUsuario.ascx" tagname="CuwFiltroPerfilUsuario" tagprefix="uc2" %>

<%@ Register src="../../UserControl/CuwGrabarCerrar.ascx" tagname="CuwGrabarCerrar" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">




 <table id="table2"  border="0" cellpadding="0" cellspacing="0" style="width:100%;">
 <tr><td>
     <ajax:UpdatePanel id="upBusquedaRegistros" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 

    <table id="table1"  border="0" style="width:100%;"  cellpadding="0" cellspacing="0" >
        <tr>
            <td colspan="3" >
                <asp:Label ID="lblTitulo" CssClass="titulo" runat="server" Text="Perfiles Asignados a Usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>         
                       
                            <table width="99%" border="0" class="cajaFiltros">
                            <tr>
                                   <td style="height:50px;"> Apellidos y Nombres</td>
                                    <td><asp:TextBox ID="txtNombres" runat="server" Height="19px" Width="249px" /> 
                                    <act:AutoCompleteExtender 
                                                                     ID="txtNombres_AutoCompleteExtender" 
                                                                     runat="server" 
                                                                     DelimiterCharacters="" 
                                                                     Enabled="True" 
                                                                     ServicePath="../../WebService/SAEService.asmx"
                                                                     ServiceMethod="GetNombresUsuariosB"
                                                                     TargetControlID="txtNombres"
                                                                     MinimumPrefixLength="1"
                                                                     CompletionSetCount ="10"
                                                                     CompletionInterval="10"
                                                                     EnableCaching="true"
                                                                     >
                                                        </act:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <uc1:CuwBuscarLimpiar ID="cuwFiltro" runat="server" OnBuscarClick="BuscarDatos" OnLimpiarClick="LimpiarFiltro" />
                                      
                                    </td>
                             </tr>
                            </table>
                                    
                
             </td>
           
        </tr>
        <tr>
        <td align="left" >
        <table width="99%" border="0" >
        <tr>
            <td colspan="3"></td>
        </tr>    
        <tr>
            <td colspan="3" >
               <table border="0" width="100%" cellpadding=0 cellspacing=0>
               <tr>        
                <td class="DivGrillaBorde">
                        <table style="width:100%" cellpadding="0" cellspacing="0" >
                        <tr style=" height:30px">
                        <td class="header-gridview" style="width:2%;" align="center"></td>
              
                        <td class="header-gridview" style="width:10%" align="center">Ubicación</td>                        
                        <td class="header-gridview" style="width:25%" align="center">Oficina</td>
<%--                        <td class="header-gridview" style="width:15%" align="center">Unidad</td>--%>
                        <td class="header-gridview" style="width:20%" align="center">Perfil</td>
                        <td class="header-gridview" style="width:10%" align="center">Modulo</td>
                        <td class="header-gridview" style="width:5%" align="center">Situación</td>
                        <td class="header-gridview" style="width:10%" align="center">Opciones</td>
                        </tr>
                        </table>
                </td>
                </tr>    
               <tr>
               <td style="width:80%;">
                 <div   class="DivGrillaBorde DivGrillaDimension" >
                                        <asp:GridView  runat="server"    ID="gvResultado" Width="97%" OnRowDataBound="gvResultado_RowDataBound"  AutoGenerateColumns="false"   ShowHeader="false" CssClass="GridViewStyle" 
                                                        AlternatingRowStyle-CssClass="GridViewAlternatingRowStyle"
                                                        RowStyle-CssClass="gridviewrowstyle">
                                          
                                                
                                                                                             <Columns>
                                                                                             
                                                                                             <asp:TemplateField ItemStyle-Width="2%" Visible="false" >
                                                                                             
                                                                                             <ItemTemplate   >
                                                                                             <asp:CheckBox runat="server" ID="chkUsuario"/>
                                                                                             </ItemTemplate>
                                                                                             </asp:TemplateField>
                                                                                             <asp:BoundField DataField="NombreUbicacion" ItemStyle-Width="10%"/>
                                                                                             <asp:BoundField DataField="NombreOficina"  ItemStyle-Width="25%"/>
                                                                                             <asp:BoundField DataField="NombrePerfil"  ItemStyle-Width="20%"/> 
                                                                                             <asp:BoundField DataField="Modulo"  ItemStyle-Width="10%"/> 
                                                                                             <asp:BoundField DataField="DescripcionSituacion"  ItemStyle-Width="5%"/> 
                                                                                            <asp:TemplateField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                 <asp:ImageButton runat="server" ID="ImgEdit"  CommandArgument=<%# Eval("CodigoPerfilUsuarioOfi") %>  CommandName="cmdEditar" OnClick="EditarClick"  ImageUrl="~/Images/Iconos/data_edit.gif" />
                                                                                                 <asp:Label runat="server" ID="lblspace" Text ="&nbsp;&nbsp;" ></asp:Label>
                                                                                                 <asp:ImageButton   runat="server" ID="ImgDelete" CommandArgument=<%# Eval("CodigoPerfilUsuarioOfi") %> CommandName="cmdEliminar" OnClick="EliminarClick"   ImageUrl="~/Images/Iconos/data_delete.gif"  />                                                            
                                                                                                 
                                                                                            </ItemTemplate>
                                                                                            
                                                                                            </asp:TemplateField>
                                                                                         
                                                                                              
                                                                                            </Columns>
                                        
                                        </asp:GridView>
                                        </div>
            </td >
            <td valign="middle">
                 
                 <!--AQUI ESTUVOI EL CONTROLDE USUARIO MENU-->
                 
            </td>
               </tr>
               <tr>
                <td style=" height:30px;" valign="middle" id="footer" colspan="1">
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
                                        
            </td>
        </tr> 
         
        </table> 
         
                
</td>                
        </tr>
        <tr>
        <td>
        </td>
        </tr>
    </table>
        </ContentTemplate>

                <Triggers>
                               <ajax:AsyncPostBackTrigger ControlID="cuwFiltro" EventName="LimpiarClick"/>
                               <ajax:AsyncPostBackTrigger ControlID="cuwFiltro" EventName="BuscarClick" />
 
                </Triggers>                
                </ajax:UpdatePanel> 
                
</td></tr>
<tr><td>
                     <asp:ImageButton ID="imgBtnNuevo" runat="server"   ImageUrl="~/Images/Botones/Bnuevo_off.gif" />

</td></tr>                
         </table>
    <!--  B = VENTANA ASIGNACION PERFIL A USUARIO  -->                                  
 <act:ModalPopupExtender 
                            ID="mpeNuevoPerfilUsuario" 
                            runat="server" 
                            BackgroundCssClass="BackgroundPopup" 
                            PopupControlID="pnModalPopupPerfilUsuario"
                            DropShadow="False" 
                            TargetControlID="imgBtnNuevo" 
                             
                             />
                                         
       
    <asp:Panel ID="pnModalPopupPerfilUsuario" runat="server" CssClass="CajaDialogoGeneral" Width="500px" Style="display:none">
                            <ajax:UpdatePanel runat="server" ID="upPerfilUsuario" >
                            <ContentTemplate>
                             
                                 <table border="0" width="100%">
                 <tr>
                 <td class="subTitulo cajaFiltros " >
                 <asp:Label runat="server" ID="lblSubtituloPopUp"  Text="Agregar usuario a perfil"></asp:Label>
                     <asp:Image ID="imgadd" runat="server" ImageUrl="~/Images/Iconos/add.gif" />   
                     </td>
                 </tr>
                 <tr>
                 <td>&nbsp;</td>
                 </tr>
                 <tr>
                 <td>
                 <uc2:CuwFiltroPerfilUsuario 
                        ID="cuwPerfil" 
                        runat="server"  
                        OnPerfilSelectedIndexChanged="PerfilIndexChanged" 
                        OnModuloSelectedIndexChanged="ModuloIndexChanged"  
                        OnUnidadSelectedIndexChanged="UnidadIndexChanged"  
                        OnOficinaSelectedIndexChanged="OficinaIndexChanged"  
                        OnUbicacionSelectedIndexChanged="UbicacionIndexChanged"  
                        
                        /></td>
                 </tr>
                 <tr>
                 <td>Opciones a escoger del Perfil</td>
                 </tr>
                 <tr>
                 <td>&nbsp;</td>
                 </tr>
                 <tr>
                 
                 <td>
                 
                 <div style=" overflow-x:auto ; height:300px; ">
                 
                
                    
                        <asp:GridView ID="gvPerfil" runat="server"  
                                        AutoGenerateColumns="false" 
                                        OnRowCreated="gvPerfil_RowCreated"
                                        OnRowCommand="gvPerfil_RowCommand"
                                        OnRowDataBound="gvPerfil_RowDataBound"
                                         BorderStyle="None" BorderWidth="0" Width=94%
                                        >
                            <HeaderStyle  Height="30px" CssClass="header-gridview"/>            
                        
                        <Columns>
                         <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Iconos/collapseall.png" runat="server"     ID="MinBT"  CommandName="_Hide"  CommandArgument=<%# Eval("CodigoOpcion") %>  />
                        <asp:ImageButton ImageUrl="~/Images/Iconos/expandall.png"   runat="server"  Visible="false"  ID="PluseBT"  CommandName="_Show" CommandArgument=<%# Eval("CodigoOpcion") %> />
                          
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="CodigoOpcionPadre" />
                        <asp:BoundField DataField="CodigoOpcion" />
                        <asp:BoundField DataField="Nombre" HeaderText="Opciones" />
                        
                        <asp:TemplateField HeaderText="Escritura">
                        <ItemTemplate>
                        <asp:RadioButtonList runat="server" ID="OpcionSel" RepeatDirection="Horizontal" RepeatLayout="Table">
                        <asp:ListItem Text="N" Value="N" />  
                        <asp:ListItem Text="W" Value="W" />  
                        <asp:ListItem Text="R" Value="R" />  
                       </asp:RadioButtonList>
                        </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                     </div>
                 </td>
                 
                 </tr>
                 <tr>
                 <td>
                     <uc3:CuwGrabarCerrar ID="cuwAccion" runat="server"  MensajeConfirmacion="¿Desea registrar la asignacion de perfil?"  OnSave_Click="RegistrarPerfilClick" OnClose_Click="ClosePopup"   />
                     </td>
                 </tr>
                 
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

