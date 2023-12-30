using Repository.Base;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }

        public User Login(string username, string password)
        {
            User entity = null;
            var pass = SecurityHelper.EncryptToMD5(password);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM Users WHERE Username = @username AND Pass = @pass";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@pass", pass);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    entity = MapFromReader(reader);
                }

                reader.Close();
                return entity;
            }
        }
    }
}
