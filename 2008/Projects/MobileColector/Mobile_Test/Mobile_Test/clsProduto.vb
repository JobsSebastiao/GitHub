Public Class clsProduto

    Private _codigoProduto As Integer
    Private _descricaoProduto As String
    Private _qtdProduto As Double
    Private _localProduto As String
    Private _ean13Produto As String
    Private _partNumberProduto As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal codigoProduto As Integer, ByVal produtoProduto As String, _
                   ByVal quantidadeProduto As Integer, ByVal localProduto As String, _
                   ByVal eanProduto As String, ByVal partNumberProduto As String)

        Me.Codigo = codigoProduto
        Me.Descricao = produtoProduto
        Me.Quantidade = quantidadeProduto
        Me.Local = localProduto
        Me.EanProduto = eanProduto
        Me.PartNumber = partNumberProduto

    End Sub

    Public Property Codigo()
        Get
            Return _codigoProduto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                _codigoProduto = value
            End If
        End Set
    End Property

    Public Property PartNumber()
        Get
            Return _partNumberProduto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                _partNumberProduto = value
            End If
        End Set
    End Property

    Public Property Descricao()
        Get
            Return _descricaoProduto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                _descricaoProduto = value
            End If
        End Set
    End Property

    Public Property EanProduto()
        Get
            Return _ean13Produto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                _ean13Produto = value
            End If
        End Set
    End Property

    Public Property Quantidade()
        Get
            Return _qtdProduto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                If (IsNumeric(value)) Then
                    _qtdProduto = value
                Else
                    _qtdProduto = 0.0
                End If
            End If
        End Set
    End Property

    Public Property Local()
        Get
            Return _localProduto
        End Get
        Set(ByVal value)
            If (value <> Nothing) Then
                _localProduto = value
            End If
        End Set
    End Property


    Public Overrides Function ToString() As String

        Return Me.Codigo & "|" & Me.Descricao & "|" & Me.Quantidade & "|" & Me.Local & "|" & Me.EanProduto & "|" & Me.PartNumber & Environment.NewLine

    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean

        If obj Is Nothing OrElse Not TypeOf obj Is clsProduto Then
            Return False
        Else
            Return _partNumberProduto = CType(obj, clsProduto)._partNumberProduto
        End If

    End Function

    Public Overrides Function GetHashCode() As Integer
        Return New With { _
        Key .A = _codigoProduto, _
        Key .B = _partNumberProduto}.GetHashCode()
    End Function

End Class
