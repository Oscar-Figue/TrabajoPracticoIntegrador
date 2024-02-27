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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIntegrador.Views.Games
{
    public partial class FrmGamesForm : FrmBase
    {
        private GamesService _gamesService;
        private GameModel _editModel;
        public FrmGamesForm(UserModel loggedUser, GameModel game = null) : base(loggedUser)
        {
            _gamesService = new GamesService();
            _editModel = game;
            InitializeComponent();
        }
    }

}
