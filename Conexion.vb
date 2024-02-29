Imports MySql.Data.MySqlClient

Module Conexion
    Public Myconexion As New MySqlConnection
    Public Myadaptador As New MySqlDataAdapter
    Public Mydata As New DataSet
    Public MyoCommBuild As New MySqlCommandBuilder

    Dim tablatemp As DataRowCollection
    Dim row As DataRow
    Dim data As New DataSet
    Dim adaptador As MySqlDataAdapter
    Public oCommBuild As MySqlCommandBuilder
    Public conectarme As New MySqlConnection
    Public Nrows, nivel As Integer
    Public sesionusuario As String
    Sub InsertarBitacora(ByVal accion2 As String)
        Try
            Dim n As Integer

            n = incrementaCodigo("SELECT idbitacora FROM bitacora  ORDER BY idbitacora DESC limit 1", "idbitacora")

            adaptador = New MySqlDataAdapter("insert into bitacora values (" & n & ", '" & accion2 & "', '" & Today.ToString("yyyy-MM-dd") & "', '" & sesionusuario & "')", frmMenu.conexion)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, "detallecuentabancaria")
            'MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "SA INTERRA")
            data.Clear()
        Catch s As Exception
        End Try
    End Sub
    Public Function incrementaCodigo(ByVal consulta As String, ByVal campo As String)
        'inicializaConexion(frmMenu.txtDireccionBD.Text)
        Dim contador As Integer
        Try
            data.Clear()
            Dim p As String = consulta
            adaptador = New MySqlDataAdapter(consulta, frmMenu.conexion)
            Dim oCommBuild As MySqlCommandBuilder = New MySqlCommandBuilder(adaptador)
            data = New DataSet
            adaptador.Fill(data, "controlpago")
            Dim tablatemporal As DataRowCollection
            Dim Filatemporal As DataRow
            'a la tabla temporal agregar las filas de la consulta
            tablatemporal = data.Tables("controlpago").Rows

            'si la consulta agregada a la tabla temporal tiene datos o filas
            If tablatemporal.Count >= 1 Then
                Filatemporal = tablatemporal.Item(tablatemporal.Count - 1)
                contador = Filatemporal(campo) + 1
            Else
                contador = 1
                'dias.Text = diasajuste
            End If
            data.Clear()
            Return contador
        Catch ex As Exception
            'MsgBox(ex.Message.ToString())
        End Try

        Return contador
    End Function
    Public Function Consulta(ByVal cadena As String, ByVal tabla As String)
        Try
            data.Clear()
            adaptador = New MySqlDataAdapter(cadena, conectarme)
            oCommBuild = New MySqlCommandBuilder(adaptador)
            adaptador.Fill(data, tabla)
            tablatemp = data.Tables(tabla).Rows
            Nrows = tablatemp.Count
            Return tablatemp
        Catch
            Return Nothing
        End Try
    End Function

End Module
