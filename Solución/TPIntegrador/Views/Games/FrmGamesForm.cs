using Base.Base;
using Base.Helpers;
using Base.Models;
using Repository.Entities;
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

namespace TPIntegrador.Views.Games
{
    public partial class FrmGamesForm : FrmBase
    {
        private GamesService _gamesService;
        private GameModel _editModel;
        public FrmGamesForm(UserModel loggedUser, GameModel model = null) : base(loggedUser)
        {
            _gamesService = new GamesService();
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

            GameModel game;
            if (_editModel != null)
            {
                _editModel.Nombre = name;
                _gamesService.Update(_editModel);
            }
            else
            {
             
                game = new GameModel();

                game.Nombre= name;

                _gamesService.Add(game);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGamesForm_Load(object sender, EventArgs e)
        {
            if (_editModel != null)
            {
                txtName.Text = _editModel.Nombre;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
