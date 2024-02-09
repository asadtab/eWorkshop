using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
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
    public partial class frmServis : Form
    {
        public UredjajVM Uredjaj { get; set; }
        public StatusHelper StatusHelp { get; set; } = new StatusHelper();
        public APIService KomponenteService { get; set; }
        public APIService ServisIzvrsen { get; set; }
        public APIService ZadatakService { get; set; }
        public APIService KomponenteRecommended { get; set; }
        public APIService UredjajService { get; set; }
        public FormControl FormControl { get; set; } = new FormControl();
        public ServisIzvrsenVM Servis { get; set; }
        public List<int> KomponenteId { get; set; } = new List<int>();


        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public int Brojac { get; set; } = 1;

        public frmServis(UredjajVM uredjaj, IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            Uredjaj = uredjaj;

            apiCalls();
        }

        private void apiCalls()
        {
            KomponenteService = new APIService("Komponente", TokenService);
            ServisIzvrsen = new APIService("ServisIzvrsen", TokenService);
            ZadatakService = new APIService("RadniZadatakUredjaj", TokenService);
            KomponenteRecommended = new APIService("ServisIzvrsen/Komponente", TokenService);
            UredjajService = new APIService("Uredjaj/Servisiraj", TokenService);
        }
          
        private async void frmServis_Load(object sender, EventArgs e)
        {
            lblEvBroj.Text = Uredjaj.UredjajId.ToString();
            lblKoda.Text = Uredjaj.Koda.ToString();
            lblLokacija.Text = Uredjaj.Lokacija.Naziv.ToString();
            lblSerBroj.Text = Uredjaj.SerijskiBroj.ToString();
            lblStatus.Text = StatusHelp.ProvjeraStatusa(Uredjaj.Status, StatusHelp.nizNaziv, StatusHelp.nizOpis);
            lblTip.Text = Uredjaj.Tip.Naziv.ToString();
            txtOpisServisiranja.Text = Uredjaj.TipNaziv == "VGS" ? ServisHelperVM.OpisServisiranjaUlosci : ServisHelperVM.OpisServisiranjaGrupe;

            ServisIzvrsenSearchObject search = new ServisIzvrsenSearchObject();
            search.TipUredjajaNaziv = Uredjaj.TipNaziv;

            var komponenteRecommended = await KomponenteRecommended.Get<List<KomponenteVM>>(search);

            cmbKomponente.DataSource = komponenteRecommended;
            cmbKomponente.ValueMember = "KomponentaId";
            cmbKomponente.DisplayMember = "Naziv";
        }

        public bool ValidirajUnos()
        {
            return
                FormControl.CheckInput(errProvider, txtKomponentaNaziv, FormControl.ObaveznaVrijednost);
        }

        private async void btnKomponenta_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                //dodaje se komponenta u tabelu iz textboxa
                ListViewItem item = new ListViewItem(Brojac++.ToString());
                item.SubItems.Add(txtKomponentaNaziv.Text);
                item.SubItems.Add(txtKomponentaVrijednost.Text);
                item.SubItems.Add(txtKomponentaKoda.Text);
                lvKomponente.Items.Add(item);

                //objekat za insertovanje komponente iz textboxa
                KomponenteUpsertRequest komponenta = new KomponenteUpsertRequest();
                komponenta.Vrijednost = txtKomponentaVrijednost.Text;
                komponenta.Naziv = txtKomponentaNaziv.Text;
                komponenta.Tip = txtKomponentaKoda.Text;

                //search objekat za pretrgu komponentu 
                var entity = new KomponenteSearchObject();
                entity.Vrijednost = txtKomponentaVrijednost.Text;
                entity.Naziv = txtKomponentaNaziv.Text;
                entity.Tip = txtKomponentaKoda.Text;

                //pretraga komponenti
                var search = await KomponenteService.Get<List<KomponenteVM>>(entity);

                var request = new KomponenteVM();

                //ako ne postoji dodana komponenta, sacuva se u bazu
                if (search.Count == 0)
                {
                    request = await KomponenteService.Post<KomponenteVM>(komponenta);

                    if (provjeriKomponentu(KomponenteId, request))
                        return;

                    KomponenteId.Add(request.KomponentaId);
                    item.SubItems.Add(request.KomponentaId.ToString());
                }
                else
                {

                    if (provjeriKomponentu(KomponenteId, search.FirstOrDefault()))
                    {
                        lvKomponente.Items.Remove(item);
                        OcistiTextBox();
                        return;
                    }

                    KomponenteId.Add(search.FirstOrDefault().KomponentaId);
                    item.SubItems.Add(search.FirstOrDefault().KomponentaId.ToString());

                    //item.SubItems.Add(search.First().KomponentaId.ToString());

                    if (request.KomponentaId != 0)
                    {
                        MessageBox.Show("Komponenta je uspjesno dodana.");
                        OcistiTextBox();
                    }
                }

                OcistiTextBox();
            }
            else
            {
                MessageBox.Show("Netačan unos!");
            }
        }

        private bool provjeriKomponentu(List<int> list, KomponenteVM komponenta)
        {
            bool flag = false;

            foreach (var item in list)
            {
                if (item == komponenta.KomponentaId)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                MessageBox.Show("Komponenta postoji na listi");
                return flag;
            }

            return flag;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServisInsertRequest servis = new ServisInsertRequest();

            RadniZadatakUredjajSearchObject search = new RadniZadatakUredjajSearchObject();
            search.UredjajId = Uredjaj.UredjajId;
            search.RadniZadatakState = "active";


            var radniZadatak = await ZadatakService.Get<List<RadniZadatakUredjajVM>>(search);

            servis.UredjajId = Uredjaj.UredjajId;
            servis.Datum = DateTime.Now;
            
            servis.KomponenteIdList = KomponenteId;
            servis.RadniZadatakId = Uredjaj.Status == "task" ? radniZadatak.FirstOrDefault().RadniZadatakId : 1;
            servis.Napomena = txtOpisServisiranja.Text;

            try
            {
                var request = await UredjajService.Put<ServisVM>(servis);

                if (request != null)
                {
                    MessageBox.Show("Uredjaj je uspjesno servisiran");
                    OcistiTextBox();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void btnDodajRecommended_Click(object sender, EventArgs e)
        {
            var komponenta = cmbKomponente.SelectedItem as KomponenteVM;
            bool flag = false;

            if (provjeriKomponentu(KomponenteId, komponenta))
                return;

            KomponenteId.Add(komponenta.KomponentaId);

            loadKomponente(komponenta);
        }

        private async void urediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KomponenteUpsertRequest request = new KomponenteUpsertRequest();
            int komponentaId = 0;

            foreach (ListViewItem item in lvKomponente.Items)
            {
                if (item.Selected)
                {
                    request.Naziv = item.SubItems[1].Text;
                    request.Vrijednost = item.SubItems[2].Text;
                    request.Tip = item.SubItems[3].Text;
                    komponentaId = int.Parse(item.SubItems[4].Text);
                }
            }

            frmKomponenteEdit form = new frmKomponenteEdit(request, komponentaId, ServiceProvider, TokenService);
            //form.FormClosing += new FormClosingEventHandler(this.frmServis_FormClosed);
            form.ShowDialog();

            frmServis_Load(sender, e);

            lvKomponente.SelectedItems[0].Remove();

            var komponenta = await KomponenteService.GetById<KomponenteVM>(komponentaId);
            loadKomponente(komponenta);

        }

        private void loadKomponente(KomponenteVM komponenta)
        {
            ListViewItem item = new ListViewItem(Brojac++.ToString());
            item.SubItems.Add(komponenta.Naziv);
            item.SubItems.Add(komponenta.Vrijednost);
            item.SubItems.Add(komponenta.Tip);
            item.SubItems.Add(komponenta.KomponentaId.ToString());
            lvKomponente.Items.Add(item);
        }

        private void izbrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kolona = 4;

            if(kolona < lvKomponente.SelectedItems[0].SubItems.Count)
            {
                var selected = int.Parse(lvKomponente.SelectedItems[0].SubItems[4].Text);

                KomponenteId.Remove(selected);
                lvKomponente.SelectedItems[0].Remove();
            } else
            {
                MessageBox.Show("Komponenta ne postoji!");
            }
        }

        private void frmServis_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmUredjajDetalji childForm = new frmUredjajDetalji(Uredjaj.UredjajId, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }
    }
}
