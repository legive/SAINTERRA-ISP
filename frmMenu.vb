Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmMenu
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
    Dim entro As Boolean
    Dim NDEI As Integer
    Public clientesForm, conexion2 As Boolean
    Dim tiempo2 As Integer


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
    Sub leertxt()
        Try

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\conexion.txt")

            Dim lineas As New List(Of String)

            ' Leer todas las líneas del archivo y almacenarlas en la lista
            Do While fileReader.Peek() <> -1
                lineas.Add(fileReader.ReadLine())
            Loop

            ' Ahora puedes acceder a cada línea individualmente
            If lineas.Count > 0 Then
                txtdireccionbd.Text = lineas(0) ' Accede a la primera línea
            End If

            If lineas.Count > 1 Then
                txtuser.Text = lineas(1) ' Accede a la segunda línea
                txtpsw.Text = lineas(2) ' Accede a la segunda línea
                txtbd.Text = lineas(3) ' Accede a la segunda línea
            End If


            fileReader.Close()

        Catch
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            leertxt()
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvCortados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvPromesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvDesconexiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'IniciarSesion.Close()
            conexion = New MySqlConnection()
            conexion.ConnectionString = "server=" & txtdireccionbd.Text & ";Port=3306;database=" & txtbd.Text & ";uid=" & txtuser.Text & ";pwd=" & txtpsw.Text & ";"
            conexion.Open()

            IniciarSesion.ShowDialog()
            cortados()
            desconexiones()
            bitacora()
            Promesa()
            Timer1.Enabled = True
            Timer1.Start()
            'conexion2 = True
        Catch s As Exception
            MsgBox("Error de conexion a la base de datos, comuniquese con el administrador del servidor")
            respuesta = MsgBox("Desea reintentar la conexión?", MsgBoxStyle.YesNo, "Atención?")
            If respuesta = 6 Then
                Form1_Load(Me, EventArgs.Empty)
            Else
                Me.Close()
            End If

            Me.Close()
        End Try
    End Sub
    Sub cortados()
        Try
            dgvCortados.Rows.Clear()
            tablatemp = ConsultarRegistro("select Cortados.IdCliente, Cortados.Nombre, Cortados.NombreComunidad, Cortados.NombreMunicipio, Cortados.fechain, Cortados.usuario, controlpago.razonCorte, Cortados.equiporetirado from Cortados, controlpago where Cortados.estadocliente=2 and Cortados.activo=1 and Cortados.IdCliente=controlpago.idCliente and Cortados.fechain=controlpago.fechain and Cortados.equiporetirado=2 order by Cortados.fechain, Cortados.nombrecomunidad")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvCortados.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvCortados.Item(0, l).Value = l + 1
                    dgvCortados.Item(1, l).Value = rowtemp("IdCliente")
                    dgvCortados.Item(2, l).Value = rowtemp("Nombre")
                    dgvCortados.Item(3, l).Value = rowtemp("NombreComunidad") & " " & rowtemp("Nombremunicipio")
                    dgvCortados.Item(4, l).Value = rowtemp("fechain")
                    dgvCortados.Item(5, l).Value = rowtemp("usuario")
                    dgvCortados.Item(6, l).Value = rowtemp("razonCorte")

                Next
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub Promesa()
        Try
            dgvPromesa.Rows.Clear()
            tablatemp = ConsultarRegistro("select * from vistapagos where year(fechaPP)=" & Today.Year & " and month(fechaPP)=" & Today.Month & " order by fechaPP")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvPromesa.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvPromesa.Item(0, l).Value = l + 1
                    dgvPromesa.Item(1, l).Value = rowtemp("IdCliente")
                    dgvPromesa.Item(2, l).Value = rowtemp("Nombre")
                    dgvPromesa.Item(3, l).Value = rowtemp("NombreComunidad") & " " & rowtemp("Nombremunicipio")
                    dgvPromesa.Item(4, l).Value = rowtemp("fechaPP")
                    dgvPromesa.Item(5, l).Value = rowtemp("usuario")

                Next


            End If
        Catch m As Exception
        End Try
    End Sub
    Sub Promesahoy()
        Try

            tablatemp = ConsultarRegistro("select * from vistapagos where day(fechaPP)=" & Today.Day & " and year(fechaPP)=" & Today.Year & " and month(fechaPP)=" & Today.Month & "")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then


                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)

                    NotifyIcon1.BalloonTipText = " " & rowtemp("Nombre") & " DE " & rowtemp("NombreComunidad") & " " & rowtemp("Nombremunicipio") & " TIENE PROMESA DE PAGO PARA EL DIA DE HOY"

                    Me.NotifyIcon1.Visible = True
                    NotifyIcon1.ShowBalloonTip(2000)

                Next
                NotifyIcon1.Visible = False
                tiempo2 = 0
            End If
        Catch m As Exception
        End Try
    End Sub
    Sub desconexiones()
        Try
            dgvDesconexiones.Rows.Clear()
            tablatemp = ConsultarRegistro("select * from fichainstalacionserviciovista where activo=2 and MONTH(fechabaja)= " & Today.Month & " order by fechabaja")
            Dim activo As String = ""
            If tablatemp.Count > 0 Then
                dgvDesconexiones.RowCount = tablatemp.Count

                For l As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(l)
                    dgvDesconexiones.Item(0, l).Value = l + 1
                    dgvDesconexiones.Item(1, l).Value = rowtemp("IdCliente")
                    dgvDesconexiones.Item(2, l).Value = rowtemp("Nombre")
                    dgvDesconexiones.Item(3, l).Value = rowtemp("NombreComunidad") & " " & rowtemp("Nombremunicipio")
                    dgvDesconexiones.Item(4, l).Value = rowtemp("fechabaja")
                    dgvDesconexiones.Item(5, l).Value = rowtemp("usuario")

                Next


            End If
        Catch m As Exception
        End Try
    End Sub
    Sub bitacora()
        Try
            'If conexion.Close() = False Then
            '    conexion.ConnectionString = "server=" & txtdireccionbd.Text & ";Port=3306;database=" & txtbd.Text & ";uid=" & txtuser.Text & ";pwd=" & txtpsw.Text & ";"
            '    conexion.Open()
            'End If
            dgvBitacora.Rows.Clear()
            tablatemp = ConsultarRegistro("select * from bitacora order by idbitacora desc limit  " & lbregistros.Text & "")
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Instalación.Show()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PagosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PagosToolStripMenuItem.Click
        Instalación.Show()
    End Sub

    Private Sub ArchivoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArchivoToolStripMenuItem.Click
        clientes.btnOrden.Visible = True
        clientes.Show()
    End Sub

    Private Sub PagosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PagosToolStripMenuItem1.Click
        Pagos.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clientes.Show()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Instalación.Show()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Pagos.Show()
    End Sub



    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Process.Start("calc.exe")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Process.Start("excel.exe")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Process.Start("WINWORD.exe")
    End Sub


    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            txtdireccionbd.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub



    Private Sub GastosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GastosToolStripMenuItem.Click
        salidas2.Show()
    End Sub


    Private Sub dgvCortados_DoubleClick(sender As Object, e As EventArgs)
        Pagos.llenaGrid("Select * from vistapagos where idCliente='" & dgvCortados.Item(1, dgvCortados.CurrentRow.Index).Value & "'  order by  No desc limit " & Pagos.txtlimite.Text & "")
        Pagos.ShowDialog()
    End Sub



    Private Sub dgvBitacora_DoubleClick(sender As Object, e As EventArgs) Handles dgvBitacora.DoubleClick
        frmBitacora.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tiempo2 = tiempo2 + 1

        If tiempo2 = 60 Then

            tiempo2 = 0
            btnAcualizar_Click(btnAcualizar, e)
            Promesahoy()
        End If

    End Sub


    Private Sub btnAcualizar_Click(sender As Object, e As EventArgs) Handles btnAcualizar.Click
        cortados()
        desconexiones()
        bitacora()
        Promesa()
    End Sub

    Private Sub lbregistros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lbregistros.KeyPress
        Dim numero As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = vbBack Then
            Exit Sub
        End If

        If InStr("1234567890", Chr(numero)) = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            bitacora()
        End If
    End Sub

    Private Sub dtpFecha1_ValueChanged(sender As Object, e As EventArgs)
        desconexiones()
    End Sub

    Private Sub dtpFecha2_ValueChanged(sender As Object, e As EventArgs)
        desconexiones()
    End Sub

    Private Sub dtpFecha2_Validated(sender As Object, e As EventArgs)
        desconexiones()
    End Sub

    Private Sub dgvDesconexiones_DoubleClick(sender As Object, e As EventArgs) Handles dgvDesconexiones.DoubleClick
        frmDesconexiones.Show()
    End Sub

    Private Sub dgvBitacora_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBitacora.CellContentClick

    End Sub

    Private Sub frmMenu_MaximumSizeChanged(sender As Object, e As EventArgs) Handles MyBase.MaximumSizeChanged
        dgvBitacora.AutoResizeColumns()
        dgvCortados.AutoResizeColumns()
        dgvPromesa.AutoResizeColumns()
        dgvDesconexiones.AutoResizeColumns()

    End Sub

    Private Sub frmMenu_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        For Each control As Control In TableLayoutPanel1.Controls
            If TypeOf control Is DataGridView Then
                DirectCast(control, DataGridView).AutoResizeColumns()
            End If
        Next
    End Sub
    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        IniciarSesion.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
        Dim calculadoraPath As String = "C:\Windows\System32\calc.exe"

        ' Verificar si la calculadora está instalada
        If System.IO.File.Exists(calculadoraPath) Then
            ' Crear un nuevo proceso para iniciar la calculadora
            Dim procesoCalculadora As New Process()

            ' Configurar el proceso
            procesoCalculadora.StartInfo.FileName = calculadoraPath

            ' Iniciar la calculadora
            procesoCalculadora.Start()
        Else
            MessageBox.Show("La calculadora no está instalada en esta máquina.")
        End If
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        Dim calculadoraPath As String = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Excel.exe"

        ' Verificar si la calculadora está instalada
        If System.IO.File.Exists(calculadoraPath) Then
            ' Crear un nuevo proceso para iniciar la calculadora
            Dim procesoCalculadora As New Process()

            ' Configurar el proceso
            procesoCalculadora.StartInfo.FileName = calculadoraPath

            ' Iniciar la calculadora
            procesoCalculadora.Start()
        Else
            MessageBox.Show("Excel no está instalada en esta máquina.")
        End If

    End Sub

    Private Sub ClientesNuevosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesNuevosToolStripMenuItem.Click
        frmConexiones.Show()
    End Sub

    Private Sub InformesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformesToolStripMenuItem.Click
        frwInforme.Show()
    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
        tiempo = 0
        Timer2.Start()
        'conectar()1
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        tiempo = tiempo + 1
    End Sub

    Private Sub ReclamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReclamosToolStripMenuItem.Click
        Reclamos.ShowDialog()
    End Sub

    Private Sub FallasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FallasToolStripMenuItem.Click
        Fallas.ShowDialog()
    End Sub
End Class
