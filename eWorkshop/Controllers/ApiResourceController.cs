using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;
using eWorkshop.Services.IDS;

namespace eWorkshop.Controllers
{
    public class ApiResourceController : BaseCRUDController<ApiResourceVM, object, ApiResourceUpsertRequest, ApiResourceUpsertRequest>
    {
        public ApiResourceController(IApiResourceService service) : base(service)
        {
        }
    }
}
