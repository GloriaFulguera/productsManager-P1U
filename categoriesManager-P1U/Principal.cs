using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace categoriesManager_P1U
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grbBotones.Enabled= false;
            grbManager.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            grbBotones.Enabled = true;
            grbManager.Enabled = false;
            txbCodigo.Text = "";
            txbDescripcion.Text = "";

            lblMensajes.Text = "";
            lblMensajes.Visible= false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string item = "";
            if (txbCodigo.Text != "" && txbDescripcion.Text != "")
            {
                item += txbCodigo.Text + "    " + txbDescripcion.Text;
                lsbInformacion.Items.Add(item);
                lblMensajes.Text = "";
                lblMensajes.Visible = false;
                txbCodigo.Text = "";
                txbDescripcion.Text = "";

                MessageBox.Show("Producto agregado correctamente.");
            }
            else
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "Tiene que llenar ambos campos!";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //DialogResult res= MessageBox.Show(MessageBoxButtons.YesNo);
            lsbInformacion.Items.Remove(lsbInformacion.SelectedItem);
        }
    }
}
