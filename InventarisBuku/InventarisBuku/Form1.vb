
Option Strict On

Imports System.Data
Imports System.Linq

Public Class Form1

    Private tabelBuku As DataTable

    ' Menyiapkan tabel, data awal, kategori, dan tampilan grid.
    Private Sub Form1_Load(sender As Object,
                           e As EventArgs) Handles MyBase.Load

        tabelBuku = New DataTable("Buku")

        tabelBuku.Columns.Add("KodeBuku", GetType(String))
        tabelBuku.Columns.Add("Judul", GetType(String))
        tabelBuku.Columns.Add("Penulis", GetType(String))
        tabelBuku.Columns.Add("Kategori", GetType(String))
        tabelBuku.Columns.Add("Tahun", GetType(Integer))
        tabelBuku.Columns.Add("Stok", GetType(Integer))

        ' Mengisi pilihan kategori buku.
        cboKategori.Items.Clear()
        cboKategori.Items.AddRange(
            New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})

        ' Mengisi pilihan filter kategori.
        cboFilterKategori.Items.Clear()
        cboFilterKategori.Items.AddRange(
            New Object() {"Semua", "Fiksi", "Nonfiksi",
                          "Referensi", "Majalah"})

        ' Mengisi pilihan pengurutan buku.
        cboUrut.Items.Clear()
        cboUrut.Items.AddRange(
            New Object() {"Urutan awal", "Judul A-Z",
                          "Tahun terbaru", "Stok terbanyak"})

        cboKategori.SelectedIndex = -1
        cboFilterKategori.SelectedIndex = 0
        cboUrut.SelectedIndex = 0
        chkStokHabis.Checked = False

        ' Memasukkan sepuluh data buku awal.
        tabelBuku.Rows.Add("BK0001", "Laskar Pelangi",
            "Andrea Hirata", "Fiksi", 2005, 5)
        tabelBuku.Rows.Add("BK0002", "Bumi",
            "Tere Liye", "Fiksi", 2014, 3)
        tabelBuku.Rows.Add("BK0003", "Laut Bercerita",
            "Leila S. Chudori", "Fiksi", 2017, 0)
        tabelBuku.Rows.Add("BK0004", "Bicara Itu Ada Seninya",
            "Oh Su Hyang", "Nonfiksi", 2018, 4)
        tabelBuku.Rows.Add("BK0005", "Atomic Habits",
            "James Clear", "Nonfiksi", 2018, 6)
        tabelBuku.Rows.Add("BK0006", "Filosofi Teras",
            "Henry Manampiring", "Nonfiksi", 2018, 2)
        tabelBuku.Rows.Add("BK0007", "Kamus Bahasa Indonesia",
            "Badan Bahasa", "Referensi", 2020, 2)
        tabelBuku.Rows.Add("BK0008", "Ensiklopedia Sains",
            "Tim Penulis", "Referensi", 2021, 0)
        tabelBuku.Rows.Add("BK0009", "Majalah Teknologi",
            "Tim Redaksi", "Majalah", 2024, 8)
        tabelBuku.Rows.Add("BK0010", "Majalah Pendidikan",
            "Tim Redaksi", "Majalah", 2025, 3)

        ' Menghubungkan DataTable melalui BindingSource.
        dgvBuku.AutoGenerateColumns = True
        bsBuku.DataSource = tabelBuku
        dgvBuku.DataSource = bsBuku

        ' Mengatur tampilan kolom tabel.
        dgvBuku.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("Judul").FillWeight = 180

        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        ' Menampilkan data dengan filter dan urutan awal.
        TerapkanUrutan()
        TerapkanFilter()

    End Sub

    ' Memvalidasi seluruh data sebelum buku ditambahkan.
    Private Function ValidasiInput() As Boolean

        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim()
        Dim tahun As Integer
        Dim stok As Integer
        Dim kodeSudahAda As Boolean = False

        errBuku.Clear()

        ' Memeriksa format kode BK diikuti empat angka.
        If kode.Length <> 6 OrElse
           Not kode.StartsWith("BK", StringComparison.Ordinal) OrElse
           Not kode.Substring(2).All(
               Function(c As Char) c >= "0"c AndAlso c <= "9"c) Then

            errBuku.SetError(txtKodeBuku,
                "Kode harus BK diikuti 4 digit.")
            valid = False

        Else
            ' Memeriksa kode yang sudah digunakan.
            For Each baris As DataRow In tabelBuku.Rows
                If baris("KodeBuku").ToString() = kode Then
                    kodeSudahAda = True
                    Exit For
                End If
            Next

            If kodeSudahAda Then
                errBuku.SetError(txtKodeBuku,
                    "Kode buku sudah digunakan.")
                valid = False
            End If
        End If

        ' Memeriksa judul buku.
        If txtJudul.Text.Trim() = "" Then
            errBuku.SetError(txtJudul, "Judul wajib diisi.")
            valid = False
        End If

        ' Memeriksa penulis buku.
        If txtPenulis.Text.Trim() = "" Then
            errBuku.SetError(txtPenulis, "Penulis wajib diisi.")
            valid = False
        End If

        ' Memeriksa kategori buku.
        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Pilih kategori buku.")
            valid = False
        End If

        ' Memeriksa tahun terbit.
        If Not Integer.TryParse(txtTahun.Text.Trim(), tahun) OrElse
           tahun < 1900 OrElse tahun > Date.Today.Year Then

            errBuku.SetError(txtTahun,
                "Tahun harus antara 1900 dan tahun ini.")
            valid = False
        End If

        ' Memeriksa jumlah stok.
        If Not Integer.TryParse(txtStok.Text.Trim(), stok) OrElse
           stok < 0 Then

            errBuku.SetError(txtStok,
                "Stok harus bilangan bulat 0 atau lebih.")
            valid = False
        End If

        Return valid

    End Function

    ' Menambahkan buku baru setelah validasi berhasil.
    Private Sub btnTambah_Click(sender As Object,
                                e As EventArgs) Handles btnTambah.Click

        If Not ValidasiInput() Then
            MessageBox.Show(
                "Periksa kembali isian yang ditandai.",
                "Validasi Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        tabelBuku.Rows.Add(
            txtKodeBuku.Text.Trim(),
            txtJudul.Text.Trim(),
            txtPenulis.Text.Trim(),
            cboKategori.SelectedItem.ToString(),
            Integer.Parse(txtTahun.Text.Trim()),
            Integer.Parse(txtStok.Text.Trim()))

        BersihkanIsian()
        TerapkanUrutan()
        TerapkanFilter()

        MessageBox.Show(
            "Buku berhasil ditambahkan.",
            "Informasi",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    ' Mengosongkan seluruh input dan pesan validasi.
    Private Sub BersihkanIsian()

        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        txtTahun.Clear()
        txtStok.Clear()

        cboKategori.SelectedIndex = -1
        errBuku.Clear()
        txtKodeBuku.Focus()

    End Sub

    ' Menjalankan fungsi bersihkan melalui tombol.
    Private Sub btnBersihkan_Click(sender As Object,
                                   e As EventArgs) Handles btnBersihkan.Click

        BersihkanIsian()

    End Sub

    ' Mengamankan karakter khusus dalam teks pencarian.
    Private Function AmankanFilter(teks As String) As String

        Dim hasil As String = teks

        hasil = hasil.Replace("'", "''")
        hasil = hasil.Replace("[", "[[]")
        hasil = hasil.Replace("%", "[%]")
        hasil = hasil.Replace("*", "[*]")

        Return hasil

    End Function

    ' Mengurutkan buku sesuai pilihan pengguna.
    Private Sub TerapkanUrutan()

        If bsBuku.DataSource Is Nothing Then
            Return
        End If

        Select Case cboUrut.Text

            Case "Judul A-Z"
                bsBuku.Sort = "Judul ASC"

            Case "Tahun terbaru"
                bsBuku.Sort = "Tahun DESC"

            Case "Stok terbanyak"
                bsBuku.Sort = "Stok DESC"

            Case Else
                ' Mengembalikan urutan sesuai DataTable.
                bsBuku.RemoveSort()

        End Select

    End Sub

    ' Menggabungkan filter teks, kategori, dan stok habis.
    Private Sub TerapkanFilter()

        If tabelBuku Is Nothing OrElse
           bsBuku.DataSource Is Nothing Then
            Return
        End If

        Dim syarat As New List(Of String)
        Dim kata As String = txtCari.Text.Trim()

        ' Mencari berdasarkan judul atau penulis.
        If kata <> "" Then

            Dim aman As String = AmankanFilter(kata)

            syarat.Add(
                "(Judul LIKE '%" & aman &
                "%' OR Penulis LIKE '%" & aman & "%')")

        End If

        ' Memfilter berdasarkan kategori.
        If cboFilterKategori.SelectedIndex > 0 Then

            Dim kategori As String =
                cboFilterKategori.SelectedItem.ToString()

            syarat.Add(
                "Kategori = '" &
                kategori.Replace("'", "''") & "'")

        End If

        ' Menampilkan buku yang stoknya nol saja.
        If chkStokHabis.Checked Then
            syarat.Add("Stok = 0")
        End If

        ' Menggabungkan semua syarat menggunakan AND.
        If syarat.Count > 0 Then
            bsBuku.Filter = String.Join(" AND ", syarat)
        Else
            bsBuku.RemoveFilter()
        End If

        PerbaruiRingkasan()

    End Sub

    ' Menghitung jumlah buku dan total stok pada grid.
    Private Sub PerbaruiRingkasan()

        Dim jumlah As Integer = 0
        Dim totalStok As Integer = 0

        For Each baris As DataGridViewRow In dgvBuku.Rows

            If Not baris.IsNewRow Then
                jumlah += 1
                totalStok += CInt(baris.Cells("Stok").Value)
            End If

        Next

        lblJumlah.Text =
            "Menampilkan " & jumlah.ToString() &
            " dari " & tabelBuku.Rows.Count.ToString() & " buku"

        lblTotalStok.Text =
            "Total stok: " & totalStok.ToString()

    End Sub

    ' Memperbarui filter ketika teks pencarian berubah.
    Private Sub txtCari_TextChanged(sender As Object,
                                    e As EventArgs) Handles txtCari.TextChanged

        If tabelBuku IsNot Nothing Then
            TerapkanFilter()
        End If

    End Sub

    ' Memperbarui filter ketika kategori berubah.
    Private Sub cboFilterKategori_SelectedIndexChanged(
        sender As Object, e As EventArgs) _
        Handles cboFilterKategori.SelectedIndexChanged

        If tabelBuku IsNot Nothing Then
            TerapkanFilter()
        End If

    End Sub

    ' Mengubah pengurutan ketika pilihan berubah.
    Private Sub cboUrut_SelectedIndexChanged(
        sender As Object, e As EventArgs) _
        Handles cboUrut.SelectedIndexChanged

        If tabelBuku IsNot Nothing AndAlso
           bsBuku.DataSource IsNot Nothing Then

            TerapkanUrutan()
            PerbaruiRingkasan()

        End If

    End Sub

    ' Memperbarui filter ketika checkbox stok habis berubah.
    Private Sub chkStokHabis_CheckedChanged(
        sender As Object, e As EventArgs) _
        Handles chkStokHabis.CheckedChanged

        If tabelBuku IsNot Nothing Then
            TerapkanFilter()
        End If

    End Sub

End Class
