<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPeminjaman
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
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblNamaPeminjam = New Label()
        txtNamaPeminjam = New TextBox()
        lblLamaPinjam = New Label()
        txtLamaPinjam = New TextBox()
        btnPinjam = New Button()
        btnBersihkan = New Button()
        lstPeminjaman = New ListBox()
        btnEkspor = New Button()
        lblStatus = New Label()
        errPinjam = New ErrorProvider(components)
        CType(errPinjam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Baskerville Old Face", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(290, 25)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(237, 32)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Buku"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKodeBuku.Location = New Point(90, 91)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(83, 20)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(214, 88)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(125, 27)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblJudul.Location = New Point(462, 91)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(85, 20)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul Buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(586, 84)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(125, 27)
        txtJudul.TabIndex = 4
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblKategori.Location = New Point(104, 168)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(67, 20)
        lblKategori.TabIndex = 5
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(214, 165)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(151, 28)
        cboKategori.TabIndex = 6
        ' 
        ' lblNamaPeminjam
        ' 
        lblNamaPeminjam.AutoSize = True
        lblNamaPeminjam.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblNamaPeminjam.Location = New Point(423, 168)
        lblNamaPeminjam.Name = "lblNamaPeminjam"
        lblNamaPeminjam.Size = New Size(121, 20)
        lblNamaPeminjam.TabIndex = 7
        lblNamaPeminjam.Text = "Nama Peminjam"
        ' 
        ' txtNamaPeminjam
        ' 
        txtNamaPeminjam.Location = New Point(586, 165)
        txtNamaPeminjam.Name = "txtNamaPeminjam"
        txtNamaPeminjam.Size = New Size(125, 27)
        txtNamaPeminjam.TabIndex = 8
        ' 
        ' lblLamaPinjam
        ' 
        lblLamaPinjam.AutoSize = True
        lblLamaPinjam.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblLamaPinjam.Location = New Point(37, 261)
        lblLamaPinjam.Name = "lblLamaPinjam"
        lblLamaPinjam.Size = New Size(137, 20)
        lblLamaPinjam.TabIndex = 9
        lblLamaPinjam.Text = "Lama Pinjam (hari)"
        ' 
        ' txtLamaPinjam
        ' 
        txtLamaPinjam.Location = New Point(214, 258)
        txtLamaPinjam.Name = "txtLamaPinjam"
        txtLamaPinjam.Size = New Size(125, 27)
        txtLamaPinjam.TabIndex = 10
        ' 
        ' btnPinjam
        ' 
        btnPinjam.BackColor = Color.LawnGreen
        btnPinjam.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnPinjam.Location = New Point(447, 289)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(94, 29)
        btnPinjam.TabIndex = 11
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.BackColor = Color.IndianRed
        btnBersihkan.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnBersihkan.Location = New Point(586, 289)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(94, 29)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = False
        ' 
        ' lstPeminjaman
        ' 
        lstPeminjaman.FormattingEnabled = True
        lstPeminjaman.Location = New Point(55, 405)
        lstPeminjaman.Name = "lstPeminjaman"
        lstPeminjaman.Size = New Size(675, 104)
        lstPeminjaman.TabIndex = 13
        ' 
        ' btnEkspor
        ' 
        btnEkspor.BackColor = Color.Orange
        btnEkspor.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnEkspor.Location = New Point(467, 621)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(94, 29)
        btnEkspor.TabIndex = 14
        btnEkspor.Text = "Ekspor CSV"
        btnEkspor.UseVisualStyleBackColor = False
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblStatus.Location = New Point(145, 654)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(163, 20)
        lblStatus.TabIndex = 15
        lblStatus.Text = "Jumlah peminjaman: 0"
        ' 
        ' errPinjam
        ' 
        errPinjam.ContainerControl = Me
        ' 
        ' FormPeminjaman
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(832, 745)
        Controls.Add(lblStatus)
        Controls.Add(btnEkspor)
        Controls.Add(lstPeminjaman)
        Controls.Add(btnBersihkan)
        Controls.Add(btnPinjam)
        Controls.Add(txtLamaPinjam)
        Controls.Add(lblLamaPinjam)
        Controls.Add(txtNamaPeminjam)
        Controls.Add(lblNamaPeminjam)
        Controls.Add(cboKategori)
        Controls.Add(lblKategori)
        Controls.Add(txtJudul)
        Controls.Add(lblJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        Name = "FormPeminjaman"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form Peminjaman Buku"
        CType(errPinjam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblNamaPeminjam As Label
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errPinjam As ErrorProvider

End Class
