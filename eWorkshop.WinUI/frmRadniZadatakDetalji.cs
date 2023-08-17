using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
using eWorkshop.WinUI.Report;
using eWorkshop.WinUI.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
    public partial class frmRadniZadatakDetalji : Form
    {
        public List<RadniZadatakUredjajVM> RadniZadatakUredjaj { get; }
        public APIService RadniZadatakUredjajService { get; set; }
        public APIService UredjajService { get; set; }
        public APIService RadniZadatakService { get; set; }
        public RadniZadatakUredjajVM RadniZadatak { get; }
        public List<RadniZadatakUredjajVM> RadniZadatakAll { get; }
        public StatusHelper StatusHelp { get; set; } = new StatusHelper();
        public double Ukupno { get; set; }
        public double Progres { get; set; }
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmRadniZadatakDetalji(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            RadniZadatakUredjajService = new APIService("RadniZadatakUredjaj", TokenService);
        }

        public frmRadniZadatakDetalji(List<RadniZadatakUredjajVM> radniZadaci, IServiceProvider serviceProvider, ITokenService tokenService) : this(serviceProvider, tokenService)
        {
            RadniZadatak = radniZadaci[0];
            RadniZadatakAll = radniZadaci;

            FormControl.OpcijeTabele(dgvUredjaji);
        }

        private void frmRadniZadatakDetalji_Load(object sender, EventArgs e)
        {
            Postotak();
            PopulateInfo();
            PopulateTable();
            EnableDisableButtons();
        }

        private void Postotak()
        {
            double brojacUkupno = 0;
            double brojacProgres = 0;

            for (int i = 0; i < RadniZadatakAll.Count; i++)
            {
                brojacUkupno++;
                if (RadniZadatakAll[i].Uredjaj.Status == "fix"
                    || RadniZadatakAll[i].Uredjaj.Status == "ready"
                    || RadniZadatakAll[i].Uredjaj.Status == "out")
                {
                    brojacProgres++;
                }//end if
            }

            Ukupno = brojacUkupno;
            double procenat = brojacProgres / brojacUkupno;
            int rezultat = (int)(procenat * 100);
            Progres = rezultat;
        }

        private void EnableDisableButtons()
        {
            if (RadniZadatak.RadniZadatak.StateMachine == "done")
            {
                btnZavrsi.Enabled = false;
            }

            if (RadniZadatak.RadniZadatak.StateMachine == "active")
            {
                btnZavrsi.Enabled = true;
            }
        }

        private async void PopulateTable()
        {
            RadniZadatakUredjajSearchObject search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = RadniZadatak.RadniZadatak.RadniZadatakId;

            var radniZadatak = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajBasicVM>>(search);
            var uredjaji = radniZadatak.Select(x => x.Uredjaj).ToList();

            for (int i = 0; i < uredjaji.Count; i++)
            {
                uredjaji[i].Status = StatusHelp.ProvjeraStatusa(uredjaji[i].Status, StatusHelp.nizNaziv, StatusHelp.nizOpis);
            }

            dgvUredjaji.DataSource = uredjaji;
        }

        private void PopulateInfo()
        {
            var datum = RadniZadatak.RadniZadatak.Datum.Day.ToString()
                + "." +
                RadniZadatak.RadniZadatak.Datum.Month.ToString()
                + "." +
                RadniZadatak.RadniZadatak.Datum.Year.ToString();

            lblNaziv.Text = RadniZadatak.RadniZadatak.Naziv;
            lblDatum.Text = datum;
            lblLokacija.Text = RadniZadatak.Uredjaj.Lokacija.Naziv;
            lblUkupno.Text = Ukupno.ToString();
            lblStatus.Text = StatusHelp.ProvjeraStatusa(RadniZadatak.RadniZadatak.StateMachine, StatusHelp.nizNazivZadatak, StatusHelp.nizOpisZadatak);

            pbProgres.Value = (int)Progres;
            lblProgres.Text = Progres.ToString() + "%";
        }


        private void dgvUredjaji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int evBroj = FormControl.SelektujRedIVratiId(dgvUredjaji, e);

            frmUredjajDetalji childForm = new frmUredjajDetalji(evBroj, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodajUredjaj_Click(object sender, EventArgs e)
        {
            var childForm = ServiceProvider.GetRequiredService<frmRadniZadaci>();

            //frmRadniZadaci childForm = new frmRadniZadaci();
            FormControl.NovaFormaOpcije(childForm);
        }

        private async void btnZavrsi_Click(object sender, EventArgs e)
        {
            DialogResult result = frmPotvrda.Show("Da li želite završiti ovaj radni zadatak?", "Potvrdi", "Poništi");

            if (result == DialogResult.Yes)
            {
                RadniZadatakService = new APIService("RadniZadatak/Zavrsi/" + RadniZadatak.RadniZadatak.RadniZadatakId, TokenService);

                UredjajSearchObject search = new UredjajSearchObject();

                try
                {
                    await RadniZadatakService.Put<RadniZadatakVM>(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                    return;
                }

                MessageBox.Show("Radni zadatak je završen. Uređaji koji nisu servisirani ponovo su aktivni.");
                this.Close();
            }
        }

        private void frmRadniZadatakDetalji_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = ServiceProvider.GetRequiredService<frmMain>();

            //frmMain childForm = new frmMain();
            FormControl.NovaFormaOpcije(form);
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            if (RadniZadatakAll.Count == 0)
            {
                MessageBox.Show("Uređaji nisu spremni za izvještaj!");
                return;
            }

            var radniZadatakUredjaj = new List<RadniZadatakUredjajVM>();

            foreach (var item in RadniZadatakAll)
            {
                if (item.Uredjaj.Status == "ready" || item.Uredjaj.Status == "out")
                {
                    radniZadatakUredjaj.Add(item);
                }
            }

            if (radniZadatakUredjaj.Count == 0)
            {
                MessageBox.Show("Uređaji nisu spremni za izvještaj!");
                return;
            }

            frmRadniZadatakIzvjestaj childForm = new frmRadniZadatakIzvjestaj(radniZadatakUredjaj, ServiceProvider, TokenService);
            childForm.Show();
        }
    }
}
