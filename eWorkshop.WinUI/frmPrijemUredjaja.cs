using eWorkshop.Model;
using eWorkshop.Model.Requests;
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
        public frmPrijemUredjaja()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        }

        private async void btnRegistruj_Click(object sender, EventArgs e)
        {
            UredjajUpsertRequest request = new UredjajUpsertRequest()
            {
                Koda = txtKoda.Text,
                TipId = (cmbTipUredjaja.SelectedItem as TipUredjajaVM).TipUredjajaId,
                SerijskiBroj = txtSerijskiBroj.Text,
                DatumIzvedbe = txtIzdanje.Text,
                LokacijaId = 1
            };

            var uredjaj = await UredjajiService.Post<UredjajVM>(request);

            if(uredjaj != null)
            {
                MessageBox.Show("Uspjesno je dodan uređaj sa evidencijskim brojem: " + uredjaj.UredjajId);
                txtIzdanje.Text = "";
                txtKoda.Text = "";
                txtSerijskiBroj.Text = "";
                txtOpisKodPrijema.Text = "";
            }
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

        private async void cmbTipUredjaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
