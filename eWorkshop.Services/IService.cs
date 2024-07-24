using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IService<TModel, TSearch> where TModel : class where TSearch : class 
    {
        IEnumerable<TModel> Get(TSearch search = null);
        TModel GetById(int id);
    }
}
