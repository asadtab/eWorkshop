using eWorkshop.Model;
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
    public partial class frmUredjajDetalji : Form
    {

        APIService UredjajService { get; set; } = new APIService("Uredjaj");
        UredjajVM Uredjaj { get; set; } = new UredjajVM();
        int EvidencijskiBroj;

        public frmUredjajDetalji(int evBroj)
        {
            InitializeComponent();
            EvidencijskiBroj = evBroj;
            
            
        }

        private async void PreuzmiDetaljeUredjaja(int evBroj)
        {
            Uredjaj = await UredjajService.GetById<UredjajVM>(evBroj);
        }

        private async void UcitajDetaljeUredjaja()
        {
            lblEvBroj.Text = Uredjaj.UredjajId.ToString();
            lblKoda.Text = Uredjaj.Koda.ToString();
            lblSerBroj.Text = Uredjaj.SerijskiBroj.ToString();
            lblTip.Text = Uredjaj.Tip.Naziv.ToString();
        }

        private void lblKoda_Click(object sender, EventArgs e)
        {

        }

        private void frmUredjajDetalji_Load(object sender, EventArgs e)
        {
            PreuzmiDetaljeUredjaja(EvidencijskiBroj);
            UcitajDetaljeUredjaja();
        }
    }
}
