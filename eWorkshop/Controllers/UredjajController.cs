using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UredjajController : BaseCRUDController<UredjajVM, UredjajSearchObject, UredjajUpsertRequest, UredjajUpsertRequest>
    {
        public IUredjajService Service { get; set; }
        public IReparacijaService ReparacijaService{ get; set; }
        public IRadniZadatakUredjajService RadniZadatakService { get; set; }

        public UredjajController(IUredjajService service, IReparacijaService reparacijaService, IRadniZadatakUredjajService radniZadatakService) : base(service)
        {
            Service = service;
            ReparacijaService = reparacijaService;
            RadniZadatakService = radniZadatakService;
        }

        [HttpPut("Aktiviraj-Ready-Vrati/{id}")]
        public UredjajVM Aktiviraj(int id)
        {
            return Service.Aktiviraj(id);
        }

        [HttpPut("Servisiraj")]
        public ServisVM Servisiraj(ServisInsertRequest request)
        {
            return ReparacijaService.Insert(request);
        }

        [HttpPut("Posalji/{id}")]
        public void Servisiraj(int id)
        {
           Service.Posalji(id);
        }

        [HttpPut("SpareParts/{id}")]
        public UredjajVM SpareParts(int id)
        {
            return Service.Parts(id);
        }

        [HttpPut("RadniZadatak")]
        public RadniZadatakUredjajBasicVM RadniZadatak([FromBody] RadniZadatakUredjajUpsertRequest request)
        {
            return RadniZadatakService.Dodaj(request);
        }
            
        [HttpPost]
        public override UredjajVM Insert([FromBody] UredjajUpsertRequest insert)
        {
            return Service.Insert(insert);
        }

        [HttpPut("VratiIzTaska/{id}")]
        public UredjajVM VratiIzTaska(int id)
        {
            return Service.VratiIzTaska(id);
        }

        [HttpPut("Deaktiviraj/{id}")]
        public UredjajVM Deaktiviraj(int id)
        {
            return Service.Deaktiviraj(id);
        }

        [HttpGet("Statistika")]
        public StatistikaVM Statistika()
        {
            StatistikaVM statistika = new StatistikaVM();

            List<UredjajVM> uredjaji = Service.Get().ToList();

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
            }

            return statistika;
        }
    }
}
