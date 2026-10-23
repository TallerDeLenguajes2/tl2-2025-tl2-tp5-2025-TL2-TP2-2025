using Microsoft.Data.Sqlite;
string connectionString = "Data Source=base_test.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
        
    // Insertar datos
            string insertQuery = "INSERT INTO productos (nombre, precio) VALUES ('Tomate', 0.50), ('Uva', 0.30)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'productos'.");
            }
 
    // Leer datos
            string selectQuery = "SELECT * FROM productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nombre: {reader["nombre"]}, Precio: {reader["precio"]}");
                }
            }
   // Actualizar datos
            string updateQuery = "UPDATE productos SET precio = 0.75 WHERE nombre = 'Manzana'";
            using (SqliteCommand updateCmd = new SqliteCommand(updateQuery, connection))
            {
                int filasAfectadas = updateCmd.ExecuteNonQuery();
                Console.WriteLine($"Datos actualizados en la tabla 'productos'. Filas afectadas: {filasAfectadas}");
            }

    // Borrar datos
            string DeleteQuery = "Delete  FROM productos Where nombre = 'Tomate'";
            using (SqliteCommand DeleteCmd = new SqliteCommand(DeleteQuery, connection))
            {
                int filasAfectadas = DeleteCmd.ExecuteNonQuery();
                Console.WriteLine($"Datos borrados de la tabla 'productos'. Filas afectadas: {filasAfectadas}");
            
            }

            connection.Close();
}