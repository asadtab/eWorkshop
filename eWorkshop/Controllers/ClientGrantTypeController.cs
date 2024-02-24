using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Model;
using eWorkshop.Services.IDS;

namespace eWorkshop.Controllers
{
    public class ClientGrantTypeController : BaseCRUDController<ClientGrantTypeVM, ClientGrantTypeSearchObject, ClientGrantTypeUpsertRequest, ClientGrantTypeUpsertRequest>
    {
        public ClientGrantTypeController(IClientGrantTypeService service) : base(service)
        {
        }
    }
}
