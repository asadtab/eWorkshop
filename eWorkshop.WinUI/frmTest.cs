using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using eWorkshop.Model;
using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.UserControls;

namespace eWorkshop.WinUI
{
    public partial class frmTest : Form
    {
        APIService zadatak = new APIService("RadniZadatak");
        APIService zadatakUredjaj = new APIService("RadniZadatakUredjaj");
        public frmTest()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private async void frmTest_Load(object sender, EventArgs e)
        {
            var getZadaci = await zadatak.Get<List<RadniZadatakVM>>();
            var getZadatakUredjaj = await zadatakUredjaj.Get<List<RadniZadatakUredjajVM>>();

            int x = 0;
            int y = 0;

            for (int i = 0; i < getZadaci.Count; i++)
            {
                var control = new RadniZadaciUserControl(getZadatakUredjaj.Where(x => x.RadniZadatakId == getZadaci[i].RadniZadatakId).ToList());
                control.Location = new Point(x, y);

                panel.Controls.Add(control);
                y += control.Height;
            }
        }
    }
}
