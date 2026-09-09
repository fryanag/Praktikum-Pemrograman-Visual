<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        picImage = New PictureBox()
        lblRole = New Label()
        lblNama = New Label()
        lblNIM = New Label()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        cmbRole = New ComboBox()
        btnLogin = New Button()
        CType(picImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picImage
        ' 
        picImage.Location = New Point(344, 37)
        picImage.Name = "picImage"
        picImage.Size = New Size(125, 62)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.TabIndex = 0
        picImage.TabStop = False
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(270, 169)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(39, 20)
        lblRole.TabIndex = 1
        lblRole.Text = "Role"
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(270, 225)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(49, 20)
        lblNama.TabIndex = 2
        lblNama.Text = "Nama"
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(270, 285)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(37, 20)
        lblNIM.TabIndex = 3
        lblNIM.Text = "NIM"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(376, 225)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(125, 27)
        txtNama.TabIndex = 4
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(376, 278)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(125, 27)
        txtNIM.TabIndex = 5
        ' 
        ' cmbRole
        ' 
        cmbRole.FormattingEnabled = True
        cmbRole.Location = New Point(376, 166)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(151, 28)
        cmbRole.TabIndex = 6
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(351, 348)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(94, 29)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Info
        ClientSize = New Size(800, 450)
        Controls.Add(btnLogin)
        Controls.Add(cmbRole)
        Controls.Add(txtNIM)
        Controls.Add(txtNama)
        Controls.Add(lblNIM)
        Controls.Add(lblNama)
        Controls.Add(lblRole)
        Controls.Add(picImage)
        ForeColor = Color.Maroon
        Name = "FrmLogin"
        Text = "FrmLogin"
        CType(picImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents picImage As PictureBox
    Friend WithEvents lblRole As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNIM As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents btnLogin As Button

End Class
