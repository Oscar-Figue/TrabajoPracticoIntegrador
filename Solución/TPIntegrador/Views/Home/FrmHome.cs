using Base.Base;
using Repository.Entities;
using Services.Base;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TPIntegrador.Views.Clients;
using TPIntegrador.Views.Rents;
using TPIntegrador.Views.Users;

namespace TPIntegrador.Views.Home
{
    public partial class FrmHome : FrmBase
    {
        private GenericService<RentModel, Rent> _rentService;
        private UserModel _loggedUser;
        public FrmHome(UserModel loggedUser) : base(loggedUser)
        {
            _rentService = new GenericService<RentModel, Rent>();
            _loggedUser = loggedUser;
            InitializeComponent();
            lblLoggedUser.Text = $"Usuario loguead: {loggedUser.Username}";
            RefreshHome();
        }

        private void FrmHome_Load(object sender, System.EventArgs e)
        {
            RefreshHome();
        }

        private void RefreshHome(string filter = "")
        {
            RefreshAdministrationView();
            var list = _rentService.GetAll();
            if (!string.IsNullOrEmpty(filter))
                list = list.Where(x => x.RentString.ToLower().Contains(filter.ToLower())).ToList();
            lstRents.DataSource = null;
            lstRents.DisplayMember = "RentString";
            lstRents.ValueMember = "Id";
            lstRents.DataSource = list;
            RefreshEndRentBtnEnabled();
            lstRents.Refresh();
        }

        private void btnRents_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmRents(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }

        private void btnEndRent_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmRents(_loggedUser, ((RentModel)lstRents.SelectedItem));
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }

        private void btnClients_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmClientsList(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }

        private void btnGames_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmGamesList(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }

        private void btnConsoles_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmConsolesList(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, System.EventArgs e)
        {
            var frm = new FrmUsersList(_loggedUser);
            frm.FormClosed += (s, ev) =>
            {
                RefreshHome();
            };
            frm.ShowDialog();
        }
        private void txtSearcher_TextChanged(object sender, System.EventArgs e)
        {
            var filter = txtSearcher.Text;
            RefreshHome(filter);
        }

        private void lstRents_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEndRentBtnEnabled();
        }

        private void RefreshEndRentBtnEnabled()
        {
            btnEndRent.Enabled = lstRents.SelectedItem == null || !((RentModel)lstRents.SelectedItem).FechaDevolucion.HasValue;
        }
        private void RefreshAdministrationView()
        {
            btnConsoles.Visible = btnGames.Visible = btnUsers.Visible = _loggedUser.IsAdmin;
        }

        private void lstRents_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstRents.Items.Count)
                return;

            var rent = lstRents.Items[e.Index] as RentModel;
            if (rent == null)
                return;

            e.DrawBackground();

            Color textColor = SystemColors.ControlText;

            // Verifica si hay una fecha de devolución y si es anterior a la fecha actual
            if (rent.FechaDevolucion.HasValue && rent.FechaDevolucion.Value < DateTime.Now)
            {
                textColor = Color.Red; // Cambia el color del texto a rojo si la fecha de devolución es anterior a la fecha actual
            }

            using (SolidBrush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(lstRents.GetItemText(lstRents.Items[e.Index]), e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }
    }
}
