Imports DAL
Public Class ActividadBLL
    Public Function Listar() As List(Of BE.ActividadBE)
        Return ActividadDAL.Listar()
    End Function


End Class
