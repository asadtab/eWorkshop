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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComponentFactory.Krypton.Toolkit;
using eWorkshop.WinUI.UserControls;
using eWorkshop.WinUI.Service;

namespace eWorkshop.WinUI
{
    public partial class frmMain : Form
    {
        APIService zadatak = new APIService("RadniZadatak");
        APIService zadatakUredjaj = new APIService("RadniZadatakUredjaj");
        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            var getZadaci = await zadatak.Get<List<RadniZadatakVM>>();
            var getZadatakUredjaj = await zadatakUredjaj.Get<List<RadniZadatakUredjajVM>>();

            int x = 0;
            int y = 0;

            var RadniZadatakDistinctIdList = getZadatakUredjaj.Select(x => x.RadniZadatakId).Distinct().ToList();
            
            for (int i = 0; i < RadniZadatakDistinctIdList.Count; i++)
            {
                if (getZadaci[i].RadniZadatakId == RadniZadatakDistinctIdList[i])
                {
                    var control = new RadniZadaciUserControl(getZadatakUredjaj.Where(x => x.RadniZadatakId == getZadaci[i].RadniZadatakId).ToList());
                    control.Location = new Point(x, y);

                    flPanel.Controls.Add(control);
                    y += control.Height;
                }
            }
        }
    }
}
