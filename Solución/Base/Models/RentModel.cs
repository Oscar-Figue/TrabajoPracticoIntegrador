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
        public UserModel User { set; get; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public RentModel() { }
        public RentModel(int userId, int gameId, int clientId)
        {
            ClientId = clientId;
            GameId = gameId;
            UserId = userId;
            Fecha = DateTime.Now;
        }
        public string RentString
        {
            get { return $"#{Id}-{Fecha.ToString("dd-MM-yyyy")}-Cliente#{Client.Id} {Client.NombreCompleto} - Juego: {Game.Nombre} - Recepcionista:{User.Username}"; }
        }
    }

}
