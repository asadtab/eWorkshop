using eWorkshop.Model.Requests;
using eWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.Services.Database;
using AutoMapper;
using eWorkshop.Model.SearchObject;

namespace eWorkshop.Services.IDS
{
    public class ApiResourceService : BaseCRUDService<ApiResourceVM, ApiResourceSearchObject, ApiResource, ApiResourceUpsertRequest, ApiResourceUpsertRequest>, IApiResourceService
    {
        public ApiResourceService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<ApiResource> AddFilter(IQueryable<ApiResource> query, ApiResourceSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && !string.IsNullOrEmpty(search.Name))
            {
                filter = filter.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search != null && !string.IsNullOrEmpty(search.DisplayName))
            {
                filter = filter.Where(x => x.DisplayName.ToLower().Contains(search.DisplayName.ToLower()));
            }

            return filter;
        }
    }
}
