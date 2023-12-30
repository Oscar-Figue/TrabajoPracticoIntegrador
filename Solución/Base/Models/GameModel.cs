using Base.Models;

namespace Repository.Entities
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ConsoleId { get; set; }
        public ConsoleModel Console { get; set; }

        public string GameString
        {
            get { return $"#{Id}| [{Console.Nombre}] - {Nombre}"; }
        }
    }
}
