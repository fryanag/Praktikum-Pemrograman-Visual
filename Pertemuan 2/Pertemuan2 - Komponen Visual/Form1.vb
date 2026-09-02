Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblName.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblNIM.Click

    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MessageBox.Show("Halo Selamat Datang!" & vbCrLf &
                        "NAMA  : " & txtNama.Text & vbCrLf &
                        "NIM   : " & txtNIM.Text & vbCrLf &
                        "KOM   : " & txtKOM.Text
        )


    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        txtNama.Clear()
        txtNIM.Clear()
        txtKOM.Clear()

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()

    End Sub
End Class
