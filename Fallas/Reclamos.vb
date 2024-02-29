Imports MySql.Data.MySqlClient
Public Class Reclamos
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Dim respuesta As Integer
    'Public conec As New Conexion
    Dim INS As New Instalación

    Dim oCommBuild As MySqlCommandBuilder

    Dim varid, meses As String
    Private tablatemp2, tablatemp3, tablatem4 As DataRowCollection

    Public NoCorrelativoFicha, no, DEI, descuentodias, descuentoHoras, tp, diasajuste, instalacionactiva As Integer
    Dim fechaPago, atlantida As String
    Dim dolar, isv, ISVE As Integer
    Dim entro, entro2, entro3 As Boolean
    Dim entroDei As Boolean
    Dim navegacion = 0, TipoPago As Integer
    Public idInstalacion, usuarioActual, mesActual, variosMeses As String
    Dim saldoDolar, filaspagos As Integer
    Dim mora, filasmora, botonNuevo As Integer
    Dim cambio, cambioant As Double
    'Sub conectar()1
    '    Try
    '        conexion = New MySqlConnection()
    '        conexion.ConnectionString = "server=" & frmMEnu.txtdireccionbd.Text & ";database=admininterrabd;uid=interraadmin;pwd=interra2012;"

    '        conexion.Open()
    '    Catch s As Exception
    '        MsgBox(s.ToString)
    '    End Try
    'End Sub
    Public Function incrementaCodigo(ByVal consulta As String, ByVal campo As String)
        'inicializaConexion(frmMenu.txtDireccionBD.Text)
        Dim contador As Integer
        Try
            data.Clear()

            adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "salidas")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("salidas").Rows

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

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Num.Text = incrementaCodigo("Select * from reclamos  order by No", "No")
        Descripcion.Text = ""
        txtNotas.Text = ""
        Id.Enabled = False
    End Sub

    Private Sub Reclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conectar()1
        Num.Text = incrementaCodigo("Select * from reclamos  order by No", "No")
        fecha.Value = Today
        Fecha2.Value = Today
        dgvReclamos.Rows.Clear()
        dgvResumen.Rows.Clear()
        Id.Enabled = False
    End Sub
    Sub Limpiar()
        Descripcion.Text = ""
        txtNotas.Text = ""
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
            dgvReclamos.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)

            If tablatemp.Count > 0 Then
                dgvReclamos.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvReclamos.Item(0, l).Value = rowtemp("No")
                    dgvReclamos.Item(1, l).Value = rowtemp("IdCliente")
                    dgvReclamos.Item(2, l).Value = rowtemp("nombre")
                    dgvReclamos.Item(3, l).Value = rowtemp("Tipo")
                    dgvReclamos.Item(4, l).Value = rowtemp("FechaReclamo")
                    dgvReclamos.Item(5, l).Value = rowtemp("Descripcion")
                    If rowtemp("Estado") = 1 Then
                        dgvReclamos.Item(6, l).Value = "EN PROCESO"
                    End If
                    If rowtemp("Estado") = 2 Then
                        dgvReclamos.Item(6, l).Value = "RESUELTO"
                    End If
                    If rowtemp("Estado") = 3 Then
                        dgvReclamos.Item(6, l).Value = "NO RESUELTO"
                    End If
                    'dgvReclamos.Item(6, l).Value = rowtemp("Estado")
                    dgvReclamos.Item(7, l).Value = rowtemp("FechaSolucion")
                    dgvReclamos.Item(8, l).Value = rowtemp("txtNota")

                Next
                'txtRecuento.Text = "No. Registros: " & dgvreclamos.RowCount & ""
            Else
                dgvReclamos.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub llenaGrid2(ByVal cadena As String, ByVal tipo As String)
        Try
            Dim recibidos, resueltos As Integer
            recibidos = 0
            resueltos = 0
            tablatemp = ConsultarRegistro(cadena)

            If tablatemp.Count > 0 Then
                dgvResumen.Rows.Add(1)

                For l As Integer = 0 To tablatemp.Count - 1

                    rowtemp = tablatemp.Item(l)

                    recibidos = recibidos + 1

                    If rowtemp("Estado") = 2 Then
                        resueltos = resueltos + 1
                    End If

                Next

                'txtRecuento.Text = "No. Registros: " & dgvreclamos.RowCount & ""
                dgvResumen.Item(0, dgvResumen.Rows.Count - 1).Value = tipo
                dgvResumen.Item(1, dgvResumen.Rows.Count - 1).Value = recibidos
                dgvResumen.Item(2, dgvResumen.Rows.Count - 1).Value = resueltos
                data.Clear()
            End If

        Catch m As Exception
        End Try
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try
            If Id.Text = "" Then
                ErrorProvider1.SetError(Id, "Ingrese el número de identidad")
                Id.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            If Nombre.Text = "" Then
                ErrorProvider1.SetError(Nombre, "Ingrese el nombre del cliente")
                Nombre.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

            If Tipo.Text = "" Then
                ErrorProvider1.SetError(Nombre, "Ingrese el tipo de reclamo")
                Tipo.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            If Descripcion.Text = "" Then
                ErrorProvider1.SetError(Nombre, "Ingrese la descripción del reclamo")
                Tipo.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

GUARDAR:
            respuesta = MsgBox("Desea agregar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Dim s As String = "Select * from reclamos where idCliente = '" & Id.Text & "' and No=" & Num.Text & ""
                adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "reclamos")

                If data.Tables("reclamos").Rows.Count = 0 Then

                    adaptador = New MySqlDataAdapter("Insert into reclamos (No, idCliente, tipo, FechaReclamo, Descripcion, Estado, FechaSolucion, txtNota) values(" & Num.Text & ", '" & Id.Text & "','" & Tipo.Text & "', '" & fecha.Value.ToString("yyyy-MM-dd") & "', '" & Descripcion.Text & "', " & cmbEstado.SelectedIndex + 1 & ", '" & Fecha2.Value.ToString("yyyy-MM-dd") & "','" & txtNotas.Text & "')", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "reclamos")
                    MsgBox("Registro agregado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGrid("SELECT * FROM vistareclamos ")
                Else

                    'Dim a As String = "update clientes set idCliente='" & Id.Text & "', Nombre='" & Nombre.Text & "', telefono='" & Telefono.Text & "', correo='" & Correo.Text & "', Codigodepartamento=" & cmbCodigodepartamento.Text & ", Codigomunicipio=" & cmbCodigomunicipio.Text & ", CodigoComunidad='" & cmbCodigoComunidad.Text & "', Activo='" & activo & "', DEI='" & ActivoD & "', Direccion='" & txtDireccion.Text.ToUpper & "', No=" & No.Text & " where idCliente='" & Identidad & "'"

                    adaptador = New MySqlDataAdapter("update reclamos set tipo='" & Tipo.Text & "', FechaReclamo='" & fecha.Value.ToString("yyy-MM-dd") & "', Descripcion='" & Descripcion.Text & "', Estado=" & cmbEstado.SelectedIndex + 1 & ", FechaSolucion='" & Fecha2.Value.ToString("yyyy-MM-dd") & "', txtNota='" & txtNotas.Text & "' where idCliente='" & Id.Text & "' and No=" & Num.Text & "", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "reclamos")
                    MsgBox("Registro actualizado exitosamente")
                    data.Clear()
                    llenaGrid("SELECT * FROM vistareclamos ")
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Num.Text = incrementaCodigo("Select * from reclamos where idCliente='" & Id.Text & "' order by No", "No")
                    'Se actualiza el grid para ver el nuevo registro agregado

                    Id.Focus()
                End If
            End If
            Num.Text = incrementaCodigo("Select * from reclamos order by No", "No")

        Catch s As Exception
            MsgBox(s.ToString)
        End Try


salir:
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from reclamos where idCliente = '" & Id.Text & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "reclamos")

                If data.Tables("reclamos").Rows.Count > 0 Then

                    adaptador = New MySqlDataAdapter("Delete from reclamos where idCliente='" & Id.Text & "' and No=" & Num.Text & "", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "reclamos")
                    MsgBox("Registro eliminado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGrid("Select * from vistareclamos ")
                    Id.Focus()
                End If
            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub


    Sub Seleccionar()
        Try
            Num.Text = dgvReclamos.Item(0, dgvReclamos.CurrentRow.Index).Value
            Id.Text = dgvReclamos.Item(1, dgvReclamos.CurrentRow.Index).Value
            Nombre.Text = dgvReclamos.Item(2, dgvReclamos.CurrentRow.Index).Value

            For i As Integer = 0 To Tipo.Items.Count - 1
                Tipo.SelectedIndex = i
                If Tipo.Text.ToString.ToUpper = dgvReclamos.Item(3, dgvReclamos.CurrentRow.Index).Value.ToString Then
                    Tipo.SelectedIndex = i
                    GoTo salir1
                End If

            Next
salir1:

            fecha.Value = dgvReclamos.Item(4, dgvReclamos.CurrentRow.Index).Value.ToString
            Descripcion.Text = dgvReclamos.Item(5, dgvReclamos.CurrentRow.Index).Value.ToString
            For i As Integer = 0 To cmbEstado.Items.Count - 1
                cmbEstado.SelectedIndex = i
                If cmbEstado.SelectedItem.ToString = dgvReclamos.Item(6, dgvReclamos.CurrentRow.Index).Value.ToString Then
                    cmbEstado.SelectedIndex = i
                    GoTo salir2
                End If

            Next
salir2:
            Fecha2.Value = dgvReclamos.Item(7, dgvReclamos.CurrentRow.Index).Value.ToString
            txtNotas.Text = dgvReclamos.Item(8, dgvReclamos.CurrentRow.Index).Value.ToString


        Catch S As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenaGrid("SELECT * FROM vistareclamos where fechaReclamo between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' ")

        dgvResumen.Rows.Clear()
        For i As Integer = 0 To Tipo.Items.Count - 1
            llenaGrid2("SELECT * FROM vistareclamos where (fechaReclamo between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' ) and tipo='" & Tipo.Items.Item(i).ToString & "' ", Tipo.Items.Item(i).ToString)
        Next

    End Sub

    Private Sub dgvReclamos_Click(sender As Object, e As EventArgs) Handles dgvReclamos.Click
        Seleccionar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        llenaGrid("SELECT * FROM vistareclamos where estado=" & cmbEstado.SelectedIndex + 1 & "")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Fallas.fecha.Value = fecha.Value
        Fallas.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        llenaGrid("SELECT * FROM vistareclamos where idCliente='" & Id.Text & "'")

    End Sub

    Private Sub Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If entro = True Then

            llenaList("Select distinct(idcliente), nombre from vistapagos where Nombre like '%" & Nombre.Text & "%' ")

            'End If
        End If
    End Sub
    Sub llenaList(ByVal cadena As String)
        Try
            lbClientes.Items.Clear()
            LbClientesId.Items.Clear()
            tablatemp3 = ConsultarRegistro(cadena)
            filaspagos = 0
            If tablatemp3.Count > 1 Then
                filaspagos = 1
                'dgvPagos.RowCount = tablatemp3.Count
                lbClientes.Visible = True
                lbClientes.BringToFront()
                For i As Integer = 0 To tablatemp3.Count - 1
                    rowtemp = tablatemp3.Item(i)
                    LbClientesId.Items.Add(rowtemp("idCliente"))
                    lbClientes.Items.Add(rowtemp("Nombre"))
                Next
            Else
                lbClientes.Visible = False
                llenaGrid("Select * from vistareclamos where idCliente ='" & LbClientesId.Items.Item(lbClientes.SelectedIndex).ToString & "' ")
                Id.Text = dgvReclamos.Item(1, dgvReclamos.Rows.Count - 1).Value
                'SeleccionarPago4()
                lbClientes.Visible = False
                'nuevo2()
            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
    End Sub

    Private Sub lbClientes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbClientes.MouseDoubleClick
        llenaGrid("Select * from vistareclamos where idCliente ='" & LbClientesId.Items.Item(lbClientes.SelectedIndex).ToString & "' ")

        Id.Text = dgvReclamos.Item(1, dgvReclamos.Rows.Count - 1).Value
        Nombre.Text = dgvReclamos.Item(2, dgvReclamos.Rows.Count - 1).Value
        'SeleccionarPago4()
        lbClientes.Visible = False
        Nuevo_Click(Nuevo, e)
    End Sub
End Class