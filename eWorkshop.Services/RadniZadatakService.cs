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
    public class RadniZadatakService : BaseCRUDService<RadniZadatakVM, object, RadniZadatak, RadniZadatakUpsertRequest, RadniZadatakUpsertRequest>, IRadniZadatakService
    {
        public RadniZadatakService(_190128Context context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
