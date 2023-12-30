using Base.Base;
using Repository.Entities;

namespace TPIntegrador.Views.Home
{
    public partial class FrmHome : FrmBase
    {
        public FrmHome(UserModel loggedUser) : base(loggedUser)
        {
            InitializeComponent();
        }
    }
}
