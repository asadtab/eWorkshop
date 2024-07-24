using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using eWorkshop.Services.RadniZadatakStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class StaniceService: BaseCRUDService<StaniceVM, object, Stanice, StaniceUpsertRequest, StaniceUpsertRequest>, IStaniceService
    {
        public StaniceService(_190128Context context, IMapper mapper, BaseState baseState) : base(context, mapper)
        {
            
        }
    }
}
