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
    public partial class frmDodajTipUredjaja : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmDodajTipUredjaja(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            var noviTip = new TipUredjajaUpsertRequest()
            {
                Naziv = txtNaziv.Text,
                Opis = txtOpis.Text
            };

            APIService TipService = new APIService("TipUredjaja", TokenService);

            var noviTipAdd = TipService.Post<TipUredjajaVM>(noviTip);

            if (noviTipAdd != null)
            {
                MessageBox.Show("Uspjesno dodan novi tip uredjaja");
                Close();
                return;
            }

            MessageBox.Show("Failed!");
        }
    }
}
