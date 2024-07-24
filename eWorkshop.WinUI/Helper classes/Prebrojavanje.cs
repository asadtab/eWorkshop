using eWorkshop.Model;
using eWorkshop.WinUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Helper_classes
{
    public class Prebrojavanje
    {
        APIService UredjajService { get; set; } = new APIService("Uredjaj");
        APIService RadniZadaciService { get; set; } = new APIService("RadniZadatak");
        public int AktivniRadniZadaci { get; set; } = 0;
        public int FakturisaniRadniZadaci { get; set; } = 0;
        public int ZavrseniRadniZadaci { get; set; } = 0;
        public int NeaktivniRadniZadaci { get; set; } = 0;
        public int ServisiraniUredjaji { get; set; } = 0;
        public int AktivniUredjaji { get; set; } = 0;
        public int NeaktivniUredjaji { get; set; } = 0;
        public int PoslaniUredjaji { get; set; } = 0;
        public int UredjajiUkupno { get; set; } = 0;
        public int SpremniUredjaji { get; set; } = 0;
        public int RezervniDijeloviUredjaji { get; set; } = 0;
        public int RadniZadaciUredjaji { get; set; } = 0;

        public Prebrojavanje()
        {
            UredjajPrebrojavanje();
            RadniZadaciPrebrojavanje();
        }


        private async void RadniZadaciPrebrojavanje()
        {
            var radniZadaci = await RadniZadaciService.Get<List<RadniZadatakVM>>();

            for (int i = 0; i < radniZadaci.Count; i++)
            {
                if (radniZadaci[i].StateMachine == "idle")
                    NeaktivniRadniZadaci++;

                if (radniZadaci[i].StateMachine == "active")
                    AktivniRadniZadaci++;

                if (radniZadaci[i].StateMachine == "done")
                    ZavrseniRadniZadaci++;

                if (radniZadaci[i].StateMachine == "invoice")
                    FakturisaniRadniZadaci++;
            }
        }

        public async void UredjajPrebrojavanje()
        {
            var uredjaji = await UredjajService.Get<List<UredjajVM>>();

            for (int i = 0; i < uredjaji.Count; i++)
            {
                UredjajiUkupno++;

                if (uredjaji[i].Status == "task")
                    RadniZadaciUredjaji++;

                if (uredjaji[i].Status == "fix")
                    ServisiraniUredjaji++;

                if (uredjaji[i].Status == "out")
                    PoslaniUredjaji++;

                if (uredjaji[i].Status == "ready")
                    SpremniUredjaji++;

                if (uredjaji[i].Status == "active")
                    AktivniUredjaji++;

            }
        }
    }
}
