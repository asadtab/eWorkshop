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

namespace eWorkshop.Services.IDS
{
    public class ClientGrantTypeService : BaseCRUDService<ClientGrantTypeVM, ClientGrantTypeSearchObject, ClientGrantType, ClientGrantTypeUpsertRequest, ClientGrantTypeUpsertRequest>, IClientGrantTypeService
    {
        public ClientGrantTypeService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<ClientGrantType> AddFilter(IQueryable<ClientGrantType> query, ClientGrantTypeSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && search.ClientId != 0)
                filter = filter.Where(x => x.ClientId == search.ClientId);

            return filter;
        }
    }
}
