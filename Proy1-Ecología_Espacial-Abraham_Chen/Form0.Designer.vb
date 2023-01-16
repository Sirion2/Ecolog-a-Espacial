<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form0
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form0))
        Me.frontImage = New System.Windows.Forms.PictureBox()
        Me.startButton = New System.Windows.Forms.Button()
        CType(Me.frontImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frontImage
        '
        Me.frontImage.BackgroundImage = CType(resources.GetObject("frontImage.BackgroundImage"), System.Drawing.Image)
        Me.frontImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.frontImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frontImage.Location = New System.Drawing.Point(0, 0)
        Me.frontImage.Name = "frontImage"
        Me.frontImage.Size = New System.Drawing.Size(800, 450)
        Me.frontImage.TabIndex = 0
        Me.frontImage.TabStop = False
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(220, 313)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(164, 45)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "START"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Form0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.frontImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ecologia Espacial - Abraham Chen"
        CType(Me.frontImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents frontImage As PictureBox
    Friend WithEvents startButton As Button
End Class
