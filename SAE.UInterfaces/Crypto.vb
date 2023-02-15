Imports System
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography

Public Class Crypto
    Private stringKey As String
    Private stringIV As String
    Private algorithm As CryptoProvider

    Public Enum CryptoProvider
        DES
        TripleDES
        RC2
        Rijndael
    End Enum

    Public Enum CryptoAction
        Encrypt
        Desencrypt
    End Enum

    Public Sub New(ByVal alg As CryptoProvider)
        Me.algorithm = alg
    End Sub

    Public Property Key() As String
        Get
            Return stringKey
        End Get
        Set(ByVal Value As String)
            stringKey = value
        End Set
    End Property

    Public Property IV() As String
        Get
            Return stringIV
        End Get
        Set(ByVal Value As String)
            stringIV = value
        End Set
    End Property

    Public Function CifrarCadena(ByVal CadenaOriginal As String) As String
        Dim memStream As MemoryStream = Nothing
        Try
            If Not (stringKey Is Nothing) AndAlso Not (stringIV Is Nothing) Then
                Dim key As Byte() = MakeKeyByteArray
                Dim IV As Byte() = MakeIVByteArray
                Dim textoPlano As Byte() = Encoding.UTF8.GetBytes(CadenaOriginal)
                memStream = New MemoryStream(CadenaOriginal.Length * 2)
                Dim cryptoProvider As CryptoServiceProvider = New CryptoServiceProvider(CType(Me.algorithm, CryptoServiceProvider.CryptoProvider), CryptoServiceProvider.CryptoAction.Encrypt)
                Dim transform As ICryptoTransform = cryptoProvider.GetServiceProvider(key, IV)
                Dim cs As CryptoStream = New CryptoStream(memStream, transform, CryptoStreamMode.Write)
                cs.Write(textoPlano, 0, textoPlano.Length)
                cs.Close()
            Else
                Throw New Exception("Error al inicializar la clave y el vector")
            End If
        Catch
            Throw
        End Try
        Return Convert.ToBase64String(memStream.ToArray)
    End Function

    Public Function DescifrarCadena(ByVal CadenaCifrada As String) As String
        Dim memStream As MemoryStream = Nothing
        Try
            If Not (stringKey Is Nothing) AndAlso Not (stringIV Is Nothing) Then
                Dim key As Byte() = MakeKeyByteArray
                Dim IV As Byte() = MakeIVByteArray
                Dim textoCifrado As Byte() = Convert.FromBase64String(CadenaCifrada)
                memStream = New MemoryStream(CadenaCifrada.Length)
                Dim cryptoProvider As CryptoServiceProvider = New CryptoServiceProvider(CType(Me.algorithm, CryptoServiceProvider.CryptoProvider), CryptoServiceProvider.CryptoAction.Desencrypt)
                Dim transform As ICryptoTransform = cryptoProvider.GetServiceProvider(key, IV)
                Dim cs As CryptoStream = New CryptoStream(memStream, transform, CryptoStreamMode.Write)
                cs.Write(textoCifrado, 0, textoCifrado.Length)
                cs.Close()
            Else
                Throw New Exception("Error al inicializar la clave y el vector.")
            End If
        Catch
            Throw
        End Try
        Return Encoding.UTF8.GetString(memStream.ToArray)
    End Function

    Private Function MakeKeyByteArray() As Byte()
        Select Case Me.algorithm
            Case CryptoProvider.DES, CryptoProvider.RC2
                If stringKey.Length < 8 Then
                    stringKey = stringKey.PadRight(8)
                Else
                    If stringKey.Length > 8 Then
                        stringKey = stringKey.Substring(0, 8)
                    End If
                End If
                ' break 
            Case CryptoProvider.TripleDES, CryptoProvider.Rijndael
                If stringKey.Length < 16 Then
                    stringKey = stringKey.PadRight(16)
                Else
                    If stringKey.Length > 16 Then
                        stringKey = stringKey.Substring(0, 16)
                    End If
                End If
                ' break 
        End Select
        Return Encoding.UTF8.GetBytes(stringKey)
    End Function

    Private Function MakeIVByteArray() As Byte()
        Select Case Me.algorithm
            Case CryptoProvider.DES, CryptoProvider.RC2, CryptoProvider.TripleDES
                If stringIV.Length < 8 Then
                    stringIV = stringIV.PadRight(8)
                Else
                    If stringIV.Length > 8 Then
                        stringIV = stringIV.Substring(0, 8)
                    End If
                End If
                ' break 
            Case CryptoProvider.Rijndael
                If stringIV.Length < 16 Then
                    stringIV = stringIV.PadRight(16)
                Else
                    If stringIV.Length > 16 Then
                        stringIV = stringIV.Substring(0, 16)
                    End If
                End If
                ' break 
        End Select
        Return Encoding.UTF8.GetBytes(stringIV)
    End Function

    Public Sub CifrarDescifrarArchivo(ByVal InFileName As String, ByVal OutFileName As String, ByVal Action As CryptoAction)
        If Not File.Exists(InFileName) Then
            Throw New Exception("No se ha encontrado el archivo.")
        End If
        Try
            If Not (stringKey Is Nothing) AndAlso Not (stringIV Is Nothing) Then
                Dim fsIn As FileStream = New FileStream(InFileName, FileMode.Open, FileAccess.Read)
                Dim fsOut As FileStream = New FileStream(OutFileName, FileMode.OpenOrCreate, FileAccess.Write)
                fsOut.SetLength(0)
                Dim key As Byte() = MakeKeyByteArray
                Dim IV As Byte() = MakeIVByteArray
                Dim byteBuffer(4096) As Byte
                Dim largoArchivo As Long = fsIn.Length
                Dim bytesProcesados As Long = 0
                Dim bloqueBytes As Integer = 0
                Dim cryptoProvider As CryptoServiceProvider = New CryptoServiceProvider(CType(Me.algorithm, CryptoServiceProvider.CryptoProvider), CType(Action, CryptoServiceProvider.CryptoAction))
                Dim transform As ICryptoTransform = cryptoProvider.GetServiceProvider(key, IV)
                Dim cryptoStream As CryptoStream = Nothing
                Select Case Action
                    Case CryptoAction.Encrypt
                        cryptoStream = New CryptoStream(fsOut, transform, CryptoStreamMode.Write)
                        ' break 
                    Case CryptoAction.Desencrypt
                        cryptoStream = New CryptoStream(fsOut, transform, CryptoStreamMode.Write)
                        ' break 
                End Select
                While bytesProcesados < largoArchivo
                    bloqueBytes = fsIn.Read(byteBuffer, 0, 4096)
                    cryptoStream.Write(byteBuffer, 0, bloqueBytes)
                    bytesProcesados += CType(bloqueBytes, Long)
                End While
                If Not (cryptoStream Is Nothing) Then
                    cryptoStream.Close()
                End If
                fsIn.Close()
                fsOut.Close()
            Else
                Throw New Exception("Error al inicializar la clave y el vector.")
            End If
        Catch
            Throw
        End Try
    End Sub

End Class
