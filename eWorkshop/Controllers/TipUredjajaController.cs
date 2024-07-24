using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class TipUredjajaController : BaseCRUDController<TipUredjajaVM, object, TipUredjajaUpsertRequest, TipUredjajaUpsertRequest>
    {
        public TipUredjajaController(ITipUredjajaService service) : base(service)
        {
        }
    }
}
