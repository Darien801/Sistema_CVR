using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCVR
{
    public partial class FrmVentas : Form
    {
        private readonly clsConexion con = new clsConexion();

        // Consulta base del historial; Filtrar() solo le agrega el WHERE.
        private const string sqlHistorial = @"
                            SELECT
                                vt.id_venta,
                                c.nombre + N' ' + c.apellido AS Cliente,
                                ma.nombreMarca + N' ' + mo.nombreModelo + N' (' + ISNULL(v.placa, N'S/P') + N')' AS Vehiculo,
                                em.nombre + N' ' + em.apellido AS Empleado,
                                vt.fecha,
                                vt.precioVenta,
                                vt.estadoVenta,
                                vt.observaciones
                            FROM venta vt
                            INNER JOIN cliente c
                                ON vt.id_cliente = c.id_cliente
                            INNER JOIN vehiculo v
                                ON vt.id_vehiculo = v.id_vehiculo
                            INNER JOIN marca ma
                                ON v.id_marca = ma.id_marca
                            INNER JOIN modelo mo
                                ON v.id_modelo = mo.id_modelo
                            INNER JOIN empleado em
                                ON vt.id_empleado = em.id_empleado
                          ";

        private const string sqlOrden = " ORDER BY vt.fecha DESC, vt.id_venta DESC;";

        public FrmVentas()
        {
            InitializeComponent();
        }

        // clsConexion.CargarCombos fuerza Selected
        private void CargarCombo(ComboBox combo, string sql, string visible, string valor)
        {
            combo.DisplayMember = visible;
            combo.ValueMember = valor;
            combo.DataSource = con.Consultar(sql);
            combo.SelectedIndex = -1;
        }

        private void CargarVehiculos()
        {
            CargarCombo(
                cmbVehiculo,
                @"SELECT
                      v.id_vehiculo,
                      ISNULL(v.placa, N'S/P') + N' - ' + ma.nombreMarca + N' ' + mo.nombreModelo
                          + ISNULL(N' ' + CAST(v.anio AS nvarchar(4)), N'') AS descripcion
                  FROM vehiculo v
                  INNER JOIN marca ma ON v.id_marca = ma.id_marca
                  INNER JOIN modelo mo ON v.id_modelo = mo.id_modelo
                  INNER JOIN estado es ON v.id_estado = es.id_estado
                  WHERE es.nombreEstado = N'Disponible'
                  ORDER BY 2",
                "descripcion",
                "id_vehiculo"
                );
        }

        private void CargarCombos()
        {
            CargarCombo(
                cmbCliente,
                "SELECT id_cliente, nombre + N' ' + apellido + N' - ' + DUI AS cliente FROM cliente ORDER BY 2",
                "cliente",
                "id_cliente"
                );

            CargarCombo(
                cmbEmpleado,
                "SELECT id_empleado, nombre + N' ' + apellido AS empleado FROM empleado WHERE estadoEmpleado = N'Activo' ORDER BY 2",
                "empleado",
                "id_empleado"
                );

            CargarVehiculos();
        }

        private void CargarDatos()
        {
            dgvVentas.DataSource = con.Consultar(sqlHistorial + sqlOrden);
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Filtrar(string filtrar)
        {
            string sql = sqlHistorial + @"
                            WHERE
                                CAST(vt.id_venta AS nvarchar(10)) LIKE @filtro OR
                                c.nombre LIKE @filtro OR
                                c.apellido LIKE @filtro OR
                                c.DUI LIKE @filtro OR
                                ma.nombreMarca LIKE @filtro OR
                                mo.nombreModelo LIKE @filtro OR
                                v.placa LIKE @filtro OR
                                em.nombre LIKE @filtro OR
                                em.apellido LIKE @filtro OR
                                vt.estadoVenta LIKE @filtro OR
                                vt.observaciones LIKE @filtro OR
                                CONVERT(nvarchar(10), vt.fecha, 103) LIKE @filtro
                          " + sqlOrden;

            SqlParameter[] parametros =
            {
                new SqlParameter("@filtro", $"%{filtrar.Trim()}%")
            };

            dgvVentas.DataSource = con.FiltrarDatos(sql, parametros);
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            cmbEstadoVenta.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            txtPrecioVenta.Clear();
            txtObservaciones.Clear();
            cmbCliente.Focus();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarDatos();
                cmbEstadoVenta.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null ||
                cmbVehiculo.SelectedValue == null ||
                cmbEmpleado.SelectedValue == null ||
                cmbEstadoVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el cliente, el vehículo, el empleado y el estado de la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal precioVenta;
            if (!decimal.TryParse(txtPrecioVenta.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out precioVenta) ||
                precioVenta <= 0 ||
                precioVenta > 9999999999.99m)
            {
                MessageBox.Show("Ingrese un precio de venta válido, mayor que cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioVenta.Focus();
                return;
            }

            if (dtpFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de la venta no puede ser posterior a hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFecha.Focus();
                return;
            }

            // El estado del vehículo sigue al estado de la venta 
            string estadoVehiculo;
            switch (cmbEstadoVenta.Text)
            {
                case "Completada":
                    estadoVehiculo = "Vendido";
                    break;
                case "Pendiente":
                    estadoVehiculo = "Reservado";
                    break;
                default:
                    estadoVehiculo = "En trámite";
                    break;
            }

            // Una sola transacción: marca el vehículo
            string sql = @"
                            SET XACT_ABORT ON;
                            BEGIN TRANSACTION;

                            UPDATE vehiculo
                            SET id_estado = (SELECT id_estado FROM estado WHERE nombreEstado = @estadoVehiculo)
                            WHERE id_vehiculo = @id_vehiculo
                              AND id_estado = (SELECT id_estado FROM estado WHERE nombreEstado = N'Disponible');

                            IF @@ROWCOUNT = 0
                            BEGIN
                                ROLLBACK TRANSACTION;
                                RETURN;
                            END

                            INSERT INTO venta (id_cliente, id_empleado, id_vehiculo, fecha, precioVenta, estadoVenta, observaciones)
                            VALUES (@id_cliente, @id_empleado, @id_vehiculo, @fecha, @precioVenta, @estadoVenta, @observaciones);

                            COMMIT TRANSACTION;
                        ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@estadoVehiculo", estadoVehiculo),
                new SqlParameter("@id_cliente", cmbCliente.SelectedValue),
                new SqlParameter("@id_empleado", cmbEmpleado.SelectedValue),
                new SqlParameter("@id_vehiculo", cmbVehiculo.SelectedValue),
                new SqlParameter("@fecha", SqlDbType.Date) { Value = dtpFecha.Value.Date },
                new SqlParameter("@precioVenta", SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = Math.Round(precioVenta, 2) },
                new SqlParameter("@estadoVenta", cmbEstadoVenta.Text),
                new SqlParameter("@observaciones", string.IsNullOrWhiteSpace(txtObservaciones.Text)
                                                    ? (object)DBNull.Value
                                                    : txtObservaciones.Text.Trim())
            };

            try
            {
                int afectadas = con.ejecutarComando(sql, parametros);
                if (afectadas > 0)
                {
                    MessageBox.Show("Venta registrada correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    CargarVehiculos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El vehículo seleccionado ya no está disponible. Se actualizó la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarVehiculos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la venta: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(sender, e);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filtrar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
