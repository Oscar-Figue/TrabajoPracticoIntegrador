using Base.Base;
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

namespace TPIntegrador.Views.Clients
{
    public partial class FrmClientsForm : FrmBase
    {
        private ClientService _clientService;
        private UserModel _loggedUser;
        public FrmClientsForm(UserModel loggedUser) : base(loggedUser)
        {
            _loggedUser = loggedUser;
            _clientService = new ClientService();
            InitializeComponent();
        }


    }



}




