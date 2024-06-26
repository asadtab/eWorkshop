﻿using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IKomponenteService : ICRUDService<KomponenteVM, KomponenteSearchObject, KomponenteUpsertRequest, KomponenteUpsertRequest>
    {
    }
}
