using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.UserControls;
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
    public partial class frmRacun : Form
    {
        public APIService ReparacijaService { get; set; } = new APIService("Reparacija");
        public APIService Komponente { get; set; } = new APIService("ServisIzvrsen");

        public frmRacun()
        {
            InitializeComponent();

            loadServise();
        }

        private async void loadServise()
        {
            ReparacijaSearchObject search = new ReparacijaSearchObject();
            search.KorisnikId = APIService.Korisnik.KorisniciId;


            var servisi = await ReparacijaService.Get<List<ServisVM>>(search);

            ServisIzvrsenSearchObject servisIzvrsenSearch = new ServisIzvrsenSearchObject();
            servisIzvrsenSearch.KorisnikId = APIService.Korisnik.KorisniciId;


            var komponente = await Komponente.Get<List<ServisIzvrsenVM>>(servisIzvrsenSearch);

            int x = 0;
            int y = 0;

            for (int i = 0; i < servisi.Count; i++)
            {
                string datum;

                if (servisi[i].Datum == null)
                {
                    datum = "Nepoznato";
                }
                else
                {
                    datum = servisi[i].Datum.Value.Day.ToString()
                    + "." +
                    servisi[i].Datum.Value.Month.ToString()
                    + "." +
                    servisi[i].Datum.Value.Year.ToString();
                }

                var control =
                    new HistorijaServisaUserControl(komponente
                    .Where(x => x.Servis.ServisId == servisi[i].ServisId && x.Servis.KorisnikId == APIService.Korisnik.KorisniciId).Distinct().ToList(), datum, servisi[i]);

                control.Location = new Point(x, y);

                flpServisi.Controls.Add(control);
                y += control.Height;
            }
        }

        private void frmRacun_Load(object sender, EventArgs e)
        {
            lblIme.Text = APIService.Korisnik.Ime;
            lblPrezime.Text = APIService.Korisnik.Prezime;
            lblKorisnickoIme.Text = APIService.Korisnik.KorisnickoIme;
            lblAktivan.Text = "Da";
            lblUloga.Text = APIService.Korisnik.NaziviUloga;
        }
    }
}
