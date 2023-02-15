<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmStickerApostilladorNuevo, App_Web_gxtujfme" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCuerpo" Runat="Server">

   
    
      <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr height="5">
                <td>
                </td>
            </tr>
            <tr>
            <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                         <td class="titulo" style="height: 30px" valign="middle">
                        <asp:Label runat="server"  ID="lblTitulo" CssClass="titulo"  ></asp:Label>  
                         
                         </td>
                         <td class="titulo" align="right" valign="middle">
                         <a href="FrmBandejaStikers.aspx" title="Cerrar Ventana"   ><img src="../../Images/Iconos/close.png" alt="Cerrar Ventana" style=" border:0px;" /></a>
                         </td>
                         </tr>
                    </table>
            </td>
            </tr>
            <tr  >
                <td   width="100%" valign="top">
                    <table cellspacing="0" cellpadding="0" width="98%"   border="0" class="table_modal"
                        bgcolor="#f9f9fa">
                        <tr>
                            <td  >
                                <div style="overflow: auto; width: 100%; height:250px">
                                    <table cellspacing="0" cellpadding="2" width="100%" align="center">
                                        <tr>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="SummaryValidation" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" EnableClientScript="True"></asp:ValidationSummary>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td>
                                                Código:</td>
                                            <td>
                                                <asp:TextBox ID="txtCodigo" Width="100px" Enabled="False" runat="server" CssClass="stl_texbox_inactivo"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ubicación:</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlUbicacion" 
                                    onselectedindexchanged="ddlUbicacion_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                               Oficina</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlOficina" 
                                    onselectedindexchanged="ddlOficina_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Apostillador</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlApostillador" ></asp:DropDownList>
                                               </td>
                                        </tr>
                                       
                                        <tr>
                                            <td>
                                                Situación</td>
                                            <td>
                                               <asp:DropDownList runat="server" ID="ddlSituacion"></asp:DropDownList>
                                                    </td>
                                        </tr>
                                      <tr>
                                            <td>
                                                Numero Serie</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSerie" />
                                                    </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Correlativo Inicial</td>
                                            <td>
                                               <asp:TextBox runat="server" ID="txtInicial" />
                                                </td>
                                        </tr>
                                          <tr>
                                            <td>
                                                Correlativo Final</td>
                                            <td>
                                               <asp:TextBox runat="server" ID="txtFinal" />
                                                </td>
                                        </tr>
                                       
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="5">
                </td>
            </tr>
            <tr>
                <td align="center" style=" height:40px;" valign="middle">
                 <%--   <asp:Button runat="server"  ID="btnRegistrar" Text="Registrar Apostillador"  onclick="btnRegistrar_Click" />--%>
                    <asp:ImageButton runat="server" ID="btnRegistrar" ImageUrl="~/Images/Botones/BRegistrar_off.gif" onclick="btnRegistrar_Click"    />
                        
                </td>
            </tr>
        </table>
         
    
     
    <asp:HiddenField ID="hidCodigoStickerApostillador" runat="server" />
 

</asp:Content>

