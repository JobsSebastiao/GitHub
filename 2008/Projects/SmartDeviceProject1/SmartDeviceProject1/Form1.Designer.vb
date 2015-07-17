<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.pnFrmMain = New System.Windows.Forms.Panel
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.pnFrmMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnFrmMain
        '
        Me.pnFrmMain.Controls.Add(Me.txt1)
        Me.pnFrmMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnFrmMain.Location = New System.Drawing.Point(0, 0)
        Me.pnFrmMain.Name = "pnFrmMain"
        Me.pnFrmMain.Size = New System.Drawing.Size(638, 455)
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(0, 3)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(100, 23)
        Me.txt1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.pnFrmMain)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnFrmMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnFrmMain As System.Windows.Forms.Panel
    Friend WithEvents txt1 As System.Windows.Forms.TextBox

End Class
