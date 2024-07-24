using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class BaseService<TModel, TSearch, TDb> : IService<TModel, TSearch>
        where TModel : class where TSearch : class where TDb : class
    {
        public IMapper Mapper { get; set; }
        public _190128Context Context { get; set; }

        public BaseService(_190128Context context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual IEnumerable<TModel> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>().AsQueryable();

            entity = AddFilter(entity, search);
            entity = AddInclude(entity, search);

            var list = entity.ToList();

            return Mapper.Map<IEnumerable<TModel>>(list);

        }

        public virtual TModel GetById(int id)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);
            

            return Mapper.Map<TModel>(entity);
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }
    }
}
