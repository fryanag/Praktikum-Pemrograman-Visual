Public Class Form1


    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNim.Text,
            txtNama.Text,
            txtJurusan.Text) Then

            MessageBox.Show("Dat Berhasil disimpan")

        End If

        txtJurusan.Clear()
        txtNama.Clear()
        txtNim.Clear()

    End Sub

    Private Sub button1_Click_1(sender As Object, e As EventArgs) Handles button1.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub dgvMahasiswa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMahasiswa.CellContentClick

    End Sub

End Class
