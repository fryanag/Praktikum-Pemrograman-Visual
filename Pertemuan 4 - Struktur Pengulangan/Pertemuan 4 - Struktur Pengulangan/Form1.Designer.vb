<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerulangan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblNilaiAwal = New Label()
        lblNilaiAkhir = New Label()
        btnInput = New Button()
        txtNilaiAwal = New TextBox()
        txtNilaiAkhir = New TextBox()
        lstHasil = New ListBox()
        SuspendLayout()
        ' 
        ' lblNilaiAwal
        ' 
        lblNilaiAwal.AutoSize = True
        lblNilaiAwal.Location = New Point(279, 77)
        lblNilaiAwal.Name = "lblNilaiAwal"
        lblNilaiAwal.Size = New Size(77, 20)
        lblNilaiAwal.TabIndex = 0
        lblNilaiAwal.Text = "Nilai Awal"
        ' 
        ' lblNilaiAkhir
        ' 
        lblNilaiAkhir.AutoSize = True
        lblNilaiAkhir.Location = New Point(279, 161)
        lblNilaiAkhir.Name = "lblNilaiAkhir"
        lblNilaiAkhir.Size = New Size(78, 20)
        lblNilaiAkhir.TabIndex = 1
        lblNilaiAkhir.Text = "Nilai Akhir"
        ' 
        ' btnInput
        ' 
        btnInput.Location = New Point(332, 250)
        btnInput.Name = "btnInput"
        btnInput.Size = New Size(94, 29)
        btnInput.TabIndex = 2
        btnInput.Text = "Input"
        btnInput.UseVisualStyleBackColor = True
        ' 
        ' txtNilaiAwal
        ' 
        txtNilaiAwal.Location = New Point(394, 79)
        txtNilaiAwal.Name = "txtNilaiAwal"
        txtNilaiAwal.Size = New Size(125, 27)
        txtNilaiAwal.TabIndex = 3
        ' 
        ' txtNilaiAkhir
        ' 
        txtNilaiAkhir.Location = New Point(394, 154)
        txtNilaiAkhir.Name = "txtNilaiAkhir"
        txtNilaiAkhir.Size = New Size(125, 27)
        txtNilaiAkhir.TabIndex = 4
        ' 
        ' lstHasil
        ' 
        lstHasil.FormattingEnabled = True
        lstHasil.Location = New Point(308, 303)
        lstHasil.Name = "lstHasil"
        lstHasil.Size = New Size(150, 104)
        lstHasil.TabIndex = 5
        ' 
        ' FrmPerulangan
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lstHasil)
        Controls.Add(txtNilaiAkhir)
        Controls.Add(txtNilaiAwal)
        Controls.Add(btnInput)
        Controls.Add(lblNilaiAkhir)
        Controls.Add(lblNilaiAwal)
        Name = "FrmPerulangan"
        Text = "Form Perulangan"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNilaiAwal As Label
    Friend WithEvents lblNilaiAkhir As Label
    Friend WithEvents btnInput As Button
    Friend WithEvents txtNilaiAwal As TextBox
    Friend WithEvents txtNilaiAkhir As TextBox
    Friend WithEvents lstHasil As ListBox

End Class
