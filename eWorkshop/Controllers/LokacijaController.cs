using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class LokacijaController : BaseCRUDController<LokacijaVM, object, LokacijaUpsertRequest, LokacijaUpsertRequest>
    {
        public LokacijaController(ILokacijaService service) : base(service)
        {
        }
    }
}
