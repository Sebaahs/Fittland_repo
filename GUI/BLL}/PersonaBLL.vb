Imports DAL
Imports BE

Public Class PersonaBLL

    Public Sub Guardar(unaPersona As BE.PersonaBE)

        If unaPersona.Id = 0 Then

            PersonaDAL.GuardarNuevo(unaPersona)
        Else
            PersonaDAL.GuardarModificacion(unaPersona)
        End If
    End Sub


    Public Sub Eliminar(unaPersona As BE.PersonaBE)

        PersonaDAL.Eliminar(unaPersona)
    End Sub


    Public Function Listar() As List(Of BE.PersonaBE)
        Return PersonaDAL.Listar()
    End Function
End Class
