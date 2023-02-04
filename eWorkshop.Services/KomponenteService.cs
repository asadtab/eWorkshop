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
    public class KomponenteService : BaseCRUDService<KomponenteVM, KomponenteSearchObject, Komponente, KomponenteUpsertRequest, KomponenteUpsertRequest>, IKomponenteService
    {
        public KomponenteService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Komponente> AddFilter(IQueryable<Komponente> query, KomponenteSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(!string.IsNullOrEmpty(search.Tip))
            {
                filter = filter.Where(x => x.Tip.ToLower() == search.Tip.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                filter = filter.Where(x => x.Naziv.ToLower() == search.Naziv.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Opis))
            {
                filter = filter.Where(x => x.Opis.ToLower() == search.Opis.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Vrijednost))
            {
                filter = filter.Where(x => x.Vrijednost.ToLower() == search.Vrijednost.ToLower());
            }

            return filter;
        }
    }
}
