Imports System.Data.SqlClient
Imports BE

Public Class PersonaDAL

    Public Shared Function CargarBE(unaPersona As PersonaBE, pRow As DataRow) As PersonaBE
        unaPersona.Id = pRow("Id_persona")
        unaPersona.nombre = pRow("Nombre")
        unaPersona.apellido = pRow("Apellido")
        unaPersona.dni = pRow("DNI")
        unaPersona.telefono = pRow("Telefono")
        unaPersona.localidad = New LocalidadBE
        unaPersona.localidad.Id = pRow("Id_Localidad")
        unaPersona.Dpto = pRow("Dpto")
        unaPersona.direccion = pRow("Direccion")
        unaPersona.sexo = New SexoBE
        unaPersona.sexo.Id = pRow("Id_sexo")

        Return unaPersona
    End Function


    '    Public Shared Function ObtenerPersona(ID As Integer) As BE.PersonaBE
    '        Dim unaPersona As New PersonaBE
    '        Dim mCommand As String = "SELECT * FROM Persona WHERE Id_Persona = ID"
    '
    '        Try
    '            Dim mDataSet As DataSet = Conexion.ExecuteDataSet(mCommand)
    '
    '            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
    '                AreaBE = CargarBE(AreaBE, mDataSet.Tables(0).Rows(0))
    '                Return AreaBE
    '            Else
    '                Return Nothing
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Error - DataSet - AreaDAL")
    '            MsgBox(ex.Message)
    '            Return Nothing
    '        End Try
    '    End Function

    Public Shared Sub GuardarNuevo(unaPersona As BE.PersonaBE)
        Dim mCommand As String = String.Empty
        Dim cn As New Conexion

        mCommand = "INSERT INTO Persona (Nombre, Apellido, DNI, Id_localidad, Telefono, Direccion, Dpto, Id_sexo) VALUES ('" & unaPersona.nombre & "','" & unaPersona.apellido & "','" & unaPersona.dni & "','" & unaPersona.localidad.Id & "','" & unaPersona.telefono & "','" & unaPersona.direccion & "','" & unaPersona.Dpto & "','" & unaPersona.sexo.Id & "'); SELECT @@Identity"

        Try
            cn.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Nuevo - PersonaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub GuardarModificacion(unaPersona As BE.PersonaBE)
        Dim mCommand As String
        Dim cn As New Conexion
        Try
            mCommand = "UPDATE Persona SET " &
                   "Nombre = '" & unaPersona.nombre &
                   "',Apellido = '" & unaPersona.apellido &
                   "',DNI ='" & unaPersona.dni &
                   "',Telefono ='" & unaPersona.telefono &
                   "',Id_localidad ='" & unaPersona.localidad.Id &
                   "',Direccion ='" & unaPersona.direccion &
                   "',Dpto ='" & unaPersona.Dpto &
                   "',Id_sexo ='" & unaPersona.sexo.Id &
                   "'WHERE Id_persona = " & unaPersona.Id
            cn.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Modificacion - PersonaDAL")
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Shared Sub Eliminar(unaPersona As BE.PersonaBE)
        Dim mCommand As String = "DELETE FROM Persona WHERE Id_Persona = " & unaPersona.Id
        Dim cn As New Conexion
        Try
            cn.ExecuteNonQuery(mCommand)
        Catch ex As Exception
            MsgBox("Error - Eliminacion - PersonaDAL")
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function Listar() As List(Of BE.PersonaBE)
        Dim mLista As New List(Of BE.PersonaBE)
        Dim mCommand As String = String.Empty
        Dim mDataSet As DataSet
        Dim cn As New Conexion

        Try
            mCommand = "SELECT * FROM Persona"
            mDataSet = cn.ExecuteDataSet(mCommand)

            If Not IsNothing(mDataSet) And mDataSet.Tables.Count > 0 And mDataSet.Tables(0).Rows.Count > 0 Then
                For Each mRow As DataRow In mDataSet.Tables(0).Rows
                    Dim unaPersona As New PersonaBE

                    unaPersona = CargarBE(unaPersona, mRow)

                    mLista.Add(unaPersona)
                Next

                Return mLista
            Else
                Return New List(Of PersonaBE)
            End If
        Catch ex As Exception
            MsgBox("Error - Listar - PersonaDAL")
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
