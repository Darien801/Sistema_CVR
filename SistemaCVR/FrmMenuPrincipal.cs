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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            FrmClientes obj = new FrmClientes();

            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            //obj.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear(); 
            
            FrmVehiculos obj = new FrmVehiculos();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            
            FrmCompras obj = new FrmCompras();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmVentas obj = new FrmVentas();
            obj.TopLevel = false;
            obj.FormBorderStyle= FormBorderStyle.None;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnRentas_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmRentas obj = new FrmRentas();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmReportes obj = new FrmReportes();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;

            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
        /*
         Empiezan los botones del submenu de configuracion, que se despliega al dar click en el boton de configuracion
         */
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            panelSubMenuConfig.Visible = !panelSubMenuConfig.Visible;
        }

        private void btnConfUsuarios_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            FrmEmpleado obj = new FrmEmpleado();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnConfCaract_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmCaracteristicas obj = new FrmCaracteristicas();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnConfEquipo_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmEquipo obj = new FrmEquipo();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            pnlContenido.Controls.Add(obj);
            obj.Show();
        }

        private void btnConfEstado_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            FrmEstado obj = new FrmEstado();
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            pnlContenido.Controls.Add(obj);
            obj.Show();
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
