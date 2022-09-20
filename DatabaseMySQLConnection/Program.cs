using MySql.Data.MySqlClient;

namespace DatabaseMySQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                string connectionString = "server=localhost;database=beisbol;user=root;password=";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM jugadores";
                MySqlCommand command = new MySqlCommand(@sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    System.Console.WriteLine(reader["id"] + " " + reader["nombre"] + " " + reader["apellido1"]);
                }               
            }
            catch(Exception e)
            {

            }
        }
    }
}