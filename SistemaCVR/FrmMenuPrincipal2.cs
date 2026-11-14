using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCVR
{
    public partial class FrmMenuPrincipal2 : Form
    {
        private void CargarFormulario<T>() where T : Form, new()
        {
            pnlContenido.Controls.Clear();

            T obj = new T();

            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            obj.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }


        public FrmMenuPrincipal2()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal2_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CargarFormulario<FrmClientes>();

        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            CargarFormulario<FrmVehiculos>();
        }

        private void btnRentas_Click(object sender, EventArgs e)
        {
            CargarFormulario<FrmRentas>();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            CargarFormulario<FrmReportes>();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea salir del sistema?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is FrmLogin login)
                    {
                        login.limpiarCampos();
                        login.Show();
                        break;
                    }
                }
                this.Close();
            }
        }
    }
}
