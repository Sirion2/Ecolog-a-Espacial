''' <summary>
''' NAVE IMAGE CLASE IS STORES ALL NAVE REALTED THINGS
''' </summary>
Public Class Nave
    'nave images
    Private Const img_nave_UP_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_UP.png"
    Private Const img_nave_DOWN_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_DOWN.png"
    Private Const img_nave_LEFT_PATH = "..\..\..\Images\Naves\nave-1_SCALED4K_LEFT.pNg"
    Private Const img_nave_RIGHT_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_RIGHT.png"
    Private Const img_nave_UP_RIGHT_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_UP_RIGHT.png"
    Private Const img_nave_DOWN_RIGHT_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_DOWN_RIGHT.png"
    Private Const img_nave_DOWN_LEFT_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_DOWN_LEFT.png"
    Private Const img_nave_UP_LEFT_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_UP_LEFT.png"
    Private Const img_nave_LANDED_PATH = "..\..\..\Images\Naves\Nave-1_SCALED4K_LANDED.png"
    Private Const img_nave_EXPLOTION = "..\..\..\Images\Explosiones\nave-1_SCALED4K_EXPLOTION.gif"

    'health images
    Private Const img_vida_0 = "..\..\..\Images\UI\salud-0_SACLED4K.png"
    Private Const img_vida_1 = "..\..\..\Images\UI\salud-1_SACLED4K.png"
    Private Const img_vida_2 = "..\..\..\Images\UI\salud-2_SACLED4K.png"
    Private Const img_vida_3 = "..\..\..\Images\UI\salud-3_SACLED4K.png"
    Private Const img_vida_4 = "..\..\..\Images\UI\salud-4_SACLED4K.png"
    Private Const img_vida_5 = "..\..\..\Images\UI\salud-5_SACLED4K.png"

    'cargo images
    Private Const img_carga_0 = "..\..\..\Images\UI\carga-0_SCALED4K.png"
    Private Const img_carga_1 = "..\..\..\Images\UI\carga-1_SCALED4K.png"
    Private Const img_carga_2 = "..\..\..\Images\UI\carga-2_SCALED4K.png"
    Private Const img_carga_3 = "..\..\..\Images\UI\carga-3_SCALED4K.png"

    Private _naveImage As PictureBox
    Private _vidaImage As PictureBox
    Private _cargaImage As PictureBox

    Private screen_height = Screen.PrimaryScreen.WorkingArea.Height
    Private screen_width = Screen.PrimaryScreen.WorkingArea.Width

    Private nave_sizeW = 72
    Private nave_sizeH = 72
    Private start_posX = (screen_width / 2) - (nave_sizeW / 2)
    Private start_posY = (screen_height / 2) - (nave_sizeH / 2)

    Public Sub New()
        naveImage = New PictureBox()
        naveImage.Size = New Size(nave_sizeW, nave_sizeH)
        naveImage.Location = New Point(start_posX, start_posY)
        naveImage.Image = Image.FromFile(img_nave_UP_PATH)
        naveImage.Padding = New Padding(0)
        naveImage.BorderStyle = BorderStyle.None
        naveImage.SizeMode = PictureBoxSizeMode.StretchImage
        naveImage.BackColor = Color.Transparent

        vidaImage = New PictureBox()
        vidaImage.Image = Image.FromFile(img_vida_5)
        vidaImage.Size = New Size(156, 26)
        vidaImage.Location = New Point(0, 36)
        vidaImage.SizeMode = PictureBoxSizeMode.StretchImage
        vidaImage.BackColor = Color.Black

        cargaImage = New PictureBox()
        cargaImage.Image = Image.FromFile(img_carga_0)
        cargaImage.Size = New Size(156, 36)
        cargaImage.Location = New Point(0, 98)
        cargaImage.SizeMode = PictureBoxSizeMode.StretchImage
        cargaImage.BackColor = Color.Black
    End Sub

    Public Sub move()
        '--- SPEED CONTROL ---
        speed_control()
        '--- FRAME COLITION VALIDATION ---
        frame_colition_val()
        '--- UPDATE ---
        update()

        '--- MOVE ---
        If diry < 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_UP_PATH)
        ElseIf diry > 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_DOWN_PATH)
        ElseIf dirx < 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_LEFT_PATH)
        ElseIf dirx > 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_RIGHT_PATH)
        End If

        '--- ADITIONAL DIAGONAL MOVE ---
        If dirx > 0 And diry < 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_UP_RIGHT_PATH)
        ElseIf dirx < 0 And diry < 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_UP_LEFT_PATH)
        ElseIf dirx < 0 And diry > 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_DOWN_LEFT_PATH)
        ElseIf dirx > 0 And diry > 0 Then
            redraw()
            naveImage.Image = Image.FromFile(img_nave_DOWN_RIGHT_PATH)
        End If

        naveImage.Location = New Point(xpos + dirx, ypos + diry)
    End Sub

    Public Sub explode(x, y)
        redraw()
        naveImage.Image = Image.FromFile(img_nave_EXPLOTION)
        naveImage.Location = New Point(x, y)
    End Sub

    Public Sub respawn()
        dirx = 0
        diry = 0
        naveImage.Location = New Point(start_posX, start_posY)
    End Sub

    Public Sub landed(b_ypos, b_dirx)
        dirx = 0
        diry = 0
        redraw()
        naveImage.Image = Image.FromFile(img_nave_LANDED_PATH)
        If (xpos + b_dirx >= Form1.Width - naveImage.Width - 10) Then
            dirx = b_dirx
            diry = -15
        End If
        naveImage.Location = New Point(xpos + b_dirx, b_ypos - 48 - 24)
    End Sub

    Public Sub health_state()
        'Debug.Print(vida)
        Select Case vida
            Case 5
                vidaImage.Image = Image.FromFile(img_vida_5)
            Case 4
                vidaImage.Image = Image.FromFile(img_vida_4)
            Case 3
                vidaImage.Image = Image.FromFile(img_vida_3)
            Case 2
                vidaImage.Image = Image.FromFile(img_vida_2)
            Case 1
                vidaImage.Image = Image.FromFile(img_vida_1)
            Case 0
                vidaImage.Image = Image.FromFile(img_vida_5)
                'Debug.Print("perdiste")
        End Select
    End Sub

    Public Sub cargo_state()
        Select Case carga
            Case 0
                cargaImage.Image = Image.FromFile(img_carga_0)
            Case 1
                cargaImage.Image = Image.FromFile(img_carga_1)
            Case 2
                cargaImage.Image = Image.FromFile(img_carga_2)
            Case 3
                cargaImage.Image = Image.FromFile(img_carga_3)
        End Select
    End Sub

    Public Sub speed_control()
        'pos its refered to the direction
        'dir its refered for speed

        If dirx > 50 Then
            dirx = 50
        ElseIf dirx < -50 Then
            dirx = -50
        End If

        If diry > 50 Then
            diry = 50
        ElseIf diry < -50 Then
            diry = -50
        End If
        'useful debug print down here
        'Debug.Print("velocidad x:" & dirx & "velocidad y:" & diry)
    End Sub

    Public Sub frame_colition_val()
        '--- BOUNCE X ---
        If xpos <= 0 Or xpos >= Form1.Width - naveImage.Width - 10 Then
            dirx = -dirx
        End If

        '--- BOUNCE Y ---
        If ypos <= 0 Or ypos >= Form1.Height - naveImage.Height - 30 Then
            diry = -diry
        End If
    End Sub

    Public Sub redraw() ' <--- deleting every image drawn on event change it saves memory trust me :/
        naveImage.Image.Dispose()
    End Sub

    Public Sub update() ' <--- updating for smoohtness
        naveImage.Update()
    End Sub

    Public Property naveImage() As PictureBox
        Get
            Return _naveImage
        End Get
        Set(ByVal value As PictureBox)
            _naveImage = value
        End Set
    End Property

    Public Property vidaImage() As PictureBox
        Get
            Return _vidaImage
        End Get

        Set(ByVal value As PictureBox)
            _vidaImage = value
        End Set
    End Property
    Public Property cargaImage() As PictureBox
        Get
            Return _cargaImage
        End Get

        Set(ByVal value As PictureBox)
            _cargaImage = value
        End Set
    End Property

    Private _x As Integer
    Public Property xpos() As Integer
        Get
            Return naveImage.Location.X
        End Get
        Set(ByVal value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer
    Public Property ypos() As Integer
        Get
            Return naveImage.Location.Y
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

    Private _vida As Integer = 5
    Public Property vida() As Integer
        Get
            Return _vida
        End Get
        Set(value As Integer)
            _vida = value
        End Set
    End Property

    Private _carga As Integer = 0
    Public Property carga() As Integer
        Get
            Return _carga
        End Get
        Set(value As Integer)
            _carga = value
        End Set
    End Property

    Public Property Bounds() As Rectangle
        Get
            Return naveImage.Bounds
        End Get
        Set(value As Rectangle)
            Bounds = value
        End Set
    End Property
End Class
