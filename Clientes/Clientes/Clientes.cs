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
            list_clientes.Items.Add("Público");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Text;
            if(nombre == "")
            {
                MessageBox.Show("Escriba el nombre");
            }
            else
            {
                list_clientes.Items.Add(nombre);
                txt_nombre.Text = "";
            }

            txt_nombre.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int indice = list_clientes.SelectedIndex;

            if (indice >= 0)
            {
                string nombre = list_clientes.Items[indice].ToString();
                DialogResult r = MessageBox.Show("¿Desea eliminar a `" + nombre + "`?","Eliminar", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    list_clientes.Items.RemoveAt(indice);
                }
            }
            else MessageBox.Show("Seleccione el cliente");
        }
    }
}
