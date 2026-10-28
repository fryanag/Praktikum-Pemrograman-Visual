# Pertemuan 8 -- Inventaris Buku Perpustakaan dengan VB.NET

## Tujuan

Pada praktikum pertemuan 8 ini, kami membuat aplikasi inventaris buku
perpustakaan menggunakan Visual Basic .NET Windows Forms. Aplikasi ini
digunakan untuk menyimpan data buku sementara di dalam program,
menambahkan buku baru, mencari buku, memfilter kategori, mengurutkan
data, dan melihat jumlah buku serta total stok.

Pada praktikum ini data disimpan menggunakan `DataTable`, jadi belum
menggunakan database seperti PostgreSQL pada pertemuan sebelumnya.

------------------------------------------------------------------------

## Pembahasan

Pada pertemuan ini kami membuat aplikasi pengelolaan data buku dengan
beberapa fitur, yaitu:

-   Membuat tabel data menggunakan `DataTable`
-   Mengisi data buku awal
-   Menghubungkan data dengan `BindingSource`
-   Menampilkan data ke `DataGridView`
-   Menambahkan buku melalui form
-   Melakukan validasi input
-   Memeriksa kode buku yang duplikat
-   Mencari buku berdasarkan judul atau penulis
-   Memfilter data berdasarkan kategori
-   Menampilkan buku yang stoknya habis
-   Mengurutkan data buku
-   Menghitung jumlah buku yang ditampilkan dan total stok

------------------------------------------------------------------------

## 1. DataTable

`DataTable` digunakan sebagai tempat penyimpanan data berbentuk tabel
selama program berjalan. Pada aplikasi ini, data buku disimpan di dalam
`DataTable`, bukan di database.

Tabel buku memiliki beberapa kolom:

  Kolom        Tipe data   Keterangan
  ------------ ----------- -------------------
  `KodeBuku`   `String`    Kode unik buku
  `Judul`      `String`    Judul buku
  `Penulis`    `String`    Nama penulis
  `Kategori`   `String`    Kategori buku
  `Tahun`      `Integer`   Tahun terbit buku
  `Stok`       `Integer`   Jumlah stok buku

Contoh pembuatan tabel:

``` vb
tabelBuku = New DataTable("Buku")

tabelBuku.Columns.Add("KodeBuku", GetType(String))
tabelBuku.Columns.Add("Judul", GetType(String))
tabelBuku.Columns.Add("Penulis", GetType(String))
tabelBuku.Columns.Add("Kategori", GetType(String))
tabelBuku.Columns.Add("Tahun", GetType(Integer))
tabelBuku.Columns.Add("Stok", GetType(Integer))
```

`New DataTable("Buku")` digunakan untuk membuat tabel bernama `Buku`.
Selanjutnya, setiap kolom ditambahkan sesuai data yang dibutuhkan
aplikasi.

Karena data hanya disimpan di memori, data yang ditambahkan akan hilang
ketika aplikasi ditutup, kecuali program dikembangkan lagi agar
menyimpan data ke file atau database.

------------------------------------------------------------------------

## 2. Data Awal Buku

Saat form dibuka, program memasukkan sepuluh data buku awal ke dalam
`DataTable`.

Contoh kode:

``` vb
tabelBuku.Rows.Add("BK0001", "Laskar Pelangi",
    "Andrea Hirata", "Fiksi", 2005, 5)

tabelBuku.Rows.Add("BK0002", "Bumi",
    "Tere Liye", "Fiksi", 2014, 3)
```

Perintah `Rows.Add()` digunakan untuk menambahkan satu baris data ke
tabel. Nilai yang dimasukkan harus mengikuti urutan kolom, yaitu kode
buku, judul, penulis, kategori, tahun terbit, dan stok.

Data awal mencakup kategori `Fiksi`, `Nonfiksi`, `Referensi`, dan
`Majalah`. Ada juga buku yang stoknya nol agar fitur filter stok habis
bisa diuji.

------------------------------------------------------------------------

## 3. BindingSource

`BindingSource` menjadi penghubung antara sumber data dan komponen
tampilan. Pada aplikasi ini, `BindingSource` menghubungkan `DataTable`
dengan `DataGridView`.

Kode yang digunakan:

``` vb
bsBuku.DataSource = tabelBuku
dgvBuku.DataSource = bsBuku
```

Baris pertama menjadikan `tabelBuku` sebagai sumber data untuk `bsBuku`.
Baris kedua menghubungkan `bsBuku` ke `dgvBuku`, sehingga data buku
dapat ditampilkan di tabel pada Form.

Penggunaan `BindingSource` juga memudahkan penerapan filter dan
pengurutan data.

------------------------------------------------------------------------

## 4. DataGridView

`DataGridView` digunakan untuk menampilkan data buku dalam bentuk tabel.
Pada aplikasi ini, nama komponennya adalah `dgvBuku`.

Kode yang digunakan:

``` vb
dgvBuku.AutoGenerateColumns = True
dgvBuku.DataSource = bsBuku
```

`AutoGenerateColumns = True` membuat kolom secara otomatis berdasarkan
kolom sumber data.

Beberapa pengaturan tampilan yang digunakan pada Designer:

-   `ReadOnly = True`, agar data tidak diedit langsung dari tabel.
-   `AllowUserToAddRows = False`, agar pengguna tidak menambahkan baris
    kosong langsung dari tabel.
-   `SelectionMode = FullRowSelect`, agar satu baris dipilih sekaligus.
-   `MultiSelect = False`, agar hanya satu baris yang bisa dipilih dalam
    satu waktu.

Lebar kolom juga diatur agar menyesuaikan tampilan. Kolom judul diberi
ruang lebih besar karena biasanya teks judul lebih panjang.

------------------------------------------------------------------------

## 5. Validasi Input

Sebelum buku ditambahkan, program memeriksa apakah data yang diisi sudah
sesuai. Validasi diperlukan supaya data kosong atau data dengan format
yang salah tidak langsung masuk ke tabel.

Pemeriksaan yang dilakukan antara lain:

-   Kode buku harus diawali `BK` dan diikuti empat angka.
-   Kode buku tidak boleh sama dengan kode yang sudah ada.
-   Judul harus diisi.
-   Penulis harus diisi.
-   Kategori harus dipilih.
-   Tahun harus berupa bilangan bulat antara 1900 dan tahun sekarang.
-   Stok harus berupa bilangan bulat nol atau lebih.

Program menggunakan `ErrorProvider` dengan nama `errBuku` untuk
menunjukkan bagian input yang bermasalah.

Contoh kode:

``` vb
If txtJudul.Text.Trim() = "" Then
    errBuku.SetError(txtJudul, "Judul wajib diisi.")
    valid = False
End If
```

`Trim()` digunakan untuk menghapus spasi di bagian awal dan akhir teks.
Jika judul kosong, `SetError()` menampilkan pesan pada komponen judul
dan nilai `valid` diubah menjadi `False`.

Di awal validasi, pesan sebelumnya dihapus dengan:

``` vb
errBuku.Clear()
```

Dengan begitu, pesan kesalahan lama tidak terus tampil setelah pengguna
memperbaiki input.

------------------------------------------------------------------------

## 6. Memeriksa Kode Buku Duplikat

Kode buku digunakan sebagai identitas buku, jadi kode yang sama tidak
boleh dimasukkan dua kali.

Pengecekan dilakukan dengan perulangan terhadap seluruh baris di
`DataTable`.

``` vb
For Each baris As DataRow In tabelBuku.Rows
    If baris("KodeBuku").ToString() = kode Then
        kodeSudahAda = True
        Exit For
    End If
Next
```

`For Each` digunakan untuk memeriksa setiap baris. Jika nilai `KodeBuku`
sama dengan kode yang sedang dimasukkan, variabel `kodeSudahAda` diubah
menjadi `True`, lalu `Exit For` menghentikan perulangan.

Jika kode sudah dipakai, program menampilkan pesan bahwa kode buku sudah
digunakan dan data tidak ditambahkan.

------------------------------------------------------------------------

## 7. TryParse untuk Tahun dan Stok

Tahun dan stok harus berupa bilangan bulat. Program menggunakan
`Integer.TryParse()` untuk memeriksa apakah teks bisa diubah menjadi
angka tanpa langsung menyebabkan error konversi.

Contoh:

``` vb
If Not Integer.TryParse(txtStok.Text.Trim(), stok) OrElse
   stok < 0 Then

    errBuku.SetError(txtStok,
        "Stok harus bilangan bulat 0 atau lebih.")
    valid = False
End If
```

Jika input bukan angka bulat atau nilainya kurang dari nol, program
memberi pesan kesalahan. Untuk tahun, program juga memeriksa batas tahun
yang diperbolehkan.

`OrElse` digunakan sebagai kondisi logika OR yang berhenti mengevaluasi
kondisi berikutnya jika kondisi pertama sudah benar. Hal ini membantu
menghindari pemeriksaan nilai yang belum berhasil dikonversi.

------------------------------------------------------------------------

## 8. Tombol Tambah

Tombol `btnTambah` digunakan untuk menambahkan data buku baru. Ketika
tombol ditekan, program menjalankan `ValidasiInput()` terlebih dahulu.

Alurnya adalah:

``` text
Pengguna mengisi data buku
          ↓
    Klik tombol Tambah
          ↓
     ValidasiInput()
          ↓
  Apakah data sudah benar?
       ↙           ↘
     Tidak          Ya
      ↓              ↓
Tampilkan pesan   Rows.Add()
kesalahan             ↓
                  Data masuk
                  ke DataTable
                       ↓
              Bersihkan input
                       ↓
              Perbarui urutan
                dan filter
```

Jika validasi gagal, program menampilkan pesan peringatan dan proses
penambahan dihentikan dengan `Return`.

Jika validasi berhasil, program memasukkan data menggunakan
`tabelBuku.Rows.Add()`, lalu membersihkan form, menerapkan pengurutan
dan filter, serta menampilkan pesan bahwa buku berhasil ditambahkan.

------------------------------------------------------------------------

## 9. Membersihkan Input

Tombol `btnBersihkan` digunakan untuk mengosongkan isian pada form.

``` vb
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
```

`Clear()` menghapus teks dari TextBox. `SelectedIndex = -1` membuat
pilihan kategori tidak terpilih. `errBuku.Clear()` menghapus pesan
validasi, sedangkan `Focus()` mengarahkan kursor kembali ke input kode
buku.

Fungsi ini dibuat terpisah supaya bisa dipanggil dari tombol Bersihkan
maupun setelah data berhasil ditambahkan.

------------------------------------------------------------------------

## 10. Pencarian Berdasarkan Judul atau Penulis

Kotak pencarian `txtCari` digunakan untuk mencari buku berdasarkan judul
atau nama penulis. Pencarian dilakukan ketika teks di dalam kotak
pencarian berubah.

Bagian utama filter pencariannya:

``` vb
syarat.Add(
    "(Judul LIKE '%" & aman &
    "%' OR Penulis LIKE '%" & aman & "%')")
```

`LIKE` digunakan untuk mencari teks yang cocok dengan pola tertentu.
Tanda `%` berarti teks apa pun dapat berada sebelum atau sesudah kata
yang dicari. Jadi, kata pencarian tidak harus sama persis dengan seluruh
judul atau nama penulis.

`OR` berarti data ditampilkan jika judul cocok atau penulis cocok. Tanda
kurung digunakan agar kedua kondisi pencarian tersebut diperlakukan
sebagai satu kelompok kondisi.

Program juga mengamankan karakter tertentu pada teks pencarian agar
tidak langsung merusak bentuk ekspresi filter. Fungsi `AmankanFilter()`
dipakai untuk keperluan tersebut.

------------------------------------------------------------------------

## 11. Filter Kategori

Filter kategori menggunakan `cboFilterKategori`. Pilihannya adalah
`Semua`, `Fiksi`, `Nonfiksi`, `Referensi`, dan `Majalah`.

Jika pengguna memilih `Semua`, program tidak menambahkan syarat
kategori. Namun, jika pengguna memilih kategori tertentu, program
menambahkan kondisi seperti:

``` vb
syarat.Add("Kategori = '" & kategori.Replace("'", "''") & "'")
```

Artinya, hanya data dengan kategori yang dipilih yang akan ditampilkan.
Filter kategori dapat digunakan bersamaan dengan pencarian teks.

------------------------------------------------------------------------

## 12. Filter Buku dengan Stok Habis

Checkbox `chkStokHabis` digunakan untuk menampilkan buku yang stoknya
nol saja.

``` vb
If chkStokHabis.Checked Then
    syarat.Add("Stok = 0")
End If
```

Jika checkbox dicentang, program menambahkan syarat `Stok = 0`. Jika
tidak dicentang, syarat tersebut tidak ditambahkan.

Filter stok habis tidak menggantikan pencarian dan filter kategori.
Semua syarat digabungkan, sehingga pengguna tetap bisa mencari judul
atau penulis tertentu, memilih kategori, dan membatasi hasil ke buku
yang stoknya habis secara bersamaan.

------------------------------------------------------------------------

## 13. Menggabungkan Filter

Pencarian teks, kategori, dan stok habis disimpan dalam daftar `syarat`.
Setelah semua kondisi diperiksa, kondisi tersebut digabungkan
menggunakan `AND`.

``` vb
If syarat.Count > 0 Then
    bsBuku.Filter = String.Join(" AND ", syarat)
Else
    bsBuku.RemoveFilter()
End If
```

`syarat.Count` memeriksa apakah ada kondisi filter.
`String.Join(" AND ", syarat)` menggabungkan semua kondisi dengan `AND`,
sehingga seluruh syarat yang aktif harus terpenuhi.

Jika tidak ada syarat, `RemoveFilter()` menghapus filter agar semua buku
dapat ditampilkan kembali.

Contohnya, jika kategori `Fiksi` dipilih dan checkbox stok habis
dicentang, data yang tampil hanya buku dengan kategori Fiksi dan stok
nol.

------------------------------------------------------------------------

## 14. Mengurutkan Data Buku

ComboBox `cboUrut` digunakan untuk mengurutkan data buku berdasarkan
pilihan pengguna.

Pilihan pengurutan yang digunakan:

-   `Urutan awal`
-   `Judul A-Z`
-   `Tahun terbaru`
-   `Stok terbanyak`

Kode utama:

``` vb
Select Case cboUrut.Text
    Case "Judul A-Z"
        bsBuku.Sort = "Judul ASC"

    Case "Tahun terbaru"
        bsBuku.Sort = "Tahun DESC"

    Case "Stok terbanyak"
        bsBuku.Sort = "Stok DESC"

    Case Else
        bsBuku.RemoveSort()
End Select
```

`ASC` berarti urutan naik, sedangkan `DESC` berarti urutan turun.

-   `Judul ASC` mengurutkan judul dari A ke Z.
-   `Tahun DESC` menampilkan tahun terbaru lebih dahulu.
-   `Stok DESC` menampilkan buku dengan stok terbanyak lebih dahulu.
-   `RemoveSort()` menghapus pengurutan khusus dan mengembalikan urutan
    awal tabel.

Pengurutan dilakukan melalui `BindingSource`, sehingga data yang
ditampilkan pada `DataGridView` mengikuti pilihan tersebut.

------------------------------------------------------------------------

## 15. Menghitung Jumlah Buku dan Total Stok

Aplikasi menampilkan ringkasan melalui `lblJumlah` dan `lblTotalStok`.

-   `lblJumlah` menunjukkan jumlah baris buku yang sedang terlihat
    dibandingkan dengan jumlah seluruh data buku.
-   `lblTotalStok` menunjukkan jumlah stok dari buku yang sedang
    terlihat pada tabel.

Program menghitung baris yang terlihat pada `DataGridView`:

``` vb
For Each baris As DataGridViewRow In dgvBuku.Rows
    If Not baris.IsNewRow Then
        jumlah += 1
        totalStok += CInt(baris.Cells("Stok").Value)
    End If
Next
```

`For Each` memeriksa setiap baris pada tabel. `IsNewRow` digunakan untuk
melewati baris input kosong jika ada. Jumlah buku ditambah satu untuk
setiap baris data, sedangkan nilai pada kolom `Stok` dijumlahkan ke
`totalStok`.

Karena perhitungan dilakukan dari baris yang terlihat pada
`DataGridView`, ringkasan ikut berubah saat pencarian atau filter
digunakan.

------------------------------------------------------------------------

## 16. Event pada Form

Beberapa event digunakan agar tampilan langsung diperbarui saat pengguna
melakukan tindakan.

  ------------------------------------------------------------------------------
  Event                                      Kegunaan
  ------------------------------------------ -----------------------------------
  `Form1_Load`                               Membuat tabel, mengisi data awal,
                                             dan mengatur tampilan

  `btnTambah_Click`                          Memvalidasi dan menambahkan buku

  `btnBersihkan_Click`                       Mengosongkan input

  `txtCari_TextChanged`                      Memperbarui pencarian saat teks
                                             berubah

  `cboFilterKategori_SelectedIndexChanged`   Memperbarui filter kategori

  `cboUrut_SelectedIndexChanged`             Mengubah pengurutan

  `chkStokHabis_CheckedChanged`              Memperbarui filter stok habis
  ------------------------------------------------------------------------------

Contohnya, `txtCari_TextChanged` berjalan saat isi `txtCari` berubah.
Dengan begitu, pengguna tidak perlu menekan tombol pencarian secara
terpisah.

------------------------------------------------------------------------

## 17. Komponen pada Form

Komponen utama yang digunakan pada Designer antara lain:

  Nama komponen         Fungsi
  --------------------- -------------------------------------
  `txtKodeBuku`         Input kode buku
  `txtJudul`            Input judul buku
  `txtPenulis`          Input nama penulis
  `cboKategori`         Memilih kategori saat menambah buku
  `txtTahun`            Input tahun terbit
  `txtStok`             Input jumlah stok
  `btnTambah`           Menambahkan buku
  `btnBersihkan`        Membersihkan input
  `txtCari`             Mencari judul atau penulis
  `cboFilterKategori`   Memfilter kategori buku
  `cboUrut`             Memilih pengurutan data
  `chkStokHabis`        Menampilkan buku dengan stok nol
  `dgvBuku`             Menampilkan data buku
  `bsBuku`              Menghubungkan data dengan tampilan
  `lblJumlah`           Menampilkan jumlah buku
  `lblTotalStok`        Menampilkan total stok
  `errBuku`             Menampilkan pesan validasi

Nama komponen harus sesuai dengan yang digunakan di kode agar program
dapat mengenali setiap kontrol.

------------------------------------------------------------------------

## 18. Hasil Praktikum

Hasil praktikum pertemuan 8 adalah aplikasi inventaris buku perpustakaan
berbasis Windows Forms yang dapat digunakan untuk:

1.  Menampilkan sepuluh data buku awal.
2.  Menambahkan data buku baru.
3.  Memeriksa format dan kelengkapan input.
4.  Mencegah kode buku yang sama dimasukkan kembali.
5.  Mencari buku berdasarkan judul atau penulis.
6.  Memfilter buku berdasarkan kategori.
7.  Menampilkan buku yang stoknya habis.
8.  Mengurutkan buku berdasarkan judul, tahun, atau stok.
9.  Menampilkan jumlah buku yang terlihat dan total stoknya.

Data buku dikelola menggunakan `DataTable` dan ditampilkan melalui
`BindingSource` ke `DataGridView`.

------------------------------------------------------------------------

## 19. Hal yang Dipelajari

Dari praktikum ini kami mempelajari bahwa aplikasi Windows Forms bisa
mengolah data tabel tanpa harus langsung menggunakan database.

Beberapa hal yang dipelajari yaitu:

-   Membuat dan mengisi `DataTable`.
-   Menghubungkan `DataTable` dengan `BindingSource`.
-   Menampilkan data menggunakan `DataGridView`.
-   Menggunakan `ErrorProvider` untuk validasi.
-   Memeriksa input angka dengan `Integer.TryParse()`.
-   Menggunakan perulangan `For Each` untuk mengecek kode duplikat.
-   Menambahkan baris dengan `Rows.Add()`.
-   Mencari data dengan ekspresi `LIKE`.
-   Menggabungkan kondisi filter dengan `AND` dan `OR`.
-   Menggunakan `BindingSource.Filter` dan `BindingSource.Sort`.
-   Menghitung jumlah baris dan total stok.
-   Menggunakan event untuk memperbarui tampilan secara langsung.

------------------------------------------------------------------------

## Kesimpulan

Pada praktikum pertemuan 8 kami membuat aplikasi inventaris buku
perpustakaan menggunakan VB.NET Windows Forms. Data buku disimpan
sementara di dalam `DataTable`, lalu ditampilkan melalui `BindingSource`
dan `DataGridView`.

Kami juga mempelajari validasi input, pengecekan kode buku duplikat,
pencarian berdasarkan judul atau penulis, filter kategori, filter stok
habis, dan pengurutan data. Selain itu, aplikasi dapat menampilkan
jumlah buku yang sedang terlihat serta total stoknya.

Dengan praktikum ini, kami belajar mengelola data pada aplikasi desktop,
membuat input lebih terkontrol, dan menambahkan fitur pencarian serta
filter tanpa harus menggunakan database.
