
function validarSeleccion(numOpc){

alert(numOpc);
return false;
}

function FC_EfectoBoton(ruta,imagen,objeto){
//  debugger;
	objeto = eval(objeto);
	objeto.src = (ruta + imagen);
}
function Grabar(){
         if(confirm("Estas seguro de Grabar")){
         
          return true ;
         
         }else{
          
          return false;
          
         }
}


function ShowModalDialog(url, name, width, height)
{
	var res;
	if (window.showModalDialog)
	{
		res = window.showModalDialog(url, name, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;status=0;scroll=no;");
		//res = window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,modal=yes');
	}
	else
	{ 
		//netscape.security.PrivilegeManager.enablePrivilege("UniversalBrowserWrite");
		res = window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes');
		res.focus();
		//netscape.security.PrivilegeManager.disablePrivilege("UniversalBrowserWrite");
	}	
	return res;		
}

function ShowModalDialogSinCroollbars(url, name, width, height)
{
	var res;
	xpos=(window.screen.width/2)-(width/2);
	ypos=(window.screen.height/2)-(height/2);
	if (window.showModalDialog)
	{
		res = window.showModalDialog(url, name, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;status=0;scroll=no;");
		//res = window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,modal=yes,top='+ypos+',left='+xpos);
	}
	else
	{ 
		//netscape.security.PrivilegeManager.enablePrivilege("UniversalBrowserWrite");
		res = window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,modal=yes,top='+ypos+',left='+xpos);		
		res.focus();
		//netscape.security.PrivilegeManager.disablePrivilege("UniversalBrowserWrite");
	}	
	return res;		
}
 function solonumeros(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key >= 48 && key <= 57));
}
function solonumerosypunto(e)
{
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	if (key == 46) return (target.value.length > 0 && target.value.indexOf(".") == -1);
	return (key <= 12 || (key >= 48 && key <= 57));
}

function solodecimalsigno(e)
{
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	if (key == 46) return (target.value.length > 0 && target.value.indexOf(".") == -1);
	if (key == 45) return (target.value.length > 0 && target.value.indexOf("-") == -1);
	return (key <= 12 || (key >= 48 && key <= 57));
}

function sololetrasynumeros(e)
{
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key>=48 && key <=57) || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165));
}
function sololetras(e)
{	 
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165)); 
}
function soloalfanumericos(e)
{	 
    var cadena="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789 ";
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	var letra=String.fromCharCode(key);
	var idx=cadena.indexOf(letra)
	if(idx!=-1){
	 	return true;	
	}else{
		return false;
			
	}
	
	//return (key <= 12 || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165) || (key>=48 && key <=57) );
}

function solonumerosyguion(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || key == 45 ||(key >= 48 && key <= 57));
}
function solohora(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || key ==58 ||(key >= 48 && key <= 57));
}
function solofecha(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || key ==47 ||(key >= 48 && key <= 57));
}
 