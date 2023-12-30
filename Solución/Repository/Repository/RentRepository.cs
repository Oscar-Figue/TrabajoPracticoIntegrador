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
    public class RentRepository : GenericRepository<Rent>
    {
        public RentRepository() { }
        public void EndRent(RentModel model)
        {
            string deleteQuery = $"UPDATE Rents SET FechaDevolucion = GetDate() WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Id", model.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
