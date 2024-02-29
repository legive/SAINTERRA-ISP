Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmDesconexiones
    Dim sRenglon As String = Nothing
    Dim strStreamW As Stream = Nothing
    Dim strStreamWriter As StreamWriter = Nothing
    Dim ContenidoArchivo As String = Nothing
    ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
    Dim PathArchivo As String
    Public conexion As New MySqlConnection
    Public tiempo As Integer = 0
    Dim i As Integer
    Dim INS As New Instalación
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Public varid, identidad, consulta1, consulta2, consulta3, identidadPagos As String

    Private Sub EquipoRetiradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipoRetiradoToolStripMenuItem.Click

        Try

            respuesta = MsgBox("Confirme que se retiraron los equipos del cliente " & dgvDesconexiones.Item(2, dgvDesconexiones.CurrentRow.Index).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Dialog1.index = dgvDesconexiones.CurrentRow.Index
                Dialog1.txtObservacion.Text = dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value
                Dialog1.ShowDialog()


                adaptador = New MySqlDataAdapter("update clientes set equiporetirado=1, observacion='" & dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value & "' where idCliente='" & dgvDesconexiones.Item(1, dgvDesconexiones.CurrentRow.Index).Value & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
                Dim i As Integer = dgvDesconexiones.CurrentRow.Index
                desconexionActualizar(i)


            End If
        Catch s As Exception
        End Try

    End Sub

    Private Sub EquipoNoRetiradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipoNoRetiradoToolStripMenuItem.Click
        Try
            respuesta = MsgBox("Confirme que no se retiraron los equipos del cliente " & dgvDesconexiones.Item(2, dgvDesconexiones.CurrentRow.Index).Value & "  ?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Dialog1.index = dgvDesconexiones.CurrentRow.Index
                Dialog1.txtObservacion.Text = dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value
                Dialog1.ShowDialog()
                adaptador = New MySqlDataAdapter("update clientes set equiporetirado=2, observacion='" & dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value & "' where idCliente='" & dgvDesconexiones.Item(1, dgvDesconexiones.CurrentRow.Index).Value & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
                Dim i As Integer = dgvDesconexiones.CurrentRow.Index
                desconexionActualizar(i)


            End If
        Catch s As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        desconexiones()
    End Sub

    Private Sub cbRetirados_CheckedChanged(sender As Object, e As EventArgs) Handles cbRetirados.CheckedChanged

        If cbRetirados.Checked = True Then
            cbTodos.Checked = False
        End If
        If cbTodos.Checked = True Then
            cbRetirados.Checked = False
        End If
    End Sub

    Private Sub cbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbTodos.CheckedChanged
        If cbTodos.Checked = True Then
            cbRetirados.Checked = False
        End If
        If cbRetirados.Checked = True Then
            cbTodos.Checked = False
        End If
    End Sub

    Private Sub ToolStripTextBoxObservacion_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub



    Private Sub ObservaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObservaciónToolStripMenuItem.Click
        Dialog1.index = dgvDesconexiones.CurrentRow.Index
        Dialog1.txtObservacion.Text = dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value
        Dialog1.ShowDialog()
        If Dialog1.DialogResult = DialogResult.OK Then
            Try

                adaptador = New MySqlDataAdapter("update clientes set observacion='" & dgvDesconexiones.Item(8, dgvDesconexiones.CurrentRow.Index).Value & "' where idCliente='" & dgvDesconexiones.Item(1, dgvDesconexiones.CurrentRow.Index).Value & "'", conexion)
                oCommBuild = New MySqlCommandBuilder(adaptador)
                adaptador.Fill(data, "clientes")
                MsgBox("Registro actualizado exitosamente")
                data.Clear()
                Dim i As Integer = dgvDesconexiones.CurrentRow.Index
                desconexionActualizar(i)



            Catch s As Exception
            End Try
        Else

        End If
    End Sub

    Public respuesta, formulario, ActivoD As Integer
    Private Sub frmDesconexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conexion = New MySqlConnection()
            conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
            conexion.Open()
            desconexiones()
        Catch
        End Try
    End Sub
    Public Function ConsultarRegistro(ByVal cadena As String)
        Try
            data.Clear()
            adaptador = New MySqlDataAdapter(cadena, conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "Resultado")
            tablatemp = data.Tables("Resultado").Rows
            Return tablatemp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "ERROR")
            Return tablatemp
        End Try
    End Function
    Sub desconexiones()
        Try
            Dim retirados As String = ""
            If cbRetirados.Checked Then
                retirados = " and equiporetirado=2 "
                cbTodos.Checked = False
            ElseIf cbRetirados.Checked = False Then
                retirados = " and equiporetirado=2 "
                cbTodos.Checked = True
            End If
            If cbTodos.Checked = True Then
                retirados = ""

            End If
            dgvDesconexiones.Rows.Clear()
            tablatemp = ConsultarRegistro("select * from fichainstalacionserviciovista where activo=2 and fechabaja between '" & dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' " & retirados & " order by fechabaja")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvDesconexiones.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvDesconexiones.Item(0, l).Value = l + 1
                    dgvDesconexiones.Item(1, l).Value = rowtemp("IdCliente")
                    dgvDesconexiones.Item(2, l).Value = rowtemp("Nombre")
                    dgvDesconexiones.Item(3, l).Value = rowtemp("NombreMunicipio")
                    dgvDesconexiones.Item(4, l).Value = rowtemp("NombreComunidad") & " " & rowtemp("Nombremunicipio")
                    dgvDesconexiones.Item(5, l).Value = rowtemp("fechabaja")
                    dgvDesconexiones.Item(6, l).Value = rowtemp("usuario")
                    If rowtemp("equiporetirado") = 1 Then
                        dgvDesconexiones.Item(7, l).Value = "Si"
                    Else
                        dgvDesconexiones.Item(7, l).Value = "No"
                    End If
                    'ToolStripTextBoxObservacion.Text = rowtemp("observacion").ToString
                    'ToolStripTextBoxObservacion2.Text = rowtemp("observacion").ToString
                    dgvDesconexiones.Item(8, l).Value = rowtemp("observacion").ToString
                    Dim router As String
                    If rowtemp("router") = 1 Then
                        router = "Si Marca: " + rowtemp("marcaRouter")
                    Else
                        router = "No"

                    End If

                    If (rowtemp("equipo").ToString = "-" Or rowtemp("equipo").ToString = "0") And router = "No" Then
                        dgvDesconexiones.Item(9, l).Value = "SIN INFORMACION"
                    Else
                        dgvDesconexiones.Item(9, l).Value = rowtemp("equipo").ToString + " Router:" + router
                    End If

                Next


            End If
        Catch m As Exception
        End Try
    End Sub

    Sub desconexionActualizar(ByVal i As Integer)
        Try

            Dim l As Integer = i
            tablatemp = ConsultarRegistro("select * from fichainstalacionserviciovista where idCliente='" & dgvDesconexiones.Item(1, l).Value & "' order by fechabaja")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                'dgvDesconexiones.RowCount = tablatemp.Count


                rowtemp = tablatemp.Item(0)

                If rowtemp("equiporetirado") = 1 Then
                    dgvDesconexiones.Item(7, l).Value = "Si"
                Else
                    dgvDesconexiones.Item(7, l).Value = "No"
                End If
                'ToolStripTextBoxObservacion.Text = rowtemp("observacion").ToString
                'ToolStripTextBoxObservacion2.Text = rowtemp("observacion").ToString
                dgvDesconexiones.Item(8, l).Value = rowtemp("observacion").ToString


            End If
        Catch m As Exception
        End Try
    End Sub
End Class