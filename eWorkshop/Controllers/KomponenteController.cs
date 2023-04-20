using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using eWorkshop.Services.MLService;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    public class KomponenteController : BaseCRUDController<KomponenteVM, KomponenteSearchObject, KomponenteUpsertRequest, KomponenteUpsertRequest>
    {
        public IKomponenteService KomponenteService { get; set; }
        public KomponenteController(IKomponenteService service) : base(service)
        {
            KomponenteService = service;
        }
        [HttpGet("Recommend")]
        public List<KomponenteVM> Recommend(int id)
        {
            return KomponenteService.Recommend(id);
        }

        [HttpGet("Test")]
        public List<IzvrseniServisEntry> test()
        {
            return KomponenteService.test();
        }
    }
}
