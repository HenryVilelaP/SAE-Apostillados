<%@ page language="C#" autoeventwireup="true" inherits="frmConsultaApostilla, App_Web_rzogjjbr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href ="~/App_Themes/Default.css" rel="Stylesheet" type="text/css" />
    
</head>
<body>


    <form id="form1" runat="server">
    <ajax:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="true" EnableScriptGlobalization="true"   />
    <div>
  

<asp:Panel runat="server" ID="pnDatos">

<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3">
Consulta en linea de Apostillas
</td>
</tr>
<tr>
<td style=" width:20%"></td>
<td align="center" >
<div class="cajaarriba"> 
<div class="cajaabajo"> 


                        <table border="0" width="100%" class="bg_fondo_tabla">
                            <tr>
                            <td class="etiqueta">Fecha</td>
                            <td  style="text-align:left;">
                            <asp:TextBox runat="server"  ID="txtFecha" ReadOnly="true" EnableViewState="true"></asp:TextBox>
                                <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                    TargetControlID="txtFecha" PopupButtonID="imbBtnCal" Format="dd/MM/yyyy">
                                </act:CalendarExtender>
                                <asp:ImageButton ID="imbBtnCal" runat="server" 
                                    ImageUrl="~/Images/Iconos/ico_calendar.gif" ToolTip="Seleccione Fecha" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtFecha" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Número de Apostilla</td>
                            <td  style="text-align:left;">
                                <asp:TextBox ID="txtNumeroApostilla" runat="server" Width="182px"  ></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtNumeroApostilla" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </td>
                            </tr>
                            
                            
                            
                        </table>
</div></div>
</td>
<td style=" width:20%"></td>
</tr>
<tr><td style="height:20px;"  colspan=3></td></tr>
<tr>
                            <td align="center" colspan=3>
                             <asp:ImageButton runat="server" ID="btnBuscar" 
                                    ImageUrl="~/Images/Botones/BBuscar_on.gif" onclick="btnBuscar_Click" /> 
                             &nbsp;&nbsp;&nbsp;
                             <asp:ImageButton runat="server" ID="btnCancelar" 
                                    ImageUrl="~/Images/Botones/BCancelar_on.gif" onclick="btnCancelar_Click" /> 
                             </td></tr>


</table>


</asp:Panel>


<asp:Panel runat="server" ID="pnResult"  Visible="true" >


<table width="100%" border="0" >
<tr>
<td class="titulo" colspan="3" align="center"><br /><br />
<asp:Label runat="server" ID="lblTituloResultado" Text="Resultado de Registro de Apostilla" Visible="false"></asp:Label>


</td>

</tr>
<tr>
<td style=" width:20%"></td>
<td align=center>
<asp:Panel runat="server" ID="pnApostillaEncontrada"  Visible="false">
<div class="cajaarriba"> 
<div class="cajaabajo"> 
 <table border="0" width="100%" class="bg_fondo_tabla"  >
                             <tr><td colspan="3" style="height:20px;"></td><tr>
                                 <td class="etiqueta" style="width:30%">
                                     Numero de Apostilla</td>
                                 <td>
                                     &nbsp;:&nbsp;</td>
                                 <td style="text-align:left;">
                                     <asp:Label ID="lblNumeroApostilla" runat="server" CssClass="numero_apostilla"></asp:Label>
                                 </td>
                                 </tr>
                             
                             <tr>
                             
                            <td class="etiqueta">Fecha</td>
                            <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                            <asp:Label runat="server" ID="lblFecha" ></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Autoridad Firmante</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                            <asp:Label runat="server"  ID="lblFirmante"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Apostillador</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                            <asp:Label runat="server" ID="lblApostillador"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Tipo de Documento</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                            <asp:Label runat="server" ID="lblTipoDocumento"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                        
                            <td class="etiqueta">Ver documento Asociado</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                                <asp:ImageButton runat="server"  ID="imgApos" ImageUrl="~/Images/Iconos/apostilla.png" 
                                    onclick="imgApos_Click"  />
                            </td>
                            </tr>
                           
                                                      
                        </table>
 </div></div>
 </asp:Panel>


</td>
<td style=" width:20%"></td>
</tr>
<tr>
<td></td>
<td>
<asp:Panel runat="server" ID="pnApostillaNoFound" Visible="false">
<table width="100%" border="0">
<tr><td style=" height:30px;"></td></tr>
<tr>
<td align="center">
<asp:Label runat="server"  ID="lblResultApostillaNoEncontrada" CssClass="msg_error"></asp:Label>

<asp:Image runat="server" id="imgIcono" ImageUrl="~/Images/Iconos/apostilla_not_found.png"  />

</td>
</tr>
</table>
</asp:Panel>
</td>
<td></td>

</tr>
</table>
</asp:Panel>

 
    </div>
    </form>
</body>
</html>
