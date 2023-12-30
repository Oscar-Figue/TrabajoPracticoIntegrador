using Base.Base;
using Repository.Entities;
using Services.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIntegrador.Views.Users
{
    public partial class FrmUsersList : FrmBase
    {
        private GenericService<UserModel, User> _service;

        public FrmUsersList(UserModel loggedUser) : base(loggedUser)
        {
            _service = new GenericService<UserModel, User>();
            InitializeComponent();
        }

        private void FrmUsersList_Load(object sender, EventArgs e)
        {
            var list = _service.GetAll();

        }
    }
}
