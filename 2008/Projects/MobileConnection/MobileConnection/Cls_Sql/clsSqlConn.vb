Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Reflection

Public NotInheritable Class clsSqlConn

    ''SQL SERVER 
    Private Shared sqlConn As New SqlConnection()
    Private Shared transacao As SqlTransaction

    ''Utilizado para criar a string de conexão
    Private Shared strPassword As String
    Private Shared booSecurity As Boolean
    Private Shared strUserId As String
    Private Shared strCatalog As String
    Private Shared strDataSource As String
    Private Shared strConnection As String



#Region "SqlServer"

#Region "Region Contrutores"


    ''Sem passar parâmetros usa a string da base tecware
    Public Sub New()
        strConnection = "Password=tec9TIT167*45e;Persist Security Info=False;User ID=sa;Initial Catalog=TECWARE;Data Source=tecwarebr.dyndns.org"
    End Sub

    Public Sub New(ByVal strPassword As String, ByVal strUserID As String, ByVal strInitialCatalog As String _
                   , ByVal strDataSource As String, Optional ByVal booSecurity As Boolean = False)

        Password = strPassword
        UserId = strUserID
        Catalog = strInitialCatalog
        DataSource = strDataSource
        Security = booSecurity

        ''Monta a string de conexão
        setStrConnection()

    End Sub

#End Region

#Region "Region Get&Set"

    Public Shared Property Password()
        Get
            Return strPassword
        End Get

        Set(ByVal value)
            If (value <> "") Then
                strPassword = Trim(value)
            End If
        End Set
    End Property

    Public Shared Property Security() As Boolean
        Get
            Return booSecurity
        End Get

        Set(ByVal value As Boolean)
            If value <> booSecurity Then
                booSecurity = value
            End If
        End Set
    End Property

    Public Shared Property UserId()
        Get
            Return strUserId
        End Get

        Set(ByVal value)
            If (value <> "") Then
                strUserId = Trim(value)
            End If
        End Set
    End Property

    Public Shared Property Catalog()
        Get
            Return strCatalog
        End Get

        Set(ByVal value)
            If (value <> "") Then
                strCatalog = Trim(value)
            End If
        End Set
    End Property

    Public Shared Property DataSource()
        Get
            Return strDataSource
        End Get

        Set(ByVal value)
            If (value <> "") Then
                strDataSource = Trim(value)
            End If
        End Set
    End Property

    Public Shared ReadOnly Property StringConection()
        Get
            Return strConnection
        End Get
    End Property

#End Region

    Private Shared Sub setStrConnection()
        clsSqlConn.strConnection = "Password=" + Password() + ";Persist Security Info=" + Security().ToString + ";User ID=" + UserId().ToString + ";Initial Catalog=" + Catalog().ToString + ";Data Source=" + DataSource().ToString
    End Sub


#Region "Open & Close"

    Public Shared Sub openConn()

        Try
            If (sqlConn.State = Data.ConnectionState.Closed) Then
                Dim strConn As String = StringConection()
                sqlConn = New SqlConnection(strConn)
                sqlConn.Open()
            End If
        Catch sqlEx As SqlException

            Throw New Exception("Ocorre um problema durante a conexão com a base de dados. " & Environment.NewLine & _
                                " Erro: " & sqlEx.Message & _
                                " Source: " & sqlEx.Source & _
                                " Number: " & sqlEx.Number)
        Catch ex As Exception

            Throw New Exception("Ocorre um problema durante a interação com a base de dados" & vbCrLf & _
                                "Erro: " & ex.Message)
        End Try

    End Sub

    Public Shared Sub closeConn()

        Try
            If (sqlConn.State = Data.ConnectionState.Open) Then
                sqlConn.Close()
            End If
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub


#End Region

    Public Shared Sub fillDataSet(ByVal ds As DataSet, ByVal sql01 As String)

        clsSqlConn.configStringConnection()

        Try
            Dim da As New SqlDataAdapter(sql01, sqlConn)
            da.Fill(ds)
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        End Try

    End Sub

    Public Shared Sub fillDataTable(ByVal dt As DataTable, ByVal sql01 As String)

        openConn()

        Try

            Dim da As New SqlDataAdapter(sql01, sqlConn)
            da.Fill(dt)

        Catch sqlEx As SqlException

            If (sqlEx.Number = 11) Then
                Throw New Exception("Não foi possível se comunicar com a base de dados devido problemas com a rede." & vbCrLf & _
                                    "Erro : " & sqlEx.Message & vbCrLf & _
                                    "Number:" & sqlEx.Number)
            Else
                Throw New Exception("Problemas durante a carga do DataTable:" & vbCrLf & _
                    "Erro : " & sqlEx.Message & vbCrLf & _
                    "Number:" & sqlEx.Number)
            End If

        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)

        Finally
            closeConn()
        End Try

    End Sub

    Public Shared Function fillDataReader(ByVal sql01 As String) As SqlDataReader

        openConn()
        Dim cmd As New SqlCommand(sql01, sqlConn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.FieldCount > 0 Then

        End If

        Return dr

        'closeConn()

    End Function

    Public Shared Sub execCommandSql(ByVal sql01 As String)

        openConn()

        Try
            Dim cmd As New SqlCommand(sql01, sqlConn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        Finally
            closeConn()
        End Try

    End Sub

    Public Shared Sub beginTransaction()

        openConn()

        Try
            If (sqlConn.State = ConnectionState.Open) Then
                transacao = sqlConn.BeginTransaction(IsolationLevel.ReadCommitted)
            End If
        Catch ex As Exception
            Throw New Exception("Ocorre um problema na conexão com a base de dados." & vbCrLf & "Erro : " + ex.Message)
        Finally
            closeConn()
        End Try

    End Sub

    Public Shared Sub EndTransaction(ByRef flag As Boolean)

        If flag = False Then
            transacao.Commit()
        Else
            transacao.Rollback()
        End If

    End Sub

    Public Overloads Shared Sub configStringConnection()
        clsSqlConn.setStrConnection()
    End Sub


    ''' <summary>
    ''' Monta a string de conexão a partir de um array contendo os dados nescessários.
    ''' </summary>
    ''' <param name="array"> Array preenchido com o padrão sql de string de conexão</param>
    ''' <exemplo>
    ''' 
    '''  Itens padrão a ser usada : 
    '''  Provider=SQLOLEDB.1
    '''  Password=senha
    '''  Persist Security Info=False/True
    '''  User ID=usuario
    '''  Initial Catalog=basededados
    '''  Data Source=ip
    ''' 
    ''' </exemplo>
    Public Overloads Shared Sub configStringConnection(ByVal array() As String)

        For Each i In array
            Select Case i.Substring(0, InStr(i, "=") - 1)
                Case "Password"
                    clsSqlConn.Password() = i.Substring(InStr(i, "="))
                Case "Persist Security Info"
                    clsSqlConn.Security() = i.Substring(InStr(i, "="))
                Case "User ID"
                    clsSqlConn.UserId() = i.Substring(InStr(i, "="))
                Case "Initial Catalog"
                    clsSqlConn.Catalog() = i.Substring(InStr(i, "="))
                Case "Data Source"
                    clsSqlConn.DataSource() = i.Substring(InStr(i, "="))
            End Select
        Next
        ''Monta a string de conexão
        clsSqlConn.setStrConnection()

    End Sub


    ''' <summary>
    ''' Redefine os atributos da string de conexão
    ''' </summary>
    ''' <param name="strPassword"></param>
    ''' <param name="strUserID"></param>
    ''' <param name="strInitialCatalog"></param>
    ''' <param name="strDataSource"></param>
    ''' <param name="booSecurity">Optional ---True or False</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub configStringConnection(ByVal strPassword As String, ByVal strUserID As String, ByVal strInitialCatalog As String, _
                                              ByVal strDataSource As String, Optional ByVal booSecurity As Boolean = False)
        ''Monta a string de conexão
        clsSqlConn.Password() = strPassword
        clsSqlConn.UserId() = strUserID
        clsSqlConn.Catalog() = strCatalog
        clsSqlConn.DataSource() = strDataSource
        clsSqlConn.Security() = booSecurity
        clsSqlConn.setStrConnection()

    End Sub



#End Region

End Class
