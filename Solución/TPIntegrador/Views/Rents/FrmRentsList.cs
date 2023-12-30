using Base.Base;
using Repository.Entities;

namespace TPIntegrador.Views.Rents
{
    public partial class FrmRentsList : FrmBase
    {
        public FrmRentsList(UserModel loggedUser) : base(loggedUser)
        {
            InitializeComponent();
        }
    }
}
