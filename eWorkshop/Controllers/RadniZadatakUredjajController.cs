using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    public class RadniZadatakUredjajController : BaseCRUDController<RadniZadatakUredjajBasicVM, RadniZadatakUredjajSearchObject, RadniZadatakUredjajUpsertRequest, RadniZadatakUredjajUpsertRequest>
    {
        public IUredjajService UredjajService { get; set; }
        public IRadniZadatakUredjajService RadniZadatakUredjajService { get; set; }
        public RadniZadatakUredjajController(IRadniZadatakUredjajService service, IUredjajService uredjajService, IRadniZadatakUredjajService radniZadatakUredjajService) : base(service)
        {
            UredjajService = uredjajService;
            RadniZadatakUredjajService = radniZadatakUredjajService;
        }

        [HttpDelete("{id}")]
        public override ActionResult Delete(int id)
        {
            var uredjaj = Service.GetById(id);

            UredjajService.VratiIzTaska(uredjaj.UredjajId);

            return base.Delete(id);
        }

        [HttpGet("Progres")]
        public int Progres (int id)
        {
            return RadniZadatakUredjajService.Progres(id);
        }

        [HttpGet("Flutter")]
        public List<RadniZadatakFlutterVM> RadniZadatakFlutter(string? StateMachine, int RadniZadatakId, int UredjajId)
        {
            return RadniZadatakUredjajService.RadniZadatakFlutter(RadniZadatakId, UredjajId, StateMachine);
        }
    }
}
