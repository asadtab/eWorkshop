using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparacijaController : BaseCRUDController<ServisVM, ReparacijaSearchObject, ServisInsertRequest, ServisUpdateRequest>
    {
        IServisAdapter ServisAdapter { get; set; }
        public ReparacijaController(IReparacijaService service, IServisAdapter servisAdapter) : base(service)
        {
            ServisAdapter = servisAdapter;
        }

        [HttpGet("IzvrseniServis")]
        public ActionResult<List<ServisIzvrsenFlutterVM>> IzvrseniServis(int id)
        {
            return ServisAdapter.Servis(id);
        }
    }
}
