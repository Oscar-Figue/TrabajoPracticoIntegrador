using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public bool IsAdmin { get; set; }
    }
}
