<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servidores
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvServidores = New System.Windows.Forms.DataGridView()
        Me.nO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Puerto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VLAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contraeña = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnEquipo = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVLAN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgvServidores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "IP API"
        '
        'dgvServidores
        '
        Me.dgvServidores.AllowUserToAddRows = False
        Me.dgvServidores.AllowUserToDeleteRows = False
        Me.dgvServidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServidores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nO, Me.Nombre, Me.Ip, Me.Puerto, Me.Lugar, Me.VLAN, Me.usuario, Me.contraeña})
        Me.dgvServidores.Location = New System.Drawing.Point(13, 112)
        Me.dgvServidores.Name = "dgvServidores"
        Me.dgvServidores.ReadOnly = True
        Me.dgvServidores.RowHeadersVisible = False
        Me.dgvServidores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServidores.Size = New System.Drawing.Size(654, 144)
        Me.dgvServidores.TabIndex = 61
        '
        'nO
        '
        Me.nO.HeaderText = "No"
        Me.nO.Name = "nO"
        Me.nO.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Equipo"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 150
        '
        'Ip
        '
        Me.Ip.HeaderText = "Ip"
        Me.Ip.Name = "Ip"
        Me.Ip.ReadOnly = True
        '
        'Puerto
        '
        Me.Puerto.HeaderText = "Puerto API"
        Me.Puerto.Name = "Puerto"
        Me.Puerto.ReadOnly = True
        '
        'Lugar
        '
        Me.Lugar.HeaderText = "Ubicación"
        Me.Lugar.Name = "Lugar"
        Me.Lugar.ReadOnly = True
        '
        'VLAN
        '
        Me.VLAN.HeaderText = "VLAN"
        Me.VLAN.Name = "VLAN"
        Me.VLAN.ReadOnly = True
        '
        'usuario
        '
        Me.usuario.HeaderText = "usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        Me.usuario.Visible = False
        '
        'contraeña
        '
        Me.contraeña.HeaderText = "contraseña"
        Me.contraeña.Name = "contraeña"
        Me.contraeña.ReadOnly = True
        Me.contraeña.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(112, 40)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(171, 20)
        Me.txtNombre.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Equipo"
        '
        'txtNo
        '
        Me.txtNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNo.Location = New System.Drawing.Point(112, 20)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Size = New System.Drawing.Size(171, 20)
        Me.txtNo.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Servidor No."
        '
        'txtIP
        '
        Me.txtIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIP.Location = New System.Drawing.Point(112, 60)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(171, 20)
        Me.txtIP.TabIndex = 65
        '
        'Eliminar
        '
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.Location = New System.Drawing.Point(342, 293)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(111, 39)
        Me.Eliminar.TabIndex = 63
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(225, 293)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(111, 39)
        Me.Guardar.TabIndex = 62
        Me.Guardar.Text = "Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'txtLogin
        '
        Me.txtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogin.Location = New System.Drawing.Point(464, 23)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(171, 20)
        Me.txtLogin.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(396, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Login"
        '
        'btnEquipo
        '
        Me.btnEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipo.Location = New System.Drawing.Point(289, 35)
        Me.btnEquipo.Name = "btnEquipo"
        Me.btnEquipo.Size = New System.Drawing.Size(94, 29)
        Me.btnEquipo.TabIndex = 118
        Me.btnEquipo.Text = "Equipo"
        Me.btnEquipo.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(464, 43)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(171, 20)
        Me.txtPassword.TabIndex = 120
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(396, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Password"
        '
        'txtPuerto
        '
        Me.txtPuerto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuerto.Location = New System.Drawing.Point(112, 80)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(171, 20)
        Me.txtPuerto.TabIndex = 122
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Puerto API"
        '
        'txtVLAN
        '
        Me.txtVLAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVLAN.Location = New System.Drawing.Point(464, 83)
        Me.txtVLAN.Name = "txtVLAN"
        Me.txtVLAN.Size = New System.Drawing.Size(171, 20)
        Me.txtVLAN.TabIndex = 126
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(396, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "VLAN"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Location = New System.Drawing.Point(464, 63)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(171, 20)
        Me.txtUbicacion.TabIndex = 124
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(396, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "Ubicación"
        '
        'Servidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 344)
        Me.Controls.Add(Me.txtVLAN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUbicacion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnEquipo)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Eliminar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.dgvServidores)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Servidores"
        Me.Text = "Servidores"
        CType(Me.dgvServidores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Eliminar As Button
    Friend WithEvents Guardar As Button
    Friend WithEvents dgvServidores As DataGridView
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIP As TextBox
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnEquipo As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents nO As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Ip As DataGridViewTextBoxColumn
    Friend WithEvents Puerto As DataGridViewTextBoxColumn
    Friend WithEvents Lugar As DataGridViewTextBoxColumn
    Friend WithEvents VLAN As DataGridViewTextBoxColumn
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents contraeña As DataGridViewTextBoxColumn
    Friend WithEvents txtPuerto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVLAN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents Label8 As Label
End Class
