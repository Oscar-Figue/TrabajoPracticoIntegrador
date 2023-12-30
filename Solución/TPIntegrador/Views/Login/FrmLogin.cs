using Base.Helpers;
using Repository.Entities;
using Services.Base;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPIntegrador.Views.Home;

namespace TPIntegrador
{
    public partial class FrmLogin : Form
    {
        private UserService _service;
        private FrmHome _frmHome;
        public FrmLogin()
        {
            _service = new UserService();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtUsername.Text;
                var pass = txtPass.Text;

                if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pass))
                {
                    MessageHelper.ShowError("Ocurrió un error al iniciar sesión");
                    return;
                }
                var result = _service.Login(username, pass);
                if (result != null)
                {
                    this.Hide();
                    _frmHome = new FrmHome(result);
                    _frmHome.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageHelper.ShowError("Ocurrió un error al iniciar sesión");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

        }
    }
}
