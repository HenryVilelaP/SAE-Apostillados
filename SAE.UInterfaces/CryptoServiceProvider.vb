Imports System
Imports System.Security.Cryptography

Friend Class CryptoServiceProvider
    Private algorithm As CryptoProvider
    Private cAction As CryptoAction

    Friend Enum CryptoAction
        Encrypt
        Desencrypt
    End Enum

    Friend Enum CryptoProvider
        DES
        TripleDES
        RC2
        Rijndael
    End Enum

    Friend Sub New(ByVal alg As CryptoProvider, ByVal action As CryptoAction)
        Me.algorithm = alg
        Me.cAction = action
    End Sub

    Friend Function GetServiceProvider(ByVal Key As Byte(), ByVal IV As Byte()) As ICryptoTransform
        Dim transform As ICryptoTransform = Nothing
        Select Case Me.algorithm
            Case CryptoProvider.DES
                Dim des As DESCryptoServiceProvider = New DESCryptoServiceProvider
                Select Case cAction
                    Case CryptoAction.Encrypt
                        transform = des.CreateEncryptor(Key, IV)
                        ' break 
                    Case CryptoAction.Desencrypt
                        transform = des.CreateDecryptor(Key, IV)
                        ' break 
                End Select
                Return transform
            Case CryptoProvider.TripleDES
                Dim des3 As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                Select Case cAction
                    Case CryptoAction.Encrypt
                        transform = des3.CreateEncryptor(Key, IV)
                        ' break 
                    Case CryptoAction.Desencrypt
                        transform = des3.CreateDecryptor(Key, IV)
                        ' break 
                End Select
                Return transform
            Case CryptoProvider.RC2
                Dim rc2 As RC2CryptoServiceProvider = New RC2CryptoServiceProvider
                Select Case cAction
                    Case CryptoAction.Encrypt
                        transform = rc2.CreateEncryptor(Key, IV)
                        ' break 
                    Case CryptoAction.Desencrypt
                        transform = rc2.CreateDecryptor(Key, IV)
                        ' break 
                End Select
                Return transform
            Case CryptoProvider.Rijndael
                Dim rijndael As Rijndael = New RijndaelManaged
                Select Case cAction
                    Case CryptoAction.Encrypt
                        transform = rijndael.CreateEncryptor(Key, IV)
                        ' break 
                    Case CryptoAction.Desencrypt
                        transform = rijndael.CreateDecryptor(Key, IV)
                        ' break 
                End Select
                Return transform
            Case Else
                Throw New CryptographicException("Error al inicializar al proveedor de cifrado")
        End Select
    End Function
End Class
