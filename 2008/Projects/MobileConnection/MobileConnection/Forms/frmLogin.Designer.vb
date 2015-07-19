<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmLogin
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
    Private mnuFrmLogin As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.mnuFrmLogin = New System.Windows.Forms.MainMenu
        Me.mnuLogin = New System.Windows.Forms.MenuItem
        Me.mnuSair = New System.Windows.Forms.MenuItem
        Me.pbLogin = New System.Windows.Forms.PictureBox
        Me.imgLogin = New System.Windows.Forms.ImageList
        Me.txtSenha = New System.Windows.Forms.TextBox
        Me.cbUsuario = New System.Windows.Forms.ComboBox
        Me.lbSenha = New System.Windows.Forms.Label
        Me.lbUsuario = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mnuFrmLogin
        '
        Me.mnuFrmLogin.MenuItems.Add(Me.mnuLogin)
        Me.mnuFrmLogin.MenuItems.Add(Me.mnuSair)
        '
        'mnuLogin
        '
        Me.mnuLogin.Text = "Login"
        '
        'mnuSair
        '
        Me.mnuSair.Text = "Sair"
        '
        'pbLogin
        '
        Me.pbLogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLogin.Location = New System.Drawing.Point(0, 0)
        Me.pbLogin.Name = "pbLogin"
        Me.pbLogin.Size = New System.Drawing.Size(161, 268)
        Me.imgLogin.Images.Clear()
        Me.imgLogin.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.imgLogin.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        Me.imgLogin.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
        '
        'txtSenha
        '
        Me.txtSenha.Enabled = False
        Me.txtSenha.Location = New System.Drawing.Point(75, 199)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(138, 21)
        Me.txtSenha.TabIndex = 8
        '
        'cbUsuario
        '
        Me.cbUsuario.Location = New System.Drawing.Point(75, 169)
        Me.cbUsuario.Name = "cbUsuario"
        Me.cbUsuario.Size = New System.Drawing.Size(138, 22)
        Me.cbUsuario.TabIndex = 7
        '
        'lbSenha
        '
        Me.lbSenha.BackColor = System.Drawing.Color.Transparent
        Me.lbSenha.Location = New System.Drawing.Point(25, 203)
        Me.lbSenha.Name = "lbSenha"
        Me.lbSenha.Size = New System.Drawing.Size(53, 20)
        Me.lbSenha.Text = "Senha :"
        Me.lbSenha.Visible = False
        '
        'lbUsuario
        '
        Me.lbUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lbUsuario.Location = New System.Drawing.Point(19, 169)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(55, 20)
        Me.lbUsuario.Text = "Usuário :"
        Me.lbUsuario.Visible = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(230, 266)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.cbUsuario)
        Me.Controls.Add(Me.lbSenha)
        Me.Controls.Add(Me.lbUsuario)
        Me.Controls.Add(Me.pbLogin)
        Me.Menu = Me.mnuFrmLogin
        Me.Name = "frmLogin"
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbLogin As System.Windows.Forms.PictureBox
    Friend WithEvents mnuLogin As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSair As System.Windows.Forms.MenuItem
    Friend WithEvents imgLogin As System.Windows.Forms.ImageList
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents cbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents lbSenha As System.Windows.Forms.Label
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
End Class
