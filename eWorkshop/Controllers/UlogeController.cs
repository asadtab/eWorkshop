using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class UlogeController : BaseCRUDController<UlogeVM, UlogeSearchObject, UlogeUpsertRequest, UlogeUpsertRequest>
    {
        public UlogeController(IUlogeService service) : base(service)
        {
        }
    }
}
