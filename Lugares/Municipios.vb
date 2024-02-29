Imports MySql.Data.MySqlClient
Public Class municipios
    Private conexion As MySqlConnection
    Private adaptador As MySqlDataAdapter
    Private data As DataSet
    Dim respuesta As Integer
    Private Sub municipios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conexion.ConnectionString = "server=" & frmMEnu.txtdireccionbd.Text & ";Port=3306;database=" & frmMEnu.txtbd.Text & ";uid=" & frmMEnu.txtuser.Text & ";pwd=" & frmMEnu.txtpsw.Text & ";"
        Limpiar()
        Llenardepartamento("Select * from departamento")
        LlenarDATAGRID("Select * from municipiopordepartamento")
        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
        BtnEliminar.Enabled = False
    End Sub
    Public Sub Limpiar()
        txtNombremunicipio.Text = ""
        txtCodigomunicipio.Text = ""
        txtNombremunicipio.Text = ""
        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
    End Sub

    Sub LlenarDATAGRID(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
        Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
        data = New DataSet
        adaptador.Fill(data, "municipiopordepartamento")
        Dim tablatemporal As DataRowCollection
        Dim Filatemporal As DataRow
        'a la tabla temporal agregar las filas de la consulta
        tablatemporal = data.Tables("municipiopordepartamento").Rows

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
            Next
            data.Clear()
        End If

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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        departamento.Show()
        Llenardepartamento("Select * from departamento")
    End Sub

    Private Sub cmbCodigodepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigodepartamento.SelectedIndexChanged
        cmbdepartamento.SelectedIndex = cmbCodigodepartamento.SelectedIndex
    End Sub

    Private Sub txtNombremunicipio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombremunicipio.KeyPress
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
        txtCodigomunicipio.Focus()
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click

        If txtCodigomunicipio.Text = "" Then
            MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
            txtCodigomunicipio.Focus()
            GoTo salir
        End If

        If txtNombremunicipio.Text = "" Then
            MsgBox("Debe ingresar la Nombredepartamento", vbExclamation, "¡Atención!")
            txtNombremunicipio.Focus()
            GoTo salir
        End If

        respuesta = MsgBox("¿Desea agregar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
        If respuesta = 6 Then
            adaptador = New MySqlDataAdapter("Select * from municipio where Codigomunicipio = " & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "", frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "municipio")

            If data.Tables("municipio").Rows.Count = 0 Then
                adaptador = New MySqlDataAdapter("Insert into municipio (Codigodepartamento, Codigomunicipio, Nombremunicipio) values(" & cmbCodigodepartamento.Text & ", " & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & ", '" & txtNombremunicipio.Text.ToUpper & "')", frmMenu.conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "municipio")
                MsgBox("Registro agregado exitosamente", MsgBoxStyle.Information, "Información")
                data.Clear()
                'Llama la función de limpiar
                Limpiar()
                'Se actualiza el grid para ver el nuevo registro agregado
                LlenarDATAGRID("SELECT * FROM municipiopordepartamento ")
            Else
                MsgBox("El registro con ese código ya existe", MsgBoxStyle.Exclamation, "¡Atención!")
                txtCodigomunicipio.Focus()
            End If
        End If
salir:
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnModificar.Click
        Try
            If txtCodigomunicipio.Text = "" Then
                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
                txtCodigomunicipio.Focus()
                GoTo salir
            End If

            If txtNombremunicipio.Text = "" Then
                MsgBox("Debe ingresar el nombre del municipio", vbExclamation, "¡Atención!")
                txtNombremunicipio.Focus()
                GoTo salir
            End If

            respuesta = MsgBox("¿Desea modificar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from municipio where Codigodepartamento = '" & cmbCodigodepartamento.Text & "' and Codigomunicipio= '" & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "municipio")

                If data.Tables("municipio").Rows.Count > 0 Then
                    adaptador = New MySqlDataAdapter("Update municipio set Nombremunicipio= '" & txtNombremunicipio.Text & "' where Codigodepartamento = '" & cmbCodigodepartamento.Text & "' and Codigomunicipio= '" & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "municipio")
                    MsgBox("Registro modificado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    txtCodigomunicipio.Focus()
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                    BtnGuardar.Enabled = True
                    'Se actualiza el grid para ver el nuevo registro agregado
                    LlenarDATAGRID("SELECT * FROM municipiopordepartamento ")
                Else
                    MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigomunicipio.Focus()
                End If
            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEliminar.Click

        If txtCodigomunicipio.Text = "" Then
            MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
            txtCodigomunicipio.Focus()
            GoTo salir
        End If



        respuesta = MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
        If respuesta = 6 Then
            adaptador = New MySqlDataAdapter("Select * from municipio where Codigodepartamento = '" & cmbCodigodepartamento.Text & "' and Codigomunicipio= '" & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "'", frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "municipio")

            If data.Tables("municipio").Rows.Count > 0 Then

                adaptador = New MySqlDataAdapter("Select * from comunidades where Codigomunicipio = '" & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "'", frmMenu.conexion)
                Dim oCommBuild2 As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "comunidades")
                If data.Tables("comunidades").Rows.Count = 0 Then

                    adaptador = New MySqlDataAdapter("Delete from municipio where Codigodepartamento = '" & cmbCodigodepartamento.Text & "' and Codigomunicipio= '" & cmbCodigodepartamento.Text & txtCodigomunicipio.Text & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "municipio")
                    MsgBox("Registro eliminado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    txtCodigomunicipio.Focus()
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                    'Se actualiza el grid para ver el nuevo registro agregado
                    LlenarDATAGRID("SELECT * FROM municipiopordepartamento ")
                Else
                    MsgBox("Hay comunidades dependientes de este municipio, no puede eliminarse", MsgBoxStyle.Exclamation, "¡Atención!")

                End If
            Else
                MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                txtCodigomunicipio.Focus()
            End If

        End If
salir:
    End Sub

    Private Sub dgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv1.Click
        Try
            Dim indice As Integer
            indice = dgv1.CurrentRow.Index

            For i As Integer = 0 To dgv1.RowCount - 1
                cmbCodigodepartamento.SelectedIndex = i
                If dgv1.Item(0, i).Value.ToString = cmbCodigodepartamento.Text.ToString Then
                    GoTo salir
                End If
            Next
salir:
            txtCodigomunicipio.Text = dgv1.Item(2, indice).Value.ToString.Substring(2, 2)
            txtNombremunicipio.Text = dgv1.Item(3, indice).Value
            BtnModificar.Enabled = True
            BtnGuardar.Enabled = False
            BtnEliminar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCodigomunicipio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigomunicipio.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombremunicipio.Focus()
        End If
    End Sub
End Class