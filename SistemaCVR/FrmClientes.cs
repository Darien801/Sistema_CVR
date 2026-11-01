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
using System.Text.RegularExpressions;

namespace SistemaCVR
{
    public partial class FrmClientes : Form
    {
        private readonly clsConexion con = new clsConexion();
        private int idseleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            string sql = @"SELECT id_cliente, nombre, apellido, DUI, direccion, telefono FROM cliente;";
            dgvClientes.DataSource = con.Consultar(sql);
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Filtrar(string filtrar)
        {
            if (string.IsNullOrWhiteSpace(filtrar))
            {
                CargarDatos();
                return;
            }
            string sql = @" SELECT 
                                id_cliente,
                                nombre,
                                apellido,
                                DUI, direccion,
                                telefono
                            FROM 
                                cliente
                            WHERE
                                nombre LIKE @filtro OR
                                apellido LIKE @filtro OR
                                DUI LIKE @filtro OR
                                direccion LIKE @filtro OR
                                Telefono LIKE @filtro;";

            SqlParameter[] parametros =
            {
                new SqlParameter("@filtro",  $"%{filtrar.Trim()}%"),
            };

            dgvClientes.DataSource = con.FiltrarDatos(sql, parametros);
        }

        private void LimpiarCampos()
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtDuiCliente.Clear();
            txtDireccionCliente.Clear();
            txtTelefonoCliente.Clear();
            txtNombreCliente.Focus();
            idseleccionado = 0;
        }

        private bool validarNombreApellido(string nombreApeliido)
        {
            return Regex.IsMatch(nombreApeliido, @"^[\p{L}\s'-]+$");
        }
        private bool validarDui(string dui)
        {
            return Regex.IsMatch(dui, @"^\d{8}-\d$");
        }

        private bool validarTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d{4}-\d{4}$");
        }


        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                 string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
                 string.IsNullOrWhiteSpace(txtDuiCliente.Text) ||
                 string.IsNullOrWhiteSpace(txtDireccionCliente.Text) ||
                  string.IsNullOrWhiteSpace(txtTelefonoCliente.Text)
                )
            {
                MessageBox.Show("Complete los campos", "Error", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                return;
            }

            if (!validarNombreApellido(txtNombreCliente.Text.Trim()) ||
                !validarNombreApellido(txtApellidoCliente.Text.Trim())     
                )
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.",
                                "Datos inválidos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
                return;
            }

            if (!validarDui(txtDuiCliente.Text.Trim()))
            {
                MessageBox.Show("El DUI no cumple con el formato correcto.",
                                "Datos inválidos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
                txtDuiCliente.Focus();
                return;
            }

            if (!validarTelefono(txtTelefonoCliente.Text.Trim()))
            {
                MessageBox.Show("El teléfono debe tener el formato 0000-0000.",
                                "Teléfono inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                );

                txtTelefonoCliente.Focus();
                return;
            }

            string sql = @"INSERT INTO cliente(nombre, apellido, DUI, direccion, telefono) 
                            VALUES (@nombre, @apellido, @DUI, @direccion, @telefono );
                          ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", txtNombreCliente.Text.Trim()),
                new SqlParameter("@apellido", txtApellidoCliente.Text.Trim()),
                new SqlParameter("@DUI", txtDuiCliente.Text.Trim()),
                new SqlParameter("@direccion", txtDireccionCliente.Text.Trim()),
                new SqlParameter("@telefono", txtTelefonoCliente.Text.Trim())
            };

            try
            {
                int Afectadas = con.ejecutarComando(sql, parametros);
                if (Afectadas > 0)
                {
                    MessageBox.Show("Cliente registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    CargarDatos();
                    LimpiarCampos();
                }    
                else
                {
                    MessageBox.Show("No se pudo registrar el cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(SqlException)
            {
                MessageBox.Show(
                    "No se pudo registrar el cliente. Verifique que el cliente y sus datos no esten registrados y que los datos sean válidos.",
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

            idseleccionado = Convert.ToInt32( fila.Cells[0].Value);
            txtNombreCliente.Text = fila.Cells[1].Value.ToString();
            txtApellidoCliente.Text = fila.Cells[2].Value.ToString();
            txtDuiCliente.Text = fila.Cells[3].Value.ToString();
            txtDireccionCliente.Text = fila.Cells[4].Value.ToString();
            txtTelefonoCliente.Text = fila.Cells[5].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idseleccionado <= 0)
            {
                MessageBox.Show("Seleccione una fila para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
                string.IsNullOrWhiteSpace(txtDuiCliente.Text) ||
                string.IsNullOrWhiteSpace(txtDireccionCliente.Text) ||
                string.IsNullOrWhiteSpace(txtTelefonoCliente.Text)
                )
            {
                MessageBox.Show("Complete los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string sql = @"UPDATE cliente SET nombre = @nombre , apellido = @apellido, 
                           DUI = @DUI, direccion = @direccion, telefono = @telefono  WHERE id_cliente = @id; ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", txtNombreCliente.Text.Trim()),
                new SqlParameter("@apellido", txtApellidoCliente.Text.Trim()),
                new SqlParameter("@DUI", txtDuiCliente.Text.Trim()),
                new SqlParameter("@direccion", txtDireccionCliente.Text.Trim()),
                new SqlParameter("@telefono", txtTelefonoCliente.Text.Trim()),
                new SqlParameter("@id", idseleccionado)
            };

            try
            {
                int Afectadas = con.ejecutarComando(sql, parametros);
                if (Afectadas > 0)
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "No se pudo actualizar el cliente. Verifique que el cliente y sus datos no esten registrados y que los datos sean válidos.",
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }


        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idseleccionado <= 0)
            {
                MessageBox.Show("Seleccione una fila para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar a este cliente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(respuesta == DialogResult.Yes)
            {
                string sql = "DELETE FROM cliente WHERE id_cliente = @id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", idseleccionado)
                };
                con.ejecutarComando(sql, parametros);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Cliente eliminado correctamente","Aviso" ,MessageBoxButtons.OK , MessageBoxIcon.Information);

            }
            else
            {
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtrar(txtBuscar.Text.Trim());
        }
    }
}
