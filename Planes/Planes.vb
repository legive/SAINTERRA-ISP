Imports MySql.Data.MySqlClient
Public Class planes
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Dim varid As String
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Dim idp As String
    Dim respuesta As Integer
    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        Try

            ErrorProvider1.Clear()

            If velocidad.Text = "" Then
                ErrorProvider1.SetError(velocidad, "Ingrese la velocidad")
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If
            If cmbMoneda.Text = "" Then
                ErrorProvider1.SetError(velocidad, "Ingrese la moneda")
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If
            If cmbUnidades.Text = "" Then
                ErrorProvider1.SetError(velocidad, "Ingrese las unidades")
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If
            If Precio.Text = "" Then
                ErrorProvider1.SetError(Precio, "Ingrese el precio")
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If
            adaptador = New MySqlDataAdapter("Select * from planes where Mensualidad= " & Precio.Text & " and Velocidad=" & velocidad.Text & "", frmmenu.conexion)
            Dim planes As String = "Select * from planes where Mensualidad= " & Precio.Text & " and Velocidad=" & velocidad.Text & ""
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "planes")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("planes").Rows


            If data.Tables("planes").Rows.Count = 0 Then
                'Dim agregar As DataRow
                'adaptador = New MySqlDataAdapter("SELECT * FROM planes ", frmmenu.conexion)
                'Dim oCommBuild2 As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                'adaptador.Fill(data, "planes")
                'agregar = Me.data.Tables("planes").NewRow()
                'agregar("Velocidad") = Me.velocidad.Text
                'agregar("unidades") = Me.cmbUnidades.Text
                'agregar("Mensualidad") = Me.Precio.Text
                'agregar("Moneda") = Me.cmbMoneda.Text
                'agregar("TipoPlan") = Me.cbTipo.Text
                'Me.data.Tables("planes").Rows.Add(agregar)
                'Me.adaptador.Update(data, "planes")
                'MsgBox("Datos agregados")
                'data.Clear()

                adaptador = New MySqlDataAdapter("Insert into planes values(0, " & velocidad.Text & ",'" & cmbUnidades.Text & "'," & Precio.Text & ",'" & cmbMoneda.Text & "', '" & cbTipo.Text & "')", frmMenu.conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "planes")
                MsgBox("Registro agregado exitosamente")
                data.Clear()
                Limpiar()
            Else
                Filatemporal = tablatemporal.Item(0)
                idp = Filatemporal("id")
                adaptador = New MySqlDataAdapter("update planes set  velocidad=" & velocidad.Text & ", unidades='" & cmbUnidades.Text & "', mensualidad=" & Precio.Text & ", moneda='" & cmbMoneda.Text & "', tipoPlan='" & cbTipo.Text & "' where id=" & idp & "", frmmenu.conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "planes")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
            End If
            llenaGrid("Select * from planes")
        Catch s As Exception
            data.Clear()
            MsgBox(s.ToString)
        End Try
salir:

    End Sub
    'Sub conectar()1
    '    Try
    '        conexion.ConnectionString = "server=" & frmMEnu.txtdireccionbd.Text & ";Port=3306;database=" & frmMEnu.txtbd.Text & ";uid=" & frmMEnu.txtuser.Text & ";pwd=" & frmMEnu.txtpsw.Text & ";"
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
            Return tablatemp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "ERROR")
            Return tablatemp
        End Try
    End Function
    Sub llenaGrid(ByVal cadena As String)
        Try

            dgvInstalacion.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)

            If tablatemp.Count > 0 Then
                dgvInstalacion.RowCount = tablatemp.Count
            Else
                dgvInstalacion.RowCount = 1
            End If

            For l As Integer = 0 To tablatemp.Count - 1
                rowtemp = tablatemp.Item(l)



                dgvInstalacion.Item(0, l).Value = rowtemp("id")
                dgvInstalacion.Item(1, l).Value = rowtemp("velocidad")
                dgvInstalacion.Item(2, l).Value = rowtemp("unidades")
                dgvInstalacion.Item(3, l).Value = rowtemp("mensualidad")
                dgvInstalacion.Item(4, l).Value = rowtemp("moneda")
                dgvInstalacion.Item(5, l).Value = rowtemp("TipoPlan")

            Next

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub

    Sub Limpiar()
        velocidad.Text = ""
        Precio.Text = ""
    End Sub


    Private Sub InventarioEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectar()1
        Limpiar()
        dgvInstalacion.Rows.Clear()
        llenaGrid("Select * from planes ORDER BY MENSUALIDAD")
    End Sub

    Private Sub dgvInstalacion_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminar.Click
        Try
            respuesta = MsgBox("Desea eliminar el registro?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                adaptador = New MySqlDataAdapter("Select * from planes where id = " & idp & "", frmmenu.conexion)
                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "planes")

                If data.Tables("planes").Rows.Count > 0 Then

                    adaptador = New MySqlDataAdapter("Delete from planes where id=" & idp & "", frmmenu.conexion)
                    oCommBuild = New MySqlCommandBuilder(adaptador)
                    adaptador.Fill(data, "planes")
                    MsgBox("Registro eliminado exitosamente")
                    data.Clear()
                    'Llama la funsion de limpiar
                    Limpiar()
                    'Se actualiza el grid para ver el nuevo registro agregado
                    llenaGrid("SELECT * FROM planes ")
                    velocidad.Focus()
                End If
            End If
        Catch s As Exception
            MsgBox(s.ToString)
        End Try
    End Sub



    Private Sub dgvInstalacion_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvInstalacion.MouseDoubleClick
        Try
            idp = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value
            Pagos.txtVelocidad.Text = dgvInstalacion.Item(1, dgvInstalacion.CurrentRow.Index).Value
            Pagos.txtUnidades.Text = dgvInstalacion.Item(2, dgvInstalacion.CurrentRow.Index).Value
            Pagos.Mensualidad.Text = dgvInstalacion.Item(3, dgvInstalacion.CurrentRow.Index).Value
            Pagos.txtMoneda.Text = dgvInstalacion.Item(4, dgvInstalacion.CurrentRow.Index).Value
            Pagos.txtTipoPlan.Text = dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value

            Me.Close()
        Catch
        End Try
    End Sub

    Private Sub dgvInstalacion_Click(sender As Object, e As EventArgs) Handles dgvInstalacion.Click
        Try
            idp = dgvInstalacion.Item(0, dgvInstalacion.CurrentRow.Index).Value
            velocidad.Text = dgvInstalacion.Item(1, dgvInstalacion.CurrentRow.Index).Value
            cmbUnidades.Text = dgvInstalacion.Item(2, dgvInstalacion.CurrentRow.Index).Value
            Precio.Text = dgvInstalacion.Item(3, dgvInstalacion.CurrentRow.Index).Value
            cmbMoneda.Text = dgvInstalacion.Item(4, dgvInstalacion.CurrentRow.Index).Value
            cbTipo.Text = dgvInstalacion.Item(5, dgvInstalacion.CurrentRow.Index).Value
        Catch
        End Try
    End Sub
End Class