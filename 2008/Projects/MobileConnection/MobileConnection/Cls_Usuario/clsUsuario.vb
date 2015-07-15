Public Class clsUsuario

    Private intCodigo As Integer
    Private intPasta As Integer
    Private strNome As String
    Private strSenha As String
    Private strNomeCompleto As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal codigoUsuario As Integer, ByVal pastaUsuario As Integer, ByVal nomeUsuario As String, ByVal senhaUsuario As String, ByVal nomeCompletoUsuario As String)
        Codigo = codigoUsuario
        Pasta = pastaUsuario
        Nome = nomeUsuario
        Senha = senhaUsuario
        NomeCompleto = nomeCompletoUsuario
    End Sub

    Public Property Codigo() As Integer
        Get
            Return Me.intCodigo
        End Get

        Set(ByVal value As Integer)
            Dim v As Integer = CInt(value)
            If (v <> Nothing And IsNumeric(v) And v <> Me.intCodigo) Then
                intCodigo = v
            End If
        End Set

    End Property

    Public Property Pasta() As Integer
        Get
            Return intPasta
        End Get

        Set(ByVal value As Integer)
            If (value <> Nothing And IsNumeric(value) And value <> Me.intPasta) Then
                intPasta = value
            End If
        End Set

    End Property

    Public Property Nome() As String
        Get
            Return strNome
        End Get

        Set(ByVal value As String)
            If (value <> Nothing And Trim(value) <> Trim(Me.strNome)) Then
                strNome = Trim(value)
            End If
        End Set

    End Property

    Public Property Senha() As String
        Get
            Return strSenha
        End Get

        Set(ByVal value As String)
            If (value <> Nothing And Trim(value) <> Trim(Me.strSenha)) Then
                strSenha = Trim(value)
            End If
        End Set

    End Property

    Public Property NomeCompleto() As String

        Get
            Return strNomeCompleto
        End Get

        Set(ByVal value As String)
            If (value <> Nothing And Trim(value) <> Trim(Me.strNomeCompleto)) Then
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

    Enum usuarioPropety
        Codigo = 1
        Pasta = 2
        Nome = 3
        Senha = 4
        NomeCompleto = 5
    End Enum

End Class
