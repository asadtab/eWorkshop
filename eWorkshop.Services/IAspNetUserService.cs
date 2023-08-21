using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IAspNetUserService: ICRUDService<AspNetUserVM, object, AspNetUserInsertRequest, AspNetUserInsertRequest>
    {
    }
}
