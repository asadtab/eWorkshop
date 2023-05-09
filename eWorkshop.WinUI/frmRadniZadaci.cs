using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
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
    public partial class frmRadniZadaci : Form
    {
        APIService RadniZadatakService { get; set; }// = new APIService("RadniZadatak");
        APIService RadniZadatakUredjajService { get; set; }// = new APIService("RadniZadatakUredjaj");
        APIService UredjajiService { get; set; }// = new APIService("Uredjaj");
        APIService UredjajChangeStateTask { get; set; }// = new APIService("Uredjaj/RadniZadatak");
        public List<RadniZadatakUredjajVM> RadniZadatak { get; set; } = new List<RadniZadatakUredjajVM>();
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmRadniZadaci(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            apiCalls();
        }

        private void apiCalls()
        {
            RadniZadatakService = new APIService("RadniZadatak", TokenService);
            RadniZadatakUredjajService = new APIService("RadniZadatakUredjaj", TokenService);
            UredjajiService = new APIService("Uredjaj", TokenService);
            UredjajChangeStateTask = new APIService("Uredjaj/RadniZadatak", TokenService);
        }

        private async void frmRadniZadaci_Load(object sender, EventArgs e)
        {
            var search = new RadniZadatakSearchObject();

            search.StateMachineArray = new string[2] { "idle", "active" };

            var zadaci = await RadniZadatakService.Get<List<RadniZadatakVM>>(search);

            cmbRadniZadaci.DataSource = zadaci;
            cmbRadniZadaci.DisplayMember = "Naziv";
            cmbRadniZadaci.ValueMember = "RadniZadatakID";


            PopulateListBoxUredjaji();
            PopulateListBoxZadaci();
            PopulateInfo();


        }

        private void PopulateInfo()
        {
            var radniZadatakCmb = cmbRadniZadaci.SelectedItem as RadniZadatakVM;


            lblNaziv.Text = radniZadatakCmb.Naziv;
            lblDatum.Text = radniZadatakCmb.Datum.Day.ToString() + "." + radniZadatakCmb.Datum.Month.ToString() + "." + radniZadatakCmb.Datum.Year.ToString();
            lblStanje.Text = radniZadatakCmb.StateMachine;
        }

        //filtriranje liste prema radnim zadacima
        private async void PopulateListBoxZadaci()
        {
            var radniZadatakCmb = cmbRadniZadaci.SelectedItem as RadniZadatakVM;

            var search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = radniZadatakCmb.RadniZadatakId;

            RadniZadatak = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(search);

            lbRadniZadatakUredjaj.DataSource = RadniZadatak;
            lbRadniZadatakUredjaj.DisplayMember = "IdTip";
            lbRadniZadatakUredjaj.ValueMember = "UredjajId";

            lblUkupno.Text = RadniZadatak.Count.ToString();
            if (radniZadatakCmb.StateMachine != "active")
            {
                btnRadniZadatakDetalji.Enabled = false;
            }
            else
            {
                btnRadniZadatakDetalji.Enabled = true;
            }

        }

        private async void PopulateListBoxUredjaji()
        {
            var stateMachine = new UredjajSearchObject();
            stateMachine.Status = "active";

            var uredjaji = await UredjajiService.Get<List<UredjajVM>>(stateMachine);


            lbUredjaji.DataSource = uredjaji;
            lbUredjaji.DisplayMember = "IdTip";
            lbUredjaji.ValueMember = "UredjajId";
        }
        
        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            DodajUredjajURadniZadatak();

            PopulateListBoxZadaci();
            PopulateListBoxUredjaji();

            this.Invalidate();
        }

        private async void DodajUredjajURadniZadatak()
        {
            int uredjajId = (lbUredjaji.SelectedItem as UredjajVM).UredjajId;
            int radniZadatakId = (cmbRadniZadaci.SelectedItem as RadniZadatakVM).RadniZadatakId;

            var search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = radniZadatakId;
            //search.UredjajId = uredjajId;

            var radniZadaci = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(search);
            //provjera da li uredjaj postoji u radnom zadatku i da li je radni zadatak zavrsen
            foreach (var uredjaj in radniZadaci)
            {
                if (uredjaj.UredjajId == uredjajId
                    || uredjaj.RadniZadatak.StateMachine == "done"
                    || uredjaj.RadniZadatak.StateMachine == "invoice")
                {
                    MessageBox.Show("Uredjaj postoji u radnom zadatku ili je radni zadatak završen.");
                    return;
                }
            }

            RadniZadatakUredjajUpsertRequest request = new RadniZadatakUredjajUpsertRequest()
            {
                RadniZadatakId = (cmbRadniZadaci.SelectedItem as RadniZadatakVM).RadniZadatakId,
                UredjajId = uredjajId,
                KorisnikId = 1,
                Napomena = "napomena"
            };

            var zadatak = await UredjajChangeStateTask.Put<UredjajVM>(request);

            if (zadatak != null)
            {
                PopulateListBoxUredjaji();
                PopulateListBoxZadaci();
                MessageBox.Show("Uredjaj je uspjesno dodan u radni zadatak");
            }
        }

        private async void btnIzbaci_Click(object sender, EventArgs e)
        {
            var selectedItem = (lbRadniZadatakUredjaj.SelectedItem as RadniZadatakUredjajVM);

            await RadniZadatakUredjajService.Delete(selectedItem.Id);

            var search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = selectedItem.RadniZadatakId;

            var provjera = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(search);
            bool flag = false;

            //provjera da li uredjaj postoji jos uvijek u radnom zadatku
            for (int i = 0; i < provjera.Count; i++)
                if (provjera[i].UredjajId == selectedItem.UredjajId)
                    flag = true;

            if (!flag)
            {
                PopulateListBoxZadaci();
                PopulateListBoxUredjaji();
                MessageBox.Show("Uređaj je izbačen iz radnog zadatka.");
                return;
            }

            MessageBox.Show("Došlo je do greške.");
            this.Invalidate();
        }

        private void lbRadniZadatakUredjaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            var uredjaj = (RadniZadatakUredjajVM)lbRadniZadatakUredjaj.SelectedItem;

            LoadFrmUredjajDetalji(uredjaj.UredjajId);
        }

        private void LoadFrmUredjajDetalji(int id)
        {
            frmUredjajDetalji childForm = new frmUredjajDetalji(id, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void lbUredjaji_SelectedIndexChanged(object sender, EventArgs e)
        {
            var uredjaj = (UredjajVM)lbUredjaji.SelectedItem;

            LoadFrmUredjajDetalji(uredjaj.UredjajId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRadniZadaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateListBoxZadaci();
            PopulateInfo();


        }

        private void btnNoviRadniZadatak_Click(object sender, EventArgs e)
        {
            frmNoviRadniZadatak childForm = ServiceProvider.GetRequiredService<frmNoviRadniZadatak>();
            childForm.ShowDialog();
        }

        private void btnRadniZadatakDetalji_Click(object sender, EventArgs e)
        {
            
            var form = ServiceProvider.GetRequiredService<frmRadniZadatakDetalji>();

            //frmRadniZadatakDetalji childForm = new frmRadniZadatakDetalji(RadniZadatak);
            FormControl.NovaFormaOpcije(form);
        }
    }
}
