Imports System.Reflection
Imports System.Data
Imports System.Text

Public Class frmLogin

    Private objUsuario As clsUsuario
    Private objSqlConn As New clsSqlConn
    Private objFile As New clsFile
    Private alUsuarios As ArrayList
    Dim sql01 As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillFileStrConnection()

        Dim caminho As String = searchPathApplication()

        cbUsuario.Enabled = True
        txtSenha.Enabled = False
        frmConfig()
    End Sub

    Private Sub frmConfig()

        carregarComboUsuarios()
        pbLoginConfig(pbLogin, Me, imgLogin, 2)
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

    Private Sub validaAcesso(ByVal usuario As String, ByVal senha As String)

        Dim arrUsuarios As Object = alUsuarios.ToArray

        For Each element In arrUsuarios
            If (usuario = CType(element, clsUsuario).Nome) Then
                If (senha = CType(element, clsUsuario).Senha) Then
                    strUsuarioLogado = CType(element, clsUsuario).Nome()
                    intUsuarioLogado = CType(element, clsUsuario).Codigo()
                    Me.Hide()
                    frmPedido.Show()
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

            'Dim _type As Type = element.GetType()
            'Dim properties() As PropertyInfo = _type.GetProperties()

            'For Each _property As PropertyInfo In properties
            ''Verifica o valor que irá preencher o ComboBox
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

        'Next

    End Sub

    Private Sub fillFileStrConnection()
        objFile.getArquivosDiretorio(".txt", "strConn")
    End Sub

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


End Class