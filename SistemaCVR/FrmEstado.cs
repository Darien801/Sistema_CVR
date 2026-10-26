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
    public partial class FrmEstado : Form
    {
        private int Id_Seleccionado = 0;
        private readonly clsConexion con = new clsConexion();
        public FrmEstado()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            string sql = @"select id_estado as ID, nombreEstado as Estado from estado";
            dgvEstadoVehiculo.DataSource = con.Consultar(sql);
            dgvEstadoVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarCampos()
        {
            txtNombreEstado.Clear();
            txtNombreEstado.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEstado.Text)) 
            {
                MessageBox.Show("Por favor rellene los campos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string sql = $"insert into estado (nombreEstado) values ('{txtNombreEstado.Text}')";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombreEstado", txtNombreEstado.Text)
            };

            con.ejecutarComando(sql,parametros);
            MessageBox.Show("Estado guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
            LimpiarCampos();
        }



        private void FrmEstado_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvEstadoVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEstadoVehiculo.Rows[e.RowIndex];

            Id_Seleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
            txtNombreEstado.Text = fila.Cells["Estado"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Id_Seleccionado == 0) 
            {
                MessageBox.Show("Seleccione el registro que desea editar");
                return;
            }

            string sql = @"update estado set nombreEstado = @nombre where id_estado = @Id_Seleccionado";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", txtNombreEstado.Text),
                new SqlParameter("@Id_Seleccionado", Id_Seleccionado)
            };

            con.ejecutarComando(sql, parametros.ToArray());
            MessageBox.Show("Estado actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
            LimpiarCampos();
            Id_Seleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Id_Seleccionado == 0) 
            {
                MessageBox.Show("Seleccione un estado para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este estado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string sql = "DELETE FROM estado WHERE id_estado = @id_estado";
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_estado", Id_Seleccionado)
                };

                con.ejecutarComando(sql, parametros.ToArray());
                MessageBox.Show("Empleado eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
                Id_Seleccionado = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
