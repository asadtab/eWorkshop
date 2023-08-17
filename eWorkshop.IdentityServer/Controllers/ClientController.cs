using Duende.IdentityServer.EntityFramework.Entities;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.IDS;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController: ControllerBase
    {
        public IClientService ClientService { get; set; } 

        public ClientController(IClientService clientService)
        {
            ClientService = clientService;
        }

        [HttpPost]
        public ClientVM Dodaj(ClientInsertRequest request)
        {
            return ClientService.Insert(request);
        }
    }
}
