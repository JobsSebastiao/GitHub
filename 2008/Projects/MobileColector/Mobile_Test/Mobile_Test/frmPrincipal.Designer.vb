<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrincipal
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
    Private mainMenuPrincipal As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenuPrincipal = New System.Windows.Forms.MainMenu
        Me.menuMenu = New System.Windows.Forms.MenuItem
        Me.menuReload = New System.Windows.Forms.MenuItem
        Me.menuGerarArquivo = New System.Windows.Forms.MenuItem
        Me.cbPedido = New System.Windows.Forms.ComboBox
        Me.dgPrincipal = New System.Windows.Forms.DataGrid
        Me.lbValor = New System.Windows.Forms.Label
        Me.lb_row = New System.Windows.Forms.Label
        Me.lbColuna = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenuPrincipal
        '
        Me.mainMenuPrincipal.MenuItems.Add(Me.menuMenu)
        '
        'menuMenu
        '
        Me.menuMenu.MenuItems.Add(Me.menuReload)
        Me.menuMenu.MenuItems.Add(Me.menuGerarArquivo)
        Me.menuMenu.Text = "Menu"
        '
        'menuReload
        '
        Me.menuReload.Text = "Reload"
        '
        'menuGerarArquivo
        '
        Me.menuGerarArquivo.Text = "Gerar Arquivo"
        '
        'cbPedido
        '
        Me.cbPedido.Location = New System.Drawing.Point(1, 3)
        Me.cbPedido.Name = "cbPedido"
        Me.cbPedido.Size = New System.Drawing.Size(233, 22)
        Me.cbPedido.TabIndex = 0
        '
        'dgPrincipal
        '
        Me.dgPrincipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPrincipal.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgPrincipal.Location = New System.Drawing.Point(0, 31)
        Me.dgPrincipal.Name = "dgPrincipal"
        Me.dgPrincipal.Size = New System.Drawing.Size(233, 122)
        Me.dgPrincipal.TabIndex = 1
        '
        'lbValor
        '
        Me.lbValor.Location = New System.Drawing.Point(0, 234)
        Me.lbValor.Name = "lbValor"
        Me.lbValor.Size = New System.Drawing.Size(233, 20)
        Me.lbValor.Text = "Valor"
        '
        'lb_row
        '
        Me.lb_row.Location = New System.Drawing.Point(0, 208)
        Me.lb_row.Name = "lb_row"
        Me.lb_row.Size = New System.Drawing.Size(233, 20)
        Me.lb_row.Text = "Linha"
        '
        'lbColuna
        '
        Me.lbColuna.Location = New System.Drawing.Point(0, 182)
        Me.lbColuna.Name = "lbColuna"
        Me.lbColuna.Size = New System.Drawing.Size(233, 20)
        Me.lbColuna.Text = "Coluna"
        '
        'lbTipo
        '
        Me.lbTipo.Location = New System.Drawing.Point(0, 156)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(233, 20)
        Me.lbTipo.Text = "Tipo"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lbTipo)
        Me.Controls.Add(Me.lbColuna)
        Me.Controls.Add(Me.lb_row)
        Me.Controls.Add(Me.lbValor)
        Me.Controls.Add(Me.dgPrincipal)
        Me.Controls.Add(Me.cbPedido)
        Me.Menu = Me.mainMenuPrincipal
        Me.Name = "frmPrincipal"
        Me.Text = "TitaniumColector"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbPedido As System.Windows.Forms.ComboBox
    Friend WithEvents dgPrincipal As System.Windows.Forms.DataGrid
    Friend WithEvents lbValor As System.Windows.Forms.Label
    Friend WithEvents lb_row As System.Windows.Forms.Label
    Friend WithEvents lbColuna As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents menuMenu As System.Windows.Forms.MenuItem
    Friend WithEvents menuReload As System.Windows.Forms.MenuItem
    Friend WithEvents menuGerarArquivo As System.Windows.Forms.MenuItem

End Class
