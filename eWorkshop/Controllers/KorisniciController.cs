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
    public class KorisniciController : BaseCRUDController<KorisniciVM, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        private IKorisniciService KorisniciService { get; set; }

        public KorisniciController(IKorisniciService service) : base(service)
        {
            KorisniciService = service;
        }

       
    }
}
