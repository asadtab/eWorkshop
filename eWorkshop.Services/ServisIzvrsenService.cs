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
    public class ServisIzvrsenService : BaseCRUDService<ServisIzvrsenVM, object, IzvrseniServi, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>, IServisIzvrsenService
    {
        public ServisIzvrsenService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
