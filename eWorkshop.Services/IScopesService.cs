using eWorkshop.Model;
using eWorkshop.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IScopesService: ICRUDService<ScopesVM, object, ScopesUpsertRequest, ScopesUpsertRequest>
    {
    }
}
