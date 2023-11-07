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
    public class AspNetRoleService : BaseCRUDService<AspNetRoleVM, AspNetRolesSearchObject, AspNetRole, AspNetRoleUpsertRequest, AspNetRoleUpsertRequest>, IAspNetRoleService
    {
        public AspNetRoleService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override void BeforeInsert(AspNetRoleUpsertRequest insert, AspNetRole entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.NormalizedName = insert.Name.ToLower();
            base.BeforeInsert(insert, entity);
        }

        public override IQueryable<AspNetRole> AddFilter(IQueryable<AspNetRole> query, AspNetRolesSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && !string.IsNullOrEmpty(search.Name))
                filter = filter.Where(x => x.Name.Contains(search.Name));

            return filter;
        }
    }
}
