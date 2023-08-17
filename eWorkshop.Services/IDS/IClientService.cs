using eWorkshop.Model;
using eWorkshop.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.IDS
{
    public interface IClientService: ICRUDService<ClientVM, object, ClientInsertRequest, object>
    {
    }
}
