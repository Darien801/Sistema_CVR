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
    public partial class FrmCaracteristicas : Form
    {

        private int idModeloSelected = 0;
        private int idMarcaSelected = 0;

        private readonly clsConexion con = new clsConexion();
        public FrmCaracteristicas()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtModelo.Clear();
            txtMarca.Clear();
            txtMarca.Focus();
        }
        private void CargarDatos()
        {
            string sqlModelo = @"select id_modelo as ID, nombreModelo as Modelo from modelo";
            string sqlMarca = @"select id_marca as ID, nombreMarca as Marca from marca";

            dgvModelo.DataSource = con.Consultar(sqlModelo);
            dgvModelo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMarca.DataSource = con.Consultar(sqlMarca);
            dgvMarca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text != "" && txtMarca.Text != "")
            {
                string sqlModelo = $"insert into modelo (nombreModelo) values ('{txtModelo.Text}')";

                SqlParameter[] parametrosModelo =
                {
                    new SqlParameter("@modelo", txtModelo.Text)
                };

                con.ejecutarComando(sqlModelo, parametrosModelo);
                /*-----------------------------------------------------------------------------*/
                string sqlMarca = $"insert into marca (nombreMarca) values ('{txtMarca.Text}')";

                SqlParameter[] parametrosMarca =
                {
                    new SqlParameter("@marca", txtMarca.Text)
                };
                con.ejecutarComando(sqlMarca, parametrosMarca);

                MessageBox.Show("Datos guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();



            } else if (txtModelo.Text != "") 
            {
                string sql = $"insert into modelo (nombreModelo) values ('{txtModelo.Text}')";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@modelo", txtModelo.Text)
                };

                con.ejecutarComando(sql, parametros);
                MessageBox.Show("Modelo guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();

    
                
            }else if(txtMarca.Text != "") 
            {
                string sql = $"insert into marca (nombreMarca) values ('{txtMarca.Text}')";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@marca", txtMarca.Text)
                };

                con.ejecutarComando(sql, parametros);
                MessageBox.Show("Marca guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();

                
            }else if (string.IsNullOrWhiteSpace(txtModelo.Text)
                || string.IsNullOrWhiteSpace(txtMarca.Text))
             {
                MessageBox.Show("Por favor, complete al menos un campo.");
                return;
             }
            
        }

        private void FrmCaracteristicas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idModeloSelected < 0) return;

            DataGridViewRow fila = dgvModelo.Rows[e.RowIndex];

            idModeloSelected = Convert.ToInt32(fila.Cells["ID"].Value);
            txtModelo.Text = fila.Cells["Modelo"].Value.ToString();
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idMarcaSelected < 0) return;

            DataGridViewRow fila = dgvMarca.Rows[e.RowIndex];

            idMarcaSelected = Convert.ToInt32(fila.Cells["ID"].Value);
            txtMarca.Text = fila.Cells["Marca"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idModeloSelected == 0 && idMarcaSelected == 0)
            {
                MessageBox.Show("Seleccione un registro para editar.");
                return;
            }

            if (idModeloSelected != 0)
            {
                if (string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    MessageBox.Show("Escriba el nombre del modelo.");
                    return;
                }

                string sql = "UPDATE modelo SET nombreModelo = @nombre WHERE id_modelo = @idModeloSelected";
                SqlParameter[] parametros = 
                {
                    new SqlParameter("@nombre", txtModelo.Text.Trim()),
                    new SqlParameter("@idModeloSelected", idModeloSelected)
                };

                con.ejecutarComando(sql, parametros);
                MessageBox.Show("Modelo actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idModeloSelected = 0;
            }
            else if (idMarcaSelected != 0)
            {
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    MessageBox.Show("Escriba el nombre de la marca.");
                    return;
                }

                string sql = "UPDATE marca SET nombreMarca = @nombre WHERE id_marca = @idMarcaSelected";
                SqlParameter[] parametros = 
                {
                    new SqlParameter("@nombre", txtMarca.Text.Trim()),
                    new SqlParameter("@idMarcaSelected", idMarcaSelected)
                };

                con.ejecutarComando(sql, parametros);
                MessageBox.Show("Marca actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idMarcaSelected = 0;
            }

            CargarDatos();
            LimpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idModeloSelected == 0 && idMarcaSelected == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
                return;
            }

            if (idModeloSelected != 0) 
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este Modelo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    string sql = "DELETE FROM modelo WHERE id_modelo = @idModeloSelected";
                    List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@idModeloSelected", idModeloSelected)
                };

                    con.ejecutarComando(sql, parametros.ToArray());
                    MessageBox.Show("Modelo eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarCampos();
                    idModeloSelected = 0;
                }
            }else if (idMarcaSelected != 0) 
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta Marca?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    string sql = "DELETE FROM marca WHERE id_marca = @idMarcaSelected";
                    List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@idMarcaSelected", idMarcaSelected)
                };

                    con.ejecutarComando(sql, parametros.ToArray());
                    MessageBox.Show("Marca eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarCampos();
                    idModeloSelected = 0;
                }
            }
        }
    }
}
