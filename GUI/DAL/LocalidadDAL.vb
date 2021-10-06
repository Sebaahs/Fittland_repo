Imports BE

Public Class LocalidadDAL


    Public Shared Function CargarBE(unaLocalidad As LocalidadBE, pRow As DataRow) As LocalidadBE
        unaLocalidad.Id = pRow("Id_localidad")
        unaLocalidad.nombre_Localidad = pRow("Nombre_localidad")

        Return unaLocalidad
    End Function


    Public Shared Function Listar() As List(Of BE.LocalidadBE)
        Dim mLista As New List(Of BE.LocalidadBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT * FROM Localidad"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unaLocalidad As New LocalidadBE

                    unaLocalidad = CargarBE(unaLocalidad, mRow)

                    mLista.Add(unaLocalidad)
                Next

                Return mLista
            Else
                Return New List(Of LocalidadBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - LocalidadDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function QueryLocalidadDAL(QLocalidad As String, DT As DataTable) As DataTable
        Dim cn As New Conexion
        Dim pCommand As String = "SELECT Localidad.Nombre_localidad FROM Localidad WHERE Id_localidad =" & QLocalidad

        cn.DataTable(pCommand, DT)


        Return DT

    End Function

End Class




