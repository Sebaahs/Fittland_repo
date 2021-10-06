Imports DAL

Public Class LocalidadBLL

    Public Function Listar() As List(Of BE.LocalidadBE)
        Return LocalidadDAL.Listar()
    End Function

    Public Function QueryLocalidadBLL(QLocalidad As String, DT As DataTable) As DataTable
        Dim unaLocalidad As New LocalidadDAL

        Return unaLocalidad.QueryLocalidadDAL(QLocalidad, DT)
    End Function

End Class
