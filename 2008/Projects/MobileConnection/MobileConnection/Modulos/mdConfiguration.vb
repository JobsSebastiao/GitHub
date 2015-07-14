Imports System.Text

Module mdConfiguracoes

    Public strUsuarioLogado As String
    Public intUsuarioLogado As Integer
    Public strSql01 As New StringBuilder()

    Public Sub pbLoginConfig(ByVal pb As PictureBox, ByVal frm As Form, ByRef imglist As ImageList, ByVal imgIndex As Int32)

        imglist.ImageSize = New Size(frm.Size.Width, frm.Size.Height)

        With pb
            .BackColor = Color.Blue
            .Size() = New System.Drawing.Size(frm.Size.Width, frm.Size.Height)
            .Image = imglist.Images.Item(imgIndex)
            .ResumeLayout()
        End With

    End Sub

End Module
