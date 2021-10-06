Imports BE
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombo()
        cargarDataGrid()
    End Sub

    Public Sub limpiar()
        cbPersona.Text = Nothing
        cbActividad.Text = Nothing
    End Sub


    Public Sub CargarCombo()
        Dim unaActividad As New BLL_.ActividadBLL
        Dim unaPersona As New BLL_.PersonaBLL

        'cbBuscarRegistro.DataSource = Nothing
        cbPersona.DataSource = unaPersona.Listar()
        cbPersona.ValueMember = "DNI"

        'cbLocalidad.DataSource = Nothing
        cbActividad.DataSource = unaActividad.Listar()
        cbActividad.ValueMember = "Nombre_actividad"

    End Sub

    Public Sub cargarDataGrid()
        Dim UnaActividad As New BLL_.ActividadBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = UnaActividad.Listar()

        'DataGridView1.Columns(8).Visible = False
    End Sub

    ' Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '
    '
    'Dim unaPersona As New BE.PersonaBE
    '    Dim unaPersonaBLL As New BLL_.PersonaBLL
    '    Dim unCliente As New ClienteBE
    '    Dim unaActividad As New ActividadBE
    '    Dim unaActividad
    '    Try
    '        If cbPersona.Text = Nothing Or cbActividad.Text = Nothing Then
    '            MsgBox("Complete todos los campos para continuar")
    '        Else
    '            unCliente = New BE.ClienteBE
    '            unCliente.persona.Id = cbPersona.SelectedItem.ToString
    '
    '            unaActividad = New ActividadBE
    '            unaActividad.nombre_actividad = cbActividad.SelectedItem.ToString
    '
    '            unaActividadBLL.Guardar_Actividad(unaActividad)
    '
    '            cargarDataGrid()
    '            limpiar()
    '            MsgBox("se dio de alta un registro")
    '            CargarCombo()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al guardar registro")
    '    End Try
    '
    'End Sub
End Class