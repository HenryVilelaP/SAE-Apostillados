<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmEditarApostilla, App_Web_kt4rh5br" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">

    <asp:Panel runat="server" ID="pnDatos">

<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
Edición de Apostilla :   <asp:Label runat="server"  CssClass="numero_apostilla" ID="lblNumeroApostilla" ></asp:Label>
</td>
</tr>
<tr>
<td style=" width:20%"></td>
<td   >
 
<div class="cajaarriba"> 
 
<div class="cajaabajo"> 
 
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
                            </tr>
                            <tr>
                            <td class="etiqueta">Serie</td>   
                            <td>
                                <asp:TextBox runat="server"  ID="txtSerie"></asp:TextBox> 
                                &nbsp;&nbsp;<b>Nro</b>&nbsp;&nbsp;
                                <asp:TextBox  runat="server"  ID="txtNumeroStiker"></asp:TextBox>
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

</asp:Content>

