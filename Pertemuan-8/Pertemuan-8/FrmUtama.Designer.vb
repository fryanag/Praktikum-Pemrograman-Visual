<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblJudul = New Label()
        btnDariArray = New Button()
        btnDariList = New Button()
        btnDataTable = New Button()
        btnCariList = New Button()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Microsoft Sans Serif", 14.0F)
        lblJudul.Location = New Point(25, 9)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(232, 29)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Contoh Pertemuan 8"
        ' 
        ' btnDariArray
        ' 
        btnDariArray.Location = New Point(219, 110)
        btnDariArray.Name = "btnDariArray"
        btnDariArray.Size = New Size(304, 29)
        btnDariArray.TabIndex = 1
        btnDariArray.Text = "1. DataGridView dari Array"
        btnDariArray.UseVisualStyleBackColor = True
        ' 
        ' btnDariList
        ' 
        btnDariList.Location = New Point(219, 170)
        btnDariList.Name = "btnDariList"
        btnDariList.Size = New Size(304, 29)
        btnDariList.TabIndex = 2
        btnDariList.Text = "2. Binding List Mahasiswa"
        btnDariList.UseVisualStyleBackColor = True
        ' 
        ' btnDataTable
        ' 
        btnDataTable.Location = New Point(219, 225)
        btnDataTable.Name = "btnDataTable"
        btnDataTable.Size = New Size(304, 29)
        btnDataTable.TabIndex = 3
        btnDataTable.Text = "3. DataTable dan Filter"
        btnDataTable.UseVisualStyleBackColor = True
        ' 
        ' btnCariList
        ' 
        btnCariList.Location = New Point(219, 281)
        btnCariList.Name = "btnCariList"
        btnCariList.Size = New Size(304, 29)
        btnCariList.TabIndex = 4
        btnCariList.Text = "4. Pencarian dengan Perulangan"
        btnCariList.UseVisualStyleBackColor = True
        ' 
        ' FrmUtama
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCariList)
        Controls.Add(btnDataTable)
        Controls.Add(btnDariList)
        Controls.Add(btnDariArray)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmUtama"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pertemuan 8 - DataGridView, Array & Koleksi Data"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnDariArray As Button
    Friend WithEvents btnDariList As Button
    Friend WithEvents btnDataTable As Button
    Friend WithEvents btnCariList As Button

End Class
