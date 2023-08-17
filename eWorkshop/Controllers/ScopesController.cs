using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class ScopesController : BaseCRUDController<ScopesVM, object, ScopesUpsertRequest, ScopesUpsertRequest>
    {
        public ScopesController(IScopesService service) : base(service)
        {
        }
    }
}
