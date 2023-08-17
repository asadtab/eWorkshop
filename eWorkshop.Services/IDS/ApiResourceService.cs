using eWorkshop.Model.Requests;
using eWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.Services.Database;
using AutoMapper;

namespace eWorkshop.Services.IDS
{
    public class ApiResourceService : BaseCRUDService<ApiResourceVM, object, ApiResource, ApiResourceUpsertRequest, ApiResourceUpsertRequest>, IApiResourceService
    {
        public ApiResourceService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
