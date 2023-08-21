using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class AspNetUserController : BaseCRUDController<AspNetUserVM, object, AspNetUserInsertRequest, AspNetUserInsertRequest>
    {
        public AspNetUserController(IAspNetUserService service) : base(service)
        {
        }
    }
}
