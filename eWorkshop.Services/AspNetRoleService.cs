using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class AspNetRoleService : BaseCRUDService<AspNetRoleVM, object, AspNetRole, AspNetRoleUpsertRequest, AspNetRoleUpsertRequest>, IAspNetRoleService
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
    }
}
