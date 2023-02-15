<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmRegistrarApostilla, App_Web_rgv28-gm" title="Untitled Page" %>

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
                            <td class="etiqueta" valign="top">Autoridad Firmante</td>
                            <td>
                             <ajax:UpdatePanel runat="server" ID="upCargoAutoridad" EnableViewState="true" >
                                <ContentTemplate>
                                         <table id="Table1" runat="server" width="100%" cellpadding="0" cellspacing="0" border="0">
                                         <tr>
                                         <td style="width:50%;"><asp:DropDownList runat="server" ID="ddlFirmante"  OnSelectedIndexChanged="BuscarCargoAutoridad"    AutoPostBack="true" ></asp:DropDownList>  
                                         </td>
                                         <%--<td style="width:50%;"><asp:Label runat="server" ID="lblCargoAutoridad" CssClass="stl_descripcion_dato_ajax"></asp:Label> 
                                         </td>--%>
                                         </tr> 
                                         <tr>
                                         <td><asp:Label runat="server" ID="lblCargoAutoridad" CssClass="stl_descripcion_dato_ajax"></asp:Label></td>
                                         </tr>
                                         <tr>
                                         <td><asp:Label runat="server" ID="lblEntidad" CssClass="stl_descripcion_dato_ajax"></asp:Label></td>
                                         </tr>
                                          
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
                            &nbsp;&nbsp;&nbsp;<span  class="etiqueta" >Nro Ticket </span>   
                            <asp:TextBox runat="server"  ID="txtNumeroTicket"></asp:TextBox>
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
                                        <%--<td align="right">
                                        <a href="#" onclick="irApost();" target="_self" title='Ver vista de impresión'>Ver Apostilla <img src="../../Images/Iconos/imprimir.gif" alt="imprimir" border="0"  alt='Ver vista de impresión' /></a>
                                        </td>--%>
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
                            <td class="etiqueta">Nro Ticket</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblTicket"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta">Serie Generada:</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                                <asp:TextBox runat="server"  ID="txtSerie"></asp:TextBox> 
                                &nbsp;&nbsp;Nro:&nbsp;&nbsp;
                                <asp:TextBox  runat="server"  ID="txtNumeroStiker"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td class="etiqueta"><%--Adjuntar Archivo de Documento--%></td> <td><%--&nbsp;:&nbsp;--%></td>
                            <td>
                            <asp:FileUpload runat="server" ID="fuApostilla"  Width="300px" />
                            </td>
                            </tr>
                            
                            <tr><td style="height:20px;" colspan="3" align="center">Vista Previa</td></tr>
                            
                            <tr>
                             
                            <td colspan="3" align="center" >
                            
                            
                            
                                        <table border="0" cellspacing="2" cellpadding="0" style="width: 90mm; height: 90mm; background-color:White;font-family:Arial;"   class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
                                        <tr><td align="center"  colspan="4" valign="bottom"><b>APOSTILLE</b></td></tr>
                                        <tr><td align="center"  colspan="4" valign="top" style=" height:20px;"><b>(Convention de la Haye du 5 octobre 1961)</b></td>                                       </tr>
                                        <tr>
                                                <td valign="top">&nbsp;1.</td>
                                                <td valign="top" colspan="3" align="left"> País / <span  >Country</span>&nbsp;<asp:Label runat="server" ID="lblPais"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;</td>
                                                <td colspan="3" align="left">El presente documento público / <span  >This public document</span>&nbsp;</td> 
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;2.</td>
                                                <td valign="top" colspan="3" align="left"> ha sido firmado por / <span  >has been signed by</span>&nbsp;<asp:Label runat="server" ID="lblFirma"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;3.</td>
                                                <td valign="top" colspan="3" align="left"> quién actua en calidad de / <span  >acting in the capacity of</span>&nbsp;<asp:Label runat="server" ID="lblCargoFirmante"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;4.</td>
                                                <td valign="top" colspan="3" align="left">y está revestido del sello / timbre de / <span  >bears the seal / stamp of</span>&nbsp;<asp:Label runat="server" ID="Label4"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td align="center"  colspan="4">Certificado / <span  >Certified</span> </td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;5.</td>
                                                <td valign="top" align="left"> en / <span  >at</span> <asp:Label runat="server" ID="lblAt"></asp:Label></td>
                                                <td valign="top"colspan="2" align="left">6.&nbsp;el / <span  >the</span> &nbsp;<asp:Label runat="server" ID="lblThe"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;7.</td>
                                                <td valign="top" colspan="3" align="left"> por / <span  >by</span> &nbsp;<asp:Label runat="server" ID="lblBy"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;8.</td>
                                                <td valign="top"  colspan="3" align="left"> bajo el n&uacute;mero / <span  >N&#186;</span>&nbsp;<asp:Label runat="server" ID="lblNro"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;9.</td>
                                                <td valign="top" align="left"> Sello/timbre / <span  >Seal/stamp</span>&nbsp;<asp:Label runat="server" ID="lblstamp"></asp:Label></td>
                                                <td valign="top" colspan="2" align="left">10.&nbsp;Firma /  <span>Signature</span>&nbsp;<asp:Label runat="server" ID="lblSignature" Width=50></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td colspan="4">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
                                                        <td  align="center"   style="width:40%;">
                                                        <img id="Img1"  runat="server"  src="~/Images/Iconos/escudo_peru.jpg" alt=""  width="55" height="60"  visible="false"/>
                                                        </td>
                                                        <td  valign="bottom" style=" height:40px; width:10cm;" align="center">
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr><td ><asp:Image  ID="imgFirma" runat="server" width="180" height="50" /></td>    </tr>
                                                                        <tr><td class="stl_apostillador_vista_sticker td-top-apostilla " ><asp:Label runat="server" ID="_lblApostilladorVista"></asp:Label></td>     </tr>
                                                                        <tr><td class="stl_firma_vista_sticker"><asp:Label runat="server" ID="lblDireccion"></asp:Label></td>     </tr>
                                                                        <tr><td class="stl_firma_vista_sticker"><asp:Label runat="server"  ID="lblMRE"></asp:Label></td>     </tr>                                    
                                                                        </table>
                                                        </td>
                                                        </tr></table>
                                        </td>
                                        </tr>
                                        </table>
                                        
                                        <table  border="0" cellspacing="0" cellpadding="0" style="width:9cm;" >
                                        <tr>
                                        <td align="center"  class="stl_serie" >
                                        Serie -  <asp:Label  ID="lblSeries" runat="server" ></asp:Label>&nbsp;&nbsp;
                                        N&#186; &nbsp;&nbsp;<asp:Label ID="lblNumeroCorrelativo"  runat="server" ></asp:Label>
                                        </td>
                                        </tr>
                                        </table>
                                        </td>
                             </tr>
                             
                             
                             
                             
                             
                             
                             <tr><td style="height:20px;" colspan="3" align="center"> </td></tr>
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
<tr><td class="titulo" colspan="3">PASO 3: Finalización de Apostillado</td></tr>
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
                                            <td>
                                            <asp:Label runat="server"  CssClass="numero_apostilla" ID="lblNumeroApostillaStep3" ></asp:Label>
                                            </td>
                                            <td align="right">
                                            
                                            </td>
                                </tr>
                                </table>
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
                            <td class="etiqueta">Nro Ticket</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblTicketStep3"></asp:Label>
                            </td>
                            </tr>
                           <%-- <tr>
                        
                            <td class="etiqueta">Ver documento Apostillado</td>   <td>&nbsp;:&nbsp;</td>
                            <td style="text-align:left;">
                                <asp:ImageButton runat="server"  ID="imgApos" ImageUrl="~/Images/Iconos/apostilla.png" 
                                    onclick="imgApos_Click"  />
                            </td>
                            </tr>--%>
                            <tr>
                            <td class="etiqueta">Serie</td>   <td>&nbsp;:&nbsp;</td>
                            <td>
                            <asp:Label runat="server"  ID="lblSerie"></asp:Label>
                            &nbsp;&nbsp;<span class="etiqueta">Nro :</span>&nbsp;&nbsp;
                            <asp:Label runat="server"  ID="lblNumeroSerie"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td></td><td></td>
                            <td><a href="#" onclick="irApost();" target="_self" title='Ver vista de impresión' style="font-size:12px;">Imprimir Apostilla <img src="../../Images/Iconos/imprimir.gif" alt="imprimir" border="0"  alt='Ver vista de impresión' /></a> 
                            </td></tr> 
                            <tr><td style="height:20px;"></td></tr>
                            <tr>
                            <td align="center" colspan="3">
                            <a href="FrmRegistrarApostilla.aspx" class="enlaceboton"   title="Ir a registrar otra Apostilla.">Registrar Nueva Apostilla</a>
                            </td>
                            </tr>
                           
                            
               <table>                         
</div></div>

</td>
<td style=" width:20%"></td>
</tr>
<tr><td colspan="3" style=" height:50px;">

</td></tr>
</table>

 


</asp:Panel>
<input type="hidden" runat="server" ID="hidNumeroActuacionApostilla" />
</asp:Content>

