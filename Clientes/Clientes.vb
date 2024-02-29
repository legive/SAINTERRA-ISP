
'Imports MySql.Data.MySqlClient
Imports MySql.Data.MySqlClient

Public Class clientes
    'Public conec As New Conexion
    Dim INS As New Instalación
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Public varid2, identidad, consulta1, consulta2, consulta3, identidadPagos, idCliente As String
    Public respuesta2, formulario, ActivoD, entro2 As Integer
    Dim NSAR As Integer
    Public clientesForm, conexion2 As Boolean

    Sub Llenarcomunidades(ByVal consulta As String)

        adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
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
            cmbCodigoComunidad1.Items.Clear()
            cmbNombreComunidad1.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigoComunidad1.Items.Add(Filatemporal("CodigoComunidad"))
                cmbNombreComunidad1.Items.Add(Filatemporal("NombreComunidad"))

            Next
            cmbCodigoComunidad1.SelectedIndex = 0
            data.Clear()
        End If

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
            cmbCodigoMunicipio1.Items.Clear()
            cmbNombreMunicipio1.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigoMunicipio1.Items.Add(Filatemporal("Codigomunicipio"))
                cmbNombreMunicipio1.Items.Add(Filatemporal("Nombremunicipio"))

            Next
            cmbCodigoMunicipio1.SelectedIndex = 0
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
            cmbCodigoDepartamento1.Items.Clear()
            cmbNombreDepartamento1.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigoDepartamento1.Items.Add(Filatemporal("Codigodepartamento"))
                cmbNombreDepartamento1.Items.Add(Filatemporal("Nombredepartamento"))
                consulta1 = " Codigodepartamento=" & cmbCodigoDepartamento1.Text & ""

            Next
            cmbNombreDepartamento1.SelectedIndex = 0
            data.Clear()
        End If

    End Sub

    Sub SeleccionarRegistro()
        Try

            entro2 = True
            txtIdentidad.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtNombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtTelefono.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtCorreo.Text = dgvClientesNuevos.Item(6, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtDireccionExacta.Text = dgvClientesNuevos.Item(9, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            Numero.Text = dgvClientesNuevos.Item(10, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            If dgvClientesNuevos.Item(7, dgvClientesNuevos.CurrentRow.Index).Value = 1 Then
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
                cmbCodigoDepartamento1.SelectedIndex = i
                If dgvClientesNuevos.Item(3, indice).Value.ToString = cmbNombreDepartamento1.Text.ToString Then
                    GoTo salir
                End If
            Next
salir:
            Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")

            For i As Integer = 0 To cmbCodigoMunicipio1.Items.Count - 1
                cmbCodigoMunicipio1.SelectedIndex = i
                If dgvClientesNuevos.Item(4, indice).Value.ToString = cmbNombreMunicipio1.Text.ToString Then
                    GoTo salir2
                End If
            Next
salir2:
            Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " and Codigomunicipio<>0")

            For i As Integer = 0 To cmbCodigoComunidad1.Items.Count - 1
                cmbNombreComunidad1.SelectedIndex = i
                If dgvClientesNuevos.Item(5, indice).Value.ToString = cmbNombreComunidad1.Text.ToString Then
                    GoTo salir3
                End If
            Next
salir3:

            entro2 = False
        Catch
        End Try
    End Sub
#Region "sELECT INDEX CHANGED DE TODOS LOS COMBOBOX"
    Private Sub cmbdepartamento1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreDepartamento1.SelectedIndexChanged

        cmbCodigoDepartamento1.SelectedIndex = cmbNombreDepartamento1.SelectedIndex
        If entro2 = False Then
            Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")
            consulta1 = " Codigodepartamento=" & cmbCodigoDepartamento1.Text & ""

            If entro2 = True Then
                llenaGridClientes("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")
            End If
        End If
    End Sub
    Private Sub cmbNombremunicipio1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreMunicipio1.SelectedIndexChanged

        cmbCodigoMunicipio1.SelectedIndex = cmbNombreMunicipio1.SelectedIndex
        If entro2 = False Then
            Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " AND Codigomunicipio<>0")
            consulta2 = " and Codigomunicipio=" & cmbCodigoMunicipio1.Text & ""

            If entro2 = True Then
                consulta1 = " Codigodepartamento=" & cmbCodigoDepartamento1.Text & ""
                llenaGridClientes("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")
            End If
        End If
    End Sub
    Private Sub cmbNombreComunidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombreComunidad1.SelectedIndexChanged

        cmbCodigoComunidad1.SelectedIndex = cmbNombreComunidad1.SelectedIndex
        If entro2 = False Then
            consulta3 = " and CodigoComunidad=" & cmbCodigoComunidad1.Text & ""

            If entro2 = True Then
                llenaGridClientes("Select * from vistaclientes where " & consulta1 & consulta2 & consulta3 & "")
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
    Private Sub dgvclientes_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then

            ' Si se ha pulsado el botón derecho del ratón,
            ' seleccionamos la fila completa del control
            ' DataGridView.
            '
            With dgvClientesNuevos

                Dim hti As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                ' Obtenemos la parte del control a las que
                ' pertenecen las coordenadas.
                '
                If hti.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell =
                    .Rows(hti.RowIndex).Cells(hti.ColumnIndex)
                End If

            End With
        End If
    End Sub


    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmclientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectar()1
        'Limpiar()
        'Id.Text = identidadPagos
        'SeleccionarRegistro()


        clientesForm = True
        txtIdentidad.Focus()

        dgvClientesNuevos.Rows.Clear()
        txtIdentidad.Text = identidadPagos
        entro2 = True
        If formulario = 2 Then
            txtNombre.Focus()

            llenaGridClientes("Select * from vistaclientes2 where activo=1")
        Else
            llenaGridClientes("Select * from vistaclientes where idCliente = '" & txtIdentidad.Text & "'")
        End If
        txtIdentidad.Text = identidadPagos
        entro2 = False
        Llenardepartamento("Select * from departamento")
        txtRecuento.Text = "No. Registros: " & dgvClientesNuevos.RowCount & ""
        btnNuevo_Click(btnNuevo, e)
        'Id.Text = identidadPagos
        If identidadPagos <> "" Then
            llenaGridClientes("Select * from vistaclientes where idCliente = '" & identidadPagos & "'")
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

    Private Sub Id_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdentidad.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890-", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub Nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ áéíóú ÁÉÍÓÚ.()", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub Telefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890-", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub



    Sub Limpiar()
        txtIdentidad.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDireccionExacta.Text = ""
        btnGuardar.Enabled = True
        Numero.Text = incrementaCodigo("Select * from clientes order by NoCorrelativo", "NoCorrelativo")


    End Sub
    Private Sub LimpiarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimpiarToolStripMenuItem.Click
        Limpiar()
    End Sub
    Private Sub Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.txtIdentidad.Text = "" Then
                MsgBox("Ingrese el número de Identidad", , "Atención")
                GoTo salir
            End If
            If Me.txtNombre.Text = "" Then
                MsgBox("Ingrese el Nombre", , "Atención")
                GoTo salir
            End If
            If Me.txtTelefono.Text = "" Then
                MsgBox("Ingrese los apellidos", , "Atención")
                GoTo salir
            End If
            If Me.cmbCodigoDepartamento1.Text = "" Then
                MsgBox("Ingrese el departamento", , "Atención")
                GoTo salir
            End If

            If Me.cmbCodigoMunicipio1.Text = "" Then
                MsgBox("Ingrese el municipio", , "Atención")
                GoTo salir
            End If
            If Me.cmbCodigoComunidad1.Text = "" Then
                MsgBox("Ingrese la comunidad", , "Atención")
                GoTo salir
            End If

            If Me.txtCorreo.Text = "" Then
                MsgBox("Ingrese el número telefónico", , "Atención")
                GoTo salir
            End If
            Dim activo As Integer
            If cbActivoSistema.Checked = True Then
                activo = 1
            ElseIf cbActivoSistema.Checked = False Then
                activo = 2
            End If

            Consulta("Select * from vistaclientes where Id='" & txtIdentidad.Text & "'", "clientes")
            If Nrows > 0 Then
                Consulta("update clientes set Id='" & Me.txtIdentidad.Text & "', nombre='" & Me.txtNombre.Text & "', Telefono='" & Me.txtTelefono.Text & "', departamento='" & Me.cmbCodigoDepartamento1.Text & "', municipio='" & Me.cmbCodigoMunicipio1.Text & "', Comunidad='" & Me.cmbCodigoComunidad1.Text & "', correo='" & Me.txtCorreo.Text & "', activo=" & activo & " where Id='" & txtIdentidad.Text & "'", "clientes")
            Else
                Consulta("insert into clientes values('" & Me.txtIdentidad.Text & "', '" & Me.txtNombre.Text & "', '" & Me.txtTelefono.Text & "','" & Me.cmbCodigoDepartamento1.Text & "','" & Me.cmbCodigoMunicipio1.Text & "','" & Me.cmbCodigoComunidad1.Text & "', '" & Me.txtCorreo.Text & "', " & activo & ")", "clientes")

            End If


            MsgBox("Datos guardados exitosamente", , "Atención")

            llenaGridClientes("select * from vistaclientes")

salir:
        Catch
        End Try
    End Sub


    Private Sub dgvclientes_MouseDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvClientesNuevos.MouseDoubleClick
        Try
            If formulario = 1 Then
                Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.txtCel.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value
            Else
                Pagos.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Pagos.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
                Pagos.DEI = dgvClientesNuevos.Item(8, dgvClientesNuevos.CurrentRow.Index).Value

            End If
            Me.Close()
        Catch
        End Try
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
                Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
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


    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
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
                    adaptador = New MySqlDataAdapter("Insert into clientes (idCliente, Nombre, telefono, correo, Codigodepartamento, Codigomunicipio, CodigoComunidad, Activo, DEI, Direccion, NoCorrelativo, usuario, ubicacion, estadocliente, fechain, fechahab, equiporetirado) values('" & txtIdentidad.Text & "','" & txtNombre.Text.ToUpper & "','" & txtTelefono.Text & "','" & txtCorreo.Text & "','" & cmbCodigoDepartamento1.Text & "', '" & cmbCodigoMunicipio1.Text & "', '" & cmbCodigoComunidad1.Text & "', '" & activo & "', '" & ActivoD & "', '" & txtDireccionExacta.Text.ToUpper & "', " & Numero.Text & ", '" & cmbUsuarioCliente.Text & "', '" & txtUbicacion.Text & "',1,null,null,2)", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "clientes")
                    MsgBox("Registro agregado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'btnNuevo_Click(btnNuevo, e)
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGridClientes("SELECT * FROM vistaclientes where idCliente='" & txtIdentidad.Text & "' ")
                    InsertarBitacora("SE AGREGO CLIENTE  " & txtNombre.Text & " DE " & cmbNombreMunicipio1.Text & " " & cmbNombreComunidad1.Text & "")

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
                End If
            End If

        Catch s As Exception
            MsgBox(s.ToString)
        End Try


salir:
    End Sub




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

    Private Sub dgvClientesNuevos_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientesNuevos.CellClick, dgvClientesNuevos.CellDoubleClick
        Try
            entro2 = True
            txtIdentidad.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtNombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtTelefono.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtCorreo.Text = dgvClientesNuevos.Item(6, dgvClientesNuevos.CurrentRow.Index).Value.ToString
            txtDireccionExacta.Text = dgvClientesNuevos.Item(9, dgvClientesNuevos.CurrentRow.Index).Value.ToString
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
                cmbCodigoDepartamento1.SelectedIndex = i
                If dgvClientesNuevos.Item(3, indice).Value.ToString = cmbNombreDepartamento1.Text.ToString Then
                    GoTo salir
                End If
            Next
salir:
            Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento1.Text & "")

            For i As Integer = 0 To cmbCodigoMunicipio1.Items.Count - 1
                cmbCodigoMunicipio1.SelectedIndex = i
                If dgvClientesNuevos.Item(4, indice).Value.ToString = cmbNombreMunicipio1.Text.ToString Then
                    GoTo salir2
                End If
            Next
salir2:
            Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigoMunicipio1.Text & " and Codigomunicipio<>0")

            For i As Integer = 0 To cmbCodigoComunidad1.Items.Count - 1
                cmbNombreComunidad1.SelectedIndex = i
                If dgvClientesNuevos.Item(5, indice).Value.ToString = cmbNombreComunidad1.Text.ToString Then
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
            'llenaGridClientes("Select * from vistaclientes where nombre='" & Nombre.Text & "'")
        Catch
        End Try
    End Sub

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
        llenaGridClientes("Select * from vistaclientes where nombre like '%" & txtNombre.Text & "%'")
    End Sub

    Private Sub cbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles cbActivoHabilitado.CheckedChanged
        If cbActivoHabilitado.Checked = True And conexion2 = True Then
            llenaGridClientes("Select * from vistaclientes where activo =1")
        ElseIf cbActivoHabilitado.Checked = False And conexion2 = True Then
            llenaGridClientes("Select * from vistaclientes")
        End If
    End Sub

    Private Sub clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        clientesForm = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Try
            If txtIdentidad.Text = "" Then
                MsgBox("Favor ingrese el cliente",, "")
                txtNombre.Focus()
            Else
                Reclamos.Id.Text = txtIdentidad.Text
                Reclamos.Nombre.Text = txtNombre.Text
                Reclamos.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDireccion_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDireccionExacta.KeyUp
        llenaGridClientes("Select * from vistaclientes where direccion like '%" & txtDireccionExacta.Text & "%'")
    End Sub



    Private Sub Telefono_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTelefono.KeyUp
        llenaGridClientes("Select * from vistaclientes where telefono like '%" & txtTelefono.Text & "%'")
    End Sub

    Private Sub cmbdepartamento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNombreDepartamento1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbNombreMunicipio1.Focus()
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

    Private Sub cmbNombreComunidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNombreComunidad1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDireccionExacta.Focus()
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

    Private Sub cmbCodigoComunidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCodigoComunidad1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDireccionExacta.Focus()
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
    Private Sub txtDireccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccionExacta.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnGuardar.Focus()
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

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'conectar()1
        dgvClientesNuevos.Rows.Clear()
        Limpiar()
        llenaGridClientes("Select * from vistaclientes where activo=1 ")
        txtIdentidad.Focus()
    End Sub

    Private Sub btnOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrden.Click
        Try
            If formulario = 1 Then
                Instalación.Id.Text = dgvClientesNuevos.Item(0, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.Nombre.Text = dgvClientesNuevos.Item(1, dgvClientesNuevos.CurrentRow.Index).Value
                Instalación.txtCel.Text = dgvClientesNuevos.Item(2, dgvClientesNuevos.CurrentRow.Index).Value
                Me.Close()
            Else

                If txtIdentidad.Text = "" Then
                    MsgBox("Seleccione un cliente para agregarle orden de instalación", MsgBoxStyle.Information, "Atención")
                Else
                    Try

                        Instalación.formulario = 3
                    Catch
                    End Try
                    Instalación.idCliente = txtIdentidad.Text
                    Instalación.nombreCliente = txtNombre.Text

                    If Instalación.InstalacionForm = True Then
                        'Instalación.Close()
                        Me.Close()

                    Else
                        Instalación.ShowDialog()
                    End If

                End If
            End If
        Catch
        End Try
    End Sub

    'Private Function Instalación() As Object
    '    Throw New NotImplementedException
    'End Function

End Class