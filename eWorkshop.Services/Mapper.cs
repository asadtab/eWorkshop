using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using Microsoft.AspNet.Identity.EntityFramework;
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
            CreateMap<Korisnici, KorisniciVM>();//.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
            CreateMap<Komponente, KomponenteVM>();
            CreateMap<Uloge, UlogeVM>();

            CreateMap<KorisniciUloge, KorisniciUlogeVM>();

            CreateMap<IzvrseniServi, ServisIzvrsenVM>();
            CreateMap<TipUredjaja, TipUredjajaVM>();
            CreateMap<RadniZadatakUredjaj, RadniZadatakUredjajVM>();
            CreateMap<RadniZadatakUredjaj, RadniZadatakUredjajBasicVM>();
            CreateMap<Lokacija, LokacijaVM>();
            CreateMap<Stanice, StaniceVM>();
            CreateMap<StaniceUredjaj, StaniceUredjajVM>()
                .ForMember(
                dest => dest.UredjajId,
                opt => opt.MapFrom(src => src.UredjajId))
                .ForMember(
                dest => dest.Naziv,
                opt => opt.MapFrom(src => src.Stanica.Naziv)
                )
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StanicaId))
                .ForMember(dest => dest.UredjajNaziv, opt => opt.MapFrom(src => src.Uredjaj.Tip.Opis))
                .ForMember(dest => dest.UredjajTip, opt => opt.MapFrom(src => src.Uredjaj.Tip.Naziv))
                .ForMember(dest => dest.Koda, opt => opt.MapFrom(src => src.Uredjaj.Koda))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


            CreateMap<Client, ClientVM>();
            CreateMap<ClientScope, ClientScopeVM>();
            CreateMap<ApiResource, ApiResourceVM>();
            CreateMap<ApiScope, ScopesVM>();


            CreateMap<IdentityUser, AspNetUserVM>();
            CreateMap<ClientScope, ClientScopeVM>();
            CreateMap<ClientClaim, ClientClaimVM>();
            CreateMap<ClientGrantType, ClientGrantTypeVM>();
            CreateMap<ClientSecret, ClientSecretsVM>();


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
            CreateMap<LokacijaUpsertRequest, Lokacija>(); 
            CreateMap<StaniceUpsertRequest, Stanice>(); 
            CreateMap<StaniceUredjajUpsertRequest, StaniceUredjaj>(); 

            CreateMap<ClientInsertRequest, Client>(); 
            CreateMap<ApiResourceUpsertRequest, ApiResource>(); 
            CreateMap<ScopesUpsertRequest, ApiScope>(); 
            CreateMap<ClientScopeUpsertRequest, ClientScope>(); 

            CreateMap<ClientSecretUpsertRequest, ClientSecret>(); 
            CreateMap<ClientClaimUpsertRequest, ClientClaim>(); 
            CreateMap<UlogeUpsertRequest, Uloge>(); 
            CreateMap<ClientGrantTypeUpsertRequest, ClientGrantType>(); 
            CreateMap<ClientSecretUpsertRequest, ClientSecret>(); 

            CreateMap<AspNetUserInsertRequest, IdentityUser>(); 


            CreateMap<ClientUpsertRequest, Client>(); 
        }
    }
}
