using AutoMapper;
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
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Uredjaj, UredjajVM>();
            CreateMap<Servi, ServisVM>();
            CreateMap<RadniZadatak, RadniZadatakVM>();
            CreateMap<Korisnici, KorisniciVM>();
            CreateMap<Komponente, KomponenteVM>();
            CreateMap<IzvrseniServi, ServisIzvrsenVM>();
            CreateMap<TipUredjaja, TipUredjajaVM>();
            CreateMap<RadniZadatakUredjaj, RadniZadatakUredjajVM>();
            CreateMap<RadniZadatakUredjaj, RadniZadatakUredjajBasicVM>();
            CreateMap<Lokacija, LokacijaVM>();

            CreateMap<KorisniciUloge, KorisniciUlogeVM>();
            CreateMap<Uloge, UlogeVM>();

            CreateMap<UredjajUpsertRequest, Uredjaj>();
            CreateMap<ServisInsertRequest, Servi>();
            CreateMap<ServisUpdateRequest, Servi>();
            CreateMap<RadniZadatakUpsertRequest, RadniZadatak>();
            CreateMap<KorisniciInsertRequest, Korisnici>();
            CreateMap<KorisniciUpdateRequest, Korisnici>();
            CreateMap<ServisIzvrsenUpsertRequest, IzvrseniServi>();
            CreateMap<KomponenteUpsertRequest, Komponente>(); 
            CreateMap<TipUredjajaUpsertRequest, TipUredjaja>(); 
            CreateMap<RadniZadatakUredjajUpsertRequest, RadniZadatakUredjaj>(); 
        }
    }
}
