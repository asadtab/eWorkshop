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

        public mdiPocetna()
        {
            InitializeComponent();
            HidePanels();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock= DockStyle.Fill;
            childForm.Show();
        }

        private void btnServis_Click(object sender, EventArgs e)
        {
            /*frmServis childForm = new frmServis();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();*/
        }

        private void btnIsporuka_Click(object sender, EventArgs e)
        {

        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            showPanel(pnlKorisnici);
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            frmListaUredjaja childForm = new frmListaUredjaja();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
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
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }



        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain childForm = new frmMain();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void detaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniZadaci childForm = new frmRadniZadaci();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKomponentu childForm = new frmDodajKomponentu();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
    }
}
