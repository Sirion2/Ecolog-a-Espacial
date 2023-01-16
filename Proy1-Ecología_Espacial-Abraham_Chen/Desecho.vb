''' <summary>
''' DESECHO IMAGE CLASE IS STORES ALL DESECHO REALTED THINGS
''' </summary>
Public Class Desecho
    Private Const img_desecho_1_PATH = "..\..\..\Images\Desechos\desecho-1_SCALED4K.png"
    Private _desechoImage As PictureBox
    Private rnd As New Random()

    Private screen_height = Screen.PrimaryScreen.WorkingArea.Height
    Private screen_width = Screen.PrimaryScreen.WorkingArea.Width

    Private desecho_sizeW = 24
    Private desecho_sizeH = 24
    Private start_posX = rnd.Next(screen_width) ' random
    Private start_posY = rnd.Next(screen_height) ' random

    Public Sub New()
        dirx = 10
        diry = 10
        desechoImage = New PictureBox()
        desechoImage.Size = New Size(desecho_sizeW, desecho_sizeH)
        desechoImage.Image = Image.FromFile(img_desecho_1_PATH)
        desechoImage.Padding = New Padding(0)
        desechoImage.BorderStyle = BorderStyle.None
        desechoImage.SizeMode = PictureBoxSizeMode.StretchImage
        desechoImage.Location = New Point(start_posX, start_posY)
        desechoImage.BackColor = Color.Transparent
        desechoImage.Visible = False
    End Sub


    Public Sub move()
        '--- SPEED CONTROL ---
        speed_control()
        '--- FRAME COLITION VALIDATION ---
        frame_colition_val()
        '--- UPDATE ---
        update()

        If ypos + diry >= screen_height - desecho_sizeH Then
            dirx = 10
            diry = -10
        End If

        If xpos + dirx >= screen_width - desecho_sizeW Then
            dirx = -10
            diry = 10
        End If
        desechoImage.Location = New Point(xpos + dirx, ypos + diry)
    End Sub

    Public Sub frame_colition_val()
        ''--- BOUNCE X ---
        If xpos <= 0 Or xpos >= Form1.Width - desechoImage.Width - 10 Then
            dirx = -dirx
        End If

        '--- BOUNCE Y ---
        If ypos <= 0 Or ypos >= Form1.Height - desechoImage.Height - 20 Then
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
        desechoImage.Invalidate()
    End Sub

    Public Property desechoImage() As PictureBox
        Get
            Return _desechoImage
        End Get
        Set(value As PictureBox)
            _desechoImage = value
        End Set
    End Property

    Private _x As Integer
    Public Property xpos() As Integer
        Get
            Return _desechoImage.Location.X
        End Get
        Set(ByVal value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer
    Public Property ypos() As Integer
        Get
            Return _desechoImage.Location.Y
        End Get
        Set(ByVal value As Integer)
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
            Return desechoImage.Bounds
        End Get
        Set(value As Rectangle)
            Bounds = value
        End Set
    End Property
End Class
