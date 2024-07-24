using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class BaseCRUDService<TModel, TSearch, TDb, TInsert, TUpdate> : BaseService<TModel, TSearch, TDb>,
        ICRUDService<TModel, TSearch, TInsert, TUpdate>
        where TDb : class where TInsert : class where TUpdate : class where TSearch : class where TModel : class
    {
        public BaseCRUDService(_190128Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public virtual TModel Insert(TInsert insert)
        {
            var set = Context.Set<TDb>();

            TDb entity = Mapper.Map<TDb>(insert);

            BeforeInsert(insert, entity);

            set.Add(entity);

            Context.SaveChanges();
            

            return Mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate update)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
                Mapper.Map(update, entity);
            else
                return null;

            Context.SaveChanges();

            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert insert, TDb entity)
        {

        }

        public virtual TModel Delete(int id)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity == null)
                return null;

            set.Remove(entity);
            Context.SaveChanges();

            return Mapper.Map<TModel>(entity);
        }
    }
}
