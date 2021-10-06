Imports BE

Public Class SexoDAL
    Public Shared Function CargarBE(unSexo As SexoBE, pRow As DataRow) As SexoBE
        unSexo.Id = pRow("Id_sexo")
        unSexo.sexo = pRow("Sexo")

        Return unSexo
    End Function


    Public Shared Function Listar() As List(Of BE.SexoBE)
        Dim mLista As New List(Of BE.SexoBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT * FROM Sexo"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unSexo As New SexoBE

                    unSexo = CargarBE(unSexo, mRow)

                    mLista.Add(unSexo)
                Next

                Return mLista
            Else
                Return New List(Of SexoBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - LocalidadDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function QuerySexoDAL(QSexo As String, DT As DataTable) As DataTable
        Dim cn As New Conexion
        Dim pCommand As String = "SELECT Sexo.sexo FROM Sexo WHERE Id_sexo =" & QSexo

        cn.DataTable(pCommand, DT)


        Return DT

    End Function

End Class
