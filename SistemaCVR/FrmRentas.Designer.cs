namespace SistemaCVR
{
    partial class FrmRentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRentas = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.grpDatosRenta = new System.Windows.Forms.GroupBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblPrecioHora = new System.Windows.Forms.Label();
            this.txtPrecioHora = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAsignarEquipo = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.grpBuscarRenta = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRentasActivas = new System.Windows.Forms.Button();
            this.dgvRentas = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoRenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDatosRenta.SuspendLayout();
            this.grpBuscarRenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRentas
            // 
            this.lblRentas.AutoSize = true;
            this.lblRentas.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.lblRentas.Location = new System.Drawing.Point(12, 9);
            this.lblRentas.Name = "lblRentas";
            this.lblRentas.Size = new System.Drawing.Size(72, 28);
            this.lblRentas.TabIndex = 0;
            this.lblRentas.Text = "Rentas";
            // 
            // lblLinea
            // 
            this.lblLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.lblLinea.Location = new System.Drawing.Point(9, 90);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(1700, 1);
            this.lblLinea.TabIndex = 1;
            // 
            // grpDatosRenta
            // 
            this.grpDatosRenta.Controls.Add(this.lblCliente);
            this.grpDatosRenta.Controls.Add(this.cmbCliente);
            this.grpDatosRenta.Controls.Add(this.lblVehiculo);
            this.grpDatosRenta.Controls.Add(this.cmbVehiculo);
            this.grpDatosRenta.Controls.Add(this.lblEmpleado);
            this.grpDatosRenta.Controls.Add(this.cmbEmpleado);
            this.grpDatosRenta.Controls.Add(this.lblFechaInicio);
            this.grpDatosRenta.Controls.Add(this.dtpFechaInicio);
            this.grpDatosRenta.Controls.Add(this.lblFechaFin);
            this.grpDatosRenta.Controls.Add(this.dtpFechaFin);
            this.grpDatosRenta.Controls.Add(this.lblPrecioHora);
            this.grpDatosRenta.Controls.Add(this.txtPrecioHora);
            this.grpDatosRenta.Controls.Add(this.lblObservaciones);
            this.grpDatosRenta.Controls.Add(this.txtObservaciones);
            this.grpDatosRenta.Controls.Add(this.btnGuardar);
            this.grpDatosRenta.Controls.Add(this.btnLimpiar);
            this.grpDatosRenta.Controls.Add(this.btnAsignarEquipo);
            this.grpDatosRenta.Controls.Add(this.btnDevolver);
            this.grpDatosRenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosRenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.grpDatosRenta.Location = new System.Drawing.Point(12, 103);
            this.grpDatosRenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatosRenta.Name = "grpDatosRenta";
            this.grpDatosRenta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatosRenta.Size = new System.Drawing.Size(712, 734);
            this.grpDatosRenta.TabIndex = 2;
            this.grpDatosRenta.TabStop = false;
            this.grpDatosRenta.Text = "Datos de la renta";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(13, 52);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(94, 28);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.ForeColor = System.Drawing.Color.Black;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(200, 48);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(485, 36);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(13, 114);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(105, 28);
            this.lblVehiculo.TabIndex = 2;
            this.lblVehiculo.Text = "Vehículo:";
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVehiculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVehiculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehiculo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVehiculo.ForeColor = System.Drawing.Color.Black;
            this.cmbVehiculo.FormattingEnabled = true;
            this.cmbVehiculo.Location = new System.Drawing.Point(200, 110);
            this.cmbVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(485, 36);
            this.cmbVehiculo.TabIndex = 3;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(13, 176);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(105, 28);
            this.lblEmpleado.TabIndex = 4;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleado.ForeColor = System.Drawing.Color.Black;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(200, 172);
            this.cmbEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(485, 36);
            this.cmbEmpleado.TabIndex = 5;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(13, 238);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(182, 28);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha de inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaInicio.Location = new System.Drawing.Point(200, 234);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(250, 34);
            this.dtpFechaInicio.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(13, 300);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(149, 28);
            this.lblFechaFin.TabIndex = 8;
            this.lblFechaFin.Text = "Fin previsto:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaFin.Location = new System.Drawing.Point(200, 296);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(250, 34);
            this.dtpFechaFin.TabIndex = 9;
            // 
            // lblPrecioHora
            // 
            this.lblPrecioHora.AutoSize = true;
            this.lblPrecioHora.Location = new System.Drawing.Point(13, 362);
            this.lblPrecioHora.Name = "lblPrecioHora";
            this.lblPrecioHora.Size = new System.Drawing.Size(182, 28);
            this.lblPrecioHora.TabIndex = 10;
            this.lblPrecioHora.Text = "Precio por hora:";
            // 
            // txtPrecioHora
            // 
            this.txtPrecioHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioHora.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioHora.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioHora.Location = new System.Drawing.Point(200, 358);
            this.txtPrecioHora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioHora.MaxLength = 13;
            this.txtPrecioHora.Name = "txtPrecioHora";
            this.txtPrecioHora.Size = new System.Drawing.Size(200, 34);
            this.txtPrecioHora.TabIndex = 11;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(13, 424);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(160, 28);
            this.lblObservaciones.TabIndex = 12;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(13, 462);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(672, 120);
            this.txtObservaciones.TabIndex = 13;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnGuardar.Location = new System.Drawing.Point(456, 600);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 39);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnLimpiar.Location = new System.Drawing.Point(584, 600);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 39);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAsignarEquipo
            // 
            this.btnAsignarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAsignarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAsignarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsignarEquipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnAsignarEquipo.Location = new System.Drawing.Point(330, 655);
            this.btnAsignarEquipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAsignarEquipo.Name = "btnAsignarEquipo";
            this.btnAsignarEquipo.Size = new System.Drawing.Size(175, 39);
            this.btnAsignarEquipo.TabIndex = 16;
            this.btnAsignarEquipo.Text = "Asignar equipo";
            this.btnAsignarEquipo.UseVisualStyleBackColor = false;
            this.btnAsignarEquipo.Click += new System.EventHandler(this.btnAsignarEquipo_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDevolver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnDevolver.Location = new System.Drawing.Point(515, 655);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(170, 39);
            this.btnDevolver.TabIndex = 17;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // grpBuscarRenta
            // 
            this.grpBuscarRenta.Controls.Add(this.txtBuscar);
            this.grpBuscarRenta.Controls.Add(this.btnBuscar);
            this.grpBuscarRenta.Controls.Add(this.btnRentasActivas);
            this.grpBuscarRenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBuscarRenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.grpBuscarRenta.Location = new System.Drawing.Point(747, 103);
            this.grpBuscarRenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBuscarRenta.Name = "grpBuscarRenta";
            this.grpBuscarRenta.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBuscarRenta.Size = new System.Drawing.Size(956, 100);
            this.grpBuscarRenta.TabIndex = 3;
            this.grpBuscarRenta.TabStop = false;
            this.grpBuscarRenta.Text = "Historial de rentas";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(5, 46);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(359, 34);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(371, 46);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(56, 34);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRentasActivas
            // 
            this.btnRentasActivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRentasActivas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRentasActivas.FlatAppearance.BorderSize = 0;
            this.btnRentasActivas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRentasActivas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentasActivas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnRentasActivas.Location = new System.Drawing.Point(445, 43);
            this.btnRentasActivas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentasActivas.Name = "btnRentasActivas";
            this.btnRentasActivas.Size = new System.Drawing.Size(170, 39);
            this.btnRentasActivas.TabIndex = 2;
            this.btnRentasActivas.Text = "Rentas activas";
            this.btnRentasActivas.UseVisualStyleBackColor = false;
            this.btnRentasActivas.Click += new System.EventHandler(this.btnRentasActivas_Click);
            // 
            // dgvRentas
            // 
            this.dgvRentas.AllowUserToAddRows = false;
            this.dgvRentas.AllowUserToDeleteRows = false;
            this.dgvRentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCliente,
            this.colVehiculo,
            this.colEmpleado,
            this.colFechaInicio,
            this.colFechaFin,
            this.colFechaDevolucion,
            this.colPrecioHora,
            this.colEstadoRenta,
            this.colObservaciones});
            this.dgvRentas.Location = new System.Drawing.Point(752, 207);
            this.dgvRentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRentas.MultiSelect = false;
            this.dgvRentas.Name = "dgvRentas";
            this.dgvRentas.ReadOnly = true;
            this.dgvRentas.RowHeadersWidth = 51;
            this.dgvRentas.RowTemplate.Height = 24;
            this.dgvRentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentas.Size = new System.Drawing.Size(951, 623);
            this.dgvRentas.TabIndex = 4;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id_renta";
            this.colID.FillWeight = 40F;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 125;
            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.FillWeight = 130F;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.MinimumWidth = 6;
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 125;
            // 
            // colVehiculo
            // 
            this.colVehiculo.DataPropertyName = "Vehiculo";
            this.colVehiculo.FillWeight = 170F;
            this.colVehiculo.HeaderText = "Vehículo";
            this.colVehiculo.MinimumWidth = 6;
            this.colVehiculo.Name = "colVehiculo";
            this.colVehiculo.ReadOnly = true;
            this.colVehiculo.Width = 125;
            // 
            // colEmpleado
            // 
            this.colEmpleado.DataPropertyName = "Empleado";
            this.colEmpleado.FillWeight = 110F;
            this.colEmpleado.HeaderText = "Empleado";
            this.colEmpleado.MinimumWidth = 6;
            this.colEmpleado.Name = "colEmpleado";
            this.colEmpleado.ReadOnly = true;
            this.colEmpleado.Width = 125;
            // 
            // colFechaInicio
            // 
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.colFechaInicio.DataPropertyName = "fecha_inicio";
            this.colFechaInicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.colFechaInicio.FillWeight = 105F;
            this.colFechaInicio.HeaderText = "Inicio";
            this.colFechaInicio.MinimumWidth = 6;
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.ReadOnly = true;
            this.colFechaInicio.Width = 125;
            // 
            // colFechaFin
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.colFechaFin.DataPropertyName = "fecha_fin";
            this.colFechaFin.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFechaFin.FillWeight = 105F;
            this.colFechaFin.HeaderText = "Fin previsto";
            this.colFechaFin.MinimumWidth = 6;
            this.colFechaFin.Name = "colFechaFin";
            this.colFechaFin.ReadOnly = true;
            this.colFechaFin.Width = 125;
            // 
            // colFechaDevolucion
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle3.NullValue = null;
            this.colFechaDevolucion.DataPropertyName = "fecha_devolucion";
            this.colFechaDevolucion.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaDevolucion.FillWeight = 105F;
            this.colFechaDevolucion.HeaderText = "Devolución";
            this.colFechaDevolucion.MinimumWidth = 6;
            this.colFechaDevolucion.Name = "colFechaDevolucion";
            this.colFechaDevolucion.ReadOnly = true;
            this.colFechaDevolucion.Width = 125;
            // 
            // colPrecioHora
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.colPrecioHora.DataPropertyName = "precioHora";
            this.colPrecioHora.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPrecioHora.FillWeight = 80F;
            this.colPrecioHora.HeaderText = "Precio por hora";
            this.colPrecioHora.MinimumWidth = 6;
            this.colPrecioHora.Name = "colPrecioHora";
            this.colPrecioHora.ReadOnly = true;
            this.colPrecioHora.Width = 125;
            // 
            // colEstadoRenta
            // 
            this.colEstadoRenta.DataPropertyName = "estadoRenta";
            this.colEstadoRenta.FillWeight = 80F;
            this.colEstadoRenta.HeaderText = "Estado";
            this.colEstadoRenta.MinimumWidth = 6;
            this.colEstadoRenta.Name = "colEstadoRenta";
            this.colEstadoRenta.ReadOnly = true;
            this.colEstadoRenta.Width = 125;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "observaciones";
            this.colObservaciones.FillWeight = 170F;
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.MinimumWidth = 6;
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            this.colObservaciones.Width = 125;
            // 
            // FrmRentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1722, 953);
            this.ControlBox = false;
            this.Controls.Add(this.lblRentas);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.grpDatosRenta);
            this.Controls.Add(this.grpBuscarRenta);
            this.Controls.Add(this.dgvRentas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRentas";
            this.Text = "Rentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRentas_Load);
            this.grpDatosRenta.ResumeLayout(false);
            this.grpDatosRenta.PerformLayout();
            this.grpBuscarRenta.ResumeLayout(false);
            this.grpBuscarRenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRentas;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.GroupBox grpDatosRenta;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.ComboBox cmbVehiculo;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblPrecioHora;
        private System.Windows.Forms.TextBox txtPrecioHora;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAsignarEquipo;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.GroupBox grpBuscarRenta;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRentasActivas;
        private System.Windows.Forms.DataGridView dgvRentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoRenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
    }
}
