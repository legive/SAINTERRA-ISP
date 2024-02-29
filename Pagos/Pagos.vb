Imports MySql.Data.MySqlClient
Public Class Pagos
    'Public conec As New Conexion
    Dim INS As New Instalación
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Dim oCommBuild As MySqlCommandBuilder
    Dim varid, meses As String
    Private data As New DataSet
    Private tablatemp, tablatemp2, tablatemp3, tablatem4 As DataRowCollection
    Private rowtemp, rowtemp2 As DataRow
    Public NoCorrelativoFicha, no, DEI, descuentodias, descuentoHoras, tp, diasajuste, instalacionactiva As Integer
    Dim fechaPago, atlantida As String
    Dim respuesta, dolar, isv, ISVE As Integer
    Dim entro, entro2, entro3 As Boolean
    Dim entroDei As Boolean
    Dim navegacion = 0, TipoPago As Integer
    Public idInstalacion, usuarioActual, mesActual, variosMeses, Fechappago As String
    Dim saldoDolar, filaspagos As Integer
    Dim mora, filasmora, botonNuevo, l, contadordeudores As Integer
    Dim cambio, cambioant As Double
    Public varid2, identidad, consulta1, consulta2, consulta3, identidadPagos, idCliente As String
    Public respuesta2, formulario, ActivoD As Integer
    Dim NSAR As Integer
    Public clientesForm, conexion2 As Boolean
    Public respuesta3, activo, Buscacliente As Integer
    Public nombreCliente As String
    Public InstalacionForm As Boolean
    Dim diasajuste2 As Integer

    Private Sub CentrarControlEnFormulario(control As Control)
        ' Calculamos la posición X para centrar el control en el formulario
        Dim xPos As Integer = (Me.ClientSize.Width - control.Width) / 2
        ' Calculamos la posición Y para centrar el control en el formulario
        Dim yPos As Integer = (Me.ClientSize.Height - control.Height) / 2

        ' Establecemos las nuevas posiciones del control
        control.Location = New Point(xPos, yPos)
    End Sub
    Sub LimpiarInstalacion()
        txtMarcaRouter.Text = ""
        txtMacRouter.Text = ""
        txtVelocidad.Text = ""
        TextBox2.Text = ""
        Mensualidad.Text = ""
        Equipo.Text = "-"
        txtDireccionIP.Text = "0"
        instalado.Text = ""
        DirMAC.Text = "0"
        txtServidor.Text = "0"
        Id.Enabled = True
        Nombre.Enabled = True
        Guardar.Enabled = True
        txtFicha.Text = incrementaCodigo("Select * from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")
        validarFecha()
        dgvInstalacion.Rows.Clear()
    End Sub

#Region "sELECT INDEX CHANGED DE TODOS LOS COMBOBOX"
    Private Sub cmbdepartamento1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreDepartamento1.SelectedIndexChanged

        cmbCodigoDepartamento1.SelectedIndex = cmbNombreDepartamento1.SelectedIndex

        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")
        consulta1 = " Codigodepartamento=" & cmbCodigoDepartamento1.Text & ""

        If entro2 = True Then
            llenaGrid("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")
        End If

    End Sub
    Private Sub cmbNombremunicipio1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreMunicipio1.SelectedIndexChanged

        cmbCodigoMunicipio1.SelectedIndex = cmbNombreMunicipio1.SelectedIndex

        Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " AND Codigomunicipio<>0")
        consulta2 = " and Codigomunicipio=" & cmbCodigoMunicipio1.Text & ""


        consulta1 = " Codigodepartamento=" & cmbCodigoDepartamento1.Text & ""
        llenaGrid("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")


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
    Private Sub cmbNombreComunidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreComunidad1.SelectedIndexChanged

        cmbCodigoComunidad1.SelectedIndex = cmbNombreComunidad1.SelectedIndex
        If entro2 = False Then
            consulta3 = " and CodigoComunidad=" & cmbCodigoComunidad1.Text & ""

            If entro2 = True Then
                llenaGrid("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")
            End If
        End If
    End Sub
    Private Sub cmbCodigodepartamento1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoDepartamento1.SelectedIndexChanged
        cmbNombreDepartamento1.SelectedIndex = cmbCodigoDepartamento1.SelectedIndex
    End Sub
    Private Sub cmbCodigomunicipio1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoMunicipio1.SelectedIndexChanged
        cmbNombreMunicipio1.SelectedIndex = cmbCodigoMunicipio1.SelectedIndex
    End Sub
    Private Sub cmbCodigoComunidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoComunidad1.SelectedIndexChanged
        cmbCodigoComunidad1.SelectedIndex = cmbNombreComunidad1.SelectedIndex
    End Sub

#End Region
    Public Function ConsultarRegistro(ByVal cadena As String)
        Try
            data.Clear()
            adaptador = New MySqlDataAdapter(cadena, conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "Resultado")
            tablatemp = data.Tables("Resultado").Rows
            'data.
            Return tablatemp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "ERROR")
            Return tablatemp
        End Try
    End Function

    Sub Conectar()
        Try
            conexion = New MySqlConnection()
            conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
            conexion.Open()

        Catch
        End Try
    End Sub
    Sub cargarInstalacion(ByVal e As System.EventArgs)
        Nuevo_Click(Nuevo, e)
        'Id.Text = clientes.txtIdentidad.Text
        'Nombre.Text = clientes.txtNombre.Text
        txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")
    End Sub

    Private Sub Instalación_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '  CargarInstalaciones()
        Me.BringToFront()
        Conectar()
        txtdias.Text = 0
        horas.Text = 0
        abonoActual.Text = 0
        txtEfectivo.Text = 0
        txtRecargo.Text = 0
        txtTotalPagar.Text = 0
        dgvclientes.Rows.Clear()
        txtPrecioDolar.Text = 0
        entro = True
        atlantida = "130120088773"
        Limpiar2()
        Llenardepartamento("Select * from departamento")
        LlenardepartamentoGeneral("Select * from departamento")

        'llenaGridClientes("Select * from vistaclientes  limit " & txtNoRegistros2.Text & "")
        navegacion = 0
        cmbAnio.SelectedIndex = 0
        For i As Integer = 0 To cmbAnio.Items.Count - 1
            cmbAnio.SelectedIndex = i
            If cmbAnio.Text = Today.Year Then
                GoTo Salir
            End If

        Next
        pb2.Value = 0
        txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where activo1=1 order by NoCorrelativo desc limit " & txtlimiteIns.Text & "")

Salir:
        cmbmostrarUsuario.SelectedIndex = 0

    End Sub
    Sub CargarInstalaciones()
        Try
            dgvclientes.Rows.Clear()
            VerificarGridInstalaciones("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad ")
            navegacion = 0
            Id.Text = dgvclientes.Item(1, navegacion).Value
            BuscarPagoPorNavegacion()
            SeleccionarPagoNavegacion()
            navegacion = 1
            lblreg.Text = "Registro No. " & navegacion
            MostrarDeudores()
            llenaGridClienteUltimoPago(dgvclientes)
        Catch
        End Try
    End Sub
#Region "sELECT INDEX CHANGED DE TODOS LOS COMBOBOX"
    Private Sub cmbdepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreDepartamento.SelectedIndexChanged

        cmbCodigoDepartamento.SelectedIndex = cmbNombreDepartamento.SelectedIndex

        LlenarmunicipiosGeneral("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento.Text & "")

    End Sub
    Private Sub cmbNombremunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombremunicipio.SelectedIndexChanged

        cmbCodigomunicipio.SelectedIndex = cmbNombremunicipio.SelectedIndex
        LlenarcomunidadesGeneral("Select * from comunidades where Codigomunicipio=" & cmbCodigomunicipio.Text & " AND Codigomunicipio<>0")


    End Sub
    Private Sub cmbNombreComunidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreComunidad.SelectedIndexChanged
        cmbCodigoComunidad.SelectedIndex = cmbNombreComunidad.SelectedIndex

        CargarInstalaciones()

    End Sub
    Sub ActualizarInstalados()
        VerificarGridInstalaciones("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad ")

        navegacion = 0
        Id.Text = dgvclientes.Item(1, navegacion).Value
        BuscarPagoPorNavegacion()
        SeleccionarPagoNavegacion()
        navegacion = 1
        lblreg.Text = "Registro No. " & navegacion
        MostrarDeudores()
        llenaGridClienteUltimoPago(dgvclientes)
    End Sub
    Sub BuscarPagoPorNavegacion()
        MostrarUsuarioNavegacion()
        'VerificarMesActual()
        llenaGrid("Select * from vistapagos where idCliente = '" & Id.Text & "' " & usuarioActual & " ORDER BY No DESC limit " & txtlimite.Text & "")
        If filaspagos > 0 Then
            SeleccionarPago4()
        End If
    End Sub
    Private Sub cmbCodigodepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoDepartamento.SelectedIndexChanged
        cmbNombreDepartamento.SelectedIndex = cmbCodigoDepartamento.SelectedIndex
    End Sub
    Private Sub cmbCodigomunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigomunicipio.SelectedIndexChanged
        cmbNombremunicipio.SelectedIndex = cmbCodigomunicipio.SelectedIndex
    End Sub
    Private Sub cmbCodigoComunidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoComunidad.SelectedIndexChanged
        cmbCodigoComunidad.SelectedIndex = cmbNombreComunidad.SelectedIndex
    End Sub

#End Region
#Region "LLENAR COMBOBOXES"
    Sub LlenardepartamentoGeneral(ByVal consulta As String)
        Try
            adaptador = New MySqlDataAdapter(consulta, conexion)
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
                cmbCodigoDepartamento.Items.Clear()
                cmbNombreDepartamento.Items.Clear()

                'recorrer cada fila
                For i As Integer = 0 To tablatemporal.Count - 1

                    Filatemporal = tablatemporal.Item(i)

                    'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                    cmbCodigoDepartamento.Items.Add(Filatemporal("Codigodepartamento"))
                    cmbNombreDepartamento.Items.Add(Filatemporal("Nombredepartamento"))


                Next
                cmbNombreDepartamento.SelectedIndex = 0
                data.Clear()
            End If
        Catch s As Exception
        End Try
    End Sub
    Sub LlenarcomunidadesGeneral(ByVal consulta As String)
        Try

            adaptador = New MySqlDataAdapter(consulta, conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "comunidades")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("comunidades").Rows

            'si la consulta agregada a la tabla temporal tiene datos o filas
            If tablatemporal.Count > 0 Then
                'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
                cmbCodigoComunidad.Items.Clear()
                cmbNombreComunidad.Items.Clear()

                'recorrer cada fila
                For i As Integer = 0 To tablatemporal.Count - 1

                    Filatemporal = tablatemporal.Item(i)

                    'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                    cmbCodigoComunidad.Items.Add(Filatemporal("CodigoComunidad"))
                    cmbNombreComunidad.Items.Add(Filatemporal("NombreComunidad"))


                Next
                cmbCodigoComunidad.SelectedIndex = 0
                data.Clear()
            End If
        Catch
        End Try


    End Sub
    Sub LlenarmunicipiosGeneral(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, conexion)
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
    Sub Llenardepartamento(ByVal consulta As String)
        Try
            adaptador = New MySqlDataAdapter(consulta, conexion)
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
                cmbCodigoDepartamento.Items.Clear()
                cmbNombreDepartamento.Items.Clear()
                cmbCodigoDepartamento1.Items.Clear()
                cmbNombreDepartamento1.Items.Clear()
                'recorrer cada fila
                For i As Integer = 0 To tablatemporal.Count - 1

                    Filatemporal = tablatemporal.Item(i)

                    'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                    cmbCodigoDepartamento.Items.Add(Filatemporal("Codigodepartamento"))
                    cmbNombreDepartamento.Items.Add(Filatemporal("Nombredepartamento"))
                    cmbCodigoDepartamento1.Items.Add(Filatemporal("Codigodepartamento"))
                    cmbNombreDepartamento1.Items.Add(Filatemporal("Nombredepartamento"))


                Next
                cmbNombreDepartamento.SelectedIndex = 0
                data.Clear()
            End If
        Catch s As Exception
        End Try
    End Sub
    Sub Llenarcomunidades(ByVal consulta As String)
        Try

            adaptador = New MySqlDataAdapter(consulta, conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "comunidades")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("comunidades").Rows

            'si la consulta agregada a la tabla temporal tiene datos o filas
            If tablatemporal.Count > 0 Then
                'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
                cmbCodigoComunidad.Items.Clear()
                cmbNombreComunidad.Items.Clear()
                cmbCodigoComunidad1.Items.Clear()
                cmbNombreComunidad1.Items.Clear()
                'recorrer cada fila
                For i As Integer = 0 To tablatemporal.Count - 1

                    Filatemporal = tablatemporal.Item(i)

                    'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                    cmbCodigoComunidad.Items.Add(Filatemporal("CodigoComunidad"))
                    cmbNombreComunidad.Items.Add(Filatemporal("NombreComunidad"))
                    cmbCodigoComunidad1.Items.Add(Filatemporal("CodigoComunidad"))
                    cmbNombreComunidad1.Items.Add(Filatemporal("NombreComunidad"))

                Next
                cmbCodigoComunidad.SelectedIndex = 0
                data.Clear()
            End If
        Catch
        End Try


    End Sub
    Sub Llenarmunicipios(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, conexion)
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
            cmbCodigoMunicipio1.Items.Clear()
            cmbNombreMunicipio1.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigomunicipio.Items.Add(Filatemporal("Codigomunicipio"))
                cmbNombremunicipio.Items.Add(Filatemporal("Nombremunicipio"))
                cmbCodigoMunicipio1.Items.Add(Filatemporal("Codigomunicipio"))
                cmbNombreMunicipio1.Items.Add(Filatemporal("Nombremunicipio"))

            Next
            cmbCodigomunicipio.SelectedIndex = 0
            data.Clear()
        End If

    End Sub


#End Region
#Region "LLENAR GRIDS"

    Sub llenaGridClientes(ByVal cadena As String)
        Try
            dgvClientesNuevos.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvClientesNuevos.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    If rowtemp("activo") = 1 Then
                        activo = "Si"
                    ElseIf rowtemp("activo") = 2 Then
                        activo = "No"
                    End If

                    rowtemp = tablatemp.Item(l)
                    If rowtemp("DEI") = 1 Then
                        NSAR = 1
                    ElseIf rowtemp("DEI") = 2 Then
                        NSAR = 2
                    End If
                    dgvClientesNuevos.Item(0, l).Value = rowtemp("idCliente")
                    dgvClientesNuevos.Item(1, l).Value = rowtemp("nombre")
                    dgvClientesNuevos.Item(2, l).Value = rowtemp("Telefono")
                    dgvClientesNuevos.Item(3, l).Value = rowtemp("Nombredepartamento")
                    dgvClientesNuevos.Item(4, l).Value = rowtemp("Nombremunicipio")
                    dgvClientesNuevos.Item(5, l).Value = rowtemp("NombreComunidad")
                    dgvClientesNuevos.Item(6, l).Value = rowtemp("Correo")
                    dgvClientesNuevos.Item(7, l).Value = activo
                    dgvClientesNuevos.Item(8, l).Value = NSAR
                    dgvClientesNuevos.Item(9, l).Value = rowtemp("Direccion")
                    dgvClientesNuevos.Item(10, l).Value = rowtemp("NoCorrelativo")
                    dgvClientesNuevos.Item(11, l).Value = rowtemp("usuario")
                    dgvClientesNuevos.Item(12, l).Value = rowtemp("ubicacion")
                Next
                txtRecuento.Text = "No. Registros: " & dgvClientesNuevos.RowCount & ""

            Else
                dgvClientesNuevos.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
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
                    dgvInstalacion.Item(13, l).Value = rowtemp("tipoPlan")

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
                dgvInstalacion.RowCount = 0


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
    Sub llenaGridCliente(ByVal cadena As String, ByVal dgv As DataGridView)
        Try
            dgv.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            'Dim activo As Integer

            dgv.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dgv.RowCount = tablatemp.Count
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgv.Item(0, l).Value = l + 1
                    dgv.Item(1, l).Value = rowtemp("idCliente")
                    dgv.Item(2, l).Value = rowtemp("nombre")
                    dgv.Item(3, l).Value = rowtemp("Tipo")
                    dgv.Item(4, l).Value = rowtemp("FechaInstalacion")
                    dgv.Item(5, l).Value = rowtemp("velocidad")
                    dgv.Item(6, l).Value = rowtemp("Mensualidad")
                    dgv.Item(7, l).Value = rowtemp("Mac")
                    dgv.Item(8, l).Value = rowtemp("Ip")
                    dgv.Item(9, l).Value = rowtemp("servidor")
                    dgv.Item(10, l).Value = rowtemp("Instaladopor")
                    dgv.Item(11, l).Value = rowtemp("Equipo")
                    dgv.Item(12, l).Value = rowtemp("NoCorrelativo")
                    dgv.Item(13, l).Value = rowtemp("unidades")
                    dgv.Item(14, l).Value = rowtemp("moneda")
                    dgv.Item(15, l).Value = rowtemp("TipoPlan")
                    dgv.Item(16, l).Value = rowtemp("activo1")
                    dgv.Item(17, l).Value = rowtemp("router")
                    dgv.Item(18, l).Value = rowtemp("macRouter")
                    dgv.Item(19, l).Value = rowtemp("marcaRouter")
                    dgv.Item(20, l).Value = rowtemp("usuario")
                    dgv.Item(21, l).Value = rowtemp("Nombremunicipio") & ", " & rowtemp("NombreComunidad")
                    DEI = rowtemp("DEI")
                    dgv.Item(25, l).Value = rowtemp("Telefono")
                    txtTotalPagos.Text = Val(dgvclientes.Item(6, l).Value) + Val(txtTotalPagos.Text)
                Next
                'SeleccionarCliente2()
                lbconteo.Text = "No. Registros: " & dgv.RowCount & ""

            Else
                dgv.Rows.Clear()
            End If

        Catch m As Exception
        End Try
    End Sub

    Sub llenaGridClienteUltimoPago(dgv As DataGridView)
        Try

            ProgressBar2.Maximum = dgv.Rows.Count
            For l As Integer = 0 To dgv.Rows.Count - 1
                tablatemp2 = ConsultarRegistro("SELECT distinct(idcliente), no, nombre, Mes, anio FROM vistapagos where idCliente= '" & dgvclientes.Item(1, l).Value & "' order by No desc limit 1")
                If tablatemp2.Count > 0 Then

                    rowtemp2 = tablatemp2.Item(0)

                    dgv.Item(23, l).Value = rowtemp2("Mes")
                    dgv.Item(24, l).Value = rowtemp2("Anio")

                    ProgressBar2.Value = l



                End If
            Next
            ProgressBar2.Value = 0
        Catch m As Exception
        End Try
    End Sub
    Sub llenaGridCliente2(ByVal cadena As String, ByVal dgv As DataGridView)
        Try
            dgv.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            Dim item As Integer = 1

            dgv.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dgv.RowCount = tablatemp.Count
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)


                    dgv.Item(3, l).Value = rowtemp("idCliente")
                    dgv.Item(4, l).Value = rowtemp("nombre")
                    dgv.Item(1, l).Value = rowtemp("Nombremunicipio")
                    dgv.Item(2, l).Value = rowtemp("NombreComunidad")
                    dgv.Item(5, l).Value = rowtemp("usuario")
                    If l > 0 Then
                        If dgv.Item(2, l - 1).Value <> dgv.Item(2, l).Value Then
                            item = 1
                        Else
                            item = item + 1
                        End If

                    End If
                    dgv.Item(0, l).Value = item & " de " & l + 1
                Next
                'SeleccionarCliente2()
                Lbconteo2.Text = "No. Registros: " & dgv.RowCount & ""

            Else
                dgv.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub llenaGridDeudoresHistorial(ByVal cadena As String)
        Try
            'dgvPagos2.Rows.Clear()
            tablatemp3 = ConsultarRegistro(cadena)
            filaspagos = 0
            If tablatemp3.Count > 0 Then
                filaspagos = 1
                'dgvPagos2.RowCount = tablatemp3.Count


                For i As Integer = 0 To tablatemp3.Count - 1

                    'pb2.Value = contadordeudores
                    rowtemp = tablatemp3.Item(i)
                    dgvPagos2.Item(0, contadordeudores).Value = rowtemp("No")
                    dgvPagos2.Item(1, contadordeudores).Value = contadordeudores
                    dgvPagos2.Item(2, contadordeudores).Value = rowtemp("Mes")
                    dgvPagos2.Item(3, contadordeudores).Value = rowtemp("Anio")
                    dgvPagos2.Item(4, contadordeudores).Value = rowtemp("idCliente")
                    dgvPagos2.Item(5, contadordeudores).Value = rowtemp("Nombre")
                    dgvPagos2.Item(6, contadordeudores).Value = rowtemp("Mensualidad")
                    dgvPagos2.Item(7, contadordeudores).Value = rowtemp("FechaInstalacion")
                    dgvPagos2.Item(8, contadordeudores).Value = rowtemp("FechaPago")
                    dgvPagos2.Item(9, contadordeudores).Value = rowtemp("DescuentoD")
                    dgvPagos2.Item(10, contadordeudores).Value = rowtemp("DescuentoH")
                    dgvPagos2.Item(11, contadordeudores).Value = rowtemp("AbonoA")
                    dgvPagos2.Item(12, contadordeudores).Value = rowtemp("AbonoS")
                    dgvPagos2.Item(13, contadordeudores).Value = rowtemp("TotalDescuento")
                    dgvPagos2.Item(14, contadordeudores).Value = rowtemp("RazonDescuento")
                    dgvPagos2.Item(15, contadordeudores).Value = rowtemp("TotalPagar")
                    dgvPagos2.Item(16, contadordeudores).Value = rowtemp("Abono")
                    If rowtemp("Pagado") = 1 Then
                        dgvPagos2.Item(17, contadordeudores).Value = "Si"
                    Else
                        dgvPagos2.Item(17, contadordeudores).Value = "No"
                    End If


                    'dgvPagos2.Item(18, contadordeudores).Value = rowtemp("Activo")
                    If rowtemp("Activo") = 1 Then
                        dgvPagos2.Item(18, contadordeudores).Value = "Si"
                    Else
                        dgvPagos2.Item(18, contadordeudores).Value = "No"
                    End If
                    If dgvPagos2.Item(17, contadordeudores).Value = "Si" Then
                        dgvPagos2.Item(19, contadordeudores).Value = rowtemp("FechaPagado")
                    Else
                        dgvPagos2.Item(19, contadordeudores).Value = ""
                    End If
                    dgvPagos2.Item(20, contadordeudores).Value = rowtemp("Saldo")
                    dgvPagos2.Item(21, contadordeudores).Value = rowtemp("FechaEmision")
                    dgvPagos2.Item(22, contadordeudores).Value = rowtemp("Recargo")
                    dgvPagos2.Item(23, contadordeudores).Value = rowtemp("Efectivo")
                    dgvPagos2.Item(24, contadordeudores).Value = rowtemp("tipoPago")
                    dgvPagos2.Item(25, contadordeudores).Value = rowtemp("NoCorrelativo")

                    'If rowtemp("Activo") = 2 Then
                    '    lbEstado.Text = "Cliente Inactivo"
                    '    lbEstado.BackColor = Color.Red
                    'Else
                    '    lbEstado.Text = ""
                    'End If
                    Try
                        dgvPagos2.Item(27, contadordeudores).Value = rowtemp("enDolar").ToString
                        dgvPagos2.Item(28, contadordeudores).Value = rowtemp("precioDolar").ToString
                        dgvPagos2.Item(29, contadordeudores).Value = rowtemp("unidades").ToString
                        dgvPagos2.Item(30, contadordeudores).Value = rowtemp("moneda").ToString
                        dgvPagos2.Item(31, contadordeudores).Value = rowtemp("TipoPlan").ToString
                        dgvPagos2.Item(32, contadordeudores).Value = rowtemp("velocidad").ToString
                        dgvPagos2.Item(33, contadordeudores).Value = rowtemp("tipoPagoDE").ToString
                        dgvPagos2.Item(34, contadordeudores).Value = rowtemp("isv").ToString
                        dgvPagos2.Item(35, contadordeudores).Value = rowtemp("isve").ToString
                        dgvPagos2.Item(36, contadordeudores).Value = rowtemp("estado").ToString
                        dgvPagos2.Item(37, contadordeudores).Value = rowtemp("Telefono").ToString
                        dgvPagos2.Item(38, contadordeudores).Value = rowtemp("fechahab").ToString
                        dgvPagos2.Item(39, contadordeudores).Value = rowtemp("detallepago").ToString

                        dgvPagos2.Item(40, contadordeudores).Value = rowtemp("cambio").ToString
                        dgvPagos2.Item(41, contadordeudores).Value = rowtemp("NoCorrelativoFicha").ToString
                        dgvPagos2.Item(42, contadordeudores).Value = rowtemp("totalmes").ToString
                        dgvPagos2.Item(43, contadordeudores).Value = rowtemp("cambioant").ToString
                        dgvPagos2.Item(44, contadordeudores).Value = rowtemp("meses").ToString
                        dgvPagos2.Item(47, contadordeudores).Value = rowtemp("usuario").ToString
                        dgvPagos2.Item(48, contadordeudores).Value = rowtemp("Activo1").ToString
                        dgvPagos2.Item(49, contadordeudores).Value = rowtemp("Nombrecomunidad") & " " & rowtemp("Nombremunicipio") & " " & rowtemp("NombreDepartamento")
                        dgvPagos2.Item(45, contadordeudores).Value = rowtemp("ip").ToString
                        dgvPagos2.Item(46, contadordeudores).Value = rowtemp("servidor").ToString

                        dgvPagos2.Item(50, contadordeudores).Value = rowtemp("FechaIn").ToString
                        dgvPagos2.Item(51, contadordeudores).Value = rowtemp("razonCorte").ToString
                        dgvPagos2.Item(52, contadordeudores).Value = rowtemp("FechaPP").ToString
                    Catch S As Exception
                    End Try


                    'If dgvPagos2.Item(34, contadordeudores).Value = 1 Then
                    '    entro2 = False
                    '    cbISV.Checked = True
                    'Else
                    '    entro2 = False
                    '    cbISV.Checked = False
                    'End If
                    'If dgvPagos2.Item(24, contadordeudores).Value = 1 Then
                    '    entro = False
                    '    cbPP.Checked = True
                    '    cbPP.Enabled = True

                    'ElseIf dgvPagos2.Item(24, contadordeudores).Value = 2 Then
                    '    entro = False
                    '    cbPP.Checked = False
                    '    cbPP.Enabled = False

                    'End If
                    contadordeudores = contadordeudores + 1
                Next

            Else
                dgvPagos2.RowCount = 1
                'cbPP.Enabled = True
                'If cbPP.Checked = True Then
                '    dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, dtpFechaPago.Value)
                'ElseIf cbPP.Checked = False Then
                '    dtpFechaPago.Value = dtpInstalacion.Value
                'End If
                'Try
                '    'dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, System.Convert.ToDateTime(rowtemp("FechaPago")))
                'Catch
                'End Try

            End If
            dgvPagos2.FirstDisplayedScrollingRowIndex = dgvPagos2.RowCount - 1
            'dgvPagos2.SelectedRows.Item(dgvPagos2.RowCount - 2).Selected = True
            entro = True
            entro2 = True
            CalcularDescuento()
            If cbDolar.Checked = True Then
                CalcularDescuentoDolar()
            End If
            'Me.dgvPagos2.Sort(Column1, System.ComponentModel.ListSortDirection.Ascending)
            If botonNuevo <> 1 Then
                SeleccionarPagoNavegacion()
            End If
            pb2.Value = 0
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
    End Sub
    Sub llenaGrid(ByVal cadena As String)
        Try
            dgvPagos.Rows.Clear()
            tablatemp3 = ConsultarRegistro(cadena)
            filaspagos = 0
            If tablatemp3.Count > 0 Then
                filaspagos = 1
                dgvPagos.RowCount = tablatemp3.Count
                pb2.Maximum = tablatemp3.Count
                For i As Integer = 0 To tablatemp3.Count - 1
                    pb2.Value = i
                    rowtemp = tablatemp3.Item(i)
                    dgvPagos.Item(0, i).Value = rowtemp("No")
                    dgvPagos.Item(1, i).Value = rowtemp("NoDEI")
                    dgvPagos.Item(2, i).Value = rowtemp("Mes")
                    dgvPagos.Item(3, i).Value = rowtemp("Anio")
                    dgvPagos.Item(4, i).Value = rowtemp("idCliente")
                    dgvPagos.Item(5, i).Value = rowtemp("Nombre")
                    dgvPagos.Item(6, i).Value = rowtemp("Mensualidad")
                    dgvPagos.Item(7, i).Value = rowtemp("FechaInstalacion")
                    dgvPagos.Item(8, i).Value = rowtemp("FechaPago")
                    dgvPagos.Item(9, i).Value = rowtemp("DescuentoD")
                    dgvPagos.Item(10, i).Value = rowtemp("DescuentoH")
                    dgvPagos.Item(11, i).Value = rowtemp("AbonoA")
                    dgvPagos.Item(12, i).Value = rowtemp("AbonoS")
                    dgvPagos.Item(13, i).Value = rowtemp("TotalDescuento")
                    dgvPagos.Item(14, i).Value = rowtemp("RazonDescuento")
                    dgvPagos.Item(15, i).Value = rowtemp("TotalPagar")
                    dgvPagos.Item(16, i).Value = rowtemp("Abono")
                    If rowtemp("Pagado") = 1 Then
                        dgvPagos.Item(17, i).Value = "Si"
                    Else
                        dgvPagos.Item(17, i).Value = "No"
                    End If
                    If rowtemp("equiporetirado") = 2 Then
                        cbEquipo.Checked = False
                    Else
                        cbEquipo.Checked = True
                    End If

                    dgvPagos.Item(18, i).Value = rowtemp("Activo")
                    If dgvPagos.Item(17, i).Value = "Si" Then
                        dgvPagos.Item(19, i).Value = rowtemp("FechaPagado")
                    Else
                        dgvPagos.Item(19, i).Value = ""
                    End If
                    dgvPagos.Item(20, i).Value = rowtemp("Saldo")
                    dgvPagos.Item(21, i).Value = rowtemp("FechaEmision")
                    dgvPagos.Item(22, i).Value = rowtemp("Recargo")
                    dgvPagos.Item(23, i).Value = rowtemp("Efectivo")
                    dgvPagos.Item(24, i).Value = rowtemp("tipoPago")
                    dgvPagos.Item(25, i).Value = rowtemp("NoCorrelativo")

                    If rowtemp("Activo") = 2 Then
                        txtActivo2.ForeColor = Color.Red
                        txtActivo2.Text = "Cliente Inactivo"

                    Else
                        txtActivo2.Text = ""
                        txtActivo2.ForeColor = Color.Green
                        txtActivo2.Text = "Cliente Activo"


                    End If
                    Try
                        dgvPagos.Item(27, i).Value = rowtemp("enDolar").ToString
                        dgvPagos.Item(28, i).Value = rowtemp("precioDolar").ToString
                        dgvPagos.Item(29, i).Value = rowtemp("unidades").ToString
                        dgvPagos.Item(30, i).Value = rowtemp("moneda").ToString
                        dgvPagos.Item(31, i).Value = rowtemp("TipoPlan").ToString
                        dgvPagos.Item(32, i).Value = rowtemp("velocidad").ToString
                        dgvPagos.Item(33, i).Value = rowtemp("tipoPagoDE").ToString
                        dgvPagos.Item(34, i).Value = rowtemp("isv").ToString
                        dgvPagos.Item(35, i).Value = rowtemp("isve").ToString
                        dgvPagos.Item(36, i).Value = rowtemp("estado").ToString
                        dgvPagos.Item(37, i).Value = rowtemp("fechaIn").ToString
                        dgvPagos.Item(38, i).Value = rowtemp("fechahab").ToString
                        dgvPagos.Item(39, i).Value = rowtemp("detallepago").ToString

                        dgvPagos.Item(40, i).Value = rowtemp("cambio").ToString
                        dgvPagos.Item(41, i).Value = rowtemp("NoCorrelativoFicha").ToString
                        dgvPagos.Item(42, i).Value = rowtemp("totalmes").ToString
                        dgvPagos.Item(43, i).Value = rowtemp("cambioant").ToString
                        dgvPagos.Item(44, i).Value = rowtemp("meses").ToString
                        dgvPagos.Item(47, i).Value = rowtemp("usuario").ToString
                        dgvPagos.Item(48, i).Value = rowtemp("Activo1").ToString
                        dgvPagos.Item(49, i).Value = rowtemp("fechaPP").ToString
                        dgvPagos.Item(45, i).Value = rowtemp("ip").ToString
                        dgvPagos.Item(46, i).Value = rowtemp("servidor").ToString
                        dgvPagos.Item(50, i).Value = rowtemp("razonCorte").ToString

                        txtNoFicha.Text = dgvPagos.Item(41, i).Value
                        txtActivo.Text = dgvPagos.Item(48, i).Value
                    Catch S As Exception
                    End Try

                    txtDireccion.Text = rowtemp("Nombrecomunidad") & " " & rowtemp("Nombremunicipio") & " " & rowtemp("NombreDepartamento")
                    txtTelefonoCliente.Text = rowtemp("Telefono").ToString
                    If dgvPagos.Item(34, i).Value = 1 Then
                        entro2 = False
                        cbISV.Checked = True
                    Else
                        entro2 = False
                        cbISV.Checked = False
                    End If
                    If dgvPagos.Item(24, i).Value = 1 Then
                        entro = False
                        cbPP.Checked = True
                        cbPP.Enabled = True

                    ElseIf dgvPagos.Item(24, i).Value = 2 Then
                        entro = False
                        cbPP.Checked = False
                        cbPP.Enabled = False

                    End If
                Next

            Else
                dgvPagos.RowCount = 1
                cbPP.Enabled = True
                If cbPP.Checked = True Then
                    dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, dtpFechaPago.Value)
                ElseIf cbPP.Checked = False Then
                    dtpFechaPago.Value = dtpInstalacion.Value
                End If
                Try
                    'dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, System.Convert.ToDateTime(rowtemp("FechaPago")))
                Catch
                End Try

            End If
            dgvPagos.FirstDisplayedScrollingRowIndex = dgvPagos.RowCount - 1
            'dgvPagos.SelectedRows.Item(dgvPagos.RowCount - 2).Selected = True
            entro = True
            entro2 = True
            CalcularDescuento()
            If cbDolar.Checked = True Then
                CalcularDescuentoDolar()
            End If
            dgvPagos.Sort(Column1, System.ComponentModel.ListSortDirection.Ascending)
            If botonNuevo <> 1 Then
                SeleccionarPagoNavegacion()
            End If
            pb2.Value = 0
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
    End Sub
    Sub llenaList(ByVal cadena As String)
        Try

            lbClientes.Items.Clear()
            LbClientesId.Items.Clear()
            lbClientes2.Items.Clear()
            LbClientesId2.Items.Clear()
            tablatemp3 = ConsultarRegistro(cadena)
            filaspagos = 0

            If tablatemp3.Count > 1 Then
                filaspagos = 1
                'dgvPagos.RowCount = tablatemp3.Count
                gbBusqueda.Visible = True
                lbClientes.Visible = True
                lbClientes.BringToFront()
                lbClientes2.Visible = True
                lbClientes2.BringToFront()
                For i As Integer = 0 To tablatemp3.Count - 1
                    rowtemp = tablatemp3.Item(i)
                    If rowtemp("Activo") = 1 Then
                        LbClientesId.Items.Add(rowtemp("idCliente"))
                        lbClientes.Items.Add(rowtemp("Nombre"))
                    Else
                        LbClientesId2.Items.Add(rowtemp("idCliente"))
                        lbClientes2.Items.Add(rowtemp("Nombre"))
                    End If
                Next
            Else
                Dim idCliente As String
                rowtemp = tablatemp3.Item(0)
                idCliente = rowtemp("idCliente")
                lbClientes.Visible = False
                llenaGrid("Select * from vistapagos where idCliente ='" & idCliente & "' and activo=1  ORDER BY No DESC limit " & txtlimite.Text & "")
                llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & idCliente & "'")
                dgvInstalacion.Rows(0).Selected = True
                SeleccionarClienteInstalacion()
                Id.Text = dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value

                lbClientes.Visible = False
                lbClientes2.Visible = False
                gbBusqueda.Visible = False
                nuevo2()
                dtpFecha1.Value = Today
                dtpFecha2.Value = Today
            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
    End Sub
    Sub llenaGrid2(ByVal cadena As String, ByVal dgv As DataGridView)
        Try
            Dim deuda As Double
            dgv.Rows.Clear()
            tablatemp2 = ConsultarRegistro(cadena)


            If tablatemp2.Count > 0 Then
                dgv.RowCount = tablatemp2.Count
                For i As Integer = 0 To tablatemp2.Count - 1
                    rowtemp = tablatemp2.Item(i)




                    dgv.Item(0, i).Value = i + 1
                    dgv.Item(1, i).Value = rowtemp("NombreComunidad")
                    dgv.Item(2, i).Value = rowtemp("Mes")
                    dgv.Item(3, i).Value = rowtemp("Anio")
                    dgv.Item(4, i).Value = rowtemp("idCliente")
                    dgv.Item(5, i).Value = rowtemp("Nombre")
                    dgv.Item(6, i).Value = rowtemp("Mensualidad")
                    dgv.Item(7, i).Value = System.Convert.ToDateTime(rowtemp("FechaInstalacion"))
                    dgv.Item(8, i).Value = rowtemp("FechaPago")
                    dgv.Item(9, i).Value = rowtemp("DescuentoD")
                    dgv.Item(10, i).Value = rowtemp("DescuentoH")
                    dgv.Item(11, i).Value = rowtemp("AbonoA")
                    dgv.Item(12, i).Value = rowtemp("AbonoS")
                    dgv.Item(13, i).Value = rowtemp("TotalDescuento")
                    dgv.Item(14, i).Value = rowtemp("RazonDescuento")
                    dgv.Item(15, i).Value = rowtemp("TotalPagar")
                    dgv.Item(16, i).Value = rowtemp("Abono")
                    If rowtemp("Pagado") = 1 Then
                        dgv.Item(17, i).Value = "Si"
                    Else
                        dgv.Item(17, i).Value = "No"
                    End If


                    dgv.Item(18, i).Value = rowtemp("Activo")
                    If dgv.Item(17, i).Value = "Si" Then
                        dgv.Item(19, i).Value = rowtemp("FechaPagado")
                    Else
                        dgv.Item(19, i).Value = ""
                    End If
                    dgv.Item(20, i).Value = rowtemp("Saldo")
                    dgv.Item(21, i).Value = rowtemp("FechaEmision")
                    dgv.Item(22, i).Value = rowtemp("Recargo")
                    dgv.Item(23, i).Value = rowtemp("Efectivo")
                    dgv.Item(24, i).Value = rowtemp("tipoPago")
                    dgv.Item(25, i).Value = rowtemp("NoCorrelativo")

                    If rowtemp("Activo") = 2 Then
                        lbEstado.Text = "Cliente Inactivo"
                        lbEstado.BackColor = Color.Red
                    Else
                        lbEstado.Text = ""
                    End If
                    Try
                        dgv.Item(27, i).Value = rowtemp("enDolar").ToString
                        dgv.Item(28, i).Value = rowtemp("precioDolar").ToString
                        dgv.Item(29, i).Value = rowtemp("unidades").ToString
                        dgv.Item(30, i).Value = rowtemp("moneda").ToString
                        dgv.Item(31, i).Value = rowtemp("TipoPlan").ToString
                        dgv.Item(32, i).Value = rowtemp("velocidad").ToString
                        dgv.Item(33, i).Value = rowtemp("tipoPagoDE").ToString
                        dgv.Item(34, i).Value = rowtemp("isv").ToString
                        dgv.Item(35, i).Value = rowtemp("isve").ToString
                        dgv.Item(36, i).Value = rowtemp("estado").ToString
                        dgv.Item(37, i).Value = rowtemp("fechaIn").ToString
                        dgv.Item(38, i).Value = rowtemp("fechahab").ToString
                        dgv.Item(39, i).Value = rowtemp("detallepago").ToString

                        dgv.Item(40, i).Value = rowtemp("cambio").ToString
                        dgv.Item(41, i).Value = rowtemp("NoCorrelativoFicha").ToString
                        dgv.Item(42, i).Value = rowtemp("totalmes").ToString
                        dgv.Item(43, i).Value = rowtemp("cambioant").ToString
                        dgv.Item(44, i).Value = rowtemp("meses").ToString
                        dgv.Item(45, i).Value = rowtemp("usuario").ToString
                        dgv.Item(46, i).Value = rowtemp("FechaPP").ToString
                        dgv.Item(47, i).Value = rowtemp("Telefono").ToString
                    Catch S As Exception
                    End Try



                    txtDireccion.Text = rowtemp("Nombredepartamento") & " " & rowtemp("Nombremunicipio") & " " & rowtemp("NombreComunidad")
                    txtTelefonoCliente.Text = rowtemp("Telefono").ToString
                    If dgv.Item(34, i).Value = 1 Then
                        entro2 = False
                        cbISV.Checked = True
                    Else
                        entro2 = False
                        cbISV.Checked = False
                    End If
                    If dgv.Item(24, i).Value = 1 Then
                        entro = False
                        cbPP.Checked = True
                        cbPP.Enabled = True

                    ElseIf dgv.Item(24, i).Value = 2 Then
                        entro = False
                        cbPP.Checked = False
                        cbPP.Enabled = False

                    End If
                    'txtDireccion.Text = rowtemp("Nombredepartamento") & " " & rowtemp("Nombremunicipio") & " " & rowtemp("NombreComunidad")

                    deuda = dgv.Item(20, i).Value + Val(deuda)

                Next

                For Each fila As DataGridViewRow In dgv.Rows
                    If fila.Cells("estado2").Value = 2 Then
                        fila.DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        fila.DefaultCellStyle.BackColor = Color.White
                    End If

                Next
                lbTotal.Text = "Lps. " & Math.Round(deuda, 2)
            End If

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
#End Region
    Public Function incrementaCodigo(ByVal consulta As String, ByVal campo As String)
        'inicializaConexion(frmMenu.txtDireccionBD.Text)
        Dim contador As Integer
        Try
            data.Clear()
            Dim p As String = consulta
            adaptador = New MySqlDataAdapter(consulta, conexion)
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
                txtdias.Text = diasajuste
            End If
            data.Clear()
            Return contador
        Catch ex As Exception
            'MsgBox(ex.Message.ToString())
        End Try

        Return contador
    End Function
    Sub Limpiar2()
        txtIdentidad.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccionExacta.Text = ""
        btnGuardar.Enabled = True
        Numero.Text = incrementaCodigo("Select * from clientes order by NoCorrelativo", "NoCorrelativo")
        llenaGridClientes("Select * from vistaclientes  limit " & txtNoRegistros2.Text & "")

    End Sub
    Sub Limpiar()
        txtEfectivo.Text = "0"
        txtPrecioDolar.Text = "0"
        txtCambio.Text = "0"
        txtRecargo.Text = "0"
        horas.Text = 0
        txtdias.Text = 0
        cbabono.Checked = False
        txtTotalMes.Text = "0"
        abonoActual.Text = "0"
        txtObservaciones.Text = ""
        txtdias.Enabled = True
        horas.Enabled = True
        txtRecargo.Enabled = True
        txtObservaciones.Enabled = True
        txtEfectivo.Enabled = True
        cbabono.Enabled = True
        cbPagado.Enabled = True
        dtpFechaEmision.Enabled = True
        dtpFechaPago.Enabled = True
        NDEI.Enabled = True
        cbISV.Checked = True
        txtEfectivoEntregado.Text = ""
        txtDescuentoTotal.Text = 0
        txtTotalPagar.Text = 0
        descuentodias = 0

        'dtpFecha1.Value = Today
        'dtpFecha2.Value = Today
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimpiarToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub dias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890.", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub horas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles horas.KeyPress
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


    Private Sub btnBuscarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Limpiar()
            Instalación.formulario = 2
            Instalación.Buscacliente = 1
            'Instalación.Id.Text = Id.Text
            Instalación.ShowDialog()
            Instalación.BringToFront()
            Id.Text = Instalación.Id.Text
            txtNoFicha.Text = Instalación.txtFicha.Text

            txtdias.Focus()
            Instalación.Buscacliente = 0
            If Id.Text <> "" Then
                ResultadoBusqueda()
                nuevo2()
            End If

            txtActivo.Text = instalacionactiva
        Catch
        End Try
    End Sub
    Sub ResultadoBusqueda()
        NDEI.Text = 0
        cbPagado.Checked = False
        cbabono.Checked = False
        ConsultaVelocidad()
        txtTotalPagar.Text = 0
        txtPrecioDolar.Text = 1
        año.Text = dtpFechaPago.Value.Year
        NPago.Text = incrementaCodigo("SELECT No FROM controlpago WHERE idCliente='" & Id.Text & "' ORDER BY No", "No")
        txtNoCorrelativo.Text = incrementaCodigo("Select NoCorrelativo from controlpago order by NoCorrelativo", "NoCorrelativo")
        llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'  order by  No desc limit " & txtlimite.Text & "")
        BuscarAbono()
        NDEI.Text = 0
        txtdias.Focus()
        rbEfectivo.Checked = True
        entro2 = False
        cbISV.Checked = True
        entro2 = True
        txtEfectivo.Text = "0"
        'txtObservaciones.Text = mes.Text
    End Sub
    Sub ConsultaVelocidad()
        Try
            data.Clear()
            tablatemp = ConsultarRegistro("Select mensualidad, fechainstalacion, activo1 from fichainstalacionserviciovista where idCliente='" & Id.Text & "'  and NoCorrelativo=" & NoCorrelativoFicha & "")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp.Item(tablatemp.Count - 1)
                txtMensualidad.Text = rowtemp("Mensualidad")
                dtpInstalacion.Value = rowtemp("FechaInstalacion")
                If rowtemp("Activo1") = 2 Then
                    lbEstado.Text = "Cliente Inactivo"
                    lbEstado.BackColor = Color.Red
                Else
                    lbEstado.Text = ""
                End If
                'NoCorrelativoFicha = rowtemp("NoCorrelativo")
            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub

    Sub BuscarAbono()
        Try
            txtMeses.Text = ""
            data.Clear()
            txtSaldoAnt.Text = 0
            cambioant = 0
            Dim consulta As String
            Dim AbonoAnterior As Double
            consulta = "SELECT Abonos, cambio, mes, Fechapago, efectivo, saldo, pagado FROM controlpago WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text - 1 & "))"""

            tablatemp = ConsultarRegistro("SELECT Abonos, cambio, mes, Fechapago, efectivo, saldo, pagado FROM controlpago WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text - 1 & " order by no desc limit 1")
            If tablatemp.Count > 0 Then
                cbPP.Enabled = False
                rowtemp = tablatemp.Item(tablatemp.Count - 1)
                abonoActual.Text = rowtemp("AbonoS")
                cambioant = rowtemp("cambio")
                txtSaldoAnt.Text = cambioant

                If txtSaldoAnt.Text < 0 Then
                    txtSaldoAnt.Text = txtSaldoAnt.Text * -1
                ElseIf rowtemp("pagado") = 2 Then

                    txtSaldoAnt.Text = txtSaldoAnt.Text * -1
                Else

                    txtSaldoAnt.Text = 0
                End If



                If abonoActual.Text < 0 Then
                    txtDescuentoTotal.Text = descuentodias + descuentoHoras

                Else
                    txtDescuentoTotal.Text = descuentodias + descuentoHoras + Val(abonoActual.Text)

                End If
                Dim dia As Integer
                dia = dtpInstalacion.Value.Day
                dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, System.Convert.ToDateTime(rowtemp("FechaPago")))
                dtpFechaPago.Value = dia & "/" & dtpFechaPago.Value.Month & "/" & dtpFechaPago.Value.Year
                Dim fechacalc As New DateTimePicker
                If cbPP.Checked = True Then
                    mes.SelectedIndex = System.Convert.ToInt32(System.Convert.ToDateTime(System.Convert.ToDateTime(rowtemp("FechaPago")).Date.ToString("yyyy-MM-dd")).Month) - 1
                    fechacalc.Value = System.Convert.ToDateTime(rowtemp("FechaPago"))
                    If fechacalc.Value.Month + 1 = 13 Then
                        año.Text = fechacalc.Value.Year
                    End If
                ElseIf cbPP.Checked = False Then
                    mes.SelectedIndex = System.Convert.ToInt32(dtpFechaPago.Value.Month) - 1
                    If dtpFechaPago.Value.Month = 1 Then
                        año.Text = dtpFechaPago.Value.Year
                    End If
                    If dtpFechaPago.Value.Day >= 15 Then
                        If dtpFechaPago.Value.Month = 12 Then
                            mes.SelectedIndex = 0
                        Else
                            mes.SelectedIndex = System.Convert.ToInt32(dtpFechaPago.Value.Month)
                        End If

                        If dtpFechaPago.Value.Month = 12 Then
                            año.Text = dtpFechaPago.Value.Year + 1
                        End If
                    End If
                End If
                Dim mes1 As String

                mes1 = mes.Text
                AbonoAnterior = rowtemp("abonoS")


                If rowtemp("Pagado") = 2 And rowtemp("abonoS") >= 0 Then
                    'txtTotalMes.Text = Val(txtTotalMes.Text) - cambioant

                    txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(rowtemp("Saldo")) - cambioant
                Else
                    If Val(rowtemp("efectivo")) > 0 And Val(rowtemp("Saldo")) < 0 Then
                        txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(rowtemp("Saldo")) - Val(rowtemp("efectivo")) - rowtemp("abonoS") + txtRecargo.Text - cambioant
                    ElseIf rowtemp("Pagado") = 2 Then

                        txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(rowtemp("Saldo")) - rowtemp("abonoS") - cambioant
                    End If
                End If

                If rowtemp("abonoS") < 0 Then
                    txtTotalPagar.Text = Val(txtTotalMes.Text) + (abonoActual.Text * -1) - cambioant
                End If

                'txtSaldoAnt.Text = Val(txtTotalPagar.Text) - Val(txtTotalMes.Text)

                'If txtSaldoAnt.Text < 0 Then
                '    txtSaldoAnt.Text = 0
                'End If

            Else
                If abonoActual.Text < 0 Then
                    txtDescuentoTotal.Text = descuentodias + descuentoHoras

                Else
                    txtDescuentoTotal.Text = descuentodias + descuentoHoras + Val(abonoActual.Text)

                End If

                If cbPP.Checked = True Then

                    mes.SelectedIndex = System.Convert.ToInt32(dtpInstalacion.Value.Month) - 1
                    If dtpInstalacion.Value.Month + 1 = 13 Then
                        año.Text = dtpInstalacion.Value.Year
                    End If

                ElseIf cbPP.Checked = False Then
                    mes.SelectedIndex = System.Convert.ToInt32(dtpInstalacion.Value.Month) - 1
                    If dtpInstalacion.Value.Month = 1 Then
                        año.Text = dtpInstalacion.Value.Year
                    End If
                    If dtpFechaPago.Value.Day >= 15 Then

                        If System.Convert.ToInt32(dtpFechaPago.Value.Month) = 12 Then
                            mes.SelectedIndex = 0
                            If dtpFechaPago.Value.Month = 12 Then
                                año.Text = dtpFechaPago.Value.Year + 1
                            End If
                        Else
                            mes.SelectedIndex = System.Convert.ToInt32(dtpFechaPago.Value.Month)
                            If dtpFechaPago.Value.Month = 1 Then
                                año.Text = dtpFechaPago.Value.Year
                            End If
                        End If
                    End If
                End If
                abonoActual.Text = 0
                txtTotalMes.Text = Val(txtMensualidad.Text) - txtDescuentoTotal.Text + Val(txtRecargo.Text)
                txtTotalPagar.Text = Val(txtTotalMes.Text) + txtSaldoAnt.Text
            End If
            If txtDescuentoTotal.Text = 0 And AbonoAnterior > 0 Then
                txtDescuentoTotal.Text = AbonoAnterior
            End If
            If txtTotalPagar.Text > 0 Then
                txtTotalMes.Text = txtMens.Text - Val(txtDescuentoTotal.Text) + Val(txtRecargo.Text)
                txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(txtSaldoAnt.Text)
            Else
                txtTotalMes.Text = txtMens.Text - Val(txtDescuentoTotal.Text) + Val(txtRecargo.Text)
                txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(txtSaldoAnt.Text)

            End If
            VerificarmesesMora2()
        Catch m As Exception


        End Try
    End Sub

    Private Sub dias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdias.TextChanged
        txtEfectivoEntregado.Text = ""
        txtDescuentoTotal.Text = 0
        txtTotalPagar.Text = 0
        txtTotalMes.Text = 0
        descuentodias = 0
        CalcularDescuento()
        'txtMens.Text = txtMensualidad.Text
        'descuentodias = ((txtMensualidad.Text * txtPrecioDolar.Text) / 30) * txtdias.Text
        'descuentoHoras = ((txtMensualidad.Text * txtPrecioDolar.Text) / 720) * horas.Text

        'txtEfectivo.Text = 0
        'txtEfectivo.Text = txtTotalPagar.Text
    End Sub
    Sub CalcularDescuentoDolar()
        Try


            BuscarAbono()
            If horas.Text = "" Then
                horas.Text = 0
            End If
            If txtdias.Text = "" Then
                txtdias.Text = 0
            End If
            descuentodias = ((txtMensualidad.Text * txtPrecioDolar.Text) / 30) * txtdias.Text
            descuentoHoras = ((txtMensualidad.Text * txtPrecioDolar.Text) / 720) * horas.Text
            txtCambio.Text = 0

            If abonoActual.Text * txtPrecioDolar.Text < 0 Then
                txtDescuentoTotal.Text = descuentodias + descuentoHoras
                'txtTotalPagar.Text = Math.Round(txtMensualidad.Text - txtDescuentoTotal.Text, 2) + Val(txtRecargo.Text) + (abonoActual.Text * -1) - Val(txtEfectivo.Text)

            Else
                txtDescuentoTotal.Text = descuentodias + descuentoHoras + Val(abonoActual.Text * txtPrecioDolar.Text)

            End If
            txtTotalMes.Text = Math.Round((txtMensualidad.Text * txtPrecioDolar.Text) - txtDescuentoTotal.Text, 2)

            txtTotalPagar.Text = txtTotalPagar.Text * txtPrecioDolar.Text + txtRecargo.Text
            If txtTotalPagar.Text > 0 Then
                txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalPagar.Text)
            Else
                txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalMes.Text)
            End If

            BuscarAbono()
        Catch
        End Try
    End Sub
    Sub CalcularDescuento()
        Try
            txtMens.Text = txtMensualidad.Text
            entro3 = True

            If horas.Text = "" Then
                horas.Text = 0
            End If
            If txtdias.Text = "" Then
                txtdias.Text = 0
            End If
            BuscarAbono()
            descuentodias = (txtMens.Text / 30) * txtdias.Text
            descuentoHoras = (txtMens.Text / 720) * horas.Text
            txtDescuentoTotal.Text = descuentodias + descuentoHoras
            txtCambio.Text = 0
            txtTotalMes.Text = Math.Round(Val(txtMens.Text - txtDescuentoTotal.Text) + Val(txtRecargo.Text), 2)

            If abonoActual.Text > 0 Then
                txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(txtSaldoAnt.Text) - abonoActual.Text
            Else
                txtTotalPagar.Text = Val(txtTotalMes.Text) + Val(txtSaldoAnt.Text)
            End If




            If txtTotalPagar.Text > 0 Then
                txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalPagar.Text)
            Else
                txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalMes.Text) + abonoActual.Text

            End If


        Catch
        End Try

    End Sub
    Sub calcularCambio()
        If txtTotalPagar.Text = "" Then
            txtTotalPagar.Text = 0
        End If
        If txtTotalPagar.Text < 0 Then
            txtCambio.Text = txtTotalPagar.Text * Val(-1)
            If Val(txtEfectivo.Text) = 0 Then
                txtCambio.Text = txtTotalPagar.Text * Val(-1)
            End If

        Else
            If Val(txtEfectivo.Text) = 0 Then
                txtCambio.Text = txtTotalPagar.Text * Val(-1)
            End If
            txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalPagar.Text)
        End If
    End Sub

    Private Sub horas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles horas.TextChanged
        txtEfectivoEntregado.Text = ""
        txtDescuentoTotal.Text = 0
        txtTotalPagar.Text = 0
        txtTotalMes.Text = 0
        descuentodias = 0
        CalcularDescuento()
    End Sub

    Private Sub txtEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivo.TextChanged
        Try
            If cbDolar.Checked = False Then
                If entro3 = False Then
                    CalcularDescuento()
                    BuscarAbono()
                End If
            End If
            If cbDolar.Checked = True And txtEfectivo.Text > 0 Then
                'CalcularDescuentoDolar()
                txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalPagar.Text)
            End If
            calcularCambio()
        Catch
        End Try
    End Sub
    Sub VerificarMora()
        Try
            Dim consultar As String
            Dim filasTotales, CalculofilasMora As Integer

            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta

            CalculofilasMora = 0
            filasmora = 0


            mora = 2
            adaptador = New MySqlDataAdapter("update controlpago set mora=" & mora & "  WHERE idCliente='" & Id.Text & "'", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "controlpago")


            consultar = "Select no from controlpago where idCliente='" & Id.Text & "' and Pagado = 2 and Saldo<>0"
            tablatemp = ConsultarRegistro("Select no from controlpago where idCliente='" & Id.Text & "' and Pagado = 2 and Saldo<>0 order by No")
            filasmora = tablatemp.Count

            data.Clear()
            tablatemp = ConsultarRegistro("SELECT no FROM controlpago WHERE idCliente='" & Id.Text & "' ORDER BY No;")
            consultar = "Select No, * from controlpago where idCliente='" & Id.Text & "' order by No"
            filasTotales = tablatemp.Count
            Filatemporal = tablatemp.Item(filasTotales - 1)
            CalculofilasMora = Filatemporal.Item("No")


            If filasmora > 1 Then
                mora = 1


                For i = 0 To filasmora
                    consultar = "UPDATE controlpago Set controlpago.mora =  " & mora & " WHERE (((controlpago.[idCliente]) ='" & Id.Text & "') AND ((controlpago.[No])=" & CalculofilasMora - i & "));"
                    adaptador = New MySqlDataAdapter("UPDATE controlpago SET controlpago.mora =  " & mora & " WHERE (((controlpago.[idCliente]) ='" & Id.Text & "') AND ((controlpago.[No])=" & CalculofilasMora - i & "));", conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "controlpago")
                Next

            Else
                mora = 2
                adaptador = New MySqlDataAdapter("update controlpago set mora=" & mora & "  WHERE idCliente='" & Id.Text & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "controlpago")
            End If

        Catch
        End Try

    End Sub
    Sub VerificarmesesMora()
        Try
            txtMeses.Text = ""
            If cbPagado.Checked = False Then
                If txtTotalPagar.Text > 0 Then
                    If String.IsNullOrEmpty(dgvPagos.Item(44, dgvPagos.CurrentRow.Index - 1).Value) Then
                        txtMeses.Text = mes.Text.Substring(3)

                    Else
                        If dgvPagos.Item("totmes", dgvPagos.CurrentRow.Index).Value > 0 Then
                            txtMeses.Text = dgvPagos.Item(44, dgvPagos.CurrentRow.Index - 1).Value & ", " & dgvPagos.Item(2, dgvPagos.CurrentRow.Index).Value.ToString.Substring(3)
                        Else
                            txtMeses.Text = dgvPagos.Item(44, dgvPagos.CurrentRow.Index - 1).Value
                        End If
                    End If
                Else
                    txtMeses.Text = ""
                End If

            Else
                txtMeses.Text = ""
            End If
        Catch
        End Try
    End Sub
    Sub VerificarmesesMora2()
        Try
            If dgvPagos.RowCount > 0 Then
                txtMeses.Text = ""
                If cbPagado.Checked = False Then
                    If String.IsNullOrEmpty(dgvPagos.Item(44, dgvPagos.CurrentRow.Index).Value) Then
                        txtMeses.Text = mes.Text.Substring(3)
                    Else
                        txtMeses.Text = dgvPagos.Item(44, dgvPagos.CurrentRow.Index).Value & ", " & mes.Text.Substring(3)
                    End If
                Else
                    txtMeses.Text = ""
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub btnGuardarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPago.Click
        If NPago.Text = 0 Or NPago.Text = "" Then
            nuevo2()
        End If
        Try
            'VerificarmesesMora2()
            'VerificarMora()
            If txtCambio.Text < 0 And cbPagado.Checked = True And txtEfectivo.Text > 0 Then
                cambio = txtCambio.Text
            Else

                cambio = 0
            End If
            If txtNoFicha.Text = 0 Or txtNoFicha.Text = "" Then
                MsgBox("No hay Orden de Instalación activa")
                GoTo salir
            End If
            If txtActivo.Text <> 1 Then
                MsgBox("No hay Orden de Instalación activa")
                GoTo salir
            End If


            If NDEI.Text <> 0 Then
                tablatemp = ConsultarRegistro("Select NoDei from controlpago where NoDei = " & NDEI.Text & "")
                If tablatemp.Count > 0 And dgvPagos.Item(1, dgvPagos.CurrentRow.Index).Value <> NDEI.Text Then
                    MsgBox("Este No de factura ya existe", MsgBoxStyle.Critical, "Atención")
                    data.Clear()
                    GoTo salir

                End If
            End If

            tablatemp = ConsultarRegistro("Select idCliente from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & "' limit 1")
            Dim s As String
            s = "Select * from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & ""
            If tablatemp.Count > 0 Then

                tablatemp = ConsultarRegistro("Select idCliente, Activo, estadocliente  from clientes where idCliente = '" & Id.Text & "'")
                If tablatemp.Count > 0 Then
                    rowtemp = tablatemp(0)
                    If rowtemp("Activo") = 2 Or rowtemp("estadocliente").ToString = 2 Then
                        If cbAgregar.Checked = False Then
                            MsgBox("Este cliente esta inactivo o inhabilitado, no puede agregar nuevos pagos, active la casilla a la par del estado que dice: agregar pagos sin activar", MsgBoxStyle.Critical, "Atención")
                            data.Clear()
                            GoTo salir
                        End If
                    End If
                End If
                ErrorProvider1.Clear()

                If Id.Text = "" Then
                    ErrorProvider1.SetError(Id, "Ingrese el número de identidad")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If cmbUsuarioPago.Text = "" Then
                    ErrorProvider1.SetError(cmbUsuarioPago, "Ingrese el usuario responsable")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If mes.Text = "" Then
                    ErrorProvider1.SetError(mes, "Ingrese el mes de pago")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If año.Text = "" Then
                    ErrorProvider1.SetError(año, "Ingrese el año actual")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If cbPagado.Checked = True And txtEfectivo.Text = "" Then
                    ErrorProvider1.SetError(txtEfectivo, "Ingrese el efectivo")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                Dim pagado, abono, abonoS, tipoP As Double

                If cbPagado.Checked = True Then
                    pagado = 1
                    NDEI.Text = NDEI.Text
                    fechaPago = dtpFechaPago.Value
                    'Fechappago = vbNull
                ElseIf cbPagado.Checked = False Then
                    pagado = 2
                    NDEI.Text = 0
                    'pagado = False
                    fechaPago = dtpFechaPago.Value.Date
                End If

                If cbabono.Checked = True Then
                    abonoS = txtCambio.Text
                    abono = 1
                ElseIf cbabono.Checked = False Then
                    abonoS = 0
                    abono = 2
                End If

                If cbPP.Checked = True Then
                    tipoP = 1
                ElseIf cbPP.Checked = False Then
                    tipoP = 2
                End If
                If horas.Text = "" Then
                    horas.Text = 0
                End If
                If txtdias.Text = "" Then
                    txtdias.Text = 0
                End If
                If txtRecargo.Text = "" Then
                    txtRecargo.Text = 0
                End If
                If cbDolar.Checked = True Then

                    dolar = 1
                ElseIf cbabono.Checked = False Then

                    dolar = 0
                End If
                If cbISV.Checked = True Then
                    isv = 1
                ElseIf cbISV.Checked = False Then
                    isv = 2
                End If

                If cbExonerado.Checked = True Then
                    ISVE = 1
                ElseIf cbExonerado.Checked = False Then
                    ISVE = 2
                End If
                Dim detallepago As String
                If rbEfectivo.Checked And txtEfectivo.Text > 0 Then
                    If txtEfectivoEntregado.Text = "" Then
                        ErrorProvider1.SetError(txtEfectivoEntregado, "Ingrese donde pago el efectivo")
                        GoTo salir
                    Else
                        detallepago = txtEfectivoEntregado.Text
                    End If
                ElseIf rbDeposito.Checked Then
                    detallepago = cmbDeposito.Text

                End If
                Dim estado As Integer
                If rbin.Checked Then
                    estado = 2
                Else
                    estado = 1
                End If
                'Dim consulta As String
                Dim Fecha1 As String = dtpFechaPago.Value.ToString("yyyy-MM-dd")
                Dim Fecha2 As String = dtpPagado.Value.ToString("yyyy-MM-dd")
                Dim Fecha3 As String = dtpFechaEmision.Value.ToString("yyyy-MM-dd")
                Dim Fecha4 As String = dtpInab.Value.ToString("yyyy-MM-dd")
                Dim Fecha5 As String = dtpInab.Value.ToString("yyyy-MM-dd")
                If cbPagado.Checked = True Then
                    txtMeses.Text = ""
                End If
                'consultaprueba = "update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDoupdate controlpago Set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "', detallepago='" & detallepago & "', cambio=" & cambio & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & " WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & ""
#Disable Warning BC42104 ' Se usa la variable antes de que se le haya asignado un valor
                If cbPagado.Checked = True Then
                    adaptador = New MySqlDataAdapter("update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & txtdias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ",  detallepago='" & detallepago & "', cambio=" & txtCambio.Text & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & ", meses='" & txtMeses.Text & "', fechapp=NULL, razonCorte='" & txtrazonCorte.Text & "' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
                Else
                    adaptador = New MySqlDataAdapter("update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & txtdias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ",  detallepago='" & detallepago & "', cambio=" & txtCambio.Text & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & ", meses='" & txtMeses.Text & "', fechapp=NULL, razonCorte='" & txtrazonCorte.Text & "' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)

                End If



                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "controlpago")

                'InsertarBitacora("SE ACTUALIZO PAGO NO " & dgvPagos.Item(0, 0).Value & " A " & dgvPagos.Item(5, 0).Value & "   DE " & txtDireccion.Text & "")
                data.Clear()

                adaptador = New MySqlDataAdapter("update clientes set  estadocliente=1 WHERE idCliente='" & Id.Text & "' ", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                data.Clear()
                botonNuevo = 2
                'Nuevo_Click(Nuevo, e)
                llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
                btnNuevoPago_Click(btnNuevoPago, e)
            Else
                tablatemp = ConsultarRegistro("Select idCliente, Activo, estadocliente  from clientes where idCliente = '" & Id.Text & "'")
                If tablatemp.Count > 0 Then
                    rowtemp = tablatemp(0)
                    If rowtemp("Activo") = 2 Or rowtemp("estadocliente").ToString = 2 Then
                        If cbAgregar.Checked = False Then
                            MsgBox("Este cliente esta inactivo o inhabilitado, no puede agregar nuevos pagos, active la casilla a la par del estado que dice: agregar pagos sin activar", MsgBoxStyle.Critical, "Atención")
                            data.Clear()
                            GoTo salir
                        End If
                    End If
                End If
                ErrorProvider1.Clear()

                If Id.Text = "" Then
                    ErrorProvider1.SetError(Id, "Ingrese el número de identidad")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If mes.Text = "" Then
                    ErrorProvider1.SetError(mes, "Ingrese el mes de pago")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If año.Text = "" Then
                    ErrorProvider1.SetError(año, "Ingrese el año actual")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                If cbPagado.Checked = True And (txtEfectivo.Text.ToString = "") Then
                    ErrorProvider1.SetError(txtEfectivo, "Ingrese el efectivo")
                    GoTo salir
                Else
                    ErrorProvider1.Clear()
                End If
                Dim pagado, abono, abonoS, tipoP As Double

                If cbPagado.Checked = True Then
                    pagado = 1
                    NDEI.Text = NDEI.Text
                    fechaPago = dtpFechaPago.Value
                ElseIf cbPagado.Checked = False Then
                    NDEI.Text = 0
                    pagado = 2
                    fechaPago = dtpFechaPago.Value
                End If

                If cbabono.Checked = True Then
                    abonoS = txtCambio.Text
                    abono = 1
                ElseIf cbabono.Checked = False Then
                    abonoS = 0
                    abono = 2
                End If
                If cbPP.Checked = True Then
                    tipoP = 1
                ElseIf cbPP.Checked = False Then
                    tipoP = 2
                End If
                If horas.Text = "" Then
                    horas.Text = 0
                End If
                If txtdias.Text = "" Then
                    txtdias.Text = 0
                End If
                If cbDolar.Checked = True Then

                    dolar = 1
                ElseIf cbabono.Checked = False Then

                    dolar = 0
                End If

                If cbISV.Checked = True Then
                    isv = 1
                ElseIf cbISV.Checked = False Then
                    isv = 2
                End If

                If cbExonerado.Checked = True Then
                    ISVE = 1
                ElseIf cbExonerado.Checked = False Then
                    ISVE = 2
                End If

                Dim detallepago As String
                detallepago = ""
                If rbEfectivo.Checked And txtEfectivo.Text <> "0" Then
                    If txtEfectivoEntregado.Text = "" Then
                        ErrorProvider1.SetError(txtEfectivoEntregado, "Ingrese donde pago el efectivo")
                        GoTo salir
                    Else
                        detallepago = txtEfectivoEntregado.Text
                    End If
                ElseIf rbDeposito.Checked Then
                    detallepago = cmbDeposito.Text

                End If
                Dim estado As Integer
                If rbin.Checked Then
                    estado = 2
                Else
                    estado = 1
                End If
                Dim insertar As String

                Dim Fecha1 As String = dtpFechaPago.Value.ToString("yyyy-MM-dd")
                Dim Fecha2 As String = dtpPagado.Value.ToString("yyyy-MM-dd")
                Dim Fecha3 As String = dtpFechaEmision.Value.ToString("yyyy-MM-dd")
                'Dim Fecha4 As String = dtpInab.Value.ToString("yyyy-MM-dd")
                'Dim Fecha5 As String = dtpInab.Value.ToString("yyyy-MM-dd")
                'Dim Fecha6 As String = dtpPP.Value.ToString("yyyy-MM-dd")

                If cbPagado.Checked = True Then
                    txtMeses.Text = ""
                End If
                insertar = "insert into controlpago values ('" & NPago.Text & "', '" & NDEI.Text & "', '" & Id.Text & "','" & Fecha1 & "','" & mes.Text & "'," & año.Text & "," & txtdias.Text & "," & horas.Text & "," & abonoActual.Text & "," & abonoS & "," & txtDescuentoTotal.Text & ",'" & txtObservaciones.Text & "'," & txtTotalMes.Text & "," & abono & "," & pagado & ", '" & Fecha2 & "', " & txtTotalPagar.Text & ", '" & Fecha3 & "', " & txtRecargo.Text & ", " & txtEfectivo.Text & ", " & tipoP & ", " & txtNoCorrelativo.Text & ", " & NoCorrelativoFicha & ", " & dolar & ", " & txtPrecioDolar.Text & ", " & tp & ", " & isv & ", " & ISVE & ", " & estado & ", NULL, NULL, '" & detallepago & "', " & txtCambio.Text & "," & txtTotalMes.Text & "," & cambioant & ", " & mora & ", '" & txtMeses.Text & "', 0, NULL"
                'insertar = "insert into controlpago values ('" & NPago.Text & "', '" & NDEI.Text & "', '" & Id.Text & "','" & Fecha1 & "','" & mes.Text & "'," & año.Text & "," & dias.Text & "," & horas.Text & "," & abonoActual.Text & "," & abonoS & "," & txtDescuentoTotal.Text & ",'" & txtObservaciones.Text & "'," & txtTotalMes.Text & "," & abono & "," & pagado & ", '" & Fecha2 & "', " & txtTotalPagar.Text & ", '" & Fecha3 & "', " & txtRecargo.Text & ", " & txtEfectivo.Text & ", " & tipoP & ", " & txtNoCorrelativo.Text & ", " & NoCorrelativoFicha & ", " & dolar & ", " & txtPrecioDolar.Text & ", " & tp & ", " & isv & ", " & ISVE & ", " & estado & ", '" & Fecha4 & "', '" & Fecha5 & "', '" & detallepago & "', " & txtCambio.Text & "," & txtTotalMes.Text & "," & cambioant & ", " & mora & ", '" & txtMeses.Text & "', 0)"
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador = New MySqlDataAdapter("insert into controlpago values ('" & NPago.Text & "', '" & NDEI.Text & "', '" & Id.Text & "','" & Fecha1 & "','" & mes.Text & "'," & año.Text & "," & txtdias.Text & "," & horas.Text & "," & abonoActual.Text & "," & abonoS & "," & txtDescuentoTotal.Text & ",'" & txtObservaciones.Text & "'," & txtTotalMes.Text & "," & abono & "," & pagado & ", '" & Fecha2 & "', " & txtTotalPagar.Text & ", '" & Fecha3 & "', " & txtRecargo.Text & ", " & txtEfectivo.Text & ", " & tipoP & ", " & txtNoCorrelativo.Text & ", " & txtNoFicha.Text & ", " & dolar & ", " & txtPrecioDolar.Text & ", " & tp & ", " & isv & ", " & ISVE & ", " & estado & ", NULL, NULL, '" & detallepago & "', " & txtCambio.Text & "," & txtTotalMes.Text & "," & cambioant & ", " & mora & ", '" & txtMeses.Text & "', 0, NULL, '" & txtrazonCorte.Text & "')", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "controlpago")
                InsertarBitacora("SE AGREGO EL PAGO NO " & dgvPagos.Item(0, 0).Value + 1 & " A " & dgvPagos.Item(5, 0).Value & "    DE " & txtDireccion.Text & "")

                adaptador = New MySqlDataAdapter("update clientes set  estadocliente=1 WHERE idCliente='" & Id.Text & "' ", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                data.Clear()

                'MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "SA INTERRA")
                data.Clear()
                botonNuevo = 2
                llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
                btnNuevoPago_Click(btnNuevoPago, e)
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub
    Sub SeleccionarPago4()
        Try
            If dgvPagos.Rows.Count > 0 And dgvPagos.Item(0, 0).Value.ToString <> "" Then

                NPago.Text = dgvPagos.Item(0, dgvPagos.CurrentRow.Index).Value
                NDEI.Text = dgvPagos.Item(1, dgvPagos.CurrentRow.Index).Value
                For i As Integer = 0 To mes.Items.Count - 1

                    If mes.Text.ToString = dgvPagos.Item(2, dgvPagos.CurrentRow.Index).Value.ToString Then
                        mes.SelectedIndex = i
                        GoTo salir
                    Else
                        mes.SelectedIndex = 0
                    End If
                Next
salir:

                año.Text = dgvPagos.Item(3, dgvPagos.CurrentRow.Index).Value
                Id.Text = dgvPagos.Item(4, dgvPagos.CurrentRow.Index).Value

                txtMensualidad.Text = dgvPagos.Item(6, dgvPagos.CurrentRow.Index).Value
                dtpInstalacion.Value = dgvPagos.Item(7, dgvPagos.CurrentRow.Index).Value
                dtpFechaPago.Value = dgvPagos.Item(8, dgvPagos.CurrentRow.Index).Value
                txtdias.Text = dgvPagos.Item(9, dgvPagos.CurrentRow.Index).Value
                horas.Text = dgvPagos.Item(10, dgvPagos.CurrentRow.Index).Value
                abonoActual.Text = dgvPagos.Item(11, dgvPagos.CurrentRow.Index).Value

                txtDescuentoTotal.Text = dgvPagos.Item(13, dgvPagos.CurrentRow.Index).Value
                txtObservaciones.Text = dgvPagos.Item(14, dgvPagos.CurrentRow.Index).Value.ToString
                txtTotalMes.Text = dgvPagos.Item(15, dgvPagos.CurrentRow.Index).Value
                txtip.Text = dgvPagos.Item(45, dgvPagos.RowCount - 1).Value
                txtServidor.Text = dgvPagos.Item(46, dgvPagos.RowCount - 1).Value
                Try
                    dtpPagado.Value = dgvPagos.Item(19, dgvPagos.CurrentRow.Index).Value
                    dtpFechaEmision.Value = dgvPagos.Item(21, dgvPagos.CurrentRow.Index).Value
                Catch
                End Try
                txtTotalPagar.Text = dgvPagos.Item(20, dgvPagos.CurrentRow.Index).Value
                txtRecargo.Text = dgvPagos.Item(22, dgvPagos.CurrentRow.Index).Value
                txtEfectivo.Text = dgvPagos.Item(23, dgvPagos.CurrentRow.Index).Value
                txtNoCorrelativo.Text = dgvPagos.Item(25, dgvPagos.CurrentRow.Index).Value
                If dgvPagos.Item(16, dgvPagos.CurrentRow.Index).Value = 1 Then
                    cbabono.Checked = True
                Else
                    cbabono.Checked = False
                End If
                If dgvPagos.Item(17, dgvPagos.CurrentRow.Index).Value = "Si" Then
                    cbPagado.Checked = True
                Else
                    cbPagado.Checked = False
                End If
            End If

        Catch s As Exception
        End Try
    End Sub


    Sub SeleccionarPagoModificacion(ByVal i As Integer)
        Try
            NPago.Text = dgvPagos.Item(0, l).Value
            NDEI.Text = dgvPagos.Item(1, l).Value
            Try
                For a As Integer = 0 To mes.Items.Count - 1
                    If mes.Text.ToString = dgvPagos.Item(2, a).Value.ToString Then
                        mes.SelectedIndex = a
                        GoTo salir
                    Else
                        mes.SelectedIndex = 0
                    End If
                Next
salir:
            Catch
            End Try

            año.Text = dgvPagos.Item(3, l).Value
            Id.Text = dgvPagos.Item(4, l).Value
            entro = False
            Nombre.Text = dgvPagos.Item(5, l).Value
            entro = True
            txtMensualidad.Text = dgvPagos.Item(6, l).Value
            dtpInstalacion.Value = dgvPagos.Item(7, l).Value
            dtpFechaPago.Value = dgvPagos.Item(8, l).Value
            txtdias.Text = dgvPagos.Item(9, l).Value
            horas.Text = dgvPagos.Item(10, l).Value
            abonoActual.Text = dgvPagos.Item(11, l).Value

            txtDescuentoTotal.Text = dgvPagos.Item(13, l).Value
            txtObservaciones.Text = dgvPagos.Item(14, l).Value
            txtTotalMes.Text = dgvPagos.Item(15, l).Value
            dtpPagado.Value = dgvPagos.Item(19, l).Value
            txtTotalPagar.Text = dgvPagos.Item(20, l).Value
            dtpFechaEmision.Value = dgvPagos.Item(21, l).Value
            txtRecargo.Text = dgvPagos.Item(22, l).Value
            txtEfectivo.Text = dgvPagos.Item(23, l).Value
            txtNoCorrelativo.Text = dgvPagos.Item(25, l).Value
            If dgvPagos.Item(16, l).Value = 1 Then
                cbabono.Checked = True
            Else
                cbabono.Checked = False
            End If
            If dgvPagos.Item(17, l).Value = 1 Then
                cbPagado.Checked = True
            Else
                cbPagado.Checked = False
            End If

        Catch
        End Try
    End Sub
    Sub SeleccionarPagoNavegacion()
        Try
            If Not String.IsNullOrEmpty(dgvPagos.Item(0, 0).Value) Then
                NPago.Text = dgvPagos.Item(0, dgvPagos.RowCount - 1).Value
                NDEI.Text = dgvPagos.Item(1, dgvPagos.RowCount - 1).Value
                Try
                    If filaspagos > 0 Then
                        For i As Integer = 0 To mes.Items.Count - 1
                            If mes.Items.Item(i).ToString = dgvPagos.Item(2, dgvPagos.RowCount - 1).Value.ToString Then
                                mes.SelectedIndex = i
                                GoTo salir
                            Else
                                mes.SelectedIndex = 0
                            End If

                        Next
                    End If
                Catch
                End Try

salir:

                año.Text = dgvPagos.Item(3, dgvPagos.RowCount - 1).Value
                Id.Text = dgvPagos.Item(4, dgvPagos.RowCount - 1).Value
                Nombre.Text = dgvPagos.Item(5, dgvPagos.RowCount - 1).Value
                txtMensualidad.Text = dgvPagos.Item(6, dgvPagos.RowCount - 1).Value
                dtpInstalacion.Value = dgvPagos.Item(7, dgvPagos.RowCount - 1).Value
                dtpFechaPago.Value = dgvPagos.Item(8, dgvPagos.RowCount - 1).Value
                txtdias.Text = dgvPagos.Item(9, dgvPagos.RowCount - 1).Value
                horas.Text = dgvPagos.Item(10, dgvPagos.RowCount - 1).Value
                abonoActual.Text = dgvPagos.Item(11, dgvPagos.RowCount - 1).Value

                txtDescuentoTotal.Text = Val(dgvPagos.Item(13, dgvPagos.RowCount - 1).Value)
                txtObservaciones.Text = dgvPagos.Item(14, dgvPagos.RowCount - 1).Value
                txtTotalMes.Text = dgvPagos.Item(15, dgvPagos.RowCount - 1).Value
                Try
                    dtpPagado.Value = dgvPagos.Item(19, dgvPagos.RowCount - 1).Value
                Catch
                End Try
                txtTotalPagar.Text = Val(dgvPagos.Item(20, dgvPagos.RowCount - 1).Value)
                dtpFechaEmision.Value = dgvPagos.Item(21, dgvPagos.RowCount - 1).Value
                txtRecargo.Text = Val(dgvPagos.Item(22, dgvPagos.RowCount - 1).Value)
                txtEfectivo.Text = Val(dgvPagos.Item(23, dgvPagos.RowCount - 1).Value)
                txtNoCorrelativo.Text = dgvPagos.Item(25, dgvPagos.RowCount - 1).Value
                txtip.Text = dgvPagos.Item(45, dgvPagos.RowCount - 1).Value
                txtServidor.Text = dgvPagos.Item(46, dgvPagos.RowCount - 1).Value

                If dgvPagos.Item(16, dgvPagos.RowCount - 1).Value = 1 Then
                    cbabono.Checked = True
                Else
                    cbabono.Checked = False
                End If
                If dgvPagos.Item(17, dgvPagos.RowCount - 1).Value = "Si" Then
                    cbPagado.Checked = True
                Else
                    cbPagado.Checked = False
                End If
                txtMeses.Text = dgvPagos.Item(44, dgvPagos.CurrentRow.Index).Value
                If dgvPagos.Item(47, dgvPagos.RowCount - 1).Value.ToString <> "" Then
                    For i As Integer = 0 To cmbUsuarioPago.Items.Count - 1
                        cmbUsuarioPago.SelectedIndex = i
                        If dgvPagos.Item(47, dgvPagos.RowCount - 1).Value.ToString = cmbUsuarioPago.Text.ToString Then
                            GoTo salir4
                        End If
                    Next
                Else
                    cmbUsuarioPago.SelectedIndex = 0
                End If
salir4:
            End If
        Catch s As Exception
        End Try
    End Sub
    Sub SeleccionarPago(ByVal dgv As DataGridView)
        Try
            If Not String.IsNullOrEmpty(dgv.Item(0, dgv.CurrentRow.Index).Value) Then
                NPago.Text = dgv.Item(0, dgv.CurrentRow.Index).Value
                Try
                    NDEI.Text = dgvPagos.Item(1, dgvPagos.CurrentRow.Index).Value
                Catch
                End Try
                If dgv.Name = "dgvPagos" Then
                Else
                    txtDireccion.Text = dgv.Item(1, dgv.CurrentRow.Index).Value
                End If


                For i As Integer = 0 To mes.Items.Count - 1
                    If mes.Items.Item(i).ToString = dgv.Item(2, dgv.CurrentRow.Index).Value.ToString Then
                        mes.SelectedIndex = i
                        GoTo salir
                    Else
                        mes.SelectedIndex = i
                    End If
                Next
salir:
                Try
                    NDEI.Text = dgvPagos.Item(1, dgvPagos.CurrentRow.Index).Value
                Catch
                End Try

                año.Text = dgv.Item(3, dgv.CurrentRow.Index).Value
                Id.Text = dgv.Item(4, dgv.CurrentRow.Index).Value
                entro = False
                Nombre.Text = dgv.Item(5, dgv.CurrentRow.Index).Value
                entro = True
                txtMensualidad.Text = dgv.Item(6, dgv.CurrentRow.Index).Value
                txtMens.Text = dgv.Item(6, dgv.CurrentRow.Index).Value
                If dgv.Item(34, dgv.CurrentRow.Index).Value.ToString = 1 Then
                    entro2 = False
                    cbISV.Checked = True
                Else
                    txtMensualidad.Text = Math.Round(txtMensualidad.Text / 1.15, 2)
                    entro2 = False
                    cbISV.Checked = False
                End If

                If dgv.Item(35, dgv.CurrentRow.Index).Value.ToString = 1 Then
                    cbExonerado.Checked = True
                Else
                    cbExonerado.Checked = False
                End If

                txtTotalMes.Text = txtMensualidad.Text
                dtpInstalacion.Value = dgv.Item(7, dgv.CurrentRow.Index).Value
                If dgv.Item(8, dgv.CurrentRow.Index).Value.ToString <> "" Then
                    dtpFechaPago.Value = dgv.Item(8, dgv.CurrentRow.Index).Value
                End If
                txtdias.Text = dgv.Item(9, dgv.CurrentRow.Index).Value
                horas.Text = dgv.Item(10, dgv.CurrentRow.Index).Value
                abonoActual.Text = dgv.Item(11, dgv.CurrentRow.Index).Value

                txtDescuentoTotal.Text = dgv.Item(13, dgv.CurrentRow.Index).Value
                txtObservaciones.Text = System.Convert.ToString(dgv.Item(14, dgv.CurrentRow.Index).Value)
                txtTotalMes.Text = dgv.Item(15, dgv.CurrentRow.Index).Value
                If dgv.Item(19, dgv.CurrentRow.Index).Value.ToString <> "" Then
                    dtpPagado.Value = dgv.Item(19, dgv.CurrentRow.Index).Value.ToString
                End If
                txtTotalPagar.Text = dgv.Item(20, dgv.CurrentRow.Index).Value
                dtpFechaEmision.Value = dgv.Item(21, dgv.CurrentRow.Index).Value.ToString
                txtRecargo.Text = dgv.Item(22, dgv.CurrentRow.Index).Value
                txtEfectivo.Text = dgv.Item(23, dgv.CurrentRow.Index).Value
                txtip.Text = dgv.Item(45, dgv.CurrentRow.Index).Value
                txtServidor.Text = dgv.Item(46, dgv.CurrentRow.Index).Value
                txtNoCorrelativo.Text = dgv.Item(25, dgv.CurrentRow.Index).Value
                If dgv.Item(16, dgv.CurrentRow.Index).Value = 1 Then
                    cbabono.Checked = True
                Else
                    cbabono.Checked = False
                End If
                Dim PAGADO As Integer
                If dgv.Item(17, dgv.CurrentRow.Index).Value.ToString = "Si" Then
                    PAGADO = 1
                Else
                    PAGADO = 2
                End If
                If PAGADO = 1 Then
                    cbPagado.Checked = True
                Else
                    cbPagado.Checked = False
                End If

                If dgv.Item(24, dgv.CurrentRow.Index).Value = 1 Then
                    cbPP.Checked = True
                Else
                    cbPP.Checked = False
                End If
                Try
                    If dgv(27, dgv.CurrentRow.Index).Value.ToString = 1 Then
                        cbDolar.Checked = True
                        txtPrecioDolar.Text = dgv(28, dgv.CurrentRow.Index).Value
                    End If
                Catch

                End Try

                lbmoneda.Text = dgv.Item(30, dgv.CurrentRow.Index).Value
                Plan.Text = "VELOCIDAD: " & dgv.Item(32, dgv.CurrentRow.Index).Value & " " & dgv.Item(29, dgv.CurrentRow.Index).Value & " PLAN:" & dgv.Item(31, dgv.CurrentRow.Index).Value

                If dgv.Item(33, dgv.CurrentRow.Index).Value = 1 Then
                    rbDeposito.Checked = True
                    For i As Integer = 0 To cmbDeposito.Items.Count - 1
                        If cmbDeposito.Items.Item(i).ToString = dgv.Item(39, dgv.CurrentRow.Index).Value.ToString Then
                            cmbDeposito.SelectedIndex = i
                            GoTo salir2
                        Else
                            cmbDeposito.SelectedIndex = i
                        End If
                    Next
salir2:

                Else
                    Try
                        txtEfectivoEntregado.Text = ""
                        rbEfectivo.Checked = True
                        txtEfectivoEntregado.Text = dgv.Item(39, dgv.CurrentRow.Index).Value.ToString
                    Catch
                    End Try

                End If
                Try
                    If dgv.Item(36, dgv.CurrentRow.Index).Value.ToString = 1 Then
                        txtEstado.Text = "Habilitado"
                        txtEstado.ForeColor = Color.Green
                        rbhab.Checked = True
                    Else
                        txtEstado.Text = "Inhabilitado"
                        txtEstado.ForeColor = Color.Red
                        rbin.Checked = True
                    End If
                Catch
                End Try
                Try
                    dtpInab.Value = dgv.Item(37, dgv.CurrentRow.Index).Value.ToString
                    dtpHab.Value = dgv.Item(38, dgv.CurrentRow.Index).Value.ToString
                Catch s As Exception
                End Try
                txtCambio.Text = dgv.Item(40, dgv.CurrentRow.Index).Value.ToString
                NoCorrelativoFicha = dgv.Item(41, dgv.CurrentRow.Index).Value
                txtMeses.Text = dgv.Item(44, dgv.CurrentRow.Index).Value

                txtNoFicha.Text = NoCorrelativoFicha
                txtActivo.Text = dgv.Item(48, dgv.CurrentRow.Index).Value
                txtrazonCorte.Text = dgv.Item(50, dgv.CurrentRow.Index).Value
                For i As Integer = 0 To cmbUsuarioPago.Items.Count - 1
                    cmbUsuarioPago.SelectedIndex = i
                    If dgv.Item(47, dgv.CurrentRow.Index).Value.ToString = cmbUsuarioPago.Text.ToString Then
                        GoTo salir4
                    End If
                Next
salir4:

                VerificarmesesMora()
                entro3 = False
                entro2 = True
            End If
        Catch S As Exception
        End Try
    End Sub
    Sub SeleccionarParaMesAutomatico()
        Try
            If Not String.IsNullOrEmpty(dgvPagos.Item(0, 0).Value) Then
                NPago.Text = dgvPagos.Item(0, 0).Value
                Try
                    NDEI.Text = dgvPagos.Item(1, 0).Value
                Catch
                End Try
                If dgvPagos.Name = "dgvPagos" Then
                Else
                    txtDireccion.Text = dgvPagos.Item(1, 0).Value
                End If


                For i As Integer = 0 To mes.Items.Count - 1
                    If mes.Items.Item(i).ToString = dgvPagos.Item(2, 0).Value.ToString Then
                        mes.SelectedIndex = i
                        GoTo salir
                    Else
                        mes.SelectedIndex = i
                    End If
                Next
salir:
                Try
                    NDEI.Text = dgvPagos.Item(1, 0).Value
                Catch
                End Try

                año.Text = dgvPagos.Item(3, 0).Value
                Id.Text = dgvPagos.Item(4, 0).Value
                entro = False
                Nombre.Text = dgvPagos.Item(5, 0).Value
                entro = True
                txtMensualidad.Text = dgvPagos.Item(6, 0).Value
                txtMens.Text = dgvPagos.Item(6, 0).Value
                If dgvPagos.Item(34, 0).Value.ToString = 1 Then
                    entro2 = False
                    cbISV.Checked = True
                Else
                    txtMensualidad.Text = Math.Round(txtMensualidad.Text / 1.15, 2)
                    entro2 = False
                    cbISV.Checked = False
                End If

                If dgvPagos.Item(35, 0).Value.ToString = 1 Then
                    cbExonerado.Checked = True
                Else
                    cbExonerado.Checked = False
                End If

                txtTotalMes.Text = txtMensualidad.Text
                dtpInstalacion.Value = dgvPagos.Item(7, 0).Value
                If dgvPagos.Item(8, 0).Value.ToString <> "" Then
                    dtpFechaPago.Value = dgvPagos.Item(8, 0).Value
                End If
                txtdias.Text = dgvPagos.Item(9, 0).Value
                horas.Text = dgvPagos.Item(10, 0).Value
                abonoActual.Text = dgvPagos.Item(11, 0).Value

                txtDescuentoTotal.Text = dgvPagos.Item(13, 0).Value
                txtObservaciones.Text = System.Convert.ToString(dgvPagos.Item(14, 0).Value)
                txtTotalMes.Text = dgvPagos.Item(15, 0).Value
                If dgvPagos.Item(19, 0).Value.ToString <> "" Then
                    dtpPagado.Value = dgvPagos.Item(19, 0).Value.ToString
                End If
                txtTotalPagar.Text = dgvPagos.Item(20, 0).Value
                dtpFechaEmision.Value = dgvPagos.Item(21, 0).Value.ToString
                txtRecargo.Text = dgvPagos.Item(22, 0).Value
                txtEfectivo.Text = dgvPagos.Item(23, 0).Value
                txtip.Text = dgvPagos.Item(45, 0).Value
                txtServidor.Text = dgvPagos.Item(46, 0).Value
                txtNoCorrelativo.Text = dgvPagos.Item(25, 0).Value
                If dgvPagos.Item(16, 0).Value = 1 Then
                    cbabono.Checked = True
                Else
                    cbabono.Checked = False
                End If
                Dim PAGADO As Integer
                If dgvPagos.Item(17, 0).Value.ToString = "Si" Then
                    PAGADO = 1
                Else
                    PAGADO = 2
                End If
                If PAGADO = 1 Then
                    cbPagado.Checked = True
                Else
                    cbPagado.Checked = False
                End If

                If dgvPagos.Item(24, 0).Value = 1 Then
                    cbPP.Checked = True
                Else
                    cbPP.Checked = False
                End If
                Try
                    If dgvPagos(27, 0).Value.ToString = 1 Then
                        cbDolar.Checked = True
                        txtPrecioDolar.Text = dgvPagos(28, 0).Value
                    End If
                Catch

                End Try

                lbmoneda.Text = dgvPagos.Item(30, 0).Value
                Plan.Text = "VELOCIDAD: " & dgvPagos.Item(32, 0).Value & " " & dgvPagos.Item(29, 0).Value & " PLAN:" & dgvPagos.Item(31, 0).Value

                If dgvPagos.Item(33, 0).Value = 1 Then
                    rbDeposito.Checked = True
                    For i As Integer = 0 To cmbDeposito.Items.Count - 1
                        If cmbDeposito.Items.Item(i).ToString = dgvPagos.Item(39, 0).Value.ToString Then
                            cmbDeposito.SelectedIndex = i
                            GoTo salir2
                        Else
                            cmbDeposito.SelectedIndex = i
                        End If
                    Next
salir2:

                Else
                    Try
                        txtEfectivoEntregado.Text = ""
                        rbEfectivo.Checked = True
                        txtEfectivoEntregado.Text = dgvPagos.Item(39, 0).Value.ToString
                    Catch
                    End Try

                End If
                Try
                    If dgvPagos.Item(36, 0).Value.ToString = 1 Then
                        txtEstado.Text = "Habilitado"
                        txtEstado.ForeColor = Color.Green
                        rbhab.Checked = True
                    Else
                        txtEstado.Text = "Inhabilitado"
                        txtEstado.ForeColor = Color.Red
                        rbin.Checked = True
                    End If
                Catch
                End Try
                Try
                    dtpInab.Value = dgvPagos.Item(37, 0).Value.ToString
                    dtpHab.Value = dgvPagos.Item(38, 0).Value.ToString
                Catch s As Exception
                End Try
                txtCambio.Text = dgvPagos.Item(40, 0).Value.ToString
                NoCorrelativoFicha = dgvPagos.Item(41, 0).Value
                txtMeses.Text = dgvPagos.Item(44, 0).Value

                txtNoFicha.Text = NoCorrelativoFicha
                txtActivo.Text = dgvPagos.Item(48, 0).Value
                txtrazonCorte.Text = dgvPagos.Item(50, 0).Value
                For i As Integer = 0 To cmbUsuarioPago.Items.Count - 1
                    cmbUsuarioPago.SelectedIndex = i
                    If dgvPagos.Item(47, 0).Value.ToString = cmbUsuarioPago.Text.ToString Then
                        GoTo salir4
                    End If
                Next
salir4:

                VerificarmesesMora()
                entro3 = False
                entro2 = True
            End If
        Catch S As Exception
        End Try
    End Sub


    Sub nuevo2()
        botonNuevo = 1
        lbClientes.Visible = False
        lbClientes2.Visible = False
        txtNoCorrelativo.Text = incrementaCodigo("Select NoCorrelativo from controlpago order by NoCorrelativo desc limit 1", "NoCorrelativo")
        llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'  order by  no desc limit " & txtlimite.Text & "")
        If NoCorrelativoFicha = 0 Then
            tablatemp = ConsultarRegistro("Select NoCorrelativo, Mensualidad from fichainstalacionserviciovista where idCliente = '" & Id.Text & "' and activo1=1")
            If dgvPagos.RowCount > 0 Then
                Id.Text = dgvPagos.Item(4, 0).Value
            End If
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                txtMens.Text = ""
                NoCorrelativoFicha = rowtemp("NoCorrelativo")
                txtMens.Text = rowtemp("Mensualidad")
                txtNoFicha.Text = NoCorrelativoFicha
            End If
        Else
            tablatemp = ConsultarRegistro("Select NoCorrelativo, Mensualidad from fichainstalacionserviciovista where idCliente = '" & Id.Text & "' and noCorrelativo=" & NoCorrelativoFicha & "")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                txtMens.Text = ""
                NoCorrelativoFicha = rowtemp("NoCorrelativo")
                txtMens.Text = rowtemp("Mensualidad")
                txtNoFicha.Text = NoCorrelativoFicha
            End If
        End If

        CalcularDescuento()
        'NDEI.Text = 0
        txtdias.Focus()
        rbEfectivo.Checked = True
        entro2 = False
        cbISV.Checked = True
        entro2 = True
        txtEfectivo.Text = "0"
        'txtObservaciones.Text = mes.Text
        NPago.Text = incrementaCodigo("SELECT no, ldCliente FROM controlpago WHERE idCliente='" & Id.Text & "' ORDER BY no DESC limit 1", "No")

        'And anio='" & cmbAnio.Text & "'
    End Sub
    Private Sub btnNuevoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPago.Click
        cbAgregar.Checked = False
        pb2.Value = 0
        botonNuevo = 1
        Limpiar()
        NDEI.Text = 0
        NoCorrelativoFicha = 0
        cbPagado.Checked = False
        cbabono.Checked = False
        ConsultaVelocidad()
        txtTotalPagar.Text = 0
        txtPrecioDolar.Text = 1
        año.Text = dtpFechaPago.Value.Year
        NPago.Text = incrementaCodigo("SELECT no, idCliente FROM controlpago WHERE idCliente='" & Id.Text & "' ORDER BY no DESC limit 1", "No")

        If dgvPagos.RowCount > 0 Then
            If Not String.IsNullOrEmpty(dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value) Then
                Id.Text = dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value
            End If
        End If
        txtNoCorrelativo.Text = incrementaCodigo("Select NoCorrelativo from controlpago order by NoCorrelativo desc limit 1", "NoCorrelativo")
        'llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'  order by  no desc limit " & txtlimite.Text & "")
        If NoCorrelativoFicha = 0 Then
            tablatemp = ConsultarRegistro("Select Activo1, NoCorrelativo, Mensualidad from fichainstalacionserviciovista where idCliente = '" & Id.Text & "' and activo1=1")
            If dgvPagos.RowCount > 0 Then
                If Not String.IsNullOrEmpty(dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value) Then
                    Id.Text = dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value
                End If
            End If
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                txtMens.Text = ""
                NoCorrelativoFicha = rowtemp("NoCorrelativo")
                txtMens.Text = rowtemp("Mensualidad")
                txtNoFicha.Text = NoCorrelativoFicha
                txtActivo.Text = rowtemp("Activo1")
            End If

        Else
            tablatemp = ConsultarRegistro("Select Activo1, NoCorrelativo, Mensualidad from fichainstalacionserviciovista where idCliente = '" & Id.Text & "' and noCorrelativo=" & NoCorrelativoFicha & "")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                txtMens.Text = ""
                NoCorrelativoFicha = rowtemp("NoCorrelativo")
                txtMens.Text = rowtemp("Mensualidad")
                txtNoFicha.Text = NoCorrelativoFicha
                txtActivo.Text = rowtemp("Activo1")
            End If
        End If
        NDEI.Text = 0
        txtdias.Focus()
        rbEfectivo.Checked = True
        entro2 = False
        cbISV.Checked = True
        entro2 = True
        txtEfectivo.Text = "0"
        'txtObservaciones.Text = mes.Text

        CalcularDescuento()
        VerificarmesesMora2()
        If dgvPagos.RowCount > 1 Then
            Nombre.Text = dgvPagos.Item(5, dgvPagos.Rows.Count - 1).Value

        End If

    End Sub



    Private Sub cbPagado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPagado.CheckedChanged
        If cbPagado.Checked = True Then
            dtpPagado.Enabled = True
            dtpFechaEmision.Enabled = True
            Fechappago = "NULL"

        ElseIf cbPagado.Checked = False Then
            dtpPagado.Enabled = False
            dtpFechaEmision.Enabled = False
            'txtEfectivo.Text = 0
        End If
    End Sub


    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Dim c As String = "Select * from controlpago where idCliente = '" & Id.Text & "' and No=" & dgvPagos(0, dgvPagos.CurrentRow.Index).Value & ""
                adaptador = New MySqlDataAdapter(c, conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "controlpago")

                If data.Tables("controlpago").Rows.Count > 0 Then
                    c = "Delete from controlpago where idCliente='" & Id.Text & "' and No=" & dgvPagos(0, dgvPagos.CurrentRow.Index).Value & ""
                    adaptador = New MySqlDataAdapter(c, conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    InsertarBitacora("SE ELIMINO EL PAGO NO " & dgvPagos.Item(0, 0).Value & "   A " & dgvPagos.Item(5, 0).Value & "   DE " & txtDireccion.Text & "")

                    MsgBox("Registro eliminado exitosamente")
                    data.Clear()
                    llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
                    btnNuevoPago_Click(btnNuevoPago, e)
                End If
            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub

    'Private Sub dias_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdias.Validating
    '    CalcularDescuento()
    '    'If cbDolar.Checked = True Then
    '    '    CalcularDescuentoDolar()
    '    'End If
    'End Sub

    Private Sub txtRecargo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecargo.TextChanged

        If txtRecargo.Text = "" Then
            txtRecargo.Text = 0
        End If
        'CalcularDescuento
        txtTotalPagar.Text = Val(txtSaldoAnt.Text) + Val(txtTotalMes.Text) + Val(txtRecargo.Text)

        'If cbDolar.Checked = True Then
        '    CalcularDescuentoDolar()
        'End If
    End Sub

    Private Sub txtRecargo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecargo.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890.", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub


    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            ExcelHISTORIAL(dgvPagos)
            'Dim rpt2 As New rptHistorial
            'ReporteHistorial.id = Id.Text
            'rpt2.RecordSelectionFormula = "{vistapagos.idCliente} ='" & Id.Text & "'"
            'ReporteHistorial.crvVisor.ReportSource = rpt2
            'ReporteHistorial.Refresh()
            'ReporteHistorial.ShowDialog()
        Catch S As Exception
        End Try

    End Sub

    Private Sub cbPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPP.CheckedChanged
        'CalcularDescuento()

        Try
            Dim FECHAPAGOANT As New DateTimePicker
            FECHAPAGOANT.Value = dtpFechaPago.Value
            If cbPP.Checked = True Then
                dtpFechaPago.Value = DateAdd(DateInterval.Month, 1, dtpInstalacion.Value)
                'mes.SelectedIndex = System.Convert.ToInt32(dtpFechaPago.Value.Month) - 2
            ElseIf cbPP.Checked = False Then
                'dtpFechaPago.Value = FECHAPAGOANT.Value
                dtpFechaPago.Value = dtpInstalacion.Value
                'mes.SelectedIndex = System.Convert.ToInt32(dtpFechaPago.Value.Month) - 1

            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
        'llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'  order by controlpago.NoCorrelativo")
    End Sub

    Private Sub dtpFechaEmision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaEmision.ValueChanged
        'dtpPagado.Value = dtpFechaEmision.Value

    End Sub

    Private Sub dtpFechaEmision_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEmision.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpPagado.Value = dtpFechaEmision.Value
            dtpPagado.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
    End Sub

    Private Sub NDEI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnGuardarPago.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
    End Sub

    Private Sub dtpPagado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpPagado.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
        If e.KeyCode = Keys.Enter Then
            NDEI.Focus()
        End If
    End Sub

    Private Sub txtEfectivo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Guardar_Click(btnGuardarPago, e)
            End If
            If e.KeyCode = Keys.Enter Then
                cbabono.Focus()
            End If
            If txtEfectivo.Text > 0 Then
                cbPagado.Checked = True
                If txtCambio.Text > 0 Then
                    cbabono.Checked = True
                End If
            End If
        Catch s As Exception
        End Try
    End Sub

    Private Sub txtRazon_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
        If e.KeyCode = Keys.Enter Then
            txtEfectivo.Focus()
        End If
    End Sub

    Private Sub dias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdias.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
        If e.KeyCode = Keys.Enter Then
            horas.Focus()
        End If
    End Sub

    Private Sub horas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles horas.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
        If e.KeyCode = Keys.Enter Then
            txtRecargo.Focus()
        End If
    End Sub

    Private Sub cbabono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbabono.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbPagado.Focus()
        End If
    End Sub

    Private Sub cbPagado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbPagado.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFechaEmision.Focus()
        End If
    End Sub

    Private Sub txtRecargo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecargo.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardarPago, e)
        End If
        If e.KeyCode = Keys.Enter Then
            txtObservaciones.Focus()
        End If
    End Sub

    Private Sub Id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Id.TextChanged
        If entro = True Then

            'tablatemp = ConsultarRegistro("Select * from clientes where idCliente = '" & Id.Text & "'")
            'If tablatemp.Count > 0 Then
            '    rowtemp = tablatemp(0)
            '    If rowtemp("Activo") = 2 Then
            '        lbEstado.Text = "Cliente Inactivo"
            '        lbEstado.BackColor = Color.Red
            '    Else
            '        lbEstado.Text = ""
            '    End If
            'End If
        End If
    End Sub


    Sub MostrarDeudores()
        'MostrarUsuario()
        ''VerificarMesActual()
        'If cbMostrarTodo.Checked = True Then
        '    'llenaGrid2("Select * from vistapagos where totalpagar>0 and pagado=2 " & usuarioActual & "  and anio='" & cmbaño2.Text & "' and activo=1 and mes LIKE '%" & cmbmes2.Items.Item(cmbmes2.SelectedIndex) & "%' group by nombre  order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
        '    'ElseIf cbMostrarTodo.Checked = True Then
        '    llenaGrid2("Select * from vistapagos where totalpagar>0 and mes='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
        'Else
        '    llenaGrid2("Select * from vistapagos where totalpagar>0 and mes='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and nombredepartamento ='" & cmbdepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

        'End If

        ''End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbmes2.Text = "" Then
            ErrorProvider1.SetError(cmbmes2, "Ingrese el mes")
            GoTo salir
        End If
        If cmbaño2.Text = "" Then
            ErrorProvider1.SetError(cmbaño2, "Ingrese el año")
            GoTo salir
        End If
        If cmbUsuario.Text = "" Then
            ErrorProvider1.SetError(cmbUsuario, "Ingrese el usuario")
            GoTo salir
        End If
        MostrarDeudores()
        MostrarUsuario()
        If cbMostrarTodo.Checked = True Then
            If cbFechaPP.Checked = False Then

                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' AND MESES <>'" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is not Null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
            Else

                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' AND MESES <>'" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

            End If
        Else

            If cbFechaPP.Checked = False Then

                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' AND MESES <>'" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is not null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
            Else

                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' AND MESES <>'" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

            End If

        End If
salir:
    End Sub

    Private Sub NDEI_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NDEI.MouseClick
        entroDei = True
    End Sub

    Private Sub NDEI_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NDEI.MouseLeave

    End Sub

    'Private Sub btnMostrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    llenaGrid2("Select * from vistapagos where mes='" & cmbMes3.Text & "' and anio='" & cmbAño3.Text & "' and efectivo>0 and pagado=1 order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

    'End Sub




    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Try
            If cmbNombreDepartamento.Text = "" Or cmbNombreComunidad.Text = "" Or cmbNombremunicipio.Text = "" Then
                MsgBox("Seleccione el departamento, municipio y Comunidad que desea enlistar")
                GoTo Salir
            End If
            'llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 and nombredepartamento='" & cmbdepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by Nombre ", dgvclientes)
            Id.Text = dgvclientes.Item(1, navegacion).Value
            If navegacion < dgvclientes.RowCount - 1 Then
                navegacion = navegacion + 1
                lblreg.Text = "Registro No. " & navegacion
            Else
                lblreg.Text = "Registro No. " & navegacion + 1
            End If


            BuscarPagoPorNavegacion()
            Dim nombre As String
            nombre = dgvclientes.Item(2, navegacion).Value

            SeleccionarPagoNavegacion()
            VerificarmesesMora()
            VerificarmesesMora2()
            'tablatemp = ConsultarRegistro("Select idCliente, Activo from clientes where idCliente = '" & Id.Text & "'")
            'If tablatemp.Count > 0 Then
            '    rowtemp = tablatemp(0)
            '    If rowtemp("Activo") = 2 Then
            '        lbEstado.Text = "Cliente Inactivo"
            '        lbEstado.BackColor = Color.Red
            '    Else
            '        lbEstado.Text = ""
            '    End If

            'End If

        Catch
        End Try
Salir:
    End Sub


    Private Sub Anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Anterior.Click
        Try
            If cmbNombreDepartamento.Text = "" Or cmbNombreComunidad.Text = "" Or cmbNombremunicipio.Text = "" Then
                MsgBox("Seleccione el departamento, municipio y Comunidad que desea enlistar")
                GoTo salir
            End If
            'llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 and nombredepartamento='" & cmbdepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by Nombre ", dgvclientes)

            If navegacion > 0 Then
                navegacion = navegacion - 1
            End If
            Id.Text = dgvclientes.Item(1, navegacion).Value
            BuscarPagoPorNavegacion()
            SeleccionarPagoNavegacion()

            lblreg.Text = "Registro No. " & navegacion + 1
            VerificarmesesMora()
            VerificarmesesMora2()
            If navegacion = 0 Then
                navegacion = 1
            End If
salir:
        Catch
        End Try
    End Sub


    Private Sub ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ultimo.Click
        Try
            If cmbNombreDepartamento.Text = "" Or cmbNombreComunidad.Text = "" Or cmbNombremunicipio.Text = "" Then
                MsgBox("Seleccione el departamento, municipio y Comunidad que desea enlistar")
                GoTo salir
            End If

            'llenaGridCliente("Select * from vistaclientes where activo=1 and nombredepartamento='" & cmbdepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by NoCorrelativo ")
            'llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 and nombredepartamento='" & cmbdepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by Nombre ", dgvclientes)
            navegacion = dgvclientes.RowCount - 1
            Id.Text = dgvclientes.Item(1, navegacion).Value
            BuscarPagoPorNavegacion()
            SeleccionarPagoNavegacion()

            lblreg.Text = "Registro No. " & navegacion + 1
            tablatemp = ConsultarRegistro("Select * from clientes where idCliente = '" & Id.Text & "'")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                If rowtemp("Activo") = 2 Then
                    lbEstado.Text = "Cliente Inactivo"
                    lbEstado.BackColor = Color.Red
                Else
                    lbEstado.Text = ""
                End If
            End If

            VerificarmesesMora()
            VerificarmesesMora2()
salir:
        Catch
        End Try
    End Sub

    Private Sub primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles primero.Click
        Try
            If cmbNombreDepartamento.Text = "" Or cmbNombreComunidad.Text = "" Or cmbNombremunicipio.Text = "" Then
                MsgBox("Seleccione el departamento, municipio y Comunidad que desea enlistar")
                GoTo salir
            End If
            navegacion = 0
            Id.Text = dgvclientes.Item(1, navegacion).Value
            BuscarPagoPorNavegacion()
            SeleccionarPagoNavegacion()
            lblreg.Text = "Registro No. " & navegacion + 1
            tablatemp = ConsultarRegistro("Select * from clientes where idCliente = '" & Id.Text & "'")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp(0)
                If rowtemp("Activo") = 2 Then
                    lbEstado.Text = "Cliente Inactivo"
                    lbEstado.BackColor = Color.Red
                Else
                    lbEstado.Text = ""
                End If
            End If
            VerificarmesesMora()
            VerificarmesesMora2()
salir:
        Catch
        End Try
    End Sub


    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clientes.identidadPagos = Id.Text
        clientes.ShowDialog()
        clientes.BringToFront()
    End Sub


    Private Sub txtPrecioDolar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioDolar.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890.", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim correlativo As Integer = 0
        correlativo = txtNoInicial.Text
        For i As Integer = 0 To txtNFact.Text
            If dgvFacturas.Item(2, l).Value.ToString = "" Or (dgvFacturas.Item(2, l).Value.ToString = "0") Then
                dgvFacturas.Item(2, l).Value = correlativo
                correlativo = correlativo + 1
            End If
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For i As Integer = 0 To dgvFacturas.RowCount - 1
            dgvFacturas.Item(2, l).Value = 0

        Next
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btnMensaje_Click(sender As Object, e As EventArgs) Handles btnMensaje.Click
        Try
            Using mensaje As New TextBox
                mensaje.Text = ""
                If txtDireccion.Text.Contains("EL OCOTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA CALIENTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA ZARCA, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("EL TABLON, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("SAN PEDRO ZACAPA") Then
                    '                
                    mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & "   SU SALDO POR SERVICIO DE INTERNET ES DE *" & txtTotalPagar.Text & "LPS(" & txtMeses.Text & ")*, PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS : 
                -CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                Else

                    If txtDireccion.Text.Contains("ATIMA") Or txtDireccion.Text.Contains("SAN NICOLAS") Or txtDireccion.Text.Contains("NUEVO CELILAC") Or txtDireccion.Text.Contains("NARANJITOS") Or txtDireccion.Text.Contains("NARANJITO") Then
                        mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & "   SU SALDO POR SERVICIO DE INTERNET ES DE " & txtTotalPagar.Text & "LPS(" & txtMeses.Text & "), PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS: 
                -CTA. ATLANTIDA 13200450677 A LEYLA GISELA VASQUEZ ENAMORADO ENAMORADO
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 98817013 A NOMBRE DE ELSY MAHELY REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                    Else
                        mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & "   SU SALDO POR SERVICIO DE INTERNET ES DE " & txtTotalPagar.Text & "LPS(" & txtMeses.Text & "), PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS : 
                -CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                    End If
                End If
                Clipboard.SetDataObject(mensaje.Text, True)
            End Using
        Catch
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnRecordar.Click
        Using mensaje As New TextBox
            mensaje.Text = ""
            If txtDireccion.Text.Contains("EL OCOTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA CALIENTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA ZARCA, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("EL TABLON, SAN PEDRO ZACAPA") Then
                mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & "   LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET FAVOR DEPOSITAR A: 
-CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
            Else
                If txtDireccion.Text.Contains("ATIMA") Or txtDireccion.Text.Contains("SAN NICOLAS") Or txtDireccion.Text.Contains("NUEVO CELILAC") Or txtDireccion.Text.Contains("NARANJITOS") Or txtDireccion.Text.Contains("NARANJITO") Then
                    mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & " LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS: 
                -CTA. ATLANTIDA 13200450677 A LEYLA GISELA VASQUEZ ENAMORADO ENAMORADO
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 98817013 A NOMBRE DE ELSY MAHELY REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                Else

                    mensaje.Text = cmbMensaje.Text & " ESTIMADO(A) " & dgvPagos.Item(5, 0).Value & "  LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET FAVOR DEPOSITAR A: 
-CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                End If
            End If
            Clipboard.SetDataObject(mensaje.Text, True)
        End Using
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Try
            If dgvDeben.Rows.Count > 0 Then
                If dgvDeben.Item(dgvDeben.Columns("saldo2").Index, dgvDeben.CurrentRow.Index).Value > dgvDeben.Item(dgvDeben.Columns("mensu").Index, dgvDeben.CurrentRow.Index).Value Then
                    Clipboard.SetDataObject(cmbMensaje2.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET Ó DEME UNA FECHA DE COMPROMISO DE PAGO  POR FAVOR", True)
                Else
                    Clipboard.SetDataObject(cmbMensaje.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET POR FAVOR", True)

                End If
            Else
                Clipboard.SetDataObject(cmbMensaje.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET POR FAVOR", True)

            End If



        Catch
        End Try
    End Sub

    Private Sub rbin_CheckedChanged(sender As Object, e As EventArgs) Handles rbin.CheckedChanged
        If rbin.Checked And rbhab.Checked = False Then
            dtpInab.Enabled = True
            dtpHab.Enabled = False
            dtpInab.Value = Today.Date
            btnHab.Enabled = False
            btnin.Enabled = True
        ElseIf rbhab.Checked And rbin.Checked = False Then
            dtpInab.Enabled = False
            dtpHab.Enabled = True
            btnHab.Enabled = True
            btnin.Enabled = False
            dtpHab.Value = Today.Date
        End If
    End Sub

    Private Sub rbhab_CheckedChanged(sender As Object, e As EventArgs) Handles rbhab.CheckedChanged
        If rbin.Checked And rbhab.Checked = False Then
            dtpInab.Enabled = True
            dtpHab.Enabled = False
        ElseIf rbhab.Checked And rbin.Checked = False Then
            dtpInab.Enabled = False
            dtpHab.Enabled = True
        End If
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        Try
            Dim numero As Short = CShort(Asc(e.KeyChar))
            If e.KeyChar = vbBack Then
                Exit Sub
            End If

            If InStr("1234567890.", Chr(numero)) = 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
            If txtEfectivo.Text > 0 Then
                cbPagado.Checked = True
                If txtCambio.Text > 0 Then
                    cbabono.Checked = True
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnFecha.Click
        Dim correlativo As Integer = 0
        For i As Integer = 0 To dgvFacturas.Rows.Count - 1
            If dgvFacturas.Item(1, i).Selected = True Then
                dgvFacturas.Item(1, i).Value = dtpFechaN.Value
                dgvFacturas.Item("cbselec", i).Value = True
            End If
        Next
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            respuesta = MsgBox("Desea dar de baja al cliente " & dgvPagos.Item(0, 0).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("update clientes set Activo=2  where idCliente='" & Id.Text & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
                Dim Fecha6 As String = Fechabaja.Value.ToString("yyyy-MM-dd")
                Dim s As String
                s = "update fichaintalacionservicio set fechabaja='" & Fecha6 & "' where idCliente='" & Id.Text & "' And NoCorrelativo='" & txtNoFicha.Text & "'"
                adaptador = New MySqlDataAdapter("update fichaintalacionservicio set fechabaja='" & Fecha6 & "' where idCliente='" & Id.Text & "' And NoCorrelativo='" & txtNoFicha.Text & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "fichainstalacionservicio")
                InsertarBitacora("SE DIO DE BAJA A " & dgvPagos.Item(5, 0).Value & " DE " & txtDireccion.Text & "")

                MsgBox("Registro actualizado exitosamente")
                data.Clear()

                llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'")
            End If
        Catch s As Exception
        End Try
    End Sub

    Sub CargarPagos()
        llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "' ORDER BY No DESC limit " & txtlimite.Text & "")

        If dgvPagos.RowCount > 1 Then
            Id.Text = dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value
        End If


        llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & Id.Text & "'")
        If dgvInstalacion.RowCount > 0 Then
            dgvInstalacion.Rows(0).Selected = True
            SeleccionarClienteInstalacion()
        Else
            TabClientes.SelectedIndex = 1
            LimpiarInstalacion()
        End If
        lbClientes.Visible = False
        lbClientes2.Visible = False
        CalcularDescuento()

    End Sub
    Sub CargarPagos2()
        llenaGrid("Select * from vistapagos where idCliente ='" & LbClientesId.Items.Item(lbClientes.SelectedIndex).ToString & "'    ORDER BY No DESC limit " & txtlimite.Text & "")

        Id.Text = LbClientesId.Items.Item(lbClientes.SelectedIndex).ToString
        Nombre.Text = dgvPagos.Item(5, dgvPagos.Rows.Count - 1).Value
        'If (dgvPagos.Item(36, dgvPagos.CurrentRow.Index).Value = 1) Then
        '    txtActivo2.Text = "INACTIVO"
        'Else
        '    txtActivo2.Text = "ACTIVO"
        'End If
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & Id.Text & "'")
        dgvInstalacion.Rows(0).Selected = True
        SeleccionarClienteInstalacion()
        lbClientes.Visible = False
        lbClientes2.Visible = False
        gbBusqueda.Visible = False
    End Sub
    Private Sub lbClientes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbClientes.MouseDoubleClick
        CargarPagos2()
        gbBusqueda.Visible = False
    End Sub


    Private Sub txtlimite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtlimite.KeyPress
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

    Private Sub dgvPagos_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvPagos.MouseClick
        lbClientes.Visible = False
        'llenaGrid("Select * from vistapagos where Nombre like '%" & Nombre.Text & "%' order by controlpago.NoCorrelativo")
        Try
empezar:
            For i As Integer = 0 To dgvPagos.RowCount - 1
                If dgvPagos.Item(5, i).Value <> dgvPagos.Item(5, dgvPagos.CurrentRow.Index).Value Then
                    dgvPagos.Rows.RemoveAt(i)
                    GoTo empezar
                End If
            Next

            SeleccionarPago(dgvPagos)

            CalcularDescuento()
            entro2 = True
            txtdias.Enabled = False
            horas.Enabled = False
            txtRecargo.Enabled = False
            txtObservaciones.Enabled = False
            txtEfectivo.Enabled = False
            cbabono.Enabled = False
            cbPagado.Enabled = False
            dtpFechaEmision.Enabled = False
            dtpFechaPago.Enabled = False
            NDEI.Enabled = False
            cbPP.Enabled = True

            If txtSaldoAnt.Text < 0 Then
                txtSaldoAnt.Text = 0
            End If
            VerificarmesesMora()
        Catch
        End Try

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        llenaGridFact("select  * from vistapagos where (codigomunicipio='1603' or codigomunicipio='1615' or codigomunicipio='1622' or codigomunicipio='1614') and nodei<>0")

    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
        Excel(dgvFacturas)
    End Sub

    Private Sub dgvPagos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvPagos.MouseDoubleClick
        EditarRegistro()
        'txtEfectivo.Text = txtTotalPagar.Text
        If txtEfectivo.Text > 0 Then

            cbPagado.Checked = True

        End If
    End Sub

    Private Sub txtlimite_TextChanged(sender As Object, e As EventArgs) Handles txtlimite.TextChanged
        If dgvPagos.Rows.Count > 0 Then
            llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "'  ORDER BY No DESC limit " & txtlimite.Text & "")
        End If
        VerificarmesesMora2()
    End Sub

    Private Sub cbMostrarTodo_CheckedChanged(sender As Object, e As EventArgs)
        MostrarDeudores()
        If cbMostrarTodo.Checked = False Then
            MsgBox("Seleccione la comunidad de donde desea montrar deudores")
        End If
    End Sub

    Private Sub btnCopiar2_Click(sender As Object, e As EventArgs) Handles btnCopiar2.Click
        Try
            Using mensaje As New TextBox
                mensaje.Text = ""
                If cmbNombreComunidad.Text.Contains("EL OCOTE, SAN PEDRO ZACAPA") Or cmbNombreComunidad.Text.Contains("AGUA CALIENTE, SAN PEDRO ZACAPA") Or cmbNombreComunidad.Text.Contains("AGUA ZARCA, SAN PEDRO ZACAPA") Or cmbNombreComunidad.Text.Contains("EL TABLON, SAN PEDRO ZACAPA") Or cmbNombreComunidad.Text.Contains("SAN PEDRO ZACAPA") Then
                    '                
                    mensaje.Text = cmbMensaje2.Text & " ESTIMADO(A) " & dgvDeben.Item(5, dgvDeben.CurrentRow.Index).Value & " SU SALDO POR SERVICIO DE INTERNET ES DE *" & dgvDeben.Item(dgvDeben.Columns("saldo2").Index, dgvDeben.CurrentRow.Index).Value & "LPS(" & dgvDeben.Item(dgvDeben.Columns("meses3").Index, dgvDeben.CurrentRow.Index).Value & ")*, PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS : 
                -CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                Else

                    If txtDireccion.Text.Contains("ATIMA") Or txtDireccion.Text.Contains("SAN NICOLAS") Or txtDireccion.Text.Contains("NUEVO CELILAC") Or txtDireccion.Text.Contains("NARANJITOS") Or txtDireccion.Text.Contains("NARANJITO") Then
                        mensaje.Text = cmbMensaje2.Text & " ESTIMADO(A) " & dgvDeben.Item(5, dgvDeben.CurrentRow.Index).Value & " SU SALDO POR SERVICIO DE INTERNET ES DE *" & dgvDeben.Item(dgvDeben.Columns("saldo2").Index, dgvDeben.CurrentRow.Index).Value & "LPS(" & dgvDeben.Item(dgvDeben.Columns("meses3").Index, dgvDeben.CurrentRow.Index).Value & ")*, PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS: 
                -CTA. ATLANTIDA 13200450677 A LEYLA GISELA VASQUEZ ENAMORADO ENAMORADO
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 98817013 A NOMBRE DE ELSY MAHELY REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                    Else
                        mensaje.Text = cmbMensaje2.Text & " ESTIMADO(A) " & dgvDeben.Item(5, dgvDeben.CurrentRow.Index).Value & " SU SALDO POR SERVICIO DE INTERNET ES DE *" & dgvDeben.Item(dgvDeben.Columns("saldo2").Index, dgvDeben.CurrentRow.Index).Value & "LPS(" & dgvDeben.Item(dgvDeben.Columns("meses3").Index, dgvDeben.CurrentRow.Index).Value & ")*, PUEDE REALIZAR SU PAGO MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS : 
                -CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                    End If
                End If
                Clipboard.SetDataObject(mensaje.Text, True)
            End Using
        Catch
        End Try
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        tablatemp = ConsultarRegistro("Select idCliente from controlpago where No=" & NPago.Text & " idCliente = '" & Id.Text & "'")
        If tablatemp.Count = 0 Then
            adaptador = New MySqlDataAdapter("update controlpago set No=" & NPago.Text & " where idCliente='" & Id.Text & "' AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "controlpago")


            data.Clear()
            llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "' and activo=1  ORDER BY No DESC limit " & txtlimite.Text & "")

        Else
            MsgBox("Ya existe ese número de pago")
        End If
    End Sub

    Private Sub Id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Id.KeyPress
        llenaGrid("Select * from vistapagos where idCliente = '" & Id.Text & "'  ORDER BY No DESC limit " & txtlimite.Text & "")
        If filaspagos > 0 Then
            SeleccionarPago4()
        End If
    End Sub


    Sub Excel2(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\CLIENTES.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        'For i As Integer = 1 To NCol

        '    If ElGrid.Columns(i - 1).Visible = True Then
        '        exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
        '        'exHoja.Cells.Item(1, l).HorizontalAlignment = 3
        '        columnaEx = columnaEx + 1
        '    End If

        'Next
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 7
        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 14) = dtpFecha1.Value
        exHoja.Cells.Item(6, 15) = dgvFacturas.Item(11, 0).Value

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Sub Excel(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\VENTAS.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        'For i As Integer = 1 To NCol

        '    If ElGrid.Columns(i - 1).Visible = True Then
        '        exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
        '        'exHoja.Cells.Item(1, l).HorizontalAlignment = 3
        '        columnaEx = columnaEx + 1
        '    End If

        'Next
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 7
        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 14) = dtpFecha1.Value
        exHoja.Cells.Item(6, 15) = dgvFacturas.Item(11, 0).Value

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Sub ExcelInstalados(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\Instalados.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        'For i As Integer = 1 To NCol

        '    If ElGrid.Columns(i - 1).Visible = True Then
        '        exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
        '        'exHoja.Cells.Item(1, l).HorizontalAlignment = 3
        '        columnaEx = columnaEx + 1
        '    End If

        'Next
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 7
        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 14) = dtpFecha1.Value
        exHoja.Cells.Item(6, 15) = dgvFacturas.Item(11, 0).Value

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub

    Sub ExcelHISTORIAL(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\HISTORIAL.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        'For i As Integer = 1 To NCol

        '    If ElGrid.Columns(i - 1).Visible = True Then
        '        exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
        '        'exHoja.Cells.Item(1, l).HorizontalAlignment = 3
        '        columnaEx = columnaEx + 1
        '    End If

        'Next
        Dim row As Integer = 0
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 7
        For Fila As Integer = 0 To NRow - 1
            If row = 0 Then
                'exHoja.Cells.Item(filaexcel + 2, columnaEx + 1).Interior.Color = RGB(154, 65, 43)
                'exHoja.Rows.Item(filaexcel + 2).Interior.Color = RGB(91, 167, 246)
            End If

            row = row + 1
            If row = 4 Then
                row = 0
            End If

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value




terminar:
                    columnaEx = columnaEx + 1


                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 14) = dtpFecha1.Value
        exHoja.Cells.Item(6, 15) = dgvFacturas.Item(11, 0).Value

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Sub ExcelHISTORIAL2(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\HISTORIAL2.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        'For i As Integer = 1 To NCol

        '    If ElGrid.Columns(i - 1).Visible = True Then
        '        exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
        '        'exHoja.Cells.Item(1, l).HorizontalAlignment = 3
        '        columnaEx = columnaEx + 1
        '    End If

        'Next
        Dim row As Integer = 0
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 7
        For Fila As Integer = 0 To NRow - 1
            If row = 0 Then
                'exHoja.Cells.Item(filaexcel + 2, columnaEx + 1).Interior.Color = RGB(154, 65, 43)
                exHoja.Rows.Item(filaexcel + 2).Interior.Color = RGB(91, 167, 246)
            End If

            row = row + 1
            If row = 4 Then
                row = 0
            End If

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value




terminar:
                    columnaEx = columnaEx + 1


                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 14) = dtpFecha1.Value
        exHoja.Cells.Item(6, 15) = dgvFacturas.Item(11, 0).Value

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Sub VerificarGridInstalaciones(consulta)
        MostrarUsuario()
        'VerificarMesActual()


        'llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & "  order by NoCorrelativo", dgvclientes)

        '    llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & "  order by  NoCorrelativo limit " & txtlimite2.Text & " ", dgvclientes)

        'End If
        '    ElseIf cbTodosInstalaciones.Checked = False Then


        llenaGridCliente(consulta, dgvclientes)


        'End If

    End Sub
    Sub TotalMensual()
        Dim total As Integer
        total = 0
        For i As Integer = 0 To dgvclientes.Rows.Count - 1

            total = total + dgvclientes.Item(6, i).Value
            lbTotalMensual.Text = "Total Mensual: " & total
        Next
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs)

        For i As Integer = 0 To dgvDeben.Rows.Count - 1
            If dgvDeben.Rows.Item(i).Selected = True Then
                ConsultarRegistro("update clientes set usuario='" & cmbUsuario.Text & "' where idcliente='" & dgvDeben.Item(4, i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")
        MostrarDeudores()
    End Sub

    Private Sub dgvDeben_DoubleClick(sender As Object, e As EventArgs) Handles dgvDeben.DoubleClick
        SeleccionarPago(dgvDeben)
        ResultadoBusqueda()
        VerificarmesesMora2()
        llenaGridClientes("Select * from vistaclientes where idcliente like '" & Id.Text & "' ")

        llenaGridInstalacion("Select * from fichainstalacionservicio where idcliente = '" & Id.Text & "' ")

        SeleccionarClienteInstalacion()

    End Sub
    Sub MostrarUsuario()
        Select Case cmbUsuario.SelectedIndex
            Case 0
                usuarioActual = ""
            Case 1
                usuarioActual = "and (usuario='" & cmbUsuario.Items.Item(1).ToString & "' or usuario='" & cmbUsuario.Items.Item(2).ToString & "')"
            Case 2
                usuarioActual = "and usuario='" & cmbUsuario.Text & "'"
            Case 3
                usuarioActual = "and usuario='" & cmbUsuario.Text & "'"
            Case 4
                usuarioActual = "and usuario='" & cmbUsuario.Text & "'"
            Case 5
                usuarioActual = "and usuario='" & cmbUsuario.Text & "'"
        End Select
    End Sub
    Sub MostrarUsuarioNavegacion()
        Select Case cmbmostrarUsuario.SelectedIndex
            Case 0
                usuarioActual = ""
            Case 1
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
            Case 2
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
            Case 3
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
            Case 4
                usuarioActual = "and (usuario='" & cmbmostrarUsuario.Items.Item(1).ToString & "' or usuario='" & cmbmostrarUsuario.Items.Item(2).ToString & "')"
            Case 5
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
        End Select
    End Sub
    'Sub VerificarMesActual()
    '    Try
    '        If cmbMesActual.Checked = True Then
    '            cbMostrarTodo.Checked = False
    '            mesActual = "and meses='" & cmbmes2.Text.Substring(3) & "'"
    '        ElseIf cmbMesActual.Checked = False Then
    '            mesActual = ""
    '        End If
    '    Catch
    '    End Try

    'End Sub
    Private Sub cmbMesActual_CheckedChanged(sender As Object, e As EventArgs)
        'VerificarMesActual()
        'cbdebenvariosmeses.Checked = False
    End Sub

    Private Sub dgvFacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturas.CellContentClick
        dgvFacturas.Item("cbselec", dgvFacturas.CurrentRow.Index).Value = True
    End Sub


    Private Sub btnInforme_Click(sender As Object, e As EventArgs) Handles btnInforme.Click
        ExcelInstalados(dgvclientes)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        llenaGridFact("select * from vistacontador where nodei<>0 and isv=1 and FechaEmision between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' order by  nodei")

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Using mensaje As New TextBox
            mensaje.Text = ""
            If txtDireccion.Text.Contains("EL OCOTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA CALIENTE, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("AGUA ZARCA, SAN PEDRO ZACAPA") Or txtDireccion.Text.Contains("EL TABLON, SAN PEDRO ZACAPA") Then
                mensaje.Text = cmbMensaje2.Text & " ESTIMADO(A) " & dgvDeben.Item(9, dgvDeben.CurrentRow.Index).Value & " LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET FAVOR DEPOSITAR A: 
-CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
            Else
                If txtDireccion.Text.Contains("ATIMA") Or txtDireccion.Text.Contains("SAN NICOLAS") Or txtDireccion.Text.Contains("NUEVO CELILAC") Or txtDireccion.Text.Contains("NARANJITOS") Or txtDireccion.Text.Contains("NARANJITO") Then
                    mensaje.Text = cmbMensaje2.Text & " LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET MEDIANTE DEPOSITO A LAS SIGUIENTES CUENTAS: 
                -CTA. ATLANTIDA 13200450677 A LEYLA GISELA VASQUEZ ENAMORADO ENAMORADO
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 98817013 A NOMBRE DE ELSY MAHELY REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                Else

                    mensaje.Text = cmbMensaje2.Text & " LE RECORDAMOS REALIZAR SU PAGO POR SERVICIO DE INTERNET FAVOR DEPOSITAR A: 
-CTA. ATLANTIDA 130120088773 A NOMBRE DE INVERSIONES TECNOLOGICAS REYES REYES ASOCIADOS S. DE R.L.
                -CTA BANRURAL 01401010307363  A NOMBRE DE EDDIN NAHUM REYES REYES                 
                -CTA FICOHSA 200008317387 A NOMBRE DE EDDIN NAHUM REYES REYES
                -CTA OCCIDENTE 216010447988 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO
                -CTA BAC CREDOMATIC 741443251 A NOMBRE DE EDDIN NAHUM REYES REYES
                -TIGO MONEY 99451496 A NOMBRE DE LEYLA GISELA VASQUEZ ENAMORADO Ó 96695968 A NOMBRE DE EDDIN NAHUM REYES  
                 FAVOR ENVIAR FOTO DEL COMPROBANTE DE PAGO A ESTE NÚMERO"
                End If
            End If
            Clipboard.SetDataObject(mensaje.Text, True)
        End Using
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If dgvDeben.Rows.Count > 0 Then
                If dgvDeben.Item(dgvDeben.Columns("saldo2").Index, dgvDeben.CurrentRow.Index).Value > dgvDeben.Item(dgvDeben.Columns("mensu").Index, dgvDeben.CurrentRow.Index).Value Then
                    Clipboard.SetDataObject(cmbMensaje2.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET Ó DEME UNA FECHA DE COMPROMISO DE PAGO  POR FAVOR", True)
                Else
                    Clipboard.SetDataObject(cmbMensaje2.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET POR FAVOR", True)

                End If
            Else
                Clipboard.SetDataObject(cmbMensaje2.Text & ",ENVÍEME SU COMPROBANTE DE PAGO POR SERVICIO DE INTERNET POR FAVOR", True)

            End If



        Catch
        End Try
    End Sub

    Private Sub cbdebenvariosmeses_CheckedChanged(sender As Object, e As EventArgs)
        'VariosMesesDeuda()
    End Sub

    Private Sub btnBuscarInstalaciones_Click(sender As Object, e As EventArgs) Handles btnBuscarInstalaciones.Click
        llenaGridCliente("Select * from fichainstalacionserviciovista where Tipo='INSTALACION' AND day(FechaInstalacion)>= " & dtpInstaladosDespues.Value.Day & " and  MONTH(FechaInstalacion)>= " & Month(dtpInstaladosDespues.Value) & " and year(FechaInstalacion)>= " & Year(dtpInstaladosDespues.Value) & "  and activo=1 and activo1=1 " & usuarioActual & "  order by usuario, NombreMunicipio, nombreComunidad, nombre", dgvclientes)


    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        MostrarUsuario()
        If cbMostrarTodo.Checked = True Then
            If cbFechaPP.Checked = False Then
                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' and meses ='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is not Null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
            Else
                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' and meses ='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=2 and activo=1 and Saldo>0 and FechaPP is Null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

            End If

        Else
            If cbFechaPP.Checked = False Then


                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' and meses ='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 And nombredepartamento ='" & cmbNombreDepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' and FechaPP is not Null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
            Else
                llenaGrid2("Select * from vistapagos where totalpagar>0 and mes like '%" & cmbmes2.Text & "%' and meses ='" & cmbmes2.Text & "' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 And nombredepartamento ='" & cmbNombreDepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' and FechaPP is  Null order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)

            End If
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        MostrarUsuario()
        If cmbmes2.Text <> "" And cmbaño2.Text <> "" Then
            llenaGrid2("Select * from VistaPagos2  where  totalpagar>0 and mes like '%" & cmbmes2.Items.Item(cmbmes2.SelectedIndex - 1).ToString & "%' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=1 and activo=1 and Saldo>0 and  MONTH(FechaPagado)= " & cmbmes2.SelectedIndex & "  order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
        Else
            MsgBox("Elija el mes y año", "Atención")
        End If
    End Sub

    Private Sub btnin_Click(sender As Object, e As EventArgs) Handles btnin.Click
        tablatemp = ConsultarRegistro("Select idCliente from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & "' limit 1")
        Dim s As String
        s = "Select * from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & ""
        If tablatemp.Count > 0 Then
            Dim estado As Integer
            If rbin.Checked Then
                estado = 2
            Else
                estado = 1
            End If
            If txtrazonCorte.Text <> "" Then
                Dim Fecha4 As String = dtpInab.Value.ToString("yyyy-MM-dd")
                'Dim Fecha5 As String = dtpHab.Value.ToString("yyyy-MM-dd")
                'Consulta = "update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "', detallepago='" & detallepago & "', cambio=" & cambio & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & " WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & ""
                adaptador = New MySqlDataAdapter("update controlpago set  estado=" & estado & ", fechahab=NULL, fechain='" & Fecha4 & "', razonCorte='" & txtrazonCorte.Text.ToUpper & "' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
#Enable Warning BC42104 ' Se usa la variable antes de que se le haya asignado un valor
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "controlpago")
                data.Clear()

                adaptador = New MySqlDataAdapter("update clientes set  estadocliente=" & estado & ", fechahab=NULL, fechain='" & Fecha4 & "'  WHERE idCliente='" & Id.Text & "' ", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                data.Clear()
                llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
                'InsertarBitacora("SE INHABILITO TEMPORALMENTE A " & dgvPagos.Item(1, 0).Value & "    DE " & txtDireccion.Text & "")
                Dim dias As Integer
                Try
                    dias = DateDiff(DateInterval.Day, dtpInab.Value, System.Convert.ToDateTime("30/" & dtpInab.Value.Month & "/" & dtpInab.Value.Year))
                Catch
                End Try
                txtdias.Text = dias
            Else
                MessageBox.Show("Ingrese la razón por la que se va inhabilitar el cliente")
                txtrazonCorte.Focus()
                InsertarBitacora("SE INHABILITO A " & dgvPagos.Item(5, 0).Value & "    DE " & txtDireccion.Text & "")
            End If
        End If
    End Sub

    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

    Sub actualizarPromesaPago()
        tablatemp = ConsultarRegistro("Select idCliente from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & "' limit 1")
        Dim s As String
        s = "Select * from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & ""
        If tablatemp.Count > 0 Then

            Dim Fecha6 As String = dtpPP.Value.ToString("yyyy-MM-dd")

            'Consulta = "update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "', detallepago='" & detallepago & "', cambio=" & cambio & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & " WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & ""
            adaptador = New MySqlDataAdapter("update controlpago set   fechapp='" & Fecha6 & "' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "controlpago")
            data.Clear()
            llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
        End If
    End Sub

    Private Sub btnHab_Click(sender As Object, e As EventArgs) Handles btnHab.Click
        tablatemp = ConsultarRegistro("Select idCliente from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & "' limit 1")
        Dim s As String
        s = "Select * from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & ""
        If tablatemp.Count > 0 Then
            Dim estado As Integer
            If rbin.Checked Then
                estado = 2
            ElseIf rbhab.Checked Then
                estado = 1
            End If
            Dim Fecha4 As String = dtpInab.Value.ToString("yyyy-MM-dd")
            Dim Fecha5 As String = dtpHab.Value.ToString("yyyy-MM-dd")
            txtdias.Text = DateDiff(DateInterval.Day, dtpInab.Value, dtpHab.Value)
            'Consulta = "update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "', detallepago='" & detallepago & "', cambio=" & cambio & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & " WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & ""
            adaptador = New MySqlDataAdapter("update controlpago set  estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "controlpago")
            data.Clear()


            adaptador = New MySqlDataAdapter("update clientes set  estadocliente=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "' WHERE idCliente='" & Id.Text & "' ", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "clientes")
            data.Clear()
            llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
            InsertarBitacora("SE HABILITO A " & dgvPagos.Item(5, 0).Value & "    DE " & txtDireccion.Text & "")

        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        Try
            Id.Text = dgvFacturas.Item(9, dgvFacturas.CurrentRow.Index).Value
            Nombre.Text = dgvFacturas.Item(4, dgvFacturas.CurrentRow.Index).Value
            llenaGrid("Select * from vistapagos where idCliente ='" & dgvFacturas.Item(9, dgvFacturas.CurrentRow.Index).Value & "'    ORDER BY No DESC limit " & txtlimite.Text & "")

            'Id.Text = dgvPagos.Item(9, dgvPagos.Rows.Count - 1).Value
            'SeleccionarPago4()
            'lbClientes.Visible = False
            btnNuevoPago_Click(btnNuevoPago, e)
        Catch
        End Try

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
        'Excel2(dgvClientesActivos)
    End Sub



    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        actualizarPromesaPago()
    End Sub

    Private Sub btnActUsu_Click(sender As Object, e As EventArgs) Handles btnActUsu.Click
        adaptador = New MySqlDataAdapter("update clientes set usuario='" & cmbUsuarioPago.Text & "' where idCliente='" & Id.Text & "'", conexion)
        oCommBuild = New MySqlCommandBuilder(adaptador)
        adaptador.Fill(data, "clientes")
        MsgBox("Registro actualizado exitosamente")
        data.Clear()
        llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "' and activo=1  ORDER BY No DESC limit " & txtlimite.Text & "")
    End Sub


    Private Sub dgvclientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvclientes.CellContentClick
        dgvclientes.Item("cbselec2", dgvclientes.CurrentRow.Index).Value = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        For i = 0 To dgvclientes.RowCount - 1
            If dgvclientes.Item("cbselec2", i).Value = True Then

                ConsultarRegistro("update fichaintalacionservicio set ip='" & dgvclientes.Item(8, i).Value & "', servidor='" & dgvclientes.Item(9, i).Value & "' where idcliente='" & dgvclientes.Item(1, i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")

    End Sub


    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        ExcelHISTORIAL(dgvPagos2)
    End Sub

    Private Sub dgvPagos2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPagos2.CellContentClick

    End Sub

    Private Sub cmbusuario2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbusuario2.SelectedIndexChanged

    End Sub

    Private Sub Pagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMenu.cortados()
        frmMenu.desconexiones()
        frmMenu.bitacora()
        frmMenu.Promesa()
    End Sub

    Private Sub dgvFacturas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturas.CellEndEdit
        dgvFacturas.Item("cbselec", dgvFacturas.CurrentRow.Index).Value = True
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        respuesta = MsgBox("Desea actualizar el numero telefónico a los clientes seleccionados?   ?", MsgBoxStyle.YesNo, "Atención?")
        If respuesta = 6 Then
            For i = 0 To dgvclientes.RowCount - 1
                If dgvclientes.Item("cbselec2", i).Value = True Then

                    ConsultarRegistro("update clientes set telefono='" & dgvclientes.Item(25, i).Value & "' where idcliente='" & dgvclientes.Item(1, i).Value & "'")
                End If
            Next
        End If
        MsgBox("Registros actualizados")
        ActualizarInstalados()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        dgvClientesNuevos.Rows.Clear()
        Limpiar2()
        'llenaGridClientes("Select * from vistaclientes where activo=1 DESC limit 5")
        txtIdentidad.Focus()
    End Sub

#Region "EVENTOS KEY"

    Private Sub clientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
    End Sub

    Private Sub Correo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCorreo.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbNombreDepartamento1.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
    End Sub


    Private Sub Nuevo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnNuevo.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnNuevo_Click(btnNuevo, e)
        End If
    End Sub

    Private Sub btnReporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnReporte.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnNuevo_Click(btnNuevo, e)
        End If
    End Sub

    Private Sub Guardar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnGuardar.KeyDown
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnNuevo_Click(btnNuevo, e)
        End If

    End Sub

    Private Sub Id_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdentidad.KeyDown
        'Codigo para ubicarse en el siguiente cuadro de texto al presionar enter
        Try
            If e.KeyCode = Keys.Enter Then
                txtNombre.Focus()
            End If
            If e.KeyCode = Keys.F2 Then
                Guardar_Click(btnGuardar, e)
            End If
            If e.KeyCode = Keys.F3 Then
                Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
                Me.Close()
            End If
        Catch
        End Try
    End Sub
    Private Sub Nombre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        Try
            'Codigo para ubicarse en el siguiente cuadro de texto al presionar enter
            If e.KeyCode = Keys.Enter Then
                txtTelefono.Focus()
            End If
            If e.KeyCode = Keys.F2 Then
                Guardar_Click(btnGuardar, e)
            End If
            If e.KeyCode = Keys.F3 Then
                Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
                Me.Close()
            End If
        Catch
        End Try
    End Sub



    Private Sub Telefono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
        Try
            'Codigo para ubicarse en el siguiente cuadro de texto al presionar enter
            If e.KeyCode = Keys.Enter Then
                txtCorreo.Focus()
            End If
            If e.KeyCode = Keys.F2 Then
                Guardar_Click(btnGuardar, e)
            End If

        Catch
        End Try
    End Sub



    Private Sub Direccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Codigo para ubicarse en el siguiente cuadro de texto al presionar enter
        If e.KeyCode = Keys.Enter Then
            txtCorreo.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        If e.KeyCode = Keys.F3 Then
            Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
            Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
            Me.Close()
        End If
    End Sub
    Private Sub Eliminar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnEliminar.KeyDown
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        If e.KeyCode = Keys.F3 Then
            Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
            Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
            Me.Close()
        End If
    End Sub

    Private Sub dgvclientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        If e.KeyCode = Keys.F3 Then

            Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
            Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
            Me.Close()
        End If
    End Sub


#End Region

    Private Sub BuscarDepartamento_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarDepartamento.Click
        departamento.ShowDialog()
        Llenardepartamento("Select * from departamento")
    End Sub

    Private Sub BuscarMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarMunicipio.Click
        municipios.ShowDialog()
        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")

    End Sub

    Private Sub BuscarComunidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarComunidad.Click
        comunidades.ShowDialog()
        Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " AND Codigomunicipio<>0")

    End Sub


    Private Sub cmbNombremunicipio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNombreMunicipio1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbNombreComunidad1.Focus()
        End If
        If e.KeyCode = Keys.F4 Then
            btnReporte_Click(btnReporte, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Guardar_Click(btnGuardar, e)
        End If
        'If e.KeyCode = Keys.B Then
        '    Id.Focus()
        'End If
        If e.KeyCode = Keys.F3 Then
            btnNuevo_Click(btnNuevo, e)
        End If

    End Sub


    Private Sub Id_KeyUp(sender As Object, e As KeyEventArgs) Handles txtIdentidad.KeyUp
        llenaGridClientes("Select * from vistaclientes where idCliente = '" & txtIdentidad.Text & "'")
    End Sub

    Private Sub Nombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyUp
        llenaGridClientes("Select * from vistaclientes where nombre like '%" & txtNombre.Text & "%' ")
    End Sub


    Private Sub cbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles cbActivoHabilitado.CheckedChanged
        If cbActivoHabilitado.Checked = True And conexion2 = True Then
            llenaGridClientes("Select * from vistaclientes where activo =1 DESC limit " & txtNoRegistros2.Text & "")
        ElseIf cbActivoHabilitado.Checked = False And conexion2 = True Then
            llenaGridClientes("Select * from vistaclientes")
        End If
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
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
                    If txtDireccionIP.Text = "" Then
                        ErrorProvider1.SetError(txtDireccionIP, "Ingrese la IP")
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

                    adaptador = New MySqlDataAdapter("update fichaintalacionservicio set idCliente='" & Id.Text.ToUpper & "', FechaInstalacion='" & fechaCalculada.Value.ToString("yyyy-MM-dd") & "', Velocidad=" & txtVelocidad.Text & ", Mensualidad='" & Mensualidad.Text & "', Mac='" & DirMAC.Text.ToUpper & "', ip='" & txtDireccionIP.Text.ToUpper & "', tipo='" & Tipo.Text.ToUpper & "', InstaladoPor='" & instalado.Text.ToUpper & "', Equipo='" & Equipo.Text.ToUpper & "', unidades='" & txtUnidades.Text & "', moneda='" & txtMoneda.Text & "', tipoPlan='" & txtTipoPlan.Text & "', activo1=" & activo & ", FechaInstalado='" & dtpFechaInstalacion.Value.ToString("yyyy-MM-dd") & "', macrouter = '" & txtMacRouter.Text & "', marcarouter = '" & txtMarcaRouter.Text & "', servidor='" & txtServidor.Text & "' where idCliente='" & Id.Text & "' and NoCorrelativo=" & txtFicha.Text & "", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "fichaintalacionservicio")

                    InsertarBitacora("SE ACTUALIZÓ FICHA DE INSTALACIÓN A  " & Nombre.Text & ", TIPO " & Tipo.Text & "  PLAN " & txtVelocidad.Text & " " & txtUnidades.Text & " FECHA " & dtpFechaInstalacion.Value & "")

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
                    If txtDireccionIP.Text = "" Then
                        ErrorProvider1.SetError(txtDireccionIP, "Ingrese la IP")
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
                    agregar("ip") = Me.txtDireccionIP.Text.ToUpper.ToUpper
                    agregar("Mensualidad") = Me.Mensualidad.Text
                    agregar("fechainstalacion") = Me.fechaCalculada.Value.ToString("yyyy-MM-dd")
                    agregar("Instaladopor") = Me.instalado.Text.ToUpper
                    agregar("Equipo") = Me.Equipo.Text.ToUpper
                    agregar("NoCorrelativo") = Me.txtFicha.Text.ToUpper
                    agregar("unidades") = Me.txtUnidades.Text.ToUpper
                    agregar("moneda") = Me.txtMoneda.Text.ToUpper
                    agregar("TipoPlan") = Me.txtTipoPlan.Text.ToUpper

                    agregar("activo1") = 1
                    agregar("router") = Router2
                    agregar("servidor") = txtServidor.Text
                    agregar("macrouter") = txtMacRouter.Text
                    agregar("marcarouter") = txtMarcaRouter.Text
                    agregar("fechaInstalado") = Me.dtpFechaInstalacion.Value.ToString("yyyy-MM-dd")

                    Me.data.Tables("fichaintalacionservicio").Rows.Add(agregar)
                    Me.adaptador.Update(data, "fichaintalacionservicio")
                    InsertarBitacora("SE AGREGO FICHA DE INSTALACIÓN A  " & Nombre.Text & ", TIPO " & Tipo.Text & "  PLAN " & txtVelocidad.Text & " " & txtUnidades.Text & " FECHA " & dtpFechaInstalacion.Value & "")

                    MsgBox("Datos agregados")
                    data.Clear()

                    llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente ='" & Id.Text & "'")
                    TabClientes.SelectedIndex = 2
                    btnNuevoPago_Click(btnNuevoPago, e)

                    InstalacionAgregada(e)
                End If
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        LimpiarInstalacion()
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where activo1=1 order by NoCorrelativo desc limit " & txtlimiteIns.Text & "")

    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
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
                        InsertarBitacora("SE ELIMINO FICHA DE INSTALACIÓN A  " & Nombre.Text & " NUMERO " & txtFicha.Text & "  PLAN " & txtVelocidad.Text & " " & txtUnidades.Text & " FECHA INSTALACION " & dtpFechaInstalacion.Value & "")

                        MsgBox("Datos eliminados")
                        Nuevo_Click(Nuevo, e)
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

    Private Sub Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo.SelectedIndexChanged
        txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo desc limit 1", "NoCorrelativo")

    End Sub

    Private Sub dgvClientesNuevos_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientesNuevos.CellClick
        Try

            txtMensualidad.Text = 0
            txtMens.Text = 0
            entro2 = True

            txtIdentidad.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtNombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            lbIdentidad.Text = "Id: " + Id.Text
            lbNombre.Text = "Nombre: " + Nombre.Text
            txtTelefono.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtTelefonoCliente.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtCorreo.Text = dgvClientesNuevos.Item(6, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtDireccionExacta.Text = dgvClientesNuevos.Item(9, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtDireccion.Text = dgvClientesNuevos.Item(9, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            Numero.Text = dgvClientesNuevos.Item(10, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtUbicacion.Text = dgvClientesNuevos.Item(12, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            If dgvClientesNuevos.Item(7, dgvClientesNuevos.CurrentRow.Index).Value = "Si" Then
                cbActivoSistema.Checked = True
            Else
                cbActivoSistema.Checked = False
            End If

            If dgvClientesNuevos.Item(8, dgvClientesNuevos.CurrentRow.Index).Value = 1 Then
                cbSar.Checked = True
            Else
                cbSar.Checked = False
            End If
            identidad = txtIdentidad.Text

            Dim indice As Integer
            indice = dgvClientesNuevos.CurrentRow.Index
            For i As Integer = 0 To cmbCodigoDepartamento1.Items.Count - 1

                If dgvClientesNuevos.Item(3, indice).Value.ToString = cmbNombreDepartamento1.Items.Item(i).ToString Then
                    cmbCodigoDepartamento1.SelectedIndex = i
                    GoTo salir
                End If
            Next
salir:
            Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")

            For i As Integer = 0 To cmbCodigoMunicipio1.Items.Count - 1
                If dgvClientesNuevos.Item(4, indice).Value.ToString = cmbNombreMunicipio1.Items.Item(i).ToString Then
                    cmbCodigoMunicipio1.SelectedIndex = i

                    GoTo salir2
                End If
            Next
salir2:
            Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " and Codigomunicipio<>0")

            For i As Integer = 0 To cmbCodigoComunidad1.Items.Count - 1

                If dgvClientesNuevos.Item(5, indice).Value.ToString = cmbNombreComunidad1.Items.Item(i).ToString Then
                    cmbNombreComunidad1.SelectedIndex = i
                    GoTo salir3
                End If
            Next
salir3:

            For i As Integer = 0 To cmbUsuarioCliente.Items.Count - 1
                cmbUsuarioCliente.SelectedIndex = i
                If dgvClientesNuevos.Item(11, indice).Value.ToString = cmbUsuarioCliente.Text.ToString Then
                    GoTo salir4
                End If
            Next
salir4:

            entro2 = False


            CargarPagos()

            If dgvInstalacion.RowCount = 0 Then
                LimpiarInstalacion()
                'Nuevo_Click(Nuevo, e)
            Else
                btnNuevoPago_Click(btnNuevoPago, e)
            End If
            'LimpiarInstalacion()

            Try

            Catch
            End Try
        Catch s As Exception
        End Try
    End Sub
    Sub InstalacionAgregada(e)

        Try
            SeleccionarCliente()

            TabClientes.SelectedIndex = 2
            Limpiar()
            txtNoFicha.Text = txtFicha.Text
            txtdias.Focus()
            If Id.Text <> "" Then
                ResultadoBusqueda()
                nuevo2()
            End If
            txtActivo.Text = instalacionactiva
            btnNuevoPago_Click(btnNuevoPago, e)
        Catch
        End Try
    End Sub

    Private Sub dgvInstalacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInstalacion.CellDoubleClick, dgvClientesNuevos.CellDoubleClick
        InstalacionAgregada(e)
    End Sub
    Sub SeleccionarClienteInstalacion()
        Try
            If dgvInstalacion.RowCount > 0 Then
                If Not Id.Text = dgvInstalacion.Item(0, 0).Value Then
                    Id.Text = dgvInstalacion.Item(0, 0).Value
                End If

                Nombre.Text = dgvInstalacion.Item(1, 0).Value
                For i As Integer = 0 To Tipo.Items.Count - 1
                    Tipo.SelectedIndex = i
                    If Tipo.Text.ToString.ToUpper = dgvInstalacion.Item(2, 0).Value.ToString Then
                        Tipo.SelectedIndex = i
                        GoTo salir1
                    End If

                Next
salir1:
                txtMensualidad.Text = dgvInstalacion.Item(5, 0).Value.ToString
                txtMens.Text = dgvInstalacion.Item(5, 0).Value.ToString
                Mensualidad.Text = dgvInstalacion.Item(5, 0).Value.ToString
                txtVelocidad.Text = dgvInstalacion.Item(4, 0).Value.ToString
                txtUnidades.Text = dgvInstalacion.Item(11, 0).Value.ToString
                txtMoneda.Text = dgvInstalacion.Item(12, 0).Value.ToString
                txtTipoPlan.Text = dgvInstalacion.Item(13, 0).Value.ToString

                Select Case dgvInstalacion.Item(14, 0).Value.ToString
                    Case "Si"
                        cbActivo.Checked = True
                    Case "No"
                        cbActivo.Checked = False
                End Select
                fechaCalculada.Text = dgvInstalacion.Item(3, 0).Value
                Equipo.Text = dgvInstalacion.Item(9, 0).Value
                txtDireccionIP.Text = dgvInstalacion.Item(7, 0).Value
                instalado.Text = dgvInstalacion.Item(8, 0).Value.ToString
                DirMAC.Text = dgvInstalacion.Item(6, 0).Value
                txtFicha.Text = dgvInstalacion.Item(10, 0).Value
                Try

                    Select Case dgvInstalacion.Item(15, 0).Value.ToString
                        Case "INTERRA"
                            rbRouterSi.Checked = True
                        Case "CLIENTE"
                            rbRouterNo.Checked = True
                    End Select

                    txtDireccion.Text = dgvInstalacion.Item(18, 0).Value
                    txtMacRouter.Text = dgvInstalacion.Item(16, 0).Value
                    txtMarcaRouter.Text = dgvInstalacion.Item(17, 0).Value
                    dtpFechaInstalacion.Text = dgvInstalacion.Item(19, 0).Value
                    ' txtCel.Text = dgvInstalacion.Item(20, 0).Value
                    txtServidor.Text = dgvInstalacion.Item(21, 0).Value
                Catch S As Exception
                End Try
            End If
        Catch S As Exception
        End Try
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles btnBuscarPlan.Click
        planes.ShowDialog()
    End Sub
    Private Sub dgvInstalacion_Click(sender As Object, e As EventArgs) Handles dgvInstalacion.Click
        SeleccionarCliente()
        llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "' ORDER BY No DESC limit " & txtlimite.Text & "")
        btnNuevoPago_Click(btnNuevoPago, e)
    End Sub
    Sub RecorrerBotonesBlack()
        ' Cambiar colores para el tema oscuro
        TabPageClientes.BackColor = Color.FromArgb(31, 31, 31)
        For Each control As Control In TabPageClientes.Controls
            If TypeOf control Is Label Then
                ' Puedes ajustar los colores de los labels
                Dim label As Label = DirectCast(control, Label)
                label.ForeColor = Color.White
            ElseIf TypeOf control Is Button Then
                ' Puedes ajustar los colores de los botones
                Dim button As Button = DirectCast(control, Button)
                button.BackColor = Color.FromArgb(45, 45, 48)
                button.ForeColor = Color.White
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)
            ElseIf TypeOf control Is TableLayoutPanel Then
                ' Puedes ajustar los colores de los botones
                Dim group As TableLayoutPanel = DirectCast(control, TableLayoutPanel)
                group.BackColor = Color.FromArgb(45, 45, 48)
                group.ForeColor = Color.White
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)
            ElseIf TypeOf control Is GroupBox Then
                ' Puedes ajustar los colores de los botones
                Dim group As GroupBox = DirectCast(control, GroupBox)
                group.ForeColor = Color.White
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)
            End If
        Next
    End Sub
    Sub RecorrerBotonesWhite()
        ' Cambiar colores para el tema oscuro

        TabPageClientes.BackColor = Color.WhiteSmoke
        For Each control As Control In TabPageClientes.Controls
            If TypeOf control Is Label Then
                ' Puedes ajustar los colores de los labels
                Dim label As Label = DirectCast(control, Label)
                label.ForeColor = Color.Black
            ElseIf TypeOf control Is Button Then
                ' Puedes ajustar los colores de los botones
                Dim button As Button = DirectCast(control, Button)
                button.BackColor = Color.WhiteSmoke
                button.ForeColor = Color.Black
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)
            ElseIf TypeOf control Is GroupBox Then
                ' Puedes ajustar los colores de los botones
                Dim group As GroupBox = DirectCast(control, GroupBox)

                group.ForeColor = Color.Black
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)
            ElseIf TypeOf control Is TableLayoutPanel Then
                ' Puedes ajustar los colores de los botones
                Dim group As TableLayoutPanel = DirectCast(control, TableLayoutPanel)
                group.BackColor = Color.WhiteSmoke
                group.ForeColor = Color.Black
                ' Añadir más controles según sea necesario (por ejemplo, TextBox, ComboBox, etc.)

            End If
        Next
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        If btnColor.BackColor = Color.Black Then
            btnColor.BackColor = Color.White
            RecorrerBotonesBlack()
            btnColor.ForeColor = Color.Black
        Else
            btnColor.BackColor = Color.Black
            btnColor.ForeColor = Color.White
            RecorrerBotonesWhite()

        End If
    End Sub



    Private Sub txtlimiteIns_KeyUp(sender As Object, e As KeyEventArgs) Handles txtlimiteIns.KeyUp
        llenaGridInstalacion("Select * from fichainstalacionserviciovista where activo1=1 order by NoCorrelativo desc limit " & txtlimiteIns.Text & "")

    End Sub

    Private Sub txtNoRegistros2_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNoRegistros2.KeyUp
        llenaGridClientes("Select * from vistaclientes  limit " & txtNoRegistros2.Text & "")
    End Sub


    Private Sub rbEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles rbEfectivo.CheckedChanged
        txtEfectivoEntregado.SelectedIndex = 0
    End Sub

    Sub SeleccionarCliente()
        Try
            If Not Id.Text = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value Then
                Id.Text = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value
            End If


            For i As Integer = 0 To Tipo.Items.Count - 1
                Tipo.SelectedIndex = i
                If Tipo.Text.ToString.ToUpper = dgvInstalacion.Item(2, dgvInstalacion.CurrentRow.Index).Value.ToString Then
                    Tipo.SelectedIndex = i
                    GoTo salir1
                End If

            Next
salir1:
            lbIdentidad.Text = "Id: " + Id.Text
            lbNombre.Text = "Nombre: " + Nombre.Text
            Nombre.Text = dgvInstalacion.Item(1, dgvInstalacion.CurrentRow.Index).Value.ToString
            Mensualidad.Text = dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtMensualidad.Text = dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtVelocidad.Text = dgvInstalacion.Item(4, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtUnidades.Text = dgvInstalacion.Item(11, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtMoneda.Text = dgvInstalacion.Item(12, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtTipoPlan.Text = dgvInstalacion.Item(13, dgvInstalacion.CurrentRow.Index).Value.ToString

            Select Case dgvInstalacion.Item(14, dgvInstalacion.CurrentRow.Index).Value.ToString
                Case "Si"
                    cbActivo.Checked = True
                Case "No"
                    cbActivo.Checked = False
            End Select
            fechaCalculada.Text = dgvInstalacion.Item(3, dgvInstalacion.CurrentRow.Index).Value
            dtpInstalacion.Value = fechaCalculada.Text
            Equipo.Text = dgvInstalacion.Item(9, dgvInstalacion.CurrentRow.Index).Value
            txtDireccionIP.Text = dgvInstalacion.Item(7, dgvInstalacion.CurrentRow.Index).Value
            instalado.Text = dgvInstalacion.Item(8, dgvInstalacion.CurrentRow.Index).Value.ToString
            txtTelefonoCliente.Text = dgvInstalacion.Item(20, dgvInstalacion.CurrentRow.Index).Value

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
                ' txtCel.Text = dgvInstalacion.Item(20, dgvInstalacion.CurrentRow.Index).Value
                txtServidor.Text = dgvInstalacion.Item(21, dgvInstalacion.CurrentRow.Index).Value
            Catch S As Exception
            End Try
        Catch S As Exception
        End Try
    End Sub

    Private Sub btnRetirado_Click(sender As Object, e As EventArgs) Handles btnRetirado.Click
        If cbEquipo.Checked Then
            Try
                respuesta = MsgBox("Confirme que se retiraron los equipos del cliente " & dgvPagos.Item(0, 0).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
                If respuesta = 6 Then
                    adaptador = New MySqlDataAdapter("update clientes set equiporetirado=1 where idCliente='" & Id.Text & "'", conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    MsgBox("Registro actualizado exitosamente")
                    data.Clear()
                    Dim Fecha6 As String = Fechabaja.Value.ToString("yyyy-MM-dd")

                    'InsertarBitacora("SE RETIRARON LOS EQUIPOS DE " & dgvPagos.Item(5, 0).Value & " DE " & txtDireccion.Text & "")
                    'MsgBox("Registro actualizado exitosamente")
                    data.Clear()


                End If
            Catch s As Exception
            End Try
        End If

        If cbEquipo.Checked = False Then
            Try
                respuesta = MsgBox("Confirme que NO retiraron los equipos del cliente " & dgvPagos.Item(0, 0).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
                If respuesta = 6 Then
                    adaptador = New MySqlDataAdapter("update clientes set equiporetirado=2 where idCliente='" & Id.Text & "'", conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    MsgBox("Registro actualizado exitosamente")
                    data.Clear()
                    Dim Fecha6 As String = Fechabaja.Value.ToString("yyyy-MM-dd")

                    'InsertarBitacora("SE RETIRARON LOS EQUIPOS DE " & dgvPagos.Item(5, 0).Value & " DE " & txtDireccion.Text & "")

                    'MsgBox("Registro actualizado exitosamente")
                    data.Clear()


                End If
            Catch s As Exception
            End Try
        End If
    End Sub


    Private Sub Pagos_MaximumSizeChanged(sender As Object, e As EventArgs) Handles MyBase.MaximumSizeChanged
        'CentrarControlEnFormulario(gbInstalacionDatos)
        Me.Width = 1200
        Me.Height = 700
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtIdentidad.Text = "" Then
                ErrorProvider1.SetError(txtIdentidad, "Ingrese el número de identidad")
                txtIdentidad.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            If txtNombre.Text = "" Then
                ErrorProvider1.SetError(txtNombre, "Ingrese el nombre del cliente")
                txtNombre.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

            If txtDireccionExacta.Text = "" Then
                ErrorProvider1.SetError(txtNombre, "Ingrese la direccion exacta")
                txtDireccionExacta.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

GUARDAR:
            respuesta2 = MsgBox("Desea agregar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta2 = 6 Then
                Dim s As String = "Select idcliente from vistaclientes where idCliente = '" & txtIdentidad.Text & "'"
                adaptador = New MySqlDataAdapter("Select * from vistaclientes where idCliente = '" & txtIdentidad.Text & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")

                If data.Tables("clientes").Rows.Count = 0 Then
                    Dim activo As Integer
                    If cbActivoSistema.Checked = True Then
                        activo = 1
                    Else
                        activo = 2
                    End If


                    If cbSar.Checked = True Then
                        ActivoD = 1
                    Else
                        ActivoD = 2
                    End If
                    Dim consulta As String = "Insert into clientes (idCliente, Nombre, telefono, correo, Codigodepartamento, Codigomunicipio, CodigoComunidad, Activo, DEI, Direccion, NoCorrelativo, usuario, ubicacion, estadocliente, fechain, fechahab, equiporetirado) values('" & txtIdentidad.Text & "','" & txtNombre.Text.ToUpper & "','" & txtTelefono.Text & "','" & txtCorreo.Text & "','" & cmbCodigoDepartamento1.Text & "', '" & cmbCodigoMunicipio1.Text & "', '" & cmbCodigoComunidad1.Text & "', '" & activo & "', '" & ActivoD & "', '" & txtDireccionExacta.Text.ToUpper & "', " & Numero.Text & ", '" & cmbUsuarioCliente.Text & "', '" & txtUbicacion.Text & "',1,null,null,2)"

                    adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    MsgBox("Registro agregado exitosamente")
                    TabClientes.SelectedTab = TabInstalaciones
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'btnNuevo_Click(btnNuevo, e)
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGridClientes("SELECT * FROM vistaclientes where idCliente='" & txtIdentidad.Text & "' ")
                    InsertarBitacora("SE AGREGO CLIENTE  " & txtNombre.Text & " DE " & cmbNombreMunicipio1.Text & " " & cmbNombreComunidad1.Text & "")
                    Id.Text = dgvClientesNuevos.Item(0, 0).Value.ToString
                    Nombre.Text = dgvClientesNuevos.Item(1, 0).Value.ToString
                    lbIdentidad.Text = "Id: " + Id.Text
                    lbNombre.Text = "Nombre: " + Nombre.Text

                    cargarInstalacion(e)
                    txtFicha.Text = incrementaCodigo("Select NoCorrelativo from fichaintalacionservicio order by NoCorrelativo", "NoCorrelativo")


                Else
                    Dim activo As Integer
                    If cbActivoSistema.Checked = True Then
                        activo = 1
                    Else
                        activo = 2
                    End If
                    If cbSar.Checked = True Then
                        ActivoD = 1
                    Else
                        ActivoD = 2
                    End If
                    Dim a As String = "update clientes set idCliente='" & txtIdentidad.Text & "', Nombre='" & txtNombre.Text & "', telefono='" & txtTelefono.Text & "', correo='" & txtCorreo.Text & "', Codigodepartamento=" & cmbCodigoDepartamento1.Text & ", Codigomunicipio=" & cmbCodigoMunicipio1.Text & ", CodigoComunidad='" & cmbCodigoComunidad1.Text & "', Activo='" & activo & "', DEI='" & ActivoD & "', Direccion='" & txtDireccionExacta.Text.ToUpper & "', No=" & Numero.Text & " where idCliente='" & identidad & "'"

                    adaptador = New MySqlDataAdapter("update clientes set idCliente='" & txtIdentidad.Text & "', Nombre='" & txtNombre.Text.ToUpper & "', telefono='" & txtTelefono.Text & "', correo='" & txtCorreo.Text & "', Codigodepartamento=" & cmbCodigoDepartamento1.Text & ", Codigomunicipio=" & cmbCodigoMunicipio1.Text & ", CodigoComunidad='" & cmbCodigoComunidad1.Text & "', Activo='" & activo & "', DEI='" & ActivoD & "', Direccion='" & txtDireccionExacta.Text.ToUpper & "', NoCorrelativo=" & Numero.Text & ", usuario='" & cmbUsuarioCliente.Text & "', ubicacion = '" & txtUbicacion.Text & "' where idCliente='" & identidad & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "Empleado")
                    InsertarBitacora("SE ACTUALIZÓ CLIENTE  " & txtNombre.Text & " DE " & cmbNombreMunicipio1.Text & " " & cmbNombreComunidad1.Text & "")

                    MsgBox("Registro actualizado exitosamente")
                    data.Clear()
                    llenaGridClientes("SELECT * FROM vistaclientes where idCliente='" & txtIdentidad.Text & "' ")

                    'Llama la funsion de limpiar
                    'Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado

                    txtIdentidad.Focus()
                    llenaGridInstalacion("Select * from fichainstalacionserviciovista where idCliente='" & txtIdentidad.Text & "'")
                    Id.Text = dgvClientesNuevos.Item(0, 0).Value.ToString
                    Nombre.Text = dgvClientesNuevos.Item(1, 0).Value.ToString
                    lbIdentidad.Text = "Id: " + Id.Text
                    lbNombre.Text = "Nombre: " + Nombre.Text
                End If
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try


salir:
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            respuesta2 = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta2 = 6 Then
                adaptador = New MySqlDataAdapter("Select * from vistaclientes where idCliente = '" & txtIdentidad.Text & "'", frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")

                If data.Tables("clientes").Rows.Count > 0 Then

                    adaptador = New MySqlDataAdapter("Delete from clientes where idCliente='" & txtIdentidad.Text & "'", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    InsertarBitacora("SE ELIMINÓ CLIENTE  " & txtNombre.Text & " DE " & cmbNombreMunicipio1.Text & " " & cmbNombreComunidad1.Text & "")

                    MsgBox("Registro eliminado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGridClientes("Select * from vistaclientes ")
                    txtIdentidad.Focus()
                End If
            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        respuesta = MsgBox("Desea agregar un mes a los clientes seleccionados?   ?", MsgBoxStyle.YesNo, "Atención?")
        If respuesta = 6 Then
            For i As Integer = 0 To dgvclientes.Rows.Count - 1
                If dgvclientes.Rows.Item(i).Selected = True Then
                    Id.Text = dgvclientes.Item(1, i).Value
                    Nombre.Text = dgvclientes.Item(2, i).Value
                    dgvPagos.RowCount = 1
                    llenaGrid("Select * from vistapagos where idCliente ='" & Id.Text & "'    ORDER BY No DESC limit 1")
                    SeleccionarParaMesAutomatico()

                    btnNuevoPago_Click(btnNuevoPago, e)
                    btnGuardarPago_Click(btnGuardarPago, e)
                End If
                'VerificarGridInstalaciones()
                'MostrarDeudores()
                'llenaGridClienteUltimoPago(dgvclientes)
            Next
            VerificarGridInstalaciones("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & " where codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad ")
            llenaGridClienteUltimoPago(dgvclientes)

            CargarInstalaciones()
        End If

    End Sub
    Private Sub txtServidor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServidor2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            llenaGridCliente("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & "  and servidor like '%" & txtServidor2.Text & "%' order by Velocidad ", dgvclientes)
            'End If
            TotalMensual()
        End If
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        If txtip.Text = "" Then
            MsgBox("Ingrese la ip")
            GoTo salir
        End If
        If txtServidor.Text = "" Then
            MsgBox("Ingrese la ip del servidor")
            GoTo salir
        End If
        ConsultarRegistro("update fichaintalacionservicio set ip='" & txtip.Text & "', servidor='" & txtServidor.Text & "' where idcliente='" & Id.Text & "'")
salir:
    End Sub
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        ExcelHISTORIAL2(dgvDeben)
    End Sub

    Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
        txtTotalPagos.Text = 0
        VerificarGridInstalaciones("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & " order by nombredepartamento, nombremunicipio, nombrecomunidad ")
        llenaGridClienteUltimoPago(dgvclientes)
        TotalMensual()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs)
        TotalMensual()
    End Sub

    Private Sub lbClientes2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbClientes2.MouseDoubleClick
        llenaGrid("Select * from vistapagos where idCliente ='" & LbClientesId2.Items.Item(lbClientes2.SelectedIndex).ToString & "'    ORDER BY No DESC limit " & txtlimite.Text & "")
        gbBusqueda.Visible = False
        Id.Text = dgvPagos.Item(4, dgvPagos.Rows.Count - 1).Value
        'SeleccionarPago4()
        lbClientes.Visible = False
        lbClientes2.Visible = False
        btnNuevoPago_Click(btnNuevoPago, e)
    End Sub

    Private Sub btnPagado_Click(sender As Object, e As EventArgs) Handles btnPagado.Click
        MostrarUsuario()
        If cbMostrarTodo.Checked = True Then
            llenaGrid2("Select * from vistapagos where efectivo>0 and mes like '%" & cmbmes2.Text & "%' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=1 and activo=1 and Saldo>0 order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
        Else
            llenaGrid2("Select * from vistapagos where efectivo>0 and mes like '%" & cmbmes2.Text & "%' " & usuarioActual & " and anio='" & cmbaño2.Text & "' and saldo>0 and pagado=1 and activo=1 and Saldo>0 And nombredepartamento ='" & cmbNombreDepartamento.Text & "' and nombremunicipio='" & cmbNombremunicipio.Text & "' and nombreComunidad='" & cmbNombreComunidad.Text & "' order by Nombredepartamento, NombreComunidad, Nombre", dgvDeben)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            SeleccionarCliente(dgvclientes)
            ResultadoBusqueda()
            VerificarmesesMora2()
            llenaGridClientes("Select * from vistaclientes where idcliente like '" & Id.Text & "' ")
            llenaGridInstalacion("Select * from fichainstalacionserviciovista where idcliente = '" & Id.Text & "' ")
            SeleccionarClienteInstalacion()
        Catch
        End Try
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        dgvPagos2.Rows.Clear()
        dgvPagos2.Rows.Add(dgvDeben.Rows.Count * 4)
        Dim npagos = dgvPagos2.Rows.Count - 1
        contadordeudores = 0
        For l = 0 To dgvDeben.Rows.Count - 1
            npagos = 0
            pb2.Maximum = dgvDeben.Rows.Count
            llenaGridDeudoresHistorial("Select * from vistapagos where idCliente ='" & dgvDeben.Item(4, l).Value & "' and activo=1 ORDER BY No DESC limit 4")
            'VerificarmesesMora2()
            npagos = npagos + 1
        Next
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        tablatemp = ConsultarRegistro("Select idCliente from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & "' limit 1")
        Dim s As String
        s = "Select * from controlpago where idCliente = '" & Id.Text & "' and mes = '" & mes.Text & "' and anio='" & año.Text & ""
        If tablatemp.Count > 0 Then
            Dim estado As Integer
            If rbin.Checked Then
                estado = 2
            Else
                estado = 1
            End If
            'Consulta = "update controlpago set FechaPago='" & Fecha1 & "', NoDEI='" & NDEI.Text & "', Mes='" & mes.Text & "', anio=" & año.Text & ", DescuentoD=" & dias.Text & ", DescuentoH=" & horas.Text & ", AbonoS=" & abonoS & ", TotalDescuento=" & txtDescuentoTotal.Text & ", Razondescuento='" & txtObservaciones.Text & "', TotalPagar=" & txtTotalMes.Text & ", abono=" & abono & ", pagado=" & pagado & ", fechapagado='" & Fecha2 & "', saldo=" & txtTotalPagar.Text & ", fechaEmision='" & Fecha3 & "', recargo=" & txtRecargo.Text & ", efectivo=" & txtEfectivo.Text & ", tipoPago=" & tipoP & ", enDolar=" & dolar & ", precioDolar=" & txtPrecioDolar.Text & ", tipoPagoDE=" & tp & ", isv=" & isv & " , isvE=" & ISVE & ", estado=" & estado & ", fechain='" & Fecha4 & "', fechahab='" & Fecha5 & "', detallepago='" & detallepago & "', cambio=" & cambio & ", totalmes=" & txtTotalMes.Text & ", cambioant=" & cambioant & " WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & ""
            adaptador = New MySqlDataAdapter("update controlpago set  estado=" & estado & ", fechain=NULL, fechahab=NULL, fechaPP=NULL, razonCorte='' WHERE idCliente='" & Id.Text & "' AND No=" & NPago.Text & " AND NoCorrelativo=" & txtNoCorrelativo.Text & " ", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "controlpago")
            data.Clear()
            llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "' order by NoCorrelativo desc limit " & txtlimite.Text & "")
        End If
    End Sub
    Private Sub cmbmostrarUsuario_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbmostrarUsuario.SelectedIndexChanged
        MostrarUsuarioNavegacion()
        CargarInstalaciones()
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        For i As Integer = 0 To dgvclientes.Rows.Count - 1
            If dgvclientes.Rows.Item(i).Selected = True Then
                ConsultarRegistro("update clientes set usuario='" & cmbusuario2.Text & "' where idcliente='" & dgvclientes.Item(1, i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")
        VerificarGridInstalaciones("Select * from fichainstalacionserviciovista where activo1=1 and Activo=1 " & usuarioActual & " where codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad ")
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Servidores.ShowDialog()
    End Sub
    Private Sub btnRehabilitar_Click(sender As Object, e As EventArgs) Handles btnRehabilitar.Click
        Try
            respuesta = MsgBox("Desea Rehabilitar al cliente " & dgvPagos.Item(0, 0).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("update clientes set Activo=1, estadocliente=1 where idCliente='" & Id.Text & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "Empleado")
                data.Clear()
                Dim Fecha6 As String = fechaAlta.Value.ToString("yyyy-MM-dd")
                Dim s As String
                s = "update fichaintalacionservicio set fechaalta='" & Fecha6 & "' where idCliente='" & Id.Text & "' And NoCorrelativo='" & txtNoFicha.Text & "'"
                adaptador = New MySqlDataAdapter("update fichaintalacionservicio set fechaalta='" & Fecha6 & "' where idCliente='" & Id.Text & "' And NoCorrelativo='" & txtNoFicha.Text & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "fichainstalacionservicio")
                InsertarBitacora("SE REHABILITO A " & dgvPagos.Item(5, 0).Value & " DE " & txtDireccion.Text & "")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
                llenaGrid("Select * from vistapagos where idCliente='" & Id.Text & "'")
            End If
        Catch s As Exception
        End Try
    End Sub

    Private Sub txtDescuentoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoTotal.KeyPress
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
    Sub SeleccionarCliente(ByVal dgv As DataGridView)
        Try
            Id.Text = dgv.Item(1, dgv.CurrentRow.Index).Value
            Nombre.Text = dgv.Item(2, dgv.CurrentRow.Index).Value
            'Pagos.DEI = DEI
            NoCorrelativoFicha = dgv.Item(10, dgv.CurrentRow.Index).Value
            txtNoFicha.Text = NoCorrelativoFicha
            txtMensualidad.Text = dgv.Item(5, dgv.CurrentRow.Index).Value.ToString
            txtMens.Text = dgv.Item(5, dgv.CurrentRow.Index).Value.ToString
            dtpInstalacion.Value = dgv.Item(3, dgv.CurrentRow.Index).Value
            dtpFechaPago.Value = dgv.Item(3, dgv.CurrentRow.Index).Value
            txtDireccion.Text = dgv.Item(18, dgv.CurrentRow.Index).Value
            txtdias.Text = 0

        Catch
        End Try
    End Sub
    Sub EditarRegistro()
        txtdias.Enabled = True
        horas.Enabled = True
        txtRecargo.Enabled = True
        txtObservaciones.Enabled = True
        txtEfectivo.Enabled = True
        cbabono.Enabled = True
        cbPagado.Enabled = True
        dtpFechaEmision.Enabled = True
        dtpFechaPago.Enabled = True
        NDEI.Enabled = True
        cbPP.Enabled = True
        txtEfectivo.Focus()
    End Sub

    Private Sub cbDolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDolar.CheckedChanged
        If cbDolar.Checked = True Then
            txtPrecioDolar.Focus()
            txtPrecioDolar.Text = 1
        ElseIf cbDolar.Checked = False Then
            txtPrecioDolar.Text = 1
            saldoDolar = txtTotalPagar.Text
        End If
    End Sub
    Sub ConvertirAlps()
        If cbDolar.Checked = True Then
            Try
                txtTotalMes.Text = txtMensualidad.Text - txtDescuentoTotal.Text + Val(txtRecargo.Text)
            Catch
            End Try

            txtTotalPagar.Text = Math.Round((Val(txtTotalMes.Text) + Val(txtSaldoAnt.Text)) * Val(txtPrecioDolar.Text), 2)
            txtCambio.Text = Val(txtEfectivo.Text) - Val(txtTotalPagar.Text)
        End If
    End Sub

    Private Sub txtPrecioDolar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioDolar.TextChanged
        If cbDolar.Checked = True And txtEfectivo.Text > 0 Then
            'CalcularDescuentoDolar()
            ConvertirAlps()
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibo.Click
        Try
            Dim correlativo As Integer = 0
            '  2 mes,3 año,15 total pagar,17 pagado,
            Dim mes, pagado As String
            mes = ""
            pagado = 0
            Try
                pagado = dgvPagos.Item(17, dgvPagos.CurrentRow.Index).Value
                If pagado = "Si" Then
                    Recibo.fecha.Value = dtpFechaEmision.Value
                    Recibo.direccion.Text = txtDireccion.Text
                    Recibo.id.Text = Id.Text
                    Recibo.nombre.Text = Nombre.Text
                    Recibo.fact.Text = txtNFact.Text
                    Recibo.obs.Text = txtObservaciones.Text
                    Recibo.saldoant = txtSaldoAnt.Text
                    Recibo.plan = dgvPagos.Item(31, dgvPagos.CurrentRow.Index).Value
                    Recibo.ShowDialog()
                End If
            Catch S As Exception
            End Try
        Catch
        End Try
    End Sub

    Private Sub rbDeposito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDeposito.CheckedChanged
        If rbDeposito.Checked = True And rbEfectivo.Checked = False Then
            tp = 1
            cmbDeposito.Enabled = True
            txtEfectivoEntregado.Enabled = False
        ElseIf rbDeposito.Checked = False And rbEfectivo.Checked = True Then
            tp = 2
            cmbDeposito.Enabled = False
            txtEfectivoEntregado.Enabled = True
        End If
    End Sub
    Sub InsertarBitacora(ByVal accion2 As String)
        Try
            Dim n As Integer

            n = incrementaCodigo("SELECT idbitacora FROM bitacora  ORDER BY idbitacora DESC limit 1", "idbitacora")

            adaptador = New MySqlDataAdapter("insert into bitacora values (" & n & ", '" & accion2 & "', '" & Today.ToString("yyyy-MM-dd") & "', '" & sesionusuario & "')", conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "detallecuentabancaria")
            'MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "SA INTERRA")
            data.Clear()
        Catch s As Exception
        End Try
    End Sub

    Sub EliminarCuentaB()
        adaptador = New MySqlDataAdapter("delete from detallecuentabancaria where NoCorrelativo=" & txtNoCorrelativo.Text & "", conexion)
        oCommBuild = New MySqlCommandBuilder(adaptador)
        adaptador.Fill(data, "detallecuentabancaria")
        'MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "SA INTERRA")
        data.Clear()
    End Sub



    Private Sub btnBuscarFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFact.Click
        Try

            llenaGrid("Select * from vistapagos where NoDEI =" & NDEI.Text & " order by NoCorrelativo")




        Catch
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        llenaGridFact("select * from vistacontador2 where activo=1   and isv=1 and FechaEmision between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' order by  FechaEmision, nodei, FechaPagado")
    End Sub
    Sub llenaGridFact(ByVal cadena As String)
        Try
            Dim subt, Isv, total As Double
            dgvFacturas.Rows.Clear()
            tablatemp2 = ConsultarRegistro(cadena)
            If tablatemp2.Count > 0 Then
                dgvFacturas.RowCount = tablatemp2.Count
                For i As Integer = 0 To tablatemp2.Count - 1
                    rowtemp = tablatemp2.Item(i)
                    dgvFacturas.Item(0, i).Value = i + 1
                    dgvFacturas.Item(1, i).Value = rowtemp("FechaEmision")

                    dgvFacturas.Item(2, i).Value = rowtemp("NoDEI")


                    dgvFacturas.Item(3, i).Value = rowtemp("FechaPagado")
                    dgvFacturas.Item(4, i).Value = rowtemp("Nombre")
                    dgvFacturas.Item(5, i).Value = (rowtemp("Efectivo") / 1.15)
                    dgvFacturas.Item(6, i).Value = rowtemp("Efectivo") - (rowtemp("Efectivo") / 1.15)
                    dgvFacturas.Item(7, i).Value = rowtemp("Efectivo")
                    dgvFacturas.Item(8, i).Value = rowtemp("meses")
                    dgvFacturas.Item(9, i).Value = rowtemp("idCliente")
                    dgvFacturas.Item(10, i).Value = rowtemp("Mes")
                    dgvFacturas.Item(11, i).Value = rowtemp("Anio")
                    'dgvFacturas.Item(13,i).Value = rowtemp("detallepago")
                    subt = subt + dgvFacturas.Item(5, i).Value
                    Isv = Isv + dgvFacturas.Item(6, i).Value
                    total = total + dgvFacturas.Item(7, i).Value
                Next
                txtSubtotal.Text = Math.Round(subt, 2)
                txtISV.Text = Math.Round(Isv, 2)
                txtTotal.Text = Math.Round(total, 2)
                'txtNRegistros.Text = tablatemp2.Count
                'dgvFacturas.Sort(dgvFacturas.Columns("Fact"), direction:=System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            For i As Integer = 0 To dgvFacturas.Rows.Count - 1

                If dgvFacturas.Item("cbselec", i).Value = True Then

                    Dim Fecha1 As New DateTimePicker
                    Fecha1.Value = Convert.ToDateTime(dgvFacturas.Item(1, i).Value.ToString)
                    Dim Fecha2 As String = Fecha1.Value.ToString("yyyy-MM-dd")
                    adaptador = New MySqlDataAdapter("update controlpago set FechaEmision='" & Fecha2 & "', NoDEI=" & dgvFacturas.Item(2, i).Value & " where idCliente='" & dgvFacturas.Item(9, i).Value & "' and Efectivo =" & dgvFacturas.Item(7, i).Value & " and Mes='" & dgvFacturas.Item(10, i).Value & "' and Anio='" & dgvFacturas.Item(11, i).Value & "'", conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "controlpago")
                End If
            Next

            MsgBox("Registros actualizados exitosamente", MsgBoxStyle.Information, "SA INTERRA")
            'llenaGridFact("select * from vistacontador where  FechaEmision >= #" & Me.dtpFecha1.Value.ToString("MM/dd/yy") & "# and FechaEmision <= #" & Me.dtpFecha2.Value.ToString("MM/dd/yy") & "# order by FechaEmision")
        Catch s As Exception
        End Try
    End Sub


    Private Sub cbISV_CheckedChanged(sender As Object, e As EventArgs) Handles cbISV.CheckedChanged
        Try
            If entro2 = True Then
                If cbISV.Checked = False Then
                    txtMensualidad.Text = Math.Round(txtMens.Text / 1.15, 2)
                    txtMens.Text = txtMensualidad.Text
                    txtTotalMes.Text = txtMensualidad.Text
                    cbExonerado.CheckState = CheckState.Unchecked
                ElseIf cbISV.Checked = True Then
                    txtMensualidad.Text = Math.Round(txtMensualidad.Text + Val(txtMensualidad.Text * 0.15), 2)
                    txtMens.Text = txtMensualidad.Text
                    txtTotalMes.Text = txtMensualidad.Text
                    txtTotalMes.Text = txtMensualidad.Text

                End If

                CalcularDescuento()
            End If
        Catch
        End Try
    End Sub




    Private Sub Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            llenaGridClientes("Select * from vistaclientes where nombre like '%" & Nombre.Text & "%' ")
            If TabClientes.SelectedTab.Equals(TabPagos) Or TabClientes.SelectedTab.Equals(TabPageClienteNuevo) Then

                llenaList("Select distinct(idcliente), nombre, Activo from vistapagos where nombre like '%" & Nombre.Text & "%' ")

            End If

            If TabClientes.SelectedTab.Equals(TabInstalaciones) Or TabClientes.SelectedTab.Equals(TabPageClienteNuevo) Then

                llenaGridInstalacion("Select * from fichainstalacionserviciovistalvasquez where nombre like '%" & Nombre.Text & "%' and Activo1=1 order by NoCorrelativo desc limit 5")

            End If
        End If
    End Sub

    Private Sub cbExonerado_CheckedChanged(sender As Object, e As EventArgs) Handles cbExonerado.CheckedChanged
        If cbExonerado.CheckState = CheckState.Checked Then
            cbISV.CheckState = CheckState.Checked
        End If
    End Sub
End Class