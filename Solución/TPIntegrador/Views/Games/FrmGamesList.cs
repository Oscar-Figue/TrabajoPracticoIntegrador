using Base.Base;
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
using TPIntegrador.Views.Games;

namespace TPIntegrador.Views
{
    public partial class FrmGamesList : FrmBase
    {
        private GamesService _gamesService;
        private UserModel _loggedUser;
        public FrmGamesList(UserModel loggedUser) : base(loggedUser)
        {
            _loggedUser = loggedUser;
            _gamesService = new GamesService();
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmGamesForm(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshList();
            };
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = ((GameModel)lstGames.SelectedItem).Id;
            _gamesService.Delete(id);
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = ((GameModel)lstGames.SelectedItem);
            var frm = new FrmGamesForm(_loggedUser, selected);
            frm.FormClosed += (s, ev) =>
            {
                RefreshList();
            };
            frm.ShowDialog();
        }

        private void FrmConsolesList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList(string filter = "")
        {
            var list = _gamesService.GetAll();
            if (!string.IsNullOrEmpty(filter))
                list = list.Where(x => x.GameString.ToLower().Contains(filter.ToLower())).ToList();
            lstGames.DataSource = null;
            lstGames.DisplayMember = "ConsoleString";
            lstGames.ValueMember = "Id";
            lstGames.DataSource = list;
        }

        private void lstGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGames.SelectedItem == null) return;
            var selected = (GameModel)lstGames.SelectedItem;
            btnEdit.Enabled = btnDelete.Enabled = selected != null;
        }

        private void txtSearcher_TextChanged(object sender, EventArgs e)
        {
            var filter = txtSearcher.Text;
            RefreshList(filter);
        }

        private void txtSearcher_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

        }
    }
}
