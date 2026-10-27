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
    public partial class FrmVehiculos : Form
    {
        clsConexion con = new clsConexion();
        private int id_vehiculo = 0;
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        // Texto vacío -> NULL (evita chocar con los índices únicos)
        private object ValorONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        private void LimpiarCampos()
        {
            id_vehiculo = 0;
            txtMostrarModelo.Clear();
            txtMostrarMarca.Clear();
            txtMostrarPlaca.Clear();
            txtMostrarChasis.Clear();
            txtMostrarMotor.Clear();
            txtPrecioCompra.Clear();
            cbxEstado.SelectedIndex = -1;
            cbxAnio.SelectedIndex = -1;
            cbxColor.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            string sql = @"
                            SELECT
                                v.id_vehiculo,
                                mo.nombreModelo AS Modelo,
                                ma.nombreMarca AS Marca,
                                placa AS Placa,
                                chasis AS Chasis,
                                numeroMotor AS 'Numero de Motor',
                                precioCompra as 'Precio de Compra',
                                es.nombreEstado as Estado,
                                ruta_imagen AS Ruta,
                                anio AS Año,
                                color AS Color 
                            FROM vehiculo v
                            INNER JOIN modelo mo
                                ON v.id_modelo = mo.id_modelo
                            INNER JOIN marca ma
                                ON v.id_marca = ma.id_marca
                            LEFT JOIN estado es
                                ON v.id_estado = es.id_estado
                            ORDER BY v.id_vehiculo DESC
                          ";

            dgvVehiculos.DataSource = con.Consultar(sql);
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            con.CargarCombos(
                cbxEstado,
                "SELECT id_estado, nombreEstado FROM estado",
                "nombreEstado",
                "id_estado"
             );

            

            CargarDatos();


            for (int a = DateTime.Now.Year + 1; a >= 1990; a--)
                cbxAnio.Items.Add(a);
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Seleccione una fila", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

            id_vehiculo = Convert.ToInt32(fila.Cells[0].Value);

            txtMostrarModelo.Text = fila.Cells[1].Value.ToString();
            txtMostrarMarca.Text = fila.Cells[2].Value.ToString();
            txtMostrarPlaca.Text = fila.Cells[3].Value.ToString();
            txtMostrarChasis.Text = fila.Cells[4].Value.ToString();
            txtMostrarMotor.Text = fila.Cells[5].Value.ToString();
            txtPrecioCompra.Text = fila.Cells[6].Value.ToString();


            cbxEstado.SelectedIndex = cbxEstado.FindStringExact(
            Convert.ToString(fila.Cells[7].Value));

            object anio = fila.Cells[9].Value;
            cbxAnio.SelectedIndex = (anio == null || anio == DBNull.Value)
                ? -1
                : cbxAnio.FindStringExact(anio.ToString());



            cbxColor.SelectedIndex = cbxColor.FindStringExact(fila.Cells[10].Value.ToString());

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (id_vehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Precio: vacío = NULL; si trae texto, debe ser un número válido
            object precio = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(txtPrecioCompra.Text))
            {
                if (!decimal.TryParse(txtPrecioCompra.Text.Trim(), out decimal p) || p < 0)
                {
                    MessageBox.Show("El precio de compra no es válido.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                precio = p;
            }

            string sql = @"
        UPDATE vehiculo
        SET placa        = @placa,
            chasis       = @chasis,
            numeroMotor  = @motor,
            precioCompra = @precio,
            id_estado    = @estado,
            anio         = @anio,
            color        = @color
        WHERE id_vehiculo = @id";

            SqlParameter[] parametros =
            {
        new SqlParameter("@placa",  ValorONulo(txtMostrarPlaca.Text)),
        new SqlParameter("@chasis", ValorONulo(txtMostrarChasis.Text)),
        new SqlParameter("@motor",  ValorONulo(txtMostrarMotor.Text)),
        new SqlParameter("@precio", precio),
        new SqlParameter("@estado", cbxEstado.SelectedIndex == -1
            ? (object)DBNull.Value : cbxEstado.SelectedValue),
        new SqlParameter("@anio",   cbxAnio.SelectedIndex == -1
            ? (object)DBNull.Value : Convert.ToInt32(cbxAnio.SelectedItem)),
        new SqlParameter("@color",  cbxColor.SelectedIndex == -1
            ? (object)DBNull.Value : cbxColor.Text),
        new SqlParameter("@id",     id_vehiculo)
    };

            try
            {
                con.ejecutarComando(sql, parametros);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Vehículo actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show("La placa, el chasis o el número de motor ya están registrados en otro vehículo.",
                    "Dato duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el vehículo: " + ex.Message);
            }
        }
    }
}
