using Clientes.dao;
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
            actualizar();
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

                ClienteDao clienteDao = new ClienteDao();

                clienteDao.Store(cliente);
                //list_clientes.Items.Add(cliente);
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";
            }

            txt_nombre.Focus();
            actualizar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            /*
            int indice = list_clientes.SelectedIndex;

            if (indice >= 0)
            {
                var cliente = (Cliente) list_clientes.Items[indice];
                //MessageBox.Show(cliente.Nombre);
                //string nombre = list_clientes.Items[indice].ToString();
                DialogResult r = MessageBox.Show("¿Desea eliminar a `" + cliente.Nombre + "`?","Eliminar", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    //list_clientes.Items.RemoveAt(indice);
                    ClienteDao clienteDao = new ClienteDao();
                    clienteDao.Destroy(cliente.Id);
                }
            }
            else MessageBox.Show("Seleccione el cliente");
            */
            var cliente = (Cliente) list_clientes.SelectedItem;

            if (cliente != null)
            {
                DialogResult r = MessageBox.Show("¿Desea eliminar a `" + cliente.Nombre + "`?", "Eliminar", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    ClienteDao clienteDao = new ClienteDao();
                    clienteDao.Destroy(cliente.Id);
                    txt_nombre.Focus();
                }
            }
            else MessageBox.Show("Seleccione el cliente");

            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void actualizar()
        {
            list_clientes.Items.Clear();

            ClienteDao clienteDao = new ClienteDao();
            List<Cliente> clientes = clienteDao.getClientes();

            if (clientes.Count == 0) btn_eliminar.Enabled = false;

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente cliente = clientes.ElementAt(i);
                list_clientes.Items.Add(cliente);
            }
        }
    }
}
