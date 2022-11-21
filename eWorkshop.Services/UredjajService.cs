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
    public class UredjajService : BaseCRUDService<UredjajVM, UredjajSearchObject, Uredjaj, UredjajUpsertRequest, UredjajUpsertRequest>,
        IUredjajService
    {

        public UredjajService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Uredjaj> AddFilter(IQueryable<Uredjaj> query, UredjajSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search.Tip != 0)
                filter = filter.Where(x => x.TipId == search.Tip);

            if (search.UredjajId != 0)
                filter = filter.Where(x => x.UredjajId == search.UredjajId);

            return filter;
        }

    }
}
