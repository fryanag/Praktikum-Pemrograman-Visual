
Option Strict On

Module ModulValidasi

    ' Memeriksa format kode buku BK diikuti empat digit.
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

End Module
