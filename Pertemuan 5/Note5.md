# Pertemuan 5 – Fungsi, Array, dan Modul

## Tujuan

Pada pertemuan ini mempelajari penggunaan **Function**, **Array**, dan **Module** pada Visual Basic .NET. Materi ini digunakan untuk menyimpan beberapa data dalam satu variabel dan membuat kode program menjadi lebih terstruktur.

## Pembahasan

### 1. Fungsi (Function)

Function digunakan untuk membuat bagian program yang dapat menerima input, melakukan proses, kemudian mengembalikan sebuah nilai.

Contoh:

```vb
Function Hitung(panjang As Integer, lebar As Integer) As Integer
    If panjang <= 50 Then
        Return 2 * panjang + 2 * lebar
    Else
        Return panjang * lebar
    End If
End Function
```

Pada fungsi `Hitung` terdapat dua parameter yaitu `panjang` dan `lebar`.

Jika nilai panjang kurang dari atau sama dengan 50, maka program menghitung:

```text
2 × panjang + 2 × lebar
```

Jika panjang lebih dari 50, maka program menghitung:

```text
panjang × lebar
```

`Return` digunakan untuk mengembalikan hasil dari fungsi.

### 2. Array

Array digunakan untuk menyimpan beberapa data dengan tipe yang sama dalam satu variabel.

Contoh array satu dimensi:

```vb
Public nilai() As Integer = {50, 60, 70, 80, 90}
```

Array tersebut menyimpan lima nilai.

Index array dimulai dari `0`, sehingga:

```text
nilai(0) = 50
nilai(1) = 60
nilai(2) = 70
nilai(3) = 80
nilai(4) = 90
```

Untuk menampilkan isi array dapat digunakan perulangan:

```vb
For i As Integer = 0 To nilai.Length - 1
    lstNilai.Items.Add(nilai(i))
Next
```

`nilai.Length` digunakan untuk mengetahui jumlah data yang ada di dalam array.

### 3. Array 2 Dimensi

Array 2 dimensi digunakan untuk menyimpan data dalam bentuk baris dan kolom.

Contoh:

```vb
Public nilai2D(,) As Integer = {
    {55, 58, 65},
    {70, 75, 82},
    {84, 86, 90}
}
```

Bentuk datanya:

|   |   |   |
|---|---|---|
| 55 | 58 | 65 |
| 70 | 75 | 82 |
| 84 | 86 | 90 |

Untuk mengambil data tertentu digunakan dua index, yaitu index baris dan kolom.

Contoh:

```vb
nilai2D(1, 2)
```

Nilai tersebut adalah `82`.

### 4. Modul (Module)

Module digunakan untuk menyimpan function, procedure, variabel, atau kode lain yang dapat digunakan oleh bagian program lainnya.

Contoh:

```vb
Module ModArray

    Public Sub TampilkanPesan(nama As String)
        MessageBox.Show("Halo " & nama)
    End Sub

End Module
```

Procedure `TampilkanPesan` dapat dipanggil dari form.

Contoh:

```vb
TampilkanPesan("Bachata")
```

Program akan menampilkan pesan:

```text
Halo Bachata
```

Module juga dapat digunakan untuk menyimpan array seperti:

```vb
Public nilai() As Integer = {50, 60, 70, 80, 90}
```

Dengan begitu data tersebut dapat digunakan dari form.

## Praktik

Pada praktik dibuat form `FrmArray` dengan beberapa komponen seperti TextBox, Button, dan ListBox.

Tombol `Tampil` digunakan untuk menampilkan data array:

```vb
Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
    For i As Integer = 0 To nilai.Length - 1
        lstNilai.Items.Add(nilai2D(1, 2))
    Next
End Sub
```

Pada praktik ini digunakan perulangan `For` untuk mengakses data array.

Terdapat juga validasi pada TextBox agar hanya dapat menerima angka:

```vb
Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```

Validasi yang sama digunakan pada `txtLebar`.

## Kode Program

### Form `FrmArray`

```vb
Public Class FrmArray
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        'MessageBox.Show(Hitung(txtPanjang.Text, txtLebar.Text))
        'lstNilai.Items.Add(nilai(0))
        For i As Integer = 0 To nilai.Length - 1
            lstNilai.Items.Add(nilai2D(1, 2))
        Next
    End Sub

    Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLebaar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLebar.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
```

### Module `ModArray`

```vb
Module ModArray
    Public Sub TampilkanPesan(nama As String)
        MessageBox.Show("Halo " & nama)
    End Sub

    Function Hitung(panjang As Integer, lebar As Integer) As Integer
        If panjang <= 50 Then
            Return 2 * panjang + 2 * lebar
        Else
            Return panjang * lebar
        End If
    End Function

    Public nilai() As Integer = {50, 60, 70, 80, 90}

    Public nilai2D(,) As Integer = {
        {55, 58, 65},
        {70, 75, 82},
        {84, 86, 90}
    }
End Module
```

## Hal yang Dipelajari

- Function digunakan untuk membuat proses yang dapat mengembalikan nilai.
- Parameter digunakan untuk memberikan data ke dalam Function.
- `Return` digunakan untuk mengembalikan hasil Function.
- Array digunakan untuk menyimpan banyak data dengan tipe yang sama.
- Array satu dimensi menggunakan satu index.
- Array 2 dimensi menggunakan index baris dan kolom.
- `Length` digunakan untuk mengetahui jumlah elemen array.
- Module dapat digunakan untuk menyimpan Function, Procedure, dan variabel.

## Kesimpulan

Pada pertemuan ini dipelajari penggunaan **Function, Array, dan Module** pada Visual Basic .NET. Array digunakan untuk menyimpan banyak data, sedangkan Function dan Module membantu membuat kode program menjadi lebih terstruktur dan dapat digunakan kembali.