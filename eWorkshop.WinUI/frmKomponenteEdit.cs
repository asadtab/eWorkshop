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
    public partial class frmKomponenteEdit : Form
    {
        KomponenteUpsertRequest Request = new KomponenteUpsertRequest();
        public APIService KomponenteService { get; set; }
        public int Id { get; set; }

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmKomponenteEdit(KomponenteUpsertRequest request, int id, IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            Request = request;
            Id = id;

            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private void frmKomponenteEdit_Load(object sender, EventArgs e)
        {
            txtKoda.Text = Request.Tip;
            txtNaziv.Text = Request.Naziv;
            txtVrijednost.Text = Request.Vrijednost;
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            KomponenteService = new APIService("Komponente/" + Id, TokenService);

            Request.Tip = txtKoda.Text;
            Request.Naziv = txtNaziv.Text;
            Request.Vrijednost = txtVrijednost.Text;

            var editKomponenta = await KomponenteService.Put<KomponenteVM>(Request);

            if (editKomponenta != null)
            {
                MessageBox.Show("Uspješna izmjena");
                Close();
            }
        }

    }
}
