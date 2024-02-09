using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class ApiScopesController : BaseCRUDController<ScopesVM, ApiScopesSearchObject, ScopesUpsertRequest, ScopesUpsertRequest>
    {
        public ApiScopesController(IScopesService service) : base(service)
        {
        }
    }
}
