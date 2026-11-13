using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaCVR
{
    public partial class FrmVehiculos : Form
    {
        clsConexion con = new clsConexion();
        private int id_vehiculo = 0;

        private byte[] imagenByte = null;
        private bool imagenCambio = false;
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        // Texto vacío -> NULL (evita chocar con los índices únicos)
        private object ValorONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        private void ConfigurarGrid()
        {
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.AllowUserToAddRows = false;

            if (dgvVehiculos.Columns["Imagen"] is DataGridViewImageColumn colImg)
            {
                colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;  // mantiene proporción
                colImg.Width = 120;
                colImg.DefaultCellStyle.NullValue = null;               // sin "X" roja si no hay foto
            }

            foreach (DataGridViewRow fila in dgvVehiculos.Rows)
                fila.Height = 80;
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
            cbxEstado.SelectedIndex = -1;
            pbVehiculo.Image?.Dispose();
            pbVehiculo.Image = null;
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
                                anio AS Año,
                                color AS Color,
                                imagen AS Imagen
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
            ConfigurarGrid();
        }


        private void Filtrar(string filtrar)
        {
            string sql = @"
                             SELECT
                            v.id_vehiculo,
                            mo.nombreModelo AS Modelo,
                            ma.nombreMarca AS Marca,
                            v.placa AS Placa,
                            v.chasis AS Chasis,
                            v.numeroMotor AS 'Numero de Motor',
                            v.precioCompra AS 'Precio de Compra',
                            es.nombreEstado AS Estado,
                            v.anio AS Año,
                            v.color AS Color,
                            v.imagen AS Imagen
                        FROM vehiculo v
                        INNER JOIN modelo mo
                            ON v.id_modelo = mo.id_modelo
                        INNER JOIN marca ma
                            ON v.id_marca = ma.id_marca
                        LEFT JOIN estado es
                            ON v.id_estado = es.id_estado
                        WHERE
                            CAST(v.id_vehiculo AS VARCHAR(20)) LIKE @filtro OR
                            es.nombreEstado LIKE @filtro OR
                            v.placa LIKE @filtro OR
                            v.chasis LIKE @filtro OR
                            v.numeroMotor LIKE @filtro OR
                            ma.nombreMarca LIKE @filtro OR
                            mo.nombreModelo LIKE @filtro
                        ORDER BY v.id_vehiculo DESC
                         ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@filtro", $"%{filtrar.Trim()}%" )
            };

            dgvVehiculos.DataSource = con.FiltrarDatos(sql, parametros);
            ConfigurarGrid();

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
            LimpiarCampos();
            ConfigurarGrid();

            for (int a = DateTime.Now.Year + 1; a >= 2000; a--)
            {
                cbxAnio.Items.Add(a);
            }
                
        }

        private byte[] ObtenerImagen(int idVehiculo)
        {
            string sql = "SELECT imagen FROM vehiculo WHERE id_vehiculo = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", idVehiculo)
            };

            object resultado = con.ejecutarEscalar(sql, parametros);

            return (resultado == null || resultado == DBNull.Value)
                ? null
                : (byte[])resultado;
        }

        private void MostrarImagen(byte[] bytes)
        {
            pbVehiculo.Image?.Dispose();
            pbVehiculo.Image = null;
            imagenByte = bytes;

            if (bytes == null) return;

            using (var ms = new MemoryStream(bytes))
            {
                pbVehiculo.Image = new Bitmap(ms);
            }
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado: ignorar sin mensaje

            DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

            id_vehiculo = Convert.ToInt32(fila.Cells["id_vehiculo"].Value);

            txtMostrarModelo.Text = fila.Cells["Modelo"].Value?.ToString();
            txtMostrarMarca.Text = fila.Cells["Marca"].Value?.ToString();
            txtMostrarPlaca.Text = fila.Cells["Placa"].Value?.ToString();
            txtMostrarChasis.Text = fila.Cells["Chasis"].Value?.ToString();
            txtMostrarMotor.Text = fila.Cells["Numero de Motor"].Value?.ToString();
            txtPrecioCompra.Text = fila.Cells["Precio de Compra"].Value?.ToString();

            cbxEstado.SelectedIndex = cbxEstado.FindStringExact(
                Convert.ToString(fila.Cells["Estado"].Value));

            object anio = fila.Cells["Año"].Value;
            cbxAnio.SelectedIndex = (anio == null || anio == DBNull.Value)
                ? -1
                : cbxAnio.FindStringExact(anio.ToString());

            cbxColor.SelectedIndex = cbxColor.FindStringExact(
                Convert.ToString(fila.Cells["Color"].Value));

            // Imagen: se carga aparte desde la base de datos
            imagenCambio = false;
            MostrarImagen(ObtenerImagen(id_vehiculo));

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"imagenCambio = {imagenCambio}\nBytes = {(imagenByte == null ? "NULL" : imagenByte.Length.ToString())}");
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
                                color        = @color,
                                imagen       = CASE WHEN @cambioImagen = 1 THEN @imagen ELSE imagen END
                            WHERE id_vehiculo = @id
                         ";

            SqlParameter pImagen = new SqlParameter("@imagen", SqlDbType.VarBinary, -1)
            {
                Value = (object)imagenByte ?? DBNull.Value
            };

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
                pImagen,
                new SqlParameter("@cambioImagen", SqlDbType.Bit) { Value = imagenCambio },
                new SqlParameter("@id",     id_vehiculo)
            };

            try
            {
                int afecetadas = con.ejecutarComando(sql, parametros);
                if (afecetadas > 0)
                {
                    CargarDatos();
                    LimpiarCampos();
                    MessageBox.Show("Vehículo actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El vehiculo no se pudo actualizar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtrar(txtBuscar.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen del vehículo";
                ofd.Filter = "Imágenes (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagenByte = File.ReadAllBytes(ofd.FileName);
                    imagenCambio = true;
                    pbVehiculo.Image?.Dispose();
                    using (var ms = new MemoryStream(imagenByte))
                    {
                        pbVehiculo.Image = new Bitmap(ms);
                    }
                }
            }
        }
    }
}
