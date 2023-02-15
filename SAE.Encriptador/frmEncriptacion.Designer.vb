<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEncriptacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLimipar = New System.Windows.Forms.Button
        Me.lblResult = New System.Windows.Forms.Label
        Me.lblCadena = New System.Windows.Forms.Label
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.btnDescencripta = New System.Windows.Forms.Button
        Me.btnEncripta = New System.Windows.Forms.Button
        Me.txtDato = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnLimipar
        '
        Me.btnLimipar.Location = New System.Drawing.Point(510, 23)
        Me.btnLimipar.Name = "btnLimipar"
        Me.btnLimipar.Size = New System.Drawing.Size(64, 23)
        Me.btnLimipar.TabIndex = 13
        Me.btnLimipar.Text = "Limpiar"
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(22, 71)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(168, 16)
        Me.lblResult.TabIndex = 12
        '
        'lblCadena
        '
        Me.lblCadena.Location = New System.Drawing.Point(22, 23)
        Me.lblCadena.Name = "lblCadena"
        Me.lblCadena.Size = New System.Drawing.Size(88, 16)
        Me.lblCadena.TabIndex = 11
        Me.lblCadena.Text = "Cadena.."
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(214, 63)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(352, 20)
        Me.txtResult.TabIndex = 10
        '
        'btnDescencripta
        '
        Me.btnDescencripta.Location = New System.Drawing.Point(422, 23)
        Me.btnDescencripta.Name = "btnDescencripta"
        Me.btnDescencripta.Size = New System.Drawing.Size(80, 23)
        Me.btnDescencripta.TabIndex = 9
        Me.btnDescencripta.Text = "Desencriptar"
        '
        'btnEncripta
        '
        Me.btnEncripta.Location = New System.Drawing.Point(342, 23)
        Me.btnEncripta.Name = "btnEncripta"
        Me.btnEncripta.Size = New System.Drawing.Size(75, 23)
        Me.btnEncripta.TabIndex = 8
        Me.btnEncripta.Text = "Encriptar"
        '
        'txtDato
        '
        Me.txtDato.Location = New System.Drawing.Point(110, 23)
        Me.txtDato.Name = "txtDato"
        Me.txtDato.Size = New System.Drawing.Size(216, 20)
        Me.txtDato.TabIndex = 7
        '
        'frmEncriptacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 110)
        Me.Controls.Add(Me.btnLimipar)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblCadena)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnDescencripta)
        Me.Controls.Add(Me.btnEncripta)
        Me.Controls.Add(Me.txtDato)
        Me.Name = "frmEncriptacion"
        Me.Text = "Encriptación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLimipar As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblCadena As System.Windows.Forms.Label
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents btnDescencripta As System.Windows.Forms.Button
    Friend WithEvents btnEncripta As System.Windows.Forms.Button
    Friend WithEvents txtDato As System.Windows.Forms.TextBox
End Class
