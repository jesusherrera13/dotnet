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
        public MySqlConnection connection_mysql;
        public SqlConnection connection_mssql;
        string dbms = "MSSQL";
        string connectionString;

        public void Conectar()
        {
            try
            {
                if(dbms == "MySQL")
                {

                    /*
                    // MySQL
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

                    connectionString = "server=localhost;database=clientes;user=root;password=;";
                    //string connectionString = "server=" + servidor + ";database=" + db + ";uid=" + user + ";password=" + password+";";
                    //string connectionString = "Database=" + database + ";Data Source=" + server + ";User Id=" + user + ";Password=" + password + ";";
                    connection_mysql = new MySqlConnection(connectionString);
                }
                else if(dbms == "MSSQL")
                {

                    /*
                    // MSSQL
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

                    connectionString = "Server=localhost\\SQLEXPRESS;Database=clientes;Trusted_Connection=True;User ID=sa;Password=A1b2C3d4E5$";
                    //connectionString = "Server=localhost\\SQLEXPRESS;Integrated Security = SSPI; database = MyDB";
                    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connectionString);
                    connection_mssql = new SqlConnection(sb.ConnectionString);
                }
            }
            catch (Exception e)
            {

            }
        }

        public List<Cliente> getClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            Conectar();
            
            try
            {
                if(dbms == "MySQL")
                {
                    connection_mysql.Open();
                    if (connection_mysql.State.ToString() == "Open")
                    {
                        string sql = "SELECT id,nombre,apellido,telefono,email FROM clientes";
                        MySqlCommand command = new MySqlCommand(@sql, connection_mysql);
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

                        connection_mysql.Close();
                    }
                }
                else if(dbms == "MSSQL")
                {
                    connection_mssql.Open();
                    if(connection_mssql.State.ToString() == "Open")
                    {
                        string sql = "SELECT [id],[nombre],[apellido],[telefono],[email] FROM clientes";
                        using (SqlCommand command = new SqlCommand(@sql,connection_mssql))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Cliente cliente = new Cliente();
                                    cliente.Id = Int32.Parse(reader["id"].ToString());
                                    cliente.Nombre = reader[1].ToString(); //Nombre
                                    cliente.Apellido = (string)reader["apellido"];
                                    cliente.Telefono = (string)reader["telefono"];
                                    cliente.Email = (string)reader["email"];
                                    clientes.Add(cliente);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error de Conección");
            }

            return clientes;
        }

        public void Store(Cliente cliente)
        {
            try
            {
                Conectar();

                string sql = "" +
                        "INSERT INTO clientes " +
                        "(nombre, apellido, telefono, email) values ('" + cliente.Nombre + "','" + cliente.Apellido + "','" + cliente.Telefono + "','" + cliente.Email + "')";

                if (dbms == "MySQL")
                {
                    connection_mysql.Open();
                    if (connection_mysql.State.ToString() == "Open")
                    {
                        MySqlCommand command = new MySqlCommand(@sql, connection_mysql);
                        command.ExecuteNonQuery();
                        connection_mysql.Close();
                    }
                }
                else if (dbms == "MSSQL")
                {
                    connection_mssql.Open();
                    if (connection_mssql.State.ToString() == "Open")
                    {
                        using (SqlCommand command = new SqlCommand(@sql, connection_mssql))
                        {
                            command.ExecuteNonQuery();
                            connection_mssql.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de Conección");
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                Conectar();

                string sql =  "UPDATE clientes SET nombre='" + cliente.Nombre + "',apellido='" + cliente.Apellido + "',telefono='" + cliente.Telefono + "',email='" + cliente.Email + "' WHERE id=" + cliente.Id;

                if (dbms == "MySQL")
                {
                    connection_mysql.Open();
                    if (connection_mysql.State.ToString() == "Open")
                    {
                        MySqlCommand command = new MySqlCommand(@sql, connection_mysql);
                        command.ExecuteNonQuery();
                        connection_mysql.Close();
                    }
                }
                else if (dbms == "MSSQL")
                {
                    connection_mssql.Open();
                    if (connection_mssql.State.ToString() == "Open")
                    {
                        using (SqlCommand command = new SqlCommand(@sql, connection_mssql))
                        {
                            command.ExecuteNonQuery();
                            connection_mssql.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de Conección");
            }
        }

        public Cliente Show(int id)
        {
            Cliente cliente = new Cliente();
            //MySqlConnection connection = Conectar();
            //connection.Open();

            //try
            //{
            //    if (connection.State.ToString() == "Open")
            //    {
            //        string sql = "SELECT * FROM " + database + ".clientes";
            //        MySqlCommand command = new MySqlCommand(@sql, connection);
            //        MySqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            cliente = new Cliente();
            //            cliente.Id = Int32.Parse(reader.GetString("id"));
            //            cliente.Nombre = reader.GetString("nombre");
            //            cliente.Apellido = reader.GetString("apellido");
            //            cliente.Telefono = reader.GetString("telefono");
            //            cliente.Email = reader.GetString("email");
            //        }

            //        connection.Close();
            //    }
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show("Error de Conección");
            //}

            return cliente;

        }

        public void Destroy(int id)
        {
            try
            {
                Conectar();

                string sql = "DELETE FROM clientes where id= " + id;

                if (dbms == "MySQL")
                {
                    connection_mysql.Open();
                    if (connection_mysql.State.ToString() == "Open")
                    {
                        MySqlCommand command = new MySqlCommand(@sql, connection_mysql);
                        command.ExecuteNonQuery();
                        connection_mysql.Close();
                    }
                }
                else if (dbms == "MSSQL")
                {
                    connection_mssql.Open();
                    if (connection_mssql.State.ToString() == "Open")
                    {
                        using (SqlCommand command = new SqlCommand(@sql, connection_mssql))
                        {
                            command.ExecuteNonQuery();
                            connection_mssql.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de Conección");
            }
        }
    }
}
