using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ConsoleId { get; set; }
        public ConsoleModel Console { get; set; }
    }
}
