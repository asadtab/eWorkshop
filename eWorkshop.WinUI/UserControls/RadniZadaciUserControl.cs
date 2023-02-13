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

namespace eWorkshop.WinUI.UserControls
{
    public partial class RadniZadaciUserControl : UserControl
    {
        public List<RadniZadatakUredjajVM> RadniZadatak { get; set; } = new List<RadniZadatakUredjajVM>();
        public double Ukupno { get; set; }
        public double Progres { get; set; }
        public RadniZadaciUserControl()
        {
            InitializeComponent();
        }

        public RadniZadaciUserControl(List<RadniZadatakUredjajVM> radniZadatak = null) : this()
        {
            RadniZadatak = radniZadatak;

            double zavrseniUredjaji = 0;
            if (radniZadatak != null)
            {
                gbZadatak.Text = radniZadatak.ElementAt(0).RadniZadatak.Naziv;
                //linkUredjaji.Text = string.Join(", ", radniZadatak.Select(x => x.UredjajId));
                for (int i = 0; i < radniZadatak.Count; i++)
                {
                    string infoUredjaj = radniZadatak[i].UredjajId + " - " + radniZadatak[i].Uredjaj.Tip.Naziv;

                    if (radniZadatak[i].Uredjaj.Status == "fix" 
                        || radniZadatak[i].Uredjaj.Status == "ready"
                        || radniZadatak[i].Uredjaj.Status == "out")
                        zavrseniUredjaji++;

                    lbUredjaji.Items.Add(infoUredjaj);
                }

                double ukupno = radniZadatak.Count;
                
                double procenat = zavrseniUredjaji / ukupno;

                int rezultat = (int)(procenat * 100);

                pbProcenatZavrsenihUredjaja.Value = rezultat;

                Ukupno = ukupno;
                Progres = rezultat;
            }
        }

        private void lbUredjaji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lbUredjaji.SelectedItem.ToString();

            int uredjaj = Int32.Parse(selectedItem.Substring(0, selectedItem.IndexOf(" ")));

            frmUredjajDetalji childForm = new frmUredjajDetalji(uredjaj);
            childForm.MdiParent = mdiPocetna.ActiveForm;
            childForm.Text = "Detalji uređaja";
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            frmRadniZadatakDetalji childForm = new frmRadniZadatakDetalji(RadniZadatak);
            childForm.MdiParent = mdiPocetna.ActiveForm;
            childForm.Text = "Radni zadatak";
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
    }
}
 