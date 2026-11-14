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
    public partial class FrmLogin : Form
    {
        clsConexion bd = new clsConexion();
        public FrmLogin()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContraseña.Text = "";
            txtNombre.Focus();
        }

        private void BuscarEmpleado()
        {
            string sql = @"
                SELECT id_empleado, nombre, apellido, rolEmpleado, estadoEmpleado
                FROM empleado
                WHERE nombre = @nombre
                AND apellido = @apellido
                AND hashEmpleado = @hash";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", txtNombre.Text.Trim()),
                new SqlParameter("@apellido", txtApellido.Text.Trim()),
                new SqlParameter("@hash", bd.GenerarHashMD5(txtContraseña.Text.Trim()))
            };

            DataTable tabla = bd.FiltrarDatos(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                string estado = tabla.Rows[0]["estadoEmpleado"].ToString();

                if (estado != "Activo")
                {
                    MessageBox.Show("El empleado se encuentra inactivo.");
                    return;
                }

                string tipoCredenciales = tabla.Rows[0]["rolEmpleado"].ToString().Trim();

                Form menu;
                if (tipoCredenciales == "Administrador")
                {
                    menu = new FrmMenuPrincipal();
                }
                else
                {
                    menu = new FrmMenuPrincipal2();
                }

                menu.FormClosed += (s, args) => 
                {
                    if (!this.Visible)
                    {
                        Application.Exit();
                    }
                };

                this.Hide();
                menu.Show();


            }
            else
            {
                MessageBox.Show("Nombre, apellido o contraseña incorrectos.");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }
    }
}
