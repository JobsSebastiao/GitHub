<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmAcoes
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
    Private mnuFrmAcoes As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuFrmAcoes = New System.Windows.Forms.MainMenu
        Me.mnuAcoes_Menu = New System.Windows.Forms.MenuItem
        Me.mnuAcoes_Sair = New System.Windows.Forms.MenuItem
        Me.mnuAcoes_Logout = New System.Windows.Forms.MenuItem
        Me.mnuAcoes_Ok = New System.Windows.Forms.MenuItem
        Me.lbProcedimento = New System.Windows.Forms.Label
        Me.btEntrada = New System.Windows.Forms.Button
        Me.btSaida = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mnuFrmAcoes
        '
        Me.mnuFrmAcoes.MenuItems.Add(Me.mnuAcoes_Menu)
        Me.mnuFrmAcoes.MenuItems.Add(Me.mnuAcoes_Ok)
        '
        'mnuAcoes_Menu
        '
        Me.mnuAcoes_Menu.MenuItems.Add(Me.mnuAcoes_Sair)
        Me.mnuAcoes_Menu.MenuItems.Add(Me.mnuAcoes_Logout)
        Me.mnuAcoes_Menu.Text = "Menu"
        '
        'mnuAcoes_Sair
        '
        Me.mnuAcoes_Sair.Text = "Sair"
        '
        'mnuAcoes_Logout
        '
        Me.mnuAcoes_Logout.Text = "Logout"
        '
        'mnuAcoes_Ok
        '
        Me.mnuAcoes_Ok.Text = "Ok"
        '
        'lbProcedimento
        '
        Me.lbProcedimento.BackColor = System.Drawing.Color.Transparent
        Me.lbProcedimento.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lbProcedimento.Location = New System.Drawing.Point(18, 10)
        Me.lbProcedimento.Name = "lbProcedimento"
        Me.lbProcedimento.Size = New System.Drawing.Size(196, 49)
        Me.lbProcedimento.Text = "procedimento a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " ser realizado:"
        Me.lbProcedimento.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btEntrada
        '
        Me.btEntrada.Location = New System.Drawing.Point(18, 80)
        Me.btEntrada.Name = "btEntrada"
        Me.btEntrada.Size = New System.Drawing.Size(204, 56)
        Me.btEntrada.TabIndex = 1
        Me.btEntrada.Text = "Entrada"
        '
        'btSaida
        '
        Me.btSaida.Location = New System.Drawing.Point(18, 181)
        Me.btSaida.Name = "btSaida"
        Me.btSaida.Size = New System.Drawing.Size(204, 56)
        Me.btSaida.TabIndex = 2
        Me.btSaida.Text = "Saída"
        '
        'frmAcoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.btSaida)
        Me.Controls.Add(Me.btEntrada)
        Me.Controls.Add(Me.lbProcedimento)
        Me.Menu = Me.mnuFrmAcoes
        Me.Name = "frmAcoes"
        Me.Text = "Ações"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbProcedimento As System.Windows.Forms.Label
    Friend WithEvents mnuAcoes_Menu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAcoes_Ok As System.Windows.Forms.MenuItem
    Friend WithEvents btEntrada As System.Windows.Forms.Button
    Friend WithEvents btSaida As System.Windows.Forms.Button
    Friend WithEvents mnuAcoes_Logout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAcoes_Sair As System.Windows.Forms.MenuItem
End Class
