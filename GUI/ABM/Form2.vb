Imports BLL_
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombo()
        cargarDataGrid()
    End Sub

    Public Sub limpiar()
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDNI.Text = ""
        txtDireccion.Text = ""
        txtDpto.Text = ""
        txtTelefono.Text = ""
        txtId.Text = ""
        cbSexo.Text = Nothing
        cbBuscarRegistro.Text = Nothing
        cbLocalidad.Text = Nothing

        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnGuardar.Enabled = True
    End Sub


    Public Sub cargarDataGrid()
        Dim UnaPersona As New BLL_.PersonaBLL

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = UnaPersona.Listar()

        'DataGridView1.Columns(8).Visible = False
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim unaPersonaBE As New BE.PersonaBE
        Dim unaPersonaBLL As New BLL_.PersonaBLL

        Try
            If Not IsNothing(unaPersonaBE) Then
                unaPersonaBE.Id = txtId.Text
                unaPersonaBE.nombre = txtNombre.Text
                unaPersonaBE.apellido = txtApellido.Text
                unaPersonaBE.dni = txtDNI.Text
                unaPersonaBE.direccion = txtDireccion.Text
                unaPersonaBE.telefono = txtTelefono.Text
                unaPersonaBE.Dpto = txtDpto.Text
                unaPersonaBE.sexo = New BE.SexoBE
                unaPersonaBE.sexo.Id = cbSexo.SelectedItem.ToString
                unaPersonaBE.localidad = New BE.LocalidadBE
                unaPersonaBE.localidad.Id = cbLocalidad.SelectedItem.ToString

                unaPersonaBLL.Guardar(unaPersonaBE)

                MessageBox.Show("Se realizó modificacion con exito")
                cargarDataGrid()
                limpiar()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim unaLocalidad As New BLL_.LocalidadBLL
            Dim DT As New DataTable
            Dim tabla As New DataSet
            Dim unSexo As New BLL_.SexoBLL
            Dim p As Integer
            p = e.RowIndex
            Dim selectedRow As DataGridViewRow
            Dim QLocalidad As String = Nothing
            Dim QSexo As String = Nothing
            selectedRow = DataGridView1.Rows(p)

            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnGuardar.Enabled = False

            txtId.Text = selectedRow.Cells(8).Value.ToString
            txtNombre.Text = selectedRow.Cells(0).Value.ToString
            txtApellido.Text = selectedRow.Cells(1).Value.ToString
            txtDNI.Text = selectedRow.Cells(2).Value.ToString
            txtDireccion.Text = selectedRow.Cells(6).Value.ToString
            txtTelefono.Text = selectedRow.Cells(3).Value.ToString
            txtDpto.Text = selectedRow.Cells(5).Value.ToString
            QSexo = selectedRow.Cells(7).Value.ToString
            'cbProvincia.Text = selectedRow.Cells(9).Value.ToString
            QLocalidad = selectedRow.Cells(4).Value.ToString

            DT = unaLocalidad.QueryLocalidadBLL(QLocalidad, DT)
            cbLocalidad.DataSource = DT
            QLocalidad = cbLocalidad.Text.ToString

            cbLocalidad.DataSource = unaLocalidad.Listar()
            cbLocalidad.ValueMember = "Nombre_localidad"
            cbLocalidad.Text = QLocalidad.ToString


            DT = New DataTable

            DT = unSexo.QuerySexoBLL(QSexo, DT)
            cbSexo.DataSource = DT
            QSexo = cbSexo.Text.ToString

            cbSexo.DataSource = unSexo.Listar()
            cbSexo.ValueMember = "sexo"
            cbSexo.Text = QSexo.ToString


        Catch ex As Exception
            MsgBox("Error DataGridView1 - Carga")
        End Try
    End Sub

    Public Sub CargarCombo()
        Dim unaLocalidad As New BLL_.LocalidadBLL
        Dim unaPersona As New BLL_.PersonaBLL
        Dim unaProvincia As New BLL_.ProvinciaBLL
        Dim unSexo As New BLL_.SexoBLL

        'cbBuscarRegistro.DataSource = Nothing
        cbBuscarRegistro.DataSource = UnaPersona.Listar()
        cbBuscarRegistro.ValueMember = "DNI"

        'cbLocalidad.DataSource = Nothing
        cbLocalidad.DataSource = unaLocalidad.Listar()
        cbLocalidad.ValueMember = "Nombre_localidad"

        cbSexo.DataSource = unSexo.Listar()
        cbSexo.ValueMember = "Sexo"


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If txtDNI.MaskFull And txtTelefono.MaskFull Then

            Dim unaPersona As New BE.PersonaBE
            Dim unaPersonaBLL As New BLL_.PersonaBLL

            Try
                If txtNombre.Text = Nothing Or txtApellido.Text = Nothing Or txtDNI.Text = Nothing Or txtDireccion.Text = Nothing Or txtTelefono.Text = Nothing Or cbSexo.Text = Nothing Then
                    MsgBox("Complete todos los campos para continuar")
                Else
                    unaPersona.nombre = txtNombre.Text
                    unaPersona.apellido = txtApellido.Text
                    unaPersona.dni = txtDNI.Text
                    unaPersona.direccion = txtDireccion.Text
                    unaPersona.telefono = txtTelefono.Text
                    unaPersona.Dpto = txtDpto.Text

                    unaPersona.sexo = New BE.SexoBE
                    unaPersona.sexo.Id = cbSexo.SelectedItem.ToString

                    unaPersona.localidad = New BE.LocalidadBE
                    unaPersona.localidad.Id = cbLocalidad.SelectedItem.ToString


                    unaPersonaBLL.Guardar(unaPersona)

                    cargarDataGrid()
                    limpiar()
                    MsgBox("se dio de alta un registro")
                    CargarCombo()
                End If
            Catch ex As Exception
                MsgBox("Error al guardar registro")
            End Try
        Else
            MsgBox("Complete los campos totalmente")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        limpiar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim unaPersonaBE As New BE.PersonaBE
            Dim unaPersonaBLL As New BLL_.PersonaBLL

            unaPersonaBE.Id = txtId.Text
            unaPersonaBE.nombre = txtNombre.Text
            unaPersonaBE.apellido = txtApellido.Text
            unaPersonaBE.dni = txtDNI.Text
            unaPersonaBE.direccion = txtDireccion.Text
            unaPersonaBE.telefono = txtTelefono.Text
            unaPersonaBE.Dpto = txtDpto.Text

            unaPersonaBE.sexo = New BE.SexoBE
            unaPersonaBE.sexo.Id = cbSexo.SelectedItem.ToString

            unaPersonaBE.localidad = New BE.LocalidadBE
            unaPersonaBE.localidad.Id = cbLocalidad.SelectedItem.ToString


            If MsgBox("Confirma la eliminacion de " & unaPersonaBE.dni, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                unaPersonaBLL.Eliminar(unaPersonaBE)

                cargarDataGrid()
                MsgBox("Registro eliminado correctamente")
                limpiar()

            End If

        Catch ex As Exception
            MsgBox("Error al intentar eliminar")
        End Try

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Dim unaLocalidad As New BLL_.LocalidadBLL
        Dim DT As New DataTable
        Dim tabla As New DataSet
        Dim unSexo As New BLL_.SexoBLL
        Dim selectedRow As DataGridViewRow
        Dim QLocalidad As String = Nothing
        Dim QSexo As String = Nothing

        Dim buscar As String
        Dim a = DataGridView1.Rows.Count()

        buscar = cbBuscarRegistro.Text

        If DataGridView1.Rows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If Not DataGridView1.Rows.Item(i) Is Nothing Then

                    If DataGridView1.Rows.Item(i).Cells("DNI").Value = buscar Then

                        selectedRow = DataGridView1.Rows(i)

                        btnModificar.Enabled = True
                        btnEliminar.Enabled = True
                        btnGuardar.Enabled = False

                        txtId.Text = selectedRow.Cells(8).Value.ToString
                        txtNombre.Text = selectedRow.Cells(0).Value.ToString
                        txtApellido.Text = selectedRow.Cells(1).Value.ToString
                        txtDNI.Text = selectedRow.Cells(2).Value.ToString
                        txtDireccion.Text = selectedRow.Cells(6).Value.ToString
                        txtTelefono.Text = selectedRow.Cells(3).Value.ToString
                        txtDpto.Text = selectedRow.Cells(5).Value.ToString
                        QSexo = selectedRow.Cells(7).Value.ToString
                        'cbProvincia.Text = selectedRow.Cells(9).Value.ToString
                        QLocalidad = selectedRow.Cells(4).Value.ToString

                        DT = unaLocalidad.QueryLocalidadBLL(QLocalidad, DT)
                        cbLocalidad.DataSource = DT
                        QLocalidad = cbLocalidad.Text.ToString

                        cbLocalidad.DataSource = unaLocalidad.Listar()
                        cbLocalidad.ValueMember = "Nombre_localidad"
                        cbLocalidad.Text = QLocalidad.ToString


                        DT = New DataTable

                        DT = unSexo.QuerySexoBLL(QSexo, DT)
                        cbSexo.DataSource = DT
                        QSexo = cbSexo.Text.ToString

                        cbSexo.DataSource = unSexo.Listar()
                        cbSexo.ValueMember = "sexo"
                        cbSexo.Text = QSexo.ToString

                    End If

                End If
            Next
        End If





    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class