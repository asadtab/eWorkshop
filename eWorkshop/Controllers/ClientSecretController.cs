using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class ClientSecretController : BaseCRUDController<ClientSecretsVM, ClientSecretSearchObject, ClientSecretUpsertRequest, ClientSecretUpsertRequest>
    {
        public ClientSecretController(IClientSecretService service) : base(service)
        {
        }
    }
}
