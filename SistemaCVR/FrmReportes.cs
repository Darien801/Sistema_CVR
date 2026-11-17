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
using ClosedXML.Excel;

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
            FormatoMoneda("Precio");

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
            FormatoMoneda("PrecioHora", "Total");

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
                else if (cmbTipoReporte.Text == "Estadísticas de ventas")
                {
                    ReporteEstadisticasVentas(parametros);
                }
                else if (cmbTipoReporte.Text == "Estado de vehículos")
                {
                    ReporteVehiculos();
                }
                else if (cmbTipoReporte.Text == "Últimas rentas")
                {
                    ReporteUltimasRentas();
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


        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable tabla = dgvReporte.DataSource as DataTable;

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("Genere primero un reporte con resultados.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                dialogo.FileName = "Reporte_" + cmbTipoReporte.Text + "_" +
                                   DateTime.Today.ToString("yyyyMMdd") + ".xlsx";

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Reporte");

                        // Insertar los datos del DataTable
                        var tablaExcel = hoja.Cell(1, 1).InsertTable(tabla);

                        // Dar formato a los encabezados
                        tablaExcel.Theme = XLTableTheme.TableStyleMedium2;

                        // Ajustar el ancho de las columnas
                        hoja.Columns().AdjustToContents();

                        // Mantener visible la primera fila al desplazarse
                        hoja.SheetView.FreezeRows(1);

                        // Guardar el archivo Excel
                        libro.SaveAs(dialogo.FileName);
                    }

                    MessageBox.Show("Reporte exportado correctamente.",
                        "Registro exitoso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar el reporte: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool usaFechas = cmbTipoReporte.Text != "Estado de vehículos" && cmbTipoReporte.Text != "Últimas rentas";
            dtpDesde.Enabled = usaFechas;
            dtpHasta.Enabled = usaFechas;
        }



        private void FormatoMoneda(params string[] columnas)
        {
            foreach (string nombre in columnas)
            {
                if (dgvReporte.Columns.Contains(nombre))
                {
                    dgvReporte.Columns[nombre].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns[nombre].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    

        private void ReporteEstadisticasVentas(SqlParameter[] parametros)
        {
            string sql = @"
                            SELECT
                                FORMAT(DATEFROMPARTS(YEAR(vt.fecha), MONTH(vt.fecha), 1), 'MMMM yyyy', 'es-ES') AS Mes,
                                COUNT(*) AS Ventas,
                                SUM(CASE WHEN vt.estadoVenta = N'Completada' THEN 1 ELSE 0 END) AS Completadas,
                                SUM(CASE WHEN vt.estadoVenta NOT IN (N'Completada', N'Cancelada') THEN 1 ELSE 0 END) AS Pendientes,
                                SUM(CASE WHEN vt.estadoVenta = N'Cancelada' THEN 1 ELSE 0 END) AS Canceladas,
                                CAST(ISNULL(SUM(CASE WHEN vt.estadoVenta = N'Completada' THEN vt.precioVenta END), 0) AS decimal(12, 2)) AS Total,
                                CAST(ISNULL(AVG(CASE WHEN vt.estadoVenta = N'Completada' THEN vt.precioVenta END), 0) AS decimal(12, 2)) AS Promedio,
                                CAST(ISNULL(MAX(CASE WHEN vt.estadoVenta = N'Completada' THEN vt.precioVenta END), 0) AS decimal(12, 2)) AS Maximo,
                                CAST(ISNULL(MIN(CASE WHEN vt.estadoVenta = N'Completada' THEN vt.precioVenta END), 0) AS decimal(12, 2)) AS Minimo
                            FROM venta vt
                            WHERE vt.fecha BETWEEN @desde AND @hasta
                            GROUP BY YEAR(vt.fecha), MONTH(vt.fecha)
                            ORDER BY YEAR(vt.fecha) DESC, MONTH(vt.fecha) DESC;
                          ";

            DataTable tabla = con.FiltrarDatos(sql, parametros);
            MostrarTabla(tabla);
            FormatoMoneda("Promedio", "Maximo", "Minimo");

            object sumaVentas = tabla.Compute("SUM(Ventas)", "");
            object sumaCompletadas = tabla.Compute("SUM(Completadas)", "");
            object sumaTotal = tabla.Compute("SUM(Total)", "");
            int ventas = sumaVentas == DBNull.Value ? 0 : Convert.ToInt32(sumaVentas);
            int completadas = sumaCompletadas == DBNull.Value ? 0 : Convert.ToInt32(sumaCompletadas);
            decimal total = sumaTotal == DBNull.Value ? 0 : Convert.ToDecimal(sumaTotal);
            decimal promedio = completadas == 0 ? 0 : total / completadas;

            string sqlMarca = @"
                                SELECT TOP 1 ma.nombreMarca
                                FROM venta vt
                                INNER JOIN vehiculo v
                                    ON vt.id_vehiculo = v.id_vehiculo
                                INNER JOIN marca ma
                                    ON v.id_marca = ma.id_marca
                                WHERE vt.estadoVenta = N'Completada' AND vt.fecha BETWEEN @desde AND @hasta
                                GROUP BY ma.nombreMarca
                                ORDER BY COUNT(*) DESC, SUM(vt.precioVenta) DESC;
                              ";

            SqlParameter[] parametrosMarca = parametros
                .Select(p => new SqlParameter(p.ParameterName, p.SqlDbType) { Value = p.Value })
                .ToArray();

            object marca = con.ejecutarEscalar(sqlMarca, parametrosMarca);

            lblResumen.Text = "Ventas: " + ventas +
                              "   |   Completadas: " + completadas +
                              "   |   Total vendido: " + total.ToString("C2") +
                              "   |   Promedio por venta: " + promedio.ToString("C2") +
                              "   |   Marca más vendida: " + (marca == null || marca == DBNull.Value ? "N/D" : marca.ToString());
        }



        private void ReporteVehiculos()
        {
            string sql = @"
                            SELECT
                                v.id_vehiculo AS ID,
                                ma.nombreMarca AS Marca,
                                mo.nombreModelo AS Modelo,
                                v.anio AS Año,
                                v.color AS Color,
                                ISNULL(v.placa, N'S/P') AS Placa,
                                ISNULL(es.nombreEstado, N'Sin estado') AS Estado,
                                v.precioCompra AS PrecioCompra
                            FROM vehiculo v
                            INNER JOIN marca ma
                                ON v.id_marca = ma.id_marca
                            INNER JOIN modelo mo
                                ON v.id_modelo = mo.id_modelo
                            LEFT JOIN estado es
                                ON v.id_estado = es.id_estado
                            ORDER BY CASE WHEN es.nombreEstado = N'Disponible' THEN 0 ELSE 1 END,
                                     es.nombreEstado, ma.nombreMarca, mo.nombreModelo;
                          ";

            DataTable tabla = con.Consultar(sql);
            MostrarTabla(tabla);
            FormatoMoneda("PrecioCompra");

            Dictionary<string, int> conteo = new Dictionary<string, int>();
            foreach (DataRow fila in tabla.Rows)
            {
                string estado = Convert.ToString(fila["Estado"]);
                conteo[estado] = conteo.ContainsKey(estado) ? conteo[estado] + 1 : 1;
            }

            int disponibles = conteo.ContainsKey("Disponible") ? conteo["Disponible"] : 0;
            string detalle = string.Join("   |   ", conteo.Where(c => c.Key != "Disponible").Select(c => c.Key + ": " + c.Value));

            lblResumen.Text = "Vehículos registrados: " + tabla.Rows.Count +
                              "   |   Disponibles: " + disponibles +
                              (detalle.Length > 0 ? "   |   " + detalle : "");
        }


        private void ReporteUltimasRentas()
        {
            string sql = @"
                            SELECT TOP 10
                                r.id_renta AS ID,
                                c.nombre + N' ' + c.apellido AS Cliente,
                                ma.nombreMarca + N' ' + mo.nombreModelo + N' (' + ISNULL(v.placa, N'S/P') + N')' AS Vehiculo,
                                em.nombre + N' ' + em.apellido AS Empleado,
                                r.fecha_inicio AS Inicio,
                                r.fecha_fin AS FinPrevisto,
                                r.fecha_devolucion AS Devolucion,
                                r.precioHora AS PrecioHora,
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
                            INNER JOIN empleado em
                                ON r.id_empleado = em.id_empleado
                            ORDER BY r.fecha_inicio DESC, r.id_renta DESC;
                          ";

            DataTable tabla = con.Consultar(sql);
            MostrarTabla(tabla);

            object suma = tabla.Compute("SUM(Total)", "");
            decimal total = suma == DBNull.Value ? 0 : Convert.ToDecimal(suma);
            int activas = tabla.Select("Estado = 'Activa'").Length;
            lblResumen.Text = "Últimas rentas registradas: " + tabla.Rows.Count +
                              "   |   Activas: " + activas +
                              "   |   Total estimado: " + total.ToString("C2");
        }
    }
}
