using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes
{
    internal class Cliente
    {
        private string nombre;
        private string apellido;

        public int Id { get; set; }
        public string Nombre
        {
            get 
            {
                return this.nombre;
            }

            set
            {
                this.nombre = value;
            }
        }

        public string Apellido {
            get => this.apellido;
            set => this.apellido = value;
        }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string NombreCompleto
        {
            get => Nombre + " " +  Apellido;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
