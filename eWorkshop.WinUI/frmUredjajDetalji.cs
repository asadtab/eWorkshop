using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
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
    public partial class frmUredjajDetalji : Form
    {
        int EvidencijskiBroj;
        APIService UredjajService { get; set; } = new APIService("Uredjaj");
        APIService UredjajAkcija{ get; set; }
        APIService ReparacijaService { get; set; } = new APIService("Reparacija");
        APIService ServisIzvrsenService { get; set; } = new APIService("ServisIzvrsen");
        public StatusHelper Status { get; set; } = new StatusHelper();
        UredjajVM Uredjaj { get; set; } = new UredjajVM();
        public FormControl FormControl { get; set; } = new FormControl();


        public frmUredjajDetalji(int evBroj)
        {
            InitializeComponent();
            EvidencijskiBroj = evBroj;
        }

        private async void PreuzmiDetaljeUredjaja(int evBroj)
        {
            Uredjaj = await UredjajService.GetById<UredjajVM>(evBroj);

            lblEvBroj.Text = Uredjaj.UredjajId.ToString();
            lblKoda.Text = Uredjaj.Koda.ToString();
            lblSerBroj.Text = Uredjaj.SerijskiBroj.ToString();
            lblTip.Text = Uredjaj.Tip.Naziv.ToString();
            lblStatus.Text = Uredjaj.Status.ToString();
            lblLokacija.Text = Uredjaj.Lokacija.Naziv.ToString();
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
            //status - idle
            if(Uredjaj.Status == Status.nizNaziv[0])
            {
                btnAktiviraj.Enabled = true;
                //btnDeaktiviraj.Enabled = false;
                btnDijelovi.Enabled = true;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
            }

            //status - active
            if (Uredjaj.Status == Status.nizNaziv[1])
            {
                btnAktiviraj.Enabled = false;
                //btnDeaktiviraj.Enabled = true;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
            }

            //status - fix
            if (Uredjaj.Status == Status.nizNaziv[2])
            {
                btnAktiviraj.Enabled = false;
                //btnDeaktiviraj.Enabled = true;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = true;
                btnVrati.Enabled = false;
            }

            //status - ready
            if (Uredjaj.Status == Status.nizNaziv[3])
            {
                btnAktiviraj.Enabled = false;
                //btnDeaktiviraj.Enabled = true;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = true;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
            }

            //status - out
            if (Uredjaj.Status == Status.nizNaziv[4])
            {
                btnAktiviraj.Enabled = false;
                //btnDeaktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = true;
            }

            //status - parts
            if (Uredjaj.Status == Status.nizNaziv[5])
            {
                btnAktiviraj.Enabled = true;
               //btnDeaktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = false;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
            }

            //status - task
            if (Uredjaj.Status == Status.nizNaziv[6])
            {
                btnAktiviraj.Enabled = false;
                //btnDeaktiviraj.Enabled = false;
                btnDijelovi.Enabled = false;
                btnPosalji.Enabled = false;
                btnServisiraj.Enabled = true;
                btnSpremi.Enabled = false;
                btnVrati.Enabled = false;
            }
        }

        private async void UcitajHistorijuServisiranja()
        {
            ReparacijaSearchObject reparacijaVM = new ReparacijaSearchObject();
            ServisIzvrsenSearchObject servisIzvrsenVM = new ServisIzvrsenSearchObject();

            reparacijaVM.UredjajId = EvidencijskiBroj;

            var reparacija = await ReparacijaService.Get<List<ServisVM>>(reparacijaVM);

           
            var komponente = await ServisIzvrsenService.Get<List<ServisIzvrsenVM>>(servisIzvrsenVM);


            int x = 0;
            int y = 0;

            /*za svaki servis se napravi novi objekat UserControl i salje mu se niz komponenti 
             koje odgovaraju odredjenom servisu*/
            for (int i = 0; i < reparacija.Count; i++)
            {
                var datum = reparacija[i].Datum.Value.Day.ToString()
                    + "." +
                    reparacija[i].Datum.Value.Month.ToString()
                    + "." +
                    reparacija[i].Datum.Value.Year.ToString();

                var control = 
                    new HistorijaServisaUserControl(komponente
                    .Where(x => x.Servis.ServisId == reparacija[i].ServisId).ToList(), datum);

                control.Location = new Point(x, y);

                flpHistorija.Controls.Add(control);
                y += control.Height;
            }
        }

        private void AktivirajReadyVratiClick() 
        {
            UredjajAkcija = new APIService("Uredjaj/" + EvidencijskiBroj + "/Aktiviraj-Ready-Vrati");

            UredjajAkcija.Put<UredjajVM>(null);

            PreuzmiDetaljeUredjaja(EvidencijskiBroj);
            Refresh();
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
            frmServis childForm = new frmServis(Uredjaj);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
