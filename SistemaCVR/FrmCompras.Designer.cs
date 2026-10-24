namespace SistemaCVR
{
    partial class FrmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompras));
            this.lblCompras = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaDeCompra = new System.Windows.Forms.DateTimePicker();
            this.txtPrecioDeCompra = new System.Windows.Forms.TextBox();
            this.txtNumeroDeMotor = new System.Windows.Forms.TextBox();
            this.txtChasis = new System.Windows.Forms.TextBox();
            this.cboPaisDeOrigen = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.nudAño = new System.Windows.Forms.NumericUpDown();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboModelo = new System.Windows.Forms.ComboBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtDescripcionObservaciones = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaisDeOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroDeMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioDeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.lblCompras.Location = new System.Drawing.Point(12, 9);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(222, 62);
            this.lblCompras.TabIndex = 2;
            this.lblCompras.Text = "Compras";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(5, 46);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(359, 34);
            this.txtBuscar.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaDeCompra);
            this.groupBox1.Controls.Add(this.txtPrecioDeCompra);
            this.groupBox1.Controls.Add(this.txtNumeroDeMotor);
            this.groupBox1.Controls.Add(this.txtChasis);
            this.groupBox1.Controls.Add(this.cboPaisDeOrigen);
            this.groupBox1.Controls.Add(this.cboColor);
            this.groupBox1.Controls.Add(this.nudAño);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Controls.Add(this.cboModelo);
            this.groupBox1.Controls.Add(this.cboMarca);
            this.groupBox1.Controls.Add(this.txtPlaca);
            this.groupBox1.Controls.Add(this.txtDescripcionObservaciones);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(712, 734);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del vehiculo";
            // 
            // dtpFechaDeCompra
            // 
            this.dtpFechaDeCompra.Location = new System.Drawing.Point(511, 372);
            this.dtpFechaDeCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaDeCompra.Name = "dtpFechaDeCompra";
            this.dtpFechaDeCompra.Size = new System.Drawing.Size(193, 34);
            this.dtpFechaDeCompra.TabIndex = 34;
            // 
            // txtPrecioDeCompra
            // 
            this.txtPrecioDeCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioDeCompra.Location = new System.Drawing.Point(511, 278);
            this.txtPrecioDeCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioDeCompra.Name = "txtPrecioDeCompra";
            this.txtPrecioDeCompra.Size = new System.Drawing.Size(194, 34);
            this.txtPrecioDeCompra.TabIndex = 33;
            // 
            // txtNumeroDeMotor
            // 
            this.txtNumeroDeMotor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDeMotor.Location = new System.Drawing.Point(19, 466);
            this.txtNumeroDeMotor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroDeMotor.Name = "txtNumeroDeMotor";
            this.txtNumeroDeMotor.Size = new System.Drawing.Size(426, 34);
            this.txtNumeroDeMotor.TabIndex = 32;
            // 
            // txtChasis
            // 
            this.txtChasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChasis.Location = new System.Drawing.Point(19, 372);
            this.txtChasis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChasis.Name = "txtChasis";
            this.txtChasis.Size = new System.Drawing.Size(426, 34);
            this.txtChasis.TabIndex = 31;
            // 
            // cboPaisDeOrigen
            // 
            this.cboPaisDeOrigen.FormattingEnabled = true;
            this.cboPaisDeOrigen.Location = new System.Drawing.Point(511, 160);
            this.cboPaisDeOrigen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPaisDeOrigen.Name = "cboPaisDeOrigen";
            this.cboPaisDeOrigen.Size = new System.Drawing.Size(193, 36);
            this.cboPaisDeOrigen.TabIndex = 30;
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(96, 160);
            this.cboColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(192, 36);
            this.cboColor.TabIndex = 29;
            // 
            // nudAño
            // 
            this.nudAño.Location = new System.Drawing.Point(511, 100);
            this.nudAño.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudAño.Name = "nudAño";
            this.nudAño.Size = new System.Drawing.Size(192, 34);
            this.nudAño.TabIndex = 28;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(96, 100);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(192, 36);
            this.cboTipo.TabIndex = 27;
            // 
            // cboModelo
            // 
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Location = new System.Drawing.Point(511, 39);
            this.cboModelo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(192, 36);
            this.cboModelo.TabIndex = 26;
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(96, 39);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(192, 36);
            this.cboMarca.TabIndex = 25;
            // 
            // txtPlaca
            // 
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Location = new System.Drawing.Point(17, 278);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(429, 34);
            this.txtPlaca.TabIndex = 24;
            // 
            // txtDescripcionObservaciones
            // 
            this.txtDescripcionObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionObservaciones.Location = new System.Drawing.Point(19, 560);
            this.txtDescripcionObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcionObservaciones.Multiline = true;
            this.txtDescripcionObservaciones.Name = "txtDescripcionObservaciones";
            this.txtDescripcionObservaciones.Size = new System.Drawing.Size(685, 167);
            this.txtDescripcionObservaciones.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(507, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 28);
            this.label12.TabIndex = 22;
            this.label12.Text = "Fecha de compra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Descripcion y observaciones:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 28);
            this.label11.TabIndex = 20;
            this.label11.Text = "Pais de Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "Precio de Compra:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Numero de Motor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 28);
            this.label9.TabIndex = 16;
            this.label9.Text = "Chasis:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 28);
            this.label10.TabIndex = 14;
            this.label10.Text = "Placa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Color:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Año:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnLimpiar.Location = new System.Drawing.Point(713, 42);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 39);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnEliminar.Location = new System.Drawing.Point(837, 41);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 39);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnEditar.Location = new System.Drawing.Point(584, 41);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(101, 39);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.btnGuardar.Location = new System.Drawing.Point(456, 41);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 39);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.groupBox2.Location = new System.Drawing.Point(747, 103);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1101, 100);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Compra";
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
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMarca,
            this.colModelo,
            this.colTipo,
            this.colAño,
            this.colPaisDeOrigen,
            this.colPlaca,
            this.colChasis,
            this.colNumeroDeMotor,
            this.colFechaDeCompra,
            this.colPrecioDeCompra});
            this.dgvCompras.Location = new System.Drawing.Point(752, 207);
            this.dgvCompras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.Size = new System.Drawing.Size(951, 623);
            this.dgvCompras.TabIndex = 19;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 125;
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.MinimumWidth = 6;
            this.colMarca.Name = "colMarca";
            this.colMarca.Width = 125;
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.MinimumWidth = 6;
            this.colModelo.Name = "colModelo";
            this.colModelo.Width = 125;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 125;
            // 
            // colAño
            // 
            this.colAño.HeaderText = "Año";
            this.colAño.MinimumWidth = 6;
            this.colAño.Name = "colAño";
            this.colAño.Width = 125;
            // 
            // colPaisDeOrigen
            // 
            this.colPaisDeOrigen.HeaderText = "Pais de Origen";
            this.colPaisDeOrigen.MinimumWidth = 6;
            this.colPaisDeOrigen.Name = "colPaisDeOrigen";
            this.colPaisDeOrigen.Width = 125;
            // 
            // colPlaca
            // 
            this.colPlaca.HeaderText = "Placa";
            this.colPlaca.MinimumWidth = 6;
            this.colPlaca.Name = "colPlaca";
            this.colPlaca.Width = 125;
            // 
            // colChasis
            // 
            this.colChasis.HeaderText = "Chasis";
            this.colChasis.MinimumWidth = 6;
            this.colChasis.Name = "colChasis";
            this.colChasis.Width = 125;
            // 
            // colNumeroDeMotor
            // 
            this.colNumeroDeMotor.HeaderText = "Numero de motor";
            this.colNumeroDeMotor.MinimumWidth = 6;
            this.colNumeroDeMotor.Name = "colNumeroDeMotor";
            this.colNumeroDeMotor.Width = 125;
            // 
            // colFechaDeCompra
            // 
            this.colFechaDeCompra.HeaderText = "Fecha de Compra";
            this.colFechaDeCompra.MinimumWidth = 6;
            this.colFechaDeCompra.Name = "colFechaDeCompra";
            this.colFechaDeCompra.Width = 125;
            // 
            // colPrecioDeCompra
            // 
            this.colPrecioDeCompra.HeaderText = "Precio de compra";
            this.colPrecioDeCompra.MinimumWidth = 6;
            this.colPrecioDeCompra.Name = "colPrecioDeCompra";
            this.colPrecioDeCompra.Width = 125;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.label13.Location = new System.Drawing.Point(9, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1700, 1);
            this.label13.TabIndex = 20;
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1722, 953);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCompras";
            this.Text = "Compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtDescripcionObservaciones;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.NumericUpDown nudAño;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboModelo;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.TextBox txtNumeroDeMotor;
        private System.Windows.Forms.TextBox txtChasis;
        private System.Windows.Forms.ComboBox cboPaisDeOrigen;
        private System.Windows.Forms.DateTimePicker dtpFechaDeCompra;
        private System.Windows.Forms.TextBox txtPrecioDeCompra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaisDeOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroDeMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioDeCompra;
    }
}