Imports System.Text

Public Class UIConstantes


    Public Enum TipoOperacion As Integer
        Ninguna = 0
        Busqueda = 1
        Creacion = 2
        Modificacion = 3
        Eliminacion = 4
        Consulta = 5
    End Enum

#Region " CORRESPONDE AL CAMPO CODIGO DE TABLA DE PARAMETRO"

    Public Class PARAMETROS              REM CORRESPONDE AL CAMPO CODIGO DE TABLA DE PARAMETRO
        Public Const TABLA_CARGO_APOSTILLADOR As Integer = 1
        Public Const TABLA_CARGO_AUTORIDAD_FIRMANTE As Integer = 2
        Public Const TABLA_DOCUMENTO_APOSTILLAR As Integer = 3
        Public Const TABLA_ENTIDAD_AUTORIDAD_FIRMANTE As Integer = 4
        Public Const TABLA_UBICACION As Integer = 5
        Public Const TABLA_TIPO_DOCUMENTO_IDENTIDAD As Integer = 6
        Public Const TABLA_MESES As Integer = 7
        Public Const TABLA_TIPO_OFICINA As Integer = 8
        Public Const TABLA_CONFIGURACION_SISTEMA As Integer = 9

    End Class

#End Region

#Region "CORRESPONDE AL CAMPO CODIGO DE REGISTRO DE PARAMETRO"
    Public Class CONFIGURACION   REM CORRESPONDE AL CAMPO CODIGO DE REGISTRO DE PARAMETRO
        Public Const RUTA_WEB_STICKER_APOSTILLA As Integer = 1
        'Public Const PASAPORTE As Integer = 2
        'Public Const CARNETEXTRANGERIA As Integer = 3


    End Class


    Public Class TIPO_DOCUMENTO_IDENTIDAD   REM CORRESPONDE AL CAMPO CODIGO DE REGISTRO DE PARAMETRO
        Public Const DNI As Integer = 1
        Public Const PASAPORTE As Integer = 2
        Public Const CARNETEXTRANGERIA As Integer = 3


    End Class
    Public Class UBICACION   REM CORRESPONDE AL CAMPO CODIGO DE REGISTRO DE PARAMETRO
        Public Const LIMA As String = "1"
        Public Const MISION As String = "2"

    End Class

    Public Class TIPO_OFICINA   REM CORRESPONDE AL CAMPO CODIGO DE REGISTRO DE PARAMETRO

        Public Const CONSULADOHONORARIO As Integer = 1
        Public Const CONSULADOCARRERA As Integer = 2
        Public Const CONSULADOGENERAL As Integer = 3
        Public Const EMBAJADAS As Integer = 4
        Public Const OFICINACOMERCIALES As Integer = 5
        Public Const REPRESENTACIONESPERMANENTES As Integer = 6
        Public Const OFICINACENTRAL As Integer = 7
        Public Const SUCURSAL As Integer = 8

 

    End Class


#End Region

    Public Class Situacion
        Public Const Activo As String = "A"
        Public Const Inactivo As String = "I"
        Public Const Bloqueado As String = "I"
        Public Const Extornado As String = "E"
        Public Const Todos As String = ""
        Public Const Terminado As String = "T"


    End Class
    Public Class Perfil
        Public Const ADMINISTRADOR_SEGURIDAD As String = "0"
        Public Const ADMINISTRADOR As String = "1"
        Public Const APOSTILLADOR As String = "2"
    End Class
     
    Public Class Sexo
        Public Const Femenino As String = "F"
        Public Const Masculino As String = "M"
    End Class
    Public Class TIPO_ACCESO_OPCION
        Public Const READ As String = "R"
        Public Const WRITE As String = "W"
        Public Const NONE As String = "N"
    End Class
    Public Class Alertas

        ' Login
        Public Const MSAElaveIncorrecta As String = "La contraseña ingresada es incorrecta"
        Public Const MsgUsuNoExiste As String = "El usuario ingresado no existe"
        Public Const MsgUsuIncorrecto As String = "El usuario ingresado y/o la contraseña son incorrectos."
        Public Const MsgUsuClaveVacio As String = "Debe ingresar su usuario y contraseña"
        Public Const MsgUsuBloqueado As String = "Se ha excedido en el numero de intentos. Usuario Bloqueado."
        Public Const MSAElaveCambiada As String = "Se cambio su contraseña con éxito"
        Public Const MSAElaveInsegura As String = "La contraseña ingresada no es segura. Debe ingresar números, letras en mayúsculas y minúsculas."
        Public Const MSAElaveLongitud As String = "La longitud de su constraseña debe ser mayor o igual a {0}"

    End Class



End Class