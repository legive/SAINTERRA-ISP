Imports MySql.Data.MySqlClient
Public Class comunidades
    Private conexion As MySqlConnection
    Private adaptador As MySqlDataAdapter
    Private data As DataSet
    Dim respuesta As Integer
    Dim comunidad As String
    Private Sub comunidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conexion.ConnectionString = "server=" & frmMEnu.txtdireccionbd.Text & ";Port=3306;database=" & frmMEnu.txtbd.Text & ";uid=" & frmMEnu.txtuser.Text & ";pwd=" & frmMEnu.txtpsw.Text & ";"
        Limpiar()
        Llenardepartamento("Select * from departamento")
        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigodepartamento.Text & "")
        LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0' and Codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & "")
        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
        BtnEliminar.Enabled = False
        comunidad = txtCodigoComunidad.Text
        txtCodigoComunidad.Focus()
    End Sub
    Sub Llenarmunicipios(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
        Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
        data = New DataSet
        adaptador.Fill(data, "municipio")
        Dim tablatemporal As DataRowCollection
        Dim Filatemporal As DataRow
        'a la tabla temporal agregar las filas de la consulta
        tablatemporal = data.Tables("municipio").Rows

        'si la consulta agregada a la tabla temporal tiene datos o filas
        If tablatemporal.Count > 0 Then
            'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
            cmbCodigomunicipio.Items.Clear()
            cmbNombremunicipio.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigomunicipio.Items.Add(Filatemporal("Codigomunicipio"))
                cmbNombremunicipio.Items.Add(Filatemporal("Nombremunicipio"))

            Next
            cmbCodigomunicipio.SelectedIndex = 0
            data.Clear()
        End If

    End Sub
    Public Sub Limpiar()
        txtCodigoComunidad.Text = ""
        txtNombreComunidad.Text = ""
        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
        LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0' and Codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & "")

    End Sub

    Sub LlenarDATAGRID(ByVal consulta As String)
        Try
            adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "comunidadpormunicipio")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("comunidadpormunicipio").Rows

            'si la consulta agregada a la tabla temporal tiene datos o filas
            If tablatemporal.Count > 0 Then
                'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
                dgv1.Rows.Clear()
                dgv1.RowCount = tablatemporal.Count
                'recorrer cada fila
                For i As Integer = 0 To tablatemporal.Count - 1

                    Filatemporal = tablatemporal.Item(i)

                    'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                    'agrega a la columna cero del grid la columna Codigodepartamento de la tabla en la base de datos de la primer fila de la tabla temporal
                    dgv1.Item(0, i).Value = Filatemporal("Codigodepartamento")

                    'agrega a la columna 1 del grid la columna Nombredepartamento de la tabla en la base de datos de la primer fila de la tabla temporal
                    dgv1.Item(1, i).Value = Filatemporal("Nombredepartamento")
                    dgv1.Item(2, i).Value = Filatemporal("Codigomunicipio")
                    dgv1.Item(3, i).Value = Filatemporal("Nombremunicipio")
                    dgv1.Item(4, i).Value = Filatemporal("CodigoComunidad")
                    dgv1.Item(5, i).Value = Filatemporal("NombreComunidad")
                Next
                data.Clear()
            End If
        Catch
        End Try
    End Sub
    Sub Llenardepartamento(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
        Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
        data = New DataSet
        adaptador.Fill(data, "departamento")
        Dim tablatemporal As DataRowCollection
        Dim Filatemporal As DataRow
        'a la tabla temporal agregar las filas de la consulta
        tablatemporal = data.Tables("departamento").Rows

        'si la consulta agregada a la tabla temporal tiene datos o filas
        If tablatemporal.Count > 0 Then
            'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
            cmbCodigodepartamento.Items.Clear()
            cmbdepartamento.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigodepartamento.Items.Add(Filatemporal("Codigodepartamento"))
                cmbdepartamento.Items.Add(Filatemporal("Nombredepartamento"))

            Next
            cmbdepartamento.SelectedIndex = 0
            data.Clear()
        End If

    End Sub

    Private Sub cmbdepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepartamento.SelectedIndexChanged

        cmbCodigodepartamento.SelectedIndex = cmbdepartamento.SelectedIndex
        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigodepartamento.Text & "")
        LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0' and Codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & "")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        departamento.Show()
        Llenardepartamento("Select * from departamento")
        Llenarmunicipios("Select * from municipio where Codigodepartamento='" & cmbCodigodepartamento.Text & "'")
    End Sub

    Private Sub cmbCodigodepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigodepartamento.SelectedIndexChanged
        cmbdepartamento.SelectedIndex = cmbCodigodepartamento.SelectedIndex
    End Sub

    Private Sub txtNombremunicipio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ áéíóúÁÉÍÓÚ", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.Click
        Limpiar()
        txtCodigoComunidad.Focus()
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click
        Try
            If txtCodigoComunidad.Text = "" Then
                MsgBox("Debe ingresar el Nombre de la Comunidad", vbExclamation, "¡Atención!")
                txtCodigoComunidad.Focus()
                GoTo salir
            End If

            respuesta = MsgBox("¿Desea agregar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from comunidades where CodigoComunidad = '" & txtCodigoComunidad.Text & "' and Codigomunicipio=" & cmbCodigomunicipio.Text & "", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "comunidades")

                If data.Tables("comunidades").Rows.Count = 0 Then
                    adaptador = New MySqlDataAdapter("Insert into comunidades (Codigomunicipio, CodigoComunidad, NombreComunidad) values('" & cmbCodigomunicipio.Text & "', '" & cmbCodigomunicipio.Text & txtCodigoComunidad.Text.ToUpper & "', '" & txtNombreComunidad.Text.ToUpper & "')", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "comunidades")
                    MsgBox("Registro agregado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    'LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0'")
                Else
                    MsgBox("El registro con ese código ya existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigoComunidad.Focus()
                End If
            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnModificar.Click
        Try
            If txtCodigoComunidad.Text = "" Then
                MsgBox("Debe ingresar el Nombre de la Comunidad", vbExclamation, "¡Atención!")
                txtCodigoComunidad.Focus()
                GoTo salir
            End If


            respuesta = MsgBox("¿Desea modificar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from comunidades where CodigoComunidad = '" & txtCodigoComunidad.Text & "' and Codigomunicipio=" & cmbCodigomunicipio.Text & "", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "comunidades")

                If data.Tables("comunidades").Rows.Count > 0 Then
                    adaptador = New MySqlDataAdapter("Update comunidades set NombreComunidad= '" & txtNombreComunidad.Text & "'  where Codigomunicipio= " & cmbCodigomunicipio.Text & " and Codigocomunidad=" & comunidad & "", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "comunidades")
                    MsgBox("Registro modificado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    txtCodigoComunidad.Focus()
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                    BtnGuardar.Enabled = True
                    'Se actualiza el grid para ver el nuevo registro agregado
                    'LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0'")
                Else
                    MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigoComunidad.Focus()
                End If
            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEliminar.Click

        Try
            If txtCodigoComunidad.Text = "" Then
                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
                txtCodigoComunidad.Focus()
                GoTo salir
            End If



            respuesta = MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from comunidades where Codigomunicipio= " & cmbCodigomunicipio.Text & " and Codigocomunidad='" & comunidad & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "comunidades")

                If data.Tables("comunidades").Rows.Count > 0 Then

                    adaptador = New MySqlDataAdapter("Select * from clientes where CodigoComunidad = '" & txtCodigoComunidad.Text & "'", frmMenu.conexion)
                    Dim oCommBuild2 As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    If data.Tables("clientes").Rows.Count = 0 Then

                        adaptador = New MySqlDataAdapter("Delete from comunidades where Codigomunicipio= " & cmbCodigomunicipio.Text & " and Codigocomunidad='" & comunidad & "'", frmMenu.conexion)
                        oCommBuild = New MySqlCommandBuilder(adaptador)
                        adaptador.Fill(data, "comunidades")
                        MsgBox("Registro eliminado exitosamente", MsgBoxStyle.Information, "Información")
                        data.Clear()
                        'Llama la función de limpiar
                        Limpiar()
                        txtCodigoComunidad.Focus()
                        BtnModificar.Enabled = False
                        BtnEliminar.Enabled = False
                        'Se actualiza el grid para ver el nuevo registro agregado
                        'LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0'")
                    Else
                        MsgBox("Hay clientes dependientes de esta comunidad, no puede eliminarse", MsgBoxStyle.Exclamation, "¡Atención!")

                    End If
                Else
                    MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigoComunidad.Focus()
                End If



            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub dgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv1.Click
        Try
            Dim indice As Integer
            '            indice = dgv1.CurrentRow.Index
            '            comunidad = txtCodigoComunidad.Text
            '            For i As Integer = 0 To dgv1.RowCount - 1
            '                cmbCodigodepartamento.SelectedIndex = i
            '                If dgv1.Item(0, indice).Value.ToString = cmbCodigodepartamento.Text.ToString Then
            '                    GoTo salir
            '                End If
            '            Next
            'salir:
            '            For i As Integer = 0 To dgv1.RowCount - 1
            '                cmbCodigomunicipio.SelectedIndex = i
            '                If dgv1.Item(2, indice).Value.ToString = cmbCodigomunicipio.Text.ToString Then
            '                    GoTo salir2
            '                End If
            '            Next
            'salir2:

            txtCodigoComunidad.Text = dgv1.Item(4, indice).Value
            comunidad = txtCodigoComunidad.Text
            txtNombreComunidad.Text = dgv1.Item(5, indice).Value
            BtnModificar.Enabled = True
            BtnGuardar.Enabled = False
            BtnEliminar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        municipios.Show()
        Llenardepartamento("Select * from departamento")
        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigodepartamento.Text & "")
    End Sub

    Private Sub cmbNombremunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombremunicipio.SelectedIndexChanged

        cmbCodigomunicipio.SelectedIndex = cmbNombremunicipio.SelectedIndex
        LlenarDATAGRID("Select * from comunidadpormunicipio where codigoComunidad<>'0' and Codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & "")

    End Sub

    Private Sub cmbCodigomunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigomunicipio.SelectedIndexChanged
        cmbNombremunicipio.SelectedIndex = cmbCodigomunicipio.SelectedIndex
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar()
    End Sub

    Private Sub txtCodigoComunidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoComunidad.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúÁÉÍÓÚ", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    'Private Sub txtCodigoComunidad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoComunidad.Validating
    '    Try
    '        txtCodigoComunidad.Text = txtCodigoComunidad.Text.ToUpper
    '        txtCodigoComunidad.Focus()
    '    Catch
    '    End Try
    'End Sub

    'Private Sub txtNombreComunidad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNombreComunidad.Validating
    '    txtNombreComunidad.Text = txtNombreComunidad.Text.ToUpper
    'End Sub


    Private Sub txtCodigoComunidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoComunidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombreComunidad.Focus()
        End If
    End Sub

    Private Sub txtNombreComunidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreComunidad.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ áéíóúÁÉÍÓÚ", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class