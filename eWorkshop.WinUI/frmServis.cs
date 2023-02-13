using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
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
    public partial class frmServis : Form
    {
        public UredjajVM Uredjaj { get; set; }
        public StatusHelper StatusHelp { get; set; } = new StatusHelper();
        public APIService KomponenteService { get; set; } = new APIService("Komponente");
        public APIService ServisIzvrsen { get; set; } = new APIService("ServisIzvrsen");
        public APIService UredjajService { get; set; } = new APIService("Uredjaj/Servisiraj");
        public ServisIzvrsenVM Servis { get; set; }
        public List<int> KomponenteId { get; set; } = new List<int>();
        public int Brojac { get; set; } = 1;

        public frmServis(UredjajVM uredjaj)
        {
            InitializeComponent();

            Uredjaj = uredjaj;
        }

        private void frmServis_Load(object sender, EventArgs e)
        {
            lblEvBroj.Text = Uredjaj.UredjajId.ToString();
            lblKoda.Text = Uredjaj.Koda.ToString();
            lblLokacija.Text = Uredjaj.Lokacija.Naziv.ToString();
            lblSerBroj.Text = Uredjaj.SerijskiBroj.ToString();
            lblStatus.Text = StatusHelp.ProvjeraStatusa(Uredjaj.Status, StatusHelp.nizNaziv, StatusHelp.nizOpis);
            lblTip.Text = Uredjaj.Tip.Naziv.ToString();
        }

        private async void btnKomponenta_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(Brojac++.ToString());
            item.SubItems.Add(txtKomponentaNaziv.Text);
            item.SubItems.Add(txtKomponentaVrijednost.Text);
            item.SubItems.Add(txtKomponentaKoda.Text);
            lvKomponente.Items.Add(item);

            KomponenteUpsertRequest komponenta = new KomponenteUpsertRequest();
            komponenta.Vrijednost = txtKomponentaVrijednost.Text;
            komponenta.Naziv = txtKomponentaNaziv.Text;
            komponenta.Tip = txtKomponentaKoda.Text;

            var entity = new KomponenteSearchObject();
            entity.Vrijednost = txtKomponentaVrijednost.Text;
            entity.Naziv = txtKomponentaNaziv.Text;
            entity.Tip = txtKomponentaKoda.Text;

            var search = await KomponenteService.Get<List<KomponenteVM>>(entity);

            var request = new KomponenteVM();

            if (search.Count == 0)
            {
                request = await KomponenteService.Post<KomponenteVM>(komponenta);
                KomponenteId.Add(request.KomponentaId);
            }

            if(request != null)
            {
                MessageBox.Show("Komponenta je uspjesno dodana.");
                OcistiTextBox();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServisInsertRequest servis = new ServisInsertRequest();

            servis.UredjajId = Uredjaj.UredjajId;
            servis.Datum = DateTime.Now;
            servis.KorisnikId = 1;
            servis.KomponenteIdList = KomponenteId;
            servis.RadniZadatakId = 1;
            
            var request = await UredjajService.Put<ServisVM>(servis);

            if (request != null)
            {
                MessageBox.Show("Uredjaj je uspjesno servisiran");
                OcistiTextBox();
                this.Close();
            }
        }

        private void OcistiTextBox()
        {
            txtKomponentaKoda.Clear();
            txtKomponentaNaziv.Clear();
            txtKomponentaVrijednost.Clear();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "Ω";
        }

        private void btnMikro_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "µ";
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "Ü";
        }

        private void btn_u_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "ü";
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "Ö";
        }

        private void btn_o_Click(object sender, EventArgs e)
        {
            txtKomponentaVrijednost.Text += "ö";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
