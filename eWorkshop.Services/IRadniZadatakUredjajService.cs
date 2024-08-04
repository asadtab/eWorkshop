using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IRadniZadatakUredjajService : ICRUDService<RadniZadatakUredjajBasicVM, RadniZadatakUredjajSearchObject, RadniZadatakUredjajUpsertRequest, RadniZadatakUredjajUpsertRequest>
    {
        RadniZadatakUredjajBasicVM Dodaj(RadniZadatakUredjajUpsertRequest request);
        int Progres(int id);
        List<RadniZadatakFlutterVM> RadniZadatakFlutter(int RadniZadatakId, int UredjajId, string status, string lokacija);
    }

}
