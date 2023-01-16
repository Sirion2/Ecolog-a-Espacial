''' <summary>
''' ASTEROIDE IMAGE CLASE IS STORES ALL ASTEROIDE REALTED THINGS
''' </summary>
Public Class Asteroide
    Private Const img_asteroide_1_PATH = "..\..\..\Images\Asteroides\Asteroide-1_SCALED4K.png"
    Private _asteroideImage As PictureBox
    Private rnd As New Random()

    Dim screen_height = Screen.PrimaryScreen.WorkingArea.Height
    Dim screen_width = Screen.PrimaryScreen.WorkingArea.Width

    Dim asteroide_sizeW = 144
    Dim asteroide_sizeH = 144
    Dim start_posX = rnd.Next(screen_width) ' random
    Dim start_posY = rnd.Next(screen_height) ' random

    Public Sub New()
        dirx = 10
        diry = 10
        asteroideImage = New PictureBox()
        asteroideImage.Size = New Size(asteroide_sizeW, asteroide_sizeH)
        asteroideImage.Image = Image.FromFile(img_asteroide_1_PATH)
        asteroideImage.Padding = New Padding(0)
        asteroideImage.BorderStyle = BorderStyle.None
        asteroideImage.SizeMode = PictureBoxSizeMode.StretchImage
        asteroideImage.Location = New Point(start_posX, start_posY)
        asteroideImage.BackColor = Color.Transparent
        asteroideImage.Visible = False
    End Sub

    Public Sub move()
        '--- SPEED CONTROL ---
        speed_control()
        '--- FRAME COLITION VALIDATION ---
        frame_colition_val()
        '--- UPDATE ---
        update()

        If ypos + diry >= screen_height - asteroide_sizeH Then
            dirx = 10
            diry = -10
        End If

        If xpos + dirx >= screen_width - asteroide_sizeW Then
            dirx = -10
            diry = 10
        End If
        asteroideImage.Location = New Point(xpos + dirx, ypos + diry)
    End Sub

    Public Sub frame_colition_val()
        '--- BOUNCE X ---
        If xpos <= 0 Or xpos >= Form1.Width - asteroideImage.Width - 10 Then
            dirx = -dirx
        End If

        '--- BOUNCE Y ---
        If ypos <= 0 Or ypos >= Form1.Height - asteroideImage.Height - 20 Then
            diry = -diry
        End If
    End Sub

    Public Sub speed_control()
        'pos its refered to the direction
        'dir its refered for speed
        If dirx > 10 Then
            dirx = -10
        ElseIf dirx < -10 Then
            dirx = -10
        End If
        If diry > 10 Then
            diry = -10
        ElseIf diry < -10 Then
            diry = -10
        End If
        'useful debug print down here
        'Debug.Print("velocidad x:" & dirx & "velocidad y:" & diry)
    End Sub

    Public Sub update() ' <--- updating for smoohtness
        asteroideImage.Invalidate()
    End Sub

    Public Property asteroideImage() As PictureBox
        Get
            Return _asteroideImage
        End Get
        Set(value As PictureBox)
            _asteroideImage = value
        End Set
    End Property

    Private _x As Integer
    Public Property xpos() As Integer
        Get
            Return asteroideImage.Location.X
        End Get
        Set(value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer
    Public Property ypos() As Integer
        Get
            Return asteroideImage.Location.Y
        End Get
        Set(value As Integer)
            _y = value
        End Set
    End Property

    Private _dirx As Integer
    Public Property dirx() As Integer
        Get
            Return _dirx
        End Get
        Set(ByVal value As Integer)
            _dirx = value
        End Set
    End Property

    Private _diry As Integer
    Public Property diry() As Integer
        Get
            Return _diry
        End Get
        Set(ByVal value As Integer)
            _diry = value
        End Set
    End Property
    Public Property Bounds() As Rectangle
        Get
            Return asteroideImage.Bounds
        End Get
        Set(value As Rectangle)
            Bounds = value
        End Set
    End Property
End Class
