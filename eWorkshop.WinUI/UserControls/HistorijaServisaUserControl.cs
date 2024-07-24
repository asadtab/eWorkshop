using eWorkshop.Model;
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

namespace eWorkshop.WinUI.UserControls
{
    public partial class HistorijaServisaUserControl : UserControl
    {
        APIService ReparacijaService { get; set; } = new APIService("Reparacija");
        APIService ServisIzvrsenService { get; set; } = new APIService("ServisIzvrsen");
        public List<ServisIzvrsenVM> Komponente { get; set; } = new List<ServisIzvrsenVM>();

        ServisVM Reparacija = new ServisVM();
        public string Datum { get; set; }
        public HistorijaServisaUserControl(List<ServisIzvrsenVM> komponente, string datum, ServisVM servisVM)
        {
            InitializeComponent();
            Reparacija = servisVM;
            Datum = datum;
            Komponente = komponente;
            HidePanel();
            UcitajKomponente(komponente);
        }

        private async void UcitajKomponente(List<ServisIzvrsenVM> komponente)
        {
            btnDatum.Text = Datum + " - " + Reparacija.UredjajId;

            for (int i = 0; i < komponente.Count; i++)
            {
                ListViewItem item = new ListViewItem(komponente[i].Komponenta.Naziv);
                item.SubItems.Add(komponente[i].Komponenta.Vrijednost);
                item.SubItems.Add(komponente[i].Komponenta.Tip);
                lvKomponente.Items.Add(item);
                //lvKomponente.Items.Add()
            }


            var ime = Reparacija.Korisnik.Ime + " " + Reparacija.Korisnik.Prezime;

            lblServiser.Text = ime;
        }


        private void HidePanel()
        {
            pnlLista.Visible = false;
        }

        private void ShowHidePanel()
        {
            if (pnlLista.Visible)
                pnlLista.Visible = false;
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
            showPanel(pnlLista);
        }
    }
}
