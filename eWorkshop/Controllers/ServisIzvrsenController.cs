using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{

    public class ServisIzvrsenController : BaseCRUDController<ServisIzvrsenVM, ServisIzvrsenSearchObject, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>
    {
        public ServisIzvrsenController(IServisIzvrsenService service) : base(service)
        {
        }


    }
}
