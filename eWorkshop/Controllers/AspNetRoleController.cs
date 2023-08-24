using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class AspNetRoleController : BaseCRUDController<AspNetRoleVM, object, AspNetRoleUpsertRequest, AspNetRoleUpsertRequest>
    {
        public AspNetRoleController(IAspNetRoleService service) : base(service)
        {
        }
    }
}
