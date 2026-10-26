namespace SistemaCVR
{
    partial class FrmCaracteristicas
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
            this.label13 = new System.Windows.Forms.Label();
            this.lblGestionClientes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvModelo = new System.Windows.Forms.DataGridView();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMarca = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.label13.Location = new System.Drawing.Point(20, 114);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1689, 1);
            this.label13.TabIndex = 23;
            // 
            // lblGestionClientes
            // 
            this.lblGestionClientes.AutoSize = true;
            this.lblGestionClientes.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.lblGestionClientes.Location = new System.Drawing.Point(14, 35);
            this.lblGestionClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGestionClientes.Name = "lblGestionClientes";
            this.lblGestionClientes.Size = new System.Drawing.Size(879, 88);
            this.lblGestionClientes.TabIndex = 22;
            this.lblGestionClientes.Text = "Características del vehículo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvModelo);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.groupBox1.Location = new System.Drawing.Point(19, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(828, 1019);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de vehículos";
            // 
            // dgvModelo
            // 
            this.dgvModelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModelo.Location = new System.Drawing.Point(63, 206);
            this.dgvModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvModelo.Name = "dgvModelo";
            this.dgvModelo.RowHeadersWidth = 72;
            this.dgvModelo.RowTemplate.Height = 31;
            this.dgvModelo.Size = new System.Drawing.Size(669, 546);
            this.dgvModelo.TabIndex = 5;
            this.dgvModelo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModelo_CellClick);
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Location = new System.Drawing.Point(63, 135);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(641, 45);
            this.txtModelo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modelo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMarca);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtMarca);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.groupBox2.Location = new System.Drawing.Point(865, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(821, 1006);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Marcas y Modelos";
            // 
            // dgvMarca
            // 
            this.dgvMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarca.Location = new System.Drawing.Point(37, 209);
            this.dgvMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMarca.Name = "dgvMarca";
            this.dgvMarca.RowHeadersWidth = 72;
            this.dgvMarca.RowTemplate.Height = 31;
            this.dgvMarca.Size = new System.Drawing.Size(757, 409);
            this.dgvMarca.TabIndex = 6;
            this.dgvMarca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarca_CellClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Brown;
            this.button3.ForeColor = System.Drawing.Color.Cornsilk;
            this.button3.Location = new System.Drawing.Point(532, 717);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 68);
            this.button3.TabIndex = 4;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Peru;
            this.button2.ForeColor = System.Drawing.Color.Cornsilk;
            this.button2.Location = new System.Drawing.Point(320, 717);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 68);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(107, 717);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarca.Location = new System.Drawing.Point(26, 145);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(641, 45);
            this.txtMarca.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Marca:";
            // 
            // FrmCaracteristicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 1213);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblGestionClientes);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(161)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCaracteristicas";
            this.Text = "FrmCaracteristicas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCaracteristicas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblGestionClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvModelo;
        private System.Windows.Forms.DataGridView dgvMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label2;
    }
}