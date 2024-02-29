Imports MySql.Data.MySqlClient
Public Class Fallas
    'Public conec As New Conexion
    Dim INS As New Instalación
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Public varid, identidad, consulta1, consulta2, consulta3, identidadPagos, idCliente As String
    Public respuesta, formulario, ActivoD As Integer
    Dim entro As Boolean

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Limpiar()
    End Sub

    Dim NDEI As Integer
    Public clientesForm, conexion2 As Boolean

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from Fallas where No = " & Num.Text & " ", frmmenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "Fallas")

                If data.Tables("Fallas").Rows.Count > 0 Then

                    adaptador = New MySqlDataAdapter("Delete from Fallas where No=" & Num.Text & "", frmmenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "Fallas")
                    InsertarBitacora("SE ELIMINÓ FALLA EN  " & Descripcion.Text & " ")

                    MsgBox("Registro eliminado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()



                End If
            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenaGrid("SELECT * FROM Fallas where fechaFalla between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' order by fechafalla asc ")
    End Sub

    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Reclamos.fecha.Value = fecha.Value
        Reclamos.ShowDialog()
    End Sub

    Private Sub dgvFallas_Click(sender As Object, e As EventArgs) Handles dgvFallas.Click
        Seleccionar()
    End Sub

    Public Function incrementaCodigo(ByVal consulta As String, ByVal campo As String)
        'inicializaConexion(frmmenu.txtDireccionBD.Text)
        Dim contador As Integer
        Try
            data.Clear()

            adaptador = New MySqlDataAdapter(consulta, frmmenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "Fallas")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("Fallas").Rows

            'si la consulta agregada a la tabla temporal tiene datos o filas
            If tablatemporal.Count >= 1 Then
                Filatemporal = tablatemporal.Item(tablatemporal.Count - 1)
                contador = Filatemporal(campo) + 1
            Else
                contador = 1
            End If
            data.Clear()
            Return contador

        Catch ex As Exception
            'MsgBox(ex.Message.ToString())
        End Try

        Return contador
    End Function

    Private Sub Fallas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        fecha.Value = Today
        Fecha2.Value = Today

        dgvFallas.Rows.Clear()

    End Sub
    Sub Limpiar()
        txtIndisponibilidad.Text = 0
        Descripcion.Text = ""
        Num.Text = incrementaCodigo("Select * from Fallas  order by No", "No")
        llenaGrid("SELECT * FROM Fallas where fechaFalla between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' ")

    End Sub
    Public Function ConsultarRegistro(ByVal cadena As String)
        Try
            data.Clear()
            adaptador = New MySqlDataAdapter(cadena, frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "Resultado")
            tablatemp = data.Tables("Resultado").Rows
            Return tablatemp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "ERROR")
            Return tablatemp
        End Try
    End Function
    Sub llenaGrid(ByVal cadena As String)
        Try
            dgvFallas.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)

            If tablatemp.Count > 0 Then
                dgvFallas.RowCount = tablatemp.Count
                txtIndisponibilidad.Text = 0
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvFallas.Item(0, l).Value = rowtemp("No")
                    dgvFallas.Item(1, l).Value = rowtemp("tipoFalla")
                    dgvFallas.Item(2, l).Value = rowtemp("FechaFalla")
                    dgvFallas.Item(3, l).Value = rowtemp("HoraFalla")
                    dgvFallas.Item(4, l).Value = rowtemp("FechaSolucion")
                    dgvFallas.Item(5, l).Value = rowtemp("HoraSolucion")
                    dgvFallas.Item(6, l).Value = rowtemp("DescripcionFalla")
                    'fecha.Value =

                    fecha.Value = dgvFallas.Item(2, l).Value
                    Fecha2.Value = dgvFallas.Item(4, l).Value
                    dgvFallas.Item(7, l).Value = DateDiff(DateInterval.Minute, fecha.Value, Fecha2.Value)
                    'Hour(System.Convert.ToDateTime(dgvFallas.Item(4, l).Value)) - Hour(System.Convert.ToDateTime(dgvFallas.Item(3, l).Value))
                    txtIndisponibilidad.Text = txtIndisponibilidad.Text + Val(dgvFallas.Item(7, l).Value)



                Next
                txtIndisponibilidad.Text = txtIndisponibilidad.Text / 60
                txtIndisponibilidad.Text = Int(txtIndisponibilidad.Text) & " horas y " & Decimal.Round((txtIndisponibilidad.Text - (Int(txtIndisponibilidad.Text))) * 60) & " minutos"
                'txtRecuento.Text = "No. Registros: " & dgvFallas.RowCount & ""
            Else
                dgvFallas.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try
            If Descripcion.Text = "" Then
                ErrorProvider1.SetError(Descripcion, "Ingrese Descripción")
                Descripcion.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            If Tipo.Text = "" Then
                ErrorProvider1.SetError(Tipo, "Seleccione el Tipo de Falla")
                Descripcion.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            If fecha.Value > Fecha2.Value Then
                ErrorProvider1.SetError(fecha, "la fecha de falla no puede ser mayor que la fecha de solución")
                fecha.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

            If fecha.Value = Fecha2.Value Then
                If Hour(fecha.Value) > Hour(Fecha2.Value) Then
                    ErrorProvider1.SetError(fecha, "la hora de falla no puede ser mayor que la hora de solución")
                    Tipo.Focus()
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
            End If


GUARDAR:
            respuesta = MsgBox("Desea agregar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                'Dim s As String = "Select * from Fallas where fechaFalla = '" & fecha.Value.ToString("yyyy-MM-dd") & "' and HoraFalla = '" & hora.Value.ToString("HH:mm") & "' and fechaSolucion = '" & Fecha2.Value.ToString("yyyy-MM-dd") & "' and HoraSolucion = '" & hora2.Value.ToString("HH:mm") & "' and tipoFalla = '" & Tipo.Text & "'"
                Dim s As String = "Select * from Fallas where No = " & Num.Text & ""

                adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "Fallas")

                If data.Tables("Fallas").Rows.Count = 0 Then

                    adaptador = New MySqlDataAdapter("Insert into Fallas (No, TipoFalla, FechaFalla, HoraFalla, FechaSolucion, HoraSolucion, DescripcionFalla) values(" & Num.Text & ", '" & Tipo.Text & "','" & fecha.Value.ToString("yyyy-MM-dd HH:mm") & "', '" & fecha.Value.ToString("HH:mm") & "', '" & Fecha2.Value.ToString("yyyy-MM-dd HH:mm") & "',  '" & Fecha2.Value.ToString("HH:mm") & "','" & Descripcion.Text.ToUpper & "')", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "Fallas")
                    InsertarBitacora("SE AGREGÓ FALLA EN  " & Descripcion.Text & " ")

                    MsgBox("Registro agregado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGrid("SELECT * FROM Fallas ")
                Else

                    'Dim a As String = "update clientes set idCliente='" & Id.Text & "', Nombre='" & Nombre.Text & "', telefono='" & Telefono.Text & "', correo='" & Correo.Text & "', Codigodepartamento=" & cmbCodigodepartamento.Text & ", Codigomunicipio=" & cmbCodigomunicipio.Text & ", CodigoComunidad='" & cmbCodigoComunidad.Text & "', Activo='" & activo & "', DEI='" & ActivoD & "', Direccion='" & txtDireccion.Text.ToUpper & "', No=" & No.Text & " where idCliente='" & Identidad & "'"

                    adaptador = New MySqlDataAdapter("update Fallas set TipoFalla='" & Tipo.Text & "', FechaFalla='" & fecha.Value.ToString("yyyy-MM-dd HH:mm") & "', HoraFalla='" & fecha.Value.ToString("HH:mm") & "', FechaSolucion='" & Fecha2.Value.ToString("yyyy-MM-dd HH:mm") & "', HoraSolucion='" & Fecha2.Value.ToString("HH:mm") & "' where No='" & Num.Text & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "Fallas")
                    MsgBox("Registro actualizado exitosamente")
                    data.Clear()

                    'Llama la funsion de limpiar
                    Limpiar()
                    'Num.Text = incrementaCodigo("Select * from reclamos where idCliente='" & Id.Text & "' order by No", "No")
                    'Se actualiza el grid para ver el nuevo registro agregado


                End If
            End If
            Nuevo_Click(Nuevo, e)
            llenaGrid("SELECT * FROM Fallas where fechaFalla between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' order by fechafalla asc ")

        Catch s As Exception
            MsgBox(s.ToString)
        End Try


salir:
    End Sub
    Sub Seleccionar()
        Try
            Num.Text = dgvFallas.Item(0, dgvFallas.CurrentRow.Index).Value
            For i As Integer = 0 To Tipo.Items.Count - 1
                Tipo.SelectedIndex = i
                If Tipo.Text.ToString.ToUpper = dgvFallas.Item(1, dgvFallas.CurrentRow.Index).Value.ToString Then
                    Tipo.SelectedIndex = i
                    GoTo salir1
                End If

            Next
salir1:
            fecha.Value = dgvFallas.Item(2, dgvFallas.CurrentRow.Index).Value
            'fecha.Value = System.Convert.ToDateTime(dgvFallas.Item(3, dgvFallas.CurrentRow.Index).Value.ToString)
            Fecha2.Value = dgvFallas.Item(4, dgvFallas.CurrentRow.Index).Value
            'hora2.Value = System.Convert.ToDateTime(dgvFallas.Item(5, dgvFallas.CurrentRow.Index).Value.ToString)
            Descripcion.Text = dgvFallas.Item(6, dgvFallas.CurrentRow.Index).Value.ToString


        Catch S As Exception
        End Try
    End Sub
End Class