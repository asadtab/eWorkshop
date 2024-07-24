using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class TipUredjajaService : BaseCRUDService<TipUredjajaVM, object, TipUredjaja, TipUredjajaUpsertRequest, TipUredjajaUpsertRequest>, ITipUredjajaService
    {
        public TipUredjajaService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
