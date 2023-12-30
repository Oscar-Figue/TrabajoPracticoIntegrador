using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { set; get; }
        public int GameId { get; set; }
        public Game Game { set; get; }
        public int UserId { get; set; }
        public User User { set; get; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }

}
