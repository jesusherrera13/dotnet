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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            Clientes vtn_clientes = new Clientes();
            vtn_clientes.ShowDialog();
        }
    }
}
