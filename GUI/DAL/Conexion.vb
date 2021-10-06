Imports System.Data.SqlClient


Public Class Conexion
    Dim mConnectionString As String = "Data source=LAPTOP-0QDHESIR\MSSQLSERVER01; Initial Catalog=Club; Integrated security=SSPI"


    Public Function Abrir() As SqlConnection
        Dim cn As New SqlConnection

        cn.ConnectionString = mConnectionString

        cn.Open()

        Return cn
    End Function

    Public Function Cerrar() As SqlConnection
        Dim cn As New SqlConnection

        cn.Close()

        Return cn
    End Function
    Public Function ExecuteDataSet(pCommand As String)
        Dim mConnection As New SqlConnection(mConnectionString)
        Dim mCommand As New SqlCommand(pCommand, mConnection)
        Dim mDataAdapter As New SqlDataAdapter(mCommand)
        Dim mDataSet As New DataSet

        Try
            mConnection.Open()
            mDataAdapter.Fill(mDataSet)

            Return mDataSet
        Catch ex As Exception
            MsgBox("Error DataSet - BD")
            MsgBox(ex.Message)
            Return Nothing
        Finally
            mConnection.Close()
        End Try
    End Function


    Public Sub ExecuteNonQuery(pCommand As String)
        Dim mConnection As New SqlConnection(mConnectionString)
        Dim mCommand As New SqlCommand(pCommand, mConnection)

        Try
            mConnection.Open()
            mCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error NonQuery - BD")
            MsgBox(ex.Message)
        Finally
            mConnection.Close()
        End Try
    End Sub

    Public Function DataTable(pCommand As String, DT As DataTable) As DataTable

        Dim mConnection As New SqlConnection(mConnectionString)
        Dim mCommand As New SqlCommand(pCommand, mConnection)
        Dim DAdapter As SqlDataAdapter

        Try

            mConnection.Open()

            DAdapter = New SqlDataAdapter(pCommand, mConnection)
            DAdapter.Fill(DT)

            mConnection.Close()

            Return DT

        Catch ex As Exception
            MsgBox("Error - DataTable - Conexion")
        End Try
    End Function


End Class
