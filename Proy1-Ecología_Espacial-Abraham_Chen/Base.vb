''' <summary>
''' bASE iMAGE CLASE IS STORES ALL BASE REALTED THINGS
''' </summary>
Public Class Base
    Private Const img_base_PATH = "..\..\..\Images\Bases\base-1_SCALED4K.gif"

    Private _baseImage As PictureBox

    Dim screen_height = Screen.PrimaryScreen.WorkingArea.Height
    Dim screen_width = Screen.PrimaryScreen.WorkingArea.Width

    Dim base_sizeW = 219
    Dim base_sizeH = 48
    Dim start_posX = (screen_width / 2) - (base_sizeW / 2)
    Dim start_posY = screen_height - base_sizeH * 2

    Public Sub New()
        baseImage = New PictureBox()
        baseImage.Size = New Size(base_sizeW, base_sizeH)
        baseImage.Location = New Point(start_posX, start_posY)
        baseImage.Image = Image.FromFile(img_base_PATH)
        baseImage.Padding = New Padding(0)
        baseImage.BorderStyle = BorderStyle.None
        baseImage.SizeMode = PictureBoxSizeMode.StretchImage
        baseImage.BackColor = Color.Transparent
    End Sub
    Public Sub move()

        '--- SPEED CONTROL ---
        speed_control()

        '--- NAVE UPDATE ---
        update()

        '--- MOVE ---
        If xpos >= Form1.Width + baseImage.Width - 10 Then
            baseImage.Location = New Point(0, ypos + diry)
        End If
        baseImage.Location = New Point(xpos + dirx, ypos + diry)
    End Sub

    Public Sub speed_control() ' <-- This is not necessary but to keep code homogeneous
        dirx = 10
        diry = 0
    End Sub

    Public Sub update() ' <--- updating for smoohtness
        baseImage.Update()
    End Sub

    Public Property baseImage() As PictureBox
        Get
            Return _baseImage
        End Get

        Set(value As PictureBox)
            _baseImage = value
        End Set
    End Property

    Private _x As Integer
    Public Property xpos() As Integer
        Get
            Return baseImage.Location.X
        End Get
        Set(value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer
    Public Property ypos() As Integer
        Get
            Return baseImage.Location.Y
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
        Set(value As Integer)
            _dirx = value
        End Set
    End Property

    Private _diry As Integer
    Public Property diry() As Integer
        Get
            Return _diry
        End Get
        Set(value As Integer)
            _diry = value
        End Set
    End Property

    Public Property Bounds() As Rectangle
        Get
            Return baseImage.Bounds
        End Get
        Set(value As Rectangle)
            Bounds = value
        End Set
    End Property
End Class
