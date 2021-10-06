Imports BE

Public Class ProvinciaDAL
    Public Shared Function CargarBE(unaProvincia As ProvinciaBE, pRow As DataRow) As ProvinciaBE
        unaProvincia.Id = pRow("Id_provincia")
        unaProvincia.nombre_provincia = pRow("Nombre_provincia")

        Return unaProvincia
    End Function


    Public Shared Function Listar() As List(Of BE.ProvinciaBE)
        Dim mLista As New List(Of BE.ProvinciaBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT * FROM Provincia"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unaProvincia As New ProvinciaBE

                    unaProvincia = CargarBE(unaProvincia, mRow)

                    mLista.Add(unaProvincia)
                Next

                Return mLista
            Else
                Return New List(Of ProvinciaBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ProvinciaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
