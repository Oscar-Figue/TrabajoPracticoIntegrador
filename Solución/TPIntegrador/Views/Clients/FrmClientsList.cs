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

namespace TPIntegrador.Views.Clients
{
    public partial class FrmClientsList: FrmBase
    {


        private ClientService _clientService;
        private UserModel _loggedUser;
        public FrmClientsList(UserModel loggedUser) : base(loggedUser)
        {
            _loggedUser = loggedUser;
            _clientService = new ClientService();
            InitializeComponent();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {                      
                this.Close();          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmClientsForm(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshList();
            };
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void RefreshList(string filter = "")
        {
            var list = _clientService.GetAll();
            if (!string.IsNullOrEmpty(filter))
                list = list.Where(x => x.ClientString.ToLower().Contains(filter.ToLower())).ToList();
            lstClients.DataSource = null;
            lstClients.DisplayMember = "ClientString";
            lstClients.ValueMember = "Id";
            lstClients.DataSource = list;
        }


    }


}
