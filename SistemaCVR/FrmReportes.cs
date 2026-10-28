using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCVR
{
    public partial class FrmReportes : Form
    {
        private readonly clsConexion con = new clsConexion();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            cmbTipoReporte.SelectedIndex = 0;
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
        }

        private void ReporteVentas(SqlParameter[] parametros)
        {
            string sql = @"
                            SELECT
                                vt.id_venta AS ID,
                                c.nombre + N' ' + c.apellido AS Cliente,
                                ma.nombreMarca + N' ' + mo.nombreModelo + N' (' + ISNULL(v.placa, N'S/P') + N')' AS Vehiculo,
                                em.nombre + N' ' + em.apellido AS Empleado,
                                vt.fecha AS Fecha,
                                vt.precioVenta AS Precio,
                                vt.estadoVenta AS Estado
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
                            WHERE vt.fecha BETWEEN @desde AND @hasta
                            ORDER BY vt.fecha DESC, vt.id_venta DESC;
                          ";

            DataTable tabla = con.FiltrarDatos(sql, parametros);
            MostrarTabla(tabla);

            object suma = tabla.Compute("SUM(Precio)", "Estado = 'Completada'");
            decimal total = suma == DBNull.Value ? 0 : Convert.ToDecimal(suma);
            lblResumen.Text = "Ventas encontradas: " + tabla.Rows.Count +
                              "   |   Total de ventas completadas: " + total.ToString("C2");
        }

        private void ReporteRentas(SqlParameter[] parametros)
        {
            // Horas = desde el inicio hasta la devolución real (o el fin previsto si aún no se devuelve).
            // Total = horas x precio por hora (las rentas canceladas no se cobran).
            string sql = @"
                            SELECT
                                r.id_renta AS ID,
                                c.nombre + N' ' + c.apellido AS Cliente,
                                ma.nombreMarca + N' ' + mo.nombreModelo + N' (' + ISNULL(v.placa, N'S/P') + N')' AS Vehiculo,
                                r.fecha_inicio AS Inicio,
                                r.fecha_fin AS FinPrevisto,
                                r.fecha_devolucion AS Devolucion,
                                r.precioHora AS PrecioHora,
                                CAST(DATEDIFF(MINUTE, r.fecha_inicio, ISNULL(r.fecha_devolucion, r.fecha_fin)) / 60.0 AS decimal(10, 2)) AS Horas,
                                CAST(CASE WHEN r.estadoRenta = N'Cancelada' THEN 0
                                          ELSE DATEDIFF(MINUTE, r.fecha_inicio, ISNULL(r.fecha_devolucion, r.fecha_fin)) / 60.0 * r.precioHora
                                     END AS decimal(12, 2)) AS Total,
                                r.estadoRenta AS Estado
                            FROM renta r
                            INNER JOIN cliente c
                                ON r.id_cliente = c.id_cliente
                            INNER JOIN vehiculo v
                                ON r.id_vehiculo = v.id_vehiculo
                            INNER JOIN marca ma
                                ON v.id_marca = ma.id_marca
                            INNER JOIN modelo mo
                                ON v.id_modelo = mo.id_modelo
                            WHERE r.fecha_inicio >= @desde AND r.fecha_inicio < DATEADD(DAY, 1, @hasta)
                            ORDER BY r.fecha_inicio DESC, r.id_renta DESC;
                          ";

            DataTable tabla = con.FiltrarDatos(sql, parametros);
            MostrarTabla(tabla);

            object suma = tabla.Compute("SUM(Total)", "");
            decimal total = suma == DBNull.Value ? 0 : Convert.ToDecimal(suma);
            int activas = tabla.Select("Estado = 'Activa'").Length;
            lblResumen.Text = "Rentas encontradas: " + tabla.Rows.Count +
                              "   |   Activas: " + activas +
                              "   |   Total estimado: " + total.ToString("C2");
        }

        private void MostrarTabla(DataTable tabla)
        {
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
            dgvReporte.DataSource = tabla;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn columna in dgvReporte.Columns)
            {
                if (columna.Name == "Precio" || columna.Name == "PrecioHora" || columna.Name == "Total")
                {
                    columna.DefaultCellStyle.Format = "C2";
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (columna.ValueType == typeof(DateTime))
                {
                    columna.DefaultCellStyle.Format = columna.Name == "Fecha" ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser posterior a la fecha final.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlParameter[] parametros =
            {
                new SqlParameter("@desde", SqlDbType.Date) { Value = dtpDesde.Value.Date },
                new SqlParameter("@hasta", SqlDbType.Date) { Value = dtpHasta.Value.Date }
            };

            try
            {
                if (cmbTipoReporte.Text == "Ventas")
                {
                    ReporteVentas(parametros);
                }
                else
                {
                    ReporteRentas(parametros);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Csv(object valor)
        {
            string texto;
            if (valor is DateTime)
            {
                DateTime fecha = (DateTime)valor;
                texto = fecha.ToString(fecha.TimeOfDay == TimeSpan.Zero ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm");
            }
            else if (valor is decimal)
            {
                texto = ((decimal)valor).ToString("0.00", CultureInfo.InvariantCulture);
            }
            else
            {
                texto = Convert.ToString(valor);
            }
            return "\"" + texto.Replace("\"", "\"\"") + "\"";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable tabla = dgvReporte.DataSource as DataTable;
            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("Genere primero un reporte con resultados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivo CSV (*.csv)|*.csv";
                dialogo.FileName = "Reporte_" + cmbTipoReporte.Text + "_" + DateTime.Today.ToString("yyyyMMdd") + ".csv";

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Join(",", tabla.Columns.Cast<DataColumn>().Select(c => Csv(c.ColumnName))));
                    foreach (DataRow fila in tabla.Rows)
                    {
                        sb.AppendLine(string.Join(",", fila.ItemArray.Select(v => Csv(v))));
                    }

                    File.WriteAllText(dialogo.FileName, sb.ToString(), new UTF8Encoding(true));
                    MessageBox.Show("Reporte exportado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
