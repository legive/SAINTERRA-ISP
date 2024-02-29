<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventarioEquipo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbSubCategoria = New System.Windows.Forms.ComboBox()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.dgvEquipo = New System.Windows.Forms.DataGridView()
        Me.MAC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbRouterNo = New System.Windows.Forms.RadioButton()
        Me.rbRouterSi = New System.Windows.Forms.RadioButton()
        Me.txtRouter = New System.Windows.Forms.TextBox()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Correo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dirección = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbEquipo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEquipo)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnReporte)
        Me.GroupBox1.Controls.Add(Me.Eliminar)
        Me.GroupBox1.Controls.Add(Me.Guardar)
        Me.GroupBox1.Controls.Add(Me.Nuevo)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.cmbSubCategoria)
        Me.GroupBox1.Controls.Add(Me.cmbCategoria)
        Me.GroupBox1.Controls.Add(Me.dgvEquipo)
        Me.GroupBox1.Controls.Add(Me.MAC)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 472)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmbSubCategoria
        '
        Me.cmbSubCategoria.AutoCompleteCustomSource.AddRange(New String() {"Primera Instalación", "Reinstalación"})
        Me.cmbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubCategoria.FormattingEnabled = True
        Me.cmbSubCategoria.Items.AddRange(New Object() {"2.4 GHZ", "5.8 GHZ"})
        Me.cmbSubCategoria.Location = New System.Drawing.Point(84, 40)
        Me.cmbSubCategoria.Name = "cmbSubCategoria"
        Me.cmbSubCategoria.Size = New System.Drawing.Size(328, 21)
        Me.cmbSubCategoria.TabIndex = 55
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoCompleteCustomSource.AddRange(New String() {"Primera Instalación", "Reinstalación"})
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Items.AddRange(New Object() {"Ubiquiti", "Mikrotik"})
        Me.cmbCategoria.Location = New System.Drawing.Point(84, 19)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(328, 21)
        Me.cmbCategoria.TabIndex = 54
        '
        'dgvEquipo
        '
        Me.dgvEquipo.AllowUserToAddRows = False
        Me.dgvEquipo.AllowUserToDeleteRows = False
        Me.dgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Correo, Me.Dirección})
        Me.dgvEquipo.Location = New System.Drawing.Point(11, 183)
        Me.dgvEquipo.Name = "dgvEquipo"
        Me.dgvEquipo.ReadOnly = True
        Me.dgvEquipo.RowHeadersVisible = False
        Me.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEquipo.Size = New System.Drawing.Size(558, 223)
        Me.dgvEquipo.TabIndex = 49
        '
        'MAC
        '
        Me.MAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MAC.Location = New System.Drawing.Point(84, 61)
        Me.MAC.Name = "MAC"
        Me.MAC.Size = New System.Drawing.Size(328, 20)
        Me.MAC.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MAC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SubCategoria"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Categoria"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbRouterNo)
        Me.GroupBox3.Controls.Add(Me.txtRouter)
        Me.GroupBox3.Controls.Add(Me.rbRouterSi)
        Me.GroupBox3.Location = New System.Drawing.Point(84, 107)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(328, 56)
        Me.GroupBox3.TabIndex = 112
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "En uso"
        '
        'rbRouterNo
        '
        Me.rbRouterNo.AutoSize = True
        Me.rbRouterNo.Location = New System.Drawing.Point(8, 34)
        Me.rbRouterNo.Name = "rbRouterNo"
        Me.rbRouterNo.Size = New System.Drawing.Size(39, 17)
        Me.rbRouterNo.TabIndex = 109
        Me.rbRouterNo.Text = "No"
        Me.rbRouterNo.UseVisualStyleBackColor = True
        '
        'rbRouterSi
        '
        Me.rbRouterSi.AutoSize = True
        Me.rbRouterSi.Checked = True
        Me.rbRouterSi.Location = New System.Drawing.Point(8, 13)
        Me.rbRouterSi.Name = "rbRouterSi"
        Me.rbRouterSi.Size = New System.Drawing.Size(34, 17)
        Me.rbRouterSi.TabIndex = 108
        Me.rbRouterSi.TabStop = True
        Me.rbRouterSi.Text = "Si"
        Me.rbRouterSi.UseVisualStyleBackColor = True
        '
        'txtRouter
        '
        Me.txtRouter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRouter.Location = New System.Drawing.Point(53, 30)
        Me.txtRouter.Name = "txtRouter"
        Me.txtRouter.Size = New System.Drawing.Size(219, 20)
        Me.txtRouter.TabIndex = 79
        '
        'btnReporte
        '
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.btnReporte.Image = Global.SA_INTERRA.My.Resources.Resources.Printer
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(406, 428)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(106, 38)
        Me.btnReporte.TabIndex = 116
        Me.btnReporte.Text = "Imprimir"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.Eliminar.Image = Global.SA_INTERRA.My.Resources.Resources.Symbol_Delete
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.Location = New System.Drawing.Point(281, 428)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(106, 38)
        Me.Eliminar.TabIndex = 115
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.Guardar.Image = Global.SA_INTERRA.My.Resources.Resources.Save
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(156, 428)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(106, 38)
        Me.Guardar.TabIndex = 113
        Me.Guardar.Text = "Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Nuevo
        '
        Me.Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.Nuevo.Image = Global.SA_INTERRA.My.Resources.Resources.Document1
        Me.Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nuevo.Location = New System.Drawing.Point(31, 428)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(106, 38)
        Me.Nuevo.TabIndex = 114
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Categoria"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "SubCategoria"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'Correo
        '
        Me.Correo.Frozen = True
        Me.Correo.HeaderText = "MAC"
        Me.Correo.Name = "Correo"
        Me.Correo.ReadOnly = True
        '
        'Dirección
        '
        Me.Dirección.Frozen = True
        Me.Dirección.HeaderText = "Descripción"
        Me.Dirección.Name = "Dirección"
        Me.Dirección.ReadOnly = True
        Me.Dirección.Width = 150
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(418, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 117
        Me.Button1.Text = "Equipo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbEquipo
        '
        Me.cmbEquipo.FormattingEnabled = True
        Me.cmbEquipo.Location = New System.Drawing.Point(84, 82)
        Me.cmbEquipo.Name = "cmbEquipo"
        Me.cmbEquipo.Size = New System.Drawing.Size(328, 21)
        Me.cmbEquipo.TabIndex = 118
        '
        'InventarioEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 497)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "InventarioEquipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario de Equipo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSubCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEquipo As System.Windows.Forms.DataGridView
    Friend WithEvents MAC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbRouterNo As RadioButton
    Friend WithEvents txtRouter As TextBox
    Friend WithEvents rbRouterSi As RadioButton
    Friend WithEvents btnReporte As Button
    Friend WithEvents Eliminar As Button
    Friend WithEvents Guardar As Button
    Friend WithEvents Nuevo As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Correo As DataGridViewTextBoxColumn
    Friend WithEvents Dirección As DataGridViewTextBoxColumn
    Friend WithEvents cmbEquipo As ComboBox
    Friend WithEvents Button1 As Button
End Class
