Imports DAL


Public Class SexoBLL
    Public Function Listar() As List(Of BE.SexoBE)
        Return SexoDAL.Listar()
    End Function

    Public Function QuerySexoBLL(QSexo As String, DT As DataTable) As DataTable
        Dim unSexo As New SexoDAL

        Return unSexo.QuerySexoDAL(QSexo, DT)
    End Function

End Class
