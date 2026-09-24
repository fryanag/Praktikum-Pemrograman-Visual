Public Class Form1

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        ' 1. Deklarasi Variabel & Input
        Dim berat As Decimal
        Dim hargaPerKg As Decimal = 7000D ' Harga Dasar Rp 7.000/kg
        Dim subtotal As Decimal
        Dim diskonPersen As Decimal = 0D
        Dim jumlahDiskon As Decimal
        Dim totalBayar As Decimal
        Dim isMember As Boolean = chkMember.Checked

        ' 2. Validasi Input
        If Not Decimal.TryParse(txtBerat.Text, berat) OrElse berat <= 0 Then
            MessageBox.Show("Masukkan jumlah berat laundry yang valid dan lebih dari 0!", "Error Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3. Hitung Subtotal
        subtotal = berat * hargaPerKg

        ' 4. Aturan Percabangan Diskon
        ' Aturan A: Diskon Berat (Kuantitas)
        If berat >= 5 Then
            diskonPersen = diskonPersen + 0.1D ' Diskon 10% jika berat >= 5 kg
        End If

        ' Aturan B: Diskon Member Tambahan (Menggunakan Operator And)
        If isMember And subtotal >= 30000D Then
            diskonPersen = diskonPersen + 0.05D ' Tambahan diskon 5% untuk member dengan belanja min Rp 30.000
        End If

        ' Aturan C: Pembatasan Diskon Maksimal (Nested/Batas Diskon)
        If diskonPersen > 0.15D Then
            diskonPersen = 0.15D ' Maksimal diskon 15%
        End If

        ' 5. Kalkulasi Output
        jumlahDiskon = subtotal * diskonPersen
        totalBayar = subtotal - jumlahDiskon

        ' 6. Tampilkan Hasil ke Label
        lblSubtotal.Text = "Rp " & subtotal.ToString("N0")
        lblDiskon.Text = (diskonPersen * 100).ToString("G") & "% (Rp " & jumlahDiskon.ToString("N0") & ")"
        lblTotal.Text = "Rp " & totalBayar.ToString("N0")
    End Sub
End Class