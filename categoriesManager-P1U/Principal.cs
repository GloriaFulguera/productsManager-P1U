﻿using System;
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

        int estadoGuardar = 0;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoGuardar = 1;
            grbBotones.Enabled = false;
            grbManager.Enabled = true;
            txbCodigo.Text = "";
            txbDescripcion.Text = "";
            lsbInformacion.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            grbBotones.Enabled = true;
            grbManager.Enabled = false;
            txbCodigo.Text = "";
            txbDescripcion.Text = "";

            lblMensajes.Text = "";
            lblMensajes.Visible = false;
            lsbInformacion.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string item = "";
            if (txbCodigo.Text != "" && txbDescripcion.Text != "")
            {
                item += txbCodigo.Text + "    " + txbDescripcion.Text;
                if (estadoGuardar == 1)
                {
                    lsbInformacion.Items.Add(item);
                    lblMensajes.Text = "";
                    lblMensajes.Visible = false;
                    txbCodigo.Text = "";
                    txbDescripcion.Text = "";
                }
                else
                {
                    int elemento = lsbInformacion.SelectedIndex;

                    if(elemento != -1)
                    {
                        lsbInformacion.Items.Remove(lsbInformacion.Items[elemento]);
                        lsbInformacion.Items.Insert(elemento, item);
                    }
                    /* (yo hice lo de arriba) el tuto decia:
                     * lsbInformacion.Items.Remove(lsbInformacion.SelectedItem);
                     * lsbInformacion.Items.Insert(elemento, item);
                     */
                }

                //MessageBox.Show("Producto agregado correctamente.");
            }
            else
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "Tiene que llenar ambos campos!";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lsbInformacion.Items.Remove(lsbInformacion.SelectedItem);
            }

            //Messaje
            //MessageBox.Show("Seguro?", "confirmar", MessageBoxButtons.YesNo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lsbInformacion_Click(object sender, EventArgs e)
        {
            string item;
            if (lsbInformacion.SelectedItem != null)
            {
                item = lsbInformacion.SelectedItem.ToString();
                txbCodigo.Text = item.Substring(0, 3).Trim();
                txbDescripcion.Text = item.Substring(3).Trim();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            estadoGuardar = 2;
            grbBotones.Enabled = false;
            grbManager.Enabled = true;

        }

    }
}
