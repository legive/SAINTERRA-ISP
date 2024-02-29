Imports MySql.Data.MySqlClient
Public Class frwInforme
    Dim INS As New Instalación
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Dim oCommBuild As MySqlCommandBuilder
    Private data As New DataSet
    Dim varid As String
    Private tablatemp, tablatemp2, tablatemp3, tablatem4 As DataRowCollection
    Private rowtemp As DataRow
    Public NoCorrelativoFicha, no, DEI, descuentodias, descuentoHoras, tp As Integer
    Dim fechaPago, atlantida, usuarioActual, posteado As String
    Dim respuesta, dolar, isv, ISVE As Integer
    Dim totalgastos As Double
    Dim ventasMensuales As Double
    'Private Sub cmbNombremunicipio_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    cmbCodigomunicipio.SelectedIndex = cmbNombremunicipio.SelectedIndex
    '    Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigomunicipio.Text & " AND Codigomunicipio<>0")

    'End Sub

    Dim entro, entro2, entro3 As Boolean
    Sub Excel(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Add
        exHoja = exLibro.Worksheets.Add()
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        For i As Integer = 1 To NCol

            If ElGrid.Columns(i - 1).Visible = True Then
                exHoja.Cells.Item(1, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                columnaEx = columnaEx + 1
            End If

        Next
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        For Fila As Integer = 0 To NRow - 1
            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(Fila + 2, columnaEx + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If
            Next
            columnaEx = 0
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()


        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        llenaGrid("Select * from vistapagos where MONTH(FechaPagado)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaPagado)=" & cmbaño2.Text & " and pagado=1 and activo=1 and efectivo>0 order by fechaPagado", dgvVentas)
        llenaGridGastos("SELECT * FROM salidas where MONTH(FechaCred)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaCred)=" & cmbaño2.Text & " order BY Fecha ", dgvGastos)
        llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalado)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaInstalado)=" & cmbaño2.Text & " order BY FechaInstalado")
        'dgvResumen.Item(0, 0).Value = 34378.45
        'dgvResumen.Item(1, 0).Value = txtVentas.Text
        'dgvResumen.Item(2, 0).Value = Val(dgvResumen.Item(1, 0).Value) + Val(dgvResumen.Item(0, 0).Value)
        'dgvResumen.Item(3, 0).Value = totalgastos
        'dgvResumen.Item(4, 0).Value = Val(dgvResumen.Item(2, 0).Value) - Val(totalgastos)
        '{ AND {fichainstalacionserviciovista.Activo}=1 and {fichainstalacionserviciovista.FechaInstalacion} <= #" & Me.dtpFecha2.Value.ToString("MM/dd/yy") & "# and {fichainstalacionserviciovista.FechaInstalacion} >= #" & Me.dtpFecha1.Value.ToString("MM/dd/yy") & "# "
    End Sub

    Private Sub cmbaño2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbaño2.SelectedIndexChanged

    End Sub

    Private Sub cbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodo.CheckedChanged
        If cbTodo.Checked = True Then
            llenaGrid("Select * from vistapagos where  YEAR(FechaPagado)=" & cmbaño2.Text & " and pagado=1 and activo=1 and efectivo>0 order by fechaPagado", dgvVentas)
            llenaGridGastos("SELECT * FROM salidas where  YEAR(FechaCred)=" & cmbaño2.Text & " order BY Fecha ", dgvGastos)
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and YEAR(FechaInstalacion)=" & cmbaño2.Text & " order BY FechaInstalacion")

        Else cbTodo.Checked = False
            llenaGrid("Select * from vistapagos where MONTH(FechaPagado)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaPagado)=" & cmbaño2.Text & " and pagado=1 and activo=1 and efectivo>0 order by fechaPagado", dgvVentas)
            llenaGridGastos("SELECT * FROM salidas where MONTH(FechaCred)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaCred)=" & cmbaño2.Text & " order BY Fecha ", dgvGastos)
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalacion)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaInstalacion)=" & cmbaño2.Text & " order BY FechaInstalacion")

        End If
    End Sub

    Private Sub btnInforme_Click(sender As Object, e As EventArgs) Handles btnInforme.Click
        Excel(dgvClientesAc)
    End Sub

    Dim entroDei As Boolean

    Private Sub cbClientesActivos_CheckedChanged(sender As Object, e As EventArgs) Handles cbClientesActivos.CheckedChanged
        If cbClientesActivos.Checked = True Then
            MostrarUsuario2()
            llenaGridClientesActivos("Select nombredepartamento, nombremunicipio, nombrecomunidad, direccion,  idcliente, nombre, velocidad, unidades,  mensualidad, ip, usuario from fichainstalacionserviciovista where activo=1 and activo1=1 and mensualidad>0 " & usuarioActual & " order by nombredepartamento, nombremunicipio, nombrecomunidad", dgvClientesAc)
        End If
    End Sub

    Private Sub cmbNombreComunidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNombreComunidad.SelectedIndexChanged
        cmbCodigoComunidad.SelectedIndex = cmbNombreComunidad.SelectedIndex
        cbClientesActivos.Checked = False
        If cmbCodigoComunidad.Text <> "" And cmbCodigomunicipio.Text <> "" And cmbCodigoComunidad.Text <> "" Then
            llenaGridClientesActivos("Select  nombredepartamento,  nombremunicipio,  nombrecomunidad, direccion,  idcliente, nombre, velocidad, unidades,  mensualidad, moneda, telefono from fichainstalacionserviciovista where activo=1 and activo1=1 and mensualidad>0 and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad, nombre", dgvClientesAc)
        End If
        If cbInst2.Checked = True Then
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalacion)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaInstalacion)=" & cmbaño2.Text & " and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "'  order BY FechaInstalacion")
        End If
    End Sub

    Dim navegacion = 0, TipoPago As Integer
    Public idInstalacion As String
    Dim saldoDolar, filaspagos As Integer

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
    Sub MostrarUsuario()
        Select Case cmbmostrarUsuario.SelectedIndex
            Case 0
                usuarioActual = ""
            Case 1
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
            Case 2
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"
            Case 3
                usuarioActual = "and usuario='" & cmbmostrarUsuario.Text & "'"

        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        llenaGrid("Select * from vistapagos where mes= '" & cmbmes2.Text & "' " & usuarioActual & " " & posteado & " and anio=" & cmbaño2.Text & " and pagado=1 and efectivo>0 and detallepago like '%" & txtDetalle.Text & "%' order by fechaPagado", dgvVentas)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Excel(dgvVentas)
    End Sub
    Sub postear()

        If cbPostear.Checked = True Then
            posteado = " and posteado=1 "
        Else
            posteado = " and posteado=0 "
        End If
    End Sub

    Private Sub dgvVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellContentClick

        'If dgvVentas.Rows(dgvVentas.CurrentRow.Index).Selected = True Then
        dgvVentas.Item("Posteado_cuentas_Edwin", dgvVentas.CurrentRow.Index).Value = True
        'Else
        '    dgvVentas.Item("Posteado_cuentas_Edwin", dgvVentas.CurrentRow.Index).Value = False
        'End If
    End Sub

    Private Sub cbPostear_CheckedChanged(sender As Object, e As EventArgs) Handles cbPostear.CheckedChanged
        postear()
    End Sub

    Sub VerificarFiltro(ByVal detalle As String, ByVal monto As String)
        If detalle <> "" Then
            detalle = " and detallepago Like '%" & txtDetalle.Text & "%'"
            resdetalle = detalle
        Else
            resdetalle = ""
        End If
        If monto <> "" Then
            resMonto = " and efectivo = " & Val(txtMonto.Text) & ""

        Else
            resMonto = ""
        End If

    End Sub
    Dim resdetalle, resMonto As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VerificarFiltro(txtDetalle.Text, txtMonto.Text)

        llenaGrid("Select * from vistapagos where FechaPagado between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' " & usuarioActual & " " & posteado & " and pagado=1 and efectivo>0 " & resdetalle & resMonto & " order by fechaPagado", dgvVentas)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Excel(dgvGastos)
    End Sub
    Sub SaldoAnterior()
        Try
            'Dim ventasMensuales As Double
            Dim anio, dia As Integer
            If dtpInicio.Value.Month = 1 Then
                anio = dtpInicio.Value.Year - 1
            Else
                anio = dtpInicio.Value.Year
            End If
            If dtpInicio.Value.Month = 1 Then
                dia = 12
            Else
                dia = dtpInicio.Value.Month - 1
            End If

            'dgv.Rows.Clear()
            tablatemp2 = ConsultarRegistro("Select * from informe where mes=" & dia & " And anio=" & anio & " ")
            If tablatemp2.Count > 0 Then

                rowtemp = tablatemp2.Item(0)
                'dgv.Item(1, i).Value = rowtemp("Nombredepartamento") & " " & rowtemp("Nombremunicipio") & "  " & rowtemp("NombreComunidad")
                dgvResumen.Item(0, 0).Value = rowtemp("saldo")

                'lbTotalDeuda.Text = "Lps. " & deuda

            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
    Private Sub btnMostrarInformes_Click(sender As Object, e As EventArgs) Handles btnMostrarInformes.Click
        dgvResumen.Rows.Clear()

        Dim meses As Integer
        'meses = DateDiff(DateInterval.Month, dtpInicio.Value, dtpFinal.Value)
        'If meses = 0 Then
        '    dgvResumen.Rows.Add(1)
        'Else
        '    dgvResumen.Rows.Add(meses)
        'End If

        'dtpFinal.Value = dtpInicio.Value
        For i As Integer = 0 To meses
            totalgastos = 0
            ventasMensuales = 0
            txtVentas.Text = 0
            txtGastos.Text = 0

            llenaGrid("Select * from vistapagos where MONTH(FechaPagado) = " & Month(dtpFinal.Value) & " And Year(FechaPagado) = " & Year(dtpFinal.Value) & " And pagado = 1 And efectivo > 0 order by fechaPagado", dgvVentas)
            llenaGridGastos("Select * FROM salidas where MONTH(FechaCred)= " & Month(dtpFinal.Value) & " And YEAR(FechaCred)=" & Year(dtpFinal.Value) & " And CREDESP=0 order BY tipo1, Fecha ", dgvGastos)
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalacion)= " & Month(dtpFinal.Value) & " and YEAR(FechaInstalacion)=" & Year(dtpFinal.Value) & " order BY FechaInstalacion")
            If i = 0 Then
                SaldoAnterior()
            Else
                dgvResumen.Item(0, i).Value = dgvResumen.Item(4, i - 1).Value
            End If
            dgvResumen.Item(1, i).Value = Math.Round(Val(txtVentas.Text), 2)
            dgvResumen.Item(2, i).Value = Math.Round(Val(dgvResumen.Item(1, i).Value) + Val(dgvResumen.Item(i, i).Value), 2)
            dgvResumen.Item(3, i).Value = Math.Round(totalgastos, 2)
            dgvResumen.Item(4, i).Value = Math.Round(Val(dgvResumen.Item(2, i).Value) - Val(totalgastos), 2)
            guardar()
            'dtpFinal.Value = dtpFinal.Value.AddMonths(1)
        Next
    End Sub
    Sub guardar()
        Try


            adaptador = New MySqlDataAdapter("Select * from informe where mes= " & dtpInicio.Value.Month & " and  anio= " & dtpInicio.Value.Year & "", frmMenu.conexion)
            'Dim planes As String = "Select * from planes where Mensualidad= " & Precio.Text & " and Velocidad=" & Velocidad.Text & ""
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "informe")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("informe").Rows


            If data.Tables("informe").Rows.Count = 0 Then

                adaptador = New MySqlDataAdapter("Insert into informe values(" & dtpInicio.Value.Month & "," & dtpInicio.Value.Year & "," & dgvResumen.Item(4, 0).Value & ")", frmMenu.conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "planes")
                MsgBox("Registro agregado exitosamente")
                data.Clear()

            Else
                Filatemporal = tablatemporal.Item(0)

                adaptador = New MySqlDataAdapter("update informe set  saldo=" & dgvResumen.Item(4, 0).Value & " where mes=" & dtpInicio.Value.Month & " and anio=" & dtpInicio.Value.Year & "", frmMenu.conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "informe")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
            End If
            'llenaGrid("Select * from planes")
        Catch s As Exception
            data.Clear()
            MsgBox(s.ToString)
        End Try
salir:

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If cbFactura.Checked Then
            llenaGrid("Select * from vistapagos where FechaEmision between '" & Me.dtpFilto2.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFiltro3.Value.ToString("yyyy-MM-dd") & "'  and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and pagado=1  and efectivo>0 and NoDEI>0 order by FechaEmision", dgvVentas)
            txtSubtotal.Text = Math.Round(((txtVentas.Text) / 1.15), 2)
            txtImpMuni.Text = Math.Round(txtSubtotal.Text * (0.36 / 100), 2)
        End If
    End Sub
    Sub InformeGeneral(ByVal ElGrid As DataGridView, ByVal ElGrid2 As DataGridView, ByVal ElGrid3 As DataGridView)

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\VENTASMENSUALESINFORMEINTERNO.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        'exLibro = exApp.Workbooks.Add
        'exHoja = exLibro.Worksheets.Add()
        Dim columnaEx As Integer = 1

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount

        exHoja.Cells.Item(3, 2) = ElGrid.Rows(0).Cells(0).Value
        exHoja.Cells.Item(4, 2) = txtVentas.Text
        exHoja.Cells.Item(6, 2) = txtGastos.Text
        'exHoja.Cells.Item(2, 5) = dtpInicio.Value.Month()
        exHoja = exLibro.Worksheets.Item(2)
        NCol = ElGrid2.ColumnCount
        NRow = ElGrid2.RowCount
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        Dim filaexcel As Integer = 2
        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid2.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 1, columnaEx + 1) = ElGrid2.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0
        exHoja = exLibro.Worksheets.Item(3)
        NCol = ElGrid3.ColumnCount
        NRow = ElGrid3.RowCount
        ProgressBar1.Maximum = NRow
        columnaEx = 0
        filaexcel = 2
        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1
                'If ElGrid.Columns(Col - 1).Visible = True Then
                If ElGrid3.Columns.Item(Col).Visible = True Then
                    exHoja.Cells.Item(filaexcel + 1, columnaEx + 1) = ElGrid3.Rows(Fila).Cells(Col).Value
                    columnaEx = columnaEx + 1
                End If


                ProgressBar1.Value = Fila
                'End If

            Next
            filaexcel = filaexcel + 1
            columnaEx = 0
        Next
        ProgressBar1.Value = 0

        'exHoja.Rows.Item(1).Font.Bold = 1
        'exHoja.Rows.Item(1).HorizontalAlignment = 3
        'exHoja.Columns.AutoFit()


        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing

    End Sub

    Private Sub btnInformeGeneral_Click(sender As Object, e As EventArgs) Handles btnInformeGeneral.Click
        InformeGeneral(dgvResumen, dgvVentas, dgvGastos)
    End Sub


    Sub MostrarUsuario2()
        Select Case cmbmostrarUsuario2.SelectedIndex
            Case 0
                usuarioActual = ""
            Case 1
                usuarioActual = "and usuario='" & cmbmostrarUsuario2.Text & "'"
            Case 2
                usuarioActual = "and usuario='" & cmbmostrarUsuario2.Text & "'"
            Case 3
                usuarioActual = "and usuario='" & cmbmostrarUsuario2.Text & "'"
            Case 4
                usuarioActual = "and (usuario='" & cmbmostrarUsuario2.Items.Item(1).ToString & "' or usuario='" & cmbmostrarUsuario2.Items.Item(2).ToString & "')"

        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        For i As Integer = 0 To dgvVentas.Rows.Count - 1
            If dgvVentas.Rows.Item(i).Selected = True Then

                ConsultarRegistro("update clientes set DEI=1 where idcliente='" & dgvVentas.Item("videntidad", i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")
        llenaGrid("Select * from vistapagos where FechaPagado between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' " & usuarioActual & " " & posteado & " and pagado=1 and efectivo>0 " & resdetalle & resMonto & " order by fechaPagado", dgvVentas)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For i As Integer = 0 To dgvVentas.Rows.Count - 1

            If dgvVentas.Rows.Item(i).Selected = True Then

                ConsultarRegistro("update clientes set DEI=2 where idcliente='" & dgvVentas.Item("videntidad", i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")
        llenaGrid("Select * from vistapagos where FechaPagado between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' " & usuarioActual & " " & posteado & " and pagado=1 and efectivo>0 " & resdetalle & resMonto & " order by fechaPagado", dgvVentas)


    End Sub

    Private Sub btnExportarClientesActivos_Click(sender As Object, e As EventArgs) Handles btnExportarClientesActivos.Click
        Excel(dgvInstalacion)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        llenaGrid("Select * from vistapagos where codigodepartamento=" & cmbCodigoDepartamento2.Text & " and codigomunicipio=" & cmbCodigoMunicipio2.Text & " and codigoComunidad='" & cmbCodigoComunidad2.Text & "' and activo=1 group by idCliente", dgvVentas)
        txtSubtotal.Text = ((txtVentas.Text) / 1.15)
        txtImpMuni.Text = txtSubtotal.Text * (0.36 / 100)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento2.SelectedIndexChanged
        cmbCodigoDepartamento2.SelectedIndex = cmbDepartamento2.SelectedIndex
        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigoDepartamento2.Text & "")

    End Sub

    Private Sub cmbMunicipio2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMunicipio2.SelectedIndexChanged
        cmbCodigoMunicipio2.SelectedIndex = cmbMunicipio2.SelectedIndex
        Llenarcomunidades("Select * from comunidades where Codigomunicipio='" & cmbCodigoMunicipio2.Text & "' AND Codigomunicipio<>0")

    End Sub

    Private Sub cmbComunidad2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComunidad2.SelectedIndexChanged
        cmbCodigoComunidad2.SelectedIndex = cmbComunidad2.SelectedIndex
    End Sub




    Private Sub cmbmostrarUsuario2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmostrarUsuario2.SelectedIndexChanged
        MostrarUsuario2()
    End Sub

    Private Sub btnPostear_Click(sender As Object, e As EventArgs) Handles btnPostear.Click
        For i As Integer = 0 To dgvVentas.Rows.Count - 1

            If dgvVentas.Item("Posteado_cuentas_Edwin", dgvVentas.CurrentRow.Index).Value = True Or dgvVentas.Rows(dgvVentas.CurrentRow.Index).Selected = True Then
                ConsultarRegistro("update controlpago set posteado=1 where idcliente='" & dgvVentas.Item("videntidad", i).Value & "'")
            Else
                ConsultarRegistro("update controlpago set posteado=0 where idcliente='" & dgvVentas.Item("videntidad", i).Value & "'")
            End If
        Next
        MsgBox("Registros actualizados")
        llenaGrid("Select * from vistapagos where mes= '" & cmbmes2.Text & "' " & usuarioActual & " " & posteado & " and anio=" & cmbaño2.Text & " and pagado=1 and efectivo>0 and detallepago like '%" & txtDetalle.Text & "%' order by fechaPagado", dgvVentas)

    End Sub

    Private Sub txtDetalle_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDetalle.KeyUp
        If cmbmes2.Text <> "" And cmbaño2.Text <> "" Then
            MostrarUsuario()
            llenaGrid("Select * from vistapagos where mes= '" & cmbmes2.Text & "' " & usuarioActual & " " & posteado & " and anio=" & cmbaño2.Text & " and pagado=1 and efectivo>0 and detallepago like '%" & txtDetalle.Text & "%' order by fechaPagado", dgvVentas)
        End If
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cbClientesActivos.Checked = False
            If cmbCodigoComunidad.Text <> "" And cmbCodigomunicipio.Text <> "" And cmbCodigoComunidad.Text <> "" Then
                llenaGridClientesActivos("Select  nombredepartamento,  nombremunicipio,  nombrecomunidad, direccion,  idcliente, nombre, velocidad, unidades,  mensualidad, moneda from fichainstalacionserviciovista where activo=1 and mensualidad>0 and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad", dgvClientesAc)
            End If
        End If
    End Sub

    Dim cambio, cambioant, mora, filasmora As Integer
    'Sub conectar()1
    '    Try
    '        conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
    '        conexion.Open()
    '    Catch s As Exception
    '        MsgBox(s.ToString)
    '    End Try
    'End Sub
    Public Function ConsultarRegistro(ByVal cadena As String)
        Try
            data.Clear()
            adaptador = New MySqlDataAdapter(cadena, frmMenu.conexion)
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
    Private Sub frwInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conectar()1
        Llenardepartamento("select * from departamento")

    End Sub
    Private Sub cmbdepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepartamento.SelectedIndexChanged

        cmbCodigodepartamento.SelectedIndex = cmbdepartamento.SelectedIndex

        Llenarmunicipios("Select * from municipio where Codigodepartamento=" & cmbCodigodepartamento.Text & "")
        cbClientesActivos.Checked = False
        If cmbCodigoComunidad.Text <> "" And cmbCodigomunicipio.Text <> "" And cmbCodigoComunidad.Text <> "" Then
            llenaGridClientesActivos("Select  nombredepartamento,  nombremunicipio,  nombrecomunidad, direccion,  idcliente, nombre, velocidad, unidades,  mensualidad, moneda from fichainstalacionserviciovista where activo=1 and activo1=1 and mensualidad>0 and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad, nombre", dgvClientesAc)
        End If
        If cbInst2.Checked = True Then
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalacion)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaInstalacion)=" & cmbaño2.Text & " and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "'  order BY FechaInstalacion")
        End If
    End Sub
    Private Sub cmbNombremunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombremunicipio.SelectedIndexChanged

        cmbCodigomunicipio.SelectedIndex = cmbNombremunicipio.SelectedIndex
        Llenarcomunidades("Select * from comunidades where Codigomunicipio=" & cmbCodigomunicipio.Text & " AND Codigomunicipio<>0")
        cbClientesActivos.Checked = False
        If cmbCodigoComunidad.Text <> "" And cmbCodigomunicipio.Text <> "" And cmbCodigoComunidad.Text <> "" Then
            llenaGridClientesActivos("Select  nombredepartamento,  nombremunicipio,  nombrecomunidad, direccion,  idcliente, nombre, velocidad, unidades,  mensualidad, moneda from fichainstalacionserviciovista where activo=1 and activo1=1 and mensualidad>0 and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "' order by nombredepartamento, nombremunicipio, nombrecomunidad, nombre", dgvClientesAc)
        End If
        If cbInst2.Checked = True Then
            llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and MONTH(FechaInstalacion)= " & cmbmes2.SelectedIndex + 1 & " and YEAR(FechaInstalacion)=" & cmbaño2.Text & " and codigodepartamento=" & cmbCodigodepartamento.Text & " and codigomunicipio=" & cmbCodigomunicipio.Text & " and codigocomunidad='" & cmbCodigoComunidad.Text & "'  order BY FechaInstalacion")
        End If
    End Sub
    Private Sub cmbCodigodepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigodepartamento.SelectedIndexChanged
        cmbdepartamento.SelectedIndex = cmbCodigodepartamento.SelectedIndex
    End Sub
    Private Sub cmbCodigomunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigomunicipio.SelectedIndexChanged
        cmbNombremunicipio.SelectedIndex = cmbCodigomunicipio.SelectedIndex
    End Sub
    Private Sub cmbCodigoComunidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigoComunidad.SelectedIndexChanged
        cmbCodigoComunidad.SelectedIndex = cmbNombreComunidad.SelectedIndex
    End Sub

    Sub Llenardepartamento(ByVal consulta As String)
        Try
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
                    cmbCodigoDepartamento2.Items.Add(Filatemporal("Codigodepartamento"))
                    cmbDepartamento2.Items.Add(Filatemporal("Nombredepartamento"))


                Next
                cmbdepartamento.SelectedIndex = 0
                data.Clear()
            End If
        Catch s As Exception
        End Try
    End Sub
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
            cmbCodigoComunidad.Items.Clear()
            cmbNombreComunidad.Items.Clear()
            cmbCodigoComunidad2.Items.Clear()
            cmbComunidad2.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigoComunidad.Items.Add(Filatemporal("CodigoComunidad"))
                cmbNombreComunidad.Items.Add(Filatemporal("NombreComunidad"))
                cmbCodigoComunidad2.Items.Add(Filatemporal("CodigoComunidad"))
                cmbComunidad2.Items.Add(Filatemporal("NombreComunidad"))

            Next
            cmbCodigoComunidad.SelectedIndex = 0
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
            cmbCodigomunicipio.Items.Clear()
            cmbNombremunicipio.Items.Clear()
            cmbCodigoMunicipio2.Items.Clear()
            cmbMunicipio2.Items.Clear()
            'recorrer cada fila
            For i As Integer = 0 To tablatemporal.Count - 1

                Filatemporal = tablatemporal.Item(i)

                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

                cmbCodigomunicipio.Items.Add(Filatemporal("Codigomunicipio"))
                cmbNombremunicipio.Items.Add(Filatemporal("Nombremunicipio"))
                cmbCodigoMunicipio2.Items.Add(Filatemporal("Codigomunicipio"))
                cmbMunicipio2.Items.Add(Filatemporal("Nombremunicipio"))

            Next
            cmbCodigomunicipio.SelectedIndex = 0
            data.Clear()
        End If

    End Sub

    'Sub Llenarcomunidades(ByVal consulta As String)
    '    Try

    '        adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
    '        Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
    '        data = New DataSet
    '        adaptador.Fill(data, "comunidades")
    '        Dim tablatemporal As DataRowCollection
    '        Dim Filatemporal As DataRow
    '        'a la tabla temporal agregar las filas de la consulta
    '        tablatemporal = data.Tables("comunidades").Rows

    '        'si la consulta agregada a la tabla temporal tiene datos o filas
    '        If tablatemporal.Count > 0 Then
    '            'se limpia y se le agrega al grid el numero de filas que tiene la tabla temporal
    '            cmbCodigoComunidad2.Items.Clear()
    '            cmbComunidad2.Items.Clear()
    '            'recorrer cada fila
    '            For i As Integer = 0 To tablatemporal.Count - 1

    '                Filatemporal = tablatemporal.Item(i)

    '                'ENTRE PARENTESIS DEBE IR EL NOMBRE DEL CAMPO DE LA TABLA EN LA BASE DE DATOS

    '                cmbCodigoComunidad2.Items.Add(Filatemporal("CodigoComunidad"))
    '                cmbComunidad2.Items.Add(Filatemporal("NombreComunidad"))

    '            Next
    '            cmbCodigoComunidad.SelectedIndex = 0
    '            data.Clear()
    '        End If
    '    Catch
    '    End Try


    'End Sub
    Sub llenaGridInstalaciones(ByVal cadena As String)
        Try
            dgvInstalacion.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dgvInstalacion.RowCount = tablatemp.Count
                txtInstalaciones.Text = tablatemp.Count
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvInstalacion.Item(0, l).Value = rowtemp("idCliente")
                    dgvInstalacion.Item(1, l).Value = rowtemp("nombre")
                    dgvInstalacion.Item(2, l).Value = rowtemp("Tipo")
                    dgvInstalacion.Item(3, l).Value = rowtemp("FechaInstalado")
                    dgvInstalacion.Item(4, l).Value = rowtemp("velocidad")
                    dgvInstalacion.Item(5, l).Value = rowtemp("Mensualidad")
                    dgvInstalacion.Item(6, l).Value = rowtemp("Mac")
                    dgvInstalacion.Item(7, l).Value = rowtemp("Ip")
                    dgvInstalacion.Item(8, l).Value = rowtemp("Instaladopor")
                    dgvInstalacion.Item(9, l).Value = rowtemp("Equipo")
                    dgvInstalacion.Item(10, l).Value = rowtemp("NoCorrelativo")
                    dgvInstalacion.Item(11, l).Value = rowtemp("unidades")
                    dgvInstalacion.Item(12, l).Value = rowtemp("moneda")
                    dgvInstalacion.Item(13, l).Value = rowtemp("TipoPlan")

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
                    DEI = rowtemp("DEI")
                Next
                'SeleccionarCliente2()
                'txtRecuento.Text = "No. Registros: " & dgvInstalacion.RowCount & ""
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
    Sub llenaGridGastos(ByVal cadena As String, ByVal dg As DataGridView)
        Try
            txtGastos.Text = 0
            dg.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dg.RowCount = tablatemp.Count
                'Dim total, no As Double
                totalgastos = 0
                no = 0
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dg.Item(0, l).Value = rowtemp("NFact")
                    dg.Item(1, l).Value = rowtemp("Fecha")
                    dg.Item(2, l).Value = rowtemp("Descripcion")
                    dg.Item(3, l).Value = rowtemp("Monto")
                    dg.Item(4, l).Value = rowtemp("MontoPagado")
                    dg.Item(5, l).Value = rowtemp("Observaciones")
                    dg.Item(6, l).Value = rowtemp("Tipo1")
                    dg.Item(7, l).Value = rowtemp("Tipo2")
                    dg.Item(8, l).Value = rowtemp("Mes")
                    dg.Item(9, l).Value = rowtemp("Anio")
                    dg.Item(10, l).Value = rowtemp("Correlativo")

                    no = no + 1
                    totalgastos = Val(totalgastos) + Val(dg.Item(4, l).Value)
                    'lbtotal.Text = "Total: " & total
                    lbNoRegistros.Text = "No. de Registros:" & no
                    dg.Item(11, l).Value = rowtemp("Cred")
                    If rowtemp("isr") Then
                        dg.Item(12, l).Value = "Si"
                    Else
                        dg.Item(12, l).Value = "No"

                    End If
                    dg.Item(13, l).Value = rowtemp("Fechacred")
                    If rowtemp("credesp") Then
                        dg.Item(14, l).Value = "Si"
                    Else
                        dg.Item(14, l).Value = "No"
                    End If


                Next
                For Each fila As DataGridViewRow In dg.Rows
                    If fila.Cells("Cred").Value = 1 Then
                        fila.DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        fila.DefaultCellStyle.BackColor = Color.White
                    End If

                Next
                txtGastos.Text = totalgastos
            Else
                dg.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub llenaGrid(ByVal cadena As String, ByVal dgv As DataGridView)
        Try
            Dim ventasMensuales As Double
            ventasMensuales = 0
            txtVentas.Text = 0
            dgv.Rows.Clear()
            tablatemp2 = ConsultarRegistro(cadena)
            If tablatemp2.Count > 0 Then
                dgv.RowCount = tablatemp2.Count
                For i As Integer = 0 To tablatemp2.Count - 1
                    rowtemp = tablatemp2.Item(i)
                    dgv.Item(1, i).Value = rowtemp("Nombredepartamento") & " " & rowtemp("Nombremunicipio") & "  " & rowtemp("NombreComunidad")
                    dgv.Item(0, i).Value = i + 1
                    dgv.Item(2, i).Value = rowtemp("NoDEI")
                    dgv.Item(3, i).Value = rowtemp("Mes")
                    dgv.Item(4, i).Value = rowtemp("Anio")
                    dgv.Item(5, i).Value = rowtemp("idCliente")
                    dgv.Item(6, i).Value = rowtemp("Nombre")
                    dgv.Item(7, i).Value = Math.Round(rowtemp("Mensualidad") / 1.15, 2)
                    dgv.Item(8, i).Value = rowtemp("FechaInstalacion")
                    dgv.Item(9, i).Value = rowtemp("FechaPago")
                    dgv.Item(10, i).Value = rowtemp("DescuentoD")
                    dgv.Item(11, i).Value = rowtemp("DescuentoH")
                    dgv.Item(12, i).Value = rowtemp("AbonoA")
                    dgv.Item(13, i).Value = rowtemp("AbonoS")
                    dgv.Item(14, i).Value = rowtemp("TotalDescuento")
                    dgv.Item(15, i).Value = rowtemp("RazonDescuento")
                    dgv.Item(16, i).Value = rowtemp("TotalPagar")
                    dgv.Item(17, i).Value = rowtemp("Abono")
                    dgv.Item(18, i).Value = rowtemp("Pagado")
                    dgv.Item(19, i).Value = rowtemp("Activo")
                    dgv.Item(20, i).Value = rowtemp("FechaPagado")
                    dgv.Item(21, i).Value = "Lps." & rowtemp("Saldo")
                    dgv.Item(22, i).Value = rowtemp("FechaEmision")
                    dgv.Item(23, i).Value = rowtemp("Recargo")
                    dgv.Item(24, i).Value = rowtemp("Efectivo")
                    dgv.Item(25, i).Value = rowtemp("tipoPago")
                    dgv.Item(26, i).Value = rowtemp("NoCorrelativo")
                    'txtDireccion.Text = rowtemp("Nombredepartamento") & " " & rowtemp("Nombremunicipio") & " " & rowtemp("NombreComunidad")

                    ventasMensuales = dgv.Item(24, i).Value + Val(ventasMensuales)
                    txtVentas.Text = ventasMensuales
                    dgv.Item(40, i).Value = rowtemp("razondescuento")
                    dgv.Item(45, i).Value = rowtemp("detallepago")
                    If rowtemp("posteado") = 1 Then
                        dgv.Item(46, i).Value = True
                    Else
                        dgv.Item(46, i).Value = False
                    End If
                    dgv.Item(47, i).Value = rowtemp("DEI")
                Next
                'lbTotalDeuda.Text = "Lps. " & deuda
                txtVentas.Text = Math.Round(ventasMensuales, 2)
            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
    Sub llenaGridClientesActivos(ByVal cadena As String, ByVal dgv As DataGridView)
        Try
            Dim SUBT, IMP, TOTAL As Double

            Dim item As Integer = 1
            dgv.Rows.Clear()
            tablatemp2 = ConsultarRegistro(cadena)
            If tablatemp2.Count > 0 Then
                dgv.RowCount = tablatemp2.Count
                For i As Integer = 0 To tablatemp2.Count - 1
                    rowtemp = tablatemp2.Item(i)

                    dgv.Item(1, i).Value = rowtemp("nombredepartamento")

                    dgv.Item(2, i).Value = rowtemp("nombremunicipio")
                    dgv.Item(3, i).Value = rowtemp("nombreComunidad")
                    If i > 0 Then
                        If dgv.Item(3, i - 1).Value <> dgv.Item(3, i).Value Then
                            item = 1
                        Else
                            item = item + 1
                        End If

                    End If
                    dgv.Item(0, i).Value = item & " de " & i + 1
                    dgv.Item(4, i).Value = rowtemp("Direccion")
                    dgv.Item(5, i).Value = rowtemp("idCliente")
                    dgv.Item(6, i).Value = rowtemp("Nombre")
                    dgv.Item(7, i).Value = rowtemp("Velocidad")
                    dgv.Item(8, i).Value = rowtemp("unidades")
                    dgv.Item(9, i).Value = rowtemp("Mensualidad")
                    'dgv.Item(10, i).Value = rowtemp("Moneda")
                    dgv.Item(11, i).Value = rowtemp("usuario")

                    TOTAL = Math.Round(Val(TOTAL) + Val(dgv.Item(9, i).Value), 2)
                    SUBT = Math.Round(TOTAL / 1.15)
                    IMP = Math.Round(SUBT * 0.15)

                    txtSubtotal.Text = SUBT

                Next
                txtImp.Text = IMP
                txtTotal.Text = TOTAL

            End If
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
End Class