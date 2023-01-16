<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.fuelLabel = New System.Windows.Forms.Label()
        Me.fuelPgrBar = New System.Windows.Forms.ProgressBar()
        Me.cagoLabel = New System.Windows.Forms.Label()
        Me.healthLabel = New System.Windows.Forms.Label()
        Me.tmr_Move = New System.Windows.Forms.Timer(Me.components)
        Me.scoreLabel = New System.Windows.Forms.Label()
        Me.levelLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.levelcvLabel = New System.Windows.Forms.Label()
        Me.scorecv_Label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fuelLabel
        '
        Me.fuelLabel.AutoSize = True
        Me.fuelLabel.Location = New System.Drawing.Point(1, 59)
        Me.fuelLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.fuelLabel.Name = "fuelLabel"
        Me.fuelLabel.Size = New System.Drawing.Size(59, 15)
        Me.fuelLabel.TabIndex = 0
        Me.fuelLabel.Text = "Fuel Level"
        '
        'fuelPgrBar
        '
        Me.fuelPgrBar.ForeColor = System.Drawing.Color.DarkOrange
        Me.fuelPgrBar.Location = New System.Drawing.Point(1, 78)
        Me.fuelPgrBar.Margin = New System.Windows.Forms.Padding(2)
        Me.fuelPgrBar.Maximum = 400
        Me.fuelPgrBar.Name = "fuelPgrBar"
        Me.fuelPgrBar.Size = New System.Drawing.Size(100, 23)
        Me.fuelPgrBar.TabIndex = 1
        Me.fuelPgrBar.Value = 400
        '
        'cagoLabel
        '
        Me.cagoLabel.AutoSize = True
        Me.cagoLabel.Location = New System.Drawing.Point(1, 43)
        Me.cagoLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cagoLabel.Name = "cagoLabel"
        Me.cagoLabel.Size = New System.Drawing.Size(88, 15)
        Me.cagoLabel.TabIndex = 2
        Me.cagoLabel.Text = "Cargo Capacity"
        '
        'healthLabel
        '
        Me.healthLabel.AutoSize = True
        Me.healthLabel.Location = New System.Drawing.Point(1, 26)
        Me.healthLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.healthLabel.Name = "healthLabel"
        Me.healthLabel.Size = New System.Drawing.Size(62, 15)
        Me.healthLabel.TabIndex = 3
        Me.healthLabel.Text = "Life Points"
        '
        'tmr_Move
        '
        Me.tmr_Move.Enabled = True
        '
        'scoreLabel
        '
        Me.scoreLabel.AutoSize = True
        Me.scoreLabel.Location = New System.Drawing.Point(1, 153)
        Me.scoreLabel.Name = "scoreLabel"
        Me.scoreLabel.Size = New System.Drawing.Size(36, 15)
        Me.scoreLabel.TabIndex = 9
        Me.scoreLabel.Text = "Score"
        '
        'levelLabel
        '
        Me.levelLabel.AutoSize = True
        Me.levelLabel.Location = New System.Drawing.Point(1, 123)
        Me.levelLabel.Name = "levelLabel"
        Me.levelLabel.Size = New System.Drawing.Size(34, 15)
        Me.levelLabel.TabIndex = 8
        Me.levelLabel.Text = "Level"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'levelcvLabel
        '
        Me.levelcvLabel.AutoSize = True
        Me.levelcvLabel.Location = New System.Drawing.Point(1, 138)
        Me.levelcvLabel.Name = "levelcvLabel"
        Me.levelcvLabel.Size = New System.Drawing.Size(77, 15)
        Me.levelcvLabel.TabIndex = 12
        Me.levelcvLabel.Text = "Current Level"
        '
        'scorecv_Label
        '
        Me.scorecv_Label.AutoSize = True
        Me.scorecv_Label.Location = New System.Drawing.Point(1, 168)
        Me.scorecv_Label.Name = "scorecv_Label"
        Me.scorecv_Label.Size = New System.Drawing.Size(79, 15)
        Me.scorecv_Label.TabIndex = 14
        Me.scorecv_Label.Text = "Current Score"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(624, 437)
        Me.Controls.Add(Me.scorecv_Label)
        Me.Controls.Add(Me.levelcvLabel)
        Me.Controls.Add(Me.scoreLabel)
        Me.Controls.Add(Me.levelLabel)
        Me.Controls.Add(Me.healthLabel)
        Me.Controls.Add(Me.cagoLabel)
        Me.Controls.Add(Me.fuelPgrBar)
        Me.Controls.Add(Me.fuelLabel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MdiChildrenMinimizedAnchorBottom = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ecologia Espacial - Abraham Chen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fuelLabel As Label
    Friend WithEvents fuelPgrBar As ProgressBar
    Friend WithEvents cargoLabel As Label
    Friend WithEvents cagoLabel As Label
    Friend WithEvents healthLabel As Label
    Friend WithEvents tmr_Move As Timer
    Friend WithEvents scoreLabel As Label
    Friend WithEvents levelLabel As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents levelcvLabel As Label
    Friend WithEvents scorecv_Label As Label
End Class
