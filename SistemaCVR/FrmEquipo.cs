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
    public partial class FrmEquipo : Form
    {
        private readonly clsConexion con = new clsConexion();

        private int id_seleccionado = 0;
        public FrmEquipo()
        {
            InitializeComponent();
        }

        private void filtrarDatos(string filto) 
        {
            string sql = @"select id_accesorio as ID, nombreAccesorio as Equipo, descripcion as Descripción from accesorio 
                where nombreAccesorio LIKE @filtro OR descripcion LIKE @filtro";

            SqlParameter[] parametros =
            {
                new SqlParameter("@filtro", $"%{filto.Trim()}%")

            };

            dgvEquipoDelVehiculo.DataSource = con.FiltrarDatos(sql, parametros);
        }

        private void mostrarDatos()
        {
            string sql = "select id_accesorio as ID, nombreAccesorio as Equipo, descripcion as Descripción from accesorio";
            dgvEquipoDelVehiculo.DataSource = con.Consultar(sql);
            dgvEquipoDelVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void limpiarCampos()
        {
            txtDescripcion.Clear();
            txtNombreDelEquipo.Clear();
            txtNombreDelEquipo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNombreDelEquipo.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe rellenar los campos","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string sql = $"insert into accesorio (nombreAccesorio, descripcion) values ('{txtNombreDelEquipo.Text}', '{txtDescripcion.Text}')";

            SqlParameter[] parametros = 
            {
                  new SqlParameter("@nombreAccesorio", txtNombreDelEquipo.Text),
                  new SqlParameter("@descripcion", txtDescripcion.Text)
            };

            con.ejecutarComando(sql,parametros);
            MessageBox.Show("Equipo guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mostrarDatos();
            limpiarCampos();
        }

        private void FrmEquipo_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void dgvEquipoDelVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEquipoDelVehiculo.Rows[e.RowIndex];

            id_seleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
            txtNombreDelEquipo.Text = fila.Cells["Equipo"].Value.ToString();
            txtDescripcion.Text = fila.Cells["Descripción"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(id_seleccionado == 0)
            {
                MessageBox.Show("Seleccione el registro que desa editar");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreDelEquipo.Text)
                || string.IsNullOrWhiteSpace(txtDescripcion.Text)) 
            {
                MessageBox.Show("Por favor, rellene los campos", "Información", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            string sql = @"update accesorio set nombreAccesorio = @Nombre, descripcion = @Descripcion where id_accesorio = @id_seleccionado";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", txtNombreDelEquipo.Text.Trim()),
                new SqlParameter("@Descripcion", txtDescripcion.Text.Trim()),
                new SqlParameter("@id_seleccionado", id_seleccionado)
            };

            MessageBox.Show("Resgistro editado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.ejecutarComando(sql,parametros.ToArray());
            mostrarDatos();
            limpiarCampos();
            id_seleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id_seleccionado == 0) 
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string sql = "DELETE FROM accesorio WHERE id_accesorio = @id_seleccionado";
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_seleccionado", id_seleccionado)
                };

                con.ejecutarComando(sql, parametros.ToArray());
                MessageBox.Show("Empleado eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarDatos();
                limpiarCampos();
                id_seleccionado = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void txtNombreDelEquipo_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
            txtBuscar.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarDatos(txtBuscar.Text.Trim());
        }
    }
}
