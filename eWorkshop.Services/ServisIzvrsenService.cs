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
    public class ServisIzvrsenService : BaseCRUDService<ServisIzvrsenVM, ServisIzvrsenSearchObject, IzvrseniServi, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>, IServisIzvrsenService
    {
        public ServisIzvrsenService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<IzvrseniServi> AddFilter(IQueryable<IzvrseniServi> query, ServisIzvrsenSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search.ServisId != null)
                filter = filter.Where(x => x.ServisId == search.ServisId);

            return filter;
        }
    }
}
