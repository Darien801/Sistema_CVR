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
    public partial class FrmCompras : Form
    {
        clsConexion con = new clsConexion();
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            con.CargarCombos(
                cbxMarca,
                "SELECT id_marca, nombreMarca FROM marca ORDER BY 2",
                "nombreMarca",
                "id_marca"
                );

            con.CargarCombos(
                cbxModelo,
                "SELECT id_modelo, nombreModelo FROM modelo ORDER BY 2",
                "nombreModelo",
                "id_modelo"
                );

            con.CargarCombos(
                cbxEmpleado,
                "SELECT id_empleado, nombre FROM empleado ORDER BY 2",
                "nombre",
                "id_empleado"
                );

            CargarDatos();
        }


        private void LimpiarCampos()
        {
            cbxMarca.SelectedIndex = -1;
            cbxModelo.SelectedIndex =-1;
            cbxTipo.SelectedIndex =-1;
            cbxEmpleado.SelectedIndex =-1;
            cbxPaisDeOrigen.SelectedIndex =-1;
            txtDescripcionObservaciones.Clear();
        }

        private void CargarDatos()
        {
            string sql = @" 
                            SELECT
                                id_compra,
                                em.nombre AS Empleado,
                                fechaRegistro, 
                                paisOrigen, 
                                observaciones,
                                c.nombreTipo, 
                                ma.nombreMarca AS Marca, 
                                mo.nombreModelo AS Modelo 
                            FROM compra c
                            INNER JOIN marca ma
                                ON c.id_marca = ma.id_marca
                            INNER JOIN modelo mo
                                ON c.id_modelo = mo.id_modelo
                            INNER JOIN empleado em
                                ON c.id_empleado = em.id_empleado
                          ";
            dgvCompras.DataSource = con.Consultar(sql);
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxEmpleado.SelectedValue == null ||
               cbxMarca.SelectedValue == null ||
               cbxModelo.SelectedValue == null ||
               string.IsNullOrWhiteSpace(cbxPaisDeOrigen.Text) ||
               string.IsNullOrWhiteSpace(cbxTipo.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            string sql = @"
                            INSERT INTO compra (id_empleado, fechaRegistro, paisOrigen, observaciones, nombreTipo, id_marca, id_modelo)
                            VALUES (@id_empleado, GETDATE(), @paisOrigen, @observaciones, @nombreTipo, @id_marca, @id_modelo);
                        ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_empleado", cbxEmpleado.SelectedValue),
                new SqlParameter("@paisOrigen", cbxPaisDeOrigen.Text),
                new SqlParameter("@observaciones", txtDescripcionObservaciones.Text.Trim()),
                new SqlParameter("@nombreTipo", cbxTipo.Text),
                new SqlParameter("@id_marca", cbxMarca.SelectedValue),
                new SqlParameter("@id_modelo", cbxModelo.SelectedValue),
            };

            try
            {
                con.ejecutarComando(sql, parametros);
                CargarDatos();
                LimpiarCampos();
                MessageBox.Show("Compra registrada. El vehículo se agregó al inventario.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la compra: " + ex.Message);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
