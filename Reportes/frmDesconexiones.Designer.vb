<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDesconexiones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesconexiones))
        Me.dgvDesconexiones = New System.Windows.Forms.DataGridView()
        Me.cdRetirar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EquipoRetiradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquipoNoRetiradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObservaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbRetirados = New System.Windows.Forms.CheckBox()
        Me.cbTodos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Municipio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.equipoRetirado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDesconexiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cdRetirar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDesconexiones
        '
        Me.dgvDesconexiones.AllowUserToAddRows = False
        Me.dgvDesconexiones.AllowUserToDeleteRows = False
        Me.dgvDesconexiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDesconexiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDesconexiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Municipio, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.equipoRetirado, Me.Observacion, Me.Equipo})
        Me.dgvDesconexiones.ContextMenuStrip = Me.cdRetirar
        Me.dgvDesconexiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDesconexiones.Location = New System.Drawing.Point(4, 69)
        Me.dgvDesconexiones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvDesconexiones.Name = "dgvDesconexiones"
        Me.dgvDesconexiones.ReadOnly = True
        Me.dgvDesconexiones.RowHeadersVisible = False
        Me.dgvDesconexiones.RowHeadersWidth = 51
        Me.dgvDesconexiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDesconexiones.Size = New System.Drawing.Size(1340, 741)
        Me.dgvDesconexiones.TabIndex = 28
        '
        'cdRetirar
        '
        Me.cdRetirar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cdRetirar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EquipoRetiradoToolStripMenuItem, Me.EquipoNoRetiradoToolStripMenuItem, Me.ObservaciónToolStripMenuItem})
        Me.cdRetirar.Name = "ContextMenuStrip1"
        Me.cdRetirar.Size = New System.Drawing.Size(204, 76)
        '
        'EquipoRetiradoToolStripMenuItem
        '
        Me.EquipoRetiradoToolStripMenuItem.Name = "EquipoRetiradoToolStripMenuItem"
        Me.EquipoRetiradoToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.EquipoRetiradoToolStripMenuItem.Text = "Equipo retirado"
        '
        'EquipoNoRetiradoToolStripMenuItem
        '
        Me.EquipoNoRetiradoToolStripMenuItem.Name = "EquipoNoRetiradoToolStripMenuItem"
        Me.EquipoNoRetiradoToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.EquipoNoRetiradoToolStripMenuItem.Text = "Equipo no retirado"
        '
        'ObservaciónToolStripMenuItem
        '
        Me.ObservaciónToolStripMenuItem.Name = "ObservaciónToolStripMenuItem"
        Me.ObservaciónToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.ObservaciónToolStripMenuItem.Text = "Observación"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(295, 26)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 16)
        Me.Label29.TabIndex = 74
        Me.Label29.Text = "Fecha final:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha2.Location = New System.Drawing.Point(388, 17)
        Me.dtpFecha2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(161, 22)
        Me.dtpFecha2.TabIndex = 73
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(19, 26)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(85, 16)
        Me.Label30.TabIndex = 72
        Me.Label30.Text = "Fecha inicial:"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha1.Location = New System.Drawing.Point(121, 17)
        Me.dtpFecha1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(161, 22)
        Me.dtpFecha1.TabIndex = 71
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(768, 14)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 75
        Me.Button1.Text = "Mostrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbRetirados
        '
        Me.cbRetirados.AutoSize = True
        Me.cbRetirados.Checked = True
        Me.cbRetirados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRetirados.Location = New System.Drawing.Point(561, 21)
        Me.cbRetirados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbRetirados.Name = "cbRetirados"
        Me.cbRetirados.Size = New System.Drawing.Size(103, 20)
        Me.cbRetirados.TabIndex = 76
        Me.cbRetirados.Text = "No retirados"
        Me.cbRetirados.UseVisualStyleBackColor = True
        '
        'cbTodos
        '
        Me.cbTodos.AutoSize = True
        Me.cbTodos.Location = New System.Drawing.Point(683, 21)
        Me.cbTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbTodos.Name = "cbTodos"
        Me.cbTodos.Size = New System.Drawing.Size(69, 20)
        Me.cbTodos.TabIndex = 77
        Me.cbTodos.Text = "Todos"
        Me.cbTodos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbTodos)
        Me.GroupBox1.Controls.Add(Me.cbRetirados)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.dtpFecha2)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.dtpFecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(892, 57)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDesconexiones, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1348, 814)
        Me.TableLayoutPanel1.TabIndex = 79
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "No"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Municipio
        '
        Me.Municipio.HeaderText = "Municipio"
        Me.Municipio.MinimumWidth = 6
        Me.Municipio.Name = "Municipio"
        Me.Municipio.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Direccion"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "F. corte"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "usuario"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'equipoRetirado
        '
        Me.equipoRetirado.HeaderText = "Retirado"
        Me.equipoRetirado.MinimumWidth = 6
        Me.equipoRetirado.Name = "equipoRetirado"
        Me.equipoRetirado.ReadOnly = True
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.MinimumWidth = 6
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        '
        'Equipo
        '
        Me.Equipo.HeaderText = "Equipo"
        Me.Equipo.MinimumWidth = 6
        Me.Equipo.Name = "Equipo"
        Me.Equipo.ReadOnly = True
        '
        'frmDesconexiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 814)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmDesconexiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desconexiones"
        CType(Me.dgvDesconexiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cdRetirar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDesconexiones As DataGridView
    Friend WithEvents Label29 As Label
    Friend WithEvents dtpFecha2 As DateTimePicker
    Friend WithEvents Label30 As Label
    Friend WithEvents dtpFecha1 As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents cdRetirar As ContextMenuStrip
    Friend WithEvents EquipoRetiradoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EquipoNoRetiradoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cbRetirados As CheckBox
    Friend WithEvents cbTodos As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ObservaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Municipio As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents equipoRetirado As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents Equipo As DataGridViewTextBoxColumn
End Class
