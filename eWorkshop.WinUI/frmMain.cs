    using eWorkshop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using eWorkshop.WinUI.UserControls;
using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.Helper_classes;
using Microsoft.Extensions.Options;

namespace eWorkshop.WinUI
{
    
    public partial class frmMain : Form
    {
        APIService zadatak;// = new APIService("RadniZadatak");
        APIService zadatakUredjaj;// = new APIService("RadniZadatakUredjaj");
        APIService UredjajService;// = new APIService("Uredjaj");
        APIService StatistikaUredjajiService;// = new APIService("Statistika/Uredjaji");
        APIService StatistikaZadaciService;// = new APIService("Statistika/RadniZadaci");
        StatistikaVM StatistikaUredjaji = new StatistikaVM();
        StatistikaVM StatistikaZadaci = new StatistikaVM();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public  int  AktivniRadniZadaci { get; set; } = 0;
        public  int  ServisiraniUredjaji { get; set; } = 0;
        public  int  AktivniUredjaji { get; set; } = 0;
        public  int  PoslaniUredjaji { get; set; } = 0;
        public  int  SpremniUredjaji { get; set; } = 0;
        public  int  UredjajiUkupno { get; set; } = 0;
        public  int  RezervniDijeloviUredjaji { get; set; } = 0;
        public  int  RadniZadaciUredjaji { get; set; } = 0;
        public frmMain(IServiceProvider serviceProvider, ITokenService tokenService) 
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            apiCalls();
        }

        private void apiCalls()
        {
            zadatak = new APIService("RadniZadatak", TokenService);
            zadatakUredjaj = new APIService("RadniZadatakUredjaj", TokenService);
            StatistikaUredjajiService = new APIService("Statistika/Uredjaji", TokenService);
            StatistikaZadaciService = new APIService("Statistika/RadniZadaci", TokenService);
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {

            StatistikaUredjaji = await StatistikaUredjajiService.Get<StatistikaVM>();
            StatistikaZadaci = await StatistikaZadaciService.Get<StatistikaVM>();

            LoadRadneZadatke();
            StatistikaInfo();
        }


        private async void StatistikaInfo()
        {
            lblUkupnoUredjaja.Text = StatistikaUredjaji.UredjajiUkupno.ToString();
            lblAktivniUredjaji.Text = StatistikaUredjaji.AktivniUredjaji.ToString();
            lblPoslaniUredjaji.Text = StatistikaUredjaji.PoslaniUredjaji.ToString();
            lblServisiraniUredjaji.Text = StatistikaUredjaji.ServisiraniUredjaji.ToString();
            lblNeaktivniUredjaji.Text = StatistikaUredjaji.NeaktivniUredjaji.ToString();
            lblSpremniUredjaji.Text = StatistikaUredjaji.SpremniUredjaji.ToString();
            lblTaskUredjaji.Text = StatistikaUredjaji.RadniZadaciUredjaji.ToString();
            
            lblUkupnoKorisnika.Text = StatistikaUredjaji.KorisniciUkupno.ToString();

            lblAktivniRadniZadaci.Text = StatistikaZadaci.AktivniRadniZadaci.ToString();
        }

        private async void LoadRadneZadatke()
        {
            var getZadaci = await zadatak.Get<List<RadniZadatakVM>>();
            var getZadatakUredjaj = await zadatakUredjaj.Get<List<RadniZadatakUredjajVM>>();

            int x = 0;
            int y = 0;

            var RadniZadatakDistinctIdList = getZadatakUredjaj.Select(x => x.RadniZadatakId).Distinct().ToList();

            for (int i = 0; i < getZadaci.Count; i++)
            {
                if (getZadaci[i].StateMachine == "active")
                {
                    AktivniRadniZadaci++;
                    //filtriranje radnih zadataka na osnovu stanja (state machine pattern)
                    var control = new RadniZadaciUserControl(ServiceProvider, TokenService, getZadatakUredjaj.Where(x => x.RadniZadatakId == getZadaci[i].RadniZadatakId).ToList());
                    control.Location = new Point(x, y);

                    flPanel.Controls.Add(control);
                    y += control.Height;
                }
            }
        }
    }
}
