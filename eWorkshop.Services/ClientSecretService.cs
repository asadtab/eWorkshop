using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class ClientSecretService : BaseCRUDService<ClientSecretsVM, ClientSecretSearchObject, ClientSecret, ClientSecretUpsertRequest, ClientSecretUpsertRequest>, IClientSecretService
    {
        public ClientSecretService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<ClientSecret> AddFilter(IQueryable<ClientSecret> query, ClientSecretSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && search.ClientId > 0)
            {
                filter = filter.Where(x => x.ClientId == search.ClientId);
            }

            return filter;
        }
    }
}
