Imports SAE.UInterfaces


Public Class frmEncriptacion

    Private Sub Encripta(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncripta.Click
        Try
            Dim objCifrar As New UIEncriptador
            Me.txtResult.Text = objCifrar.EncriptarCadena(Me.txtDato.Text.Trim)
            Me.lblResult.Text = "Cadena Encriptada"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnDescencripta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescencripta.Click
        Try
            Dim objCifrar As New UIEncriptador
            Me.txtResult.Text = objCifrar.DesEncriptarCadena(Me.txtDato.Text.Trim)
            Me.lblResult.Text = "Cadena Desencriptada"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnLimipar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimipar.Click
        Try
            Me.txtDato.Text = String.Empty
            Me.txtResult.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class