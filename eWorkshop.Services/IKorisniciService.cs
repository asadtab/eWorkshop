using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IKorisniciService : ICRUDService<KorisniciVM, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public Task<KorisniciVM> Register(KorisniciInsertRequest request);
        public Task<KorisniciVM?> UpdatePassword(PromjeniPasswordRequest request);
    }
}
