using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using eWorkshop.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController: ControllerBase
    {
        private readonly IClientStore _clientStore;
        private readonly _190128Context Context;

        public ClientController(IClientStore clientStore, _190128Context context)
        {
            Context = context;
            _clientStore = clientStore;
        }


    }
}
