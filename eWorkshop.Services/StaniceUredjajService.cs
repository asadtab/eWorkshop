using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class StaniceUredjajService : BaseCRUDService<StaniceUredjajVM, StaniceUredjajSearchObject, StaniceUredjaj, StaniceUredjajUpsertRequest, StaniceUredjajUpsertRequest>, IStaniceUredjajService
    {
        public StaniceUredjajService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<StaniceUredjaj> AddInclude(IQueryable<StaniceUredjaj> query, StaniceUredjajSearchObject search = null)
        {
            query = query.Include("Stanice");
            query = query.Include("Uredjaj");
            query = query.Include("Uredjaj.Tip");


            return query;
        }

        public override IQueryable<StaniceUredjaj> AddFilter(IQueryable<StaniceUredjaj> query, StaniceUredjajSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && search.StanicaId != 0)
                filter = filter.Where(x => x.StanicaId == search.StanicaId);

            if (search != null && search.UredjajId != 0)
                filter = filter.Where(x => x.UredjajId == search.UredjajId);

            return filter;
        }

        public override StaniceUredjajVM? Insert(StaniceUredjajUpsertRequest insert)
        {
            var result = Context.StaniceUredjajs.Where(x => x.UredjajId == insert.UredjajId).FirstOrDefault();

            if (result is null)
            {
                return base.Insert(insert);
            }
            return null;
        }
    }
}
