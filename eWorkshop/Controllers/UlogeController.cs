using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UlogeController : BaseCRUDController<UlogeVM, UlogeSearchObject, UlogeUpsertRequest, UlogeUpsertRequest>
    {
        public UlogeController(IUlogeService service) : base(service)
        {
        }
    }
}
