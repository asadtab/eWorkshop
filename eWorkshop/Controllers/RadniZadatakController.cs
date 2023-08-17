using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadniZadatakController : BaseCRUDController<RadniZadatakVM, RadniZadatakSearchObject, RadniZadatakUpsertRequest, RadniZadatakUpsertRequest>
    {
        public IRadniZadatakService RadniZadatakService { get; set; }
        public RadniZadatakController(IRadniZadatakService service) : base(service)
        {
            RadniZadatakService = service;
        }

        [HttpPost]
        public override RadniZadatakVM Insert([FromBody] RadniZadatakUpsertRequest insert)
        {
            return RadniZadatakService.Insert(insert);
        }

        [HttpPut("Zavrsi/{id}")]
        public RadniZadatakVM Zavrsi(int id)
        {
            return RadniZadatakService.Zavrsi(id);
        }

        [HttpPut("Fakturisi/{id}")]
        public RadniZadatakVM Fakturisi(int id)
        {
            return RadniZadatakService.Fakturisi(id);
        }
    }
}
