<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPedido
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
    Private mnuFrmPedidos As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuFrmPedidos = New System.Windows.Forms.MainMenu
        Me.lbFornecedor = New System.Windows.Forms.Label
        Me.txtFornecedor = New System.Windows.Forms.TextBox
        Me.lbPedido = New System.Windows.Forms.Label
        Me.cbCodigoPedido = New System.Windows.Forms.ComboBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.SuspendLayout()
        '
        'lbFornecedor
        '
        Me.lbFornecedor.Location = New System.Drawing.Point(7, 36)
        Me.lbFornecedor.Name = "lbFornecedor"
        Me.lbFornecedor.Size = New System.Drawing.Size(100, 24)
        Me.lbFornecedor.Text = "Fornecedor"
        '
        'txtFornecedor
        '
        Me.txtFornecedor.Location = New System.Drawing.Point(4, 52)
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(233, 21)
        Me.txtFornecedor.TabIndex = 1
        '
        'lbPedido
        '
        Me.lbPedido.Location = New System.Drawing.Point(7, 1)
        Me.lbPedido.Name = "lbPedido"
        Me.lbPedido.Size = New System.Drawing.Size(100, 16)
        Me.lbPedido.Text = "Pedido Nº"
        '
        'cbCodigoPedido
        '
        Me.cbCodigoPedido.Location = New System.Drawing.Point(4, 16)
        Me.cbCodigoPedido.Name = "cbCodigoPedido"
        Me.cbCodigoPedido.Size = New System.Drawing.Size(100, 22)
        Me.cbCodigoPedido.TabIndex = 8
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGrid1.Location = New System.Drawing.Point(3, 80)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(234, 185)
        Me.DataGrid1.TabIndex = 12
        '
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.cbCodigoPedido)
        Me.Controls.Add(Me.lbPedido)
        Me.Controls.Add(Me.txtFornecedor)
        Me.Controls.Add(Me.lbFornecedor)
        Me.Menu = Me.mnuFrmPedidos
        Me.Name = "frmPedido"
        Me.Text = "Pedidos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbFornecedor As System.Windows.Forms.Label
    Friend WithEvents txtFornecedor As System.Windows.Forms.TextBox
    Friend WithEvents lbPedido As System.Windows.Forms.Label
    Friend WithEvents cbCodigoPedido As System.Windows.Forms.ComboBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
End Class
