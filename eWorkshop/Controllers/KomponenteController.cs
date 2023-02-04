using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class KomponenteController : BaseCRUDController<KomponenteVM, KomponenteSearchObject, KomponenteUpsertRequest, KomponenteUpsertRequest>
    {
        public KomponenteController(IKomponenteService service) : base(service)
        {
        }
    }
}
