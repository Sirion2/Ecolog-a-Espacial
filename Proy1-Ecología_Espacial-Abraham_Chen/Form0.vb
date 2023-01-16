Imports System.Diagnostics.CodeAnalysis
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form0
    Private Sub Form0_Load(Sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.startButton.FlatStyle = FlatStyle.Flat
        Me.startButton.FlatAppearance.BorderColor = Color.Black
        Me.startButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 18, 18)
        Me.startButton.Location = New Point(Me.Width - 200, Me.Height - 100)
        Me.startButton.ForeColor = Color.White
        Me.startButton.BackColor = Color.Black
        Me.startButton.Font = New Font("Segoe U", 10, FontStyle.Bold)
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        Form1.Show()
        Me.Close()
        Form2.Close()
    End Sub
End Class