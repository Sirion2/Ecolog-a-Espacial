<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.backImage = New System.Windows.Forms.PictureBox()
        Me.playButton = New System.Windows.Forms.Button()
        Me.exitButton = New System.Windows.Forms.Button()
        CType(Me.backImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'backImage
        '
        Me.backImage.BackgroundImage = CType(resources.GetObject("backImage.BackgroundImage"), System.Drawing.Image)
        Me.backImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.backImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.backImage.Location = New System.Drawing.Point(0, 0)
        Me.backImage.Name = "backImage"
        Me.backImage.Size = New System.Drawing.Size(800, 450)
        Me.backImage.TabIndex = 0
        Me.backImage.TabStop = False
        '
        'playButton
        '
        Me.playButton.Location = New System.Drawing.Point(318, 215)
        Me.playButton.Name = "playButton"
        Me.playButton.Size = New System.Drawing.Size(164, 45)
        Me.playButton.TabIndex = 1
        Me.playButton.Text = "Play Again"
        Me.playButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(318, 283)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(164, 45)
        Me.exitButton.TabIndex = 2
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.playButton)
        Me.Controls.Add(Me.backImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MdiChildrenMinimizedAnchorBottom = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ecologia Espacial - Abraham Chen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.backImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents backImage As PictureBox
    Friend WithEvents playButton As Button
    Friend WithEvents exitButton As Button
End Class
