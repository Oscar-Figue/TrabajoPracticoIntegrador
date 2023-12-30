using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class RentModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { set; get; }
        public int GameId { get; set; }
        public GameModel Game { set; get; }
        public int UserId { get; set; }
        public UserModel Usuario { set; get; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }

}
