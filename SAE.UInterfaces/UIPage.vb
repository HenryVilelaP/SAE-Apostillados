Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.IO
Imports System.Web
Imports System.Web.HttpContext
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports System.Web.SessionState
Imports SAE.UInterfaces.UIConstantes



Public Class UIPage
    Inherits Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

#Region "Declaraciones"

    Public Const LogoutURL As String = "/Comunes/frmComLogOut.aspx"
    Public Separador As String = "%"

    Private _strConexion As String
    Private _strConexionSTC As String
    Private _intPaginacion As Integer

#End Region

#Region "Propiedades"

    Public Enum Operacion As Integer
        Insertar = 0
        Modificar = 1
        Eliminar = 2
    End Enum
    Public Enum Eliminacion As Integer
        Ninguna = 0
        Unica = 1
        Bloque = 2
    End Enum


    Protected Property OperacionActual() As Operacion
        Get
            Return CType(ViewState("_Operacion"), Operacion)
        End Get
        Set(ByVal value As Operacion)
            ViewState("_Operacion") = value
        End Set
    End Property
    Protected Property TipoEliminacion() As Eliminacion
        Get

            Return IIf(ViewState("_Tipo_Eliminacion") Is Nothing, Eliminacion.Ninguna, CType(ViewState("_Tipo_Eliminacion"), Eliminacion))
        End Get
        Set(ByVal value As Eliminacion)
            ViewState("_Tipo_Eliminacion") = value
        End Set
    End Property

#Region " DATOS SESSION ACTUAL"


    Public Property varIdUnidadActual() As Integer
        Get
            Return Convert.ToInt32((Session("_IdUnidadActual")))
        End Get
        Set(ByVal value As Integer)
            Session("_IdUnidadActual") = value
        End Set
    End Property
    Public Property varIdPerfilActual() As Integer
        Get
            Return Convert.ToInt32(Session("_IdPerfilActual"))
        End Get
        Set(ByVal value As Integer)
            Session("_IdPerfilActual") = value
        End Set
    End Property
    Public Property varIdOficinaActual() As Integer
        Get
            Return Convert.ToInt32(Session("_IdOficinaActual"))
        End Get
        Set(ByVal value As Integer)
            Session("_IdOficinaActual") = value
        End Set
    End Property
    Public Property varIdCodigoAuditoria() As Integer
        Get
            Return Convert.ToInt32(Session("_IDPerfilUsuarioOficina"))
        End Get
        Set(ByVal value As Integer)
            Session("_IDPerfilUsuarioOficina") = value
        End Set
    End Property
    Public Property varIdModuloSel() As Integer
        Get
            Return Convert.ToInt32(Session("IdModuloSel"))
        End Get
        Set(ByVal value As Integer)
            Session("IdModuloSel") = value
        End Set
    End Property
    Public Property varNombreModuloSel() As String
        Get
            If Session("NombreModuloSel") Is Nothing Then
                Session("NombreModuloSel") = ""
            End If
            Return DirectCast(Session("NombreModuloSel"), String)
        End Get
        Set(ByVal value As String)
            Session("NombreModuloSel") = value
        End Set
    End Property
    Public Property varIdUbicacionOficinaSel() As Integer
        Get
            Return Convert.ToInt32(Session("_IdUbicacionOficina"))
        End Get
        Set(ByVal value As Integer)
            Session("_IdUbicacionOficina") = value
        End Set
    End Property




    Public Property Usuario() As Object
        Get
            Return DirectCast(Session("Usuario"), Object)
        End Get
        Set(ByVal value As Object)
            Session("Usuario") = value
        End Set
    End Property
    Public Property EmailUsuario() As String
        Get
            If Session("EmailUsuario") Is Nothing Then
                Session("EmailUsuario") = ""
            End If
            Return DirectCast(Session("EmailUsuario"), String)
        End Get
        Set(ByVal value As String)
            Session("EmailUsuario") = value
        End Set
    End Property
    Public Property NombreUsuario() As String
        Get
            If Session("NombreUsuario") Is Nothing Then
                Session("NombreUsuario") = ""
            End If
            Return DirectCast(Session("NombreUsuario"), String)
        End Get
        Set(ByVal value As String)
            Session("NombreUsuario") = value
        End Set
    End Property

#End Region


    Public ReadOnly Property Conexion() As String
        Get
            Return _strConexion
        End Get
    End Property

    Public ReadOnly Property ConexionSTC() As String
        Get
            Return Me._strConexionSTC
        End Get
    End Property


    Public ReadOnly Property Paginacion() As Integer
        Get
            Return Me._intPaginacion
        End Get
    End Property

    'Protected Property TipoOperacionActual() As UIConstantes.TipoOperacion
    '    Get
    '        Return DirectCast(Me.ViewState(UIConstantes.TipoOperacionActual), UIConstantes.TipoOperacion)
    '    End Get
    '    Set(ByVal Value As UIConstantes.TipoOperacion)
    '        Me.ViewState(UIConstantes.TipoOperacionActual) = Value
    '    End Set
    'End Property

    Protected ReadOnly Property _Server() As String
        Get
            'Dim UIEncripto As New UIEncripto
            'Return UIEncripto.DecryptText(ConfigurationManager.AppSettings("Server"))
            Return ""
        End Get
    End Property

#End Region

#Region "Eventos"


    Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim _url As String = Request.ApplicationPath & System.Web.Configuration.WebConfigurationManager.AppSettings("RutaLogin")
        Try

            If Context.Session Is Nothing Then
                Response.Redirect(_url)
            Else
                Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
            End If
            If System.Web.HttpContext.Current.Request.Url.ToString.LastIndexOf(Request.ApplicationPath & "/Default.aspx") < 0 Then
                If Session("Usuario") Is Nothing Then
                    Session.RemoveAll()
                    Session.Abandon()
                    REM Response.Redirect(_url)
                End If
            End If

        Catch ex As System.NullReferenceException
            If Context.Session Is Nothing Then
                Response.Redirect(_url)
            Else
                Throw ex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Métodos"

    Sub New()

        If ConfigurationManager.AppSettings("paginacion") <> String.Empty Then
            If IsNumeric(ConfigurationManager.AppSettings("paginacion")) Then
                _intPaginacion = Convert.ToInt32(ConfigurationManager.AppSettings("paginacion"))
            Else
                _intPaginacion = 5
            End If
        Else
            _intPaginacion = 5
        End If

        GetConexion()
        '_strConexion = "server=" & UIEncripto.DecryptText(ConfigurationManager.AppSettings("Server")) & ";database=" & UIEncripto.DecryptText(ConfigurationManager.AppSettings("database")) & ";user id=" & UIEncripto.DecryptText(ConfigurationManager.AppSettings("user")) & ";password=" & UIEncripto.DecryptText(ConfigurationManager.AppSettings("password")) & ";"
        '_strConexion = "Persist Security Info=False;User ID=sa;password=avances;Initial Catalog=SAC;Data Source=LORENA-QUISPE"

    End Sub
    Private Sub GetConexion()
        Dim UIEncripto As New UIEncriptador

        Dim tipoConexcion As String = Convert.ToString(ConfigurationManager.AppSettings("TipoConexionBD"))

        If (tipoConexcion = "SQL") Then
            _strConexion = " data source=" & ConfigurationManager.AppSettings("Server") & ";  initial catalog=" & ConfigurationManager.AppSettings("database") & " ; user id=" & ConfigurationManager.AppSettings("user") & " ; Password=" & ConfigurationManager.AppSettings("password") & " ;"
        ElseIf (tipoConexcion = "SQLX") Then
            _strConexion = "data source=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("Server")) & ";initial catalog=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("database")) & ";user id=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("user")) & ";password=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("password")) & ";"
        ElseIf (tipoConexcion = "WIN") Then
            _strConexion = "Server=" & ConfigurationManager.AppSettings("Server") & "; initial catalog=" & ConfigurationManager.AppSettings("database") & "; Trusted_Connection=True;Integrated Security=True"
        ElseIf (tipoConexcion = "WINX") Then
            _strConexion = "Server=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("Server")) & "; initial catalog=" & UIEncripto.DesEncriptarCadena(ConfigurationManager.AppSettings("database")) & "; Trusted_Connection=True;Integrated Security=True"
        End If


    End Sub

    Public Shared Function GetControl(ByVal item As DataGridItem, ByVal name As String) As Control
        Dim value As Control = item.FindControl(name)
        If value Is Nothing Then
            Throw New Exception("No existe el control '" + name + "' en el datagrid.")
        End If
        Return value
    End Function

    Public Shared Sub GridBindLabel(ByVal item As DataGridItem, ByVal name As String, ByVal value As String)
        Dim control As Label = DirectCast(GetControl(item, name), Label)
        control.Text = value
    End Sub

    Public Shared Function GridBindLabel(ByVal item As DataGridItem, ByVal name As String) As String
        Dim control As Label = DirectCast(GetControl(item, name), Label)
        Return control.Text
    End Function

    Public Shared Sub GridBindLinkButton(ByVal item As DataGridItem, ByVal name As String, ByVal value As String)
        Dim control As LinkButton = DirectCast(GetControl(item, name), LinkButton)
        control.Text = value
    End Sub

    Public Shared Function GridBindLinkButton(ByVal item As DataGridItem, ByVal name As String) As String
        Dim control As LinkButton = DirectCast(GetControl(item, name), LinkButton)
        Return control.Text
    End Function

    Public Shared Sub GridBindCheckBox(ByVal item As DataGridItem, ByVal name As String, ByVal value As Boolean)
        Dim control As CheckBox = DirectCast(GetControl(item, name), CheckBox)
        control.Checked = value
    End Sub

    Public Shared Function GridBindCheckBox(ByVal item As DataGridItem, ByVal name As String) As Boolean
        Dim control As CheckBox = DirectCast(GetControl(item, name), CheckBox)
        Return control.Checked
    End Function

    Public Shared Sub Bind(ByVal control As DropDownList, ByVal values As ICollection, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As DropDownList, ByVal values As DataTable, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As DropDownList, ByVal values As ICollection)
        control.DataSource = values
        control.DataValueField = "Codigo"
        control.DataTextField = "Descripcion"
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As ListBox, ByVal values As DataTable, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As ListBox, ByVal values As ICollection, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As CheckBoxList, ByVal values As DataTable, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As CheckBoxList, ByVal values As ICollection, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As RadioButtonList, ByVal values As DataTable, ByVal valuefield As String, ByVal textfield As String)
        control.DataSource = values
        control.DataValueField = valuefield.Trim()
        control.DataTextField = textfield
        control.DataBind()
    End Sub
    Public Shared Sub Bind(ByVal control As DataList, ByVal values As ICollection)
        control.DataSource = values
        control.DataBind()
    End Sub

    Public Shared Sub Bind(ByVal control As DataList, ByVal values As DataTable)
        control.DataSource = values
        control.DataBind()
    End Sub

    Public Shared Sub FillSituacionDll(ByVal control As DropDownList, Optional ByVal blEsSituacionUsuario As Boolean = False)

        control.Items.Add(New ListItem("<Todos>", Situacion.Todos))
        control.Items.Add(New ListItem("Activo", Situacion.Activo))
        REM  If blEsSituacionUsuario Then control.Items.Add(New ListItem("Bloqueado", Situacion.Bloqueado))
        control.Items.Add(New ListItem("Inactivo", Situacion.Inactivo))

    End Sub
    Public Shared Sub addItemTodos(ByVal control As DropDownList)
        control.Items.Insert(0, New ListItem("<Todos>", Situacion.Todos))
    End Sub

    Public Shared Function IsMail(ByVal p_email As String) As Boolean
        Dim l_reg = New System.Text.RegularExpressions.Regex("^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
        Return (l_reg.IsMatch(p_email))
    End Function


    Public Shared Sub AlmacenarErrorLog( _
        ByVal pexpError As Exception)

        Dim objWriter As StreamWriter
        Dim objFile As FileStream
        Dim objDirectorio As DirectoryInfo

        'SE CREA EL DIRECTORIO LOG
        objDirectorio = New DirectoryInfo(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\log\")
        If Not objDirectorio.Exists Then
            objDirectorio.Create()
        End If
        For Each objFileOld As FileInfo In objDirectorio.GetFiles("*.log")
            If objFileOld.LastAccessTime.AddDays(30) < DateTime.Now Then
                objFileOld.Delete()
            End If
        Next
        objFile = New FileStream(objDirectorio.FullName & "LogError" & DateTime.Now.ToString("yyyy-MM-dd") & ".log", FileMode.OpenOrCreate, FileAccess.Write)
        objWriter = New StreamWriter(objFile)
        objWriter.BaseStream.Seek(0, SeekOrigin.End)
        'objWriter.WriteLine("[Telefono   ][" + pstrTelefono + "]")
        objWriter.WriteLine("[Fecha      ][" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]")
        objWriter.WriteLine("[Source     ][" + pexpError.Source + "]")
        objWriter.WriteLine("[Mensaje    ][" + pexpError.Message + "]")
        objWriter.WriteLine("[StackTrace ][" + pexpError.StackTrace + "]")
        objWriter.WriteLine()
        objWriter.Flush()
        objWriter.Close()
        objFile.Close()
    End Sub

    ''RPB 26/11/2007
    'Protected Overridable Sub NotificarError(ByVal ex As Exception)
    '    Me.Session(UIConstantes.Exception) = ex
    '    AlmacenarErrorLog(ex)
    '    Me.Response.Redirect("../../Comunes/frmError.aspx")
    'End Sub

#End Region

End Class
