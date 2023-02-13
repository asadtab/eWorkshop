using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
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
    public partial class frmPrijemUredjaja : Form
    {
        APIService UredjajiService = new APIService("Uredjaj");
        APIService TipUredjajaService = new APIService("TipUredjaja");
        APIService LokacijaService = new APIService("Lokacija");
        APIService RadniZadatakService = new APIService("RadniZadatak");
        APIService RadniZadatakUredjajService = new APIService("Uredjaj/RadniZadatak");
        public frmPrijemUredjaja()
        {
            InitializeComponent();
        }

        private async Task getTipUredjaja()
        {
            var tip = await TipUredjajaService.Get<List<TipUredjajaVM>>();
            cmbTipUredjaja.DataSource = tip;
            cmbTipUredjaja.ValueMember = "TipUredjajaId";
            cmbTipUredjaja.DisplayMember = "OpisNaziv";
        }

        private async void frmPrijemUredjaja_Load(object sender, EventArgs e)
        {
            await getTipUredjaja();
            await getLokacija();
            await getRadneZadatke();
            await getZadnjiEvBroj();
            
            SelectDefault();
        }

        private async Task getZadnjiEvBroj()
        {
            UredjajSearchObject search = new UredjajSearchObject();
            search.GetNajveciEvBroj = true;

            var uredjaj = await UredjajiService.Get<List<UredjajVM>>();

            txtEvBroj.Text = uredjaj.OrderByDescending(x => x.UredjajId).First().UredjajId.ToString();
        }

        private async Task getRadneZadatke()
        {
            RadniZadatakUredjajSearchObject searchZadatak = new RadniZadatakUredjajSearchObject();
            searchZadatak.ZadatakState = new string[2] {"idle", "active"};
            

            var result = await RadniZadatakService.Get<List<RadniZadatakVM>>(searchZadatak);
            var zadaci = result.Where(x => x.StateMachine == "idle" || x.StateMachine == "active").ToList();

            /*cmbRadniZadatak.DataSource = zadaci;
            cmbRadniZadatak.ValueMember = "RadniZadatakId";
            cmbRadniZadatak.DisplayMember = "Naziv";*/
        }

        private void SelectDefault()
        {
            cmbLokacija.SelectedItem = null;
            cmbLokacija.SelectedText = "--Odaberi lokaciju--";

            cmbTipUredjaja.SelectedItem = null;
            cmbTipUredjaja.SelectedText = "--Odaberi tip--";

            /*cmbRadniZadatak.SelectedItem = null;
            cmbRadniZadatak.SelectedText = "--Odaberi radni zadatak--";*/
        }

        private async Task getLokacija()
        {
            var lokacija = await LokacijaService.Get<List<LokacijaVM>>();
            cmbLokacija.DataSource = lokacija;
            cmbLokacija.ValueMember = "LokacijaId";
            cmbLokacija.DisplayMember = "Naziv";
        }

        private async void btnRegistruj_Click(object sender, EventArgs e)
        {
            UredjajUpsertRequest request = new UredjajUpsertRequest()
            {
                Koda = txtKoda.Text,
                TipId = (cmbTipUredjaja.SelectedItem as TipUredjajaVM).TipUredjajaId,
                SerijskiBroj = txtSerijskiBroj.Text,
                DatumIzvedbe = txtIzdanje.Text,
                LokacijaId = (cmbLokacija.SelectedItem as LokacijaVM).LokacijaId
            };

            var uredjaj = await UredjajiService.Post<UredjajVM>(request);

            if(uredjaj != null)
            {
                MessageBox.Show("Uspjesno je dodan uređaj sa evidencijskim brojem : " + uredjaj.UredjajId);
                txtIzdanje.Text = "";
                txtKoda.Text = "";
                txtSerijskiBroj.Text = "";
                txtOpisKodPrijema.Text = "";
                SelectDefault();
            }

/*            if(cmbRadniZadatak.SelectedItem != null)
            {
                RadniZadatakUredjajUpsertRequest requestZadatak = new RadniZadatakUredjajUpsertRequest();
                requestZadatak.UredjajId = uredjaj.UredjajId;
                requestZadatak.RadniZadatakId = (cmbRadniZadatak.SelectedItem as RadniZadatakVM).RadniZadatakId;
                requestZadatak.KorisnikId = 1;
                
                await RadniZadatakUredjajService.Put<RadniZadatakUredjajBasicVM>(requestZadatak);
            }*/
        }

        private async void btnNoviTipUredjaja_Click(object sender, EventArgs e)
        {
            frmDodajTipUredjaja frmTip = new frmDodajTipUredjaja();
            frmTip.ShowDialog();
        }

        private void btnGenerisiSerijskiBroj_Click(object sender, EventArgs e)
        {
            txtSerijskiBroj.Text = (int.Parse(txtEvBroj.Text) + 1).ToString() + "/" + DateTime.Now.Year;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
