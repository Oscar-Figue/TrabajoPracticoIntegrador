using Base.Base;
using Base.Helpers;
using Base.Models;
using Repository.Entities;
using Services.Services;
using System;
using System.Data;
using System.Linq;

namespace TPIntegrador.Views
{
    public partial class FrmConsolesForm : FrmBase
    {
        private ConsoleService _consoleService;
        private ConsoleModel _editModel;
        public FrmConsolesForm(UserModel loggedUser, ConsoleModel model = null) : base(loggedUser)
        {
            _consoleService = new ConsoleService();
            _editModel = model;
            InitializeComponent();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageHelper.ShowError("El campo es requerido");
                return;
            }
            ConsoleModel model;
            if (_editModel != null)
            {
                _editModel.Nombre = name;
                _consoleService.Update(_editModel);
            }
            else
            {
                model = new ConsoleModel(name);
                _consoleService.Add(model);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsolesForm_Load(object sender, EventArgs e)
        {
            if (_editModel != null)
            {
                txtName.Text = _editModel.Nombre;
            }
        }
    }
}
