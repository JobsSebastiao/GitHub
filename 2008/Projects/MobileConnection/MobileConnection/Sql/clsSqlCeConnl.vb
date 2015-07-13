Imports System
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Text
Imports System.Collections.Generic

Public Class clsConnectionCeSql

    ''sqlCE
    Private sqlCeConn As New SqlCeConnection()
    Private transacaoCe As SqlCeTransaction
    Private strBancoCe As String
    Private strConnectionCe As String
    Private strPasswordCe As String

#Region "SqlCE"

    Public Sub New()

    End Sub

    Public Sub New(ByVal strConnection As String, ByVal dbName As String)
        Me.BancoCe = dbName
    End Sub


    Public Property BancoCe()
        Get
            Return Me.strBancoCe
        End Get
        Set(ByVal value)
            If (value <> "") Then
                Me.strBancoCe = value
            End If
        End Set

    End Property

    Public Property PasswordCe()
        Get
            Return Me.strPasswordCe
        End Get
        Set(ByVal value)
            If (value <> "") Then
                Me.strPasswordCe = value
            End If
        End Set

    End Property

    Public ReadOnly Property StringConectionCe() As String
        Get
            Return Me.strConnectionCe
        End Get
    End Property

    Private Function createStringConectionCe() As String

        If (Me.BancoCe() <> "" And Me.PasswordCe() <> "") Then
            Me.strConnectionCe = "Persist Security Info = False;" & _
                                 "data source = " & Me.BancoCe() & ";" & _
                                 "Password = " & Me.PasswordCe() & ";" & _
                                 "Max Database Size = 256;" & _
                                 "Max Buffer Size = 1024;"
        End If

        Return Me.strConnectionCe

    End Function

    Public Sub openConnCe()

        Try
            If (sqlCeConn.State = ConnectionState.Closed) Then
                Dim strConn As String = createStringConectionCe() ''"data source = \Temp\" + banco + ".sdf"
                sqlCeConn = New SqlCeConnection(strConn)
                sqlCeConn.Open()
            End If
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Function closeConnCe() As Boolean
        Try
            If (sqlCeConn.State = ConnectionState.Open) Then
                sqlCeConn.Close()
                Return True
            End If
        Catch ex As Exception
            Return False
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Function

    Public Sub createBDCe(ByVal dataBase As String)

        If dataBase = "" Then
            MsgBox("O dataBase não foi setado.")
        Else
            BancoCe() = dataBase
        End If

        Try
            Dim sqlEngine As New SqlCeEngine("data source=\Temp\" + BancoCe() + ".sdf")
            sqlEngine.CreateDatabase()
        Catch ex As Exception
            MsgBox("Erro durante a criação da base de dados!! Motivo:" + ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Create DataBase")
        End Try


    End Sub


    Public Sub fillDataSetCe(ByVal ds As DataSet, ByVal sql01 As String)

        Try
            Dim da As New SqlCeDataAdapter(sql01, sqlCeConn)
            da.Fill(ds)
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Sub fillDataTableCe(ByVal dt As DataTable, ByVal sql01 As String)

        Try
            Dim da As New SqlCeDataAdapter(sql01, sqlCeConn)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Function fillDataReaderCe(ByVal sql01 As String) As SqlCeDataReader

        Dim cmd As New SqlCeCommand(sql01, sqlCeConn)
        Dim dr As SqlCeDataReader = cmd.ExecuteReader()
        Return dr

    End Function

    Public Sub execCommandSqlCe(ByVal sql01 As String)

        Try
            Dim cmd As New SqlCeCommand(sql01, sqlCeConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Sub beginTransactionCe()

        Try
            If (sqlCeConn.State = ConnectionState.Open) Then
                transacaoCe = sqlCeConn.BeginTransaction(IsolationLevel.ReadCommitted)
            End If
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Sub EndTransactionCe(ByRef flag As Boolean)

        If flag = False Then
            transacaoCe.Commit()
        Else
            transacaoCe.Rollback()
        End If

    End Sub

#End Region

End Class
