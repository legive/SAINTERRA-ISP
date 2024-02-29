Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmConexiones
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
    Private Sub frmConexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
        conexion.Open()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenaGridInstalaciones("Select * from fichainstalacionserviciovista where fichainstalacionserviciovista.tipo='INSTALACIÓN' and activo=1 and FechaInstalacion between '" & dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' order BY FechaInstalacion")

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

    Sub llenaGridInstalaciones(ByVal cadena As String)
        Try
            dgvInstalacion.Rows.Clear()
            tablatemp = ConsultarRegistro(cadena)
            If tablatemp.Count > 0 Then
                dgvInstalacion.RowCount = tablatemp.Count
                txtInstalaciones.Text = tablatemp.Count
                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvInstalacion.Item(0, l).Value = l + 1
                    dgvInstalacion.Item(1, l).Value = rowtemp("idCliente")
                    dgvInstalacion.Item(2, l).Value = rowtemp("nombre")
                    dgvInstalacion.Item(3, l).Value = rowtemp("Tipo")
                    dgvInstalacion.Item(4, l).Value = rowtemp("FechaInstalado")
                    dgvInstalacion.Item(5, l).Value = rowtemp("velocidad")
                    dgvInstalacion.Item(6, l).Value = rowtemp("Mensualidad")
                    dgvInstalacion.Item(7, l).Value = rowtemp("Mac")
                    dgvInstalacion.Item(8, l).Value = rowtemp("Ip")
                    dgvInstalacion.Item(9, l).Value = rowtemp("Instaladopor")
                    dgvInstalacion.Item(10, l).Value = rowtemp("Equipo")
                    dgvInstalacion.Item(11, l).Value = rowtemp("NoCorrelativo")
                    dgvInstalacion.Item(12, l).Value = rowtemp("unidades")
                    dgvInstalacion.Item(13, l).Value = rowtemp("moneda")
                    dgvInstalacion.Item(14, l).Value = rowtemp("TipoPlan")

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
                    'DEI = rowtemp("DEI")
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
            MsgBox(m.Message.ToString, , "Atención")
        End Try
    End Sub




End Class