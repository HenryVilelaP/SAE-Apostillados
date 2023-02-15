<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmRegistrarApostilla, App_Web_kt4rh5br" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">

    <asp:Panel runat="server" ID="pnStep1">

<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
PASO 1: Selección de  Datos
</td>
</tr>
<tr>
<td style=" width:20%"></td>
<td>
 
<div class="cajaarriba"> 
 
<div class="cajaabajo"> 
 
                        <table border="0" width="100%"  class="bg_fondo_tabla" >
                            <tr>
                            <td class="etiqueta" style="width:25%;">Fecha</td>
                            <td>
                            <asp:TextBox runat="server"  ID="txtFecha" ReadOnly="true"></asp:TextBox>
                                <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                    TargetControlID="txtFecha" PopupButtonID="imbBtnCal" Format="dd/MM/yyyy">
                                </act:CalendarExtender>
                                <asp:ImageButton ID="imbBtnCal" runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif"  ToolTip="Seleccione Fecha" />
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Autoridad Firmante</td>
                            <td>
                             <ajax:UpdatePanel runat="server" ID="upCargoAutoridad" EnableViewState="true" >
                                <ContentTemplate>
                                         <table id="Table1" runat="server" width="100%" cellpadding="0" cellspacing="0" border="0">
                                         <tr>
                                         <td style="width:50%;"><asp:DropDownList runat="server" ID="ddlFirmante"  OnSelectedIndexChanged="BuscarCargoAutoridad"    AutoPostBack="true" ></asp:DropDownList>  
                                         </td>
                                         <td style="width:50%;"><asp:Label runat="server" ID="lblCargoAutoridad" CssClass="stl_descripcion_dato_ajax"></asp:Label> 
                                         </td></tr> 
                                         </table> 
                                 </ContentTemplate>
                                  <Triggers>
                                  <ajax:AsyncPostBackTrigger ControlID="ddlFirmante" EventName="SelectedIndexChanged" />
                                  </Triggers>
                            </ajax:UpdatePanel>   
                            
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Apostillador</td>
                            <td>
                            <asp:DropDownList runat="server" ID="ddlApostillador" ></asp:DropDownList>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Tipo de Documento</td>
                            <td> 
                            <ajax:UpdatePanel runat="server" ID="upCargaPrecio" EnableViewState="true" >
                                <ContentTemplate>
                                         <table id="tb_tipo_doc" runat="server" width="100%" cellpadding="0" cellspacing="0">
                                         <tr>
                                         <td style="width:50%;"><asp:DropDownList runat="server" ID="ddlTipoDocumento"  OnSelectedIndexChanged="BuscarTarifa"    AutoPostBack="true" ></asp:DropDownList>  
                                         </td>
                                         <td style="width:50%;"><asp:Label runat="server" ID="lblPrecio" CssClass="stl_descripcion_dato_ajax"></asp:Label> 
                                         </td></tr> 
                                         </table> 
                                 </ContentTemplate>
                                  <Triggers>
                                  <ajax:AsyncPostBackTrigger ControlID="ddlTipoDocumento" EventName="SelectedIndexChanged" />
                                  </Triggers>
                            </ajax:UpdatePanel>                                                

                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Nro Operación Bancaria</td>
                            <td>
                            <asp:TextBox runat="server"  ID="txtOperacion"></asp:TextBox>
                                
                            </td>
                            </tr>
                            
                            <tr><td style="height:20px;"></td></tr>
                            
                          
                        </table>
                        </div></div>
</td>
<td style=" width:20%"></td>
</tr>
<tr><td style="height:20px;"  colspan=3></td></tr>
<tr>
                            <td align="center" colspan=3>
                             <asp:ImageButton runat="server" ID="btnRegistrar" ImageUrl="~/Images/Botones/BNext_off.gif" onclick="btnRegistrar_Click"  ToolTip="Ir  al siguiente paso del registro de apostillas."  /> 
                             &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                             <asp:ImageButton runat="server" ID="btnCancelar"  ImageUrl="~/Images/Botones/BCancelar_off.gif" onclick="btnCancelar_Click"  ToolTip="Cancelar apostillado."   /> 
                             </td></tr>


</table>


</asp:Panel>


<asp:Panel runat="server" ID="pnStep2"  Visible="false" >


<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
PASO 2: N&uacute;mero de Apostilla Generado


</td>

</tr>
<tr>
<td style=" width:20%"></td>
<td>
<div class="cajaarriba"> 
<div class="cajaabajo"> 

 <table border="0" width="100%"  class="bg_fondo_tabla">
                             <tr>
                             
                            <td class="etiqueta" style="width:30%">N&uacute;mero de Apostilla</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                                        <table width="100%">
                                        <tr>
                                        <td><asp:Label runat="server"  CssClass="numero_apostilla" ID="lblNumeroApostilla" ></asp:Label></td>
                                        <td align="right"><a href="#" onclick="irApost();" target="_self" title='Ver vista de impresión'>Ver Apostilla <img src="../../Images/Iconos/imprimir.gif" alt="imprimir" border="0"  alt='Ver vista de impresión' /></a></td>
                                        </tr>
                                        </table>
                            
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Fecha</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblFecha"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Autoridad Firmante</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblFirmante"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Apostillador</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblApostillador"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Tipo de Documento</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblTipoDocumento"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Nro Operación Bancaria</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblOperacion"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Adjuntar Archivo de Documento</td> <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:FileUpload runat="server" ID="fuApostilla"  Width="300px" />
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Serie:</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                                <asp:TextBox runat="server"  ID="txtSerie"></asp:TextBox> 
                                &nbsp;&nbsp;Nro:&nbsp;&nbsp;
                                <asp:TextBox  runat="server"  ID="txtNumeroStiker"></asp:TextBox>
                            </td>
                            </tr>
                            <tr><td style="height:20px;"></td></tr>
                            
                            <tr>
                            <td align="center" colspan="3">
                              <asp:ImageButton runat="server" ID="imgBtnBack" ImageUrl="~/Images/Botones/BBack_off.gif" onclick="btnBack_Click" ToolTip="Volver al paso anterior."    />
                                &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                              <asp:ImageButton runat="server" ID="imgBtnNext" ImageUrl="~/Images/Botones/BFinalizar_off.gif" onclick="btnNextGrabarFinal_Click"  ToolTip="Registrar y finalizar el apostillado."     />
                              &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                              <asp:ImageButton runat="server" ID="imgBtnAnular" ImageUrl="~/Images/Botones/BCancelar_off.gif" onclick="btnAnularApostilla_Click"  ToolTip="Cancelar apostillado."    />
                                                
                            </td>
                            </tr>
                            
                        </table>
</div></div>

</td>
<td style=" width:20%"></td>
</tr>
<tr><td colspan="3" style=" height:50px;"></td></tr>
</table>
</asp:Panel>
<asp:Panel runat="server" ID="pnStep3"  Visible="false" >
<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
PASO 3: Finalización de Apostillado


</td>

</tr>
<tr>
<td style=" width:20%"></td>
<td>
<div class="cajaarriba"> 
<div class="cajaabajo"> 

 <table border="0" width="100%"  class="bg_fondo_tabla">
                             <tr>
                             
                            <td class="etiqueta" style="width:30%">N&uacute;mero de Apostilla</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  CssClass="numero_apostilla" ID="lblNumeroApostillaStep3" ></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Fecha</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblFechaStep3"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Autoridad Firmante</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblFirmanteStep3"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Apostillador</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblApostilladorStep3"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Tipo de Documento</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server" ID="lblTipoDocumentoStep3"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Nro Operación Bancaria</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblOperacionStep3"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                        
                            <td class="etiqueta">Ver documento Apostillado</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                                <asp:ImageButton runat="server"  ID="imgApos" ImageUrl="~/Images/Iconos/apostilla.png" 
                                    onclick="imgApos_Click"  />
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Serie</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblSerie"></asp:Label>
                            &nbsp;&nbsp;Nro :&nbsp;&nbsp;
                            <asp:Label runat="server"  ID="lblNumeroSerie"></asp:Label>
                            </td>
                            </tr>
                            <tr><td style="height:20px;"></td></tr>
                            <tr>
                            <td align="center" colspan="3">
                            <a href="FrmRegistrarApostilla.aspx" class="enlaceboton"   title="Ir a registrar otra Apostilla.">Registrar Nueva Apostilla</a>
                            </td>
                            </tr>
                            
                        </table>
</div></div>

</td>
<td style=" width:20%"></td>
</tr>
<tr><td colspan="3" style=" height:50px;">

</td></tr>
</table>
<table>
 


</asp:Panel>
<input type=hidden runat="server" ID="hidNumeroApostilla" />
</asp:Content>

