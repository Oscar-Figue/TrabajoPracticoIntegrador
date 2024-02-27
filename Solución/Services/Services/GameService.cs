using Repository.Entities;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GamesService : GenericService<GameModel, Game>
    {
        public GamesService()
        {
        }
    }
}

