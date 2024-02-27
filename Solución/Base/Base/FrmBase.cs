using Repository.Entities;
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
