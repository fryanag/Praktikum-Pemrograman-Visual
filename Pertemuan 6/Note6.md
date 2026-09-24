# Pertemuan 6 – Koneksi Database PostgreSQL

## Tujuan

Pada praktikum pertemuan 6 ini, kami belajar menghubungkan aplikasi Visual Basic .NET dengan database PostgreSQL. Selain melakukan koneksi database, kami juga belajar memasukkan data dari form ke database dan menampilkan data dari database ke dalam DataGridView.

Praktikum ini menggunakan library `Npgsql` sebagai penghubung antara aplikasi VB.NET dengan PostgreSQL.

---

## Pembahasan

Pada pertemuan ini program mulai dihubungkan dengan database. Jadi data yang dimasukkan melalui aplikasi tidak hanya tampil di form, tetapi dapat disimpan ke database dan ditampilkan kembali dari database.

Beberapa bagian yang dipelajari yaitu:

- Koneksi VB.NET dengan PostgreSQL
- Penggunaan `Npgsql`
- Connection String
- Penggunaan `appsettings.json`
- Module untuk koneksi database
- Function untuk mengambil data
- Function untuk menjalankan perintah SQL
- Query `INSERT`
- Query `SELECT`
- Penggunaan parameter pada query
- Menampilkan data ke `DataGridView`

---

## 1. Npgsql

`Npgsql` adalah library yang digunakan untuk menghubungkan aplikasi .NET dengan database PostgreSQL.

Pada project ini package `Npgsql` digunakan agar program dapat membuat koneksi dan menjalankan query ke database PostgreSQL.

Selain itu, project juga menggunakan:

```text
Microsoft.Extensions.Configuration.Json
```

Library tersebut digunakan untuk membaca konfigurasi database dari file `appsettings.json`.

---

## 2. Connection String

Informasi koneksi database disimpan di dalam file:

```text
appsettings.json
```

Connection string berisi informasi yang dibutuhkan program untuk terhubung ke database, seperti:

- Host
- Port
- Nama database
- Username
- Password
- SSL Mode

Contoh bentuk connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

Dengan menggunakan `appsettings.json`, informasi koneksi database dapat dipisahkan dari kode program utama.

---

## 3. Module ModDatabase

Module `ModDatabase` digunakan untuk mengatur koneksi database.

Kode yang digunakan:

```vb
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase

    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("Appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function

    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString)
                conn.Open()

                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message)
        End Try
    End Sub

End Module
```

Function `GetConnectionString()` digunakan untuk mengambil connection string dari `appsettings.json`.

Sedangkan `DatabaseKoneksi()` digunakan untuk mencoba membuka koneksi ke database.

Jika koneksi berhasil maka akan muncul pesan:

```text
Koneksi database berhasil
```

Jika koneksi gagal maka program akan menampilkan pesan error.

---

## 4. Module ModFunction

Pada `ModFunction` terdapat function yang digunakan untuk mengambil data dan menjalankan perintah SQL.

Dengan adanya module ini, proses database tidak perlu ditulis berulang-ulang di dalam Form.

### AmbilData()

Function `AmbilData()` digunakan untuk mengambil data dari database.

```vb
Public Function AmbilData(query As String) As DataTable
    Dim dt As New DataTable

    Try
        Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
            conn.Open()

            Using cmd As New NpgsqlCommand(query, conn)
                Using adapter As New NpgsqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
    Catch ex As Exception
        MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message)
    End Try

    Return dt
End Function
```

Pada function tersebut dibuat koneksi menggunakan `NpgsqlConnection`.

Kemudian query dijalankan menggunakan `NpgsqlCommand`.

Hasil query dimasukkan ke dalam `DataTable` menggunakan `NpgsqlDataAdapter`.

`DataTable` nantinya digunakan sebagai sumber data untuk `DataGridView`.

### EksekusiData()

Function `EksekusiData()` digunakan untuk menjalankan perintah SQL yang melakukan perubahan terhadap database.

```vb
Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
    Try
        Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
            conn.Open()

            Using cmd As New NpgsqlCommand(query, conn)

                For Each parameter In parameters
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                Next

                cmd.ExecuteNonQuery()
                Return True

            End Using
        End Using

    Catch ex As Exception
        MessageBox.Show(
            "Gagal mengeksekusi data:" & vbCrLf & ex.Message,
            "Error Database"
        )

        Return False
    End Try
End Function
```

Function ini menerima `query` dan `parameters`.

`query` berisi perintah SQL yang akan dijalankan, sedangkan `parameters` berisi nilai yang akan dimasukkan ke dalam query.

Perintah:

```vb
cmd.ExecuteNonQuery()
```

digunakan untuk menjalankan query yang tidak menghasilkan data tabel secara langsung, seperti `INSERT`.

---

## 5. Module ModQuery

`ModQuery` digunakan untuk menyimpan query yang berhubungan dengan tabel database.

Pada praktikum ini digunakan tabel:

```text
mahasiswa
```

Data mahasiswa yang digunakan terdiri dari:

- NIM
- Nama
- Jurusan

Dengan adanya `ModQuery`, query database dipisahkan dari kode pada Form.

---

## 6. Menambah Data Mahasiswa

Function `TambahData()` digunakan untuk memasukkan data mahasiswa ke dalam database.

```vb
Public Function TambahData(
    nim As String,
    nama As String,
    jurusan As String
) As Boolean

    Dim query As String =
        "INSERT INTO mahasiswa (nim, nama, jurusan) " &
        "VALUES (@nim, @nama, @jurusan)"

    Dim parameters As New Dictionary(Of String, Object) From {
        {"@nim", nim},
        {"@nama", nama},
        {"@jurusan", jurusan}
    }

    Return ModFunction.EksekusiData(query, parameters)

End Function
```

Query yang digunakan adalah:

```sql
INSERT INTO mahasiswa (nim, nama, jurusan)
VALUES (@nim, @nama, @jurusan);
```

Query tersebut digunakan untuk memasukkan data baru ke tabel `mahasiswa`.

Parameter yang digunakan yaitu:

```text
@nim
@nama
@jurusan
```

Nilai parameter berasal dari input yang diberikan melalui TextBox pada Form.

---

## 7. Menggunakan Parameter pada Query

Pada query digunakan parameter seperti:

```sql
@nim
@nama
@jurusan
```

Kemudian parameter tersebut diisi melalui:

```vb
Dim parameters As New Dictionary(Of String, Object) From {
    {"@nim", nim},
    {"@nama", nama},
    {"@jurusan", jurusan}
}
```

Penggunaan parameter membuat nilai input dipisahkan dari perintah SQL yang dijalankan.

Dengan cara ini query menjadi lebih terstruktur dibandingkan langsung menggabungkan nilai input ke dalam string SQL.

---

## 8. Menampilkan Data Mahasiswa

Untuk mengambil seluruh data mahasiswa digunakan function `TampilkanData()`.

```vb
Public Function TampilkanData() As DataTable
    Return ModFunction.AmbilData(
        "SELECT * FROM mahasiswa ORDER BY id ASC"
    )
End Function
```

Query SQL yang digunakan:

```sql
SELECT * FROM mahasiswa
ORDER BY id ASC;
```

Query tersebut mengambil seluruh data yang terdapat pada tabel `mahasiswa` dan mengurutkannya berdasarkan `id`.

---

## 9. Form Utama

Pada Form terdapat beberapa TextBox yang digunakan untuk memasukkan data mahasiswa, yaitu:

```text
txtNim
txtNama
txtJurusan
```

Selain itu terdapat tombol untuk menambahkan data dan tombol untuk menampilkan data ke `DataGridView`.

Data yang dimasukkan melalui TextBox akan diteruskan ke `ModQuery`, kemudian `ModQuery` menjalankan proses database melalui `ModFunction`.

---

## 10. Tombol Tambah

Ketika tombol tambah ditekan, program akan menjalankan function `TambahData()`.

Kode yang digunakan:

```vb
Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click

    If ModQuery.TambahData(
        txtNim.Text,
        txtNama.Text,
        txtJurusan.Text) Then

        MessageBox.Show("Data Berhasil disimpan")

    End If

    txtJurusan.Clear()
    txtNama.Clear()
    txtNim.Clear()

End Sub
```

Data dari TextBox:

```text
txtNim
txtNama
txtJurusan
```

dikirim ke:

```vb
ModQuery.TambahData()
```

Jika proses berhasil maka muncul pesan:

```text
Data Berhasil disimpan
```

Setelah data berhasil disimpan, semua TextBox dikosongkan menggunakan:

```vb
txtJurusan.Clear()
txtNama.Clear()
txtNim.Clear()
```

---

## 11. Menampilkan Data ke DataGridView

Untuk menampilkan data mahasiswa digunakan `DataGridView`.

Kode yang digunakan:

```vb
Private Sub button1_Click_1(sender As Object, e As EventArgs) Handles button1.Click

    dgvMahasiswa.AutoGenerateColumns = True
    dgvMahasiswa.DataSource = ModQuery.TampilkanData()

End Sub
```

`AutoGenerateColumns = True` digunakan agar kolom pada DataGridView dapat dibuat berdasarkan data yang diterima.

Sedangkan:

```vb
dgvMahasiswa.DataSource = ModQuery.TampilkanData()
```

digunakan untuk mengambil data dari database dan menampilkannya pada DataGridView.

---

## 12. DataTable

`DataTable` digunakan sebagai tempat menyimpan data hasil query sebelum ditampilkan ke DataGridView.

Pada proses mengambil data:

```text
PostgreSQL
    ↓
Query SELECT
    ↓
NpgsqlDataAdapter
    ↓
DataTable
    ↓
DataGridView
```

Dengan menggunakan `DataTable`, data dari database dapat diproses dan ditampilkan dalam bentuk tabel pada aplikasi.

---

## 13. Alur Menyimpan Data

Alur ketika pengguna menambahkan data adalah:

```text
Input NIM, Nama, Jurusan
          ↓
     Klik Tombol Tambah
          ↓
   ModQuery.TambahData()
          ↓
 ModFunction.EksekusiData()
          ↓
      NpgsqlConnection
          ↓
       PostgreSQL
          ↓
     Data Tersimpan
```

Jadi Form tidak langsung menjalankan query database, tetapi prosesnya dibagi melalui module.

---

## 14. Alur Menampilkan Data

Alur ketika pengguna ingin menampilkan data adalah:

```text
Klik Tombol Tampilkan
          ↓
 ModQuery.TampilkanData()
          ↓
   ModFunction.AmbilData()
          ↓
      PostgreSQL
          ↓
       DataTable
          ↓
     DataGridView
```

Data yang berasal dari database akan diambil menggunakan query `SELECT`, kemudian ditampilkan pada DataGridView.

---

## 15. Pemisahan Module

Pada program ini kode dibagi menjadi beberapa bagian supaya lebih terstruktur.

### ModDatabase

Digunakan untuk:

- Membaca connection string
- Mengatur koneksi database
- Membuka koneksi PostgreSQL
- Mengecek apakah koneksi database berhasil

### ModFunction

Digunakan untuk:

- Mengambil data dari database
- Menjalankan perintah SQL
- Mengatur proses eksekusi query

### ModQuery

Digunakan untuk:

- Menyimpan query database
- Menambah data mahasiswa
- Mengambil data mahasiswa

### Form

Digunakan untuk:

- Menerima input dari pengguna
- Menjalankan tombol
- Menampilkan pesan
- Menampilkan data pada DataGridView

Dengan pembagian tersebut, kode program menjadi lebih rapi karena setiap bagian mempunyai tugas masing-masing.

---

## 16. Struktur Program

Struktur project pada praktikum ini terdiri dari beberapa file utama:

```text
Pertremuan6
│
├── Form1.vb
├── Form1.Designer.vb
├── Form1.resx
│
├── ModDatabase.vb
├── ModFunction.vb
├── ModQuery.vb
│
├── appsettings.json
│
├── Pertremuan6.vbproj
└── Pertremuan6.slnx
```

File `Form1.vb` digunakan untuk mengatur proses pada Form.

File `ModDatabase.vb` digunakan untuk koneksi database.

File `ModFunction.vb` digunakan untuk function database.

File `ModQuery.vb` digunakan untuk query database.

File `appsettings.json` digunakan untuk menyimpan konfigurasi connection string.

---

## 17. Hasil Praktikum

Hasil dari praktikum pertemuan 6 adalah aplikasi Windows Forms yang dapat terhubung dengan database PostgreSQL.

Aplikasi dapat digunakan untuk:

1. Memasukkan NIM mahasiswa.
2. Memasukkan nama mahasiswa.
3. Memasukkan jurusan mahasiswa.
4. Menyimpan data mahasiswa ke database.
5. Mengambil data mahasiswa dari database.
6. Menampilkan data mahasiswa pada DataGridView.

Dengan begitu, aplikasi sudah tidak hanya mengolah data pada Form, tetapi juga dapat berkomunikasi dengan database.

---

## 18. Hal yang Dipelajari

Dari praktikum ini kami mempelajari bahwa aplikasi desktop dapat dihubungkan dengan database menggunakan library tertentu.

kami juga belajar bahwa proses database sebaiknya dipisahkan dari Form agar kode lebih mudah dibaca dan dikelola.

Beberapa hal yang kami pelajari yaitu:

- Cara menggunakan `Npgsql`.
- Cara membuat koneksi PostgreSQL.
- Cara menggunakan `appsettings.json`.
- Cara mengambil connection string.
- Cara membuat `NpgsqlConnection`.
- Cara menjalankan query menggunakan `NpgsqlCommand`.
- Cara mengambil data menggunakan `NpgsqlDataAdapter`.
- Cara menyimpan hasil query ke `DataTable`.
- Cara menggunakan parameter pada query.
- Cara menggunakan `INSERT`.
- Cara menggunakan `SELECT`.
- Cara menampilkan data database pada `DataGridView`.
- Cara membagi proses database ke dalam beberapa module.

---

## Kesimpulan

Pada praktikum pertemuan 6 kami belajar membuat aplikasi VB.NET yang dapat terhubung dengan database PostgreSQL menggunakan `Npgsql`.

kami juga belajar menggunakan `appsettings.json` untuk menyimpan connection string, membuat `ModDatabase` untuk mengatur koneksi, `ModFunction` untuk menjalankan proses database, dan `ModQuery` untuk menyimpan query yang digunakan aplikasi.

Selain itu, kami belajar bagaimana data dari TextBox dapat disimpan ke database menggunakan query `INSERT` dan bagaimana data dari database dapat ditampilkan kembali menggunakan query `SELECT` ke dalam `DataGridView`.

Dengan adanya pembagian module tersebut, program menjadi lebih terstruktur dan setiap bagian memiliki fungsi masing-masing.
