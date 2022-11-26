using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;

namespace eWorkshop.Controllers
{
    public class ServisIzvrsenController : BaseCRUDController<ServisIzvrsenVM, object, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>
    {
        public ServisIzvrsenController(IServisIzvrsenService service) : base(service)
        {
        }
    }
}
