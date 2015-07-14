Imports System.Reflection
Imports System.Data
Imports System.Text

Public Class frmLogin

    Private objUsuario As clsUsuario
    Private objSql As New clsSqlServerConn

    Private listUsuario As ArrayList
    Dim sql01 As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pbLoginConfig(pbLogin, Me, imgLogin, 2)
        carregarUsuario()
    End Sub

    Private Sub carregarUsuario()

        clsSqlServerConn.initConnection()

        Dim dt As New DataTable("Usuários")

        With strSql01
            .Append("SELECT codigoUSUARIO as Codigo,pastaUSUARIO as Pasta,nomeUSUARIO as Nome,")
            .Append("senhaUSUARIO as Senha,nomecompletoUSUARIO")
            .AppendLine()
            .Append("FROM tb0201_usuarios")
            Me.sql01 = strSql01.ToString
        End With

        FillObjects.preencheComboBox(cbUsuario, sql01, dt, "Nome")

    End Sub

End Class