Public Class clsUsuario

    Private intCodigo As Integer
    Private intPasta As Integer
    Private strNome As String
    Private strSenha As String
    Private strNomeCompleto As String

    Public Property Codigo() As Integer
        Get
            Return Me.intCodigo
        End Get

        Set(ByVal value As Integer)
            If (value <> "" And IsNumeric(value) And value <> Me.intCodigo) Then
                intCodigo = value
            End If
        End Set

    End Property

    Public Property Pasta() As Integer
        Get
            Return intPasta
        End Get

        Set(ByVal value As Integer)
            If (value <> "" And IsNumeric(value) And value <> Me.intPasta) Then
                intPasta = value
            End If
        End Set

    End Property

    Public Property Nome() As String
        Get
            Return strNome
        End Get

        Set(ByVal value As String)
            If (value <> "" And Trim(value) <> Trim(Me.strNome)) Then
                strNome = Trim(value)
            End If
        End Set

    End Property

    Public Property Senha() As String
        Get
            Return strSenha
        End Get

        Set(ByVal value As String)
            If (value <> "" And Trim(value) <> Trim(Me.strSenha)) Then
                strSenha = Trim(value)
            End If
        End Set

    End Property

    Public Property NomeCompleto() As String

        Get
            Return strNomeCompleto
        End Get

        Set(ByVal value As String)
            If (value <> "" And Trim(value) <> Trim(Me.strNomeCompleto)) Then
                strNomeCompleto = Trim(value)
            End If
        End Set

    End Property

    Public Overrides Function ToString() As String

        Return "Código : " & Codigo() + vbCrLf + _
              +"Pasta :" + Pasta() + vbCrLf + _
              +"Senha : " + Senha() + vbCrLf + _
              +"Nome : " + Nome() + vbCrLf + _
              +"Nome Completo :" + NomeCompleto()

    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean

        If obj Is Nothing OrElse Not TypeOf obj Is clsUsuario Then
            Return False
        Else
            Return Codigo() = CType(obj, clsUsuario).Codigo()
        End If

    End Function

End Class
