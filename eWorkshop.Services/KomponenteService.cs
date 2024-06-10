using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class KomponenteService : BaseCRUDService<KomponenteVM, KomponenteSearchObject, Komponente, KomponenteUpsertRequest, KomponenteUpsertRequest>, IKomponenteService
    {
        public IServisIzvrsenService ServisIzvrsen { get; set; }
        public IUredjajService UredjajService { get; set; }
        public KomponenteService(_190128Context context, IMapper mapper, IServisIzvrsenService servisIzvrsen, IUredjajService uredjajService) : base(context, mapper)
        {
            ServisIzvrsen = servisIzvrsen;
            UredjajService = uredjajService;
        }

        public override IQueryable<Komponente> AddFilter(IQueryable<Komponente> query, KomponenteSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(!string.IsNullOrEmpty(search.Tip))
            {
                filter = filter.Where(x => x.Tip.ToLower() == search.Tip.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                filter = filter.Where(x => x.Naziv.ToLower() == search.Naziv.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Opis))
            {
                filter = filter.Where(x => x.Opis.ToLower() == search.Opis.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Vrijednost))
            {
                filter = filter.Where(x => x.Vrijednost.ToLower() == search.Vrijednost.ToLower());
            }

           

            return filter;
        }


    }
}
