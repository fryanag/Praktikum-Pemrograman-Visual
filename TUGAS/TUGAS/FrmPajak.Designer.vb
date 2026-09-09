<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPajak
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblLimaJuta = New Label()
        lblTigaPuluhJuta = New Label()
        lblSeratusJuta = New Label()
        lblPendapatan = New Label()
        lblRupiah = New Label()
        btnHitung = New Button()
        btnKeluar = New Button()
        txtPendapatan = New TextBox()
        SuspendLayout()
        ' 
        ' lblLimaJuta
        ' 
        lblLimaJuta.AutoSize = True
        lblLimaJuta.Location = New Point(278, 73)
        lblLimaJuta.Name = "lblLimaJuta"
        lblLimaJuta.Size = New Size(268, 20)
        lblLimaJuta.TabIndex = 0
        lblLimaJuta.Text = "Pendapatan lebih dari 5 juta, 10% Pajak" & vbLf
        ' 
        ' lblTigaPuluhJuta
        ' 
        lblTigaPuluhJuta.AutoSize = True
        lblTigaPuluhJuta.Location = New Point(278, 122)
        lblTigaPuluhJuta.Name = "lblTigaPuluhJuta"
        lblTigaPuluhJuta.Size = New Size(276, 20)
        lblTigaPuluhJuta.TabIndex = 1
        lblTigaPuluhJuta.Text = "Pendapatan lebih dari 30 juta, 20% Pajak"
        ' 
        ' lblSeratusJuta
        ' 
        lblSeratusJuta.AutoSize = True
        lblSeratusJuta.Location = New Point(278, 167)
        lblSeratusJuta.Name = "lblSeratusJuta"
        lblSeratusJuta.Size = New Size(284, 20)
        lblSeratusJuta.TabIndex = 2
        lblSeratusJuta.Text = "Pendapatan lebih dari 100 juta, 30% Pajak"
        ' 
        ' lblPendapatan
        ' 
        lblPendapatan.AutoSize = True
        lblPendapatan.Location = New Point(329, 235)
        lblPendapatan.Name = "lblPendapatan"
        lblPendapatan.Size = New Size(156, 20)
        lblPendapatan.TabIndex = 3
        lblPendapatan.Text = "Masukkan Pendapatan"
        ' 
        ' lblRupiah
        ' 
        lblRupiah.AutoSize = True
        lblRupiah.Location = New Point(324, 300)
        lblRupiah.Name = "lblRupiah"
        lblRupiah.Size = New Size(30, 20)
        lblRupiah.TabIndex = 4
        lblRupiah.Text = "Rp."
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(278, 355)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(94, 29)
        btnHitung.TabIndex = 5
        btnHitung.Text = "Hitung"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' btnKeluar
        ' 
        btnKeluar.Location = New Point(452, 355)
        btnKeluar.Name = "btnKeluar"
        btnKeluar.Size = New Size(94, 29)
        btnKeluar.TabIndex = 6
        btnKeluar.Text = "Keluar"
        btnKeluar.UseVisualStyleBackColor = True
        ' 
        ' txtPendapatan
        ' 
        txtPendapatan.Location = New Point(360, 297)
        txtPendapatan.Name = "txtPendapatan"
        txtPendapatan.Size = New Size(125, 27)
        txtPendapatan.TabIndex = 7
        ' 
        ' FrmPajak
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Info
        ClientSize = New Size(800, 450)
        Controls.Add(txtPendapatan)
        Controls.Add(btnKeluar)
        Controls.Add(btnHitung)
        Controls.Add(lblRupiah)
        Controls.Add(lblPendapatan)
        Controls.Add(lblSeratusJuta)
        Controls.Add(lblTigaPuluhJuta)
        Controls.Add(lblLimaJuta)
        ForeColor = Color.Maroon
        Name = "FrmPajak"
        Text = "FrmPajak"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblLimaJuta As Label
    Friend WithEvents lblTigaPuluhJuta As Label
    Friend WithEvents lblSeratusJuta As Label
    Friend WithEvents lblPendapatan As Label
    Friend WithEvents lblRupiah As Label
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents txtPendapatan As TextBox
End Class
