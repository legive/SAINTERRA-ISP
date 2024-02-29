Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmBitacora
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
    Public respuesta, formulario, ActivoD As Integer

    Private Sub frmBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
        conexion.Open()
        Llenarbitacora("SELECT * FROM bitacora")

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lbBusqueda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Llenarbitacora("SELECT * FROM bitacora where bitaDescripcion like '%" & lbBusqueda.Text & "%' or usuario like '%" & lbBusqueda.Text & "%' order by bitafecha ")
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles lbBusqueda.TextChanged

    End Sub

    Dim entro As Boolean
    Dim NDEI As Integer
    Public clientesForm, conexion2 As Boolean

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
    Sub Llenarbitacora(ByVal consulta As String)
        Try
            dgvBitacora.Rows.Clear()
            tablatemp = ConsultarRegistro(consulta)
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvBitacora.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvBitacora.Item(0, l).Value = l + 1
                    dgvBitacora.Item(1, l).Value = rowtemp("bitaDescripcion")
                    dgvBitacora.Item(2, l).Value = rowtemp("bitafecha")
                    dgvBitacora.Item(3, l).Value = rowtemp("usuario")

                Next


            End If
        Catch m As Exception
        End Try
    End Sub
End Class