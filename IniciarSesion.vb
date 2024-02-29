Imports System.IO
Imports MySql.Data.MySqlClient
Public Class IniciarSesion

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

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Try
            tablatemp = ConsultarRegistro("select * from usuarios where usuario ='" & txtUsuario.Text & "'")
            If tablatemp.Count > 0 Then
                rowtemp = tablatemp.Item(0)
                If txtContrasenia.Text = rowtemp("pass") Then
                    Me.Hide()
                    sesionusuario = txtUsuario.Text
                    nivel = rowtemp("nivel")
                    frmMenu.Timer1.Start()

                Else
                    MsgBox("Contraseña incorrecta")
                End If
            Else
                MsgBox("usuario incorrecto")
            End If
            limpiar()
        Catch
        End Try
    End Sub
    Sub CargarUsuarios()
        Try
            txtUsuario.Items.Clear()
            tablatemp = ConsultarRegistro("select * from usuarios")
            If tablatemp.Count > 0 Then
                For i As Integer = 0 To tablatemp.Count - 1
                    rowtemp = tablatemp.Item(i)
                    txtUsuario.Items.Add(rowtemp("usuario"))
                Next
            End If
            limpiar()
        Catch
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub IniciarSesion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenu.Close()
    End Sub

    Public respuesta, formulario, ActivoD As Integer

    Private Sub txtContrasenia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasenia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try
                tablatemp = ConsultarRegistro("select * from usuarios where usuario ='" & txtUsuario.Text & "'")
                If tablatemp.Count > 0 Then
                    rowtemp = tablatemp.Item(0)
                    If txtContrasenia.Text = rowtemp("pass") Then
                        Me.Hide()
                        sesionusuario = txtUsuario.Text
                        nivel = rowtemp("nivel")
                        frmMenu.Timer1.Start()

                    Else
                        MsgBox("Contraseña incorrecta")
                    End If
                Else
                    MsgBox("usuario incorrecto")
                End If
                limpiar()
            Catch
            End Try
        End If
    End Sub

    Private Sub txtUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtUsuario.SelectedIndexChanged
        txtContrasenia.Focus()
    End Sub

    Dim entro As Boolean
    Dim NDEI As Integer

    Sub IniciarSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmMenu.Timer1.Enabled = False
        conexion = New MySqlConnection()
        conexion.ConnectionString = "server=" & frmMenu.txtdireccionbd.Text & ";Port=3306;database=" & frmMenu.txtbd.Text & ";uid=" & frmMenu.txtuser.Text & ";pwd=" & frmMenu.txtpsw.Text & ";"
        conexion.Open()
        CargarUsuarios()
        limpiar()
        txtUsuario.Focus()
        txtUsuario.SelectedIndex = 0
    End Sub

    Sub limpiar()
        txtUsuario.Text = ""
        txtContrasenia.Text = ""
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

End Class