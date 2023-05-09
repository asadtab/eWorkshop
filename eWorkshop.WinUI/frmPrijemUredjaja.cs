using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
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
    public partial class frmPrijemUredjaja : Form
    {
        APIService UredjajiService;
        APIService TipUredjajaService;
        APIService LokacijaService;
        APIService RadniZadatakService;
        APIService RadniZadatakUredjajService;

        public FormControl FormControl { get; set; } = new FormControl();
        public bool EditActivated { get; set; } = false;
        int UredjajId;
        APIService UredjajiServiceEdit;
        int TipId;
        public UredjajVM Uredjaj { get; set; } = new UredjajVM();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmPrijemUredjaja(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            apiCalls();
        }

        private void apiCalls()
        {
            UredjajiService = new APIService("Uredjaj", TokenService);
            TipUredjajaService = new APIService("TipUredjaja", TokenService);
            LokacijaService = new APIService("Lokacija", TokenService);
            RadniZadatakService = new APIService("RadniZadatak", TokenService);
            RadniZadatakUredjajService = new APIService("Uredjaj/RadniZadatak", TokenService);
        }

        public frmPrijemUredjaja(UredjajVM uredjaj, IServiceProvider serviceProvider, ITokenService tokenService) : this(serviceProvider, tokenService)
        {
            Uredjaj = uredjaj;
            EditActivated = true;

            TipId = uredjaj.Tip.TipUredjajaId;

            txtEvBroj.Text = Uredjaj.UredjajId.ToString();
            txtIzdanje.Text = Uredjaj.DatumIzvedbe?.ToString() == null ? "" : Uredjaj.DatumIzvedbe?.ToString();
            txtKoda.Text = Uredjaj.Koda;
            txtSerijskiBroj.Text = Uredjaj.SerijskiBroj;
        }

        private async Task getTipUredjaja()
        {

            var tip = await TipUredjajaService.Get<List<TipUredjajaVM>>();


            cmbTipUredjaja.DataSource = tip;
            cmbTipUredjaja.ValueMember = "TipUredjajaId";
            cmbTipUredjaja.DisplayMember = "OpisNaziv";


            if (EditActivated == true)
            {
                var selectedItem = tip.Where(x => x.TipUredjajaId == Uredjaj.Tip.TipUredjajaId).FirstOrDefault();

                if (selectedItem != null)
                {
                    cmbTipUredjaja.SelectedItem = selectedItem;
                }
            }
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
            searchZadatak.ZadatakState = new string[2] { "idle", "active" };


            var result = await RadniZadatakService.Get<List<RadniZadatakVM>>(searchZadatak);
            var zadaci = result.Where(x => x.StateMachine == "idle" || x.StateMachine == "active").ToList();

        }

        private void SelectDefault()
        {
            cmbLokacija.SelectedItem = null;
            cmbLokacija.SelectedText = "--Odaberi lokaciju--";

            cmbTipUredjaja.SelectedItem = null;
            cmbTipUredjaja.SelectedText = "--Odaberi tip--";

        }

        private async Task getLokacija()
        {
            var lokacija = await LokacijaService.Get<List<LokacijaVM>>();
            cmbLokacija.DataSource = lokacija;
            cmbLokacija.ValueMember = "LokacijaId";
            cmbLokacija.DisplayMember = "Naziv";

            if (EditActivated == true)
            {
                var selectedItem = lokacija.Where(x => x.LokacijaId == Uredjaj.Lokacija.LokacijaId).FirstOrDefault();

                if (selectedItem != null)
                {
                    cmbLokacija.SelectedItem = selectedItem;
                }
            }
        }

        private bool ValidirajUnos()
        {
            return FormControl.CheckInput(errProvider, txtKoda, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtIzdanje, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtOpisKodPrijema, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtSerijskiBroj, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, cmbTipUredjaja, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, cmbLokacija, FormControl.ObaveznaVrijednost);
        }

        private async void btnRegistruj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                UredjajUpsertRequest request = new UredjajUpsertRequest()
                {
                    Koda = txtKoda.Text,
                    TipId = (cmbTipUredjaja.SelectedItem as TipUredjajaVM).TipUredjajaId,
                    SerijskiBroj = txtSerijskiBroj.Text,
                    DatumIzvedbe = txtIzdanje?.Text,
                    LokacijaId = (cmbLokacija.SelectedItem as LokacijaVM).LokacijaId
                };

                var uredjaj = new UredjajVM();

                if (EditActivated == true)
                {
                    DialogResult result = frmPotvrda.Show("Da li želite sačuvati promjene?", "Potvrdi", "Poništi");

                    if (result == DialogResult.Yes)
                    {
                        UredjajiServiceEdit = new APIService("Uredjaj/" + Uredjaj.UredjajId, TokenService);

                        try
                        {
                            uredjaj = await UredjajiServiceEdit.Put<UredjajVM>(request);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        MessageBox.Show("Uspjesno su sačuvane promjene za uređaj sa evidencijskim brojem : " + Uredjaj.UredjajId);
                        txtIzdanje.Text = "";
                        txtKoda.Text = "";
                        txtSerijskiBroj.Text = "";
                        txtOpisKodPrijema.Text = "";
                        SelectDefault();

                        this.Close();
                    }
                }
                else
                {
                    try
                    {
                        uredjaj = await UredjajiService.Post<UredjajVM>(request);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }


                if (uredjaj != null && !EditActivated)
                {
                    MessageBox.Show("Uspjesno je dodan uređaj sa evidencijskim brojem : " + uredjaj.UredjajId);
                    txtIzdanje.Text = "";
                    txtKoda.Text = "";
                    txtSerijskiBroj.Text = "";
                    txtOpisKodPrijema.Text = "";
                    SelectDefault();

                    errProvider.Clear();

                    this.Close();

                    var form = ServiceProvider.GetRequiredService<frmPrijemUredjaja>();
                    FormControl.NovaFormaOpcije(form);
                }
            }
            else
            {
                MessageBox.Show("Netačan unos!");
            }
        }

        private async void btnNoviTipUredjaja_Click(object sender, EventArgs e)
        {
            frmDodajTipUredjaja frmTip = ServiceProvider.GetRequiredService<frmDodajTipUredjaja>();
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

        private void frmPrijemUredjaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditActivated == true)
            {
                frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
                FormControl.NovaFormaOpcije(childForm);
            }
        }
    }
}
