using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Base.Helpers;
using Console = Repository.Entities.Console;

namespace Repository.Base
{
    public class GenericRepository<T>
    {
        internal readonly string connectionString = ConfigurationHelper.GetConnectionString(); // Tu cadena de conexión a la base de datos
        public List<T> GetAll()
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM {tableName}";
            List<T> entities = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T entity = MapFromReader(reader);
                    entities.Add(entity);
                }
                reader.Close();
            }
            return entities;
        }

        public T GetById(int id)
        {
            string tableName = GetTableName();
            string idColumnName = "Id"; // Considerando que el nombre de la columna de ID es el mismo en todas las tablas.

            string query = $"SELECT * FROM {tableName} WHERE {idColumnName} = @Id";
            T entity = default;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entity = MapFromReader(reader);
                }

                reader.Close();
            }

            return entity;
        }

        public void Add(T entity)
        {
            string tableName = GetTableName();
            string insertQuery = GenerateInsertQuery(tableName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                MapParameters(command, entity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(T entity)
        {
            string tableName = GetTableName();
            string idColumnName = "Id"; // Considerando que el nombre de la columna de ID es el mismo en todas las tablas.
            string updateQuery = GenerateUpdateQuery(tableName, idColumnName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);
                MapParameters(command, entity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void MapParameters(SqlCommand command, T entity)
        {
            var entityType = typeof(T);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var parameter = new SqlParameter($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                command.Parameters.Add(parameter);
            }
        }

        public void Delete(int id)
        {
            string tableName = GetTableName();
            string idColumnName = "Id"; // Considerando que el nombre de la columna de ID es el mismo en todas las tablas.
            string deleteQuery = $"DELETE FROM {tableName} WHERE {idColumnName} = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para obtener el nombre de la tabla basado en el tipo
        private string GetTableName()
        {
            return typeof(T).Name + "s"; // Asumiendo que el nombre de la tabla en la base de datos es el nombre de la clase en plural.
        }
        private string GenerateInsertQuery(string tableName)
        {
            if (typeof(T) == typeof(Client))
            {
                return $"INSERT INTO {tableName} (NombreCompleto, FechaNacimiento) VALUES (@NombreCompleto, @FechaNacimiento)";
            }
            else if (typeof(T) == typeof(Console))
            {
                return $"INSERT INTO {tableName} (Nombre) VALUES (@Nombre)";
            }
            // Implementar para otras clases como Game, Rent, User...

            throw new NotSupportedException($"Entity type {typeof(T)} not supported.");
        }

        private string GenerateUpdateQuery(string tableName, string idColumnName)
        {
            if (typeof(T) == typeof(Client))
            {
                return $"UPDATE {tableName} SET NombreCompleto = @NombreCompleto, FechaNacimiento = @FechaNacimiento WHERE {idColumnName} = @Id";
            }
            else if (typeof(T) == typeof(Console))
            {
                return $"UPDATE {tableName} SET Nombre = @Nombre WHERE {idColumnName} = @Id";
            }
            // Implementar para otras clases como Game, Rent, User...

            throw new NotSupportedException($"Entity type {typeof(T)} not supported.");
        }

        internal T MapFromReader(SqlDataReader reader)
        {
            var entityType = typeof(T);
            var entity = Activator.CreateInstance(entityType);

            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                if (reader[property.Name] != DBNull.Value)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(entity, Convert.ToInt32(reader[property.Name]));
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, Convert.ToString(reader[property.Name]));
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(entity, Convert.ToDateTime(reader[property.Name]));
                    }
                    // Puedes agregar más tipos según sea necesario

                    // Lógica adicional para obtener entidades asociadas (si corresponde)
                    // Esto es solo un ejemplo para Game.ConsoleId y Game.Console, ajusta según tu modelo
                    else if (property.Name == "ConsoleId" && entityType == typeof(Game))
                    {
                        var consoleType = typeof(Console);
                        var console = Activator.CreateInstance(consoleType);

                        var consoleProperties = consoleType.GetProperties();

                        foreach (var consoleProperty in consoleProperties)
                        {
                            if (reader[consoleProperty.Name] != DBNull.Value)
                            {
                                if (consoleProperty.PropertyType == typeof(int))
                                {
                                    consoleProperty.SetValue(console, Convert.ToInt32(reader[consoleProperty.Name]));
                                }
                                else if (consoleProperty.PropertyType == typeof(string))
                                {
                                    consoleProperty.SetValue(console, Convert.ToString(reader[consoleProperty.Name]));
                                }
                                // Puedes agregar más tipos según sea necesario
                            }
                        }

                        property.SetValue(entity, console);
                    }
                }
            }

            return (T)entity;
        }

    }
}