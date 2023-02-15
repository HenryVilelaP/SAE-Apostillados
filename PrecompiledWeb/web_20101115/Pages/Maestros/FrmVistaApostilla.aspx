<%@ page language="C#" autoeventwireup="true" inherits="Pages_Maestros_FrmVistaApostilla, App_Web_nisepjg2" %>

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
     	height:15px;
     	font-weight:bold;
     }
     .stl_apostillador_vista_sticker{
		font-size:9px; 
		font-weight:bold; 
    }
    .stl_firma_vista_sticker{
		font-size:8px; 
    }

     </style>
</head>
<body  OnContextMenu="return false">
    <form id="form1" runat="server">
    <div style="position: absolute; top:2px;  left: 0px;">
   
    <center><asp:Label runat="server" ID="lbllink"></asp:Label></center>
            
                                        <table border="0" cellspacing="2" cellpadding="0" style="width:8.7cm; height:9cm; font-family:Arial;" class="td-left-apostilla td-right-apostilla td-bottom-apostilla td-top-apostilla">
                                        <tr><td align="center"  colspan="4" valign="bottom"><b>APOSTILLE</b></td></tr>
                                        <tr><td align="center"  colspan="4" valign="top" style=" height:20px;"><b>(Convention de la Haye du 5 octobre 1961)</b></td></tr>
                                        <tr>
                                                <td valign="top">&nbsp;1.</td>
                                                <td valign="top" colspan="3"> País / <span  >Country</span>&nbsp;<asp:Label runat="server" ID="lblPais"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;</td>
                                                <td colspan="3">El presente documento público / <span  >This public document</span>&nbsp;</td> 
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;2.</td>
                                                <td valign="top" colspan="3"> ha sido firmado por / <span  >has been signed by</span>&nbsp;<asp:Label runat="server" ID="lblFirma"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;3.</td>
                                                <td valign="top" colspan="3"> quién actua en calidad de / <span  >acting in the capacity of</span>&nbsp;<asp:Label runat="server" ID="lblCargoFirmante"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;4.</td>
                                                <td valign="top" colspan="3">y está revestido del sello / timbre de / <span  >bears the seal / stamp of</span>&nbsp;<asp:Label runat="server" ID="Label4"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td align="center"  colspan="4"><b>Certificado / <span  >Certified</span> </b></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;5.</td>
                                                <td valign="top"> en / <span  >at</span> <asp:Label runat="server" ID="lblAt"></asp:Label></td>
                                                <td valign="top"colspan="2">6.&nbsp;el / <span  >the</span> &nbsp;<asp:Label runat="server" ID="lblThe"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;7.</td>
                                                <td valign="top" colspan="3"> por / <span  >by</span> &nbsp;<asp:Label runat="server" ID="lblBy"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;8.</td>
                                                <td valign="top"  colspan="3"> bajo el n&uacute;mero / <span  >N&#186;</span>&nbsp;<asp:Label runat="server" ID="lblNro"></asp:Label></td>
                                        </tr>
                                        <tr>
                                                <td valign="top">&nbsp;9.</td>
                                                <td valign="top"> Sello/timbre / <span  >Seal/stamp</span>&nbsp;<asp:Label runat="server" ID="lblstamp"></asp:Label></td>
                                                <td valign="top" colspan="2" align="center">10.&nbsp;Firma /  <span>Signature</span>&nbsp;<asp:Label runat="server" ID="lblSignature" Width=50></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td colspan="4">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
                                                        <td  align="center"   style="width:40%;">
                                                        <img  runat="server"  src="~/Images/Iconos/escudo_peru.jpg" alt=""  width="55" height="60" />
                                                        </td>
                                                        <td  valign="bottom" style=" height:40px; width:10cm;" align="center">
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr><td style="width:180px; height:50px;"> <asp:Image  ID="imgFirma" runat="server" width="180" height="50" /></td>    </tr>
                                                                        <tr><td style="height:1px; background-color:gray;"> </td>    </tr>
                                                                        <tr><td class="stl_apostillador_vista_sticker" ><asp:Label runat="server" ID="lblApostillador"></asp:Label></td>     </tr>
                                                                        <tr><td class="stl_firma_vista_sticker"><asp:Label runat="server" ID="lblDireccion"></asp:Label></td>     </tr>
                                                                        <tr><td class="stl_firma_vista_sticker"><asp:Label runat="server"   ID="lblMRE"></asp:Label></td>     </tr>                                    
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
    <div style="position: absolute; top: 2px; left: 10px;" >
<center><a href="#"   onClick="imprimir();" id="alink" title="Imprimir Apostilla"> Imprimir</a></center>
</div>

</body>
</html>

<script type="text/javascript">
function imprimir(){
document.getElementById("alink").style.visibility = "hidden";
window.print();
return false;

}
</script>