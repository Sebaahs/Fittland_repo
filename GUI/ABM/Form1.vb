Public Class Form1
    Private formActual As Form = Nothing
    Private Sub abrirFormHijo(formHijo As Form)
        If formActual IsNot Nothing Then formActual.Close()

        formActual = formHijo
        formHijo.TopLevel = False
        formHijo.FormBorderStyle = FormBorderStyle.None
        formHijo.Dock = DockStyle.Fill
        contenedor.Controls.Add(formHijo)
        contenedor.Tag = formHijo
        formHijo.BringToFront()
        formHijo.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        abrirFormHijo(New Form2())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Me.Close()
    End Sub

    Private Sub contenedor_Paint(sender As Object, e As PaintEventArgs) Handles contenedor.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        abrirFormHijo(New Form3())
    End Sub
End Class
