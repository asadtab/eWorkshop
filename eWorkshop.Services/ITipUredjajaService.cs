using eWorkshop.Model;
using eWorkshop.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface ITipUredjajaService : ICRUDService<TipUredjajaVM, object, TipUredjajaUpsertRequest, TipUredjajaUpsertRequest>
    {
        //public List<KomponenteVM> Recommend(int id);

    }

    
}
