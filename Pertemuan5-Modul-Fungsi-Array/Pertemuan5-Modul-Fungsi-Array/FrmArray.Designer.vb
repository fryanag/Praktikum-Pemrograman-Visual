<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArray
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
        btnTampil = New Button()
        lblPanjang = New Label()
        txtPanjang = New TextBox()
        txtLebar = New TextBox()
        lblLebar = New Label()
        lstNilai = New ListBox()
        SuspendLayout()
        ' 
        ' btnTampil
        ' 
        btnTampil.BackColor = Color.Yellow
        btnTampil.Location = New Point(293, 313)
        btnTampil.Name = "btnTampil"
        btnTampil.Size = New Size(241, 91)
        btnTampil.TabIndex = 0
        btnTampil.Text = "Tampilkan"
        btnTampil.UseVisualStyleBackColor = False
        ' 
        ' lblPanjang
        ' 
        lblPanjang.AutoSize = True
        lblPanjang.Location = New Point(278, 118)
        lblPanjang.Name = "lblPanjang"
        lblPanjang.Size = New Size(61, 20)
        lblPanjang.TabIndex = 1
        lblPanjang.Text = "Panjang"
        ' 
        ' txtPanjang
        ' 
        txtPanjang.Location = New Point(408, 115)
        txtPanjang.Name = "txtPanjang"
        txtPanjang.Size = New Size(125, 27)
        txtPanjang.TabIndex = 2
        ' 
        ' txtLebar
        ' 
        txtLebar.Location = New Point(409, 198)
        txtLebar.Name = "txtLebar"
        txtLebar.Size = New Size(125, 27)
        txtLebar.TabIndex = 3
        ' 
        ' lblLebar
        ' 
        lblLebar.AutoSize = True
        lblLebar.Location = New Point(278, 198)
        lblLebar.Name = "lblLebar"
        lblLebar.Size = New Size(46, 20)
        lblLebar.TabIndex = 4
        lblLebar.Text = "Lebar"
        ' 
        ' lstNilai
        ' 
        lstNilai.FormattingEnabled = True
        lstNilai.Location = New Point(337, 431)
        lstNilai.Name = "lstNilai"
        lstNilai.Size = New Size(150, 104)
        lstNilai.TabIndex = 5
        ' 
        ' FrmArray
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(806, 570)
        Controls.Add(lstNilai)
        Controls.Add(lblLebar)
        Controls.Add(txtLebar)
        Controls.Add(txtPanjang)
        Controls.Add(lblPanjang)
        Controls.Add(btnTampil)
        Name = "FrmArray"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampil As Button
    Friend WithEvents lblPanjang As Label
    Friend WithEvents txtPanjang As TextBox
    Friend WithEvents txtLebar As TextBox
    Friend WithEvents lblLebar As Label
    Friend WithEvents lstNilai As ListBox

End Class
