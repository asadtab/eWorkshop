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

/*        [HttpPut]
        public RadniZadatakUredjajVM Dodaj([FromBody] RadniZadatakUredjajUpsertRequest request)
        {
            return RadniZadatakUredjajService.Dodaj(request);
        }*/




        [HttpDelete("{id}")]
        public override ActionResult Delete(int id)
        {
            var uredjaj = Service.GetById(id);

            UredjajService.VratiIzTaska(uredjaj.UredjajId);

            return base.Delete(id);
        }
    }
}
