using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using eWorkshop.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class ServisIzvrsenService : BaseCRUDService<ServisIzvrsenVM, ServisIzvrsenSearchObject, IzvrseniServi, ServisIzvrsenUpsertRequest, ServisIzvrsenUpsertRequest>, IServisIzvrsenService
    {
        public ServisIzvrsenService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<IzvrseniServi> AddFilter(IQueryable<IzvrseniServi> query, ServisIzvrsenSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search != null && search.ServisId != 0)
                filter = filter.Where(x => x.ServisId == search.ServisId);

            if (search != null && search.UredjajId != 0)
                filter = filter.Where(x => x.Servis.UredjajId == search.UredjajId);

            if (search != null && search.TipUredjajaId != 0)
                filter = filter.Where(x => x.Servis.Uredjaj.TipId == search.TipUredjajaId);

            if (search != null && !string.IsNullOrEmpty(search.TipUredjajaNaziv))
                filter = filter.Where(x => x.Servis.Uredjaj.Tip.Naziv == search.TipUredjajaNaziv);

            if (search.KorisnikId != 0 && search.KorisnikId != null)
                filter = filter.Where(x => x.Servis.KorisnikId == search.KorisnikId);


            return filter;
        }

        public override IQueryable<IzvrseniServi> AddInclude(IQueryable<IzvrseniServi> query, ServisIzvrsenSearchObject search = null)
        {
            query = query.Include("Komponenta");
            query = query.Include("Servis");
            query = query.Include("Servis.RadniZadatak");
            query = query.Include("Servis.Uredjaj");
            query = query.Include("Servis.Uredjaj.Tip");
            query = query.Include("Servis.Korisnik");

            return query;
        }

        public List<KomponenteVM> PreporuciKomponentu(string tip, int uredjajId)
        {
            ServisIzvrsenSearchObject search = new ServisIzvrsenSearchObject();
            search.TipUredjajaNaziv = tip;
            search.UredjajId = uredjajId;

            var list = base.Get(search);

            

            

            var komponente = base.Get(search).Select(x => new KomponenteVM()
            {
                KomponentaId = x?.Komponenta.KomponentaId == null ? 0 : x.Komponenta.KomponentaId,
                Naziv = x?.Komponenta?.Naziv == null ? "" : x.Komponenta.Naziv,
                Opis = x?.Komponenta?.Opis == null ? "" : x.Komponenta.Opis,
                Tip = x?.Komponenta?.Tip == null ? "" : x.Komponenta.Tip,
                Vrijednost = x?.Komponenta?.Vrijednost == null ? "" : x.Komponenta.Vrijednost
            }).DistinctBy(x => x?.KomponentaId).ToList();

            return komponente;
        }

    }
}
