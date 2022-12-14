using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IUredjajService : ICRUDService<UredjajVM, UredjajSearchObject, UredjajUpsertRequest, UredjajUpsertRequest>
    {
        UredjajVM Aktiviraj(int id);
        UredjajVM VratiIzTaska(int id);
        //ServisVM Servisiraj(ServisInsertRequest request);
        UredjajLokacijaVM Posalji(UredjajLokacijaVM uredjajLokacija);
        UredjajVM Parts(int id);
        UredjajVM Insert(UredjajUpsertRequest uredjaj);
    }
}
