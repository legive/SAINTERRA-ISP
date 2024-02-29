Imports MySql.Data.MySqlClient
Public Class salidas2
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Public varid, identidad, consulta1, consulta2, consulta3, identidadPagos, Fact As String
    Public respuesta, formulario, ActivoD, cambioFact As Integer
    Public credliq, creditoTar, isr2 As String
    Dim entro As Boolean
    Dim NDEI As Integer
    Dim creditostring, fechaCompra As String
    Dim CONSULTAvar As Integer

    Sub limpiar()
        txtFac.Text = ""
        txtDescripcion.Text = ""
        txtMonto.Text = 0
        txtMontoPagado.Text = 0
        txtObservaciones.Text = ""
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            limpiar()
            lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
            Eliminar.Enabled = False
            btnModificar.Enabled = False
            btnGuardar.Enabled = True
        Catch
        End Try
    End Sub
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
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtFac.Text.Length = 11 Then
                txtFac.Text = "000-000-00-0000000000"
            End If
            'If txtFac.Text = "" Then
            '    ErrorProvider1.SetError(txtFac, "Ingrese el número de Factura")
            '    txtFac.Focus()
            '    GoTo salir
            'Else
            '    ErrorProvider1.Clear()
            'End If
            If txtDescripcion.Text = "" Then
                ErrorProvider1.SetError(txtDescripcion, "Ingrese la descripcion")
                txtDescripcion.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

            If txtMonto.Text = "" Then
                ErrorProvider1.SetError(txtMonto, "Ingrese el monto")
                txtMonto.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            Dim cre As Integer
            If cbcredito.CheckState = CheckState.Checked Then
                cre = 1
            ElseIf cbcredito.CheckState = CheckState.Unchecked Then
                dtpCredito.Value = dtpFecha.Value
                cre = 0
            End If

            Dim ISR As Integer
            If CBISR.CheckState = CheckState.Checked Then
                ISR = 1
            ElseIf CBISR.CheckState = CheckState.Unchecked Then
                ISR = 0
            End If

            Dim credEsp As Integer
            If cbLiquidacion.CheckState = CheckState.Checked Then
                credEsp = 1
            ElseIf cbLiquidacion.CheckState = CheckState.Unchecked Then
                credEsp = 0


            End If
            If txtMontoPagado.Text = "" Or txtMontoPagado.Text = "0" Then
                txtMontoPagado.Text = txtMonto.Text
            End If
GUARDAR:
            respuesta = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                If txtFac.Text = "000-000-00-0000000000" Then
                    Dim s As String = "Select * from salidas where Nfact='" & txtFac.Text & "' and Correlativo= " & lbcorrelativo.Text & ""
                    adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")
                Else
                    Dim s As String = "Select * from salidas where Nfact='" & txtFac.Text & "' "
                    adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")
                End If

                If data.Tables("salidas").Rows.Count = 0 Then
                    Dim N As String = "Insert into salidas (Nfact, Fecha, Descripcion, Monto, MontoPagado, Observaciones, Tipo1, Tipo2, Mes, Anio, correlativo, creD, ISR, fechacred, mescred, añocred, credesp) values('" & txtFac.Text & "', '" & dtpFecha.Value.ToString("yyyy-MM-dd") & "','" & txtDescripcion.Text.ToUpper & "','" & txtMonto.Text & "', " & txtMontoPagado.Text & ",'" & txtObservaciones.Text.ToUpper & "','" & cmbTipo.Text & "', '" & cmbSalida.Text & "', '" & dtpFecha.Value.Month & "', '" & dtpFecha.Value.Year & "', " & lbcorrelativo.Text & ", " & cre & " , " & ISR & ", '" & dtpCredito.Value.ToString("yyyy-MM-dd") & "', '" & dtpCredito.Value.Month & "', '" & dtpCredito.Value.Year & "', " & credEsp & ")"

                    adaptador = New MySqlDataAdapter("Insert into salidas (Nfact, Fecha, Descripcion, Monto, MontoPagado, Observaciones, Tipo1, Tipo2, Mes, Anio, correlativo, creD, ISR, fechacred, mescred, añocred, credesp, responsable) values('" & txtFac.Text & "', '" & dtpFecha.Value.ToString("yyyy-MM-dd") & "','" & txtDescripcion.Text.ToUpper & "','" & txtMonto.Text & "', " & txtMontoPagado.Text & ",'" & txtObservaciones.Text.ToUpper & "','" & cmbTipo.Text & "', '" & cmbSalida.Text & "', '" & dtpFecha.Value.Month & "', '" & dtpFecha.Value.Year & "', " & lbcorrelativo.Text & ", " & cre & " , " & ISR & ", '" & dtpCredito.Value.ToString("yyyy-MM-dd") & "', '" & dtpCredito.Value.Month & "', '" & dtpCredito.Value.Month & "', " & credEsp & ", '" & cmbResponsable.Text & "')", frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")
                    MsgBox("Registro agregado exitosamente")
                    data.Clear()
                    btnGuardar.Enabled = True
                    'Llama la funsion de limpiar
                    limpiar()

                Else
                    tablatemp = ConsultarRegistro("Select * from salidas where Nfact='" & txtFac.Text & "' ")
                    If tablatemp.Count > 0 Then

                        rowtemp = tablatemp.Item(0)
                        MsgBox("El registro ya existe con fecha" & rowtemp("fecha") & "")
                    End If
                End If
            End If
            cbcredito.CheckState = CheckState.Unchecked
            If cbTodos.CheckState = CheckState.Unchecked Then
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' order BY Fecha ", dgv1)
            Else
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " order BY Fecha ", dgv1)
            End If
            lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")


        Catch s As Exception
            MsgBox(s.ToString)
        End Try

salir:
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
    Sub actualizarfilaGrid(ByVal cadena As String, ByVal dg As DataGridView)
        Try
            'dg.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                'dg.RowCount = tablatemp.Count
                Dim total, no As Double
                total = 0
                no = 0
                Dim l As Integer = dgv1.CurrentRow.Index
                rowtemp = tablatemp.Item(0)
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
                total = Val(total) + Val(dg.Item(3, l).Value)
                no = no + 1
                lbtotal.Text = "Total: " & total
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



            Else
                'dg.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub llenaGrid(ByVal cadena As String, ByVal dg As DataGridView)
        Try
            dg.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dg.RowCount = tablatemp.Count
                Dim total, no As Double
                total = 0
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
                    total = Val(total) + Val(dg.Item(3, l).Value)
                    no = no + 1
                    lbtotal.Text = "Total: " & total
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
            Else
                dg.Rows.Clear()
            End If
        Catch m As Exception
        End Try
    End Sub

    Private Sub salidas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbSalida.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
        cmbAnio.SelectedIndex = 0
        For i As Integer = 0 To cmbAnio.Items.Count - 1

            If Today.Year.ToString = cmbAnio.Items.Item(i).ToString Then
                cmbAnio.SelectedIndex = i
                GoTo salir
            End If
        Next
salir:

        For i As Integer = 0 To cmbMes.Items.Count - 1

            If Today.Month - 1 = i Then
                cmbMes.SelectedIndex = i
                GoTo salir2
            End If
        Next
salir2:
        'cmbMes.SelectedIndex = 0
        cambioFact = 0
        lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
        txtFac.Focus()

    End Sub
    Sub CONSULTA()
        comprasCredito()

        If cbmostrarcredito.Checked = CheckState.Checked Then
            creditostring = "and cred=0"
        ElseIf cbmostrarcredito.Checked = CheckState.Unchecked Then
            creditostring = ""
        End If
        If cbMostrarISR.CheckState = CheckState.Checked Then
            If cbTodos.CheckState = CheckState.Checked Then
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " " & isr2 & " " & creditostring & " order BY Fecha ", dgv1)
            ElseIf cbTodos.CheckState = CheckState.Unchecked Then
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "'  " & creditostring & " " & isr2 & " order BY Fecha ", dgv1)
            End If
        Else
            If cbTodos.CheckState = CheckState.Checked Then
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " " & creditostring & " order BY Fecha ", dgv1)
            ElseIf cbTodos.CheckState = CheckState.Unchecked Then
                llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' " & creditostring & " order BY Fecha ", dgv1)
            End If

        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMes.SelectedIndexChanged
        CONSULTA()
        'comprasCredito()

        'If cbmostrarcredito.Checked = CheckState.Checked Then
        '    creditostring = "and cred=0"
        'ElseIf cbmostrarcredito.Checked = CheckState.Unchecked Then
        '    creditostring = ""
        'End If
        'If cbMostrarISR.CheckState = CheckState.Checked Then
        '    If cbTodos.CheckState = CheckState.Checked Then
        '        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and ISR=1 " & creditostring & " order BY Fecha ", dgv1)
        '    ElseIf cbTodos.CheckState = CheckState.Unchecked Then
        '        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' and ISR=0 " & creditostring & " order BY Fecha ", dgv1)
        '    End If
        'Else
        '    If cbTodos.CheckState = CheckState.Checked Then
        '        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " " & creditostring & " order BY Fecha ", dgv1)
        '    ElseIf cbTodos.CheckState = CheckState.Unchecked Then
        '        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' " & creditostring & " order BY Fecha ", dgv1)
        '    End If

        'End If

    End Sub



    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        CONSULTA()
    End Sub



    Private Sub dgv2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellClick
        Try

            entro = True
            txtFac.Text = dgv2.Item(0, dgv2.CurrentRow.Index).Value.ToString
            dtpFecha.Value = dgv2.Item(1, dgv2.CurrentRow.Index).Value.ToString
            txtDescripcion.Text = dgv2.Item(2, dgv2.CurrentRow.Index).Value.ToString
            txtMonto.Text = dgv2.Item(3, dgv2.CurrentRow.Index).Value.ToString
            txtObservaciones.Text = dgv2.Item(4, dgv2.CurrentRow.Index).Value.ToString

            Dim indice As Integer
            indice = dgv2.CurrentRow.Index
            For i As Integer = 0 To cmbTipo.Items.Count - 1
                cmbTipo.SelectedIndex = i
                If dgv2.Item(5, indice).Value.ToString = cmbTipo.Text.ToString Then
                    GoTo salir
                End If
            Next
salir:
            Dim indice2 As Integer
            indice2 = dgv2.CurrentRow.Index
            For i As Integer = 0 To cmbSalida.Items.Count - 1
                cmbSalida.SelectedIndex = i
                If dgv2.Item(6, indice).Value.ToString = cmbSalida.Text.ToString Then
                    GoTo salir2
                End If
            Next
salir2:
            lbcorrelativo.Text = dgv2.Item(9, dgv2.CurrentRow.Index).Value.ToString
            btnModificar.Enabled = True
            Eliminar.Enabled = True
            btnGuardar.Enabled = False
        Catch

        End Try
    End Sub

    Private Sub dgv1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellClick
        Try
            CONSULTAvar = 1
            entro = True
            txtFac.Text = dgv1.Item(0, dgv1.CurrentRow.Index).Value.ToString
            txtNfac.Text = dgv1.Item(0, dgv1.CurrentRow.Index).Value.ToString
            dtpFecha.Value = dgv1.Item(1, dgv1.CurrentRow.Index).Value.ToString
            txtDescripcion.Text = dgv1.Item(2, dgv1.CurrentRow.Index).Value.ToString
            txtMonto.Text = dgv1.Item(3, dgv1.CurrentRow.Index).Value.ToString
            txtMontoPagado.Text = dgv1.Item(4, dgv1.CurrentRow.Index).Value.ToString
            txtObservaciones.Text = dgv1.Item(5, dgv1.CurrentRow.Index).Value.ToString
            If dgv1.Item(11, dgv1.CurrentRow.Index).Value.ToString = "1" Then
                cbcredito.CheckState = CheckState.Checked
            Else
                cbcredito.CheckState = CheckState.Unchecked

            End If

            Dim indice As Integer
            indice = dgv1.CurrentRow.Index
            For i As Integer = 0 To cmbTipo.Items.Count - 1

                If dgv1.Item(6, indice).Value.ToString = cmbTipo.Items.Item(i).ToString Then
                    cmbTipo.SelectedIndex = i
                    GoTo salir
                End If
            Next
salir:
            btnModificar.Enabled = True
            Eliminar.Enabled = True
            btnGuardar.Enabled = False
            Dim indice2 As Integer
            indice2 = dgv1.CurrentRow.Index
            For i As Integer = 0 To cmbSalida.Items.Count - 1

                If dgv1.Item(7, indice).Value.ToString = cmbSalida.Items.Item(i).ToString Then
                    cmbSalida.SelectedIndex = i
                    GoTo salir2
                End If
            Next
salir2:
            lbcorrelativo.Text = dgv1.Item(10, dgv1.CurrentRow.Index).Value.ToString
            If dgv1.Item(12, dgv1.CurrentRow.Index).Value.ToString = "Si" Then
                CBISR.CheckState = CheckState.Checked
            Else
                CBISR.CheckState = CheckState.Unchecked

            End If
            dtpCredito.Value = dgv1.Item(13, dgv1.CurrentRow.Index).Value.ToString
            If dgv1.Item(14, dgv1.CurrentRow.Index).Value.ToString = "Si" Then
                cbLiquidacion.CheckState = CheckState.Checked
            Else
                cbLiquidacion.CheckState = CheckState.Unchecked

            End If
            Try
                For i As Integer = 0 To cmbResponsable.Items.Count - 1

                    If dgv1.Item(responsable.Index, indice).Value.ToString = cmbResponsable.Items.Item(i).ToString Then
                        cmbResponsable.SelectedIndex = i
                        GoTo salir3
                    End If
                Next
            Catch
            End Try
salir3:


            btnModificar.Enabled = True
            Eliminar.Enabled = True
            btnGuardar.Enabled = False
            CONSULTAvar = 0
        Catch s As Exception

        End Try
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then

                If txtNfac.Text = "000-000-00-0000000000" Then
                    Dim s As String = "Select * from salidas where Nfact='" & txtFac.Text & "' and Correlativo= " & lbcorrelativo.Text & ""
                    adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")

                    If data.Tables("salidas").Rows.Count > 0 Then
                        adaptador = New MySqlDataAdapter("Delete from salidas where  Correlativo=" & lbcorrelativo.Text & "", frmMenu.conexion)
                        oCommBuild = New MySqlCommandBuilder(adaptador)
                        adaptador.Fill(data, "salidas")
                        MsgBox("Registro eliminado exitosamente")
                        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' order BY Fecha ", dgv1)

                        btnGuardar.Enabled = True
                        Eliminar.Enabled = False
                        btnModificar.Enabled = False
                    Else
                        MsgBox("El registro no existe")
                    End If
                Else
                    Dim s As String = "Select * from salidas where Nfact='" & txtNfac.Text & "' "
                    adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                    Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")
                    If data.Tables("salidas").Rows.Count > 0 Then
                        adaptador = New MySqlDataAdapter("Delete from salidas where Nfact='" & txtNfac.Text & "' and Correlativo=" & lbcorrelativo.Text & "", frmMenu.conexion)
                        oCommBuild = New MySqlCommandBuilder(adaptador)
                        adaptador.Fill(data, "salidas")
                        MsgBox("Registro eliminado exitosamente")

                        llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' order BY Fecha ", dgv1)

                        btnGuardar.Enabled = True
                        Eliminar.Enabled = False
                        btnModificar.Enabled = False
                    Else
                        MsgBox("El registro no existe")
                    End If
                End If


            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
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



    Private Sub cbMostrarISR_CheckedChanged(sender As Object, e As EventArgs) Handles cbMostrarISR.CheckedChanged
        If cbMostrarISR.CheckState = CheckState.Checked Then
            isr2 = "and ISR=1 "
        ElseIf cbMostrarISR.CheckState = CheckState.Unchecked Then
            isr2 = ""
        End If

        consultaCriterios()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoPagado.KeyPress
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

    Private Sub cbmostrarcredito_CheckedChanged(sender As Object, e As EventArgs) Handles cbmostrarcredito.CheckedChanged
        If cbmostrarcredito.CheckState = CheckState.Checked Then
            creditoTar = " and cred=1 "
        ElseIf cbmostrarcredito.CheckState = CheckState.Unchecked Then
            creditoTar = ""
        End If
        consultaCriterios()

    End Sub
    Sub consultaCriterios()

        If cbMostrarISR.Checked = True Then
            llenaGrid("SELECT * FROM salidas where month(fecha)='" & cmbMes.SelectedIndex + 1 & "' and year(fecha) ='" & cmbAnio.Text & "' " & isr2 & " " & credliq & " " & creditoTar & " order BY Fecha ", dgv1)

        Else
            llenaGrid("SELECT * FROM salidas where month(fechacred)='" & cmbMes.SelectedIndex + 1 & "' and year(fechacred) ='" & cmbAnio.Text & "' " & isr2 & " " & credliq & " " & creditoTar & " order BY Fecha ", dgv1)

        End If
        '   
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        dtpCredito.Value = dtpFecha.Value
    End Sub

    Private Sub cbLiquidacion2_CheckedChanged(sender As Object, e As EventArgs) Handles cbLiquidacion2.CheckedChanged
        cbMostrarISR.Checked = False
        cbmostrarcredito.Checked = False
        cbTodos.Checked = False
        If cbLiquidacion2.Checked = True Then
            credliq = " And credEsp = 1 "
        ElseIf cbLiquidacion2.Checked = False Then
            credliq = ""
        End If
        consultaCriterios()
    End Sub

    Private Sub cbcredito_CheckedChanged(sender As Object, e As EventArgs) Handles cbcredito.CheckedChanged
        If cbcredito.Checked = False Then
            dtpCredito.Value = dtpFecha.Value
        End If
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub TextBox1_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles Busqueda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            llenaGrid("SELECT * FROM salidas where Descripcion like '%" & Busqueda.Text & "%' or Observaciones like '%" & Busqueda.Text & "%' or Nfact like '%" & Busqueda.Text & "%' or MOnto like '%" & Busqueda.Text & "%' order by fecha ", dgv1)
        End If
    End Sub

    Private Sub cbComprasCredito_CheckedChanged(sender As Object, e As EventArgs) Handles cbComprasCredito.CheckedChanged
        comprasCredito()
    End Sub

    Private Sub cbLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles cbLiquidacion.CheckedChanged

    End Sub

    Sub comprasCredito()
        If cbComprasCredito.Checked = True Then
            fechaCompra = "month(fecha)='" & cmbMes.SelectedIndex + 1 & "' and year(fecha) ='" & cmbAnio.Text & "'"
        ElseIf cbComprasCredito.Checked = False Then
            fechaCompra = "month(fechacred)='" & cmbMes.SelectedIndex + 1 & "' and year(fechacred) ='" & cmbAnio.Text & "'"

        End If
    End Sub
    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            llenaGrid("SELECT * FROM salidas where Descripcion like '%" & txtDescripcion.Text & "%' ", dgv1)
        End If
    End Sub
    Sub Excel(ByVal ElGrid As DataGridView)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet


        exLibro = exApp.Workbooks.Open(Application.StartupPath & "\FORMATOS\GASTOS.xlsx")
        exHoja = exLibro.Worksheets.Item(1)
        Dim columnaEx As Integer = 2

        Dim NCol As Integer = ElGrid.ColumnCount
        Dim NRow As Integer = ElGrid.RowCount
        For i As Integer = 1 To NCol

            If ElGrid.Columns(i - 1).Visible = True Then
                exHoja.Cells.Item(8, columnaEx) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                columnaEx = columnaEx + 1
            End If

        Next
        ProgressBar1.Maximum = NRow
        columnaEx = 1
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
            columnaEx = 1
        Next
        ProgressBar1.Value = 0


        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()
        exHoja.Cells.Item(6, 9) = cmbMes.Text
        exHoja.Cells.Item(6, 10) = cmbAnio.Text

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing
    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Excel(dgv1)
    End Sub

    Private Sub txtFac_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            llenaGrid("SELECT * FROM salidas where NFact like '%" & txtFac.Text & "%' ", dgv1)
        End If
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890-F", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        'Dim ro
        If CONSULTAvar = 0 Then
            If cbTodos.Checked = CheckState.Unchecked Then
                If cmbTipo.Text = "TELEFONO" Or cmbTipo.Text = "ENERGIA" Or cmbTipo.Text = "IMPUESTO" Or cmbTipo.Text = "SALARIO" Or cmbTipo.Text = "PRESTAMO" Or cmbTipo.Text = "ALOJAMIENTO" Or cmbTipo.Text = "CUENTAS POR COBRAR" Then
                    cmbSalida.SelectedIndex = 1
                Else
                    cmbSalida.SelectedIndex = 0
                End If
                If cbTodos.CheckState = CheckState.Checked Then
                    llenaGrid("SELECT * FROM salidas where " & fechaCompra & "  order BY Fecha ", dgv1)
                ElseIf cbTodos.CheckState = CheckState.Unchecked Then
                    llenaGrid("SELECT * FROM salidas where " & fechaCompra & " and TIPO1='" & cmbTipo.Text & "' order BY Fecha ", dgv1)
                End If
            End If
            CONSULTA()
        End If
        'lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
        'dgv1.SelectedRows()¡
    End Sub

    Private Sub cmbSalida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSalida.SelectedIndexChanged
        'lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
    End Sub

    Private Sub btnModificar_Click_1(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtFac.Text = "" Or txtFac.Text = "0" Then
                txtFac.Text = lbcorrelativo.Text

            End If
            If txtFac.Text = "" Then
                ErrorProvider1.SetError(txtFac, "Ingrese el número de Factura")
                txtFac.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If
            If txtDescripcion.Text = "" Then
                ErrorProvider1.SetError(txtDescripcion, "Ingrese la descripcion")
                txtDescripcion.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If

            If txtMonto.Text = "" Then
                ErrorProvider1.SetError(txtMonto, "Ingrese el monto")
                txtMonto.Focus()
                GoTo salir
            Else
                ErrorProvider1.Clear()

            End If
            Dim cre As Integer
            If cbcredito.CheckState = CheckState.Checked Then
                cre = 1
            ElseIf cbcredito.CheckState = CheckState.Unchecked Then
                cre = 0
            End If
GUARDAR:    Dim ISR As Integer
            If CBISR.CheckState = CheckState.Checked Then
                ISR = 1
            ElseIf CBISR.CheckState = CheckState.Unchecked Then
                ISR = 0
            End If

            Dim credesp As Integer
            If cbLiquidacion.CheckState = CheckState.Checked Then
                credesp = 1
            ElseIf cbLiquidacion.CheckState = CheckState.Unchecked Then
                credesp = 0
            End If
            respuesta = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Dim s As String = "Select * from salidas where Nfact='" & txtFac.Text & "' and Correlativo= " & lbcorrelativo.Text & ""

                adaptador = New MySqlDataAdapter(s, frmMenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "salidas")
                If data.Tables("salidas").Rows.Count > 0 Then
                    Dim a As String = "update salidas set  Descripcion='" & txtDescripcion.Text.ToUpper & "', Monto='" & txtMonto.Text & "', MontoPagado=" & txtMontoPagado.Text & ", Observaciones='" & txtObservaciones.Text.ToUpper & "', Tipo1='" & cmbTipo.Text & "', Tipo2= '" & cmbSalida.Text & "', Mes='" & dtpFecha.Value.Month & "', Anio='" & dtpFecha.Value.Year & "', cred=" & cre & ", fecha='" & dtpFecha.Value.ToString("yyyy-MM-dd") & "', ISR=" & ISR & ", fechacred='" & dtpCredito.Value.ToString("yyyy-MM-dd") & "', mescred='" & dtpCredito.Value.Month & "', añocred='" & dtpCredito.Value.Year & "', credesp=" & credesp & ", responsable='" & cmbResponsable.Text & "' where Nfact='" & txtFac.Text & "' and correlativo=" & lbcorrelativo.Text & ""
                    adaptador = New MySqlDataAdapter(a, frmMenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "salidas")
                    MsgBox("Registro agregado exitosamente")
                    data.Clear()
                    btnGuardar.Enabled = True
                    btnModificar.Enabled = False
                    Eliminar.Enabled = False
                    'Llama la funsion de limpiar
                    limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    txtFac.Focus()
                Else
                    respuesta = MsgBox("Usted intenta cambiar el número de factura del registro actual, se procederá a elinar el registro y agregarlo con el nuevo número", MsgBoxStyle.YesNo, "Atención")
                    If respuesta = 6 Then
                        cambioFact = 1
                        Eliminar_Click(Eliminar, e)
                        btnGuardar.Enabled = True
                        btnModificar.Enabled = False
                    End If

                End If
            End If
            cbcredito.CheckState = CheckState.Unchecked
            If cbTodos.CheckState = CheckState.Unchecked Then
                actualizarfilaGrid("SELECT * FROM salidas where  TIPO1='" & cmbTipo.Text & "' and Correlativo =" & dgv1.Item(10, dgv1.CurrentRow.Index).Value & " order BY Fecha, Tipo1 ", dgv1)
            Else
                actualizarfilaGrid("SELECT * FROM salidas where Correlativo =" & dgv1.Item(10, dgv1.CurrentRow.Index).Value & " order BY Fecha ", dgv1)
            End If
            lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub

    Private Sub cbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodos.CheckedChanged
        credliq = ""
        creditoTar = ""
        isr2 = ""
        If cbTodos.Checked = True Then
            consultaCriterios()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lbcorrelativo.Text = incrementaCodigo("Select * from salidas order by Correlativo", "Correlativo")
        txtFac.Text = ""
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        Eliminar.Enabled = False

    End Sub
End Class