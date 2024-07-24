using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Model;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class StaniceController: BaseCRUDController<StaniceVM, object, StaniceUpsertRequest, StaniceUpsertRequest>
    {
        public StaniceController(IStaniceService service) : base(service)
        {
            
        }
    }
}
