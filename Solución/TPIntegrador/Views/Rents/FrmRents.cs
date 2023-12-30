using Base.Base;
using Repository.Entities;
using Services.Base;
using Services.Services;
using System;
using System.Collections.Generic;

namespace TPIntegrador.Views.Rents
{
    public partial class FrmRents : FrmBase
    {
        private GenericService<GameModel, Game> _gameService;
        private GenericService<ClientModel, Client> _clientService;
        private RentService _rentService;
        private UserModel _loggedUser;
        private RentModel _model;
        public FrmRents(UserModel loggedUser, RentModel model = null) : base(loggedUser)
        {
            _loggedUser = loggedUser;
            _model = model;
            _gameService = new GenericService<GameModel, Game>();
            _clientService = new GenericService<ClientModel, Client>();
            _rentService = new RentService();
            InitializeComponent();
            LoadCbos();
        }

        private void LoadCbos()
        {
            var gameList = _gameService.GetAll();
            var clientList = _clientService.GetAll();
            cboClients.DataSource = null;
            cboClients.DisplayMember = "ClientString";
            cboClients.ValueMember = "Id";
            cboClients.DataSource = clientList;
            cboGames.DataSource = null;
            cboGames.DisplayMember = "GameString";
            cboGames.ValueMember = "Id";
            cboGames.DataSource = gameList;
            if (_model != null)
                cboClients.Enabled = cboGames.Enabled = false;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            var selectedGame = ((GameModel)cboGames.SelectedItem).Id;
            var client = ((ClientModel)cboClients.SelectedItem).Id;
            if (_model != null)
            {
                _rentService.EndRent(_model);
            }
            else
            {
                var model = new RentModel(_loggedUser.Id, selectedGame, client);
                _rentService.Add(model);

            }
            this.Close();
        }
    }
}
