Public Class Form2

    Private Sub Form2_Load(Sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim StartPosX = (Me.Width / 2) - (Me.playButton.Width / 2)
        Dim StartPosY = (Me.Height / 2) - (Me.playButton.Height / 2)

        Me.playButton.FlatStyle = FlatStyle.Flat
        Me.playButton.FlatAppearance.BorderColor = Color.Black
        Me.playButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 18, 18)
        Me.playButton.Location = New Point(StartPosX - 200, StartPosY - 50)
        Me.playButton.ForeColor = Color.White
        Me.playButton.BackColor = Color.Black
        Me.playButton.Font = New Font("Segoe U", 10, FontStyle.Bold)

        Me.exitButton.FlatStyle = FlatStyle.Flat
        Me.exitButton.FlatAppearance.BorderColor = Color.Black
        Me.exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 18, 18)
        Me.exitButton.Location = New Point(StartPosX - 200, StartPosY)
        Me.exitButton.ForeColor = Color.White
        Me.exitButton.BackColor = Color.Black
        Me.exitButton.Font = New Font("Segoe U", 10, FontStyle.Bold)
    End Sub

    Private Sub playButton_Click(sender As Object, e As EventArgs) Handles playButton.Click
        Form0.Show()
        Me.Close()
        Form1.Close()
        Me.Close()
    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Form0.Close()
        Form1.Close()
        Me.Close()
    End Sub
End Class