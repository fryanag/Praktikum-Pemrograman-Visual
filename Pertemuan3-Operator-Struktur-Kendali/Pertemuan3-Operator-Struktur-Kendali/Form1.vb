Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtNilai_TextChanged(sender As Object, e As EventArgs) Handles txtNilai.TextChanged

    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilaiUjian As Integer

        If Not Integer.TryParse(txtNilai.Text, nilaiUjian) Then
            MessageBox.Show("Masukkan dalam bentuk angka")
            txtNilai.Focus()
            Return
        End If

        If nilaiUjian < 0 OrElse nilaiUjian > 100 Then
            MessageBox.Show("Masukkan nila 0 - 100")
            txtNilai.Focus()
            Return
        End If

        If nilaiUjian <= 50 Then
            picImage.Image = Image.FromFile("Assets\giphy.gif")

        ElseIf nilaiUjian <= 75 Then
            picImage.Image = Image.FromFile("Assets\giphy1.webp")

        Else
            picImage.Image = Image.FromFile("Assets\giphy2.webp")
        End If
    End Sub

    Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
