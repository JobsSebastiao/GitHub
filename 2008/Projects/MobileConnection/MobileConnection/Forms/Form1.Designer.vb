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
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.dgPrincipal = New System.Windows.Forms.DataGrid
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem5)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem7)
        Me.MenuItem1.Text = "Menu"
        '
        'MenuItem2
        '
        Me.MenuItem2.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem2.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem2.MenuItems.Add(Me.MenuItem6)
        Me.MenuItem2.Text = "DataBase"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Create"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "TestConection"
        '
        'MenuItem6
        '
        Me.MenuItem6.Text = "Carrega"
        '
        'MenuItem7
        '
        Me.MenuItem7.Text = "Pedidos"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "OpenConn"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "Criar Data Base :"
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(4, 25)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(233, 21)
        Me.txtDBName.TabIndex = 1
        '
        'dgPrincipal
        '
        Me.dgPrincipal.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgPrincipal.Location = New System.Drawing.Point(4, 53)
        Me.dgPrincipal.Name = "dgPrincipal"
        Me.dgPrincipal.Size = New System.Drawing.Size(233, 160)
        Me.dgPrincipal.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.dgPrincipal)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents dgPrincipal As System.Windows.Forms.DataGrid
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem

End Class
