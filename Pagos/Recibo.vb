Imports MySql.Data.MySqlClient
Public Class Recibo
    Dim INS As New Instalación
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Dim oCommBuild As MySqlCommandBuilder
    Private data As New DataSet
    Dim varid As String
    Private tablatemp, tablatemp2, tablatemp3, tablatem4 As DataRowCollection
    Private rowtemp As DataRow
    Public NoCorrelativoFicha, DEI, descuentodias, descuentoHoras, tp, diasajuste As Integer
    Dim fechaPago, atlantida As String
    Dim respuesta, dolar, isv, ISVE As Integer

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        dgvPagos.CurrentCell.Selected = False
        ' Capturar todo el área del formulario
        efectivo.Refresh()
        Dim gr As Graphics = Me.CreateGraphics
        ' Tamaño de lo que queremos copiar
        Dim fSize As Size = Me.Size
        ' Creamos el bitmap con el área que vamos a capturar
        ' En este caso, con el tamaño del formulario actual
        Dim bm As New Bitmap(fSize.Width - 25, fSize.Height - 55, gr)
        ' Un objeto Graphics a partir del bitmap
        Dim gr2 As Graphics = Graphics.FromImage(bm)
        ' Copiar el área de la pantalla que ocupa el formulario
        gr2.CopyFromScreen(Me.Location.X + 10, Me.Location.Y + 22, 0, 0, fSize)

        ' Asignamos la imagen al PictureBox
        'Me.picCaptura.Image = bm
        Clipboard.SetDataObject(bm, True)
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
        StatusStrip1.Visible = False
        dgvPagos.CurrentCell.Selected = False
        Me.TextBox1.Select()
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview

        PrintForm1.Print()
        StatusStrip1.Visible = True
    End Sub

    Dim entro, entro2, entro3 As Boolean
    Dim entroDei As Boolean
    Dim navegacion = 0, TipoPago As Integer
    Public idInstalacion, plan As String
    Dim saldoDolar, filaspagos As Integer
    Dim cambio, cambioant, mora, filasmora As Integer
    Public total1 As Double = 0.0
    Public saldoant As Double

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
    Private Sub Recibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        total.Text = 0
        efectivo.Text = 0
        total1 = 0
        txtAbono.Text = 0
        saldo.Text = 0
        dgvPagos.Rows.Clear()
        saldoant = 0

        llenaGrid("Select No, NoDeI, mes, anio, RECARGO, idcliente, nombre, mensualidad, totaldescuento, abonoa, abonos, razondescuento, fechaemision, fechapagado, efectivo, totalpagar, totalmes, saldo, cambioant from vistapagos where idCliente='" & id.Text & "' and fechaemision='" & fecha.Value.ToString("yyyy-MM-dd") & "' and pagado=1 order by  No")
        Try
            'dgvPagos.CurrentCell.Selected = False
        Catch
        End Try
        StatusStrip1.Focus()
        Me.TextBox1.Select()

    End Sub
    Sub llenaGrid(ByVal cadena As String)
        Try
            dgvPagos.Rows.Clear()
            tablatemp3 = ConsultarRegistro(cadena)
            filaspagos = 0
            Dim mensualidad As Double
            If tablatemp3.Count > 0 Then
                filaspagos = 1
                dgvPagos.RowCount = tablatemp3.Count
                Dim abonoa As Double = 0
                For i As Integer = 0 To tablatemp3.Count - 1
                    rowtemp = tablatemp3.Item(i)
                    dgvPagos.Item(0, i).Value = i + 1
                    If plan.Contains("TV") Then
                        dgvPagos.Item(1, i).Value = plan & " MES DE " & rowtemp("Mes").ToString.Remove(0, 2) & " DE " & rowtemp("Anio")
                    Else
                        dgvPagos.Item(1, i).Value = "INTERNET MES DE " & rowtemp("Mes").ToString.Remove(0, 2) & " DE " & rowtemp("Anio")
                    End If

                    If saldoant < 0 Then
                        saldoant = saldoant * -1
                    End If


                    dgvPagos.Item(2, i).Value = rowtemp("Mensualidad")
                    mensualidad = mensualidad + dgvPagos.Item(2, i).Value
                    saldoant = rowtemp("saldo") - mensualidad
                    If saldoant < 0 Then
                        saldoant = 0
                    End If
                    dgvPagos.Item(3, i).Value = rowtemp("recargo") + saldoant
                    If rowtemp("cambioant") > 0 Then
                        dgvPagos.Item(4, i).Value = rowtemp("totaldescuento") + rowtemp("cambioant")
                    Else
                        dgvPagos.Item(4, i).Value = rowtemp("totaldescuento")
                    End If

                    If rowtemp("efectivo") > 0 Then
                        If Val(rowtemp("abonoa")) > 0 Then
                            abonoa = Val(rowtemp("abonoa"))

                        End If
                    Else
                        abonoa = 0
                    End If
                    If rowtemp("cambioant") > 0 Then
                        dgvPagos.Item(5, i).Value = Val(rowtemp("totalmes")) - Val(rowtemp("cambioant"))
                    Else
                        dgvPagos.Item(5, i).Value = Val(rowtemp("totalmes"))
                    End If


                    'dgvPagos.Item(5, i).Value = Val(rowtemp("mensualidad")) - rowtemp("totaldescuento") + Val(rowtemp("recargo")) + saldoant
                    total1 = Val(dgvPagos.Item(5, i).Value)
                    total.Text = Val(total1) + Val(total.Text)
                    If rowtemp("efectivo") > 0 Then
                        efectivo.Text = rowtemp("efectivo")
                    End If
                Next
                'If tablatemp3.Count > 1 Then
                '    For i As Integer = 0 To tablatemp3.Count - 1
                '        rowtemp = tablatemp3.Item(i)
                '        dgvPagos.Item(0, i).Value = i + 1
                '        If plan.Contains("TV") Then
                '            dgvPagos.Item(1, i).Value = plan & " MES DE " & rowtemp("Mes").ToString.Remove(0, 2) & " DE " & rowtemp("Anio")
                '        Else
                '            dgvPagos.Item(1, i).Value = "INTERNET MES DE " & rowtemp("Mes").ToString.Remove(0, 2) & " DE " & rowtemp("Anio")
                '        End If
                '        '    If saldoant < 0 Then
                '        '        saldoant = saldoant * -1

                '        '    End If
                '        '    If rowtemp("saldo") <> rowtemp("totalpagar") Then
                '        '        saldoant = rowtemp("totalpagar") - rowtemp("saldo")
                '        '    End If
                '        '    If saldoant < 0 Then
                '        '        saldoant = saldoant * -1

                '        '    End If
                '        '    If saldoant = rowtemp("Mensualidad") Then
                '        '        saldoant = 0
                '        '    End If
                '        '    dgvPagos.Item(2, i).Value = rowtemp("Mensualidad")

                '        '    dgvPagos.Item(3, i).Value = rowtemp("recargo") + saldoant

                '        '    dgvPagos.Item(4, i).Value = rowtemp("totaldescuento")
                '        '    'dgvPagos.Item(5, i).Value = rowtemp("abonos")
                '        '    'If dgvPagos.Item(5, i).Value < 0 Then
                '        '    '    dgvPagos.Item(5, i).Value = 0
                '        '    'End If
                '        '    If rowtemp("efectivo") > 0 Then
                '        '        If Val(rowtemp("abonoa")) > 0 Then
                '        '            abonoa = Val(rowtemp("abonoa"))

                '        '        End If
                '        '    Else
                '        '        abonoa = 0
                '        '    End If

                '        '    dgvPagos.Item(5, i).Value = Val(rowtemp("mensualidad")) - rowtemp("totaldescuento") + Val(rowtemp("recargo")) + saldoant
                '        '    total1 = Val(dgvPagos.Item(5, i).Value)
                '        '    total.Text = Val(total1) + Val(total.Text)
                '        '    If rowtemp("efectivo") > 0 Then
                '        '        efectivo.Text = rowtemp("efectivo")
                '        '    End If
                '    Next
                'End If
                fecha.Value = rowtemp("fechapagado")

                'efectivo.Text = rowtemp("efectivo")
                If Val(total.Text) > Val(efectivo.Text) Then
                    saldo.Text = Val(total.Text) - Val(efectivo.Text)
                    TextBox1.Text = "0"
                Else
                    txtAbono.Text = Val(efectivo.Text) - Val(total.Text)
                    TextBox1.Text = "0"
                End If

                If rowtemp("pagado") = 1 Then
                    lbPagado.Visible = True
                Else
                    lbPagado.Visible = False
                End If
            End If
            dgvPagos.ClearSelection()
        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
            entro = True
        End Try
        TextBox1.Focus()
        dgvPagos.ClearSelection()
    End Sub
End Class