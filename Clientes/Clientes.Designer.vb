<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(clientes))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnReclamos = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbUsuarioCliente = New System.Windows.Forms.ComboBox()
        Me.cbActivoHabilitado = New System.Windows.Forms.CheckBox()
        Me.btnOrden = New System.Windows.Forms.Button()
        Me.Numero = New System.Windows.Forms.Label()
        Me.dgvClientesNuevos = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDireccionExacta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRecuento = New System.Windows.Forms.Label()
        Me.BuscarComunidad = New System.Windows.Forms.Button()
        Me.cmbNombreComunidad1 = New System.Windows.Forms.ComboBox()
        Me.cbSar = New System.Windows.Forms.CheckBox()
        Me.cmbCodigoComunidad1 = New System.Windows.Forms.ComboBox()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.BuscarMunicipio = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.cmbCodigoMunicipio1 = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbNombreMunicipio1 = New System.Windows.Forms.ComboBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.BuscarDepartamento = New System.Windows.Forms.Button()
        Me.cbActivoSistema = New System.Windows.Forms.CheckBox()
        Me.cmbNombreDepartamento1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCodigoDepartamento1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIdentidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvClientesNuevos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUbicacion)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnReclamos)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmbUsuarioCliente)
        Me.GroupBox2.Controls.Add(Me.cbActivoHabilitado)
        Me.GroupBox2.Controls.Add(Me.btnOrden)
        Me.GroupBox2.Controls.Add(Me.Numero)
        Me.GroupBox2.Controls.Add(Me.dgvClientesNuevos)
        Me.GroupBox2.Controls.Add(Me.txtDireccionExacta)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtRecuento)
        Me.GroupBox2.Controls.Add(Me.BuscarComunidad)
        Me.GroupBox2.Controls.Add(Me.cmbNombreComunidad1)
        Me.GroupBox2.Controls.Add(Me.cbSar)
        Me.GroupBox2.Controls.Add(Me.cmbCodigoComunidad1)
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.BuscarMunicipio)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.cmbCodigoMunicipio1)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.cmbNombreMunicipio1)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Controls.Add(Me.BuscarDepartamento)
        Me.GroupBox2.Controls.Add(Me.cbActivoSistema)
        Me.GroupBox2.Controls.Add(Me.cmbNombreDepartamento1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmbCodigoDepartamento1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCorreo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtTelefono)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtIdentidad)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(19, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(929, 572)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Location = New System.Drawing.Point(143, 183)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(341, 20)
        Me.txtUbicacion.TabIndex = 60
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(51, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Ubicación"
        '
        'btnReclamos
        '
        Me.btnReclamos.Location = New System.Drawing.Point(637, 134)
        Me.btnReclamos.Name = "btnReclamos"
        Me.btnReclamos.Size = New System.Drawing.Size(274, 38)
        Me.btnReclamos.TabIndex = 59
        Me.btnReclamos.Text = "Reclamos"
        Me.btnReclamos.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(634, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Usuario Sistema"
        '
        'cmbUsuarioCliente
        '
        Me.cmbUsuarioCliente.FormattingEnabled = True
        Me.cmbUsuarioCliente.Items.AddRange(New Object() {"evasquez", "lvasquez", "ereyes"})
        Me.cmbUsuarioCliente.Location = New System.Drawing.Point(726, 182)
        Me.cmbUsuarioCliente.Name = "cmbUsuarioCliente"
        Me.cmbUsuarioCliente.Size = New System.Drawing.Size(121, 21)
        Me.cmbUsuarioCliente.TabIndex = 57
        '
        'cbActivoHabilitado
        '
        Me.cbActivoHabilitado.AutoSize = True
        Me.cbActivoHabilitado.Checked = True
        Me.cbActivoHabilitado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActivoHabilitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivoHabilitado.Location = New System.Drawing.Point(496, 87)
        Me.cbActivoHabilitado.Name = "cbActivoHabilitado"
        Me.cbActivoHabilitado.Size = New System.Drawing.Size(68, 17)
        Me.cbActivoHabilitado.TabIndex = 56
        Me.cbActivoHabilitado.Text = " ACTIVO"
        Me.cbActivoHabilitado.UseVisualStyleBackColor = True
        '
        'btnOrden
        '
        Me.btnOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrden.Location = New System.Drawing.Point(637, 94)
        Me.btnOrden.Name = "btnOrden"
        Me.btnOrden.Size = New System.Drawing.Size(274, 38)
        Me.btnOrden.TabIndex = 55
        Me.btnOrden.Text = "Orden de Instalación"
        Me.btnOrden.UseVisualStyleBackColor = True
        '
        'Numero
        '
        Me.Numero.AutoSize = True
        Me.Numero.Location = New System.Drawing.Point(56, 13)
        Me.Numero.Name = "Numero"
        Me.Numero.Size = New System.Drawing.Size(13, 13)
        Me.Numero.TabIndex = 54
        Me.Numero.Text = "0"
        '
        'dgvClientesNuevos
        '
        Me.dgvClientesNuevos.AllowUserToAddRows = False
        Me.dgvClientesNuevos.AllowUserToDeleteRows = False
        Me.dgvClientesNuevos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvClientesNuevos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientesNuevos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column1, Me.usuario, Me.ubicacion})
        Me.dgvClientesNuevos.Location = New System.Drawing.Point(22, 220)
        Me.dgvClientesNuevos.Name = "dgvClientesNuevos"
        Me.dgvClientesNuevos.ReadOnly = True
        Me.dgvClientesNuevos.RowHeadersVisible = False
        Me.dgvClientesNuevos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientesNuevos.Size = New System.Drawing.Size(885, 323)
        Me.dgvClientesNuevos.TabIndex = 53
        '
        'Column5
        '
        Me.Column5.HeaderText = "Id"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nombre"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 200
        '
        'Column7
        '
        Me.Column7.HeaderText = "Teléfono"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "departamento"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "municipio"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Comunidad"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Correo"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "activo"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "DEI"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Dirección"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'usuario
        '
        Me.usuario.HeaderText = "usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "Ubicacion"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.ReadOnly = True
        '
        'txtDireccionExacta
        '
        Me.txtDireccionExacta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionExacta.Location = New System.Drawing.Point(143, 160)
        Me.txtDireccionExacta.Name = "txtDireccionExacta"
        Me.txtDireccionExacta.Size = New System.Drawing.Size(341, 20)
        Me.txtDireccionExacta.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(51, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Dirección"
        '
        'txtRecuento
        '
        Me.txtRecuento.AutoSize = True
        Me.txtRecuento.Location = New System.Drawing.Point(6, 546)
        Me.txtRecuento.Name = "txtRecuento"
        Me.txtRecuento.Size = New System.Drawing.Size(39, 13)
        Me.txtRecuento.TabIndex = 50
        Me.txtRecuento.Text = "Label8"
        '
        'BuscarComunidad
        '
        Me.BuscarComunidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarComunidad.Location = New System.Drawing.Point(491, 144)
        Me.BuscarComunidad.Name = "BuscarComunidad"
        Me.BuscarComunidad.Size = New System.Drawing.Size(22, 18)
        Me.BuscarComunidad.TabIndex = 16
        Me.BuscarComunidad.Text = ". . ."
        Me.BuscarComunidad.UseVisualStyleBackColor = True
        '
        'cmbNombreComunidad1
        '
        Me.cmbNombreComunidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreComunidad1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombreComunidad1.FormattingEnabled = True
        Me.cmbNombreComunidad1.Location = New System.Drawing.Point(235, 141)
        Me.cmbNombreComunidad1.Name = "cmbNombreComunidad1"
        Me.cmbNombreComunidad1.Size = New System.Drawing.Size(250, 21)
        Me.cmbNombreComunidad1.TabIndex = 9
        '
        'cbSar
        '
        Me.cbSar.AutoSize = True
        Me.cbSar.Checked = True
        Me.cbSar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSar.Location = New System.Drawing.Point(496, 55)
        Me.cbSar.Name = "cbSar"
        Me.cbSar.Size = New System.Drawing.Size(127, 17)
        Me.cbSar.TabIndex = 49
        Me.cbSar.Text = "FACTURACION SAR"
        Me.cbSar.UseVisualStyleBackColor = True
        '
        'cmbCodigoComunidad1
        '
        Me.cmbCodigoComunidad1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodigoComunidad1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodigoComunidad1.FormattingEnabled = True
        Me.cmbCodigoComunidad1.Location = New System.Drawing.Point(143, 141)
        Me.cmbCodigoComunidad1.Name = "cmbCodigoComunidad1"
        Me.cmbCodigoComunidad1.Size = New System.Drawing.Size(90, 21)
        Me.cmbCodigoComunidad1.TabIndex = 8
        '
        'btnReporte
        '
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(777, 15)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(134, 38)
        Me.btnReporte.TabIndex = 48
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'BuscarMunicipio
        '
        Me.BuscarMunicipio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarMunicipio.Location = New System.Drawing.Point(491, 126)
        Me.BuscarMunicipio.Name = "BuscarMunicipio"
        Me.BuscarMunicipio.Size = New System.Drawing.Size(22, 18)
        Me.BuscarMunicipio.TabIndex = 7
        Me.BuscarMunicipio.Text = ". . ."
        Me.BuscarMunicipio.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(777, 53)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(134, 38)
        Me.btnEliminar.TabIndex = 47
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'cmbCodigoMunicipio1
        '
        Me.cmbCodigoMunicipio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodigoMunicipio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodigoMunicipio1.FormattingEnabled = True
        Me.cmbCodigoMunicipio1.Location = New System.Drawing.Point(143, 122)
        Me.cmbCodigoMunicipio1.Name = "cmbCodigoMunicipio1"
        Me.cmbCodigoMunicipio1.Size = New System.Drawing.Size(90, 21)
        Me.cmbCodigoMunicipio1.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(637, 53)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(134, 38)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cmbNombreMunicipio1
        '
        Me.cmbNombreMunicipio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreMunicipio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombreMunicipio1.FormattingEnabled = True
        Me.cmbNombreMunicipio1.Location = New System.Drawing.Point(235, 122)
        Me.cmbNombreMunicipio1.Name = "cmbNombreMunicipio1"
        Me.cmbNombreMunicipio1.Size = New System.Drawing.Size(250, 21)
        Me.cmbNombreMunicipio1.TabIndex = 7
        '
        'btnNuevo
        '
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(637, 15)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(134, 38)
        Me.btnNuevo.TabIndex = 45
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'BuscarDepartamento
        '
        Me.BuscarDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarDepartamento.Location = New System.Drawing.Point(491, 108)
        Me.BuscarDepartamento.Name = "BuscarDepartamento"
        Me.BuscarDepartamento.Size = New System.Drawing.Size(22, 18)
        Me.BuscarDepartamento.TabIndex = 6
        Me.BuscarDepartamento.Text = ". . ."
        Me.BuscarDepartamento.UseVisualStyleBackColor = True
        '
        'cbActivoSistema
        '
        Me.cbActivoSistema.AutoSize = True
        Me.cbActivoSistema.Checked = True
        Me.cbActivoSistema.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActivoSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivoSistema.Location = New System.Drawing.Point(496, 25)
        Me.cbActivoSistema.Name = "cbActivoSistema"
        Me.cbActivoSistema.Size = New System.Drawing.Size(65, 17)
        Me.cbActivoSistema.TabIndex = 44
        Me.cbActivoSistema.Text = "ACTIVO"
        Me.cbActivoSistema.UseVisualStyleBackColor = True
        '
        'cmbNombreDepartamento1
        '
        Me.cmbNombreDepartamento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreDepartamento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombreDepartamento1.FormattingEnabled = True
        Me.cmbNombreDepartamento1.Location = New System.Drawing.Point(235, 103)
        Me.cmbNombreDepartamento1.Name = "cmbNombreDepartamento1"
        Me.cmbNombreDepartamento1.Size = New System.Drawing.Size(250, 21)
        Me.cmbNombreDepartamento1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "No. de Identidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Municipio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Teléfono"
        '
        'cmbCodigoDepartamento1
        '
        Me.cmbCodigoDepartamento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodigoDepartamento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodigoDepartamento1.FormattingEnabled = True
        Me.cmbCodigoDepartamento1.Location = New System.Drawing.Point(143, 103)
        Me.cmbCodigoDepartamento1.Name = "cmbCodigoDepartamento1"
        Me.cmbCodigoDepartamento1.Size = New System.Drawing.Size(90, 21)
        Me.cmbCodigoDepartamento1.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Departamento"
        '
        'txtCorreo
        '
        Me.txtCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorreo.Location = New System.Drawing.Point(143, 85)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(342, 20)
        Me.txtCorreo.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Comunidad"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(143, 67)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(342, 20)
        Me.txtTelefono.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Correo"
        '
        'txtIdentidad
        '
        Me.txtIdentidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentidad.Location = New System.Drawing.Point(143, 31)
        Me.txtIdentidad.Name = "txtIdentidad"
        Me.txtIdentidad.Size = New System.Drawing.Size(342, 20)
        Me.txtIdentidad.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(143, 49)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(342, 20)
        Me.txtNombre.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(115, 26)
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.LimpiarToolStripMenuItem.Text = "Limpiar"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(967, 22)
        Me.StatusStrip1.TabIndex = 59
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(64, 17)
        Me.ToolStripStatusLabel1.Text = "F2 Guardar"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel2.Text = "F3 Nuevo"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(63, 17)
        Me.ToolStripStatusLabel3.Text = "F4 Reporte"
        '
        'clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 626)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "clientes"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvClientesNuevos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LimpiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbActivoSistema As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdentidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents cbSar As System.Windows.Forms.CheckBox
    Friend WithEvents BuscarComunidad As System.Windows.Forms.Button
    Friend WithEvents cmbNombreComunidad1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCodigoComunidad1 As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarMunicipio As System.Windows.Forms.Button
    Friend WithEvents cmbCodigoMunicipio1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNombreMunicipio1 As System.Windows.Forms.ComboBox
    Friend WithEvents BuscarDepartamento As System.Windows.Forms.Button
    Friend WithEvents cmbNombreDepartamento1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCodigoDepartamento1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRecuento As System.Windows.Forms.Label
    Friend WithEvents txtDireccionExacta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvClientesNuevos As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Numero As System.Windows.Forms.Label
    Friend WithEvents btnOrden As System.Windows.Forms.Button
    Friend WithEvents cbActivoHabilitado As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbUsuarioCliente As ComboBox
    Friend WithEvents btnReclamos As Button
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
End Class
