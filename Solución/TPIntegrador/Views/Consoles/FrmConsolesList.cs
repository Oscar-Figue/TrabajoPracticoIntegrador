using Base.Base;
using Base.Models;
using Repository.Entities;
using Services.Services;
using System;
using System.Data;
using System.Linq;
using TPIntegrador.Views.Rents;

namespace TPIntegrador.Views
{
    public partial class FrmConsolesList : FrmBase
    {
        private ConsoleService _consoleService;
        private UserModel _loggedUser;
        public FrmConsolesList(UserModel loggedUser) : base(loggedUser)
        {
            _loggedUser = loggedUser;
            _consoleService = new ConsoleService();
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new FrmConsolesForm(_loggedUser);
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
            var id = ((ConsoleModel)lstConsoles.SelectedItem).Id;
            _consoleService.Delete(id);
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = ((ConsoleModel)lstConsoles.SelectedItem);
            var frm = new FrmConsolesForm(_loggedUser, selected);
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
            var list = _consoleService.GetAll();
            if (!string.IsNullOrEmpty(filter))
                list = list.Where(x => x.ConsoleString.ToLower().Contains(filter.ToLower())).ToList();
            lstConsoles.DataSource = null;
            lstConsoles.DisplayMember = "ConsoleString";
            lstConsoles.ValueMember = "Id";
            lstConsoles.DataSource = list;
        }

        private void lstConsoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConsoles.SelectedItem == null) return;
            var selected = (ConsoleModel)lstConsoles.SelectedItem;
            btnEdit.Enabled = btnDelete.Enabled = selected != null;
        }

        private void txtSearcher_TextChanged(object sender, EventArgs e)
        {
            var filter = txtSearcher.Text;
            RefreshList(filter);
        }
    }
}
