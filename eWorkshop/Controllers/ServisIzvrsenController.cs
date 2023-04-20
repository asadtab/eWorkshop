using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{

    public class ServisIzvrsenController : BaseCRUDController<ServisIzvrsenVM, ServisIzvrsenSearchObject, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>
    {
        IServisIzvrsenService ServisIzvrsenService { get; set; }
        public ServisIzvrsenController(IServisIzvrsenService service) : base(service)
        {
            ServisIzvrsenService = service;
        }

        [HttpGet("Komponente")]
        public ActionResult<List<KomponenteVM>> Komponente(string? TipUredjajaNaziv, int UredjajId)
        {
            return ServisIzvrsenService.PreporuciKomponentu(TipUredjajaNaziv, UredjajId);
        }
    }
}
