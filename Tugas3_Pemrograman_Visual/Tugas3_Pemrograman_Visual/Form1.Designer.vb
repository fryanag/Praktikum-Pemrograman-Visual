<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        lblSubtotal = New Label()
        lblDiskon = New Label()
        lblTotal = New Label()
        chkMember = New CheckBox()
        btnHitung = New Button()
        txtBerat = New TextBox()
        lblBerat = New Label()
        lblST = New Label()
        lblD = New Label()
        lblT = New Label()
        SuspendLayout()
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(102, 342)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(39, 20)
        lblSubtotal.TabIndex = 0
        lblSubtotal.Text = "Rp 0"
        ' 
        ' lblDiskon
        ' 
        lblDiskon.AutoSize = True
        lblDiskon.Location = New Point(352, 342)
        lblDiskon.Name = "lblDiskon"
        lblDiskon.Size = New Size(29, 20)
        lblDiskon.TabIndex = 1
        lblDiskon.Text = "0%"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(598, 342)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(39, 20)
        lblTotal.TabIndex = 2
        lblTotal.Text = "Rp 0"
        ' 
        ' chkMember
        ' 
        chkMember.AutoSize = True
        chkMember.Location = New Point(260, 158)
        chkMember.Name = "chkMember"
        chkMember.Size = New Size(130, 24)
        chkMember.TabIndex = 3
        chkMember.Text = "Punya Member"
        chkMember.UseVisualStyleBackColor = True
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(339, 226)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(94, 29)
        btnHitung.TabIndex = 4
        btnHitung.Text = "Hitung Total"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' txtBerat
        ' 
        txtBerat.Location = New Point(396, 86)
        txtBerat.Name = "txtBerat"
        txtBerat.Size = New Size(125, 27)
        txtBerat.TabIndex = 5
        ' 
        ' lblBerat
        ' 
        lblBerat.AutoSize = True
        lblBerat.Location = New Point(260, 89)
        lblBerat.Name = "lblBerat"
        lblBerat.Size = New Size(130, 20)
        lblBerat.TabIndex = 6
        lblBerat.Text = "Input Berat Kain   :"
        ' 
        ' lblST
        ' 
        lblST.AutoSize = True
        lblST.Location = New Point(102, 300)
        lblST.Name = "lblST"
        lblST.Size = New Size(71, 20)
        lblST.TabIndex = 7
        lblST.Text = "Sub Total"
        ' 
        ' lblD
        ' 
        lblD.AutoSize = True
        lblD.Location = New Point(352, 300)
        lblD.Name = "lblD"
        lblD.Size = New Size(54, 20)
        lblD.TabIndex = 8
        lblD.Text = "Diskon"
        ' 
        ' lblT
        ' 
        lblT.AutoSize = True
        lblT.Location = New Point(596, 300)
        lblT.Name = "lblT"
        lblT.Size = New Size(42, 20)
        lblT.TabIndex = 9
        lblT.Text = "Total"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        ClientSize = New Size(800, 450)
        Controls.Add(lblT)
        Controls.Add(lblD)
        Controls.Add(lblST)
        Controls.Add(lblBerat)
        Controls.Add(txtBerat)
        Controls.Add(btnHitung)
        Controls.Add(chkMember)
        Controls.Add(lblTotal)
        Controls.Add(lblDiskon)
        Controls.Add(lblSubtotal)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblDiskon As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents chkMember As CheckBox
    Friend WithEvents btnHitung As Button
    Friend WithEvents txtBerat As TextBox
    Friend WithEvents lblBerat As Label
    Friend WithEvents lblST As Label
    Friend WithEvents lblD As Label
    Friend WithEvents lblT As Label

End Class
