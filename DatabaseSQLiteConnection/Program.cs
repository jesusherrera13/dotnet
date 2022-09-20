using System.Data.SQLite;

namespace DatabaseSQLiteConnection
{
    class Program{
        static void Main(string[] args)
        {
            string db = @"Jugadores.sqlite";

            SQLiteConnection connection;
            SQLiteCommand command;
            SQLiteDataReader reader;
            string connectionString = "Data Source=" + db;
            string sql;

            if(!File.Exists(db)) {

                // SQLiteConnection.CreateFile("Jugadores.sqlite");

                try 
                {
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();

                    command = connection.CreateCommand();
                    sql = @"CREATE TABLE jugadores (id INTEGER PRIMARY KEY, nombre TEXT, apellido1 TEXT)";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "INSERT INTO jugadores (nombre,apellido1) VALUES ('Thomas A.','Anderson'),('Leon S.','Kennedy'),('Bruce','Wayne');";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = @"CREATE TABLE jugadores (id INTEGER PRIMARY KEY, nombre TEXT, apellido1 TEXT)";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "INSERT INTO jugadores (nombre,apellido1) VALUES ('Thomas A.','Anderson'),('Leon S.','Kennedy'),('Bruce','Wayne');";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    
                    connection.Close();

                }
                catch(Exception e)
                {

                }
            }

            connection = new SQLiteConnection(connectionString);
            connection.Open();

            command = connection.CreateCommand();
            
            sql = "SELECT * FROM jugadores";
            command.CommandText = sql;                    
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                System.Console.WriteLine(reader["id"] + " " + reader["nombre"] + " " + reader["apellido1"]);
            }

            connection.Close();
        }
    }
}