<%@ page language="C#" autoeventwireup="true" inherits="Pages_Maestros_FrmVistaApostilla, App_Web_jzxak1ig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apostilla</title>
     <link href ="~/App_Themes/Default.css" rel="Stylesheet" type="text/css" />
     <style type="text/css">
     body
     {
     	font-family:Arial;
     	
     }
     .stl_serie
     {
     	font-size:12px;
     	height:30px;
     	font-weight:bold;
     }
     </style>
</head>
<body  OnContextMenu="return false">
    <form id="form1" runat="server">
    <div>
    <%--style=" width:370px; height:342px;"  --%>
    <table border="0" cellspacing="2" cellpadding="0" style="width:9cm; height:9cm;"    class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
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
    <td></td><td colspan="3">&nbsp;El presente documento público</td> 
    </tr>
    <tr>
    <td>&nbsp;2.&nbsp;</td><td   colspan="3"> ha sido firmado por&nbsp;:&nbsp;<asp:Label runat="server" ID="lblFirma"></asp:Label></td>
    </tr>
    <tr>
    <td>&nbsp;3.&nbsp;</td><td   colspan="3"> quién actua en calidad de&nbsp;<asp:Label runat="server" ID="lblCargoFirmante"></asp:Label></td>
    </tr>
    <tr>
    <td>&nbsp;4.&nbsp;</td><td   colspan="3">y está revestido del sello / timbre de &nbsp;<asp:Label runat="server" ID="Label4"></asp:Label></td>
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
    <td colspan="2" align="center">10.&nbsp;Firma&nbsp;<asp:Label runat="server" ID="lblSignature" Width=50></asp:Label></td>
    </tr>
    
    <tr>
    <td colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
                    <td  align="center"   style="width:30%;">
                    
                    <img  runat="server"  src="~/Images/Iconos/escudo_peru.jpg" alt=""  width="55" height="60" />
                    
                    </td>
                    <td  valign="bottom" style=" height:40px; width:10cm;" align="center">
                    
                                    <table border="0" cellpadding="0" cellspacing="0">
                                    <tr><td> <asp:Image  ID="imgFirma" runat="server" width="200" height="60" /></td>    </tr>
                                   <%-- <tr><td style="height:1px; background-color:Black;"> </td>    </tr>--%>
                                    <%--<tr><td><asp:Label runat="server" ID="lblApostillador"></asp:Label></td>     </tr>--%>
                                    </table>
                    </td>
                    </tr></table>
    </td>
    </tr>
     
    
    
    
    </table>
    <table  border="0" cellspacing="0" cellpadding="0" style="width:9cm;" >
    <tr>
    <td align="center"  class="stl_serie" >
    Serie -  <asp:Label  ID="lblSerie" runat="server" ></asp:Label>&nbsp;&nbsp;
    N&#186; &nbsp;&nbsp;<asp:Label ID="lblNumeroCorrelativo"  runat="server" ></asp:Label>
    </td>
    </tr>
    </table>
    
    
    </div>
    </form> 
<center><a href="#"   onClick="imprimir();" id="alink"> imprimir</a></center>

</body>
</html>

<script type="text/javascript">
function imprimir(){
document.getElementById("alink").style.visibility = "hidden";

window.print();
return false;

}
</script>