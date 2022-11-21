using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services;
using eWorkshop.Services.Database;

namespace eWorkshop.Controllers
{
    public class KorisniciController : BaseCRUDController<KorisniciVM, object, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public KorisniciController(IKorisniciService service) : base(service)
        {

        }
    }
}
