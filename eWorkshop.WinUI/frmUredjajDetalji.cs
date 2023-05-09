using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.UserControls;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmUredjajDetalji : Form
    {
        int EvidencijskiBroj;
        APIService UredjajService { get; set; }
        APIService UredjajAkcija { get; set; }
        APIService ReparacijaService { get; set; }
        APIService ServisIzvrsenService { get; set; }
        public StatusHelper Status { get; set; } = new StatusHelper();
        UredjajVM Uredjaj { get; set; } = new UredjajVM();
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmUredjajDetalji(int evBroj, IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            EvidencijskiBroj = evBroj;

            apiCalls();
        }

        private void apiCalls()
        {

            UredjajService = new APIService("Uredjaj", TokenService);
            ReparacijaService = new APIService("Reparacija", TokenService);
            ServisIzvrsenService = new APIService("ServisIzvrsen", TokenService);
        }
        private async void PreuzmiDetaljeUredjaja(int evBroj)
        {
            Uredjaj = await UredjajService.GetById<UredjajVM>(evBroj);

            lblEvBroj.Text = Uredjaj.UredjajId.ToString();
            lblKoda.Text = Uredjaj.Koda.ToString();
            lblSerBroj.Text = Uredjaj.SerijskiBroj.ToString();
            lblTip.Text = Uredjaj.Tip.Naziv.ToString();
            lblStatus.Text = Uredjaj.Status.ToString();
            lblLokacija.Text = Uredjaj.Lokacija.Naziv?.ToString();
            //Prikazivanje human readable statusa za uredjaje preko helper metode
            lblStatus.Text = Status.ProvjeraStatusa(Uredjaj.Status, Status.nizNaziv, Status.nizOpis);

            EnableDisableButtons();
        }

        private void frmUredjajDetalji_Load(object sender, EventArgs e)
        {
            PreuzmiDetaljeUredjaja(EvidencijskiBroj);
            UcitajHistorijuServisiranja();
        }

        private void EnableDisableButtons()
        {
            if (Uredjaj.isDeleted)
            {
                btnRecikliraj.Enabled = true;
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
                return;
            }
            else
            {
                btnRecikliraj.Enabled = false;
            }


            //status - idle
            if (Uredjaj.Status == Status.nizNaziv[0])
            {
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = true;
                btnDijelovi.Enabled = true;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = true;
                btnUredi.Enabled = true;

            }

            //status - active
            if (Uredjaj.Status == Status.nizNaziv[1])
            {
                btnDeaktiviraj.Enabled = true;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
            }

            //status - fix
            if (Uredjaj.Status == Status.nizNaziv[2])
            {
                btnDeaktiviraj.Enabled = true;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = true;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
            }

            //status - ready
            if (Uredjaj.Status == Status.nizNaziv[3])
            {
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = true;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
            }

            //status - out
            if (Uredjaj.Status == Status.nizNaziv[4])
            {
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = true;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
            }

            //status - parts
            if (Uredjaj.Status == Status.nizNaziv[5])
            {
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = true;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = true;
                btnUredi.Enabled = true;
            }

            //status - task
            if (Uredjaj.Status == Status.nizNaziv[6])
            {
                btnDeaktiviraj.Enabled = false;
                btnAktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnUredi.Enabled = false;
            }
        }

        private async void UcitajHistorijuServisiranja()
        {
            ReparacijaSearchObject reparacijaSearch = new ReparacijaSearchObject();
            ServisIzvrsenSearchObject servisIzvrsenSearch = new ServisIzvrsenSearchObject();

            reparacijaSearch.UredjajId = EvidencijskiBroj;

            var reparacija = await ReparacijaService.Get<List<ServisVM>>(reparacijaSearch);



            servisIzvrsenSearch.UredjajId = EvidencijskiBroj;


            var komponente = await ServisIzvrsenService.Get<List<ServisIzvrsenVM>>(servisIzvrsenSearch);


            int x = 0;
            int y = 0;

            /*za svaki servis se napravi novi objekat UserControl i salje mu se niz komponenti 
             koje odgovaraju odredjenom servisu*/
            for (int i = 0; i < reparacija.Count; i++)
            {
                string datum;

                if (reparacija[i].Datum == null)
                {
                    datum = "Nepoznato";
                }
                else
                {
                    datum = reparacija[i].Datum.Value.Day.ToString()
                    + "." +
                    reparacija[i].Datum.Value.Month.ToString()
                    + "." +
                    reparacija[i].Datum.Value.Year.ToString();
                }

                var control =
                    new HistorijaServisaUserControl(komponente
                    .Where(x => x.Servis.ServisId == reparacija[i].ServisId).Distinct().ToList(), datum, reparacija[i]);

                control.Location = new Point(x, y);

                flpHistorija.Controls.Add(control);
                y += control.Height;
            }
        }

        private void AktivirajReadyVratiClick()
        {
            UredjajAkcija = new APIService("Uredjaj/Aktiviraj-Ready-Vrati/" + EvidencijskiBroj, TokenService);

            UredjajAkcija.Put<UredjajVM>(null);

            PreuzmiDetaljeUredjaja(EvidencijskiBroj);

            MessageBox.Show("Uspješno izvršena akcija!");

            this.Close();
            frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnAktiviraj_Click(object sender, EventArgs e)
        {
            AktivirajReadyVratiClick();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            AktivirajReadyVratiClick();
        }

        private void btnVrati_Click(object sender, EventArgs e)
        {
            AktivirajReadyVratiClick();
        }

        private void btnServisiraj_Click(object sender, EventArgs e)
        {
            frmServis childForm = new frmServis(Uredjaj, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            frmPrijemUredjaja childForm = new frmPrijemUredjaja(Uredjaj, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private async void btnDijelovi_Click(object sender, EventArgs e)
        {
            UredjajAkcija = new APIService("Uredjaj/SpareParts/" + Uredjaj.UredjajId, TokenService);

            DialogResult result = frmPotvrda.Show("Da li želite ostaviti uređaj za rezervne dijelove?", "Potvrdi", "Poništi");

            if (result == DialogResult.Yes)
            {
                try
                {
                    await UredjajAkcija.Put<UredjajVM>(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
                frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
                FormControl.NovaFormaOpcije(childForm);
            }
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            DialogResult result = frmPotvrda.Show("Da li želite izbrisati uređaj?", "Potvrdi", "Poništi");

            if (result == DialogResult.Yes)
            {
                try
                {
                    await UredjajService.Delete(Uredjaj.UredjajId);

                    MessageBox.Show("Uspješno je izbrisan uređaj sa evidencijskim brojem: " + Uredjaj.UredjajId.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
                frmListaUredjaja childForm = ServiceProvider.GetRequiredService<frmListaUredjaja>();
                FormControl.NovaFormaOpcije(childForm);
            }
        }

        private async void btnDeaktiviraj_Click(object sender, EventArgs e)
        {
            UredjajAkcija = new APIService("Uredjaj/Deaktiviraj/" + Uredjaj.UredjajId, TokenService);

            DialogResult result = frmPotvrda.Show("Da li želite deaktivirati uređaj?", "Potvrdi", "Poništi");

            if (result == DialogResult.Yes)
            {
                try
                {
                    await UredjajAkcija.Put<UredjajVM>(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
                frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
                FormControl.NovaFormaOpcije(childForm);
            }
        }

        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            UredjajAkcija = new APIService("Uredjaj/Posalji", TokenService);

            UredjajLokacijaVM uredjajLokacija = new UredjajLokacijaVM();
            uredjajLokacija.UredjajId = Uredjaj.UredjajId;
            uredjajLokacija.LokacijaId = Uredjaj.Lokacija.LokacijaId;


            DialogResult result = frmPotvrda.Show("Da li želite poslati uređaj?", "Potvrdi", "Poništi");

            if (result == DialogResult.Yes)
            {
                try
                {
                    await UredjajAkcija.Put<UredjajVM>(uredjajLokacija);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
                frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
                FormControl.NovaFormaOpcije(childForm);
            }
        }

        private async void btnRecikliraj_Click(object sender, EventArgs e)
        {
            DialogResult result = frmPotvrda.Show("Da li želite poslati uređaj?", "Potvrdi", "Poništi");

            UredjajAkcija = new APIService("Uredjaj/" + Uredjaj.UredjajId, TokenService);

            UredjajUpsertRequest request = new UredjajUpsertRequest();
            request.TipId = Uredjaj.Tip.TipUredjajaId;
            request.SerijskiBroj = Uredjaj.SerijskiBroj;
            request.Koda = Uredjaj.Koda;
            request.LokacijaId = Uredjaj.Lokacija.LokacijaId;
            request.DatumIzvedbe = Uredjaj.DatumIzvedbe;
            request.isDeleted = false;

            if (result == DialogResult.Yes)
            {
                try
                {
                    await UredjajAkcija.Put<UredjajVM>(request);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
                frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
                FormControl.NovaFormaOpcije(childForm);
            }
        }
    }
}
