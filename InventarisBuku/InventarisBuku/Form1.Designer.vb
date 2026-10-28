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
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        lblJudul = New Label()
        lblPenulis = New Label()
        lblKategori = New Label()
        lblTahun = New Label()
        lblStok = New Label()
        lblPencarian = New Label()
        lblFilterKategori = New Label()
        lblJumlah = New Label()
        lblTotalStok = New Label()
        txtJudul = New TextBox()
        txtKodeBuku = New TextBox()
        txtPenulis = New TextBox()
        txtStok = New TextBox()
        txtTahun = New TextBox()
        txtCari = New TextBox()
        cboFilterKategori = New ComboBox()
        cboKategori = New ComboBox()
        btnTambah = New Button()
        btnBersihkan = New Button()
        dgvBuku = New DataGridView()
        errBuku = New ErrorProvider(components)
        bsBuku = New BindingSource(components)
        chkStokHabis = New CheckBox()
        cboUrut = New ComboBox()
        lblUrutkan = New Label()
        CType(dgvBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(errBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.BackColor = Color.Transparent
        lblJudulForm.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        lblJudulForm.Location = New Point(337, 21)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(332, 31)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Inventaris Buku Perpustakaan"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Location = New Point(75, 81)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(80, 20)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(515, 81)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(79, 20)
        lblJudul.TabIndex = 2
        lblJudul.Text = "Judul Buku"
        ' 
        ' lblPenulis
        ' 
        lblPenulis.AutoSize = True
        lblPenulis.Location = New Point(101, 140)
        lblPenulis.Name = "lblPenulis"
        lblPenulis.Size = New Size(54, 20)
        lblPenulis.TabIndex = 3
        lblPenulis.Text = "Penulis"
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(528, 140)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(66, 20)
        lblKategori.TabIndex = 4
        lblKategori.Text = "Kategori"
        ' 
        ' lblTahun
        ' 
        lblTahun.AutoSize = True
        lblTahun.Location = New Point(66, 211)
        lblTahun.Name = "lblTahun"
        lblTahun.Size = New Size(89, 20)
        lblTahun.TabIndex = 5
        lblTahun.Text = "Tahun Terbit"
        ' 
        ' lblStok
        ' 
        lblStok.AutoSize = True
        lblStok.Location = New Point(556, 211)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(38, 20)
        lblStok.TabIndex = 6
        lblStok.Text = "Stok"
        ' 
        ' lblPencarian
        ' 
        lblPencarian.AutoSize = True
        lblPencarian.Location = New Point(53, 324)
        lblPencarian.Name = "lblPencarian"
        lblPencarian.Size = New Size(132, 20)
        lblPencarian.TabIndex = 7
        lblPencarian.Text = "Cari Judul / Penulis"
        ' 
        ' lblFilterKategori
        ' 
        lblFilterKategori.AutoSize = True
        lblFilterKategori.Location = New Point(556, 407)
        lblFilterKategori.Name = "lblFilterKategori"
        lblFilterKategori.Size = New Size(103, 20)
        lblFilterKategori.TabIndex = 8
        lblFilterKategori.Text = "Filter Kategori"
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(120, 737)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(189, 20)
        lblJumlah.TabIndex = 9
        lblJumlah.Text = "Menampilkan 0 dari 0 buku"
        ' 
        ' lblTotalStok
        ' 
        lblTotalStok.AutoSize = True
        lblTotalStok.Location = New Point(672, 737)
        lblTotalStok.Name = "lblTotalStok"
        lblTotalStok.Size = New Size(88, 20)
        lblTotalStok.TabIndex = 10
        lblTotalStok.Text = "Total stok: 0"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(676, 78)
        txtJudul.MaxLength = 100
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(125, 27)
        txtJudul.TabIndex = 11
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(239, 77)
        txtKodeBuku.MaxLength = 6
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(125, 27)
        txtKodeBuku.TabIndex = 12
        ' 
        ' txtPenulis
        ' 
        txtPenulis.Location = New Point(239, 142)
        txtPenulis.MaxLength = 100
        txtPenulis.Name = "txtPenulis"
        txtPenulis.Size = New Size(125, 27)
        txtPenulis.TabIndex = 14
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(676, 208)
        txtStok.MaxLength = 9
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(125, 27)
        txtStok.TabIndex = 15
        ' 
        ' txtTahun
        ' 
        txtTahun.Location = New Point(239, 209)
        txtTahun.MaxLength = 4
        txtTahun.Name = "txtTahun"
        txtTahun.Size = New Size(125, 27)
        txtTahun.TabIndex = 16
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(230, 321)
        txtCari.MaxLength = 100
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(278, 27)
        txtCari.TabIndex = 17
        ' 
        ' cboFilterKategori
        ' 
        cboFilterKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterKategori.FormattingEnabled = True
        cboFilterKategori.Items.AddRange(New Object() {"Semua, ", "Fiksi, ", "Nonfiksi, ", "Referensi, ", "Majalah"})
        cboFilterKategori.Location = New Point(694, 403)
        cboFilterKategori.Name = "cboFilterKategori"
        cboFilterKategori.Size = New Size(151, 28)
        cboFilterKategori.TabIndex = 18
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi, ", "Nonfiksi, ", "Referensi, ", "Majalah"})
        cboKategori.Location = New Point(676, 137)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(125, 28)
        cboKategori.TabIndex = 19
        ' 
        ' btnTambah
        ' 
        btnTambah.BackColor = Color.LightGoldenrodYellow
        btnTambah.Location = New Point(63, 403)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(94, 29)
        btnTambah.TabIndex = 20
        btnTambah.Text = "Tambah Buku"
        btnTambah.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.BackColor = Color.LightCyan
        btnBersihkan.Location = New Point(215, 403)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(94, 29)
        btnBersihkan.TabIndex = 21
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = False
        ' 
        ' dgvBuku
        ' 
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.AllowUserToDeleteRows = False
        dgvBuku.AllowUserToResizeColumns = False
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBuku.Location = New Point(75, 520)
        dgvBuku.MultiSelect = False
        dgvBuku.Name = "dgvBuku"
        dgvBuku.ReadOnly = True
        dgvBuku.RowHeadersVisible = False
        dgvBuku.RowHeadersWidth = 51
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.Size = New Size(797, 188)
        dgvBuku.TabIndex = 22
        ' 
        ' errBuku
        ' 
        errBuku.BlinkStyle = ErrorBlinkStyle.NeverBlink
        errBuku.ContainerControl = Me
        ' 
        ' chkStokHabis
        ' 
        chkStokHabis.AutoSize = True
        chkStokHabis.Location = New Point(390, 408)
        chkStokHabis.Name = "chkStokHabis"
        chkStokHabis.Size = New Size(143, 24)
        chkStokHabis.TabIndex = 23
        chkStokHabis.Text = "Hanya stok habis"
        chkStokHabis.UseVisualStyleBackColor = True
        ' 
        ' cboUrut
        ' 
        cboUrut.DropDownStyle = ComboBoxStyle.DropDownList
        cboUrut.FormattingEnabled = True
        cboUrut.Items.AddRange(New Object() {"Urutan awal, ", "Judul A-Z, ", "Tahun terbaru, ", "Stok terbanyak"})
        cboUrut.Location = New Point(694, 324)
        cboUrut.Name = "cboUrut"
        cboUrut.Size = New Size(151, 28)
        cboUrut.TabIndex = 24
        ' 
        ' lblUrutkan
        ' 
        lblUrutkan.AutoSize = True
        lblUrutkan.Location = New Point(594, 327)
        lblUrutkan.Name = "lblUrutkan"
        lblUrutkan.Size = New Size(96, 20)
        lblUrutkan.TabIndex = 25
        lblUrutkan.Text = "Urutkan Buku"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1082, 814)
        Controls.Add(lblUrutkan)
        Controls.Add(cboUrut)
        Controls.Add(chkStokHabis)
        Controls.Add(dgvBuku)
        Controls.Add(btnBersihkan)
        Controls.Add(btnTambah)
        Controls.Add(cboKategori)
        Controls.Add(cboFilterKategori)
        Controls.Add(txtCari)
        Controls.Add(txtTahun)
        Controls.Add(txtStok)
        Controls.Add(txtPenulis)
        Controls.Add(txtKodeBuku)
        Controls.Add(txtJudul)
        Controls.Add(lblTotalStok)
        Controls.Add(lblJumlah)
        Controls.Add(lblFilterKategori)
        Controls.Add(lblPencarian)
        Controls.Add(lblStok)
        Controls.Add(lblTahun)
        Controls.Add(lblKategori)
        Controls.Add(lblPenulis)
        Controls.Add(lblJudul)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        MinimumSize = New Size(900, 600)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventaris Buku Perpustakaan"
        CType(dgvBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(errBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents lblJudul As Label
    Friend WithEvents lblPenulis As Label
    Friend WithEvents lblKategori As Label
    Friend WithEvents lblTahun As Label
    Friend WithEvents lblStok As Label
    Friend WithEvents lblPencarian As Label
    Friend WithEvents lblFilterKategori As Label
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents txtStok As TextBox
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents errBuku As ErrorProvider
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents lblUrutkan As Label

End Class
