using Base.Models;
using Repository.Entities;
using Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ConsoleService : GenericService<ConsoleModel, Console>
    {
        public ConsoleService()
        {
        }
    }
}
