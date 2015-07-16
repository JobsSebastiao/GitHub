Public Class frmAcoes

    Private Sub mnuAcoes_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAcoes_Logout.Click
        frmLogin.Show()
        frmLogin.frmLogin_Load(sender, Nothing)
        Me.Hide()

        With frmLogin
            .cbUsuario.Text = Nothing
            .cbUsuario.Focus()
            .txtSenha.Text = Nothing
        End With

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAcoes_Sair.Click
        Application.Exit()
    End Sub
End Class