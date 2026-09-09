Public Class FrmLogin

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRole.Items.Add("Staff")
        cmbRole.Items.Add("Manager")
        cmbRole.SelectedIndex = 0
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged

        If cmbRole.Text = "Staff" Then
            picImage.Image = Image.FromFile("Image\staff.png")
        ElseIf cmbRole.Text = "Manager" Then
            picImage.Image = Image.FromFile("Image\manager.png")
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim nim As Integer

        If Not Integer.TryParse(txtNIM.Text, nim) Then
            txtNIM.Focus()
            Return
        End If

        If cmbRole.Text = "Staff" AndAlso
           txtNama.Text.Trim().ToLower() = "mrbread" AndAlso
           txtNIM.Text = "241712000" Then

            FrmPajak.Show()
            Me.Hide()

        ElseIf cmbRole.Text = "Manager" AndAlso
               txtNama.Text.Trim().ToLower() = "bachata" AndAlso
               txtNIM.Text = "241712111" Then

            FrmPajak.Show()
            Me.Hide()

        Else
            MessageBox.Show("Masukkan akun dengan benar")
            Return
        End If

        txtNama.Clear()
        txtNIM.Clear()

    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso
           Not Char.IsWhiteSpace(e.KeyChar) AndAlso
           Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class