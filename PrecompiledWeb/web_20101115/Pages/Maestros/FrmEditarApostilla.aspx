<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmEditarApostilla, App_Web_nisepjg2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">


<asp:Panel runat="server" ID="pnDatos">

<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
Impresi&oacute;n de Apostilla :   <asp:Label runat="server"  CssClass="numero_apostilla" ID="lblNumeroApostilla" ></asp:Label>
</td>
</tr>
<tr>
<td style=" width:20%"></td>
<td>
 
<div class="cajaarriba"> 
 
<div class="cajaabajo"> 
                 <asp:Panel runat="server" ID="pnActualizar">
                                        <table border="0" width="100%" class="bg_fondo_tabla" >
                                            <tr>
                                            <td class="etiqueta">Fecha</td>
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
                                            <asp:DropDownList runat="server" ID="ddlFirmante"></asp:DropDownList>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="etiqueta">Apostillador</td>
                                            <td>
                                            <asp:DropDownList runat="server" ID="ddlApostillador"></asp:DropDownList>
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
                                            <td class="etiqueta">Nro Ticket</td>
                                            <td>
                                            <asp:TextBox runat="server"  ID="txtNumeroTicket"></asp:TextBox>
                                            </td>
                                            </tr>
                                          <%--  <tr>
                                            <td class="etiqueta">Adjuntar Archivo de Documento</td>
                                            <td>
                                            <asp:FileUpload runat="server" ID="fuApostilla"  Width="300px" />
                                            </td>
                                            </tr>
                                            <tr>
                                        
                                            <td class="etiqueta">Ver documento Apostillado</td>  
                                            <td style="text-align:left;">
                                                <asp:ImageButton runat="server"  ID="imgApos" ImageUrl="~/Images/Iconos/apostilla.png" 
                                                    onclick="imgApos_Click"  />
                                            </td>
                                            </tr>--%>
                                            <tr>
                                            <td class="etiqueta">Serie</td>   
                                            <td>
                                                <asp:TextBox runat="server"  ID="txtSerie"></asp:TextBox> 
                                                &nbsp;&nbsp;<b>Nro</b>&nbsp;&nbsp;
                                                <asp:TextBox  runat="server"  ID="txtNumeroStiker"></asp:TextBox>
                                            </td>
                                            </tr>
                                            <tr> 
                                              <td></td> 
                                            <td style=" height:40px;" valign="bottom"><a href="#" onclick="irApost();" target="_self" title='Ver vista de impresión' style="font-size:12px;">Imprimir Apostilla Con Firma <img src="../../Images/Iconos/imprimir.gif" alt="imprimir" border="0"  alt='Ver vista de impresión' /></a> 
                                            </td></tr>
                                             </tr>
                                            <tr> 
                                              <td></td> 
                                            <td style=" height:40px;" valign="bottom"><a href="#" onclick="irApostSinFirma();" target="_self" title='Ver vista de impresión de apostilla sin firma' style="font-size:12px;">Imprimir Apostilla Sin Firma <img src="../../Images/Iconos/imprimir.gif" alt="imprimir" border="0"  alt='Ver vista de impresión' /></a> 
                                            </td></tr>
                                            
                                        </table>
                </asp:Panel>   

                <asp:Panel runat="server" ID="pnresultado" Visible="false">
                 <table border="0" width="100%" class="bg_fondo_tabla" >
                            <tr>
                            <td class="etiqueta">Fecha</td>
                            <td>
                            <asp:Label runat="server" ID="lblFecha"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Autoridad Firmante</td>
                            <td>
                            <asp:Label runat="server" ID="lblAutoridad"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Apostillador</td>
                            <td>
                            <asp:Label runat="server" ID="lblApostillador"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Tipo de Documento</td>
                            <td>
                            <asp:Label runat="server" ID="lblTipoDoc"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Nro Operación Bancaria</td>
                            <td>
                            <asp:Label runat="server" ID="lblNroOperacion"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Ver documento Apostillado</td>  
                            <td style="text-align:left;">
                                <asp:ImageButton runat="server"  ID="imgApos2" ImageUrl="~/Images/Iconos/apostilla.png" 
                                    onclick="imgApos_Click"  />
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Serie</td>   
                            <td>
                               <asp:Label runat="server" ID="lblserie"></asp:Label>
                                &nbsp;&nbsp;<b>Nro</b>&nbsp;&nbsp;
                               <asp:Label runat="server" ID="lblNumeroSerie"></asp:Label>
                            </td>
                            </tr>
                             <tr>
                            <td align="center" colspan="3" style=" height:30px">
                            </td></tr>
                            <tr>
                            <td align="center" colspan="3">
                            <a href="FrmBandejaApostillados.aspx" class="enlaceboton"   title="Ir a bandeja de Apostillas.">ir a bandejas de Apostillas</a>
                            </td>
                            </tr>
                        </table>
                </asp:Panel>   
                     
</div></div>
</td>
<td style=" width:20%"></td>
</tr>
<tr><td style="height:20px;"  colspan=3></td></tr>
<tr>
                            <td align="center" colspan=3>
                             <asp:ImageButton runat="server" ID="btnRegistrar" 
                                    ImageUrl="~/Images/Botones/BRegistrar_on.gif" onclick="btnRegistrar_Click" /> 
                             &nbsp;&nbsp;&nbsp;
                             <asp:ImageButton runat="server" ID="btnCancelar" 
                                    ImageUrl="~/Images/Botones/BCancelar_on.gif" onclick="btnCancelar_Click" /> 
                             </td></tr>


</table>


</asp:Panel>
<asp:HiddenField runat="server" ID="hidActuacion" />
<asp:HiddenField runat="server" ID="hidNombreArchivo" />
<input type="hidden" runat="server" ID="hidNumeroActuacionApostilla" />
</asp:Content>

