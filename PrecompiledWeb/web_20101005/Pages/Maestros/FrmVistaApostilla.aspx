<%@ page language="C#" autoeventwireup="true" inherits="Pages_Maestros_FrmVistaApostilla, App_Web_kt4rh5br" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apostilla</title>
     <link href ="~/App_Themes/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table style=" width:9cm; height:9cm;"  border="0" cellspacing="0"   cellpadding="0" class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
    <tr>
            <td align="center"  colspan="4" valign="bottom"><b>APOSTILLE</b></td>
    </tr>
    <tr>
            <td align="center"  colspan="4" valign="top"><b>(Convention de la Haye du 5 octobre 1961)</b></td>
    </tr>
    <%--<tr><td style=" height:2px;"  colspan="2"></td></tr>--%>
    
    <tr>
    <td>&nbsp;1.</td><td  colspan="3"> País: <asp:Label runat="server" ID="lblPais"></asp:Label></td>
    </tr>
    <tr>
    </td><td><td   colspan="3">&nbsp;El presente documento público</td> 
    </tr>
    <tr>
    <td  >&nbsp;2.&nbsp;</td><td   colspan="3"> ha sido firmado por&nbsp;:&nbsp;<asp:Label runat="server" ID="lblFirma"></asp:Label></td>
    </tr>
    <tr>
    <td  >&nbsp;3.&nbsp;</td><td   colspan="3"> quién actua en calidad de&nbsp;<asp:Label runat="server" ID="lblCargoFirmante"></asp:Label></td>
    </tr>
    <tr>
    <td  >&nbsp;4.&nbsp;</td><td   colspan="3">y está revestido del sello / timbre de &nbsp;<asp:Label runat="server" ID="Label4"></asp:Label></td>
    </tr>
    
    <tr>
            <td align="center"  colspan="4"><b>Certificado</b></td>
    </tr>
    
    <tr>
    <td>&nbsp;5.&nbsp;</td><td> en <asp:Label runat="server" ID="lblAt"></asp:Label></td><td colspan="2">6.&nbsp;el&nbsp;<asp:Label runat="server" ID="lblThe"></asp:Label></td>
    </tr>
    <tr>
    <td >&nbsp;7.&nbsp;</td><td   colspan="3"> por &nbsp;<asp:Label runat="server" ID="lblBy"></asp:Label></td>
    </tr>
    <tr>
    <td  >&nbsp;8.&nbsp;</td><td   colspan="3"> N&#186; &nbsp;<asp:Label runat="server" ID="lblNro"></asp:Label></td>
    </tr>
    <tr>
    <td>&nbsp;9.&nbsp;</td><td> Sello/timbre&nbsp;<asp:Label runat="server" ID="lblstamp"></asp:Label></td>
    <td colspan="2">10.&nbsp;Firma&nbsp;<asp:Label runat="server" ID="lblSignature" Width=50></asp:Label></td>
    </tr>
    
    <tr>
    <td colspan="2" align="center"><img  runat="server"  src="~/Images/Iconos/escudo_peru.jpg" alt="" /></td>
    <td colspan="2" valign="bottom" style=" height:40px;" align="center">______________________________<br><asp:Label runat="server" ID="lblApostillador"></asp:Label></td>
    </tr>
    <tr>
    <td > </td>
    </tr>
    
    
    
    </table>
    
    
    </div>
    </form><br />
<center><a href="#"   onClick="window.print();return false"> imprimir</a></center>

</body>
</html>
