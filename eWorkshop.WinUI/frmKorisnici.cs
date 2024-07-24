using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
using Microsoft.Extensions.DependencyInjection;
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
        public FormControl FormControl { get; set; } = new FormControl();
        public APIService KorisniciService { get; set; }

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmKorisnici(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            FormControl.OpcijeTabele(dgvLista);

            KorisniciService = new APIService("AspNetUser", TokenService);
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

            var lista = await KorisniciService.Get<List<AspNetUserVM>>(searchobject);

            dgvLista.DataSource = lista;

        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            FormControl.OpcijeTabele(dgvLista);

            var lista = await KorisniciService.Get<List<AspNetUserVM>>();

            dgvLista.DataSource = lista;
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int korisnikID = FormControl.SelektujRedIVratiId(dgvLista, e);

            frmRacun form = new frmRacun(korisnikID, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(form);
        }

        private void btnDodajNovogKorisnika_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika childForm = ServiceProvider.GetRequiredService<frmDodajKorisnika>();
            childForm.ShowDialog();
            //FormControl.NovaFormaOpcije(childForm);
        }

        private void dgvLista_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
