using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class StaniceUredjajController : BaseCRUDController<StaniceUredjajVM, StaniceUredjajSearchObject, StaniceUredjajUpsertRequest, StaniceUredjajUpsertRequest>
    {
        public StaniceUredjajController(IStaniceUredjajService service) : base(service)
        {
        }
    }
}
