Public Class TransparenteControl
    Inherits Control

    Protected HasBackground As Boolean = False

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Dim form As IControlBackground = CType(Parent, IControlBackground)
        If (form Is Nothing) Then
            MyBase.OnPaintBackground(e)
            Return
        Else
            HasBackground = True
        End If
        e.Graphics.DrawImage(form.BackgroundImage(), 0, 0, Bounds, GraphicsUnit.Pixel)
    End Sub

End Class
