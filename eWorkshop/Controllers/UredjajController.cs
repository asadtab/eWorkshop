using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UredjajController : BaseCRUDController<UredjajVM, UredjajSearchObject, UredjajUpsertRequest, UredjajUpsertRequest>
    {
        public UredjajController(IUredjajService service) : base(service)
        {

        }

    }
}
