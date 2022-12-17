using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
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
    public partial class frmRadniZadaci : Form
    {
        APIService RadniZadatakService { get; set; } = new APIService("RadniZadatak");
        APIService RadniZadatakUredjajService { get; set; } = new APIService("RadniZadatakUredjaj");
        APIService UredjajiService { get; set; } = new APIService("Uredjaj");
        APIService UredjajChangeStateTask { get; set; } = new APIService("Uredjaj/RadniZadatak");
        public frmRadniZadaci()
        {
            InitializeComponent();
        }

        private async void frmRadniZadaci_Load(object sender, EventArgs e)
        {
            var zadaci = await RadniZadatakService.Get<List<RadniZadatakVM>>();

            cmbRadniZadaci.DataSource = zadaci;
            cmbRadniZadaci.DisplayMember = "Naziv";
            cmbRadniZadaci.ValueMember = "RadniZadatakID";

            PopulateListBoxZadaci();
            PopulateListBoxUredjaji();
        }

        private async void cmbRadniZadaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateListBoxZadaci();
        }


        //filtriranje liste prema radnim zadacima


        private async void PopulateListBoxZadaci()
        {
            var radniZadatakCmb = cmbRadniZadaci.SelectedItem as RadniZadatakVM;

            var search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = radniZadatakCmb.RadniZadatakId;
            //search.UredjajState = "task";

            var uredjaji = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(search);


            lblNaziv.Text = radniZadatakCmb.Naziv;
            lblDatum.Text = radniZadatakCmb.Datum.ToString();
            lblStanje.Text = radniZadatakCmb.StateMachine;
            lblUkupno.Text = uredjaji.Count.ToString();

            //lbRadniZadatakUredjaj.DataSource = uredjaji;

            lbRadniZadatakUredjaj.Items.Clear();
            lbRadniZadatakUredjaj.Items.AddRange(uredjaji.Cast<object>().ToArray());
            lbRadniZadatakUredjaj.DisplayMember = "IdTip";
            lbRadniZadatakUredjaj.ValueMember = "UredjajId";

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
            /*var bw = new BackgroundWorker();

            bw.DoWork += (sender, e) => DodajUredjajURadniZadatak();
            bw.RunWorkerCompleted += (sender, r) => PopulateListBoxZadaci();
            bw.RunWorkerCompleted += (sender, r) => PopulateListBoxUredjaji();
            bw.RunWorkerAsync();*/

            DodajUredjajURadniZadatak();

            PopulateListBoxZadaci();
            PopulateListBoxUredjaji();

            lbRadniZadatakUredjaj.Refresh();
            lbRadniZadatakUredjaj.Update();
            lbUredjaji.Update();
            lbUredjaji.Refresh();


            


            MessageBox.Show("Uredjaj je uspjesno dodan u radni zadatak");
            this.Invalidate();
        }

        private async void DodajUredjajURadniZadatak()
        {
            int uredjajId = (lbUredjaji.SelectedItem as UredjajVM).UredjajId;
            int radniZadatakId = (cmbRadniZadaci.SelectedItem as RadniZadatakVM).RadniZadatakId;

            var search = new RadniZadatakUredjajSearchObject();
            search.RadniZadatakId = radniZadatakId;
            search.UredjajId = uredjajId;

            var radniZadaci = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(search);
            //provjera da li uredjaj postoji u radnom zadatku
            foreach (var uredjaj in radniZadaci)
            {
                if (uredjaj.UredjajId == uredjajId && uredjaj.RadniZadatakId == radniZadatakId 
                    || uredjaj.UredjajId == uredjajId && uredjaj.RadniZadatakId != radniZadatakId)
                {
                    MessageBox.Show("Uredjaj postoji u radnom zadatku");
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
            //RadniZadatakUredjajService.Post<RadniZadatakUredjajVM>(request);
            UredjajChangeStateTask.Put<UredjajVM>(request);
        }

        private void btnIzbaci_Click(object sender, EventArgs e)
        {
            RadniZadatakUredjajService.Delete((lbRadniZadatakUredjaj.SelectedItem as RadniZadatakUredjajVM).Id);
            this.Invalidate();
            
        }
    }
}
