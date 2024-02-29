<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fallas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Fecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvFallas = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraFalla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaSolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraSolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionFalla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.minutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Num = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReclamos = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtIndisponibilidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvFallas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(438, 42)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 23)
        Me.Button2.TabIndex = 120
        Me.Button2.Text = "Filtrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Fecha2
        '
        Me.Fecha2.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.Fecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Fecha2.Location = New System.Drawing.Point(159, 92)
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Size = New System.Drawing.Size(273, 20)
        Me.Fecha2.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Fecha y hora de solución"
        '
        'dgvFallas
        '
        Me.dgvFallas.AllowUserToAddRows = False
        Me.dgvFallas.AllowUserToDeleteRows = False
        Me.dgvFallas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFallas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.Tipo1, Me.Fecha1, Me.HoraFalla, Me.FechaSolucion, Me.HoraSolucion, Me.DescripcionFalla, Me.minutos})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFallas.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFallas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvFallas.Location = New System.Drawing.Point(0, 387)
        Me.dgvFallas.Name = "dgvFallas"
        Me.dgvFallas.ReadOnly = True
        Me.dgvFallas.RowHeadersVisible = False
        Me.dgvFallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFallas.Size = New System.Drawing.Size(735, 274)
        Me.dgvFallas.TabIndex = 113
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Visible = False
        '
        'Tipo1
        '
        Me.Tipo1.HeaderText = "Tipo"
        Me.Tipo1.Name = "Tipo1"
        Me.Tipo1.ReadOnly = True
        '
        'Fecha1
        '
        Me.Fecha1.HeaderText = "Fecha"
        Me.Fecha1.Name = "Fecha1"
        Me.Fecha1.ReadOnly = True
        '
        'HoraFalla
        '
        Me.HoraFalla.HeaderText = "HoraFalla"
        Me.HoraFalla.Name = "HoraFalla"
        Me.HoraFalla.ReadOnly = True
        '
        'FechaSolucion
        '
        Me.FechaSolucion.HeaderText = "Fecha de Solución"
        Me.FechaSolucion.Name = "FechaSolucion"
        Me.FechaSolucion.ReadOnly = True
        '
        'HoraSolucion
        '
        Me.HoraSolucion.HeaderText = "HoraSolucion"
        Me.HoraSolucion.Name = "HoraSolucion"
        Me.HoraSolucion.ReadOnly = True
        '
        'DescripcionFalla
        '
        Me.DescripcionFalla.HeaderText = "DescripcionFalla"
        Me.DescripcionFalla.Name = "DescripcionFalla"
        Me.DescripcionFalla.ReadOnly = True
        '
        'minutos
        '
        Me.minutos.HeaderText = "Minutos"
        Me.minutos.Name = "minutos"
        Me.minutos.ReadOnly = True
        Me.minutos.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(159, 116)
        Me.Descripcion.Multiline = True
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(273, 48)
        Me.Descripcion.TabIndex = 111
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Descripción"
        '
        'Num
        '
        Me.Num.BackColor = System.Drawing.Color.White
        Me.Num.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Num.Location = New System.Drawing.Point(159, 18)
        Me.Num.Name = "Num"
        Me.Num.ReadOnly = True
        Me.Num.Size = New System.Drawing.Size(138, 20)
        Me.Num.TabIndex = 110
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "No. "
        '
        'Tipo
        '
        Me.Tipo.AutoCompleteCustomSource.AddRange(New String() {"Primera Instalación", "Reinstalación"})
        Me.Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tipo.FormattingEnabled = True
        Me.Tipo.Items.AddRange(New Object() {"INSTALACION DEL SERVICIO", "SUSPENCION DEL SERVICIO", "FUNCIONAMIENTO DEL SERVICIO", "CALIDAD DEL SERVICIO", "COBROS Y FACTURACION", "ATENCION AL CLIENTE", "OTROS"})
        Me.Tipo.Location = New System.Drawing.Point(159, 42)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(273, 21)
        Me.Tipo.TabIndex = 104
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Tipo"
        '
        'fecha
        '
        Me.fecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha.Location = New System.Drawing.Point(159, 69)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(273, 20)
        Me.fecha.TabIndex = 106
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Fecha y hora de la falla"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReclamos)
        Me.GroupBox1.Controls.Add(Me.Eliminar)
        Me.GroupBox1.Controls.Add(Me.Guardar)
        Me.GroupBox1.Controls.Add(Me.Nuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(104, 284)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(527, 61)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'btnReclamos
        '
        Me.btnReclamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReclamos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReclamos.Location = New System.Drawing.Point(387, 12)
        Me.btnReclamos.Name = "btnReclamos"
        Me.btnReclamos.Size = New System.Drawing.Size(119, 38)
        Me.btnReclamos.TabIndex = 91
        Me.btnReclamos.Text = "Reclamos"
        Me.btnReclamos.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.Location = New System.Drawing.Point(262, 12)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(119, 38)
        Me.Eliminar.TabIndex = 89
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(137, 12)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(119, 38)
        Me.Guardar.TabIndex = 87
        Me.Guardar.Text = "Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Nuevo
        '
        Me.Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nuevo.Location = New System.Drawing.Point(12, 12)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(119, 38)
        Me.Nuevo.TabIndex = 88
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dtpFecha2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dtpFecha1)
        Me.GroupBox2.Location = New System.Drawing.Point(185, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 48)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resumen"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(283, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 103
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(157, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "al"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha2.Location = New System.Drawing.Point(178, 17)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(97, 20)
        Me.dtpFecha2.TabIndex = 102
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Del"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha1.Location = New System.Drawing.Point(47, 19)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(97, 20)
        Me.dtpFecha1.TabIndex = 100
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtIndisponibilidad
        '
        Me.txtIndisponibilidad.Location = New System.Drawing.Point(287, 258)
        Me.txtIndisponibilidad.Name = "txtIndisponibilidad"
        Me.txtIndisponibilidad.ReadOnly = True
        Me.txtIndisponibilidad.Size = New System.Drawing.Size(321, 20)
        Me.txtIndisponibilidad.TabIndex = 127
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Tiempo total de indisponibilidad"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Fecha2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Descripcion)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Num)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Tipo)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.fecha)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(109, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(516, 202)
        Me.GroupBox3.TabIndex = 129
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'Fallas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 661)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtIndisponibilidad)
        Me.Controls.Add(Me.dgvFallas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Fallas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fallas"
        CType(Me.dgvFallas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Fecha2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvFallas As DataGridView
    Friend WithEvents Descripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Num As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Tipo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents fecha As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnReclamos As Button
    Friend WithEvents Eliminar As Button
    Friend WithEvents Guardar As Button
    Friend WithEvents Nuevo As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIndisponibilidad As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents Tipo1 As DataGridViewTextBoxColumn
    Friend WithEvents Fecha1 As DataGridViewTextBoxColumn
    Friend WithEvents HoraFalla As DataGridViewTextBoxColumn
    Friend WithEvents FechaSolucion As DataGridViewTextBoxColumn
    Friend WithEvents HoraSolucion As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionFalla As DataGridViewTextBoxColumn
    Friend WithEvents minutos As DataGridViewTextBoxColumn
End Class
