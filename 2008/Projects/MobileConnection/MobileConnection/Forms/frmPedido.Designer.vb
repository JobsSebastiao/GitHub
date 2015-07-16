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
        Me.txtTransportadora = New System.Windows.Forms.TextBox
        Me.lbTranportadora = New System.Windows.Forms.Label
        Me.lbPedido = New System.Windows.Forms.Label
        Me.cbCodigoPedido = New System.Windows.Forms.ComboBox
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
        'txtTransportadora
        '
        Me.txtTransportadora.Location = New System.Drawing.Point(4, 88)
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(233, 21)
        Me.txtTransportadora.TabIndex = 3
        '
        'lbTranportadora
        '
        Me.lbTranportadora.Location = New System.Drawing.Point(7, 73)
        Me.lbTranportadora.Name = "lbTranportadora"
        Me.lbTranportadora.Size = New System.Drawing.Size(100, 20)
        Me.lbTranportadora.Text = "Transportadora"
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
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.cbCodigoPedido)
        Me.Controls.Add(Me.lbPedido)
        Me.Controls.Add(Me.txtTransportadora)
        Me.Controls.Add(Me.lbTranportadora)
        Me.Controls.Add(Me.txtFornecedor)
        Me.Controls.Add(Me.lbFornecedor)
        Me.Menu = Me.mnuFrmPedidos
        Me.Name = "frmPedido"
        Me.Text = "Pedidos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbFornecedor As System.Windows.Forms.Label
    Friend WithEvents txtFornecedor As System.Windows.Forms.TextBox
    Friend WithEvents txtTransportadora As System.Windows.Forms.TextBox
    Friend WithEvents lbTranportadora As System.Windows.Forms.Label
    Friend WithEvents lbPedido As System.Windows.Forms.Label
    Friend WithEvents cbCodigoPedido As System.Windows.Forms.ComboBox
End Class
