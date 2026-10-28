
Option Strict On

Imports System.Globalization

Public Module ModValidasi

    Public Function SemuaDigit(teks As String, jumlah As Integer) As Boolean
        If teks Is Nothing OrElse teks.Length <> jumlah Then
            Return False
        End If

        For Each karakter As Char In teks
            If Not Char.IsDigit(karakter) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function Kosong(teks As String) As Boolean
        Return String.IsNullOrWhiteSpace(teks)
    End Function

    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        hasil = 0D

        If String.IsNullOrWhiteSpace(teks) Then
            Return False
        End If

        Dim formatIndonesia As CultureInfo =
            CultureInfo.GetCultureInfo("id-ID")

        Dim formatInternasional As CultureInfo =
            CultureInfo.InvariantCulture

        If Decimal.TryParse(
            teks.Trim(),
            NumberStyles.Number,
            formatIndonesia,
            hasil
        ) Then
            Return True
        End If

        Return Decimal.TryParse(
            teks.Trim(),
            NumberStyles.Number,
            formatInternasional,
            hasil
        )
    End Function

End Module
