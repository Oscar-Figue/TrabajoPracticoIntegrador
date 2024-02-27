using Repository.Entities;
using System.Windows.Forms;

namespace Base.Base
{
    public class FrmBase : Form
    {
        UserModel UsuarioLogueado;
        public FrmBase(UserModel usuarioLogueado)
        {
            UsuarioLogueado = usuarioLogueado;
        }
        public FrmBase() { }
    }
}
