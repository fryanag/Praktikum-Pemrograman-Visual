
Option Strict On

Public Module ModPencarian

    Public Function AmankanTeksFilter(teks As String) As String
        Dim hasil As String = ""

        For Each karakter As Char In teks
            Select Case karakter
                Case "'"c
                    hasil &= "''"
                Case "["c, "]"c, "*"c, "%"c
                    hasil &= "[" & karakter & "]"
                Case Else
                    hasil &= karakter
            End Select
        Next

        Return hasil
    End Function

End Module
