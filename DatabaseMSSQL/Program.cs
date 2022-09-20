using System.Data.SqlClient;

namespace DatabaseMSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                DROP DATABASE beisbol;
                CREATE DATABASE beisbol;
                USE beisbol;
                CREATE TABLE jugadores (
                    id INT IDENTITY(1,1) PRIMARY KEY,
                    nombre varchar(50),
                    apellido1 varchar(50),
                    edad TINYINT
                );
                INSERT INTO jugadores (nombre,apellido1,edad) VALUES ('Keanu','Reeves',50);

                SELECT * FROM jugadores;
                */
                string connectionString = "Data Source=localhost;Initial Catalog=beisbol;Integrated Security=false;User ID=sa;Password=A1b2C3d4E5$";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) 
                {
                    connection.Open();
                    System.Console.WriteLine("MSSQL connected");

                    // string sql = "SELECT * FROM jugadores";
                    string sql = "SELECT TOP (1000) [id],[nombre],[apellido1],[edad] FROM [beisbol].[dbo].[jugadores]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                System.Console.WriteLine(reader["id"] + " " + reader["nombre"] + " " + reader["apellido1"]);
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
    }
}