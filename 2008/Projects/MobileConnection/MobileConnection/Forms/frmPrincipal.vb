Imports System.Data
Imports System.Text

Public Class Form1

    Private conn As New clsConnectionCeSql()
    Private strConn As String
    Private dt As DataTable
    Public strSql01 As New StringBuilder()
    Dim sql01 As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsSqlServerConn.iniConnection()

        ''Mosta uma string de comando
        strSql01.Append("SELECT codigoUSUARIO as Cód,")
        strSql01.Append("usuarioUSUARIO as Usuário,")
        strSql01.Append("nomeUSUARIO as [Nome     ],")
        strSql01.Append("nomecompletoUSUARIO as [Nome Completo]")
        strSql01.Append("FROM tb0201_Usuarios")

        sql01 = strSql01.ToString
        dt = New DataTable("Usuários")
        FillObjects.preencheDataGrid(dt, dgPrincipal, sql01)

    End Sub


#Region "SQLCE"
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        If (txtDBName.Text <> "") Then
            conn.createBDCe(Trim(txtDBName.Text))
        Else
            MsgBox("Informe o nome para o DataBase", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Create DataBase")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        ''strConn = "data source = \Storage Card\DBMobile.sdf; Persistir Segurança Informações = False;" ''senha = tec9TIT167*45e;" ''"data source = \Temp\Dbteste.sdf"
        conn.BancoCe() = "\Storage Card\DBMobile.sdf"
        conn.PasswordCe() = "tec9TIT167*45e"
        conn.openConnCe()

        MsgBox("Conectado com sucesso!!" & vbCrLf & " Clique em Ok para desconectar!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Teste de Conexão !!!")

        conn.closeConnCe()

        MsgBox("Desconectado com sucesso!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Teste de Conexão !!!")

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        clsSqlServerConn.openConn()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        frmPedido.Show()
    End Sub

#End Region

End Class
