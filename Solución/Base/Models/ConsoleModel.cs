using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class ConsoleModel
    {
        public ConsoleModel() { }
        public ConsoleModel(string name)
        {
            this.Nombre = name;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string ConsoleString
        {
            get { return $"#{Id}|{Nombre}"; }
        }
    }
}
