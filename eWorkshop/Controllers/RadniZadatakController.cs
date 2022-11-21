using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class RadniZadatakController : BaseCRUDController<RadniZadatakVM, object, RadniZadatakUpsertRequest, RadniZadatakUpsertRequest>
    {
        public RadniZadatakController(IRadniZadatakService service) : base(service)
        {

        }
    }
}
