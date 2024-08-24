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
