using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using eWorkshop.Services.IDS;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientScopeController : BaseCRUDController<ClientScopeVM, ApiScopesSearchObject, ClientScopeUpsertRequest, ClientScopeUpsertRequest>
    {
        public ClientScopeController(IClientScopeService service) : base(service)
        {
        }
    }
}
