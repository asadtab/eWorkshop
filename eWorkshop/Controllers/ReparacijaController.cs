using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparacijaController : BaseCRUDController<ServisVM, object, ServisInsertRequest, ServisUpdateRequest>
    {
        public ReparacijaController(IReparacijaService service) : base(service)
        {

        }
    }
}
