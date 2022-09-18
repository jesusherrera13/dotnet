using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientes
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "Público";
            list_clientes.Items.Add(cliente);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (list_clientes.Items.Count == 0) btn_eliminar.Enabled = true;

            string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            string telefono = txt_telefono.Text;
            string email = txt_email.Text;

            if (txt_nombre.Text == "")
            {
                MessageBox.Show("Escriba el nombre");
            }
            else
            { 
                Cliente cliente = new Cliente();

                cliente.Nombre = txt_nombre.Text;
                cliente.Apellido = txt_apellido.Text;
                cliente.Telefono = txt_telefono.Text;
                cliente.Email = txt_email.Text;

                list_clientes.Items.Add(cliente);
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";
            }

            txt_nombre.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int indice = list_clientes.SelectedIndex;

            if (indice >= 0)
            {
                var cliente = (Cliente) list_clientes.Items[indice];
                //MessageBox.Show(cliente.Nombre);
                //string nombre = list_clientes.Items[indice].ToString();
                DialogResult r = MessageBox.Show("¿Desea eliminar a `" + cliente.Nombre + "`?","Eliminar", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    list_clientes.Items.RemoveAt(indice);
                }
            }
            else MessageBox.Show("Seleccione el cliente");

            if (list_clientes.Items.Count == 0) btn_eliminar.Enabled = false;
        }
    }
}
