using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class KomponenteController : BaseCRUDController<KomponenteVM, object, KomponenteUpsertRequest, KomponenteUpsertRequest>
    {
        public KomponenteController(IKomponenteService service) : base(service)
        {
        }
    }
}
