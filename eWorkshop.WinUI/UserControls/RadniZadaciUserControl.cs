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
        public RadniZadaciUserControl()
        {
            InitializeComponent();
        }

        public RadniZadaciUserControl(List<RadniZadatakUredjajVM> radniZadatak = null) : this()
        {
            double zavrseniUredjaji = 0;
            if (radniZadatak != null)
            {
                gbZadatak.Text = radniZadatak.ElementAt(0).RadniZadatak.Naziv;
                //linkUredjaji.Text = string.Join(", ", radniZadatak.Select(x => x.UredjajId));
                for (int i = 0; i < radniZadatak.Count; i++)
                {
                    string infoUredjaj = radniZadatak[i].UredjajId + " - " + radniZadatak[i].Uredjaj.Tip.Naziv;

                    if (radniZadatak[i].Uredjaj.Status == "fix")
                        zavrseniUredjaji++;

                    lbUredjaji.Items.Add(infoUredjaj);
                }

                double ukupno = radniZadatak.Count;

                double procenat = zavrseniUredjaji / ukupno;

                int rezultat = (int)(procenat * 100);

                pbProcenatZavrsenihUredjaja.Value = rezultat;
            }
        }
    }
}
 