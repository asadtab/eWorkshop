using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using eWorkshop.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class KorisniciController : BaseCRUDController<KorisniciVM, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public KorisniciController(IKorisniciService service) : base(service)
        {

        }
    }
}
