Imports MySql.Data.MySqlClient
Public Class InventarioEquipo
    'Public conec As New Conexion
    Private conexion As New MySqlConnection
    Private adaptador As New MySqlDataAdapter
    Private data As New DataSet
    Dim varid As String
    Private tablatemp As DataRowCollection
    Private rowtemp As DataRow
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
                dgvEquipo.Item(4, l).Value = rowtemp("Existencia")


            Next

        Catch m As Exception
            'MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub

    Sub Limpiar()

        MAC.Text = ""




    End Sub

    Private Sub dgvInstalacion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEquipo.DoubleClick
        Instalación.Equipo.Text = dgvEquipo.Item(3, dgvEquipo.CurrentRow.Index).Value
        Instalación.DirMAC.Text = dgvEquipo.Item(2, dgvEquipo.CurrentRow.Index).Value

    End Sub

    Private Sub InventarioEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectar()1
        Limpiar()
        dgvEquipo.Rows.Clear()
        llenaGrid("Select * from Equipo")
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            adaptador = New MySqlDataAdapter("DELETE FROM Equipo WHERE MAC like '" & MAC.Text & "'", frmmenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "Equipo")
            data.Clear()

            ErrorProvider1.Clear()

            If MAC.Text = "" Then
                ErrorProvider1.SetError(MAC, "Ingrese la MAC")
                GoTo salir
            Else
                ErrorProvider1.Clear()
            End If

            Dim agregar As DataRow
            adaptador = New MySqlDataAdapter("SELECT * FROM Equipo ", frmmenu.conexion)
            Dim oCommBuild2 As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "Equipo")
            agregar = Me.data.Tables("Equipo").NewRow()
            agregar("Categoria") = Me.cmbCategoria.Text
            agregar("SubCategoria") = Me.cmbSubCategoria.Text
            agregar("MAC") = Me.MAC.Text
            'agregar("Descripcion") = Me.Descripcion.Text
            'agregar("Existencia") = Me.Existencia.Text

            Me.data.Tables("Equipo").Rows.Add(agregar)
            Me.adaptador.Update(data, "Equipo")
            MsgBox("Datos agregados")
            data.Clear()
            Limpiar()

        Catch s As Exception
            MsgBox(s.ToString)
        End Try
salir:
    End Sub

    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        adaptador = New MySqlDataAdapter("DELETE FROM Equipo WHERE MAC like '" & MAC.Text & "'", frmmenu.conexion)
        Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
        adaptador.Fill(data, "Equipo")
        data.Clear()
        tablatemp = ConsultarRegistro("Select * from Equipo where MAC LIKE '" & MAC.Text & "'")

        If tablatemp.Count > 0 Then
            MsgBox("El registro no pudo eliminarse")
        Else
            MsgBox("Datos eliminados")
            Limpiar()
        End If
    End Sub

    Private Sub MAC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAC.TextChanged
        llenaGrid("Select * from Equipo where MAC like '%" & MAC.Text & "%'")

    End Sub

    Private Sub Descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'llenaGrid("Select * from Equipo where Descripcion like '%" & Descripcion.Text & "%'")

    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria.SelectedIndexChanged
        llenaGrid("Select * from Equipo where Categoria like '%" & cmbCategoria.Text & "%'")
    End Sub

    Private Sub cmbSubCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCategoria.SelectedIndexChanged
        llenaGrid("Select * from Equipo where Categoria like '%" & cmbCategoria.Text & "%' and SubCategoria like '%" & cmbSubCategoria.Text & "%'")
    End Sub

    Private Sub dgvEquipo_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipo.CellClick

        For i As Integer = 0 To cmbCategoria.Items.Count - 1
            cmbCategoria.SelectedIndex = i
            If cmbCategoria.Text = System.Convert.ToString(dgvEquipo.Item(0, dgvEquipo.CurrentRow.Index).Value) Then
                GoTo salir
            End If
        Next
salir:

        For i As Integer = 0 To cmbCategoria.Items.Count - 1
            cmbSubCategoria.SelectedIndex = i
            If cmbSubCategoria.Text = System.Convert.ToString(dgvEquipo.Item(1, dgvEquipo.CurrentRow.Index).Value) Then
                GoTo salir2
            End If
        Next
salir2:



        MAC.Text = dgvEquipo.Item(2, dgvEquipo.CurrentRow.Index).Value
        'Descripcion.Text = dgvEquipo.Item(3, dgvEquipo.CurrentRow.Index).Value
        'Existencia.Text = dgvEquipo.Item(4, dgvEquipo.CurrentRow.Index).Value

    End Sub
End Class