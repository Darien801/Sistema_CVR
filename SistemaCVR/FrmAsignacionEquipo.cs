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
    // Formulario modal: se abre desde FrmRentas con el id de la renta seleccionada.
    public partial class FrmAsignacionEquipo : Form
    {
        private readonly clsConexion con = new clsConexion();
        private readonly int idRenta;

        public FrmAsignacionEquipo(int idRenta)
        {
            InitializeComponent();
            this.idRenta = idRenta;
        }

        private void CargarDatos()
        {
            string sql = @"
                            SELECT
                                ra.id_renta_accesorio,
                                a.nombreAccesorio AS Equipo,
                                ra.cantidad
                            FROM renta_accesorio ra
                            INNER JOIN accesorio a
                                ON ra.id_accesorio = a.id_accesorio
                            WHERE ra.id_renta = @id_renta
                            ORDER BY a.nombreAccesorio;
                          ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_renta", idRenta)
            };

            dgvEquipoAsignado.DataSource = con.FiltrarDatos(sql, parametros);
            dgvEquipoAsignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmAsignacionEquipo_Load(object sender, EventArgs e)
        {
            try
            {
                // Datos de la renta para mostrarlos en el encabezado
                string sqlRenta = @"
                            SELECT
                                c.nombre + N' ' + c.apellido + N' - ' + ma.nombreMarca + N' ' + mo.nombreModelo
                                    + N' (' + ISNULL(v.placa, N'S/P') + N')' AS descripcion
                            FROM renta r
                            INNER JOIN cliente c ON r.id_cliente = c.id_cliente
                            INNER JOIN vehiculo v ON r.id_vehiculo = v.id_vehiculo
                            INNER JOIN marca ma ON v.id_marca = ma.id_marca
                            INNER JOIN modelo mo ON v.id_modelo = mo.id_modelo
                            WHERE r.id_renta = @id_renta;
                          ";

                DataTable renta = con.FiltrarDatos(sqlRenta, new SqlParameter[] { new SqlParameter("@id_renta", idRenta) });
                if (renta.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró la renta seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }
                lblRenta.Text = "Renta #" + idRenta + ": " + renta.Rows[0]["descripcion"];

                cmbEquipo.DisplayMember = "nombreAccesorio";
                cmbEquipo.ValueMember = "id_accesorio";
                cmbEquipo.DataSource = con.Consultar("SELECT id_accesorio, nombreAccesorio FROM accesorio ORDER BY 2");
                cmbEquipo.SelectedIndex = -1;

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbEquipo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el equipo que desea asignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Si el equipo ya estaba asignado a la renta, se suma la cantidad (la tabla no permite repetidos).
            string sql = @"
                            IF EXISTS (SELECT 1 FROM renta_accesorio WHERE id_renta = @id_renta AND id_accesorio = @id_accesorio)
                                UPDATE renta_accesorio
                                SET cantidad = cantidad + @cantidad
                                WHERE id_renta = @id_renta AND id_accesorio = @id_accesorio;
                            ELSE
                                INSERT INTO renta_accesorio (id_renta, id_accesorio, cantidad)
                                VALUES (@id_renta, @id_accesorio, @cantidad);
                          ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_renta", idRenta),
                new SqlParameter("@id_accesorio", cmbEquipo.SelectedValue),
                new SqlParameter("@cantidad", (int)nudCantidad.Value)
            };

            try
            {
                con.ejecutarComando(sql, parametros);
                CargarDatos();
                cmbEquipo.SelectedIndex = -1;
                nudCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo asignar el equipo: " + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvEquipoAsignado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el equipo que desea quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Quitar el equipo seleccionado de la renta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string sql = "DELETE FROM renta_accesorio WHERE id_renta_accesorio = @id_renta_accesorio;";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_renta_accesorio", Convert.ToInt32(dgvEquipoAsignado.CurrentRow.Cells["colID"].Value))
            };

            try
            {
                con.ejecutarComando(sql, parametros);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo quitar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
