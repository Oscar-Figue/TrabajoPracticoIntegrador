using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base.Base
{
    public class FrmBase : Form
    {
        UserModel UsuarioLogueado;

        public GameModel LoggedUser { get; }

        public FrmBase(UserModel usuarioLogueado)
        {
            UsuarioLogueado = usuarioLogueado;
        }
        public FrmBase() { }

        public FrmBase(GameModel loggedUser)
        {
            LoggedUser = loggedUser;
        }
    }
}
