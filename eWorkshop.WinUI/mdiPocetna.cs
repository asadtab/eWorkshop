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
    public partial class mdiPocetna : Form
    {
        private int childFormNumber = 0;
        public FormControl FormControl { get; set; } = new FormControl();
        public mdiPocetna()
        {
            InitializeComponent();
            HidePanels();
        }

        private void HidePanels()
        {
            pnlUredjaj.Visible = false;
            pnlKorisnici.Visible = false;
        }

        private void ShowHidePanel()
        {
            if (pnlUredjaj.Visible)
                pnlUredjaj.Visible = false;

            if (pnlKorisnici.Visible)
                pnlKorisnici.Visible = false;
        }

        private void showPanel (Panel subMenu)
        {
            if(!subMenu.Visible)
            {
                ShowHidePanel();
                subMenu.Visible = true; 
            } else
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
            frmPrijemUredjaja childForm = new frmPrijemUredjaja();
            FormControl.NovaFormaOpcije(childForm);

        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            showPanel(pnlKorisnici);
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            frmListaUredjaja childForm = new frmListaUredjaja();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void mdiPocetna_Load(object sender, EventArgs e)
        {
            frmMain childForm = new frmMain();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            frmTest childForm = new frmTest();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain childForm = new frmMain();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void detaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniZadaci childForm = new frmRadniZadaci();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKomponentu childForm = new frmDodajKomponentu();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void prijemUređajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrijemUredjaja childForm = new frmPrijemUredjaja();
            FormControl.NovaFormaOpcije(childForm);
        }

        private void dodajNoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviRadniZadatak childForm = new frmNoviRadniZadatak();
            childForm.ShowDialog();
        }

        private void listaRadnihZadatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniZadaciLista childForm = new frmRadniZadaciLista();
            FormControl.NovaFormaOpcije(childForm);
        }
    }
}
