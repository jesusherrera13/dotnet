using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientes.dao
{
    internal class ClienteDao
    {
        // private MySqlConnection connection;
        private string server = "localhost";
        private string user = "root";
        private string password = "";
        private string database = "clientes";

        public MySqlConnection Conectar()
        {
            MySqlConnection connection;

            try
            {
                // MySQL
                /*
                drop database clientes;
                create database clientes;
                use clientes;
                create table clientes.clientes (
	                id int not null auto_increment, 
                    nombre varchar(50),
                    telefono varchar(50),
                    email varchar(50),
                    primary key (id)
                );
                alter table clientes.clientes add column `apellido` varchar(50) after nombre;
                INSERT INTO `clientes`.`clientes` (`nombre`, `apellido`, `telefono`, `email`) VALUES ('Keanu', 'Reeves', '369', 'neo@matrix.com'); 
                */

                string connectionString = "server=" + this.server + ";database=" + this.database + ";user=" + this.user + ";password=" + this.password + ";";
                //string connectionString = "server=" + servidor + ";database=" + db + ";uid=" + user + ";password=" + password+";";
                //string connectionString = "Database=" + database + ";Data Source=" + server + ";User Id=" + user + ";Password=" + password + ";";

                /* 
                MSSQL
                var connectionString = "Server=localhost\\SQLEXPRESS;Integrated Security = SSPI; database = MyDB";
                */

                connection = new MySqlConnection(connectionString);

                return connection;

            }
            catch (Exception e)
            {

            }

            return null;
            
        }

        public List<Cliente> getClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            MySqlConnection connection = Conectar();

            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM " + database + ".clientes";
                MySqlCommand command = new MySqlCommand(@sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = Int32.Parse(reader.GetString("id"));
                    cliente.Nombre = reader.GetString("nombre");
                    cliente.Apellido = reader.GetString("apellido");
                    cliente.Telefono = reader.GetString("telefono");
                    cliente.Email = reader.GetString("email");
                    clientes.Add(cliente);
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Error de Conección");
            }

            return clientes;
        }

        public void Store(Cliente cliente)
        {
            MySqlConnection connection = Conectar();

            if (connection != null)
            {
                connection.Open();
                string sql = "" +
                    "INSERT INTO " + database + ".clientes " +
                    "(nombre, apellido, telefono, email) values ('" + cliente.Nombre + "','" + cliente.Apellido + "','" + cliente.Telefono + "','" + cliente.Email + "')";
                MySqlCommand command = new MySqlCommand(@sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Error de Conección");
            }
        }

        public void Update(Cliente cliente)
        {
            MySqlConnection connection = Conectar();

            if (connection != null)
            {
                connection.Open();
                string sql = "" +
                    "UPDATE " + database + ".clientes SET nombre='" + cliente.Nombre + "',apellido='" + cliente.Apellido + "',telefono='" + cliente.Telefono + "',email='" + cliente.Email + "' WHERE id=" + cliente.Id;
                MySqlCommand command = new MySqlCommand(@sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Error de Conección");
            }
        }

        public Cliente Show(int id)
        {
            MySqlConnection connection = Conectar();
            Cliente cliente = new Cliente();

            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM " + database + ".clientes";
                MySqlCommand command = new MySqlCommand(@sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.Id = Int32.Parse(reader.GetString("id"));
                    cliente.Nombre = reader.GetString("nombre");
                    cliente.Apellido = reader.GetString("apellido");
                    cliente.Telefono = reader.GetString("telefono");
                    cliente.Email = reader.GetString("email");
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Error de Conección");
            }

            return cliente;

        }

        public void Destroy(int id)
        {
            MySqlConnection connection = Conectar();

            if (connection != null)
            {
                connection.Open();
                string query = "DELETE FROM clientes where id= " + id;
                MySqlCommand command = new MySqlCommand(@query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Error de Conección");
            }
        }
    }
}
