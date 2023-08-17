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
    public class UlogeService : BaseCRUDService<UlogeVM, UlogeSearchObject, Uloge, UlogeUpsertRequest, UlogeUpsertRequest>, IUlogeService
    {
        public UlogeService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
