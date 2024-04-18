using eWorkshop.Model;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatistikaController
    {
        public IUredjajService UredjajService { get; set; }
        public IRadniZadatakService RadniZadatakService { get; set; }
        public IKorisniciService KorisniciService { get; set; }

        public StatistikaController(IUredjajService service, IRadniZadatakService radniZadatakService, IKorisniciService korisniciService)
        {
            UredjajService = service;
            RadniZadatakService = radniZadatakService;
            KorisniciService = korisniciService;
        }

        [HttpGet("Korisnici")]
        public StatistikaVM KorisniciStatistika()
        {
            StatistikaVM statistika = new StatistikaVM();

            List < KorisniciVM > korisnici = KorisniciService.Get().ToList();

            for (int i = 0; i < korisnici.Count; i++)
            {
                statistika.KorisniciUkupno++;
            }

            return statistika;
        }

        [HttpGet("Uredjaji")]
        public List<StatistikaVM> UredjajiStatistika()
        {
            var statistika = new List<StatistikaVM>
            {
                new StatistikaVM()
            };

            List<UredjajVM> uredjaji = UredjajService.Get().ToList();

            for (int i = 0; i < uredjaji.Count(); i++)
            {
                statistika[0].UredjajiUkupno++;

                if (uredjaji[i].Status == "task")
                    statistika[0].RadniZadaciUredjaji++;

                if (uredjaji[i].Status == "fix")
                    statistika[0].ServisiraniUredjaji++;

                if (uredjaji[i].Status == "out")
                    statistika[0].PoslaniUredjaji++;

                if (uredjaji[i].Status == "ready")
                    statistika[0].SpremniUredjaji++;

                if (uredjaji[i].Status == "active")
                    statistika[0].AktivniUredjaji++;

                if (uredjaji[i].Status == "idle")
                    statistika[0].NeaktivniUredjaji++;

                if (uredjaji[i].Status == "parts")
                    statistika[0].RezervniDijeloviUredjaji++;
            }

            List<RadniZadatakVM> zadaci = RadniZadatakService.Get().ToList();

            for (int i = 0; i < zadaci.Count; i++)
            {
                statistika[0].RadniZadaciUkupno++;

                if (zadaci[i].StateMachine == "idle")
                    statistika[0].NeaktivniRadniZadaci++;

                if (zadaci[i].StateMachine == "active")
                    statistika[0].AktivniRadniZadaci++;

                if (zadaci[i].StateMachine == "done")
                    statistika[0].ZavrseniRadniZadaci++;

                if (zadaci[i].StateMachine == "invoice")
                    statistika[0].FakturisaniRadniZadaci++;
            }

            return statistika;
        }

        [HttpGet("RadniZadaci")]
        public StatistikaVM RadniZadaciStatistika()
        {
            StatistikaVM statistika = new StatistikaVM();

            List<RadniZadatakVM> zadaci = RadniZadatakService.Get().ToList();

            for (int i = 0; i < zadaci.Count; i++)
            {
                statistika.RadniZadaciUkupno++;

                if (zadaci[i].StateMachine =="idle")
                    statistika.NeaktivniRadniZadaci++;

                if (zadaci[i].StateMachine == "active")
                    statistika.AktivniRadniZadaci++;

                if (zadaci[i].StateMachine == "done")
                    statistika.ZavrseniRadniZadaci++;

                if (zadaci[i].StateMachine == "invoice")
                    statistika.FakturisaniRadniZadaci++;
            }

            return statistika;
        }
    }
}
