using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch> 
        where TModel : class where TSearch : class where TInsert : class where TUpdate : class 
    {
        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base (service)
        {

        }

        [HttpPost]
        public virtual TModel Insert ([FromBody] TInsert insert)
        {
            var result = ((ICRUDService<TModel, TSearch, TInsert, TUpdate>)this.Service).Insert(insert);

            return result;
        }

        [HttpGet]
        public IEnumerable<TModel> Get([FromQuery] TSearch search = null)
        {
            return Service.Get(search);
        }

        [HttpGet("{id}")]
        public TModel GetById(int id)
        {
            return Service.GetById(id);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, [FromBody] TUpdate update)
        {
            var result = ((ICRUDService<TModel, TSearch, TInsert, TUpdate>)this.Service).Update(id, update);

            return result;
        }
    }
}
