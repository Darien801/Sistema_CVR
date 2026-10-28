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
    public partial class FrmRentas : Form
    {
        private readonly clsConexion con = new clsConexion();
        private bool soloActivas = false;

        // Consulta base del historial; CargarDatos() le agrega el WHERE.
        private const string sqlHistorial = @"
                            SELECT
                                r.id_renta,
                                c.nombre + N' ' + c.apellido AS Cliente,
                                ma.nombreMarca + N' ' + mo.nombreModelo + N' (' + ISNULL(v.placa, N'S/P') + N')' AS Vehiculo,
                                em.nombre + N' ' + em.apellido AS Empleado,
                                r.fecha_inicio,
                                r.fecha_fin,
                                r.fecha_devolucion,
                                r.precioHora,
                                r.estadoRenta,
                                r.observaciones
                            FROM renta r
                            INNER JOIN cliente c
                                ON r.id_cliente = c.id_cliente
                            INNER JOIN vehiculo v
                                ON r.id_vehiculo = v.id_vehiculo
                            INNER JOIN marca ma
                                ON v.id_marca = ma.id_marca
                            INNER JOIN modelo mo
                                ON v.id_modelo = mo.id_modelo
                            INNER JOIN empleado em
                                ON r.id_empleado = em.id_empleado
                          ";

        private const string sqlOrden = " ORDER BY r.fecha_inicio DESC, r.id_renta DESC;";

        public FrmRentas()
        {
            InitializeComponent();
        }

        // clsConexion.CargarCombos falla si la lista viene vacía (SelectedIndex = 0), por eso se usa este método local.
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

        // Carga el historial aplicando el texto de búsqueda y el filtro "Rentas activas".
        private void CargarDatos()
        {
            string sql = sqlHistorial + @"
                            WHERE
                                (@soloActivas = 0 OR r.estadoRenta = N'Activa') AND
                                (
                                    CAST(r.id_renta AS nvarchar(10)) LIKE @filtro OR
                                    c.nombre LIKE @filtro OR
                                    c.apellido LIKE @filtro OR
                                    c.DUI LIKE @filtro OR
                                    ma.nombreMarca LIKE @filtro OR
                                    mo.nombreModelo LIKE @filtro OR
                                    v.placa LIKE @filtro OR
                                    em.nombre LIKE @filtro OR
                                    em.apellido LIKE @filtro OR
                                    r.estadoRenta LIKE @filtro OR
                                    r.observaciones LIKE @filtro OR
                                    CONVERT(nvarchar(10), r.fecha_inicio, 103) LIKE @filtro
                                )
                          " + sqlOrden;

            SqlParameter[] parametros =
            {
                new SqlParameter("@soloActivas", soloActivas ? 1 : 0),
                new SqlParameter("@filtro", $"%{txtBuscar.Text.Trim()}%")
            };

            dgvRentas.DataSource = con.FiltrarDatos(sql, parametros);
            dgvRentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Quita los segundos (el selector solo muestra hasta los minutos).
        private DateTime Minuto(DateTime valor)
        {
            return new DateTime(valor.Ticks - (valor.Ticks % TimeSpan.TicksPerMinute));
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvRentas.CurrentRow == null)
            {
                return 0;
            }
            return Convert.ToInt32(dgvRentas.CurrentRow.Cells["colID"].Value);
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            dtpFechaInicio.Value = Minuto(DateTime.Now);
            dtpFechaFin.Value = Minuto(DateTime.Now).AddDays(1);
            txtPrecioHora.Clear();
            txtObservaciones.Clear();
            cmbCliente.Focus();
        }

        private void FrmRentas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarDatos();
                LimpiarCampos();
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
                cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el cliente, el vehículo y el empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal precioHora;
            if (!decimal.TryParse(txtPrecioHora.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out precioHora) ||
                precioHora <= 0 ||
                precioHora > 9999999999.99m)
            {
                MessageBox.Show("Ingrese un precio por hora válido, mayor que cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioHora.Focus();
                return;
            }

            DateTime inicio = Minuto(dtpFechaInicio.Value);
            DateTime fin = Minuto(dtpFechaFin.Value);

            if (fin <= inicio)
            {
                MessageBox.Show("La fecha prevista de fin debe ser posterior a la fecha de inicio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaFin.Focus();
                return;
            }

            // Si ya empezó queda Activa y el vehículo Rentado; si empieza después queda Reservada.
            bool activa = inicio <= DateTime.Now;
            string estadoRenta = activa ? "Activa" : "Reservada";
            string estadoVehiculo = activa ? "Rentado" : "Reservado";

            // Una sola transacción: marca el vehículo (solo si sigue 'Disponible') e inserta la renta.
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

                            INSERT INTO renta (id_cliente, id_empleado, id_vehiculo, fecha_inicio, fecha_fin, precioHora, estadoRenta, observaciones)
                            VALUES (@id_cliente, @id_empleado, @id_vehiculo, @fecha_inicio, @fecha_fin, @precioHora, @estadoRenta, @observaciones);

                            COMMIT TRANSACTION;
                        ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@estadoVehiculo", estadoVehiculo),
                new SqlParameter("@id_cliente", cmbCliente.SelectedValue),
                new SqlParameter("@id_empleado", cmbEmpleado.SelectedValue),
                new SqlParameter("@id_vehiculo", cmbVehiculo.SelectedValue),
                new SqlParameter("@fecha_inicio", SqlDbType.DateTime2) { Value = inicio },
                new SqlParameter("@fecha_fin", SqlDbType.DateTime2) { Value = fin },
                new SqlParameter("@precioHora", SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = Math.Round(precioHora, 2) },
                new SqlParameter("@estadoRenta", estadoRenta),
                new SqlParameter("@observaciones", string.IsNullOrWhiteSpace(txtObservaciones.Text)
                                                    ? (object)DBNull.Value
                                                    : txtObservaciones.Text.Trim())
            };

            try
            {
                int afectadas = con.ejecutarComando(sql, parametros);
                if (afectadas > 0)
                {
                    MessageBox.Show("Renta registrada correctamente. Puede asignar equipo seleccionándola en la tabla.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No se pudo guardar la renta: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnAsignarEquipo_Click(object sender, EventArgs e)
        {
            int idRenta = ObtenerIdSeleccionado();
            if (idRenta <= 0)
            {
                MessageBox.Show("Seleccione una renta en la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (FrmAsignacionEquipo frm = new FrmAsignacionEquipo(idRenta))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la asignación de equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            int idRenta = ObtenerIdSeleccionado();
            if (idRenta <= 0)
            {
                MessageBox.Show("Seleccione la renta que desea finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Registrar la devolución del vehículo de la renta #" + idRenta + "?", "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // Finaliza la renta (solo si está Activa) y deja el vehículo Disponible.
            string sql = @"
                            SET XACT_ABORT ON;
                            BEGIN TRANSACTION;

                            UPDATE renta
                            SET estadoRenta = N'Finalizada', fecha_devolucion = GETDATE()
                            WHERE id_renta = @id_renta AND estadoRenta = N'Activa';

                            IF @@ROWCOUNT = 0
                            BEGIN
                                ROLLBACK TRANSACTION;
                                RETURN;
                            END

                            UPDATE vehiculo
                            SET id_estado = (SELECT id_estado FROM estado WHERE nombreEstado = N'Disponible')
                            WHERE id_vehiculo = (SELECT id_vehiculo FROM renta WHERE id_renta = @id_renta);

                            COMMIT TRANSACTION;
                        ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_renta", idRenta)
            };

            try
            {
                int afectadas = con.ejecutarComando(sql, parametros);
                if (afectadas > 0)
                {
                    MessageBox.Show("Devolución registrada. El vehículo está disponible nuevamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    CargarVehiculos();
                }
                else
                {
                    MessageBox.Show("Solo se pueden finalizar rentas en estado Activa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentasActivas_Click(object sender, EventArgs e)
        {
            soloActivas = !soloActivas;
            btnRentasActivas.Text = soloActivas ? "Ver todas" : "Rentas activas";
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
