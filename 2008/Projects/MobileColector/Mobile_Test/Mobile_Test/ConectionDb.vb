Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlServerCe

Public Class ConectionDb

    Private Sub btnConectarBd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Cursor.Current = Cursors.WaitCursor
        Dim PathBD = ""

        Try
            'Inicia uma instancia da classe SQLCeconnection
            Dim Conn As New SqlCeConnection("Data Source=" & PathBD)

            'Caso a conexão esteja fechada, será possível conectar com o BD
            If Conn.State = ConnectionState.Closed Then

                'Abre a conexão
                Conn.Open()

                ' MostraStatus("Conectado ao Banco de dados " & PathBD & " com sucesso !!!")
            End If
        Catch ex As Exception
            'Caso ocorra algum tipo de erro, deve ser tratado aqui
        End Try
        Cursor.Current = Cursors.Default
    End Sub

End Class
