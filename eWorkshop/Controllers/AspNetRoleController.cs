using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class AspNetRoleController : BaseCRUDController<AspNetRoleVM, AspNetRolesSearchObject, AspNetRoleUpsertRequest, AspNetRoleUpsertRequest>
    {
        public AspNetRoleController(IAspNetRoleService service) : base(service)
        {
        }
    }
}
