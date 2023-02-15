<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmBandejaApostilladosConPDF, App_Web_nisepjg2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">



    <%--<div  style="position:absolute;" id="apDivProgresoGeneral" >
    <ajax:UpdateProgress ID="uproFiltros" runat="server" AssociatedUpdatePanelID="upFiltros">
    <ProgressTemplate > 
                     <img alt='' src="../../Images/Iconos/barr-cicle-ajax-loader.gif" />
    </ProgressTemplate>
    </ajax:UpdateProgress>
    </div>--%>
    <asp:UpdatePanel runat="server" ID="upBandejaApostilla" EnableViewState="true" UpdateMode="Conditional">
        
        <ContentTemplate>
<div>
    <table width="100%" border="0"> 
       <tr><td style=" height:40px;">
<asp:label runat="server"  Text="Bandeja  de Apostillas Con PDF Asociado" ID="lbltitulo" CssClass="titulo"></asp:label>
<hr />
</td></tr>
        <tr>
        <td></td>
        </tr>  
        <tr>
        <td>
        
        
        
        <asp:Panel ID="pn1" runat="server" BorderWidth="1" CssClass="cajaFiltros">
      
        
        <table width="100%" border="0" >
        <tr><td>
       
        
       
                        <table width="100%" border="0" >
                         
                         <tr>
                           
                                            <td class="etiqueta">Ubicación</td>
                                            <td>
                                          
                                            <asp:DropDownList runat="server" 
                                                              ID="ddlUbicacion" 
                                                              onselectedindexchanged="ddlUbicacion_SelectedIndexChanged" 
                                                              AutoPostBack="true" 
                                                              />
                                           
                                            </td>
                                            <td class="etiqueta">Oficina</td>
                                            <td>
                                            <asp:DropDownList runat="server" 
                                                              ID="ddlOficina" 
                                                              onselectedindexchanged="ddlOficina_SelectedIndexChanged"  
                                                              AutoPostBack="true"
                                                              />
                                            </td>
                                            <td class="etiqueta">Apostillador</td>
                                            <td>
                                            <asp:DropDownList runat="server" ID="ddlApostillador" ></asp:DropDownList>
                                            </td>
                                             
                                             
                        </tr>
                        
                        <tr>
                        <td style=" height:30px;" class="etiqueta"><asp:Label ID="lblNombre"  runat="server" Text="Fecha" /></td>
                        <td>
                        <asp:TextBox runat="server" ID="txtFecha" Width=60></asp:TextBox>
                        <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFecha" PopupButtonID="imbBtnCal" Format="dd/MM/yyyy">
                                                </act:CalendarExtender>
                                                <asp:ImageButton ID="imbBtnCal"  runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif"  ToolTip="Seleccione Fecha" />
                        </td>
                        <td class="etiqueta"><asp:Label ID="lblPaterno"  runat="server" Text="N&deg; Apostilla" /></td>
                        <td><asp:TextBox runat="server" ID="txtNumeroApostilla" Width="150"></asp:TextBox></td>
                        <td class="etiqueta">Series </td>
                        <td>
                        <asp:DropDownList runat="server" ID="ddlSeries" ></asp:DropDownList> 
                        </td>
                        </tr>
                        
                        <%--<tr>
                        <td class="etiqueta">
                        <asp:Label ID="lblOperacionBancaria"  runat="server" Text="No Operación Bancaria" />
                        </td>
                        <td>
                        <asp:TextBox runat="server" ID="txtNumeroOperacion" Width="70"></asp:TextBox>
                        </td>          
                        <td style=" height:30px;" class="etiqueta">
                        <asp:Label ID="lblTipoDocumento"  runat="server" Text="Tipo de Documento" />
                        </td>
                        <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlTipoDocumento" ></asp:DropDownList>   
                          </td>
                       
                        </tr>--%>
                        </table>
        
      
       </td>
       <td>
                                                          <table>
                                                          <tr><td>
                                                              <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/Botones/BBuscar_off.gif" onclick="btnBuscar_Click"    /> 
                                                          </td></tr>
                                                          <tr><td>
                                                              <asp:ImageButton runat="server" ID="btnLimpar" ImageUrl="~/Images/Botones/Blimpiar_off.gif" onclick="btnLimpiar_Click"    />
                                                          </td></tr>
                                                          
                                                          </table>
       
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
                        <td class="header-gridview" style="width:4%;" align="center">RGE</td>
                        <td class="header-gridview" style="width:4%;" align="center">RGE-OFI</td>
                        <td class="header-gridview" style="width:4%;" align="center">RGE-APOS</td>
                        <td class="header-gridview" style="width:15%" align="center">Nro Apostilla</td>
                        <td class="header-gridview" style="width:10%" align="center">Oficina</td>
                        <td class="header-gridview" style="width:19%" align="center">Apostillador</td>
                        <td class="header-gridview" style="width:10%" align="center">Operación Bancaria</td>
                        <td class="header-gridview" style="width:15%" align="center">Tipo Documento</td>
                        <td class="header-gridview" style="width:5%" align="center">Fecha</td>
                        <td class="header-gridview" style="width:5%" align="center">Estado</td>
                        <td class="header-gridview" style="width:10%" align="center">Opciones</td>
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
              
             
             <asp:ImageButton runat="server" CommandArgument='<%# Eval("CODIGOACTUACION") %>' ID="btnDelete"  CommandName="_delete" ToolTip="Eliminar Apostilla" Width="13" Height="13" ImageUrl="~/Images/Iconos/data_delete.gif" onclick="btnDelete_Click" />
             &nbsp; 
             <asp:ImageButton runat="server"  CommandArgument='<%# Eval("CODIGOACTUACION") %>' onclick="btnEdit_Click" ID="btnEdit" ToolTip="Editar Datos" Width="13" Height="13" ImageUrl="~/Images/Iconos/data_edit.gif" />
             &nbsp; 
             <asp:ImageButton runat="server"  CommandArgument='<%# Eval("CODIGOACTUACION") %>' onclick="imgApos_Click" ID="btnView"  ToolTip="Ver Apostilla" Width="13" Height="13" ImageUrl="~/Images/Iconos/data_view.gif" />
              </ItemTemplate>

<HeaderStyle CssClass="header-gridview"></HeaderStyle>
              </asp:TemplateField>
                  
                              
              </Columns>
              
              </asp:GridView>
        </div></td></tr>
        <tr><td style="height:30px" valign="middle">
      <table border="0" width="100%"  class="cajaFiltros">
      <tr>
      <td>
                       
                       <b> <asp:Label runat="server" ID="lblNumeroRegistros"></asp:Label></b>
      </td> 
      <td align="right">
                        <table border="0">
                        <tr>
                        <td  align="right">
                        <b> <asp:Label runat="server" ID="lblPagina"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</b>
      
                        </td>
                        <td>
                         <asp:ImageButton runat="server" ID="imgbtnStart" ImageUrl="~/Images/Iconos/ico_quitar_todos_off.gif"  ToolTip="ir a la página inicial" />
                        </td>
                        <td>
                        <asp:ImageButton runat="server" ID="imgbtnNext" ImageUrl="~/Images/Iconos/ico_agregar_uno_off.gif"  ToolTip="ir a la página siguiente"   />
                        </td>
                        <td>
                        <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="~/Images/Iconos/ico_quitar_uno_off.gif"  ToolTip="ir a la página anterior"  />
                        </td>
                        <td>
                        <asp:ImageButton runat="server" ID="imgbtnEnd" ImageUrl="~/Images/Iconos/ico_agregar_todos_off.gif"   ToolTip="ir a la página final" />
                        </td>
                        </tr>
                        </table>
                          
                          
                           
                          
      </td>
     
      </tr>
      </table>
      
       
        
      
        </td></tr>
        
        </table>
        </td></tr>
        </table>
        
        
       <asp:HiddenField ID="hidNumeroActuacionApostilla" runat="server" />
    </div>
    
   
    
    
  </ContentTemplate>
                            
      
</asp:UpdatePanel>

 <!--vista apostilla-->
        <!--  B = VENTANA ASIGNACION PERFIL A USUARIO  -->                                  
 <asp:Button runat="server" ID="imgbtn" Width="0" Height="0"/>

 <act:ModalPopupExtender 
                            ID="mpeEditarApostilla" 
                            runat="server" 
                            BackgroundCssClass="BackgroundPopup" 
                            PopupControlID="pnModalPopupEditApostilla"
                            DropShadow="False" 
                            TargetControlID="imgbtn" 
                             />
    <asp:Panel ID="pnModalPopupEditApostilla" runat="server" CssClass="CajaDialogoGeneral stl_texto_sin_negrita" Width="450px" Style="display:none">
     <ajax:UpdatePanel ID="upEdicionApostilla" runat="server">
                                                <ContentTemplate>
                                    <div style="position: absolute; top:0px;  left: 420px;">
                                         <asp:ImageButton runat="server" ToolTip="cerrar ventana" ImageUrl="~/Images/Iconos/close.png"  ID="imgCerrar"    onclick="imgCerrar_Click" />
                                    </div>  
                                    
                                     <table border="0" width="100%" class="bg_fondo_tabla" >
                                     <tr>
                                     <td colspan="2" class="subTitulo header-gridview" align="center" style="height:30px;">Edici&oacute;n de Datos de Apostilla
                                     <hr />
                                      </td>
                                      
                                     <tr>
                                     <td class="etiqueta" >Apostilla </td>
                                     <td> 
                                     <asp:HiddenField runat="server" ID="hidActuacion" />
                                     <asp:HiddenField runat="server" ID="hidNombrePDfApostilla" />
                                     
                                     <asp:Label runat="server" ID="lblNumeroApostilla" CssClass="numero_apostilla"></asp:Label> </td>
                                     </tr>
                                            <tr>
                                            <td class="etiqueta">Fecha</td>
                                            <td>
                                            <asp:TextBox runat="server"  ID="txtFechaEdicion"></asp:TextBox>
                                                <act:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                    TargetControlID="txtFechaEdicion" PopupButtonID="imbBtnCalEdicion" Format="dd/MM/yyyy">
                                                </act:CalendarExtender>
                                                <asp:ImageButton ID="imbBtnCalEdicion" runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif"  ToolTip="Seleccione Fecha" />
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Autoridad Firmante</td>
                                            <td>
                                                        <table>
                                                        <tr><td> <asp:DropDownList runat="server" ID="ddlFirmante"  OnSelectedIndexChanged="BuscarCargoAutoridad"  AutoPostBack="true"></asp:DropDownList></td></tr>
                                                        <tr><td><asp:Label ID="lblCargoAutoridad" runat="server" CssClass="stl_descripcion_dato_ajax"></asp:Label> </td></tr>
                                                        <tr><td><asp:Label ID="lblEntidad" runat="server" CssClass="stl_descripcion_dato_ajax"></asp:Label> </td></tr>
                                                        </table>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Apostillador</td>
                                            <td>
                                            <asp:DropDownList runat="server" ID="ddlApostilladorEdicion"></asp:DropDownList>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Tipo de Documento</td>
                                            <td>
                                            <asp:DropDownList runat="server" ID="ddlTipoDocumento"></asp:DropDownList>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Nro Operación Bancaria</td>
                                            <td>
                                            <asp:TextBox runat="server"  ID="txtOperacion"></asp:TextBox>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Serie</td>   
                                            <td>
                                                <asp:TextBox runat="server"  ID="txtSerie"  Width="50px"> </asp:TextBox> 
                                                &nbsp;&nbsp;<b>Nro</b>&nbsp;&nbsp;
                                                <asp:TextBox  runat="server"  ID="txtNumeroStiker" Width="100px"></asp:TextBox>
                                            </td>
                                            </tr>
                                           <tr>
                                           <td colspan="2" align="center"  style="height:50" valign="middle">
                                             <asp:ImageButton runat="server" ID="btnRegistrar" ImageUrl="~/Images/Botones/BRegistrar_off.gif" onclick="btnRegistrar_Click"  ToolTip="Registar la actualización de Apostilla."  /> 
                                             &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                                             <asp:ImageButton runat="server" ID="btnCancelar"  ImageUrl="~/Images/Botones/BCancelar_off.gif" onclick="btnCancelar_Click"  ToolTip="Cancelar actualización."   /> 
                             
                                           </td>
                                           </tr> 
                                           <tr>
                                           <td colspan="2"></td>
                                           </tr> 
                                            
                                        </table>
                                      
                                        
    
    
     </ContentTemplate>
                                                <Triggers>
                                                <ajax:AsyncPostBackTrigger ControlID="imgCerrar" EventName="Click" />
                                                <ajax:AsyncPostBackTrigger ControlID="ddlFirmante" EventName="SelectedIndexChanged" />
                                                <ajax:AsyncPostBackTrigger ControlID="btnRegistrar" EventName="Click" />
                                             
                                                </Triggers> 
                                                </ajax:UpdatePanel>
     </asp:Panel>
 </asp:Content>