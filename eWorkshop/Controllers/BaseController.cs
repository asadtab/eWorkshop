using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TModel, TSearch> : ControllerBase where TModel : class where TSearch : class
    {
        public IService<TModel, TSearch> Service { get; set; }

        public BaseController(IService<TModel, TSearch> service)
        {
            Service = service;
        }
    }
}
