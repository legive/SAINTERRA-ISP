Imports MySql.Data.MySqlClient


Public Class Equipos
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Dim varid As String
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        txtDescripcion.Text = ""
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        '        Try
        '            If txtCodigo.Text = "" Then
        '                MsgBox("Debe ingresar el codigo de Nombredepartamento", vbExclamation, "¡Atención!")
        '                txtCodigo.Focus()
        '                GoTo salir
        '            End If

        '            If txtNombredepartamento.Text = "" Then
        '                MsgBox("Debe ingresar la Nombredepartamento", vbExclamation, "¡Atención!")
        '                txtNombredepartamento.Focus()
        '                GoTo salir
        '            End If

        '            respuesta = MsgBox("¿Desea agregar el registro?", MsgBoxStyle.YesNo, "¡Atención!")
        '            If respuesta = 6 Then
        '                adaptador = New MySqlDataAdapter("Select * from departamento where Codigodepartamento = " & txtCodigo.Text & "", frmMenu.conexion)
        '                Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
        '                adaptador.Fill(data, "departamento")

        '                If data.Tables("departamento").Rows.Count = 0 Then
        '                    adaptador = New MySqlDataAdapter("Insert into departamento (Codigodepartamento, Nombredepartamento) values(" & txtCodigo.Text & ",'" & txtNombredepartamento.Text.ToUpper & "')", frmMenu.conexion)
        '                    oCommBuild = New MySqlCommandBuilder(adaptador)
        '                    adaptador.Fill(data, "departamento")
        '                    MsgBox("Registro agregado exitosamente", MsgBoxStyle.Information, "Información")
        '                    data.Clear()
        '                    'Llama la función de limpiar
        '                    Limpiar()
        '                    'Se actualiza el grid para ver el nuevo registro agregado
        '                    LlenarDATAGRID("SELECT * FROM departamento ")
        '                Else
        '                    MsgBox("El registro con ese código ya existe", MsgBoxStyle.Exclamation, "¡Atención!")
        '                    txtCodigo.Focus()
        '                End If
        '            End If
        'salir:
        '        Catch
        '        End Try
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
    Private Sub Equipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conectar()1
        txtDescripcion.Text = ""
        dgvEquipo.Rows.Clear()
        llenaGrid("Select * from Equipo")
    End Sub
    Sub llenaGrid(ByVal cadena As String)
        Try

            dgvEquipo.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)

            If tablatemp.Count > 0 Then
                dgvEquipo.RowCount = tablatemp.Count
            Else
                dgvEquipo.RowCount = 1
            End If

            For l As Integer = 0 To tablatemp.Count - 1
                rowtemp = tablatemp.Item(l)


                '                For i As Integer = 0 To cmbCategoria.Items.Count - 1
                '                    cmbCategoria.SelectedIndex = i
                '                    If cmbCategoria.Text = rowtemp("Categoria").ToString Then
                '                        GoTo salir
                '                    End If
                '                Next
                'salir:

                '                For i As Integer = 0 To cmbCategoria.Items.Count - 1
                '                    cmbCategoria.SelectedIndex = i
                '                    If cmbCategoria.Text = rowtemp("SubCategoria").ToString Then
                '                        GoTo salir2
                '                    End If
                '                Next
                'salir2:


                dgvEquipo.Item(0, l).Value = rowtemp("Categoria")
                dgvEquipo.Item(1, l).Value = rowtemp("Subcategoria")
                dgvEquipo.Item(2, l).Value = rowtemp("MAC")
                dgvEquipo.Item(3, l).Value = rowtemp("Descripcion")



            Next

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub
    'Sub conectar()1
    '    Try
    '        conexion = New MySqlConnection()
    '        conexion.ConnectionString = "server=" & frmMEnu.txtdireccionbd.Text & ";database=admininterrabd;uid=interraadmin;pwd=interra2012;"
    '        conexion.Open()
    '    Catch s As Exception
    '        MsgBox(s.ToString)
    '    End Try
    'End Sub
End Class