Imports System.Text
Imports System.Data

Public Class frmPedido

    Public strSql01 As New StringBuilder()
    Dim sql01 As String


    Private Sub frmPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsSqlServerConn.initConnection()

        ''Mosta uma string de comando
        strSql01.Append("SELECT codigoPEDIDOCOMPRA as Código ")
        strSql01.Append("FROM tb1402_Pedidos")

        sql01 = strSql01.ToString
        Dim dtPedidos = New DataTable("Pedidos")

        FillObjects.preencheComboBox(cbCodigoPedido, sql01, dtPedidos, "Código")

    End Sub

End Class