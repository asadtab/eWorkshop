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
    public class ScopesService : BaseCRUDService<ScopesVM, ApiScopesSearchObject, ApiScope, ScopesUpsertRequest, ScopesUpsertRequest>, IScopesService
    {
        public ScopesService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<ApiScope> AddFilter(IQueryable<ApiScope> query, ApiScopesSearchObject search = null)
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
