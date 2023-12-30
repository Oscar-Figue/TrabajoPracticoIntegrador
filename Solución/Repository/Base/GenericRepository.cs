using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Base.Helpers;
using Console = Repository.Entities.Console;
using System.Linq;
using System.Reflection;

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

            // Aquí podrías tener lógica para obtener información sobre las asociaciones de la entidad
            // Por ejemplo, supongamos que hay una lista de propiedades asociadas en la clase de entidad
            var associatedProperties = typeof(T).GetProperties().Where(prop => !IsSimpleType(prop.PropertyType));

            // Si hay propiedades asociadas, modifica la consulta para incluir las tablas asociadas mediante joins
            if (associatedProperties.Any())
            {
                // Construir los joins para las tablas asociadas en la consulta SQL
                foreach (var prop in associatedProperties)
                {
                    // Asumiendo que la propiedad tiene un atributo que indica el nombre de la tabla asociada
                    // Puedes personalizar esta lógica según tu implementación
                    string associatedTableName = GetAssociatedTableName(prop); // Obtener el nombre de la tabla asociada
                    query += $" LEFT JOIN {associatedTableName} ON {tableName}.{prop.Name}Id = {associatedTableName}.Id";
                }
            }

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
        private string GetAssociatedTableName(PropertyInfo prop)
        {
            return prop.Name + "s"; // Asumiendo que el nombre de la tabla en la base de datos es el nombre de la clase en plural.
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
                if (IsSimpleType(property.PropertyType)) // Si es un tipo simple
                {
                    if (reader[property.Name] != DBNull.Value)
                    {
                        if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) // Si es un tipo DateTime
                        {
                            property.SetValue(entity, reader.GetDateTime(reader.GetOrdinal(property.Name)));
                        }
                        else // Otros tipos simples
                        {
                            property.SetValue(entity, Convert.ChangeType(reader[property.Name], property.PropertyType));
                        }
                    }
                }
                else // Si es una entidad asociada
                {
                    var associatedEntity = GetAssociatedEntity(property.PropertyType, reader);
                    property.SetValue(entity, associatedEntity);
                }
            }
            return (T)entity;
        }
        private object GetAssociatedEntity(Type entityType, SqlDataReader reader)
        {
            var entity = Activator.CreateInstance(entityType);

            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                if (IsSimpleType(property.PropertyType)) // Si es un tipo simple
                {
                    if (reader[property.Name] != DBNull.Value)
                    {
                        if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) // Si es un tipo DateTime
                        {
                            property.SetValue(entity, reader.GetDateTime(reader.GetOrdinal(property.Name)));
                        }
                        else // Otros tipos simples
                        {
                            property.SetValue(entity, Convert.ChangeType(reader[property.Name], property.PropertyType));
                        }
                    }
                }
                // Puedes agregar más lógica para otros tipos complejos si es necesario
            }

            return entity;
        }

        private bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || new[] { typeof(string), typeof(decimal), typeof(DateTime), typeof(Guid) }.Contains(type) || type.IsValueType;
        }

        private object MapAssociatedEntity(Type entityType, SqlDataReader reader)
        {
            var associatedEntity = Activator.CreateInstance(entityType);

            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                if (reader[property.Name] != DBNull.Value)
                {
                    if (IsSimpleType(property.PropertyType)) // Si es un tipo simple
                    {
                        if (property.PropertyType == typeof(DateTime)) // Si es un tipo DateTime
                        {
                            property.SetValue(associatedEntity, reader.GetDateTime(reader.GetOrdinal(property.Name)));
                        }
                        else // Otros tipos simples
                        {
                            property.SetValue(associatedEntity, Convert.ChangeType(reader[property.Name], property.PropertyType));
                        }
                    }
                }
            }

            return associatedEntity;
        }

    }
}