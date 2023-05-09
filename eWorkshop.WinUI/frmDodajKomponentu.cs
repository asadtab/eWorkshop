using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI
{
    public partial class frmDodajKomponentu : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmDodajKomponentu(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private async void btnRegistruj_Click(object sender, EventArgs e)
        {
            APIService KomponenteService = new APIService("Komponente", TokenService);
            /*
             Naziv      -> Oznaka
             Opis       -> Naziv
             Tip        -> Koda
             Vrijednost -> Vrijednost
             */

            KomponenteUpsertRequest request = new KomponenteUpsertRequest();

            request.Vrijednost = txtVrijednost.Text;
            request.Naziv = txtOznaka.Text;
            request.Opis = txtNaziv.Text;
            request.Tip = txtKoda.Text;

            var result = await KomponenteService.Post<KomponenteVM>(request);

            if (result != null)
            {
                MessageBox.Show("Dodana je komponenta sa nazivom: " + result.Opis);
                OcistiTextBox();
            }
        }

        private void OcistiTextBox()
        {
            txtKoda.Clear();
            txtNaziv.Clear();
            txtOznaka.Clear();
            txtVrijednost.Clear();
        }
    }
}
