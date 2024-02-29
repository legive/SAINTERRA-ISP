Imports MySql.Data.MySqlClient

Public Class Instalación
    'Public conec As New Conexion
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Dim varid As String
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Public respuesta, formulario, DEI, activo, Buscacliente As Integer
    Public idInstalacion, idCliente, nombreCliente As String
    Public InstalacionForm As Boolean
    Dim diasajuste2 As Integer

    Private Sub Instalación_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InstalacionForm = True
        'conectar()1

        If formulario <> 3 Then
            If Buscacliente = 1 Then
                Nombre.Text = Pagos.Nombre.Text
                Id.Text = Pagos.Id.Text

            End If
            If dgvInstalacion.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(dgvInstalacion.Item(0, 0).Value) Then
                    SeleccionarCliente2()
                End If
            Else
                btnNuevo2_Click(Nuevo, e)
            End If
        Else
            btnNuevo2_Click(Nuevo, e)
            Id.Text = clientes.txtIdentidad.Text
            Nombre.Text = clientes.txtNombre.Text
            txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")

        End If


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

    Sub llenaGridInstalacion(ByVal cadena As String)
        Try
            dgvInstalacion.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dgvInstalacion.RowCount = tablatemp.Count
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvInstalacion.Item(0, l).Value = rowtemp("idCliente")
                    dgvInstalacion.Item(1, l).Value = rowtemp("nombre")
                    dgvInstalacion.Item(2, l).Value = rowtemp("Tipo")
                    dgvInstalacion.Item(3, l).Value = rowtemp("FechaInstalacion")
                    dgvInstalacion.Item(4, l).Value = rowtemp("velocidad")
                    dgvInstalacion.Item(5, l).Value = rowtemp("Mensualidad")
                    dgvInstalacion.Item(6, l).Value = rowtemp("Mac")
                    dgvInstalacion.Item(7, l).Value = rowtemp("Ip")
                    dgvInstalacion.Item(8, l).Value = rowtemp("Instaladopor")
                    dgvInstalacion.Item(9, l).Value = rowtemp("Equipo")
                    dgvInstalacion.Item(10, l).Value = rowtemp("NoCorrelativo")
                    dgvInstalacion.Item(11, l).Value = rowtemp("unidades")
                    dgvInstalacion.Item(12, l).Value = rowtemp("moneda")
                    dgvInstalacion.Item(13, l).Value = rowtemp("Telefono")

                    If rowtemp("activo1") = 1 Then
                        dgvInstalacion.Item(14, l).Value = "Si"
                    Else
                        dgvInstalacion.Item(14, l).Value = "No"
                    End If


                    If rowtemp("router") = 1 Then
                        dgvInstalacion.Item(15, l).Value = "INTERRA"
                    Else
                        dgvInstalacion.Item(15, l).Value = "CLIENTE"
                    End If

                    dgvInstalacion.Item(16, l).Value = rowtemp("macRouter")
                    dgvInstalacion.Item(17, l).Value = rowtemp("marcaRouter")
                    dgvInstalacion.Item(18, l).Value = rowtemp("Nombremunicipio") & ", " & rowtemp("NombreComunidad")
                    dgvInstalacion.Item(19, l).Value = rowtemp("FechaInstalado")
                    dgvInstalacion.Item(20, l).Value = rowtemp("Telefono")
                    dgvInstalacion.Item(21, l).Value = rowtemp("Servidor")
                    DEI = rowtemp("DEI")
                Next
                'SeleccionarCliente2()
                txtRecuento.Text = "No. Registros: " & dgvInstalacion.RowCount & ""
            Else
                dgvInstalacion.RowCount = 1
            End If

            For Each fila As DataGridViewRow In dgvInstalacion.Rows
                If fila.Cells("activo1").Value = "No" Then
                    fila.DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    fila.DefaultCellStyle.BackColor = Color.White
                End If

            Next

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub

    Sub llenarCliente(ByVal cadena As String)
        Try
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp.Item(0)
                dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value = rowtemp("idCliente")
                dgvInstalacion.Item(1, dgvInstalacion.CurrentRow.Index).Value = rowtemp("nombre")
                dgvInstalacion.Item(2, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Tipo")
                dgvInstalacion.Item(3, dgvInstalacion.CurrentRow.Index).Value = rowtemp("FechaInstalacion")
                dgvInstalacion.Item(4, dgvInstalacion.CurrentRow.Index).Value = rowtemp("velocidad")
                dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Mensualidad")
                dgvInstalacion.Item(6, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Mac")
                dgvInstalacion.Item(7, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Ip")
                dgvInstalacion.Item(8, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Instaladopor")
                dgvInstalacion.Item(9, dgvInstalacion.CurrentRow.Index).Value = rowtemp("Equipo")
                dgvInstalacion.Item(10, dgvInstalacion.CurrentRow.Index).Value = rowtemp("NoCorrelativo")
                dgvInstalacion.Item(11, dgvInstalacion.CurrentRow.Index).Value = rowtemp("unidades")
                dgvInstalacion.Item(12, dgvInstalacion.CurrentRow.Index).Value = rowtemp("moneda")
                dgvInstalacion.Item(13, dgvInstalacion.CurrentRow.Index).Value = rowtemp("TipoPlan")
                dgvInstalacion.Item(14, dgvInstalacion.CurrentRow.Index).Value = rowtemp("activo1")
                DEI = rowtemp("DEI")

            End If

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
    Sub Limpiar()

        Id.Text = ""
        Nombre.Text = ""
        'Mensualidad.Text = ""
        txtVelocidad.Text = ""
        'Mensualidad.Text = ""
        Equipo.Text = "-"
        IP.Text = "0"
        instalado.Text = ""
        DirMAC.Text = "0"
        txtServidor.Text = "0"
        Id.Enabled = True
        Nombre.Enabled = True
        Guardar.Enabled = True
        txtFicha.Text = incrementaCodigo("Select * from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")
        validarFecha()
    End Sub


    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub pAGO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub MAC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Equipo.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzñ: ", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub IP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IP.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890. ", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub btnEliminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminar.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                tablatemp = ConsultarRegistro("Select * from controlpago where NoCorrelativoFicha =" & txtFicha.Text & "")
                If tablatemp.Count = 0 Then
                    adaptador = New MySqlDataAdapter("DELETE FROM fichaintalacionservicio WHERE  NoCorrelativo=" & txtFicha.Text & "", frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")
                    data.Clear()
                    tablatemp = ConsultarRegistro("Select * from fichaintalacionservicio where NoCorrelativo= " & txtFicha.Text & "")

                    If tablatemp.Count > 0 Then
                        MsgBox("El registro no pudo eliminarse")
                    Else
                        InsertarBitacora("SE ELIMINO FICHA DE INSTALACIÓN A  " & Nombre.Text & " NUMERO " & txtFicha.Text & "  PLAN " & txtVelocidad.Text & " " & unidades.Text & " FECHA INSTALACION " & dtpFechaInstalacion.Value & "")

                        MsgBox("Datos eliminados")
                        Limpiar()
                    End If
                Else
                    MsgBox("El registro no pudo eliminarse, está siendo utilizado por pagos")
                End If
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub
    Private Sub LimpiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimpiarToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub btnBuscarC_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarC.Click
        txtDireccion.Text = ""
        instalado.Text = ""
        Limpiar()
        If clientes.clientesForm = True Then
            clientes.Close()
        End If
        clientes.formulario = 1


        'clientes.btnOrden.Visible = False
        clientes.formulario = 1
        clientes.idCliente = Id.Text
        clientes.ShowDialog()
        'Id.Text = idCliente
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & Id.Text & "'")



        If dgvInstalacion.Rows.Count > 0 And Not String.IsNullOrEmpty(dgvInstalacion.Item(0, 0).Value) Then
            SeleccionarCliente2()
        Else
            txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")

        End If

    End Sub
    Sub SeleccionarCliente2()
        Try

            Id.Text = dgvInstalacion.Item(0, 0).Value
            Nombre.Text = dgvInstalacion.Item(1, 0).Value
            Try
                If dgvInstalacion.Item(2, 0).Value.ToString = "Reinstalación" Then

                    Tipo.SelectedIndex = 1
                Else
                    Tipo.SelectedIndex = 0
                End If
            Catch
            End Try
            Try
                If dgvInstalacion.Item(14, 0).Value.ToString = "1" Then

                    cbActivo.Checked = True
                Else
                    cbActivo.Checked = False
                End If
            Catch
            End Try

salir:
            Try
                fechaCalculada.Text = dgvInstalacion.Item(3, 0).Value.ToString
            Catch
            End Try
            Equipo.Text = dgvInstalacion.Item(9, 0).Value.ToString
            IP.Text = dgvInstalacion.Item(7, 0).Value.ToString
            instalado.Text = dgvInstalacion.Item(8, 0).Value.ToString
            DirMAC.Text = dgvInstalacion.Item(6, 0).Value.ToString
            txtFicha.Text = dgvInstalacion.Item(10, 0).Value
            Mensualidad.Text = dgvInstalacion.Item(5, 0).Value.ToString
            txtVelocidad.Text = dgvInstalacion.Item(4, 0).Value.ToString
            unidades.Text = dgvInstalacion.Item(11, 0).Value.ToString
            moneda.Text = dgvInstalacion.Item(12, 0).Value.ToString
            txtTipoPlan.Text = dgvInstalacion.Item(13, 0).Value.ToString
            txtMacRouter.Text = dgvInstalacion.Item(16, 0).Value.ToString
            txtMarcaRouter.Text = dgvInstalacion.Item(17, 0).Value.ToString
            txtDireccion.Text = dgvInstalacion.Item(18, 0).Value.ToString
            txtServidor.Text = dgvInstalacion.Item(21, 0).Value.ToString
        Catch
        End Try
    End Sub
    Sub SeleccionarCliente()
        Try
            If Not Id.Text = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value Then
                Id.Text = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value
            End If

            Nombre.Text = dgvInstalacion.Item(1, dgvInstalacion.CurrentRow.Index).Value
            For i As Integer = 0 To Tipo.Items.Count - 1
                Tipo.SelectedIndex = i
                If Tipo.Text.ToString.ToUpper = dgvInstalacion.Item(2, dgvInstalacion.CurrentRow.Index).Value.ToString Then
                    Tipo.SelectedIndex = i
                    GoTo salir1
                End If

            Next
salir1:

            Mensualidad.Text = dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtVelocidad.Text = dgvInstalacion.Item(4, dgvInstalacion.CurrentRow.Index).Value.ToString
            unidades.Text = dgvInstalacion.Item(11, dgvInstalacion.CurrentRow.Index).Value.ToString
            moneda.Text = dgvInstalacion.Item(12, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtTipoPlan.Text = dgvInstalacion.Item(13, dgvInstalacion.CurrentRow.Index).Value.ToString

            Select Case dgvInstalacion.Item(14, dgvInstalacion.CurrentRow.Index).Value.ToString
                Case "Si"
                    cbActivo.Checked = True
                Case "No"
                    cbActivo.Checked = False
            End Select
            fechaCalculada.Text = dgvInstalacion.Item(3, dgvInstalacion.CurrentRow.Index).Value
            Equipo.Text = dgvInstalacion.Item(9, dgvInstalacion.CurrentRow.Index).Value
            IP.Text = dgvInstalacion.Item(7, dgvInstalacion.CurrentRow.Index).Value
            instalado.Text = dgvInstalacion.Item(8, dgvInstalacion.CurrentRow.Index).Value.ToString
            DirMAC.Text = dgvInstalacion.Item(6, dgvInstalacion.CurrentRow.Index).Value
            txtFicha.Text = dgvInstalacion.Item(10, dgvInstalacion.CurrentRow.Index).Value
            Try

                Select Case dgvInstalacion.Item(15, dgvInstalacion.CurrentRow.Index).Value.ToString
                    Case "INTERRA"
                        rbRouterSi.Checked = True
                    Case "CLIENTE"
                        rbRouterNo.Checked = True
                End Select

                txtDireccion.Text = dgvInstalacion.Item(18, dgvInstalacion.CurrentRow.Index).Value

                txtMacRouter.Text = dgvInstalacion.Item(16, dgvInstalacion.CurrentRow.Index).Value
                txtMarcaRouter.Text = dgvInstalacion.Item(17, dgvInstalacion.CurrentRow.Index).Value
                dtpFechaInstalacion.Text = dgvInstalacion.Item(19, dgvInstalacion.CurrentRow.Index).Value
                txtCel.Text = dgvInstalacion.Item(20, dgvInstalacion.CurrentRow.Index).Value
                txtServidor.Text = dgvInstalacion.Item(21, dgvInstalacion.CurrentRow.Index).Value
            Catch S As Exception
            End Try
        Catch S As Exception
        End Try
    End Sub
    Private Sub dgvInstalacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvInstalacion.Click

        SeleccionarCliente()

    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        planes.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InventarioEquipo.Show()
    End Sub


    Private Sub btnGuardar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        Try
            respuesta = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                tablatemp = ConsultarRegistro("Select * from fichaintalacionservicio where NoCorrelativo=" & txtFicha.Text & "")

                If tablatemp.Count > 0 Then

                    ErrorProvider1.Clear()

                    If Id.Text = "" Then
                        ErrorProvider1.SetError(Id, "Ingrese el número de identidad")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If Tipo.Text = "" Then
                        ErrorProvider1.SetError(Nombre, "Ingrese el tipo de Instalación")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If txtVelocidad.Text = "" Then
                        ErrorProvider1.SetError(txtVelocidad, "Ingrese la Velocidad")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If Equipo.Text = "" Then
                        ErrorProvider1.SetError(Equipo, "Ingrese la MAC del NANO")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If IP.Text = "" Then
                        ErrorProvider1.SetError(IP, "Ingrese la IP")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If

                    adaptador = New MySqlDataAdapter("update fichaintalacionservicio set activo1=0 where idCliente='" & Id.Text & "'", frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")




                    If cbActivo.Checked = True Then
                        activo = 1
                    ElseIf cbActivo.Checked = False Then
                        activo = 0
                    End If

                    adaptador = New MySqlDataAdapter("update fichaintalacionservicio set idCliente='" & Id.Text.ToUpper & "', FechaInstalacion='" & fechaCalculada.Value.ToString("yyyy-MM-dd") & "', Velocidad=" & txtVelocidad.Text & ", Mensualidad='" & Mensualidad.Text & "', Mac='" & DirMAC.Text.ToUpper & "', ip='" & IP.Text.ToUpper & "', tipo='" & Tipo.Text.ToUpper & "', InstaladoPor='" & instalado.Text.ToUpper & "', Equipo='" & Equipo.Text.ToUpper & "', unidades='" & unidades.Text & "', moneda='" & moneda.Text & "', tipoPlan='" & txtTipoPlan.Text & "', activo1=" & activo & ", FechaInstalado='" & dtpFechaInstalacion.Value.ToString("yyyy-MM-dd") & "', macrouter = '" & txtMacRouter.Text & "', marcarouter = '" & txtMarcaRouter.Text & "', servidor='" & txtServidor.Text & "' where idCliente='" & Id.Text & "' and NoCorrelativo=" & txtFicha.Text & "", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")

                    InsertarBitacora("SE ACTUALIZÓ FICHA DE INSTALACIÓN A  " & Nombre.Text & ", TIPO " & Tipo.Text & "  PLAN " & txtVelocidad.Text & " " & unidades.Text & " FECHA " & dtpFechaInstalacion.Value & "")

                    MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "SA INTERRA")
                    data.Clear()


                    llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente ='" & Id.Text & "'")
                Else
                    txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")

                    ErrorProvider1.Clear()

                    If Id.Text = "" Then
                        ErrorProvider1.SetError(Id, "Ingrese el número de identidad")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If Tipo.Text = "" Then
                        ErrorProvider1.SetError(Nombre, "Ingrese el tipo de Instalación")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If txtVelocidad.Text = "" Then
                        ErrorProvider1.SetError(txtVelocidad, "Ingrese la Velocidad")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If Mensualidad.Text = "" Then
                        ErrorProvider1.SetError(Mensualidad, "Ingrese el pago")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If Equipo.Text = "" Then
                        ErrorProvider1.SetError(Equipo, "Ingrese la MAC del NANO")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If
                    If IP.Text = "" Then
                        ErrorProvider1.SetError(IP, "Ingrese la IP")
                        GoTo salir
                    Else
                        ErrorProvider1.Clear()
                    End If

                    If cbActivo.Checked = True Then
                        activo = 1
                    ElseIf cbActivo.Checked = False Then
                        activo = 0
                    End If
                    Dim Router2 As Integer
                    If rbRouterSi.Checked = True Then
                        Router2 = 1
                    ElseIf cbActivo.Checked = False Then
                        Router2 = 0
                    End If
                    adaptador = New MySqlDataAdapter("update fichaintalacionservicio set activo1=0 where idCliente='" & Id.Text & "'", frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")


                    Dim agregar As DataRow
                    adaptador = New MySqlDataAdapter("SELECT * FROM fichaintalacionservicio ", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")
                    agregar = Me.data.Tables("fichaintalacionservicio").NewRow()
                    agregar("IdCliente") = Me.Id.Text.ToUpper
                    agregar("Tipo") = Me.Tipo.Text.ToUpper
                    agregar("velocidad") = Me.txtVelocidad.Text.ToUpper
                    agregar("mac") = Me.DirMAC.Text.ToUpper
                    agregar("ip") = Me.IP.Text.ToUpper.ToUpper
                    agregar("Mensualidad") = Me.Mensualidad.Text
                    agregar("fechainstalacion") = Me.fechaCalculada.Value.ToString("yyyy-MM-dd")
                    agregar("Instaladopor") = Me.instalado.Text.ToUpper
                    agregar("Equipo") = Me.Equipo.Text.ToUpper
                    agregar("NoCorrelativo") = Me.txtFicha.Text.ToUpper
                    agregar("unidades") = Me.unidades.Text.ToUpper
                    agregar("moneda") = Me.moneda.Text.ToUpper
                    agregar("TipoPlan") = Me.txtTipoPlan.Text.ToUpper

                    agregar("activo1") = 1
                    agregar("router") = Router2
                    agregar("servidor") = txtServidor.Text
                    agregar("macrouter") = txtMacRouter.Text
                    agregar("marcarouter") = txtMarcaRouter.Text
                    agregar("fechaInstalado") = Me.dtpFechaInstalacion.Value.ToString("yyyy-MM-dd")

                    Me.data.Tables("fichaintalacionservicio").Rows.Add(agregar)
                    Me.adaptador.Update(data, "fichaintalacionservicio")
                    InsertarBitacora("SE AGREGO FICHA DE INSTALACIÓN A  " & Nombre.Text & ", TIPO " & Tipo.Text & "  PLAN " & txtVelocidad.Text & " " & unidades.Text & " FECHA " & dtpFechaInstalacion.Value & "")

                    MsgBox("Datos agregados")
                    data.Clear()

                    llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente ='" & Id.Text & "'")

                End If
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub

    Private Sub btnNuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo.Click

        Limpiar()
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where activo1=1 order by NoCorrelativo desc limit " & txtlimiteIns.Text & "")


    End Sub
    Public Function incrementaCodigo(ByVal consulta As String, ByVal campo As String)
        'inicializaConexion(frmMenu.txtDireccionBD.Text)
        Dim contador As Integer
        Try
            data.Clear()

            adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "controlpago")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("controlpago").Rows

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
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        'Dim rpt2 As New OrdenInstalacion
        'rpt2.RecordSelectionFormula = "{fichainstalacionservicovista.idCliente} = '" & Id.Text & "' and {fichainstalacionservicovista.NoCorrelativo} = " & txtNoFicha.Text & ""
        'Reporte.CrystalReportViewer1.ReportSource = rpt2
        'Reporte.Refresh()
        'Reporte.Show()
        Excel(dgvInstalacion)

    End Sub

    Private Sub Instalación_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub
    Sub Excel(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        'exLibro = exApp.Workbooks.Add
        'exHoja = exLibro.Worksheets.Add()
        'Dim columnaEx As Integer = 1
        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\ORDENINSTALACION.xlsx")
        exHoja = exLibro.Worksheets.Item(3)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        For i As Integer = 1 To NCol

            'If ElGrid.Columns(i - 1).Visible = True Then
            exHoja.Cells.Item(1, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
            'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            columnaEx = columnaEx + 1
            'End If

        Next
        'ProgressBar1.Maximum = NRow
        columnaEx = 0
        For Fila As Integer = 0 To NRow - 1
            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                'If ElGrid.Columns.Item(Col).Visible = True Then
                exHoja.Cells.Item(Fila + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                columnaEx = columnaEx + 1
                'End If


                'ProgressBar1.Value = Fila
                'End If
            Next
            columnaEx = 0
        Next
        'ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()


        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    'Sub Excel(ByVal ElGrid As DataGridView)
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


    '    exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\ORDENINSTALACION.xlsx")
    '    exHoja = exLibro.Worksheets.Item(3)
    '    Dim columnaEx As Integer = 1

    '    Dim NCol As Integer = ElGrid.ColumnCount
    '    Dim NRow As Integer = ElGrid.RowCount
    '    'For i As Integer = 1 To NCol

    '    '    'If ElGrid.Columns(i - 1).Visible = True Then
    '    '    exHoja.Cells.Item(0, columnaEx) = ElGrid.Columns(i - 1).HeaderText.ToString
    '    '        exHoja.Cells.Item(1, i).HorizontalAlignment = 3
    '    '        columnaEx = columnaEx + 1
    '    '    'End If

    '    'Next
    '    'ProgressBar1.Maximum = NRow
    '    columnaEx = 0
    '    Dim filaexcel As Integer = 1
    '    For Fila As Integer = 0 To NRow - 1

    '        For Col As Integer = 0 To NCol - 1
    '            'If ElGrid.Columns(Col - 1).Visible = True Then
    '            'If ElGrid.Columns.Item(Col).Visible = True Then
    '            exHoja.Cells.Item(filaexcel + 1, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
    '                columnaEx = columnaEx + 1
    '            'End If



    '            'End If

    '        Next
    '        filaexcel = filaexcel + 1
    '        columnaEx = 0
    '    Next



    '    exHoja.Rows.Item(1).Font.Bold = 1
    '    exHoja.Rows.Item(1).HorizontalAlignment = 3
    '    exHoja.Columns.AutoFit()


    '    exApp.Application.Visible = True

    '    exHoja = Nothing
    '    exLibro = Nothing
    '    exApp = Nothing
    'End Sub

    Private Sub Id_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Id.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Nombre.Focus()
        End If
    End Sub

    Private Sub Nombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Nombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            Tipo.Focus()
        End If
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub

    Private Sub Tipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tipo.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            fechaCalculada.Focus()
        End If
    End Sub

    Private Sub fecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fechaCalculada.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            txtVelocidad.Focus()
        End If
    End Sub

    Private Sub Velocidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Mensualidad.Focus()
        End If
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Mensualidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            instalado.Focus()
        End If
    End Sub

    Private Sub Instalado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Equipo.Focus()
        End If
    End Sub

    Private Sub Equipo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Equipo.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            DirMAC.Focus()
        End If
    End Sub

    Private Sub DirMAC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DirMAC.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            IP.Focus()
        End If
    End Sub

    Private Sub IP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles IP.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Guardar.Focus()
        End If
    End Sub

    Private Sub Button2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnBuscarC.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub

    Private Sub Nuevo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Nuevo.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub

    Private Sub Guardar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Guardar.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub

    Private Sub btnReporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnReporte.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If
    End Sub

    Private Sub dgvInstalacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvInstalacion.KeyDown

        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            btnGuardar2_Click(Guardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnBuscarC_click(btnBuscarC, e)
        End If


    End Sub

    Private Sub Id_TextChanged(sender As Object, e As EventArgs) Handles Id.TextChanged
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & Id.Text & "' ")
    End Sub
    Private Sub rbRouterSi_CheckedChanged(sender As Object, e As EventArgs) Handles rbRouterSi.CheckedChanged
        If rbRouterSi.Checked Then
            txtMacRouter.Enabled = True
            txtMarcaRouter.Enabled = True
        ElseIf rbRouterNo.Checked = True Then
            txtMacRouter.Enabled = False
            txtMarcaRouter.Enabled = False
            txtMarcaRouter.Text = "-"
            txtMacRouter.Text = "0"
        End If
    End Sub
    Sub validarFecha()
        If dtpFechaInstalacion.Value.Day > 15 Then
            fechaCalculada.Value = 1 & "/" & dtpFechaInstalacion.Value.AddDays(17).Month & "/" & dtpFechaInstalacion.Value.AddDays(17).Year
        Else
            fechaCalculada.Value = (1 & "/" & dtpFechaInstalacion.Value.Month & "/" & dtpFechaInstalacion.Value.Year)

            diasajuste2 = dtpFechaInstalacion.Value.Day
            If diasajuste2 = 1 Then
                diasajuste2 = 0
            End If

        End If
    End Sub
    Private Sub dtpAjuste_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInstalacion.ValueChanged
        validarFecha()
    End Sub

    Private Sub rbRouterNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbRouterNo.CheckedChanged
        If rbRouterNo.Checked = True Then
            txtMacRouter.Enabled = False
            txtMarcaRouter.Enabled = False
        ElseIf rbRouterSi.Checked = True Then
            txtMacRouter.Enabled = True
            txtMarcaRouter.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If entro = True Then

            llenaGridInstalacion("Select * from fichainstalacionserviciovista where nombre like '%" & Nombre.Text & "%' and Activo1=1 order by NoCorrelativo desc limit 5")

        End If
    End Sub

    Private Sub Instalación_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        InstalacionForm = False
    End Sub

    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Try
            If Id.Text = "" Then
                MsgBox("Favor ingrese el cliente",, "")
                Nombre.Focus()
            Else
                Reclamos.Id.Text = Id.Text
                Reclamos.Nombre.Text = Nombre.Text
                Reclamos.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvInstalacion_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvInstalacion.MouseDoubleClick
        Try
            If formulario = 2 Or formulario = 3 Then
                If dgvInstalacion.Item(14, dgvInstalacion.CurrentRow.Index).Value = "Si" Then
                    Pagos.Id.Text = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value
                    Pagos.Nombre.Text = Nombre.Text
                    Pagos.DEI = DEI
                    Pagos.NoCorrelativoFicha = txtFicha.Text
                    Pagos.txtMensualidad.Text = Mensualidad.Text
                    Pagos.txtMens.Text = Mensualidad.Text
                    Pagos.dtpInstalacion.Value = fechaCalculada.Value
                    Pagos.dtpFechaPago.Value = fechaCalculada.Value
                    Pagos.txtDireccion.Text = txtDireccion.Text
                    Pagos.txtdias.Text = 0
                    Pagos.diasajuste = diasajuste2
                    Pagos.instalacionactiva = 1
                    Me.Close()
                Else
                    MsgBox("Favor elija una orden de instalación activa",, "Error")
                    Pagos.txtActivo.Text = 0
                End If
            End If

        Catch
        End Try
    End Sub
    Private Sub Tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tipo.SelectedIndexChanged
        txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo desc limit 1", "NoCorrelativo")
    End Sub
    Private Sub Velocidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub
End Class