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
        public StatistikaVM UredjajiStatistika()
        {
            StatistikaVM statistika = new StatistikaVM();

            List<UredjajVM> uredjaji = UredjajService.Get().ToList();

            for (int i = 0; i < uredjaji.Count(); i++)
            {
                statistika.UredjajiUkupno++;

                if (uredjaji[i].Status == "task")
                    statistika.RadniZadaciUredjaji++;

                if (uredjaji[i].Status == "fix")
                    statistika.ServisiraniUredjaji++;

                if (uredjaji[i].Status == "out")
                    statistika.PoslaniUredjaji++;

                if (uredjaji[i].Status == "ready")
                    statistika.SpremniUredjaji++;

                if (uredjaji[i].Status == "active")
                    statistika.AktivniUredjaji++;

                if (uredjaji[i].Status == "idle")
                    statistika.NeaktivniUredjaji++;

                if (uredjaji[i].Status == "parts")
                    statistika.RezervniDijeloviUredjaji++;
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
