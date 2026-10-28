
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.IO

Public Class FormPeminjaman

    ' Menyimpan kode buku yang sedang dipinjam.
    Private ReadOnly daftarKodeDipinjam As New List(Of String)()

    ' Menyimpan data lengkap untuk kebutuhan ekspor CSV.
    Private ReadOnly daftarDataPeminjaman As New List(Of String())()

    ' Mengatur kondisi awal form.
    Private Sub FormPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cboKategori.Items.Count = 0 Then
            cboKategori.Items.Add("Fiksi")
            cboKategori.Items.Add("Nonfiksi")
            cboKategori.Items.Add("Referensi")
            cboKategori.Items.Add("Majalah")
        End If

        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.SelectedIndex = -1
        lblStatus.Text = "Jumlah peminjaman: 0"
        errPinjam.Clear()
    End Sub

    ' Memeriksa seluruh input dan menandai kesalahan dengan ErrorProvider.
    Private Function ValidasiInput() As Boolean
        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        Dim nama As String = txtNamaPeminjam.Text.Trim()
        Dim lamaPinjam As Integer

        errPinjam.Clear()

        If Not KodeBukuValid(kode) Then
            errPinjam.SetError(txtKodeBuku,
                "Kode harus BK diikuti 4 digit angka.")
            valid = False
        ElseIf daftarKodeDipinjam.Contains(kode) Then
            errPinjam.SetError(txtKodeBuku,
                "Buku ini sedang dipinjam.")
            valid = False
        End If

        If String.IsNullOrWhiteSpace(txtJudul.Text) Then
            errPinjam.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If

        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Kategori wajib dipilih.")
            valid = False
        End If

        If nama.Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam,
                "Nama minimal 3 karakter.")
            valid = False
        End If

        If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam) _
            OrElse lamaPinjam < 1 OrElse lamaPinjam > 14 Then

            errPinjam.SetError(txtLamaPinjam,
                "Lama pinjam harus bilangan bulat 1 sampai 14.")
            valid = False
        End If

        Return valid
    End Function

    ' Mencatat data peminjaman jika semua input valid.
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then
            Return
        End If

        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        Dim judul As String = txtJudul.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim nama As String = txtNamaPeminjam.Text.Trim()
        Dim lamaPinjam As Integer

        If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam) Then
            Return
        End If

        Dim tanggalKembali As String =
            Date.Today.AddDays(lamaPinjam).ToString("dd/MM/yyyy")

        Dim data As String() = {
            kode,
            judul,
            kategori,
            nama,
            lamaPinjam.ToString(),
            tanggalKembali
        }

        daftarKodeDipinjam.Add(kode)
        daftarDataPeminjaman.Add(data)

        Dim baris As String =
            kode & " | " & judul & " | " & kategori &
            " | " & nama & " | " & lamaPinjam.ToString() &
            " hari | kembali " & tanggalKembali

        lstPeminjaman.Items.Add(baris)

        lblStatus.Text =
            "Jumlah peminjaman: " & daftarDataPeminjaman.Count.ToString()

        BersihkanForm()
    End Sub

    ' Mengosongkan isian dan menghapus semua tanda kesalahan.
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
    End Sub

    ' Menangani tombol Bersihkan.
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
    End Sub

    ' Memvalidasi format kode buku ketika fokus berpindah.
    Private Sub txtKodeBuku_Validating(
        sender As Object,
        e As System.ComponentModel.CancelEventArgs
    ) Handles txtKodeBuku.Validating

        Dim kode As String = txtKodeBuku.Text.Trim()

        If kode = "" Then
            errPinjam.SetError(txtKodeBuku, "")
        ElseIf Not KodeBukuValid(kode) Then
            errPinjam.SetError(txtKodeBuku,
                "Kode harus BK diikuti 4 digit angka.")
        Else
            errPinjam.SetError(txtKodeBuku, "")
        End If
    End Sub

    ' Menyiapkan nilai agar aman ditulis ke kolom CSV.
    Private Function FormatKolomCsv(nilai As String) As String
        If nilai.Contains(";") OrElse nilai.Contains("""") _
            OrElse nilai.Contains(vbCr) OrElse nilai.Contains(vbLf) Then

            Return """" & nilai.Replace("""", """""") & """"
        End If

        Return nilai
    End Function

    ' Mengekspor data peminjaman ke file CSV di folder Documents.
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show(
                "Belum ada data peminjaman yang dapat diekspor.",
                "Ekspor CSV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim lokasiFile As String = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "peminjaman.csv")

        Dim penulis As StreamWriter = Nothing

        Try
            penulis = New StreamWriter(lokasiFile, False)

            penulis.WriteLine(
                "Kode Buku;Judul Buku;Kategori;Nama Peminjam;Lama Pinjam (hari);Tanggal Kembali")

            For Each data As String() In daftarDataPeminjaman
                Dim kolom As New List(Of String)()

                For Each nilai As String In data
                    kolom.Add(FormatKolomCsv(nilai))
                Next

                penulis.WriteLine(String.Join(";", kolom))
            Next

            penulis.Flush()

            MessageBox.Show(
                "Data berhasil diekspor ke:" & Environment.NewLine & lokasiFile,
                "Ekspor Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As IOException
            MessageBox.Show(
                "File tidak dapat ditulis. Tutup peminjaman.csv jika " &
                "sedang dibuka di Excel, lalu coba kembali.",
                "Gagal Mengekspor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As UnauthorizedAccessException
            MessageBox.Show(
                "Akses ditolak. Periksa izin folder Documents " &
                "atau gunakan folder yang dapat ditulisi.",
                "Akses Ditolak",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Finally
            If penulis IsNot Nothing Then
                penulis.Close()
            End If
        End Try
    End Sub

End Class
