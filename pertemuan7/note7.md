# Pertemuan 7 -- Form Peminjaman Buku

## Tujuan

Pada praktikum pertemuan 7 ini, kami membuat aplikasi Windows Forms
menggunakan VB.NET untuk mencatat peminjaman buku. Aplikasi ini dibuat
agar data peminjaman dapat dimasukkan melalui form, diperiksa terlebih
dahulu, ditampilkan dalam daftar, dan diekspor ke file CSV.

Pada tugas ini kami belajar menggunakan validasi input, `ErrorProvider`,
`List(Of String)`, perhitungan tanggal kembali, serta penanganan error
saat ekspor file.

------------------------------------------------------------------------

## Pembahasan

Pada pertemuan ini, aplikasi digunakan untuk mencatat peminjaman buku
perpustakaan. Setiap peminjaman harus memenuhi aturan yang sudah
ditentukan sebelum data ditambahkan ke daftar.

Beberapa bagian yang dipelajari yaitu:

-   Membuat form peminjaman buku menggunakan Windows Forms
-   Mengatur nama kontrol melalui Designer
-   Validasi input menggunakan `Function`
-   Penggunaan `ErrorProvider`
-   Pemeriksaan format kode buku
-   Penggunaan `Integer.TryParse`
-   Penggunaan `List(Of String)`
-   Mencegah buku yang sama dipinjam dua kali
-   Menghitung tanggal kembali menggunakan `Date.Today.AddDays()`
-   Mengosongkan input setelah data dicatat
-   Mengekspor data ke file CSV
-   Penanganan error menggunakan `Try...Catch...Finally`

------------------------------------------------------------------------

## 1. Rancangan Form

Form dibuat menggunakan Windows Forms Designer. Semua kontrol dibuat
melalui Designer dan nama kontrol disesuaikan dengan ketentuan tugas.

Kontrol yang digunakan antara lain:

  Kontrol         Name                Kegunaan
  --------------- ------------------- -------------------------------
  Label           `lblJudulForm`      Menampilkan judul form
  TextBox         `txtKodeBuku`       Memasukkan kode buku
  TextBox         `txtJudul`          Memasukkan judul buku
  ComboBox        `cboKategori`       Memilih kategori buku
  TextBox         `txtNamaPeminjam`   Memasukkan nama peminjam
  TextBox         `txtLamaPinjam`     Memasukkan lama pinjam
  Button          `btnPinjam`         Mencatat peminjaman
  Button          `btnBersihkan`      Mengosongkan isian
  ListBox         `lstPeminjaman`     Menampilkan daftar peminjaman
  Button          `btnEkspor`         Mengekspor data ke CSV
  Label           `lblStatus`         Menampilkan jumlah peminjaman
  ErrorProvider   `errPinjam`         Menandai input yang salah

Setiap TextBox dan ComboBox juga mempunyai Label keterangan dengan
awalan `lbl`.

------------------------------------------------------------------------

## 2. ComboBox Kategori

ComboBox `cboKategori` digunakan untuk memilih kategori buku. Pilihannya
adalah:

-   Fiksi
-   Nonfiksi
-   Referensi
-   Majalah

Properti `DropDownStyle` diatur menjadi `DropDownList`. Dengan begitu,
pengguna memilih kategori dari pilihan yang tersedia dan tidak mengetik
kategori secara bebas.

------------------------------------------------------------------------

## 3. Validasi Input

Validasi digunakan untuk memeriksa apakah semua isian sudah sesuai
sebelum data dicatat. Pemeriksaan dikumpulkan dalam satu function, yaitu
`ValidasiInput() As Boolean`.

Function tersebut mengembalikan `True` jika semua isian valid dan
`False` jika masih ada kesalahan. Semua isian diperiksa sehingga
beberapa kesalahan dapat ditampilkan sekaligus melalui `ErrorProvider`,
tanpa menggunakan `MessageBox` untuk kesalahan validasi.

Aturan validasi yang digunakan yaitu:

-   Kode buku harus berformat `BK` diikuti empat digit angka, misalnya
    `BK0012`.
-   Kode dengan huruf kecil, misalnya `bk0012`, tetap diterima dan
    disimpan dalam huruf besar.
-   Judul buku wajib diisi.
-   Kategori buku wajib dipilih.
-   Nama peminjam minimal tiga karakter setelah spasi di awal dan akhir
    diabaikan.
-   Lama pinjam harus berupa bilangan bulat dari 1 sampai 14 hari.

------------------------------------------------------------------------

## 4. Function KodeBukuValid()

Pemeriksaan format kode buku dipisahkan ke dalam Module bernama
`ModulValidasi`. Function yang digunakan adalah
`KodeBukuValid(kode As String) As Boolean`.

``` vb
Public Function KodeBukuValid(kode As String) As Boolean
    kode = kode.Trim().ToUpperInvariant()

    If kode.Length <> 6 Then
        Return False
    End If

    If Not kode.StartsWith("BK") Then
        Return False
    End If

    For i As Integer = 2 To 5
        If Not Char.IsDigit(kode(i)) Then
            Return False
        End If
    Next

    Return True
End Function
```

Function ini memeriksa panjang kode, awalan `BK`, dan empat karakter
angka setelahnya. `Trim()` menghapus spasi di awal dan akhir, sedangkan
`ToUpperInvariant()` membuat pemeriksaan kode tidak membedakan huruf
besar dan kecil.

Contohnya, `bk0105` akan diterima dan kemudian disimpan sebagai
`BK0105`, sedangkan kode yang tidak mengikuti format akan ditolak.

Function ini dipakai dalam `ValidasiInput()` dan event `Validating` pada
`txtKodeBuku`.

------------------------------------------------------------------------

## 5. ErrorProvider dan Event Validating

`ErrorProvider` digunakan untuk memberikan tanda kesalahan di dekat
kontrol yang isinya belum benar. Contohnya, jika kode buku salah, ikon
kesalahan akan muncul pada `txtKodeBuku`.

Sebelum melakukan validasi, program menjalankan:

``` vb
errPinjam.Clear()
```

Perintah tersebut menghapus tanda kesalahan yang lama agar hasil
validasi terbaru dapat ditampilkan.

Selain validasi saat tombol Pinjam ditekan, `txtKodeBuku` juga
menggunakan event `Validating`. Event ini memeriksa format kode ketika
fokus berpindah dari TextBox. Pada tugas ini, event tersebut tidak
menggunakan `e.Cancel = True`, sehingga fokus tidak dipaksa tetap berada
di kontrol itu.

------------------------------------------------------------------------

## 6. Integer.TryParse

`Integer.TryParse` digunakan untuk memeriksa apakah nilai lama pinjam
bisa dibaca sebagai bilangan bulat.

``` vb
Dim lamaPinjam As Integer

If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam) _
    OrElse lamaPinjam < 1 OrElse lamaPinjam > 14 Then

    errPinjam.SetError(txtLamaPinjam,
        "Lama pinjam harus bilangan bulat 1 sampai 14.")
End If
```

Dengan `TryParse`, program dapat mengetahui apakah input berupa angka
bulat tanpa langsung mengubah teks menggunakan `CInt` atau `Val`.
Setelah berhasil dibaca, nilainya tetap harus berada di antara 1 dan 14.

------------------------------------------------------------------------

## 7. List(Of String) untuk Kode Buku

Program menggunakan `List(Of String)` bernama `daftarKodeDipinjam` untuk
menyimpan kode buku yang sedang dipinjam.

Sebelum peminjaman dicatat, kode diperiksa menggunakan:

``` vb
daftarKodeDipinjam.Contains(kode)
```

Jika kode tersebut sudah ada, program menampilkan kesalahan melalui
`ErrorProvider` dengan pesan:

``` text
Buku ini sedang dipinjam.
```

Dengan pemeriksaan ini, kode buku yang sama tidak bisa dicatat sebagai
peminjaman baru selama masih tercatat di daftar peminjaman aplikasi.

Selain itu, program menggunakan `List(Of String())` bernama
`daftarDataPeminjaman` untuk menyimpan data lengkap setiap peminjaman
yang diperlukan saat ekspor CSV.

------------------------------------------------------------------------

## 8. Tombol Pinjam

Tombol `btnPinjam` menjalankan function `ValidasiInput()` terlebih
dahulu. Jika masih ada input yang salah, proses pencatatan dihentikan.

Jika semua input valid, program mengambil nilai dari TextBox dan
ComboBox, mengubah kode buku menjadi huruf besar, lalu menghitung
tanggal kembali.

``` vb
Dim tanggalKembali As String =
    Date.Today.AddDays(lamaPinjam).ToString("dd/MM/yyyy")
```

`Date.Today` mengambil tanggal hari ini, kemudian `AddDays(lamaPinjam)`
menambahkan jumlah hari sesuai lama pinjam. Hasil tanggal ditampilkan
dengan format hari/bulan/tahun.

Data yang berhasil dicatat ditampilkan pada `lstPeminjaman` dengan
format seperti berikut:

``` text
BK0012 | Laskar Pelangi | Fiksi | Rina Lubis | 7 hari | kembali 04/11/2026
```

Tanggal pada contoh bergantung pada tanggal saat program dijalankan.

Setelah data ditambahkan, `lblStatus` diperbarui untuk menampilkan
jumlah peminjaman. Form kemudian dikosongkan agar bisa digunakan untuk
memasukkan peminjaman berikutnya.

------------------------------------------------------------------------

## 9. Tombol Bersihkan

Tombol `btnBersihkan` digunakan untuk mengosongkan seluruh isian pada
form dan menghapus tanda kesalahan.

Proses tersebut dipisahkan ke dalam Sub `BersihkanForm()` supaya dapat
digunakan kembali setelah peminjaman berhasil dicatat maupun ketika
pengguna menekan tombol Bersihkan.

Kontrol yang dikosongkan yaitu:

-   `txtKodeBuku`
-   `txtJudul`
-   `cboKategori`
-   `txtNamaPeminjam`
-   `txtLamaPinjam`

Program juga menjalankan `errPinjam.Clear()` untuk menghapus semua ikon
kesalahan.

Properti `CausesValidation` pada tombol Bersihkan diatur menjadi
`False`, agar tombol tersebut dapat digunakan untuk membersihkan form
tanpa memicu validasi input.

------------------------------------------------------------------------

## 10. Format Data CSV

CSV digunakan untuk menyimpan data dalam bentuk teks dengan kolom yang
dipisahkan oleh tanda tertentu. Pada tugas ini, pemisah kolom yang
digunakan adalah titik koma (`;`).

Baris pertama file berisi judul kolom:

``` text
Kode Buku;Judul Buku;Kategori;Nama Peminjam;Lama Pinjam (hari);Tanggal Kembali
```

Setiap peminjaman ditulis sebagai satu baris di bawah judul kolom
tersebut. Program menggunakan function `FormatKolomCsv()` untuk
menangani nilai yang mengandung titik koma, tanda kutip, atau pergantian
baris agar penulisan CSV lebih aman.

File disimpan dengan nama `peminjaman.csv` di folder Documents. Lokasi
tersebut diperoleh menggunakan:

``` vb
Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    "peminjaman.csv")
```

------------------------------------------------------------------------

## 11. Tombol Ekspor dan Penanganan Exception

Tombol `btnEkspor` digunakan untuk menulis data peminjaman ke file CSV.
Jika daftar peminjaman masih kosong, program menampilkan pesan bahwa
belum ada data yang bisa diekspor dan tidak melanjutkan proses penulisan
file.

Proses penulisan menggunakan `StreamWriter` dan struktur
`Try...Catch...Finally`.

### IOException

`IOException` ditangani ketika terjadi masalah input/output pada file,
misalnya file tidak dapat ditulis karena sedang dikunci oleh aplikasi
lain.

Pesan yang ditampilkan meminta pengguna menutup `peminjaman.csv` jika
sedang dibuka di Excel, kemudian mencoba ekspor kembali.

### UnauthorizedAccessException

`UnauthorizedAccessException` ditangani ketika program tidak memiliki
izin untuk mengakses atau menulis file. Pesan meminta pengguna memeriksa
izin folder Documents atau menggunakan folder yang bisa ditulisi.

### Finally

Blok `Finally` digunakan untuk menutup `StreamWriter` setelah proses
ekspor selesai, termasuk ketika terjadi exception. Dengan penanganan
exception, aplikasi dapat menampilkan pesan kegagalan daripada langsung
berhenti ketika terjadi masalah ekspor.

Perlu diketahui, pengujian dengan membuka CSV di Excel tidak selalu
menghasilkan `IOException`. Hasilnya bergantung pada apakah Excel
benar-benar mengunci file tersebut. Jika file masih dapat ditulis oleh
program, ekspor bisa tetap berhasil.

------------------------------------------------------------------------

## 12. Alur Validasi dan Peminjaman

Alur ketika pengguna mencatat peminjaman adalah:

``` text
Pengguna mengisi form
          ↓
     Klik tombol Pinjam
          ↓
     ValidasiInput()
          ↓
Apakah semua input valid?
       ↙           ↘
     Tidak          Ya
      ↓              ↓
ErrorProvider     Menghitung tanggal kembali
menampilkan            ↓
kesalahan         Menyimpan kode dan data
                     peminjaman
                         ↓
                 Menambah item ListBox
                         ↓
                 Memperbarui lblStatus
                         ↓
                   Membersihkan form
```

Dengan alur tersebut, data hanya dicatat jika semua isian sudah memenuhi
aturan.

------------------------------------------------------------------------

## 13. Alur Ekspor CSV

Alur ketika pengguna mengekspor data adalah:

``` text
Klik tombol Ekspor
         ↓
Periksa daftar peminjaman
         ↓
Apakah daftar kosong?
     ↙           ↘
   Ya             Tidak
    ↓               ↓
Tampilkan pesan  Siapkan lokasi CSV
dan berhenti          ↓
                  Try menulis file
                       ↓
                Ekspor berhasil?
                  ↙         ↘
              Berhasil      Gagal
                 ↓            ↓
           Pesan sukses   Catch exception
                               ↓
                         Pesan kesalahan
                               ↓
                            Finally
                               ↓
                         Tutup StreamWriter
```

`Try` berisi proses utama penulisan file. `Catch` menangani jenis
kesalahan yang ditentukan, sedangkan `Finally` digunakan untuk menutup
file.

------------------------------------------------------------------------

## 14. Hasil Praktikum

Hasil dari praktikum pertemuan 7 adalah aplikasi Windows Forms untuk
mencatat peminjaman buku. Aplikasi ini memiliki beberapa fungsi, yaitu:

1.  Memasukkan kode buku, judul, kategori, nama peminjam, dan lama
    pinjam.
2.  Memeriksa seluruh isian sebelum mencatat data.
3.  Menampilkan tanda kesalahan melalui `ErrorProvider`.
4.  Menerima kode buku huruf kecil dan menyimpannya dalam huruf besar.
5.  Mencegah kode buku yang sama dicatat dua kali.
6.  Menghitung tanggal kembali berdasarkan lama pinjam.
7.  Menampilkan daftar peminjaman beserta jumlahnya.
8.  Mengosongkan form dan menghapus ikon kesalahan.
9.  Mengekspor daftar peminjaman ke file CSV.
10. Menangani kegagalan ekspor menggunakan `IOException` dan
    `UnauthorizedAccessException`.

------------------------------------------------------------------------

## 15. Hal yang Dipelajari

Dari praktikum ini kami belajar bahwa input pengguna perlu diperiksa
sebelum diproses atau disimpan. Validasi yang terpusat membuat
pemeriksaan lebih teratur, sedangkan `ErrorProvider` membantu
menunjukkan kontrol yang masih salah tanpa menampilkan banyak
MessageBox.

Kami juga belajar menggunakan `List(Of String)` untuk memeriksa kode
buku yang sudah tercatat, menggunakan `Integer.TryParse` untuk membaca
bilangan bulat dengan aman, serta menggunakan `Date.Today.AddDays()`
untuk menghitung tanggal kembali.

Selain itu, kami mempelajari cara menulis data ke file CSV dan menangani
masalah file dengan `Try...Catch...Finally`. Dengan begitu, aplikasi
tidak hanya mencatat data, tetapi juga memberikan pesan yang sesuai
ketika ekspor tidak dapat dilakukan.

------------------------------------------------------------------------

## Kesimpulan

Pada praktikum pertemuan 7 kami membuat aplikasi Windows Forms untuk
mencatat peminjaman buku menggunakan VB.NET. Aplikasi menggunakan
validasi terpusat melalui `ValidasiInput()`, penanda kesalahan
`ErrorProvider`, dan function `KodeBukuValid()` untuk memeriksa format
kode buku.

Data peminjaman yang valid disimpan dalam daftar, ditampilkan pada
`ListBox`, dan dihitung tanggal kembalinya secara otomatis. Kami juga
belajar mencegah peminjaman dengan kode yang sama serta mengekspor data
ke file CSV dengan penanganan exception.

Melalui praktikum ini, kami memahami penggunaan validasi input, list,
perhitungan tanggal, dan penanganan error file pada aplikasi Windows
Forms.
