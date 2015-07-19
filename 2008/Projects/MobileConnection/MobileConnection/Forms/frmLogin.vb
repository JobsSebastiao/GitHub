Imports System.Reflection
Imports System.Data
Imports System.Text
Imports System.IO
Imports System.Net

Public Class frmLogin

    Private objUsuario As clsUsuario
    Private objFile As New clsFile()   'ao ser instanciada configura um caminho padrão e um arquivo padrão onde será buscado o arquivo .txt contendo a string de conexão
    Private alUsuarios As ArrayList
    Dim sql01 As String

    Public Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmConfig()
    End Sub

    Private Sub frmConfig()

        If (strConnectionConfig()) Then
            pbLoginConfig(pbLogin, Me, imgLogin, 2)
            carregarComboUsuarios()

            'Campos
            lbSenha.Visible = False
            lbUsuario.Visible = False
            cbUsuario.Enabled = True
            txtSenha.Enabled = False
        Else
            Application.Exit()
            Exit Sub
        End If

    End Sub

    Private Sub mnuLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogin.Click
        validaAcesso(cbUsuario.Text, txtSenha.Text)
    End Sub

    Private Sub mnuSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSair.Click
        Application.Exit()
    End Sub

    Private Sub carregarComboUsuarios()

        Dim dt As New DataTable("Usuários")

        With strSql01
            .Append("SELECT codigoUSUARIO as Codigo,pastaUSUARIO as Pasta,nomeUSUARIO as Nome,")
            .Append("senhaUSUARIO as Senha,nomecompletoUSUARIO as NomeCompleto ")
            .Append("FROM tb0201_usuarios ")
            .Append("ORDER BY nomeUSUARIO ")
            Me.sql01 = strSql01.ToString
        End With

        alUsuarios = fillArrayListUsuarios(dt, sql01)
        preencheComboBoxUsuario(cbUsuario, alUsuarios, clsUsuario.usuarioPropety.Nome)

    End Sub


    ''' <summary>
    ''' Válida o acesso ao sistema
    ''' </summary>
    ''' <param name="usuario">Usuário contido na base de dados</param>
    ''' <param name="senha">Senha contida na base de dados</param>
    ''' <remarks></remarks>
    Private Sub validaAcesso(ByVal usuario As String, ByVal senha As String)

        Dim arrUsuarios As Object = alUsuarios.ToArray

        For Each element In arrUsuarios
            If (usuario = CType(element, clsUsuario).Nome) Then
                If (senha = CType(element, clsUsuario).Senha) Then
                    strUsuarioLogado = CType(element, clsUsuario).Nome()
                    intUsuarioLogado = CType(element, clsUsuario).Codigo()
                    cbUsuario.Text = Nothing
                    txtSenha.Text = Nothing
                    CodigoAcesso(intUsuarioLogado)
                    Dim frmAcoes = New frmAcoes()
                    frmAcoes.Show()
                    Me.Hide()
                    Return
                Else
                    MsgBox("A senha digítada é inválida!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Login Inválido")
                    txtSenha.Text = Nothing
                    txtSenha.Focus()
                    Return
                End If
            End If
        Next
        MsgBox("Usuário/Senha não existem na base de dados!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Login Inválido")
    End Sub

    ''' <summary>
    ''' Configura o Picture Box (pbLogin) com a imagens passada como parâmetro
    ''' </summary>
    ''' <param name="pb"></param>
    ''' <param name="frm"></param>
    ''' <param name="imglist"></param>
    ''' <param name="imgIndex"></param>
    ''' <remarks></remarks>
    Private Sub pbLoginConfig(ByVal pb As PictureBox, ByVal frm As Form, ByRef imglist As ImageList, ByVal imgIndex As Int32)

        imglist.ImageSize = New Size(frm.Size.Width, frm.Size.Height)

        With pb
            .BackColor = Color.Blue
            .Size() = New System.Drawing.Size(frm.Size.Width, frm.Size.Height)
            .Image = imglist.Images.Item(imgIndex)
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Carrega uma Combo com uma das propriedades(Codigo,Nome ou NomeCompleto) de um objeto cslUsuario
    ''' </summary>
    ''' <param name="cb">ComboBox a ser prenchido</param>
    ''' <param name="list">Array List previamente carregada</param>
    ''' <param name="propriedade">Uma das propriedades do objeto usuário (Codigo,Nome ou NomeCompleto)</param>
    ''' <remarks></remarks>
    Private Sub preencheComboBoxUsuario(ByVal cb As ComboBox, ByVal list As ArrayList, ByVal propriedade As clsUsuario.usuarioPropety)

        'Gera um array prenchido com objetos do tipo clsUsuario
        Dim obj As Object() = list.ToArray

        Dim columnName As String = Nothing
        cb.Items.Clear()

        'Loop em cada objeto contido no array
        For Each element In obj

            Select Case propriedade

                Case 1
                    columnName = "Codigo"
                    cb.Items.Add(CType(element, clsUsuario).Codigo)
                    Continue For
                Case 3
                    columnName = "Nome"
                    cb.Items.Add(CType(element, clsUsuario).Nome)
                    Continue For
                Case 5
                    columnName = "NomeCompleto"
                    cb.Items.Add(CType(element, clsUsuario).NomeCompleto)
                    Continue For
                Case Else
                    columnName = "Nome"
                    cb.Items.Add(CType(element, clsUsuario).NomeCompleto)
            End Select

        Next

        cb.DropDownStyle = ComboBoxStyle.DropDown
        cb.DisplayMember = columnName
        cb.ValueMember = columnName

    End Sub

    ''' <summary>
    ''' Configura os parametros da string de conexão.
    ''' </summary>
    ''' <remarks>
    ''' Verifica se o arquivo que contém o string de conexão existe:
    ''' Lê o arquivo e o coloca em uma string que é devolvida em um ArrayList
    ''' Gera um array, realizando um split na string contida na variável
    ''' utiliza a classe statica clsSqlConn para definir os parâmetros da string de conexão
    ''' configura a string de conexão na classe static clsSqlConn
    ''' </remarks>
    Private Function strConnectionConfig() As Boolean

        Try

            If (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) & "\strConn.txt")) Then

                Dim str As ArrayList = objFile.readTextFile() ''Retorn o texto do arquivo
                'gera um array com  o texto da string
                Dim arrayStringConn As String() = objFile.arrayOfTextFile(str(0).ToString, clsFile.splitType.PONTO_VIRGULA)
                'configura a string de conexão
                clsSqlConn.configStringConnection(arrayStringConn)
                Return True

            Else

                MsgBox("O arquivo de configuração strConn.txt não foi encontrado." & vbCrLf & _
                       "Local de busca do arquivo:" & Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), _
                       MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "TecwareColector")
                Return False

            End If

        Catch ex As Exception

            Throw New Exception("Problemas durante a configuração da string de conexão." & vbCrLf & _
                                "Favor contate o administrador do sistema." & vbCrLf & _
                                "Erro :" & ex.Message)
            Application.Exit()

        End Try

    End Function

    Private Sub cbUsuario_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbUsuario.KeyUp
        validaComboBox(cbUsuario, txtSenha, e)
    End Sub

    Private Sub cbUsuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUsuario.LostFocus
        Dim key As New KeyEventArgs(AscW(ChrW(13)))
        validaComboBox(cbUsuario, txtSenha, key)
    End Sub

    Private Sub txtSenha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSenha.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            mnuLogin_Click(txtSenha, Nothing)
        End If
    End Sub

    Public Function CodigoAcesso(ByVal intUsuario As Integer) As Long

        strHostName = getHostName()

        'Insere o acesso e inicia a transação
        sql01 = "INSERT INTO tb0207_Acessos (usuarioACESSO, maquinaACESSO)"
        sql01 = sql01 & " VALUES (" & intUsuario & ",'" & strHostName & "')"
        clsSqlConn.execCommandSql(sql01)

        'Recupera o código do acesso
        sql01 = "SELECT MAX(codigoACESSO) AS novoACESSO"
        sql01 = sql01 & " FROM tb0207_Acessos"
        dr = clsSqlConn.fillDataReader(sql01)
        If (dr.FieldCount > 0) Then
            While (dr.Read)
                CodigoAcesso = dr.Item("novoACESSO")
            End While
        End If

        'Fecha a transação
        'Call ConnExecCommitTrans()

    End Function

    Private Sub lbSenha_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSenha.ParentChanged

    End Sub
End Class