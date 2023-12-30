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

namespace TPIntegrador
{
    public partial class FrmLogin : Form
    {
        private GenericService<UserModel, User> _service;

        public FrmLogin()
        {
            _service = new GenericService<UserModel, User>();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var list = _service.GetAll();
        }
    }
}
