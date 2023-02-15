Imports System.Security.Cryptography

Public Class UIEncriptador

    Private objCrypto As New Crypto(Crypto.CryptoProvider.TripleDES)

    Sub New()
        objCrypto.Key = "XSAE"
        objCrypto.IV = "XSAE"
    End Sub

#Region "Encriptacion"

    Public Function EncriptarCadena(ByVal pstrCadena As String) As String
        EncriptarCadena = objCrypto.CifrarCadena(pstrCadena)
    End Function

    Public Function DesEncriptarCadena(ByVal pstrCadena As String) As String
        DesEncriptarCadena = objCrypto.DescifrarCadena(pstrCadena)
    End Function

#End Region

#Region "Strong Password"

    Public Function GenerarStrongPassword(ByVal pintLongPassword As Int32) As String
        Dim abytRand() As Byte
        Dim strReturn As String = String.Empty
        Dim intChars As Integer
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
        Dim PWD_ALLOWED_CHARS As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*(){}[]|\~`<>?"
        Dim PasswordLength As Integer = pintLongPassword
        ReDim abytRand(PasswordLength)
        rng.GetBytes(abytRand)
        intChars = PWD_ALLOWED_CHARS.Length
        For intLoop As Integer = 0 To PasswordLength - 1
            strReturn &= PWD_ALLOWED_CHARS.Substring((Convert.ToInt32(abytRand(intLoop)) Mod intChars), 1)
        Next
        Return strReturn
    End Function

    Public Function StrongPassword(ByVal pstrPassword As String) As Boolean
        Dim bolMinusculas As Boolean = False
        Dim bolMayusculas As Boolean = False
        Dim bolNumeros As Boolean = False
        Dim bolAlfaNumerico As Boolean = False
        Dim arrPasswords As Array = pstrPassword.ToCharArray()
        For i As Integer = 0 To arrPasswords.Length - 1
            Dim aux As Char = pstrPassword.Chars(i)
            Dim caracter As Integer = Asc(arrPasswords.GetValue(i))
            If caracter >= 48 And caracter <= 57 Then
                bolNumeros = True
            ElseIf caracter >= 65 And caracter <= 90 Then
                bolMayusculas = True
            ElseIf caracter >= 97 And caracter <= 122 Then
                bolMinusculas = True
            Else
                bolAlfaNumerico = True
            End If
        Next
        Return bolMinusculas And bolMayusculas And bolNumeros And bolAlfaNumerico
    End Function

#End Region

End Class