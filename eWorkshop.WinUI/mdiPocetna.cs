using eWorkshop.WinUI.Report;
using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI
{
    public partial class mdiPocetna : Form
    {
        private int childFormNumber = 0;
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public NavigationUserControl Navigation { get; set; }

        public mdiPocetna(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            HidePanels();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = frmPotvrda.Show("Da li se želite odjaviti?", "Da", "Ne");

            if (result == DialogResult.Yes)
            {
                APIService.Korisnik = null;

                var login = ServiceProvider.GetRequiredService<frmLogin>();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Restart();
                }
                else
                {

                }
            }
        }

        private void HidePanels()
        {
            pnlUredjaj.Visible = false;
        }

        private void ShowHidePanel()
        {
            if (pnlUredjaj.Visible)
                pnlUredjaj.Visible = false;


        }

        private void showPanel(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                ShowHidePanel();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showPanel(pnlUredjaj);
        }

        private void btnPrijemUredjaja_Click(object sender, EventArgs e)
        {
            frmPrijemUredjaja childForm = ServiceProvider.GetRequiredService<frmPrijemUredjaja>();
            FormControl.NovaFormaOpcije(childForm);
        }



        private void btnLista_Click(object sender, EventArgs e)
        {
            frmListaUredjaja childForm = ServiceProvider.GetRequiredService<frmListaUredjaja>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void mdiPocetna_Load(object sender, EventArgs e)
        {
            frmMain childForm = ServiceProvider.GetRequiredService<frmMain>();

            childForm.MdiParent = this;
            childForm.Text = string.Empty;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain childForm = ServiceProvider.GetRequiredService<frmMain>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void detaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniZadaci childForm = ServiceProvider.GetRequiredService<frmRadniZadaci>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKomponentu childForm = new frmDodajKomponentu(ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void prijemUređajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrijemUredjaja childForm = ServiceProvider.GetRequiredService<frmPrijemUredjaja>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajNoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviRadniZadatak childForm = ServiceProvider.GetRequiredService<frmNoviRadniZadatak>();
            childForm.ShowDialog();
        }

        private void listaRadnihZadatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniZadaciLista childForm = ServiceProvider.GetRequiredService<frmRadniZadaciLista>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnListaKorisnika_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika childForm = ServiceProvider.GetRequiredService<frmDodajKorisnika>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void mojRačunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRacun childForm = new frmRacun(APIService.Korisnik.KorisniciId, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            frmReportPicker childForm = ServiceProvider.GetRequiredService<frmReportPicker>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnDodajKorisnika_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika childForm = ServiceProvider.GetRequiredService<frmDodajKorisnika>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajNovogKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika childForm = ServiceProvider.GetRequiredService<frmDodajKorisnika>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajKlijentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKlijent childForm = ServiceProvider.GetRequiredService<frmDodajKlijent>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void klijentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlijenti childForm = ServiceProvider.GetRequiredService<frmKlijenti>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void resursiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResursi childForm = ServiceProvider.GetRequiredService<frmResursi>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void korisniciToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmKorisnici childForm = ServiceProvider.GetRequiredService<frmKorisnici>();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void ulogeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUloge childForm = ServiceProvider.GetRequiredService<frmUloge>();
            FormControl.NovaFormaOpcije(childForm);
        }
    }
}
