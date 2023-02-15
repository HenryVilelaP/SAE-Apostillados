<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_frmParametroNuevo, App_Web_kt4rh5br" title="Untitled Page" %>

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
                         <a href="frmParametro.aspx" title="Cerrar Ventana"   ><img src="../../Images/Iconos/close.png" alt="Cerrar Ventana" style=" border:0px;" /></a>
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
                                <div style="overflow: auto; width: 100%; height:200px">
                                    <table cellspacing="0" cellpadding="2" width="100%" align="center">
                                        <tr>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="SummaryValidation" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" EnableClientScript="True"></asp:ValidationSummary>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tabla:</td>
                                            <td>
                                                <asp:DropDownList ID="ddltabla" Width="350px" runat="server" CssClass="stl_texbox">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Codigo:</td>
                                            <td>
                                                <asp:TextBox ID="txtCodigo" Width="100px" Enabled="False" runat="server" CssClass="stl_texbox_inactivo"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Nombre:</td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" Width="350px" runat="server" CssClass="stl_texbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredNombre" runat="server" ControlToValidate="txtNombre"
                                                    ErrorMessage="Debe ingresar un nombre">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Valor Numerico</td>
                                            <td>
                                                <asp:TextBox ID="txtValorNumerico" runat="server" onkeyPress="return solonumerosypunto(event);"
                                                    MaxLength="5" CssClass="stl_texbox"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Valor Texto</td>
                                            <td>
                                                <asp:TextBox ID="txtValorTexto" runat="server" MaxLength="20" CssClass="stl_texbox" Width="263px"></asp:TextBox></td>
                                        </tr>
                                        <%--<tr>
                                            <td>
                                                Situacion:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlSituacion" Width="120px" runat="server" CssClass="stl_texbox">
                                                    <asp:ListItem Value="A">Activo</asp:ListItem>
                                                    <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                               <span runat="server" id="lblchkU"> Modificable</span></td>
                                            <td>
                                                <asp:CheckBox ID="chkModificar" runat="server" Checked="True">
                                                </asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span runat="server" id="lblchkD"> Eliminable</span></td>
                                            <td>
                                                <asp:CheckBox ID="chkEliminar" runat="server"   Checked="True">
                                                </asp:CheckBox></td>
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
                <%--    <asp:Button runat="server"  ID="btnRegistrar" Text="Registrar Parametro"  onclick="btnRegistrar_Click" />--%>
                   <asp:ImageButton runat="server" ID="btnRegistrar" ImageUrl="~/Images/Botones/BRegistrar_off.gif" onclick="btnRegistrar_Click"    />
                        
                </td>
            </tr>
        </table>
         
    
    <asp:HiddenField ID="hidCodigoTabla" runat="server" />
    <asp:HiddenField ID="hidCodigoParametro" runat="server" />
 

</asp:Content>

