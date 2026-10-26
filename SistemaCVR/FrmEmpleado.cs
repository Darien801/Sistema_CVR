using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCVR
{
    public partial class FrmEmpleado : Form
    {
        private readonly clsConexion con = new clsConexion();

        private int idSeleccionado = 0;
        public FrmEmpleado()
        {
            InitializeComponent();
        }



        private void mostrarDatos()
        {
            string sql = "SELECT id_empleado as ID, nombre as Nombre, apellido as Apellido, DUI, rolEmpleado as Rol, estadoEmpleado as Estado FROM empleado";
            dgvEmpleado.DataSource = con.Consultar(sql);
            dgvEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void filtarDatos(string filtro)
        {
            string sql = @"SELECT id_empleado AS ID, nombre AS Nombre, apellido AS Apellido,
                          DUI, rolEmpleado AS Rol, estadoEmpleado AS Estado
                   FROM empleado
                   WHERE nombre LIKE @filtro
                      OR apellido LIKE @filtro
                      OR DUI LIKE @filtro";

            SqlParameter[] parametros = 
                {
                    new SqlParameter("@filtro", $"%{filtro.Trim()}%")
                };

            dgvEmpleado.DataSource = con.FiltrarDatos(sql, parametros);
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDui.Clear();
            txtPass.Clear();
            cbxRol.SelectedIndex = -1;
            chkEstado.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDui.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cbxRol.Text)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string estado = chkEstado.Checked ? "Activo" : "Inactivo";
            string sql = $"INSERT INTO empleado (nombre, apellido, DUI, hashEmpleado , rolEmpleado, estadoEmpleado) VALUES ('{txtNombre.Text}', '{txtApellido.Text}', '{txtDui.Text}', '{txtPass.Text}', '{cbxRol.Text}', '{estado}')";

            SqlParameter[] parametros = {
                new SqlParameter("@nombre", txtNombre.Text),
                new SqlParameter("@apellido", txtApellido.Text),
                new SqlParameter("@DUI", txtDui.Text),
                new SqlParameter("@hashEmpleado", txtPass.Text),
                new SqlParameter("@rolEmpleado", cbxRol.Text),
                new SqlParameter("@estadoEmpleado", estado)
            };
            con.ejecutarComando(sql, parametros);
            MessageBox.Show("Empleado guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mostrarDatos();
            LimpiarCampos();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEmpleado.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
            txtDui.Text = fila.Cells["DUI"].Value.ToString();
            cbxRol.Text = fila.Cells["Rol"].Value.ToString();
            chkEstado.Checked = fila.Cells["Estado"].Value.ToString() == "Activo";
            txtPass.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDui.Text) ||
                string.IsNullOrWhiteSpace(cbxRol.Text)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string estado = chkEstado.Checked ? "Activo" : "Inactivo";
            bool actualizarPass = !string.IsNullOrWhiteSpace(txtPass.Text);

            string sql = @"UPDATE empleado SET nombre = @nombre, apellido = @apellido, DUI = @DUI, rolEmpleado = @rolEmpleado, estadoEmpleado = @estadoEmpleado" +
                         (actualizarPass ? ", hashEmpleado = @hashEmpleado" : "") +
                         " WHERE id_empleado = @id_empleado"; 

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", txtNombre.Text.Trim()),
                new SqlParameter("@apellido", txtApellido.Text.Trim()),
                new SqlParameter("@DUI", txtDui.Text.Trim()),
                new SqlParameter("@rolEmpleado", cbxRol.Text.Trim()),
                new SqlParameter("@estadoEmpleado", estado),
                new SqlParameter("@id_empleado", idSeleccionado)
            };

            if (actualizarPass)
            {
                parametros.Add(new SqlParameter("@hashEmpleado", txtPass.Text.Trim()));
            }

            con.ejecutarComando(sql, parametros.ToArray());
            MessageBox.Show("Empleado actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mostrarDatos();
            LimpiarCampos();
            idSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string sql = "DELETE FROM empleado WHERE id_empleado = @id_empleado";
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_empleado", idSeleccionado)
                };

                con.ejecutarComando(sql, parametros.ToArray());
                MessageBox.Show("Empleado eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarDatos();
                LimpiarCampos();
                idSeleccionado = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
            txtBuscar.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtarDatos(txtBuscar.Text.Trim());
        }
    }
}
