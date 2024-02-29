Public Class OrdenTrabajo
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Limpiar()
        fechasol.Value = Today
        fecgaprog.Value = Today

        dgvFallas.Rows.Clear()
    End Sub
    Sub Limpiar()
        'txtIndisponibilidad.Text = 0
        'trabajo.Text = ""
        'Num.Text = incrementaCodigo("Select * from Fallas  order by No", "No")
        'llenaGrid("SELECT * FROM Fallas where fechaFalla between '" & Me.dtpFecha1.Value.ToString("yyyy-MM-dd") & "' and '" & Me.dtpFecha2.Value.ToString("yyyy-MM-dd") & "' ")

    End Sub
End Class