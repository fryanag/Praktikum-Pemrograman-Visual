<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        lblName = New Label()
        lblNIM = New Label()
        lblKOM = New Label()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        txtKOM = New TextBox()
        btnTampilkan = New Button()
        btnHapus = New Button()
        btnKeluar = New Button()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(377, 63)
        lblName.Name = "lblName"
        lblName.Size = New Size(64, 20)
        lblName.TabIndex = 0
        lblName.Text = "NAMA  :"
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(377, 107)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(64, 20)
        lblNIM.TabIndex = 1
        lblNIM.Text = "NIM      :"
        ' 
        ' lblKOM
        ' 
        lblKOM.AutoSize = True
        lblKOM.Location = New Point(377, 146)
        lblKOM.Name = "lblKOM"
        lblKOM.Size = New Size(64, 20)
        lblKOM.TabIndex = 2
        lblKOM.Text = "KOM     :"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(504, 60)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(125, 27)
        txtNama.TabIndex = 3
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(504, 104)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(125, 27)
        txtNIM.TabIndex = 4
        ' 
        ' txtKOM
        ' 
        txtKOM.Location = New Point(504, 143)
        txtKOM.Name = "txtKOM"
        txtKOM.Size = New Size(125, 27)
        txtKOM.TabIndex = 5
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(348, 212)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(105, 29)
        btnTampilkan.TabIndex = 6
        btnTampilkan.Text = "TAMPILKAN"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(568, 212)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(94, 29)
        btnHapus.TabIndex = 7
        btnHapus.Text = "HAPUS"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnKeluar
        ' 
        btnKeluar.Location = New Point(465, 253)
        btnKeluar.Name = "btnKeluar"
        btnKeluar.Size = New Size(94, 29)
        btnKeluar.TabIndex = 8
        btnKeluar.Text = "KELUAR"
        btnKeluar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Info
        ClientSize = New Size(1133, 450)
        Controls.Add(btnKeluar)
        Controls.Add(btnHapus)
        Controls.Add(btnTampilkan)
        Controls.Add(txtKOM)
        Controls.Add(txtNIM)
        Controls.Add(txtNama)
        Controls.Add(lblKOM)
        Controls.Add(lblNIM)
        Controls.Add(lblName)
        Name = "Form1"
        Text = "PROFIL MAHASISWA"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents lblNIM As Label
    Friend WithEvents lblKOM As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents txtKOM As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnKeluar As Button

End Class
