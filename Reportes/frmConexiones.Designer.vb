<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexiones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConexiones))
        Me.dgvInstalacion = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Correo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dirección = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cunidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTipoPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.activo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.router = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.macRouter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcaRouter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.txtInstalaciones = New System.Windows.Forms.Label()
        CType(Me.dgvInstalacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInstalacion
        '
        Me.dgvInstalacion.AllowUserToAddRows = False
        Me.dgvInstalacion.AllowUserToDeleteRows = False
        Me.dgvInstalacion.AllowUserToOrderColumns = True
        Me.dgvInstalacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInstalacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Correo, Me.Dirección, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn48, Me.MAC, Me.DataGridViewTextBoxColumn49, Me.DataGridViewTextBoxColumn50, Me.DataGridViewTextBoxColumn51, Me.DataGridViewTextBoxColumn52, Me.Cunidades, Me.CMoneda, Me.CTipoPlan, Me.activo1, Me.router, Me.macRouter, Me.MarcaRouter, Me.Direccion_})
        Me.dgvInstalacion.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInstalacion.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInstalacion.Location = New System.Drawing.Point(9, 52)
        Me.dgvInstalacion.Name = "dgvInstalacion"
        Me.dgvInstalacion.ReadOnly = True
        Me.dgvInstalacion.RowHeadersVisible = False
        Me.dgvInstalacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInstalacion.Size = New System.Drawing.Size(907, 578)
        Me.dgvInstalacion.TabIndex = 51
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'Correo
        '
        Me.Correo.HeaderText = "Tipo"
        Me.Correo.Name = "Correo"
        Me.Correo.ReadOnly = True
        '
        'Dirección
        '
        Me.Dirección.HeaderText = "Fecha de Instalación"
        Me.Dirección.Name = "Dirección"
        Me.Dirección.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Velocidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.HeaderText = "Mens"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.ReadOnly = True
        Me.DataGridViewTextBoxColumn48.Width = 60
        '
        'MAC
        '
        Me.MAC.HeaderText = "Mac"
        Me.MAC.Name = "MAC"
        Me.MAC.ReadOnly = True
        Me.MAC.Visible = False
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.HeaderText = "Ip"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        Me.DataGridViewTextBoxColumn49.ReadOnly = True
        Me.DataGridViewTextBoxColumn49.Visible = False
        Me.DataGridViewTextBoxColumn49.Width = 200
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.HeaderText = "Instalado por"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        Me.DataGridViewTextBoxColumn50.ReadOnly = True
        Me.DataGridViewTextBoxColumn50.Visible = False
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.HeaderText = "Equipo"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        Me.DataGridViewTextBoxColumn51.ReadOnly = True
        Me.DataGridViewTextBoxColumn51.Visible = False
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.HeaderText = "No"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.Visible = False
        Me.DataGridViewTextBoxColumn52.Width = 60
        '
        'Cunidades
        '
        Me.Cunidades.HeaderText = "un."
        Me.Cunidades.Name = "Cunidades"
        Me.Cunidades.ReadOnly = True
        Me.Cunidades.Visible = False
        Me.Cunidades.Width = 50
        '
        'CMoneda
        '
        Me.CMoneda.HeaderText = "Mon."
        Me.CMoneda.Name = "CMoneda"
        Me.CMoneda.ReadOnly = True
        Me.CMoneda.Visible = False
        Me.CMoneda.Width = 60
        '
        'CTipoPlan
        '
        Me.CTipoPlan.HeaderText = "Tipo Plan"
        Me.CTipoPlan.Name = "CTipoPlan"
        Me.CTipoPlan.ReadOnly = True
        Me.CTipoPlan.Visible = False
        '
        'activo1
        '
        Me.activo1.HeaderText = "Plan activo"
        Me.activo1.Name = "activo1"
        Me.activo1.ReadOnly = True
        Me.activo1.Visible = False
        Me.activo1.Width = 60
        '
        'router
        '
        Me.router.HeaderText = "Propiedad Router"
        Me.router.Name = "router"
        Me.router.ReadOnly = True
        Me.router.Visible = False
        Me.router.Width = 60
        '
        'macRouter
        '
        Me.macRouter.HeaderText = "macRouter"
        Me.macRouter.Name = "macRouter"
        Me.macRouter.ReadOnly = True
        Me.macRouter.Visible = False
        Me.macRouter.Width = 60
        '
        'MarcaRouter
        '
        Me.MarcaRouter.HeaderText = "MarcaRouter"
        Me.MarcaRouter.Name = "MarcaRouter"
        Me.MarcaRouter.ReadOnly = True
        Me.MarcaRouter.Visible = False
        Me.MarcaRouter.Width = 60
        '
        'Direccion_
        '
        Me.Direccion_.HeaderText = "Direccion"
        Me.Direccion_.Name = "Direccion_"
        Me.Direccion_.ReadOnly = True
        Me.Direccion_.Width = 200
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(665, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 80
        Me.Button1.Text = "Actualizar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(387, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(104, 13)
        Me.Label29.TabIndex = 79
        Me.Label29.Text = "Fecha de pago final:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha2.Location = New System.Drawing.Point(495, 12)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(122, 20)
        Me.dtpFecha2.TabIndex = 78
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(140, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(111, 13)
        Me.Label30.TabIndex = 77
        Me.Label30.Text = "Fecha de pago inicial:"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha1.Location = New System.Drawing.Point(261, 12)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(122, 20)
        Me.dtpFecha1.TabIndex = 76
        '
        'txtInstalaciones
        '
        Me.txtInstalaciones.AutoSize = True
        Me.txtInstalaciones.Location = New System.Drawing.Point(31, 36)
        Me.txtInstalaciones.Name = "txtInstalaciones"
        Me.txtInstalaciones.Size = New System.Drawing.Size(10, 13)
        Me.txtInstalaciones.TabIndex = 81
        Me.txtInstalaciones.Text = "."
        '
        'frmConexiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 642)
        Me.Controls.Add(Me.txtInstalaciones)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.dtpFecha2)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.dtpFecha1)
        Me.Controls.Add(Me.dgvInstalacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConexiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conexiones"
        CType(Me.dgvInstalacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvInstalacion As DataGridView
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Correo As DataGridViewTextBoxColumn
    Friend WithEvents Dirección As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn
    Friend WithEvents MAC As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn
    Friend WithEvents Cunidades As DataGridViewTextBoxColumn
    Friend WithEvents CMoneda As DataGridViewTextBoxColumn
    Friend WithEvents CTipoPlan As DataGridViewTextBoxColumn
    Friend WithEvents activo1 As DataGridViewTextBoxColumn
    Friend WithEvents router As DataGridViewTextBoxColumn
    Friend WithEvents macRouter As DataGridViewTextBoxColumn
    Friend WithEvents MarcaRouter As DataGridViewTextBoxColumn
    Friend WithEvents Direccion_ As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents Label30 As Label
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents txtInstalaciones As Label
End Class
