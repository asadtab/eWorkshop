using eWorkshop.Model;
using eWorkshop.WinUI.Service;
using Microsoft.Extensions.Options;
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
        private readonly IServiceProvider ServiceProvider;
        private readonly ITokenService TokenService;

        public List<RadniZadatakUredjajVM> RadniZadatak { get; set; } = new List<RadniZadatakUredjajVM>();
        public double Ukupno { get; set; }
        public double Progres { get; set; }
        public FormControl FormControl { get; set; } = new FormControl();
        public RadniZadaciUserControl(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        public RadniZadaciUserControl(IServiceProvider serviceProvider, ITokenService tokenService, List<RadniZadatakUredjajVM> radniZadatak = null) : this(serviceProvider, tokenService)
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

            frmUredjajDetalji childForm = new frmUredjajDetalji(uredjaj, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            frmRadniZadatakDetalji childForm = new frmRadniZadatakDetalji(RadniZadatak, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }
    }
}
 