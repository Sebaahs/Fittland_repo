Imports BE

Public Class ActividadDAL
    Public Shared Function CargarBE(unaActividad As ActividadBE, pRow As DataRow) As ActividadBE
        unaActividad.Id = pRow("Id_actividad")
        unaActividad.nombre_actividad = pRow("Nombre_actividad")

        Return unaActividad
    End Function

    Public Shared Function Listar() As List(Of BE.ActividadBE)
        Dim mLista As New List(Of BE.ActividadBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT * FROM Actividad"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unaActividad As New ActividadBE

                    unaActividad = CargarBE(unaActividad, mRow)

                    mLista.Add(unaActividad)
                Next

                Return mLista
            Else
                Return New List(Of ActividadBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ActividadDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ListarForm3() As List(Of BE.ActividadBE)
        Dim mLista As New List(Of BE.ActividadBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT Persona.DNI,  Persona.Nombre , Actividad.Nombre_actividad 
FROM Persona , Actividad , Cliente
WHERE Persona.Id_persona = Cliente.Id_persona AND Cliente.Id_actividad = Actividad.Id_actividad"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unaActividad As New ActividadBE

                    unaActividad = CargarBE(unaActividad, mRow)

                    mLista.Add(unaActividad)
                Next

                Return mLista
            Else
                Return New List(Of ActividadBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - ActividadDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class