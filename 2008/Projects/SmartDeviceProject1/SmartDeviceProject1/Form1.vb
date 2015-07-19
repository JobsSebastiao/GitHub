Public Class Form1

    Dim intScreenHeigth As Integer
    Dim intScreenWidth As Integer
    Dim intScreenX As Integer
    Dim intScreenY As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("E Aiii evoluiu!!!!!")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MsgBox(String.Format("Versão {0}", Environment.OSVersion.ToString()))

        Dim screensize As System.Drawing.Rectangle = Screen.PrimaryScreen.Bounds

        intScreenHeigth = screensize.Height

        intScreenWidth = screensize.Left

        intScreenX = screensize.X
        intScreenY = screensize.Y

        pnFrmMain.Size = New System.Drawing.Size(intScreenWidth, intScreenHeigth)

        txt1.Size = New System.Drawing.Size(pnFrmMain.Size().Width - 10, 20)
        txt1.Location() = New System.Drawing.Point(intScreenX + 100, intScreenY + 100)

        txt1.Text = intScreenHeigth & " " & intScreenWidth & " " & intScreenX & " " & intScreenY

    End Sub
End Class
