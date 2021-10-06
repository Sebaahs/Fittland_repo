Imports DAL

Public Class ProvinciaBLL

    Public Function Listar() As List(Of BE.ProvinciaBE)
        Return ProvinciaDAL.Listar()
    End Function
End Class