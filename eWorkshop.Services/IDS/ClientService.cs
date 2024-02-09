using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.IDS
{
    public class ClientService : BaseCRUDService<ClientVM, ClientSearchObject, Client, ClientInsertRequest, ClientInsertRequest>, IClientService
    {
        public ClientService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<ClientVM> Get(ClientSearchObject search = null)
        {
            var client = base.Get(search);
            return client;
        }

        public override IQueryable<Client> AddFilter(IQueryable<Client> query, ClientSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search != null && !string.IsNullOrEmpty(search.Naziv))
            {
                filter = filter.Where(x => x.ClientName.ToLower().Contains(search.Naziv.ToLower()));
            }

            if (search != null && !string.IsNullOrEmpty(search.Id))
            {
                filter = filter.Where(x => x.ClientId.ToLower().Contains(search.Id.ToLower()));
            }

            return filter;
        }
    }
}
