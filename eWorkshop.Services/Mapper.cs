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

            CreateMap<UredjajUpsertRequest, Uredjaj>();
            CreateMap<ServisInsertRequest, Servi>();
            CreateMap<ServisUpdateRequest, Servi>();
            CreateMap<RadniZadatakUpsertRequest, RadniZadatak>();
            CreateMap<KorisniciInsertRequest, Korisnici>();
            CreateMap<KorisniciUpdateRequest, Korisnici>();
            
        }
    }
}
