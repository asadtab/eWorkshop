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
    public class KomponenteService : BaseCRUDService<KomponenteVM, object, Komponente, KomponenteUpsertRequest, KomponenteUpsertRequest>, IKomponenteService
    {
        public KomponenteService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
