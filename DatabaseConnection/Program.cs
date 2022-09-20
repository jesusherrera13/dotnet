using System.Data.SqlClient;

namespace DatabaseConnection {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder build = new SqlConnectionStringBuilder();
                
                build.DataSource = "localhost";
                build.UserID = "sa";
                build.Password = "";
                build.InitialCatalog = "beisbol";

                using (SqlConnection connection = new SqlConnection(build.ConnectionString))
                {
                    connection.Open();
                    System.Console.WriteLine("Conección exitosa...");

                    Init(connection);

                    String sql = "SELECT TOP (5) [id],[nombre] from [beisbol].[dbo].[jugadores]";
                    System.Console.WriteLine("Lectura de Registros");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                System.Console.WriteLine(reader["id"]);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch(Exception e)
            {

            }
        }
        private static void Init(SqlConnection connection)
        {
            String sql = "DROP DATABASE IF EXISTS [beisbol]";
            System.Console.WriteLine(sql);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                System.Console.WriteLine("Base de datos eliminada");
            }

            sql = "CREATE DATABASE [beisbol]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                System.Console.WriteLine("Base de datos creada");
            }

            sql = "CREATE TABLE [beisbol].[dbo].[jugadores]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
                System.Console.WriteLine("Tabla jugadores creada");
            }

            for(int i = 1; i <= 5; i++)
            {
                sql = "INSERT INTO [beisbol].[dbo].[jugadores] (id, nombre) values (" + i +", 'Jugador " + i + "')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                System.Console.WriteLine("Jugador " + i + " creado");
            }
        }
    }
}