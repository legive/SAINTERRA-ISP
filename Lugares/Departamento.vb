Imports MySql.Data.MySqlClient
Public Class departamento
    Private conexion As MySqlConnection
    Private adaptador As MySqlDataAdapter
    Private data As DataSet
    Dim respuesta As Integer

    Private Sub departamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
        Limpiar()
        LlenarDATAGRID("Select * from departamento")
        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
        BtnEliminar.Enabled = False
    End Sub
    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub



    Public Sub Limpiar()
        txtNombredepartamento.Text = ""
        txtCodigo.Text = ""
        BtnGuardar.Enabled = True
    End Sub

    Sub LlenarDATAGRID(ByVal consulta As String)

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

            Next
            data.Clear()
        End If

    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.Click
        Limpiar()
        txtCodigo.Focus()
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click
        Try
            If txtCodigo.Text = "" Then
                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
                txtCodigo.Focus()
                GoTo salir
            End If

            If txtNombredepartamento.Text = "" Then
                MsgBox("Debe ingresar la Nombredepartamento", vbExclamation, "¡Atención!")
                txtNombredepartamento.Focus()
                GoTo salir
            End If

            respuesta = MsgBox("¿Desea agregar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from departamento where Codigodepartamento = " & txtCodigo.Text & "", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "departamento")

                If data.Tables("departamento").Rows.Count = 0 Then
                    adaptador = New MySqlDataAdapter("Insert into departamento (Codigodepartamento, Nombredepartamento) values(" & txtCodigo.Text & ",'" & txtNombredepartamento.Text.ToUpper & "')", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "departamento")
                    MsgBox("Registro agregado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    LlenarDATAGRID("SELECT * FROM departamento ")
                Else
                    MsgBox("El registro con ese código ya existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigo.Focus()
                End If
            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnModificar.Click
        Try
            If txtCodigo.Text = "" Then
                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
                txtCodigo.Focus()
                GoTo salir
            End If

            If txtNombredepartamento.Text = "" Then
                MsgBox("Debe ingresar la Nombredepartamento", vbExclamation, "¡Atención!")
                txtNombredepartamento.Focus()
                GoTo salir
            End If

            respuesta = MsgBox("¿Desea modificar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from departamento where Codigodepartamento = " & txtCodigo.Text & "", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "departamento")

                If data.Tables("departamento").Rows.Count > 0 Then
                    adaptador = New MySqlDataAdapter("Update departamento set Nombredepartamento = " & txtNombredepartamento.Text & " where Codigodepartamento = '" & txtCodigo.Text & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "departamento")
                    MsgBox("Registro modificado exitosamente", MsgBoxStyle.Information, "Información")
                    data.Clear()
                    'Llama la función de limpiar
                    Limpiar()
                    txtCodigo.Focus()
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                    BtnGuardar.Enabled = True
                    'Se actualiza el grid para ver el nuevo registro agregado
                    LlenarDATAGRID("SELECT * FROM departamento ")
                Else
                    MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigo.Focus()
                End If
            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEliminar.Click
        Try
            If txtCodigo.Text = "" Then
                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
                txtCodigo.Focus()
                GoTo salir
            End If

            If txtNombredepartamento.Text = "" Then
                MsgBox("Debe ingresar la Nombredepartamento", vbExclamation, "¡Atención!")
                txtNombredepartamento.Focus()
                GoTo salir
            End If

            respuesta = MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from departamento where Codigodepartamento = '" & txtCodigo.Text & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "departamento")


                If data.Tables("departamento").Rows.Count > 0 Then
                    adaptador = New MySqlDataAdapter("Select * from municipio where Codigodepartamento = '" & txtCodigo.Text & "'", frmMenu.conexion)
                    Dim oCommBuild2 As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "municipio")
                    If data.Tables("municipio").Rows.Count = 0 Then

                        adaptador = New MySqlDataAdapter("Delete from departamento where Codigodepartamento = '" & txtCodigo.Text & "'", frmMenu.conexion)
                        oCommBuild = New MySqlCommandBuilder(adaptador)
                        adaptador.Fill(data, "departamento")
                        MsgBox("Registro eliminado exitosamente", MsgBoxStyle.Information, "Información")
                        data.Clear()
                        'Llama la función de limpiar
                        Limpiar()
                        txtCodigo.Focus()
                        BtnModificar.Enabled = False
                        BtnEliminar.Enabled = False
                        'Se actualiza el grid para ver el nuevo registro agregado
                        LlenarDATAGRID("SELECT * FROM departamento ")
                    Else
                        MsgBox("Hay municipios dependientes de este departamento, no puede eliminarse", MsgBoxStyle.Exclamation, "¡Atención!")
                        txtCodigo.Focus()
                    End If
                Else
                    MsgBox("El registro con ese código no existe", MsgBoxStyle.Exclamation, "¡Atención!")
                    txtCodigo.Focus()
                End If


            End If
salir:
        Catch
        End Try
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        LlenarDATAGRID("SELECT * FROM departamento where Codigodepartamento like '%" & txtCodigo.Text & "%'")
    End Sub


    Private Sub dgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv1.Click
        Try
            Dim indice As Integer
            indice = dgv1.CurrentRow.Index
            txtCodigo.Text = dgv1.Item(0, indice).Value
            txtNombredepartamento.Text = dgv1.Item(1, indice).Value
            BtnModificar.Enabled = True
            BtnGuardar.Enabled = False
            BtnEliminar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNombredepartamento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombredepartamento.KeyPress
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


    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombredepartamento.Focus()
        End If
    End Sub
End Class