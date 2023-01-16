''' <summary>
''' MAIN
''' </summary>
Public Class Form1
    Private Const cargo_max_load = 3
    Private Const cargo_points_value = 10

    Private fuel_remaining As Integer
    Private score As Integer
    Private level As Integer

    Private rnd As New Random()
    Private Nave_obj As Nave
    Private Base_obj As Base
    Private Asteroide_obj As Asteroide
    Private Desecho_obj As Desecho

    Public vpic_desecho(10) As Desecho
    Public vpic_asteroide(10) As Asteroide

    Private Sub Tmr_move_Tick(Sender As Object, e As EventArgs) Handles tmr_Move.Tick
        '--- Move nave ---
        Nave_obj.move()

        If fuel_remaining = 500 Then 'After 40 seconds the 'nave'  will be 10 second on dift state  
            fuel_remaining = 0
            fuelPgrBar.Value = 400
        End If
        fuel_remaining += 1

        If fuel_remaining <= fuelPgrBar.Maximum - 1 Then
            fuelPgrBar.Value -= 1
        End If

        '--- Move base ---
        Base_obj.move()

        '--- Move desecho ---
        For i = 0 To 9
            vpic_desecho(i).move()
            vpic_asteroide(i).move()
        Next

        '--- Colition val ---
        check_colition()

        '--- End game
        end_game()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 0 To 9
            If vpic_asteroide(i).asteroideImage.Visible = False Then
                vpic_asteroide(i).asteroideImage.Visible = True
                Exit For
            End If
        Next

        For i = 0 To 9
            If vpic_desecho(i).desechoImage.Visible = False Then
                vpic_desecho(i).desechoImage.Visible = True
                Exit For
            End If
        Next
    End Sub

    Public Sub New()
        InitializeComponent()

        tmr_Move.Start()
        Timer1.Start()

        Nave_obj = New Nave()
        Controls.Add(Nave_obj.cargaImage)
        Controls.Add(Nave_obj.vidaImage)
        Controls.Add(Nave_obj.naveImage)


        For i = 0 To 9
            Asteroide_obj = New Asteroide()
            vpic_asteroide(i) = Asteroide_obj
            Controls.Add(Asteroide_obj.asteroideImage)

            Desecho_obj = New Desecho()
            vpic_desecho(i) = Desecho_obj
            Controls.Add(Desecho_obj.desechoImage)
        Next

        Base_obj = New Base()
        Controls.Add(Base_obj.baseImage)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If fuel_remaining <= 400 Then
            Select Case keyData
                Case Keys.Up    '--arriba--
                    Nave_obj.diry -= 5
                Case Keys.Down  '--abajo--
                    Nave_obj.diry += 5
                Case Keys.Left  '--izquierda--
                    Nave_obj.dirx -= 5
                Case Keys.Right '--derecha--
                    Nave_obj.dirx += 5
                Case Keys.Up And Keys.Right '--diagonal drecha--
                    Nave_obj.diry -= 5
                    Nave_obj.dirx -= 5
                Case Keys.Up And Keys.Left '--diagonal izquierda--
                    Nave_obj.diry -= 5
                    Nave_obj.dirx += 5
                Case Keys.Down And Keys.Right '--diagonal abajo derecha--
                    Nave_obj.diry += 5
                    Nave_obj.dirx += 5
                Case Keys.Down And Keys.Left    '--diagonal abajo izquierda--
                    Nave_obj.diry += 5
                    Nave_obj.dirx -= 5S
            End Select
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub check_colition()
        '-- nave --> base colition resolver
        Dim nave_position_Y = Nave_obj.ypos + Nave_obj.naveImage.Height
        Dim nave_position_X = Nave_obj.xpos + Nave_obj.naveImage.Width

        Dim base_position_Y = Base_obj.ypos + Base_obj.baseImage.Height - Base_obj.baseImage.Height

        Dim base_position_Xi = Base_obj.xpos + Nave_obj.naveImage.Width - Nave_obj.naveImage.Width - 5
        Dim base_position_Xf = Base_obj.xpos + Base_obj.baseImage.Width + Nave_obj.naveImage.Width / 2 + 5

        If nave_position_Y >= base_position_Y Then
            If nave_position_X >= base_position_Xi And nave_position_X <= base_position_Xf Then
                If Nave_obj.diry > 10 Or Nave_obj.dirx > 10 Or Nave_obj.dirx < -10 Then
                    Nave_obj.explode(Nave_obj.xpos, Nave_obj.ypos - Base_obj.baseImage.Height / 4)
                    Nave_obj.respawn()
                    Nave_obj.vida -= 1
                    Nave_obj.carga = 0
                    Nave_obj.health_state()
                    Nave_obj.cargo_state()
                Else
                    If Nave_obj.carga >= cargo_max_load Then
                        score_calc()
                        level_calc()
                        Nave_obj.carga = 0
                        Nave_obj.cargo_state()
                    End If
                    Nave_obj.landed(Base_obj.ypos, Base_obj.dirx)
                End If
            End If
        End If

        '--- desechos --> base colition position resolver
        For i = 0 To 9
            Dim desecho_position_Y = vpic_desecho(i).ypos + Desecho_obj.desechoImage.Height
            Dim desecho_position_X = vpic_desecho(i).xpos + Desecho_obj.desechoImage.Width

            Dim desecho_position_Xi = vpic_desecho(i).xpos + Nave_obj.naveImage.Width - 5
            Dim desecho_position_xf = vpic_desecho(i).xpos + Desecho_obj.desechoImage.Width + Nave_obj.naveImage.Width / 2 + 5

            If desecho_position_Y >= base_position_Y Then
                If desecho_position_X >= base_position_Xi And desecho_position_X <= base_position_Xf Then
                    vpic_desecho(i).dirx = -rnd.Next(1, 968)
                    vpic_desecho(i).diry = -rnd.Next(1, 968)
                End If
            Else
                Desecho_obj.speed_control()
            End If

            '--- asteroides --> base colition resolver 
            Dim asteroide_position_Y = vpic_asteroide(i).ypos + Asteroide_obj.asteroideImage.Height
            Dim asteroide_position_X = vpic_asteroide(i).xpos + Asteroide_obj.asteroideImage.Width

            Dim asteroide_position_Xi = vpic_asteroide(i).xpos + Nave_obj.naveImage.Width - 5
            Dim asteroide_position_xf = vpic_asteroide(i).xpos + Asteroide_obj.asteroideImage.Width + Nave_obj.naveImage.Width / 2 + 5

            If asteroide_position_Y >= base_position_Y Then
                If asteroide_position_X >= base_position_Xi And desecho_position_X <= base_position_Xf Then
                    vpic_asteroide(i).dirx = -rnd.Next(1, 968)
                    vpic_asteroide(i).diry = -rnd.Next(1, 968)
                Else
                    Asteroide_obj.speed_control()
                End If
            End If

            '-- nave --> desecho recolection 
            If Nave_obj.naveImage.Bounds.IntersectsWith(vpic_desecho(i).Bounds) Then
                If vpic_desecho(i).desechoImage.Visible = True Then
                    Nave_obj.carga += 1
                    Nave_obj.cargo_state()
                    vpic_desecho(i).desechoImage.Visible = False
                End If
            End If

            '--- asteroide --> nave colition resolver
            If Nave_obj.naveImage.Bounds.IntersectsWith(vpic_asteroide(i).asteroideImage.Bounds) And vpic_asteroide(i).asteroideImage.Visible = True Then
                Nave_obj.explode(Nave_obj.xpos, Nave_obj.ypos - Base_obj.baseImage.Height / 4)
                Nave_obj.respawn()
                Nave_obj.vida -= 1
                Nave_obj.carga = 0
                Nave_obj.health_state()
                Nave_obj.cargo_state()
            End If

            For j = 0 To 9
                '-- desecho --> desecho colition resolver
                If vpic_desecho(i).desechoImage.Bounds.IntersectsWith(vpic_desecho(j).desechoImage.Bounds) Then
                    vpic_desecho(i).diry = -vpic_desecho(i).diry
                    vpic_desecho(j).diry = -vpic_desecho(j).diry
                    vpic_desecho(i).dirx = -vpic_desecho(i).diry
                    vpic_desecho(j).dirx = -vpic_desecho(j).diry
                End If

                '-- asteroide --> asteroide colition resolver
                If vpic_asteroide(i).asteroideImage.Bounds.IntersectsWith(vpic_asteroide(j).asteroideImage.Bounds) Then
                    vpic_asteroide(i).dirx = -vpic_asteroide(i).diry
                    vpic_asteroide(j).dirx = -vpic_asteroide(j).diry
                    vpic_asteroide(i).diry = -vpic_asteroide(i).diry
                    vpic_asteroide(j).diry = -vpic_asteroide(j).diry
                End If

                '-- asteroide --> desecho colition resolver
                If vpic_desecho(i).desechoImage.Bounds.IntersectsWith(vpic_asteroide(j).asteroideImage.Bounds) And vpic_asteroide(j).asteroideImage.Visible = True Then
                    vpic_desecho(i).diry = -vpic_desecho(i).diry
                    vpic_desecho(i).dirx = -vpic_desecho(i).dirx
                End If
            Next
        Next
    End Sub

    Public Sub level_calc()
        Dim level As Integer
        level = score / 100
        If level = 0 Then
            level = 1
        End If

        If level >= 2 And level <= 10 Then
            levelcvLabel.Text = level.ToString
            For i = 0 To 9
                vpic_asteroide(i).dirx = level * 10
                vpic_asteroide(i).diry = level * 10

                vpic_desecho(i).dirx = level * 10
                vpic_desecho(i).diry = level * 10
            Next
        End If
    End Sub

    Public Sub score_calc()
        score = score + cargo_max_load * cargo_points_value
        scorecv_Label.Text = score.ToString
    End Sub

    Public Sub end_game()
        If Nave_obj.vida = 0 Then
            Form2.Show()
            Me.Close()
            Nave_obj.vida = 5
        End If

        If score <> 0 Then
            score = 0
        End If

        If level <= 1 Then
            level = 0
        End If
        'Debug.Print("vida" & Nave_obj.vida)
    End Sub

    Private Sub Form1_Load(Sender As Object, e As EventArgs) Handles MyBase.Shown

        Form0.Show()
        Form2.Close()
        Me.Hide()

        Me.Timer1.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds
        Me.Timer1.Start()

        healthLabel.Text = "Life Points"
        healthLabel.AutoSize = False
        healthLabel.Size = New Size(156, 36)
        healthLabel.Location = New Point(0, 0)
        healthLabel.BackColor = Color.Black
        healthLabel.ForeColor = Color.White

        cagoLabel.Text = "Cargo Capacity"
        cagoLabel.AutoSize = False
        cagoLabel.Size = New Size(156, 36)
        cagoLabel.Location = New Point(0, 62)
        cagoLabel.BackColor = Color.Black
        cagoLabel.ForeColor = Color.White

        fuelLabel.Text = "Fuel Level"
        fuelLabel.AutoSize = False
        fuelLabel.Size = New Size(156, 36)
        fuelLabel.Location = New Point(0, 134)
        fuelLabel.BackColor = Color.Black
        fuelLabel.ForeColor = Color.White

        fuelPgrBar.Location = New Point(0, 170)
        fuelPgrBar.Size = New Size(156, 36)

        levelLabel.Text = "Level"
        levelLabel.AutoSize = False
        levelLabel.Size = New Size(40, 36)
        levelLabel.Location = New Point(0, 232)
        levelLabel.BackColor = Color.Black
        levelLabel.ForeColor = Color.White

        levelcvLabel.Text = "1"
        levelcvLabel.AutoSize = False
        levelcvLabel.TextAlign = ContentAlignment.MiddleCenter
        levelcvLabel.Size = New Size(90, 36)
        levelcvLabel.Location = New Point(40, 232)
        levelcvLabel.BackColor = Color.Black
        levelcvLabel.ForeColor = Color.White
        levelcvLabel.Font = New Font("Segoe U", 24, FontStyle.Regular)

        scoreLabel.Text = "Score"
        scoreLabel.AutoSize = False
        scoreLabel.Size = New Size(40, 36)
        scoreLabel.Location = New Point(0, 268)
        scoreLabel.BackColor = Color.Black
        scoreLabel.ForeColor = Color.White

        scorecv_Label.Text = "0"
        scorecv_Label.AutoSize = False
        levelcvLabel.TextAlign = ContentAlignment.MiddleCenter
        scorecv_Label.Size = New Size(90, 36)
        scorecv_Label.Location = New Point(40, 268)
        scorecv_Label.BackColor = Color.Black
        scorecv_Label.ForeColor = Color.White
        scorecv_Label.Font = New Font("Segoe U", 24, FontStyle.Regular)
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
End Class
