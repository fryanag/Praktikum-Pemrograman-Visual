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
