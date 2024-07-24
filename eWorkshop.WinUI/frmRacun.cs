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
        public APIService ReparacijaService { get; set; } 
        public APIService Komponente { get; set; } 
        public APIService KorisniciService { get; set; } 

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;
        public KorisniciVM Korisnik { get; set; } = new KorisniciVM();
        public int KorisnikID { get; set; }

        public frmRacun(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            ReparacijaService = new APIService("Reparacija", TokenService);
            Komponente = new APIService("ServisIzvrsen", TokenService);
            KorisniciService = new APIService("Korisnici", TokenService);
        }

        public frmRacun(int korisnikID, IServiceProvider serviceProvider, ITokenService tokenService) : this(serviceProvider, tokenService)
        {
            KorisnikID = korisnikID;
        }

        private async void loadServise()
        {
            ReparacijaSearchObject search = new ReparacijaSearchObject();
            search.KorisnikId = Korisnik.KorisniciId.ToString();


            var servisi = await ReparacijaService.Get<List<ServisVM>>(search);

            ServisIzvrsenSearchObject servisIzvrsenSearch = new ServisIzvrsenSearchObject();
            servisIzvrsenSearch.KorisnikId = Korisnik.KorisniciId.ToString();


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
                    .Where(x => x.Servis.ServisId == servisi[i].ServisId && x.Servis.KorisnikId == Korisnik.KorisniciId).Distinct().ToList(), datum, servisi[i]);

                control.Location = new Point(x, y);

                flpServisi.Controls.Add(control);
                y += control.Height;
            }
        }

        private async void frmRacun_Load(object sender, EventArgs e)
        {
            KorisniciSearchObject search = new KorisniciSearchObject();

            var result = await KorisniciService.Get<List<KorisniciVM>>(search);

            Korisnik = result.FirstOrDefault();

            lblIme.Text = Korisnik.Ime;
            lblPrezime.Text = Korisnik.Prezime;
            lblKorisnickoIme.Text = Korisnik.KorisnickoIme;
            lblAktivan.Text = "Da";
            lblUloga.Text = Korisnik.NaziviUloga;

            loadServise();
        }
    }
}
