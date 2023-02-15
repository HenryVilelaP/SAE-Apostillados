<%@ Page Language="C#" MasterPageFile="~/MP/Main.master" AutoEventWireup="true" CodeFile="FrmBandejaApostillados.aspx.cs"
    Inherits="Pages_Maestros_FrmBandejaApostillados" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" runat="Server">
    <%--<div  style="position:absolute;" id="apDivProgresoGeneral" >
    <ajax:UpdateProgress ID="uproFiltros" runat="server" AssociatedUpdatePanelID="upFiltros">
    <ProgressTemplate > 
                     <img alt='' src="../../Images/Iconos/barr-cicle-ajax-loader.gif" />
    </ProgressTemplate>
    </ajax:UpdateProgress>
    </div>--%>
    <asp:UpdatePanel runat="server" ID="upBandejaApostilla" EnableViewState="true">
        <ContentTemplate>
            <div>
                <table width="100%" border="0">
                    <tr>
                        <td style="height: 40px;">
                            <asp:Label runat="server" Text="Bandeja  de Apostillas" ID="lbltitulo" CssClass="titulo"></asp:Label>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pn1" runat="server" BorderWidth="1" CssClass="cajaFiltros">
                                <table width="100%" border="0">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0">
                                                <tr>
                                                    <td class="etiqueta">
                                                        Ubicación
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlUbicacion" OnSelectedIndexChanged="ddlUbicacion_SelectedIndexChanged"
                                                            AutoPostBack="true" />
                                                    </td>
                                                    <td class="etiqueta">
                                                        Oficina
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlOficina" OnSelectedIndexChanged="ddlOficina_SelectedIndexChanged"
                                                            AutoPostBack="true" />
                                                    </td>
                                                    <td class="etiqueta">
                                                        Apostillador
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlApostillador">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 30px;" class="etiqueta">
                                                        <asp:Label ID="lblNombre" runat="server" Text="Fecha" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFecha" Width="60"></asp:TextBox>
                                                        <act:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" TargetControlID="txtFecha"
                                                            PopupButtonID="imbBtnCal" Format="dd/MM/yyyy">
                                                        </act:CalendarExtender>
                                                        <asp:ImageButton ID="imbBtnCal" runat="server" ImageUrl="~/Images/Iconos/ico_calendar.gif"
                                                            ToolTip="Seleccione Fecha" />
                                                    </td>
                                                    <td class="etiqueta">
                                                        <asp:Label ID="lblPaterno" runat="server" Text="N&deg; Apostilla" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtNumeroApostilla" Width="150"></asp:TextBox>
                                                    </td>
                                                    <td class="etiqueta">
                                                        Situación
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSituacion">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="etiqueta">
                                                        <asp:Label ID="lblOperacionBancaria" runat="server" Text="No Operación Bancaria" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtNumeroOperacion" Width="70"></asp:TextBox>
                                                    </td>
                                                    <td style="height: 30px;" class="etiqueta">
                                                        <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo de Documento" />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:DropDownList runat="server" ID="ddlTipoDocumento">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/Botones/BBuscar_off.gif"
                                                            OnClick="btnBuscar_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="btnLimpar" ImageUrl="~/Images/Botones/Blimpiar_off.gif"
                                                            OnClick="btnLimpiar_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" valign="bottom">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="DivGrillaBorde">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr style="height: 30px">
                                                <td class="header-gridview" style="width: 4%;" align="center">
                                                    RGE
                                                </td>
                                                <td class="header-gridview" style="width: 4%;" align="center">
                                                    RGE-OFI
                                                </td>
                                                <td class="header-gridview" style="width: 4%;" align="center">
                                                    RGE-APOS
                                                </td>
                                                <td class="header-gridview" style="width: 15%" align="center">
                                                    Nro Apostilla
                                                </td>
                                                <td class="header-gridview" style="width: 10%" align="center">
                                                    Oficina
                                                </td>
                                                <td class="header-gridview" style="width: 19%" align="center">
                                                    Apostillador
                                                </td>
                                                <td class="header-gridview" style="width: 10%" align="center">
                                                    Operación Bancaria
                                                </td>
                                                <td class="header-gridview" style="width: 15%" align="center">
                                                    Tipo Documento
                                                </td>
                                                <td class="header-gridview" style="width: 5%" align="center">
                                                    Fecha
                                                </td>
                                                <td class="header-gridview" style="width: 5%" align="center">
                                                    Estado
                                                </td>
                                                <td class="header-gridview" style="width: 10%" align="center">
                                                    Opciones
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="DivGrillaBorde DivGrillaDimension">
                                            <asp:GridView runat="server" ID="gvApostillas" Width="98%" AutoGenerateColumns="false"
                                                ShowHeader="false" CssClass="DivGrillaBorde GridViewStyle" Height="37px">
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <Columns>
                                                    <asp:BoundField DataField="CODIGOACTUACION" HeaderText="ID" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="4%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CODIGOACTUACIONOFICINA" HeaderText="ID" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="4%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CORRELATIVO" HeaderText="ID" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="4%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NUMEROAPOSTILLA" HeaderText="Nro Apostilla" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OFICINA" HeaderText="Apostillador" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NOMBRESAPOSTILLADOR" HeaderText="Apostillador" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OPERACIONBANCARIA" HeaderText="Operación Bancaria" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NOMBRETIPODOCUMENTO" HeaderText="Tipo Documento" HeaderStyle-CssClass="header-gridview">
                                                        <ItemStyle Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FECHAAPOSTILLA" DataFormatString="{0:d}" HeaderText="Fecha"
                                                        HeaderStyle-CssClass="header-gridview">
                                                        <HeaderStyle CssClass="header-gridview" Width="10%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SITUACIONDESCRIPCION" HeaderText="Estado" HeaderStyle-CssClass="header-gridview">
                                                        <HeaderStyle CssClass="header-gridview" Width="8%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-CssClass="header-gridview" HeaderText="Opciones">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" CommandArgument='<%# Eval("CODIGOACTUACION") %>'
                                                                ID="btnDelete" CommandName="_delete" ToolTip="Eliminar Apostilla" Width="13"
                                                                Height="13" ImageUrl="~/Images/Iconos/data_delete.gif" OnClick="btnDelete_Click" />
                                                            &nbsp;
                                                            <asp:ImageButton runat="server" CommandArgument='<%# Eval("CODIGOACTUACION") %>'
                                                                OnClick="btnEdit_Click" ID="btnEdit" ToolTip="ir a imprimir Apostilla" Width="13"
                                                                Height="13" ImageUrl="~/Images/Iconos/imprimir.gif" />
                                                            &nbsp;
                                                            <asp:ImageButton runat="server" CommandArgument='<%# Eval("CODIGOACTUACION") %>'
                                                                OnClick="imgApos_Click" ID="btnView" ToolTip="Ver Apostilla" Width="13" Height="13"
                                                                ImageUrl="~/Images/Iconos/data_view.gif" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="header-gridview"></HeaderStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px" valign="middle">
                                        <table border="0" width="100%" class="cajaFiltros">
                                            <tr>
                                                <td>
                                                    <b>
                                                        <asp:Label runat="server" ID="lblNumeroRegistros"></asp:Label></b>
                                                </td>
                                                <td align="right">
                                                    <table border="0">
                                                        <tr>
                                                            <td align="right">
                                                                <b>
                                                                    <asp:Label runat="server" ID="lblPagina"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</b>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="imgbtnStart" ImageUrl="~/Images/Iconos/ico_quitar_todos_off.gif"
                                                                    ToolTip="ir a la página inicial" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="imgbtnNext" ImageUrl="~/Images/Iconos/ico_agregar_uno_off.gif"
                                                                    ToolTip="ir a la página siguiente" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="~/Images/Iconos/ico_quitar_uno_off.gif"
                                                                    ToolTip="ir a la página anterior" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="imgbtnEnd" ImageUrl="~/Images/Iconos/ico_agregar_todos_off.gif"
                                                                    ToolTip="ir a la página final" />
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
                </table>
                <asp:HiddenField ID="hidNumeroActuacionApostilla" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--vista apostilla-->
    <!--  B = VENTANA ASIGNACION PERFIL A USUARIO  -->
    <asp:Button runat="server" ID="imgbtn" Width="0" Height="0" />
    <act:ModalPopupExtender ID="mpeVerApostilla" runat="server" BackgroundCssClass="BackgroundPopup"
        PopupControlID="pnModalPopupVistaApostilla" DropShadow="False" TargetControlID="imgbtn" />
    <asp:Panel ID="pnModalPopupVistaApostilla" runat="server" CssClass="CajaDialogoGeneral stl_texto_sin_negrita"
        Width="9cm" Style="display: none">
        <ajax:UpdatePanel ID="upVistaApostilla" runat="server">
            <ContentTemplate>
                <div style="position: absolute; top: 2px; left: 8cm;">
                    <asp:ImageButton runat="server" ToolTip="cerrar ventana" ImageUrl="~/Images/Iconos/close.png"
                        ID="imgCerrar" OnClick="imgCerrar_Click" />
                </div>
                <table border="0" cellspacing="2" cellpadding="0" style="width: 90mm; height: 90mm;
                    background-color: White; font-family: Arial;" class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
                    <tr>
                        <td align="center" colspan="4" valign="bottom">
                            <b>APOSTILLE</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" valign="top" style="height: 20px;">
                            <b>(Convention de la Haye du 5 octobre 1961)</b>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;1.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            País / <span>Country</span>&nbsp;<asp:Label runat="server" ID="lblPais"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                        <td colspan="3" align="left">
                            El presente documento público / <span>This public document</span>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;2.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            ha sido firmado por / <span>has been signed by</span>&nbsp;<asp:Label runat="server"
                                ID="lblFirma" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;3.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            quién actua en calidad de / <span>acting in the capacity of</span>&nbsp;<asp:Label
                                runat="server" ID="lblCargoFirmante" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;4.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            y está revestido del sello / timbre de / <span>bears the seal / stamp of</span>&nbsp;<asp:Label
                                runat="server" ID="Label4" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            Certificado / <span>Certified</span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;5.
                        </td>
                        <td valign="top" align="left">
                            en / <span>at</span>
                            <asp:Label runat="server" ID="lblAt" Font-Bold="true"></asp:Label>
                        </td>
                        <td valign="top" colspan="2" align="left">
                            6.&nbsp;el / <span>the</span> &nbsp;<asp:Label runat="server" ID="lblThe" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;7.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            por / <span>by</span> &nbsp;<asp:Label runat="server" ID="lblBy"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;8.
                        </td>
                        <td valign="top" colspan="3" align="left">
                            bajo el n&uacute;mero / <span>N&#186;</span>&nbsp;<asp:Label runat="server" ID="lblNro"
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;9.
                        </td>
                        <td valign="top" align="left">
                            Sello/timbre / <span>Seal/stamp</span>&nbsp;<asp:Label runat="server" ID="lblstamp"></asp:Label>
                        </td>
                        <td valign="top" colspan="2" align="left">
                            10.&nbsp;Firma / <span>Signature</span>&nbsp;<asp:Label runat="server" ID="lblSignature"
                                Width="50"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="width: 40%;">
                                        <img id="Img1" runat="server" src="~/Images/Iconos/escudo_peru.jpg" alt="" width="55"
                                            height="60" visible="false" />
                                    </td>
                                    <td valign="bottom" style="height: 40px; width: 10cm;" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Image ID="imgFirma" runat="server" Width="180" Height="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="stl_apostillador_vista_sticker  td-top-apostilla">
                                                    <asp:Label runat="server" ID="_lblApostilladorVista"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="stl_firma_vista_sticker">
                                                    <asp:Label runat="server" ID="lblDireccion"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="stl_firma_vista_sticker">
                                                    <asp:Label runat="server" ID="lblMRE"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 9cm;">
                    <tr>
                        <td align="center" class="stl_serie">
                            Serie -
                            <asp:Label ID="lblSeries" runat="server"></asp:Label>&nbsp;&nbsp; N&#186; &nbsp;&nbsp;<asp:Label
                                ID="lblNumeroCorrelativo" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <ajax:AsyncPostBackTrigger ControlID="imgCerrar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="imgCerrar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="imgCerrar" EventName="Click" />
            </Triggers>
        </ajax:UpdatePanel>
    </asp:Panel>

    <script language="javascript">
function _irApost()
{
    if(document.getElementById("ctl00_cphCuerpo_hidNumeroActuacionApostilla")!=null){
          //
            numeroApostilla=document.getElementById("ctl00_cphCuerpo_hidNumeroActuacionApostilla").value;
            height='450';
            width='390';
            url="FrmVistaApostilla.aspx?idTicketAct="+numeroApostilla;
	        xpos=(window.screen.width/2)-(width/2);
	        ypos=(window.screen.height/2)-(height/2);
	        name=''
        	 
		 window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes,top='+ypos+',left='+xpos);		
		//res.focus();
		 
    }
}
    </script>

</asp:Content>
