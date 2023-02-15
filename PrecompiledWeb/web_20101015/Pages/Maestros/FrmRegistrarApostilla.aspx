<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmRegistrarApostilla, App_Web_jzxak1ig" title="Untitled Page" %>

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
                                        <table border="0" cellspacing="2" cellpadding="0" style="width:9cm; height:9cm; background-color:White;"    class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
                                                <tr><td align="center"  colspan="4" valign="bottom"><b>APOSTILLE</b></td></tr>
                                                <tr><td align="center"  colspan="4" valign="top"><b>(Convention de la Haye du 5 octobre 1961)</b></td></tr>
                                                <tr><td>&nbsp;1.</td><td  colspan="3" align="left"> País: <asp:Label runat="server" ID="lblPais"></asp:Label></td></tr>
                                                <tr><td colspan="3" align="left">&nbsp;El presente documento público</td></tr>
                                                <tr><td>&nbsp;2.&nbsp;</td><td  align="left"  colspan="3"> ha sido firmado por&nbsp;:&nbsp;<asp:Label runat="server" ID="lblFirma"></asp:Label></td></tr>
                                                <tr><td>&nbsp;3.&nbsp;</td><td  align="left"  colspan="3"> quién actua en calidad de&nbsp;<asp:Label runat="server" ID="lblCargoFirmante"></asp:Label></td></tr>
                                                <tr><td>&nbsp;4.&nbsp;</td><td  align="left"  colspan="3">y está revestido del sello / timbre de &nbsp;<asp:Label runat="server" ID="Label4"></asp:Label></td></tr>
                                                <tr><td align="center"  colspan="4"><b>Certificado</b></td></tr>
                                                <tr><td>&nbsp;5.&nbsp;</td><td  align="left"> en <asp:Label runat="server" ID="lblAt"></asp:Label></td><td colspan="2">6.&nbsp;el&nbsp;<asp:Label runat="server" ID="lblThe"></asp:Label></td></tr>
                                                <tr><td>&nbsp;7.&nbsp;</td><td  align="left"  colspan="3"> por &nbsp;<asp:Label runat="server" ID="lblBy"></asp:Label></td></tr>
                                                <tr><td>&nbsp;8.&nbsp;</td><td  align="left"  colspan="3"> N&#186; &nbsp;<asp:Label runat="server" ID="lblNro"></asp:Label></td></tr>
                                                <tr><td>&nbsp;9.&nbsp;</td><td  align="left"> Sello/timbre&nbsp;<asp:Label runat="server" ID="lblstamp"></asp:Label></td>
                                                <td colspan="2" align="center">10.&nbsp;Firma&nbsp;<asp:Label runat="server" ID="lblSignature" Width=50></asp:Label></td>
                                                </tr>
                                                <tr>
                                                <td colspan="2" align="center"  style="height:65px;">
                                                <img id="Img1"  runat="server"  src="~/Images/Iconos/escudo_peru.jpg" alt=""  width="55" height="60" />
                                                </td>
                                                <td colspan="2" valign="bottom" style=" height:40px;" align="center">
                                                
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr><td> <asp:Image  ID="imgFirma" runat="server" width="200" height="60" /></td>    </tr>
                                                                <tr><td style="height:1px; background-color:Black;"> </td>    </tr>
                                                                <tr><td><asp:Label runat="server" ID="Label1"></asp:Label></td>     </tr>
                                                                </table>
                                                </td>
                                                </tr>
                                        </table>
                                        <table  border="0" cellspacing="0" cellpadding="0" style="width:9cm;background-color:White;" >
                                                <tr>
                                                <td align="center"  class="stl_serie" >
                                                Serie -  <asp:Label ID="lblSeries"  runat="server"  ></asp:Label>&nbsp;&nbsp;
                                                N&#186; &nbsp;&nbsp;<asp:Label ID="lblNumeroCorrelativo"  runat="server"  ></asp:Label>
                                                </td>
                                                </tr>
                                        </table>
                                        </td></tr>
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

