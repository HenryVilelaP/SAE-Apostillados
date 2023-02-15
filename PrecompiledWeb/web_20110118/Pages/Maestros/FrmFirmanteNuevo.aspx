<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_FrmFirmanteNuevo, App_Web_gxtujfme" title="Untitled Page" %>

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
                         <a href="FrmFirmantes.aspx" title="Cerrar Ventana"   ><img src="../../Images/Iconos/close.png" alt="Cerrar Ventana" style=" border:0px;" /></a>
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
                                                Código:</td>
                                            <td>
                                                <asp:TextBox ID="txtCodigo" Width="100px" Enabled="False" runat="server" CssClass="stl_texbox_inactivo"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Nombres:</td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" Width="350px" runat="server" CssClass="stl_texbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredNombre" runat="server" ControlToValidate="txtNombre"
                                                    ErrorMessage="Debe ingresar un nombre">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Apellido Paterno</td>
                                            <td>
                                                <asp:TextBox ID="txtPaterno" runat="server"  CssClass="stl_texbox" Width="263px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredNombre0" runat="server" ControlToValidate="txtPaterno"
                                                    ErrorMessage="Debe ingresar un apellido paterno">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Apellido Materno</td>
                                            <td>
                                                <asp:TextBox ID="txtMaterno" runat="server" MaxLength="20" CssClass="stl_texbox" Width="263px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredNombre1" runat="server" ControlToValidate="txtMaterno"
                                                    ErrorMessage="Debe ingresar un apellido materno">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        
                                        <tr>
                                            <td>
                                                DNI</td>
                                            <td>
                                                <asp:TextBox ID="txtDNI" runat="server" MaxLength="20" 
                                                    CssClass="stl_texbox" Width="381px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Cargo</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlCargo"  CssClass="stl_texbox"  />
                                                    </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                Entidad Asociada a la Autoridad</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlEntidad"  CssClass="stl_texbox"  />
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
                 <%--   <asp:Button runat="server"  ID="btnRegistrar" Text="Registrar Firmante"  onclick="btnRegistrar_Click" />--%>
                    <asp:ImageButton runat="server" ID="btnRegistrar" ImageUrl="~/Images/Botones/BRegistrar_off.gif" onclick="btnRegistrar_Click"    />
                        
                </td>
            </tr>
        </table>
         
    
     
    <asp:HiddenField ID="hidCodigoFirmante" runat="server" />
 

</asp:Content>

