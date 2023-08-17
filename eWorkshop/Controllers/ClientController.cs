using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;
using eWorkshop.Services.IDS;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : BaseCRUDController<ClientVM, object, ClientInsertRequest, object>
    {
        public ClientController(IClientService service) : base(service)
        {
        }
    }
}
