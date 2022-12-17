using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI
{
    public partial class frmKorisnici : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");

        public frmKorisnici()
        {
            InitializeComponent();
            dgvLista.AutoGenerateColumns = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var unos = txtUserName.Text;

            var searchobject = new KorisniciSearchObject();

            searchobject.KorisnickoIme = unos;
            searchobject.ImePrezime = txtImePrezime.Text;
            searchobject.IncludeUloge = true;

            var lista = await KorisniciService.Get<List<KorisniciVM>>(searchobject);

            dgvLista.DataSource = lista;

        }
    }
}
