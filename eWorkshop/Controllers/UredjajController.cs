using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UredjajController : BaseCRUDController<UredjajVM, UredjajSearchObject, UredjajUpsertRequest, UredjajUpsertRequest>
    {
        public IUredjajService Service { get; set; }
        public IReparacijaService ReparacijaService{ get; set; }
        public UredjajController(IUredjajService service, IReparacijaService reparacijaService) : base(service)
        {
            Service = service;
            ReparacijaService = reparacijaService;
        }

        [HttpPut("{id}/Aktiviraj-Ready-Vrati")]
        public UredjajVM Aktiviraj(int id)
        {
            return Service.Aktiviraj(id);
        }

        [HttpPut("Servisiraj")]
        public ServisVM Servisiraj(ServisInsertRequest request)
        {
            return ReparacijaService.Insert(request);
        }

        [HttpPut("Posalji")]
        public UredjajLokacijaVM Servisiraj([FromBody]UredjajLokacijaVM uredjajLokacija)
        {
            return Service.Posalji(uredjajLokacija);
        }

        [HttpPut("{id}/SpareParts")]
        public UredjajVM SpareParts(int id)
        {
            return Service.Parts(id);
        }
    }
}
