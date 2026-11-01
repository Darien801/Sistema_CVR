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
    }
}
