using AutoMapper;
using Duende.IdentityServer.Extensions;
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

        public override void BeforeInsert(UlogeUpsertRequest insert, Uloge entity)
        {
            if (string.IsNullOrEmpty(insert.Name))
            {
                throw new Exception("Naziv uloge ne smije biti prazan");
            }

            var uloga = Context.Uloge.Where(x => x.NormalizedName == insert.Name.ToUpper()).FirstOrDefault();

            if (uloga is not null)
            {
                throw new Exception("Uloga već postoji");
            }

            entity.NormalizedName = insert.Name.ToUpper();
        }

        public override IQueryable<Uloge> AddFilter(IQueryable<Uloge> query, UlogeSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && !string.IsNullOrEmpty(search.Naziv))
                filter = filter.Where(x => x.NormalizedName.Contains(search.Naziv.ToUpper()));

            return filter;
        }
    }
}
