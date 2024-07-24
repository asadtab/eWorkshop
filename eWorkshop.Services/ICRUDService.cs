using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch>
        where TModel : class where TSearch : class where TInsert : class where TUpdate : class  
    {
        TModel Insert(TInsert insert);
        TModel Update(int id, TUpdate update);

        TModel Delete(int id);
        
    }
}
